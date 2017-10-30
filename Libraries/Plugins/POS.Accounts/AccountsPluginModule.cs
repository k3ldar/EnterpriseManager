using System.Globalization;
using System.Windows.Forms;

using Languages;
using SharedControls.Forms;

using POS.Accounts.Controls;
using POS.Base.Classes;
using POS.Base.Plugins;
using System.Collections.Generic;

namespace POS.Accounts
{
    public class AccountsPluginModule : BasePlugin
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public AccountsPluginModule(Form parent)
            : base (parent)
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
            return (LanguageStrings.AppPluginAccounts);
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
            
        }

        public override void NotificationsGet(ref List<string> names)
        {
            names.Add(StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_USER);
        }

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_USER:
                    
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
            settingsForm.LoadControlOption(LanguageStrings.AppAccounts,
                LanguageStrings.AppAccountSettings,
                null, new AccountsSettings());
            
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
    }
}
