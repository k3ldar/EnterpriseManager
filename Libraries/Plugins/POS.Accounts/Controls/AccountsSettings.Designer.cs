namespace POS.Accounts.Controls
{
    partial class AccountsSettings
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
            this.lblAccountYearStart = new System.Windows.Forms.Label();
            this.dtpAccountYearStart = new System.Windows.Forms.DateTimePicker();
            this.dtpAccountYearEnd = new System.Windows.Forms.DateTimePicker();
            this.lblAccountYearEnd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAccountYearStart
            // 
            this.lblAccountYearStart.AutoSize = true;
            this.lblAccountYearStart.Location = new System.Drawing.Point(4, 4);
            this.lblAccountYearStart.Name = "lblAccountYearStart";
            this.lblAccountYearStart.Size = new System.Drawing.Size(35, 13);
            this.lblAccountYearStart.TabIndex = 0;
            this.lblAccountYearStart.Text = "label1";
            // 
            // dtpAccountYearStart
            // 
            this.dtpAccountYearStart.CustomFormat = "dd MMMM";
            this.dtpAccountYearStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccountYearStart.Location = new System.Drawing.Point(7, 21);
            this.dtpAccountYearStart.Name = "dtpAccountYearStart";
            this.dtpAccountYearStart.Size = new System.Drawing.Size(200, 20);
            this.dtpAccountYearStart.TabIndex = 1;
            this.dtpAccountYearStart.ValueChanged += new System.EventHandler(this.dtpAccountYearStart_ValueChanged);
            // 
            // dtpAccountYearEnd
            // 
            this.dtpAccountYearEnd.CustomFormat = "dd MMMM";
            this.dtpAccountYearEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccountYearEnd.Location = new System.Drawing.Point(7, 80);
            this.dtpAccountYearEnd.Name = "dtpAccountYearEnd";
            this.dtpAccountYearEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpAccountYearEnd.TabIndex = 3;
            // 
            // lblAccountYearEnd
            // 
            this.lblAccountYearEnd.AutoSize = true;
            this.lblAccountYearEnd.Location = new System.Drawing.Point(4, 63);
            this.lblAccountYearEnd.Name = "lblAccountYearEnd";
            this.lblAccountYearEnd.Size = new System.Drawing.Size(35, 13);
            this.lblAccountYearEnd.TabIndex = 2;
            this.lblAccountYearEnd.Text = "label2";
            // 
            // AccountsSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpAccountYearEnd);
            this.Controls.Add(this.lblAccountYearEnd);
            this.Controls.Add(this.dtpAccountYearStart);
            this.Controls.Add(this.lblAccountYearStart);
            this.Name = "AccountsSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountYearStart;
        private System.Windows.Forms.DateTimePicker dtpAccountYearStart;
        private System.Windows.Forms.DateTimePicker dtpAccountYearEnd;
        private System.Windows.Forms.Label lblAccountYearEnd;
    }
}
