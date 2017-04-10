namespace IndoorNavigator.MapEditor.Windows
{
    using Models.Nodes;

    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newFloorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._layerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._loadBackgroundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._removeBackgroundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setScaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._messageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolStripPlaceholder = new System.Windows.Forms.ToolStripStatusLabel();
            this._mapStatusLable = new System.Windows.Forms.ToolStripStatusLabel();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._panel = new System.Windows.Forms.Panel();
            this.nodeControl1 = new IndoorNavigator.MapEditor.Controls.Node();
            this._designer = new IndoorNavigator.MapEditor.Controls.Designer();
            this._designToolStrip = new System.Windows.Forms.ToolStrip();
            this._entryNodeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._guideNodeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._wallNodeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._linkToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._rightPanel = new System.Windows.Forms.SplitContainer();
            this._mapView = new System.Windows.Forms.TreeView();
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._mapViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._mapViewAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddFloorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddEntryNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddGuideNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddWallNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewAddLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapViewRemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this._tableLayoutPanel.SuspendLayout();
            this._panel.SuspendLayout();
            this._designToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._rightPanel)).BeginInit();
            this._rightPanel.Panel1.SuspendLayout();
            this._rightPanel.Panel2.SuspendLayout();
            this._rightPanel.SuspendLayout();
            this._mapViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenuItem,
            this._layerMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1008, 24);
            this._menuStrip.TabIndex = 1;
            // 
            // _fileMenuItem
            // 
            this._fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newMenuItem,
            this._openMenuItem,
            this._toolStripSeparator1,
            this._closeMenuItem,
            this._toolStripSeparator2,
            this._saveMenuItem,
            this._toolStripSeparator3,
            this._exitMenuItem});
            this._fileMenuItem.Name = "_fileMenuItem";
            this._fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileMenuItem.Text = "File";
            // 
            // _newMenuItem
            // 
            this._newMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newMapMenuItem,
            this._newFloorMenuItem,
            this._newNodeMenuItem,
            this._newLinkMenuItem});
            this._newMenuItem.Name = "_newMenuItem";
            this._newMenuItem.Size = new System.Drawing.Size(138, 22);
            this._newMenuItem.Text = "New";
            // 
            // _newMapMenuItem
            // 
            this._newMapMenuItem.Name = "_newMapMenuItem";
            this._newMapMenuItem.Size = new System.Drawing.Size(103, 22);
            this._newMapMenuItem.Text = "Map";
            this._newMapMenuItem.Click += new System.EventHandler(this.NewMapMenuItemClick);
            // 
            // _newFloorMenuItem
            // 
            this._newFloorMenuItem.Name = "_newFloorMenuItem";
            this._newFloorMenuItem.Size = new System.Drawing.Size(103, 22);
            this._newFloorMenuItem.Text = "Floor";
            this._newFloorMenuItem.Click += new System.EventHandler(this.NewFloorMenuItemClick);
            // 
            // _newNodeMenuItem
            // 
            this._newNodeMenuItem.Name = "_newNodeMenuItem";
            this._newNodeMenuItem.Size = new System.Drawing.Size(103, 22);
            this._newNodeMenuItem.Text = "Node";
            this._newNodeMenuItem.Click += new System.EventHandler(this.NewNodeMenuItemClick);
            // 
            // _newLinkMenuItem
            // 
            this._newLinkMenuItem.Name = "_newLinkMenuItem";
            this._newLinkMenuItem.Size = new System.Drawing.Size(103, 22);
            this._newLinkMenuItem.Text = "Link";
            this._newLinkMenuItem.Click += new System.EventHandler(this.NewLinkMenuItemClick);
            // 
            // _openMenuItem
            // 
            this._openMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openMapMenuItem});
            this._openMenuItem.Name = "_openMenuItem";
            this._openMenuItem.Size = new System.Drawing.Size(138, 22);
            this._openMenuItem.Text = "Open";
            // 
            // _openMapMenuItem
            // 
            this._openMapMenuItem.Name = "_openMapMenuItem";
            this._openMapMenuItem.Size = new System.Drawing.Size(98, 22);
            this._openMapMenuItem.Text = "Map";
            this._openMapMenuItem.Click += new System.EventHandler(this.OpenMapMenuItemClick);
            // 
            // _toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "_toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // _closeMenuItem
            // 
            this._closeMenuItem.Name = "_closeMenuItem";
            this._closeMenuItem.Size = new System.Drawing.Size(138, 22);
            this._closeMenuItem.Text = "Close";
            this._closeMenuItem.Click += new System.EventHandler(this.CloseMenuItemClick);
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // _saveMenuItem
            // 
            this._saveMenuItem.Name = "_saveMenuItem";
            this._saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._saveMenuItem.Size = new System.Drawing.Size(138, 22);
            this._saveMenuItem.Text = "Save";
            this._saveMenuItem.Click += new System.EventHandler(this.SaveMenuItemClick);
            // 
            // _toolStripSeparator3
            // 
            this._toolStripSeparator3.Name = "_toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size(135, 6);
            // 
            // _exitMenuItem
            // 
            this._exitMenuItem.Name = "_exitMenuItem";
            this._exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._exitMenuItem.Size = new System.Drawing.Size(138, 22);
            this._exitMenuItem.Text = "Exit";
            this._exitMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
            // 
            // _layerMenuItem
            // 
            this._layerMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._loadBackgroundMenuItem,
            this._removeBackgroundMenuItem,
            this._setScaleMenuItem});
            this._layerMenuItem.Name = "_layerMenuItem";
            this._layerMenuItem.Size = new System.Drawing.Size(47, 20);
            this._layerMenuItem.Text = "Layer";
            // 
            // _loadBackgroundMenuItem
            // 
            this._loadBackgroundMenuItem.Name = "_loadBackgroundMenuItem";
            this._loadBackgroundMenuItem.Size = new System.Drawing.Size(184, 22);
            this._loadBackgroundMenuItem.Text = "Load background";
            this._loadBackgroundMenuItem.Click += new System.EventHandler(this.LoadBackgroundMenuItemClick);
            // 
            // _removeBackgroundMenuItem
            // 
            this._removeBackgroundMenuItem.Name = "_removeBackgroundMenuItem";
            this._removeBackgroundMenuItem.Size = new System.Drawing.Size(184, 22);
            this._removeBackgroundMenuItem.Text = "Remove background";
            this._removeBackgroundMenuItem.Click += new System.EventHandler(this.RemoveBackgroundMenuItemClick);
            // 
            // _setScaleMenuItem
            // 
            this._setScaleMenuItem.Name = "_setScaleMenuItem";
            this._setScaleMenuItem.Size = new System.Drawing.Size(184, 22);
            this._setScaleMenuItem.Text = "Set scale";
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._messageStatusLabel,
            this._toolStripPlaceholder,
            this._mapStatusLable});
            this._statusStrip.Location = new System.Drawing.Point(0, 707);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(1008, 22);
            this._statusStrip.TabIndex = 3;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _messageStatusLabel
            // 
            this._messageStatusLabel.Name = "_messageStatusLabel";
            this._messageStatusLabel.Size = new System.Drawing.Size(39, 17);
            this._messageStatusLabel.Text = "Ready";
            // 
            // _toolStripPlaceholder
            // 
            this._toolStripPlaceholder.Name = "_toolStripPlaceholder";
            this._toolStripPlaceholder.Size = new System.Drawing.Size(887, 17);
            this._toolStripPlaceholder.Spring = true;
            // 
            // _mapStatusLable
            // 
            this._mapStatusLable.Name = "_mapStatusLable";
            this._mapStatusLable.Size = new System.Drawing.Size(67, 17);
            this._mapStatusLable.Text = "Map: Floor:";
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this._tableLayoutPanel.Controls.Add(this._panel, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._rightPanel, 1, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 1;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 683F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(1008, 683);
            this._tableLayoutPanel.TabIndex = 4;
            // 
            // _panel
            // 
            this._panel.Controls.Add(this.nodeControl1);
            this._panel.Controls.Add(this._designer);
            this._panel.Controls.Add(this._designToolStrip);
            this._panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel.Location = new System.Drawing.Point(3, 3);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(702, 677);
            this._panel.TabIndex = 1;
            // 
            // nodeControl1
            // 
            this.nodeControl1.BackColor = System.Drawing.Color.Transparent;
            this.nodeControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nodeControl1.BackgroundImage")));
            this.nodeControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nodeControl1.Location = new System.Drawing.Point(332, 211);
            this.nodeControl1.MaximumSize = new System.Drawing.Size(14, 14);
            this.nodeControl1.MinimumSize = new System.Drawing.Size(10, 10);
            this.nodeControl1.Name = "nodeControl1";
            this.nodeControl1.Size = new System.Drawing.Size(10, 10);
            this.nodeControl1.TabIndex = 4;
            this.nodeControl1.Type = IndoorNavigator.MapEditor.Models.Nodes.NodeType.WallNode;
            // 
            // _designer
            // 
            this._designer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._designer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._designer.Location = new System.Drawing.Point(0, 25);
            this._designer.Name = "_designer";
            this._designer.Size = new System.Drawing.Size(702, 652);
            this._designer.TabIndex = 3;
            // 
            // _designToolStrip
            // 
            this._designToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._entryNodeToolStripButton,
            this._guideNodeToolStripButton,
            this._wallNodeToolStripButton,
            this._toolStripSeparator4,
            this._linkToolStripButton});
            this._designToolStrip.Location = new System.Drawing.Point(0, 0);
            this._designToolStrip.Name = "_designToolStrip";
            this._designToolStrip.Size = new System.Drawing.Size(702, 25);
            this._designToolStrip.TabIndex = 2;
            this._designToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DesignToolStripItemClicked);
            // 
            // _entryNodeToolStripButton
            // 
            this._entryNodeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._entryNodeToolStripButton.Image = global::IndoorNavigator.MapEditor.Properties.Resources.EntryNode;
            this._entryNodeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._entryNodeToolStripButton.Name = "_entryNodeToolStripButton";
            this._entryNodeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._entryNodeToolStripButton.Text = "Entry node";
            // 
            // _guideNodeToolStripButton
            // 
            this._guideNodeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._guideNodeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_guideNodeToolStripButton.Image")));
            this._guideNodeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._guideNodeToolStripButton.Name = "_guideNodeToolStripButton";
            this._guideNodeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._guideNodeToolStripButton.Text = "Guide node";
            // 
            // _wallNodeToolStripButton
            // 
            this._wallNodeToolStripButton.CheckOnClick = true;
            this._wallNodeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._wallNodeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_wallNodeToolStripButton.Image")));
            this._wallNodeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._wallNodeToolStripButton.Name = "_wallNodeToolStripButton";
            this._wallNodeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._wallNodeToolStripButton.Text = "Wall node";
            // 
            // _toolStripSeparator4
            // 
            this._toolStripSeparator4.Name = "_toolStripSeparator4";
            this._toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // _linkToolStripButton
            // 
            this._linkToolStripButton.CheckOnClick = true;
            this._linkToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._linkToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_linkToolStripButton.Image")));
            this._linkToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._linkToolStripButton.Name = "_linkToolStripButton";
            this._linkToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._linkToolStripButton.Text = "Link";
            // 
            // _rightPanel
            // 
            this._rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rightPanel.Location = new System.Drawing.Point(711, 3);
            this._rightPanel.Name = "_rightPanel";
            this._rightPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _rightPanel.Panel1
            // 
            this._rightPanel.Panel1.Controls.Add(this._mapView);
            // 
            // _rightPanel.Panel2
            // 
            this._rightPanel.Panel2.Controls.Add(this._propertyGrid);
            this._rightPanel.Size = new System.Drawing.Size(294, 677);
            this._rightPanel.SplitterDistance = 405;
            this._rightPanel.SplitterWidth = 10;
            this._rightPanel.TabIndex = 2;
            // 
            // _mapView
            // 
            this._mapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mapView.Location = new System.Drawing.Point(0, 0);
            this._mapView.Name = "_mapView";
            this._mapView.Size = new System.Drawing.Size(294, 405);
            this._mapView.TabIndex = 3;
            this._mapView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MapViewNodeMouseClick);
            // 
            // _propertyGrid
            // 
            this._propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertyGrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this._propertyGrid.Location = new System.Drawing.Point(0, 0);
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.Size = new System.Drawing.Size(294, 262);
            this._propertyGrid.TabIndex = 0;
            this._propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGridPropertyValueChanged);
            // 
            // _mapViewMenuStrip
            // 
            this._mapViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mapViewAddMenuItem,
            this._mapViewRemoveMenuItem});
            this._mapViewMenuStrip.Name = "_floorNodeContextMenuStrip";
            this._mapViewMenuStrip.Size = new System.Drawing.Size(153, 70);
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
            this._mapViewAddMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this._mapViewRemoveMenuItem.Size = new System.Drawing.Size(152, 22);
            this._mapViewRemoveMenuItem.Text = "Remove";
            this._mapViewRemoveMenuItem.Click += new System.EventHandler(this.MapViewRemoveMenuItemClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Name = "MainWindow";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.MainWindowLoad);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._tableLayoutPanel.ResumeLayout(false);
            this._panel.ResumeLayout(false);
            this._panel.PerformLayout();
            this._designToolStrip.ResumeLayout(false);
            this._designToolStrip.PerformLayout();
            this._rightPanel.Panel1.ResumeLayout(false);
            this._rightPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._rightPanel)).EndInit();
            this._rightPanel.ResumeLayout(false);
            this._mapViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newFloorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _closeMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _saveMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _exitMenuItem;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.ToolStrip _designToolStrip;
        private System.Windows.Forms.ToolStripButton _wallNodeToolStripButton;
        private System.Windows.Forms.ToolStripButton _linkToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem _layerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _loadBackgroundMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _removeBackgroundMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _setScaleMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel _messageStatusLabel;
        private System.Windows.Forms.SplitContainer _rightPanel;
        private System.Windows.Forms.TreeView _mapView;
        private System.Windows.Forms.PropertyGrid _propertyGrid;
        private System.Windows.Forms.ContextMenuStrip _mapViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddEntryNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddGuideNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddWallNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewRemoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddLinkMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapViewAddFloorMenuItem;
        private Controls.Node nodeControl1;
        private Controls.Designer _designer;
        private System.Windows.Forms.ToolStripStatusLabel _toolStripPlaceholder;
        private System.Windows.Forms.ToolStripStatusLabel _mapStatusLable;
        private System.Windows.Forms.ToolStripMenuItem _newNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newLinkMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openMapMenuItem;
        private System.Windows.Forms.ToolStripButton _entryNodeToolStripButton;
        private System.Windows.Forms.ToolStripButton _guideNodeToolStripButton;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator4;
    }
}

