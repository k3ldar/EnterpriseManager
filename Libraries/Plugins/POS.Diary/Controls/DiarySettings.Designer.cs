namespace POS.Diary.Controls
{
    partial class DiarySettings
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
            this.cbMaxDiaryAge1Month = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbMaxDiaryAge1Month
            // 
            this.cbMaxDiaryAge1Month.AutoSize = true;
            this.cbMaxDiaryAge1Month.Location = new System.Drawing.Point(3, 3);
            this.cbMaxDiaryAge1Month.Name = "cbMaxDiaryAge1Month";
            this.cbMaxDiaryAge1Month.Size = new System.Drawing.Size(169, 17);
            this.cbMaxDiaryAge1Month.TabIndex = 1;
            this.cbMaxDiaryAge1Month.Text = "Maximum diary age of 1 month";
            this.cbMaxDiaryAge1Month.UseVisualStyleBackColor = true;
            // 
            // Diary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbMaxDiaryAge1Month);
            this.Name = "Diary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbMaxDiaryAge1Month;
    }
}
