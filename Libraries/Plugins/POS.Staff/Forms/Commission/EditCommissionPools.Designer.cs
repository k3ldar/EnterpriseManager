namespace POS.Staff.Forms
{
    partial class EditCommissionPools
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
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCommissionRate = new System.Windows.Forms.Label();
            this.udCommissionRate = new System.Windows.Forms.NumericUpDown();
            this.lblPaymentTypes = new System.Windows.Forms.Label();
            this.lstPaymentTypes = new System.Windows.Forms.CheckedListBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.udCommissionRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(12, 45);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(240, 251);
            this.lstItems.TabIndex = 14;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            this.lstItems.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstItems_Format);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(259, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "label1";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(262, 60);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(281, 20);
            this.txtName.TabIndex = 16;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblCommissionRate
            // 
            this.lblCommissionRate.AutoSize = true;
            this.lblCommissionRate.Location = new System.Drawing.Point(262, 97);
            this.lblCommissionRate.Name = "lblCommissionRate";
            this.lblCommissionRate.Size = new System.Drawing.Size(35, 13);
            this.lblCommissionRate.TabIndex = 17;
            this.lblCommissionRate.Text = "label2";
            // 
            // udCommissionRate
            // 
            this.udCommissionRate.DecimalPlaces = 4;
            this.udCommissionRate.Location = new System.Drawing.Point(265, 114);
            this.udCommissionRate.Name = "udCommissionRate";
            this.udCommissionRate.Size = new System.Drawing.Size(120, 20);
            this.udCommissionRate.TabIndex = 18;
            this.udCommissionRate.ValueChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblPaymentTypes
            // 
            this.lblPaymentTypes.AutoSize = true;
            this.lblPaymentTypes.Location = new System.Drawing.Point(265, 152);
            this.lblPaymentTypes.Name = "lblPaymentTypes";
            this.lblPaymentTypes.Size = new System.Drawing.Size(35, 13);
            this.lblPaymentTypes.TabIndex = 19;
            this.lblPaymentTypes.Text = "label1";
            // 
            // lstPaymentTypes
            // 
            this.lstPaymentTypes.CheckOnClick = true;
            this.lstPaymentTypes.FormattingEnabled = true;
            this.lstPaymentTypes.Location = new System.Drawing.Point(268, 169);
            this.lstPaymentTypes.Name = "lstPaymentTypes";
            this.lstPaymentTypes.Size = new System.Drawing.Size(275, 124);
            this.lstPaymentTypes.TabIndex = 20;
            this.lstPaymentTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstPaymentTypes_ItemCheck);
            this.lstPaymentTypes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstPaymentTypes_Format);
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(405, 97);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(35, 13);
            this.lblStore.TabIndex = 21;
            this.lblStore.Text = "label1";
            // 
            // cmbStore
            // 
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(408, 113);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(135, 21);
            this.cmbStore.TabIndex = 22;
            this.cmbStore.SelectedIndexChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.cmbStore.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbStore_Format);
            // 
            // EditCommissionPools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 341);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.lstPaymentTypes);
            this.Controls.Add(this.lblPaymentTypes);
            this.Controls.Add(this.udCommissionRate);
            this.Controls.Add(this.lblCommissionRate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lstItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditCommissionPools";
            this.Text = "EditCommissionPools";
            this.Controls.SetChildIndex(this.lstItems, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblCommissionRate, 0);
            this.Controls.SetChildIndex(this.udCommissionRate, 0);
            this.Controls.SetChildIndex(this.lblPaymentTypes, 0);
            this.Controls.SetChildIndex(this.lstPaymentTypes, 0);
            this.Controls.SetChildIndex(this.lblStore, 0);
            this.Controls.SetChildIndex(this.cmbStore, 0);
            ((System.ComponentModel.ISupportInitialize)(this.udCommissionRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCommissionRate;
        private System.Windows.Forms.NumericUpDown udCommissionRate;
        private System.Windows.Forms.Label lblPaymentTypes;
        private System.Windows.Forms.CheckedListBox lstPaymentTypes;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.ComboBox cmbStore;
    }
}