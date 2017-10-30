namespace PointOfSale.Controls.Settings.LocalUser
{
    partial class LanguageSettings
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
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblDefaultCurrency = new System.Windows.Forms.Label();
            this.cbShowLanguageMenu = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(3, 49);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(59, 13);
            this.lblCurrency.TabIndex = 2;
            this.lblCurrency.Text = "lblCurrency";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(3, 21);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(190, 21);
            this.cmbCurrency.TabIndex = 1;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            this.cmbCurrency.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbCurrency_Format);
            // 
            // lblDefaultCurrency
            // 
            this.lblDefaultCurrency.AutoSize = true;
            this.lblDefaultCurrency.Location = new System.Drawing.Point(0, 4);
            this.lblDefaultCurrency.Name = "lblDefaultCurrency";
            this.lblDefaultCurrency.Size = new System.Drawing.Size(86, 13);
            this.lblDefaultCurrency.TabIndex = 0;
            this.lblDefaultCurrency.Text = "Default Currency";
            // 
            // cbShowLanguageMenu
            // 
            this.cbShowLanguageMenu.AutoSize = true;
            this.cbShowLanguageMenu.Location = new System.Drawing.Point(6, 91);
            this.cbShowLanguageMenu.Name = "cbShowLanguageMenu";
            this.cbShowLanguageMenu.Size = new System.Drawing.Size(134, 17);
            this.cbShowLanguageMenu.TabIndex = 3;
            this.cbShowLanguageMenu.Text = "Show Language Menu";
            this.cbShowLanguageMenu.UseVisualStyleBackColor = true;
            // 
            // LanguageSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbShowLanguageMenu);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.lblDefaultCurrency);
            this.Name = "LanguageSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblDefaultCurrency;
        private System.Windows.Forms.CheckBox cbShowLanguageMenu;
    }
}
