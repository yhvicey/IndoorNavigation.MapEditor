namespace IndoorNavigator.MapEditor
{
    using System.Windows.Forms;

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (var item in _toolStrip.Items)
            {
                var button = item as ToolStripButton;
                if (button == null) continue;
                if (button.Name == e.ClickedItem.Name) continue;
                button.Checked = false;
            }
        }
    }
}
