namespace POS.Staff.Controls.Settings
{
    partial class CommissionSettings
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
            this.csOverdueBack = new SharedControls.ColorSelector();
            this.csDueSoonBack = new SharedControls.ColorSelector();
            this.colorSelector1 = new SharedControls.ColorSelector();
            this.lblDueSoon = new System.Windows.Forms.Label();
            this.udDueSoon = new System.Windows.Forms.NumericUpDown();
            this.lblDays = new System.Windows.Forms.Label();
            this.csOverdueFore = new SharedControls.ColorSelector();
            this.csDueSoonFore = new SharedControls.ColorSelector();
            this.csSelectedFore = new SharedControls.ColorSelector();
            this.csSelectedBack = new SharedControls.ColorSelector();
            ((System.ComponentModel.ISupportInitialize)(this.udDueSoon)).BeginInit();
            this.SuspendLayout();
            // 
            // csOverdueBack
            // 
            this.csOverdueBack.Color = System.Drawing.Color.Red;
            this.csOverdueBack.Description = "Description";
            this.csOverdueBack.Location = new System.Drawing.Point(3, 3);
            this.csOverdueBack.Name = "csOverdueBack";
            this.csOverdueBack.Size = new System.Drawing.Size(176, 50);
            this.csOverdueBack.TabIndex = 0;
            // 
            // csDueSoonBack
            // 
            this.csDueSoonBack.Color = System.Drawing.Color.MidnightBlue;
            this.csDueSoonBack.Description = "Description";
            this.csDueSoonBack.Location = new System.Drawing.Point(3, 68);
            this.csDueSoonBack.Name = "csDueSoonBack";
            this.csDueSoonBack.Size = new System.Drawing.Size(176, 50);
            this.csDueSoonBack.TabIndex = 2;
            // 
            // colorSelector1
            // 
            this.colorSelector1.Color = System.Drawing.SystemColors.ActiveBorder;
            this.colorSelector1.Description = "Description";
            this.colorSelector1.Location = new System.Drawing.Point(3, 3);
            this.colorSelector1.Name = "colorSelector1";
            this.colorSelector1.Size = new System.Drawing.Size(176, 50);
            this.colorSelector1.TabIndex = 1;
            // 
            // lblDueSoon
            // 
            this.lblDueSoon.AutoSize = true;
            this.lblDueSoon.Location = new System.Drawing.Point(28, 133);
            this.lblDueSoon.Name = "lblDueSoon";
            this.lblDueSoon.Size = new System.Drawing.Size(227, 13);
            this.lblDueSoon.TabIndex = 4;
            this.lblDueSoon.Text = "Show as due soon when the date due is within";
            // 
            // udDueSoon
            // 
            this.udDueSoon.Location = new System.Drawing.Point(290, 131);
            this.udDueSoon.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udDueSoon.Name = "udDueSoon";
            this.udDueSoon.Size = new System.Drawing.Size(55, 20);
            this.udDueSoon.TabIndex = 5;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(351, 133);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(35, 13);
            this.lblDays.TabIndex = 6;
            this.lblDays.Text = "label1";
            // 
            // csOverdueFore
            // 
            this.csOverdueFore.Color = System.Drawing.SystemColors.ActiveBorder;
            this.csOverdueFore.Description = "Description";
            this.csOverdueFore.Location = new System.Drawing.Point(185, 3);
            this.csOverdueFore.Name = "csOverdueFore";
            this.csOverdueFore.Size = new System.Drawing.Size(176, 50);
            this.csOverdueFore.TabIndex = 1;
            // 
            // csDueSoonFore
            // 
            this.csDueSoonFore.Color = System.Drawing.SystemColors.ActiveBorder;
            this.csDueSoonFore.Description = "Description";
            this.csDueSoonFore.Location = new System.Drawing.Point(185, 68);
            this.csDueSoonFore.Name = "csDueSoonFore";
            this.csDueSoonFore.Size = new System.Drawing.Size(176, 50);
            this.csDueSoonFore.TabIndex = 3;
            // 
            // csSelectedFore
            // 
            this.csSelectedFore.Color = System.Drawing.Color.Magenta;
            this.csSelectedFore.Description = "Description";
            this.csSelectedFore.Location = new System.Drawing.Point(185, 192);
            this.csSelectedFore.Name = "csSelectedFore";
            this.csSelectedFore.Size = new System.Drawing.Size(176, 50);
            this.csSelectedFore.TabIndex = 8;
            // 
            // csSelectedBack
            // 
            this.csSelectedBack.Color = System.Drawing.Color.DarkSeaGreen;
            this.csSelectedBack.Description = "Description";
            this.csSelectedBack.Location = new System.Drawing.Point(3, 192);
            this.csSelectedBack.Name = "csSelectedBack";
            this.csSelectedBack.Size = new System.Drawing.Size(176, 50);
            this.csSelectedBack.TabIndex = 7;
            // 
            // CommissionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.csSelectedFore);
            this.Controls.Add(this.csSelectedBack);
            this.Controls.Add(this.csDueSoonFore);
            this.Controls.Add(this.csOverdueFore);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.udDueSoon);
            this.Controls.Add(this.lblDueSoon);
            this.Controls.Add(this.csDueSoonBack);
            this.Controls.Add(this.csOverdueBack);
            this.Name = "CommissionSettings";
            ((System.ComponentModel.ISupportInitialize)(this.udDueSoon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.ColorSelector csOverdueBack;
        private SharedControls.ColorSelector csDueSoonBack;
        private SharedControls.ColorSelector colorSelector1;
        private System.Windows.Forms.Label lblDueSoon;
        private System.Windows.Forms.NumericUpDown udDueSoon;
        private System.Windows.Forms.Label lblDays;
        private SharedControls.ColorSelector csOverdueFore;
        private SharedControls.ColorSelector csDueSoonFore;
        private SharedControls.ColorSelector csSelectedFore;
        private SharedControls.ColorSelector csSelectedBack;

    }
}
