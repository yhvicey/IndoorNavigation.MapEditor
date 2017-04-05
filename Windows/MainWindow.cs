namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Map;
    using Models;
    using Properties;

    public partial class MainWindow : Form
    {
        private Map _currentMap;

        private void Alert(string message, string title = "Alert")
        {
            MessageBox.Show(this, message, title);
        }

        private void Alert(Exception ex, string appendMessage = null)
        {
            Alert(ex.ToString(), Resources.ErrorDialogTitle);
            StatusBarMessage($"Exception occured.{(appendMessage == null ? string.Empty : " " + appendMessage)}");
        }

        private void StatusBarMessage(string message)
        {
            _statusLabel.Text = message;
        }

        public MainWindow(IReadOnlyList<string> args)
        {
            InitializeComponent();
            if (args.Count < 1) return;
            try
            {
                _currentMap = MapParser.Parse(args[0]);
                StatusBarMessage($"Succeed to Load {args[0]}.");
            }
            catch (Exception ex)
            {
                Alert(ex, $"Failed to load {args[0]}.");
            }
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
