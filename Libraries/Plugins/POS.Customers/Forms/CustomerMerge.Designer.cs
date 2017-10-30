namespace POS.Customers.Forms
{
    partial class CustomerMerge
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
            this.grpPrimary = new System.Windows.Forms.GroupBox();
            this.btnSelectPrimary = new System.Windows.Forms.Button();
            this.btnViewPrimary = new System.Windows.Forms.Button();
            this.lblPrimaryRecord = new System.Windows.Forms.Label();
            this.lblPrimaryDescription = new System.Windows.Forms.Label();
            this.grpSecondary = new System.Windows.Forms.GroupBox();
            this.btnSelectSecondary = new System.Windows.Forms.Button();
            this.btnViewSecondary = new System.Windows.Forms.Button();
            this.lblSecondaryRecord = new System.Windows.Forms.Label();
            this.lblSecondaryDescription = new System.Windows.Forms.Label();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpPrimary.SuspendLayout();
            this.grpSecondary.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPrimary
            // 
            this.grpPrimary.Controls.Add(this.btnSelectPrimary);
            this.grpPrimary.Controls.Add(this.btnViewPrimary);
            this.grpPrimary.Controls.Add(this.lblPrimaryRecord);
            this.grpPrimary.Controls.Add(this.lblPrimaryDescription);
            this.grpPrimary.Location = new System.Drawing.Point(13, 13);
            this.grpPrimary.Name = "grpPrimary";
            this.grpPrimary.Size = new System.Drawing.Size(461, 115);
            this.grpPrimary.TabIndex = 0;
            this.grpPrimary.TabStop = false;
            this.grpPrimary.Text = "Primary Record";
            // 
            // btnSelectPrimary
            // 
            this.btnSelectPrimary.Location = new System.Drawing.Point(12, 86);
            this.btnSelectPrimary.Name = "btnSelectPrimary";
            this.btnSelectPrimary.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPrimary.TabIndex = 2;
            this.btnSelectPrimary.Text = "Select";
            this.btnSelectPrimary.UseVisualStyleBackColor = true;
            this.btnSelectPrimary.Click += new System.EventHandler(this.btnSelectPrimary_Click);
            // 
            // btnViewPrimary
            // 
            this.btnViewPrimary.Location = new System.Drawing.Point(93, 86);
            this.btnViewPrimary.Name = "btnViewPrimary";
            this.btnViewPrimary.Size = new System.Drawing.Size(75, 23);
            this.btnViewPrimary.TabIndex = 3;
            this.btnViewPrimary.Text = "View";
            this.btnViewPrimary.UseVisualStyleBackColor = true;
            this.btnViewPrimary.Click += new System.EventHandler(this.btnViewPrimary_Click);
            // 
            // lblPrimaryRecord
            // 
            this.lblPrimaryRecord.AutoSize = true;
            this.lblPrimaryRecord.Location = new System.Drawing.Point(9, 53);
            this.lblPrimaryRecord.Name = "lblPrimaryRecord";
            this.lblPrimaryRecord.Size = new System.Drawing.Size(122, 13);
            this.lblPrimaryRecord.TabIndex = 1;
            this.lblPrimaryRecord.Text = "Customer: Please Select";
            // 
            // lblPrimaryDescription
            // 
            this.lblPrimaryDescription.AutoSize = true;
            this.lblPrimaryDescription.Location = new System.Drawing.Point(6, 25);
            this.lblPrimaryDescription.Name = "lblPrimaryDescription";
            this.lblPrimaryDescription.Size = new System.Drawing.Size(420, 13);
            this.lblPrimaryDescription.TabIndex = 0;
            this.lblPrimaryDescription.Text = "Please select the primary record, this will be the record that will have data mer" +
    "ged into it.";
            // 
            // grpSecondary
            // 
            this.grpSecondary.Controls.Add(this.btnSelectSecondary);
            this.grpSecondary.Controls.Add(this.btnViewSecondary);
            this.grpSecondary.Controls.Add(this.lblSecondaryRecord);
            this.grpSecondary.Controls.Add(this.lblSecondaryDescription);
            this.grpSecondary.Location = new System.Drawing.Point(12, 134);
            this.grpSecondary.Name = "grpSecondary";
            this.grpSecondary.Size = new System.Drawing.Size(461, 115);
            this.grpSecondary.TabIndex = 1;
            this.grpSecondary.TabStop = false;
            this.grpSecondary.Text = "Secondary Record";
            // 
            // btnSelectSecondary
            // 
            this.btnSelectSecondary.Location = new System.Drawing.Point(10, 86);
            this.btnSelectSecondary.Name = "btnSelectSecondary";
            this.btnSelectSecondary.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSecondary.TabIndex = 2;
            this.btnSelectSecondary.Text = "Select";
            this.btnSelectSecondary.UseVisualStyleBackColor = true;
            this.btnSelectSecondary.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnViewSecondary
            // 
            this.btnViewSecondary.Location = new System.Drawing.Point(94, 86);
            this.btnViewSecondary.Name = "btnViewSecondary";
            this.btnViewSecondary.Size = new System.Drawing.Size(75, 23);
            this.btnViewSecondary.TabIndex = 3;
            this.btnViewSecondary.Text = "View";
            this.btnViewSecondary.UseVisualStyleBackColor = true;
            this.btnViewSecondary.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblSecondaryRecord
            // 
            this.lblSecondaryRecord.AutoSize = true;
            this.lblSecondaryRecord.Location = new System.Drawing.Point(10, 65);
            this.lblSecondaryRecord.Name = "lblSecondaryRecord";
            this.lblSecondaryRecord.Size = new System.Drawing.Size(122, 13);
            this.lblSecondaryRecord.TabIndex = 1;
            this.lblSecondaryRecord.Text = "Customer: Please Select";
            // 
            // lblSecondaryDescription
            // 
            this.lblSecondaryDescription.Location = new System.Drawing.Point(6, 25);
            this.lblSecondaryDescription.Name = "lblSecondaryDescription";
            this.lblSecondaryDescription.Size = new System.Drawing.Size(420, 28);
            this.lblSecondaryDescription.TabIndex = 0;
            this.lblSecondaryDescription.Text = "Please select the secondary record, the data from this record will be merged into" +
    " the primary record and this record will be deleted.";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(399, 260);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 3;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(318, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CustomerMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(486, 295);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.grpSecondary);
            this.Controls.Add(this.grpPrimary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerMerge";
            this.SaveState = true;
            this.Text = "Customer Merge";
            this.grpPrimary.ResumeLayout(false);
            this.grpPrimary.PerformLayout();
            this.grpSecondary.ResumeLayout(false);
            this.grpSecondary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPrimary;
        private System.Windows.Forms.Button btnSelectPrimary;
        private System.Windows.Forms.Button btnViewPrimary;
        private System.Windows.Forms.Label lblPrimaryRecord;
        private System.Windows.Forms.Label lblPrimaryDescription;
        private System.Windows.Forms.GroupBox grpSecondary;
        private System.Windows.Forms.Button btnSelectSecondary;
        private System.Windows.Forms.Button btnViewSecondary;
        private System.Windows.Forms.Label lblSecondaryRecord;
        private System.Windows.Forms.Label lblSecondaryDescription;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnCancel;
    }
}