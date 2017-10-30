namespace POS.Base.Controls
{
    partial class OrderItem
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
            this.lblSKU = new System.Windows.Forms.Label();
            this.lblQuanity = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnNotSent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSKU
            // 
            this.lblSKU.AutoSize = true;
            this.lblSKU.Location = new System.Drawing.Point(3, 8);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.Size = new System.Drawing.Size(32, 13);
            this.lblSKU.TabIndex = 0;
            this.lblSKU.Text = "P999";
            // 
            // lblQuanity
            // 
            this.lblQuanity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuanity.AutoSize = true;
            this.lblQuanity.Location = new System.Drawing.Point(291, 8);
            this.lblQuanity.Name = "lblQuanity";
            this.lblQuanity.Size = new System.Drawing.Size(25, 13);
            this.lblQuanity.TabIndex = 2;
            this.lblQuanity.Text = "999";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(322, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Done";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProduct.Location = new System.Drawing.Point(51, 8);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(234, 20);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "label1";
            // 
            // btnNotSent
            // 
            this.btnNotSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotSent.Location = new System.Drawing.Point(409, 3);
            this.btnNotSent.Name = "btnNotSent";
            this.btnNotSent.Size = new System.Drawing.Size(84, 23);
            this.btnNotSent.TabIndex = 4;
            this.btnNotSent.Text = "Not Sent";
            this.btnNotSent.UseVisualStyleBackColor = true;
            this.btnNotSent.Click += new System.EventHandler(this.btnNotSent_Click);
            // 
            // OrderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnNotSent);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblQuanity);
            this.Controls.Add(this.lblSKU);
            this.Name = "OrderItem";
            this.Size = new System.Drawing.Size(496, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSKU;
        private System.Windows.Forms.Label lblQuanity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnNotSent;
    }
}
