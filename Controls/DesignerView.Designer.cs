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
            this._designToolStrip = new System.Windows.Forms.ToolStrip();
            this._entryNodeButton = new System.Windows.Forms.ToolStripButton();
            this._guideNodeButton = new System.Windows.Forms.ToolStripButton();
            this._wallNodeButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._linkButton = new System.Windows.Forms.ToolStripButton();
            this._designToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _designToolStrip
            // 
            this._designToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._entryNodeButton,
            this._guideNodeButton,
            this._wallNodeButton,
            this._toolStripSeparator4,
            this._linkButton});
            this._designToolStrip.Location = new System.Drawing.Point(0, 0);
            this._designToolStrip.Name = "_designToolStrip";
            this._designToolStrip.Size = new System.Drawing.Size(500, 25);
            this._designToolStrip.TabIndex = 3;
            this._designToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DesignToolStripItemClicked);
            // 
            // _entryNodeButton
            // 
            this._entryNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._entryNodeButton.Image = global::IndoorNavigator.MapEditor.Properties.Resources.EntryNode;
            this._entryNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._entryNodeButton.Name = "_entryNodeButton";
            this._entryNodeButton.Size = new System.Drawing.Size(23, 22);
            this._entryNodeButton.Text = "Entry node";
            // 
            // _guideNodeButton
            // 
            this._guideNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._guideNodeButton.Image = global::IndoorNavigator.MapEditor.Properties.Resources.GuideNode;
            this._guideNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._guideNodeButton.Name = "_guideNodeButton";
            this._guideNodeButton.Size = new System.Drawing.Size(23, 22);
            this._guideNodeButton.Text = "Guide node";
            // 
            // _wallNodeButton
            // 
            this._wallNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._wallNodeButton.Image = global::IndoorNavigator.MapEditor.Properties.Resources.WallNode;
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
            // DesignerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._designToolStrip);
            this.Name = "DesignerView";
            this.Size = new System.Drawing.Size(500, 400);
            this._designToolStrip.ResumeLayout(false);
            this._designToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _designToolStrip;
        private System.Windows.Forms.ToolStripButton _entryNodeButton;
        private System.Windows.Forms.ToolStripButton _guideNodeButton;
        private System.Windows.Forms.ToolStripButton _wallNodeButton;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton _linkButton;
    }
}
