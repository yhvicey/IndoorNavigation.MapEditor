namespace IndoorNavigator.MapEditor.Windows
{
    partial class ExceptionDialog
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
            this._errorIcon = new System.Windows.Forms.PictureBox();
            this._errorMessage = new System.Windows.Forms.Label();
            this._detailsButton = new System.Windows.Forms.Button();
            this._yesButton = new System.Windows.Forms.Button();
            this._detailsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // _errorIcon
            // 
            this._errorIcon.BackColor = System.Drawing.Color.Transparent;
            this._errorIcon.ErrorImage = null;
            this._errorIcon.Image = global::IndoorNavigator.MapEditor.Properties.Resources.ErrorIcon;
            this._errorIcon.InitialImage = null;
            this._errorIcon.Location = new System.Drawing.Point(21, 21);
            this._errorIcon.Margin = new System.Windows.Forms.Padding(12);
            this._errorIcon.Name = "_errorIcon";
            this._errorIcon.Size = new System.Drawing.Size(50, 50);
            this._errorIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._errorIcon.TabIndex = 0;
            this._errorIcon.TabStop = false;
            // 
            // _errorMessage
            // 
            this._errorMessage.Location = new System.Drawing.Point(86, 21);
            this._errorMessage.Name = "_errorMessage";
            this._errorMessage.Size = new System.Drawing.Size(266, 50);
            this._errorMessage.TabIndex = 1;
            this._errorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _detailsButton
            // 
            this._detailsButton.Location = new System.Drawing.Point(12, 86);
            this._detailsButton.Name = "_detailsButton";
            this._detailsButton.Size = new System.Drawing.Size(75, 23);
            this._detailsButton.TabIndex = 2;
            this._detailsButton.Text = "Details ▼";
            this._detailsButton.UseVisualStyleBackColor = true;
            this._detailsButton.Visible = false;
            this._detailsButton.Click += new System.EventHandler(this.DetailsButtonClick);
            // 
            // _yesButton
            // 
            this._yesButton.Location = new System.Drawing.Point(277, 86);
            this._yesButton.Name = "_yesButton";
            this._yesButton.Size = new System.Drawing.Size(75, 23);
            this._yesButton.TabIndex = 4;
            this._yesButton.Text = "Yes";
            this._yesButton.UseVisualStyleBackColor = true;
            this._yesButton.Click += new System.EventHandler(this.YesButtonClick);
            // 
            // _detailsTextBox
            // 
            this._detailsTextBox.Location = new System.Drawing.Point(12, 125);
            this._detailsTextBox.Multiline = true;
            this._detailsTextBox.Name = "_detailsTextBox";
            this._detailsTextBox.ReadOnly = true;
            this._detailsTextBox.Size = new System.Drawing.Size(340, 124);
            this._detailsTextBox.TabIndex = 5;
            this._detailsTextBox.Visible = false;
            // 
            // ExceptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 121);
            this.Controls.Add(this._detailsTextBox);
            this.Controls.Add(this._yesButton);
            this.Controls.Add(this._detailsButton);
            this.Controls.Add(this._errorMessage);
            this.Controls.Add(this._errorIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exception";
            ((System.ComponentModel.ISupportInitialize)(this._errorIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox _errorIcon;
        private System.Windows.Forms.Button _yesButton;
        private System.Windows.Forms.Button _detailsButton;
        private System.Windows.Forms.Label _errorMessage;
        private System.Windows.Forms.TextBox _detailsTextBox;
    }
}