using System;
using System.Collections.Generic;
using System.Linq;

using DataConverter.Core.TestData;

namespace DataConverter.Core.Tests
{
    internal sealed class SimpleTestCaseCollection : Dictionary<string, SimpleTestCase>
    {
        public SimpleTestCaseCollection(Dictionary<string, SimpleTestCase> seed)
            : base(seed)
        {
        }

        public SimpleTestCaseCollection(MockData testData, Func<Example, SimpleTestCase> testCaseSelector)
            : base(testData
                  .GetType()
                  .GetProperties()
                  .Where(x => x.PropertyType == typeof(Example))
                  .ToDictionary(x => x.Name, x => testCaseSelector((Example)x.GetValue(testData))))
        {
        }

        public (TTest test, TSolution solution) Get<TTest, TSolution>(string key)
        {
            var testCase = this[key];
            return ((TTest)testCase.Test, (TSolution)testCase.Solution);
        }
    }
}
