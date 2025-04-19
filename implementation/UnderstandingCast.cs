namespace Implementation;

public class UnderstandingCast
{
    public UnderstandingCast() { }

    public bool CanCastToInt32(object? value)
    {
        // TODO: value が int 型にキャストできる場合は true を返す
        //       それ以外は false を返す
        throw new NotImplementedException();
    }

    public bool CanCastTo<T>(object? value)
    {
        // TODO: value が T 型にキャストできる場合は true を返す
        //       それ以外は false を返す
        throw new NotImplementedException();
    }

    public bool CanUpperCast<T>(object? value)
    {
        // TODO: value が T 型より上位の型でキャストできる場合は true を返す
        //       それ以外は false を返す
        // REMARK: value が T 型である場合は false を返す
        //         現時点で上位の型が存在するかは問わず、新たに上位の型を作成することで条件を満たせる場合は true を返す
        throw new NotImplementedException();
    }
}
