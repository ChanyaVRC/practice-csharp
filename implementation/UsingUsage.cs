using Library.UsingUsage.Valid;

namespace Implementation;
using Library.UsingUsage.Invalid;
// TODO: using を追加して、Result が "Valid" になるようにする

public class UsingUsage
{
    public string Result { get; }
    public Type PriorityCheck { get; }

    public UsingUsage()
    {
        Result = LibraryClass.Result;
        PriorityCheck = typeof(PriorityCheck);
    }
}