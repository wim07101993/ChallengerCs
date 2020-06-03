using System.Windows.Controls;

namespace DataConverter.Wpf
{
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnPageListSelectionChanged(object sender, SelectionChangedEventArgs e) => DrawerHost.IsLeftDrawerOpen = false;
    }
}
