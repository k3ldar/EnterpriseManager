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
 *  File: UpdatePOSPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Languages;
using POS.Base.Classes;
using POS.Base.Plugins;
using POS.UpdateImages.Classes;

namespace POS.Updater
{
    public class UpdatePOSPluginModule : BasePlugin
    {

        #region Constructors

        public UpdatePOSPluginModule(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region  Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginPOSUpdater);
        }

        public override bool CanUnload()
        {
            return (true);
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
            Shared.Classes.ThreadManager.ThreadStart(new UpdatePOSInstallerThread(),
                StringConstants.THREAD_NAME_POS_INSTALL_UPDATER, ThreadPriority.BelowNormal);
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

        public override void UpdateLanguage(CultureInfo culture)
        {

        }

        public override void LoadAdministrationSettings(SharedControls.Forms.FormSettings settingsForm)
        {

        }

        public override void LoadUserSettings(SharedControls.Forms.FormSettings settingsForm)
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
    }
}
