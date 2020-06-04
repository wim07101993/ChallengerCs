namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedAsciiString : ConvertedValue<string>
    {
        public override string Name => "ASCII String";

        protected override byte[] ToBytes(string value) => Converter.GetAsciiBytes(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetAsciiString(bytes);
    }
}
