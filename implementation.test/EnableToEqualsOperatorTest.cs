using Xunit;
namespace Implementation.Test;

[Trait("TestOf", nameof(EnableToEqualsOperator))]
public class EnableToEqualsOperatorTest
{
    [Fact]
    public void Test_Equals()
    {
        Assert.Equal(new EnableToEqualsOperator(1, "test"), new EnableToEqualsOperator(1, "test"));

        Assert.NotEqual(new EnableToEqualsOperator(1, "test"), new EnableToEqualsOperator(2, "test"));
        Assert.NotEqual(new EnableToEqualsOperator(1, "test"), new EnableToEqualsOperator(1, "test2"));
        Assert.NotEqual(new EnableToEqualsOperator(1, "test"), new EnableToEqualsOperator(2, "test2"));

        Assert.True(new EnableToEqualsOperator(1, "test").Equals(new EnableToEqualsOperator(1, "test")));
        Assert.False(new EnableToEqualsOperator(1, "test").Equals(new EnableToEqualsOperator(2, "test")));

        Assert.False(new EnableToEqualsOperator(1, "test").Equals(null));
        Assert.False(new EnableToEqualsOperator(1, "test").Equals(new object()));
    }

    [Fact]
    public void Test_GetHashCode()
    {
        Assert.True(new EnableToEqualsOperator(1, "test").GetHashCode() == new EnableToEqualsOperator(1, "test").GetHashCode());
        Assert.True(new EnableToEqualsOperator(1, "test").GetHashCode() != new EnableToEqualsOperator(2, "test").GetHashCode());
    }

    [Fact]
    public void Test_Operator()
    {
        Assert.True(new EnableToEqualsOperator(1, "test") == new EnableToEqualsOperator(1, "test"));
        Assert.False(new EnableToEqualsOperator(1, "test") == new EnableToEqualsOperator(2, "test"));
        Assert.True(new EnableToEqualsOperator(1, "test") != new EnableToEqualsOperator(2, "test"));
        Assert.False(new EnableToEqualsOperator(1, "test") != new EnableToEqualsOperator(1, "test"));
    }

    [Fact]
    public void Test_Operator_Null()
    {
        Assert.False(new EnableToEqualsOperator(1, "test") == null);
        Assert.True(new EnableToEqualsOperator(1, "test") != null);
    }

    [Fact]
    public void Test_Operator_Null_Reverse()
    {
        Assert.False(null == new EnableToEqualsOperator(1, "test"));
        Assert.True(null != new EnableToEqualsOperator(1, "test"));
    }
}
