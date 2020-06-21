using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

using Challenger.Core.Converters;

using DataConverter.Core.TestData;

namespace Challenger.Wpf.Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    public class ConverterBenchmarks
    {
        private static readonly IConverter[] converters = new IConverter[]
          {
            new DotNetConverter(),
            new LinqConverter(),
            new PerformanceConverter(),
            new ObfuscatedConverter()
          };

        private static readonly MockData data = new MockData();

        [Params(0, 1, 2, 3)]
        public int ConverterIndex { get; set; }

        #region from bytes

        public byte[] BinaryStringBytes => data.BinaryBytes.Bytes;
        public byte[] OctalStringBytes => data.OctalBytes.Bytes;
        public byte[] DecimalStringBytes => data.DecimalBytes.Bytes;
        public byte[] HexStringBytes => data.DecimalBytes.Bytes;
        public byte[] AsciiStringBytes => data.Ascii.Bytes;
        public byte[] UshortBytes => data.UShort.Bytes;
        public byte[] UintBytes => data.UInt.Bytes;
        public byte[] UlongBytes => data.ULong.Bytes;
        public byte[] ShortBytes => data.Short.Bytes;
        public byte[] IntBytes => data.Int.Bytes;
        public byte[] LongBytes => data.Long.Bytes;
        public byte[] FloatBytes => data.Float.Bytes;
        public byte[] DoubleBytes => data.Double.Bytes;
        public byte[] DecimalBytes => data.Decimal.Bytes;

        [Benchmark]
        public string GetBinaryString() => converters[ConverterIndex].GetBinaryString(BinaryStringBytes);

        [Benchmark]
        public string GetOctalString() => converters[ConverterIndex].GetOctalString(OctalStringBytes);

        [Benchmark]
        public string GetDecimalString() => converters[ConverterIndex].GetDecimalString(DecimalStringBytes);

        [Benchmark]
        public string GetHexString() => converters[ConverterIndex].GetHexString(HexStringBytes);

        [Benchmark]
        public string GetAsciiString() => converters[ConverterIndex].GetAsciiString(AsciiStringBytes);

        [Benchmark]
        public ushort GetUShort() => converters[ConverterIndex].GetUShort(UshortBytes);

        [Benchmark]
        public uint GetUInt() => converters[ConverterIndex].GetUInt(UintBytes);

        [Benchmark]
        public ulong GetULong() => converters[ConverterIndex].GetULong(UlongBytes);

        [Benchmark]
        public short GetShort() => converters[ConverterIndex].GetShort(ShortBytes);

        [Benchmark]
        public int GetInt() => converters[ConverterIndex].GetInt(IntBytes);

        [Benchmark]
        public long GetLong() => converters[ConverterIndex].GetLong(LongBytes);

        [Benchmark]
        public float GetFloat() => converters[ConverterIndex].GetFloat(FloatBytes);

        [Benchmark]
        public double GetDouble() => converters[ConverterIndex].GetDouble(DoubleBytes);

        [Benchmark]
        public decimal GetDecimal() => converters[ConverterIndex].GetDecimal(DecimalBytes);

        #endregion from bytes

        #region to bytes

        public string BinaryString => data.BinaryBytes.ShortBinaryString;
        public string OctalString => data.OctalBytes.ShortOctalString;
        public string DecimalString => data.DecimalBytes.ShortDecimalString;
        public string HexString => data.DecimalBytes.ShortHexString;
        public string AsciiString => data.Ascii.AsciiString;
        public ushort Ushort => data.UShort.UShort;
        public uint Uint => data.UInt.UInt;
        public ulong Ulong => data.ULong.ULong;
        public short Short => data.Short.Short;
        public int Int => data.Int.Int;
        public long Long => data.Long.Long;
        public float Float => data.Float.Float;
        public double Double => data.Double.Double;
        public decimal Decimal => data.Decimal.Decimal;

        [Benchmark]
        public byte[] ParseBinaryString() => converters[ConverterIndex].ParseBinaryString(BinaryString);

        [Benchmark]
        public byte[] ParseOctalString() => converters[ConverterIndex].ParseOctalString(OctalString);

        [Benchmark]
        public byte[] ParseDecimalString() => converters[ConverterIndex].ParseDecimalString(DecimalString);

        [Benchmark]
        public byte[] ParseHexString() => converters[ConverterIndex].ParseHexString(HexString);

        [Benchmark]
        public byte[] GetAsciiBytes() => converters[ConverterIndex].GetAsciiBytes(AsciiString);

        [Benchmark]
        public byte[] GetUShortBytes() => converters[ConverterIndex].GetUShortBytes(Ushort);

        [Benchmark]
        public byte[] GetUIntBytes() => converters[ConverterIndex].GetUIntBytes(Uint);

        [Benchmark]
        public byte[] GetULongBytes() => converters[ConverterIndex].GetULongBytes(Ulong);

        [Benchmark]
        public byte[] GetShortBytes() => converters[ConverterIndex].GetShortBytes(Short);

        [Benchmark]
        public byte[] GetIntBytes() => converters[ConverterIndex].GetIntBytes(Int);

        [Benchmark]
        public byte[] GetLongBytes() => converters[ConverterIndex].GetLongBytes(Long);

        [Benchmark]
        public byte[] GetFloatBytes() => converters[ConverterIndex].GetFloatBytes(Float);

        [Benchmark]
        public byte[] GetDoubleBytes() => converters[ConverterIndex].GetDoubleBytes(Double);

        [Benchmark]
        public byte[] GetDecimalBytes() => converters[ConverterIndex].GetDecimalBytes(Decimal);

        #endregion to bytes
    }
}
