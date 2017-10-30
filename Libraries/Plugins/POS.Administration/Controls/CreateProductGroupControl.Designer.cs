namespace POS.Administration.Controls
{
    partial class CreateProductGroupControl
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
            this.cmbPrimaryType = new System.Windows.Forms.ComboBox();
            this.lblPrimaryProductGroup = new System.Windows.Forms.Label();
            this.txtProductGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPrimaryType
            // 
            this.cmbPrimaryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimaryType.FormattingEnabled = true;
            this.cmbPrimaryType.Location = new System.Drawing.Point(10, 71);
            this.cmbPrimaryType.Name = "cmbPrimaryType";
            this.cmbPrimaryType.Size = new System.Drawing.Size(258, 21);
            this.cmbPrimaryType.TabIndex = 7;
            // 
            // lblPrimaryProductGroup
            // 
            this.lblPrimaryProductGroup.AutoSize = true;
            this.lblPrimaryProductGroup.Location = new System.Drawing.Point(6, 55);
            this.lblPrimaryProductGroup.Name = "lblPrimaryProductGroup";
            this.lblPrimaryProductGroup.Size = new System.Drawing.Size(81, 13);
            this.lblPrimaryProductGroup.TabIndex = 6;
            this.lblPrimaryProductGroup.Text = "Primary Product";
            // 
            // txtProductGroupName
            // 
            this.txtProductGroupName.Location = new System.Drawing.Point(10, 28);
            this.txtProductGroupName.Name = "txtProductGroupName";
            this.txtProductGroupName.Size = new System.Drawing.Size(258, 20);
            this.txtProductGroupName.TabIndex = 5;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(7, 12);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(75, 13);
            this.lblGroupName.TabIndex = 4;
            this.lblGroupName.Text = "Product Name";
            // 
            // CreateProductGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbPrimaryType);
            this.Controls.Add(this.lblPrimaryProductGroup);
            this.Controls.Add(this.txtProductGroupName);
            this.Controls.Add(this.lblGroupName);
            this.Name = "CreateProductGroupControl";
            this.Size = new System.Drawing.Size(280, 105);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPrimaryType;
        private System.Windows.Forms.Label lblPrimaryProductGroup;
        private System.Windows.Forms.TextBox txtProductGroupName;
        private System.Windows.Forms.Label lblGroupName;
    }
}
