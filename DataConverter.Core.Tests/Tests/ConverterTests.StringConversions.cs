using DataConverter.Core.TestData;

using FluentAssertions;

using NUnit.Framework;

namespace DataConverter.Core.Tests.Tests
{
    public partial class ConverterTests
    {
        #region Binary string

        private static readonly SimpleTestCaseCollection getBinaryStringTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, @$"({x.BinaryString.Replace(" ", @"[-\. _]")})|({x.ShortBinaryString.Replace(" ", @"[-\. _]")})"));

        private static readonly SimpleTestCaseCollection parseBinaryStringTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.ShortBinaryString, x.Bytes));

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void GetBinaryStringTest(string caseKey)
        {
            var (test, solution) = getBinaryStringTestCases.Get<byte[], string>(caseKey);
            _ = Converter.GetBinaryString(test)
                .Should()
                .MatchRegex(solution);
        }

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void ParseBinaryStringTest(string caseKey)
        {
            var (test, solution) = parseBinaryStringTestCases.Get<string, byte[]>(caseKey);
            _ = Converter.ParseBinaryString(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Binary string

        #region Octal string

        private static readonly SimpleTestCaseCollection getOctalStringTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, $"^(?i)({x.ShortOctalString.Replace(" ", @"[-\. _]")})|({x.OctalString.Replace(" ", @"[-\. _]")})$"));

        private static readonly SimpleTestCaseCollection parseOctalStringTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.ShortOctalString, x.Bytes));

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void GetOctalStringTest(string caseKey)
        {
            var (test, solution) = getOctalStringTestCases.Get<byte[], string>(caseKey);
            _ = Converter.GetOctalString(test)
                .Should()
                .MatchRegex(solution);
        }

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void ParseOctalStringTest(string caseKey)
        {
            var (test, solution) = parseOctalStringTestCases.Get<string, byte[]>(caseKey);
            _ = Converter.ParseOctalString(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Octal string

        #region Decimal string

        private static readonly SimpleTestCaseCollection getDecimalStringTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, $"^(?i)({x.ShortDecimalString.Replace(" ", @"[-\. _]")})|({x.DecimalString.Replace(" ", @"[-\. _]")})$"));

        private static readonly SimpleTestCaseCollection parseDecimalStringTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.ShortDecimalString, x.Bytes));

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void GetDecimalStringTest(string caseKey)
        {
            var (test, solution) = getDecimalStringTestCases.Get<byte[], string>(caseKey);
            _ = Converter.GetDecimalString(test)
                .Should()
                .MatchRegex(solution);
        }

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void ParseDecimalStringTest(string caseKey)
        {
            var (test, solution) = parseDecimalStringTestCases.Get<string, byte[]>(caseKey);
            _ = Converter.ParseDecimalString(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Decimal string

        #region Hex string

        private static readonly SimpleTestCaseCollection getHexStringTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, $"^(?i)({x.ShortHexString.Replace(" ", @"[-\. _]")})|({x.HexString.Replace(" ", @"[-\. _]")})$"));

        private static readonly SimpleTestCaseCollection parseHexStringTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.ShortHexString, x.Bytes));

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void GetHexStringTest(string caseKey)
        {
            var (test, solution) = getHexStringTestCases.Get<byte[], string>(caseKey);
            _ = Converter.GetHexString(test)
                .Should()
                .MatchRegex(solution);
        }

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.FF))]
        [TestCase(nameof(MockData.BinaryBytes))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.UInt))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Short))]
        [TestCase(nameof(MockData.Int))]
        [TestCase(nameof(MockData.Long))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Double))]
        [TestCase(nameof(MockData.Decimal))]
        public void ParseHexStringTest(string caseKey)
        {
            var (test, solution) = parseHexStringTestCases.Get<string, byte[]>(caseKey);
            _ = Converter.ParseHexString(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Hex string

        #region Ascii string

        private static readonly SimpleTestCaseCollection getAsciiStringTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.AsciiString));

        private static readonly SimpleTestCaseCollection parseAsciiStringTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.AsciiString, x.Bytes));

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        public void GetAsciiStringTest(string caseKey)
        {
            var (test, solution) = getAsciiStringTestCases.Get<byte[], string>(caseKey);
            _ = Converter.GetAsciiString(test)
                .Should()
                .Be(solution);
        }

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.OctalBytes))]
        [TestCase(nameof(MockData.DecimalBytes))]
        [TestCase(nameof(MockData.Ascii))]
        [TestCase(nameof(MockData.UShort))]
        public void GetAsciiBytesTest(string caseKey)
        {
            var (test, solution) = parseAsciiStringTestCases.Get<string, byte[]>(caseKey);
            _ = Converter.GetAsciiBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Ascii string
    }
}
