namespace POS.Administration.Controls.Wizards.Coupons
{
    partial class Step4
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
            this.cmbFreeProduct = new System.Windows.Forms.ComboBox();
            this.lblFreeProduct = new System.Windows.Forms.Label();
            this.cbFreeProduct = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbFreeProduct
            // 
            this.cmbFreeProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFreeProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFreeProduct.FormattingEnabled = true;
            this.cmbFreeProduct.Location = new System.Drawing.Point(129, 54);
            this.cmbFreeProduct.Name = "cmbFreeProduct";
            this.cmbFreeProduct.Size = new System.Drawing.Size(434, 21);
            this.cmbFreeProduct.TabIndex = 32;
            this.cmbFreeProduct.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbFreeProduct_Format);
            // 
            // lblFreeProduct
            // 
            this.lblFreeProduct.AutoSize = true;
            this.lblFreeProduct.Location = new System.Drawing.Point(5, 57);
            this.lblFreeProduct.Name = "lblFreeProduct";
            this.lblFreeProduct.Size = new System.Drawing.Size(68, 13);
            this.lblFreeProduct.TabIndex = 31;
            this.lblFreeProduct.Text = "Free Product";
            // 
            // cbFreeProduct
            // 
            this.cbFreeProduct.AutoSize = true;
            this.cbFreeProduct.Location = new System.Drawing.Point(8, 4);
            this.cbFreeProduct.Name = "cbFreeProduct";
            this.cbFreeProduct.Size = new System.Drawing.Size(277, 17);
            this.cbFreeProduct.TabIndex = 33;
            this.cbFreeProduct.Text = "Does this coupon provide a free product when used?";
            this.cbFreeProduct.UseVisualStyleBackColor = true;
            this.cbFreeProduct.CheckedChanged += new System.EventHandler(this.cbFreeProduct_CheckedChanged);
            // 
            // Step4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbFreeProduct);
            this.Controls.Add(this.cmbFreeProduct);
            this.Controls.Add(this.lblFreeProduct);
            this.Name = "Step4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFreeProduct;
        private System.Windows.Forms.Label lblFreeProduct;
        private System.Windows.Forms.CheckBox cbFreeProduct;
    }
}
