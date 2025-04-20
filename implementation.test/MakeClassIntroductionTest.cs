using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace Implementation.Test;

[Trait("TestOf", nameof(MakeClassIntroduction))]
public class MakeClassIntroductionTest 
{
    private static readonly Type s_parentType = typeof(MakeClassIntroduction);

    private static Type? GetUserClass()
        => s_parentType.GetNestedType("User", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

    [Fact]
    public void Test_ExistsUserClass()
    {
        Type? userClass = GetUserClass();
        Assert.NotNull(userClass);
    }

    [Fact]
    public void Test_ApplyingAppropriateModifiers()
    {
        Type? userClass = GetUserClass();
        Assert.NotNull(userClass);
        Assert.True(userClass.IsNestedPublic, "User class should be public");
        Assert.False(userClass.IsAbstract, "User class should not be abstract");
        Assert.False(userClass.IsSealed, "User class should not be sealed");
        Assert.False(userClass.IsValueType, "User class should not be a value type");
    }

    [Fact]
    public void Test_DefaultConstructor()
    {
        Type? userClass = GetUserClass();
        Assert.NotNull(userClass);
        ConstructorInfo? constructor = userClass.GetConstructor(Type.EmptyTypes);
        Assert.NotNull(constructor);

        object? instance = constructor.Invoke(null);
        Assert.NotNull(instance);
        Assert.IsType(userClass, instance);

        FieldInfo? fieldInfo = userClass.GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(fieldInfo);
        string? fieldValue = fieldInfo.GetValue(instance) as string;
        Assert.Equal("unknown", fieldValue);
    }

    [Fact]
    public void Test_ConstructorWithParameters()
    {
        Type? userClass = GetUserClass();
        Assert.NotNull(userClass);
        ConstructorInfo? constructor = userClass.GetConstructor([typeof(string)]);
        Assert.NotNull(constructor);

        object? instance = constructor.Invoke(["John Doe"]);
        Assert.NotNull(instance);
        Assert.IsType(userClass, instance);

        FieldInfo? fieldInfo = userClass.GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(fieldInfo);
        string? fieldValue = fieldInfo.GetValue(instance) as string;
        Assert.Equal("John Doe", fieldValue);
    }

    [Fact]
    public void Test_NameField()
    {
        Type? userClass = GetUserClass();
        Assert.NotNull(userClass);

        FieldInfo? fieldInfo = userClass.GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(fieldInfo);
        Assert.Equal(typeof(string), fieldInfo.FieldType);
        Assert.True(fieldInfo.IsPrivate, "_name field should be private");
    }

    [Fact]
    public void Test_SetNameMethod()
    {
        Type? userClass = GetUserClass();
        Assert.NotNull(userClass);
        MethodInfo? methodInfo = userClass.GetMethod("SetName");
        Assert.NotNull(methodInfo);

        object? instance = Activator.CreateInstance(userClass);
        Assert.NotNull(instance);
        methodInfo.Invoke(instance, ["Jane Doe"]);

        FieldInfo? fieldInfo = userClass.GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(fieldInfo);
        string? fieldValue = fieldInfo.GetValue(instance) as string;
        Assert.Equal("Jane Doe", fieldValue);
    }

    [Fact]
    public void Test_NameProperty()
    {
        Type? userClass = GetUserClass();
        Assert.NotNull(userClass);
        
        PropertyInfo? propertyInfo = userClass.GetProperty("Name");
        Assert.NotNull(propertyInfo);

        object? instance = Activator.CreateInstance(userClass);
        Assert.NotNull(instance);
        
        MethodInfo? getMethod = propertyInfo.GetMethod;
        MethodInfo? setMethod = propertyInfo.SetMethod;
        Assert.NotNull(getMethod);
        Assert.NotNull(setMethod);
        Assert.True(getMethod.IsPublic, "The getter should be public");
        Assert.True(setMethod.IsPrivate, "The setter should be private");

        string? nameValue = getMethod.Invoke(instance, null) as string;
        Assert.Equal("unknown", nameValue);

        setMethod.Invoke(instance, ["John Doe"]);

        nameValue = propertyInfo.GetValue(instance) as string;
        Assert.Equal("John Doe", nameValue);
    }

    [Fact]
    public void Test_NamePropertyAccessorsAreNotAutoImplemented()
    {
        var userClass = GetUserClass();
        Assert.NotNull(userClass);

        var propertyInfo = userClass.GetProperty("Name");
        Assert.NotNull(propertyInfo);

        var getMethod = propertyInfo.GetMethod;
        var setMethod = propertyInfo.SetMethod;
        Assert.NotNull(getMethod);
        Assert.NotNull(setMethod);

        Assert.False(getMethod.IsDefined(typeof(CompilerGeneratedAttribute), false), "The getter should not be auto‑implemented");
        Assert.False(setMethod.IsDefined(typeof(CompilerGeneratedAttribute), false), "The setter should not be auto‑implemented");
    }
}