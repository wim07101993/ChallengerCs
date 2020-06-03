using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

using DataConverter.Core.Converters;
using DataConverter.Core.TestData;

namespace DataConverter.Core.Benchmarks.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp30, baseline: true)]
    [SimpleJob(RuntimeMoniker.CoreRt30, baseline: true)]
    [SimpleJob(RuntimeMoniker.Mono, baseline: true)]
    [RPlotExporter]
    public class ConverterBenchmarks
    {
        private readonly IConverter _converter = ConverterFactory.Instance.GetConverter();
        private readonly MockData _data = new MockData();

        [Params(1000, 10000)]
        public int n;

        [GlobalSetup]
        public void Setup()
        {
            _binaryStringBytes = _data.BinaryBytes.Bytes;
            _octalStringBytes = _data.OctalBytes.Bytes;
            _decimalStringBytes = _data.DecimalBytes.Bytes;
            _hexStringBytes = _data.DecimalBytes.Bytes;
            _asciiStringBytes = _data.Ascii.Bytes;
            _utf8StringBytes = _data.Utf8.Bytes;
            _utf32StringBytes = _data.Utf32.Bytes;
            _ushortBytes = _data.UShort.Bytes;
            _uintBytes = _data.UInt.Bytes;
            _ulongBytes = _data.ULong.Bytes;
            _shortBytes = _data.Short.Bytes;
            _intBytes = _data.Int.Bytes;
            _longBytes = _data.Long.Bytes;
            _floatBytes = _data.Float.Bytes;
            _doubleBytes = _data.Double.Bytes;
            _decimalBytes = _data.Decimal.Bytes;

            _binaryString = _data.BinaryBytes.ShortBinaryString;
            _octalString = _data.OctalBytes.ShortOctalString;
            _decimalString = _data.DecimalBytes.ShortDecimalString;
            _hexString = _data.DecimalBytes.ShortHexString;
            _asciiString = _data.Ascii.AsciiString;
            _utf8String = _data.Utf8.Utf8String;
            _utf32String = _data.Utf32.Utf32String;
            _ushort = _data.UShort.UShort;
            _uint = _data.UInt.UInt;
            _ulong = _data.ULong.ULong;
            _short = _data.Short.Short;
            _int = _data.Int.Int;
            _long = _data.Long.Long;
            _float = _data.Float.Float;
            _double = _data.Double.Double;
            _decimal = _data.Decimal.Decimal;
        }

        #region from bytes

        private byte[] _binaryStringBytes;
        private byte[] _octalStringBytes;
        private byte[] _decimalStringBytes;
        private byte[] _hexStringBytes;
        private byte[] _asciiStringBytes;
        private byte[] _utf8StringBytes;
        private byte[] _utf32StringBytes;
        private byte[] _ushortBytes;
        private byte[] _uintBytes;
        private byte[] _ulongBytes;
        private byte[] _shortBytes;
        private byte[] _intBytes;
        private byte[] _longBytes;
        private byte[] _floatBytes;
        private byte[] _doubleBytes;
        private byte[] _decimalBytes;

        [Benchmark]
        public string GetBinaryString() => _converter.GetBinaryString(_binaryStringBytes);

        [Benchmark]
        public string GetOctalString() => _converter.GetOctalString(_octalStringBytes);

        [Benchmark]
        public string GetDecimalString() => _converter.GetDecimalString(_decimalStringBytes);

        [Benchmark]
        public string GetHexString() => _converter.GetHexString(_hexStringBytes);

        [Benchmark]
        public string GetAsciiString() => _converter.GetAsciiString(_asciiStringBytes);

        [Benchmark]
        public string GetUtf8String() => _converter.GetUtf8String(_utf8StringBytes);

        [Benchmark]
        public string GetUtf32String() => _converter.GetUtf32String(_utf32StringBytes);

        [Benchmark]
        public ushort GetUShort() => _converter.GetUShort(_ushortBytes);

        [Benchmark]
        public uint GetUInt() => _converter.GetUInt(_uintBytes);

        [Benchmark]
        public ulong GetULong() => _converter.GetULong(_ulongBytes);

        [Benchmark]
        public short GetShort() => _converter.GetShort(_shortBytes);

        [Benchmark]
        public int GetInt() => _converter.GetInt(_intBytes);

        [Benchmark]
        public long GetLong() => _converter.GetLong(_longBytes);

        [Benchmark]
        public float GetFloat() => _converter.GetFloat(_floatBytes);

        [Benchmark]
        public double GetDouble() => _converter.GetDouble(_doubleBytes);

        [Benchmark]
        public decimal GetDecimal() => _converter.GetDecimal(_decimalBytes);

        #endregion from bytes

        #region to bytes

        private string _binaryString;
        private string _octalString;
        private string _decimalString;
        private string _hexString;
        private string _asciiString;
        private string _utf8String;
        private string _utf32String;
        private ushort _ushort;
        private uint _uint;
        private ulong _ulong;
        private short _short;
        private int _int;
        private long _long;
        private float _float;
        private double _double;
        private decimal _decimal;

        [Benchmark]
        public byte[] ToBinaryString() => _converter.ParseBinaryString(_binaryString);

        [Benchmark]
        public byte[] ToOctalString() => _converter.ParseOctalString(_octalString);

        [Benchmark]
        public byte[] ToDecimalString() => _converter.ParseDecimalString(_decimalString);

        [Benchmark]
        public byte[] ToHexString() => _converter.ParseHexString(_hexString);

        [Benchmark]
        public byte[] ToAsciiString() => _converter.GetAsciiBytes(_asciiString);

        [Benchmark]
        public byte[] ToUtf8String() => _converter.GetUtf8Bytes(_utf8String);

        [Benchmark]
        public byte[] ToUtf32String() => _converter.GetUtf32Bytes(_utf32String);

        [Benchmark]
        public byte[] ToUShort() => _converter.GetBytes(_ushort);

        [Benchmark]
        public byte[] ToUInt() => _converter.GetBytes(_uint);

        [Benchmark]
        public byte[] ToULong() => _converter.GetBytes(_ulong);

        [Benchmark]
        public byte[] ToShort() => _converter.GetBytes(_short);

        [Benchmark]
        public byte[] ToInt() => _converter.GetBytes(_int);

        [Benchmark]
        public byte[] ToLong() => _converter.GetBytes(_long);

        [Benchmark]
        public byte[] ToFloat() => _converter.GetBytes(_float);

        [Benchmark]
        public byte[] ToDouble() => _converter.GetBytes(_double);

        [Benchmark]
        public byte[] ToDecimal() => _converter.GetBytes(_decimal);

        #endregion to bytes
    }
}
