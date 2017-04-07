namespace IndoorNavigator.MapEditor.Share
{
    using System;
    using System.Windows.Forms;
    using Properties;

    public static class Alerter
    {
        public static void Alert(string message, string title = "Alert")
        {
            MessageBox.Show(message, title);
        }

        public static void Alert(Exception ex, string statusBarMessage = null)
        {
            Alert(ex.ToString(), Resources.ErrorDialogTitle);
        }

    }
}
