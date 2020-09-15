using System.Collections.Generic;

using Challenger.Core.Math;

using FluentAssertions;

using Math.Core.TestData;

using NUnit.Framework;

using Testing.Shared;

namespace Math.Core.Tests
{
    public abstract class CalculatorTests
    {
        protected abstract ICalculator Calculator { get; }

        [SetUp]
        public void Setup()
        {
        }

        #region NextPrime

        private static readonly SimpleTestCaseCollection<CalculatorMockData, PrimeExample> nextPrimeTestCases
            = new SimpleTestCaseCollection<CalculatorMockData, PrimeExample>(
                new CalculatorMockData(), x => new SimpleTestCase(x.PrimeNumber, x.Prime));

        [TestCase(nameof(CalculatorMockData.FirstPrime))]
        [TestCase(nameof(CalculatorMockData.SecondPrime))]
        [TestCase(nameof(CalculatorMockData.ThirdPrime))]
        [TestCase(nameof(CalculatorMockData.FourthPrime))]
        [TestCase(nameof(CalculatorMockData.TwentiethPrime))]
        [TestCase(nameof(CalculatorMockData.EightyThirdPrime))]
        [TestCase(nameof(CalculatorMockData.NineHundrethAndSeventySixthPrime))]
        public void NextPrimeTest(string caseKey)
        {
            var (test, solution) = nextPrimeTestCases.Get<int, int>(caseKey);
            _ = Calculator.NextPrime(test)
                .Should()
                .Be(solution);
        }

        #endregion NextPrime

        #region Fibonacci

        private static readonly SimpleTestCaseCollection<CalculatorMockData, FibonacciExample> fibonacciTestCases
            = new SimpleTestCaseCollection<CalculatorMockData, FibonacciExample>(
                new CalculatorMockData(), x => new SimpleTestCase(null, x.Sequence));

        [TestCase(nameof(CalculatorMockData.Fibonacci))]
        public void FibonacciTest(string caseKey)
        {
            var (_, solution) = fibonacciTestCases.Get<object, List<double>>(caseKey);

            using var enumerator = Calculator.Fibonacci().GetEnumerator();

            foreach (var item in solution)
            {
                if (!enumerator.MoveNext())
                    break;

                _ = item.Should().Be(enumerator.Current);
            }
        }

        #endregion Fibonacci

        #region Sin

        private static readonly DoubleTestCaseCollection<CalculatorMockData, DegreesExample> sinTestCases
            = new DoubleTestCaseCollection<CalculatorMockData, DegreesExample>(
                new CalculatorMockData(), x => new DoubleTestCase(x.Degrees, x.Sine, x.Accuracy));

        [TestCase(nameof(CalculatorMockData.Degrees0))]
        [TestCase(nameof(CalculatorMockData.Degrees20))]
        [TestCase(nameof(CalculatorMockData.Degrees30))]
        [TestCase(nameof(CalculatorMockData.Degrees60))]
        [TestCase(nameof(CalculatorMockData.Degrees80))]
        [TestCase(nameof(CalculatorMockData.Degrees90))]
        [TestCase(nameof(CalculatorMockData.Degrees100))]
        [TestCase(nameof(CalculatorMockData.Degrees220))]
        [TestCase(nameof(CalculatorMockData.Degrees240))]
        [TestCase(nameof(CalculatorMockData.Degrees260))]
        [TestCase(nameof(CalculatorMockData.Degrees340))]
        [TestCase(nameof(CalculatorMockData.Degrees360))]
        [TestCase(nameof(CalculatorMockData.Degrees400))]
        public void SinTest(string caseKey)
        {
            var (test, solution, accuracy) = sinTestCases.Get<double>(caseKey);
            _ = Calculator.Sin(test)
                .Should()
                .BeApproximately(solution, accuracy);
        }

        #endregion Sin

        #region Cos

        private static readonly DoubleTestCaseCollection<CalculatorMockData, DegreesExample> cosTestCases
            = new DoubleTestCaseCollection<CalculatorMockData, DegreesExample>(
                new CalculatorMockData(), x => new DoubleTestCase(x.Degrees, x.Cosine, x.Accuracy));

