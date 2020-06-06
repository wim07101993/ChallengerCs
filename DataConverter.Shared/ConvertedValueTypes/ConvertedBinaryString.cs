using System;
using System.Threading.Tasks;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedBinaryString : ConvertedValue<string>
    {
        public ConvertedBinaryString(Func<Action, Task> uiThreadInvoker) : base(uiThreadInvoker)
        {
        }

        public override string Name => "Binary String";

        protected override byte[] ToBytes(string value) => Converter.ParseBinaryString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetBinaryString(bytes);
    }
}
