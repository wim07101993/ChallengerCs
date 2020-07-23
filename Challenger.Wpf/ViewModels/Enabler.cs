using Prism.Mvvm;

namespace Challenger.Wpf.ViewModels
{
    public class Enabler<T> : BindableBase
    {
        private bool _isEnabled;

        public Enabler(T item, bool isEnabled = false)
        {
            Item = item;
            IsEnabled = isEnabled;
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public T Item { get; }
    }
}
