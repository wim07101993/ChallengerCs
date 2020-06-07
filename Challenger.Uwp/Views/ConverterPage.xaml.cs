using Challenger.Uwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Challenger.Uwp.Views
{
    public sealed partial class ConverterPage : Page
    {
        public ConverterPage()
        {
            InitializeComponent();
            ViewModel = new ConverterViewModel();
        }

        public ConverterViewModel ViewModel
        {
            get => DataContext as ConverterViewModel;
            set => DataContext = value;
        }
    }
}
