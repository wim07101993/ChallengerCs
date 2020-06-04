using System;
using System.Collections.Generic;
using System.Text;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedUtf32String : ConvertedValue<string>
    {
        public override string Name => "UTF32 String";

        protected override byte[] ToBytes(string value) => Converter.GetUtf32Bytes(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetUtf32String(bytes);
    }
}
