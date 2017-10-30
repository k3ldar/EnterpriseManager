namespace POS.CashManager.Classes
{
    partial class CashDrawerSettings
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
            this.lblTimes = new System.Windows.Forms.Label();
            this.udCashDrawBypassCount = new System.Windows.Forms.NumericUpDown();
            this.lblSpotChecks = new System.Windows.Forms.Label();
            this.cbCashDrawBypassStart = new System.Windows.Forms.CheckBox();
            this.cbCashDrawerForceChecks = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.udCashDrawBypassCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(251, 82);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(31, 13);
            this.lblTimes.TabIndex = 9;
            this.lblTimes.Text = "times";
            // 
            // udCashDrawBypassCount
            // 
            this.udCashDrawBypassCount.Location = new System.Drawing.Point(195, 80);
            this.udCashDrawBypassCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udCashDrawBypassCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udCashDrawBypassCount.Name = "udCashDrawBypassCount";
            this.udCashDrawBypassCount.Size = new System.Drawing.Size(50, 20);
            this.udCashDrawBypassCount.TabIndex = 8;
            this.udCashDrawBypassCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblSpotChecks
            // 
            this.lblSpotChecks.AutoSize = true;
            this.lblSpotChecks.Location = new System.Drawing.Point(3, 82);
            this.lblSpotChecks.Name = "lblSpotChecks";
            this.lblSpotChecks.Size = new System.Drawing.Size(167, 13);
            this.lblSpotChecks.TabIndex = 7;
            this.lblSpotChecks.Text = "Allow user to bypass spot checks ";
            // 
            // cbCashDrawBypassStart
            // 
            this.cbCashDrawBypassStart.AutoSize = true;
            this.cbCashDrawBypassStart.Location = new System.Drawing.Point(3, 42);
            this.cbCashDrawBypassStart.Name = "cbCashDrawBypassStart";
            this.cbCashDrawBypassStart.Size = new System.Drawing.Size(153, 17);
            this.cbCashDrawBypassStart.TabIndex = 6;
            this.cbCashDrawBypassStart.Text = "Bypass start of day checks";
            this.cbCashDrawBypassStart.UseVisualStyleBackColor = true;
            // 
            // cbCashDrawerForceChecks
            // 
            this.cbCashDrawerForceChecks.AutoSize = true;
            this.cbCashDrawerForceChecks.Location = new System.Drawing.Point(3, 10);
            this.cbCashDrawerForceChecks.Name = "cbCashDrawerForceChecks";
            this.cbCashDrawerForceChecks.Size = new System.Drawing.Size(91, 17);
            this.cbCashDrawerForceChecks.TabIndex = 5;
            this.cbCashDrawerForceChecks.Text = "Force checks";
            this.cbCashDrawerForceChecks.UseVisualStyleBackColor = true;
            // 
            // CashDrawerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTimes);
            this.Controls.Add(this.udCashDrawBypassCount);
            this.Controls.Add(this.lblSpotChecks);
            this.Controls.Add(this.cbCashDrawBypassStart);
            this.Controls.Add(this.cbCashDrawerForceChecks);
            this.Name = "CashDrawerSettings";
            ((System.ComponentModel.ISupportInitialize)(this.udCashDrawBypassCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.NumericUpDown udCashDrawBypassCount;
        private System.Windows.Forms.Label lblSpotChecks;
        private System.Windows.Forms.CheckBox cbCashDrawBypassStart;
        private System.Windows.Forms.CheckBox cbCashDrawerForceChecks;
    }
}
