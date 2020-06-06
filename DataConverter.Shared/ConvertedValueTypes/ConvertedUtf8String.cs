using System;
using System.Threading.Tasks;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedUtf8String : ConvertedValue<string>
    {
        public ConvertedUtf8String(Func<Action, Task> uiThreadInvoker) : base(uiThreadInvoker)
        {
        }

        public override string Name => "UTF8 String";

        protected override byte[] ToBytes(string value) => Converter.GetUtf8Bytes(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetUtf8String(bytes);
    }
}
