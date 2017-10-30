namespace POS.Diary.Forms
{
    partial class SalonAdvancedSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalonAdvancedSettings));
            this.options1 = new SalonDiary.Controls.Options();
            this.SuspendLayout();
            // 
            // options1
            // 
            this.options1.Location = new System.Drawing.Point(1, -1);
            this.options1.Name = "options1";
            this.options1.Size = new System.Drawing.Size(405, 469);
            this.options1.TabIndex = 0;
            // 
            // SalonAdvancedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 468);
            this.Controls.Add(this.options1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalonAdvancedSettings";
            this.SaveState = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SalonAdvancedSettings";
            this.ResumeLayout(false);

        }

        #endregion

        public SalonDiary.Controls.Options options1;
    }
}