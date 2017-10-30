namespace POS.Staff.Forms
{
    partial class ViewSickRecord
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
            this.lblDateNotified = new System.Windows.Forms.Label();
            this.lblDateStarted = new System.Windows.Forms.Label();
            this.lblDateFinished = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageReason = new System.Windows.Forms.TabPage();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.tabPageNotes = new System.Windows.Forms.TabPage();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lbldtpNotified = new System.Windows.Forms.Label();
            this.lbldtpStarted = new System.Windows.Forms.Label();
            this.lbldtpFinished = new System.Windows.Forms.Label();
            this.lblCertified = new System.Windows.Forms.Label();
            this.lblPrebooked = new System.Windows.Forms.Label();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.lblInterviewed = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageReason.SuspendLayout();
            this.tabPageNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateNotified
            // 
            this.lblDateNotified.AutoSize = true;
            this.lblDateNotified.Location = new System.Drawing.Point(12, 20);
            this.lblDateNotified.Name = "lblDateNotified";
            this.lblDateNotified.Size = new System.Drawing.Size(35, 13);
            this.lblDateNotified.TabIndex = 0;
            this.lblDateNotified.Text = "label1";
            // 
            // lblDateStarted
            // 
            this.lblDateStarted.AutoSize = true;
            this.lblDateStarted.Location = new System.Drawing.Point(12, 44);
            this.lblDateStarted.Name = "lblDateStarted";
            this.lblDateStarted.Size = new System.Drawing.Size(35, 13);
            this.lblDateStarted.TabIndex = 2;
            this.lblDateStarted.Text = "label2";
            // 
            // lblDateFinished
            // 
            this.lblDateFinished.AutoSize = true;
            this.lblDateFinished.Location = new System.Drawing.Point(12, 71);
            this.lblDateFinished.Name = "lblDateFinished";
            this.lblDateFinished.Size = new System.Drawing.Size(35, 13);
            this.lblDateFinished.TabIndex = 4;
            this.lblDateFinished.Text = "label3";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(509, 310);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "button1";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageReason);
            this.tabControl1.Controls.Add(this.tabPageNotes);
            this.tabControl1.Location = new System.Drawing.Point(15, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(571, 189);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPageReason
            // 
            this.tabPageReason.Controls.Add(this.txtReason);
            this.tabPageReason.Location = new System.Drawing.Point(4, 22);
            this.tabPageReason.Name = "tabPageReason";
            this.tabPageReason.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReason.Size = new System.Drawing.Size(563, 163);
            this.tabPageReason.TabIndex = 0;
            this.tabPageReason.Text = "tabPage1";
            this.tabPageReason.UseVisualStyleBackColor = true;
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.Location = new System.Drawing.Point(6, 6);
            this.txtReason.MinimumSize = new System.Drawing.Size(551, 151);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReason.Size = new System.Drawing.Size(551, 151);
            this.txtReason.TabIndex = 0;
            // 
            // tabPageNotes
            // 
            this.tabPageNotes.Controls.Add(this.txtNotes);
            this.tabPageNotes.Location = new System.Drawing.Point(4, 22);
            this.tabPageNotes.Name = "tabPageNotes";
            this.tabPageNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotes.Size = new System.Drawing.Size(563, 163);
            this.tabPageNotes.TabIndex = 1;
            this.tabPageNotes.Text = "tabPage2";
            this.tabPageNotes.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(6, 6);
            this.txtNotes.MinimumSize = new System.Drawing.Size(551, 151);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(551, 151);
            this.txtNotes.TabIndex = 0;
            // 
            // lbldtpNotified
            // 
            this.lbldtpNotified.AutoSize = true;
            this.lbldtpNotified.Location = new System.Drawing.Point(150, 20);
            this.lbldtpNotified.Name = "lbldtpNotified";
            this.lbldtpNotified.Size = new System.Drawing.Size(35, 13);
            this.lbldtpNotified.TabIndex = 12;
            this.lbldtpNotified.Text = "label1";
            // 
            // lbldtpStarted
            // 
            this.lbldtpStarted.AutoSize = true;
            this.lbldtpStarted.Location = new System.Drawing.Point(150, 44);
            this.lbldtpStarted.Name = "lbldtpStarted";
            this.lbldtpStarted.Size = new System.Drawing.Size(35, 13);
            this.lbldtpStarted.TabIndex = 13;
            this.lbldtpStarted.Text = "label2";
            // 
            // lbldtpFinished
            // 
            this.lbldtpFinished.AutoSize = true;
            this.lbldtpFinished.Location = new System.Drawing.Point(150, 71);
            this.lbldtpFinished.Name = "lbldtpFinished";
            this.lbldtpFinished.Size = new System.Drawing.Size(35, 13);
            this.lbldtpFinished.TabIndex = 14;
            this.lbldtpFinished.Text = "label3";
            // 
            // lblCertified
            // 
            this.lblCertified.AutoSize = true;
            this.lblCertified.Location = new System.Drawing.Point(376, 20);
            this.lblCertified.Name = "lblCertified";
            this.lblCertified.Size = new System.Drawing.Size(35, 13);
            this.lblCertified.TabIndex = 15;
            this.lblCertified.Text = "label4";
            // 
            // lblPrebooked
            // 
            this.lblPrebooked.AutoSize = true;
            this.lblPrebooked.Location = new System.Drawing.Point(376, 44);
            this.lblPrebooked.Name = "lblPrebooked";
            this.lblPrebooked.Size = new System.Drawing.Size(35, 13);
            this.lblPrebooked.TabIndex = 16;
            this.lblPrebooked.Text = "label5";
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Location = new System.Drawing.Point(376, 71);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(35, 13);
            this.lblCancelled.TabIndex = 17;
            this.lblCancelled.Text = "label6";
            // 
            // lblInterviewed
            // 
            this.lblInterviewed.AutoSize = true;
            this.lblInterviewed.Location = new System.Drawing.Point(376, 96);
            this.lblInterviewed.Name = "lblInterviewed";
            this.lblInterviewed.Size = new System.Drawing.Size(35, 13);
            this.lblInterviewed.TabIndex = 18;
            this.lblInterviewed.Text = "label7";
            // 
            // ViewSickRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 345);
            this.Controls.Add(this.lblInterviewed);
            this.Controls.Add(this.lblCancelled);
            this.Controls.Add(this.lblPrebooked);
            this.Controls.Add(this.lblCertified);
            this.Controls.Add(this.lbldtpFinished);
            this.Controls.Add(this.lbldtpStarted);
            this.Controls.Add(this.lbldtpNotified);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDateFinished);
            this.Controls.Add(this.lblDateStarted);
            this.Controls.Add(this.lblDateNotified);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewSickRecord";
            this.ShowIcon = false;
            this.Text = "ViewSickRecord";
            this.tabControl1.ResumeLayout(false);
            this.tabPageReason.ResumeLayout(false);
            this.tabPageReason.PerformLayout();
            this.tabPageNotes.ResumeLayout(false);
            this.tabPageNotes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateNotified;
        private System.Windows.Forms.Label lblDateStarted;
        private System.Windows.Forms.Label lblDateFinished;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageReason;
        private System.Windows.Forms.TabPage tabPageNotes;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lbldtpNotified;
        private System.Windows.Forms.Label lbldtpStarted;
        private System.Windows.Forms.Label lbldtpFinished;
        private System.Windows.Forms.Label lblCertified;
        private System.Windows.Forms.Label lblPrebooked;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.Label lblInterviewed;
    }
}