namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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

    public partial class MainWindow :
        Form
    {
        #region Variables

        private DesignerViewAdapter _designerViewAdapter;

        private MapViewAdapter _mapViewAdapter;

        #endregion // Variables

        #region Properties

        public int CurrentFloorIndex { get; private set; } = Constant.NoSelectedFloor;

        public Map CurrentMap { get; private set; }

        public string CurrentMapFile { get; private set; }

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

        private void AboutMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                new AboutBox().ShowDialog(this);
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void ChangeCanvasSizeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void CloseMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                RemoveMap();
                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void DebugButtonClick(object sender, EventArgs e)
        {
            try
            {
                var value = int.Parse("Hello world");
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
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
                ExceptionDialog.Show(this, ex);
            }
        }

        private void LoadBackgroundMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                StatusBarMessage("Loading background...");

                var openFileDialog = new OpenFileDialog
                {
                    Filter = Resources.ImageFilter
                };

                if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;

                using (var stream = openFileDialog.OpenFile())
                {
                    var image = Image.FromStream(stream);
                    if (CurrentFloorIndex != Constant.NoSelectedFloor &&
                        MessageBox.Show(this, Resources.UseBackgroundImageSizeNotification, Resources.InfoDialogTitle,
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        _designerViewAdapter.ChangeCanvasSize(image.Size, CurrentFloorIndex);
                    _designerViewAdapter.LoadBackground(image, CurrentFloorIndex);
                }

                StatusBarMessage("Background loaded.");
                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            try
            {
                Flush();
                if (CurrentMapFile != null) AddMap(MapParser.Parse(CurrentMapFile));
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void NewFloorMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }

                AddFloor(new Floor());
                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void NewLinkMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }
                if (CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                var wizard = new AddLinkWizard(CurrentMap)
                {
                    Floor = CurrentFloorIndex
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddLink(wizard.Make(), wizard.Floor);
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
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
                ExceptionDialog.Show(this, ex);
            }
        }

        private void NewNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }
                if (CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                var wizard = new AddNodeWizard(CurrentMap)
                {
                    Floor = CurrentFloorIndex
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                AddNode(wizard.Make(), wizard.Floor);
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void OpenMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                RemoveMap();
                AddMap(LoadMap());
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
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
                ExceptionDialog.Show(this, ex);
            }
        }

        private void RemoveBackgroundMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                _designerViewAdapter.RemoveBackground();
                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void SaveMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }

                SaveMap(CurrentMap);
                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void SaveAsMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }

                SaveMap(CurrentMap, true);
                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        #endregion // Event handlers

        #region View functions

        private void OnAddMap(Map map)
        {
            Debug.Assert(map != null);

            StatusBarMessage("Adding map...");

            _designerViewAdapter.OnAddMap(map);
            _mapViewAdapter.OnAddMap(map);

            SelectMap(map);

            StatusBarMessage("Map added.");
            Flush();
        }

        private void OnAddFloor(Floor floor)
        {
            Debug.Assert(floor != null);

            StatusBarMessage("Adding floor...");

            _designerViewAdapter.OnAddFloor(floor);
            _mapViewAdapter.OnAddFloor(floor);

            var floorIndex = CurrentMap.Floors.Count - 1;
            SelectFloor(floorIndex);

            var wizard = new ChangeSizeWizard
            {
                WidthProperty = _designerView.CanvasSize.Width,
                HeightProperty = _designerView.CanvasSize.Height
            };

            if (wizard.ShowDialog() != DialogResult.Yes) return;
            if (wizard.Ready) _designerViewAdapter.ChangeCanvasSize(wizard.Make(), floorIndex);

            StatusBarMessage("Floor added.");
            Flush();
        }

        private void OnAddLink(Link link, int floorIndex)
        {
            Debug.Assert(link != null);
            Debug.Assert(floorIndex >= 0);

            StatusBarMessage("Adding link...");

            _designerViewAdapter.OnAddLink(link, floorIndex);
            _mapViewAdapter.OnAddLink(link, floorIndex);

            StatusBarMessage("Link added.");
            Flush();
        }

        private void OnAddNode(NodeBase node, int floorIndex)
        {
            Debug.Assert(node != null);
            Debug.Assert(floorIndex >= 0);

            StatusBarMessage("Adding node...");

            _designerViewAdapter.OnAddNode(node, floorIndex);
            _mapViewAdapter.OnAddNode(node, floorIndex);

            StatusBarMessage("Node added.");
            Flush();
        }

        private void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            Unselect();

            StatusBarMessage("Removing catalogue...");

            _designerViewAdapter.OnRemoveCatalogue(floorIndex, catalogueIndex);
            _mapViewAdapter.OnRemoveCatalogue(floorIndex, catalogueIndex);

            StatusBarMessage("Catalogue removed.");
            Flush();
        }

        private void OnRemoveMap(Map map)
        {
            Debug.Assert(map != null);

            Unselect();

            StatusBarMessage("Removing map...");

            if (
                MessageBox.Show(this, Resources.SaveMapNotification, Resources.InfoDialogTitle, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes) SaveMap(map);

            _designerViewAdapter.OnRemoveMap();
            _mapViewAdapter.OnRemoveMap();

            StatusBarMessage("Map removed.");
            Flush();
        }

        private void OnRemoveFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            Unselect();

            StatusBarMessage("Removing floor...");

            _designerViewAdapter.OnRemoveFloor(floorIndex);
            _mapViewAdapter.OnRemoveFloor(floorIndex);

            StatusBarMessage("Floor removed.");
            Flush();
        }

        private void OnRemoveLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            Unselect();

            StatusBarMessage("Removing link...");

            _designerViewAdapter.OnRemoveLink(floorIndex, linkIndex);
            _mapViewAdapter.OnRemoveLink(floorIndex, linkIndex);

            StatusBarMessage("Link removed.");
            Flush();
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

            StatusBarMessage("Node removed.");
            Flush();
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
            _mapStatusLable.Text = string.Format(Resources.MapStatusTemplate,
                CurrentFloorIndex == Constant.NoSelectedFloor ? "None" : (CurrentFloorIndex + 1).ToString(),
                $"{_designerView.CanvasSize.Width}, {_designerView.CanvasSize.Height}");
            Text = Resources.MainWindowTitle + (CurrentMapFile == null ? "" : $" - {CurrentMapFile}");
        }

        public void AddMap(Map map)
        {
            Debug.Assert(map != null);

            if (CurrentMap != null && !SaveMap(CurrentMap)) return;
            CurrentMap = map;

            OnAddMap(map);
        }

        public void AddFloor(Floor floor)
        {
            Debug.Assert(floor != null);

            CurrentMap.AddFloor(floor);

            OnAddFloor(floor);
        }

        public void AddLink(Link link, int floorIndex)
        {
            Debug.Assert(link != null);
            Debug.Assert(floorIndex >= 0);

            var floor = CurrentMap.Floors[floorIndex];
            if (floor.Links.Contains(link)) return;
            floor.AddLink(link);

            OnAddLink(link, floorIndex);
        }

        public void AddNode(NodeBase node, int floorIndex)
        {
            Debug.Assert(node != null);
            Debug.Assert(floorIndex >= 0);

            var floor = CurrentMap.Floors[floorIndex];
            floor.AddNode(node);

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

            var floor = CurrentMap.Floors[floorIndex];
            if (floor == null) return;
            switch (catalogueIndex)
            {
                case Constant.EntryNodesIndex:
                {
                    for (var i = floor.EntryNodes.Count - 1; i >= 0; i--) RemoveNode(floorIndex, NodeType.EntryNode, i);
                    break;
                }
                case Constant.GuideNodesIndex:
                {
                    for (var i = floor.GuideNodes.Count - 1; i >= 0; i--) RemoveNode(floorIndex, NodeType.GuideNode, i);
                    break;
                }
                case Constant.WallNodesIndex:
                {
                    for (var i = floor.WallNodes.Count - 1; i >= 0; i--) RemoveNode(floorIndex, NodeType.WallNode, i);
                    break;
                }
                case Constant.LinksIndex:
                {
                    for (var i = floor.Links.Count - 1; i >= 0; i--) RemoveLink(floorIndex, i);
                    break;
                }
            }

            SelectFloor(floorIndex);

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

            CurrentMap.RemoveFloor(floorIndex);
            CurrentFloorIndex = Constant.NoSelectedFloor;

            SelectMap(CurrentMap);

            OnRemoveFloor(floorIndex);
        }

        public void RemoveLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            CurrentMap.Floors[floorIndex].RemoveLink(linkIndex);

            SelectCatalogue(floorIndex, Constant.LinksIndex);

            OnRemoveLink(floorIndex, linkIndex);
        }

        public void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            var floor = CurrentMap.Floors[floorIndex];
            floor?.GetRelatedLinkIndices(type, nodeIndex).ForEach(index => RemoveLink(floorIndex, index));
            floor?.RemoveNode(type, nodeIndex);

            SelectCatalogue(floorIndex, (int)type);

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

        public void UpdateCursorLocation(int x, int y)
        {
            _cursorStatusLabel.Text = string.Format(Resources.CursorStatusTemplate, x, y);
        }

        public MainWindow(IReadOnlyCollection<string> args = null)
        {
            InitializeComponent();

            InitializeDesignerView();
            InitializeMapView();
#if DEBUG
            _debugMenuItem.Visible = true;
#endif

            if (!(args?.Count > 0)) return;
            CurrentMapFile = args.First();
        }
    }
}
