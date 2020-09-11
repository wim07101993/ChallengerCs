namespace Testing.Shared
{
    public sealed class SimpleTestCase
    {
        public SimpleTestCase()
        {
        }

        public SimpleTestCase(object test, object solution)
        {
            Test = test;
            Solution = solution;
        }

        public object Test { get; set; }
        public object Solution { get; set; }
    }
}
