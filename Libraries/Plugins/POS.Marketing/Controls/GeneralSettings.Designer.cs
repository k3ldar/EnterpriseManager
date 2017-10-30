namespace POS.Marketing.Controls
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
            this.cbAutoUpdateMarketingFiles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbAutoUpdateMarketingFiles
            // 
            this.cbAutoUpdateMarketingFiles.AutoSize = true;
            this.cbAutoUpdateMarketingFiles.Location = new System.Drawing.Point(0, 3);
            this.cbAutoUpdateMarketingFiles.Name = "cbAutoUpdateMarketingFiles";
            this.cbAutoUpdateMarketingFiles.Size = new System.Drawing.Size(197, 17);
            this.cbAutoUpdateMarketingFiles.TabIndex = 4;
            this.cbAutoUpdateMarketingFiles.Text = "Update marketing files when starting";
            this.cbAutoUpdateMarketingFiles.UseVisualStyleBackColor = true;
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAutoUpdateMarketingFiles);
            this.Name = "GeneralSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAutoUpdateMarketingFiles;
    }
}
