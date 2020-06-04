namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedBinaryString : ConvertedValue<string>
    {
        public override string Name => "Binary String";

        protected override byte[] ToBytes(string value) => Converter.ParseBinaryString(value);

        protected override string FromBytes(byte[] bytes) => Converter.GetBinaryString(bytes);
    }
}
