using System.Globalization;
using System.Windows.Forms;

using Languages;
using SharedControls.Forms;
using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.Suppliers
{
    public class SuppliersPluginModule : BasePlugin
    {
        #region Private Members

        SuppliersCard _supplierTab;

        #endregion Private Members

        #region Constructors

        public SuppliersPluginModule(Form parent)
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
            return (LanguageStrings.AppPluginSuppliers);
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

        public override void UpdateLanguage(CultureInfo culture)
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
            HomeCards Result = new HomeCards();

            if (_supplierTab == null)
                _supplierTab = new SuppliersCard(this);

            Result.Add(_supplierTab);

            return (Result);
        }

        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        #endregion Overridden Methods
    }
}
