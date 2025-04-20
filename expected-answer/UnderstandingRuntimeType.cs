namespace Implementation;

public class UnderstandingRuntimeType
{
    public static Type GetCompileTimeType<T>(T value)
    {
        return typeof(T);
    }

    public static Type? GetRuntimeType<T>(T value)
    {
        return value?.GetType();
    }
}