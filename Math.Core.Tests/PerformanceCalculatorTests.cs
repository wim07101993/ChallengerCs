using Challenger.Core.Math;

namespace Math.Core.Tests
{
    public class PerformanceCalculatorTests : CalculatorTests
    {
        protected override ICalculator Calculator => new PerformanceCalculator();
    }
}
