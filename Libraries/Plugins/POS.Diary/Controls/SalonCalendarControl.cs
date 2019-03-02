/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: SalonCalendarControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using SharedBase;
using SharedBase.BOL.Users;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Therapists;
using SharedBase.BOLEvents;
using SharedBase.BOL.ValidationChecks;

using SharedControls.Interfaces;

using POS.Base.Classes;
using POS.Base.Forms;
using POS.Diary.Forms;

namespace POS.Diary.Controls
{
    public partial class SalonCalendarControl : POS.Base.Controls.BaseTabControl, ISMSSend
    {
        #region Private / Protected Members

        private Base.Plugins.NotificationEventArgs updateStatusBar;

        private Dictionary<string, AppointmentGroup> _activeUserGroup = new Dictionary<string, AppointmentGroup>();

        #region Global

        #endregion Global

        #endregion Private / Protected Members

        #region Constructors

        public SalonCalendarControl()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            AppController.ApplicationController.OnUserChanged += User_OnUserChanged;

            SetCurrentUser(AppController.ActiveUser);
            LoadLocations();

            #region Calendar

#if CACHE_APPOINTMENTS
            salonDiary1.CacheAppointments = AppController.LocalSettings.DiaryAppointmentsCache;
#else
            salonDiary1.CacheAppointments = false;
#endif

            updateStatusBar = new Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_UPDATE_STATUS_BAR);

            statusStripSalon.Visible = false;
            salonDiary1.Height = salonDiary1.Height + 26;

            if (!AppController.LocalSettings.DiaryUseMinimumDate)
                salonDiary1.MinimumDate = DateTime.Now.AddMonths(-1);
            else
                salonDiary1.MinimumDate = AppController.LocalSettings.DiaryMinimumDate;

            salonDiary1.Initialise(AppController.ApplicationController.AllAppointments);

            //settings
            for (int i = 0; i < salonDiary1.EmployeeCount; ++i)
                salonDiary1.EmployeeSelect(i, AppController.LocalSettings.DiaryViewEmployee(
                    salonDiary1.EmployeeName(i)));

            salonDiary1.IgnoreWorkingHours = AppController.LocalSettings.DiaryIgnoreworkingHours;

            salonDiary1.ShowCancelled = AppController.LocalSettings.DiaryShowCancelled;
            salonDiary1.Style = (SalonDiary.CalendarStyle)Enum.Parse(typeof(SalonDiary.CalendarStyle),
                AppController.LocalSettings.DiaryCalendarStyle);
            salonDiary1.WeekStartsOnMonday = AppController.LocalSettings.DiaryMondayStartsWeek;
            salonDiary1.TeamView = AppController.LocalSettings.DiaryMultiView;
            salonDiary1.ShowImageOverlays = AppController.LocalSettings.DiaryShowImageOverlays;
            salonDiary1.ShowMinutes = AppController.LocalSettings.DiaryShowMinutes;
            salonDiary1.BirthdayNotification = AppController.LocalSettings.DiaryBirthdayAlert;
            salonDiary1.AppointmentLockTime = AppController.LocalSettings.DiaryAutoLock;
            salonDiary1.AutoCompleteOnPayment = AppController.LocalSettings.DiaryAutoCompleteOnPayment;
            salonDiary1.ScrollAmount = AppController.LocalSettings.DiaryScrollAmount;
            salonDiary1.ToolTipDelay = AppController.LocalSettings.DiaryToolTipDelay;

            salonDiary1.ImageOverlaysHasCancelled = AppController.LocalSettings.DiaryOverlayCancelled;
            salonDiary1.ImageOverlaysLinked = AppController.LocalSettings.DiaryOverlayLinkedAppoitnment;
            salonDiary1.ImageOverlaysLocked = AppController.LocalSettings.DiaryOverlayLockedAppointment;
            salonDiary1.ImageOverlaysNotes = AppController.LocalSettings.DiaryOverlayUserNotes;
            salonDiary1.ImageOverlaysOverridden = AppController.LocalSettings.DiaryOverlayOverriddenHours;
            salonDiary1.ImageOverlaysNoTreatments = AppController.LocalSettings.DiaryOverlayNoTreatments;
            salonDiary1.AutoHideUsers = AppController.LocalSettings.DiaryAutoHideUsers;
            salonDiary1.WeekStartsOnMonday = AppController.LocalSettings.DiaryWeekStartsOnMonday;
            salonDiary1.BirthdayNotification = AppController.LocalSettings.DiaryBirthdayNotification;
            salonDiary1.AppointmentLockTime = AppController.LocalSettings.DiaryAppointmentLockTime;
            salonDiary1.ShowNameFirst = AppController.LocalSettings.DiaryShowNameFirst;
            salonDiary1.WaitingListUpdated += salonDiary1_WaitingListUpdated;

            salonDiary1.MaxLunchDuration = AppController.LocalSettings.DiaryMaximumLunchDuration;
            LoadColors();

            salonDiary1.Date = DateTime.Now;

            toolStripSettings.Location = new Point(313, 0);
            toolStripOptions.Location = new Point(6, 0);

