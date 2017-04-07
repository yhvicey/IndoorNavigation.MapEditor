namespace IndoorNavigator.MapEditor.Share
{
    using System;
    using System.Linq;
    using Properties;

    public static class Contract
    {
        public static void EnsureArgsNonNull(params object[] args)
        {
            if (args.Any(arg => arg == null)) throw new ArgumentNullException(Resources.InvalidArgument);
        }

        public static void EnsureValuesNonNull(params object[] values)
        {
            if (values.Any(value => value == null)) throw new NullReferenceException();
        }
    }
}
