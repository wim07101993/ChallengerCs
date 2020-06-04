using System.Windows;

namespace DataConverter.Wpf
{
    /// <summary>Interaction logic for App.xaml</summary>
    public partial class App : Application
    {
        public static new MainWindow MainWindow => Current.MainWindow as MainWindow;
    }
}
