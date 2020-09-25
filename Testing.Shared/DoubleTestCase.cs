namespace Testing.Shared
{
    public sealed class DoubleTestCase
    {
        public DoubleTestCase()
        {
        }

        public DoubleTestCase(object test, double solution, double accuracy)
        {
            Test = test;
            Solution = solution;
            Accuracy = accuracy;
        }

        public object Test { get; set; }
        public double Solution { get; set; }
        public double Accuracy { get; set; }
    }
}
