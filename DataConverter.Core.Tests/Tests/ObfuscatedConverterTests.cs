using Challenger.Core.Converters;

namespace DataConverter.Core.Tests.Tests
{
    public class ObfuscatedConverterTests : ConverterTests
    {
        protected override IConverter Converter => new ObfuscatedConverter();
    }
}
