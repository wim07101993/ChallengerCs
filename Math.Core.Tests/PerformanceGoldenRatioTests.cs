using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class PerformanceGoldenRatioTests : GoldenRatioTester
    {
        protected override IConstantGenerator ConstantGenerator => new PerformanceConstantGenerator();
    }
}
