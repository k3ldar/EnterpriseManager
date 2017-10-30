namespace POS.WebsiteAdministration.Forms
{
    partial class AdminWebsites
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
            this.tvOptions = new SharedControls.Controls.TreeViewEx();
            this.SuspendLayout();
            // 
            // tvOptions
            // 
            this.tvOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvOptions.HideSelection = false;
            this.tvOptions.Location = new System.Drawing.Point(0, 28);
            this.tvOptions.Name = "tvOptions";
            this.tvOptions.Size = new System.Drawing.Size(320, 180);
            this.tvOptions.TabIndex = 1;
            this.tvOptions.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvOptions_BeforeSelect);
            this.tvOptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOptions_AfterSelect);
            // 
            // AdminWebsites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvOptions);
            this.Name = "AdminWebsites";
            this.Size = new System.Drawing.Size(665, 211);
            this.Controls.SetChildIndex(this.tvOptions, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Controls.TreeViewEx tvOptions;
    }
}
