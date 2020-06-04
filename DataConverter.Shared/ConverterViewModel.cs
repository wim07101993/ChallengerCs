using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

using DataConverter.Core.Converters;
using DataConverter.Shared.ConvertedValueTypes;

using Prism.Mvvm;

using Timer = System.Timers.Timer;

namespace DataConverter.Shared
{
    public class ConverterViewModel : BindableBase, IConverterViewModel
    {
        private readonly object _lock = new object();

        private readonly List<IConverter> _converters = new List<IConverter>
        {
            new DotNetConverter(),
            new LinqConverter(),
            new PerformanceConverter(),
            new ObfuscatedConverter(),
        };

        private readonly Timer _updateDelaytimer = new Timer(500);

        private IConverter _converter;
        private byte[] _data = new byte[0];
        private bool _surpressUpdates;

        public ConverterViewModel()
        {
            BinaryString = new ConvertedBinaryString();
            OctalString = new ConvertedOctalString();
            DecimalString = new ConvertedDecimalString();
            HexString = new ConvertedHexString();
            AsciiString = new ConvertedAsciiString();
            Utf8String = new ConvertedUtf8String();
            Utf32String = new ConvertedUtf32String();
            UShort = new ConvertedValue<ushort>();
            Short = new ConvertedValue<short>();
            UInt = new ConvertedValue<uint>();
            Int = new ConvertedValue<int>();
            ULong = new ConvertedValue<ulong>();
            Long = new ConvertedValue<long>();
            Float = new ConvertedValue<float>();
            Double = new ConvertedValue<double>();
            Decimal = new ConvertedValue<decimal>();

            BinaryString.OnValueChanged += OnValueChanged;
            OctalString.OnValueChanged += OnValueChanged;
            DecimalString.OnValueChanged += OnValueChanged;
            HexString.OnValueChanged += OnValueChanged;
            AsciiString.OnValueChanged += OnValueChanged;
            Utf8String.OnValueChanged += OnValueChanged;
            Utf32String.OnValueChanged += OnValueChanged;
            UShort.OnValueChanged += OnValueChanged;
            Short.OnValueChanged += OnValueChanged;
            UInt.OnValueChanged += OnValueChanged;
            Int.OnValueChanged += OnValueChanged;
            ULong.OnValueChanged += OnValueChanged;
            Long.OnValueChanged += OnValueChanged;
            Float.OnValueChanged += OnValueChanged;
            Double.OnValueChanged += OnValueChanged;
            Decimal.OnValueChanged += OnValueChanged;

            _surpressUpdates = true;
            Converter = _converters[0];
            _surpressUpdates = false;
        }

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

                OnValueChanged(this, _data);
                RaisePropertyChanged(nameof(SelectedConverterIndex));
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

        private void OnValueChanged(object sender, byte[] e)
        {
            if (_surpressUpdates)
                return;

            _data = e;
            lock (_lock)
            {
                if (!_updateDelaytimer.Enabled)
                    _updateDelaytimer.Elapsed += StartUpdateAsync;

                _updateDelaytimer.Enabled = false;
                _updateDelaytimer.Enabled = true;
            }

            void StartUpdateAsync(object timer, ElapsedEventArgs args)
            {
                _updateDelaytimer.Enabled = false;
                _updateDelaytimer.Elapsed -= StartUpdateAsync;
                foreach (var value in Values.Where(x => x != sender))
                    _ = Task.Run(() => value.Update(_data));
            }
        }
    }
}
