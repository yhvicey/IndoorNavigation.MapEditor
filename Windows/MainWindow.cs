namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Controls.Adapter;
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

        internal int CurrentFloorIndex { get; private set; } = -1;

        internal Map CurrentMap { get; private set; }

        internal string CurrentMapFile { get; private set; }

        #endregion // Variables

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
            StatusBarMessage("Adding floor...");

            _designerViewAdapter.OnAddFloor(floor);
            _mapViewAdapter.OnAddFloor(floor);

            Flush();
            StatusBarMessage("Floor added.");
        }

        private void OnAddLink(Link link, int floorIndex)
        {
            StatusBarMessage("Adding link...");

            _designerViewAdapter.OnAddLink(link, floorIndex);
            _mapViewAdapter.OnAddLink(link, floorIndex);

            Flush();
            StatusBarMessage("Link added.");
        }

        private void OnAddNode(NodeBase node, int floorIndex)
        {
            StatusBarMessage("Adding node...");

            _designerViewAdapter.OnAddNode(node, floorIndex);
            _mapViewAdapter.OnAddNode(node, floorIndex);

            Flush();
            StatusBarMessage("Node added.");
        }

        private void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            Unselect();

            StatusBarMessage("Removing catalogue...");

            _designerViewAdapter.OnRemoveCatalogue(floorIndex, catalogueIndex);
            _mapViewAdapter.OnRemoveCatalogue(floorIndex, catalogueIndex);

            Flush();
            StatusBarMessage("Catalogue removed.");
        }

        private void OnRemoveMap(Map map)
        {
            Unselect();

            StatusBarMessage("Removing map...");

            if (map != null &&
                MessageBox.Show(Resources.SaveMapNotification, Resources.InfoDialogTitle, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes) SaveMap(map);

            _designerViewAdapter.OnRemoveMap();
            _mapViewAdapter.OnRemoveMap();

            Flush();
            StatusBarMessage("Map removed.");
        }

        private void OnRemoveFloor(int floorIndex)
        {
            Unselect();

            StatusBarMessage("Removing floor...");

            _designerViewAdapter.OnRemoveFloor(floorIndex);
            _mapViewAdapter.OnRemoveFloor(floorIndex);

            Flush();
            StatusBarMessage("Floor removed.");
        }

        private void OnRemoveLink(int floorIndex, int linkIndex)
        {
            Unselect();

            StatusBarMessage("Removing link...");

            _designerViewAdapter.OnRemoveLink(floorIndex, linkIndex);
            _mapViewAdapter.OnRemoveLink(floorIndex, linkIndex);

            Flush();
            StatusBarMessage("Link removed.");
        }

        private void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Unselect();

            StatusBarMessage("Removing node...");

            _designerViewAdapter.OnRemoveNode(floorIndex, type, nodeIndex);
            _mapViewAdapter.OnRemoveNode(floorIndex, type, nodeIndex);

            Flush();
            StatusBarMessage("Node removed.");
        }

        private void OnSelectCatalogue(int floorIndex, int catalogueIndex)
        {
            _designerViewAdapter.OnSelectCatalogue(floorIndex, catalogueIndex);
            _mapViewAdapter.OnSelectCatalogue(floorIndex, catalogueIndex);
            _propertyGrid.SelectedObject = CurrentMap;

            Flush();
        }

        private void OnSelectMap(Map map)
        {
            _designerViewAdapter.OnSelectMap(map);
            _mapViewAdapter.OnSelectMap(map);
            _propertyGrid.SelectedObject = map;

            Flush();
        }

        private void OnSelectFloor(int floorIndex)
        {
            _designerViewAdapter.OnSelectFloor(floorIndex);
            _mapViewAdapter.OnSelectFloor(floorIndex);
            _propertyGrid.SelectedObject = CurrentMap.Floors[floorIndex];

            Flush();
        }

        private void OnSelectLink(int floorIndex, int linkIndex)
        {
            _designerViewAdapter.OnSelectLink(floorIndex, linkIndex);
            _mapViewAdapter.OnSelectLink(floorIndex, linkIndex);
            _propertyGrid.SelectedObject = CurrentMap.Floors[floorIndex].Links[linkIndex];

            Flush();
        }

        private void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
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

        internal void AddMap(Map map)
        {
            if (CurrentMap != null && !SaveMap(CurrentMap)) return;
            if (map == null) return;
            SelectMap(map);

            OnAddMap();
        }

        internal void AddFloor(Floor floor)
        {
            CurrentMap?.AddFloor(floor);

            OnAddFloor(floor);
        }

        internal void AddLink(Link link, int floorIndex)
        {
            CurrentMap?.Floors[floorIndex].AddLink(link);

            OnAddLink(link, floorIndex);
        }

        internal void AddNode(NodeBase node, int floorIndex)
        {
            CurrentMap?.Floors[floorIndex].AddNode(node);

            OnAddNode(node, floorIndex);
        }

        internal Map LoadMap()
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

        internal void RemoveCatalogue(int floorIndex, int catalogueIndex)
        {
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

        internal void RemoveMap()
        {
            var mapToRemove = CurrentMap;
            CurrentMapFile = null;
            CurrentFloorIndex = Constant.NoSelectedFloor;
            CurrentMap = null;

            OnRemoveMap(mapToRemove);
        }

        internal void RemoveFloor(int floorIndex)
        {
            CurrentMap?.RemoveFloor(floorIndex);

            OnRemoveFloor(floorIndex);
        }

        internal void RemoveLink(int floorIndex, int linkIndex)
        {
            CurrentMap?.Floors[floorIndex].RemoveLink(linkIndex);

            OnRemoveLink(floorIndex, linkIndex);
        }

        internal void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            CurrentMap?.Floors[floorIndex].GetLinkIndices(type, nodeIndex).ForEach(linkIndex => RemoveLink(floorIndex, linkIndex));
            CurrentMap?.Floors[floorIndex].RemoveNode(type, nodeIndex);

            OnRemoveNode(floorIndex, type, nodeIndex);
        }

        internal bool SaveMap(Map map, bool saveAs = false)
        {
            if (map == null)
            {
                MessageBox.Show(Resources.NoMapToSaveError);
                return false;
            }
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

        internal void SelectCatalogue(int floorIndex, int catalogueIndex)
        {
            if (floorIndex != CurrentFloorIndex) SelectFloor(floorIndex);

            OnSelectCatalogue(floorIndex, catalogueIndex);
        }

        internal void SelectMap(Map map)
        {
            CurrentFloorIndex = Constant.NoSelectedFloor;
            CurrentMap = map;

            OnSelectMap(map);
        }

        internal void SelectFloor(int floorIndex)
        {
            CurrentFloorIndex = floorIndex;

            OnSelectFloor(floorIndex);
        }

        internal void SelectLink(int floorIndex, int linkIndex)
        {
            if (floorIndex != CurrentFloorIndex) SelectFloor(floorIndex);

            OnSelectLink(floorIndex, linkIndex);
        }

        internal void SelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            if (floorIndex != CurrentFloorIndex) SelectFloor(floorIndex);

            OnSelectNode(floorIndex, type, nodeIndex);
        }

        internal void StatusBarMessage(string message = null)
        {
            _messageStatusLabel.Text = message ?? Resources.Ready;
        }

        internal void Unselect()
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
