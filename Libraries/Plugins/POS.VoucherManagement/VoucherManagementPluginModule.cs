using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using Library;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.VoucherManagement
{
    class VoucherManagementPluginModule : BasePlugin
    {
        #region Private Members

        private VoucherManagementCard _voucherTab;

        private ToolStripMenuItem menuToolsVoucherManagement;
        private ToolStripSeparator menuToolsVoucherManagementSeperator;

        #endregion Private Members

        #region Constructors

        public VoucherManagementPluginModule(Form parent)
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
            return (LanguageStrings.AppPluginVoucherManagement);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            menuToolsVoucherManagementSeperator.Owner.Items.Remove(menuToolsVoucherManagementSeperator);
            menuToolsVoucherManagementSeperator.Dispose();
            menuToolsVoucherManagementSeperator = null;

            // remove the menu items
            menuToolsVoucherManagement.Owner.Items.Remove(menuToolsVoucherManagement);
            menuToolsVoucherManagement.Dispose();
            menuToolsVoucherManagement = null;
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
            menuToolsVoucherManagement.Text = LanguageStrings.AppMenuVoucherManagement;
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
                case PluginMenuType.Tools:
                    CreateToolsMenu(parentMenu);
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
            if (_voucherTab == null)
                _voucherTab = new VoucherManagementCard(this);

            HomeCards Result = new HomeCards();
            Result.Add(_voucherTab);
            return (Result);
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

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void CreateToolsMenu(ToolStripMenuItem parent)
        {
            menuToolsVoucherManagementSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuToolsVoucherManagementSeperator);

            menuToolsVoucherManagement = new ToolStripMenuItem(LanguageStrings.AppMenuVoucherManagement);
            menuToolsVoucherManagement.Click += menuToolsVoucherManagement_Click;
            parent.DropDownItems.Add(menuToolsVoucherManagement);
        }

        void menuToolsVoucherManagement_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerVoucherManagement))
            {
                _voucherTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionManageVouchers), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Private Methods
    }
}
