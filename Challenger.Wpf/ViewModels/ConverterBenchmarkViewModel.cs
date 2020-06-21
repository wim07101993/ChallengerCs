using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

using Challenger.Core;
using Challenger.Core.Converters;
using Challenger.Wpf.Benchmarks;
using Challenger.Wpf.Services;

using LiveCharts;
using LiveCharts.Wpf;

using Prism.Commands;
using Prism.Mvvm;

using WSharp.Extensions;

namespace Challenger.Wpf.ViewModels
{
    public partial class ConverterBenchmarkViewModel : BindableBase
    {
        private ICommand _benchmarkCommand;
        private string[] _enabledMethods;

        public ConverterBenchmarkViewModel()
        {
            Console.SetOut(ConsoleOutput);

            MethodEnablers = typeof(IConverter)
                .GetMethods()
                .Select(x => new Enabler<ConverterMethod>(new ConverterMethod(x), false))
                .ToArray();
        }

        public Enabler<ConverterMethod>[] MethodEnablers { get; }

        public string[] EnabledMethods
        {
            get => _enabledMethods;
            set => SetProperty(ref _enabledMethods, value);
        }

        public ObservableTextReader ConsoleOutput { get; } = new ObservableTextReader();

        public SeriesCollection SeriesCollection { get; } = new SeriesCollection();

        public ICommand BenchmarkCommand => _benchmarkCommand ??= new DelegateCommand(() => _ = BenchmarkAsync());

        public Task BenchmarkAsync() => Task.Run(() =>
        {
            Summary summary;
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ConsoleOutput.Clear();
                    SeriesCollection.Clear();
                });

                var enabledMethods = MethodEnablers
                    .Where(x => x.IsEnabled)
                    .Select(x => x.Item)
                    .ToList();

                EnabledMethods = enabledMethods
                    .Select(x => x.ConverterMethodInfo.Name)
                    .ToArray();

                var methods = enabledMethods
                    .Select(x => x.BenchmarkMethodInfo)
                    .ToArray();

                summary = BenchmarkRunner.Run(typeof(ConverterBenchmarks), methods);
                //var reports = summary.Reports;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Benchmark failed: {e.Message}");
                return;
            }

            InterpreteSummary(summary);
        });

        public void InterpreteSummary(Summary summary)
        {
            Console.WriteLine("Interpreting results");
            AddRowSeries(summary, 0, "DotNet");
            AddRowSeries(summary, 1, "Linq");
            AddRowSeries(summary, 2, "Performance");
            AddRowSeries(summary, 3, "Obfuscated");
        }

        public void AddRowSeries(Summary summary, int converterIndex, string title)
        {
            Console.WriteLine($"Interpreting {title} results");
            var cases = summary.BenchmarksCases
               .Where(x => (int)x.Parameters["ConverterIndex"] == converterIndex)
               .ToList();

            var means = summary.Reports
                .Where(x => cases.Contains(x.BenchmarkCase))
                .Select(x => x.ResultStatistics.Mean);

            Application.Current.Dispatcher.Invoke(() =>
            {
                SeriesCollection.Add(new RowSeries
                {
                    Title = title,
                    Values = new ChartValues<double>(means)
                });
            });
        }
    }
}
