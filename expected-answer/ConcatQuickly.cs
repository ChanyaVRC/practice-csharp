using System.Runtime.CompilerServices;
using System.Text;

namespace Implementation;

public class ConcatQuickly
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string MakeStringOfSequentialNumber()
    {
        StringBuilder result = new(48889);
        result.Append(0);
        for (int i = 1; i < 10000; i++)
        {
            result.Append(',').Append(i);
        }
        return result.ToString();
    }
}
