using Library.UsingUsage.Valid;
// TODO: using を追加して、Result が "Valid" になるようにする

namespace Implementation;
using Library.UsingUsage.Invalid;

public class UsingUsage
{
    public string Result { get; }
    public Type PriorityCheck { get; }

    public UsingUsage()
    {
        Result = Library.Result;
        PriorityCheck = typeof(PriorityCheck);
    }
}