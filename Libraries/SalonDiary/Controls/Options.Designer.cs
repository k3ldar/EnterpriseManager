namespace SalonDiary.Controls
{
    partial class Options
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
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.cbAutoCompleteNonTreatments = new System.Windows.Forms.CheckBox();
            this.lblTooltip = new System.Windows.Forms.Label();
            this.trackBarTooltip = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOldestDate = new System.Windows.Forms.DateTimePicker();
            this.lblScroll = new System.Windows.Forms.Label();
            this.trackBarScrollMovement = new System.Windows.Forms.TrackBar();
            this.cbAutoComplete = new System.Windows.Forms.CheckBox();
            this.trackBarBirthday = new System.Windows.Forms.TrackBar();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblLockAppointments = new System.Windows.Forms.Label();
            this.trackBarAutoLock = new System.Windows.Forms.TrackBar();
            this.tabPageColors = new System.Windows.Forms.TabPage();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.lblChangesImmediate = new System.Windows.Forms.Label();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblApptStatusDesc = new System.Windows.Forms.Label();
            this.cmbAppointmentStatus = new System.Windows.Forms.ComboBox();
            this.tabPageImageOverLays = new System.Windows.Forms.TabPage();
            this.cbNoShowAppointments = new System.Windows.Forms.CheckBox();
            this.pbNoShow = new System.Windows.Forms.PictureBox();
            this.cbNoAppointments = new System.Windows.Forms.CheckBox();
            this.pbNoAppointments = new System.Windows.Forms.PictureBox();
            this.cbWorkingOverride = new System.Windows.Forms.CheckBox();
            this.pbOverride = new System.Windows.Forms.PictureBox();
            this.cbUserNotes = new System.Windows.Forms.CheckBox();
            this.pbNotes = new System.Windows.Forms.PictureBox();
            this.cbAppointmentLinked = new System.Windows.Forms.CheckBox();
            this.pbLinked = new System.Windows.Forms.PictureBox();
            this.cbOverlayLockedAppt = new System.Windows.Forms.CheckBox();
            this.pbOverlayLocked = new System.Windows.Forms.PictureBox();
            this.cbOverlays = new System.Windows.Forms.CheckBox();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.txtIgnoreUsers = new System.Windows.Forms.TextBox();
            this.lblAutoHideDesc = new System.Windows.Forms.Label();
            this.tabPageTimes = new System.Windows.Forms.TabPage();
            this.cmbLunchDurations = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.gbAppointmentText = new System.Windows.Forms.GroupBox();
            this.rbApptTextTreatment = new System.Windows.Forms.RadioButton();
            this.rbApptTextName = new System.Windows.Forms.RadioButton();
            this.cbCacheAppointments = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControlOptions.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTooltip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScrollMovement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBirthday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAutoLock)).BeginInit();
            this.tabPageColors.SuspendLayout();
            this.gbPreview.SuspendLayout();
            this.tabPageImageOverLays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOverride)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLinked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOverlayLocked)).BeginInit();
            this.tabPageUsers.SuspendLayout();
            this.tabPageTimes.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.gbAppointmentText.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabPageGeneral);
            this.tabControlOptions.Controls.Add(this.tabPageColors);
            this.tabControlOptions.Controls.Add(this.tabPageImageOverLays);
            this.tabControlOptions.Controls.Add(this.tabPageUsers);
            this.tabControlOptions.Controls.Add(this.tabPageTimes);
            this.tabControlOptions.Controls.Add(this.tabPageAdvanced);
            this.tabControlOptions.Location = new System.Drawing.Point(8, 8);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(386, 421);
            this.tabControlOptions.TabIndex = 0;
            this.tabControlOptions.SelectedIndexChanged += new System.EventHandler(this.tabControlOptions_SelectedIndexChanged);
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.cbAutoCompleteNonTreatments);
            this.tabPageGeneral.Controls.Add(this.lblTooltip);
            this.tabPageGeneral.Controls.Add(this.trackBarTooltip);
            this.tabPageGeneral.Controls.Add(this.label2);
            this.tabPageGeneral.Controls.Add(this.dtpOldestDate);
            this.tabPageGeneral.Controls.Add(this.lblScroll);
            this.tabPageGeneral.Controls.Add(this.trackBarScrollMovement);
            this.tabPageGeneral.Controls.Add(this.cbAutoComplete);
            this.tabPageGeneral.Controls.Add(this.trackBarBirthday);
            this.tabPageGeneral.Controls.Add(this.lblBirthday);
            this.tabPageGeneral.Controls.Add(this.lblLockAppointments);
            this.tabPageGeneral.Controls.Add(this.trackBarAutoLock);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(378, 395);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // cbAutoCompleteNonTreatments
            // 
            this.cbAutoCompleteNonTreatments.AutoSize = true;
            this.cbAutoCompleteNonTreatments.Location = new System.Drawing.Point(9, 349);
            this.cbAutoCompleteNonTreatments.Name = "cbAutoCompleteNonTreatments";
            this.cbAutoCompleteNonTreatments.Size = new System.Drawing.Size(270, 17);
            this.cbAutoCompleteNonTreatments.TabIndex = 11;
            this.cbAutoCompleteNonTreatments.Text = "Automatically Complete non treatment Appointments";
            this.cbAutoCompleteNonTreatments.UseVisualStyleBackColor = true;
            // 
            // lblTooltip
            // 
            this.lblTooltip.AutoSize = true;
            this.lblTooltip.Location = new System.Drawing.Point(6, 232);
            this.lblTooltip.Name = "lblTooltip";
            this.lblTooltip.Size = new System.Drawing.Size(195, 13);
            this.lblTooltip.TabIndex = 10;
            this.lblTooltip.Text = "delay showing tooltip by {0} milliseconds";
            // 
            // trackBarTooltip
            // 
            this.trackBarTooltip.LargeChange = 1;
            this.trackBarTooltip.Location = new System.Drawing.Point(9, 248);
            this.trackBarTooltip.Maximum = 40;
            this.trackBarTooltip.Minimum = 1;
            this.trackBarTooltip.Name = "trackBarTooltip";
            this.trackBarTooltip.Size = new System.Drawing.Size(354, 45);
            this.trackBarTooltip.TabIndex = 9;
            this.trackBarTooltip.Value = 40;
            this.trackBarTooltip.Scroll += new System.EventHandler(this.trackBarTooltip_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Oldest Date";
            // 
            // dtpOldestDate
            // 
            this.dtpOldestDate.Location = new System.Drawing.Point(104, 305);
            this.dtpOldestDate.Name = "dtpOldestDate";
            this.dtpOldestDate.Size = new System.Drawing.Size(162, 20);
            this.dtpOldestDate.TabIndex = 7;
            // 
            // lblScroll
            // 
            this.lblScroll.AutoSize = true;
            this.lblScroll.Location = new System.Drawing.Point(6, 162);
            this.lblScroll.Name = "lblScroll";
            this.lblScroll.Size = new System.Drawing.Size(222, 13);
            this.lblScroll.TabIndex = 6;
            this.lblScroll.Text = "Move Calendar by {0} Minutes when Scrolling";
            // 
            // trackBarScrollMovement
            // 
            this.trackBarScrollMovement.Location = new System.Drawing.Point(9, 178);
            this.trackBarScrollMovement.Maximum = 4;
            this.trackBarScrollMovement.Minimum = 1;
            this.trackBarScrollMovement.Name = "trackBarScrollMovement";
            this.trackBarScrollMovement.Size = new System.Drawing.Size(354, 45);
            this.trackBarScrollMovement.TabIndex = 5;
            this.trackBarScrollMovement.Value = 1;
            this.trackBarScrollMovement.Scroll += new System.EventHandler(this.trackBarScrollMovement_Scroll);
            // 
            // cbAutoComplete
            // 
            this.cbAutoComplete.AutoSize = true;
            this.cbAutoComplete.Location = new System.Drawing.Point(9, 372);
            this.cbAutoComplete.Name = "cbAutoComplete";
            this.cbAutoComplete.Size = new System.Drawing.Size(254, 17);
            this.cbAutoComplete.TabIndex = 4;
            this.cbAutoComplete.Text = "Complete Appointments When Taking Payments";
            this.cbAutoComplete.UseVisualStyleBackColor = true;
            // 
            // trackBarBirthday
            // 
            this.trackBarBirthday.Location = new System.Drawing.Point(9, 101);
            this.trackBarBirthday.Maximum = 30;
            this.trackBarBirthday.Name = "trackBarBirthday";
            this.trackBarBirthday.Size = new System.Drawing.Size(354, 45);
            this.trackBarBirthday.TabIndex = 3;
            this.trackBarBirthday.Value = 14;
            this.trackBarBirthday.Scroll += new System.EventHandler(this.trackBarBirthday_Scroll);
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(6, 85);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(260, 13);
            this.lblBirthday.TabIndex = 2;
            this.lblBirthday.Text = "Alert staff to clients birthday within {0} days of birthday";
            // 
            // lblLockAppointments
            // 
            this.lblLockAppointments.AutoSize = true;
            this.lblLockAppointments.Location = new System.Drawing.Point(6, 10);
            this.lblLockAppointments.Name = "lblLockAppointments";
            this.lblLockAppointments.Size = new System.Drawing.Size(258, 13);
            this.lblLockAppointments.TabIndex = 1;
            this.lblLockAppointments.Text = "Lock appointments {0} minutes after original start time\r\n";
            // 
            // trackBarAutoLock
            // 
            this.trackBarAutoLock.LargeChange = 1;
            this.trackBarAutoLock.Location = new System.Drawing.Point(9, 26);
            this.trackBarAutoLock.Maximum = 6;
            this.trackBarAutoLock.Name = "trackBarAutoLock";
            this.trackBarAutoLock.Size = new System.Drawing.Size(354, 45);
            this.trackBarAutoLock.SmallChange = 15;
            this.trackBarAutoLock.TabIndex = 0;
            this.trackBarAutoLock.Value = 6;
            this.trackBarAutoLock.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tabPageColors
            // 
            this.tabPageColors.Controls.Add(this.btnTextColor);
            this.tabPageColors.Controls.Add(this.btnBackColor);
            this.tabPageColors.Controls.Add(this.lblChangesImmediate);
            this.tabPageColors.Controls.Add(this.btnResetAll);
            this.tabPageColors.Controls.Add(this.gbPreview);
            this.tabPageColors.Controls.Add(this.lblApptStatusDesc);
            this.tabPageColors.Controls.Add(this.cmbAppointmentStatus);
            this.tabPageColors.Location = new System.Drawing.Point(4, 22);
            this.tabPageColors.Name = "tabPageColors";
            this.tabPageColors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColors.Size = new System.Drawing.Size(378, 395);
            this.tabPageColors.TabIndex = 1;
            this.tabPageColors.Text = "Colours";
            this.tabPageColors.UseVisualStyleBackColor = true;
            // 
            // btnTextColor
            // 
            this.btnTextColor.Location = new System.Drawing.Point(207, 172);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(75, 23);
            this.btnTextColor.TabIndex = 6;
            this.btnTextColor.Text = "Text Colour";
            this.btnTextColor.UseVisualStyleBackColor = true;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(288, 172);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(75, 23);
            this.btnBackColor.TabIndex = 5;
            this.btnBackColor.Text = "Back Colour";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // lblChangesImmediate
            // 
            this.lblChangesImmediate.Location = new System.Drawing.Point(12, 327);
            this.lblChangesImmediate.Name = "lblChangesImmediate";
            this.lblChangesImmediate.Size = new System.Drawing.Size(351, 42);
            this.lblChangesImmediate.TabIndex = 4;
            this.lblChangesImmediate.Text = "* Changes take effect immediately";
            // 
            // btnResetAll
            // 
            this.btnResetAll.Location = new System.Drawing.Point(288, 242);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(75, 23);
            this.btnResetAll.TabIndex = 3;
            this.btnResetAll.Text = "Reset All";
            this.btnResetAll.UseVisualStyleBackColor = true;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.lblPreview);
            this.gbPreview.Location = new System.Drawing.Point(15, 66);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(348, 100);
            this.gbPreview.TabIndex = 2;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview";
            // 
            // lblPreview
            // 
            this.lblPreview.Location = new System.Drawing.Point(18, 27);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(311, 56);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "label2";
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApptStatusDesc
            // 
            this.lblApptStatusDesc.AutoSize = true;
            this.lblApptStatusDesc.Location = new System.Drawing.Point(12, 19);
            this.lblApptStatusDesc.Name = "lblApptStatusDesc";
            this.lblApptStatusDesc.Size = new System.Drawing.Size(99, 13);
            this.lblApptStatusDesc.TabIndex = 1;
            this.lblApptStatusDesc.Text = "Appointment Status";
            // 
            // cmbAppointmentStatus
            // 
            this.cmbAppointmentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppointmentStatus.FormattingEnabled = true;
            this.cmbAppointmentStatus.Location = new System.Drawing.Point(117, 16);
            this.cmbAppointmentStatus.Name = "cmbAppointmentStatus";
            this.cmbAppointmentStatus.Size = new System.Drawing.Size(246, 21);
            this.cmbAppointmentStatus.TabIndex = 0;
            this.cmbAppointmentStatus.SelectedIndexChanged += new System.EventHandler(this.cmbAppointmentStatus_SelectedIndexChanged);
            this.cmbAppointmentStatus.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbAppointmentStatus_Format);
            // 
            // tabPageImageOverLays
            // 
            this.tabPageImageOverLays.Controls.Add(this.cbNoShowAppointments);
            this.tabPageImageOverLays.Controls.Add(this.pbNoShow);
            this.tabPageImageOverLays.Controls.Add(this.cbNoAppointments);
            this.tabPageImageOverLays.Controls.Add(this.pbNoAppointments);
            this.tabPageImageOverLays.Controls.Add(this.cbWorkingOverride);
            this.tabPageImageOverLays.Controls.Add(this.pbOverride);
            this.tabPageImageOverLays.Controls.Add(this.cbUserNotes);
            this.tabPageImageOverLays.Controls.Add(this.pbNotes);
            this.tabPageImageOverLays.Controls.Add(this.cbAppointmentLinked);
            this.tabPageImageOverLays.Controls.Add(this.pbLinked);
            this.tabPageImageOverLays.Controls.Add(this.cbOverlayLockedAppt);
            this.tabPageImageOverLays.Controls.Add(this.pbOverlayLocked);
            this.tabPageImageOverLays.Controls.Add(this.cbOverlays);
            this.tabPageImageOverLays.Location = new System.Drawing.Point(4, 22);
            this.tabPageImageOverLays.Name = "tabPageImageOverLays";
            this.tabPageImageOverLays.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImageOverLays.Size = new System.Drawing.Size(378, 395);
            this.tabPageImageOverLays.TabIndex = 2;
            this.tabPageImageOverLays.Text = "Image Overlays";
            this.tabPageImageOverLays.UseVisualStyleBackColor = true;
            // 
            // cbNoShowAppointments
            // 
            this.cbNoShowAppointments.AutoSize = true;
            this.cbNoShowAppointments.Location = new System.Drawing.Point(40, 217);
            this.cbNoShowAppointments.Name = "cbNoShowAppointments";
            this.cbNoShowAppointments.Size = new System.Drawing.Size(221, 17);
            this.cbNoShowAppointments.TabIndex = 12;
            this.cbNoShowAppointments.Text = "Has No Show or Cancelled Appointments";
            this.cbNoShowAppointments.UseVisualStyleBackColor = true;
            // 
            // pbNoShow
            // 
            this.pbNoShow.Location = new System.Drawing.Point(18, 216);
            this.pbNoShow.Name = "pbNoShow";
            this.pbNoShow.Size = new System.Drawing.Size(16, 16);
            this.pbNoShow.TabIndex = 11;
            this.pbNoShow.TabStop = false;
            // 
            // cbNoAppointments
            // 
            this.cbNoAppointments.AutoSize = true;
            this.cbNoAppointments.Location = new System.Drawing.Point(40, 183);
            this.cbNoAppointments.Name = "cbNoAppointments";
            this.cbNoAppointments.Size = new System.Drawing.Size(107, 17);
            this.cbNoAppointments.TabIndex = 10;
            this.cbNoAppointments.Text = "No Appointments";
            this.cbNoAppointments.UseVisualStyleBackColor = true;
            // 
            // pbNoAppointments
            // 
            this.pbNoAppointments.Location = new System.Drawing.Point(18, 182);
            this.pbNoAppointments.Name = "pbNoAppointments";
            this.pbNoAppointments.Size = new System.Drawing.Size(16, 16);
            this.pbNoAppointments.TabIndex = 9;
            this.pbNoAppointments.TabStop = false;
            // 
            // cbWorkingOverride
            // 
            this.cbWorkingOverride.AutoSize = true;
            this.cbWorkingOverride.Location = new System.Drawing.Point(40, 150);
            this.cbWorkingOverride.Name = "cbWorkingOverride";
            this.cbWorkingOverride.Size = new System.Drawing.Size(109, 17);
            this.cbWorkingOverride.TabIndex = 8;
            this.cbWorkingOverride.Text = "Working Override";
            this.cbWorkingOverride.UseVisualStyleBackColor = true;
            // 
            // pbOverride
            // 
            this.pbOverride.Location = new System.Drawing.Point(18, 149);
            this.pbOverride.Name = "pbOverride";
            this.pbOverride.Size = new System.Drawing.Size(16, 16);
            this.pbOverride.TabIndex = 7;
            this.pbOverride.TabStop = false;
            // 
            // cbUserNotes
            // 
            this.cbUserNotes.AutoSize = true;
            this.cbUserNotes.Location = new System.Drawing.Point(40, 116);
            this.cbUserNotes.Name = "cbUserNotes";
            this.cbUserNotes.Size = new System.Drawing.Size(79, 17);
            this.cbUserNotes.TabIndex = 6;
            this.cbUserNotes.Text = "User Notes";
            this.cbUserNotes.UseVisualStyleBackColor = true;
            // 
            // pbNotes
            // 
            this.pbNotes.Location = new System.Drawing.Point(18, 115);
            this.pbNotes.Name = "pbNotes";
            this.pbNotes.Size = new System.Drawing.Size(16, 16);
            this.pbNotes.TabIndex = 5;
            this.pbNotes.TabStop = false;
            // 
            // cbAppointmentLinked
            // 
            this.cbAppointmentLinked.AutoSize = true;
            this.cbAppointmentLinked.Location = new System.Drawing.Point(40, 83);
            this.cbAppointmentLinked.Name = "cbAppointmentLinked";
            this.cbAppointmentLinked.Size = new System.Drawing.Size(125, 17);
            this.cbAppointmentLinked.TabIndex = 4;
            this.cbAppointmentLinked.Text = "Linked Appointments";
            this.cbAppointmentLinked.UseVisualStyleBackColor = true;
            // 
            // pbLinked
            // 
            this.pbLinked.Location = new System.Drawing.Point(18, 82);
            this.pbLinked.Name = "pbLinked";
            this.pbLinked.Size = new System.Drawing.Size(16, 16);
            this.pbLinked.TabIndex = 3;
            this.pbLinked.TabStop = false;
            // 
            // cbOverlayLockedAppt
            // 
            this.cbOverlayLockedAppt.AutoSize = true;
            this.cbOverlayLockedAppt.Location = new System.Drawing.Point(40, 49);
            this.cbOverlayLockedAppt.Name = "cbOverlayLockedAppt";
            this.cbOverlayLockedAppt.Size = new System.Drawing.Size(129, 17);
            this.cbOverlayLockedAppt.TabIndex = 2;
            this.cbOverlayLockedAppt.Text = "Locked Appointments";
            this.cbOverlayLockedAppt.UseVisualStyleBackColor = true;
            // 
            // pbOverlayLocked
            // 
            this.pbOverlayLocked.Location = new System.Drawing.Point(18, 48);
            this.pbOverlayLocked.Name = "pbOverlayLocked";
            this.pbOverlayLocked.Size = new System.Drawing.Size(16, 16);
            this.pbOverlayLocked.TabIndex = 1;
            this.pbOverlayLocked.TabStop = false;
            // 
            // cbOverlays
            // 
            this.cbOverlays.AutoSize = true;
            this.cbOverlays.Location = new System.Drawing.Point(6, 15);
            this.cbOverlays.Name = "cbOverlays";
            this.cbOverlays.Size = new System.Drawing.Size(129, 17);
            this.cbOverlays.TabIndex = 0;
            this.cbOverlays.Text = "Show Image Overlays";
            this.cbOverlays.UseVisualStyleBackColor = true;
            this.cbOverlays.CheckedChanged += new System.EventHandler(this.cbOverlays_CheckedChanged);
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.txtIgnoreUsers);
            this.tabPageUsers.Controls.Add(this.lblAutoHideDesc);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(378, 395);
            this.tabPageUsers.TabIndex = 3;
            this.tabPageUsers.Text = "Auto Hide";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // txtIgnoreUsers
            // 
            this.txtIgnoreUsers.Location = new System.Drawing.Point(9, 50);
            this.txtIgnoreUsers.Multiline = true;
            this.txtIgnoreUsers.Name = "txtIgnoreUsers";
            this.txtIgnoreUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIgnoreUsers.Size = new System.Drawing.Size(363, 191);
            this.txtIgnoreUsers.TabIndex = 1;
            // 
            // lblAutoHideDesc
            // 
            this.lblAutoHideDesc.Location = new System.Drawing.Point(6, 12);
            this.lblAutoHideDesc.Name = "lblAutoHideDesc";
            this.lblAutoHideDesc.Size = new System.Drawing.Size(366, 35);
            this.lblAutoHideDesc.TabIndex = 0;
            this.lblAutoHideDesc.Text = "To automatically hide staff members diary enter their names below\r\nOnly one name " +
    "per line";
            // 
            // tabPageTimes
            // 
            this.tabPageTimes.Controls.Add(this.cmbLunchDurations);
            this.tabPageTimes.Controls.Add(this.label5);
            this.tabPageTimes.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimes.Name = "tabPageTimes";
            this.tabPageTimes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimes.Size = new System.Drawing.Size(378, 395);
            this.tabPageTimes.TabIndex = 4;
            this.tabPageTimes.Text = "Times";
            this.tabPageTimes.UseVisualStyleBackColor = true;
            // 
            // cmbLunchDurations
            // 
            this.cmbLunchDurations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLunchDurations.FormattingEnabled = true;
            this.cmbLunchDurations.Location = new System.Drawing.Point(131, 17);
            this.cmbLunchDurations.Name = "cmbLunchDurations";
            this.cmbLunchDurations.Size = new System.Drawing.Size(121, 21);
            this.cmbLunchDurations.TabIndex = 1;
            this.cmbLunchDurations.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbLunchDurations_Format);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Maximum Lunch Break:";
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.gbAppointmentText);
            this.tabPageAdvanced.Controls.Add(this.cbCacheAppointments);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(378, 395);
            this.tabPageAdvanced.TabIndex = 5;
            this.tabPageAdvanced.Text = "Advanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // gbAppointmentText
            // 
            this.gbAppointmentText.Controls.Add(this.rbApptTextTreatment);
            this.gbAppointmentText.Controls.Add(this.rbApptTextName);
            this.gbAppointmentText.Location = new System.Drawing.Point(18, 58);
            this.gbAppointmentText.Name = "gbAppointmentText";
            this.gbAppointmentText.Size = new System.Drawing.Size(257, 45);
            this.gbAppointmentText.TabIndex = 1;
            this.gbAppointmentText.TabStop = false;
            this.gbAppointmentText.Text = "Appointment Text";
            // 
            // rbApptTextTreatment
            // 
            this.rbApptTextTreatment.AutoSize = true;
            this.rbApptTextTreatment.Location = new System.Drawing.Point(118, 19);
            this.rbApptTextTreatment.Name = "rbApptTextTreatment";
            this.rbApptTextTreatment.Size = new System.Drawing.Size(125, 17);
            this.rbApptTextTreatment.TabIndex = 1;
            this.rbApptTextTreatment.Text = "Show Treatment First";
            this.rbApptTextTreatment.UseVisualStyleBackColor = true;
            // 
            // rbApptTextName
            // 
            this.rbApptTextName.AutoSize = true;
            this.rbApptTextName.Checked = true;
            this.rbApptTextName.Location = new System.Drawing.Point(7, 20);
            this.rbApptTextName.Name = "rbApptTextName";
            this.rbApptTextName.Size = new System.Drawing.Size(105, 17);
            this.rbApptTextName.TabIndex = 0;
            this.rbApptTextName.TabStop = true;
            this.rbApptTextName.Text = "Show Name First";
            this.rbApptTextName.UseVisualStyleBackColor = true;
            // 
            // cbCacheAppointments
            // 
            this.cbCacheAppointments.AutoSize = true;
            this.cbCacheAppointments.Location = new System.Drawing.Point(18, 19);
            this.cbCacheAppointments.Name = "cbCacheAppointments";
            this.cbCacheAppointments.Size = new System.Drawing.Size(151, 17);
            this.cbCacheAppointments.TabIndex = 0;
            this.cbCacheAppointments.Text = "Cache Diary Appointments";
            this.cbCacheAppointments.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(319, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(238, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControlOptions);
            this.Name = "Options";
            this.Size = new System.Drawing.Size(405, 469);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTooltip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScrollMovement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBirthday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAutoLock)).EndInit();
            this.tabPageColors.ResumeLayout(false);
            this.tabPageColors.PerformLayout();
            this.gbPreview.ResumeLayout(false);
            this.tabPageImageOverLays.ResumeLayout(false);
            this.tabPageImageOverLays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOverride)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLinked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOverlayLocked)).EndInit();
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageUsers.PerformLayout();
            this.tabPageTimes.ResumeLayout(false);
            this.tabPageTimes.PerformLayout();
            this.tabPageAdvanced.ResumeLayout(false);
            this.tabPageAdvanced.PerformLayout();
            this.gbAppointmentText.ResumeLayout(false);
            this.gbAppointmentText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLockAppointments;
        private System.Windows.Forms.TrackBar trackBarAutoLock;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.TrackBar trackBarBirthday;
        private System.Windows.Forms.CheckBox cbAutoComplete;
        private System.Windows.Forms.TabPage tabPageColors;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblApptStatusDesc;
        private System.Windows.Forms.ComboBox cmbAppointmentStatus;
        private System.Windows.Forms.Button btnResetAll;
        private System.Windows.Forms.GroupBox gbPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Label lblScroll;
        private System.Windows.Forms.TrackBar trackBarScrollMovement;
        private System.Windows.Forms.TabPage tabPageImageOverLays;
        private System.Windows.Forms.CheckBox cbOverlayLockedAppt;
        private System.Windows.Forms.PictureBox pbOverlayLocked;
        private System.Windows.Forms.CheckBox cbOverlays;
        private System.Windows.Forms.CheckBox cbNoAppointments;
        private System.Windows.Forms.PictureBox pbNoAppointments;
        private System.Windows.Forms.CheckBox cbWorkingOverride;
        private System.Windows.Forms.PictureBox pbOverride;
        private System.Windows.Forms.CheckBox cbUserNotes;
        private System.Windows.Forms.PictureBox pbNotes;
        private System.Windows.Forms.CheckBox cbAppointmentLinked;
        private System.Windows.Forms.PictureBox pbLinked;
        private System.Windows.Forms.CheckBox cbNoShowAppointments;
        private System.Windows.Forms.PictureBox pbNoShow;
        private System.Windows.Forms.Label lblChangesImmediate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOldestDate;
        private System.Windows.Forms.Label lblTooltip;
        private System.Windows.Forms.TrackBar trackBarTooltip;
        private System.Windows.Forms.CheckBox cbAutoCompleteNonTreatments;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TextBox txtIgnoreUsers;
        private System.Windows.Forms.Label lblAutoHideDesc;
        private System.Windows.Forms.TabPage tabPageTimes;
        private System.Windows.Forms.ComboBox cmbLunchDurations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.CheckBox cbCacheAppointments;
        private System.Windows.Forms.GroupBox gbAppointmentText;
        private System.Windows.Forms.RadioButton rbApptTextTreatment;
        private System.Windows.Forms.RadioButton rbApptTextName;
    }
}
