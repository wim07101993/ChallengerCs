using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataConverter.Core.Converters
{
    public class DotNetConverter : IConverter
    {
        public byte[] GetAsciiBytes(string s) => Encoding.ASCII.GetBytes(s);

        public string GetAsciiString(byte[] bytes) => Encoding.ASCII.GetString(bytes);

        public string GetBinaryString(byte[] bytes)
        {
            return bytes
                .Select(x => Convert.ToString(x, 2))
                .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
                .ToString()
                .Trim();
        }

        public byte[] GetBytes(ushort s) => BitConverter.GetBytes(s);

        public byte[] GetBytes(uint i) => BitConverter.GetBytes(i);

        public byte[] GetBytes(ulong l) => BitConverter.GetBytes(l);

        public byte[] GetBytes(short s) => BitConverter.GetBytes(s);

        public byte[] GetBytes(int i) => BitConverter.GetBytes(i);

        public byte[] GetBytes(long l) => BitConverter.GetBytes(l);

        public byte[] GetBytes(float f) => BitConverter.GetBytes(f);

        public byte[] GetBytes(double d) => BitConverter.GetBytes(d);

        public unsafe byte[] GetBytes(decimal d)
        {
            var bytes = new byte[16];
            fixed (byte* b = bytes)
                *(decimal*)b = d;
            return bytes;
        }

        public unsafe decimal GetDecimal(byte[] bytes)
        {
            fixed (byte* pbyte = &bytes[0])
                return *(long*)pbyte;
        }

        public string GetDecimalString(byte[] bytes)
        {
            return bytes
                .Select(x => Convert.ToString(x, 10))
                .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
                .ToString()
                .Trim();
        }

        public double GetDouble(byte[] bytes) => BitConverter.ToDouble(bytes, 0);

        public float GetFloat(byte[] bytes) => BitConverter.ToSingle(bytes, 0);

        public string GetHexString(byte[] bytes)
        {
            return bytes
                .Select(x => Convert.ToString(x, 16))
                .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
                .ToString()
                .Trim();
        }

        public int GetInt(byte[] bytes) => BitConverter.ToInt32(bytes, 0);

        public long GetLong(byte[] bytes) => BitConverter.ToInt64(bytes, 0);

        public string GetOctalString(byte[] bytes)
        {
            return bytes
                .Select(x => Convert.ToString(x, 8))
                .Aggregate(new StringBuilder(), (b, x) => b.Append($"{x} "))
                .ToString()
                .Trim();
        }

        public short GetShort(byte[] bytes) => BitConverter.ToInt16(bytes, 0);

        public uint GetUInt(byte[] bytes) => BitConverter.ToUInt32(bytes, 0);

        public ulong GetULong(byte[] bytes) => BitConverter.ToUInt64(bytes, 0);

        public ushort GetUShort(byte[] bytes) => BitConverter.ToUInt16(bytes, 0);

        public byte[] GetUtf32Bytes(string s) => Encoding.UTF32.GetBytes(s);

        public string GetUtf32String(byte[] bytes) => Encoding.UTF32.GetString(bytes);

        public byte[] GetUtf8Bytes(string s) => Encoding.UTF8.GetBytes(s);

        public string GetUtf8String(byte[] bytes) => Encoding.UTF8.GetString(bytes);

        public byte[] ParseBinaryString(string s)
        {
            var split = s.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

            var bytes = new byte[split.Length];

            for (var i = 0; i < split.Length; ++i)
                bytes[i] = Convert.ToByte(split[i], 2);

            return bytes;
        }

        public byte[] ParseDecimalString(string s) => default;

        public byte[] ParseHexString(string s) => default;

        public byte[] ParseOctalString(string s) => default;
    }
}
