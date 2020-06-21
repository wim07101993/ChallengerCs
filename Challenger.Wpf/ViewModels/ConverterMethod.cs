using System;
using System.Reflection;

using Challenger.Wpf.Benchmarks;

using WSharp.Extensions;

namespace Challenger.Wpf.ViewModels
{
    public class ConverterMethod
    {
        public ConverterMethod(MethodInfo info)
        {
            ConverterMethodInfo = info ?? throw new ArgumentNullException(nameof(info));
            BenchmarkMethodInfo = typeof(ConverterBenchmarks).GetMethod(info.Name);
            DisplayName = ConverterMethodInfo.GetDisplayName();
        }

        public MethodInfo ConverterMethodInfo { get; }
        public MethodInfo BenchmarkMethodInfo { get; }
        public string DisplayName { get; }

        public override string ToString() => DisplayName;
    }
}
