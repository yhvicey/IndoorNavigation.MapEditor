namespace IndoorNavigator.MapEditor.Controls
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Windows;
    using Extensions;
    using Models;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Models.Nodes;
    using Share;

    public partial class DesignerView : UserControl
    {
        #region Inner classes

        private enum ToolStripSelection
        {
            None,
            GuideNode,
            WallNode,
            Link
        }

        public class RenderTarget
        {
            private readonly DesignerView _parent;

            public IMapModel MapModel { get; }

            public List<RenderTarget> Targets { get; } = new List<RenderTarget>();

            public bool Highlighted { get; private set; }

            public RenderTarget(DesignerView parent, IMapModel mapModel = null, IEnumerable<IMapModel> childItems = null)
            {
                Debug.Assert(parent != null);

                _parent = parent;
                MapModel = mapModel;
                childItems?.ForEach(item => Targets.Add(new RenderTarget(parent, item)));
            }

            public void Highlight()
            {
                Highlighted = true;
                Targets.ForEach(target => target.Highlight());
            }

            public void Render()
            {
                switch (MapModel)
                {
                    case GuideNode entryNode:
                    {
                        _parent.DrawEntryNode(entryNode, Highlighted);
                        return;
                    }
                    case WallNode wallNode:
                    {
                        _parent.DrawWallNode(wallNode, Highlighted);
                        return;
                    }
                    case Link link:
                    {
                        _parent.DrawLink(link, Highlighted);
                        return;
                    }
                    default:
                    {
                        Targets.ForEach(target => target.Render());
                        return;
                    }
                }
            }

            public void Unhighlight()
            {
                Highlighted = false;
                Targets.ForEach(target => target.Unhighlight());
            }
        }

        #endregion // Inner classes

        #region Variables

        private Point _clickLocation;

        private readonly SolidBrush _entryNodeBrush = new SolidBrush(Constant.EntryNodeColor);

        private Graphics _graphics;

        private bool _isPressingLeftButton;

        private readonly Pen _linkPen = new Pen(Constant.LinkColor)
        {
            DashStyle = DashStyle.Dot
        };

        private MainWindow _parent;

        private RenderTarget _prevSelectedTarget;

        private RenderTarget _selectedTarget;

        private ToolStripSelection _selection = ToolStripSelection.None;

        private readonly SolidBrush _wallNodeBrush = new SolidBrush(Constant.WallNodeColor);

        #endregion // Variables

        #region Properties

        public Image Background
        {
            get { return _canvas.BackgroundImage; }
            set { _canvas.BackgroundImage = value; }
        }

        public int CurrentFloorIndex => _parent?.CurrentFloorIndex ?? Constant.NoSelectedFloor;

        public Size CanvasSize
        {
            get { return _canvas.Size; }
            set { _canvas.Size = value; }
        }

        public List<RenderTarget> Targets { get; } = new List<RenderTarget>();

        #endregion // Properties

        #region Event handlers

        private void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (CurrentFloorIndex == Constant.NoSelectedFloor) return;

                _clickLocation.X = e.X;
                _clickLocation.Y = e.Y;

                var floorTarget = Targets[CurrentFloorIndex];
                var floor = floorTarget.MapModel as Floor;
                Debug.Assert(floor != null);
                var target =
                    floorTarget.Targets.SelectMany(
                            catalogueTarget =>
                                catalogueTarget.Targets.Where(
                                    elementTarget =>
                                        elementTarget.MapModel is NodeBase && InsideNodeArea(elementTarget, e.X, e.Y)))
                        .FirstOrDefault();
                SelectTarget(target);

                switch (e.Button)
                {
                    case MouseButtons.Left:
                    {
                        OnCanvasMouseDown(target, e);
                        return;
                    }
                    case MouseButtons.Right:
                    {
                        OnDesignerViewMenuShow();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                WorkspaceMouseMove(sender, e);
                if (!_isPressingLeftButton || !(_selectedTarget?.MapModel is NodeBase node)) return;
                node.X = e.X;
                node.Y = e.Y;
                Flush();
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            _isPressingLeftButton = false;
        }

        private void CanvasSizeChanged(object sender, EventArgs e)
        {
            try
            {
                var image = _canvas.Image;
                _canvas.Image = null;
                image?.Dispose();

                if (CurrentFloorIndex == Constant.NoSelectedFloor) return;

                image = new Bitmap(CanvasSize.Width, CanvasSize.Height);
                _graphics = Graphics.FromImage(image);
                _graphics.Clear(Color.Transparent);
                _canvas.Image = image;
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void DesignerToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                SelectTarget(null);
                _designerToolStrip.Items.OfType<ToolStripButton>().ForEach(item =>
                {
                    if (item != e.ClickedItem) item.Checked = false;
                    else
                    {
                        item.Checked = !item.Checked;
                        if (item.Checked && e.ClickedItem.Name == _guideNodeButton.Name) _selection = ToolStripSelection.GuideNode;
                        else if (item.Checked && e.ClickedItem.Name == _wallNodeButton.Name) _selection = ToolStripSelection.WallNode;
                        else if (item.Checked && e.ClickedItem.Name == _linkButton.Name) _selection = ToolStripSelection.Link;
                        else _selection = ToolStripSelection.None;
                    }
                });
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void DesignerViewAddGuideNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTarget != null) return;
                _parent.AddNode(new GuideNode(_clickLocation.X, _clickLocation.Y), CurrentFloorIndex);
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void DesignerViewAddWallNodeMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTarget != null) return;
                _parent.AddNode(new WallNode(_clickLocation.X, _clickLocation.Y), CurrentFloorIndex);
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void DesignerViewMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClearSelection();
            var location = _canvas.PointToClient(Cursor.Position);
            CanvasMouseDown(sender, new MouseEventArgs(MouseButtons.Right, 1, location.X, location.Y, 0));
        }

        private void DesignerViewLoad(object sender, EventArgs e)
        {
            try
            {
                const int sideLength = Constant.NodeHalfSideLength * 2;

                var entryNodeImage = new Bitmap(sideLength, sideLength);
                Graphics.FromImage(entryNodeImage).FillEllipse(_entryNodeBrush, 0, 0, sideLength, sideLength);
                _guideNodeButton.Image = entryNodeImage;

                var wallNodeImage = new Bitmap(sideLength, sideLength);
                Graphics.FromImage(wallNodeImage).FillEllipse(_wallNodeBrush, 0, 0, sideLength, sideLength);
                _wallNodeButton.Image = wallNodeImage;
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void DesignerViewRemoveMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var node = _selectedTarget.MapModel as NodeBase;
                if (node == null) return;
                var floor = _parent.CurrentMap.Floors[CurrentFloorIndex];
                var nodeIndex = floor.GetNodeIndex(node);
                _parent.RemoveNode(CurrentFloorIndex, node.Type, nodeIndex);
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show(this, ex);
            }
        }

        private void WorkspaceMouseMove(object sender, MouseEventArgs e)
        {
            _parent.UpdateCursorLocation(e.X, e.Y);
        }

        #endregion // Event handlers

        private void ClearSelection()
        {
            _designerToolStrip.Items.OfType<ToolStripButton>().ForEach(button => button.Checked = false);
            _selection = ToolStripSelection.None;
        }

        private void DrawEntryNode(GuideNode node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            _graphics?.FillEllipse(_entryNodeBrush, GetNodeRectangle(node, highlighted));
        }

        private void DrawWallNode(WallNode node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            _graphics?.FillEllipse(_wallNodeBrush, GetNodeRectangle(node, highlighted));
        }

        private void DrawLink(Link link, bool highlighted = false)
        {
            Debug.Assert(link != null);

            var linkWidth = highlighted ? Constant.HighlightedLinkWidth : Constant.LinkWidth;
            _linkPen.Width = linkWidth;
            var startNode =
                Targets[CurrentFloorIndex].Targets[(int)link.Type].Targets[link.StartIndex].MapModel as NodeBase;
            Debug.Assert(startNode != null);
            var endNode =
                Targets[CurrentFloorIndex].Targets[(int)link.Type].Targets[link.EndIndex].MapModel as NodeBase;
            Debug.Assert(endNode != null);
            _graphics?.DrawLine(_linkPen, startNode.X, startNode.Y, endNode.X, endNode.Y);
        }

        private Rectangle GetNodeRectangle(NodeBase node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            var halfSideLength = highlighted ? Constant.HighlightedNodeHalfSideLength : Constant.NodeHalfSideLength;
            return new Rectangle(node.X - halfSideLength, node.Y - halfSideLength, halfSideLength * 2,
                halfSideLength * 2);
        }

        private bool InsideNodeArea(RenderTarget nodeTarget, int x, int y)
        {
            var node = nodeTarget.MapModel as NodeBase;
            Debug.Assert(node != null);

            var rect = GetNodeRectangle(node);
            return x >= rect.X && x <= rect.X + rect.Width && y >= rect.Y && y <= rect.Y + rect.Height;
        }

        private void OnCanvasMouseDown(RenderTarget target, MouseEventArgs e)
        {
            if (CurrentFloorIndex == Constant.NoSelectedFloor) return;

            _isPressingLeftButton = _prevSelectedTarget != null;

            switch (_selection)
            {
                case ToolStripSelection.GuideNode:
                {
                    if (_selectedTarget == null) _parent.AddNode(new GuideNode(e.X, e.Y), CurrentFloorIndex);
                    return;
                }
                case ToolStripSelection.WallNode:
                {
                    if (_selectedTarget == null) _parent.AddNode(new WallNode(e.X, e.Y), CurrentFloorIndex);
                    return;
                }
                case ToolStripSelection.Link:
                {
                    if (_selectedTarget == null || _prevSelectedTarget == null) return;
                    var startNode = _prevSelectedTarget.MapModel as NodeBase;
                    if (startNode == null) return;
                    var endNode = _selectedTarget.MapModel as NodeBase;
                    if (endNode == null) return;
                    var floor = Targets[CurrentFloorIndex].MapModel as Floor;
                    Debug.Assert(floor != null);
                    _parent.AddLink(
                        new Link(startNode.Type, floor.GetNodeIndex(startNode), floor.GetNodeIndex(endNode)),
                        CurrentFloorIndex);
                    SelectTarget(null);
                    return;
                }
                default:
                {
                    var node = target?.MapModel as NodeBase;
                    if (node != null)
                        _parent.SelectNode(CurrentFloorIndex, node.Type,
                            _parent.CurrentMap.Floors[CurrentFloorIndex].GetNodeIndex(node));
                    return;
                }
            }
        }

        private void OnDesignerViewMenuShow()
        {
            if (_selectedTarget != null)
            {
                _designerViewAddMenuItem.Visible = false;
                _designerViewRemoveMenuItem.Visible = true;
            }
            else
            {
                _designerViewAddMenuItem.Visible = true;
                _designerViewRemoveMenuItem.Visible = false;
            }
        }

        public DesignerView()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _graphics?.Clear(Color.Transparent);
        }

        public void Flush()
        {
            Clear();

            if (CurrentFloorIndex != Constant.NoSelectedFloor)
            {
                Targets[CurrentFloorIndex].Render();
            }

            _canvas.Invalidate();
        }

        public Size GetMininalDisplaySize(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            var floor = Targets[floorIndex].MapModel as Floor;
            Debug.Assert(floor != null);
            var width = 0d;
            var height = 0d;
            floor.GuideNodes.ForEach(entryNode =>
            {
                if (entryNode.X > width) width = entryNode.X;
                if (entryNode.Y > height) height = entryNode.Y;
            });
            floor.WallNodes.ForEach(wallNode =>
            {
                if (wallNode.X > width) width = wallNode.X;
                if (wallNode.Y > height) height = wallNode.Y;
            });
            return new Size((int)width + Constant.NodeHalfSideLength * 2,
                (int)height + Constant.NodeHalfSideLength * 2);
        }

        public void SelectTarget(RenderTarget target, bool highlight = true)
        {
            _prevSelectedTarget = _selectedTarget;
            _selectedTarget?.Unhighlight();
            _selectedTarget = target;
            if (highlight) _selectedTarget?.Highlight();
            Flush();
        }

        public void SetParent(MainWindow parent)
        {
            Debug.Assert(parent != null);

            _parent = parent;
        }

        public void Unhighlight()
        {
            if (CurrentFloorIndex == Constant.NoSelectedFloor) return;

            Targets[CurrentFloorIndex].Unhighlight();
        }
    }
}
