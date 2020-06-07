using System;
using System.Threading.Tasks;

namespace Challenger.Shared.ConvertedValueTypes
{
    public class ConvertedOctalString : ConvertedValue<string>
    {
        public ConvertedOctalString(Func<Action, Task> uiThreadInvoker) : base(uiThreadInvoker)
        {
        }

        public override string Name => "Octal String";

        protected override byte[] ToBytes(string value) => Converter.ParseOctalString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetOctalString(bytes);
    }
}
