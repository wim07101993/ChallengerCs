using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using DataConverter.Core.Converters;

using Prism.Mvvm;

namespace DataConverter.Shared
{
    public class ConverterViewModel : BindableBase, IConverterViewModel
    {
        private static readonly List<string> valuePropertyNames = typeof(ConverterViewModel)
            .GetProperties()
            .Select(x => x.Name)
            .Where(x => x != nameof(SelectedConverterIndex) && x != nameof(Converters) && x != nameof(Converter))
            .ToList();

        private readonly List<IConverter> _converters = new List<IConverter>
        {
            new DotNetConverter(),
            new LinqConverter(),
            new PerformanceConverter(),
            new ObfuscatedConverter(),
        };

        private IConverter _converter;
        private byte[] _data = new byte[0];

        public ConverterViewModel()
        {
            _converter = _converters[0];
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

                RaisePropertyChangeds(valuePropertyNames.Concat(new[] { nameof(SelectedConverterIndex) }));
            }
        }

        public string BinaryString
        {
            get => Converter.GetBinaryString(_data);
            set => SetData(value);
        }

        public string OctalString
        {
            get => Converter.GetOctalString(_data);
            set => SetData(value);
        }

        public string DecimalString
        {
            get => Converter.GetDecimalString(_data);
            set => SetData(value);
        }

        public string HexString
        {
            get => Converter.GetHexString(_data);
            set => SetData(value);
        }

        public string AsciiString
        {
            get => Converter.GetAsciiString(_data);
            set => SetData(value);
        }

        public string Utf8String
        {
            get => Converter.GetUtf8String(_data);
            set => SetData(value);
        }

        public string Utf32String
        {
            get => Converter.GetUtf32String(_data);
            set => SetData(value);
        }

        public ushort UShort
        {
            get => Converter.GetUShort(_data);
            set => SetData(value);
        }

        public short Short
        {
            get => Converter.GetShort(_data);
            set => SetData(value);
        }

        public uint UInt
        {
            get => Converter.GetUInt(_data);
            set => SetData(value);
        }

        public int Int
        {
            get => Converter.GetInt(_data);
            set => SetData(value);
        }

        public ulong ULong
        {
            get => Converter.GetULong(_data);
            set => SetData(value);
        }

        public long Long
        {
            get => Converter.GetLong(_data);
            set => SetData(value);
        }

        public float Float
        {
            get => Converter.GetFloat(_data);
            set => SetData(value);
        }

        public double Double
        {
            get => Converter.GetDouble(_data);
            set => SetData(value);
        }

        public decimal Decimal
        {
            get => Converter.GetDecimal(_data);
            set => SetData(value);
        }

        private void RaisePropertyChangeds(IEnumerable<string> valuePropertyNames)
        {
            foreach (var propertyName in valuePropertyNames)
                RaisePropertyChanged(propertyName);
        }

        private void SetData(object value, [CallerMemberName] string settingProperty = null)
        {
            switch (settingProperty)
            {
                case nameof(BinaryString):
                    _data = Converter.ParseBinaryString((string)value);
                    break;

                case nameof(OctalString):
                    _data = Converter.ParseOctalString((string)value);
                    break;

                case nameof(DecimalString):
                    _data = Converter.ParseDecimalString((string)value);
                    break;

                case nameof(HexString):
                    _data = Converter.ParseHexString((string)value);
                    break;

                case nameof(AsciiString):
                    _data = Converter.GetAsciiBytes((string)value);
                    break;

                case nameof(Utf8String):
                    _data = Converter.GetUtf8Bytes((string)value);
                    break;

                case nameof(Utf32String):
                    _data = Converter.GetUtf32Bytes((string)value);
                    break;

                case nameof(UShort):
                    _data = Converter.GetBytes((ushort)value);
                    break;

                case nameof(Short):
                    _data = Converter.GetBytes((short)value);
                    break;

                case nameof(UInt):
                    _data = Converter.GetBytes((uint)value);
                    break;

                case nameof(Int):
                    _data = Converter.GetBytes((int)value);
                    break;

                case nameof(ULong):
                    _data = Converter.GetBytes((ulong)value);
                    break;

                case nameof(Long):
                    _data = Converter.GetBytes((long)value);
                    break;

                case nameof(Float):
                    _data = Converter.GetBytes((float)value);
                    break;

                case nameof(Double):
                    _data = Converter.GetBytes((double)value);
                    break;

                case nameof(Decimal):
                    _data = Converter.GetBytes((decimal)value);
                    break;

                default:
                    break;
            }

            RaisePropertyChangeds(valuePropertyNames);
        }
    }
}
