using System;
using System.Collections.Generic;
using System.Text;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedUtf8String : ConvertedValue<string>
    {
        public override string Name => "UTF8 String";

        protected override byte[] ToBytes(string value) => Converter.GetUtf8Bytes(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetUtf8String(bytes);
    }
}
