namespace POS.Suppliers.Controls.Wizards.Products
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.lblMake = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.lblSKU = new System.Windows.Forms.Label();
            this.lblAssetType = new System.Windows.Forms.Label();
            this.cmbAssetType = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.udNetCost = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.udNetCost)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 21);
            this.txtName.MaxLength = 180;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(7, 64);
            this.txtMake.MaxLength = 150;
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(280, 20);
            this.txtMake.TabIndex = 5;
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(4, 47);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(35, 13);
            this.lblMake.TabIndex = 4;
            this.lblMake.Text = "label2";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(7, 107);
            this.txtModel.MaxLength = 150;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(280, 20);
            this.txtModel.TabIndex = 7;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(4, 90);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(35, 13);
            this.lblModel.TabIndex = 6;
            this.lblModel.Text = "label3";
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(7, 150);
            this.txtSKU.MaxLength = 70;
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(280, 20);
            this.txtSKU.TabIndex = 9;
            // 
            // lblSKU
            // 
            this.lblSKU.AutoSize = true;
            this.lblSKU.Location = new System.Drawing.Point(4, 133);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.Size = new System.Drawing.Size(35, 13);
            this.lblSKU.TabIndex = 8;
            this.lblSKU.Text = "label4";
            // 
            // lblAssetType
            // 
            this.lblAssetType.AutoSize = true;
            this.lblAssetType.Location = new System.Drawing.Point(4, 176);
            this.lblAssetType.Name = "lblAssetType";
            this.lblAssetType.Size = new System.Drawing.Size(35, 13);
            this.lblAssetType.TabIndex = 10;
            this.lblAssetType.Text = "label5";
            // 
            // cmbAssetType
            // 
            this.cmbAssetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssetType.FormattingEnabled = true;
            this.cmbAssetType.Location = new System.Drawing.Point(7, 192);
            this.cmbAssetType.Name = "cmbAssetType";
            this.cmbAssetType.Size = new System.Drawing.Size(193, 21);
            this.cmbAssetType.TabIndex = 11;
            this.cmbAssetType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbAssetType_Format);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(4, 219);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 12;
            this.lblNotes.Text = "label6";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(7, 236);
            this.txtNotes.MaxLength = 180;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(556, 117);
            this.txtNotes.TabIndex = 13;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(319, 4);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(35, 13);
            this.lblCost.TabIndex = 2;
            this.lblCost.Text = "label1";
            // 
            // udNetCost
            // 
            this.udNetCost.DecimalPlaces = 4;
            this.udNetCost.Location = new System.Drawing.Point(322, 21);
            this.udNetCost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.udNetCost.Name = "udNetCost";
            this.udNetCost.Size = new System.Drawing.Size(120, 20);
            this.udNetCost.TabIndex = 3;
            this.udNetCost.ValueChanged += new System.EventHandler(this.txtName_TextChanged);
            this.udNetCost.Enter += new System.EventHandler(this.udNetCost_Enter);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.udNetCost);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cmbAssetType);
            this.Controls.Add(this.lblAssetType);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.lblSKU);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.lblMake);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "Step1";
            ((System.ComponentModel.ISupportInitialize)(this.udNetCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label lblSKU;
        private System.Windows.Forms.Label lblAssetType;
        private System.Windows.Forms.ComboBox cmbAssetType;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.NumericUpDown udNetCost;
    }
}
