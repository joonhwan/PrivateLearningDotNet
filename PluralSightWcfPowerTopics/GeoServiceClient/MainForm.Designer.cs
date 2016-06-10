namespace GeoServiceClient
{
    partial class MainForm
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
            this.getZipCodeButton = new System.Windows.Forms.Button();
            this.getInfoButton = new System.Windows.Forms.Button();
            this.zipCodeComboBox = new System.Windows.Forms.ComboBox();
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getZipCodeButton
            // 
            this.getZipCodeButton.Location = new System.Drawing.Point(13, 13);
            this.getZipCodeButton.Name = "getZipCodeButton";
            this.getZipCodeButton.Size = new System.Drawing.Size(139, 23);
            this.getZipCodeButton.TabIndex = 0;
            this.getZipCodeButton.Text = "Get Zip Codes";
            this.getZipCodeButton.UseVisualStyleBackColor = true;
            this.getZipCodeButton.Click += new System.EventHandler(this.getZipCodeButton_Click);
            // 
            // getInfoButton
            // 
            this.getInfoButton.Location = new System.Drawing.Point(13, 69);
            this.getInfoButton.Name = "getInfoButton";
            this.getInfoButton.Size = new System.Drawing.Size(139, 23);
            this.getInfoButton.TabIndex = 1;
            this.getInfoButton.Text = "Get Info";
            this.getInfoButton.UseVisualStyleBackColor = true;
            this.getInfoButton.Click += new System.EventHandler(this.getInfoButton_Click);
            // 
            // zipCodeComboBox
            // 
            this.zipCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zipCodeComboBox.FormattingEnabled = true;
            this.zipCodeComboBox.Location = new System.Drawing.Point(13, 43);
            this.zipCodeComboBox.Name = "zipCodeComboBox";
            this.zipCodeComboBox.Size = new System.Drawing.Size(259, 20);
            this.zipCodeComboBox.TabIndex = 2;
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.Location = new System.Drawing.Point(13, 99);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.Size = new System.Drawing.Size(259, 79);
            this.InfoTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.InfoTextBox);
            this.Controls.Add(this.zipCodeComboBox);
            this.Controls.Add(this.getInfoButton);
            this.Controls.Add(this.getZipCodeButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getZipCodeButton;
        private System.Windows.Forms.Button getInfoButton;
        private System.Windows.Forms.ComboBox zipCodeComboBox;
        private System.Windows.Forms.TextBox InfoTextBox;
    }
}

