using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using Challenger.Wpf.ViewModels;

namespace Challenger.Wpf.Views
{
    public partial class ConverterBenchmark : UserControl
    {
        private bool _autoScroll = true;
        private bool _isAutoScrolling;

        public ConverterBenchmark()
        {
            InitializeComponent();

            DataContextChanged += OnDataContextChanged;
            OnDataContextChanged(this, new DependencyPropertyChangedEventArgs(DataContextProperty, null, ViewModel));
        }

        public ConverterBenchmarkViewModel ViewModel
        {
            get => DataContext as ConverterBenchmarkViewModel;
            set => DataContext = value;
        }

        private void OnConsoleOutputScrollviewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (_isAutoScrolling)
                return;

            _autoScroll = ConsoleOutputScrollviewer.VerticalOffset == ConsoleOutputScrollviewer.ScrollableHeight;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is ConverterBenchmarkViewModel oldViewModel)
                oldViewModel.ConsoleOutput.CollectionChanged -= OnConsoleOutputChanged;

            if (e.NewValue is ConverterBenchmarkViewModel newViewModel)
                newViewModel.ConsoleOutput.CollectionChanged += OnConsoleOutputChanged;

        }

        private void OnConsoleOutputChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!_autoScroll)
                return;

            _isAutoScrolling = true;
            ConsoleOutputScrollviewer.ScrollToVerticalOffset(ConsoleOutputScrollviewer.ExtentHeight);
            _isAutoScrolling = false;
        }
    }
}
