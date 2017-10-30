namespace POS.Diary.Controls
{
    partial class TextMagic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSenderName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblAPIKey = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtAPIKEy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(4, 4);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(72, 13);
            this.lblSenderName.TabIndex = 0;
            this.lblSenderName.Text = "Sender Name";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(4, 54);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Username";
            // 
            // lblAPIKey
            // 
            this.lblAPIKey.AutoSize = true;
            this.lblAPIKey.Location = new System.Drawing.Point(4, 101);
            this.lblAPIKey.Name = "lblAPIKey";
            this.lblAPIKey.Size = new System.Drawing.Size(45, 13);
            this.lblAPIKey.TabIndex = 2;
            this.lblAPIKey.Text = "API Key";
            // 
            // txtSenderName
            // 
            this.txtSenderName.Location = new System.Drawing.Point(4, 21);
            this.txtSenderName.MaxLength = 150;
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(450, 20);
            this.txtSenderName.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(4, 70);
            this.txtUserName.MaxLength = 150;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(450, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtAPIKEy
            // 
            this.txtAPIKEy.Location = new System.Drawing.Point(4, 117);
            this.txtAPIKEy.MaxLength = 150;
            this.txtAPIKEy.Name = "txtAPIKEy";
            this.txtAPIKEy.Size = new System.Drawing.Size(450, 20);
            this.txtAPIKEy.TabIndex = 5;
            // 
            // TextMagic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAPIKEy);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtSenderName);
            this.Controls.Add(this.lblAPIKey);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblSenderName);
            this.Name = "TextMagic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblAPIKey;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtAPIKEy;
    }
}
