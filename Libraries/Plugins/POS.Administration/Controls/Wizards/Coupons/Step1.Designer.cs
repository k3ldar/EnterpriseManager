namespace POS.Administration.Controls.Wizards.Coupons
{
    partial class Step1
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
            this.lblActive = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.dtpExpires = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblExpiresDateTime = new System.Windows.Forms.Label();
            this.lblCouponName = new System.Windows.Forms.Label();
            this.dtpStarts = new System.Windows.Forms.DateTimePicker();
            this.lblStartDateTime = new System.Windows.Forms.Label();
            this.lblFreePostage = new System.Windows.Forms.Label();
            this.numMaxUsage = new System.Windows.Forms.NumericUpDown();
            this.lblMaximumUsage = new System.Windows.Forms.Label();
            this.txtMinSpend = new System.Windows.Forms.TextBox();
            this.lblMinimumSpend = new System.Windows.Forms.Label();
            this.cbFreePostage = new System.Windows.Forms.CheckBox();
            this.cbRestrictUsage = new System.Windows.Forms.CheckBox();
            this.lblRestrictUsage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxUsage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(2, 134);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(37, 13);
            this.lblActive.TabIndex = 6;
            this.lblActive.Text = "Active";
            // 
            // cbActive
            // 
            this.cbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(126, 133);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 7;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // dtpExpires
            // 
            this.dtpExpires.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpExpires.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpires.Location = new System.Drawing.Point(126, 86);
            this.dtpExpires.Name = "dtpExpires";
            this.dtpExpires.Size = new System.Drawing.Size(200, 20);
            this.dtpExpires.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(126, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblExpiresDateTime
            // 
            this.lblExpiresDateTime.AutoSize = true;
            this.lblExpiresDateTime.Location = new System.Drawing.Point(2, 92);
            this.lblExpiresDateTime.Name = "lblExpiresDateTime";
            this.lblExpiresDateTime.Size = new System.Drawing.Size(41, 13);
            this.lblExpiresDateTime.TabIndex = 4;
            this.lblExpiresDateTime.Text = "Expires";
            // 
            // lblCouponName
            // 
            this.lblCouponName.AutoSize = true;
            this.lblCouponName.Location = new System.Drawing.Point(2, 6);
            this.lblCouponName.Name = "lblCouponName";
            this.lblCouponName.Size = new System.Drawing.Size(75, 13);
            this.lblCouponName.TabIndex = 0;
            this.lblCouponName.Text = "Coupon Name";
            // 
            // dtpStarts
            // 
            this.dtpStarts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStarts.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStarts.Location = new System.Drawing.Point(126, 50);
            this.dtpStarts.Name = "dtpStarts";
            this.dtpStarts.Size = new System.Drawing.Size(200, 20);
            this.dtpStarts.TabIndex = 3;
            // 
            // lblStartDateTime
            // 
            this.lblStartDateTime.AutoSize = true;
            this.lblStartDateTime.Location = new System.Drawing.Point(2, 56);
            this.lblStartDateTime.Name = "lblStartDateTime";
            this.lblStartDateTime.Size = new System.Drawing.Size(83, 13);
            this.lblStartDateTime.TabIndex = 2;
            this.lblStartDateTime.Text = "Start Date/Time";
            // 
            // lblFreePostage
            // 
            this.lblFreePostage.AutoSize = true;
            this.lblFreePostage.Location = new System.Drawing.Point(2, 174);
            this.lblFreePostage.Name = "lblFreePostage";
            this.lblFreePostage.Size = new System.Drawing.Size(70, 13);
            this.lblFreePostage.TabIndex = 8;
            this.lblFreePostage.Text = "Free Postage";
            // 
            // numMaxUsage
            // 
            this.numMaxUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaxUsage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxUsage.Location = new System.Drawing.Point(125, 266);
            this.numMaxUsage.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxUsage.Name = "numMaxUsage";
            this.numMaxUsage.Size = new System.Drawing.Size(120, 20);
            this.numMaxUsage.TabIndex = 13;
            this.numMaxUsage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaximumUsage
            // 
            this.lblMaximumUsage.AutoSize = true;
            this.lblMaximumUsage.Location = new System.Drawing.Point(2, 268);
            this.lblMaximumUsage.Name = "lblMaximumUsage";
            this.lblMaximumUsage.Size = new System.Drawing.Size(85, 13);
            this.lblMaximumUsage.TabIndex = 12;
            this.lblMaximumUsage.Text = "Maximum Usage";
            // 
            // txtMinSpend
            // 
            this.txtMinSpend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinSpend.Location = new System.Drawing.Point(126, 219);
            this.txtMinSpend.Name = "txtMinSpend";
            this.txtMinSpend.Size = new System.Drawing.Size(100, 20);
            this.txtMinSpend.TabIndex = 11;
            // 
            // lblMinimumSpend
            // 
            this.lblMinimumSpend.AutoSize = true;
            this.lblMinimumSpend.Location = new System.Drawing.Point(2, 222);
            this.lblMinimumSpend.Name = "lblMinimumSpend";
            this.lblMinimumSpend.Size = new System.Drawing.Size(82, 13);
            this.lblMinimumSpend.TabIndex = 10;
            this.lblMinimumSpend.Text = "Minimum Spend";
            // 
            // cbFreePostage
            // 
            this.cbFreePostage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFreePostage.AutoSize = true;
            this.cbFreePostage.Location = new System.Drawing.Point(127, 173);
            this.cbFreePostage.Name = "cbFreePostage";
            this.cbFreePostage.Size = new System.Drawing.Size(15, 14);
            this.cbFreePostage.TabIndex = 9;
            this.cbFreePostage.UseVisualStyleBackColor = true;
            // 
            // cbRestrictUsage
            // 
            this.cbRestrictUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRestrictUsage.AutoSize = true;
            this.cbRestrictUsage.Location = new System.Drawing.Point(127, 303);
            this.cbRestrictUsage.Name = "cbRestrictUsage";
            this.cbRestrictUsage.Size = new System.Drawing.Size(15, 14);
            this.cbRestrictUsage.TabIndex = 14;
            this.cbRestrictUsage.UseVisualStyleBackColor = true;
            // 
            // lblRestrictUsage
            // 
            this.lblRestrictUsage.AutoSize = true;
            this.lblRestrictUsage.Location = new System.Drawing.Point(2, 303);
            this.lblRestrictUsage.Name = "lblRestrictUsage";
            this.lblRestrictUsage.Size = new System.Drawing.Size(35, 13);
            this.lblRestrictUsage.TabIndex = 15;
            this.lblRestrictUsage.Text = "label1";
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRestrictUsage);
            this.Controls.Add(this.cbRestrictUsage);
            this.Controls.Add(this.lblFreePostage);
            this.Controls.Add(this.numMaxUsage);
            this.Controls.Add(this.lblMaximumUsage);
            this.Controls.Add(this.txtMinSpend);
            this.Controls.Add(this.lblMinimumSpend);
            this.Controls.Add(this.cbFreePostage);
            this.Controls.Add(this.dtpStarts);
            this.Controls.Add(this.lblStartDateTime);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.dtpExpires);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblExpiresDateTime);
            this.Controls.Add(this.lblCouponName);
            this.Name = "Step1";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxUsage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.DateTimePicker dtpExpires;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblExpiresDateTime;
        private System.Windows.Forms.Label lblCouponName;
        private System.Windows.Forms.DateTimePicker dtpStarts;
        private System.Windows.Forms.Label lblStartDateTime;
        private System.Windows.Forms.Label lblFreePostage;
        private System.Windows.Forms.NumericUpDown numMaxUsage;
        private System.Windows.Forms.Label lblMaximumUsage;
        private System.Windows.Forms.TextBox txtMinSpend;
        private System.Windows.Forms.Label lblMinimumSpend;
        private System.Windows.Forms.CheckBox cbFreePostage;
        private System.Windows.Forms.CheckBox cbRestrictUsage;
        private System.Windows.Forms.Label lblRestrictUsage;
    }
}
