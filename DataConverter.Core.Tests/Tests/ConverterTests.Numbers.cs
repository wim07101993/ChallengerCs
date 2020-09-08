using System.Linq;

using DataConverter.Core.TestData;

using FluentAssertions;

using NUnit.Framework;

namespace DataConverter.Core.Tests.Tests
{
    public partial class ConverterTests
    {
        #region UShort

        private static readonly SimpleTestCaseCollection getUShortTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.UShort));

        private static readonly SimpleTestCaseCollection parseUShortTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.UShort, ResizeArray(x.Bytes, 2)));

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

        private static readonly SimpleTestCaseCollection getUIntTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.UInt));

        private static readonly SimpleTestCaseCollection parseUIntTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.UInt, ResizeArray(x.Bytes, 4)));

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

        private static readonly SimpleTestCaseCollection getULongTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.ULong));

        private static readonly SimpleTestCaseCollection parseULongTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.ULong, ResizeArray(x.Bytes, 8)));

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

        private static readonly SimpleTestCaseCollection getShortTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.Short));

        private static readonly SimpleTestCaseCollection parseShortTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Short, ResizeArray(x.Bytes, 2)));

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

        private static readonly SimpleTestCaseCollection getIntTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.Int));

        private static readonly SimpleTestCaseCollection parseIntTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Int, ResizeArray(x.Bytes, 4)));

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

        private static readonly SimpleTestCaseCollection getLongTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.Long));

        private static readonly SimpleTestCaseCollection parseLongTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Long, ResizeArray(x.Bytes, 8)));

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

        private static readonly SimpleTestCaseCollection getFloatTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.Float));

        private static readonly SimpleTestCaseCollection parseFloatTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Float, ResizeArray(x.Bytes, 4)));

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

        private static readonly SimpleTestCaseCollection getDoubleTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.Double));

        private static readonly SimpleTestCaseCollection parseDoubleTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Double, ResizeArray(x.Bytes, 8)));

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

        private static readonly SimpleTestCaseCollection getDecimalTestCases
            = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Bytes, x.Decimal));

        private static readonly SimpleTestCaseCollection parseDecimalTestCases
           = new SimpleTestCaseCollection(new MockData(), x => new SimpleTestCase(x.Decimal, ResizeArray(x.Bytes, 16)));

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
