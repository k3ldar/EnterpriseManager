namespace POS.Administration.Forms.Products
{
    partial class AdminProductCostItemAdd
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblProductCostType = new System.Windows.Forms.Label();
            this.cmbProductCostType = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(253, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblProductCostType
            // 
            this.lblProductCostType.AutoSize = true;
            this.lblProductCostType.Location = new System.Drawing.Point(12, 55);
            this.lblProductCostType.Name = "lblProductCostType";
            this.lblProductCostType.Size = new System.Drawing.Size(35, 13);
            this.lblProductCostType.TabIndex = 2;
            this.lblProductCostType.Text = "label2";
            // 
            // cmbProductCostType
            // 
            this.cmbProductCostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCostType.FormattingEnabled = true;
            this.cmbProductCostType.Location = new System.Drawing.Point(12, 72);
            this.cmbProductCostType.Name = "cmbProductCostType";
            this.cmbProductCostType.Size = new System.Drawing.Size(253, 21);
            this.cmbProductCostType.TabIndex = 3;
            this.cmbProductCostType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbProductCostType_Format);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(190, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "button1";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(109, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AdminProductCostItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 160);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbProductCostType);
            this.Controls.Add(this.lblProductCostType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminProductCostItemAdd";
            this.ShowIcon = false;
            this.Text = "AdminProductCostItemAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblProductCostType;
        private System.Windows.Forms.ComboBox cmbProductCostType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}