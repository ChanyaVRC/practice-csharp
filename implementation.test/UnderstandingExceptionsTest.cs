using User = Implementation.UnderstandingExceptions.User;
using DrinkCategory = Implementation.UnderstandingExceptions.DrinkCategory;
using Xunit.Sdk;

namespace Implementation.Test;

[Trait("Category", "Exception")]
[Trait("TestOf", nameof(UnderstandingExceptions))]
public class UnderstandingExceptionsTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(12345)]
    [InlineData(int.MaxValue)]
    public void AllowOnlyPositiveValueTest_PositiveValues(int value)
    {
        UnderstandingExceptions.AllowOnlyPositiveValue(value);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-123)]
    [InlineData(int.MinValue)]
    public void AllowOnlyPositiveValueTest_NonPositiveValues(int value)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => UnderstandingExceptions.AllowOnlyPositiveValue(value));
        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void AllowNumericOnlyIdTest_WithNullId()
    {
        User user = new(null, 20);
        var exception = Assert.Throws<ArgumentException>(() => UnderstandingExceptions.AllowNumericOnlyId(user));
        Assert.Equal("user", exception.ParamName);
    }

    [Fact]
    public void AllowNumericOnlyIdTest_WithEmptyId()
    {
        User user = new(string.Empty, 20);
        var exception = Assert.Throws<ArgumentException>(() => UnderstandingExceptions.AllowNumericOnlyId(user));
        Assert.Equal("user", exception.ParamName);
    } 

    [Fact]
    public void AllowNumericOnlyIdTest_WithNullUser()
    {
        User user = new(null, 20);
        var exception = Assert.Throws<ArgumentException>(() => UnderstandingExceptions.AllowNumericOnlyId(user));
        Assert.Equal("user", exception.ParamName);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("1234567890")]
    [InlineData("12345678901234567890")]
    [InlineData("1234567890123456789012345678901234567890")]
    [InlineData("12345678901234567890123456789012345678901234567890")]
    [InlineData("01234567890123456789012345678901234567890123456789012345678901234567890")]
    [InlineData("0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")]
    public void AllowNumericOnlyIdTest_WithNumericOnlyId(string id)
    {
        User user = new(id, 20);
        UnderstandingExceptions.AllowNumericOnlyId(user);
    }

    [Theory]
    [InlineData("1a")]
    [InlineData("1234567890a")]
    [InlineData("12345678901234567890a")]
    [InlineData("1234567890123456789012345678901234567890a")]
    [InlineData("12345678901234567890123456789012345678901234567890a")]
    [InlineData("01234567890123456789012345678901234567890123456789012345678901234567890a")]
    [InlineData("0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890a")]
    [InlineData("a123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")]
    [InlineData("a0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")]
    [InlineData("a")]
    [InlineData("-1")]
    [InlineData("１")]
    public void AllowNumericOnlyIdTest_WithNonNumericId(string id)
    {
        User user = new(id, 20);
        var exception = Assert.ThrowsAny<ArgumentException>(() => UnderstandingExceptions.AllowNumericOnlyId(user));
        // Check if the exception is of type ArgumentException or ArgumentOutOfRangeException
        try
        {
            Assert.IsType<ArgumentException>(exception);
        }
        catch (IsTypeException)
        {
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }
        Assert.Equal("user", exception.ParamName);
        Assert.Equal(DrinkCategory.None, user.LastDrink);
    }

    [Fact]
    public void DrinkAlcoholButPreventDrinkingUnder20Test_WithNullUser()
    {
        User? user = null;
        var exception = Assert.Throws<ArgumentNullException>(() => UnderstandingExceptions.DrinkAlcoholButPreventDrinkingUnder20(user));
        Assert.Equal("user", exception.ParamName);
    }

    [Theory]
    [InlineData(20)]
    [InlineData(21)]
    public void DrinkAlcoholButPreventDrinkingUnder20Test_GreaterOrEqualsThan20(int age)
    {
        User user = new("1", age);
        UnderstandingExceptions.DrinkAlcoholButPreventDrinkingUnder20(user);
        Assert.Equal(DrinkCategory.Alcohol, user.LastDrink);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(19)]
    public void DrinkAlcoholButPreventDrinkingUnder20Test_LessThan20(int age)
    {
        User user = new("1", age);
        var exception = Assert.Throws<ArgumentException>(() => UnderstandingExceptions.DrinkAlcoholButPreventDrinkingUnder20(user));
        Assert.Equal("user", exception.ParamName);
        Assert.Equal(DrinkCategory.None, user.LastDrink);
    }

    [Theory]
    [InlineData(0, DrinkCategory.NonAlcohol)]
    [InlineData(19, DrinkCategory.NonAlcohol)]
    [InlineData(20, DrinkCategory.NonAlcohol)]
    [InlineData(21, DrinkCategory.NonAlcohol)]
    [InlineData(20, DrinkCategory.Alcohol)]
    [InlineData(21, DrinkCategory.Alcohol)]
    public void DrinkTest_ValidCases(int age, DrinkCategory drinkCategory)
    {
        User user = new("1", age);
        user.Drink(drinkCategory);
        Assert.Equal(drinkCategory, user.LastDrink);
    }

    [Theory]
    [InlineData(0, DrinkCategory.Alcohol)]
    [InlineData(19, DrinkCategory.Alcohol)]
    public void DrinkTest_InvalidCases(int age, DrinkCategory drinkCategory)
    {
        User user = new("1", age);
        Assert.Throws<InvalidOperationException>(() => user.Drink(drinkCategory));
        Assert.Equal(DrinkCategory.None, user.LastDrink);
    }
}