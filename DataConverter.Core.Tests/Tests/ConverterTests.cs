using System;

using Challenger.Core.Converters;

namespace DataConverter.Core.Tests.Tests
{
    public abstract partial class ConverterTests
    {
        protected abstract IConverter Converter { get; }

        #region helping methods

        private static byte[] ResizeArray(byte[] bytes, int newSize)
        {
            Array.Resize(ref bytes, newSize);
            return bytes;
        }

        #endregion
    }
}
