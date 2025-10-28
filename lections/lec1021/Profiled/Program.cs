using System.Diagnostics;

Console.WriteLine("Hello, World!");

var sw = Stopwatch.StartNew();
Calculate();
sw.Stop();

Console.WriteLine(sw.ElapsedMilliseconds);
void Calculate()
{
    var result = 0;

    for (int i = 0; i < 10_000_000; i++)
        result += i % 3 == 0 ? i / 3 : i / 2;
}