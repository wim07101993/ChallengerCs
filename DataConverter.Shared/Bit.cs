using Prism.Mvvm;

namespace DataConverter.Shared
{
    public class Bit : BindableBase
    {
        private readonly byte[] _bytes;

        public Bit(int index, byte[] bytes)
        {
            _bytes = bytes;
            Index = index;
        }

        public int Index { get; }

        public bool Value
        {
            get => (_bytes[Index >> 3] & (1 << (Index & 0b111))) > 0;
            set
            {
                if (value)
                    _bytes[Index >> 3] |= (byte)(1 << (Index & 0b111));
                else
                    _bytes[Index >> 3] &= (byte)~(byte)(1 << (Index & 0b111));
                RaisePropertyChanged();
            }
        }

        public void RaiseValueChanged() => RaisePropertyChanged(nameof(Value));
    }
}
