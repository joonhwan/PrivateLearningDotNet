namespace PunService.AJAX.WinFormClient
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
            this.cookieTextBox = new System.Windows.Forms.TextBox();
            this.cookieButton = new System.Windows.Forms.Button();
            this.cookieLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.degreeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.complexCookieButton = new System.Windows.Forms.Button();
            this.complexCookieLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cookieTextBox
            // 
            this.cookieTextBox.Location = new System.Drawing.Point(65, 13);
            this.cookieTextBox.Name = "cookieTextBox";
            this.cookieTextBox.Size = new System.Drawing.Size(100, 21);
            this.cookieTextBox.TabIndex = 0;
            // 
            // cookieButton
            // 
            this.cookieButton.Location = new System.Drawing.Point(172, 13);
            this.cookieButton.Name = "cookieButton";
            this.cookieButton.Size = new System.Drawing.Size(75, 23);
            this.cookieButton.TabIndex = 1;
            this.cookieButton.Text = "Get Cookie";
            this.cookieButton.UseVisualStyleBackColor = true;
            this.cookieButton.Click += new System.EventHandler(this.cookieButton_Click);
            // 
            // cookieLabel
            // 
            this.cookieLabel.Location = new System.Drawing.Point(172, 37);
            this.cookieLabel.Name = "cookieLabel";
            this.cookieLabel.Size = new System.Drawing.Size(388, 23);
            this.cookieLabel.TabIndex = 2;
            this.cookieLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(66, 82);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 21);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.Text = "John Papa";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(66, 109);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(100, 21);
            this.ageTextBox.TabIndex = 3;
            this.ageTextBox.Text = "40";
            // 
            // degreeTextBox
            // 
            this.degreeTextBox.Location = new System.Drawing.Point(66, 136);
            this.degreeTextBox.Name = "degreeTextBox";
            this.degreeTextBox.Size = new System.Drawing.Size(100, 21);
            this.degreeTextBox.TabIndex = 3;
            this.degreeTextBox.Text = "3.4";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Age";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Degree";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.AutoSize = true;
            this.isActiveCheckBox.Checked = true;
            this.isActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isActiveCheckBox.Location = new System.Drawing.Point(55, 172);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(68, 16);
            this.isActiveCheckBox.TabIndex = 4;
            this.isActiveCheckBox.Text = "IsActive";
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // complexCookieButton
            // 
            this.complexCookieButton.Location = new System.Drawing.Point(172, 80);
            this.complexCookieButton.Name = "complexCookieButton";
            this.complexCookieButton.Size = new System.Drawing.Size(167, 23);
            this.complexCookieButton.TabIndex = 1;
            this.complexCookieButton.Text = "Get Complex Cookie";
            this.complexCookieButton.UseVisualStyleBackColor = true;
            this.complexCookieButton.Click += new System.EventHandler(this.complexCookieButton_Click);
            // 
            // complexCookieLabel
            // 
            this.complexCookieLabel.Location = new System.Drawing.Point(172, 107);
            this.complexCookieLabel.Name = "complexCookieLabel";
            this.complexCookieLabel.Size = new System.Drawing.Size(388, 23);
            this.complexCookieLabel.TabIndex = 2;
            this.complexCookieLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 201);
            this.Controls.Add(this.isActiveCheckBox);
            this.Controls.Add(this.degreeTextBox);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.complexCookieLabel);
            this.Controls.Add(this.cookieLabel);
            this.Controls.Add(this.complexCookieButton);
            this.Controls.Add(this.cookieButton);
            this.Controls.Add(this.cookieTextBox);
            this.Name = "MainForm";
            this.Text = "WCF AJAX WinForm Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cookieTextBox;
        private System.Windows.Forms.Button cookieButton;
        private System.Windows.Forms.Label cookieLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.TextBox degreeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.Button complexCookieButton;
        private System.Windows.Forms.Label complexCookieLabel;
    }
}