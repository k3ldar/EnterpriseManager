namespace SieraDelta.POS.Administration.Forms.Staff
{
    partial class AdminStaff
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstStaff = new SieraDelta.Controls.Classes.ListViewEx();
            this.colHeaderFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 212);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabelCount.Text = "0 Staff Found";
            // 
            // lstStaff
            // 
            this.lstStaff.AllowColumnReorder = true;
            this.lstStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStaff.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderFirstName,
            this.colHeaderLastName,
            this.colHeaderEmail});
            this.lstStaff.FullRowSelect = true;
            this.lstStaff.Location = new System.Drawing.Point(9, 56);
            this.lstStaff.MultiSelect = false;
            this.lstStaff.Name = "lstStaff";
            this.lstStaff.OwnerDraw = true;
            this.lstStaff.ShowToolTip = false;
            this.lstStaff.Size = new System.Drawing.Size(709, 143);
            this.lstStaff.TabIndex = 26;
            this.lstStaff.UseCompatibleStateImageBehavior = false;
            this.lstStaff.View = System.Windows.Forms.View.Details;
            this.lstStaff.DoubleClick += new System.EventHandler(this.lstUsers_DoubleClick);
            // 
            // colHeaderFirstName
            // 
            this.colHeaderFirstName.Text = "First Name";
            this.colHeaderFirstName.Width = 147;
            // 
            // colHeaderLastName
            // 
            this.colHeaderLastName.Text = "Last Name";
            this.colHeaderLastName.Width = 148;
            // 
            // colHeaderEmail
            // 
            this.colHeaderEmail.Text = "Email Address";
            this.colHeaderEmail.Width = 245;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(6, 13);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 28;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(198, 13);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 29;
            this.lblLastName.Text = "Last Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(409, 12);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(73, 13);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Email Address";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(643, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(9, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(181, 20);
            this.txtFirstName.TabIndex = 32;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(201, 30);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(199, 20);
            this.txtLastName.TabIndex = 33;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(412, 30);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 20);
            this.txtEmail.TabIndex = 34;
            // 
            // AdminStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 234);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstStaff);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminStaff";
            this.SaveState = true;
            this.Text = "Administration -Staff";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private SieraDelta.Controls.Classes.ListViewEx lstStaff;
        private System.Windows.Forms.ColumnHeader colHeaderFirstName;
        private System.Windows.Forms.ColumnHeader colHeaderLastName;
        private System.Windows.Forms.ColumnHeader colHeaderEmail;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
    }
}