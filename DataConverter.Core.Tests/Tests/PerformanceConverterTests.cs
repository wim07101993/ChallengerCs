using DataConverter.Core.Converters;

namespace DataConverter.Core.Tests.Tests
{
    public class PerformanceConverterTests : ConverterTests
    {
        protected override IConverter Converter => new PerformanceConverter();
    }
}
