using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Challenger.Core.Converters;
using Challenger.Shared.ConvertedValueTypes;

namespace Challenger.Shared
{
    public abstract class ConverterViewModelBase : AsyncBindableBase, IConverterViewModel
    {
        /// <summary>Maximum lengt of the data in bytes</summary>
        public const int MaxDataLength = 32;

        private readonly List<IConverter> _converters = new List<IConverter>
        {
            new DotNetConverter(),
            new LinqConverter(),
            new PerformanceConverter(),
            new ObfuscatedConverter(),
        };

        private IConverter _converter;
        private bool _surpressUpdates;

        public ConverterViewModelBase()
        {
            Bits = new Bit[MaxDataLength * 8];
            for (var i = 0; i < Bits.Length; i++)
            {
                var bit = new Bit(i, Bytes);
                bit.PropertyChanged += OnBitChanged;
                Bits[Bits.Length - i - 1] = bit;
            }

            BinaryString = new ConvertedBinaryString(InvokeOnSTAThread);
            OctalString = new ConvertedOctalString(InvokeOnSTAThread);
            DecimalString = new ConvertedDecimalString(InvokeOnSTAThread);
            HexString = new ConvertedHexString(InvokeOnSTAThread);
            AsciiString = new ConvertedAsciiString(InvokeOnSTAThread);
            Utf8String = new ConvertedUtf8String(InvokeOnSTAThread);
            Utf32String = new ConvertedUtf32String(InvokeOnSTAThread);
            UShort = new ConvertedValue<ushort>(InvokeOnSTAThread);
            Short = new ConvertedValue<short>(InvokeOnSTAThread);
            UInt = new ConvertedValue<uint>(InvokeOnSTAThread);
            Int = new ConvertedValue<int>(InvokeOnSTAThread);
            ULong = new ConvertedValue<ulong>(InvokeOnSTAThread);
            Long = new ConvertedValue<long>(InvokeOnSTAThread);
            Float = new ConvertedValue<float>(InvokeOnSTAThread);
            Double = new ConvertedValue<double>(InvokeOnSTAThread);
            Decimal = new ConvertedValue<decimal>(InvokeOnSTAThread);

            BinaryString.OnValueChanged += OnValueChangedAsync;
            OctalString.OnValueChanged += OnValueChangedAsync;
            DecimalString.OnValueChanged += OnValueChangedAsync;
            HexString.OnValueChanged += OnValueChangedAsync;
            AsciiString.OnValueChanged += OnValueChangedAsync;
            Utf8String.OnValueChanged += OnValueChangedAsync;
            Utf32String.OnValueChanged += OnValueChangedAsync;
            UShort.OnValueChanged += OnValueChangedAsync;
            Short.OnValueChanged += OnValueChangedAsync;
            UInt.OnValueChanged += OnValueChangedAsync;
            Int.OnValueChanged += OnValueChangedAsync;
            ULong.OnValueChanged += OnValueChangedAsync;
            Long.OnValueChanged += OnValueChangedAsync;
            Float.OnValueChanged += OnValueChangedAsync;
            Double.OnValueChanged += OnValueChangedAsync;
            Decimal.OnValueChanged += OnValueChangedAsync;

            _surpressUpdates = true;
            Converter = _converters[0];
            _surpressUpdates = false;
        }

        public byte[] Bytes { get; } = new byte[MaxDataLength];

        public Bit[] Bits { get; }

        public int SelectedConverterIndex
        {
            get => _converters.IndexOf(Converter);
            set => Converter = _converters[value];
        }

        public IEnumerable<string> Converters => _converters.Select(x => x.GetType().Name);

        public IConverter Converter
        {
            get => _converter;
            set
            {
                if (!SetProperty(ref _converter, value))
                    return;

                foreach (var v in Values)
                    v.Converter = value;

                OnValueChangedAsync(this, Bytes);
                _ = RaisePropertyChangedAsync(nameof(SelectedConverterIndex));
            }
        }

        public IConvertedValue[] Values => new IConvertedValue[]
        {
            BinaryString,
            OctalString,
            DecimalString,
            HexString,
            AsciiString,
            Utf8String,
            Utf32String,
            UShort,
            Short,
            UInt,
            Int,
            ULong,
            Long,
            Float,
            Double,
            Decimal
        };

        public ConvertedBinaryString BinaryString { get; }
        public ConvertedOctalString OctalString { get; }
        public ConvertedDecimalString DecimalString { get; }
        public ConvertedHexString HexString { get; }
        public ConvertedAsciiString AsciiString { get; }
        public ConvertedUtf8String Utf8String { get; }
        public ConvertedUtf32String Utf32String { get; }
        public ConvertedValue<ushort> UShort { get; }
        public ConvertedValue<short> Short { get; }
        public ConvertedValue<uint> UInt { get; }
        public ConvertedValue<int> Int { get; }
        public ConvertedValue<ulong> ULong { get; }
        public ConvertedValue<long> Long { get; }
        public ConvertedValue<float> Float { get; }
        public ConvertedValue<double> Double { get; }
        public ConvertedValue<decimal> Decimal { get; }

        protected abstract Task InvokeOnSTAThread(Action action);

        protected virtual async void OnValueChangedAsync(object sender, byte[] e)
        {
            if (_surpressUpdates)
                return;
            _surpressUpdates = true;

            if (e.Length > Bytes.Length)
                Array.Copy(e, Bytes, Bytes.Length);
            else
            {
                Array.Copy(e, Bytes, e.Length);
                Array.Clear(Bytes, e.Length, Bytes.Length - e.Length);
            }

            var tasks = Values
                .Where(x => x != sender)
                .Select(x => x.UpdateAsync(Bytes))
                .Concat(Bits.Select(x => InvokeOnSTAThread(x.RaiseValueChanged)));

            await Task.WhenAll(tasks);
            _surpressUpdates = false;
        }

        private void OnBitChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_surpressUpdates)
                return;

            OnValueChangedAsync(this, Bytes);
        }
    }
}
