using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing.Shared
{
    public class TestCaseCollection<TMockData, TExample, TTestCase> : Dictionary<string, TTestCase>
    {
        public TestCaseCollection(Dictionary<string, TTestCase> seed)
            : base(seed)
        {
        }

        public TestCaseCollection(TMockData testData, Func<TExample, TTestCase> testCaseSelector)
            : base(testData
                  .GetType()
                  .GetProperties()
                  .Where(x => x.PropertyType == typeof(TExample))
                  .ToDictionary(x => x.Name, x => testCaseSelector((TExample)x.GetValue(testData))))
        {
        }
    }
}
