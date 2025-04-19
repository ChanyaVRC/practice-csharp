namespace Implementation.Test;

[Trait("TestOf", nameof(UsingUsage))]
public class UsingUsageTest
{
    [Fact]
    public void Test_UsingUsage_ResultReference()
    {
        var usingUsage = new UsingUsage();
        Assert.Equal("Valid", usingUsage.Result);
    }

    [Fact]
    public void Test_UsingUsage_PriorityCheck()
    {
        var usingUsage = new UsingUsage();
        Assert.Equal(typeof(Library.UsingUsage.Invalid.PriorityCheck), usingUsage.PriorityCheck);
    }
}