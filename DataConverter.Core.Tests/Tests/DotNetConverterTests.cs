using DataConverter.Core.Converters;

namespace DataConverter.Core.Tests.Tests
{
    public class DotNetConverterTests : ConverterTests
    {
        protected override IConverter Converter => new DotNetConverter();
    }
}
