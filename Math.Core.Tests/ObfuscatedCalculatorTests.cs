using Challenger.Core.Converters;
using Challenger.Core.Math;

namespace Math.Core.Tests
{
    public class ObfuscatedCalculatorTests : CalculatorTests
    {
        protected override ICalculator Calculator => new ObfuscatedCalculator();
    }
}
