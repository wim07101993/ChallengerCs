using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class DotNetETests : ETester
    {
        protected override IConstantGenerator ConstantGenerator => new DotNetConstantGenerator();
    }
}
