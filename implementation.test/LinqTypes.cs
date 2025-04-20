namespace Implementation.Test
{
    public static class LinqTypes
    {
        public static Type Select<TSource, TResult>() => Array.Empty<TSource>().Select(v => default(TResult)).GetType();
        public static Type Where<TSource>() => Array.Empty<TSource>().Where(v => false).GetType();
        public static Type OfType<TResult>() => Array.Empty<int>().OfType<TResult>().GetType();
        public static Type Take<TResult>() => Array.Empty<TResult>().Take(1).GetType();
        public static Type Skip<TResult>() => Array.Empty<TResult>().Skip(1).GetType();
        public static Type Concat<TResult>() => Array.Empty<TResult>().Concat([]).GetType();
    }
}