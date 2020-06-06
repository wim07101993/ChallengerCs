using System;

using DataConverter.Core.Converters;

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
                ValueType.Utf8String => converter.GetUtf8Bytes(options.Input),
                ValueType.Utf32String => converter.GetUtf32Bytes(options.Input),
                ValueType.UShort => converter.GetBytes(ushort.Parse(options.Input)),
                ValueType.Short => converter.GetBytes(short.Parse(options.Input)),
                ValueType.UInt => converter.GetBytes(uint.Parse(options.Input)),
                ValueType.Int => converter.GetBytes(int.Parse(options.Input)),
                ValueType.ULong => converter.GetBytes(ulong.Parse(options.Input)),
                ValueType.Float => converter.GetBytes(float.Parse(options.Input)),
                ValueType.Double => converter.GetBytes(double.Parse(options.Input)),
                ValueType.Decimal => converter.GetBytes(decimal.Parse(options.Input)),

                _ => converter.ParseHexString(options.Input),
            };
        }
    }
}
