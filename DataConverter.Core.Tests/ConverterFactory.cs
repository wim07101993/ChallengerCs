using DataConverter.Core.Converters;

namespace DataConverter.Core.Tests
{
    public class ConverterFactory
    {
        private static ConverterFactory instance;
        public static ConverterFactory Instance => instance ??= new ConverterFactory();

        private ConverterFactory()
        {
        }

        public IConverter GetConverter() => new DotNetConverter();
    }
}
