namespace PointOfSale.Controls.InitialSetupWizard
{
    partial class Step5
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
            this.btnTestEmail = new System.Windows.Forms.Button();
            this.udEmailPort = new System.Windows.Forms.NumericUpDown();
            this.lblEmailPort = new System.Windows.Forms.Label();
            this.txtEmailHost = new System.Windows.Forms.TextBox();
            this.lblEmailHost = new System.Windows.Forms.Label();
            this.txtEmailPassword = new System.Windows.Forms.TextBox();
            this.lblEmailPassword = new System.Windows.Forms.Label();
            this.txtEmailUsername = new System.Windows.Forms.TextBox();
            this.lblEmailUsername = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cbUseSSL = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.udEmailPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestEmail
            // 
            this.btnTestEmail.Location = new System.Drawing.Point(451, 242);
            this.btnTestEmail.Name = "btnTestEmail";
            this.btnTestEmail.Size = new System.Drawing.Size(75, 23);
            this.btnTestEmail.TabIndex = 39;
            this.btnTestEmail.Text = "button1";
            this.btnTestEmail.UseVisualStyleBackColor = true;
            this.btnTestEmail.Click += new System.EventHandler(this.btnTestEmail_Click);
            // 
            // udEmailPort
            // 
            this.udEmailPort.Location = new System.Drawing.Point(4, 195);
            this.udEmailPort.Maximum = new decimal(new int[] {
            65353,
            0,
            0,
            0});
            this.udEmailPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udEmailPort.Name = "udEmailPort";
            this.udEmailPort.Size = new System.Drawing.Size(120, 20);
            this.udEmailPort.TabIndex = 36;
            this.udEmailPort.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // lblEmailPort
            // 
            this.lblEmailPort.AutoSize = true;
            this.lblEmailPort.Location = new System.Drawing.Point(4, 178);
            this.lblEmailPort.Name = "lblEmailPort";
            this.lblEmailPort.Size = new System.Drawing.Size(35, 13);
            this.lblEmailPort.TabIndex = 35;
            this.lblEmailPort.Text = "label5";
            // 
            // txtEmailHost
            // 
            this.txtEmailHost.Location = new System.Drawing.Point(4, 151);
            this.txtEmailHost.MaxLength = 80;
            this.txtEmailHost.Name = "txtEmailHost";
            this.txtEmailHost.Size = new System.Drawing.Size(283, 20);
            this.txtEmailHost.TabIndex = 34;
            // 
            // lblEmailHost
            // 
            this.lblEmailHost.AutoSize = true;
            this.lblEmailHost.Location = new System.Drawing.Point(4, 134);
            this.lblEmailHost.Name = "lblEmailHost";
            this.lblEmailHost.Size = new System.Drawing.Size(35, 13);
            this.lblEmailHost.TabIndex = 33;
            this.lblEmailHost.Text = "label4";
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(4, 107);
            this.txtEmailPassword.MaxLength = 80;
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.PasswordChar = '*';
            this.txtEmailPassword.Size = new System.Drawing.Size(283, 20);
            this.txtEmailPassword.TabIndex = 32;
            // 
            // lblEmailPassword
            // 
            this.lblEmailPassword.AutoSize = true;
            this.lblEmailPassword.Location = new System.Drawing.Point(4, 91);
            this.lblEmailPassword.Name = "lblEmailPassword";
            this.lblEmailPassword.Size = new System.Drawing.Size(35, 13);
            this.lblEmailPassword.TabIndex = 31;
            this.lblEmailPassword.Text = "label3";
            // 
            // txtEmailUsername
            // 
            this.txtEmailUsername.Location = new System.Drawing.Point(4, 64);
            this.txtEmailUsername.MaxLength = 80;
            this.txtEmailUsername.Name = "txtEmailUsername";
            this.txtEmailUsername.Size = new System.Drawing.Size(283, 20);
            this.txtEmailUsername.TabIndex = 30;
            // 
            // lblEmailUsername
            // 
            this.lblEmailUsername.AutoSize = true;
            this.lblEmailUsername.Location = new System.Drawing.Point(4, 47);
            this.lblEmailUsername.Name = "lblEmailUsername";
            this.lblEmailUsername.Size = new System.Drawing.Size(35, 13);
            this.lblEmailUsername.TabIndex = 29;
            this.lblEmailUsername.Text = "label2";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(89, 24);
            this.lblHeader.TabIndex = 26;
            this.lblHeader.Text = "Welcome";
            // 
            // cbUseSSL
            // 
            this.cbUseSSL.AutoSize = true;
            this.cbUseSSL.Location = new System.Drawing.Point(4, 231);
            this.cbUseSSL.Name = "cbUseSSL";
            this.cbUseSSL.Size = new System.Drawing.Size(80, 17);
            this.cbUseSSL.TabIndex = 40;
            this.cbUseSSL.Text = "checkBox1";
            this.cbUseSSL.UseVisualStyleBackColor = true;
            // 
            // Step5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbUseSSL);
            this.Controls.Add(this.btnTestEmail);
            this.Controls.Add(this.udEmailPort);
            this.Controls.Add(this.lblEmailPort);
            this.Controls.Add(this.txtEmailHost);
            this.Controls.Add(this.lblEmailHost);
            this.Controls.Add(this.txtEmailPassword);
            this.Controls.Add(this.lblEmailPassword);
            this.Controls.Add(this.txtEmailUsername);
            this.Controls.Add(this.lblEmailUsername);
            this.Controls.Add(this.lblHeader);
            this.Name = "Step5";
            ((System.ComponentModel.ISupportInitialize)(this.udEmailPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTestEmail;
        private System.Windows.Forms.NumericUpDown udEmailPort;
        private System.Windows.Forms.Label lblEmailPort;
        private System.Windows.Forms.TextBox txtEmailHost;
        private System.Windows.Forms.Label lblEmailHost;
        private System.Windows.Forms.TextBox txtEmailPassword;
        private System.Windows.Forms.Label lblEmailPassword;
        private System.Windows.Forms.TextBox txtEmailUsername;
        private System.Windows.Forms.Label lblEmailUsername;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbUseSSL;
    }
}
