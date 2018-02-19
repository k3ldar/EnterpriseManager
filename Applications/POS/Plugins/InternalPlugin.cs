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
 *  File: InternalPlugin.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;
using System.Collections.Generic;

namespace PointOfSale.Plugins
{
    internal class InternalPlugin : BasePlugin
    {
        #region Constructor

        internal InternalPlugin(Form parent)
            : base(parent)
        {

        }

        #endregion Constructor

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.VersionInternal);
        }

        public override string PluginName()
        {
            return (StringConstants.PLUGIN_MODULE_INTERNAL);
        }

        public override bool CanUnload()
        {
            return (false);
        }

        public override void Unload()
        {

        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {

        }

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_RAISE_LOGOUT_WARNING:
                    ((Forms.MainForm)ParentForm).RaiseLogoutWarning(this, EventArgs.Empty);

                    break;

                case StringConstants.PLUGIN_EVENT_SWITCH_USER:
                    User newUser = AppController.ActiveUser;
                    e.Result = SwitchUser(ref newUser);
                    e.Param4 = newUser;
                    e.AllowContinue = false;

                    break;

                case StringConstants.PLUGIN_EVENT_DATABASE_BACKUP:
                    bool backupComplete = (bool)e.EventValue;
                    ((Forms.MainForm)ParentForm).ShowStatusBar(backupComplete, (string)e.Param1);
                    e.AllowContinue = false;

                    break;

                case StringConstants.PLUGIN_EVENT_LOAD_ADMIN_SETTINGS:
                    e.Result = Classes.AdminSettingsWrapper.LoadAdminSettings(ParentForm);
                    e.AllowContinue = false;

                    break;

                case StringConstants.PLUGIN_EVENT_HOST_VERSION:
                    e.Result = Application.ProductVersion.ToString();
                    e.AllowContinue = false;

                    break;

                case StringConstants.PLUGIN_EVENT_NEW_POS_VERSION:
                    ((Forms.MainForm)ParentForm).NewVersionAvailable();
                    e.AllowContinue = false;

                    break;

                case StringConstants.PLUGIN_EVENT_TOAST_NOTIFICATION:
                    if ((Shared.ToastEventType)e.EventValue == Shared.ToastEventType.None)
                    {
                        e.Result = ((Forms.MainForm)ParentForm).ShowToastNotification((string)e.Param1,
                            (string)e.Param2, (string)e.Param3);
                        e.AllowContinue = false;
                    }

                    break;

                case StringConstants.PLUGIN_EVENT_ORDER_PROCESS_STATUS_CHANGED:
                case StringConstants.PLUGIN_EVENT_INVOICE_CREATED:
                case StringConstants.PLUGIN_EVENT_UPDATE_STATUS_BAR:
                    ((Forms.MainForm)ParentForm).RaiseUpdateStatusBars(this, EventArgs.Empty);

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

            names.Add(StringConstants.PLUGIN_EVENT_RAISE_LOGOUT_WARNING);
            names.Add(StringConstants.PLUGIN_EVENT_SWITCH_USER);
            names.Add(StringConstants.PLUGIN_EVENT_DATABASE_BACKUP);
            names.Add(StringConstants.PLUGIN_EVENT_LOAD_ADMIN_SETTINGS);
            names.Add(StringConstants.PLUGIN_EVENT_HOST_VERSION);
            names.Add(StringConstants.PLUGIN_EVENT_NEW_POS_VERSION);
            names.Add(StringConstants.PLUGIN_EVENT_TOAST_NOTIFICATION);
            names.Add(StringConstants.PLUGIN_EVENT_UPDATE_STATUS_BAR);
            names.Add(StringConstants.PLUGIN_EVENT_ORDER_PROCESS_STATUS_CHANGED);
            names.Add(StringConstants.PLUGIN_EVENT_INVOICE_CREATED);
        }

        public override void UpdateLanguage(System.Globalization.CultureInfo culture)
        {

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

        public override void MenuAdd(PluginMenuType menuType, System.Windows.Forms.ToolStripMenuItem parentMenu)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, System.Windows.Forms.MenuStrip mainMenu)
        {

        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

        public override HomeCards HomeCards()
        {
            return (null);
        }

        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        #endregion Overridden Methods

        #region Private Methods

        private bool SwitchUser(ref User newUser)
        {
            bool Result = false;

            if (Forms.Other.LoginForm.DoLogin(ref newUser, LanguageStrings.AppSwapUser, false))
            {
                AppController.ApplicationController.GetUser = newUser;
            }

            return (Result);
        }


        #endregion Private Methods
    }
}
