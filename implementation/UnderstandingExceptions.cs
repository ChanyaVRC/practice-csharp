namespace Implementation;

public class UnderstandingExceptions
{
    /// <summary>
    /// Represents the category of a drink.
    /// </summary>
    /// <remarks>This enumeration is used to classify drinks as either alcoholic or non-alcoholic.</remarks>
    public enum DrinkCategory
    {
        /// <summary>
        /// Represents an unknown drink category.
        /// </summary>
        None,
        /// <summary>
        /// Represents an alcoholic drink.
        /// </summary>
        Alcohol,
        /// <summary>
        /// Represents a non-alcoholic drink.
        /// </summary>
        NonAlcohol
    }

    /// <summary>
    /// Represents a user with an ID and age.
    /// </summary>
    /// <param name="Id">User ID</param>
    /// <param name="Age">User Age</param>
    public record class User(string? Id, int Age)
    {
        /// <summary>
        /// Gets or sets the last drink category consumed by the user.
        /// </summary>
        public DrinkCategory LastDrink { get; set; }

        /// <summary>
        /// Drinks a specified category of drink.
        /// </summary>
        /// <remarks>note that this method does not perform any actual drinking action.</remarks>
        public void Drink(DrinkCategory drinkCategory)
        {
            // TODO: Check if the drink category is valid.
            // REMARK: Drinking alcohol is not permitted under the age of 20.
            LastDrink = drinkCategory;
        }
    }

    public static void AllowOnlyPositiveValue(int value)
    {
        // TODO: Check if the value is positive. If not, throw an appropriate exception.
        throw new NotImplementedException();
    }

    public static void AllowNumericOnlyId(User? user)
    {
        // TODO: Check if the user ID is numeric. If not, throw an appropriate exception.
        // REMARK: The user ID should not be null or empty.
        // REMARK: The numeric represent 0 to 9.
        throw new NotImplementedException();
    }

    public static void DrinkAlcoholButPreventDrinkingUnder20(User? user)
    {
        // TODO: Before the user drinks alcohol, check the user's age. If the user is under 20,
        //       throw an appropriate exception.
        throw new NotImplementedException();
    }
}