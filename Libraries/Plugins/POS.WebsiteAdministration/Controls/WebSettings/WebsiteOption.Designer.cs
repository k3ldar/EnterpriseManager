namespace POS.WebsiteAdministration.Controls.WebSettings
{
    partial class WebsiteOption
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmbValue = new System.Windows.Forms.ComboBox();
            this.cbSetting = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(4, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 28);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "label2";
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(7, 44);
            this.txtValue.MaxLength = 1000;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(398, 20);
            this.txtValue.TabIndex = 2;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // cmbValue
            // 
            this.cmbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(417, 43);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(177, 21);
            this.cmbValue.TabIndex = 3;
            this.cmbValue.SelectedIndexChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // cbSetting
            // 
            this.cbSetting.AutoSize = true;
            this.cbSetting.Location = new System.Drawing.Point(629, 47);
            this.cbSetting.Name = "cbSetting";
            this.cbSetting.Size = new System.Drawing.Size(15, 14);
            this.cbSetting.TabIndex = 4;
            this.cbSetting.UseVisualStyleBackColor = true;
            this.cbSetting.CheckedChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // WebsiteOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSetting);
            this.Controls.Add(this.cmbValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Name = "WebsiteOption";
            this.Size = new System.Drawing.Size(791, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cmbValue;
        private System.Windows.Forms.CheckBox cbSetting;
    }
}
