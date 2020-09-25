using Challenger.Core.Converters;

namespace DataConverter.Core.Tests
{
    public class LinqConverterTests : ConverterTests
    {
        protected override IConverter Converter => new LinqConverter();
    }
}
