using System.Diagnostics;

namespace Implementation;

public class LinqIntroduction
{
    public static IEnumerable<int> EnumerateX2(int[] values)
    {
        return values.Select(v => v * 2);
    }

    public static IEnumerable<int> EnumerateOnlyMinusValues(int[] values)
    {
        return values.Where(v => v < 0);
    }

    public static bool IsOverThanAverage(int[] samples, int value)
    {
        Debug.Assert(samples.Length > 0, "samples must have at least one element.");

        return samples.Average() < value;
    }

    public static bool IsOverThanMax(int[] samples, double value)
    {
        Debug.Assert(samples.Length > 0, "samples must have at least one element.");

        return samples.Max() < value;
    }

    public static IEnumerable<string> EnumerateStringElements(object[] values)
    {
        return values.OfType<string>();
    }

    public static IEnumerable<int> CastToIntWithRound(double[] values)
    {
        return values.Select(v => (int)Math.Round(v, MidpointRounding.AwayFromZero));
    }

    public static IEnumerable<int> Take2(IEnumerable<int> values)
    {
        return values.Take(2);
    }

    public static IEnumerable<int> Skip3(IEnumerable<int> values)
    {
        return values.Skip(3);
    }

    public static IEnumerable<int> Concat(IEnumerable<int> values1, IEnumerable<int> values2)
    {
        return values1.Concat(values2);
    }

    public static int[] MakeArray(IEnumerable<int> values)
    {
        return values.ToArray();
    }
}