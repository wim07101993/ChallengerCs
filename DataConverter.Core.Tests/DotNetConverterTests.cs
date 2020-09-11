using Challenger.Core.Converters;

namespace DataConverter.Core.Tests
{
    public class DotNetConverterTests : ConverterTests
    {
        protected override IConverter Converter => new DotNetConverter();
    }
}
