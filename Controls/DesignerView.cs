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

        private Graphics _graphics;

        private MainWindow _parent;

        private ToolStripSelection _selection = ToolStripSelection.None;

        #endregion // Variables

        #region Properties

        public int CurrentFloorIndex => _parent.CurrentFloorIndex;

        public Size MapSize => _background.Size;

        public List<RenderTarget> Targets { get; } = new List<RenderTarget>();

        #endregion // Properties

        #region Event handlers

        private void CanvasMouseClick(object sender, MouseEventArgs e)
        {
            switch (_selection)
            {
                case ToolStripSelection.EntryNode:
                {
                    return;
                }
                case ToolStripSelection.GuideNode:
                {
                    return;
                }
                case ToolStripSelection.WallNode:
                {
                    return;
                }
                case ToolStripSelection.Link:
                {
                    return;
                }
                default:
                {
                    return;
                }
            }
        }

        private void CanvasSizeChanged(object sender, EventArgs e)
        {
            var image = _canvas.Image;
            _canvas.Image = null;
            image?.Dispose();
            if (CurrentFloorIndex == Constant.NoSelectedFloor) return;
            image = new Bitmap(MapSize.Width, MapSize.Height);
            _graphics = Graphics.FromImage(image);
            _graphics.Clear(Color.Transparent);
            _canvas.Image = image;
        }

        private void DesignToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                _designToolStrip.Items.OfType<ToolStripButton>().ForEach(item =>
                {
                    if (item != e.ClickedItem) item.Checked = false;
                    else
                    {
                        item.Checked = !item.Checked;
                        if (e.ClickedItem.Name == _entryNodeButton.Name) _selection = ToolStripSelection.EntryNode;
                        else if (e.ClickedItem.Name == _guideNodeButton.Name) _selection = ToolStripSelection.GuideNode;
                        else if (e.ClickedItem.Name == _wallNodeButton.Name) _selection = ToolStripSelection.WallNode;
                        else if (e.ClickedItem.Name == _linkButton.Name) _selection = ToolStripSelection.Link;
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

        }

        #endregion // Event handlers

        #region View functions

        #endregion // View functions

        private void DrawEntryNode(EntryNode node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            _graphics.DrawEllipse(new Pen(Constant.EntryNodeColor, 2), GetNodeRectangle(node, highlighted));
        }

        private void DrawGuideNode(GuideNode node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            _graphics.DrawEllipse(new Pen(Constant.GuideNodeColor, 2), GetNodeRectangle(node, highlighted));
        }

        private void DrawWallNode(WallNode node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            _graphics.DrawEllipse(new Pen(Constant.WallNodeColor, 2), GetNodeRectangle(node, highlighted));
        }

        private void DrawLink(Link link, bool highlighted = false)
        {
            Debug.Assert(link != null);

            var linkWidth = highlighted ? 4 : 2;
            var startNode =
                Targets[CurrentFloorIndex].Targets[(int)link.StartType].Targets[link.StartIndex].MapModel as NodeBase;
            Debug.Assert(startNode != null);
            var endNode =
                Targets[CurrentFloorIndex].Targets[(int)link.EndType].Targets[link.EndIndex].MapModel as NodeBase;
            Debug.Assert(endNode != null);
            _graphics.DrawLine(new Pen(Color.Gray, linkWidth), (int)startNode.X, (int)startNode.Y, (int)endNode.X,
                (int)endNode.Y);
        }

        private Point GetLocation(NodeBase node)
        {
            Debug.Assert(node != null);

            return new Point((int)node.X, (int)node.Y);
        }

        private Rectangle GetNodeRectangle(NodeBase node, bool highlighted = false)
        {
            Debug.Assert(node != null);

            var halfSideLength = highlighted ? 7 : 5;
            return new Rectangle((int)node.X - halfSideLength, (int)node.Y - halfSideLength, halfSideLength * 2, halfSideLength * 2);
        }

        public DesignerView()
        {
            InitializeComponent();
        }

        public void Flush()
        {
            if (CurrentFloorIndex == Constant.NoSelectedFloor) return;
            UpdateFloorSize();
            _graphics.Clear(Color.Transparent);
            Targets[CurrentFloorIndex].Render();
            _canvas.Invalidate();
        }

        public void LoadBackground(Image background)
        {
            Debug.Assert(background != null);

            _background.BackgroundImage = background;
            _background.Size = background.Size;
        }

        public void RemoveBackground()
        {
            _background.BackgroundImage = null;
            UpdateFloorSize();
        }

        public void SetParent(MainWindow parent)
        {
            Debug.Assert(parent != null);

            _parent = parent;
        }

        public void Unhighlight()
        {
            Targets.ForEach(target => target.Unhighlight());
        }

        public void UpdateFloorSize()
        {
            if (CurrentFloorIndex == Constant.NoSelectedFloor)
            {
                _background.Size = new Size();
                return;
            }
            if (_background.BackgroundImage != null) return;
            var floor = Targets[CurrentFloorIndex].MapModel as Floor;
            Debug.Assert(floor != null);
            var width = 0;
            var height = 0;
            floor.EntryNodes.ForEach(entryNode =>
            {
                var location = GetLocation(entryNode);
                if (entryNode.X > width) width = location.X;
                if (entryNode.Y > height) height = location.Y;
            });
            floor.GuideNodes.ForEach(guideNode =>
            {
                var location = GetLocation(guideNode);
                if (guideNode.X > width) width = location.X;
                if (guideNode.Y > height) height = location.Y;
            });
            floor.WallNodes.ForEach(wallNode =>
            {
                var location = GetLocation(wallNode);
                if (wallNode.X > width) width = location.X;
                if (wallNode.Y > height) height = location.Y;
            });
            _background.Size = new Size(width, height);
        }
    }
}
