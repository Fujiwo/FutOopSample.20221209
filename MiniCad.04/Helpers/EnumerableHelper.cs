namespace MiniCad.Helpers
{
    static class EnumerableHelper
    {
        public static void ForEach<TElement>(this IEnumerable<TElement> @this, Action<TElement> action)
        {
            foreach (var item in @this)
                action(item);
        }
    }
}
