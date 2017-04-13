namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Adapter;
    using Extensions;
    using Map;
    using Models;
    using Models.Nodes;
    using Properties;
    using Share;

    public partial class MainWindow : Form
    {
        #region Variables

        private DesignerViewAdapter _designerViewAdapter;

        private MapViewAdapter _mapViewAdapter;

        #endregion // Variables

        #region Properties

        public int CurrentFloorIndex { get; private set; } = Constant.NoSelectedFloor;

        public Map CurrentMap { get; private set; }

        public string CurrentMapFile { get; private set; }

        public int Scale { get; private set; }

        #endregion // Properties

        #region Initialize functions

        private void InitializeDesignerView()
        {
            _designerView.SetParent(this);
            _designerViewAdapter = new DesignerViewAdapter(_designerView);
        }

        private void InitializeMapView()
        {
            _mapView.SetParent(this);
            _mapViewAdapter = new MapViewAdapter(_mapView);
        }

        #endregion // Initialize functions

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

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMap != null) RemoveMap();
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
                    _designerView.BackgroundImage = background;
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
                if (CurrentMapFile == null) return;
                AddMap(MapParser.Parse(CurrentMapFile));
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
                var wizard = new AddLinkWizard(CurrentMap)
                {
                    Floor = CurrentFloorIndex
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
                var wizard = new AddNodeWizard(CurrentMap)
                {
                    Floor = CurrentFloorIndex
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
                _designerView.BackgroundImage = null;
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
                if (CurrentMap == null)
                {
                    MessageBox.Show(Resources.NoMapToSaveError);
                    return;
                }
                SaveMap(CurrentMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveAsMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMap == null)
                {
                    MessageBox.Show(Resources.NoMapToSaveError);
                    return;
                }
                SaveMap(CurrentMap, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion // Event handlers

        #region View functions

        private void OnAddMap()
        {
            StatusBarMessage("Adding map...");

            _designerViewAdapter.OnAddMap(CurrentMap);
            _mapViewAdapter.OnAddMap(CurrentMap);

            Flush();
            StatusBarMessage("Map added.");
        }

        private void OnAddFloor(Floor floor)
        {
            Debug.Assert(floor != null);

            StatusBarMessage("Adding floor...");

            _designerViewAdapter.OnAddFloor(floor);
            _mapViewAdapter.OnAddFloor(floor);

            Flush();
            StatusBarMessage("Floor added.");
        }

        private void OnAddLink(Link link, int floorIndex)
        {
            Debug.Assert(link != null);
            Debug.Assert(floorIndex >= 0);


            StatusBarMessage("Adding link...");

            _designerViewAdapter.OnAddLink(link, floorIndex);
            _mapViewAdapter.OnAddLink(link, floorIndex);

            Flush();
            StatusBarMessage("Link added.");
        }

        private void OnAddNode(NodeBase node, int floorIndex)
        {
            Debug.Assert(node != null);
            Debug.Assert(floorIndex >= 0);


            StatusBarMessage("Adding node...");

            _designerViewAdapter.OnAddNode(node, floorIndex);
            _mapViewAdapter.OnAddNode(node, floorIndex);

            Flush();
            StatusBarMessage("Node added.");
        }

        private void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            Unselect();

            StatusBarMessage("Removing catalogue...");

            _designerViewAdapter.OnRemoveCatalogue(floorIndex, catalogueIndex);
            _mapViewAdapter.OnRemoveCatalogue(floorIndex, catalogueIndex);

            Flush();
            StatusBarMessage("Catalogue removed.");
        }

        private void OnRemoveMap(Map map)
        {
            Debug.Assert(map != null);

            Unselect();

            StatusBarMessage("Removing map...");

            if (
                MessageBox.Show(Resources.SaveMapNotification, Resources.InfoDialogTitle, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes) SaveMap(map);

            _designerViewAdapter.OnRemoveMap();
            _mapViewAdapter.OnRemoveMap();

            Flush();
            StatusBarMessage("Map removed.");
        }

        private void OnRemoveFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            Unselect();

            StatusBarMessage("Removing floor...");

            _designerViewAdapter.OnRemoveFloor(floorIndex);
            _mapViewAdapter.OnRemoveFloor(floorIndex);

            Flush();
            StatusBarMessage("Floor removed.");
        }

        private void OnRemoveLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            Unselect();

            StatusBarMessage("Removing link...");

            _designerViewAdapter.OnRemoveLink(floorIndex, linkIndex);
            _mapViewAdapter.OnRemoveLink(floorIndex, linkIndex);

            Flush();
            StatusBarMessage("Link removed.");
        }

        private void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            Unselect();

            StatusBarMessage("Removing node...");

            _designerViewAdapter.OnRemoveNode(floorIndex, type, nodeIndex);
            _mapViewAdapter.OnRemoveNode(floorIndex, type, nodeIndex);

            Flush();
            StatusBarMessage("Node removed.");
        }

        private void OnSelectCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            _designerViewAdapter.OnSelectCatalogue(floorIndex, catalogueIndex);
            _mapViewAdapter.OnSelectCatalogue(floorIndex, catalogueIndex);
            _propertyGrid.SelectedObject = CurrentMap;

            Flush();
        }

        private void OnSelectMap(Map map)
        {
            Debug.Assert(map != null);

            _designerViewAdapter.OnSelectMap(map);
            _mapViewAdapter.OnSelectMap(map);
            _propertyGrid.SelectedObject = map;

            Flush();
        }

        private void OnSelectFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            _designerViewAdapter.OnSelectFloor(floorIndex);
            _mapViewAdapter.OnSelectFloor(floorIndex);
            _propertyGrid.SelectedObject = CurrentMap.Floors[floorIndex];

            Flush();
        }

        private void OnSelectLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            _designerViewAdapter.OnSelectLink(floorIndex, linkIndex);
            _mapViewAdapter.OnSelectLink(floorIndex, linkIndex);
            _propertyGrid.SelectedObject = CurrentMap.Floors[floorIndex].Links[linkIndex];

            Flush();
        }

        private void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            _designerViewAdapter.OnSelectNode(floorIndex, type, nodeIndex);
            _mapViewAdapter.OnSelectNode(floorIndex, type, nodeIndex);
            _propertyGrid.SelectedObject = CurrentMap.Floors[floorIndex].GetNode(type, nodeIndex);

            Flush();
        }

        #endregion // View functions

        private void Flush()
        {
            _designerViewAdapter.OnFlush();
            _mapViewAdapter.OnFlush();
            _mapStatusLable.Text = string.Format(Resources.MapStatusTemplate, CurrentMapFile ?? "None",
                CurrentFloorIndex == Constant.NoSelectedFloor ? "None" : (CurrentFloorIndex + 1).ToString());
        }

        public void AddMap(Map map)
        {
            Debug.Assert(map != null);

            if (CurrentMap != null && !SaveMap(CurrentMap)) return;
            SelectMap(map);

            OnAddMap();
        }

        public void AddFloor(Floor floor)
        {
            Debug.Assert(floor != null);

            CurrentMap?.AddFloor(floor);

            OnAddFloor(floor);
        }

        public void AddLink(Link link, int floorIndex)
        {
            Debug.Assert(link != null);
            Debug.Assert(floorIndex >= 0);

            CurrentMap?.Floors[floorIndex].AddLink(link);

            OnAddLink(link, floorIndex);
        }

        public void AddNode(NodeBase node, int floorIndex)
        {
            Debug.Assert(node != null);
            Debug.Assert(floorIndex >= 0);

            CurrentMap?.Floors[floorIndex].AddNode(node);

            OnAddNode(node, floorIndex);
        }

        public Map LoadMap()
        {
            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".xml",
                Filter = Resources.MapFileFilter
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return null;
            var map = MapParser.Parse(openFileDialog.FileName);
            CurrentMapFile = openFileDialog.FileName;
            StatusBarMessage("Map loaded.");
            return map;
        }

        public void RemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            var floor = CurrentMap?.Floors[floorIndex];
            if (floor == null) return;
            switch (catalogueIndex)
            {
                case Constant.EntryNodesIndex:
                {
                    floor.EntryNodes.Clear();
                    break;
                }
                case Constant.GuideNodesIndex:
                {
                    floor.GuideNodes.Clear();
                    break;
                }
                case Constant.WallNodesIndex:
                {
                    floor.WallNodes.Clear();
                    break;
                }
                case Constant.LinksIndex:
                {
                    floor.Links.Clear();
                    break;
                }
            }

            OnRemoveCatalogue(floorIndex, catalogueIndex);
        }

        public void RemoveMap()
        {
            if (CurrentMap == null) return;

            var mapToRemove = CurrentMap;
            CurrentMapFile = null;
            CurrentFloorIndex = Constant.NoSelectedFloor;
            CurrentMap = null;

            OnRemoveMap(mapToRemove);
        }

        public void RemoveFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            CurrentMap?.RemoveFloor(floorIndex);

            OnRemoveFloor(floorIndex);
        }

        public void RemoveLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            CurrentMap?.Floors[floorIndex].RemoveLink(linkIndex);

            OnRemoveLink(floorIndex, linkIndex);
        }

        public void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            CurrentMap?.Floors[floorIndex].GetLinkIndices(type, nodeIndex).ForEach(linkIndex => RemoveLink(floorIndex, linkIndex));
            CurrentMap?.Floors[floorIndex].RemoveNode(type, nodeIndex);

            OnRemoveNode(floorIndex, type, nodeIndex);
        }

        public bool SaveMap(Map map, bool saveAs = false)
        {
            Debug.Assert(map != null);

            if (CurrentMapFile == null || saveAs)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    DefaultExt = ".xml",
                    Filter = Resources.MapFileFilter,
                    InitialDirectory = Path.GetDirectoryName(CurrentMapFile) ?? ""
                };
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return false;
                CurrentMapFile = saveFileDialog.FileName;
            }
            MapSaver.Save(CurrentMapFile, map);
            StatusBarMessage("Map saved.");
            return true;
        }

        public void SelectCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            if (floorIndex != CurrentFloorIndex) SelectFloor(floorIndex);

            OnSelectCatalogue(floorIndex, catalogueIndex);
        }

        public void SelectMap(Map map)
        {
            Debug.Assert(map != null);

            CurrentFloorIndex = Constant.NoSelectedFloor;
            CurrentMap = map;

            OnSelectMap(map);
        }

        public void SelectFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            CurrentFloorIndex = floorIndex;

            OnSelectFloor(floorIndex);
        }

        public void SelectLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            if (floorIndex != CurrentFloorIndex) SelectFloor(floorIndex);

            OnSelectLink(floorIndex, linkIndex);
        }

        public void SelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            if (floorIndex != CurrentFloorIndex) SelectFloor(floorIndex);

            OnSelectNode(floorIndex, type, nodeIndex);
        }

        public void StatusBarMessage(string message = null)
        {
            _messageStatusLabel.Text = message ?? Resources.Ready;
        }

        public void Unselect()
        {
            _propertyGrid.SelectedObject = null;
        }

        public MainWindow(IReadOnlyCollection<string> args = null)
        {
            InitializeComponent();

            InitializeDesignerView();
            InitializeMapView();

            if (!(args?.Count > 0)) return;
            CurrentMapFile = args.First();
        }
    }
}
