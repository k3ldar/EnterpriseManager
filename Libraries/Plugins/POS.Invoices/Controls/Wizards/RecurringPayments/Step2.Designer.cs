namespace POS.Invoices.Controls.Wizards.RecurringPayments
{
    partial class Step2
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
            this.lstProducts = new SharedControls.Classes.ListViewEx();
            this.chQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // lstProducts
            // 
            this.lstProducts.AllowColumnReorder = true;
            this.lstProducts.CheckBoxes = true;
            this.lstProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQuantity,
            this.chProductType,
            this.chProductName,
            this.chProductSize,
            this.chSKU});
            this.lstProducts.HideSelection = false;
            this.lstProducts.LabelEdit = true;
            this.lstProducts.Location = new System.Drawing.Point(5, 32);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.OwnerDraw = true;
            this.lstProducts.SaveName = "Step3Coupons";
            this.lstProducts.ShowToolTip = false;
            this.lstProducts.Size = new System.Drawing.Size(557, 293);
            this.lstProducts.TabIndex = 5;
            this.lstProducts.UseCompatibleStateImageBehavior = false;
            this.lstProducts.View = System.Windows.Forms.View.Details;
            this.lstProducts.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstProducts_AfterLabelEdit);
            this.lstProducts.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstProducts_BeforeLabelEdit);
            // 
            // chQuantity
            // 
            this.chQuantity.Text = "Quantity";
            // 
            // chProductType
            // 
            this.chProductType.Text = "ProductType";
            this.chProductType.Width = 114;
            // 
            // chProductName
            // 
            this.chProductName.Text = "Product Name";
            this.chProductName.Width = 223;
            // 
            // chProductSize
            // 
            this.chProductSize.Text = "Size";
            this.chProductSize.Width = 150;
            // 
            // chSKU
            // 
            this.chSKU.Text = "SKU";
            this.chSKU.Width = 80;
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstProducts);
            this.Controls.Add(this.lblDescription);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ColumnHeader chSKU;
        private System.Windows.Forms.ColumnHeader chProductType;
        private System.Windows.Forms.ColumnHeader chProductName;
        private System.Windows.Forms.ColumnHeader chProductSize;
        private SharedControls.Classes.ListViewEx lstProducts;
        private System.Windows.Forms.ColumnHeader chQuantity;
    }
}
