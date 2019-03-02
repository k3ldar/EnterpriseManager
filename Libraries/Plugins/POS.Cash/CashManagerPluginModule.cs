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
 *  File: CashManagerPluginModule.cs
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

using POS.CashManager.Forms;

using SharedControls.Forms;
using Languages;
using SharedBase;
using POS.Base.Classes;
using POS.Base.Plugins;
using POS.CashManager.Classes;

namespace POS.CashManager
{
    class CashManagerPluginModule : BasePlugin
    {
        #region Private Members

        private ToolStripMenuItem menuAccountsCash;
        private ToolStripSeparator menuAccountsCashSeperator;

        private ToolStripMenuItem menuAccountsCashTill;
        private ToolStripMenuItem menuAccountsCashTillVerify;
        private ToolStripSeparator menuAccountsCashTillSeperator;

        private ToolStripMenuItem menuAccountsSafe;
        private ToolStripMenuItem menuAccountsSafeVerify;
        private ToolStripSeparator menuAccountsSafeSeperator;

        private ToolStripMenuItem menuAccountsPettyCash;
        private ToolStripMenuItem menuAccountsPettyCashVerify;

        #endregion Private Members

        #region Constructors

        public CashManagerPluginModule(Form parent)
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
            return (LanguageStrings.AppPluginCashManager);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            menuAccountsCashSeperator.Dispose();
            menuAccountsCashSeperator = null;

            menuAccountsCashTill.Dispose();
            menuAccountsCashTill = null;

            menuAccountsCashTillVerify.Dispose();
            menuAccountsCashTillVerify = null;

            menuAccountsCashTillSeperator.Dispose();
            menuAccountsCashTillSeperator = null;

            menuAccountsSafe.Dispose();
            menuAccountsSafe = null;

            menuAccountsSafeVerify.Dispose();
            menuAccountsSafeVerify = null;

            menuAccountsSafeSeperator.Dispose();
            menuAccountsSafeSeperator = null;

            menuAccountsPettyCash.Dispose();
            menuAccountsPettyCash = null;

            menuAccountsPettyCashVerify.Dispose();
            menuAccountsPettyCashVerify = null;

            menuAccountsCash.Dispose();
            menuAccountsCash = null;
        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {
            POS.Base.Classes.AppController.ApplicationController.OnUserChanged += POSApplication_OnUserChanged;

            if (AppController.LocalSettings.CashDrawerForceChecks)
            {
                CashDrawerRandomCheckThread cashDrawerChecks = new CashDrawerRandomCheckThread();
                cashDrawerChecks.CheckCashDrawer += cashDrawerChecks_CheckCashDrawer;
                Shared.Classes.ThreadManager.ThreadStart(cashDrawerChecks,
                    StringConstants.THREAD_NAME_CASH_DRAWER_CHECKS, System.Threading.ThreadPriority.Lowest);
            }
        }

        private void POSApplication_OnUserChanged(object sender, EventArgs e)
        {
            if (ParentForm.InvokeRequired)
            {
                EventHandler eh = new EventHandler(POSApplication_OnUserChanged);
                ParentForm.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                CashDrawerChecks();
            }
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuAccountsCash.Text = LanguageStrings.AppMenuCash;
            menuAccountsCashTill.Text = LanguageStrings.AppMenuCashTill;
            menuAccountsCashTillVerify.Text = LanguageStrings.AppMenuCashTillVerify;
            menuAccountsPettyCash.Text = LanguageStrings.AppMenuCashPettyCash;
            menuAccountsPettyCashVerify.Text = LanguageStrings.AppMenuCashPettyCashVerify;
            menuAccountsSafe.Text = LanguageStrings.AppMenuCashSafe;
            menuAccountsSafeVerify.Text = LanguageStrings.AppMenuCashSafeVerify;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppCashDrawer,
                Languages.LanguageStrings.AppCashDrawerSettings,
                null, new CashDrawerSettings()); // Cash Drawer Plugin

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
                case StringConstants.PLUGIN_EVENT_MAIN_FORM_SHOWING:
                    CashDrawerChecks();
                    break;

                case StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_ADMIN:
                    if (AppController.LocalSettings.CashDrawerForceChecks &&
                        !Shared.Classes.ThreadManager.Exists(StringConstants.THREAD_NAME_CASH_DRAWER_CHECKS))
                    {
                        CashDrawerRandomCheckThread cashDrawerChecks = new CashDrawerRandomCheckThread();
                        cashDrawerChecks.CheckCashDrawer += cashDrawerChecks_CheckCashDrawer;
                        Shared.Classes.ThreadManager.ThreadStart(cashDrawerChecks,
                            StringConstants.THREAD_NAME_CASH_DRAWER_CHECKS, System.Threading.ThreadPriority.Lowest);
                    }

                    CashDrawerChecks();
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
            names.Add(StringConstants.PLUGIN_EVENT_MAIN_FORM_SHOWING);
            names.Add(StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_ADMIN);
        }

        #endregion Notification Events


        #endregion Overridden Methods

        #region Private Methods

        private void CreateAccountsMenu(ToolStripMenuItem parent)
        {
            menuAccountsCashSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuAccountsCashSeperator);

            menuAccountsCash = new ToolStripMenuItem(LanguageStrings.AppMenuCash);
            parent.DropDownItems.Add(menuAccountsCash);

