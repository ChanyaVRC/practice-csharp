namespace Implementation;

public class OverloadResolution
{
    public OverloadResolution() { }

    public Type? ArgumentType { get; private set; }
    public object? Value { get; private set; }

    public void Method(int i) { ArgumentType = i.GetType(); Value = i; }
    public void Method(long i) { ArgumentType = i.GetType(); Value = i; }

    public void CallMethod()
    {
        Method(1L);
    }
}
