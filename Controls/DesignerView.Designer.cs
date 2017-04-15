namespace IndoorNavigator.MapEditor.Controls
{
    partial class DesignerView
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
            this._designerToolStrip = new System.Windows.Forms.ToolStrip();
            this._entryNodeButton = new System.Windows.Forms.ToolStripButton();
            this._guideNodeButton = new System.Windows.Forms.ToolStripButton();
            this._wallNodeButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._linkButton = new System.Windows.Forms.ToolStripButton();
            this._workspace = new System.Windows.Forms.Panel();
            this._canvas = new System.Windows.Forms.PictureBox();
            this._designerViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._designerViewAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._designerViewAddEntryNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._designerViewAddGuideNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._designerViewAddWallNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._designerViewRemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._designerToolStrip.SuspendLayout();
            this._workspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._canvas)).BeginInit();
            this._designerViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _designerToolStrip
            // 
            this._designerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._entryNodeButton,
            this._guideNodeButton,
            this._wallNodeButton,
            this._toolStripSeparator4,
            this._linkButton});
            this._designerToolStrip.Location = new System.Drawing.Point(0, 0);
            this._designerToolStrip.Name = "_designerToolStrip";
            this._designerToolStrip.Size = new System.Drawing.Size(500, 25);
            this._designerToolStrip.TabIndex = 3;
            this._designerToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DesignerToolStripItemClicked);
            // 
            // _entryNodeButton
            // 
            this._entryNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._entryNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._entryNodeButton.Name = "_entryNodeButton";
            this._entryNodeButton.Size = new System.Drawing.Size(23, 22);
            this._entryNodeButton.Text = "Entry node";
            // 
            // _guideNodeButton
            // 
            this._guideNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._guideNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._guideNodeButton.Name = "_guideNodeButton";
            this._guideNodeButton.Size = new System.Drawing.Size(23, 22);
            this._guideNodeButton.Text = "Guide node";
            // 
            // _wallNodeButton
            // 
            this._wallNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._wallNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._wallNodeButton.Name = "_wallNodeButton";
            this._wallNodeButton.Size = new System.Drawing.Size(23, 22);
            this._wallNodeButton.Text = "Wall node";
            // 
            // _toolStripSeparator4
            // 
            this._toolStripSeparator4.Name = "_toolStripSeparator4";
            this._toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // _linkButton
            // 
            this._linkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._linkButton.Image = global::IndoorNavigator.MapEditor.Properties.Resources.LinkIcon;
            this._linkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._linkButton.Name = "_linkButton";
            this._linkButton.Size = new System.Drawing.Size(23, 22);
            this._linkButton.Text = "Link";
            // 
            // _workspace
            // 
            this._workspace.AutoScroll = true;
            this._workspace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._workspace.Controls.Add(this._canvas);
            this._workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this._workspace.Location = new System.Drawing.Point(0, 25);
            this._workspace.Name = "_workspace";
            this._workspace.Size = new System.Drawing.Size(500, 375);
            this._workspace.TabIndex = 4;
            this._workspace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkspaceMouseMove);
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.Color.Transparent;
            this._canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._canvas.ContextMenuStrip = this._designerViewMenuStrip;
            this._canvas.ErrorImage = null;
            this._canvas.InitialImage = null;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(0, 0);
            this._canvas.TabIndex = 1;
            this._canvas.TabStop = false;
            this._canvas.SizeChanged += new System.EventHandler(this.CanvasSizeChanged);
            this._canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseClick);
            this._canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkspaceMouseMove);
            // 
            // _designerViewMenuStrip
            // 
            this._designerViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._designerViewAddMenuItem,
            this._designerViewRemoveMenuItem});
            this._designerViewMenuStrip.Name = "_designerViewMenuStrip";
            this._designerViewMenuStrip.Size = new System.Drawing.Size(118, 48);
            this._designerViewMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.DesignerViewMenuStripOpening);
            // 
            // _designerViewAddMenuItem
            // 
            this._designerViewAddMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._designerViewAddEntryNodeMenuItem,
            this._designerViewAddGuideNodeMenuItem,
            this._designerViewAddWallNodeMenuItem});
            this._designerViewAddMenuItem.Name = "_designerViewAddMenuItem";
            this._designerViewAddMenuItem.Size = new System.Drawing.Size(117, 22);
            this._designerViewAddMenuItem.Text = "Add";
            // 
            // _designerViewAddEntryNodeMenuItem
            // 
            this._designerViewAddEntryNodeMenuItem.Name = "_designerViewAddEntryNodeMenuItem";
            this._designerViewAddEntryNodeMenuItem.Size = new System.Drawing.Size(135, 22);
            this._designerViewAddEntryNodeMenuItem.Text = "Entry node";
            this._designerViewAddEntryNodeMenuItem.Click += new System.EventHandler(this.DesignerViewAddEntryNodeMenuItemClick);
            // 
            // _designerViewAddGuideNodeMenuItem
            // 
            this._designerViewAddGuideNodeMenuItem.Name = "_designerViewAddGuideNodeMenuItem";
            this._designerViewAddGuideNodeMenuItem.Size = new System.Drawing.Size(135, 22);
            this._designerViewAddGuideNodeMenuItem.Text = "Guide node";
            this._designerViewAddGuideNodeMenuItem.Click += new System.EventHandler(this.DesignerViewAddGuideNodeMenuItemClick);
            // 
            // _designerViewAddWallNodeMenuItem
            // 
            this._designerViewAddWallNodeMenuItem.Name = "_designerViewAddWallNodeMenuItem";
            this._designerViewAddWallNodeMenuItem.Size = new System.Drawing.Size(135, 22);
            this._designerViewAddWallNodeMenuItem.Text = "Wall node";
            this._designerViewAddWallNodeMenuItem.Click += new System.EventHandler(this.DesignerViewAddWallNodeMenuItemClick);
            // 
            // _designerViewRemoveMenuItem
            // 
            this._designerViewRemoveMenuItem.Name = "_designerViewRemoveMenuItem";
            this._designerViewRemoveMenuItem.Size = new System.Drawing.Size(117, 22);
            this._designerViewRemoveMenuItem.Text = "Remove";
            this._designerViewRemoveMenuItem.Click += new System.EventHandler(this.DesignerViewRemoveMenuItemClick);
            // 
            // DesignerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this._workspace);
            this.Controls.Add(this._designerToolStrip);
            this.Name = "DesignerView";
            this.Size = new System.Drawing.Size(500, 400);
            this.Load += new System.EventHandler(this.DesignerViewLoad);
            this._designerToolStrip.ResumeLayout(false);
            this._designerToolStrip.PerformLayout();
            this._workspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._canvas)).EndInit();
            this._designerViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _designerToolStrip;
        private System.Windows.Forms.ToolStripButton _entryNodeButton;
        private System.Windows.Forms.ToolStripButton _guideNodeButton;
        private System.Windows.Forms.ToolStripButton _wallNodeButton;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton _linkButton;
        private System.Windows.Forms.Panel _workspace;
        private System.Windows.Forms.PictureBox _canvas;
        private System.Windows.Forms.ContextMenuStrip _designerViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _designerViewAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _designerViewAddEntryNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _designerViewRemoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _designerViewAddGuideNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _designerViewAddWallNodeMenuItem;
    }
}
