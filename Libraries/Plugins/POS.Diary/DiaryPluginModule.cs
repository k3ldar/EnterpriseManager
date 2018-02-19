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
 *  File: DiaryPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;
using Library;
using Library.BOL.Appointments;
using Library.BOL.Users;
using Library.BOL.Therapists;
using Library.BOL.ValidationChecks;

using POS.Base.Classes;
using POS.Base.Plugins;
using POS.Diary.Forms;
using POS.Diary.Classes;

namespace POS.Diary
{
    public class DiaryPluginModule : BasePlugin
    {
        #region Private Members

        private TrayNotificationCollection _trayNotifications = new TrayNotificationCollection();

        private DiaryCard _diaryTab;

        private ToolStripSeparator _menuSeperator;
        private ToolStripMenuItem _menuDiary;

        private ToolStripSeparator _menuAdministrationSalonTreatmentsSeperator;
        private ToolStripMenuItem _menuAdministrationSalonTreatments;

        #endregion Private Members

        #region Constructors

        public DiaryPluginModule(Form parent)
            : base(parent)
        {
        }

        #endregion Constructors

        #region Overridden Methods

        /// <summary>
        /// Gets the name of the Plugin
        /// </summary>
        /// <returns></returns>
        public override string PluginName()
        {
            return (LanguageStrings.AppPluginDiary);
        }

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override void AfterLoad()
        {

        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override bool CanClose()
        {
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.NewAppointments) &&
                AppController.Administration.StatsAppointments(Enums.AppointmentStats.NewAppointments) > 0)
            {
                if (!Shared.Classes.Parameters.GetOption(StringConstants.PARAM_IGNORE_CHECKS, false))
                {
                    if (MessageBox.Show(LanguageStrings.AppReviewAppointments, LanguageStrings.AppNewAppointments,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    else
                        POSValidation.Add(AppController.ActiveUser, ValidationReasons.IgnoreNewAppointments, String.Empty);
                }
            }

            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            // do nothing
        }

        /// <summary>
        /// Method for update of culture
        /// </summary>
        /// <param name="culture"></param>
        public override void UpdateLanguage(CultureInfo culture)
        {

        }

        /// <summary>
        /// Allows the plugin to Load settings within the Administration Settings Panel
        /// </summary>
        /// <param name="settingsForm"></param>
        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppSMS,
                Languages.LanguageStrings.AppTextMagic,
                null, new Controls.TextMagic());
        }

        /// <summary>
        /// Allows the plugin to load settings within the user settings panel
        /// </summary>
        /// <param name="settingsForm"></param>
        public override void LoadUserSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppDiary,
                Languages.LanguageStrings.AppDiarySettings,
                null, new Controls.DiarySettings());
        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Tools:
                    CreateToolMenuItems(parentMenu);
                    break;
                case PluginMenuType.Administration:
                    CreateAdminMenuItems(parentMenu);
                    break;
            }
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {

        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_diaryTab == null)
                _diaryTab = new DiaryCard(this);

            Result.Add(_diaryTab);

            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            _trayNotifications.Add(new NewAppointmentsTrayNotification(this));
            _trayNotifications.Add(new TodaysAppointmentsTrayNotification(this));
            _trayNotifications.Add(new AppointmentsInProgressTrayNotification(this));

            return (_trayNotifications);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_EDIT_APPOINTMENT:
                    EditAppointment((Appointment)e.EventValue);
                    break;

                default:
                    foreach (HomeCard card in HomeCards())
                    {
                        card.EventRaised(e);
                    }

                    break;
            }
        }

        public override void NotificationsGet(ref List<string> names)
        {
            base.NotificationsGet(ref names);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_APPOINTMENT);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Internal Methods

        internal void ResetTrayNotifications()
        {
            foreach (TrayNotification notification in _trayNotifications)
            {
                notification.LastUpdated = DateTime.Now.AddDays(-10);
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private void EditAppointment(Appointment appt)
        {
            CalendarAppointment ap = new CalendarAppointment(User.UserGet(appt.UserID), Therapist.Get(appt.EmployeeID),
                appt, appt.AppointmentDate, true);
            try
            {
                ap.ShowDialog(ParentForm);
            }
            finally
            {
                ap.Dispose();
                ap = null;
            }
        }

        #region Edit New Appointments

        private void newAppointments1_EditUser(object sender, SalonDiary.Controls.SalonUserEventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(e.AppointmentUser));
        }

        private void salonDiary1_AppointmentEdit(object sender, SalonDiary.Controls.EditAppointmentEventArgs e)
        {
            Library.BOL.Appointments.Appointment appt = e.Appointment;

            switch (appt.AppointmentType)
            {
                case 14:  // training appointment
                    if (appt.MasterAppointment > -1)
                        appt = Library.BOL.Appointments.Appointments.Get(appt.MasterAppointment);

                    bool isLocked = appt.IsLocked || appt.AppointmentDate < DateTime.Now;

                    PluginManager.RaiseEvent(new NotificationEventArgs(StringConstants.PLUGIN_EVENT_EDIT_TRAINING_APPOINTMENT, appt, isLocked));

                    break;

                default:
                    CalendarAppointment ca = new CalendarAppointment(AppController.ActiveUser, e.Appointment.Therapist, e.Appointment, e.Appointment.AppointmentDate, e.IsLocked);
                    try
                    {
                        ca.ShowDialog(ParentForm);
                    }
                    finally
                    {
                        ca.Dispose();
                        ca = null;
                    }

                    break;
            }
        }

        #endregion Edit New Appointments

        private void CreateAdminMenuItems(ToolStripMenuItem parent)
        {
            if (parent.HasDropDownItems)
            {
                _menuAdministrationSalonTreatmentsSeperator = new ToolStripSeparator();
                parent.DropDownItems.Add(_menuAdministrationSalonTreatmentsSeperator);
            }

            _menuAdministrationSalonTreatments = new ToolStripMenuItem(LanguageStrings.AppMenuSalonTreatments);
            _menuAdministrationSalonTreatments.Click += _menuAdministrationSalonTreatments_Click;
            _menuAdministrationSalonTreatments.ShortcutKeys = Keys.Alt | Keys.T;
            parent.DropDownItems.Add(_menuAdministrationSalonTreatments);
        }

        private void CreateToolMenuItems(ToolStripMenuItem parent)
        {
            if (parent.HasDropDownItems)
            {
                _menuSeperator = new ToolStripSeparator();
                parent.DropDownItems.Add(_menuSeperator);
            }

            _menuDiary = new ToolStripMenuItem(LanguageStrings.AppMenuButtonSalonDiary);
            _menuDiary.ShortcutKeys = Keys.F6;
            _menuDiary.Click += _menuDiary_Click;
            parent.DropDownItems.Add(_menuDiary);
        }

        private void _menuDiary_Click(object sender, EventArgs e)
        {
            _diaryTab.HomeTabButton.ForceClick();
        }

        private void _diaryButton_POSBringToFront(object sender, EventArgs e)
        {
            base.OnRaiseBringToFront(EventArgs.Empty);
        }

        private void _diaryButton_PluginUsage(object sender, PluginUsageEventArgs e)
        {
            base.OnRaisePluginUsage(e);
        }

        private void _menuAdministrationSalonTreatments_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerSalonTreatments))
            {
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                    StringConstants.PLUGIN_EVENT_EDIT_SALON_TREATMENTS, null));
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionSalonTreatments), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Private Methods
    }
}
