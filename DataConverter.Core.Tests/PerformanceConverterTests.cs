using Challenger.Core.Converters;

namespace DataConverter.Core.Tests
{
    public class PerformanceConverterTests : ConverterTests
    {
        protected override IConverter Converter => new PerformanceConverter();
    }
}
