namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
{
    partial class Step3
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
            this.lblAppointments = new System.Windows.Forms.Label();
            this.pnlAppointments = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblAppointments
            // 
            this.lblAppointments.AutoSize = true;
            this.lblAppointments.Location = new System.Drawing.Point(4, 4);
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.Size = new System.Drawing.Size(35, 13);
            this.lblAppointments.TabIndex = 0;
            this.lblAppointments.Text = "label1";
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.AutoScroll = true;
            this.pnlAppointments.Location = new System.Drawing.Point(7, 54);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(556, 299);
            this.pnlAppointments.TabIndex = 1;
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAppointments);
            this.Controls.Add(this.lblAppointments);
            this.Name = "Step3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppointments;
        private System.Windows.Forms.FlowLayoutPanel pnlAppointments;
    }
}
