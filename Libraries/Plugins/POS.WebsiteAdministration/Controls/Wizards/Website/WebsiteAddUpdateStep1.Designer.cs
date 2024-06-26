﻿namespace POS.WebsiteAdministration.Controls.Wizards.Website
{
    partial class WebsiteAddUpdateStep1
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
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblFTPUsername = new System.Windows.Forms.Label();
            this.txtFTPUsername = new System.Windows.Forms.TextBox();
            this.lblFTPPassword = new System.Windows.Forms.Label();
            this.txtFTPPassword = new System.Windows.Forms.TextBox();
            this.lblFTPHost = new System.Windows.Forms.Label();
            this.txtFTPHost = new System.Windows.Forms.TextBox();
            this.lblFTPPort = new System.Windows.Forms.Label();
            this.udFTPPort = new System.Windows.Forms.NumericUpDown();
            this.btnTestFTP = new System.Windows.Forms.Button();
            this.lblRootPath = new System.Windows.Forms.Label();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.udFTPPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(4, 4);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(35, 13);
            this.lblWebsite.TabIndex = 0;
            this.lblWebsite.Text = "label1";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(4, 21);
            this.txtWebsite.MaxLength = 100;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(395, 20);
            this.txtWebsite.TabIndex = 1;
            // 
            // lblFTPUsername
            // 
            this.lblFTPUsername.AutoSize = true;
            this.lblFTPUsername.Location = new System.Drawing.Point(4, 66);
            this.lblFTPUsername.Name = "lblFTPUsername";
            this.lblFTPUsername.Size = new System.Drawing.Size(35, 13);
            this.lblFTPUsername.TabIndex = 2;
            this.lblFTPUsername.Text = "label2";
            // 
            // txtFTPUsername
            // 
            this.txtFTPUsername.Location = new System.Drawing.Point(4, 83);
            this.txtFTPUsername.MaxLength = 80;
            this.txtFTPUsername.Name = "txtFTPUsername";
            this.txtFTPUsername.Size = new System.Drawing.Size(283, 20);
            this.txtFTPUsername.TabIndex = 3;
            // 
            // lblFTPPassword
            // 
            this.lblFTPPassword.AutoSize = true;
            this.lblFTPPassword.Location = new System.Drawing.Point(4, 110);
            this.lblFTPPassword.Name = "lblFTPPassword";
            this.lblFTPPassword.Size = new System.Drawing.Size(35, 13);
            this.lblFTPPassword.TabIndex = 4;
            this.lblFTPPassword.Text = "label3";
            // 
            // txtFTPPassword
            // 
            this.txtFTPPassword.Location = new System.Drawing.Point(4, 126);
            this.txtFTPPassword.MaxLength = 80;
            this.txtFTPPassword.Name = "txtFTPPassword";
            this.txtFTPPassword.PasswordChar = '*';
            this.txtFTPPassword.Size = new System.Drawing.Size(283, 20);
            this.txtFTPPassword.TabIndex = 5;
            // 
            // lblFTPHost
            // 
            this.lblFTPHost.AutoSize = true;
            this.lblFTPHost.Location = new System.Drawing.Point(4, 153);
            this.lblFTPHost.Name = "lblFTPHost";
            this.lblFTPHost.Size = new System.Drawing.Size(35, 13);
            this.lblFTPHost.TabIndex = 6;
            this.lblFTPHost.Text = "label4";
            // 
            // txtFTPHost
            // 
            this.txtFTPHost.Location = new System.Drawing.Point(4, 170);
            this.txtFTPHost.MaxLength = 80;
            this.txtFTPHost.Name = "txtFTPHost";
            this.txtFTPHost.Size = new System.Drawing.Size(283, 20);
            this.txtFTPHost.TabIndex = 7;
            // 
            // lblFTPPort
            // 
            this.lblFTPPort.AutoSize = true;
            this.lblFTPPort.Location = new System.Drawing.Point(4, 197);
            this.lblFTPPort.Name = "lblFTPPort";
            this.lblFTPPort.Size = new System.Drawing.Size(35, 13);
            this.lblFTPPort.TabIndex = 8;
            this.lblFTPPort.Text = "label5";
            // 
            // udFTPPort
            // 
            this.udFTPPort.Location = new System.Drawing.Point(4, 214);
            this.udFTPPort.Maximum = new decimal(new int[] {
            65353,
            0,
            0,
            0});
            this.udFTPPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFTPPort.Name = "udFTPPort";
            this.udFTPPort.Size = new System.Drawing.Size(120, 20);
            this.udFTPPort.TabIndex = 9;
            this.udFTPPort.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // btnTestFTP
            // 
            this.btnTestFTP.Location = new System.Drawing.Point(4, 301);
            this.btnTestFTP.Name = "btnTestFTP";
            this.btnTestFTP.Size = new System.Drawing.Size(75, 23);
            this.btnTestFTP.TabIndex = 12;
            this.btnTestFTP.Text = "button1";
            this.btnTestFTP.UseVisualStyleBackColor = true;
            this.btnTestFTP.Click += new System.EventHandler(this.btnTestFTP_Click);
            // 
            // lblRootPath
            // 
            this.lblRootPath.AutoSize = true;
            this.lblRootPath.Location = new System.Drawing.Point(4, 247);
            this.lblRootPath.Name = "lblRootPath";
            this.lblRootPath.Size = new System.Drawing.Size(35, 13);
            this.lblRootPath.TabIndex = 10;
            this.lblRootPath.Text = "label1";
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(4, 264);
            this.txtRootPath.MaxLength = 130;
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(283, 20);
            this.txtRootPath.TabIndex = 11;
            this.txtRootPath.Text = "/";
            // 
            // WebsiteAddUpdateStep1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.lblRootPath);
            this.Controls.Add(this.btnTestFTP);
            this.Controls.Add(this.udFTPPort);
            this.Controls.Add(this.lblFTPPort);
            this.Controls.Add(this.txtFTPHost);
            this.Controls.Add(this.lblFTPHost);
            this.Controls.Add(this.txtFTPPassword);
            this.Controls.Add(this.lblFTPPassword);
            this.Controls.Add(this.txtFTPUsername);
            this.Controls.Add(this.lblFTPUsername);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.lblWebsite);
            this.Name = "WebsiteAddUpdateStep1";
            ((System.ComponentModel.ISupportInitialize)(this.udFTPPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblFTPUsername;
        private System.Windows.Forms.TextBox txtFTPUsername;
        private System.Windows.Forms.Label lblFTPPassword;
        private System.Windows.Forms.TextBox txtFTPPassword;
        private System.Windows.Forms.Label lblFTPHost;
        private System.Windows.Forms.TextBox txtFTPHost;
        private System.Windows.Forms.Label lblFTPPort;
        private System.Windows.Forms.NumericUpDown udFTPPort;
        private System.Windows.Forms.Button btnTestFTP;
        private System.Windows.Forms.Label lblRootPath;
        private System.Windows.Forms.TextBox txtRootPath;
    }
}
