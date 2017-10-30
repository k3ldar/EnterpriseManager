namespace POS.Marketing.Controls
{
    partial class SelectProductControl
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
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.lblProductItem = new System.Windows.Forms.Label();
            this.cmbProductCost = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.DropDownWidth = 250;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(4, 27);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(160, 21);
            this.cmbProductType.TabIndex = 0;
            this.cmbProductType.SelectedIndexChanged += new System.EventHandler(this.cmbProductType_SelectedIndexChanged);
            this.cmbProductType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductType_Format);
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(4, 8);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 1;
            this.lblProductType.Text = "Product Type";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(167, 8);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(49, 13);
            this.lblProducts.TabIndex = 3;
            this.lblProducts.Text = "Products";
            // 
            // cmbProducts
            // 
            this.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducts.DropDownWidth = 400;
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(170, 27);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(219, 21);
            this.cmbProducts.TabIndex = 2;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            this.cmbProducts.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProducts_Format);
            // 
            // lblProductItem
            // 
            this.lblProductItem.AutoSize = true;
            this.lblProductItem.Location = new System.Drawing.Point(392, 8);
            this.lblProductItem.Name = "lblProductItem";
            this.lblProductItem.Size = new System.Drawing.Size(67, 13);
            this.lblProductItem.TabIndex = 5;
            this.lblProductItem.Text = "Product Item";
            // 
            // cmbProductCost
            // 
            this.cmbProductCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCost.DropDownWidth = 400;
            this.cmbProductCost.FormattingEnabled = true;
            this.cmbProductCost.Location = new System.Drawing.Point(395, 27);
            this.cmbProductCost.Name = "cmbProductCost";
            this.cmbProductCost.Size = new System.Drawing.Size(163, 21);
            this.cmbProductCost.TabIndex = 4;
            this.cmbProductCost.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductCost_Format);
            // 
            // SelectProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProductItem);
            this.Controls.Add(this.cmbProductCost);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.cmbProductType);
            this.Name = "SelectProductControl";
            this.Size = new System.Drawing.Size(558, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Label lblProductItem;
        private System.Windows.Forms.ComboBox cmbProductCost;
    }
}