            menuAccountsCashTill = new ToolStripMenuItem(LanguageStrings.AppMenuCashTill);
            menuAccountsCashTill.Click += menuAccountsCashTill_Click;
            menuAccountsCash.DropDownItems.Add(menuAccountsCashTill);

            menuAccountsCashTillVerify = new ToolStripMenuItem(LanguageStrings.AppMenuCashTillVerify);
            menuAccountsCashTillVerify.Click += menuAccountsCashTillVerify_Click;
            menuAccountsCash.DropDownItems.Add(menuAccountsCashTillVerify);

            menuAccountsCashTillSeperator = new ToolStripSeparator();
            menuAccountsCash.DropDownItems.Add(menuAccountsCashTillSeperator);

            menuAccountsSafe = new ToolStripMenuItem(LanguageStrings.AppMenuCashSafe);
            menuAccountsSafe.Click += menuAccountsSafe_Click;
            menuAccountsCash.DropDownItems.Add(menuAccountsSafe);

            menuAccountsSafeVerify = new ToolStripMenuItem(LanguageStrings.AppMenuCashSafeVerify);
            menuAccountsSafeVerify.Click += menuAccountsSafeVerify_Click;
            menuAccountsCash.DropDownItems.Add(menuAccountsSafeVerify);

            menuAccountsSafeSeperator = new ToolStripSeparator();
            menuAccountsCash.DropDownItems.Add(menuAccountsSafeSeperator);

            menuAccountsPettyCash = new ToolStripMenuItem(LanguageStrings.AppMenuCashPettyCash);
            menuAccountsPettyCash.Click += menuAccountsPettyCash_Click;
            menuAccountsCash.DropDownItems.Add(menuAccountsPettyCash);

            menuAccountsPettyCashVerify = new ToolStripMenuItem(LanguageStrings.AppMenuCashPettyCashVerify);
            menuAccountsPettyCashVerify.Click += menuAccountsPettyCashVerify_Click;
            menuAccountsCash.DropDownItems.Add(menuAccountsPettyCashVerify);
        }

        void menuAccountsPettyCashVerify_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CashDrawer))
            {
                CashDrawerSummary.Show(ParentForm, CashDrawerType.PettyCash, LanguageStrings.AppPettyCashVerify);
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionValidatePettyCash),
                    LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAccountsPettyCash_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CashDrawer))
            {
                CashDrawerForm cashDrawer = new CashDrawerForm(CashDrawerType.PettyCash, LanguageStrings.AppPettyCash);
                try
                {
                    cashDrawer.ShowDialog(ParentForm);
                }
                finally
                {
                    cashDrawer.Dispose();
                    cashDrawer = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionEnterDataPettyCash),
                    LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAccountsSafeVerify_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CashDrawer))
            {
                CashDrawerSummary.Show(ParentForm, CashDrawerType.Safe, LanguageStrings.AppSafeVerify);
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionValidateSafe),
                    LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAccountsSafe_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CashDrawer))
            {
                CashDrawerForm cashDrawer = new CashDrawerForm(CashDrawerType.Safe, LanguageStrings.AppSafe);
                try
                {
                    cashDrawer.ShowDialog(ParentForm);
                }
                finally
                {
                    cashDrawer.Dispose();
                    cashDrawer = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionEnterDataSafe),
                    LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAccountsCashTillVerify_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CashDrawer))
            {
                CashDrawerSummary.Show(ParentForm, CashDrawerType.Till, LanguageStrings.AppTillVerify);
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionValidateCashDrawer),
                    LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAccountsCashTill_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CashDrawer))
            {
                CashDrawerForm cashDrawer = new CashDrawerForm(CashDrawerType.Till, LanguageStrings.AppTill);
                try
                {
                    cashDrawer.ShowDialog(ParentForm);
                }
                finally
                {
                    cashDrawer.Dispose();
                    cashDrawer = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionEnterDataCashDrawer),
                    LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        #region Cash Drawer

        private void CashDrawerChecks()
        {
            if (AppController.ActiveUser.ID != -1)
            {
                CashDrawerStartOfDayChecksThread startOfDayThread = new CashDrawerStartOfDayChecksThread();
                startOfDayThread.ForceStartOfDay += startOfDayThread_ForceStartOfDay;
                Shared.Classes.ThreadManager.ThreadStart(startOfDayThread, StringConstants.THREAD_NAME_START_OF_DAY_CASH_DRAWER, System.Threading.ThreadPriority.Normal);
            }
        }

        private void startOfDayThread_ForceStartOfDay(object sender, EventArgs e)
        {
            if (ParentForm.InvokeRequired)
            {
                EventHandler eh = new EventHandler(startOfDayThread_ForceStartOfDay);
                ParentForm.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                CashDrawerForm.StartOfDayChecks();
            }
        }

        private void cashDrawerChecks_CheckCashDrawer(object sender, ValidateCashDrawer e)
        {
            if (ParentForm.InvokeRequired)
            {
                CheckCashDrawerHandler ccdh = new CheckCashDrawerHandler(cashDrawerChecks_CheckCashDrawer);
                ParentForm.Invoke(ccdh, new object[] { sender, e });
            }
            else
            {
                if (CashDrawerForm.SpotCheck(ParentForm, e.AllowByPass))
                    e.Result = true;
            }
        }

        #endregion Cash Drawer

        #endregion Private Methods
    }
}
