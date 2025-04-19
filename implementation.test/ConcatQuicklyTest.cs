using System.Diagnostics;

namespace Implementation.Test;

[Trait("TestOf", nameof(ConcatQuickly))]
public class ConcatQuicklyTest
{
    [Fact]
    public void Test_ConcatQuickly()
    {
        Assert.Equal(string.Join(',', Enumerable.Range(0, 10000)), ConcatQuickly.MakeStringOfSequentialNumber());
    }

    [Fact]
    public void Test_ConcatQuickly_SpeedCompare()
    {
        // Warm up the JIT compiler
        _ = string.Join(",", Enumerable.Range(0, 10000));
        _ = ConcatQuickly.MakeStringOfSequentialNumber();

        var expectedStopwatch = Stopwatch.StartNew();
        _ = string.Join(",", Enumerable.Range(0, 10000));
        expectedStopwatch.Stop();

        var actualStopwatch = Stopwatch.StartNew();
        _ = ConcatQuickly.MakeStringOfSequentialNumber();
        actualStopwatch.Stop();

        Assert.True(actualStopwatch.ElapsedTicks <= expectedStopwatch.ElapsedTicks * 2, "ConcatQuickly is too slow");
    }
}