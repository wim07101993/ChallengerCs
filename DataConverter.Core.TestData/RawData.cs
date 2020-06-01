using System;
using System.Collections.Generic;

namespace DataConverter.Core.TestData
{
    public static class RawData
    {
        public static byte[] Zero => new byte[] { 0x00 };
        public static byte[] FF => new byte[] { 0xFF };
        public static byte[] BinaryBytes => new byte[] { 0b10101010, 0b10101010, 0b10101010, 0b10101010 };
        public static byte[] OctalBytes => new byte[] { 0x53, 0x25, 0x37 };
        public static byte[] DecimalBytes => new byte[] { 123, 45, 67, 89, 98, 67, 45, 32, 1 };
        public static byte[] Ascii => new byte[] { 104, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100 };
        public static byte[] Utf8 => new byte[] { 0x75, 0x74, 0x66, 0x38 };
        public static byte[] Utf32 => new byte[] { 0x00, 0x00, 0x26, 0x00, 0x00, 0x03, 0x20 };
        public static byte[] Base64 => new byte[] { 84, 71, 86, 48, 74, 51, 77, 103, 90, 71, 56, 103, 99, 50, 57, 116, 90, 88, 82, 111, 97, 87, 53, 110, 73, 71, 78, 121, 89, 88, 78, 53 };
        public static byte[] UShort => new byte[] { 0x30, 0x39 };
        public static byte[] UInt => new byte[] { 0x49, 0x96, 0x02, 0xd3 };
        public static byte[] ULong => new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb };
        public static byte[] Short => new byte[] { 0xcf, 0xc7 };
        public static byte[] Int => new byte[] { 0xf8, 0xa4, 0x32, 0xeb };
        public static byte[] Long => new byte[] { 0xf9, 0x10, 0x86, 0xf8, 0x80, 0x45 };
        public static byte[] Float => new byte[] { 0xb7, 0xe6, 0x40, 0x46 };
        public static byte[] Double => BitConverter.GetBytes(Math.PI);

        public static unsafe IEnumerable<byte> Decimal
        {
            get
            {
                // Code interpolated from https://referencesource.microsoft.com/#mscorlib/system/bitconverter.cs
                var d = 2.71828182845904523536028747135266249775724709369995957496696762772M;
                var bytes = new byte[128];
                fixed (byte* b = bytes)
                    *(decimal*)b = d;
                return bytes;
            }
        }


    }
}
