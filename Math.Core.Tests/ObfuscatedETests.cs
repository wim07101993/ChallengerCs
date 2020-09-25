using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class ObfuscatedETests : ETester
    {
        protected override IConstantGenerator ConstantGenerator => new ObfuscatedConstantGenerator();
    }
}
