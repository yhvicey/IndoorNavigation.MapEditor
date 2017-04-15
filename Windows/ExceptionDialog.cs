namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Windows.Forms;

    public partial class ExceptionDialog :
        Form
    {
        public static DialogResult Show(IWin32Window parent, Exception ex, string message = null)
        {
            return new ExceptionDialog(ex, message).ShowDialog(parent);
        }

        private const int CollapsedHeight = 160;

        private const string DetailsButtonCollapsedText = "Details ▼";

        private const string DetailsButtonExpandedText = "Details ▲";

        private const int ExpandedHeight = 300;

        private bool _expanded;

        private void DetailsButtonClick(object sender, EventArgs e)
        {
            if (_expanded)
            {
                Height = CollapsedHeight;
                _detailsButton.Text = DetailsButtonCollapsedText;
            }
            else
            {
                Height = ExpandedHeight;
                _detailsButton.Text = DetailsButtonExpandedText;
            }
            _expanded = !_expanded;
        }

        private void YesButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        protected ExceptionDialog(Exception ex, string message = null)
        {
            InitializeComponent();
            _errorMessage.Text = message ?? ex.Message;
#if DEBUG
            _detailsButton.Visible = true;
            _detailsTextBox.Visible = true;
            _detailsTextBox.Text = ex.ToString();
#endif
        }
    }
}
