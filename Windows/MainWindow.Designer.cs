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
            this._openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openFloorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._closeMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._layerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._loadBackgroundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._removeBackgroundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setScaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._panel = new System.Windows.Forms.Panel();
            this._floorTabControl = new System.Windows.Forms.TabControl();
            this._floor1TabPage = new System.Windows.Forms.TabPage();
            this.nodeControl1 = new IndoorNavigator.MapEditor.Controls.Node();
            this._designToolStrip = new System.Windows.Forms.ToolStrip();
            this._wallNodeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._linkToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._rightPanel = new System.Windows.Forms.SplitContainer();
            this._mapView = new System.Windows.Forms.TreeView();
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._loadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._mapTreeNodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._mapTreeNodeAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapTreeNodeFloorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mapTreeNodeSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._floorTreeNodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._floorTreeNodeAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._floorTreeNodeEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._floorTreeNodeGuideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._floorTreeNodeWallMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._floorTreeNodeRemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nodeTreeNodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._nodeTreeNodeAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nodeTreeNodeLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nodeTreeNodeRemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this._tableLayoutPanel.SuspendLayout();
            this._panel.SuspendLayout();
            this._floorTabControl.SuspendLayout();
            this._floor1TabPage.SuspendLayout();
            this._designToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._rightPanel)).BeginInit();
            this._rightPanel.Panel1.SuspendLayout();
            this._rightPanel.Panel2.SuspendLayout();
            this._rightPanel.SuspendLayout();
            this._mapTreeNodeMenu.SuspendLayout();
            this._floorTreeNodeMenu.SuspendLayout();
            this._nodeTreeNodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenuItem,
            this._editMenuItem,
            this._layerMenuItem,
            this.magicToolStripMenuItem});
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
            this._closeMapMenuItem,
            this._toolStripSeparator2,
            this._saveMenuItem,
            this._saveAllMenuItem,
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
            this._newFloorMenuItem});
            this._newMenuItem.Name = "_newMenuItem";
            this._newMenuItem.Size = new System.Drawing.Size(187, 22);
            this._newMenuItem.Text = "New";
            // 
            // _newMapMenuItem
            // 
            this._newMapMenuItem.Name = "_newMapMenuItem";
            this._newMapMenuItem.Size = new System.Drawing.Size(101, 22);
            this._newMapMenuItem.Text = "Map";
            // 
            // _newFloorMenuItem
            // 
            this._newFloorMenuItem.Name = "_newFloorMenuItem";
            this._newFloorMenuItem.Size = new System.Drawing.Size(101, 22);
            this._newFloorMenuItem.Text = "Floor";
            // 
            // _openMenuItem
            // 
            this._openMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openMapMenuItem,
            this._openFloorMenuItem});
            this._openMenuItem.Name = "_openMenuItem";
            this._openMenuItem.Size = new System.Drawing.Size(187, 22);
            this._openMenuItem.Text = "Open";
            // 
            // _openMapMenuItem
            // 
            this._openMapMenuItem.Name = "_openMapMenuItem";
            this._openMapMenuItem.Size = new System.Drawing.Size(101, 22);
            this._openMapMenuItem.Text = "Map";
            // 
            // _openFloorMenuItem
            // 
            this._openFloorMenuItem.Name = "_openFloorMenuItem";
            this._openFloorMenuItem.Size = new System.Drawing.Size(101, 22);
            this._openFloorMenuItem.Text = "Floor";
            // 
            // _toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "_toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // _closeMenuItem
            // 
            this._closeMenuItem.Name = "_closeMenuItem";
            this._closeMenuItem.Size = new System.Drawing.Size(187, 22);
            this._closeMenuItem.Text = "Close";
            // 
            // _closeMapMenuItem
            // 
            this._closeMapMenuItem.Name = "_closeMapMenuItem";
            this._closeMapMenuItem.Size = new System.Drawing.Size(187, 22);
            this._closeMapMenuItem.Text = "Close Map";
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // _saveMenuItem
            // 
            this._saveMenuItem.Name = "_saveMenuItem";
            this._saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._saveMenuItem.Size = new System.Drawing.Size(187, 22);
            this._saveMenuItem.Text = "Save";
            // 
            // _saveAllMenuItem
            // 
            this._saveAllMenuItem.Name = "_saveAllMenuItem";
            this._saveAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this._saveAllMenuItem.Size = new System.Drawing.Size(187, 22);
            this._saveAllMenuItem.Text = "Save All";
            // 
            // _toolStripSeparator3
            // 
            this._toolStripSeparator3.Name = "_toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // _exitMenuItem
            // 
            this._exitMenuItem.Name = "_exitMenuItem";
            this._exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._exitMenuItem.Size = new System.Drawing.Size(187, 22);
            this._exitMenuItem.Text = "Exit";
            // 
            // _editMenuItem
            // 
            this._editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undoMenuItem,
            this._redoMenuItem,
            this._toolStripSeparator4,
            this._cutMenuItem,
            this._copyMenuItem,
            this._pasteMenuItem,
            this._deleteMenuItem});
            this._editMenuItem.Name = "_editMenuItem";
            this._editMenuItem.Size = new System.Drawing.Size(39, 20);
            this._editMenuItem.Text = "Edit";
            // 
            // _undoMenuItem
            // 
            this._undoMenuItem.Name = "_undoMenuItem";
            this._undoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this._undoMenuItem.Size = new System.Drawing.Size(144, 22);
            this._undoMenuItem.Text = "Undo";
            // 
            // _redoMenuItem
            // 
            this._redoMenuItem.Name = "_redoMenuItem";
            this._redoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this._redoMenuItem.Size = new System.Drawing.Size(144, 22);
            this._redoMenuItem.Text = "Redo";
            // 
            // _toolStripSeparator4
            // 
            this._toolStripSeparator4.Name = "_toolStripSeparator4";
            this._toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // _cutMenuItem
            // 
            this._cutMenuItem.Name = "_cutMenuItem";
            this._cutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this._cutMenuItem.Size = new System.Drawing.Size(144, 22);
            this._cutMenuItem.Text = "Cut";
            // 
            // _copyMenuItem
            // 
            this._copyMenuItem.Name = "_copyMenuItem";
            this._copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this._copyMenuItem.Size = new System.Drawing.Size(144, 22);
            this._copyMenuItem.Text = "Copy";
            // 
            // _pasteMenuItem
            // 
            this._pasteMenuItem.Name = "_pasteMenuItem";
            this._pasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this._pasteMenuItem.Size = new System.Drawing.Size(144, 22);
            this._pasteMenuItem.Text = "Paste";
            // 
            // _deleteMenuItem
            // 
            this._deleteMenuItem.Name = "_deleteMenuItem";
            this._deleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this._deleteMenuItem.Size = new System.Drawing.Size(144, 22);
            this._deleteMenuItem.Text = "Delete";
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
            this._statusLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 707);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(1008, 22);
            this._statusStrip.TabIndex = 3;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(39, 17);
            this._statusLabel.Text = "Ready";
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
            this._panel.Controls.Add(this._floorTabControl);
            this._panel.Controls.Add(this._designToolStrip);
            this._panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel.Location = new System.Drawing.Point(3, 3);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(702, 677);
            this._panel.TabIndex = 1;
            // 
            // _floorTabControl
            // 
            this._floorTabControl.Controls.Add(this._floor1TabPage);
            this._floorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._floorTabControl.Location = new System.Drawing.Point(0, 25);
            this._floorTabControl.Name = "_floorTabControl";
            this._floorTabControl.SelectedIndex = 0;
            this._floorTabControl.Size = new System.Drawing.Size(702, 652);
            this._floorTabControl.TabIndex = 3;
            // 
            // _floor1TabPage
            // 
            this._floor1TabPage.Controls.Add(this.nodeControl1);
            this._floor1TabPage.Location = new System.Drawing.Point(4, 22);
            this._floor1TabPage.Name = "_floor1TabPage";
            this._floor1TabPage.Padding = new System.Windows.Forms.Padding(3);
            this._floor1TabPage.Size = new System.Drawing.Size(694, 626);
            this._floor1TabPage.TabIndex = 0;
            this._floor1TabPage.Text = "Floor 1";
            this._floor1TabPage.UseVisualStyleBackColor = true;
            // 
            // nodeControl1
            // 
            this.nodeControl1.BackColor = System.Drawing.Color.Transparent;
            this.nodeControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nodeControl1.BackgroundImage")));
            this.nodeControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nodeControl1.Location = new System.Drawing.Point(428, 227);
            this.nodeControl1.MaximumSize = new System.Drawing.Size(14, 14);
            this.nodeControl1.MinimumSize = new System.Drawing.Size(10, 10);
            this.nodeControl1.Name = "nodeControl1";
            this.nodeControl1.Size = new System.Drawing.Size(10, 10);
            this.nodeControl1.TabIndex = 0;
            this.nodeControl1.Type = IndoorNavigator.MapEditor.Models.Nodes.NodeType.EntryNode;
            // 
            // _designToolStrip
            // 
            this._designToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._wallNodeToolStripButton,
            this._linkToolStripButton});
            this._designToolStrip.Location = new System.Drawing.Point(0, 0);
            this._designToolStrip.Name = "_designToolStrip";
            this._designToolStrip.Size = new System.Drawing.Size(702, 25);
            this._designToolStrip.TabIndex = 2;
            this._designToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DesignToolStripItemClicked);
            // 
            // _wallNodeToolStripButton
            // 
            this._wallNodeToolStripButton.CheckOnClick = true;
            this._wallNodeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._wallNodeToolStripButton.Image = global::IndoorNavigator.MapEditor.Properties.Resources.NodeIcon;
            this._wallNodeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._wallNodeToolStripButton.Name = "_wallNodeToolStripButton";
            this._wallNodeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._wallNodeToolStripButton.Text = "WallNode node";
            // 
            // _linkToolStripButton
            // 
            this._linkToolStripButton.CheckOnClick = true;
            this._linkToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._linkToolStripButton.Image = global::IndoorNavigator.MapEditor.Properties.Resources.LinkIcon;
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
            // _mapTreeNodeMenu
            // 
            this._mapTreeNodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mapTreeNodeAddMenuItem,
            this._mapTreeNodeSaveMenuItem});
            this._mapTreeNodeMenu.Name = "_mapNodeContextMenuStrip";
            this._mapTreeNodeMenu.Size = new System.Drawing.Size(99, 48);
            // 
            // _mapTreeNodeAddMenuItem
            // 
            this._mapTreeNodeAddMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mapTreeNodeFloorMenuItem});
            this._mapTreeNodeAddMenuItem.Name = "_mapTreeNodeAddMenuItem";
            this._mapTreeNodeAddMenuItem.Size = new System.Drawing.Size(98, 22);
            this._mapTreeNodeAddMenuItem.Text = "Add";
            // 
            // _mapTreeNodeFloorMenuItem
            // 
            this._mapTreeNodeFloorMenuItem.Name = "_mapTreeNodeFloorMenuItem";
            this._mapTreeNodeFloorMenuItem.Size = new System.Drawing.Size(101, 22);
            this._mapTreeNodeFloorMenuItem.Text = "Floor";
            // 
            // _mapTreeNodeSaveMenuItem
            // 
            this._mapTreeNodeSaveMenuItem.Name = "_mapTreeNodeSaveMenuItem";
            this._mapTreeNodeSaveMenuItem.Size = new System.Drawing.Size(98, 22);
            this._mapTreeNodeSaveMenuItem.Text = "Save";
            // 
            // _floorTreeNodeMenu
            // 
            this._floorTreeNodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._floorTreeNodeAddMenuItem,
            this._floorTreeNodeRemoveMenuItem});
            this._floorTreeNodeMenu.Name = "_floorNodeContextMenuStrip";
            this._floorTreeNodeMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // _floorTreeNodeAddMenuItem
            // 
            this._floorTreeNodeAddMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._floorTreeNodeEntryMenuItem,
            this._floorTreeNodeGuideMenuItem,
            this._floorTreeNodeWallMenuItem});
            this._floorTreeNodeAddMenuItem.Name = "_floorTreeNodeAddMenuItem";
            this._floorTreeNodeAddMenuItem.Size = new System.Drawing.Size(117, 22);
            this._floorTreeNodeAddMenuItem.Text = "Add";
            // 
            // _floorTreeNodeEntryMenuItem
            // 
            this._floorTreeNodeEntryMenuItem.Name = "_floorTreeNodeEntryMenuItem";
            this._floorTreeNodeEntryMenuItem.Size = new System.Drawing.Size(135, 22);
            this._floorTreeNodeEntryMenuItem.Text = "Entry node";
            // 
            // _floorTreeNodeGuideMenuItem
            // 
            this._floorTreeNodeGuideMenuItem.Name = "_floorTreeNodeGuideMenuItem";
            this._floorTreeNodeGuideMenuItem.Size = new System.Drawing.Size(135, 22);
            this._floorTreeNodeGuideMenuItem.Text = "Guide node";
            // 
            // _floorTreeNodeWallMenuItem
            // 
            this._floorTreeNodeWallMenuItem.Name = "_floorTreeNodeWallMenuItem";
            this._floorTreeNodeWallMenuItem.Size = new System.Drawing.Size(135, 22);
            this._floorTreeNodeWallMenuItem.Text = "Wall node";
            // 
            // _floorTreeNodeRemoveMenuItem
            // 
            this._floorTreeNodeRemoveMenuItem.Name = "_floorTreeNodeRemoveMenuItem";
            this._floorTreeNodeRemoveMenuItem.Size = new System.Drawing.Size(117, 22);
            this._floorTreeNodeRemoveMenuItem.Text = "Remove";
            // 
            // _nodeTreeNodeMenu
            // 
            this._nodeTreeNodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._nodeTreeNodeAddMenuItem,
            this._nodeTreeNodeRemoveMenuItem});
            this._nodeTreeNodeMenu.Name = "_nodeTreeNodeMenu";
            this._nodeTreeNodeMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // _nodeTreeNodeAddMenuItem
            // 
            this._nodeTreeNodeAddMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._nodeTreeNodeLinkMenuItem});
            this._nodeTreeNodeAddMenuItem.Name = "_nodeTreeNodeAddMenuItem";
            this._nodeTreeNodeAddMenuItem.Size = new System.Drawing.Size(117, 22);
            this._nodeTreeNodeAddMenuItem.Text = "Add";
            // 
            // _nodeTreeNodeLinkMenuItem
            // 
            this._nodeTreeNodeLinkMenuItem.Name = "_nodeTreeNodeLinkMenuItem";
            this._nodeTreeNodeLinkMenuItem.Size = new System.Drawing.Size(152, 22);
            this._nodeTreeNodeLinkMenuItem.Text = "Link";
            // 
            // _nodeTreeNodeRemoveMenuItem
            // 
            this._nodeTreeNodeRemoveMenuItem.Name = "_nodeTreeNodeRemoveMenuItem";
            this._nodeTreeNodeRemoveMenuItem.Size = new System.Drawing.Size(117, 22);
            this._nodeTreeNodeRemoveMenuItem.Text = "Remove";
            // 
            // magicToolStripMenuItem
            // 
            this.magicToolStripMenuItem.Name = "magicToolStripMenuItem";
            this.magicToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.magicToolStripMenuItem.Text = "Magic";
            this.magicToolStripMenuItem.Click += new System.EventHandler(this.magicToolStripMenuItem_Click);
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
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._tableLayoutPanel.ResumeLayout(false);
            this._panel.ResumeLayout(false);
            this._panel.PerformLayout();
            this._floorTabControl.ResumeLayout(false);
            this._floor1TabPage.ResumeLayout(false);
            this._designToolStrip.ResumeLayout(false);
            this._designToolStrip.PerformLayout();
            this._rightPanel.Panel1.ResumeLayout(false);
            this._rightPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._rightPanel)).EndInit();
            this._rightPanel.ResumeLayout(false);
            this._mapTreeNodeMenu.ResumeLayout(false);
            this._floorTreeNodeMenu.ResumeLayout(false);
            this._nodeTreeNodeMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem _openMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openFloorMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _closeMapMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _redoMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem _cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _pasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deleteMenuItem;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.TabControl _floorTabControl;
        private System.Windows.Forms.ToolStrip _designToolStrip;
        private System.Windows.Forms.ToolStripButton _wallNodeToolStripButton;
        private System.Windows.Forms.ToolStripButton _linkToolStripButton;
        private System.Windows.Forms.TabPage _floor1TabPage;
        private System.Windows.Forms.ToolStripMenuItem _layerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _loadBackgroundMenuItem;
        private System.Windows.Forms.OpenFileDialog _loadFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _removeBackgroundMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _setScaleMenuItem;
        private Controls.Node nodeControl1;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
        private System.Windows.Forms.SplitContainer _rightPanel;
        private System.Windows.Forms.TreeView _mapView;
        private System.Windows.Forms.PropertyGrid _propertyGrid;
        private System.Windows.Forms.ContextMenuStrip _mapTreeNodeMenu;
        private System.Windows.Forms.ToolStripMenuItem _mapTreeNodeAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapTreeNodeSaveMenuItem;
        private System.Windows.Forms.ContextMenuStrip _floorTreeNodeMenu;
        private System.Windows.Forms.ToolStripMenuItem _floorTreeNodeAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _floorTreeNodeEntryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _floorTreeNodeGuideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _floorTreeNodeWallMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _floorTreeNodeRemoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mapTreeNodeFloorMenuItem;
        private System.Windows.Forms.ContextMenuStrip _nodeTreeNodeMenu;
        private System.Windows.Forms.ToolStripMenuItem _nodeTreeNodeAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _nodeTreeNodeLinkMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _nodeTreeNodeRemoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magicToolStripMenuItem;
    }
}

