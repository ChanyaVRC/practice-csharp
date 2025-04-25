using System.ComponentModel;
using User = Implementation.UnderstandingExceptions.User;
using DrinkCategory = Implementation.UnderstandingExceptions.DrinkCategory;

namespace Implementation.Test;

[Trait("Category", "Exception")]
[Trait("TestOf", nameof(UnderstandingExceptions))]
public class UnderstandingExceptionsTest_NextStep
{
    [Theory]
    [InlineData(0, DrinkCategory.None, typeof(ArgumentOutOfRangeException))]
    [InlineData(0, (DrinkCategory)999, typeof(InvalidEnumArgumentException))]
    public void DrinkTest_InvalidEnum(int age, DrinkCategory drinkCategory, Type expectedExceptionType)
    {
        User user = new("1", age);
        var exception = Assert.Throws(expectedExceptionType, () => user.Drink(drinkCategory));
        Assert.Equal(DrinkCategory.None, user.LastDrink);
    }
}