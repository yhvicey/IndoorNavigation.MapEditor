namespace IndoorNavigator.MapEditor.Controls
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Windows;
    using Models;
    using Models.Nodes;

    public partial class MapView : TreeView
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

        #endregion // Constants

        #region Variables

        private MainWindow _parent;

        #endregion // Variables

        public MapView()
        {
            InitializeComponent();
        }

        private void OnMapViewMenuShow(int itemLevel, int catalogueIndex, object mapElement)
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
                    switch (catalogueIndex)
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

        public void SetParent(MainWindow parent)
        {
            Debug.Assert(parent != null);
            _parent = parent;
        }

        #region Event handlers

        private void MapViewAddEntryNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var wizard = new AddNodeWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
                    Type = NodeType.EntryNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                _parent.AddNode(wizard.MakeNode(), wizard.Floor);
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
                _parent.AddFloor(new Floor());
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
                var wizard = new AddNodeWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
                    Type = NodeType.GuideNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                _parent.AddNode(wizard.MakeNode(), wizard.Floor);
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
                var selectedNode = SelectedNode as MapElementTreeNode;
                if (selectedNode == null) return;
                var wizard = new AddLinkWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
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
                _parent.AddLink(wizard.MakeLink(), wizard.Floor);
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
                var wizard = new AddNodeWizard(_parent.CurrentMap)
                {
                    Floor = _parent.CurrentFloorIndex,
                    Type = NodeType.WallNode
                };
                if (wizard.ShowDialog() == DialogResult.Cancel) return;
                if (!wizard.Ready) return;
                _parent.AddNode(wizard.MakeNode(), wizard.Floor);
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
                        _parent.SelectMap();
                        break;
                    }
                    case FloorNodeLevel:
                    {
                        _parent.SelectFloor(selectedNode.Index);
                        break;
                    }
                    case CatalogueNodeLevel:
                    {
                        _parent.SelectCatalogue(selectedNode.Parent.Index, selectedNode.Index);
                        break;
                    }
                    case ElementNodeLevel:
                    {
                        var catalogueIndex = selectedNode.Parent.Index;
                        if (catalogueIndex == LinksIndex)
                            _parent.SelectLink(selectedNode.Parent.Parent.Index, selectedNode.Index);
                        else
                            _parent.SelectNode(selectedNode.Parent.Parent.Index, (NodeType)selectedNode.Parent.Index,
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
                var selectedNode = SelectedNode as MapElementTreeNode;
                if (selectedNode == null) return;
                switch (selectedNode.Level)
                {
                    case MapNodeLevel:
                    {
                        _parent.RemoveMap();
                        break;
                    }
                    case FloorNodeLevel:
                    {
                        _parent.RemoveFloor(selectedNode.Index);
                        break;
                    }
                    case CatalogueNodeLevel:
                    {
                        _parent.RemoveCatalogue(selectedNode.Parent.Index, selectedNode.Index);
                        break;
                    }
                    case ElementNodeLevel:
                    {
                        switch (selectedNode.Parent.Index)
                        {
                            case EntryNodesIndex:
                            case GuideNodesIndex:
                            case WallNodesIndex:
                            {
                                _parent.RemoveNode(selectedNode.Parent.Parent.Index, (NodeType)selectedNode.Parent.Index, selectedNode.Index);
                                break;
                            }
                            case LinksIndex:
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
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion // Event handlers
    }
}
