namespace Math.Core.Tests.ConstantGeneratorBases
{
    public abstract class ETester : AConstantGeneratorTests
    {
        protected override decimal CorrectValue => 2.718281828459045235360287471352m;
        protected override decimal Func(int decimals) => ConstantGenerator.E(decimals);
    }
}
