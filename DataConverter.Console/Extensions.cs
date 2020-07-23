using Challenger.Core.Converters;

namespace DataConverter.Console
{
    public static class Extensions
    {
        public static IConverter GetConverter(this Options options)
        {
            return options.Converter switch
            {
                ConverterType.DotNet => new DotNetConverter(),
                ConverterType.Linq => new LinqConverter(),
                ConverterType.Performace => new PerformanceConverter(),
                ConverterType.Obfuscated => new ObfuscatedConverter(),

                _ => new PerformanceConverter()
            };
        }

        public static byte[] GetBytes(this Options options, IConverter converter)
        {
            return options.InputType switch
            {
                ValueType.BinaryString => converter.ParseBinaryString(options.Input),
                ValueType.OctalString => converter.ParseOctalString(options.Input),
                ValueType.DecimalString => converter.ParseDecimalString(options.Input),
                ValueType.HexString => converter.ParseHexString(options.Input),
                ValueType.AsciiString => converter.GetAsciiBytes(options.Input),
                ValueType.UShort => converter.GetUShortBytes(ushort.Parse(options.Input)),
                ValueType.Short => converter.GetShortBytes(short.Parse(options.Input)),
                ValueType.UInt => converter.GetUIntBytes(uint.Parse(options.Input)),
                ValueType.Int => converter.GetIntBytes(int.Parse(options.Input)),
                ValueType.ULong => converter.GetULongBytes(ulong.Parse(options.Input)),
                ValueType.Float => converter.GetFloatBytes(float.Parse(options.Input)),
                ValueType.Double => converter.GetDoubleBytes(double.Parse(options.Input)),
                ValueType.Decimal => converter.GetDecimalBytes(decimal.Parse(options.Input)),

                _ => converter.ParseHexString(options.Input),
            };
        }
    }
}
