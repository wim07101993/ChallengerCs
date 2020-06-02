﻿using System.Text;

namespace DataConverter.Core.TestData
{
    public class MockData
    {
        public Example Zero => new Example
        {
            Bytes = new byte[] { 0x00 },
            BinaryString = "00000000",
            ShortBinaryString = "0",
            OctalString = "000",
            ShortOctalString = "0",
            DecimalString = "000",
            ShortDecimalString = "0",
            HexString = "0",
            ShortHexString = "0",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0, }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0, }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0, }),
            UShort = 0,
            UInt = 0,
            ULong = 0,
            Short = 0,
            Int = 0,
            Long = 0,
            Float = 0,
            Double = 0,
            Decimal = 0,
        };

        public Example FF => new Example
        {
            Bytes = new byte[] { 0xFF },
            BinaryString = "11111111",
            ShortBinaryString = "11111111",
            OctalString = "377",
            ShortOctalString = "377",
            DecimalString = "255",
            ShortDecimalString = "255",
            HexString = "FF",
            ShortHexString = "FF",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0xFF }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0xFF }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0xFF }),
            UShort = 255,
            UInt = 255,
            ULong = 255,
            Short = 255,
            Int = 255,
            Long = 255,
            Float = (float)3.57E-43,
            Double = 1.26E-321,
            Decimal = 0,
        };

        public Example BinaryBytes => new Example
        {
            Bytes = new byte[] { 0xAA, 0xAA, 0xAA, 0xAA },
            BinaryString = "10101010 10101010 10101010 10101010",
            ShortBinaryString = "10101010 10101010 10101010 10101010",
            OctalString = "252 252 252 252",
            ShortOctalString = "252 252 252 252",
            DecimalString = "170 170 170 170",
            ShortDecimalString = "170 170 170 170",
            HexString = "AA AA AA AA",
            ShortHexString = "AA AA AA AA",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0xAA, 0xAA, 0xAA, 0xAA }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0xAA, 0xAA, 0xAA, 0xAA }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0xAA, 0xAA, 0xAA, 0xAA }),
            UShort = ushort.MaxValue,
            UInt = 2863311530,
            ULong = 2863311530,
            Short = short.MinValue,
            Int = -1431655766,
            Long = 2863311530,
            Float = (float)-3.0316488E-13,
            Double = 1.4146638603E-314,
            Decimal = 0,
        };

        public Example OctalBytes => new Example
        {
            Bytes = new byte[] { 0x53, 0x25, 0x37 },
            BinaryString = "01010011 00100101 00110111",
            ShortBinaryString = "1010011 100101 110111",
            OctalString = "123 045 067",
            ShortOctalString = "123 45 67",
            DecimalString = "083 037 055",
            ShortDecimalString = "83 37 55",
            HexString = "53 25 37",
            ShortHexString = "53 25 37",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x53, 0x25, 0x37 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x53, 0x25, 0x37 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x53, 0x25, 0x37 }),
            UShort = ushort.MaxValue,
            UInt = 5449015,
            ULong = 5449015,
            Short = short.MinValue,
            Int = 5449015,
            Long = 5449015,
            Float = (float)7.635696E-39,
            Double = 2.692171E-317,
            Decimal = 0,
        };

        public Example DecimalBytes => new Example
        {
            Bytes = new byte[] { 0x7b, 0x2d, 0x43, 0x59, 0x62, 0x4c, 0x36, 0x20, 0x1 },
            BinaryString = "01111011 00101101 01000011 01100010 01001100 00110110 00100000 00000001",
            ShortBinaryString = "1111011 101101 1000011 1100010 1001100 110110 100000 1",
            OctalString = "173 055 103 142 114 66 40 01",
            ShortOctalString = "173 55 103 142 114 66 40 1",
            DecimalString = "123 045 067 089 098 076 054 032 001",
            ShortDecimalString = "123 45 67 89 98 76 54 32 1",
            HexString = "7B 2D 43 62 4C 36 20 01",
            ShortHexString = "7B 2D 43 62 4C 36 20 1",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x7b, 0x2d, 0x43, 0x59, 0x62, 0x4c, 0x36, 0x20, 0x1 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x7b, 0x2d, 0x43, 0x59, 0x62, 0x4c, 0x36, 0x20, 0x1 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x7b, 0x2d, 0x43, 0x59, 0x62, 0x4c, 0x36, 0x20, 0x1 }),
            UShort = ushort.MaxValue,
            UInt = uint.MaxValue,
            ULong = ulong.MaxValue,
            Short = short.MinValue,
            Int = int.MinValue,
            Long = long.MinValue,
            Float = float.NaN,
            Double = double.NaN,
            Decimal = 1.400825E-026m,
        };

        public Example Ascii => new Example
        {
            Bytes = new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 },
            BinaryString = "011010000 01100101 01101100 01101100 01101111 00100000 01110111 01101111 01110010 01101100 01100100",
            ShortBinaryString = "11010000 1100101 1101100 1101100 1101111 100000 1110111 1101111 1110010 1101100 1100100",
            OctalString = "150 145 154 154 157 040 167 157 162 154 144",
            ShortOctalString = "150 145 154 154 157 40 167 157 162 154 144",
            DecimalString = "104 101 108 108 111 032 119 111 114 108 100 114",
            ShortDecimalString = "104 101 108 108 111 32 119 111 114 108 100 114",
            HexString = "68 65 6C 6C 6F 20 77 6F 72 6C 64",
            ShortHexString = "68 65 6C 6C 6F 20 77 6F 72 6C 64",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 }),
            UShort = ushort.MaxValue,
            UInt = uint.MaxValue,
            ULong = ulong.MaxValue,
            Short = short.MinValue,
            Int = int.MinValue,
            Long = long.MinValue,
            Float = float.NaN,
            Double = double.NaN,
            Decimal = 3.355873E-086m,
        };

        public Example Utf8 => new Example
        {
            Bytes = new byte[] { 0x75, 0x74, 0x66, 0x38 },
            BinaryString = "01110101 01110100 01100110 00111000",
            ShortBinaryString = "1110101 1110100 1100110 111000",
            OctalString = "165 164 146 070",
            ShortOctalString = "165 164 146 70",
            DecimalString = "117 116 102 056",
            ShortDecimalString = "117 116 102 56",
            HexString = "75 74 66 38",
            ShortHexString = "75 74 66 38",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x75, 0x74, 0x66, 0x38 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x75, 0x74, 0x66, 0x38 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x75, 0x74, 0x66, 0x38 }),
            UShort = ushort.MaxValue,
            UInt = 1970562616,
            ULong = 1970562616,
            Short = short.MinValue,
            Int = 1970562616,
            Long = 1970562616,
            Float = (float)3.098129E+32,
            Double = 9.735872915E-315,
            Decimal = 0,
        };

        public Example Utf32 => new Example
        {
            Bytes = new byte[] { 0x00, 0x00, 0x00, 0x26, 0x00, 0x00, 0x03, 0x20 },
            BinaryString = "00000000 00000000 00000000 00100110 00000000 00000000 00000011 00100000",
            ShortBinaryString = "0 0 0 100110 0 0 11 100000",
            OctalString = "000 000 000 046 000 000 003 040",
            ShortOctalString = "0 0 0 46 0 0 2 40",
            DecimalString = "000 000 000 038 000 000 003 032",
            ShortDecimalString = "0 0 0 38 0 0 3 32",
            HexString = "00 00 00 26 00 00 03 20",
            ShortHexString = "0 0 0 26 0 0 3 20",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x00, 0x00, 0x00, 0x26, 0x00, 0x00, 0x03, 0x20 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x00, 0x00, 0x00, 0x26, 0x00, 0x00, 0x03, 0x20 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x00, 0x00, 0x00, 0x26, 0x00, 0x00, 0x03, 0x20 }),
            UShort = ushort.MaxValue,
            UInt = uint.MaxValue,
            ULong = 163208758048,
            Short = short.MinValue,
            Int = int.MinValue,
            Long = 163208758048,
            Float = float.NaN,
            Double = 8.0635840452E-313,
            Decimal = 7.009763E+020m,
        };

        public Example UShort => new Example
        {
            Bytes = new byte[] { 0x30, 0x39 },
            BinaryString = "00110000 00111001",
            ShortBinaryString = "110000 111001",
            OctalString = "060 071",
            ShortOctalString = "60 71",
            DecimalString = "048 057",
            ShortDecimalString = "48 57",
            HexString = "30 39",
            ShortHexString = "30 39",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x30, 0x39 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x30, 0x39 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x30, 0x39 }),
            UShort = 12345,
            UInt = 12345,
            ULong = 12345,
            Short = 12345,
            Int = 12345,
            Long = 12345,
            Float = (float)1.7299E-41,
            Double = 6.099E-320,
            Decimal = 0,
        };

        public Example UInt => new Example
        {
            Bytes = new byte[] { 0x49, 0x96, 0x02, 0xd3 },
            BinaryString = "01001001 10010110 00000010 11010011",
            ShortBinaryString = "1001001 10010110 10 11010011",
            OctalString = "111 226 002 232",
            ShortOctalString = "111 226 2 323",
            DecimalString = "073 150 002 211",
            ShortDecimalString = "73 150 2 211",
            HexString = "49 96 02 D3",
            ShortHexString = "49 96 2 D3",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x49, 0x96, 0x02, 0xd3 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x49, 0x96, 0x02, 0xd3 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x49, 0x96, 0x02, 0xd3 }),
            UShort = ushort.MaxValue,
            UInt = 1234567891,
            ULong = 1234567891,
            Short = short.MinValue,
            Int = 1234567891,
            Long = 1234567891,
            Float = (float)6.099575824E-315,
            Double = 6.099575824E-315,
            Decimal = 0,
        };

        public Example ULong => new Example
        {
            Bytes = new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb },
            BinaryString = "00000110 11101111 01111001 01111111 10111011",
            ShortBinaryString = "110 11101111 1111001 1111111 10111011",
            OctalString = "006 357 171 177 273",
            ShortOctalString = "6 357 171 177 273",
            DecimalString = "006 239 121 127 187",
            ShortDecimalString = "6 239 121 127 187",
            HexString = "06 EF 79 07 7F BB",
            ShortHexString = "6 EF 79 7 7F BB",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb }),
            UShort = ushort.MaxValue,
            UInt = uint.MaxValue,
            ULong = 7625597484987,
            Short = short.MinValue,
            Int = int.MinValue,
            Long = 7625597484987,
            Float = float.NaN,
            Double = 3.7675457463455E-311,
            Decimal = 3.27429707308344541184E+15m,
        };

        public Example Short => new Example
        {
            Bytes = new byte[] { 0xcf, 0xc7 },
            BinaryString = "11001111 11000111",
            ShortBinaryString = "11001111 11000111",
            OctalString = "317 307",
            ShortOctalString = "317 307",
            DecimalString = "207 199",
            ShortDecimalString = "207 199",
            HexString = "CF C7",
            ShortHexString = "CF C7",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0xcf, 0xc7 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0xcf, 0xc7 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0xcf, 0xc7 }),
            UShort = 51151,
            UInt = 51151,
            ULong = 51151,
            Short = -14385,
            Int = 51151,
            Long = 53191,
            Float = -105984,
            Double = -8.241213573866478E+37,
            Decimal = 14397726533726765056,
        };

        public Example Int => new Example
        {
            Bytes = new byte[] { 0xf8, 0xa4, 0x32, 0xeb },
            BinaryString = "11111000 10100100 00110010 11101011",
            ShortBinaryString = "11111000 10100100 110010 11101011",
            OctalString = "370 244 062 353",
            ShortOctalString = "370 244 062 353",
            DecimalString = "248 164 050 235",
            ShortDecimalString = "248 164 50 235",
            HexString = "F8 A4 32 EB",
            ShortHexString = "F8 A4 32 EB",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0xf8, 0xa4, 0x32, 0xeb }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0xf8, 0xa4, 0x32, 0xeb }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0xf8, 0xa4, 0x32, 0xeb }),
            UShort = ushort.MaxValue,
            UInt = 3945964792,
            ULong = 3945964792,
            Short = short.MinValue,
            Int = -349002504,
            Long = 3945964792,
            Float = (float)-2.1596784E+26,
            Double = -2.3943390158503974E+208,
            Decimal = 16947789732807442432m,
        };

        public Example Long => new Example
        {
            Bytes = new byte[] { 0xf9, 0x10, 0x86, 0xf8, 0x80, 0x45 },
            BinaryString = "11111001 00010000 100000110 11111000 10000000 01000101",
            ShortBinaryString = "11111001 10000 100000110 11111000 10000000 1000101",
            OctalString = "371 020 206 370 200 105",
            ShortOctalString = "371 20 206 370 200 105",
            DecimalString = "249 016 134 248 128 069",
            ShortDecimalString = "249 16 134 248 128 69",
            HexString = "F9 10 86 F8 80 45",
            ShortHexString = "F9 10 86 F8 80 45",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0xf9, 0x10, 0x86, 0xf8, 0x80, 0x45 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0xf9, 0x10, 0x86, 0xf8, 0x80, 0x45 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0xf9, 0x10, 0x86, 0xf8, 0x80, 0x45 }),
            UShort = ushort.MaxValue,
            UInt = uint.MaxValue,
            ULong = 273849379225669,
            Short = short.MinValue,
            Int = int.MinValue,
            Long = 273849379225669,
            Float = float.NaN,
            Double = 1.352995704103546E-309,
            Decimal = -1.17616440213972101103616E-224m,
        };

        public Example Float => new Example
        {
            Bytes = new byte[] { 0x46, 0x40, 0xe6, 0xb7 },
            BinaryString = "01000110 01000000 11100110 10110111",
            ShortBinaryString = "1000110 1000000 11100110 10110111",
            OctalString = "106 100 346 267",
            ShortOctalString = "106 100 346 267",
            DecimalString = "070 064 230 183",
            ShortDecimalString = "70 64 230 183",
            HexString = "46 40 E6 B7",
            ShortHexString = "46 40 E6 B7",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x46, 0x40, 0xe6, 0xb7 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x46, 0x40, 0xe6, 0xb7 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x46, 0x40, 0xe6, 0xb7 }),
            UShort = ushort.MaxValue,
            UInt = 1178658487,
            ULong = 1178658487,
            Short = short.MinValue,
            Int = 1178658487,
            Long = 1178658487,
            Float = (float)12345.679,
            Double = 5.823346666E-315,
            Decimal = 0,
        };

        public Example Double => new Example
        {
            Bytes = new byte[] { 0x40, 0x09, 0x21, 0xfb, 0x54, 0x44, 0x2d, 0x18 },
            BinaryString = "01000000 00001001 00100001 11111011 01010100 01000100 00101101 00011000",
            ShortBinaryString = "1000000 1001 100001 11111011 1010100 1000100 101101 11000",
            OctalString = "100 011 041 373 124 104 055 030",
            ShortOctalString = "100 11 41 373 124 104 055 30",
            DecimalString = "064 009 033 251 084 068 045 024",
            ShortDecimalString = "64 9 33 251 84 68 45 24",
            HexString = "40 09 21 FB 54 44 2D 18",
            ShortHexString = "40 9 21 FB 54 44 2D 18",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0x40, 0x09, 0x21, 0xfb, 0x54, 0x44, 0x2d, 0x18 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0x40, 0x09, 0x21, 0xfb, 0x54, 0x44, 0x2d, 0x18 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0x40, 0x09, 0x21, 0xfb, 0x54, 0x44, 0x2d, 0x18 }),
            UShort = ushort.MaxValue,
            UInt = uint.MaxValue,
            ULong = 4614256656552045848,
            Short = short.MinValue,
            Int = int.MinValue,
            Long = 4614256656552045848,
            Float = float.NaN,
            Double = 3.141592653589793,
            Decimal = 1.98180814291693132603478507520E-040m,
        };

        public Example Decimal => new Example
        {
            Bytes = new byte[] { 0xeb, 0xec, 0xde, 0x35, 0x85, 0x7a, 0xed, 0x5a, 0x57, 0xd5, 0x19, 0xab, 0x00, 0x1c, 0x00, 0x00 },
            BinaryString = "11101011 11101100 11011110 00110101 10000101 01111010 1101101 01011010 010101111 11010101 00011001 10101011 00000000 00011100 00000000 00000000",
            ShortBinaryString = "11101011 11101100 11011110 110101 10000101 1111010 1101101 1011010 10101111 11010101 11001 10101011 0 11100 0 0",
            OctalString = "353 354 336 065 205 172 355 132 127 325 031 253 000 034 000 000 ",
            ShortOctalString = "353 354 336 65 205 172 355 132 127 325 31 253 0 34 0 0 ",
            DecimalString = "235 236 222 053 133 122 237 090 087 213 025 171 000 028 000 000",
            ShortDecimalString = "235 236 222 53 133 122 237 90 87 213 25 171 0 28 0 0",
            HexString = "EB EC DE 35 85 7A ED 5A 57 D5 19 AB 00 1C 00 00",
            ShortHexString = "EB EC DE 35 85 7A ED 5A 57 D5 19 AB 0 1C 0 0",
            AsciiString = Encoding.ASCII.GetString(new byte[] { 0xeb, 0xec, 0xde, 0x35, 0x85, 0x7a, 0xed, 0x5a, 0x57, 0xd5, 0x19, 0xab, 0x00, 0x1c, 0x00, 0x00 }),
            Utf8String = Encoding.UTF8.GetString(new byte[] { 0xeb, 0xec, 0xde, 0x35, 0x85, 0x7a, 0xed, 0x5a, 0x57, 0xd5, 0x19, 0xab, 0x00, 0x1c, 0x00, 0x00 }),
            Utf32String = Encoding.UTF32.GetString(new byte[] { 0xeb, 0xec, 0xde, 0x35, 0x85, 0x7a, 0xed, 0x5a, 0x57, 0xd5, 0x19, 0xab, 0x00, 0x1c, 0x00, 0x00 }),
            UShort = ushort.MaxValue,
            UInt = uint.MaxValue,
            ULong = ulong.MaxValue,
            Short = short.MinValue,
            Int = int.MinValue,
            Long = long.MinValue,
            Float = float.NaN,
            Double = double.NaN,
            Decimal = 2.71828182845904523536028747140E+000m,
        };
    }
}