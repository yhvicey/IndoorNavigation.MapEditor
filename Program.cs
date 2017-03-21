namespace IndoorNavigator.MapEditor
{
    using System;
    using System.Windows.Forms;
    using Windows;

    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(args));
        }
    }
}
