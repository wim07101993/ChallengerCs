using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        public class SomeAttribute : Attribute
        {
            public SomeAttribute(string value)
            {
                this.Value = value;
            }

            public string Value { get; set; }
        }

        public class SomeClass
        {
            public string Value = "Test";
        }
    }
}
