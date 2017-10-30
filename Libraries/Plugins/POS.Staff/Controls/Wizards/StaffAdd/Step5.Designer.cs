namespace POS.Staff.Controls.Wizards.StaffAdd
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
            this.cmbMemberLevel = new System.Windows.Forms.ComboBox();
            this.lblMemberLevel = new System.Windows.Forms.Label();
            this.lblCopyPermissions = new System.Windows.Forms.Label();
            this.cmbPermissions = new System.Windows.Forms.ComboBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.cmbManager = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbMemberLevel
            // 
            this.cmbMemberLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemberLevel.FormattingEnabled = true;
            this.cmbMemberLevel.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbMemberLevel.Location = new System.Drawing.Point(3, 16);
            this.cmbMemberLevel.Name = "cmbMemberLevel";
            this.cmbMemberLevel.Size = new System.Drawing.Size(262, 21);
            this.cmbMemberLevel.TabIndex = 1;
            this.cmbMemberLevel.SelectedIndexChanged += new System.EventHandler(this.cmbMemberLevel_SelectedIndexChanged);
            this.cmbMemberLevel.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbMemberLevel_Format);
            // 
            // lblMemberLevel
            // 
            this.lblMemberLevel.AutoSize = true;
            this.lblMemberLevel.Location = new System.Drawing.Point(3, 0);
            this.lblMemberLevel.Name = "lblMemberLevel";
            this.lblMemberLevel.Size = new System.Drawing.Size(74, 13);
            this.lblMemberLevel.TabIndex = 0;
            this.lblMemberLevel.Text = "Member Level";
            // 
            // lblCopyPermissions
            // 
            this.lblCopyPermissions.AutoSize = true;
            this.lblCopyPermissions.Location = new System.Drawing.Point(3, 63);
            this.lblCopyPermissions.Name = "lblCopyPermissions";
            this.lblCopyPermissions.Size = new System.Drawing.Size(112, 13);
            this.lblCopyPermissions.TabIndex = 2;
            this.lblCopyPermissions.Text = "Copy Permissions from";
            // 
            // cmbPermissions
            // 
            this.cmbPermissions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPermissions.FormattingEnabled = true;
            this.cmbPermissions.Location = new System.Drawing.Point(3, 80);
            this.cmbPermissions.Name = "cmbPermissions";
            this.cmbPermissions.Size = new System.Drawing.Size(259, 21);
            this.cmbPermissions.TabIndex = 3;
            this.cmbPermissions.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbManager_Format);
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(3, 123);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(104, 13);
            this.lblManager.TabIndex = 4;
            this.lblManager.Text = "Manager/Supervisor";
            // 
            // cmbManager
            // 
            this.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManager.FormattingEnabled = true;
            this.cmbManager.Location = new System.Drawing.Point(3, 140);
            this.cmbManager.Name = "cmbManager";
            this.cmbManager.Size = new System.Drawing.Size(256, 21);
            this.cmbManager.TabIndex = 5;
            this.cmbManager.SelectedIndexChanged += new System.EventHandler(this.cmbMemberLevel_SelectedIndexChanged);
            this.cmbManager.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbManager_Format);
            // 
            // Step5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbManager);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.cmbPermissions);
            this.Controls.Add(this.lblCopyPermissions);
            this.Controls.Add(this.cmbMemberLevel);
            this.Controls.Add(this.lblMemberLevel);
            this.Name = "Step5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMemberLevel;
        private System.Windows.Forms.Label lblMemberLevel;
        private System.Windows.Forms.Label lblCopyPermissions;
        private System.Windows.Forms.ComboBox cmbPermissions;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.ComboBox cmbManager;
    }
}
