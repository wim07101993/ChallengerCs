using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class PerformancePiTests : PiTester
    {
        protected override IConstantGenerator ConstantGenerator => new PerformanceConstantGenerator();
    }
}
