namespace POS.Staff.Controls.Wizards.StaffAdd
{
    partial class Step4
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
            this.rbLeaveHours = new System.Windows.Forms.RadioButton();
            this.rbLeaveDays = new System.Windows.Forms.RadioButton();
            this.cbLeaveCarriesOver = new System.Windows.Forms.CheckBox();
            this.cbLeaveAccrues = new System.Windows.Forms.CheckBox();
            this.udLeaveEntitlement = new System.Windows.Forms.NumericUpDown();
            this.lblLeaveEntitlement = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udLeaveEntitlement)).BeginInit();
            this.SuspendLayout();
            // 
            // rbLeaveHours
            // 
            this.rbLeaveHours.AutoSize = true;
            this.rbLeaveHours.Location = new System.Drawing.Point(222, 16);
            this.rbLeaveHours.Name = "rbLeaveHours";
            this.rbLeaveHours.Size = new System.Drawing.Size(53, 17);
            this.rbLeaveHours.TabIndex = 3;
            this.rbLeaveHours.TabStop = true;
            this.rbLeaveHours.Text = "Hours";
            this.rbLeaveHours.UseVisualStyleBackColor = true;
            // 
            // rbLeaveDays
            // 
            this.rbLeaveDays.AutoSize = true;
            this.rbLeaveDays.Checked = true;
            this.rbLeaveDays.Location = new System.Drawing.Point(144, 16);
            this.rbLeaveDays.Name = "rbLeaveDays";
            this.rbLeaveDays.Size = new System.Drawing.Size(49, 17);
            this.rbLeaveDays.TabIndex = 2;
            this.rbLeaveDays.TabStop = true;
            this.rbLeaveDays.Text = "Days";
            this.rbLeaveDays.UseVisualStyleBackColor = true;
            // 
            // cbLeaveCarriesOver
            // 
            this.cbLeaveCarriesOver.AutoSize = true;
            this.cbLeaveCarriesOver.Location = new System.Drawing.Point(320, 17);
            this.cbLeaveCarriesOver.Name = "cbLeaveCarriesOver";
            this.cbLeaveCarriesOver.Size = new System.Drawing.Size(84, 17);
            this.cbLeaveCarriesOver.TabIndex = 4;
            this.cbLeaveCarriesOver.Text = "Carries Over";
            this.cbLeaveCarriesOver.UseVisualStyleBackColor = true;
            // 
            // cbLeaveAccrues
            // 
            this.cbLeaveAccrues.AutoSize = true;
            this.cbLeaveAccrues.Location = new System.Drawing.Point(464, 17);
            this.cbLeaveAccrues.Name = "cbLeaveAccrues";
            this.cbLeaveAccrues.Size = new System.Drawing.Size(65, 17);
            this.cbLeaveAccrues.TabIndex = 5;
            this.cbLeaveAccrues.Text = "Accrues";
            this.cbLeaveAccrues.UseVisualStyleBackColor = true;
            // 
            // udLeaveEntitlement
            // 
            this.udLeaveEntitlement.DecimalPlaces = 1;
            this.udLeaveEntitlement.Location = new System.Drawing.Point(6, 17);
            this.udLeaveEntitlement.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLeaveEntitlement.Name = "udLeaveEntitlement";
            this.udLeaveEntitlement.Size = new System.Drawing.Size(120, 20);
            this.udLeaveEntitlement.TabIndex = 1;
            this.udLeaveEntitlement.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // lblLeaveEntitlement
            // 
            this.lblLeaveEntitlement.AutoSize = true;
            this.lblLeaveEntitlement.Location = new System.Drawing.Point(3, 0);
            this.lblLeaveEntitlement.Name = "lblLeaveEntitlement";
            this.lblLeaveEntitlement.Size = new System.Drawing.Size(91, 13);
            this.lblLeaveEntitlement.TabIndex = 0;
            this.lblLeaveEntitlement.Text = "Leave entitlement";
            // 
            // Step4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbLeaveHours);
            this.Controls.Add(this.rbLeaveDays);
            this.Controls.Add(this.cbLeaveCarriesOver);
            this.Controls.Add(this.cbLeaveAccrues);
            this.Controls.Add(this.udLeaveEntitlement);
            this.Controls.Add(this.lblLeaveEntitlement);
            this.Name = "Step4";
            ((System.ComponentModel.ISupportInitialize)(this.udLeaveEntitlement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbLeaveHours;
        private System.Windows.Forms.RadioButton rbLeaveDays;
        private System.Windows.Forms.CheckBox cbLeaveCarriesOver;
        private System.Windows.Forms.CheckBox cbLeaveAccrues;
        private System.Windows.Forms.NumericUpDown udLeaveEntitlement;
        private System.Windows.Forms.Label lblLeaveEntitlement;
    }
}
