using System;
using System.Collections.Generic;
using System.Text;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedOctalString : ConvertedValue<string>
    {
        public override string Name => "Octal String";

        protected override byte[] ToBytes(string value) => Converter.ParseOctalString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetOctalString(bytes);
    }
}
