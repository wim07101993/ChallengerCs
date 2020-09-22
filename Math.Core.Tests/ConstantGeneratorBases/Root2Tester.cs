namespace Math.Core.Tests.ConstantGeneratorBases
{
    public abstract class Root2Tester : AConstantGeneratorTests
    {
        protected override decimal CorrectValue => 1.414213562373095048801688724209m;
        protected override decimal Func(int decimals) => ConstantGenerator.Root2(decimals);
    }
}
