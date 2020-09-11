using System.Linq;

using Challenger.Core.Converters;
using DataConverter.Core.TestData;

using NUnit.Framework;

namespace DataConverter.Core.Tests
{
    public abstract partial class ConverterTests
    {
        protected abstract IConverter Converter { get; }

        #region helping methods

        private static byte[] TrimArray(byte[] bytes)
        {
            var i = bytes.Length - 1;
            if (bytes[i] != 0)
                return bytes;

            for (i--; i >= 0; i--)
            {
                if (bytes[i] != 0)
                    break;
            }

            return i == -1 // all values are 0
                 ? new byte[] { 0 }
                 : bytes.Take(i + 1).ToArray();
        }

        #endregion
    }
}
