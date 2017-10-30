namespace SalonDiary.Controls.Wizards.WaitingListWizard
{
    partial class Summary
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
            this.lvAppointments = new SharedControls.Classes.ListViewEx();
            this.columnHeaderTherapist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvAppointments
            // 
            this.lvAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTherapist,
            this.columnHeaderDate,
            this.columnHeaderTime});
            this.lvAppointments.FullRowSelect = true;
            this.lvAppointments.HideSelection = false;
            this.lvAppointments.Location = new System.Drawing.Point(5, 46);
            this.lvAppointments.Name = "lvAppointments";
            this.lvAppointments.Size = new System.Drawing.Size(557, 306);
            this.lvAppointments.TabIndex = 3;
            this.lvAppointments.UseCompatibleStateImageBehavior = false;
            this.lvAppointments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTherapist
            // 
            this.columnHeaderTherapist.Text = "Therapist";
            this.columnHeaderTherapist.Width = 260;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 120;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.Width = 120;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(5, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(305, 39);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "The next available appointment date is below, you can either\r\nselect one of the d" +
    "ates/times, and an appointment will be made\r\nor just click finish to remain on t" +
    "he waiting list.";
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lvAppointments);
            this.Name = "Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvAppointments;
        private System.Windows.Forms.ColumnHeader columnHeaderTherapist;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.Label lblDescription;
    }
}
