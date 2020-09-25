using System;
using System.Collections.Generic;

namespace Testing.Shared
{
    public sealed class DoubleTestCaseCollection<TMockData, TExample> : TestCaseCollection<TMockData, TExample, DoubleTestCase>
    {
        public DoubleTestCaseCollection(Dictionary<string, DoubleTestCase> seed)
            : base(seed)
        {
        }

        public DoubleTestCaseCollection(TMockData testData, Func<TExample, DoubleTestCase> testCaseSelector)
            : base(testData, testCaseSelector)
        {
        }

        public (TTest test, double solution, double accuracy) Get<TTest>(string key)
        {
            var testCase = this[key];
            return ((TTest)testCase.Test, testCase.Solution, testCase.Accuracy);
        }
    }
}
