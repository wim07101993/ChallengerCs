using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class DotNetPiTests : PiTester
    {
        protected override IConstantGenerator ConstantGenerator => new DotNetConstantGenerator();
    }
}
