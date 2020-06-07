using System;
using System.Threading.Tasks;

namespace Challenger.Shared.ConvertedValueTypes
{
    public class ConvertedAsciiString : ConvertedValue<string>
    {
        public ConvertedAsciiString(Func<Action, Task> uiThreadInvoker) : base(uiThreadInvoker)
        {
        }

        public override string Name => "ASCII String";

        protected override byte[] ToBytes(string value) => Converter.GetAsciiBytes(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetAsciiString(bytes);
    }
}
