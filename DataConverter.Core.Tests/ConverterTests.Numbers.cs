using System.Linq;

using DataConverter.Core.TestData;

using FluentAssertions;

using NUnit.Framework;

using Testing.Shared;

namespace DataConverter.Core.Tests
{
    public partial class ConverterTests
    {
        #region UShort

        private static readonly SimpleTestCaseCollection<MockData, Example> getUShortTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.UShort));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseUShortTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.UShort, TrimArray(x.Bytes.Take(2).ToArray())));

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
        public void GetUShortTest(string caseKey)
        {
            var (test, solution) = getUShortTestCases.Get<byte[], ushort>(caseKey);
            _ = Converter.GetUShort(test)
                .Should()
                .Be(solution);
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
        public void GetUShortBytesTest(string caseKey)
        {
            var (test, solution) = parseUShortTestCases.Get<ushort, byte[]>(caseKey);
            _ = Converter.GetUShortBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion UShort

        #region UInt

        private static readonly SimpleTestCaseCollection<MockData, Example> getUIntTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.UInt));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseUIntTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.UInt, TrimArray(x.Bytes.Take(4).ToArray())));

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
        public void GetUIntTest(string caseKey)
        {
            var (test, solution) = getUIntTestCases.Get<byte[], uint>(caseKey);
            _ = Converter.GetUInt(test)
                .Should()
                .Be(solution);
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
        public void GetUIntBytesTest(string caseKey)
        {
            var (test, solution) = parseUIntTestCases.Get<uint, byte[]>(caseKey);
            _ = Converter.GetUIntBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion UInt

        #region ULong

        private static readonly SimpleTestCaseCollection<MockData, Example> getULongTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.ULong));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseULongTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.ULong, TrimArray(x.Bytes.Take(8).ToArray())));

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
        public void GetULongTest(string caseKey)
        {
            var (test, solution) = getULongTestCases.Get<byte[], ulong>(caseKey);
            _ = Converter.GetULong(test)
                .Should()
                .Be(solution);
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
        public void GetULongBytesTest(string caseKey)
        {
            var (test, solution) = parseULongTestCases.Get<ulong, byte[]>(caseKey);
            _ = Converter.GetULongBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion ULong

        #region Short

        private static readonly SimpleTestCaseCollection<MockData, Example> getShortTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.Short));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseShortTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Short, TrimArray(x.Bytes.Take(2).ToArray())));

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
        public void GetShortTest(string caseKey)
        {
            var (test, solution) = getShortTestCases.Get<byte[], short>(caseKey);
            _ = Converter.GetShort(test)
                .Should()
                .Be(solution);
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
        public void GetShortBytesTest(string caseKey)
        {
            var (test, solution) = parseShortTestCases.Get<short, byte[]>(caseKey);
            _ = Converter.GetShortBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Short

        #region Int

        private static readonly SimpleTestCaseCollection<MockData, Example> getIntTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.Int));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseIntTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Int, TrimArray(x.Bytes.Take(4).ToArray())));

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
        public void GetIntTest(string caseKey)
        {
            var (test, solution) = getIntTestCases.Get<byte[], int>(caseKey);
            _ = Converter.GetInt(test)
                .Should()
                .Be(solution);
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
        public void GetIntBytesTest(string caseKey)
        {
            var (test, solution) = parseIntTestCases.Get<int, byte[]>(caseKey);
            _ = Converter.GetIntBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Int

        #region Long

        private static readonly SimpleTestCaseCollection<MockData, Example> getLongTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.Long));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseLongTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Long, TrimArray(x.Bytes.Take(8).ToArray())));

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
        public void GetLongTest(string caseKey)
        {
            var (test, solution) = getLongTestCases.Get<byte[], long>(caseKey);
            _ = Converter.GetLong(test)
                .Should()
                .Be(solution);
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
        public void GetLongBytesTest(string caseKey)
        {
            var (test, solution) = parseLongTestCases.Get<long, byte[]>(caseKey);
            _ = Converter.GetLongBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Long

        #region Float

        private static readonly SimpleTestCaseCollection<MockData, Example> getFloatTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.Float));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseFloatTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Float, TrimArray(x.Bytes.Take(4).ToArray())));

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
        public void GetFloatTest(string caseKey)
        {
            var (test, solution) = getFloatTestCases.Get<byte[], float>(caseKey);
            _ = Converter.GetFloat(test)
                .Should()
                .Be(solution);
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
        public void GetFloatBytesTest(string caseKey)
        {
            var (test, solution) = parseFloatTestCases.Get<float, byte[]>(caseKey);
            _ = Converter.GetFloatBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Float

        #region Double

        private static readonly SimpleTestCaseCollection<MockData, Example> getDoubleTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.Double));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseDoubleTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Double, TrimArray(x.Bytes.Take(8).ToArray())));

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
        public void GetDoubleTest(string caseKey)
        {
            var (test, solution) = getDoubleTestCases.Get<byte[], double>(caseKey);
            _ = Converter.GetDouble(test)
                .Should()
                .Be(solution);
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
        public void GetDoubleBytesTest(string caseKey)
        {
            var (test, solution) = parseDoubleTestCases.Get<double, byte[]>(caseKey);
            _ = Converter.GetDoubleBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Double

        #region Decimal

        private static readonly SimpleTestCaseCollection<MockData, Example> getDecimalTestCases
            = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Bytes, x.Decimal));

        private static readonly SimpleTestCaseCollection<MockData, Example> parseDecimalTestCases
           = new SimpleTestCaseCollection<MockData, Example>(new MockData(), x => new SimpleTestCase(x.Decimal, TrimArray(x.Bytes.Take(16).ToArray())));

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.UShort))]
        [TestCase(nameof(MockData.ULong))]
        [TestCase(nameof(MockData.Float))]
        [TestCase(nameof(MockData.Decimal))]
        public unsafe void GetDecimalTest(string caseKey)
        {
            var (test, solution) = getDecimalTestCases.Get<byte[], decimal>(caseKey);
            var dec = Converter.GetDecimal(test);
            if (dec < 10e-9m)
                return;
            var diff = dec - solution;
            _ = diff
                .Should()
                .BeLessThan(dec / 1000);
        }

        [TestCase(nameof(MockData.Zero))]
        [TestCase(nameof(MockData.Decimal))]
        public void GetDecimalBytesTest(string caseKey)
        {
            var (test, solution) = parseDecimalTestCases.Get<decimal, byte[]>(caseKey);
            _ = Converter.GetDecimalBytes(test)
                .Should()
                .BeEquivalentTo(solution);
        }

        #endregion Decimal
    }
}
