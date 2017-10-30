namespace SieraDelta.POS.Administration.Forms.DiscountCoupons
{
    partial class AdminDiscountCouponEdit
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
            this.lblCouponName = new System.Windows.Forms.Label();
            this.lblExpires = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtpExpires = new System.Windows.Forms.DateTimePicker();
            this.spnDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountAmount2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMainProduct = new System.Windows.Forms.Label();
            this.cmbMainProduct = new System.Windows.Forms.ComboBox();
            this.cmbFreeProduct = new System.Windows.Forms.ComboBox();
            this.lblFreeProduct = new System.Windows.Forms.Label();
            this.cbFreePostage = new System.Windows.Forms.CheckBox();
            this.lblMinimumSpend = new System.Windows.Forms.Label();
            this.txtMinSpend = new System.Windows.Forms.TextBox();
            this.lblMaximumUsage = new System.Windows.Forms.Label();
            this.numMaxUsage = new System.Windows.Forms.NumericUpDown();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.lblVoucherType = new System.Windows.Forms.Label();
            this.cmbVoucherType = new System.Windows.Forms.ComboBox();
            this.lblFreePostage = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spnDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxUsage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCouponName
            // 
            this.lblCouponName.AutoSize = true;
            this.lblCouponName.Location = new System.Drawing.Point(16, 15);
            this.lblCouponName.Name = "lblCouponName";
            this.lblCouponName.Size = new System.Drawing.Size(75, 13);
            this.lblCouponName.TabIndex = 0;
            this.lblCouponName.Text = "Coupon Name";
            // 
            // lblExpires
            // 
            this.lblExpires.AutoSize = true;
            this.lblExpires.Location = new System.Drawing.Point(16, 44);
            this.lblExpires.Name = "lblExpires";
            this.lblExpires.Size = new System.Drawing.Size(41, 13);
            this.lblExpires.TabIndex = 2;
            this.lblExpires.Text = "Expires";
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Location = new System.Drawing.Point(16, 67);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(60, 13);
            this.lblDiscountAmount.TabIndex = 4;
            this.lblDiscountAmount.Text = "Discount %";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(140, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 20);
            this.txtName.TabIndex = 1;
            // 
            // dtpExpires
            // 
            this.dtpExpires.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpExpires.Location = new System.Drawing.Point(140, 38);
            this.dtpExpires.Name = "dtpExpires";
            this.dtpExpires.Size = new System.Drawing.Size(200, 20);
            this.dtpExpires.TabIndex = 3;
            // 
            // spnDiscount
            // 
            this.spnDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spnDiscount.Location = new System.Drawing.Point(140, 65);
            this.spnDiscount.Name = "spnDiscount";
            this.spnDiscount.Size = new System.Drawing.Size(72, 20);
            this.spnDiscount.TabIndex = 5;
            this.spnDiscount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDiscountAmount2
            // 
            this.lblDiscountAmount2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountAmount2.AutoSize = true;
            this.lblDiscountAmount2.Location = new System.Drawing.Point(218, 67);
            this.lblDiscountAmount2.Name = "lblDiscountAmount2";
            this.lblDiscountAmount2.Size = new System.Drawing.Size(15, 13);
            this.lblDiscountAmount2.TabIndex = 6;
            this.lblDiscountAmount2.Text = "%";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(308, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(227, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblMainProduct
            // 
            this.lblMainProduct.AutoSize = true;
            this.lblMainProduct.Location = new System.Drawing.Point(16, 95);
            this.lblMainProduct.Name = "lblMainProduct";
            this.lblMainProduct.Size = new System.Drawing.Size(70, 13);
            this.lblMainProduct.TabIndex = 7;
            this.lblMainProduct.Text = "Main Product";
            // 
            // cmbMainProduct
            // 
            this.cmbMainProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMainProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainProduct.FormattingEnabled = true;
            this.cmbMainProduct.Location = new System.Drawing.Point(140, 92);
            this.cmbMainProduct.Name = "cmbMainProduct";
            this.cmbMainProduct.Size = new System.Drawing.Size(243, 21);
            this.cmbMainProduct.TabIndex = 8;
            this.cmbMainProduct.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbMainProduct_Format);
            // 
            // cmbFreeProduct
            // 
            this.cmbFreeProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFreeProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFreeProduct.FormattingEnabled = true;
            this.cmbFreeProduct.Location = new System.Drawing.Point(140, 119);
            this.cmbFreeProduct.Name = "cmbFreeProduct";
            this.cmbFreeProduct.Size = new System.Drawing.Size(243, 21);
            this.cmbFreeProduct.TabIndex = 10;
            this.cmbFreeProduct.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbFreeProduct_Format);
            // 
            // lblFreeProduct
            // 
            this.lblFreeProduct.AutoSize = true;
            this.lblFreeProduct.Location = new System.Drawing.Point(16, 122);
            this.lblFreeProduct.Name = "lblFreeProduct";
            this.lblFreeProduct.Size = new System.Drawing.Size(68, 13);
            this.lblFreeProduct.TabIndex = 9;
            this.lblFreeProduct.Text = "Free Product";
            // 
            // cbFreePostage
            // 
            this.cbFreePostage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFreePostage.AutoSize = true;
            this.cbFreePostage.Location = new System.Drawing.Point(140, 150);
            this.cbFreePostage.Name = "cbFreePostage";
            this.cbFreePostage.Size = new System.Drawing.Size(15, 14);
            this.cbFreePostage.TabIndex = 12;
            this.cbFreePostage.UseVisualStyleBackColor = true;
            // 
            // lblMinimumSpend
            // 
            this.lblMinimumSpend.AutoSize = true;
            this.lblMinimumSpend.Location = new System.Drawing.Point(16, 199);
            this.lblMinimumSpend.Name = "lblMinimumSpend";
            this.lblMinimumSpend.Size = new System.Drawing.Size(82, 13);
            this.lblMinimumSpend.TabIndex = 15;
            this.lblMinimumSpend.Text = "Minimum Spend";
            // 
            // txtMinSpend
            // 
            this.txtMinSpend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinSpend.Location = new System.Drawing.Point(139, 196);
            this.txtMinSpend.Name = "txtMinSpend";
            this.txtMinSpend.Size = new System.Drawing.Size(100, 20);
            this.txtMinSpend.TabIndex = 16;
            // 
            // lblMaximumUsage
            // 
            this.lblMaximumUsage.AutoSize = true;
            this.lblMaximumUsage.Location = new System.Drawing.Point(16, 224);
            this.lblMaximumUsage.Name = "lblMaximumUsage";
            this.lblMaximumUsage.Size = new System.Drawing.Size(85, 13);
            this.lblMaximumUsage.TabIndex = 17;
            this.lblMaximumUsage.Text = "Maximum Usage";
            // 
            // numMaxUsage
            // 
            this.numMaxUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaxUsage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxUsage.Location = new System.Drawing.Point(139, 222);
            this.numMaxUsage.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxUsage.Name = "numMaxUsage";
            this.numMaxUsage.Size = new System.Drawing.Size(120, 20);
            this.numMaxUsage.TabIndex = 18;
            this.numMaxUsage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbActive
            // 
            this.cbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(140, 173);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 14;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // lblVoucherType
            // 
            this.lblVoucherType.AutoSize = true;
            this.lblVoucherType.Location = new System.Drawing.Point(16, 251);
            this.lblVoucherType.Name = "lblVoucherType";
            this.lblVoucherType.Size = new System.Drawing.Size(74, 13);
            this.lblVoucherType.TabIndex = 19;
            this.lblVoucherType.Text = "Voucher Type";
            // 
            // cmbVoucherType
            // 
            this.cmbVoucherType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoucherType.FormattingEnabled = true;
            this.cmbVoucherType.Location = new System.Drawing.Point(139, 248);
            this.cmbVoucherType.Name = "cmbVoucherType";
            this.cmbVoucherType.Size = new System.Drawing.Size(121, 21);
            this.cmbVoucherType.TabIndex = 20;
            this.cmbVoucherType.SelectedIndexChanged += new System.EventHandler(this.cmbVoucherType_SelectedIndexChanged);
            // 
            // lblFreePostage
            // 
            this.lblFreePostage.AutoSize = true;
            this.lblFreePostage.Location = new System.Drawing.Point(16, 151);
            this.lblFreePostage.Name = "lblFreePostage";
            this.lblFreePostage.Size = new System.Drawing.Size(70, 13);
            this.lblFreePostage.TabIndex = 11;
            this.lblFreePostage.Text = "Free Postage";
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(16, 174);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(37, 13);
            this.lblActive.TabIndex = 13;
            this.lblActive.Text = "Active";
            // 
            // AdminDiscountCouponEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 336);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.lblFreePostage);
            this.Controls.Add(this.cmbVoucherType);
            this.Controls.Add(this.lblVoucherType);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.numMaxUsage);
            this.Controls.Add(this.lblMaximumUsage);
            this.Controls.Add(this.txtMinSpend);
            this.Controls.Add(this.lblMinimumSpend);
            this.Controls.Add(this.cbFreePostage);
            this.Controls.Add(this.cmbFreeProduct);
            this.Controls.Add(this.lblFreeProduct);
            this.Controls.Add(this.cmbMainProduct);
            this.Controls.Add(this.lblMainProduct);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDiscountAmount2);
            this.Controls.Add(this.spnDiscount);
            this.Controls.Add(this.dtpExpires);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDiscountAmount);
            this.Controls.Add(this.lblExpires);
            this.Controls.Add(this.lblCouponName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 374);
            this.Name = "AdminDiscountCouponEdit";
            this.SaveState = true;
            this.Text = "Administration - Discount Coupon Edit";
            ((System.ComponentModel.ISupportInitialize)(this.spnDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxUsage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCouponName;
        private System.Windows.Forms.Label lblExpires;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpExpires;
        private System.Windows.Forms.NumericUpDown spnDiscount;
        private System.Windows.Forms.Label lblDiscountAmount2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMainProduct;
        private System.Windows.Forms.ComboBox cmbMainProduct;
        private System.Windows.Forms.ComboBox cmbFreeProduct;
        private System.Windows.Forms.Label lblFreeProduct;
        private System.Windows.Forms.CheckBox cbFreePostage;
        private System.Windows.Forms.Label lblMinimumSpend;
        private System.Windows.Forms.TextBox txtMinSpend;
        private System.Windows.Forms.Label lblMaximumUsage;
        private System.Windows.Forms.NumericUpDown numMaxUsage;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label lblVoucherType;
        private System.Windows.Forms.ComboBox cmbVoucherType;
        private System.Windows.Forms.Label lblFreePostage;
        private System.Windows.Forms.Label lblActive;
    }
}