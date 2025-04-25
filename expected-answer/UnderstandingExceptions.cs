using System.ComponentModel;

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
            // Check if the drink category is valid.
            switch (drinkCategory)
            {
                case DrinkCategory.Alcohol:
                    if (Age < 20)
                    {
                        throw new InvalidOperationException("User is not allowed to drink alcohol until they are 20 years old.");
                    }
                    break;
                case DrinkCategory.NonAlcohol:
                    break;
                case DrinkCategory.None:
                    throw new ArgumentOutOfRangeException(nameof(drinkCategory), "Drink category should be Alcohol or NonAlcohol.");
                default:
                    throw new InvalidEnumArgumentException("Invalid drink category.", new ArgumentOutOfRangeException(nameof(drinkCategory), "Drink category should be Alcohol or NonAlcohol."));
            }
            LastDrink = drinkCategory;
        }
    }

    public static void AllowOnlyPositiveValue(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be positive.");
        }
    }

    public static void AllowNumericOnlyId(User? user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        string id = user.Id ?? throw new ArgumentException("User ID cannot be null.", nameof(user));
        if (id.Length == 0)
        {
            throw new ArgumentException("User ID cannot be empty.", nameof(user));
        }

        if (id.Any(v => !char.IsAsciiDigit(v)))
        {
            // FormatException is not appropriate here.
            throw new ArgumentException("User ID must be numeric.", nameof(user));
        }
    }

    public static void DrinkAlcoholButPreventDrinkingUnder20(User? user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        if (user.Age < 20)
        {
            throw new ArgumentException("User is not allowed to drink alcohol until they are 20 years old.", nameof(user));
        }
        user.Drink(DrinkCategory.Alcohol);
    }
}