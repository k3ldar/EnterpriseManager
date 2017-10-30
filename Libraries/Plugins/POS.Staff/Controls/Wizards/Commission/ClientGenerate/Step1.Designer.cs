namespace POS.Staff.Controls.Wizards.Commission.ClientGenerate
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
            this.lblMayTakeTime = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mcDateTo = new System.Windows.Forms.MonthCalendar();
            this.mcDateFrom = new System.Windows.Forms.MonthCalendar();
            this.cbReplaceData = new System.Windows.Forms.CheckBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMayTakeTime
            // 
            this.lblMayTakeTime.AutoSize = true;
            this.lblMayTakeTime.Location = new System.Drawing.Point(6, 252);
            this.lblMayTakeTime.Name = "lblMayTakeTime";
            this.lblMayTakeTime.Size = new System.Drawing.Size(35, 13);
            this.lblMayTakeTime.TabIndex = 13;
            this.lblMayTakeTime.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 271);
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(481, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // mcDateTo
            // 
            this.mcDateTo.Location = new System.Drawing.Point(260, 17);
            this.mcDateTo.Name = "mcDateTo";
            this.mcDateTo.TabIndex = 10;
            // 
            // mcDateFrom
            // 
            this.mcDateFrom.Location = new System.Drawing.Point(6, 17);
            this.mcDateFrom.Name = "mcDateFrom";
            this.mcDateFrom.TabIndex = 8;
            // 
            // cbReplaceData
            // 
            this.cbReplaceData.AutoSize = true;
            this.cbReplaceData.Checked = true;
            this.cbReplaceData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReplaceData.Location = new System.Drawing.Point(6, 214);
            this.cbReplaceData.Name = "cbReplaceData";
            this.cbReplaceData.Size = new System.Drawing.Size(15, 14);
            this.cbReplaceData.TabIndex = 11;
            this.cbReplaceData.UseVisualStyleBackColor = true;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(257, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 13);
            this.lblDateTo.TabIndex = 9;
            this.lblDateTo.Text = "label2";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(3, 0);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(35, 13);
            this.lblDateFrom.TabIndex = 7;
            this.lblDateFrom.Text = "label1";
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

        private System.Windows.Forms.Label lblMayTakeTime;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MonthCalendar mcDateTo;
        private System.Windows.Forms.MonthCalendar mcDateFrom;
        private System.Windows.Forms.CheckBox cbReplaceData;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
    }
}
