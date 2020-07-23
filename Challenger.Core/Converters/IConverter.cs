using System.ComponentModel;

namespace Challenger.Core.Converters
{
    public interface IConverter
    {
        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a binary format (01001111-01001011-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a binary format (01001111-01001011-...).</returns>
        [DisplayName("Bytes -> Binary string")]
        string GetBinaryString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a octal format (117-113-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a octal format (117-113-...).</returns>
        [DisplayName("Bytes -> Octal string")]
        string GetOctalString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a decimal format (79-75-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a decimal format (79-75-...).</returns>
        [DisplayName("Bytes -> Decimal string")]
        string GetDecimalString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> representing the bytes in
        ///     a hexadecimal format (4F-4B-...).
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The string representing the bytes in a hexadecimal format (4F-4B-...).</returns>
        [DisplayName("Bytes -> Hex string")]
        string GetHexString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to <see cref="string" /> using ASCII.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The ASCII string representing the bytes.</returns>
        [DisplayName("Bytes -> ASCII string")]
        string GetAsciiString(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="ushort" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="ushort" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> UInt16")]
        ushort GetUShort(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="uint" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="uint" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> UInt32")]
        uint GetUInt(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="ulong" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="ulong" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> UInt64")]
        ulong GetULong(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="short" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="short" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> Int16")]
        short GetShort(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="int" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="int" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> Int32")]
        int GetInt(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="long" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="long" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> Int64")]
        long GetLong(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="float" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="float" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> Float32")]
        float GetFloat(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="double" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="double" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> Float64")]
        double GetDouble(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="byte[]" /> to a <see cref="decimal" />.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>The <see cref="decimal" /> that the bytes represent.</returns>
        [DisplayName("Bytes -> Float128")]
        decimal GetDecimal(byte[] bytes);

        /// <summary>
        ///     Converts a <see cref="ushort" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="ushort" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="ushort" /></returns>
        [DisplayName("UInt16 -> Bytes")]
        byte[] GetUShortBytes(ushort s);

        /// <summary>
        ///     Converts a <see cref="uint" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="uint" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="uint" /></returns>
        [DisplayName("UInt32 -> Bytes")]
        byte[] GetUIntBytes(uint i);

        /// <summary>
        ///     Converts a <see cref="ulong" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="ulong" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="ulong" /></returns>
        [DisplayName("UInt64 -> Bytes")]
        byte[] GetULongBytes(ulong l);

        /// <summary>
        ///     Converts a <see cref="short" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="short" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="short" /></returns>
        [DisplayName("Int16 -> Bytes")]
        byte[] GetShortBytes(short s);

        /// <summary>
        ///     Converts a <see cref="int" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="int" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="int" /></returns>
        [DisplayName("Int32 -> Bytes")]
        byte[] GetIntBytes(int i);

        /// <summary>
        ///     Converts a <see cref="long" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="long" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="long" /></returns>
        [DisplayName("Int64 -> Bytes")]
        byte[] GetLongBytes(long l);

        /// <summary>
        ///     Converts a <see cref="float" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="float" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="float" /></returns>
        [DisplayName("Float32 -> Bytes")]
        byte[] GetFloatBytes(float f);

        /// <summary>
        ///     Converts a <see cref="double" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="double" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="double" /></returns>
        [DisplayName("Float64 -> Bytes")]
        byte[] GetDoubleBytes(double d);

        /// <summary>
        ///     Converts a <see cref="decimal" /> to its representing <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="decimal" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="decimal" /></returns>
        [DisplayName("Float128 -> Bytes")]
        byte[] GetDecimalBytes(decimal d);

        /// <summary>
        ///     Converts a binary <see cref="string" /> (1001111-1001011-...) to its representing
        ///     <see cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        [DisplayName("Binary string -> Bytes")]
        byte[] ParseBinaryString(string s);

        /// <summary>
        ///     Converts a octal <see cref="string" /> (117-113-...) to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        [DisplayName("Octal string -> Bytes")]
        byte[] ParseOctalString(string s);

        /// <summary>
        ///     Converts a decimal <see cref="string" /> (79-75-...) to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        [DisplayName("Decimal string -> Bytes")]
        byte[] ParseDecimalString(string s);

        /// <summary>
        ///     Converts a hexadecimal <see cref="string" /> (4F-4B-...) to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        [DisplayName("Hex string -> Bytes")]
        byte[] ParseHexString(string s);

        /// <summary>
        ///     Converts a ASCII <see cref="string" /> to its representing <see
        ///     cref="byte[]" />.
        /// </summary>
        /// <param name="s">The <see cref="string" /> to convert.</param>
        /// <returns>The bytes representing the <see cref="string" /></returns>
        [DisplayName("ASCII string -> Bytes")]
        byte[] GetAsciiBytes(string s);
    }
}
