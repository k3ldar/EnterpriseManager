namespace POS.Staff.Controls.Settings
{
    partial class StaffSettingsExpenses
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
            this.lblFirstFor = new System.Windows.Forms.Label();
            this.udFirstRate = new System.Windows.Forms.NumericUpDown();
            this.lblFirstMiles = new System.Windows.Forms.Label();
            this.lblFirstCurrency = new System.Windows.Forms.Label();
            this.udFirstMiles = new System.Windows.Forms.NumericUpDown();
            this.lblSecondCurrency = new System.Windows.Forms.Label();
            this.udSecondRate = new System.Windows.Forms.NumericUpDown();
            this.lblSecondFor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udFirstRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFirstMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSecondRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstFor
            // 
            this.lblFirstFor.AutoSize = true;
            this.lblFirstFor.Location = new System.Drawing.Point(116, 19);
            this.lblFirstFor.Name = "lblFirstFor";
            this.lblFirstFor.Size = new System.Drawing.Size(56, 13);
            this.lblFirstFor.TabIndex = 2;
            this.lblFirstFor.Text = "for the first";
            // 
            // udFirstRate
            // 
            this.udFirstRate.DecimalPlaces = 4;
            this.udFirstRate.Location = new System.Drawing.Point(36, 17);
            this.udFirstRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udFirstRate.Name = "udFirstRate";
            this.udFirstRate.Size = new System.Drawing.Size(74, 20);
            this.udFirstRate.TabIndex = 1;
            this.udFirstRate.Value = new decimal(new int[] {
            42,
            0,
            0,
            131072});
            // 
            // lblFirstMiles
            // 
            this.lblFirstMiles.AutoSize = true;
            this.lblFirstMiles.Location = new System.Drawing.Point(309, 19);
            this.lblFirstMiles.Name = "lblFirstMiles";
            this.lblFirstMiles.Size = new System.Drawing.Size(35, 13);
            this.lblFirstMiles.TabIndex = 4;
            this.lblFirstMiles.Text = "label2";
            // 
            // lblFirstCurrency
            // 
            this.lblFirstCurrency.AutoSize = true;
            this.lblFirstCurrency.Location = new System.Drawing.Point(3, 19);
            this.lblFirstCurrency.Name = "lblFirstCurrency";
            this.lblFirstCurrency.Size = new System.Drawing.Size(13, 13);
            this.lblFirstCurrency.TabIndex = 0;
            this.lblFirstCurrency.Text = "£";
            // 
            // udFirstMiles
            // 
            this.udFirstMiles.Location = new System.Drawing.Point(205, 17);
            this.udFirstMiles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.udFirstMiles.Name = "udFirstMiles";
            this.udFirstMiles.Size = new System.Drawing.Size(87, 20);
            this.udFirstMiles.TabIndex = 3;
            this.udFirstMiles.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblSecondCurrency
            // 
            this.lblSecondCurrency.AutoSize = true;
            this.lblSecondCurrency.Location = new System.Drawing.Point(3, 59);
            this.lblSecondCurrency.Name = "lblSecondCurrency";
            this.lblSecondCurrency.Size = new System.Drawing.Size(13, 13);
            this.lblSecondCurrency.TabIndex = 5;
            this.lblSecondCurrency.Text = "£";
            // 
            // udSecondRate
            // 
            this.udSecondRate.DecimalPlaces = 4;
            this.udSecondRate.Location = new System.Drawing.Point(36, 57);
            this.udSecondRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udSecondRate.Name = "udSecondRate";
            this.udSecondRate.Size = new System.Drawing.Size(74, 20);
            this.udSecondRate.TabIndex = 6;
            this.udSecondRate.Value = new decimal(new int[] {
            26,
            0,
            0,
            131072});
            // 
            // lblSecondFor
            // 
            this.lblSecondFor.AutoSize = true;
            this.lblSecondFor.Location = new System.Drawing.Point(116, 59);
            this.lblSecondFor.Name = "lblSecondFor";
            this.lblSecondFor.Size = new System.Drawing.Size(88, 13);
            this.lblSecondFor.TabIndex = 7;
            this.lblSecondFor.Text = "for the remaining ";
            // 
            // StaffSettingsExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSecondCurrency);
            this.Controls.Add(this.udSecondRate);
            this.Controls.Add(this.lblSecondFor);
            this.Controls.Add(this.udFirstMiles);
            this.Controls.Add(this.lblFirstCurrency);
            this.Controls.Add(this.lblFirstMiles);
            this.Controls.Add(this.udFirstRate);
            this.Controls.Add(this.lblFirstFor);
            this.Name = "StaffSettingsExpenses";
            ((System.ComponentModel.ISupportInitialize)(this.udFirstRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFirstMiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSecondRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstFor;
        private System.Windows.Forms.NumericUpDown udFirstRate;
        private System.Windows.Forms.Label lblFirstMiles;
        private System.Windows.Forms.Label lblFirstCurrency;
        private System.Windows.Forms.NumericUpDown udFirstMiles;
        private System.Windows.Forms.Label lblSecondCurrency;
        private System.Windows.Forms.NumericUpDown udSecondRate;
        private System.Windows.Forms.Label lblSecondFor;
    }
}
