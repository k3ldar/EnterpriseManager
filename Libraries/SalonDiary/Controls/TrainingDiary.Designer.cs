namespace SalonDiary.Controls
{
    partial class TrainingDiary
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
            this.components = new System.ComponentModel.Container();
            Calendar.DrawTool drawTool1 = new Calendar.DrawTool();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainingDiary));
            this.dayViewTrainingDiary = new Calendar.DayView();
            this.contextMenuStripDiary = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.monthCalendar1 = new Pabo.Calendar.MonthCalendar();
            this.imgNext = new System.Windows.Forms.PictureBox();
            this.imgPrevious = new System.Windows.Forms.PictureBox();
            this.btnScheduleTraining = new System.Windows.Forms.Button();
            this.contextMenuStripDiary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPrevious)).BeginInit();
            this.SuspendLayout();
            // 
            // dayViewTrainingDiary
            // 
            drawTool1.DayView = this.dayViewTrainingDiary;
            this.dayViewTrainingDiary.ActiveTool = drawTool1;
            this.dayViewTrainingDiary.AllowAppointmentResize = false;
            this.dayViewTrainingDiary.AllowInplaceEditing = false;
            this.dayViewTrainingDiary.AllowNew = false;
            this.dayViewTrainingDiary.AlwaysShowAppointmentText = true;
            this.dayViewTrainingDiary.AmPmDisplay = false;
            this.dayViewTrainingDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayViewTrainingDiary.ContextMenuAllDay = null;
            this.dayViewTrainingDiary.ContextMenuDiary = this.contextMenuStripDiary;
            this.dayViewTrainingDiary.ContextMenuHeader = null;
            this.dayViewTrainingDiary.DrawAllAppointmentBorders = false;
            this.dayViewTrainingDiary.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dayViewTrainingDiary.Location = new System.Drawing.Point(240, 0);
            this.dayViewTrainingDiary.Name = "dayViewTrainingDiary";
            this.dayViewTrainingDiary.RightMouseSelect = true;
            this.dayViewTrainingDiary.SelectedAppointment = null;
            this.dayViewTrainingDiary.SelectionEnd = new System.DateTime(((long)(0)));
            this.dayViewTrainingDiary.SelectionStart = new System.DateTime(((long)(0)));
            this.dayViewTrainingDiary.ShowMinutes = true;
            this.dayViewTrainingDiary.Size = new System.Drawing.Size(678, 420);
            this.dayViewTrainingDiary.StartDate = new System.DateTime(((long)(0)));
            this.dayViewTrainingDiary.StartHour = 9;
            this.dayViewTrainingDiary.TabIndex = 31;
            this.dayViewTrainingDiary.Text = "dayViewTrainingDiary";
            this.dayViewTrainingDiary.TooltipDelay = 1000;
            this.dayViewTrainingDiary.WorkingHourStart = 9;
            this.dayViewTrainingDiary.WorkingMinuteEnd = 0;
            this.dayViewTrainingDiary.WorkingMinuteStart = 0;
            this.dayViewTrainingDiary.AppointmentSelected += new Calendar.AppointmentSelectedEventHandler(this.dayView1_AppointmentSelected);
            this.dayViewTrainingDiary.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
            this.dayViewTrainingDiary.AppointmentMoved += new System.EventHandler<Calendar.AppointmentEventArgs>(this.dayView1_AppointmentMoved);
            this.dayViewTrainingDiary.MultiCount += new Calendar.MultiCountEventHandler(this.dayViewTrainingDiary_MultiCount);
            this.dayViewTrainingDiary.ToolTipShow += new Calendar.TooltipEventHandler(this.dayView1_ToolTipShow);
            this.dayViewTrainingDiary.WorkingHours += new Calendar.WorkingHoursEventHandler(this.dayViewTrainingDiary_WorkingHours);
            this.dayViewTrainingDiary.AfterDrawAppointment += new Calendar.AfterDrawAppointmentEventHandler(this.dayView1_AfterDrawAppointment);
            this.dayViewTrainingDiary.HeaderClicked += new Calendar.HeaderClickEventHandler(this.dayView1_HeaderClicked);
            this.dayViewTrainingDiary.DoubleClick += new System.EventHandler(this.dayView1_DoubleClick);
            // 
            // contextMenuStripDiary
            // 
            this.contextMenuStripDiary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cancelToolStripMenuItem});
            this.contextMenuStripDiary.Name = "contextMenuStrip1";
            this.contextMenuStripDiary.Size = new System.Drawing.Size(111, 54);
            this.contextMenuStripDiary.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripDiary_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.cancelToolStripMenuItem.Text = "&Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.Location = new System.Drawing.Point(36, 0);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(161, 34);
            this.lblCurrentDate.TabIndex = 34;
            this.lblCurrentDate.Text = "label1";
            this.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.ActiveMonth.Month = 5;
            this.monthCalendar1.ActiveMonth.Year = 2013;
            this.monthCalendar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(198)))), ((int)(((byte)(214)))));
            this.monthCalendar1.Culture = new System.Globalization.CultureInfo("en-GB");
            this.monthCalendar1.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Header.BackColor1 = System.Drawing.SystemColors.GradientActiveCaption;
            this.monthCalendar1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar1.Header.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthCalendar1.ImageList = null;
            this.monthCalendar1.Location = new System.Drawing.Point(3, 40);
            this.monthCalendar1.MaxDate = new System.DateTime(2023, 5, 1, 19, 48, 5, 942);
            this.monthCalendar1.MinDate = new System.DateTime(2003, 5, 1, 19, 48, 5, 942);
            this.monthCalendar1.Month.BackgroundImage = null;
            this.monthCalendar1.Month.Colors.Focus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(213)))), ((int)(((byte)(224)))));
            this.monthCalendar1.Month.Colors.Focus.Border = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(198)))), ((int)(((byte)(214)))));
            this.monthCalendar1.Month.Colors.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(198)))), ((int)(((byte)(214)))));
            this.monthCalendar1.Month.Colors.Selected.Border = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(135)))));
            this.monthCalendar1.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Month.TextAlign = Pabo.Calendar.mcItemAlign.Center;
            this.monthCalendar1.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Month.Transparency.Background = 255;
            this.monthCalendar1.Month.Transparency.Text = 255;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.SelectionMode = Pabo.Calendar.mcSelectionMode.One;
            this.monthCalendar1.Size = new System.Drawing.Size(227, 174);
            this.monthCalendar1.TabIndex = 35;
            this.monthCalendar1.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Weekdays.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(200)))));
            this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Weeknumbers.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(200)))));
            this.monthCalendar1.DayClick += new Pabo.Calendar.DayClickEventHandler(this.monthCalendar1_DayClick);
            this.monthCalendar1.FooterClick += new Pabo.Calendar.ClickEventHandler(this.monthCalendar1_FooterClick);
            this.monthCalendar1.DaySelected += new Pabo.Calendar.DaySelectedEventHandler(this.monthCalendar1_DaySelected);
            // 
            // imgNext
            // 
            this.imgNext.BackgroundImage = global::SalonDiary.Properties.Resources._112_RightArrowShort_Blue;
            this.imgNext.InitialImage = null;
            this.imgNext.Location = new System.Drawing.Point(199, 0);
            this.imgNext.Name = "imgNext";
            this.imgNext.Size = new System.Drawing.Size(31, 34);
            this.imgNext.TabIndex = 33;
            this.imgNext.TabStop = false;
            this.imgNext.Click += new System.EventHandler(this.imgNext_Click);
            // 
            // imgPrevious
            // 
            this.imgPrevious.BackgroundImage = global::SalonDiary.Properties.Resources._112_LeftArrowShort_Blue;
            this.imgPrevious.InitialImage = null;
            this.imgPrevious.Location = new System.Drawing.Point(3, 0);
            this.imgPrevious.Name = "imgPrevious";
            this.imgPrevious.Size = new System.Drawing.Size(31, 34);
            this.imgPrevious.TabIndex = 32;
            this.imgPrevious.TabStop = false;
            this.imgPrevious.Click += new System.EventHandler(this.imgPrevious_Click);
            // 
            // btnScheduleTraining
            // 
            this.btnScheduleTraining.Image = ((System.Drawing.Image)(resources.GetObject("btnScheduleTraining.Image")));
            this.btnScheduleTraining.Location = new System.Drawing.Point(3, 223);
            this.btnScheduleTraining.Name = "btnScheduleTraining";
            this.btnScheduleTraining.Size = new System.Drawing.Size(115, 116);
            this.btnScheduleTraining.TabIndex = 36;
            this.btnScheduleTraining.Text = "Schedule Course";
            this.btnScheduleTraining.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnScheduleTraining.UseVisualStyleBackColor = true;
            this.btnScheduleTraining.Click += new System.EventHandler(this.btnScheduleTraining_Click);
            // 
            // TrainingDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnScheduleTraining);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.imgNext);
            this.Controls.Add(this.imgPrevious);
            this.Controls.Add(this.dayViewTrainingDiary);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "TrainingDiary";
            this.Size = new System.Drawing.Size(918, 420);
            this.Enter += new System.EventHandler(this.TrainingDiary_Enter);
            this.contextMenuStripDiary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPrevious)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.PictureBox imgNext;
        private System.Windows.Forms.PictureBox imgPrevious;
        private Calendar.DayView dayViewTrainingDiary;
        private Pabo.Calendar.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnScheduleTraining;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDiary;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
    }
}
