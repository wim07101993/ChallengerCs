using System;
using System.Collections.Generic;
using System.Text;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedHexString : ConvertedValue<string>
    {
        public override string Name => "Hexadecimal String";

        protected override byte[] ToBytes(string value) => Converter.ParseHexString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetHexString(bytes);
    }
}
