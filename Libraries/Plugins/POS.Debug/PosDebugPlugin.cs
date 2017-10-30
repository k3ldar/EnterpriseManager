using System;
using System.Collections.Generic;
using System.Windows.Forms;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Debug
{
    public class PosDebugPlugin : BasePlugin
    {
        #region Private Members

        private DebugCard _debugTab;

        private ToolStripMenuItem _debugMenu;

        #endregion Private Members

        #region Constructors

        public PosDebugPlugin(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override void AfterLoad()
        {

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

            if (_debugTab == null)
                _debugTab = new DebugCard(this);

            Result.Add(_debugTab);

            return (Result);
        }

        public override void LoadAdministrationSettings(SharedControls.Forms.FormSettings settingsForm)
        {

        }

        public override void LoadUserSettings(SharedControls.Forms.FormSettings settingsForm)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, System.Windows.Forms.MenuStrip mainMenu)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, System.Windows.Forms.ToolStripMenuItem parentMenu)
        {
            if (menuType == PluginMenuType.Tools)
            {
                _debugMenu = new ToolStripMenuItem(Languages.LanguageStrings.AppMenuDebug);
                _debugMenu.Click += _debugMenu_Click;
                parentMenu.DropDownItems.Add(_debugMenu);
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
            names.Add(StringConstants.PLUGIN_EVENT_DATABASE_BACKUP);
            names.Add(StringConstants.PLUGIN_EVENT_TAKE_PAYMENT);
            names.Add(StringConstants.PLUGIN_EVENT_PLUGIN_LOADED);
            names.Add(StringConstants.PLUGIN_EVENT_PLUGIN_UNLOADED);
            names.Add(StringConstants.PLUGIN_EVENT_MAIN_FORM_SHOWING);
            names.Add(StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_USER);
            names.Add(StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_ADMIN);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_PRODUCT_ITEM);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_CUSTOMER);
            names.Add(StringConstants.PLUGIN_EVENT_SHOW_TILL_DISCOUNT);
            names.Add(StringConstants.PLUGIN_EVENT_SHOW_CUSTOM_VAT_RATE);
            names.Add(StringConstants.PLUGIN_EVENT_SHOW_MARK_AS_PAID);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_TRAINING_APPOINTMENT);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_APPOINTMENT);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_SALON_TREATMENTS);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_STAFF_WORKING_HOURS);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_STAFF_MEMBER);
            names.Add(StringConstants.PLUGIN_EVENT_SWITCH_USER);
            names.Add(StringConstants.PLUGIN_EVENT_VIEW_TICKET);
            names.Add(StringConstants.PLUGIN_EVENT_CHANGE_STATUSBAR);
            names.Add(StringConstants.PLUGIN_EVENT_SELECT_SALON);
            names.Add(StringConstants.PLUGIN_EVENT_VIEW_INVOICE);
            names.Add(StringConstants.PLUGIN_EVENT_VIEW_ORDER);
            names.Add(StringConstants.PLUGIN_EVENT_VIEW_INVOICES_RECEIVED);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_SALON);
            names.Add(StringConstants.PLUGIN_EVENT_LOAD_ADMIN_SETTINGS);
            names.Add(StringConstants.PLUGIN_EVENT_HOST_VERSION);
            names.Add(StringConstants.PLUGIN_EVENT_NEW_POS_VERSION);
            names.Add(StringConstants.PLUGIN_EVENT_RAISE_LOGOUT_WARNING);
            names.Add(StringConstants.PLUGIN_EVENT_TOAST_NOTIFICATION);
            names.Add(StringConstants.PLUGIN_EVENT_UPDATE_STATUS_BAR);
            names.Add(StringConstants.PLUGIN_EVENT_WEBSITE_MODULE);
            names.Add(StringConstants.PLUGIN_EVENT_WEBSITE_COUNT);
            names.Add(StringConstants.PLUGIN_EVENT_LEAVE_ADD);
            names.Add(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
            names.Add(StringConstants.PLUGIN_EVENT_TREATMENT_ADD_REMOVE_UPDATE);
            names.Add(StringConstants.PLUGIN_EVENT_STOCK_COUNT_CHANGED);
            names.Add(StringConstants.PLUGIN_EVENT_INVOICE_CREATED);
            names.Add(StringConstants.PLUGIN_EVENT_ORDER_DISPATCHED);
            names.Add(StringConstants.PLUGIN_EVENT_ORDER_PROCESS_STATUS_CHANGED);
        }

        public override string PluginName()
        {
            return (Languages.LanguageStrings.AppPluginDebug);
        }

        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        public override void Unload()
        {
            if (_debugMenu != null)
            {
                _debugMenu.Owner.Items.Remove(_debugMenu);
                _debugMenu.Dispose();
                _debugMenu = null;
            }
        }

        public override void UpdateLanguage(System.Globalization.CultureInfo culture)
        {
            _debugMenu.Text = Languages.LanguageStrings.AppMenuDebug;
        }

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void _debugMenu_Click(object sender, EventArgs e)
        {
            _debugTab.HomeTabButton.ForceClick();
        }

        #endregion Private Methods
    }
}
