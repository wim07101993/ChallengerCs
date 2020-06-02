using System.Collections.Generic;

namespace DataConverter.Core.Tests
{
    internal sealed class SimpleTestCaseCollection : Dictionary<string, SimpleTestCase>
    {
        public (TTest test, TSolution solution) Get<TTest, TSolution>(string key)
        {
            var testCase = this[key];
            return ((TTest)testCase.Test, (TSolution)testCase.Solution);
        }
    }
}
