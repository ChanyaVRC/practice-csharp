namespace Implementation.Test;

[Trait("TestOf", nameof(UnderstandingRuntimeType))]
public class UnderstandingRuntimeTypeTest
{
    [Fact]
    public void Test_GetCompileTimeType()
    {
        Assert.Equal(typeof(int), UnderstandingRuntimeType.GetCompileTimeType(1));
        Assert.Equal(typeof(uint), UnderstandingRuntimeType.GetCompileTimeType(1u));
        Assert.Equal(typeof(ValueType), UnderstandingRuntimeType.GetCompileTimeType<ValueType>(1u));
        Assert.Equal(typeof(string), UnderstandingRuntimeType.GetCompileTimeType(""));
        Assert.Equal(typeof(object), UnderstandingRuntimeType.GetCompileTimeType<object>(""));
        Assert.Equal(typeof(object), UnderstandingRuntimeType.GetCompileTimeType(new object()));
        Assert.Equal(typeof(Class), UnderstandingRuntimeType.GetCompileTimeType(new Class()));
        Assert.Equal(typeof(object), UnderstandingRuntimeType.GetCompileTimeType<object>(new Class()));
        Assert.Equal(typeof(Class), UnderstandingRuntimeType.GetRuntimeType<Class>(null));
    }

    [Fact]
    public void Test_GetRuntimeType()
    {
        Assert.Equal(typeof(int), UnderstandingRuntimeType.GetRuntimeType(1));
        Assert.Equal(typeof(uint), UnderstandingRuntimeType.GetRuntimeType(1u));
        Assert.Equal(typeof(uint), UnderstandingRuntimeType.GetRuntimeType<ValueType>(1u));
        Assert.Equal(typeof(string), UnderstandingRuntimeType.GetRuntimeType(""));
        Assert.Equal(typeof(string), UnderstandingRuntimeType.GetRuntimeType<object>(""));
        Assert.Equal(typeof(object), UnderstandingRuntimeType.GetRuntimeType(new object()));
        Assert.Equal(typeof(Class), UnderstandingRuntimeType.GetRuntimeType(new Class()));
        Assert.Equal(typeof(Class), UnderstandingRuntimeType.GetRuntimeType<object>(new Class()));
        Assert.Null(UnderstandingRuntimeType.GetRuntimeType<Class?>(null));
    }

    class Class { }
}