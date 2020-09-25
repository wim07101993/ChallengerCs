using Challenger.Core.Math;

namespace Math.Core.Tests
{
    public class DotNetCalculatorTests : CalculatorTests
    {
        protected override ICalculator Calculator => new DotNetCalculator();
    }
}
