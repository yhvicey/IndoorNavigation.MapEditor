namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Map;
    using Models;
    using Properties;

    public partial class MainWindow : Form
    {
        #region Variables

        private Map _currentMap;

        #endregion // Variables

        #region Flush functions

        private void FlushMapView()
        {
            _mapView.Nodes.Clear();
            if (_currentMap == null) return;
            var rootNode = new TreeNode(_currentMap.Name);
            var index = 1;
            foreach (var floor in _currentMap.Floors)
            {
                var floorNode = new TreeNode($"Floor {index++}");
                var entryNodes = floor.EntryNodes.Select(entryNode => new TreeNode(entryNode.ToString()));
                var guideNodes = floor.GuideNodes.Select(guideNode => new TreeNode(guideNode.ToString()));
                var wallNodes = floor.WallNodes.Select(wallNode => new TreeNode(wallNode.ToString()));
                floorNode.Nodes.Add(new TreeNode("Entry nodes", entryNodes.ToArray()));
                floorNode.Nodes.Add(new TreeNode("Guide nodes", guideNodes.ToArray()));
                floorNode.Nodes.Add(new TreeNode("Wall nodes", wallNodes.ToArray()));
                rootNode.Nodes.Add(floorNode);
            }
            _mapView.Nodes.Add(rootNode);
        }

        #endregion // Flush functions

        #region Functions

        private void Alert(string message, string title = "Alert")
        {
            MessageBox.Show(this, message, title);
        }

        private void Alert(Exception ex, string statusBarMessage = null)
        {
            Alert(ex.ToString(), Resources.ErrorDialogTitle);
            StatusBarMessage($"Exception occured. {statusBarMessage ?? ""}");
        }

        private bool LoadMap(string fileName)
        {
            try
            {
                _currentMap = MapParser.Parse(fileName);
                StatusBarMessage($"Succeed to Load {fileName}.");
                FlushMapView();
                return true;
            }
            catch (Exception ex)
            {
                Alert(ex, $"Failed to load {fileName}.");
                return false;
            }
        }

        private void StatusBarMessage(string message)
        {
            _statusLabel.Text = message;
        }

        #endregion // Functions

        #region Constructors

        public MainWindow(IReadOnlyList<string> args)
        {
            InitializeComponent();
            if (args.Count < 1) return;
            LoadMap(args[0]);
        }

        #endregion // Constructors

        #region Event handlers

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

        #endregion // Event handlers
    }
}
