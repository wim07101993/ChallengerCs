using System;
using System.Threading.Tasks;

using DataConverter.Shared;

using Windows.UI.Core;

namespace DataConverter.Uwp.ViewModels
{
    public class ConverterViewModel : ConverterViewModelBase
    {
        protected override Task InvokeOnSTAThread(Action action)
            => Task.Run(async () => await App.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action()));
    }
}
