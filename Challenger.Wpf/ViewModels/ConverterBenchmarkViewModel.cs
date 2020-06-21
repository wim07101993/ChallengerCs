using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using BenchmarkDotNet.Running;

using Challenger.Core;
using Challenger.Core.Converters;
using Challenger.Wpf.Benchmarks;
using Challenger.Wpf.Services;

using Prism.Commands;
using Prism.Mvvm;

namespace Challenger.Wpf.ViewModels
{
    public partial class ConverterBenchmarkViewModel : BindableBase
    {
        private ICommand _benchmarkCommand;

        public Enabler<ConverterMethod>[] EnabledMethods { get; } = typeof(IConverter)
            .GetMethods()
            .Select(x => new Enabler<ConverterMethod>(new ConverterMethod(x), false))
            .ToArray();

        public ICommand BenchmarkCommand => _benchmarkCommand ??= new DelegateCommand(() => _ = BenchmarkAsync());

        public ObservableTextReader ConsoleOutput { get; } = new ObservableTextReader();

        public ConverterBenchmarkViewModel()
        {
            Console.SetOut(ConsoleOutput);
        }

        public Task BenchmarkAsync() => Task.Run(() =>
        {
            try
            {
                ConsoleOutput.Clear();
                var methods = EnabledMethods
                    .Where(x => x.IsEnabled)
                    .Select(x => x.Item.BenchmarkMethodInfo)
                    .ToArray();

                _ = BenchmarkRunner.Run(typeof(ConverterBenchmarks), methods);
            }
            catch
            {
            }
        });
    }
}
