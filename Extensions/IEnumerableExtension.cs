namespace IndoorNavigator.MapEditor.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class EnumerableExtension
    {
        public static void For(this IEnumerable source, Action<object, int> action)
        {
            var index = 0;
            foreach (var item in source)
            {
                action(item, index++);
            }
        }

        public static void ForEach(this IEnumerable source, Action<object> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void For<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in source)
            {
                action(item, index++);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