            #endregion Calendar

            UpdateToolbarButtons();

            AppController.ApplicationController.AppointmentIDChanged += User_AppointmentIDChanged;
            AppController.ApplicationController.ReplicationComplete += User_ReplicationComplete;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            if (DesignMode)
                return;

            toolStripButtonTeamView.Text = LanguageStrings.AppDiaryTeamView;
            toolStripButtonSingleView.Text = LanguageStrings.AppDiaryWeeklyView;
            toolStripDropDownButtonSkin.Text = LanguageStrings.AppDiaryChangeSkin;

            office12ToolStripMenuItem.Text = LanguageStrings.AppDiarySkinOffice12;
            office11ToolStripMenuItem.Text = LanguageStrings.AppDiarySkinOffice11;
            greyToolStripMenuItem.Text = LanguageStrings.AppDiarySkinGrey;
            pinkToolStripMenuItem.Text = LanguageStrings.AppDiarySkinPink;
            roundedToolStripMenuItem.Text = LanguageStrings.AppDiarySkinRounded;
            blueToolStripMenuItem.Text = LanguageStrings.AppDiarySkinBlue;

            toolStripButtonIgnoreWorkingHours.Text = LanguageStrings.AppDiaryIgnoreWorkingHours;
            toolStripButtonWeekStartsMonday.Text = LanguageStrings.AppDiaryWeekStartsMonday;
            toolStripButtonShowCancelledAppointments.Text = LanguageStrings.AppDiaryShowCanncelledAppointments;
            toolStripButtonShowMinutes.Text = LanguageStrings.AppDiaryShowMiutes;
            toolStripButtonShowImageOverlays.Text = LanguageStrings.AppDiaryShowImageOverlays;
            toolStripButtonPrint.Text = LanguageStrings.AppDiaryPrintView;

            toolStripButtonEditSalonTreatments.Text = LanguageStrings.AppDiarySalonTreatments;
            toolStripButtonAdvancedSettings.Text = LanguageStrings.AppDiaryAdvancedSettings;
            toolStripButtonNewAppointments.Text = LanguageStrings.AppDiaryNewAppointments;
            toolStripButtonReports.Text = LanguageStrings.AppDiaryViewReports;
            toolStripButtonSwapUser.Text = LanguageStrings.AppSwapUser;
            toolStripButtonRevertUser.Text = LanguageStrings.AppMenuUserRevert;



            toolStripButtonTeamView.ToolTipText = LanguageStrings.AppDiaryTeamView;
            toolStripButtonSingleView.ToolTipText = LanguageStrings.AppDiaryWeeklyView;
            toolStripDropDownButtonSkin.ToolTipText = LanguageStrings.AppDiaryChangeSkin;

            office12ToolStripMenuItem.ToolTipText = LanguageStrings.AppDiarySkinOffice12;
            office11ToolStripMenuItem.ToolTipText = LanguageStrings.AppDiarySkinOffice11;
            greyToolStripMenuItem.ToolTipText = LanguageStrings.AppDiarySkinGrey;
            pinkToolStripMenuItem.ToolTipText = LanguageStrings.AppDiarySkinPink;
            roundedToolStripMenuItem.ToolTipText = LanguageStrings.AppDiarySkinRounded;
            blueToolStripMenuItem.ToolTipText = LanguageStrings.AppDiarySkinBlue;

            toolStripButtonIgnoreWorkingHours.ToolTipText = LanguageStrings.AppDiaryIgnoreWorkingHours;
            toolStripButtonWeekStartsMonday.ToolTipText = LanguageStrings.AppDiaryWeekStartsMonday;
            toolStripButtonShowCancelledAppointments.ToolTipText = LanguageStrings.AppDiaryShowCanncelledAppointments;
            toolStripButtonShowMinutes.ToolTipText = LanguageStrings.AppDiaryShowMiutes;
            toolStripButtonShowImageOverlays.ToolTipText = LanguageStrings.AppDiaryShowImageOverlays;
            toolStripButtonPrint.ToolTipText = LanguageStrings.AppDiaryPrintView;

