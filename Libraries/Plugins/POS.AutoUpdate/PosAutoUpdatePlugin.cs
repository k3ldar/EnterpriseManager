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
 *  File: PosAutoUpdatePlugin.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Languages;
using POS.AutoUpdate.Classes;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.AutoUpdate
{
    public class PosAutoUpdatePlugin : BasePlugin
    {
        #region Private Members

        private AutomaticUpdatesCard _automaticUpdatesTab;

        private ToolStripMenuItem _autoUpdatesMenu;
        private RunAutoUpdatesThread _runUpdateThread;

        #endregion Private Members

        #region Constructors

        public PosAutoUpdatePlugin(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override void AfterLoad()
        {
            _runUpdateThread = new RunAutoUpdatesThread();
            Shared.Classes.ThreadManager.ThreadStart(_runUpdateThread,
                POS.Base.Classes.StringConstants.THREAD_NAME_EXECUTE_AUTO_UPDATES, System.Threading.ThreadPriority.Lowest);
        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override bool CanClose()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_automaticUpdatesTab == null)
                _automaticUpdatesTab = new AutomaticUpdatesCard(this);

            Result.Add(_automaticUpdatesTab);

            return (Result);
        }

        public override void LoadAdministrationSettings(SharedControls.Forms.FormSettings settingsForm)
        {

        }

        public override void LoadUserSettings(SharedControls.Forms.FormSettings settingsForm)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            if (menuType == PluginMenuType.AdministrationTools)
            {
                _autoUpdatesMenu = new ToolStripMenuItem(LanguageStrings.AppMenuDebug);
                _autoUpdatesMenu.Click += autoUpdatesMenu_Click;
                _autoUpdatesMenu.ShortcutKeys = Keys.Alt | Keys.A;
                parentMenu.DropDownItems.Add(_autoUpdatesMenu);
            }
        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

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

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginDebug);
        }

        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        public override void Unload()
        {
            if (_autoUpdatesMenu != null)
            {
                _autoUpdatesMenu.Owner.Items.Remove(_autoUpdatesMenu);
                _autoUpdatesMenu.Dispose();
                _autoUpdatesMenu = null;
            }

            Shared.Classes.ThreadManager.Cancel(_runUpdateThread.Name);
        }

        public override void UpdateLanguage(System.Globalization.CultureInfo culture)
        {
            _autoUpdatesMenu.Text = LanguageStrings.AppMenuAutoUpdate;
        }

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void autoUpdatesMenu_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SharedBase.SecurityEnums.SecurityPermissionsPOS.ManageAutoUpdates))
            {
                _automaticUpdatesTab.HomeTabButton.ForceClick();
            }
            else
            {

            }
        }

        #endregion Private Methods
    }
}
