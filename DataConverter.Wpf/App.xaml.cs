using System.Windows;

namespace DataConverter.Wpf
{
    /// <summary>Interaction logic for App.xaml</summary>
    public partial class App : Application
    {
        public new static MainWindow MainWindow => Current.MainWindow as MainWindow;
    }
}
