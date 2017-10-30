using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Customers.Forms;

namespace POS.Customers
{
    public class CustomersPluginModule : BasePlugin
    {
        #region Private Members

        private List<AdminMemberEdit> _loadedCustomers = new List<AdminMemberEdit>();

        private CustomerAffiliateCard _affiliateTab;
        private CustomerSearchCard _searchTab;

        private ToolStripSeparator _menuSeperator;
        private ToolStripMenuItem _menuCustomer;
        private ToolStripMenuItem _menuCustomerSearch;
        private ToolStripMenuItem _menuCustomerMerge;
        private ToolStripSeparator _menuCustomerExportSeperator;
        private ToolStripMenuItem _menuCustomerExport;

        private ToolStripSeparator _menuCustomerAffiliateSeperator;
        private ToolStripMenuItem _menuCustomerAffiliateDataView;
        private ToolStripMenuItem _menuCustomerAffiliatePayCommission;

        #endregion Private Members

        #region Constructors

        public CustomersPluginModule(Form parent)
            : base(parent)
        {
        }

        #endregion Constructors

        #region Overridden Methods

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginCustomers);
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
            return (false);
        }

        public override void Unload()
        {
            // do nothing
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            _menuCustomerSearch.Text = LanguageStrings.AppMenuCustomerSearch;
            _menuCustomerMerge.Text = LanguageStrings.AppMenuCustomerMerge;
            _menuCustomer.Text = LanguageStrings.AppMenuCustomers;

            _menuCustomerExport.Text = LanguageStrings.AppMenuExport;

            _menuCustomerAffiliateDataView.Text = LanguageStrings.AppMenuCommissionAffiliateData;
            _menuCustomerAffiliatePayCommission.Text = LanguageStrings.AppMenuCommissionAffiliatePay;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppAffiliateSettingsName,
                Languages.LanguageStrings.AppAffiliateSettingsDescription,
                null, new Controls.AffiliateSettings());
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Administration:
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

            if (_affiliateTab == null)
                _affiliateTab = new CustomerAffiliateCard(this);

            if (_searchTab == null)
                _searchTab = new CustomerSearchCard(this);

            Result.Add(_searchTab);
            Result.Add(_affiliateTab);

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
                case StringConstants.PLUGIN_EVENT_EDIT_CUSTOMER:
                    e.Result = EditCustomerDetails((User)e.EventValue,
                        e.Param1 == null ? false : (bool)e.Param1,
                        e.Param2 == null ? String.Empty : (string)e.Param2,
                        //e.Param3 == null ? false : (bool)e.Param3); // enable this line for non modal
                        true);
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
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_CUSTOMER);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void CreateToolMenuItems(ToolStripMenuItem parent)
        {
            if (parent.HasDropDownItems)
            {
                _menuSeperator = new ToolStripSeparator();
                parent.DropDownItems.Add(_menuSeperator);
            }

            _menuCustomer = new ToolStripMenuItem(LanguageStrings.AppMenuCustomers);
            parent.DropDownItems.Add(_menuCustomer);

            _menuCustomerSearch = new ToolStripMenuItem(LanguageStrings.AppMenuCustomerSearch);
            _menuCustomerSearch.ShortcutKeys = Keys.F2;
            _menuCustomerSearch.Click += menuCustomerSearch_Click;
            _menuCustomer.DropDownItems.Add(_menuCustomerSearch);

            _menuCustomerMerge = new ToolStripMenuItem(LanguageStrings.AppMenuCustomerMerge);
            _menuCustomerMerge.Click += menuCustomerMerge_Click;
            _menuCustomer.DropDownItems.Add(_menuCustomerMerge);

            _menuCustomerExportSeperator = new ToolStripSeparator();
            _menuCustomer.DropDownItems.Add(_menuCustomerExportSeperator);

            _menuCustomerExport = new ToolStripMenuItem(LanguageStrings.AppMenuExport);
            _menuCustomerExport.Click += _menuCustomerExport_Click;
            _menuCustomer.DropDownItems.Add(_menuCustomerExport);

            _menuCustomerAffiliateSeperator = new ToolStripSeparator();
            _menuCustomer.DropDownItems.Add(_menuCustomerAffiliateSeperator);

            _menuCustomerAffiliateDataView = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionAffiliateData);
            _menuCustomerAffiliateDataView.Click += _menuCustomerAffiliateDataView_Click;
            _menuCustomer.DropDownItems.Add(_menuCustomerAffiliateDataView);

            _menuCustomerAffiliatePayCommission = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionAffiliatePay);
            _menuCustomerAffiliatePayCommission.Click += _menuCustomerAffiliatePayCommission_Click;
            _menuCustomer.DropDownItems.Add(_menuCustomerAffiliatePayCommission);
        }

        private void _menuCustomerAffiliatePayCommission_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ManageAffiliates))
            {
                Classes.AffiliateCommissionWizards.CommissionAffiliatePay();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionManageAffiliates),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _menuCustomerAffiliateDataView_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ManageAffiliates))
            {
                _affiliateTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionManageAffiliates),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _menuCustomerExport_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ExportCustomers))
            {
                Classes.ExportWizardWrapper.ShowExportWizard();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionExportCustomerRecords),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuCustomerMerge_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.MergeCustomerRecords))
            {
                CustomerMerge merge = new CustomerMerge();
                try
                {
                    merge.ShowDialog(ParentForm);
                }
                finally
                {
                    merge.Dispose();
                    merge = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionMergeCustomerRecords),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuCustomerSearch_Click(object sender, EventArgs e)
        {
            _searchTab.HomeTabButton.ForceClick();
        }

        private void customerButton_PluginUsage(object sender, PluginUsageEventArgs e)
        {

        }

        private void customerButton_POSBringToFront(object sender, EventArgs e)
        {
            base.OnRaiseBringToFront(EventArgs.Empty);
        }

        private AdminMemberEdit EditCustomerDetails(User user, bool showNotes, string newTitle, bool isModal)
        {
            if (isModal)
            {
                AdminMemberEdit editCustomer = new AdminMemberEdit(user, showNotes);
                try
                {
                    if (!String.IsNullOrEmpty(newTitle))
                        editCustomer.Text = newTitle;

                    editCustomer.ShowDialog(ParentForm);

                    return (null);
                }
                finally
                {
                    editCustomer.Dispose();
                    editCustomer = null;
                }
            }
            else
            {
                AdminMemberEdit editCustomer = new AdminMemberEdit(user, showNotes);
                editCustomer.MinimizeBox = true;
                _loadedCustomers.Add(editCustomer);
                editCustomer.FormClosed += editCustomer_FormClosed;

                if (!String.IsNullOrEmpty(newTitle))
                    editCustomer.Text = newTitle;

                editCustomer.Show();

                if (editCustomer.WindowState != FormWindowState.Normal)
                    editCustomer.WindowState = FormWindowState.Normal;

                return (editCustomer);
            }
        }

        private void editCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminMemberEdit editCustomer = (AdminMemberEdit)sender;
            _loadedCustomers.Remove(editCustomer);
            editCustomer.Dispose();
            editCustomer = null;
        }

        #endregion Private Methods
    }
}
