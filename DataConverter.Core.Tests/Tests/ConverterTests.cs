using Challenger.Core.Converters;
using DataConverter.Core.TestData;

using NUnit.Framework;

namespace DataConverter.Core.Tests.Tests
{
    public abstract partial class ConverterTests
    {
        protected abstract IConverter Converter { get; }
    }
}
