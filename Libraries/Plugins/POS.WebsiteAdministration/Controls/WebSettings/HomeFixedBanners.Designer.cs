namespace POS.WebsiteAdministration.Controls.WebSettings
{
    partial class HomeFixedBanners
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbShowHomeFixedBanners = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(618, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "You can have upto four, fixed, static home page banners on the homepage, these wi" +
    "ll appear below campaign banners (if shown).";
            // 
            // cbShowHomeFixedBanners
            // 
            this.cbShowHomeFixedBanners.AutoSize = true;
            this.cbShowHomeFixedBanners.Location = new System.Drawing.Point(7, 34);
            this.cbShowHomeFixedBanners.Name = "cbShowHomeFixedBanners";
            this.cbShowHomeFixedBanners.Size = new System.Drawing.Size(80, 17);
            this.cbShowHomeFixedBanners.TabIndex = 1;
            this.cbShowHomeFixedBanners.Text = "checkBox1";
            this.cbShowHomeFixedBanners.UseVisualStyleBackColor = true;
            this.cbShowHomeFixedBanners.CheckedChanged += new System.EventHandler(this.cbShowHomeFixedBanners_CheckedChanged);
            // 
            // HomeFixedBanners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbShowHomeFixedBanners);
            this.Controls.Add(this.lblDescription);
            this.Name = "HomeFixedBanners";
            this.Size = new System.Drawing.Size(905, 276);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox cbShowHomeFixedBanners;
    }
}
