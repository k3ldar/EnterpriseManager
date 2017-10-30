namespace PointOfSale.Controls.Settings.LocalUser
{
    partial class GeneralSettings
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
            this.cmbDefaultCountry = new System.Windows.Forms.ComboBox();
            this.lblDefaultCountry = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDefaultCountry
            // 
            this.cmbDefaultCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDefaultCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultCountry.FormattingEnabled = true;
            this.cmbDefaultCountry.Location = new System.Drawing.Point(0, 25);
            this.cmbDefaultCountry.Name = "cmbDefaultCountry";
            this.cmbDefaultCountry.Size = new System.Drawing.Size(383, 21);
            this.cmbDefaultCountry.TabIndex = 4;
            this.cmbDefaultCountry.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDefaultCountry_Format);
            // 
            // lblDefaultCountry
            // 
            this.lblDefaultCountry.AutoSize = true;
            this.lblDefaultCountry.Location = new System.Drawing.Point(-3, 9);
            this.lblDefaultCountry.Name = "lblDefaultCountry";
            this.lblDefaultCountry.Size = new System.Drawing.Size(215, 13);
            this.lblDefaultCountry.TabIndex = 3;
            this.lblDefaultCountry.Text = "Default Country for creating Orders/Invoices";
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDefaultCountry);
            this.Controls.Add(this.lblDefaultCountry);
            this.Name = "GeneralSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDefaultCountry;
        private System.Windows.Forms.Label lblDefaultCountry;
    }
}
