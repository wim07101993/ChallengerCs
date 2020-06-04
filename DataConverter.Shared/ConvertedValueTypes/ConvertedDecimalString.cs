using System;
using System.Collections.Generic;
using System.Text;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedDecimalString : ConvertedValue<string>
    {
        public override string Name => "Decimal String";

        protected override byte[] ToBytes(string value) => Converter.ParseDecimalString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetDecimalString(bytes);
    }
}
