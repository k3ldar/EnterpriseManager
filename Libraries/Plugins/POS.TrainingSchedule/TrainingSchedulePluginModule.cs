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
 *  File: TrainingSchedulePluginModule.cs
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
using SharedBase.BOL.Appointments;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.TrainingSchedule.Forms;

namespace POS.TrainingSchedule
{
    class TrainingSchedulePluginModule : BasePlugin
    {
        #region Private Members

        TrainingScheduleCard _trainingScheduleTab;

        private ToolStripMenuItem menuToolsTraining;
        private ToolStripSeparator menuToolsTrainingSeperator;

        #endregion Private Members

        #region Constructors

        public TrainingSchedulePluginModule(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginTrainingSchedule);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            // remove the menu items
            menuToolsTraining.Owner.Items.Remove(menuToolsTraining);
            menuToolsTraining.Dispose();
            menuToolsTraining = null;

            menuToolsTrainingSeperator.Owner.Items.Remove(menuToolsTrainingSeperator);
            menuToolsTrainingSeperator.Dispose();
            menuToolsTrainingSeperator = null;
        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {

        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuToolsTraining.Text = LanguageStrings.AppMenuTrainingSchedule;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {

        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override bool CanClose()
        {
            return (true);
        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Tools:
                    CreateToolsMenu(parentMenu);
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

            if (_trainingScheduleTab == null)
                _trainingScheduleTab = new TrainingScheduleCard(this);

            Result.Add(_trainingScheduleTab);

            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_EDIT_TRAINING_APPOINTMENT:
                    EditTrainingAppointment((Appointment)e.EventValue, (bool)e.Param1);
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
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_TRAINING_APPOINTMENT);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void EditTrainingAppointment(Appointment appt, bool isLocked)
        {
            EditTrainingAppointment ta = new EditTrainingAppointment(appt, isLocked);
            try
            {
                ta.ShowDialog(ParentForm);
            }
            finally
            {
                ta.Dispose();
                ta = null;
            }

        }
        private void CreateToolsMenu(ToolStripMenuItem parent)
        {
            menuToolsTrainingSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuToolsTrainingSeperator);

            menuToolsTraining = new ToolStripMenuItem(LanguageStrings.AppMenuTrainingSchedule);
            menuToolsTraining.Click += menuToolsTraining_Click;
            parent.DropDownItems.Add(menuToolsTraining);
        }

        void menuToolsTraining_Click(object sender, EventArgs e)
        {
            _trainingScheduleTab.HomeTabButton.ForceClick();
        }

        #endregion Private Methods
    }
}
