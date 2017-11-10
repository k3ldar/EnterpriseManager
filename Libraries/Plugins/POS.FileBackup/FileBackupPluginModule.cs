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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: FileBackupPluginModule.cs
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
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.FileBackup
{
    class FileBackupPluginModule : BasePlugin
    {
        #region Private Members

        private ToolStripMenuItem menuToolsFileBackup;

        private Shared.Classes.FileBackup _autoBackup;

        #endregion Private Members

        #region Constructors

        public FileBackupPluginModule(Form parent)
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
            return (LanguageStrings.AppPluginFileBackup);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            menuToolsFileBackup.Owner.Items.Remove(menuToolsFileBackup);
            menuToolsFileBackup.Dispose();
            menuToolsFileBackup = null;

            _autoBackup.CancelThread();
        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {
            _autoBackup = new Shared.Classes.FileBackup(GetWatchedFolders());
            Shared.Classes.ThreadManager.ThreadStart(_autoBackup, StringConstants.THREAD_NAME_FILE_BACKUP, System.Threading.ThreadPriority.Lowest);
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuToolsFileBackup.Text = LanguageStrings.AppMenuFileBackup;
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
            return (null);
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

        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private List<string> GetWatchedFolders()
        {
            List<string> Result = new List<string>();

            Result.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));

            return (Result);
        }

        private void CreateToolsMenu(ToolStripMenuItem parent)
        {
            menuToolsFileBackup = new ToolStripMenuItem(LanguageStrings.AppMenuFileBackup);
            menuToolsFileBackup.Click += menuToolsFileBackup_Click;
            parent.DropDownItems.Add(menuToolsFileBackup);
        }

        private void menuToolsFileBackup_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, LanguageStrings.AppErrorDatabaseBackup,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion Private Methods
    }
}
