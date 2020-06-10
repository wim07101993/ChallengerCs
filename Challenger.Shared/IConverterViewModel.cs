using System.Collections.Generic;
using System.ComponentModel;

using Challenger.Shared.ConvertedValueTypes;

namespace Challenger.Shared
{
    public interface IConverterViewModel : INotifyPropertyChanged
    {
        int SelectedConverterIndex { get; set; }
        IEnumerable<string> Converters { get; }

        ConvertedBinaryString BinaryString { get; }
        ConvertedOctalString OctalString { get; }
        ConvertedDecimalString DecimalString { get; }
        ConvertedHexString HexString { get; }
        ConvertedAsciiString AsciiString { get; }
        ConvertedValue<ushort> UShort { get; }
        ConvertedValue<short> Short { get; }
        ConvertedValue<uint> UInt { get; }
        ConvertedValue<int> Int { get; }
        ConvertedValue<ulong> ULong { get; }
        ConvertedValue<long> Long { get; }
        ConvertedValue<float> Float { get; }
        ConvertedValue<double> Double { get; }
        ConvertedValue<decimal> Decimal { get; }
    }
}
