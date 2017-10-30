namespace POS.Customers.Controls
{
    partial class Permissions
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
            this.lstAvailableSecurity = new System.Windows.Forms.ListBox();
            this.lstSelectedSecurity = new System.Windows.Forms.ListBox();
            this.cmbPermissions = new System.Windows.Forms.ComboBox();
            this.lblPermissionType = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblAssigned = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAvailableSecurity
            // 
            this.lstAvailableSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAvailableSecurity.FormattingEnabled = true;
            this.lstAvailableSecurity.Location = new System.Drawing.Point(3, 74);
            this.lstAvailableSecurity.Name = "lstAvailableSecurity";
            this.lstAvailableSecurity.Size = new System.Drawing.Size(227, 290);
            this.lstAvailableSecurity.TabIndex = 3;
            this.lstAvailableSecurity.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstSelectedSecurity_Format);
            this.lstAvailableSecurity.DoubleClick += new System.EventHandler(this.lstAvailableSecurity_DoubleClick);
            // 
            // lstSelectedSecurity
            // 
            this.lstSelectedSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectedSecurity.FormattingEnabled = true;
            this.lstSelectedSecurity.Location = new System.Drawing.Point(317, 74);
            this.lstSelectedSecurity.Name = "lstSelectedSecurity";
            this.lstSelectedSecurity.Size = new System.Drawing.Size(220, 290);
            this.lstSelectedSecurity.TabIndex = 2;
            this.lstSelectedSecurity.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstSelectedSecurity_Format);
            this.lstSelectedSecurity.DoubleClick += new System.EventHandler(this.lstSelectedSecurity_DoubleClick);
            // 
            // cmbPermissions
            // 
            this.cmbPermissions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPermissions.FormattingEnabled = true;
            this.cmbPermissions.Items.AddRange(new object[] {
            "General",
            "Accounts",
            "Calendar",
            "Website",
            "Reports",
            "Stock Control"});
            this.cmbPermissions.Location = new System.Drawing.Point(0, 24);
            this.cmbPermissions.Name = "cmbPermissions";
            this.cmbPermissions.Size = new System.Drawing.Size(230, 21);
            this.cmbPermissions.TabIndex = 4;
            this.cmbPermissions.SelectedIndexChanged += new System.EventHandler(this.cmbPermissions_SelectedIndexChanged);
            // 
            // lblPermissionType
            // 
            this.lblPermissionType.AutoSize = true;
            this.lblPermissionType.Location = new System.Drawing.Point(0, 8);
            this.lblPermissionType.Name = "lblPermissionType";
            this.lblPermissionType.Size = new System.Drawing.Size(76, 13);
            this.lblPermissionType.TabIndex = 5;
            this.lblPermissionType.Text = "Permission Set";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(6, 61);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(50, 13);
            this.lblAvailable.TabIndex = 6;
            this.lblAvailable.Text = "Available";
            // 
            // lblAssigned
            // 
            this.lblAssigned.AutoSize = true;
            this.lblAssigned.Location = new System.Drawing.Point(314, 58);
            this.lblAssigned.Name = "lblAssigned";
            this.lblAssigned.Size = new System.Drawing.Size(50, 13);
            this.lblAssigned.TabIndex = 7;
            this.lblAssigned.Text = "Assigned";
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(236, 155);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 8;
            this.btnAssign.Text = "&Assign >>";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.lstAvailableSecurity_DoubleClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(236, 184);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "<< &Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.lstSelectedSecurity_DoubleClick);
            // 
            // Permissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.lblAssigned);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lblPermissionType);
            this.Controls.Add(this.cmbPermissions);
            this.Controls.Add(this.lstAvailableSecurity);
            this.Controls.Add(this.lstSelectedSecurity);
            this.Name = "Permissions";
            this.Size = new System.Drawing.Size(540, 375);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAvailableSecurity;
        private System.Windows.Forms.ListBox lstSelectedSecurity;
        private System.Windows.Forms.ComboBox cmbPermissions;
        private System.Windows.Forms.Label lblPermissionType;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblAssigned;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnRemove;
    }
}
