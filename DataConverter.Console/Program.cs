using System;
using System.Linq;

using CommandLine;

using Challenger.Core.Converters;

using C = System.Console;
using Challenger.Core.IL;

namespace DataConverter.Console
{
    internal class Program
    {
        private static IConverter converter;
        private static byte[] bytes;

        private static void Main(string[] args)
        {
            var helloWorld = new HelloWorld();

            helloWorld.PrintHelloWorld();
            //_ = Parser.Default.ParseArguments<Options>(args)
            //    .WithParsed(Convert);
        }

        private static void Convert(Options options)
        {
            converter = options.GetConverter();
            if (options.IsVerbose)
                C.WriteLine($"Converter: {options.Converter} => {converter.GetType().Name}");

            if (!Try(() => options.GetBytes(converter), out bytes))
                return;

            if (options.IsVerbose)
            {
                C.Write($"Input: {options.Input} => bytes = [");
                foreach (var b in bytes)
                    C.Write($"{b:X} ");
                C.WriteLine("]");
            }

            if (options.OutputType == ValueType.All)
            {
                PrintAllConvertedValues();
                return;
            }

            var enumValues = Enum
                .GetValues(typeof(ValueType))
                .Cast<ValueType>()
                .Where(x => options.OutputType.HasFlag(x))
                .ToList();

            switch (enumValues.Count)
            {
                case 0:
                    C.WriteLine("Nothing to do...");
                    break;

                case 1:
                    if (options.IsVerbose)
                        C.Write($"{enumValues[0]}: ");
                    C.WriteLine(TryGetConvertedValue(GetConverterMethod(enumValues[0]), bytes));
                    break;

                default:
                    foreach (var enumValue in enumValues)
                        PrintConvertedValue(enumValue);
                    break;
            }
        }

        private static void PrintAllConvertedValues()
        {
            C.WriteLine($"Binary string:\t{TryGetConvertedValue(converter.GetBinaryString, bytes)}");
            C.WriteLine($"Octal string:\t{TryGetConvertedValue(converter.GetOctalString, bytes)}");
            C.WriteLine($"Decimal string:\t{TryGetConvertedValue(converter.GetDecimalString, bytes)}");
            C.WriteLine($"Hex string:\t{TryGetConvertedValue(converter.GetHexString, bytes)}");
            C.WriteLine($"ASCII string:\t{TryGetConvertedValue(converter.GetAsciiString, bytes)}");
            C.WriteLine($"UShort:\t\t{TryGetConvertedValue(converter.GetUShort, bytes)}");
            C.WriteLine($"Short:\t\t{TryGetConvertedValue(converter.GetShort, bytes)}");
            C.WriteLine($"UInt:\t\t{TryGetConvertedValue(converter.GetUInt, bytes)}");
            C.WriteLine($"Int:\t\t{TryGetConvertedValue(converter.GetInt, bytes)}");
            C.WriteLine($"ULong:\t\t{TryGetConvertedValue(converter.GetULong, bytes)}");
            C.WriteLine($"Float:\t\t{TryGetConvertedValue(converter.GetLong, bytes)}");
            C.WriteLine($"Double:\t\t{TryGetConvertedValue(converter.GetDouble, bytes)}");
            C.WriteLine($"Decimal:\t{TryGetConvertedValue(converter.GetDecimal, bytes)}");
        }

        private static void PrintConvertedValue(ValueType valueType)
        {
            C.WriteLine(valueType switch
            {
                ValueType.BinaryString => $"Binary string:\t{TryGetConvertedValue(converter.GetBinaryString, bytes)}",
                ValueType.OctalString => $"Octal string:\t{TryGetConvertedValue(converter.GetOctalString, bytes)}",
                ValueType.DecimalString => $"Decimal string:\t{TryGetConvertedValue(converter.GetDecimalString, bytes)}",
                ValueType.HexString => $"Hex string:\t{TryGetConvertedValue(converter.GetHexString, bytes)}",
                ValueType.AsciiString => $"ASCII string:\t{TryGetConvertedValue(converter.GetAsciiString, bytes)}",
                ValueType.UShort => $"UShort:\t\t{TryGetConvertedValue(converter.GetUShort, bytes)}",
                ValueType.Short => $"Short:\t\t{TryGetConvertedValue(converter.GetShort, bytes)}",
                ValueType.UInt => $"UInt:\t\t{TryGetConvertedValue(converter.GetUInt, bytes)}",
                ValueType.Int => $"Int:\t\t{TryGetConvertedValue(converter.GetInt, bytes)}",
                ValueType.ULong => $"ULong:\t\t{TryGetConvertedValue(converter.GetULong, bytes)}",
                ValueType.Float => $"Float:\t\t{TryGetConvertedValue(converter.GetLong, bytes)}",
                ValueType.Double => $"Double:\t\t{TryGetConvertedValue(converter.GetDouble, bytes)}",
                ValueType.Decimal => $"Decimal:\t{TryGetConvertedValue(converter.GetDecimal, bytes)}",
                _ => $"Unknown output type: {valueType}"
            });
        }

        private static Func<byte[], object> GetConverterMethod(ValueType valueType)
        {
            return valueType switch
            {
                ValueType.BinaryString => converter.GetBinaryString,
                ValueType.OctalString => converter.GetOctalString,
                ValueType.DecimalString => converter.GetDecimalString,
                ValueType.HexString => converter.GetHexString,
                ValueType.AsciiString => converter.GetAsciiString,
                ValueType.UShort => x => converter.GetUShort(x),
                ValueType.Short => x => converter.GetShort(x),
                ValueType.UInt => x => converter.GetUInt(x),
                ValueType.Int => x => converter.GetInt(x),
                ValueType.ULong => x => converter.GetULong(x),
                ValueType.Float => x => converter.GetLong(x),
                ValueType.Double => x => converter.GetDouble(x),
                ValueType.Decimal => x => converter.GetDecimal(x),
                _ => null
            };
        }

        private static string TryGetConvertedValue<T>(Func<byte[], T> convertAction, byte[] bytes)
        {
            try
            {
                return convertAction(bytes).ToString();
            }
            catch
            {
                return "Could not convert value";
            }
        }

        private static bool Try<T>(Func<T> action, out T output, string errorMessage = null)
        {
            T x = default;
            var success = Try(() => x = action(), errorMessage);
            output = x;
            return success;
        }

        private static bool Try(Action action, string errorMessage = null)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception e)
            {
                C.WriteLine(errorMessage ?? e.Message);
                return false;
            }
        }
    }
}
