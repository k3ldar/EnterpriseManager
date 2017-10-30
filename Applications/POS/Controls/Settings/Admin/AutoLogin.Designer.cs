namespace PointOfSale.Controls.Settings.Admin
{
    partial class AutoLogin
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
            this.lblLoginDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblLoginDescription
            // 
            this.lblLoginDescription.AutoSize = true;
            this.lblLoginDescription.Location = new System.Drawing.Point(4, 4);
            this.lblLoginDescription.Name = "lblLoginDescription";
            this.lblLoginDescription.Size = new System.Drawing.Size(405, 52);
            this.lblLoginDescription.TabIndex = 0;
            this.lblLoginDescription.Text = "To have the POS automatically login, please set the username and password for the" +
    " \r\nuser below.\r\n\r\nYou can still lock the POS when away from your computer.\r\n";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(4, 137);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User";
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(4, 154);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(380, 21);
            this.cmbUsers.TabIndex = 2;
            this.cmbUsers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbUsers_Format);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(4, 182);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(4, 198);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(216, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.Checked = true;
            this.cbAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoLogin.Location = new System.Drawing.Point(4, 101);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(117, 17);
            this.cbAutoLogin.TabIndex = 5;
            this.cbAutoLogin.Text = "Automatically Login";
            this.cbAutoLogin.UseVisualStyleBackColor = true;
            this.cbAutoLogin.CheckedChanged += new System.EventHandler(this.cbAutoLogin_CheckedChanged);
            // 
            // AutoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAutoLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblLoginDescription);
            this.Name = "AutoLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginDescription;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox cbAutoLogin;
    }
}
