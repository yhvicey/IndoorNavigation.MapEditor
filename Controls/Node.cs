namespace IndoorNavigator.MapEditor.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Models.Nodes;
    using Properties;

    public partial class Node : UserControl
    {
        private bool _isMouseHovering;

        private bool _isDragging;

        private Point _dragStartPositon;

        private Point _dragStartCursorPosition;

        private NodeType _type;

        [Browsable(true)]
        [Description("Indicate the node is selected or not.")]
        [Category("Appearence")]
        [DefaultValue(false)]
        public bool IsSelected { get; set; }

        [Browsable(true)]
        [Description("Indicate the node's type.")]
        [Category("Appearence")]
        [DefaultValue("WallNode")]
        public NodeType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                switch (_type)
                {
                    case NodeType.EntryNode:
                    {
                        BackgroundImage = Resources.EntryNode;
                        return;
                    }
                    case NodeType.GuideNode:
                    {
                        BackgroundImage = Resources.GuideNode;
                        return;
                    }
                    case NodeType.WallNode:
                    {
                        BackgroundImage = Resources.WallNode;
                        return;
                    }
                    default:
                    {
                        BackgroundImage = Resources.ErrorIcon;
                        return;
                    }
                }
            }
        }

        private void EnlargeSize()
        {
            Size += new Size(4, 4);
            Location -= new Size(2, 2);
        }

        private void ReduceSize()
        {
            Size -= new Size(4, 4);
            Location += new Size(2, 2);
        }

        protected override void OnClick(EventArgs e)
        {
            if (!_isMouseHovering)
            {
                if (IsSelected)
                {
                    UnselectNode();
                }
                else
                {
                    SelectNode();
                }
            }
            base.OnClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isDragging = true;
            _dragStartPositon = Location;
            _dragStartCursorPosition = Cursor.Position;
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isMouseHovering = true;
            EnlargeSize();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isMouseHovering = false;
            ReduceSize();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isDragging)
            {
                Left = _dragStartPositon.X + Cursor.Position.X - _dragStartCursorPosition.X;
                Top = _dragStartPositon.Y + Cursor.Position.Y - _dragStartCursorPosition.Y;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDragging = false;
            base.OnMouseUp(e);
        }

        public Node()
        {
            InitializeComponent();
        }

        public void SelectNode()
        {
            EnlargeSize();
            IsSelected = true;
        }

        public void UnselectNode()
        {
            ReduceSize();
            IsSelected = false;
        }
    }
}
