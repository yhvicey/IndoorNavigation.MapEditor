namespace IndoorNavigator.MapEditor.Windows
{
    partial class AddLinkWizard
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
            this._label2 = new System.Windows.Forms.Label();
            this._startTypeComboBox = new System.Windows.Forms.ComboBox();
            this._label4 = new System.Windows.Forms.Label();
            this._endTypeComboBox = new System.Windows.Forms.ComboBox();
            this._label3 = new System.Windows.Forms.Label();
            this._startNodeComboBox = new System.Windows.Forms.ComboBox();
            this._label5 = new System.Windows.Forms.Label();
            this._endNodeComboBox = new System.Windows.Forms.ComboBox();
            this._label1 = new System.Windows.Forms.Label();
            this._floorComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _confirmButton
            // 
            this._confirmButton.Location = new System.Drawing.Point(12, 150);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(116, 150);
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(12, 36);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(52, 13);
            this._label2.TabIndex = 3;
            this._label2.Text = "Start type";
            // 
            // _startTypeComboBox
            // 
            this._startTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._startTypeComboBox.FormattingEnabled = true;
            this._startTypeComboBox.Items.AddRange(new object[] {
            "EntryNode",
            "GuideNode",
            "WallNode"});
            this._startTypeComboBox.Location = new System.Drawing.Point(74, 33);
            this._startTypeComboBox.Name = "_startTypeComboBox";
            this._startTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this._startTypeComboBox.TabIndex = 2;
            this._startTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.StartTypeComboBoxSelectedIndexChanged);
            // 
            // _label4
            // 
            this._label4.AutoSize = true;
            this._label4.Location = new System.Drawing.Point(12, 90);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(49, 13);
            this._label4.TabIndex = 5;
            this._label4.Text = "End type";
            // 
            // _endTypeComboBox
            // 
            this._endTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._endTypeComboBox.FormattingEnabled = true;
            this._endTypeComboBox.Items.AddRange(new object[] {
            "EntryNode",
            "GuideNode",
            "WallNode"});
            this._endTypeComboBox.Location = new System.Drawing.Point(74, 87);
            this._endTypeComboBox.Name = "_endTypeComboBox";
            this._endTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this._endTypeComboBox.TabIndex = 4;
            this._endTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.EndTypeComboBoxSelectedIndexChanged);
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.Location = new System.Drawing.Point(12, 63);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(56, 13);
            this._label3.TabIndex = 6;
            this._label3.Text = "Start node";
            // 
            // _startNodeComboBox
            // 
            this._startNodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._startNodeComboBox.FormattingEnabled = true;
            this._startNodeComboBox.Location = new System.Drawing.Point(74, 60);
            this._startNodeComboBox.Name = "_startNodeComboBox";
            this._startNodeComboBox.Size = new System.Drawing.Size(121, 21);
            this._startNodeComboBox.TabIndex = 7;
            // 
            // _label5
            // 
            this._label5.AutoSize = true;
            this._label5.Location = new System.Drawing.Point(12, 117);
            this._label5.Name = "_label5";
            this._label5.Size = new System.Drawing.Size(53, 13);
            this._label5.TabIndex = 9;
            this._label5.Text = "End node";
            // 
            // _endNodeComboBox
            // 
            this._endNodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._endNodeComboBox.FormattingEnabled = true;
            this._endNodeComboBox.Location = new System.Drawing.Point(74, 114);
            this._endNodeComboBox.Name = "_endNodeComboBox";
            this._endNodeComboBox.Size = new System.Drawing.Size(121, 21);
            this._endNodeComboBox.TabIndex = 8;
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(12, 9);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(30, 13);
            this._label1.TabIndex = 17;
            this._label1.Text = "Floor";
            // 
            // _floorComboBox
            // 
            this._floorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._floorComboBox.FormattingEnabled = true;
            this._floorComboBox.Location = new System.Drawing.Point(74, 6);
            this._floorComboBox.Name = "_floorComboBox";
            this._floorComboBox.Size = new System.Drawing.Size(121, 21);
            this._floorComboBox.TabIndex = 16;
            this._floorComboBox.SelectedIndexChanged += new System.EventHandler(this.FloorComboBoxSelectedIndexChanged);
            // 
            // AddLinkWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 187);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._floorComboBox);
            this.Controls.Add(this._label5);
            this.Controls.Add(this._endNodeComboBox);
            this.Controls.Add(this._startNodeComboBox);
            this.Controls.Add(this._label3);
            this.Controls.Add(this._label4);
            this.Controls.Add(this._endTypeComboBox);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._startTypeComboBox);
            this.Name = "AddLinkWizard";
            this.Text = "Add link";
            this.Load += new System.EventHandler(this.AddLinkWizardLoad);
            this.Controls.SetChildIndex(this._startTypeComboBox, 0);
            this.Controls.SetChildIndex(this._label2, 0);
            this.Controls.SetChildIndex(this._endTypeComboBox, 0);
            this.Controls.SetChildIndex(this._label4, 0);
            this.Controls.SetChildIndex(this._label3, 0);
            this.Controls.SetChildIndex(this._startNodeComboBox, 0);
            this.Controls.SetChildIndex(this._endNodeComboBox, 0);
            this.Controls.SetChildIndex(this._label5, 0);
            this.Controls.SetChildIndex(this._floorComboBox, 0);
            this.Controls.SetChildIndex(this._label1, 0);
            this.Controls.SetChildIndex(this._confirmButton, 0);
            this.Controls.SetChildIndex(this._cancelButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.ComboBox _startTypeComboBox;
        private System.Windows.Forms.Label _label4;
        private System.Windows.Forms.ComboBox _endTypeComboBox;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.ComboBox _startNodeComboBox;
        private System.Windows.Forms.Label _label5;
        private System.Windows.Forms.ComboBox _endNodeComboBox;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.ComboBox _floorComboBox;
    }
}