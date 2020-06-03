using System;

using BenchmarkDotNet.Running;

using DataConverter.Core.Benchmarks.Benchmarks;

namespace DataConverter.Core.Benchmarks
{
    internal class Program
    {
        private static void Main()
        {
            var summary = BenchmarkRunner.Run<ConverterBenchmarks>();
            Console.Write(summary);
            _ = Console.ReadKey();
        }
    }
}
