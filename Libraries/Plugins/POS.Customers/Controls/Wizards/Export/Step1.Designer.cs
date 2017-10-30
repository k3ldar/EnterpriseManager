namespace POS.Customers.Controls.Wizards.Export
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
            this.lblSelectCountryDesc = new System.Windows.Forms.Label();
            this.clbCountries = new System.Windows.Forms.CheckedListBox();
            this.rbAllCountries = new System.Windows.Forms.RadioButton();
            this.rbSelectCountries = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblSelectCountryDesc
            // 
            this.lblSelectCountryDesc.AutoSize = true;
            this.lblSelectCountryDesc.Location = new System.Drawing.Point(4, 4);
            this.lblSelectCountryDesc.Name = "lblSelectCountryDesc";
            this.lblSelectCountryDesc.Size = new System.Drawing.Size(90, 13);
            this.lblSelectCountryDesc.TabIndex = 0;
            this.lblSelectCountryDesc.Text = "Country Selection";
            // 
            // clbCountries
            // 
            this.clbCountries.CheckOnClick = true;
            this.clbCountries.FormattingEnabled = true;
            this.clbCountries.HorizontalScrollbar = true;
            this.clbCountries.Location = new System.Drawing.Point(33, 84);
            this.clbCountries.MultiColumn = true;
            this.clbCountries.Name = "clbCountries";
            this.clbCountries.Size = new System.Drawing.Size(533, 259);
            this.clbCountries.TabIndex = 3;
            this.clbCountries.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCountries_ItemCheck);
            this.clbCountries.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.clbCountries_Format);
            this.clbCountries.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clbCountries_MouseUp);
            // 
            // rbAllCountries
            // 
            this.rbAllCountries.AutoSize = true;
            this.rbAllCountries.Checked = true;
            this.rbAllCountries.Location = new System.Drawing.Point(7, 37);
            this.rbAllCountries.Name = "rbAllCountries";
            this.rbAllCountries.Size = new System.Drawing.Size(83, 17);
            this.rbAllCountries.TabIndex = 1;
            this.rbAllCountries.TabStop = true;
            this.rbAllCountries.Text = "All Countries";
            this.rbAllCountries.UseVisualStyleBackColor = true;
            this.rbAllCountries.CheckedChanged += new System.EventHandler(this.rbAllCountries_CheckedChanged);
            // 
            // rbSelectCountries
            // 
            this.rbSelectCountries.AutoSize = true;
            this.rbSelectCountries.Location = new System.Drawing.Point(7, 61);
            this.rbSelectCountries.Name = "rbSelectCountries";
            this.rbSelectCountries.Size = new System.Drawing.Size(102, 17);
            this.rbSelectCountries.TabIndex = 2;
            this.rbSelectCountries.TabStop = true;
            this.rbSelectCountries.Text = "Select Countries";
            this.rbSelectCountries.UseVisualStyleBackColor = true;
            this.rbSelectCountries.CheckedChanged += new System.EventHandler(this.rbAllCountries_CheckedChanged);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbSelectCountries);
            this.Controls.Add(this.rbAllCountries);
            this.Controls.Add(this.clbCountries);
            this.Controls.Add(this.lblSelectCountryDesc);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectCountryDesc;
        private System.Windows.Forms.CheckedListBox clbCountries;
        private System.Windows.Forms.RadioButton rbAllCountries;
        private System.Windows.Forms.RadioButton rbSelectCountries;

    }
}
