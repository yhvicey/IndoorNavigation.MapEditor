namespace IndoorNavigator.MapEditor.Windows
{
    partial class ChangeSizeWizard
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
            this._label1 = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._widthTextBox = new System.Windows.Forms.TextBox();
            this._heightTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _confirmButton
            // 
            this._confirmButton.Location = new System.Drawing.Point(12, 70);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(116, 71);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(12, 9);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(35, 13);
            this._label1.TabIndex = 0;
            this._label1.Text = "Width";
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(12, 35);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(38, 13);
            this._label2.TabIndex = 1;
            this._label2.Text = "Height";
            // 
            // _widthTextBox
            // 
            this._widthTextBox.Location = new System.Drawing.Point(56, 6);
            this._widthTextBox.Name = "_widthTextBox";
            this._widthTextBox.Size = new System.Drawing.Size(139, 20);
            this._widthTextBox.TabIndex = 2;
            // 
            // _heightTextBox
            // 
            this._heightTextBox.Location = new System.Drawing.Point(56, 32);
            this._heightTextBox.Name = "_heightTextBox";
            this._heightTextBox.Size = new System.Drawing.Size(139, 20);
            this._heightTextBox.TabIndex = 3;
            // 
            // ChangeSizeWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 107);
            this.Controls.Add(this._heightTextBox);
            this.Controls.Add(this._widthTextBox);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._label1);
            this.Name = "ChangeSizeWizard";
            this.Text = "Change size";
            this.Load += new System.EventHandler(this.ChangeSizeWizardLoad);
            this.Controls.SetChildIndex(this._label1, 0);
            this.Controls.SetChildIndex(this._label2, 0);
            this.Controls.SetChildIndex(this._widthTextBox, 0);
            this.Controls.SetChildIndex(this._heightTextBox, 0);
            this.Controls.SetChildIndex(this._confirmButton, 0);
            this.Controls.SetChildIndex(this._cancelButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.TextBox _widthTextBox;
        private System.Windows.Forms.TextBox _heightTextBox;
    }
}