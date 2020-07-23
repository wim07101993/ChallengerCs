using System;
using System.Threading.Tasks;
using System.Windows;

using Challenger.Shared;

namespace Challenger.Wpf.ViewModels
{
    public class ConverterChallengeViewModel : ConverterViewModelBase
    {
        protected override Task InvokeOnSTAThread(Action action)
            => Task.Run(() => Application.Current.Dispatcher.Invoke(action));
    }
}
