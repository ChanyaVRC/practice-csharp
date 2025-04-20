extern alias Expected;
extern alias Actual;

using BenchmarkDotNet.Running;

namespace Benchmark;

public class Benchmarks
{

}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmarks>();
    }
}