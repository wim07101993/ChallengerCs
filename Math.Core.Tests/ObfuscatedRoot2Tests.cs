using Challenger.Core.Math;

using Math.Core.Tests.ConstantGeneratorBases;

namespace Math.Core.Tests
{
    public class ObfuscatedRoot2Tests : Root2Tester
    {
        protected override IConstantGenerator ConstantGenerator => new ObfuscatedConstantGenerator();
    }
}
