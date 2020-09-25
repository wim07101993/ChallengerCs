using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class DotNetGoldenRatioTests : GoldenRatioTester
    {
        protected override IConstantGenerator ConstantGenerator => new DotNetConstantGenerator();
    }
}
