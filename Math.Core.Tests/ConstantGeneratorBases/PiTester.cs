namespace Math.Core.Tests.ConstantGeneratorBases
{
    public abstract class PiTester : AConstantGeneratorTests
    {
        protected override decimal CorrectValue => 3.141592653589793238462643383279m;
        protected override decimal Func(int decimals) => ConstantGenerator.Pi(decimals);
    }
}
