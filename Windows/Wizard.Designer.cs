namespace IndoorNavigator.MapEditor.Windows
{
    partial class Wizard<T>
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
            this._confirmButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _confirmButton
            // 
            this._confirmButton.Location = new System.Drawing.Point(12, 42);
            this._confirmButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this._confirmButton.Name = "_confirmButton";
            this._confirmButton.Size = new System.Drawing.Size(75, 23);
            this._confirmButton.TabIndex = 0;
            this._confirmButton.Text = "Confirm";
            this._confirmButton.UseVisualStyleBackColor = true;
            this._confirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(116, 43);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(79, 22);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // Wizard
            // 
            this.AcceptButton = this._confirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(207, 79);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._confirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Wizard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button _confirmButton;
        protected System.Windows.Forms.Button _cancelButton;
    }
}