using BenchmarkDotNet.Running;

using DataConverter.Core.Benchmarks.Benchmarks;

namespace DataConverter.Core.Benchmarks
{
    internal class Program
    {
        private static void Main() => _ = BenchmarkRunner.Run<ConverterBenchmarks>();
    }
}
