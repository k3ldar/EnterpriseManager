namespace POS.WebsiteAdministration.Controls
{
    partial class WebsiteSettings
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
            this.cbWebsiteMenus = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbWebsiteMenus
            // 
            this.cbWebsiteMenus.AutoSize = true;
            this.cbWebsiteMenus.Location = new System.Drawing.Point(4, 4);
            this.cbWebsiteMenus.Name = "cbWebsiteMenus";
            this.cbWebsiteMenus.Size = new System.Drawing.Size(132, 17);
            this.cbWebsiteMenus.TabIndex = 0;
            this.cbWebsiteMenus.Text = "Show Website Menu\'s";
            this.cbWebsiteMenus.UseVisualStyleBackColor = true;
            // 
            // WebsiteSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbWebsiteMenus);
            this.Name = "WebsiteSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbWebsiteMenus;
    }
}
