namespace POS.Administration.Controls
{
    partial class ProductVerificationSettings
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
            this.txtGiftWrapMax = new System.Windows.Forms.TextBox();
            this.txtGiftWrapMin = new System.Windows.Forms.TextBox();
            this.lblGiftWrapMax = new System.Windows.Forms.Label();
            this.lblGiftWrapMin = new System.Windows.Forms.Label();
            this.cbVerifyGiftWrap = new System.Windows.Forms.CheckBox();
            this.cbVerifyFeaturedProduct = new System.Windows.Forms.CheckBox();
            this.cbVerifyCarousel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtGiftWrapMax
            // 
            this.txtGiftWrapMax.Location = new System.Drawing.Point(120, 88);
            this.txtGiftWrapMax.Name = "txtGiftWrapMax";
            this.txtGiftWrapMax.Size = new System.Drawing.Size(69, 20);
            this.txtGiftWrapMax.TabIndex = 11;
            // 
            // txtGiftWrapMin
            // 
            this.txtGiftWrapMin.Location = new System.Drawing.Point(120, 60);
            this.txtGiftWrapMin.Name = "txtGiftWrapMin";
            this.txtGiftWrapMin.Size = new System.Drawing.Size(69, 20);
            this.txtGiftWrapMin.TabIndex = 10;
            // 
            // lblGiftWrapMax
            // 
            this.lblGiftWrapMax.AutoSize = true;
            this.lblGiftWrapMax.Location = new System.Drawing.Point(21, 91);
            this.lblGiftWrapMax.Name = "lblGiftWrapMax";
            this.lblGiftWrapMax.Size = new System.Drawing.Size(78, 13);
            this.lblGiftWrapMax.TabIndex = 9;
            this.lblGiftWrapMax.Text = "Maximum Price";
            // 
            // lblGiftWrapMin
            // 
            this.lblGiftWrapMin.AutoSize = true;
            this.lblGiftWrapMin.Location = new System.Drawing.Point(21, 63);
            this.lblGiftWrapMin.Name = "lblGiftWrapMin";
            this.lblGiftWrapMin.Size = new System.Drawing.Size(75, 13);
            this.lblGiftWrapMin.TabIndex = 8;
            this.lblGiftWrapMin.Text = "Minimum Price";
            // 
            // cbVerifyGiftWrap
            // 
            this.cbVerifyGiftWrap.AutoSize = true;
            this.cbVerifyGiftWrap.Location = new System.Drawing.Point(4, 39);
            this.cbVerifyGiftWrap.Name = "cbVerifyGiftWrap";
            this.cbVerifyGiftWrap.Size = new System.Drawing.Size(168, 17);
            this.cbVerifyGiftWrap.TabIndex = 7;
            this.cbVerifyGiftWrap.Text = "Verify Gift Wrap product exists";
            this.cbVerifyGiftWrap.UseVisualStyleBackColor = true;
            this.cbVerifyGiftWrap.CheckedChanged += new System.EventHandler(this.cbVerifyGiftWrap_CheckedChanged);
            // 
            // cbVerifyFeaturedProduct
            // 
            this.cbVerifyFeaturedProduct.AutoSize = true;
            this.cbVerifyFeaturedProduct.Location = new System.Drawing.Point(4, 3);
            this.cbVerifyFeaturedProduct.Name = "cbVerifyFeaturedProduct";
            this.cbVerifyFeaturedProduct.Size = new System.Drawing.Size(167, 17);
            this.cbVerifyFeaturedProduct.TabIndex = 6;
            this.cbVerifyFeaturedProduct.Text = "Verify Featured Product Exists";
            this.cbVerifyFeaturedProduct.UseVisualStyleBackColor = true;
            // 
            // cbVerifyCarousel
            // 
            this.cbVerifyCarousel.AutoSize = true;
            this.cbVerifyCarousel.Location = new System.Drawing.Point(4, 122);
            this.cbVerifyCarousel.Name = "cbVerifyCarousel";
            this.cbVerifyCarousel.Size = new System.Drawing.Size(80, 17);
            this.cbVerifyCarousel.TabIndex = 12;
            this.cbVerifyCarousel.Text = "checkBox1";
            this.cbVerifyCarousel.UseVisualStyleBackColor = true;
            // 
            // ProductVerificationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbVerifyCarousel);
            this.Controls.Add(this.txtGiftWrapMax);
            this.Controls.Add(this.txtGiftWrapMin);
            this.Controls.Add(this.lblGiftWrapMax);
            this.Controls.Add(this.lblGiftWrapMin);
            this.Controls.Add(this.cbVerifyGiftWrap);
            this.Controls.Add(this.cbVerifyFeaturedProduct);
            this.Name = "ProductVerificationSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGiftWrapMax;
        private System.Windows.Forms.TextBox txtGiftWrapMin;
        private System.Windows.Forms.Label lblGiftWrapMax;
        private System.Windows.Forms.Label lblGiftWrapMin;
        private System.Windows.Forms.CheckBox cbVerifyGiftWrap;
        private System.Windows.Forms.CheckBox cbVerifyFeaturedProduct;
        private System.Windows.Forms.CheckBox cbVerifyCarousel;
    }
}
