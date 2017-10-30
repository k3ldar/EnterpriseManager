namespace POS.Administration.Controls
{
    partial class AdminProductItemEdit
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbMemberLevel = new System.Windows.Forms.ComboBox();
            this.lblOutOfStock = new System.Windows.Forms.Label();
            this.lblMemberLevel = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblPrice1 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.cbOutOfStock = new System.Windows.Forms.CheckBox();
            this.txtCost1 = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.lblGiftWrap = new System.Windows.Forms.Label();
            this.cbGiftWrap = new System.Windows.Forms.CheckBox();
            this.lblPrice2 = new System.Windows.Forms.Label();
            this.txtCost2 = new System.Windows.Forms.TextBox();
            this.txtCost3 = new System.Windows.Forms.TextBox();
            this.lblPrice3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscount = new SharedControls.TextBoxEx();
            this.lblSaving = new System.Windows.Forms.Label();
            this.udSaving = new System.Windows.Forms.NumericUpDown();
            this.btnCost1Calculate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udSaving)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.Location = new System.Drawing.Point(3, 292);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(411, 63);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "lblDescription";
            // 
            // cmbMemberLevel
            // 
            this.cmbMemberLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemberLevel.FormattingEnabled = true;
            this.cmbMemberLevel.Location = new System.Drawing.Point(132, 161);
            this.cmbMemberLevel.Name = "cmbMemberLevel";
            this.cmbMemberLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbMemberLevel.TabIndex = 13;
            // 
            // lblOutOfStock
            // 
            this.lblOutOfStock.AutoSize = true;
            this.lblOutOfStock.Location = new System.Drawing.Point(3, 187);
            this.lblOutOfStock.Name = "lblOutOfStock";
            this.lblOutOfStock.Size = new System.Drawing.Size(65, 13);
            this.lblOutOfStock.TabIndex = 14;
            this.lblOutOfStock.Text = "Out of stock";
            // 
            // lblMemberLevel
            // 
            this.lblMemberLevel.AutoSize = true;
            this.lblMemberLevel.Location = new System.Drawing.Point(3, 163);
            this.lblMemberLevel.Name = "lblMemberLevel";
            this.lblMemberLevel.Size = new System.Drawing.Size(74, 13);
            this.lblMemberLevel.TabIndex = 12;
            this.lblMemberLevel.Text = "Member Level";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(3, 137);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 10;
            this.lblProductType.Text = "Product Type";
            // 
            // lblPrice1
            // 
            this.lblPrice1.AutoSize = true;
            this.lblPrice1.Location = new System.Drawing.Point(3, 59);
            this.lblPrice1.Name = "lblPrice1";
            this.lblPrice1.Size = new System.Drawing.Size(40, 13);
            this.lblPrice1.TabIndex = 4;
            this.lblPrice1.Text = "Price 1";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(3, 33);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(85, 13);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Size/Description";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(3, 7);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(72, 13);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "Product Code";
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(132, 134);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(295, 21);
            this.cmbProductType.TabIndex = 11;
            this.cmbProductType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductType_Format);
            // 
            // cbOutOfStock
            // 
            this.cbOutOfStock.AutoSize = true;
            this.cbOutOfStock.Location = new System.Drawing.Point(132, 187);
            this.cbOutOfStock.Name = "cbOutOfStock";
            this.cbOutOfStock.Size = new System.Drawing.Size(15, 14);
            this.cbOutOfStock.TabIndex = 15;
            this.cbOutOfStock.UseVisualStyleBackColor = true;
            // 
            // txtCost1
            // 
            this.txtCost1.Location = new System.Drawing.Point(132, 56);
            this.txtCost1.MaxLength = 10;
            this.txtCost1.Name = "txtCost1";
            this.txtCost1.Size = new System.Drawing.Size(65, 20);
            this.txtCost1.TabIndex = 5;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(132, 30);
            this.txtSize.MaxLength = 60;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(295, 20);
            this.txtSize.TabIndex = 3;
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(132, 4);
            this.txtSKU.MaxLength = 10;
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(77, 20);
            this.txtSKU.TabIndex = 1;
            // 
            // lblGiftWrap
            // 
            this.lblGiftWrap.AutoSize = true;
            this.lblGiftWrap.Location = new System.Drawing.Point(3, 214);
            this.lblGiftWrap.Name = "lblGiftWrap";
            this.lblGiftWrap.Size = new System.Drawing.Size(52, 13);
            this.lblGiftWrap.TabIndex = 16;
            this.lblGiftWrap.Text = "Gift Wrap";
            // 
            // cbGiftWrap
            // 
            this.cbGiftWrap.AutoSize = true;
            this.cbGiftWrap.Location = new System.Drawing.Point(132, 214);
            this.cbGiftWrap.Name = "cbGiftWrap";
            this.cbGiftWrap.Size = new System.Drawing.Size(15, 14);
            this.cbGiftWrap.TabIndex = 17;
            this.cbGiftWrap.UseVisualStyleBackColor = true;
            // 
            // lblPrice2
            // 
            this.lblPrice2.AutoSize = true;
            this.lblPrice2.Location = new System.Drawing.Point(3, 85);
            this.lblPrice2.Name = "lblPrice2";
            this.lblPrice2.Size = new System.Drawing.Size(40, 13);
            this.lblPrice2.TabIndex = 6;
            this.lblPrice2.Text = "Price 2";
            // 
            // txtCost2
            // 
            this.txtCost2.Location = new System.Drawing.Point(132, 82);
            this.txtCost2.Name = "txtCost2";
            this.txtCost2.Size = new System.Drawing.Size(65, 20);
            this.txtCost2.TabIndex = 7;
            // 
            // txtCost3
            // 
            this.txtCost3.Location = new System.Drawing.Point(132, 108);
            this.txtCost3.Name = "txtCost3";
            this.txtCost3.Size = new System.Drawing.Size(65, 20);
            this.txtCost3.TabIndex = 9;
            // 
            // lblPrice3
            // 
            this.lblPrice3.AutoSize = true;
            this.lblPrice3.Location = new System.Drawing.Point(3, 111);
            this.lblPrice3.Name = "lblPrice3";
            this.lblPrice3.Size = new System.Drawing.Size(40, 13);
            this.lblPrice3.TabIndex = 8;
            this.lblPrice3.Text = "Price 3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Discount %";
            // 
            // txtDiscount
            // 
            this.txtDiscount.AllowBackSpace = true;
            this.txtDiscount.AllowCopy = true;
            this.txtDiscount.AllowCut = true;
            this.txtDiscount.AllowedCharacters = "0123456789";
            this.txtDiscount.AllowPaste = true;
            this.txtDiscount.Location = new System.Drawing.Point(132, 236);
            this.txtDiscount.MaxLength = 3;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(65, 20);
            this.txtDiscount.TabIndex = 19;
            // 
            // lblSaving
            // 
            this.lblSaving.AutoSize = true;
            this.lblSaving.Location = new System.Drawing.Point(3, 266);
            this.lblSaving.Name = "lblSaving";
            this.lblSaving.Size = new System.Drawing.Size(43, 13);
            this.lblSaving.TabIndex = 20;
            this.lblSaving.Text = "Saving ";
            // 
            // udSaving
            // 
            this.udSaving.DecimalPlaces = 2;
            this.udSaving.Location = new System.Drawing.Point(132, 264);
            this.udSaving.Name = "udSaving";
            this.udSaving.Size = new System.Drawing.Size(93, 20);
            this.udSaving.TabIndex = 21;
            // 
            // btnCost1Calculate
            // 
            this.btnCost1Calculate.Location = new System.Drawing.Point(203, 55);
            this.btnCost1Calculate.Name = "btnCost1Calculate";
            this.btnCost1Calculate.Size = new System.Drawing.Size(29, 23);
            this.btnCost1Calculate.TabIndex = 23;
            this.btnCost1Calculate.Text = "...";
            this.btnCost1Calculate.UseVisualStyleBackColor = true;
            this.btnCost1Calculate.Click += new System.EventHandler(this.btnCost1Calculate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdminProductItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCost1Calculate);
            this.Controls.Add(this.udSaving);
            this.Controls.Add(this.lblSaving);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCost3);
            this.Controls.Add(this.lblPrice3);
            this.Controls.Add(this.txtCost2);
            this.Controls.Add(this.lblPrice2);
            this.Controls.Add(this.cbGiftWrap);
            this.Controls.Add(this.lblGiftWrap);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbMemberLevel);
            this.Controls.Add(this.lblOutOfStock);
            this.Controls.Add(this.lblMemberLevel);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.lblPrice1);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.cmbProductType);
            this.Controls.Add(this.cbOutOfStock);
            this.Controls.Add(this.txtCost1);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtSKU);
            this.Name = "AdminProductItemEdit";
            this.Size = new System.Drawing.Size(427, 355);
            ((System.ComponentModel.ISupportInitialize)(this.udSaving)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.CheckBox cbOutOfStock;
        private System.Windows.Forms.TextBox txtCost1;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblPrice1;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblMemberLevel;
        private System.Windows.Forms.Label lblOutOfStock;
        private System.Windows.Forms.ComboBox cmbMemberLevel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblGiftWrap;
        private System.Windows.Forms.CheckBox cbGiftWrap;
        private System.Windows.Forms.Label lblPrice2;
        private System.Windows.Forms.TextBox txtCost2;
        private System.Windows.Forms.TextBox txtCost3;
        private System.Windows.Forms.Label lblPrice3;
        private System.Windows.Forms.Label label1;
        private SharedControls.TextBoxEx txtDiscount;
        private System.Windows.Forms.Label lblSaving;
        private System.Windows.Forms.NumericUpDown udSaving;
        private System.Windows.Forms.Button btnCost1Calculate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
