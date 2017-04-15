namespace IndoorNavigator.MapEditor.Windows
{
    sealed partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._logoPictureBox = new System.Windows.Forms.PictureBox();
            this._productNameLabel = new System.Windows.Forms.Label();
            this._versionLabel = new System.Windows.Forms.Label();
            this._authorLabel = new System.Windows.Forms.Label();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this._logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this._productNameLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this._versionLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this._authorLabel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this._descriptionTextBox, 1, 4);
            this.tableLayoutPanel.Controls.Add(this._okButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // _logoPictureBox
            // 
            this._logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logoPictureBox.Image = global::IndoorNavigator.MapEditor.Properties.Resources.Logo;
            this._logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this._logoPictureBox.Name = "_logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this._logoPictureBox, 6);
            this._logoPictureBox.Size = new System.Drawing.Size(131, 259);
            this._logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._logoPictureBox.TabIndex = 12;
            this._logoPictureBox.TabStop = false;
            // 
            // _productNameLabel
            // 
            this._productNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productNameLabel.Location = new System.Drawing.Point(143, 0);
            this._productNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._productNameLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this._productNameLabel.Name = "_productNameLabel";
            this._productNameLabel.Size = new System.Drawing.Size(271, 17);
            this._productNameLabel.TabIndex = 19;
            this._productNameLabel.Text = "Product Name";
            this._productNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _versionLabel
            // 
            this._versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._versionLabel.Location = new System.Drawing.Point(143, 26);
            this._versionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._versionLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this._versionLabel.Name = "_versionLabel";
            this._versionLabel.Size = new System.Drawing.Size(271, 17);
            this._versionLabel.TabIndex = 0;
            this._versionLabel.Text = "Version";
            this._versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _authorLabel
            // 
            this._authorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._authorLabel.Location = new System.Drawing.Point(143, 52);
            this._authorLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._authorLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this._authorLabel.Name = "_authorLabel";
            this._authorLabel.Size = new System.Drawing.Size(271, 17);
            this._authorLabel.TabIndex = 21;
            this._authorLabel.Text = "Author";
            this._authorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._descriptionTextBox.Location = new System.Drawing.Point(143, 107);
            this._descriptionTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this._descriptionTextBox.Multiline = true;
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.ReadOnly = true;
            this._descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._descriptionTextBox.Size = new System.Drawing.Size(271, 126);
            this._descriptionTextBox.TabIndex = 23;
            this._descriptionTextBox.TabStop = false;
            this._descriptionTextBox.Text = "Description";
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._okButton.Location = new System.Drawing.Point(339, 239);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 24;
            this._okButton.Text = "&OK";
            // 
            // AboutBox
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox _logoPictureBox;
        private System.Windows.Forms.Label _productNameLabel;
        private System.Windows.Forms.Label _versionLabel;
        private System.Windows.Forms.Label _authorLabel;
        private System.Windows.Forms.TextBox _descriptionTextBox;
        private System.Windows.Forms.Button _okButton;
    }
}
