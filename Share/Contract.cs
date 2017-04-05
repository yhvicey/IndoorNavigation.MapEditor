namespace IndoorNavigator.MapEditor.Share
{
    using System;
    using System.Linq;

    public static class Contract
    {
        public static void EnsureArgsNonNull(params object[] args)
        {
            if (args.Any(arg => arg == null)) throw new ArgumentNullException();
        }

        public static void EnsureValuesNonNull(params object[] values)
        {
            if (values.Any(value => value == null)) throw new NullReferenceException();
        }
    }
}
