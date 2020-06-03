using DataConverter.Core.Converters;
using DataConverter.Core.TestData;

using NUnit.Framework;

namespace DataConverter.Core.Tests.Tests
{
    [TestFixture]
    public partial class ConverterTests
    {
        private IConverter Converter => ConverterFactory.Instance.GetConverter();
    }
}
