using System;
using System.Threading.Tasks;
using System.Windows;

using DataConverter.Shared;

namespace DataConverter.Wpf.ViewModels
{
    public class ConverterViewModel : ConverterViewModelBase
    {
        protected override Task InvokeOnSTAThread(Action action)
            => Task.Run(() => Application.Current.Dispatcher.Invoke(action));
    }
}
