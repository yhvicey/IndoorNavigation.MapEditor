namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
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

        private int _currentFloorIndex = -1;

        private Map _map;

        private MapViewAdapter _mapViewAdapter;

        private Floor CurrentFloor => _map.Floors[_currentFloorIndex];

        #endregion // Variables

        #region Initialize functions

        private void InitializeMapElementTreeNode()
        {
            MapElementTreeNode.CustomContextMenuStrip = _mapViewMenu;
        }

        private void InitializeMapViewAdapter()
        {
            _mapViewAdapter = new MapViewAdapter(_mapView);
        }

        #endregion // Initialize functions

        #region Flush functions

        private void FlushMapStatusLabel()
        {
            _mapStatusLable.Text = string.Format(Resources.MapStatusTemplate, _map?.Name ?? "None",
                _currentFloorIndex == -1 ? "None" : (_currentFloorIndex + 1).ToString());
        }

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
                _mapViewAdapter.Map = _map;

                StatusBarMessage($"Succeed to Load {fileName}.");
                FlushMapStatusLabel();
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
            _messageStatusLabel.Text = message;
        }

        private void SwitchFloor(int floor)
        {
            _currentFloorIndex = floor;
            FlushMapStatusLabel();
        }

        #endregion // Functions

        #region Constructors

        public MainWindow(IReadOnlyList<string> args)
        {
            InitializeComponent();

            InitializeMapElementTreeNode();
            InitializeMapViewAdapter();

            if (args.Count < 1) return;
            LoadMap(args[0]);
        }

        #endregion // Constructors

        #region Event handlers

        private void MainWindowLoad(object sender, EventArgs e)
        {

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
            using (var stream = _loadFileDialog.OpenFile())
            {
                try
                {
                    var background = Image.FromStream(stream);
                    _designer.BackgroundImage = background;
                    _designer.BackgroundImageLayout = ImageLayout.Center;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Resources.ErrorDialogTitle);
                }
            }
        }

        private void MapViewAddFloorMenuItemClick(object sender, EventArgs e)
        {

        }

        private void MapViewAddEntryNodeMenuItemClick(object sender, EventArgs e)
        {
            var wizard = new AddNodeWizard(_map)
            {
                Floor = _currentFloorIndex,
                Type = NodeType.EntryNode
            };
            wizard.ShowDialog();
            if (!wizard.Ready) return;
            CurrentFloor.AddNode(wizard.MakeNode());
        }

        private void MapViewAddGuideNodeMenuItemClick(object sender, EventArgs e)
        {
            var wizard = new AddNodeWizard(_map)
            {
                Floor = _currentFloorIndex,
                Type = NodeType.GuideNode
            };
            wizard.ShowDialog();
            if (!wizard.Ready) return;
            CurrentFloor.AddNode(wizard.MakeNode());
        }

        private void MapViewAddWallNodeMenuItemClick(object sender, EventArgs e)
        {
            var wizard = new AddNodeWizard(_map)
            {
                Floor = _currentFloorIndex,
                Type = NodeType.WallNode
            };
            if (wizard.ShowDialog() == DialogResult.Cancel) return;
            if (!wizard.Ready) return;
            CurrentFloor.AddNode(wizard.MakeNode());
        }

        private void MapViewAddLinkMenuItemClick(object sender, EventArgs e)
        {
            var selectedNode = _mapView.SelectedNode as MapElementTreeNode;
            if (selectedNode == null) return;
            _mapView.SelectedNode = selectedNode;
            var wizard = new AddLinkWizard(_map)
            {
                Floor = _currentFloorIndex,
            };
            switch (selectedNode.Level)
            {
                // Collection node
                case 2:
                {
                    // "3" is magic - stands for links node
                    if (selectedNode.Index != 3) wizard.StartType = (NodeType)selectedNode.Index;
                    break;
                }
                // Element node
                case 3:
                {
                    if (selectedNode.Parent.Index != 3) wizard.StartType = (NodeType)selectedNode.Parent.Index;
                    wizard.StartIndex = selectedNode.Index;
                    break;
                }
            }
            if (wizard.ShowDialog() == DialogResult.Cancel) return;
            if (!wizard.Ready) return;
            CurrentFloor.AddLink(wizard.MakeLink());
        }

        private void MapViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var selectedNode = e.Node as MapElementTreeNode;
            if (selectedNode == null) return;
            _mapView.SelectedNode = selectedNode;
            if (selectedNode.Level == 1) SwitchFloor(selectedNode.Index);
            switch (e.Button)
            {
                case MouseButtons.Left:
                {
                    _propertyGrid.SelectedObject = selectedNode.MapElement;
                    return;
                }
                case MouseButtons.Right:
                {
                    _mapViewAddMenuItem.Visible = false;
                    _mapViewAddFloorMenuItem.Visible = false;
                    _mapViewAddEntryNodeMenuItem.Visible = false;
                    _mapViewAddGuideNodeMenuItem.Visible = false;
                    _mapViewAddWallNodeMenuItem.Visible = false;
                    _mapViewAddLinkMenuItem.Visible = false;
                    switch (e.Node.Level)
                    {
                        // Root node
                        case 0:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddFloorMenuItem.Visible = true;
                            return;
                        }
                        // Floor node
                        case 1:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddEntryNodeMenuItem.Visible = true;
                            _mapViewAddGuideNodeMenuItem.Visible = true;
                            _mapViewAddWallNodeMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        // Collection node
                        case 2:
                        {
                            switch (selectedNode.Index)
                            {
                                // Entry nodes
                                case 0:
                                {
                                    _mapViewAddMenuItem.Visible = true;
                                    _mapViewAddEntryNodeMenuItem.Visible = true;
                                    _mapViewAddLinkMenuItem.Visible = true;
                                    return;
                                }
                                // Guide nodes
                                case 1:
                                {
                                    _mapViewAddMenuItem.Visible = true;
                                    _mapViewAddGuideNodeMenuItem.Visible = true;
                                    _mapViewAddLinkMenuItem.Visible = true;
                                    return;
                                }
                                // Wall nodes
                                case 2:
                                {
                                    _mapViewAddMenuItem.Visible = true;
                                    _mapViewAddWallNodeMenuItem.Visible = true;
                                    _mapViewAddLinkMenuItem.Visible = true;
                                    return;
                                }
                                // Links
                                case 3:
                                {
                                    _mapViewAddMenuItem.Visible = true;
                                    _mapViewAddLinkMenuItem.Visible = true;
                                    return;
                                }
                                default:
                                {
                                    return;
                                }
                            }
                        }
                        // Element node
                        case 3:
                        {
                            if (selectedNode.MapElement is Link) return;
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        default:
                        {
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
            _designer.BackgroundImage = null;
        }

        #endregion // Event handlers
    }
}
