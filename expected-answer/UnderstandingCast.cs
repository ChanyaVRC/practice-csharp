namespace Implementation;

public class UnderstandingCast
{
    public UnderstandingCast() { }

    public bool CanCastToInt32(object? value)
    {
        return value is int;
    }

    public bool CanCastTo<T>(object? value)
    {
        if (value is T)
        {
            return true;
        }
        // T がクラスであれば (T)null が可能であることに留意する
        if (value is null && typeof(T).IsClass)
        {
            return true;
        }
        return false;
    }

    public bool CanUpperCast<T>(object? value)
    {
        // シールドクラスである場合は継承出来ないため、上位の型は存在しない
        if (typeof(T).IsSealed)
        {
            return false;
        }
        if (typeof(T) == typeof(ValueType))
        {
            return value is ValueType;
        }
        if (value is null)
        {
            return typeof(T).IsClass;
        }
        if (value is T)
        {
            return typeof(T) != value.GetType();
        }
        return false;
    }
}
