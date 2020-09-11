using System;
using System.Linq;
using System.Text;

namespace Challenger.Core.Converters
{
    public class LinqConverter : IConverter
    {
        #region array string

        public string GetBinaryString(byte[] bytes) => GetArrayString(bytes, x => Convert.ToString(x, 2));

        public string GetOctalString(byte[] bytes) => GetArrayString(bytes, x => Convert.ToString(x, 8));

        public string GetDecimalString(byte[] bytes) => GetArrayString(bytes, x => Convert.ToString(x, 10));

        public string GetHexString(byte[] bytes) => GetArrayString(bytes, x => Convert.ToString(x, 16));

        private string GetArrayString(byte[] bytes, Func<byte, string> toString)
        {
            return bytes
              .Reverse() // little endian
              .Select(toString)
              .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
              .ToString()
              .Trim();
        }

        public byte[] ParseBinaryString(string s) => ParseArrayString(s, x => Convert.ToByte(x, 2));

        public byte[] ParseOctalString(string s) => ParseArrayString(s, x => Convert.ToByte(x, 8));

        public byte[] ParseDecimalString(string s) => ParseArrayString(s, x => Convert.ToByte(x, 10));

        public byte[] ParseHexString(string s) => ParseArrayString(s, x => Convert.ToByte(x, 16));

        private byte[] ParseArrayString(string s, Func<string, byte> fromString)
        {
            var split = s.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

            var bytes = new byte[split.Length];

            for (var i = 0; i < split.Length; ++i)
                bytes[i] = fromString(split[split.Length - 1 - i]);

            return bytes;
        }

        #endregion array string

        #region encoding

        public string GetAsciiString(byte[] bytes) => Encoding.ASCII.GetString(bytes);

        public byte[] GetAsciiBytes(string s) => Encoding.ASCII.GetBytes(s);

        #endregion encoding

        #region to number

        public ushort GetUShort(byte[] bytes) => BitConverter.ToUInt16(ResizeArray(bytes, 2), 0);

        public short GetShort(byte[] bytes) => BitConverter.ToInt16(ResizeArray(bytes, 2), 0);

        public uint GetUInt(byte[] bytes) => BitConverter.ToUInt32(ResizeArray(bytes, 4), 0);

        public int GetInt(byte[] bytes) => BitConverter.ToInt32(ResizeArray(bytes, 4), 0);

        public ulong GetULong(byte[] bytes) => BitConverter.ToUInt64(ResizeArray(bytes, 8), 0);

        public long GetLong(byte[] bytes) => BitConverter.ToInt64(ResizeArray(bytes, 8), 0);

        public float GetFloat(byte[] bytes) => BitConverter.ToSingle(ResizeArray(bytes, 4), 0);

        public double GetDouble(byte[] bytes) => BitConverter.ToDouble(ResizeArray(bytes, 8), 0);

        public unsafe decimal GetDecimal(byte[] bytes)
        {
            bytes = ResizeArray(bytes, 16);
            fixed (byte* pbyte = &bytes[0])
                return *(decimal*)pbyte;
        }

        public byte[] ResizeArray(byte[] bytes, int size)
        {
            var ret = new byte[size];
            Array.Copy(bytes, ret, System.Math.Min(bytes.Length, size));
            return ret;
        }

        #endregion to number

        #region from number

        public byte[] GetUShortBytes(ushort s) => TrimArray(BitConverter.GetBytes(s));

        public byte[] GetShortBytes(short s) => TrimArray(BitConverter.GetBytes(s));

        public byte[] GetUIntBytes(uint i) => TrimArray(BitConverter.GetBytes(i));

        public byte[] GetIntBytes(int i) => TrimArray(BitConverter.GetBytes(i));

        public byte[] GetULongBytes(ulong l) => TrimArray(BitConverter.GetBytes(l));

        public byte[] GetLongBytes(long l) => TrimArray(BitConverter.GetBytes(l));

        public byte[] GetFloatBytes(float f) => TrimArray(BitConverter.GetBytes(f));

        public byte[] GetDoubleBytes(double d) => TrimArray(BitConverter.GetBytes(d));

        public unsafe byte[] GetDecimalBytes(decimal d)
        {
            var bytes = new byte[16];
            fixed (byte* b = bytes)
                *(decimal*)b = d;

            return TrimArray(bytes);
        }

        private static byte[] TrimArray(byte[] bytes)
        {
            var i = bytes.Length - 1;
            if (bytes[i] != 0)
                return bytes;

            for (i--; i >= 0; i--)
            {
                if (bytes[i] != 0)
                    break;
            }

            return i == -1 // all values are 0
                ? new byte[] { 0 }
                : bytes.Take(i + 1).ToArray();
        }

        #endregion from number
    }
}
