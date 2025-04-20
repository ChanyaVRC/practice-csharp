using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Implementation.Test;

[Trait("TestOf", nameof(UnderstandingCast))]
public class UnderstandingCastTest
{
    private readonly UnderstandingCast _understandingCast;
    public UnderstandingCastTest()
    {
        _understandingCast = new UnderstandingCast();
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(0, true)]
    [InlineData(-1, true)]
    [InlineData(int.MaxValue, true)]
    [InlineData(int.MinValue, true)]
    [InlineData(1L, false)]
    [InlineData("", false)]
    [InlineData((short)1, false)]
    [InlineData(null, false)]
    public void Test_CanCastToInt32(object? value, bool expected)
    {
        Assert.Equal(expected, _understandingCast.CanCastToInt32(value));
    }

    [Theory]
    [MemberData(nameof(CanCastData))]
    public void Test_CanCastTo(object? data, bool[] expected)
    {
        Assert.Equal(expected[0], _understandingCast.CanCastTo<int>(data));
        Assert.Equal(expected[1], _understandingCast.CanCastTo<long>(data));
        Assert.Equal(expected[2], _understandingCast.CanCastTo<string>(data));
        Assert.Equal(expected[3], _understandingCast.CanCastTo<Base>(data));
        Assert.Equal(expected[4], _understandingCast.CanCastTo<Derived>(data));
        Assert.Equal(expected[5], _understandingCast.CanCastTo<Derived2>(data));
        Assert.Equal(expected[6], _understandingCast.CanCastTo<Derived3>(data));
        Assert.Equal(expected[7], _understandingCast.CanCastTo<Derived4>(data));
        Assert.Equal(expected[8], _understandingCast.CanCastTo<Struct>(data));

        Assert.True(_understandingCast.CanCastTo<object>(data));
        Assert.Equal(data is ValueType || data is null, _understandingCast.CanCastTo<ValueType>(data));
    }

    [Theory]
    [MemberData(nameof(CanUpperCastData))]
    public void Test_CanUpperCast(object? data, bool[] expected)
    {
        Assert.False(_understandingCast.CanUpperCast<int>(data));
        Assert.False(_understandingCast.CanUpperCast<long>(data));
        Assert.False(_understandingCast.CanUpperCast<string>(data));
        Assert.Equal(expected[0], _understandingCast.CanUpperCast<Base>(data));
        Assert.Equal(expected[1], _understandingCast.CanUpperCast<Derived>(data));
        Assert.Equal(expected[2], _understandingCast.CanUpperCast<Derived2>(data));
        Assert.Equal(expected[3], _understandingCast.CanUpperCast<Derived3>(data));
        Assert.Equal(expected[4], _understandingCast.CanUpperCast<Derived4>(data));
        Assert.False(_understandingCast.CanUpperCast<Struct>(data));

        Assert.Equal(data?.GetType() != typeof(object), _understandingCast.CanUpperCast<object>(data));
        Assert.Equal(data is ValueType, _understandingCast.CanUpperCast<ValueType>(data));
    }

    #region TestData
    public static TheoryData<object?, bool[]> CanCastData()
    {
        return new TheoryData<object?, bool[]>
        {
            { 1,              [true,  false, false, false, false, false, false, false, false] },
            { 1L,             [false, true,  false, false, false, false, false, false, false] },
            { "",             [false, false, true,  false, false, false, false, false, false] },
            { (short)1,       [false, false, false, false, false, false, false, false, false] },
            { null,           [false, false, true,  true,  true,  true,  true,  true , false] },
            { new object(),   [false, false, false, false, false, false, false, false, false] },
            { new Base(),     [false, false, false, true,  false, false, false, false, false] },
            { new Derived(),  [false, false, false, true,  true,  false, false, false, false] },
            { new Derived2(), [false, false, false, true,  false, true,  false, false, false] },
            { new Derived3(), [false, false, false, true,  true,  false, true,  false, false] },
            { new Derived4(), [false, false, false, true,  true,  false, true,  true , false] },
            { new Struct(),   [false, false, false, false, false, false, false, false, true ] },
        };
    }

    public static TheoryData<object?, bool[]> CanUpperCastData()
    {
        return new TheoryData<object?, bool[]>
        {
            { 1,              [false, false, false, false, false] },
            { 1L,             [false, false, false, false, false] },
            { "",             [false, false, false, false, false] },
            { (short)1,       [false, false, false, false, false] },
            { null,           [true,  true,  true,  true,  false] },
            { new object(),   [false, false, false, false, false] },
            { new Base(),     [false, false, false, false, false] },
            { new Derived(),  [true,  false, false, false, false] },
            { new Derived2(), [true,  false, false, false, false] },
            { new Derived3(), [true,  true,  false, false, false] },
            { new Derived4(), [true,  true,  false, true,  false] },
            { new Struct(),   [false, false, false, false, false] },
        };
    }

    struct Struct { }
    class Base { }
    class Derived : Base { }
    class Derived2 : Base { }
    class Derived3 : Derived { }
    sealed class Derived4 : Derived3 { }
    #endregion
}
