using System;
using System.Diagnostics;
using System.Windows.Controls;

using DataConverter.Shared;

using Prism.Events;

namespace DataConverter.Wpf
{
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            _ = EventAggregator.GetEvent<ErrorEvent>().Subscribe(OnErrorEvent);
        }

        public IEventAggregator EventAggregator { get; internal set; } = new EventAggregator();

        private void OnPageListSelectionChanged(object sender, SelectionChangedEventArgs e) => DrawerHost.IsLeftDrawerOpen = false;

        private void OnErrorEvent(string message)
        {
            try
            {
                Dispatcher.Invoke(() => MainSnackbar.MessageQueue.Enqueue(message));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to show error on snackmbar: {e.Message}");
            }
        }
    }
}
