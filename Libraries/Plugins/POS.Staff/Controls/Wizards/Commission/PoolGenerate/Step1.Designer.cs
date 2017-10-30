namespace POS.Staff.Controls.Wizards.Commission.PoolGenerate
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
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.cbReplaceData = new System.Windows.Forms.CheckBox();
            this.mcDateFrom = new System.Windows.Forms.MonthCalendar();
            this.mcDateTo = new System.Windows.Forms.MonthCalendar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMayTakeTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(4, 4);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 13);
            this.lblDateFrom.TabIndex = 0;
            this.lblDateFrom.Text = "label1";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(258, 4);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 13);
            this.lblDateTo.TabIndex = 2;
            this.lblDateTo.Text = "label2";
            // 
            // cbReplaceData
            // 
            this.cbReplaceData.AutoSize = true;
            this.cbReplaceData.Checked = true;
            this.cbReplaceData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReplaceData.Location = new System.Drawing.Point(7, 218);
            this.cbReplaceData.Name = "cbReplaceData";
            this.cbReplaceData.Size = new System.Drawing.Size(15, 14);
            this.cbReplaceData.TabIndex = 4;
            this.cbReplaceData.UseVisualStyleBackColor = true;
            // 
            // mcDateFrom
            // 
            this.mcDateFrom.Location = new System.Drawing.Point(7, 21);
            this.mcDateFrom.Name = "mcDateFrom";
            this.mcDateFrom.TabIndex = 1;
            // 
            // mcDateTo
            // 
            this.mcDateTo.Location = new System.Drawing.Point(261, 21);
            this.mcDateTo.Name = "mcDateTo";
            this.mcDateTo.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 275);
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(481, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // lblMayTakeTime
            // 
            this.lblMayTakeTime.AutoSize = true;
            this.lblMayTakeTime.Location = new System.Drawing.Point(7, 256);
            this.lblMayTakeTime.Name = "lblMayTakeTime";
            this.lblMayTakeTime.Size = new System.Drawing.Size(35, 13);
            this.lblMayTakeTime.TabIndex = 6;
            this.lblMayTakeTime.Text = "label1";
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMayTakeTime);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mcDateTo);
            this.Controls.Add(this.mcDateFrom);
            this.Controls.Add(this.cbReplaceData);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.CheckBox cbReplaceData;
        private System.Windows.Forms.MonthCalendar mcDateFrom;
        private System.Windows.Forms.MonthCalendar mcDateTo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblMayTakeTime;
    }
}