        [TestCase(nameof(CalculatorMockData.Degrees0))]
        [TestCase(nameof(CalculatorMockData.Degrees20))]
        [TestCase(nameof(CalculatorMockData.Degrees30))]
        [TestCase(nameof(CalculatorMockData.Degrees60))]
        [TestCase(nameof(CalculatorMockData.Degrees80))]
        [TestCase(nameof(CalculatorMockData.Degrees90))]
        [TestCase(nameof(CalculatorMockData.Degrees100))]
        [TestCase(nameof(CalculatorMockData.Degrees220))]
        [TestCase(nameof(CalculatorMockData.Degrees240))]
        [TestCase(nameof(CalculatorMockData.Degrees260))]
        [TestCase(nameof(CalculatorMockData.Degrees340))]
        [TestCase(nameof(CalculatorMockData.Degrees360))]
        [TestCase(nameof(CalculatorMockData.Degrees400))]
        public void CosTest(string caseKey)
        {
            var (test, solution, accuracy) = cosTestCases.Get<double>(caseKey);
            _ = Calculator.Cos(test)
                .Should()
                .BeApproximately(solution, accuracy);
        }

        #endregion Cos

        #region Tan

        private static readonly DoubleTestCaseCollection<CalculatorMockData, DegreesExample> tanTestCases
            = new DoubleTestCaseCollection<CalculatorMockData, DegreesExample>(
                new CalculatorMockData(), x => new DoubleTestCase(x.Degrees, x.Tan, x.Accuracy));

        [TestCase(nameof(CalculatorMockData.Degrees0))]
        [TestCase(nameof(CalculatorMockData.Degrees20))]
        [TestCase(nameof(CalculatorMockData.Degrees30))]
        [TestCase(nameof(CalculatorMockData.Degrees60))]
        [TestCase(nameof(CalculatorMockData.Degrees80))]
        [TestCase(nameof(CalculatorMockData.Degrees90))]
        [TestCase(nameof(CalculatorMockData.Degrees100))]
        [TestCase(nameof(CalculatorMockData.Degrees220))]
        [TestCase(nameof(CalculatorMockData.Degrees240))]
        [TestCase(nameof(CalculatorMockData.Degrees260))]
        [TestCase(nameof(CalculatorMockData.Degrees340))]
        [TestCase(nameof(CalculatorMockData.Degrees360))]
        [TestCase(nameof(CalculatorMockData.Degrees400))]
        public void TanTest(string caseKey)
        {
            var (test, solution, accuracy) = tanTestCases.Get<double>(caseKey);
            _ = Calculator.Tan(test)
                .Should()
                .BeApproximately(solution, accuracy);
        }

        #endregion Tan

        #region DegToRad

        private static readonly DoubleTestCaseCollection<CalculatorMockData, DegreesExample> degToRadTestCases
            = new DoubleTestCaseCollection<CalculatorMockData, DegreesExample>(
                new CalculatorMockData(), x => new DoubleTestCase(x.Degrees, x.Radians, x.Accuracy));

        [TestCase(nameof(CalculatorMockData.Degrees0))]
        [TestCase(nameof(CalculatorMockData.Degrees20))]
        [TestCase(nameof(CalculatorMockData.Degrees30))]
        [TestCase(nameof(CalculatorMockData.Degrees60))]
        [TestCase(nameof(CalculatorMockData.Degrees80))]
        [TestCase(nameof(CalculatorMockData.Degrees90))]
        [TestCase(nameof(CalculatorMockData.Degrees100))]
        [TestCase(nameof(CalculatorMockData.Degrees220))]
        [TestCase(nameof(CalculatorMockData.Degrees240))]
        [TestCase(nameof(CalculatorMockData.Degrees260))]
        [TestCase(nameof(CalculatorMockData.Degrees340))]
        [TestCase(nameof(CalculatorMockData.Degrees360))]
        [TestCase(nameof(CalculatorMockData.Degrees400))]
        public void DegToRad(string caseKey)
        {
            var (test, solution, accuracy) = degToRadTestCases.Get<double>(caseKey);
            _ = Calculator.DegToRad(test)
                .Should()
                .BeApproximately(solution, accuracy);
        }

        #endregion DegToRad

        #region DegToRad

