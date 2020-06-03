using DataConverter.Core.Converters;

namespace DataConverter.Core.Tests.Tests
{
    public class LinqConverterTests : ConverterTests
    {
        protected override IConverter Converter => new LinqConverter();
    }
}
