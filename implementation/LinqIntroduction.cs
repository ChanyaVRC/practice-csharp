using System.Diagnostics;

namespace Implementation;

public class LinqIntroduction
{
    public static IEnumerable<int> EnumerateX2(int[] values)
    {
        // TODO: Select メソッドを使用して values の各要素を 2 倍にして返す
        throw new NotImplementedException();
    }

    public static IEnumerable<int> EnumerateOnlyMinusValues(int[] values)
    {
        // TODO: Where メソッドを使用して values の中から負の値を取得して返す
        throw new NotImplementedException();
    }

    public static bool IsOverThanAverage(int[] samples, int value)
    {
        Debug.Assert(samples.Length > 0, "samples must have at least one element.");

        // TODO: samples の平均値を求めて value がそれより大きい場合は true を返す、それ以外は false を返す
        // REMARK: samples の要素数は必ず 1 以上であると限定して良い
        throw new NotImplementedException();
    }

    public static bool IsOverThanMax(int[] samples, double value)
    {
        Debug.Assert(samples.Length > 0, "samples must have at least one element.");

        // TODO: samples の最大値を求めて value がそれより大きい場合は true を返す、それ以外は false を返す
        // REMARK: samples の要素数は必ず 1 以上であると限定して良い
        throw new NotImplementedException();
    }

    public static IEnumerable<string> EnumerateStringElements(object[] values)
    {
        // TODO: values の要素の内、string 型である要素を返す
        throw new NotImplementedException();
    }

    public static IEnumerable<int> CastToIntWithRound(double[] values)
    {
        // TODO: values の各要素を四捨五入して int 型で返す
        // REMARK: 四捨五入に Math.Round メソッドを使用すること
        //         https://learn.microsoft.com/dotnet/api/system.math.round
        // ATTENTION: 偶数丸めは FAIL になるので注意
        throw new NotImplementedException();
    }

    public static IEnumerable<int> Take2(IEnumerable<int> values)
    {
        // TODO: values の先頭から 2 個の要素を返す
        throw new NotImplementedException();
    }

    public static IEnumerable<int> Skip3(IEnumerable<int> values)
    {
        // TODO: values の先頭から 3 個の要素をスキップして返す
        throw new NotImplementedException();
    }

    public static IEnumerable<int> Concat(IEnumerable<int> values1, IEnumerable<int> values2)
    {
        // TODO: values1 と values2 を連結して返す
        throw new NotImplementedException();
    }

    public static int[] MakeArray(IEnumerable<int> values)
    {
        // TODO: values を配列に変換して返す
        throw new NotImplementedException();
    }
}