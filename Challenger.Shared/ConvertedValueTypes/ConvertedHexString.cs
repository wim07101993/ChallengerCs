using System;
using System.Threading.Tasks;

namespace Challenger.Shared.ConvertedValueTypes
{
    public class ConvertedHexString : ConvertedValue<string>
    {
        public ConvertedHexString(Func<Action, Task> uiThreadInvoker) : base(uiThreadInvoker)
        {
        }

        public override string Name => "Hexadecimal String";

        protected override byte[] ToBytes(string value) => Converter.ParseHexString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetHexString(bytes);
    }
}
