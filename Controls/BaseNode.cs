namespace IndoorNavigator.MapEditor.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class BaseNode : UserControl
    {
        private bool _isMouseHovering;

        private bool _isDragging;

        private Point _dragStartPositon;

        private Point _dragStartCursorPosition;

        [Browsable(true)]
        [Description("Indicate the node is selected or not.")]
        [Category("Appearence")]
        [DefaultValue(false)]
        public bool Selected { get; set; }

        public BaseNode()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            if (!_isMouseHovering)
            {
                if (Selected)
                {
                    Size -= new Size(4, 4);
                    Location += new Size(2, 2);
                }
                else
                {
                    Size += new Size(4, 4);
                    Location -= new Size(2, 2);
                }
            }
            Selected = !Selected;
            base.OnClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isMouseHovering = true;
            if (!Selected)
            {
                Size += new Size(4, 4);
                Location -= new Size(2, 2);
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isMouseHovering = false;
            if (!Selected)
            {
                Size -= new Size(4, 4);
                Location += new Size(2, 2);
            }
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isDragging = true;
            _dragStartPositon = Location;
            _dragStartCursorPosition = Cursor.Position;
            base.OnMouseDown(e);
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
    }
}
