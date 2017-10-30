namespace Reports.Members
{
    partial class frmBirthdayReport
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
            this.lstCustomers = new SharedControls.Classes.ListViewEx();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAddressLine1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCounty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPostcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.rbCurrentMonth = new System.Windows.Forms.RadioButton();
            this.rbNextMonth = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.udRadius = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentPostCode = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCustomers
            // 
            this.lstCustomers.AllowColumnReorder = true;
            this.lstCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCustomers.CheckBoxes = true;
            this.lstCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chTelephone,
            this.chAddressLine1,
            this.chCity,
            this.chCounty,
            this.chPostcode});
            this.lstCustomers.Location = new System.Drawing.Point(12, 63);
            this.lstCustomers.MultiSelect = false;
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(626, 156);
            this.lstCustomers.TabIndex = 8;
            this.lstCustomers.UseCompatibleStateImageBehavior = false;
            this.lstCustomers.View = System.Windows.Forms.View.Details;
            this.lstCustomers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstCustomers_ItemChecked);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 161;
            // 
            // chTelephone
            // 
            this.chTelephone.Text = "Telephone";
            this.chTelephone.Width = 118;
            // 
            // chAddressLine1
            // 
            this.chAddressLine1.Text = "Address Line 1";
            this.chAddressLine1.Width = 124;
            // 
            // chCity
            // 
            this.chCity.Text = "City";
            this.chCity.Width = 109;
            // 
            // chCounty
            // 
            this.chCounty.Text = "County";
            this.chCounty.Width = 102;
            // 
            // chPostcode
            // 
            this.chPostcode.Text = "Post Code";
            this.chPostcode.Width = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create letters for customers who\'s birthday is in";
            // 
            // rbCurrentMonth
            // 
            this.rbCurrentMonth.AutoSize = true;
            this.rbCurrentMonth.Location = new System.Drawing.Point(245, 11);
            this.rbCurrentMonth.Name = "rbCurrentMonth";
            this.rbCurrentMonth.Size = new System.Drawing.Size(78, 17);
            this.rbCurrentMonth.TabIndex = 1;
            this.rbCurrentMonth.Text = "This Month";
            this.rbCurrentMonth.UseVisualStyleBackColor = true;
            // 
            // rbNextMonth
            // 
            this.rbNextMonth.AutoSize = true;
            this.rbNextMonth.Checked = true;
            this.rbNextMonth.Location = new System.Drawing.Point(350, 11);
            this.rbNextMonth.Name = "rbNextMonth";
            this.rbNextMonth.Size = new System.Drawing.Size(80, 17);
            this.rbNextMonth.TabIndex = 2;
            this.rbNextMonth.TabStop = true;
            this.rbNextMonth.Text = "Next Month";
            this.rbNextMonth.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Only for customers whose postcode is within ";
            // 
            // udRadius
            // 
            this.udRadius.Location = new System.Drawing.Point(240, 37);
            this.udRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRadius.Name = "udRadius";
            this.udRadius.Size = new System.Drawing.Size(83, 20);
            this.udRadius.TabIndex = 4;
            this.udRadius.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "km of postcode";
            // 
            // txtCurrentPostCode
            // 
            this.txtCurrentPostCode.Location = new System.Drawing.Point(425, 36);
            this.txtCurrentPostCode.Name = "txtCurrentPostCode";
            this.txtCurrentPostCode.Size = new System.Drawing.Size(108, 20);
            this.txtCurrentPostCode.TabIndex = 6;
            this.txtCurrentPostCode.Text = "TF11";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(542, 34);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(96, 23);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "View Customers";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(563, 225);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(15, 225);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(96, 13);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "No Users Selected";
            // 
            // frmBirthdayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 260);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtCurrentPostCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.udRadius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbNextMonth);
            this.Controls.Add(this.rbCurrentMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(666, 299);
            this.Name = "frmBirthdayReport";
            this.Text = "Birthday Report";
            ((System.ComponentModel.ISupportInitialize)(this.udRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lstCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbCurrentMonth;
        private System.Windows.Forms.RadioButton rbNextMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udRadius;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentPostCode;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chTelephone;
        private System.Windows.Forms.ColumnHeader chAddressLine1;
        private System.Windows.Forms.ColumnHeader chCity;
        private System.Windows.Forms.ColumnHeader chCounty;
        private System.Windows.Forms.ColumnHeader chPostcode;
        private System.Windows.Forms.Label lblCount;
    }
}