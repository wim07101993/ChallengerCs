using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

using Challenger.Core.Converters;
using DataConverter.Core.TestData;

namespace DataConverter.Core.Benchmarks.Benchmarks
{
    /// <summary>Benchmark class that benchmarks all <see cref="IConverter" /> methods.</summary>
    /// <remarks>
    ///     By (un)commenting simple jobs, it is possible to modify on which runtimes the benchmark
    ///     should be done.
    /// </remarks>
    [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [SimpleJob(RuntimeMoniker.CoreRt31)]
    //[SimpleJob(RuntimeMoniker.CoreRt50)]
    //[SimpleJob(RuntimeMoniker.Mono)]
    [RPlotExporter]
    public abstract class ConverterBenchmarks
    {
        /// <summary>List of converters to benchmark.</summary>
        /// <remarks>
        ///     By adding or removing items from this list, it is possible to modify which
        ///     converters the project should benchmark. When editing this list, please make sure
        ///     the <see cref="ParamsAttribute" /> of the <see cref="ConverterIndex" /> property is
        ///     also updated.
        /// </remarks>
        private static readonly IConverter[] converters = new IConverter[]
        {
            new DotNetConverter(),
            new LinqConverter(),
            new PerformanceConverter(),
            new ObfuscatedConverter()
        };

        /// <summary>The mock data that will be used to run the benchmark.</summary>
        private readonly MockData _data = new MockData();

        /// <summary>Amount of runs that should be done.</summary>
        [Params(1000, 10000)]
        public int n;

        /// <summary>
        ///     Index of the converter to use. For each value in the <see cref="ParamsAttribute" />,
        ///     the benchmark will run.
        ///     <para>The index corresponds to the <see cref="converters" /> field.</para>
        /// </summary>
        [Params(0, 1, 2, 3)]
        public int ConverterIndex { get; set; }

        /// <summary>Initializes the benchmark.</summary>
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

        /// <summary>
        ///     To make the benchmark faster comment methods out that should not be benchmarked.
        /// </summary>

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
        public string GetBinaryString() => converters[ConverterIndex].GetBinaryString(_binaryStringBytes);

        [Benchmark]
        public string GetOctalString() => converters[ConverterIndex].GetOctalString(_octalStringBytes);

        [Benchmark]
        public string GetDecimalString() => converters[ConverterIndex].GetDecimalString(_decimalStringBytes);

        [Benchmark]
        public string GetHexString() => converters[ConverterIndex].GetHexString(_hexStringBytes);

        [Benchmark]
        public string GetAsciiString() => converters[ConverterIndex].GetAsciiString(_asciiStringBytes);

        [Benchmark]
        public string GetUtf8String() => converters[ConverterIndex].GetUtf8String(_utf8StringBytes);

        [Benchmark]
        public string GetUtf32String() => converters[ConverterIndex].GetUtf32String(_utf32StringBytes);

        [Benchmark]
        public ushort GetUShort() => converters[ConverterIndex].GetUShort(_ushortBytes);

        [Benchmark]
        public uint GetUInt() => converters[ConverterIndex].GetUInt(_uintBytes);

        [Benchmark]
        public ulong GetULong() => converters[ConverterIndex].GetULong(_ulongBytes);

        [Benchmark]
        public short GetShort() => converters[ConverterIndex].GetShort(_shortBytes);

        [Benchmark]
        public int GetInt() => converters[ConverterIndex].GetInt(_intBytes);

        [Benchmark]
        public long GetLong() => converters[ConverterIndex].GetLong(_longBytes);

        [Benchmark]
        public float GetFloat() => converters[ConverterIndex].GetFloat(_floatBytes);

        [Benchmark]
        public double GetDouble() => converters[ConverterIndex].GetDouble(_doubleBytes);

        [Benchmark]
        public decimal GetDecimal() => converters[ConverterIndex].GetDecimal(_decimalBytes);

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
        public byte[] ToBinaryString() => converters[ConverterIndex].ParseBinaryString(_binaryString);

        [Benchmark]
        public byte[] ToOctalString() => converters[ConverterIndex].ParseOctalString(_octalString);

        [Benchmark]
        public byte[] ToDecimalString() => converters[ConverterIndex].ParseDecimalString(_decimalString);

        [Benchmark]
        public byte[] ToHexString() => converters[ConverterIndex].ParseHexString(_hexString);

        [Benchmark]
        public byte[] ToAsciiString() => converters[ConverterIndex].GetAsciiBytes(_asciiString);

        [Benchmark]
        public byte[] ToUtf8String() => converters[ConverterIndex].GetUtf8Bytes(_utf8String);

        [Benchmark]
        public byte[] ToUtf32String() => converters[ConverterIndex].GetUtf32Bytes(_utf32String);

        [Benchmark]
        public byte[] ToUShort() => converters[ConverterIndex].GetBytes(_ushort);

        [Benchmark]
        public byte[] ToUInt() => converters[ConverterIndex].GetBytes(_uint);

        [Benchmark]
        public byte[] ToULong() => converters[ConverterIndex].GetBytes(_ulong);

        [Benchmark]
        public byte[] ToShort() => converters[ConverterIndex].GetBytes(_short);

        [Benchmark]
        public byte[] ToInt() => converters[ConverterIndex].GetBytes(_int);

        [Benchmark]
        public byte[] ToLong() => converters[ConverterIndex].GetBytes(_long);

        [Benchmark]
        public byte[] ToFloat() => converters[ConverterIndex].GetBytes(_float);

        [Benchmark]
        public byte[] ToDouble() => converters[ConverterIndex].GetBytes(_double);

        [Benchmark]
        public byte[] ToDecimal() => converters[ConverterIndex].GetBytes(_decimal);

        #endregion to bytes
    }
}
