namespace IndoorNavigator.MapEditor.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class EnumerableExtension
    {
        public static void For(this IEnumerable source, Action<object, int> action)
        {
            Debug.Assert(source != null);
            Debug.Assert(action != null);

            var index = 0;
            foreach (var item in source)
            {
                action(item, index++);
            }
        }

        public static void ForEach(this IEnumerable source, Action<object> action)
        {
            Debug.Assert(source != null);
            Debug.Assert(action != null);

            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void For<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            Debug.Assert(source != null);
            Debug.Assert(action != null);

            var index = 0;
            foreach (var item in source)
            {
                action(item, index++);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Debug.Assert(source != null);
            Debug.Assert(action != null);

            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
