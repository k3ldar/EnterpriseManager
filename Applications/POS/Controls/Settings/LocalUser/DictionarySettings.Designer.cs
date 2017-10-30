namespace PointOfSale.Controls.Settings.LocalUser
{
    partial class DictionarySettings
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
            this.lblCultureName = new System.Windows.Forms.Label();
            this.cmbDictionary = new System.Windows.Forms.ComboBox();
            this.lblDefaultLanguage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCultureName
            // 
            this.lblCultureName.AutoSize = true;
            this.lblCultureName.Location = new System.Drawing.Point(3, 50);
            this.lblCultureName.Name = "lblCultureName";
            this.lblCultureName.Size = new System.Drawing.Size(78, 13);
            this.lblCultureName.TabIndex = 5;
            this.lblCultureName.Text = "lblCultureName";
            // 
            // cmbDictionary
            // 
            this.cmbDictionary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDictionary.FormattingEnabled = true;
            this.cmbDictionary.Location = new System.Drawing.Point(3, 22);
            this.cmbDictionary.Name = "cmbDictionary";
            this.cmbDictionary.Size = new System.Drawing.Size(171, 21);
            this.cmbDictionary.TabIndex = 4;
            this.cmbDictionary.SelectedIndexChanged += new System.EventHandler(this.cmbDictionary_SelectedIndexChanged);
            this.cmbDictionary.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDictionary_Format);
            // 
            // lblDefaultLanguage
            // 
            this.lblDefaultLanguage.AutoSize = true;
            this.lblDefaultLanguage.Location = new System.Drawing.Point(0, 5);
            this.lblDefaultLanguage.Name = "lblDefaultLanguage";
            this.lblDefaultLanguage.Size = new System.Drawing.Size(92, 13);
            this.lblDefaultLanguage.TabIndex = 3;
            this.lblDefaultLanguage.Text = "Default Language";
            // 
            // DictionarySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCultureName);
            this.Controls.Add(this.cmbDictionary);
            this.Controls.Add(this.lblDefaultLanguage);
            this.Name = "DictionarySettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCultureName;
        private System.Windows.Forms.ComboBox cmbDictionary;
        private System.Windows.Forms.Label lblDefaultLanguage;
    }
}
