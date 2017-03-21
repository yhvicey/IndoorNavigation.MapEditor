namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Contracts;
    using Properties;

    public partial class MainWindow : Form
    {
        private Map _currentMap;

        private void Alert(string message, string title = "Alert")
        {
            MessageBox.Show(this, message, title);
        }

        private void StatusBarMessage(string message)
        {
            _statusLabel.Text = message;
        }

        public MainWindow(string[] args)
        {
            InitializeComponent();
            if (args.Length < 1) return;
            try
            {
                _currentMap = Map.FromFile(args[0]);
                StatusBarMessage($"Load {args[0]} successfully.");
            }
            catch (Exception ex)
            {
                Alert(ex.ToString(), Resources.ErrorDialogTitle);
            }
            if (_currentMap != null) return;
            Alert("Failed to load map file!");
            StatusBarMessage($"Load {args[0]} failed.");
        }

        private void DesignToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (var item in _designToolStrip.Items)
            {
                var button = item as ToolStripButton;
                if (button == null) continue;
                if (button.Name == e.ClickedItem.Name) continue;
                button.Checked = false;
            }
        }

        private void LoadBackgroundMenuItemClick(object sender, EventArgs e)
        {
            _loadFileDialog.Title = Resources.LoadBackgroundDialogTitle;
            _loadFileDialog.Filter = Resources.LoadBackgroundDialogFilter;
            if (_loadFileDialog.ShowDialog(this) != DialogResult.OK) return;
            if (_floorTabControl.TabCount == 0) return;
            using (var stream = _loadFileDialog.OpenFile())
            {
                try
                {
                    var background = Image.FromStream(stream);
                    var currentFloorTabPage = _floorTabControl.SelectedTab;
                    currentFloorTabPage.BackgroundImage = background;
                    currentFloorTabPage.BackgroundImageLayout = ImageLayout.Center;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), Resources.ErrorDialogTitle);
                }
            }
        }

        private void RemoveBackgroundMenuItemClick(object sender, EventArgs e)
        {
            if (_floorTabControl.TabCount == 0) return;
            _floorTabControl.SelectedTab.BackgroundImage = null;
        }
    }
}
