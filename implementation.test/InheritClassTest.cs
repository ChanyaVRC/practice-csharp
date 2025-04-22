using Library.InheritClass;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.ComponentModel.Design;
using System.Reflection;

namespace Implementation.Test;

[Trait("TestOf", nameof(InheritClass))]
public class InheritClassTest
{
    #region TestClass
    private class Cat() : Animal("Test")
    {
        public override string ConvertToCry(string word) => throw new NotImplementedException();
    }
    private class Dog() : Animal("Test")
    {
        public override string ConvertToCry(string word) => throw new NotImplementedException();
    }
    private class Human() : Animal("Test")
    {
        public override string ConvertToCry(string word) => throw new NotImplementedException();
    }
    #endregion

    public static Type? GetClass(string name)
        => typeof(InheritClass).GetNestedType(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

    public static Animal GetInstance(string className)
    {
        Type? type = GetClass(className);
        Assert.NotNull(type);

        Animal? animal;
        try
        {
            animal = (Animal?)Activator.CreateInstance(type, ["TestName"]);
        }
        catch (MissingMethodException)
        {
            animal = (Animal?)Activator.CreateInstance(type, ["Jane", "Doe"]);
        }
        Assert.NotNull(animal);
        return animal;
    }

    public static Animal GetHumanInstance(string firstName, string lastName, GeneticSex sex)
    {
        Type? type = GetClass("Human");
        Assert.NotNull(type);

        Animal? human = (Animal?)Activator.CreateInstance(type, [firstName, lastName]);
        Assert.NotNull(human);
        typeof(Animal).GetProperty(nameof(human.GeneticSex))!.SetValue(human, sex);
        return human;
    }

    [Fact]
    public void Test_IsHuman()
    {
        MethodInfo? isHumanMethod = typeof(InheritClass).GetMethod("IsHuman", BindingFlags.Public | BindingFlags.Static, [typeof(Animal)]);
        Assert.NotNull(isHumanMethod);

        Assert.True(isHumanMethod.IsPublic, "IsHuman method should be public");
        Assert.True(isHumanMethod.IsStatic, "IsHuman method should be static");
        Assert.Equal(typeof(bool), isHumanMethod.ReturnType);

        Assert.False(isHumanMethod.Invoke(null, [new Cat() { GeneticSex = GeneticSex.Male }]) as bool? ?? false);
        Assert.False(isHumanMethod.Invoke(null, [new Dog() { GeneticSex = GeneticSex.Male }]) as bool? ?? false);
        Assert.True(isHumanMethod.Invoke(null, [new Human() { GeneticSex = GeneticSex.Male }]) as bool? ?? false);
    }

    [Theory]
    [InlineData("Cat")]
    [InlineData("Dog")]
    [InlineData("Human")]
    public void Test_ClassExists(string className)
    {
        Type? type = GetClass(className);
        Assert.NotNull(type);
    }

    [Theory]
    [InlineData("Cat")]
    [InlineData("Dog")]
    [InlineData("Human")]
    public void Test_ApplyingAppropriateModifiers(string className)
    {
        Type? type = GetClass(className);
        Assert.NotNull(type);

        Assert.True(type.IsNestedPublic, $"{className} class should be public");
        Assert.False(type.IsAbstract, $"{className} class should not be abstract");
        Assert.True(type.IsClass, $"{className} class should be a class");
        Assert.True(type.IsSubclassOf(typeof(Animal)), $"{className} class should inherit from Animal");
    }

    [Theory]
    [InlineData("Cat")]
    [InlineData("Dog")]
    public void Test_Constructor(string className)
    {
        Type? type = GetClass(className);
        Assert.NotNull(type);

        ConstructorInfo? constructor = type.GetConstructor([typeof(string)]);
        Assert.NotNull(constructor);
        Assert.True(constructor.IsPublic, $"{className} constructor should be public");

        object? instance = constructor.Invoke(["Test"]);
        Assert.NotNull(instance);
        Assert.IsType(type, instance);

        var animal = Assert.IsAssignableFrom<Animal>(instance);
        Assert.Equal("Test", animal.Name);
    }
    
    [Theory]
    [InlineData("Human", "Jane", "Doe")]
    [InlineData("Human", "John", "Smith")]
    [InlineData("Human", "Alice De", "Wonderland")]
    [InlineData("Human", "Charlie Van", "Brown Meat")]
    public void Test_HumanClassConstructor(string className, string firstName, string lastName)
    {
        Type? type = GetClass(className);
        Assert.NotNull(type);

        ConstructorInfo? constructor = type.GetConstructor([typeof(string), typeof(string)]);
        Assert.NotNull(constructor);
        Assert.True(constructor.IsPublic, $"{className} constructor should be public");

        object? instance = constructor.Invoke([firstName, lastName]);
        Assert.NotNull(instance);
        Assert.IsType(type, instance);

        var animal = Assert.IsAssignableFrom<Animal>(instance);
        Assert.Equal($"{firstName} {lastName}", animal.Name);

        PropertyInfo? firstNameProperty = type.GetProperty("FirstName", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(firstNameProperty);
        string? fieldValue = firstNameProperty.GetValue(instance) as string;
        Assert.Equal(firstName, fieldValue);

        PropertyInfo? lastNameProperty = type.GetProperty("LastName", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(lastNameProperty);
        fieldValue = lastNameProperty.GetValue(instance) as string;
        Assert.Equal(lastName, fieldValue);
    }

    [Theory]
    [InlineData("FirstName")]
    [InlineData("LastName")]
    public void Test_HumanClass_ApplyingAppropriateModifiersToReadOnlyProperties(string name)
    {
        var type = GetClass("Human");
        Assert.NotNull(type);

        var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        Assert.NotNull(property);

        MethodInfo? getMethod = property.GetGetMethod();
        Assert.True(getMethod != null, $"{name} property should be readable");
        Assert.True(getMethod.IsPublic, $"{name} property getter should be public");
        Assert.False(getMethod.IsStatic, $"{name} property getter should not be static");
        Assert.False(getMethod.IsVirtual, $"{name} property getter should not be virtual");
        Assert.False(getMethod.IsAbstract, $"{name} property getter should not be abstract");

        MethodInfo? setMethod = property.GetSetMethod();
        Assert.False(setMethod != null, $"{name} property should not be writable");
    }

    [Theory]
    [InlineData("Cat", "にゃー")]
    [InlineData("Dog", "ワン")]
    [InlineData("Human", "です")]
    public void Test_ConvertToCry(string className, string expectedCry)
    {
        Animal? animal = GetInstance(className);
        string result = animal.ConvertToCry("Test");
        Assert.Equal("Test" + expectedCry, result);
    }

    [Theory]
    [InlineData(GeneticSex.Male, GeneticSex.Male, false)]
    [InlineData(GeneticSex.Male, GeneticSex.Female, true)]
    [InlineData(GeneticSex.Female, GeneticSex.Male, true)]
    [InlineData(GeneticSex.Female, GeneticSex.Female, false)]
    public void Test_MarryTo(GeneticSex sex1, GeneticSex sex2, bool isSupported)
    {
        Type? type = GetClass("Human");
        Assert.NotNull(type);

        PropertyInfo? firstNameProperty = type.GetProperty("FirstName", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(firstNameProperty);
        PropertyInfo? lastNameProperty = type.GetProperty("LastName", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(lastNameProperty);

        Animal human1 = GetHumanInstance("Jane", "Doe", sex1);
        Animal human2 = GetHumanInstance("John", "Smith", sex2);

        MethodInfo? marryToMethod = human1.GetType().GetMethod("MarryTo", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(marryToMethod);

        if (isSupported)
        {
            marryToMethod.Invoke(human1, [human2]);
            if (human1.GeneticSex == GeneticSex.Male)
            {
                Assert.Equal("Jane Doe", human1.Name);
                Assert.Equal("Jane", firstNameProperty.GetValue(human1));
                Assert.Equal("Doe", lastNameProperty.GetValue(human1));

                Assert.Equal("John Doe", human2.Name);
                Assert.Equal("John", firstNameProperty.GetValue(human2));
                Assert.Equal("Doe", lastNameProperty.GetValue(human2));
            }
            else
            {
                Assert.Equal("Jane Smith", human1.Name);
                Assert.Equal("Jane", firstNameProperty.GetValue(human1));
                Assert.Equal("Smith", lastNameProperty.GetValue(human1));

                Assert.Equal("John Smith", human2.Name);
                Assert.Equal("John", firstNameProperty.GetValue(human2));
                Assert.Equal("Smith", lastNameProperty.GetValue(human2));
            }
        }
        else
        {
            var exception = Assert.Throws<TargetInvocationException>(() => marryToMethod.Invoke(human1, [human2]));
            Assert.True(exception.InnerException is NotSupportedException, "Expected NotSupportedException");

            Assert.Equal("Jane Doe", human1.Name);
            Assert.Equal("Jane", firstNameProperty.GetValue(human1));
            Assert.Equal("Doe", lastNameProperty.GetValue(human1));

            Assert.Equal("John Smith", human2.Name);
            Assert.Equal("John", firstNameProperty.GetValue(human2));
            Assert.Equal("Smith", lastNameProperty.GetValue(human2));
        }
    }
}