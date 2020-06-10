<Query Kind="Statements" />

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
var inputs = new List<(string name, byte[] bytes)>
{
	( "Zero", new byte[] { 0x00 } ),
	( "FF", new byte[] { 0xFF } ),
	( "BinaryBytes", new byte[]  { 0xAA, 0xAA, 0xAA, 0xAA } ),
	// 123 45 67
	( "OctalBytes", new byte[] { 0x37, 0x25, 0x53 } ),
	// 123 45 67 89 98 76 54 32 1
	( "DecimalBytes", new byte[] { 0x7b, 0x2d, 0x43, 0x59, 0x62, 0x4c, 0x36, 0x20, 0x1 }.Reverse().ToArray() ),
	// hello world
	( "Ascii", new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 } ),
	// 12345
	( "UShort", new byte[] { 0x39, 0x30 } ),
	// 1234567891
	( "UInt", new byte[] { 0x49, 0x96, 0x02, 0xd3 }.Reverse().ToArray() ),
	// 7625597484987 (3^27=3^3^3=3↑↑3=3↑↑↑2)
	( "ULong", new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb }.Reverse().ToArray()),
	// -12345
	( "Short", new byte[] { 0xcf, 0xc7 }.Reverse().ToArray() ),
	// -123456789
	( "Int", new byte[] { 0xf8, 0xa4, 0x32, 0xeb }.Reverse().ToArray() ),
	// 273849379225669
	( "Long", new byte[] { 0xf9, 0x10, 0x86, 0xf8, 0x80, 0x45 }.Reverse().ToArray()),
	// 12345.679
	( "Float", new byte[] { 0x46, 0x40, 0xe6, 0xb7 }.Reverse().ToArray() ),
	// 3.141592653589793 (pi)
	( "Double", new byte[] { 0x40, 0x09, 0x21, 0xfb, 0x54, 0x44, 0x2d, 0x18 }.Reverse().ToArray() ),
	// 2.7182818284590452353602874714 (e)
	( "Decimal", new byte[]{ 0xeb, 0xec, 0xde, 0x35, 0x85, 0x7a, 0xed, 0x5a, 0x57, 0xd5, 0x19, 0xab, 0x0, 0x1c, 0x0, 0x0 }.Reverse().ToArray() ),	
};


var bytes = new byte[16];
foreach (var (name, input) in inputs) 
{
	Console.WriteLine($"public Example {name} => new Example");
	Console.WriteLine("{");
	
	var s = input.Aggregate("", (s, x) => s += $"0x{x:x}, ").ToString();
	var sByteArray = $"new byte[] {{{s}}}";
	Console.WriteLine($"Bytes = {sByteArray},");
	
	s = input
		.Reverse()
		.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))
		.Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
		.ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"BinaryString = \"{s}\",");
	s = input
		.Reverse()
		.Select(x => Convert.ToString(x, 2))
		.Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
		.ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"ShortBinaryString = \"{s}\",");
	
	s = input
		.Reverse()
        .Select(x => Convert.ToString(x, 8).PadLeft(3, '0'))
        .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
        .ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"OctalString = \"{s}\",");
	s = input
		.Reverse()
        .Select(x => Convert.ToString(x, 8))
        .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
        .ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"ShortOctalString = \"{s}\",");
	
	s = input
		.Reverse()
        .Select(x => Convert.ToString(x).PadLeft(3, '0'))
        .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
        .ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"DecimalString = \"{s}\",");
	s = input
		.Reverse()
        .Select(x => Convert.ToString(x))
        .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
        .ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"ShortDecimalString = \"{s}\",");
	
	s =  input
		.Reverse()
        .Select(x => Convert.ToString(x, 16).PadLeft(2, '0'))
        .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
        .ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"HexString = \"{s}\",");
	s = input
		.Reverse()
        .Select(x => Convert.ToString(x, 16))
        .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
        .ToString()
		.ToUpper()
        .Trim();
	Console.WriteLine($"ShortHexString = \"{s}\",");
	
	Console.WriteLine($"AsciiString = Encoding.ASCII.GetString({sByteArray}),");

	Array.Clear(bytes, 0, 16);
	Array.Copy(input, bytes, Math.Min(input.Length, bytes.Length));
	
	Console.WriteLine($"UShort = {BitConverter.ToUInt16(bytes)},");
	Console.WriteLine($"Short = {BitConverter.ToInt16(bytes)},");
	Console.WriteLine($"UInt = {BitConverter.ToUInt32(bytes)},");
	Console.WriteLine($"Int = {BitConverter.ToInt32(bytes)},");
	Console.WriteLine($"ULong = {BitConverter.ToUInt64(bytes)},");
	Console.WriteLine($"Long = {BitConverter.ToInt64(bytes)},");
	Console.WriteLine($"Float = (float){BitConverter.ToSingle(bytes)},");
	Console.WriteLine($"Double = {BitConverter.ToDouble(bytes)},");
	
	fixed (byte* pbyte = &bytes[0])
    {
        var dec = *(decimal*)pbyte;
		Console.WriteLine($"Decimal = {dec}m,");
    }
	
	Console.WriteLine("};\r\n");
}
