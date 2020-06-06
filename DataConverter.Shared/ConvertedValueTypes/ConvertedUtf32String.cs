using System;
using System.Threading.Tasks;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedUtf32String : ConvertedValue<string>
    {
        public ConvertedUtf32String(Func<Action, Task> uiThreadInvoker) : base(uiThreadInvoker)
        {
        }

        public override string Name => "UTF32 String";

        protected override byte[] ToBytes(string value) => Converter.GetUtf32Bytes(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetUtf32String(bytes);
    }
}
