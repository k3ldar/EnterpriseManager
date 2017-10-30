namespace POS.WebsiteAdministration.Forms.Salons
{
    partial class AdminSalonToUser
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.cmbSalons = new System.Windows.Forms.ComboBox();
            this.lblSalons = new System.Windows.Forms.Label();
            this.pnlSalonUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.cbUnassigned = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(675, 227);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(276, 227);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(250, 21);
            this.cmbUsers.TabIndex = 4;
            this.cmbUsers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbUsers_Format);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(273, 210);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(34, 13);
            this.lblUsers.TabIndex = 3;
            this.lblUsers.Text = "Users";
            // 
            // cmbSalons
            // 
            this.cmbSalons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalons.FormattingEnabled = true;
            this.cmbSalons.Location = new System.Drawing.Point(13, 229);
            this.cmbSalons.Name = "cmbSalons";
            this.cmbSalons.Size = new System.Drawing.Size(257, 21);
            this.cmbSalons.TabIndex = 2;
            this.cmbSalons.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbSalons_Format);
            // 
            // lblSalons
            // 
            this.lblSalons.AutoSize = true;
            this.lblSalons.Location = new System.Drawing.Point(13, 212);
            this.lblSalons.Name = "lblSalons";
            this.lblSalons.Size = new System.Drawing.Size(39, 13);
            this.lblSalons.TabIndex = 1;
            this.lblSalons.Text = "Salons";
            // 
            // pnlSalonUsers
            // 
            this.pnlSalonUsers.AutoScroll = true;
            this.pnlSalonUsers.Location = new System.Drawing.Point(13, 13);
            this.pnlSalonUsers.Name = "pnlSalonUsers";
            this.pnlSalonUsers.Size = new System.Drawing.Size(737, 196);
            this.pnlSalonUsers.TabIndex = 0;
            // 
            // cbUnassigned
            // 
            this.cbUnassigned.AutoSize = true;
            this.cbUnassigned.Checked = true;
            this.cbUnassigned.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUnassigned.Location = new System.Drawing.Point(532, 229);
            this.cbUnassigned.Name = "cbUnassigned";
            this.cbUnassigned.Size = new System.Drawing.Size(117, 17);
            this.cbUnassigned.TabIndex = 6;
            this.cbUnassigned.Text = "Unassigned Salons";
            this.cbUnassigned.UseVisualStyleBackColor = true;
            this.cbUnassigned.CheckedChanged += new System.EventHandler(this.cbUnassigned_CheckedChanged);
            // 
            // AdminSalonToUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 261);
            this.Controls.Add(this.cbUnassigned);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.cmbSalons);
            this.Controls.Add(this.lblSalons);
            this.Controls.Add(this.pnlSalonUsers);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(778, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(778, 300);
            this.Name = "AdminSalonToUser";
            this.SaveState = true;
            this.Text = "Salon To Salon Owner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlSalonUsers;
        private System.Windows.Forms.Label lblSalons;
        private System.Windows.Forms.ComboBox cmbSalons;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox cbUnassigned;

    }
}