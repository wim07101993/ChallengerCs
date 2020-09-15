using System;
using System.Collections.Generic;

namespace Testing.Shared
{
    public sealed class SimpleTestCaseCollection<TMockData, TExample> : TestCaseCollection<TMockData, TExample, SimpleTestCase>
    {
        public SimpleTestCaseCollection(Dictionary<string, SimpleTestCase> seed)
            : base(seed)
        {
        }

        public SimpleTestCaseCollection(TMockData testData, Func<TExample, SimpleTestCase> testCaseSelector)
            : base(testData, testCaseSelector)
        {
        }

        public (TTest test, TSolution solution) Get<TTest, TSolution>(string key)
        {
            var testCase = this[key];
            return ((TTest)testCase.Test, (TSolution)testCase.Solution);
        }
    }
}
