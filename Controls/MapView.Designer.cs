namespace IndoorNavigator.MapEditor.Controls
{
    partial class MapView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._mapViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._mapViewAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddFloorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddEntryNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddGuideNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddWallNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewRemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mapViewMenuStrip
            // 
            this._mapViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mapViewAddMenuItem,
            this._mapViewRemoveMenuItem});
            this._mapViewMenuStrip.Name = "_floorNodeContextMenuStrip";
            this._mapViewMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // _mapViewAddMenuItem
            // 
            this._mapViewAddMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mapViewAddFloorMenuItem,
            this._mapViewAddEntryNodeMenuItem,
            this._mapViewAddGuideNodeMenuItem,
            this._mapViewAddWallNodeMenuItem,
            this._mapViewAddLinkMenuItem});
            this._mapViewAddMenuItem.Name = "_mapViewAddMenuItem";
            this._mapViewAddMenuItem.Size = new System.Drawing.Size(117, 22);
            this._mapViewAddMenuItem.Text = "Add";
            // 
            // _mapViewAddFloorMenuItem
            // 
            this._mapViewAddFloorMenuItem.Name = "_mapViewAddFloorMenuItem";
            this._mapViewAddFloorMenuItem.Size = new System.Drawing.Size(135, 22);
            this._mapViewAddFloorMenuItem.Text = "Floor";
            this._mapViewAddFloorMenuItem.Click += new System.EventHandler(this.MapViewAddFloorMenuItemClick);
            // 
            // _mapViewAddEntryNodeMenuItem
            // 
            this._mapViewAddEntryNodeMenuItem.Name = "_mapViewAddEntryNodeMenuItem";
            this._mapViewAddEntryNodeMenuItem.Size = new System.Drawing.Size(135, 22);
            this._mapViewAddEntryNodeMenuItem.Text = "Entry node";
            this._mapViewAddEntryNodeMenuItem.Click += new System.EventHandler(this.MapViewAddEntryNodeMenuItemClick);
            // 
            // _mapViewAddGuideNodeMenuItem
            // 
            this._mapViewAddGuideNodeMenuItem.Name = "_mapViewAddGuideNodeMenuItem";
            this._mapViewAddGuideNodeMenuItem.Size = new System.Drawing.Size(135, 22);
            this._mapViewAddGuideNodeMenuItem.Text = "Guide node";
            this._mapViewAddGuideNodeMenuItem.Click += new System.EventHandler(this.MapViewAddGuideNodeMenuItemClick);
            // 
            // _mapViewAddWallNodeMenuItem
            // 
            this._mapViewAddWallNodeMenuItem.Name = "_mapViewAddWallNodeMenuItem";
            this._mapViewAddWallNodeMenuItem.Size = new System.Drawing.Size(135, 22);
            this._mapViewAddWallNodeMenuItem.Text = "Wall node";
            this._mapViewAddWallNodeMenuItem.Click += new System.EventHandler(this.MapViewAddWallNodeMenuItemClick);
            // 
            // _mapViewAddLinkMenuItem
            // 
            this._mapViewAddLinkMenuItem.Name = "_mapViewAddLinkMenuItem";
            this._mapViewAddLinkMenuItem.Size = new System.Drawing.Size(135, 22);
            this._mapViewAddLinkMenuItem.Text = "Link";
            this._mapViewAddLinkMenuItem.Click += new System.EventHandler(this.MapViewAddLinkMenuItemClick);
            // 
            // _mapViewRemoveMenuItem
            // 
            this._mapViewRemoveMenuItem.Name = "_mapViewRemoveMenuItem";
            this._mapViewRemoveMenuItem.Size = new System.Drawing.Size(117, 22);
            this._mapViewRemoveMenuItem.Text = "Remove";
            this._mapViewRemoveMenuItem.Click += new System.EventHandler(this.MapViewRemoveMenuItemClick);
            // 
            // MapView
            // 
            this.ContextMenuStrip = this._mapViewMenuStrip;
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MapViewNodeMouseClick);
            this._mapViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip _mapViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddFloorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddEntryNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddGuideNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddWallNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddLinkMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewRemoveMenuItem;
    }
}
