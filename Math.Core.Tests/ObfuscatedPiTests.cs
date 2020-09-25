using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class ObfuscatedPiTests : PiTester
    {
        protected override IConstantGenerator ConstantGenerator => new ObfuscatedConstantGenerator();
    }
}
