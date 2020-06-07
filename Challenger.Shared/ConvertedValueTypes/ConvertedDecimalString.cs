using System;
using System.Threading.Tasks;

namespace Challenger.Shared.ConvertedValueTypes
{
    public class ConvertedDecimalString : ConvertedValue<string>
    {
        public ConvertedDecimalString(Func<Action, Task> uiThreadInvoker) : base(uiThreadInvoker)
        {
        }

        public override string Name => "Decimal String";

        protected override byte[] ToBytes(string value) => Converter.ParseDecimalString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetDecimalString(bytes);
    }
}
