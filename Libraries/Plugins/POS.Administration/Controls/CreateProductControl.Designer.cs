namespace POS.Administration.Controls
{
    partial class CreateProductControl
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblPrimaryProduct = new System.Windows.Forms.Label();
            this.cmbPrimaryType = new System.Windows.Forms.ComboBox();
            this.lblPrimaryGroup = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(4, 15);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(118, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(258, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // lblPrimaryProduct
            // 
            this.lblPrimaryProduct.AutoSize = true;
            this.lblPrimaryProduct.Location = new System.Drawing.Point(3, 55);
            this.lblPrimaryProduct.Name = "lblPrimaryProduct";
            this.lblPrimaryProduct.Size = new System.Drawing.Size(81, 13);
            this.lblPrimaryProduct.TabIndex = 2;
            this.lblPrimaryProduct.Text = "Primary Product";
            // 
            // cmbPrimaryType
            // 
            this.cmbPrimaryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimaryType.FormattingEnabled = true;
            this.cmbPrimaryType.Location = new System.Drawing.Point(118, 52);
            this.cmbPrimaryType.Name = "cmbPrimaryType";
            this.cmbPrimaryType.Size = new System.Drawing.Size(258, 21);
            this.cmbPrimaryType.TabIndex = 3;
            // 
            // lblPrimaryGroup
            // 
            this.lblPrimaryGroup.AutoSize = true;
            this.lblPrimaryGroup.Location = new System.Drawing.Point(4, 90);
            this.lblPrimaryGroup.Name = "lblPrimaryGroup";
            this.lblPrimaryGroup.Size = new System.Drawing.Size(73, 13);
            this.lblPrimaryGroup.TabIndex = 4;
            this.lblPrimaryGroup.Text = "Primary Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(118, 87);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(258, 21);
            this.cmbGroup.TabIndex = 5;
            // 
            // CreateProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.lblPrimaryGroup);
            this.Controls.Add(this.cmbPrimaryType);
            this.Controls.Add(this.lblPrimaryProduct);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductName);
            this.Name = "CreateProductControl";
            this.Size = new System.Drawing.Size(387, 122);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblPrimaryProduct;
        private System.Windows.Forms.ComboBox cmbPrimaryType;
        private System.Windows.Forms.Label lblPrimaryGroup;
        private System.Windows.Forms.ComboBox cmbGroup;
    }
}
