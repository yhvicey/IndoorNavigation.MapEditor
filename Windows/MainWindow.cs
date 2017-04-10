namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Controls;
    using Extensions;
    using Map;
    using Models;
    using Models.Nodes;
    using Properties;

    public partial class MainWindow : Form
    {
        #region Constants

        private const int MapNodeLevel = 0;

        private const int FloorNodeLevel = 1;

        private const int CatalogueNodeLevel = 2;

        private const int ElementNodeLevel = 3;

        private const int EntryNodesIndex = 0;

        private const int GuideNodesIndex = 1;

        private const int WallNodesIndex = 2;

        private const int LinksIndex = 3;

        #endregion

        #region Variables

        private IReadOnlyList<string> _commandLineArgs;

        private int _currentFloorIndex = -1;

        private Map _currentMap;

        private MapViewAdapter _mapViewAdapter;

        #endregion // Variables

        #region Initialize functions

        private void InitializeMapElementTreeNode()
        {
            MapElementTreeNode.CustomContextMenuStrip = _mapViewMenuStrip;
        }

        private void InitializeMapViewAdapter()
        {
            _mapViewAdapter = new MapViewAdapter(_mapView);
        }

        #endregion // Initialize functions

        #region Flush functions

        private void Flush()
        {
            FlushDesigner();
            FlushMapStatusLabel();
            FlushMapView();
        }

        private void FlushDesigner()
        {

        }

        private void FlushMapStatusLabel()
        {
            _mapStatusLable.Text = string.Format(Resources.MapStatusTemplate, _currentMap?.Name ?? "None",
                _currentFloorIndex == -1 ? "None" : (_currentFloorIndex + 1).ToString());
        }

        public void FlushMapView()
        {
            _mapViewAdapter?.Flush();
        }

        #endregion // Flush functions

        #region View functions

        private void OnAddMap()
        {
            StatusBarMessage("Adding map...");

            _mapViewAdapter.AddMap(_currentMap);

            Flush();
            StatusBarMessage("Map added.");
        }

        private void OnAddFloor(Floor floor)
        {
            StatusBarMessage("Adding floor...");

            _mapViewAdapter.AddFloor(floor);

            Flush();
            StatusBarMessage("Floor added.");
        }

        private void OnAddLink(Link link, int floorIndex)
        {
            StatusBarMessage("Adding link...");

            _mapViewAdapter.AddLink(link, floorIndex);

            Flush();
            StatusBarMessage("Link added.");
        }

        private void OnAddNode(NodeBase node, int floorIndex)
        {
            StatusBarMessage("Adding node...");

            _mapViewAdapter.AddNode(node, floorIndex);

            Flush();
            StatusBarMessage("Node added.");
        }

        private void OnMapViewMenuShow(int itemLevel, int nodeIndex, object mapElement)
        {
            _mapViewAddMenuItem.Visible = false;
            _mapViewAddFloorMenuItem.Visible = false;
            _mapViewAddEntryNodeMenuItem.Visible = false;
            _mapViewAddGuideNodeMenuItem.Visible = false;
            _mapViewAddWallNodeMenuItem.Visible = false;
            _mapViewAddLinkMenuItem.Visible = false;
            switch (itemLevel)
            {
                case MapNodeLevel:
                {
                    _mapViewAddMenuItem.Visible = true;
                    _mapViewAddFloorMenuItem.Visible = true;
                    return;
                }
                case FloorNodeLevel:
                {
                    _mapViewAddMenuItem.Visible = true;
                    _mapViewAddEntryNodeMenuItem.Visible = true;
                    _mapViewAddGuideNodeMenuItem.Visible = true;
                    _mapViewAddWallNodeMenuItem.Visible = true;
                    _mapViewAddLinkMenuItem.Visible = true;
                    return;
                }
                case CatalogueNodeLevel:
                {
                    switch (nodeIndex)
                    {
                        case EntryNodesIndex:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddEntryNodeMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        case GuideNodesIndex:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddGuideNodeMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        case WallNodesIndex:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddWallNodeMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        case LinksIndex:
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
                case ElementNodeLevel:
                {
                    if (mapElement is Link) return;
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

        private void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            StatusBarMessage("Removing catalogue...");

            _mapViewAdapter.RemoveCatalogue(floorIndex, catalogueIndex);

            Flush();
            StatusBarMessage("Catalogue removed.");
        }

        private void OnRemoveMap(Map map)
        {
            StatusBarMessage("Removing map...");

            if (map != null &&
                MessageBox.Show(Resources.SaveMapNotification, Resources.InfoDialogTitle, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes) SaveMap(map);

            _mapViewAdapter.RemoveMap();

            Flush();
            StatusBarMessage("Map removed.");
        }

        private void OnRemoveFloor(int floorIndex)
        {
            StatusBarMessage("Removing floor...");

            _mapViewAdapter.RemoveFloor(floorIndex);

            Flush();
            StatusBarMessage("Floor removed.");
        }

        private void OnRemoveLink(int floorIndex, int linkIndex)
        {
            StatusBarMessage("Removing link...");

            _mapViewAdapter.RemoveLink(floorIndex, linkIndex);

            Flush();
            StatusBarMessage("Link removed.");
        }

        private void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            StatusBarMessage("Removing node...");

            _mapViewAdapter.RemoveNode(floorIndex, type, nodeIndex);

            Flush();
            StatusBarMessage("Node removed.");
        }

        private void OnSelectCatalogue(int floorIndex, int catalogueIndex)
        {
            _mapViewAdapter.SelectCatalogue(floorIndex, catalogueIndex);
            _propertyGrid.SelectedObject = _currentMap;

            Flush();
        }

        private void OnSelectMap()
        {
            _mapViewAdapter.SelectMap();
            _propertyGrid.SelectedObject = _currentMap;

            Flush();
        }

        private void OnSelectFloor(int floorIndex)
        {
            _mapViewAdapter.SelectFloor(floorIndex);
            _propertyGrid.SelectedObject = _currentMap.Floors[floorIndex];

            Flush();
        }

        private void OnSelectLink(int floorIndex, int linkIndex)
        {
            _mapViewAdapter.SelectLink(floorIndex, linkIndex);
            _propertyGrid.SelectedObject = _currentMap.Floors[floorIndex].Links[linkIndex];

            Flush();
        }

        private void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            _mapViewAdapter.SelectNode(floorIndex, type, nodeIndex);
            _propertyGrid.SelectedObject = _currentMap.Floors[floorIndex].GetNode(type, nodeIndex);

            Flush();
        }

        #endregion // View functions

        #region Functions

        private void AddMap(Map map)
        {
            if (_currentMap != null && !SaveMap(_currentMap)) return;
            if (map == null) return;
            _currentMap = map;

            OnAddMap();
        }

        private void AddFloor(Floor floor)
        {
            _currentMap?.AddFloor(floor);

            OnAddFloor(floor);
        }

        private void AddLink(Link link, int floorIndex)
        {
            _currentMap?.Floors[floorIndex].AddLink(link);

            OnAddLink(link, floorIndex);
        }

        private void AddNode(NodeBase node, int floorIndex)
        {
            _currentMap?.Floors[floorIndex].AddNode(node);

            OnAddNode(node, floorIndex);
        }

        private Map LoadMap()
        {
            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".xml",
                Filter = Resources.MapFileFilter
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return null;
            var map = MapParser.Parse(openFileDialog.FileName);
            StatusBarMessage("Map loaded.");
            return map;
        }

        private void RemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            Unselect();

            var floor = _currentMap?.Floors[floorIndex];
            if (floor == null) return;
            switch (catalogueIndex)
            {
                case EntryNodesIndex:
                {
                    floor.EntryNodes.Clear();
                    break;
                }
                case GuideNodesIndex:
                {
                    floor.GuideNodes.Clear();
                    break;
                }
                case WallNodesIndex:
                {
                    floor.WallNodes.Clear();
                    break;
                }
                case LinksIndex:
                {
                    floor.Links.Clear();
                    break;
                }
            }

            OnRemoveCatalogue(floorIndex, catalogueIndex);
        }

        private void RemoveMap()
        {
            Unselect();

            var mapToRemove = _currentMap;
            _currentMap = null;

            OnRemoveMap(mapToRemove);
        }

        private void RemoveFloor(int floorIndex)
        {
            Unselect();

            _currentMap?.RemoveFloor(floorIndex);

            OnRemoveFloor(floorIndex);
        }

        private void RemoveLink(int floorIndex, int linkIndex)
        {
            Unselect();

            _currentMap?.Floors[floorIndex].RemoveLink(linkIndex);

            OnRemoveLink(floorIndex, linkIndex);
        }

        private void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Unselect();

            _currentMap?.Floors[floorIndex].RemoveNode(type, nodeIndex);

            OnRemoveNode(floorIndex, type, nodeIndex);
        }

        private bool SaveMap(Map map)
        {
            if (map == null)
            {
                MessageBox.Show(Resources.NoMapToSaveError);
                return false;
            }
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".xml",
                Filter = Resources.MapFileFilter
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return false;
            MapSaver.Save(saveFileDialog.FileName, map);
            StatusBarMessage("Map saved.");
            return true;
        }

        private void SelectCatalogue(int floorIndex, int catalogueIndex)
        {
            if (floorIndex != _currentFloorIndex) SelectFloor(floorIndex);

            OnSelectCatalogue(floorIndex, catalogueIndex);
        }

        private void SelectMap()
        {
            OnSelectMap();
        }

        private void SelectFloor(int floorIndex)
        {
            _currentFloorIndex = floorIndex;

            OnSelectFloor(floorIndex);
        }

        private void SelectLink(int floorIndex, int linkIndex)
        {
            if (floorIndex != _currentFloorIndex) SelectFloor(floorIndex);

            OnSelectLink(floorIndex, linkIndex);
        }

        private void SelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            if (floorIndex != _currentFloorIndex) SelectFloor(floorIndex);

            OnSelectNode(floorIndex, type, nodeIndex);
        }

        private void StatusBarMessage(string message = null)
        {
            _messageStatusLabel.Text = message ?? Resources.Ready;
        }

        private void Unselect()
        {
            _propertyGrid.SelectedObject = null;
        }

        #endregion // Functions

        #region Constructors

        public MainWindow(IReadOnlyList<string> args = null)
        {
            InitializeComponent();

            InitializeMapElementTreeNode();
            InitializeMapViewAdapter();

            _commandLineArgs = args;
        }

        #endregion // Constructors

        #region Event handlers

        private void CloseMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                RemoveMap();
                Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DesignToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                _designToolStrip.Items.OfType<ToolStripButton>().ForEach(item => item.Checked = false);
                if (e.ClickedItem is ToolStripButton button) button.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_currentMap != null) RemoveMap();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadBackgroundMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = Resources.ImageFilter
                };
                if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;
                using (var stream = openFileDialog.OpenFile())
                {
                    var background = Image.FromStream(stream);
                    _designer.BackgroundImage = background;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(_commandLineArgs?.Count > 0)) return;
                AddMap(MapParser.Parse(_commandLineArgs[0]));
                _commandLineArgs = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MapViewAddEntryNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var wizard = new AddNodeWizard(_currentMap)
                {
                    Floor = _currentFloorIndex,
                    Type = NodeType.EntryNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddNode(wizard.MakeNode(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MapViewAddFloorMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                AddFloor(new Floor());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MapViewAddGuideNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var wizard = new AddNodeWizard(_currentMap)
                {
                    Floor = _currentFloorIndex,
                    Type = NodeType.GuideNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddNode(wizard.MakeNode(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MapViewAddLinkMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var selectedNode = _mapView.SelectedNode as MapElementTreeNode;
                if (selectedNode == null) return;
                var wizard = new AddLinkWizard(_currentMap)
                {
                    Floor = _currentFloorIndex,
                };
                switch (selectedNode.Level)
                {
                    case CatalogueNodeLevel:
                    {
                        if (selectedNode.Index != LinksIndex) wizard.StartType = (NodeType)selectedNode.Index;
                        break;
                    }
                    case ElementNodeLevel:
                    {
                        if (selectedNode.Parent.Index != LinksIndex) wizard.StartType = (NodeType)selectedNode.Parent.Index;
                        wizard.StartIndex = selectedNode.Index;
                        break;
                    }
                }
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddLink(wizard.MakeLink(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MapViewAddWallNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var wizard = new AddNodeWizard(_currentMap)
                {
                    Floor = _currentFloorIndex,
                    Type = NodeType.WallNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddNode(wizard.MakeNode(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MapViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var selectedNode = e.Node as MapElementTreeNode;
                if (selectedNode == null) return;
                switch (selectedNode.Level)
                {
                    case MapNodeLevel:
                    {
                        SelectMap();
                        break;
                    }
                    case FloorNodeLevel:
                    {
                        SelectFloor(selectedNode.Index);
                        break;
                    }
                    case CatalogueNodeLevel:
                    {
                        SelectCatalogue(selectedNode.Parent.Index, selectedNode.Index);
                        break;
                    }
                    case ElementNodeLevel:
                    {
                        var catalogueIndex = selectedNode.Parent.Index;
                        if (catalogueIndex == LinksIndex)
                            SelectLink(selectedNode.Parent.Parent.Index, selectedNode.Index);
                        else
                            SelectNode(selectedNode.Parent.Parent.Index, (NodeType)selectedNode.Parent.Index,
                                selectedNode.Index);
                        break;
                    }
                }
                if (e.Button != MouseButtons.Right) return;
                OnMapViewMenuShow(selectedNode.Level, selectedNode.Index, selectedNode.MapElement);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MapViewRemoveMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var selectedNode = _mapView.SelectedNode as MapElementTreeNode;
                if (selectedNode == null) return;
                switch (selectedNode.Level)
                {
                    case MapNodeLevel:
                    {
                        RemoveMap();
                        break;
                    }
                    case FloorNodeLevel:
                    {
                        RemoveFloor(selectedNode.Index);
                        break;
                    }
                    case CatalogueNodeLevel:
                    {
                        RemoveCatalogue(selectedNode.Parent.Index, selectedNode.Index);
                        break;
                    }
                    case ElementNodeLevel:
                    {
                        switch (selectedNode.Index)
                        {
                            case EntryNodesIndex:
                            case GuideNodesIndex:
                            case WallNodesIndex:
                            {
                                RemoveNode(selectedNode.Parent.Parent.Index, (NodeType)selectedNode.Index, selectedNode.Index);
                                break;
                            }
                            case LinksIndex:
                            {
                                RemoveLink(selectedNode.Parent.Parent.Index, selectedNode.Index);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NewFloorMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                AddFloor(new Floor());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NewLinkMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var wizard = new AddLinkWizard(_currentMap)
                {
                    Floor = _currentFloorIndex
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddLink(wizard.MakeLink(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NewMapMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                RemoveMap();
                AddMap(new Map("Untitled", new List<Floor>()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NewNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var wizard = new AddNodeWizard(_currentMap)
                {
                    Floor = _currentFloorIndex
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddNode(wizard.MakeNode(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OpenMapMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                RemoveMap();
                AddMap(LoadMap());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PropertyGridPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RemoveBackgroundMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                _designer.BackgroundImage = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                SaveMap(_currentMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion // Event handlers
    }
}