        private static readonly DoubleTestCaseCollection<CalculatorMockData, DegreesExample> radToDegTestCases
            = new DoubleTestCaseCollection<CalculatorMockData, DegreesExample>(
                new CalculatorMockData(), x => new DoubleTestCase(x.Degrees, x.Radians, x.Accuracy));

        [TestCase(nameof(CalculatorMockData.Degrees0))]
        [TestCase(nameof(CalculatorMockData.Degrees20))]
        [TestCase(nameof(CalculatorMockData.Degrees30))]
        [TestCase(nameof(CalculatorMockData.Degrees60))]
        [TestCase(nameof(CalculatorMockData.Degrees80))]
        [TestCase(nameof(CalculatorMockData.Degrees90))]
        [TestCase(nameof(CalculatorMockData.Degrees100))]
        [TestCase(nameof(CalculatorMockData.Degrees220))]
        [TestCase(nameof(CalculatorMockData.Degrees240))]
        [TestCase(nameof(CalculatorMockData.Degrees260))]
        [TestCase(nameof(CalculatorMockData.Degrees340))]
        [TestCase(nameof(CalculatorMockData.Degrees360))]
        [TestCase(nameof(CalculatorMockData.Degrees400))]
        public void RadToDeg(string caseKey)
        {
            var (test, solution, accuracy) = radToDegTestCases.Get<double>(caseKey);
            _ = Calculator.RadToDeg(test)
                .Should()
                .BeApproximately(solution, accuracy);
        }

        #endregion DegToRad

        #region Factorial

        private static readonly SimpleTestCaseCollection<CalculatorMockData, FactorialExample> factorialTestCases
            = new SimpleTestCaseCollection<CalculatorMockData, FactorialExample>(
                new CalculatorMockData(), x => new SimpleTestCase(x.Input, x.Output));

        [TestCase(nameof(CalculatorMockData.Factorial1))]
        [TestCase(nameof(CalculatorMockData.Factorial2))]
        [TestCase(nameof(CalculatorMockData.Factorial3))]
        [TestCase(nameof(CalculatorMockData.Factorial4))]
        [TestCase(nameof(CalculatorMockData.Factorial5))]
        [TestCase(nameof(CalculatorMockData.Factorial10))]
        [TestCase(nameof(CalculatorMockData.Factorial20))]
        public void FactorialTests(string caseKey)
        {
            var (test, solution) = factorialTestCases.Get<uint, ulong>(caseKey);
            _ = Calculator.Factorial(test)
                .Should()
                .Be(solution);
        }

        #endregion Factorial

        #region Factorial

        private static readonly SimpleTestCaseCollection<CalculatorMockData, I2I1> greatestCommonFactorTestCases
            = new SimpleTestCaseCollection<CalculatorMockData, I2I1>(
                new CalculatorMockData(), x => new SimpleTestCase((x.Input1, x.Input2), x.Output));

        [TestCase(nameof(CalculatorMockData.GCF1))]
        [TestCase(nameof(CalculatorMockData.GCF2))]
        [TestCase(nameof(CalculatorMockData.GCF3))]
        public void GreatestCommonFactorTests(string caseKey)
        {
            var (test, solution) = greatestCommonFactorTestCases.Get<(int, int), int>(caseKey);
            _ = Calculator.GreatestCommonFactor(test.Item1, test.Item2)
                .Should()
                .Be(solution);
        }

        #endregion Factorial

        #region Factorial

        private static readonly SimpleTestCaseCollection<CalculatorMockData, I2I1> lowestCommonMultipleTestCases
            = new SimpleTestCaseCollection<CalculatorMockData, I2I1>(
                new CalculatorMockData(), x => new SimpleTestCase((x.Input1, x.Input2), x.Output));

        [TestCase(nameof(CalculatorMockData.GCF1))]
        [TestCase(nameof(CalculatorMockData.GCF2))]
        [TestCase(nameof(CalculatorMockData.GCF3))]
        public void LowestCommonMultipleTests(string caseKey)
        {
            var (test, solution) = lowestCommonMultipleTestCases.Get<(int, int), int>(caseKey);
            _ = Calculator.LowestCommonMultiple(test.Item1, test.Item2)
                .Should()
                .Be(solution);
        }

        #endregion Factorial
    }
}
