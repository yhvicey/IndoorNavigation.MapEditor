namespace IndoorNavigator.MapEditor.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using Windows;
    using Extensions;
    using Models;
    using Models.Nodes;
    using Properties;
    using Share;

    public partial class MapView : TreeView
    {
        #region Inner classes

        public class MapViewTreeNode :
            TreeNode
        {
            public IMapModel MapModel { get; set; }

            public string StaticText { get; set; }

            public MapViewTreeNode(string text = null, IMapModel mapModel = null, IEnumerable<IMapModel> childItems = null)
            {
                StaticText = text;
                MapModel = mapModel;
                childItems?.ForEach(item => Nodes.Add(new MapViewTreeNode(mapModel: item)));

                Update();
            }

            public void Update()
            {
                Text = StaticText ?? MapModel?.ToString() ?? "";
                Nodes.OfType<MapViewTreeNode>().ForEach(node => node.Update());
            }
        }

        #endregion // Inner classes

        #region Variables

        private MainWindow _parent;

        #endregion // Variables

        #region Event handlers

        private void MapViewAddEntryNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_parent.CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }
                if (_parent.CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                var wizard = new AddNodeWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
                    Type = NodeType.EntryNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                _parent.AddNode(wizard.Make(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void MapViewAddFloorMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_parent.CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }

                _parent.AddFloor(new Floor());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void MapViewAddGuideNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_parent.CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }
                if (_parent.CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                var wizard = new AddNodeWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
                    Type = NodeType.GuideNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                _parent.AddNode(wizard.Make(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void MapViewAddLinkMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_parent.CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }
                if (_parent.CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                var selectedNode = SelectedNode as MapViewTreeNode;
                if (selectedNode == null) return;
                var wizard = new AddLinkWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
                };
                switch (selectedNode.Level)
                {
                    case Constant.CatalogueNodeLevel:
                    {
                        if (selectedNode.Index != Constant.LinksIndex) wizard.StartType = (NodeType)selectedNode.Index;
                        break;
                    }
                    case Constant.ElementNodeLevel:
                    {
                        if (selectedNode.Parent.Index != Constant.LinksIndex) wizard.StartType = (NodeType)selectedNode.Parent.Index;
                        wizard.StartIndex = selectedNode.Index;
                        break;
                    }
                }
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                _parent.AddLink(wizard.Make(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void MapViewAddWallNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_parent.CurrentMap == null)
                {
                    MessageBox.Show(this, Resources.NoCurrentMapError);
                    return;
                }
                if (_parent.CurrentFloorIndex == Constant.NoSelectedFloor)
                {
                    MessageBox.Show(this, Resources.NoSelectedFloorError);
                    return;
                }

                var wizard = new AddNodeWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
                    Type = NodeType.WallNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                _parent.AddNode(wizard.Make(), wizard.Floor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void MapViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var selectedNode = e.Node as MapViewTreeNode;
                if (selectedNode == null) return;
                switch (selectedNode.Level)
                {
                    case Constant.MapNodeLevel:
                    {
                        _parent.SelectMap(_parent.CurrentMap);
                        break;
                    }
                    case Constant.FloorNodeLevel:
                    {
                        _parent.SelectFloor(selectedNode.Index);
                        break;
                    }
                    case Constant.CatalogueNodeLevel:
                    {
                        _parent.SelectCatalogue(selectedNode.Parent.Index, selectedNode.Index);
                        break;
                    }
                    case Constant.ElementNodeLevel:
                    {
                        var catalogueIndex = selectedNode.Parent.Index;
                        if (catalogueIndex == Constant.LinksIndex)
                            _parent.SelectLink(selectedNode.Parent.Parent.Index, selectedNode.Index);
                        else
                            _parent.SelectNode(selectedNode.Parent.Parent.Index, (NodeType)selectedNode.Parent.Index,
                                selectedNode.Index);
                        break;
                    }
                }
                if (e.Button != MouseButtons.Right) return;
                OnMapViewMenuShow(selectedNode.Level, selectedNode.Index, selectedNode.MapModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void MapViewRemoveMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var selectedNode = SelectedNode as MapViewTreeNode;
                if (selectedNode == null) return;
                switch (selectedNode.Level)
                {
                    case Constant.MapNodeLevel:
                    {
                        _parent.RemoveMap();
                        break;
                    }
                    case Constant.FloorNodeLevel:
                    {
                        _parent.RemoveFloor(selectedNode.Index);
                        break;
                    }
                    case Constant.CatalogueNodeLevel:
                    {
                        _parent.RemoveCatalogue(selectedNode.Parent.Index, selectedNode.Index);
                        break;
                    }
                    case Constant.ElementNodeLevel:
                    {
                        switch (selectedNode.Parent.Index)
                        {
                            case Constant.EntryNodesIndex:
                            case Constant.GuideNodesIndex:
                            case Constant.WallNodesIndex:
                            {
                                _parent.RemoveNode(selectedNode.Parent.Parent.Index, (NodeType)selectedNode.Parent.Index, selectedNode.Index);
                                break;
                            }
                            case Constant.LinksIndex:
                            {
                                _parent.RemoveLink(selectedNode.Parent.Parent.Index, selectedNode.Index);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        #endregion // Event handlers

        private void OnMapViewMenuShow(int itemLevel, int catalogueIndex, object mapElement)
        {
            Debug.Assert(itemLevel >= 0);
            Debug.Assert(catalogueIndex >= 0);

            _mapViewAddMenuItem.Visible = false;
            _mapViewAddFloorMenuItem.Visible = false;
            _mapViewAddEntryNodeMenuItem.Visible = false;
            _mapViewAddGuideNodeMenuItem.Visible = false;
            _mapViewAddWallNodeMenuItem.Visible = false;
            _mapViewAddLinkMenuItem.Visible = false;
            switch (itemLevel)
            {
                case Constant.MapNodeLevel:
                {
                    _mapViewAddMenuItem.Visible = true;
                    _mapViewAddFloorMenuItem.Visible = true;
                    return;
                }
                case Constant.FloorNodeLevel:
                {
                    _mapViewAddMenuItem.Visible = true;
                    _mapViewAddEntryNodeMenuItem.Visible = true;
                    _mapViewAddGuideNodeMenuItem.Visible = true;
                    _mapViewAddWallNodeMenuItem.Visible = true;
                    _mapViewAddLinkMenuItem.Visible = true;
                    return;
                }
                case Constant.CatalogueNodeLevel:
                {
                    switch (catalogueIndex)
                    {
                        case Constant.EntryNodesIndex:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddEntryNodeMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        case Constant.GuideNodesIndex:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddGuideNodeMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        case Constant.WallNodesIndex:
                        {
                            _mapViewAddMenuItem.Visible = true;
                            _mapViewAddWallNodeMenuItem.Visible = true;
                            _mapViewAddLinkMenuItem.Visible = true;
                            return;
                        }
                        case Constant.LinksIndex:
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
                case Constant.ElementNodeLevel:
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

        public MapView()
        {
            InitializeComponent();
        }

        public void SetParent(MainWindow parent)
        {
            Debug.Assert(parent != null);

            _parent = parent;
        }
    }
}
