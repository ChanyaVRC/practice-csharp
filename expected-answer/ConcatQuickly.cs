using System.Runtime.CompilerServices;
using System.Text;

namespace Implementation;

public class ConcatQuickly
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // REMARK: This is fast enough, but using StringBuilder properly can finish in about 80% of the time.
    public static string MakeStringOfSequentialNumber()
        => string.Join(",", Enumerable.Range(0, 10000));
}
