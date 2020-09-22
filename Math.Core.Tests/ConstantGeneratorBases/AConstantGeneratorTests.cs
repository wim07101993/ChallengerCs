using System;

using Challenger.Core.Math;

using FluentAssertions;

using NUnit.Framework;

namespace Math.Core.Tests
{
    public abstract class AConstantGeneratorTests
    {
        protected abstract IConstantGenerator ConstantGenerator { get; }

        protected abstract decimal CorrectValue { get; }

        protected abstract decimal Func(int decimals);

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        [TestCase(21)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        [TestCase(26)]
        [TestCase(27)]
        [TestCase(28)]
        public void Test(int decimals)
        {
            _ = Func(decimals)
                .Should()
                .BeApproximately(CorrectValue, (decimal)System.Math.Pow(10, -decimals));
        }
    }
}
