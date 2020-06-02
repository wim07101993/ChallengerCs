namespace DataConverter.Core.Converters
{
    public interface IConverter
    {
        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a binary format (01001111-01001011-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a binary format (01001111-01001011-...).</returns>
        string GetBinaryString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a octal format (117-113-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a octal format (117-113-...).</returns>
        string GetOctalString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a decimal format (79-75-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a decimal format (79-75-...).</returns>
        string GetDecimalString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a hexadecimal format (4F-4B-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a hexadecimal format (4F-4B-...).</returns>
        string GetHexString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> using ASCII.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The ASCII string representing the bytes.</returns>
        string GetAsciiString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> using UTF8.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The UTF8 string representing the bytes.</returns>
        string GetUtf8String(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> using UTF32.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The UTF32 string representing the bytes.</returns>
        string GetUtf32String(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="ushort" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="ushort" /> that the bytes represent.</returns>
        ushort GetUShort(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="uint" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="uint" /> that the bytes represent.</returns>
        uint GetUInt(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="ulong" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="ulong" /> that the bytes represent.</returns>
        ulong GetULong(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="short" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="short" /> that the bytes represent.</returns>
        short GetShort(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="int" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="int" /> that the bytes represent.</returns>
        int GetInt(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="long" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="long" /> that the bytes represent.</returns>
        long GetLong(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="float" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="float" /> that the bytes represent.</returns>
        float GetFloat(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="double" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="double" /> that the bytes represent.</returns>
        double GetDouble(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="decimal" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="decimal" /> that the bytes represent.</returns>
        decimal GetDecimal(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="ushort" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="ushort" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="ushort" /></returns>
        byte[] GetBytes(ushort s);

        /// <summary>
        ///     Converts a <see cref="uint" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="uint" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="uint" /></returns>
        byte[] GetBytes(uint i);

        /// <summary>
        ///     Converts a <see cref="ulong" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="ulong" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="ulong" /></returns>
        byte[] GetBytes(ulong l);

        /// <summary>
        ///     Converts a <see cref="short" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="short" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="short" /></returns>
        byte[] GetBytes(short s);

        /// <summary>
        ///     Converts a <see cref="int" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="int" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="int" /></returns>
        byte[] GetBytes(int i);

        /// <summary>
        ///     Converts a <see cref="long" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="long" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="long" /></returns>
        byte[] GetBytes(long l);

        /// <summary>
        ///     Converts a <see cref="float" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="float" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="float" /></returns>
        byte[] GetBytes(float f);

        /// <summary>
        ///     Converts a <see cref="double" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="double" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="double" /></returns>
        byte[] GetBytes(double d);

        /// <summary>
        ///     Converts a <see cref="decimal" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="decimal" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="decimal" /></returns>
        byte[] GetBytes(decimal d);

        /// <summary>
        ///     Converts a binary <see cref="string" /> (1001111-1001011-...) to its representing
        ///     <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        byte[] ParseBinaryString(string s);

        /// <summary>
        ///     Converts a octal <see cref="string" /> (117-113-...) to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        byte[] ParseOctalString(string s);

        /// <summary>
        ///     Converts a decimal <see cref="string" /> (79-75-...) to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        byte[] ParseDecimalString(string s);

        /// <summary>
        ///     Converts a hexadecimal <see cref="string" /> (4F-4B-...) to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        byte[] ParseHexString(string s);

        /// <summary>
        ///     Converts a ASCII <see cref="string" /> to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        byte[] GetAsciiBytes(string s);

        /// <summary>
        ///     Converts a UTF8 <see cref="string" /> to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        byte[] GetUtf8Bytes(string s);

        /// <summary>
        ///     Converts a UTF32 <see cref="string" /> to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        byte[] GetUtf32Bytes(string s);
    }
}
