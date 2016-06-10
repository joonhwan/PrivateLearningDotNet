namespace FaultReport.Client
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
            this.makeCallButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // makeCallButton
            // 
            this.makeCallButton.Location = new System.Drawing.Point(13, 13);
            this.makeCallButton.Name = "makeCallButton";
            this.makeCallButton.Size = new System.Drawing.Size(104, 23);
            this.makeCallButton.TabIndex = 0;
            this.makeCallButton.Text = "Test Call";
            this.makeCallButton.UseVisualStyleBackColor = true;
            this.makeCallButton.Click += new System.EventHandler(this.makeCallButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.Location = new System.Drawing.Point(17, 39);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(409, 23);
            this.messageLabel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 201);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.makeCallButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button makeCallButton;
        private System.Windows.Forms.Label messageLabel;
    }
}