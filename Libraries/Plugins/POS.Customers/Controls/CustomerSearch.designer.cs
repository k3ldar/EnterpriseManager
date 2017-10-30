namespace POS.Customers.Controls
{
    partial class CustomerSearchControl
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
            this.statusStripCustomer = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstUsers = new SharedControls.Classes.ListViewEx();
            this.colHeaderFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderEmailAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblName = new System.Windows.Forms.Label();
            this.lblTelephoneNumber = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cbFastSearch = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.statusStripCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripCustomer
            // 
            this.statusStripCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStripCustomer.Location = new System.Drawing.Point(0, 295);
            this.statusStripCustomer.Name = "statusStripCustomer";
            this.statusStripCustomer.Size = new System.Drawing.Size(896, 22);
            this.statusStripCustomer.SizingGrip = false;
            this.statusStripCustomer.TabIndex = 10;
            this.statusStripCustomer.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabelCount.Text = "0 Customers Found";
            // 
            // lstUsers
            // 
            this.lstUsers.AllowColumnReorder = true;
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderFirstName,
            this.colHeaderLastName,
            this.colHeaderEmailAddress,
            this.colHeaderCountry,
            this.colHeaderTelephone});
            this.lstUsers.FullRowSelect = true;
            this.lstUsers.Location = new System.Drawing.Point(9, 56);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.OwnerDraw = true;
            this.lstUsers.SaveName = "";
            this.lstUsers.ShowToolTip = false;
            this.lstUsers.Size = new System.Drawing.Size(884, 236);
            this.lstUsers.TabIndex = 9;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Details;
            this.lstUsers.DoubleClick += new System.EventHandler(this.lstUsers_DoubleClick);
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
            // colHeaderEmailAddress
            // 
            this.colHeaderEmailAddress.Text = "Email Address";
            this.colHeaderEmailAddress.Width = 245;
            // 
            // colHeaderCountry
            // 
            this.colHeaderCountry.DisplayIndex = 4;
            this.colHeaderCountry.Text = "Country";
            this.colHeaderCountry.Width = 203;
            // 
            // colHeaderTelephone
            // 
            this.colHeaderTelephone.DisplayIndex = 3;
            this.colHeaderTelephone.Text = "Telephone";
            this.colHeaderTelephone.Width = 137;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblTelephoneNumber
            // 
            this.lblTelephoneNumber.AutoSize = true;
            this.lblTelephoneNumber.Location = new System.Drawing.Point(467, 13);
            this.lblTelephoneNumber.Name = "lblTelephoneNumber";
            this.lblTelephoneNumber.Size = new System.Drawing.Size(58, 13);
            this.lblTelephoneNumber.TabIndex = 4;
            this.lblTelephoneNumber.Text = "Telephone";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(254, 13);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(73, 13);
            this.lblEmailAddress.TabIndex = 2;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(737, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(9, 30);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(470, 30);
            this.txtTelephone.MaxLength = 100;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(143, 20);
            this.txtTelephone.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(257, 31);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // cbFastSearch
            // 
            this.cbFastSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFastSearch.AutoSize = true;
            this.cbFastSearch.Checked = true;
            this.cbFastSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFastSearch.Location = new System.Drawing.Point(648, 33);
            this.cbFastSearch.Name = "cbFastSearch";
            this.cbFastSearch.Size = new System.Drawing.Size(83, 17);
            this.cbFastSearch.TabIndex = 6;
            this.cbFastSearch.Text = "Fast Search";
            this.cbFastSearch.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(818, 29);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // CustomerSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cbFastSearch);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.lblTelephoneNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.statusStripCustomer);
            this.Controls.Add(this.lstUsers);
            this.MinimumSize = new System.Drawing.Size(896, 317);
            this.Name = "CustomerSearchControl";
            this.Size = new System.Drawing.Size(896, 317);
            this.statusStripCustomer.ResumeLayout(false);
            this.statusStripCustomer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripCustomer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private SharedControls.Classes.ListViewEx lstUsers;
        private System.Windows.Forms.ColumnHeader colHeaderFirstName;
        private System.Windows.Forms.ColumnHeader colHeaderLastName;
        private System.Windows.Forms.ColumnHeader colHeaderEmailAddress;
        private System.Windows.Forms.ColumnHeader colHeaderCountry;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTelephoneNumber;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox cbFastSearch;
        private System.Windows.Forms.ColumnHeader colHeaderTelephone;
        private System.Windows.Forms.Button btnCreate;
    }
}