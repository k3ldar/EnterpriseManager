using System;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;


using POS.Base.Classes;
using POS.Base.Plugins;

using System.Collections.Generic;

namespace POS.Orders
{
    public class OrdersPluginModule : BasePlugin
    {
        #region Private Members

        private OrderDispatchCard _orderDispatchTab;

        private TrayNotificationCollection _trayNotifications = new TrayNotificationCollection();
        private ToolStripMenuItem _menuOrderDispatch;
        private ToolStripSeparator _menuSeperator1;

        #endregion Private Members

        #region Constructors

        public OrdersPluginModule(Form parent)
            : base(parent)
        {
        }

        #endregion Constructors

        #region Overridden Methods

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginOrders);
        }

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

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

        public override void Unload()
        {
            // do nothing
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            if (_menuOrderDispatch != null)
                _menuOrderDispatch.Text = LanguageStrings.AppMenuButtonOrderDispatch;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            TreeNode parent = settingsForm.LoadControlOption(Languages.LanguageStrings.AppOrderManager,
                Languages.LanguageStrings.AppOrderManagerSettings,
                null, new Controls.OrderManagerSettings());

            settingsForm.LoadControlOption(Languages.LanguageStrings.AppRecordedDelivery,
                Languages.LanguageStrings.AppRecordedDeliveryDescription,
                parent, new Controls.RecordedDeliverySettings());

            settingsForm.LoadControlOption(Languages.LanguageStrings.AppPrinting,
                Languages.LanguageStrings.AppPrintSettings,
                parent, new Controls.PrintSettings());
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Tools:
                    CreateToolMenuItems(parentMenu);
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
            HomeCards Result = new HomeCards();

            if (_orderDispatchTab == null)
                _orderDispatchTab = new OrderDispatchCard(this);

            Result.Add(_orderDispatchTab);
            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            _trayNotifications.Add(new OrdersTrayStatus(this));
            return (_trayNotifications);
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

            names.Add(StringConstants.PLUGIN_EVENT_ORDER_PROCESS_STATUS_CHANGED);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Internal Methods

        internal void ResetTrayNotifications()
        {
            foreach (TrayNotification notification in _trayNotifications)
            {
                notification.LastUpdated = DateTime.Now.AddMinutes(-10);
            }
        }

        #endregion Internal Methods

        #region Private Methods


        private void CreateToolMenuItems(ToolStripMenuItem parent)
        {
            _menuOrderDispatch = new ToolStripMenuItem(LanguageStrings.AppMenuButtonOrderDispatch);
            _menuOrderDispatch.Click += menuOrderDispatch_Click;
            _menuOrderDispatch.ShortcutKeys = Keys.Alt | Keys.D;
            parent.DropDownItems.Insert(0, _menuOrderDispatch);

            _menuSeperator1 = new ToolStripSeparator();
            parent.DropDownItems.Insert(1, _menuSeperator1);

        }

        private void menuOrderDispatch_Click(object sender, EventArgs e)
        {
            _orderDispatchTab.HomeTabButton.ForceClick();
        }

        #endregion Private Methods
    }
}
