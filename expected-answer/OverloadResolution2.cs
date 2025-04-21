namespace Implementation;

public class OverloadResolution2
{
    public OverloadResolution2() { }

    public bool HasSpecialCall { get; private set; }
    public int CallCount { get; private set; }

    public void Method<T>(T value)
    {
        CallCount++;
    }

    public void Method(int value)
    {
        Method<int>(value);
        HasSpecialCall = true;
    }
}
