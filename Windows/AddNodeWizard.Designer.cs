namespace IndoorNavigator.MapEditor.Windows
{
    partial class AddNodeWizard
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
            this._nodeTypeComboBox = new System.Windows.Forms.ComboBox();
            this._label1 = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this._xTextBox = new System.Windows.Forms.TextBox();
            this._yTextBox = new System.Windows.Forms.TextBox();
            this._label4 = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._label5 = new System.Windows.Forms.Label();
            this._label6 = new System.Windows.Forms.Label();
            this._label7 = new System.Windows.Forms.Label();
            this._confirmButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._label2 = new System.Windows.Forms.Label();
            this._floorComboBox = new System.Windows.Forms.ComboBox();
            this._prevComboBox = new System.Windows.Forms.ComboBox();
            this._nextComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _nodeTypeComboBox
            // 
            this._nodeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._nodeTypeComboBox.FormattingEnabled = true;
            this._nodeTypeComboBox.Items.AddRange(new object[] {
            "EntryNode",
            "GuideNode",
            "WallNode"});
            this._nodeTypeComboBox.Location = new System.Drawing.Point(74, 6);
            this._nodeTypeComboBox.Name = "_nodeTypeComboBox";
            this._nodeTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this._nodeTypeComboBox.TabIndex = 0;
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(12, 9);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(56, 13);
            this._label1.TabIndex = 1;
            this._label1.Text = "Node type";
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.Location = new System.Drawing.Point(12, 63);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(14, 13);
            this._label3.TabIndex = 2;
            this._label3.Text = "X";
            // 
            // _xTextBox
            // 
            this._xTextBox.Location = new System.Drawing.Point(74, 60);
            this._xTextBox.Name = "_xTextBox";
            this._xTextBox.Size = new System.Drawing.Size(121, 20);
            this._xTextBox.TabIndex = 3;
            // 
            // _yTextBox
            // 
            this._yTextBox.Location = new System.Drawing.Point(74, 86);
            this._yTextBox.Name = "_yTextBox";
            this._yTextBox.Size = new System.Drawing.Size(121, 20);
            this._yTextBox.TabIndex = 5;
            // 
            // _label4
            // 
            this._label4.AutoSize = true;
            this._label4.Location = new System.Drawing.Point(12, 89);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(14, 13);
            this._label4.TabIndex = 4;
            this._label4.Text = "Y";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(74, 112);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(121, 20);
            this._nameTextBox.TabIndex = 7;
            // 
            // _label5
            // 
            this._label5.AutoSize = true;
            this._label5.Location = new System.Drawing.Point(12, 115);
            this._label5.Name = "_label5";
            this._label5.Size = new System.Drawing.Size(35, 13);
            this._label5.TabIndex = 6;
            this._label5.Text = "Name";
            // 
            // _label6
            // 
            this._label6.AutoSize = true;
            this._label6.Location = new System.Drawing.Point(12, 141);
            this._label6.Name = "_label6";
            this._label6.Size = new System.Drawing.Size(29, 13);
            this._label6.TabIndex = 8;
            this._label6.Text = "Prev";
            // 
            // _label7
            // 
            this._label7.AutoSize = true;
            this._label7.Location = new System.Drawing.Point(12, 167);
            this._label7.Name = "_label7";
            this._label7.Size = new System.Drawing.Size(29, 13);
            this._label7.TabIndex = 10;
            this._label7.Text = "Next";
            // 
            // _confirmButton
            // 
            this._confirmButton.Location = new System.Drawing.Point(12, 200);
            this._confirmButton.Name = "_confirmButton";
            this._confirmButton.Size = new System.Drawing.Size(79, 22);
            this._confirmButton.TabIndex = 12;
            this._confirmButton.Text = "Confirm";
            this._confirmButton.UseVisualStyleBackColor = true;
            this._confirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(116, 200);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(79, 22);
            this._cancelButton.TabIndex = 13;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(12, 36);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(30, 13);
            this._label2.TabIndex = 15;
            this._label2.Text = "Floor";
            // 
            // _floorComboBox
            // 
            this._floorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._floorComboBox.FormattingEnabled = true;
            this._floorComboBox.Location = new System.Drawing.Point(74, 33);
            this._floorComboBox.Name = "_floorComboBox";
            this._floorComboBox.Size = new System.Drawing.Size(121, 21);
            this._floorComboBox.TabIndex = 14;
            this._floorComboBox.SelectedIndexChanged += new System.EventHandler(this.FloorComboBoxSelectedIndexChanged);
            // 
            // _prevComboBox
            // 
            this._prevComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._prevComboBox.FormattingEnabled = true;
            this._prevComboBox.Location = new System.Drawing.Point(74, 138);
            this._prevComboBox.Name = "_prevComboBox";
            this._prevComboBox.Size = new System.Drawing.Size(121, 21);
            this._prevComboBox.TabIndex = 16;
            // 
            // _nextComboBox
            // 
            this._nextComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._nextComboBox.FormattingEnabled = true;
            this._nextComboBox.Location = new System.Drawing.Point(74, 165);
            this._nextComboBox.Name = "_nextComboBox";
            this._nextComboBox.Size = new System.Drawing.Size(121, 21);
            this._nextComboBox.TabIndex = 17;
            // 
            // AddNodeWizard
            // 
            this.AcceptButton = this._confirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(207, 234);
            this.Controls.Add(this._nextComboBox);
            this.Controls.Add(this._prevComboBox);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._floorComboBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._confirmButton);
            this.Controls.Add(this._label7);
            this.Controls.Add(this._label6);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._label5);
            this.Controls.Add(this._yTextBox);
            this.Controls.Add(this._label4);
            this.Controls.Add(this._xTextBox);
            this.Controls.Add(this._label3);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._nodeTypeComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNodeWizard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add node";
            this.Load += new System.EventHandler(this.AddNodeWizardLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _nodeTypeComboBox;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.TextBox _xTextBox;
        private System.Windows.Forms.TextBox _yTextBox;
        private System.Windows.Forms.Label _label4;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label _label5;
        private System.Windows.Forms.Label _label6;
        private System.Windows.Forms.Label _label7;
        private System.Windows.Forms.Button _confirmButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.ComboBox _floorComboBox;
        private System.Windows.Forms.ComboBox _prevComboBox;
        private System.Windows.Forms.ComboBox _nextComboBox;
    }
}