using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Challenger.Core.Converters
{
    public class PerformanceConverter : IConverter
    {
        #region array string

        public string GetBinaryString(byte[] bytes)
        {
            // bytes.Length * 9 = 8 1/0's + the '-' between bytes
            // -1 because the first byte is not preceded by a '-'
            var builder = new StringBuilder((bytes.Length * 9) - 1);

            var l = bytes.Length - 1;

            for (var j = 7; j >= 0; j--)
                _ = builder.Append((bytes[l] & (1 << j)) == 0 ? '0' : '1');

            for (var i = l - 1; i >= 0; i--)
            {
                _ = builder.Append('-');
                for (var j = 7; j >= 0; j--)
                    _ = builder.Append((bytes[i] & (1 << j)) == 0 ? '0' : '1');
            }

            return builder.ToString();
        }

        public string GetOctalString(byte[] bytes)
        {
            // bytes.Length * 4 = 3 digits + the '-' between bytes
            // -1 because the first byte is not preceded by a '-'
            var builder = new StringBuilder((bytes.Length * 4) - 1);

            var l = bytes.Length - 1;

            _ = builder
                .Append(((0b1100_0000) & bytes[l]) >> 6)
                .Append(((0b0011_1000) & bytes[l]) >> 3)
                .Append((0b0000_0111) & bytes[l]);

            for (var i = l - 1; i >= 0; i--)
            {
                _ = builder
                    .Append('-')
                    .Append(((0b1100_0000) & bytes[i]) >> 6)
                    .Append(((0b0011_1000) & bytes[i]) >> 3)
                    .Append((0b0000_0111) & bytes[i]);
            }

            return builder.ToString();
        }

        public string GetDecimalString(byte[] bytes)
        {
            // bytes.Length * 4 = 3 digits + the '-' between bytes
            // -1 because the first byte is not preceded by a '-'
            var builder = new StringBuilder((bytes.Length * 4) - 1);

            var l = bytes.Length - 1;

            _ = builder.Append(bytes[l]);

            for (var i = l - 1; i >= 0; i--)
            {
                _ = builder
                    .Append('-')
                    .Append(bytes[i]);
            }

            return builder.ToString();
        }

        public string GetHexString(byte[] bytes)
        {
            // bytes.Length * 3 = 2 digits + the '-' between bytes
            // -1 because the first byte is not preceded by a '-'
            var builder = new StringBuilder((bytes.Length * 3) - 1);

            var l = bytes.Length - 1;

            _ = builder
                .Append(NibbleToHexString(((0b1111_0000) & bytes[l]) >> 4))
                .Append(NibbleToHexString((0b0000_1111) & bytes[l]));

            for (var i = l - 1; i >= 0; i--)
            {
                _ = builder
                    .Append('-')
                    .Append(NibbleToHexString(((0b1111_0000) & bytes[i]) >> 4))
                    .Append(NibbleToHexString((0b0000_1111) & bytes[i]));
            }

            return builder.ToString();

            static string NibbleToHexString(int nible) => nible switch
            {
                10 => "A",
                11 => "B",
                12 => "C",
                13 => "D",
                14 => "E",
                15 => "F",
                _ => nible.ToString(),
            };
        }

        public byte[] ParseBinaryString(string s)
        {
            var bytes = new byte[s.Length >> 1];
            var byteCount = 0;
            var byteStarted = false;
            var bitIndex = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case '0':
                        bitIndex++;
                        byteStarted = true;
                        break;

                    case '1':
                        bytes[byteCount] |= (byte)(1 << bitIndex);
                        bitIndex++;
                        byteStarted = true;
                        break;

                    default:
                        bitIndex = 0;
                        if (byteStarted)
                        {
                            byteStarted = false;
                            byteCount++;
                        }
                        break;
                }

                if (bitIndex == 8)
                {
                    byteStarted = false;
                    byteCount++;
                    bitIndex = 0;
                }
            }

            if (byteCount == 0)
                return new byte[1];

            if (byteStarted)
                byteCount++;

            var result = new byte[byteCount];
            for (var i = 0; i < byteCount; i++)
                result[i] = bytes[i];

            return result;
        }

        public byte[] ParseOctalString(string s)
        {
            var bytes = new byte[s.Length >> 1];
            var byteCount = 0;
            var byteStarted = false;
            var digitIndex = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case '0':
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '1':
                        bytes[byteCount] += (byte)FastPow(8, digitIndex);
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '2':
                        bytes[byteCount] += (byte)(2 * FastPow(8, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '3':
                        bytes[byteCount] += (byte)(3 * FastPow(8, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '4':
                        bytes[byteCount] += (byte)(4 * FastPow(8, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '5':
                        bytes[byteCount] += (byte)(5 * FastPow(8, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '6':
                        bytes[byteCount] += (byte)(6 * FastPow(8, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '7':
                        bytes[byteCount] += (byte)(7 * FastPow(8, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    default:
                        digitIndex = 0;
                        if (byteStarted)
                        {
                            byteStarted = false;
                            byteCount++;
                        }
                        break;
                }

                if (digitIndex == 3)
                {
                    byteStarted = false;
                    byteCount++;
                    digitIndex = 0;
                }
            }

            if (byteCount == 0)
                return new byte[1];

            if (byteStarted)
                byteCount++;

            var result = new byte[byteCount];
            for (var i = 0; i < byteCount; i++)
                result[i] = bytes[i];

            return result;
        }

        public byte[] ParseDecimalString(string s)
        {
            var bytes = new byte[s.Length >> 1];
            var byteCount = 0;
            var byteStarted = false;
            var digitIndex = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case '0':
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '1':
                        bytes[byteCount] += (byte)FastPow(10, digitIndex);
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '2':
                        bytes[byteCount] += (byte)(2 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '3':
                        bytes[byteCount] += (byte)(3 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '4':
                        bytes[byteCount] += (byte)(4 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '5':
                        bytes[byteCount] += (byte)(5 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '6':
                        bytes[byteCount] += (byte)(6 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '7':
                        bytes[byteCount] += (byte)(7 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '8':
                        bytes[byteCount] += (byte)(8 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '9':
                        bytes[byteCount] += (byte)(9 * FastPow(10, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    default:
                        digitIndex = 0;
                        if (byteStarted)
                        {
                            byteStarted = false;
                            byteCount++;
                        }
                        break;
                }

                if (digitIndex == 3)
                {
                    byteStarted = false;
                    byteCount++;
                    digitIndex = 0;
                }
            }

            if (byteCount == 0)
                return new byte[1];

            if (byteStarted)
                byteCount++;

            var result = new byte[byteCount];
            for (var i = 0; i < byteCount; i++)
                result[i] = bytes[i];

            return result;
        }

        public byte[] ParseHexString(string s)
        {
            var bytes = new byte[s.Length >> 1];
            var byteCount = 0;
            var byteStarted = false;
            var digitIndex = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case '0':
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '1':
                        bytes[byteCount] += (byte)FastPow(16, digitIndex);
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '2':
                        bytes[byteCount] += (byte)(0x2 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '3':
                        bytes[byteCount] += (byte)(0x3 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '4':
                        bytes[byteCount] += (byte)(0x4 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '5':
                        bytes[byteCount] += (byte)(0x5 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '6':
                        bytes[byteCount] += (byte)(0x6 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '7':
                        bytes[byteCount] += (byte)(0x7 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '8':
                        bytes[byteCount] += (byte)(0x8 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case '9':
                        bytes[byteCount] += (byte)(0x9 * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case 'A':
                    case 'a':
                        bytes[byteCount] += (byte)(0xa * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case 'B':
                    case 'b':
                        bytes[byteCount] += (byte)(0xb * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case 'C':
                    case 'c':
                        bytes[byteCount] += (byte)(0xc * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case 'D':
                    case 'd':
                        bytes[byteCount] += (byte)(0xd * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case 'E':
                    case 'e':
                        bytes[byteCount] += (byte)(0xe * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    case 'F':
                    case 'f':
                        bytes[byteCount] += (byte)(0xf * FastPow(16, digitIndex));
                        digitIndex++;
                        byteStarted = true;
                        break;

                    default:
                        digitIndex = 0;
                        if (byteStarted)
                        {
                            byteStarted = false;
                            byteCount++;
                        }
                        break;
                }

                if (digitIndex == 2)
                {
                    byteStarted = false;
                    byteCount++;
                    digitIndex = 0;
                }
            }

            if (byteCount == 0)
                return new byte[1];

            if (byteStarted)
                byteCount++;

            var result = new byte[byteCount];
            for (var i = 0; i < byteCount; i++)
                result[i] = bytes[i];

            return result;
        }

        private int FastPow(int x, int exp)
        {
            switch (exp)
            {
                case 0: return 1;

                default:
                    for (var i = 1; i < exp; i++)
                        x *= x;
                    return x;
            }
        }

        #endregion array string

        #region encoding

        public string GetAsciiString(byte[] bytes) => Encoding.ASCII.GetString(bytes);

        public byte[] GetAsciiBytes(string s) => Encoding.ASCII.GetBytes(s);

        #endregion encoding

        #region to number

        public unsafe ushort GetUShort(byte[] bytes)
        {
            if (bytes.Length < 2)
            {
                var ret = new byte[2];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 2));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(ushort*)pbyte;
        }

        public unsafe short GetShort(byte[] bytes)
        {
            if (bytes.Length < 2)
            {
                var ret = new byte[2];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 2));
            }

            fixed (byte* pbyte = &bytes[0])
                return *(short*)pbyte;
        }

        public unsafe uint GetUInt(byte[] bytes)
        {
            if (bytes.Length < 4)
            {
                var ret = new byte[4];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 4));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(uint*)pbyte;
        }

        public unsafe int GetInt(byte[] bytes)
        {
            if (bytes.Length < 4)
            {
                var ret = new byte[4];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 4));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(int*)pbyte;
        }

        public unsafe ulong GetULong(byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                var ret = new byte[8];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 8));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(ulong*)pbyte;
        }

        public unsafe long GetLong(byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                var ret = new byte[8];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 8));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(long*)pbyte;
        }

        public unsafe float GetFloat(byte[] bytes)
        {
            if (bytes.Length < 4)
            {
                var ret = new byte[4];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 4));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(float*)pbyte;
        }

        public unsafe double GetDouble(byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                var ret = new byte[8];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 8));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(double*)pbyte;
        }

        public unsafe decimal GetDecimal(byte[] bytes)
        {
            if (bytes.Length < 16)
            {
                var ret = new byte[16];
                Array.Copy(bytes, ret, Math.Min(bytes.Length, 16));
                bytes = ret;
            }

            fixed (byte* pbyte = &bytes[0])
                return *(decimal*)pbyte;
        }

        #endregion to number

        #region from number

        public unsafe byte[] GetUShortBytes(ushort s)
        {
            var bytes = new byte[2];
            fixed (byte* b = bytes)
                *(ushort*)b = s;
            return bytes;
        }

        public unsafe byte[] GetShortBytes(short s)
        {
            var bytes = new byte[2];
            fixed (byte* b = bytes)
                *(short*)b = s;
            return bytes;
        }

        public unsafe byte[] GetUIntBytes(uint i)
        {
            var bytes = new byte[4];
            fixed (byte* b = bytes)
                *(uint*)b = i;
            return bytes;
        }

        public unsafe byte[] GetIntBytes(int i)
        {
            var bytes = new byte[4];
            fixed (byte* b = bytes)
                *(int*)b = i;
            return bytes;
        }

        public unsafe byte[] GetULongBytes(ulong l)
        {
            var bytes = new byte[8];
            fixed (byte* b = bytes)
                *(ulong*)b = l;
            return bytes;
        }

        public unsafe byte[] GetLongBytes(long l)
        {
            var bytes = new byte[8];
            fixed (byte* b = bytes)
                *(long*)b = l;
            return bytes;
        }

        public unsafe byte[] GetFloatBytes(float f)
        {
            var bytes = new byte[4];
            fixed (byte* b = bytes)
                *(float*)b = f;
            return bytes;
        }

        public unsafe byte[] GetDoubleBytes(double d)
        {
            var bytes = new byte[8];
            fixed (byte* b = bytes)
                *(double*)b = d;
            return bytes;
        }

        public unsafe byte[] GetDecimalBytes(decimal d)
        {
            var bytes = new byte[16];
            fixed (byte* b = bytes)
                *(decimal*)b = d;

            return bytes;
        }

        #endregion from number
    }
}