            toolStripButtonEditSalonTreatments.ToolTipText = LanguageStrings.AppDiarySalonTreatments;
            toolStripButtonAdvancedSettings.ToolTipText = LanguageStrings.AppDiaryAdvancedSettings;
            toolStripButtonNewAppointments.ToolTipText = LanguageStrings.AppDiaryNewAppointments;
            toolStripButtonReports.ToolTipText = LanguageStrings.AppDiaryViewReports;
            toolStripButtonSwapUser.ToolTipText = LanguageStrings.AppSwapUser;
            toolStripButtonRevertUser.ToolTipText = LanguageStrings.AppMenuUserRevert;
        }

        #endregion Overridden Methods

        #region Public Methods

        public override int GetStatusCount()
        {
            return (statusStripSalon.Items.Count);
        }

        public override string GetStatusText(int index)
        {
            return (statusStripSalon.Items[index].Text);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStripSalon.Items[index].ToolTipText);
        }

        public void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            AppController.LocalSettings.DiaryAppointmentsCache = salonDiary1.CacheAppointments;
            AppController.LocalSettings.DiaryIgnoreworkingHours = salonDiary1.IgnoreWorkingHours;
            AppController.LocalSettings.DiaryShowCancelled = salonDiary1.ShowCancelled;
            AppController.LocalSettings.DiaryCalendarStyle = salonDiary1.Style.ToString();
            AppController.LocalSettings.DiaryMultiView = salonDiary1.TeamView;
            AppController.LocalSettings.DiaryMondayStartsWeek = salonDiary1.WeekStartsOnMonday;
            AppController.LocalSettings.DiaryShowImageOverlays = salonDiary1.ShowImageOverlays;
            AppController.LocalSettings.DiaryShowMinutes = salonDiary1.ShowMinutes;
            AppController.LocalSettings.DiaryToolBarOptions_X = toolStripOptions.Location.X;
            AppController.LocalSettings.DiaryToolBarOptions_Y = toolStripOptions.Location.Y;
            AppController.LocalSettings.DiaryToolBarSettings_X = toolStripSettings.Location.X;
            AppController.LocalSettings.DiaryToolBarSettings_Y = toolStripSettings.Location.Y;
            AppController.LocalSettings.DiaryBirthdayAlert = salonDiary1.BirthdayNotification;
            AppController.LocalSettings.DiaryAutoLock = salonDiary1.AppointmentLockTime;
            AppController.LocalSettings.DiaryAutoCompleteOnPayment = salonDiary1.AutoCompleteOnPayment;
            AppController.LocalSettings.DiaryScrollAmount = salonDiary1.ScrollAmount;
            AppController.LocalSettings.DiaryToolTipDelay = salonDiary1.ToolTipDelay;

            AppController.LocalSettings.DiaryOverlayCancelled = salonDiary1.ImageOverlaysHasCancelled;
            AppController.LocalSettings.DiaryOverlayLinkedAppoitnment = salonDiary1.ImageOverlaysLinked;
            AppController.LocalSettings.DiaryOverlayLockedAppointment = salonDiary1.ImageOverlaysLocked;
            AppController.LocalSettings.DiaryOverlayUserNotes = salonDiary1.ImageOverlaysNotes;
            AppController.LocalSettings.DiaryOverlayOverriddenHours = salonDiary1.ImageOverlaysOverridden;
            AppController.LocalSettings.DiaryOverlayNoTreatments = salonDiary1.ImageOverlaysNoTreatments;
            AppController.LocalSettings.DiaryAutoHideUsers = salonDiary1.AutoHideUsers;
            AppController.LocalSettings.DiaryShowNameFirst = salonDiary1.ShowNameFirst;

            string employees = String.Empty;

            for (int i = 0; i < salonDiary1.EmployeeCount; ++i)
                if (!String.IsNullOrEmpty(salonDiary1.EmployeeName(i)))
                    employees += String.Format(StringConstants.DIARY_HIDDEN_USER_SEPERATOR,
                        salonDiary1.EmployeeName(i), salonDiary1.EmployeeSelected(i).ToString());

            AppController.LocalSettings.DiaryViewEmployees = employees;

            AppController.LocalSettings.DiaryMaximumLunchDuration = salonDiary1.MaxLunchDuration;

            SaveColors();
        }

        #endregion Public Methods

        #region Salon Diary Methods/Events

        private void salonDiary1_AppointmentShowHistory(object sender, SalonDiary.Controls.SalonAppointmentEventArgs e)
        {
            SharedBase.BOL.Appointments.AppointmentChanges changes = e.Appointment.History();

            if (changes.Count == 0)
            {
                ShowInformation(LanguageStrings.AppDiaryApptChanges, LanguageStrings.AppDiaryApptChangesNone);
                return;
            }

            POS.Diary.Forms.AppointmentChanges changesForm = new POS.Diary.Forms.AppointmentChanges(changes);
            try
            {
                changesForm.ShowDialog(this);
            }
            finally
            {
                changesForm.Dispose();
                changesForm = null;
            }
        }

        private void salonDiary1_NotesGet(object sender, SalonDiary.Controls.NotesGetEventArgs e)
        {
            Notes notesForm = new Notes();
            try
            {
                notesForm.Text = String.Format(LanguageStrings.AppDiaryNotesForPerson, e.Title);

                notesForm.Required = e.Required;

                if (e.Required)
                    notesForm.Text = String.Format(LanguageStrings.AppDiaryNotesRequired, notesForm.Text);

                e.Result = notesForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK;
                e.Notes = notesForm.Note;
            }
            finally
            {
                notesForm.Dispose();
                notesForm = null;
            }
        }

        private void salonDiary1_AppointmentClone(object sender, SalonDiary.Controls.CloneAppointmentEventArgs e)
        {
            CloneAppointment clone = new CloneAppointment(e.Appointment);
            try
            {
                clone.ShowDialog(this);

                e.ClonedDate = clone.Date;
            }
            finally
            {
                clone.Dispose();
                clone = null;
            }
        }

        private void salonDiary1_AppointmentCreate(object sender, SalonDiary.Controls.CreateAppointmentEventArgs e)
        {
            CalendarAppointment ca = new CalendarAppointment(AppController.ActiveUser,
                e.Therapist, null, e.AppointmentDateTime, false);
            try
            {
                ca.ShowDialog(this);
            }
            finally
            {
                ca.Dispose();
                ca = null;
            }
        }

        private void salonDiary1_AppointmentEdit(object sender, SalonDiary.Controls.EditAppointmentEventArgs e)
        {
            SharedBase.BOL.Appointments.Appointment appt = e.Appointment;

            switch (appt.AppointmentType)
            {
                case 14:  // training appointment
                    if (appt.MasterAppointment > -1)
                        appt = Appointments.Get(appt.MasterAppointment);

                    bool isLocked = appt.IsLocked || appt.AppointmentDate < DateTime.Now;

                    PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                        StringConstants.PLUGIN_EVENT_EDIT_TRAINING_APPOINTMENT, appt, isLocked));

                    break;

                default:
                    CalendarAppointment ca = new CalendarAppointment(AppController.ActiveUser,
                        e.Appointment.Therapist, e.Appointment, e.Appointment.AppointmentDate, e.IsLocked);
                    try
                    {
                        ca.ShowDialog(this);
                    }
                    finally
                    {
                        ca.Dispose();
                        ca = null;
                    }

                    break;
            }
        }

        private void salonDiary1_AppointmentUserNotesShow(object sender, SalonDiary.Controls.AppointmentUserEventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(User.UserGet(e.Appointment.UserID)));
        }

        private void salonDiary1_AppointmentUserShow(object sender, SalonDiary.Controls.AppointmentUserEventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(User.UserGet(e.Appointment.UserID)));
        }

        private void salonDiary1_AppointmentStatusChanged(object sender, SalonDiary.Controls.AppointmentStatusChangedEventArgs e)
        {
            RaiseStatusChanged();

            switch (e.Appointment.Status)
            {
                case Enums.AppointmentStatus.Completed:
                    ValidateClientDetails(e.Appointment.User);

                    //check to see if want to pay now
                    if (e.Appointment.AppointmentType == 0 && ShowQuestion(LanguageStrings.AppDiaryApptPayNow,
                        LanguageStrings.AppDiaryApptTakePaymentNow))
                    {
                        RaisePayNow(e.Appointment);
                    }
                    else
                        POSValidation.Add(AppController.ActiveUser, ValidationReasons.IgnoreTakePayment,
                            String.Format(LanguageStrings.AppDiaryAppt, Shared.Utilities.MaximumLength(
                            e.Appointment.ToString(), 180)));

                    break;
                case Enums.AppointmentStatus.Arrived:
                    ValidateClientDetails(e.Appointment.User);

                    break;
            }
        }

        private void salonDiary1_EditEmployee(object sender, SalonDiary.Controls.EditEmployeeEventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.EditEmployee))
            {
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                    StringConstants.PLUGIN_EVENT_EDIT_STAFF_MEMBER, User.UserGet(e.Therapist.EmployeeID)));
            }
            else
                ShowError(LanguageStrings.AppDiaryStaffEdit, LanguageStrings.AppPermissionEditStaffMembers);

            salonDiary1.ForceRefresh(false);
        }

        private void salonDiary1_EditWorkingHours(object sender, SalonDiary.Controls.EditWorkingHoursEventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ChangeWorkingHours))
            {
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                    StringConstants.PLUGIN_EVENT_EDIT_STAFF_WORKING_HOURS, e.Therapist, e.Date, this));
            }
            else
                ShowError(LanguageStrings.AppDiaryEditWorkingHours, LanguageStrings.AppPermissionEditWorkingHours);

            salonDiary1.ForceRefresh(false);
        }

        /// <summary>
        /// Validates client details for data accuracy
        /// </summary>
        /// <param name="user">User being validated</param>
        private void ValidateClientDetails(User user)
        {
            string invalid = String.Empty;

            if (!user.ValidAddress())
            {
                invalid = StringConstants.SYMBOL_CRLF + LanguageStrings.AppAddress;
            }

            if (String.IsNullOrEmpty(user.Telephone))
            {
                invalid += StringConstants.SYMBOL_CRLF + LanguageStrings.AppDiaryUserDetailsTelephone;
            }

            if (!user.ValidBirthDate())
            {
                invalid += StringConstants.SYMBOL_CRLF + LanguageStrings.AppDiaryUserDetailsDateOfBirth;
            }

            if (!String.IsNullOrEmpty(invalid))
            {
                ShowError(LanguageStrings.AppUserDetails,
                    String.Format(LanguageStrings.AppDiaryUserDetailsWrong, invalid));

                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(user, false, true));
            }

        }

        #endregion Salon Diary Methods/Events

        #region Toolbar

        private void toolStripButtonTeamView_Click(object sender, EventArgs e)
        {
            salonDiary1.TeamView = true;
            toolStripButtonSingleView.Checked = false;
            toolStripButtonWeekStartsMonday.Enabled = false;
        }

        private void toolStripButtonSingleView_Click(object sender, EventArgs e)
        {
            salonDiary1.TeamView = false;
            toolStripButtonTeamView.Checked = false;
            toolStripButtonWeekStartsMonday.Enabled = true;
            toolStripButtonWeekStartsMonday.Checked = salonDiary1.WeekStartsOnMonday;
        }

        private void toolStripButtonIgnoreWorkingHours_Click(object sender, EventArgs e)
        {
            salonDiary1.IgnoreWorkingHours = toolStripButtonIgnoreWorkingHours.Checked;
        }

        private void toolStripButtonWeekStartsMonday_Click(object sender, EventArgs e)
        {
            salonDiary1.WeekStartsOnMonday = toolStripButtonWeekStartsMonday.Checked;
        }

        private void toolStripButtonShowCancelledAppointments_Click(object sender, EventArgs e)
        {
            salonDiary1.ShowCancelled = toolStripButtonShowCancelledAppointments.Checked;
        }

        private void toolStripButtonShowImageOverlays_Click(object sender, EventArgs e)
        {
            salonDiary1.ShowImageOverlays = toolStripButtonShowImageOverlays.Checked;
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            salonDiary1.Print();
        }

        private void toolStripButtonShowMinutes_Click(object sender, EventArgs e)
        {
            salonDiary1.ShowMinutes = toolStripButtonShowMinutes.Checked;
        }

        private void toolStripDropDownButton1_DropDownItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        {
            switch (Shared.Utilities.StrToInt((string)e.ClickedItem.Tag, 0))
            {
                case 0://Office 12
                    salonDiary1.Style = SalonDiary.CalendarStyle.Office12;
                    break;
                case 1: //Office 11
                    salonDiary1.Style = SalonDiary.CalendarStyle.Office11;
                    break;
                case 2: //Grey
                    salonDiary1.Style = SalonDiary.CalendarStyle.Grey;
                    break;
                case 3: //Blue
                    salonDiary1.Style = SalonDiary.CalendarStyle.Blue;
                    break;
                case 5: //Rounded
                    salonDiary1.Style = SalonDiary.CalendarStyle.Rounded;
                    break;
                default:
                    salonDiary1.Style = SalonDiary.CalendarStyle.Pink;
                    break;
            }
        }

        private void toolStripButtonEditSalonTreatments_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionCalendar(
                SecurityEnums.SecurityPermissionsCalendar.EditTreatments))
            {
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                    StringConstants.PLUGIN_EVENT_EDIT_SALON_TREATMENTS, null));
            }
            else
                ShowError(LanguageStrings.AppTreatmentsEdit, LanguageStrings.AppPermissionEditTreatments);
        }

        private void toolStripButtonAdvancedSettings_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.AdvancedSettings))
            {
                SalonAdvancedSettings advanced = new SalonAdvancedSettings(this);
                try
                {
                    advanced.ShowDialog(this);
                }
                finally
                {
                    advanced.Dispose();
                    advanced = null;
                }
            }
            else
                ShowError(LanguageStrings.AppSettings, LanguageStrings.AppPermissionSettings);
        }

        #endregion Toolbar

        #region Form

        private void SalonCalendar_Activated(object sender, EventArgs e)
        {
            //salonDiary1.ForceRefresh();
        }

        #endregion Form

        #region Events

        internal void RaisePayNow(SharedBase.BOL.Appointments.Appointment appointment)
        {
            if (appointment.MasterAppointment > -1)
                appointment = Appointments.Get(appointment.MasterAppointment);

            if (PayNow != null)
                PayNow(this, new SalonDiary.Controls.AppointmentPayNowEventArgs(appointment));
        }

        public event SalonDiary.Controls.PayNowEventHandler PayNow;


        internal void RaiseStatusChanged()
        {
            if (AppointmentStatusChanged != null)
                AppointmentStatusChanged(this, EventArgs.Empty);
        }

        public event EventHandler AppointmentStatusChanged;

        #endregion Events

        #region Private Methods

        private void salonDiary1_WaitingListUpdated(object sender, EventArgs e)
        {
            statusStripWaiting.Text = String.Format(LanguageStrings.AppDiaryWaitingListCount, WaitingLists.CountAll());
        }

        private void User_ReplicationComplete(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_ReplicationComplete);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                salonDiary1.ForceRefresh(true);
            }
        }

        private void User_AppointmentIDChanged(object sender, AppController.IDChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AppController.IDChangedHandler eh = new AppController.IDChangedHandler(
                    User_AppointmentIDChanged);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                salonDiary1.AppointmentIDChanged(e.OldID, e.NewID);
            }
        }

        private void User_OnUserChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_OnUserChanged);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                this.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                    LanguageStrings.AppDiarySalon, AppController.ActiveUser.UserName);
                SetCurrentUser(AppController.ActiveUser);
            }
        }

        private void LoadLocations()
        {
            toolStripComboBoxLocation.Items.Clear();
            AppointmentGroups groups = AppointmentGroups.Get();
            Therapist ther = Therapist.Get(AppController.ActiveUser.ID);
            toolStripComboBoxLocation.ComboBox.DataSource = groups;
            toolStripComboBoxLocation.ComboBox.DisplayMember = StringConstants.DATA_SOURCE_COLUMN_DESCRIPTION;
            toolStripComboBoxLocation.ComboBox.ValueMember = StringConstants.DATA_SOURCE_COLUMN_ID;

            foreach (AppointmentGroup group in toolStripComboBoxLocation.Items)
            {
                if (ther == null || (group.ID == ther.Group.ID))
                {
                    toolStripComboBoxLocation.SelectedItem = group;
                    break;
                }
            }
        }

        private void SetCurrentUser(User user)
        {
            salonDiary1.User = AppController.ActiveUser;

            if (!_activeUserGroup.ContainsKey(AppController.ActiveUser.Email))
                _activeUserGroup.Add(AppController.ActiveUser.Email, null);

            toolStripAdmin.Visible = salonDiary1.User.HasPermissionCalendar(
                SecurityEnums.SecurityPermissionsCalendar.AdministrationToolbar);

            Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppDiarySalon, AppController.ActiveUser.UserName);

            UpdateToolbarButtons();
        }

        private void LoadColors()
        {
            salonDiary1.AppointmentSelected = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentSelectedColor);
            salonDiary1.AppointmentSelectedText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentSelectedTextColor);
            salonDiary1.AppointmentRequested = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentRequestedColor);
            salonDiary1.AppointmentRequestedText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentRequestedTextColor);
            salonDiary1.AppointmentConfirmed = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentConfirmedColor);
            salonDiary1.AppointmentConfirmedText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentConfirmedTextColor);
            salonDiary1.AppointmentCancelledByUser = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentCancelledByUserColor);
            salonDiary1.AppointmentCancelledByUserText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentCancelledByUserTextColor);
            salonDiary1.AppointmentCancelledByStaff = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentCancelledByStaffColor);
            salonDiary1.AppointmentCancelledbyStaffText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentCancelledbyStaffTextColor);
            salonDiary1.AppointmentNoShow = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentNoShowColor);
            salonDiary1.AppointmentNoShowText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentNoShowTextColor);
            salonDiary1.AppointmentCompleted = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentCompletedColor);
            salonDiary1.AppointmentCompletedText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentCompletedTextColor);
            salonDiary1.AppointmentArrived = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentArrivedColor);
            salonDiary1.AppointmentArrivedText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentArrivedTextColor);
            salonDiary1.AppointmentDeleted = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentDeletedColor);
            salonDiary1.AppointmentDeletedText = ColorTranslator.FromHtml(AppController.LocalSettings.DiaryAppointmentDeletedTextColor);
        }

        private void SaveColors()
        {
            AppController.LocalSettings.DiaryAppointmentSelectedColor = salonDiary1.AppointmentSelected.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentSelectedTextColor = salonDiary1.AppointmentSelectedText.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentRequestedColor = salonDiary1.AppointmentRequested.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentRequestedTextColor = salonDiary1.AppointmentRequestedText.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentConfirmedColor = salonDiary1.AppointmentConfirmed.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentConfirmedTextColor = salonDiary1.AppointmentConfirmedText.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentCancelledByUserColor = salonDiary1.AppointmentCancelledByUser.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentCancelledByUserTextColor = salonDiary1.AppointmentCancelledByUserText.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentCancelledByStaffColor = salonDiary1.AppointmentCancelledByStaff.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentCancelledbyStaffTextColor = salonDiary1.AppointmentCancelledbyStaffText.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentNoShowColor = salonDiary1.AppointmentNoShow.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentNoShowTextColor = salonDiary1.AppointmentNoShowText.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentCompletedColor = salonDiary1.AppointmentCompleted.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentCompletedTextColor = salonDiary1.AppointmentCompletedText.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentArrivedColor = salonDiary1.AppointmentArrived.ToArgb().ToString();
            AppController.LocalSettings.DiaryAppointmentArrivedTextColor = salonDiary1.AppointmentArrivedText.ToArgb().ToString();
        }

        private void UpdateToolbarButtons()
        {
            toolStripButtonTeamView.Checked = salonDiary1.TeamView;
            toolStripButtonSingleView.Checked = !salonDiary1.TeamView;

            toolStripButtonWeekStartsMonday.Enabled = toolStripButtonSingleView.Checked;
            toolStripButtonShowImageOverlays.Checked = salonDiary1.ShowImageOverlays;
            toolStripButtonShowCancelledAppointments.Checked = salonDiary1.ShowCancelled;
            toolStripButtonIgnoreWorkingHours.Checked = salonDiary1.IgnoreWorkingHours;
            toolStripButtonShowMinutes.Checked = salonDiary1.ShowMinutes;

            toolStripButtonAdvancedSettings.Enabled = AppController.ActiveUser.HasPermissionCalendar(
                SecurityEnums.SecurityPermissionsCalendar.AdvancedSettings);
            toolStripButtonEditSalonTreatments.Enabled = AppController.ActiveUser.HasPermissionPOS(
                SecurityEnums.SecurityPermissionsPOS.AdministerSalonTreatments);

            toolStripComboBoxLocation.Enabled = AppController.ActiveUser.HasPermissionCalendar(
            SecurityEnums.SecurityPermissionsCalendar.ViewAllLocations);

            Therapist ther = Therapist.Get(AppController.ActiveUser.ID);

            foreach (AppointmentGroup group in toolStripComboBoxLocation.Items)
            {
                if (_activeUserGroup[AppController.ActiveUser.Email] == null)
                {
                    if (ther == null || (group.ID == ther.Group.ID))
                    {
                        toolStripComboBoxLocation.SelectedItem = group;
                        break;
                    }
                }
                else
                {
                    if (group.ID == _activeUserGroup[AppController.ActiveUser.Email].ID)
                    {
                        toolStripComboBoxLocation.SelectedItem = group;
                        break;
                    }
                }
            }
        }

        private void salonDiary1_PayNow(object sender, SalonDiary.Controls.AppointmentPayNowEventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.TakePayment))
                RaisePayNow(e.Appointment);
            else
                ShowError(LanguageStrings.AppTillTakePayments, LanguageStrings.AppPermissionTakePayment);
        }

        private void salonDiary1_CursorChanged(object sender, EventArgs e)
        {
            this.Cursor = salonDiary1.Cursor;
        }

        private void toolStripButtonNewAppointments_Click(object sender, EventArgs e)
        {
            NewAppointments appts = new NewAppointments();
            try
            {
                appts.newAppointments1.User = AppController.ActiveUser;
                appts.newAppointments1.Refresh();
                appts.newAppointments1.EditAppointment += new SalonDiary.Controls.NewAppointments.SalonAppointmentEventHandler(salonDiary1_AppointmentEdit);
                appts.newAppointments1.EditUser += new SalonDiary.Controls.NewAppointments.SalonUserEventHandler(newAppointments1_EditUser);
                appts.ShowDialog();
            }
            finally
            {
                appts.Dispose();
                appts = null;
            }
        }

        private void newAppointments1_EditUser(object sender, SalonDiary.Controls.SalonUserEventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(e.AppointmentUser));
        }

        private void toolStripButtonReports_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ViewReports))
            {
                Reports.Salons.CalendarReports.ViewSalonReportsA(AppController.ApplicationController.AllAppointments);
            }
            else
                ShowError(LanguageStrings.AppReports, LanguageStrings.AppPermissionReport);
        }

        private void toolStripButtonSwapUser_Click(object sender, EventArgs e)
        {
            POS.Base.Plugins.NotificationEventArgs args = new POS.Base.Plugins.NotificationEventArgs(
                StringConstants.PLUGIN_EVENT_SWITCH_USER, null);

            PluginManager.RaiseEvent(args);

            if ((bool)args.Result)
            {
                //logged in as new user
                SetCurrentUser((User)args.Param4);

                toolStripButtonRevertUser.Enabled = true;
                toolStripButtonSwapUser.Enabled = false;
            }
        }

        private void toolStripButtonRevertUser_Click(object sender, EventArgs e)
        {
            AppController.ApplicationController.Revert();
            SetCurrentUser(AppController.ActiveUser);
            toolStripButtonRevertUser.Enabled = false;
            toolStripButtonSwapUser.Enabled = true;
        }

        private void salonDiary1_MinimumDateChanged(object sender, EventArgs e)
        {
            AppController.LocalSettings.DiaryMinimumDate = salonDiary1.MinimumDate;
        }

        private void SalonCalendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            // are there uncomplete treatments?
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.ManageBookings))
            {
                int incomplete = salonDiary1.IncompleteAppointments;

                if (incomplete > 0)
                {
                    if (ShowQuestion(LanguageStrings.AppDiaryApptIncomplete,
                        LanguageStrings.AppDiaryApptIncompleteMessage))
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        POSValidation.Add(AppController.ActiveUser,
                            ValidationReasons.IgnoreIncompleteAppointments,
                            String.Empty);
                    }
                }

                // are there new appoinmets
                if (AppController.Administration.StatsAppointments(Enums.AppointmentStats.NewAppointments) > 0)
                {
                    if (ShowQuestion(LanguageStrings.AppDiaryApptNew, LanguageStrings.AppDiaryApptNewReview))
                    {
                        toolStripButtonNewAppointments_Click(this, EventArgs.Empty);
                    }
                    else
                        POSValidation.Add(AppController.ActiveUser,
                            ValidationReasons.IgnoreNewAppointments, String.Empty);
                }
            }
        }

        private void toolStripComboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppointmentGroup grp = (AppointmentGroup)toolStripComboBoxLocation.SelectedItem;
            salonDiary1.Group = grp.ID;

            _activeUserGroup[AppController.ActiveUser.Email] = grp;
        }

        private void SalonCalendar_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppController.ApplicationController.OnUserChanged -= User_OnUserChanged;
        }

        private void salonDiary1_CachedAppointmentsChanged(object sender, EventArgs e)
        {
            if (salonDiary1.CacheAppointments)
                salonDiary1.Initialise(AppController.ApplicationController.AllAppointments);
        }

        private void toolStripAdminFindAppointment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Int64 appointmentID = Shared.Utilities.StrToInt64(toolStripAdminFindAppointment.Text, -1);
                Appointment appt = AppController.ApplicationController.AllAppointments.Find(appointmentID);

                if (appt != null)
                {
                    string message = String.Format(LanguageStrings.AppDiaryApptFoundMessage,
                        appt.AppointmentDate.ToString(StringConstants.SYMBOL_DATE_FORMAT_D),
                        appt.AppointmentAsDateTime().ToString(StringConstants.SYMBOL_DATE_FORMAT_T),
                        appt.EmployeeName);

                    if (ShowQuestion(LanguageStrings.AppDiaryApptFound, message))
                    {
                        salonDiary1.Date = appt.AppointmentDate;
                        salonDiary1.SelectedAppointment = appt;
                    }
                }
                else
                {
                    ShowInformation(LanguageStrings.AppDiaryApptFind,
                        LanguageStrings.AppDiaryApptNotFound);
                }

                toolStripAdminFindAppointment.Text = String.Empty;
                e.Handled = true;
            }
        }

        private void salonDiary1_AppointmentAfterSelect(object sender,
            SalonDiary.Controls.SalonAppointmentEventArgs e)
        {
            if (e.Appointment == null)
            {
                statusStripAppointment.Text = LanguageStrings.AppDiaryNoApptSelected;
                statusStripAppointment.ToolTipText = String.Empty;
                statusStripStatus.Text = String.Empty;
                statusStripLocked.Text = String.Empty;
            }
            else
            {
                statusStripAppointment.Text = String.Format(StringConstants.PREFIX_SUFFIX_COLON,
                    e.Appointment.EmployeeName,
                    e.Appointment.AppointmentText.Replace(StringConstants.SYMBOL_CRLF_DOUBLE,
                    StringConstants.SYMBOL_HYPHON_SPACES).Replace(StringConstants
                    .SYMBOL_CRLF, StringConstants.SYMBOL_SPACE).Replace(
                    StringConstants.SYMBOL_LINE_FEED, StringConstants.SYMBOL_SPACE));
                statusStripAppointment.ToolTipText = statusStripAppointment.Text;
                statusStripStatus.Text = e.Appointment.StatusText;
                statusStripLocked.Text = String.Format(LanguageStrings.AppDiaryApptLockedByUser,
                    e.Appointment.IsLocked ? LanguageStrings.AppYes : LanguageStrings.AppNo);
            }

            statusStripLocked.Visible = !String.IsNullOrEmpty(statusStripLocked.Text);
            statusStripStatus.Visible = !String.IsNullOrEmpty(statusStripStatus.Text);

            POS.Base.Classes.PluginManager.RaiseEvent(updateStatusBar);
        }

        private void salonDiary1_OnSelectUser(object sender, SelectUserEventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                e.User = selUser.SelectedUser;
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }
        }

        private void statusStripWaiting_DoubleClick(object sender, EventArgs e)
        {
            SalonDiary.Classes.WaitingListWizardWrapper.ShowWaitingListWizard(salonDiary1);
        }

        private void salonDiary1_OnRequestSMSInterface(object sender, SalonDiary.Controls.SMSSendEventArgs e)
        {
            e.SendInterface = this;
        }

        #region SMS Sending

        bool ISMSSend.SendSMS(string telephone, string message)
        {
#warning urgent finish
            return false;
            //Shared.Communication.SendSMSTextMagic tmSender = new Shared.Communication.SendSMSTextMagic(
            //    AppController.LocalSettings.TextMagicUsername, AppController.LocalSettings.TextMagicAPI);
            //try
            //{
            //    tmSender.SMSSend(AppController.LocalSettings.TextMagicSender, telephone, message);
            //    return (true);
            //}
            //catch (Exception err)
            //{
            //    Shared.EventLog.Add(err);
            //    return (false);
            //}
            //finally
            //{
            //    tmSender = null;
            //}
        }

        bool ISMSSend.SendSMS(string from, string telephone, string message)
        {
#warning urgent finish
            return false;
            //Shared.Communication.SendSMSTextMagic tmSender = new Shared.Communication.SendSMSTextMagic(
            //    AppController.LocalSettings.TextMagicUsername, AppController.LocalSettings.TextMagicAPI);
            //try
            //{
            //    tmSender.SMSSend(from, telephone, message);
            //    return (true);
            //}
            //catch (Exception err)
            //{
            //    Shared.EventLog.Add(err);
            //    return (false);
            //}
            //finally
            //{
            //    tmSender = null;
            //}
        }

        #endregion SMS Sending

        private void notifyIconDiary_DoubleClick(object sender, EventArgs e)
        {
            this.Show();

            this.BringToFront();
            this.Focus();
        }

        #endregion Private Methods
    }

}
