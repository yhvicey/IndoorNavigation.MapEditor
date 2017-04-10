using System.Windows.Forms;

namespace IndoorNavigator.MapEditor.Controls
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Windows;
    using Extensions;
    using Models;

    public partial class DesignerView : UserControl
    {
        private MainWindow _parent;

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            HorizontalScroll.Visible = BackgroundImage?.Size.Width > Size.Width;
            VerticalScroll.Visible = BackgroundImage?.Size.Height > Size.Height;
            base.OnBackgroundImageChanged(e);
        }

        public DesignerView()
        {
            InitializeComponent();
        }

        public void DrawFloor(Floor floor)
        {

        }

        public void DrawLink(Floor floor, int linkIndex)
        {

        }

        public void SetParent(MainWindow parent)
        {
            Debug.Assert(parent != null);
            _parent = parent;
        }

        #region Event handlers

        private void DesignToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                _designToolStrip.Items.OfType<ToolStripButton>().ForEach(item =>
                {
                    if (item != e.ClickedItem) item.Checked = false;
                    else item.Checked = !item.Checked;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion // Event handlers
    }
}
