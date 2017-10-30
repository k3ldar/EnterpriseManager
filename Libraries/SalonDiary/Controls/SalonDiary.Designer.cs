namespace SalonDiary.Controls
{
    partial class SalonDiary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalonDiary));
            this.dayView1 = new Calendar.DayView();
            this.calendarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.calenderMenuCreateAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuEditAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuCloneAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.apptHistoryToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.appointmentHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.lockAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.calendarMenuStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuStatusRequested = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuStatusConfirmed = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuStatusArrived = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuStatusCancelledByUser = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuStatusCancelledByStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuStatusNoShow = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuStatusCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.calendarMenuClient = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenuClientNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.calendarMenuTakePayment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWorkingHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAllDayEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notWorkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workingOffSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontDeskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbTherapists = new System.Windows.Forms.ComboBox();
            this.lstTherapists = new System.Windows.Forms.CheckedListBox();
            this.imageAppointmentOverlays = new System.Windows.Forms.ImageList(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.imageHeaderOverlays = new System.Windows.Forms.ImageList(this.components);
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.monthCalendar1 = new Pabo.Calendar.MonthCalendar();
            this.tmrRefreshFromDatabase = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblSalonUtilisation = new System.Windows.Forms.Label();
            this.lblUtilisationHeader = new System.Windows.Forms.Label();
            this.btnWaitingList = new System.Windows.Forms.Button();
            this.btnNewAppointmentWizard = new System.Windows.Forms.Button();
            this.imgNext = new System.Windows.Forms.PictureBox();
            this.imgPrevious = new System.Windows.Forms.PictureBox();
            this.btnSendRemindersWizard = new System.Windows.Forms.Button();
            this.calendarMenu.SuspendLayout();
            this.contextMenuStripHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPrevious)).BeginInit();
            this.SuspendLayout();
            // 
            // dayView1
            // 
            drawTool1.DayView = this.dayView1;
            this.dayView1.ActiveTool = drawTool1;
            this.dayView1.AllowInplaceEditing = false;
            this.dayView1.AlwaysShowAppointmentText = true;
            this.dayView1.AmPmDisplay = false;
            this.dayView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayView1.ContextMenuAllDay = null;
            this.dayView1.ContextMenuDiary = this.calendarMenu;
            this.dayView1.ContextMenuHeader = this.contextMenuStripHeader;
            this.dayView1.DrawAllAppointmentBorders = false;
            this.dayView1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dayView1.Location = new System.Drawing.Point(244, 6);
            this.dayView1.Name = "dayView1";
            this.dayView1.RightMouseSelect = true;
            this.dayView1.SelectedAppointment = null;
            this.dayView1.SelectionEnd = new System.DateTime(((long)(0)));
            this.dayView1.SelectionStart = new System.DateTime(((long)(0)));
            this.dayView1.ShowMinutes = true;
            this.dayView1.Size = new System.Drawing.Size(891, 808);
            this.dayView1.StartDate = new System.DateTime(((long)(0)));
            this.dayView1.StartHour = 9;
            this.dayView1.TabIndex = 7;
            this.dayView1.Text = "dayView1";
            this.dayView1.TooltipDelay = 500;
            this.dayView1.ViewType = Calendar.DayView.DayViewType.TeamView;
            this.dayView1.BeforeAppointmentMove += new Calendar.BeforeMoveAppointmentEventHandler(this.dayView1_BeforeAppointmentMove);
            this.dayView1.BeforeContextMenuShow += new Calendar.ContextMenuEventHandler(this.dayView1_BeforeContextMenuShow);
            this.dayView1.HeaderClicked += new Calendar.HeaderClickEventHandler(this.dayView1_HeaderClicked);
            // 
            // calendarMenu
            // 
            this.calendarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calenderMenuCreateAppointment,
            this.calendarMenuEditAppointment,
            this.calendarMenuCloneAppointment,
            this.apptHistoryToolStripSeparator,
            this.appointmentHistoryToolStripMenuItem,
            this.toolStripMenuItem5,
            this.lockAppointmentToolStripMenuItem,
            this.unlockAppointmentToolStripMenuItem,
            this.toolStripSeparator1,
            this.moveAppointmentToolStripMenuItem,
            this.copyAppointmentToolStripMenuItem,
            this.pasteAppointmentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.calendarMenuStatus,
            this.toolStripMenuItem1,
            this.calendarMenuClient,
            this.calendarMenuClientNotes,
            this.toolStripMenuItem3,
            this.calendarMenuTakePayment,
            this.toolStripMenuItem6,
            this.printToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.calendarMenu.Name = "CalendarMenu";
            this.calendarMenu.Size = new System.Drawing.Size(187, 376);
            this.calendarMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.calendarMenu_Closed);
            this.calendarMenu.Opening += new System.ComponentModel.CancelEventHandler(this.CalendarMenu_Opening);
            // 
            // calenderMenuCreateAppointment
            // 
            this.calenderMenuCreateAppointment.Name = "calenderMenuCreateAppointment";
            this.calenderMenuCreateAppointment.Size = new System.Drawing.Size(186, 22);
            this.calenderMenuCreateAppointment.Text = "Create &Appointment";
            this.calenderMenuCreateAppointment.Click += new System.EventHandler(this.dayView1_DoubleClick);
            // 
            // calendarMenuEditAppointment
            // 
            this.calendarMenuEditAppointment.Name = "calendarMenuEditAppointment";
            this.calendarMenuEditAppointment.Size = new System.Drawing.Size(186, 22);
            this.calendarMenuEditAppointment.Text = "&Edit Appointment";
            this.calendarMenuEditAppointment.Click += new System.EventHandler(this.dayView1_DoubleClick);
            // 
            // calendarMenuCloneAppointment
            // 
            this.calendarMenuCloneAppointment.Name = "calendarMenuCloneAppointment";
            this.calendarMenuCloneAppointment.Size = new System.Drawing.Size(186, 22);
            this.calendarMenuCloneAppointment.Text = "Clone A&ppointment";
            this.calendarMenuCloneAppointment.Click += new System.EventHandler(this.calendarMenuCloneAppointment_Click);
            // 
            // apptHistoryToolStripSeparator
            // 
            this.apptHistoryToolStripSeparator.Name = "apptHistoryToolStripSeparator";
            this.apptHistoryToolStripSeparator.Size = new System.Drawing.Size(183, 6);
            // 
            // appointmentHistoryToolStripMenuItem
            // 
            this.appointmentHistoryToolStripMenuItem.Name = "appointmentHistoryToolStripMenuItem";
            this.appointmentHistoryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.appointmentHistoryToolStripMenuItem.Text = "Appointment &History";
            this.appointmentHistoryToolStripMenuItem.Click += new System.EventHandler(this.appointmentHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(183, 6);
            // 
            // lockAppointmentToolStripMenuItem
            // 
            this.lockAppointmentToolStripMenuItem.Name = "lockAppointmentToolStripMenuItem";
            this.lockAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.lockAppointmentToolStripMenuItem.Text = "&Lock";
            this.lockAppointmentToolStripMenuItem.Click += new System.EventHandler(this.lockAppointmentToolStripMenuItem_Click);
            // 
            // unlockAppointmentToolStripMenuItem
            // 
            this.unlockAppointmentToolStripMenuItem.Name = "unlockAppointmentToolStripMenuItem";
            this.unlockAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.unlockAppointmentToolStripMenuItem.Text = "&Unlock";
            this.unlockAppointmentToolStripMenuItem.Click += new System.EventHandler(this.unlockAppointmentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // moveAppointmentToolStripMenuItem
            // 
            this.moveAppointmentToolStripMenuItem.Name = "moveAppointmentToolStripMenuItem";
            this.moveAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.moveAppointmentToolStripMenuItem.Text = "&Move Appointment";
            this.moveAppointmentToolStripMenuItem.Click += new System.EventHandler(this.moveAppointmentToolStripMenuItem_Click);
            // 
            // copyAppointmentToolStripMenuItem
            // 
            this.copyAppointmentToolStripMenuItem.Name = "copyAppointmentToolStripMenuItem";
            this.copyAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.copyAppointmentToolStripMenuItem.Text = "C&opy Appointment";
            this.copyAppointmentToolStripMenuItem.Click += new System.EventHandler(this.copyAppointmentToolStripMenuItem_Click);
            // 
            // pasteAppointmentToolStripMenuItem
            // 
            this.pasteAppointmentToolStripMenuItem.Name = "pasteAppointmentToolStripMenuItem";
            this.pasteAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pasteAppointmentToolStripMenuItem.Text = "&Paste Appointment";
            this.pasteAppointmentToolStripMenuItem.Click += new System.EventHandler(this.pasteAppointmentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
            // 
            // calendarMenuStatus
            // 
            this.calendarMenuStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarMenuStatusRequested,
            this.calendarMenuStatusConfirmed,
            this.calendarMenuStatusArrived,
            this.calendarMenuStatusCancelledByUser,
            this.calendarMenuStatusCancelledByStaff,
            this.calendarMenuStatusNoShow,
            this.calendarMenuStatusCompleted});
            this.calendarMenuStatus.Name = "calendarMenuStatus";
            this.calendarMenuStatus.Size = new System.Drawing.Size(186, 22);
            this.calendarMenuStatus.Text = "&Status";
            this.calendarMenuStatus.DropDownOpening += new System.EventHandler(this.calendarMenuStatus_DropDownOpening);
            // 
            // calendarMenuStatusRequested
            // 
            this.calendarMenuStatusRequested.Name = "calendarMenuStatusRequested";
            this.calendarMenuStatusRequested.Size = new System.Drawing.Size(169, 22);
            this.calendarMenuStatusRequested.Text = "Requested";
            this.calendarMenuStatusRequested.Click += new System.EventHandler(this.calendarMenuStatusRequested_Click);
            // 
            // calendarMenuStatusConfirmed
            // 
            this.calendarMenuStatusConfirmed.Name = "calendarMenuStatusConfirmed";
            this.calendarMenuStatusConfirmed.Size = new System.Drawing.Size(169, 22);
            this.calendarMenuStatusConfirmed.Text = "Confirmed";
            this.calendarMenuStatusConfirmed.Click += new System.EventHandler(this.calendarMenuStatusConfirmed_Click);
            // 
            // calendarMenuStatusArrived
            // 
            this.calendarMenuStatusArrived.Name = "calendarMenuStatusArrived";
            this.calendarMenuStatusArrived.Size = new System.Drawing.Size(169, 22);
            this.calendarMenuStatusArrived.Text = "Arrived";
            this.calendarMenuStatusArrived.Click += new System.EventHandler(this.calendarMenuStatusArrived_Click);
            // 
            // calendarMenuStatusCancelledByUser
            // 
            this.calendarMenuStatusCancelledByUser.Name = "calendarMenuStatusCancelledByUser";
            this.calendarMenuStatusCancelledByUser.Size = new System.Drawing.Size(169, 22);
            this.calendarMenuStatusCancelledByUser.Text = "Cancelled by User";
            this.calendarMenuStatusCancelledByUser.Click += new System.EventHandler(this.calendarMenuStatusCancelledByUser_Click);
            // 
            // calendarMenuStatusCancelledByStaff
            // 
            this.calendarMenuStatusCancelledByStaff.Name = "calendarMenuStatusCancelledByStaff";
            this.calendarMenuStatusCancelledByStaff.Size = new System.Drawing.Size(169, 22);
            this.calendarMenuStatusCancelledByStaff.Text = "Cancelled by Staff";
            this.calendarMenuStatusCancelledByStaff.Click += new System.EventHandler(this.calendarMenuStatusCancelledByStaff_Click);
            // 
            // calendarMenuStatusNoShow
            // 
            this.calendarMenuStatusNoShow.Name = "calendarMenuStatusNoShow";
            this.calendarMenuStatusNoShow.Size = new System.Drawing.Size(169, 22);
            this.calendarMenuStatusNoShow.Text = "No Show";
            this.calendarMenuStatusNoShow.Click += new System.EventHandler(this.calendarMenuStatusNoShow_Click);
            // 
            // calendarMenuStatusCompleted
            // 
            this.calendarMenuStatusCompleted.Name = "calendarMenuStatusCompleted";
            this.calendarMenuStatusCompleted.Size = new System.Drawing.Size(169, 22);
            this.calendarMenuStatusCompleted.Text = "Completed";
            this.calendarMenuStatusCompleted.Click += new System.EventHandler(this.calendarMenuStatusCompleted_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // calendarMenuClient
            // 
            this.calendarMenuClient.Name = "calendarMenuClient";
            this.calendarMenuClient.Size = new System.Drawing.Size(186, 22);
            this.calendarMenuClient.Text = "&Client";
            this.calendarMenuClient.Click += new System.EventHandler(this.calendarMenuClient_Click);
            // 
            // calendarMenuClientNotes
            // 
            this.calendarMenuClientNotes.Name = "calendarMenuClientNotes";
            this.calendarMenuClientNotes.Size = new System.Drawing.Size(186, 22);
            this.calendarMenuClientNotes.Text = "Client &Notes";
            this.calendarMenuClientNotes.Click += new System.EventHandler(this.calendarMenuClientNotes_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(183, 6);
            // 
            // calendarMenuTakePayment
            // 
            this.calendarMenuTakePayment.Name = "calendarMenuTakePayment";
            this.calendarMenuTakePayment.Size = new System.Drawing.Size(186, 22);
            this.calendarMenuTakePayment.Text = "&Take Payment";
            this.calendarMenuTakePayment.Click += new System.EventHandler(this.takePaymentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(183, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // contextMenuStripHeader
            // 
            this.contextMenuStripHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.changeWorkingHoursToolStripMenuItem,
            this.addAllDayEventToolStripMenuItem});
            this.contextMenuStripHeader.Name = "contextMenuStripHeader";
            this.contextMenuStripHeader.Size = new System.Drawing.Size(199, 70);
            this.contextMenuStripHeader.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripHeader_Opening);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem4.Text = "Edit &Employee";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // changeWorkingHoursToolStripMenuItem
            // 
            this.changeWorkingHoursToolStripMenuItem.Name = "changeWorkingHoursToolStripMenuItem";
            this.changeWorkingHoursToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.changeWorkingHoursToolStripMenuItem.Text = "Change Working &Hours";
            this.changeWorkingHoursToolStripMenuItem.Click += new System.EventHandler(this.changeWorkingHoursToolStripMenuItem_Click);
            // 
            // addAllDayEventToolStripMenuItem
            // 
            this.addAllDayEventToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notWorkingToolStripMenuItem,
            this.workingOffSiteToolStripMenuItem,
            this.trainingToolStripMenuItem,
            this.frontDeskToolStripMenuItem});
            this.addAllDayEventToolStripMenuItem.Name = "addAllDayEventToolStripMenuItem";
            this.addAllDayEventToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addAllDayEventToolStripMenuItem.Text = "&Add All Day Event";
            // 
            // notWorkingToolStripMenuItem
            // 
            this.notWorkingToolStripMenuItem.Name = "notWorkingToolStripMenuItem";
            this.notWorkingToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.notWorkingToolStripMenuItem.Text = "&Not Working";
            this.notWorkingToolStripMenuItem.Click += new System.EventHandler(this.notWorkingToolStripMenuItem_Click);
            // 
            // workingOffSiteToolStripMenuItem
            // 
            this.workingOffSiteToolStripMenuItem.Name = "workingOffSiteToolStripMenuItem";
            this.workingOffSiteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.workingOffSiteToolStripMenuItem.Text = "&Working Off Site";
            this.workingOffSiteToolStripMenuItem.Click += new System.EventHandler(this.workingOffSiteToolStripMenuItem_Click);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.trainingToolStripMenuItem.Text = "&Training";
            this.trainingToolStripMenuItem.Click += new System.EventHandler(this.trainingToolStripMenuItem_Click);
            // 
            // frontDeskToolStripMenuItem
            // 
            this.frontDeskToolStripMenuItem.Name = "frontDeskToolStripMenuItem";
            this.frontDeskToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.frontDeskToolStripMenuItem.Text = "&Front Desk";
            this.frontDeskToolStripMenuItem.Click += new System.EventHandler(this.frontDeskToolStripMenuItem_Click);
            // 
            // cmbTherapists
            // 
            this.cmbTherapists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTherapists.FormattingEnabled = true;
            this.cmbTherapists.Location = new System.Drawing.Point(10, 237);
            this.cmbTherapists.Name = "cmbTherapists";
            this.cmbTherapists.Size = new System.Drawing.Size(228, 21);
            this.cmbTherapists.TabIndex = 2;
            this.cmbTherapists.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbTherapists_Format);
            this.cmbTherapists.SelectedValueChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lstTherapists
            // 
            this.lstTherapists.CheckOnClick = true;
            this.lstTherapists.FormattingEnabled = true;
            this.lstTherapists.Location = new System.Drawing.Point(10, 237);
            this.lstTherapists.Name = "lstTherapists";
            this.lstTherapists.Size = new System.Drawing.Size(227, 184);
            this.lstTherapists.TabIndex = 3;
            this.lstTherapists.ThreeDCheckBoxes = true;
            this.lstTherapists.Visible = false;
            this.lstTherapists.SelectedIndexChanged += new System.EventHandler(this.lstTherapists_SelectedValueChanged);
            this.lstTherapists.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstTherapists_Format);
            // 
            // imageAppointmentOverlays
            // 
            this.imageAppointmentOverlays.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageAppointmentOverlays.ImageStream")));
            this.imageAppointmentOverlays.TransparentColor = System.Drawing.Color.White;
            this.imageAppointmentOverlays.Images.SetKeyName(0, "notes.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(1, "warning.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(2, "meeting.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(3, "meeting_internal.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(4, "annual_leave.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(5, "training.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(6, "notes_appt.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(7, "locked.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(8, "LinkedAppointment.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(9, "LinkedAppointments 2.bmp");
            this.imageAppointmentOverlays.Images.SetKeyName(10, "vip.bmp");
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printDocument1_QueryPageSettings);
            // 
            // imageHeaderOverlays
            // 
            this.imageHeaderOverlays.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageHeaderOverlays.ImageStream")));
            this.imageHeaderOverlays.TransparentColor = System.Drawing.Color.White;
            this.imageHeaderOverlays.Images.SetKeyName(0, "EditWrokingHours.bmp");
            this.imageHeaderOverlays.Images.SetKeyName(1, "EmployeeNoTreatments.bmp");
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.Location = new System.Drawing.Point(43, 17);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(161, 34);
            this.lblCurrentDate.TabIndex = 0;
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
            this.monthCalendar1.Location = new System.Drawing.Point(10, 57);
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
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Weekdays.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(200)))));
            this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar1.Weeknumbers.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(200)))));
            this.monthCalendar1.DayClick += new Pabo.Calendar.DayClickEventHandler(this.monthCalendar1_DayClick);
            this.monthCalendar1.FooterClick += new Pabo.Calendar.ClickEventHandler(this.monthCalendar1_FooterClick);
            this.monthCalendar1.DaySelected += new Pabo.Calendar.DaySelectedEventHandler(this.monthCalendar1_DaySelected);
            // 
            // tmrRefreshFromDatabase
            // 
            this.tmrRefreshFromDatabase.Interval = 1000;
            this.tmrRefreshFromDatabase.Tick += new System.EventHandler(this.tmrRefreshFromDatabase_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Salon Utilisation";
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // lblSalonUtilisation
            // 
            this.lblSalonUtilisation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalonUtilisation.AutoSize = true;
            this.lblSalonUtilisation.Location = new System.Drawing.Point(7, 801);
            this.lblSalonUtilisation.Name = "lblSalonUtilisation";
            this.lblSalonUtilisation.Size = new System.Drawing.Size(35, 13);
            this.lblSalonUtilisation.TabIndex = 9;
            this.lblSalonUtilisation.Text = "label1";
            this.toolTip1.SetToolTip(this.lblSalonUtilisation, "asdf");
            // 
            // lblUtilisationHeader
            // 
            this.lblUtilisationHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUtilisationHeader.AutoSize = true;
            this.lblUtilisationHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtilisationHeader.Location = new System.Drawing.Point(7, 785);
            this.lblUtilisationHeader.Name = "lblUtilisationHeader";
            this.lblUtilisationHeader.Size = new System.Drawing.Size(99, 13);
            this.lblUtilisationHeader.TabIndex = 8;
            this.lblUtilisationHeader.Text = "Salon Utilisation";
            // 
            // btnWaitingList
            // 
            this.btnWaitingList.BackgroundImage = global::SalonDiary.Properties.Resources.waiting_icon;
            this.btnWaitingList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWaitingList.Location = new System.Drawing.Point(86, 427);
            this.btnWaitingList.Name = "btnWaitingList";
            this.btnWaitingList.Size = new System.Drawing.Size(70, 70);
            this.btnWaitingList.TabIndex = 5;
            this.btnWaitingList.UseVisualStyleBackColor = true;
            this.btnWaitingList.Click += new System.EventHandler(this.btnWaitingList_Click);
            // 
            // btnNewAppointmentWizard
            // 
            this.btnNewAppointmentWizard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewAppointmentWizard.BackgroundImage")));
            this.btnNewAppointmentWizard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewAppointmentWizard.Location = new System.Drawing.Point(10, 427);
            this.btnNewAppointmentWizard.Name = "btnNewAppointmentWizard";
            this.btnNewAppointmentWizard.Size = new System.Drawing.Size(70, 70);
            this.btnNewAppointmentWizard.TabIndex = 4;
            this.btnNewAppointmentWizard.UseVisualStyleBackColor = true;
            this.btnNewAppointmentWizard.Click += new System.EventHandler(this.btnNewAppointmentWizard_Click);
            // 
            // imgNext
            // 
            this.imgNext.BackgroundImage = global::SalonDiary.Properties.Resources._112_RightArrowShort_Blue;
            this.imgNext.InitialImage = null;
            this.imgNext.Location = new System.Drawing.Point(206, 17);
            this.imgNext.Name = "imgNext";
            this.imgNext.Size = new System.Drawing.Size(31, 34);
            this.imgNext.TabIndex = 28;
            this.imgNext.TabStop = false;
            this.imgNext.Click += new System.EventHandler(this.imgNext_Click);
            // 
            // imgPrevious
            // 
            this.imgPrevious.BackgroundImage = global::SalonDiary.Properties.Resources._112_LeftArrowShort_Blue;
            this.imgPrevious.InitialImage = null;
            this.imgPrevious.Location = new System.Drawing.Point(10, 17);
            this.imgPrevious.Name = "imgPrevious";
            this.imgPrevious.Size = new System.Drawing.Size(31, 34);
            this.imgPrevious.TabIndex = 27;
            this.imgPrevious.TabStop = false;
            this.imgPrevious.Click += new System.EventHandler(this.imgPrevious_Click);
            // 
            // btnSendRemindersWizard
            // 
            this.btnSendRemindersWizard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSendRemindersWizard.BackgroundImage")));
            this.btnSendRemindersWizard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendRemindersWizard.Location = new System.Drawing.Point(163, 427);
            this.btnSendRemindersWizard.Name = "btnSendRemindersWizard";
            this.btnSendRemindersWizard.Size = new System.Drawing.Size(70, 70);
            this.btnSendRemindersWizard.TabIndex = 6;
            this.btnSendRemindersWizard.UseVisualStyleBackColor = true;
            this.btnSendRemindersWizard.Click += new System.EventHandler(this.btnSendRemindersWizard_Click);
            // 
            // SalonDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSendRemindersWizard);
            this.Controls.Add(this.btnWaitingList);
            this.Controls.Add(this.btnNewAppointmentWizard);
            this.Controls.Add(this.lblUtilisationHeader);
            this.Controls.Add(this.lblSalonUtilisation);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.imgNext);
            this.Controls.Add(this.imgPrevious);
            this.Controls.Add(this.dayView1);
            this.Controls.Add(this.cmbTherapists);
            this.Controls.Add(this.lstTherapists);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "SalonDiary";
            this.Size = new System.Drawing.Size(1141, 820);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SalonDiary_KeyUp);
            this.calendarMenu.ResumeLayout(false);
            this.contextMenuStripHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPrevious)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTherapists;
        private System.Windows.Forms.CheckedListBox lstTherapists;
        private Calendar.DayView dayView1;
        private System.Windows.Forms.ContextMenuStrip calendarMenu;
        private System.Windows.Forms.ToolStripMenuItem calenderMenuCreateAppointment;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuEditAppointment;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuCloneAppointment;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatus;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatusRequested;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatusConfirmed;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatusArrived;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatusCancelledByUser;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatusCancelledByStaff;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatusNoShow;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuStatusCompleted;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuClient;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuClientNotes;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripHeader;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem changeWorkingHoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notWorkingToolStripMenuItem;
        private System.Windows.Forms.PictureBox imgPrevious;
        private System.Windows.Forms.PictureBox imgNext;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.ToolStripMenuItem addAllDayEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workingOffSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem moveAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuTakePayment;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator apptHistoryToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem appointmentHistoryToolStripMenuItem;
        private Pabo.Calendar.MonthCalendar monthCalendar1;
        internal System.Windows.Forms.ImageList imageAppointmentOverlays;
        internal System.Windows.Forms.ImageList imageHeaderOverlays;
        private System.Windows.Forms.Timer tmrRefreshFromDatabase;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblSalonUtilisation;
        private System.Windows.Forms.Label lblUtilisationHeader;
        private System.Windows.Forms.ToolStripMenuItem lockAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem frontDeskToolStripMenuItem;
        private System.Windows.Forms.Button btnNewAppointmentWizard;
        private System.Windows.Forms.Button btnWaitingList;
        private System.Windows.Forms.Button btnSendRemindersWizard;
    }
}
