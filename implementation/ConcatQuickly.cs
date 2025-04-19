using System.Runtime.CompilerServices;
using System.Text;

namespace Implementation;

public class ConcatQuickly
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // TODO: Make fast string concatenation
    public static string MakeStringOfSequentialNumber()
    {
        string result = string.Empty;
        for (int i = 0; i < 10000; i++)
        {
            if (result != "")
            {
                result += ",";
            }
            result += i.ToString();
        }
        return result;
    }
}
