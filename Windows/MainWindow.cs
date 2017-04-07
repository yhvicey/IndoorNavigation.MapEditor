namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Controls;
    using Map;
    using Models;
    using Models.Nodes;
    using Properties;
    using Share;

    public partial class MainWindow : Form
    {
        #region Variables

        private Map _map;

        private readonly MapViewAdapter _mapViewAdapter;

        #endregion // Variables

        #region Initialize functions

        #endregion // Initialize functions

        #region Flush functions

        public void FlushMapView()
        {
            _mapViewAdapter?.Flush();
        }

        #endregion // Flush functions

        #region Functions

        private bool LoadMap(string fileName)
        {
            try
            {
                _map = MapParser.Parse(fileName);
                StatusBarMessage($"Succeed to Load {fileName}.");
                _mapViewAdapter.Map = _map;
                return true;
            }
            catch (Exception ex)
            {
                Alerter.Alert(ex, $"Failed to load {fileName}.");
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
            _mapViewAdapter = new MapViewAdapter(_mapView);
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

        private void MapViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var treeNode = e.Node as MapElementTreeNode;
            if (treeNode == null) return;
            _mapView.SelectedNode = treeNode;
            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    _propertyGrid.SelectedObject = treeNode.MapElement;
                    return;
                }
                case MouseButtons.Right:
                {
                    switch (treeNode.MapElement)
                    {
                        case Map map:
                        {
                            _mapView.ContextMenuStrip = _mapTreeNodeMenu;
                            return;
                        }
                        case Floor floor:
                        {
                            _mapView.ContextMenuStrip = _floorTreeNodeMenu;
                            return;
                        }
                        case NodeBase node:
                        {
                            _mapView.ContextMenuStrip = _nodeTreeNodeMenu;
                            return;
                        }
                        default:
                        {
                            _mapView.ContextMenuStrip = null;
                            return;
                        }
                    }
                }
                default:
                {
                    return;
                }
            }
        }

        private void PropertyGridPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            FlushMapView();
        }

        private void RemoveBackgroundMenuItemClick(object sender, EventArgs e)
        {
            if (_floorTabControl.TabCount == 0) return;
            _floorTabControl.SelectedTab.BackgroundImage = null;
        }

        #endregion // Event handlers

        private void magicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wizard = new AddNodeWizard(_map);
            if (wizard.ShowDialog() != DialogResult.Yes) return;
            var floorIndex = wizard.Floor;
            var floor = _map.Floors[floorIndex];
            NodeBase node;
            switch (wizard.Type)
            {
                case NodeType.EntryNode:
                {
                    node = new EntryNode(floor, wizard.X, wizard.Y, wizard.NodeName, wizard.Prev, wizard.Next);
                    break;
                }
                case NodeType.GuideNode:
                {
                    node = new GuideNode(floor, wizard.X, wizard.Y, wizard.NodeName);
                    break;
                }
                case NodeType.WallNode:
                {
                    node = new WallNode(floor, wizard.X, wizard.Y);
                    break;
                }
                default:
                {
                    return;
                }
            }
            floor.AddNode(node);
            _mapViewAdapter.AddNode(floorIndex, node);
        }
    }
}
