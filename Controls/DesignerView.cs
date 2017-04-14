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
            EntryNode,
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
                    case EntryNode entryNode:
                    {
                        _parent.DrawEntryNode(entryNode, Highlighted);
                        return;
                    }
                    case GuideNode guideNode:
                    {
                        _parent.DrawGuideNode(guideNode, Highlighted);
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

        private readonly Pen _borderPen = new Pen(Color.Black, 1)
        {
            DashStyle = DashStyle.Dot
        };

        private readonly SolidBrush _entryNodeBrush = new SolidBrush(Constant.EntryNodeColor);

        private Graphics _graphics;

        private readonly SolidBrush _guideNodeBrush = new SolidBrush(Constant.GuideNodeColor);

        private readonly Pen _linkPen = new Pen(Constant.LinkColor);

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

        public Size MapSize => new Size(CanvasSize.Width - Constant.MapPadding * 2, CanvasSize.Height - Constant.MapPadding * 2);

        public List<RenderTarget> Targets { get; } = new List<RenderTarget>();

        #endregion // Properties

        #region Event handlers

        private void CanvasMouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (CurrentFloorIndex == Constant.NoSelectedFloor) return;

                OnClick(e.X, e.Y);
                switch (_selection)
                {
                    case ToolStripSelection.EntryNode:
                    {
                        if (_selectedTarget != null) return;
                        _parent.AddNode(new EntryNode(e.X - Constant.MapPadding, e.Y - Constant.MapPadding), CurrentFloorIndex);
                        return;
                    }
                    case ToolStripSelection.GuideNode:
                    {
                        if (_selectedTarget != null) return;
                        _parent.AddNode(new GuideNode(e.X - Constant.MapPadding, e.Y - Constant.MapPadding), CurrentFloorIndex);
                        return;
                    }
                    case ToolStripSelection.WallNode:
                    {
                        if (_selectedTarget != null) return;
                        _parent.AddNode(new WallNode(e.X - Constant.MapPadding, e.Y - Constant.MapPadding), CurrentFloorIndex);
                        return;
                    }
                    case ToolStripSelection.Link:
                    {
                        if (_selectedTarget == null || _prevSelectedTarget == null)
                        {
                            _prevSelectedTarget = _selectedTarget;
                            return;
                        }
                        var startNode = _prevSelectedTarget.MapModel as NodeBase;
                        if (startNode == null) return;
                        var endNode = _selectedTarget.MapModel as NodeBase;
                        if (endNode == null) return;
                        var floor = _parent.CurrentMap.Floors[CurrentFloorIndex];
                        _parent.AddLink(
                            new Link(startNode.Type, floor.GetNodeIndex(startNode), endNode.Type,
                                floor.GetNodeIndex(endNode)), CurrentFloorIndex);
                        _prevSelectedTarget = null;
                        SelectTarget(null);
                        return;
                    }
                    default:
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void DesignToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                SelectTarget(null);
                _designToolStrip.Items.OfType<ToolStripButton>().ForEach(item =>
                {
                    if (item != e.ClickedItem) item.Checked = false;
                    else
                    {
                        item.Checked = !item.Checked;
                        if (item.Checked && e.ClickedItem.Name == _entryNodeButton.Name) _selection = ToolStripSelection.EntryNode;
                        else if (item.Checked && e.ClickedItem.Name == _guideNodeButton.Name) _selection = ToolStripSelection.GuideNode;
                        else if (item.Checked && e.ClickedItem.Name == _wallNodeButton.Name) _selection = ToolStripSelection.WallNode;
                        else if (item.Checked && e.ClickedItem.Name == _linkButton.Name) _selection = ToolStripSelection.Link;
                        else _selection = ToolStripSelection.None;
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DesignerViewLoad(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void WorkspaceMouseMove(object sender, MouseEventArgs e)
        {
            _parent.UpdateCursorLocation(e.X, e.Y);
        }

        #endregion // Event handlers

        private void DrawEntryNode(EntryNode node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            _graphics?.FillEllipse(_entryNodeBrush, GetNodeRectangle(node, highlighted));
        }

        private void DrawGuideNode(GuideNode node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            _graphics?.FillEllipse(_guideNodeBrush, GetNodeRectangle(node, highlighted));
        }

        private void DrawMapBorder()
        {
            _graphics.DrawRectangle(_borderPen, new Rectangle(Constant.MapPadding, Constant.MapPadding, _canvas.Size.Width - Constant.MapPadding * 2, _canvas.Size.Height - Constant.MapPadding * 2));
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
                Targets[CurrentFloorIndex].Targets[(int)link.StartType].Targets[link.StartIndex].MapModel as NodeBase;
            Debug.Assert(startNode != null);
            var endNode =
                Targets[CurrentFloorIndex].Targets[(int)link.EndType].Targets[link.EndIndex].MapModel as NodeBase;
            Debug.Assert(endNode != null);
            _graphics?.DrawLine(_linkPen, (int)startNode.X + Constant.MapPadding,
                (int)startNode.Y + Constant.MapPadding, (int)endNode.X + Constant.MapPadding,
                (int)endNode.Y + Constant.MapPadding);
        }

        private Rectangle GetNodeRectangle(NodeBase node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            var halfSideLength = highlighted ? Constant.HighlightedNodeHalfSideLength : Constant.NodeHalfSideLength;
            return new Rectangle((int)node.X - halfSideLength + Constant.MapPadding,
                (int)node.Y - halfSideLength + Constant.MapPadding, halfSideLength * 2, halfSideLength * 2);
        }

        private bool InsideNodeArea(RenderTarget nodeTarget, int x, int y)
        {
            var node = nodeTarget.MapModel as NodeBase;
            Debug.Assert(node != null);

            var rect = GetNodeRectangle(node);
            return x >= rect.X && x <= rect.X + rect.Width && y >= rect.Y && y <= rect.Y + rect.Height;
        }

        private void OnClick(int x, int y)
        {
            if (CurrentFloorIndex == Constant.NoSelectedFloor) return;

            var floorTarget = Targets[CurrentFloorIndex];
            var floor = floorTarget.MapModel as Floor;
            Debug.Assert(floor != null);
            SelectTarget(
                floorTarget.Targets.SelectMany(
                        catalogueTarget =>
                            catalogueTarget.Targets.Where(
                                elementTarget => elementTarget.MapModel is NodeBase && InsideNodeArea(elementTarget, x, y)))
                    .FirstOrDefault());
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
                DrawMapBorder();
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
            floor.EntryNodes.ForEach(entryNode =>
            {
                if (entryNode.X > width) width = entryNode.X;
                if (entryNode.Y > height) height = entryNode.Y;
            });
            floor.GuideNodes.ForEach(guideNode =>
            {
                if (guideNode.X > width) width = guideNode.X;
                if (guideNode.Y > height) height = guideNode.Y;
            });
            floor.WallNodes.ForEach(wallNode =>
            {
                if (wallNode.X > width) width = wallNode.X;
                if (wallNode.Y > height) height = wallNode.Y;
            });
            return new Size((int)width + Constant.MapPadding * 2, (int)height + Constant.MapPadding * 2);
        }

        public void SelectTarget(RenderTarget target, bool highlight = true)
        {
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
