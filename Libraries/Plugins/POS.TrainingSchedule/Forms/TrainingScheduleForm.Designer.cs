namespace POS.TrainingSchedule.Forms
{
    partial class TrainingScheduleForm
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
            this.trainingDiary1 = new SalonDiary.Controls.TrainingDiary();
            this.SuspendLayout();
            // 
            // trainingDiary1
            // 
            this.trainingDiary1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingDiary1.AppointmentArrived = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.trainingDiary1.AppointmentArrivedText = System.Drawing.Color.Black;
            this.trainingDiary1.AppointmentCancelledByStaff = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.trainingDiary1.AppointmentCancelledbyStaffText = System.Drawing.Color.Black;
            this.trainingDiary1.AppointmentCancelledByUser = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.trainingDiary1.AppointmentCancelledByUserText = System.Drawing.Color.White;
            this.trainingDiary1.AppointmentCompleted = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.trainingDiary1.AppointmentCompletedText = System.Drawing.Color.Black;
            this.trainingDiary1.AppointmentConfirmed = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.trainingDiary1.AppointmentConfirmedText = System.Drawing.Color.Black;
            this.trainingDiary1.AppointmentNoShow = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.trainingDiary1.AppointmentNoShowText = System.Drawing.Color.Black;
            this.trainingDiary1.AppointmentRequested = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.trainingDiary1.AppointmentRequestedText = System.Drawing.Color.Black;
            this.trainingDiary1.AppointmentSelected = System.Drawing.Color.Aqua;
            this.trainingDiary1.AppointmentSelectedText = System.Drawing.Color.Black;
            this.trainingDiary1.CurrentUser = null;
            this.trainingDiary1.Cursor = System.Windows.Forms.Cursors.Default;
            this.trainingDiary1.Date = new System.DateTime(2003, 4, 28, 0, 0, 0, 0);
            this.trainingDiary1.HintControl = null;
            this.trainingDiary1.Location = new System.Drawing.Point(12, 12);
            this.trainingDiary1.MinimumDate = new System.DateTime(((long)(0)));
            this.trainingDiary1.Name = "trainingDiary1";
            this.trainingDiary1.ScrollAmount = 0;
            this.trainingDiary1.ShowMinutes = true;
            this.trainingDiary1.Size = new System.Drawing.Size(747, 340);
            this.trainingDiary1.Style = SalonDiary.CalendarStyle.Office11;
            this.trainingDiary1.TabIndex = 0;
            this.trainingDiary1.ToolTipDelay = 1000;
            this.trainingDiary1.WeekStartsOnMonday = true;
            this.trainingDiary1.AppointmentEdit += new SalonDiary.Controls.TrainingDiary.EditAppointmentEventHandler(this.trainingDiary1_AppointmentEdit);
            this.trainingDiary1.ScheduleNewTrainingDays += new System.EventHandler(this.trainingDiary1_ScheduleNewTrainingDays);
            // 
            // TrainingScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trainingDiary1);
            this.MinimumSize = new System.Drawing.Size(787, 403);
            this.Name = "TrainingScheduleForm";
            this.Size = new System.Drawing.Size(787, 403);
            this.ResumeLayout(false);

        }

        #endregion

        private SalonDiary.Controls.TrainingDiary trainingDiary1;
    }
}