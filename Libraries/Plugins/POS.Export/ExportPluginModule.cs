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
 *  File: ExportPluginModule.cs
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
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Export
{
    class ExportPluginModule : BasePlugin
    {
        #region Private Members

        private ToolStripMenuItem menuAccountsExportSage;
        private ToolStripSeparator menuAccountsExportSageSeperator;

        #endregion Private Members

        #region Constructors

        public ExportPluginModule(Form parent)
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
            return (LanguageStrings.AppPluginExport);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            menuAccountsExportSageSeperator.Owner.Items.Remove(menuAccountsExportSageSeperator);
            menuAccountsExportSageSeperator.Dispose();
            menuAccountsExportSageSeperator = null;

            menuAccountsExportSage.Owner.Items.Remove(menuAccountsExportSage);
            menuAccountsExportSage.Dispose();
            menuAccountsExportSage = null;
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
            menuAccountsExportSage.Text = LanguageStrings.AppMenuExportSage;
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
                case PluginMenuType.Accounts:
                    CreateAccountsMenu(parentMenu);
                    break;
                case PluginMenuType.Administration:

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
                case StringConstants.PLUGIN_EVENT_PLUGIN_UNLOADED:
                    if (menuAccountsExportSageSeperator.Selected)
                    {

                    }

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
            names.Add(StringConstants.PLUGIN_EVENT_PLUGIN_UNLOADED);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void CreateAccountsMenu(ToolStripMenuItem parent)
        {
            menuAccountsExportSageSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuAccountsExportSageSeperator);

            menuAccountsExportSage = new ToolStripMenuItem(LanguageStrings.AppMenuExportSage);
            menuAccountsExportSage.Click += menuAccountsExportSage_Click;
            parent.DropDownItems.Add(menuAccountsExportSage);
        }

        void menuAccountsExportSage_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ExportToSage))
            {
                this.ParentForm.Cursor = Cursors.WaitCursor;
                try
                {
                    string sFile = Shared.Utilities.CurrentPath(true) + StringConstants.FILE_SAGE_EXPORT;
                    ProcessStatuses status = ProcessStatuses.Processing | ProcessStatuses.OrderReceived;
                    SageUsers su = new SageUsers(AppController.ActiveUser, sFile, status);

                    Forms.frmExportSelectDate frm = new Forms.frmExportSelectDate();
                    try
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            int count = su.Execute(frm.DateFrom);

                            MessageBox.Show(String.Format(LanguageStrings.AppExportSageComplete, sFile, count),
                                LanguageStrings.AppExportComplete,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    finally
                    {
                        frm.Close();
                        frm.Dispose();
                        frm = null;
                    }
                }
                finally
                {
                    this.ParentForm.Cursor = Cursors.Arrow;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppExportToSage), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Private Methods
    }
}
