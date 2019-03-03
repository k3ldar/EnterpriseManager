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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CurrencyWatchPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Globalization;
using System.Windows.Forms;

using POS.CurrencyWatch.Classes;
using POS.CurrencyWatch.Controls;

using Languages;
using Shared.Classes;
using SharedControls.Forms;
using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.CurrencyWatch
{
    public class CurrencyWatchPluginModule : BasePlugin
    {
        #region Private Members

        CurrencyWatchTrayIcon _currencyWatchTrayIcon;

        CurrencyWatchCard _currencyWatchTab;

        #endregion Private Members

        #region Constructors

        public CurrencyWatchPluginModule(Form parent)
            : base (parent)
        {
            _currencyWatchTrayIcon = new CurrencyWatchTrayIcon(this);
        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginCurrencyWatch);
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
            CurrencyWatchUpdaterThread currencyThread = new CurrencyWatchUpdaterThread(AppController.LocalSettings.CurrencyBase);
            currencyThread.AfterUpdate += _currencyWatchTrayIcon.CurrencyUpdateThread_AfterUpdate;

            ThreadManager.ThreadStart(
                currencyThread,
                StringConstants.THREAD_NAME_CURRENCY_CONVERSION,
                System.Threading.ThreadPriority.Lowest);

        }

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_USER:
                    _currencyWatchTrayIcon.SettingsUpdated();
                    break;

                default:
                    foreach (HomeCard card in HomeCards())
                    {
                        card.EventRaised(e);
                    }

                    break;
            }
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppCurrencyWatch,
                Languages.LanguageStrings.AppCurrencyWatchSettings,
                null, new CurrencyWatchSettings());
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
            HomeCards Result = new HomeCards();

            if (_currencyWatchTab == null)
                _currencyWatchTab = new CurrencyWatchCard(this, _currencyWatchTrayIcon);

            Result.Add(_currencyWatchTab);

            return (Result);
        }

        public override TrayNotificationCollection TrayNotifications()
        {
            TrayNotificationCollection Result = new TrayNotificationCollection();

            Result.Add(_currencyWatchTrayIcon);

            return (Result);
        }

        #endregion Overridden Methods
    }
}
