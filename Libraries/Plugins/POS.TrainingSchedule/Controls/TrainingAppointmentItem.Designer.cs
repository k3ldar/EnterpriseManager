namespace POS.TrainingSchedule.Controls
{
    partial class TrainingAppointmentItem
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
            this.lblSalon = new System.Windows.Forms.Label();
            this.lblCourseFee = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblNoOfAttendees = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblSalonName = new System.Windows.Forms.Label();
            this.picDelete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSalon
            // 
            this.lblSalon.AutoSize = true;
            this.lblSalon.Location = new System.Drawing.Point(3, 8);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(65, 13);
            this.lblSalon.TabIndex = 0;
            this.lblSalon.Text = "Salon Name";
            // 
            // lblCourseFee
            // 
            this.lblCourseFee.AutoSize = true;
            this.lblCourseFee.Location = new System.Drawing.Point(3, 32);
            this.lblCourseFee.Name = "lblCourseFee";
            this.lblCourseFee.Size = new System.Drawing.Size(88, 13);
            this.lblCourseFee.TabIndex = 3;
            this.lblCourseFee.Text = "Total Cost: £0.00";
            // 
            // lblTotalPaid
            // 
            this.lblTotalPaid.AutoSize = true;
            this.lblTotalPaid.Location = new System.Drawing.Point(134, 32);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.Size = new System.Drawing.Size(88, 13);
            this.lblTotalPaid.TabIndex = 4;
            this.lblTotalPaid.Text = "Total Paid: £0.00";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(272, 32);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(79, 13);
            this.lblBalance.TabIndex = 5;
            this.lblBalance.Text = "Balance: £0.00";
            // 
            // lblNoOfAttendees
            // 
            this.lblNoOfAttendees.AutoSize = true;
            this.lblNoOfAttendees.Location = new System.Drawing.Point(272, 8);
            this.lblNoOfAttendees.Name = "lblNoOfAttendees";
            this.lblNoOfAttendees.Size = new System.Drawing.Size(83, 13);
            this.lblNoOfAttendees.TabIndex = 1;
            this.lblNoOfAttendees.Text = "No of attendees";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(397, 6);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblSalonName
            // 
            this.lblSalonName.AutoSize = true;
            this.lblSalonName.Location = new System.Drawing.Point(74, 8);
            this.lblSalonName.Name = "lblSalonName";
            this.lblSalonName.Size = new System.Drawing.Size(0, 13);
            this.lblSalonName.TabIndex = 6;
            // 
            // picDelete
            // 
            this.picDelete.Image = Properties.Resources.EmployeeNoTreatments;
            this.picDelete.Location = new System.Drawing.Point(421, 31);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(19, 19);
            this.picDelete.TabIndex = 7;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // TrainingAppointmentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.lblSalonName);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblNoOfAttendees);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblTotalPaid);
            this.Controls.Add(this.lblCourseFee);
            this.Controls.Add(this.lblSalon);
            this.Name = "TrainingAppointmentItem";
            this.Size = new System.Drawing.Size(444, 56);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalon;
        private System.Windows.Forms.Label lblCourseFee;
        private System.Windows.Forms.Label lblTotalPaid;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblNoOfAttendees;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblSalonName;
        private System.Windows.Forms.PictureBox picDelete;
    }
}
