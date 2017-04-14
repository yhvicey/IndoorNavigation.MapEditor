namespace IndoorNavigator.MapEditor.Windows
{
    using System.Windows.Forms;

    public partial class Wizard<T> :
        Form
    {
        public bool Ready { get; private set; }

        private void CancelButtonClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConfirmButtonClick(object sender, System.EventArgs e)
        {
            if (!Prepare()) return;

            Ready = true;
            DialogResult = DialogResult.Yes;
            Close();
        }

        protected Wizard()
        {
            InitializeComponent();
        }

        protected virtual bool Prepare()
        {
            return false;
        }

        public virtual T Make()
        {
            return default(T);
        }
    }
}
