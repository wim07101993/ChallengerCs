using System.Collections.Generic;
using System.ComponentModel;

namespace DataConverter.Shared
{
    public interface IConverterViewModel : INotifyPropertyChanged
    {
        int SelectedConverterIndex { get; set; }
        IEnumerable<string> Converters { get; }

        string BinaryString { get; set; }
        string OctalString { get; set; }
        string DecimalString { get; set; }
        string HexString { get; set; }
        string AsciiString { get; set; }
        string Utf8String { get; set; }
        string Utf32String { get; set; }
        ushort UShort { get; set; }
        short Short { get; set; }
        uint UInt { get; set; }
        int Int { get; set; }
        ulong ULong { get; set; }
        long Long { get; set; }
        float Float { get; set; }
        double Double { get; set; }
        decimal Decimal { get; set; }
    }
}
