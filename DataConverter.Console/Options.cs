using System.Collections.Generic;

using CommandLine;
using CommandLine.Text;

using DataConverter.Core.Converters;

namespace DataConverter.Console
{
    public class Options
    {
        private const string ValueTypePossibilities =
            "- BinaryString\r\n" +
            "- OctalString\r\n" +
            "- DecimalString\r\n" +
            "- HexString\r\n" +
            "- AsciiString\r\n" +
            "- Utf8String\r\n" +
            "- Utf32String\r\n" +
            "- UShort\t(16 bit unsigned integer)\r\n" +
            "- Short\t(16 bit integer)\r\n" +
            "- UInt\t(32 bit unsigned integer)\r\n" +
            "- Int\t(32 bit integer)\r\n" +
            "- ULong\t(64 bit unsigned integer)\r\n" +
            "- Long\t(64 bit integer)\r\n" +
            "- Float\t(32 bit floating point number)\r\n" +
            "- Double\t(64 bit floating point number)\r\n" +
            "- Decimal\t(128 bit floating point number)";

        private const string ConverterTypePossibilities =
            "- Dotnet\tConverter written in the most idiomatic .Net way.\r\n" +
            "- Linq\tConverter written completely in Linq queries.\r\n" +
            "- Performance\tConverter written for the best performance.\r\n" +
            "- Obfuscated\tConverter written to be ununderstandable.\r\n";

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Convert int to hex", new Options 
                {
                    Input = "10", 
                    InputType = ValueType.Int,
                    OutputType = ValueType.HexString
                });
            }
        }

        [Option('i', "input", Required = true,
            HelpText = "Input data to convert.")]
        public string Input { get; set; }

        [Option('t', "type", Required = false, Default = ValueType.HexString,
            HelpText = "Type of the input data.\r\n" + ValueTypePossibilities)]
        public ValueType InputType { get; set; }

        [Option('o', "output", Required = false,
            HelpText = "File to write the output in. (If not passed, the output is printed on console.)")]
        public string Output { get; set; }

        [Option('p', "outputtype", Required = false, Default = ValueType.All,
            HelpText = "Type of the data to convert to.\r\n- All\t\r\n" + ValueTypePossibilities)]
        public ValueType OutputType { get; set; }


        [Option('c', "converter", Required = false, Default = ConverterType.Performace,
            HelpText = "Type of converter to convert with.\r\n" + ConverterTypePossibilities)]
        public ConverterType Converter { get; set; }

        [Option('v', "Verbose", Required = false, Default = false,
            HelpText = "Enables verbose logging.")]
        public bool IsVerbose { get; set; }
    }
}
