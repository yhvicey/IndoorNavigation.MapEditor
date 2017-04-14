namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Properties;

    public partial class ChangeSizeWizard :
        Wizard<Size>
    {
        public int HeightProperty { get; set; }

        public int WidthProperty { get; set; }

        private void ChangeSizeWizardLoad(object sender, EventArgs e)
        {
            _widthTextBox.Text = WidthProperty.ToString();
            _heightTextBox.Text = HeightProperty.ToString();
        }

        protected override bool Prepare()
        {
            if (!int.TryParse(_widthTextBox.Text, out var width))
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }
            if (!int.TryParse(_heightTextBox.Text, out var height))
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }

            WidthProperty = width;
            HeightProperty = height;

            return true;
        }

        public ChangeSizeWizard()
        {
            InitializeComponent();
        }

        public override Size Make()
        {
            return !Ready ? new Size() : new Size(WidthProperty, HeightProperty);
        }
    }
}
