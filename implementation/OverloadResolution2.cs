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

    // TODO: Method に int 型の引数を渡した場合に、既存の動作を変更せずに、HasSpecialCall = true になるようにする
}
