using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing.Shared
{
    public sealed class SimpleTestCaseCollection<TMockData, TExample> : Dictionary<string, SimpleTestCase>
    {
        public SimpleTestCaseCollection(Dictionary<string, SimpleTestCase> seed)
            : base(seed)
        {
        }

        public SimpleTestCaseCollection(TMockData testData, Func<TExample, SimpleTestCase> testCaseSelector)
            : base(testData
                  .GetType()
                  .GetProperties()
                  .Where(x => x.PropertyType == typeof(TExample))
                  .ToDictionary(x => x.Name, x => testCaseSelector((TExample)x.GetValue(testData))))
        {
        }

        public (TTest test, TSolution solution) Get<TTest, TSolution>(string key)
        {
            var testCase = this[key];
            return ((TTest)testCase.Test, (TSolution)testCase.Solution);
        }
    }
}
