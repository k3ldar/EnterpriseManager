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
 *  File: DatabaseBackupPluginModule.cs
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

namespace POS.DatabaseBackup
{
    class DatabaseBackupPluginModule : BasePlugin
    {
        #region Private Members

        private ToolStripMenuItem menuToolsDatabase;
        private ToolStripMenuItem menuToolsDatabaseBackup;
        private ToolStripMenuItem menuToolsDatabaseBackupUpload;
        private ToolStripSeparator menuToolsDatabaseSeperator;

        #endregion Private Members

        #region Constructors

        public DatabaseBackupPluginModule(Form parent)
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
            return (LanguageStrings.AppPluginDatabase);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            menuToolsDatabaseSeperator.Owner.Items.Remove(menuToolsDatabaseSeperator);
            menuToolsDatabaseSeperator.Dispose();
            menuToolsDatabaseSeperator = null;

            menuToolsDatabaseBackup.Owner.Items.Remove(menuToolsDatabaseBackup);
            menuToolsDatabaseBackup.Dispose();
            menuToolsDatabaseBackup = null;

            menuToolsDatabaseBackupUpload.Owner.Items.Remove(menuToolsDatabaseBackupUpload);
            menuToolsDatabaseBackupUpload.Dispose();
            menuToolsDatabaseBackupUpload = null;

            // remove the menu items
            menuToolsDatabase.Owner.Items.Remove(menuToolsDatabase);
            menuToolsDatabase.Dispose();
            menuToolsDatabase = null;
        }

        public override bool BeforeLoad()
        {
            return (Shared.Utilities.ServiceInstalled(StringConstants.SERVICE_REPLICATION_ENGINE_1));
        }

        public override void AfterLoad()
        {

            //if (AppController.LocalSettings.LastBackup )
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuToolsDatabase.Text = LanguageStrings.AppMenuBackup;
            menuToolsDatabaseBackup.Text = LanguageStrings.AppMenuBackupDatabase;
            menuToolsDatabaseBackupUpload.Text = LanguageStrings.AppMenuBackupDatabaseUpload;
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

        private void CreateToolsMenu(ToolStripMenuItem parent)
        {
            menuToolsDatabase = new ToolStripMenuItem(LanguageStrings.AppMenuBackup);
            parent.DropDownItems.Add(menuToolsDatabase);

            menuToolsDatabaseBackup = new ToolStripMenuItem(LanguageStrings.AppMenuBackupDatabase);
            menuToolsDatabaseBackup.Click += menuToolsDatabaseBackup_Click;
            menuToolsDatabase.DropDownItems.Add(menuToolsDatabaseBackup);

            menuToolsDatabaseBackupUpload = new ToolStripMenuItem(LanguageStrings.AppMenuBackupDatabaseUpload);
            menuToolsDatabaseBackupUpload.Click += menuToolsDatabaseBackupUpload_Click;
            menuToolsDatabase.DropDownItems.Add(menuToolsDatabaseBackupUpload);

            menuToolsDatabaseSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuToolsDatabaseSeperator);

        }

        private void menuToolsDatabaseBackupUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //Library.Backup.DatabaseBackupThread.OnStageChanged += DatabaseBackup_OnStageChanged;
                //Library.Backup.DatabaseBackupThread.BackupDatabase(
                //    AppController.POSFolder(FolderType.Backups, true),
                //    true, true, SharedBase.DAL.DALHelper.StoreID, 
                //    StringConstants.BACKUP_NAME, String.Empty);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, LanguageStrings.AppDatabaseBackup,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void menuToolsDatabaseBackup_Click(object sender, EventArgs e)
        {
            try
            {
                //Library.Backup.DatabaseBackupThread.OnStageChanged += DatabaseBackup_OnStageChanged;
                //Library.Backup.DatabaseBackupThread.BackupDatabase(
                //    AppController.POSFolder(FolderType.Backups, true),
                //    false, true, SharedBase.DAL.DALHelper.StoreID,
                //    StringConstants.BACKUP_NAME, String.Empty, );
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, LanguageStrings.AppErrorDatabaseBackup,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DatabaseBackup_OnStageChanged(SharedBase.Backup.DatabaseBackupStage e)
        {
            if (ParentForm.InvokeRequired)
            {
                SharedBase.Backup.DatabaseBackupEventHandler eh = new SharedBase.Backup.DatabaseBackupEventHandler(DatabaseBackup_OnStageChanged);
                ParentForm.Invoke(eh, new object[] { e });

            }
            else
            {
                RaiseEventNotification(new NotificationEventArgs(StringConstants.PLUGIN_EVENT_DATABASE_BACKUP,
                    e != SharedBase.Backup.DatabaseBackupStage.BackupComplete,
                    Shared.Utilities.SplitCamelCase(e.ToString())));
                menuToolsDatabase.Enabled = e != SharedBase.Backup.DatabaseBackupStage.BackupComplete;

            }
        }

        #endregion Private Methods
    }
}
