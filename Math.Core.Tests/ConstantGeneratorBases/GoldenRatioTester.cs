namespace Math.Core.Tests.ConstantGeneratorBases
{
    public abstract class GoldenRatioTester : AConstantGeneratorTests
    {
        protected override decimal CorrectValue => 1.618033988749894848204586834365m;
        protected override decimal Func(int decimals) => ConstantGenerator.GoldenRatio(decimals);
    }
}
