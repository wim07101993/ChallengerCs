using System;

namespace DataConverter.Console
{
    [Flags]
    public enum ValueType
    {
        BinaryString = 0x1,
        OctalString = 0x2,
        DecimalString = 0x4,
        HexString = 0x8,
        AsciiString = 0x10,
        UShort = 0x80,
        Short = 0x100,
        UInt = 0x200,
        Int = 0x400,
        ULong = 0x800,
        Float = 0x1000,
        Double = 0x2000,
        Decimal = 0x4000,

        All = 0xFFFF,
    }
}
