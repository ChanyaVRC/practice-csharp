using Xunit;
using Implementation;

namespace Implementation.Test;

[Trait("Category", "Linq")]
[Trait("TestOf", nameof(LinqIntroduction))]
public class LinqIntroductionTest
{
    [Fact]
    public void Test_EnumerateX2()
    {
        Assert.Equal([2, 4, 6], [.. LinqIntroduction.EnumerateX2([1, 2, 3])]);
        Assert.Equal([0, 0, 0], [.. LinqIntroduction.EnumerateX2([0, 0, 0])]);
        Assert.Equal([-2, -4, -6], [.. LinqIntroduction.EnumerateX2([-1, -2, -3])]);
        Assert.Equal([0, -2, -4], [.. LinqIntroduction.EnumerateX2([0, -1, -2])]);
        Assert.IsType(LinqTypes.Select<int, int>(), LinqIntroduction.EnumerateX2([]));
    }

    [Fact]
    public void Test_EnumerateOnlyMinusValues()
    {
        Assert.Equal([-1, -2, -3], [.. LinqIntroduction.EnumerateOnlyMinusValues([1, -1, 2, -2, 3, -3])]);
        Assert.Equal([], [.. LinqIntroduction.EnumerateOnlyMinusValues([1, 2, 3])]);
        Assert.Equal([], [.. LinqIntroduction.EnumerateOnlyMinusValues([])]);
        Assert.IsType(LinqTypes.Where<int>(), LinqIntroduction.EnumerateOnlyMinusValues([]));
    }

    [Fact]
    public void Test_IsOverThanAverage()
    {
        Assert.True(LinqIntroduction.IsOverThanAverage([1, 2, 3], 4));
        Assert.True(LinqIntroduction.IsOverThanAverage([1, 2, 3], 3));
        Assert.False(LinqIntroduction.IsOverThanAverage([1, 2, 3], 2));
        Assert.False(LinqIntroduction.IsOverThanAverage([1, 2, 3], 1));
        Assert.False(LinqIntroduction.IsOverThanAverage([1, 2, 3], -1));
        //Assert.Throws<ArgumentException>(() => LinqIntroduction.IsOverThanAverage([], 0));
    }

    [Fact]
    public void Test_IsOverThanMax()
    {
        Assert.True(LinqIntroduction.IsOverThanMax([1, 2, 3], 4));
        Assert.False(LinqIntroduction.IsOverThanMax([1, 2, 3], 3));
        Assert.False(LinqIntroduction.IsOverThanMax([1, 2, 3], 2));
        Assert.False(LinqIntroduction.IsOverThanMax([1, 2, 3], 1));
        Assert.False(LinqIntroduction.IsOverThanMax([1, 2, 3], -1));
        //Assert.Throws<ArgumentException>(() => LinqIntroduction.IsOverThanMax([], 0));
    }

    [Fact]
    public void Test_EnumerateStringElements()
    {
        Assert.Equal(["a", "b", "c"], [.. LinqIntroduction.EnumerateStringElements(["a", 1, "b", 2, "c"])]);
        Assert.Equal([], [.. LinqIntroduction.EnumerateStringElements([1, 2, 3])]);
        Assert.Equal([], [.. LinqIntroduction.EnumerateStringElements([])]);
        Assert.IsType(LinqTypes.OfType<string>(), LinqIntroduction.EnumerateStringElements([]));
    }

    [Fact]
    public void Test_CastToIntWithRound()
    {
        Assert.Equal([1, 2, 3], [.. LinqIntroduction.CastToIntWithRound([1.4, 2.4, 3.4])]);
        Assert.Equal([2, 3, 4], [.. LinqIntroduction.CastToIntWithRound([1.5, 2.5, 3.5])]);
        Assert.Equal([2, 3, 4], [.. LinqIntroduction.CastToIntWithRound([1.6, 2.6, 3.6])]);
        Assert.Equal([-1, -2, -3], [.. LinqIntroduction.CastToIntWithRound([-1.4, -2.4, -3.4])]);
        Assert.Equal([-2, -3, -4], [.. LinqIntroduction.CastToIntWithRound([-1.5, -2.5, -3.5])]);
        Assert.Equal([-2, -3, -4], [.. LinqIntroduction.CastToIntWithRound([-1.6, -2.6, -3.6])]);
        Assert.IsType(LinqTypes.Select<double, int>(), LinqIntroduction.CastToIntWithRound([]));
    }

    [Fact]
    public void Test_Take2()
    {
        Assert.Equal([1, 2], [.. LinqIntroduction.Take2([1, 2, 3])]);
        Assert.Equal([1, 2], [.. LinqIntroduction.Take2([1, 2])]);
        Assert.Equal([1, 2], [.. LinqIntroduction.Take2([1, 2, 3, 4])]);
        Assert.Equal([], [.. LinqIntroduction.Take2([])]);
        Assert.IsType(LinqTypes.Take<int>(), LinqIntroduction.Take2([]));
    }

    [Fact]
    public void Test_Skip3()
    {
        Assert.Equal([4, 5], [.. LinqIntroduction.Skip3([1, 2, 3, 4, 5])]);
        Assert.Equal([4], [.. LinqIntroduction.Skip3([1, 2, 3, 4])]);
        Assert.Equal([], [.. LinqIntroduction.Skip3([1, 2])]);
        Assert.Equal([], [.. LinqIntroduction.Skip3([])]);
        Assert.IsType(LinqTypes.Skip<int>(), LinqIntroduction.Skip3([]));
    }

    [Fact]
    public void Test_Concat()
    {
        Assert.Equal([1, 2, 3, 4, 5], [.. LinqIntroduction.Concat([1, 2, 3], [4, 5])]);
        Assert.Equal([1, 2, 3], [.. LinqIntroduction.Concat([1, 2, 3], [])]);
        Assert.Equal([4, 5], [.. LinqIntroduction.Concat([], [4, 5])]);
        Assert.Equal([], [.. LinqIntroduction.Concat([], [])]);
        Assert.IsType(LinqTypes.Concat<int>(), LinqIntroduction.Concat([], []));
    }

    [Fact]
    public void Test_MakeArray()
    {
        Assert.Equal([1, 2, 3], LinqIntroduction.MakeArray([1, 2, 3]));
        Assert.Equal([], LinqIntroduction.MakeArray([]));
    }
}