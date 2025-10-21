using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

Console.WriteLine("PerformanceTest");

BenchmarkRunner.Run<StringConcatBenchmark>();

[MemoryDiagnoser]
public class StringConcatBenchmark
{    
    private int[] data;

    [GlobalSetup]
    public void SetUp()
    {
        data = new int[n];

        for (int i = 0;i < n;i++)
        {
            data[i] = Random.Shared.Next();
        }
    }

    [GlobalCleanup]
    public void CleanUp()
    {
    }

    [Params(2, 10, 100, 1000)]
    public int n;

    [Benchmark]
    public string PlusConcat()
    {
        string s = "";

        for (int i = 0; i < n; i++)
        {
            s += "a";
        }

        return s;
    }

    [Benchmark]
    public string StringBuilderConcat()
    {
        StringBuilder s = new();

        for (int i = 0; i < n; i++)
        {
            s.Append('a');
        }

        return s.ToString();
    }

}
