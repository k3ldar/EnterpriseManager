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
 *  File: InvoicesPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using SharedBase;
using SharedBase.BOL.Invoices;
using SharedBase.BOL.Orders;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Invoices.Forms;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0028 // collection initialization can be simplified

namespace POS.Invoices
{
    public class InvoicesPluginModule : BasePlugin
    {
        #region Private Members

        private InvoiceManagerCard _invoiceCard;
        private OrdersReceivedCard _ordersReceivedCard;
        private UnpaidOrdersCard _unpaidOrdersCard;
        private CreateOrderCard _createOrderCard;
        private RecurringInvoiceCard _recurringInvoiceCard;

        private InvoiceManager _invoiceManager = null;
        private InvoicesReceived _invoicesReceived = null;

        private List<InvoiceView> _openInvoices = new List<InvoiceView>();

        private List<OrderView> _openOrders = new List<OrderView>();

        private ToolStripMenuItem menuAccountsInvoiceManager;
        private ToolStripMenuItem menuAccountsInvoiceIssueRefund;
        private ToolStripSeparator menuAccountsInvoiceSeperator1;

        private ToolStripMenuItem _menuOrderParent;
        private ToolStripMenuItem _menuOrderFindOrder;
        private ToolStripMenuItem _menuOrderViewReceived;
        private ToolStripMenuItem _menuOrderViewUnpaid;
        private ToolStripSeparator _menuSeperator2;
        private ToolStripMenuItem _menuCreateOrder;

        #endregion Private Members

        #region Constructors

        public InvoicesPluginModule(Form parent)
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
            return (LanguageStrings.AppPluginInvoices);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            menuAccountsInvoiceManager.Dispose();
            menuAccountsInvoiceManager = null;

            menuAccountsInvoiceIssueRefund.Dispose();
            menuAccountsInvoiceIssueRefund = null;

            menuAccountsInvoiceSeperator1.Dispose();
            menuAccountsInvoiceSeperator1 = null;
        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {
            Shared.Classes.ThreadManager.ThreadStart(new Classes.GenerateRecurringInvoiceThread(),
                StringConstants.THREAD_NAME_RECURRING_INVOICES, System.Threading.ThreadPriority.Lowest);
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuAccountsInvoiceManager.Text = LanguageStrings.AppMenuInvoiceManager;
            menuAccountsInvoiceIssueRefund.Text = LanguageStrings.AppMenuOrderRefund;

            _menuOrderParent.Text = LanguageStrings.AppMenuOrders;
            _menuOrderFindOrder.Text = LanguageStrings.AppMenuFindOrder;
            _menuOrderViewReceived.Text = LanguageStrings.AppMenuOrdersReceived;
            _menuOrderViewUnpaid.Text = LanguageStrings.AppMenuOrdersUnpaid;
            _menuCreateOrder.Text = LanguageStrings.AppMenuOrderCreate;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            TreeNode parent = settingsForm.LoadControlOption(Languages.LanguageStrings.AppInvoices,
                Languages.LanguageStrings.AppInvoiceSettings,
                null, new Controls.InvoiceSettings());

            settingsForm.LoadControlOption(Languages.LanguageStrings.AppInvoiceHeader,
                Languages.LanguageStrings.AppInvoiceHeaderSettings,
                parent, new Controls.InvoiceHeaderSettings());

            settingsForm.LoadControlOption(Languages.LanguageStrings.AppInvoiceFooter,
                Languages.LanguageStrings.AppInvoiceFooterSettings,
                parent, new Controls.InvoiceFooterSettings());
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
                case PluginMenuType.Accounts:
                    CreateAccountsMenu(parentMenu);
                    break;
            }
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {
            _menuOrderParent = new ToolStripMenuItem(LanguageStrings.AppMenuOrders);
            mainMenu.Items.Insert(2, _menuOrderParent);

            CreateOrdersMenu();
        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_invoiceCard == null)
                _invoiceCard = new InvoiceManagerCard(this);

            if (_ordersReceivedCard == null)
                _ordersReceivedCard = new OrdersReceivedCard(this);

            if (_unpaidOrdersCard == null)
                _unpaidOrdersCard = new UnpaidOrdersCard(this);

            if (_createOrderCard == null)
                _createOrderCard = new CreateOrderCard(this);

            if (_recurringInvoiceCard == null)
                _recurringInvoiceCard = new RecurringInvoiceCard(this);

            Result.Add(_invoiceCard);
            Result.Add(_createOrderCard);
            Result.Add(_ordersReceivedCard);
            Result.Add(_unpaidOrdersCard);
            Result.Add(_recurringInvoiceCard);

            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            TrayNotificationCollection Result = new TrayNotificationCollection();

            Result.Add(new InvoicesTrayStatus(this));
            Result.Add(new InvoicePartiallyDispatchedTrayStatus(this));
            Result.Add(new InvoiceOnHoldTrayStatus(this));

            return (Result);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_VIEW_INVOICE:
                    ViewInvoiceDetails((Invoice)e.EventValue);
                    break;

                case StringConstants.PLUGIN_EVENT_VIEW_ORDER:
                    ViewOrderDetails((Order)e.EventValue);
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

            names.Add(StringConstants.PLUGIN_EVENT_VIEW_INVOICE);
            names.Add(StringConstants.PLUGIN_EVENT_VIEW_ORDER);
            names.Add(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Internal Methods

        internal void ShowInvoiceManager()
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ViewOrderManager))
            {
                if (_invoiceManager == null)
                {
                    _invoiceManager = new InvoiceManager();
                    _invoiceManager.FormClosed += new FormClosedEventHandler(_invoiceManager_FormClosed);
                }

                _invoiceManager.Show();
                _invoiceManager.BringToFront();
            }
            else
            {
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppInvoiceManager), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Internal Methods

        #region Private Methods

        private void ViewOrderDetails(Order order)
        {
            if (_openOrders.Count >= AppController.LocalSettings.OrderMaximumOpen)
            {
                MessageBox.Show(String.Format(LanguageStrings.AppOrderMaxOpenExceeded, AppController.LocalSettings.OrderMaximumOpen),
                    LanguageStrings.AppOrderOpen, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderView orderView = new OrderView(order);
            orderView.FormClosed += orderView_FormClosed;
            _openOrders.Add(orderView);
            orderView.Show();

            if (orderView.WindowState != FormWindowState.Normal)
                orderView.WindowState = FormWindowState.Normal;

        }

        private void orderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            OrderView frm = (OrderView)sender;
            frm.FormClosed -= orderView_FormClosed;

            if (!_openOrders.Remove(frm))
            {
            }

            frm.Dispose();
            frm = null;

        }

        private void menuCreateOrder_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CreateOrder))
            {
                _createOrderCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppCreateOrder),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuOrderViewUnpaid_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ViewUnpaidOrders))
            {
                _unpaidOrdersCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppUnpaidOrders),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuOrderViewReceived_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ViewOrdersReceived))
            {
                _ordersReceivedCard.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppViewOrdersReceived),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _invoicesReceived_FormClosed(object sender, FormClosedEventArgs e)
        {
            _invoicesReceived.Dispose();
            _invoicesReceived = null;
            base.OnRaiseBringToFront(EventArgs.Empty);
        }

        private void menuOrderFindOrder_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ViewOrdersReceived))
            {
                FindOrderForm frm = new FindOrderForm();
                try
                {
                    frm.ShowDialog(ParentForm);
                }
                finally
                {
                    frm.Dispose();
                    frm = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppSearchForOrders),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// View's an invoice
        /// </summary>
        /// <param name="invoice"></param>
        private void ViewInvoiceDetails(Invoice invoice)
        {
            if (_openInvoices.Count >= AppController.LocalSettings.InvoiceMaximumOpen)
            {
                MessageBox.Show(String.Format(LanguageStrings.AppInvoiceMaxOpenExceeded, AppController.LocalSettings.InvoiceMaximumOpen),
                    LanguageStrings.AppInvoiceOpen, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InvoiceView iv = new InvoiceView(invoice);
            _openInvoices.Add(iv);
            iv.FormClosed += iv_FormClosed;
            iv.Show();

            if (iv.WindowState != FormWindowState.Normal)
                iv.WindowState = FormWindowState.Normal;

            Debug.Write("invoice showing " + invoice.ID.ToString());
        }

        private void iv_FormClosed(object sender, FormClosedEventArgs e)
        {
            InvoiceView frm = (InvoiceView)sender;
            frm.FormClosed -= iv_FormClosed;

            _openInvoices.Remove(frm);
            frm.Dispose();
            frm = null;
        }

        private void CreateOrdersMenu()
        {
            _menuOrderFindOrder = new ToolStripMenuItem(LanguageStrings.AppMenuFindOrder);
            _menuOrderFindOrder.Click += menuOrderFindOrder_Click;
            _menuOrderFindOrder.ShortcutKeys = Keys.Alt | Keys.F;
            _menuOrderParent.DropDownItems.Add(_menuOrderFindOrder);

            _menuOrderViewReceived = new ToolStripMenuItem(LanguageStrings.AppMenuOrdersReceived);
            _menuOrderViewReceived.Click += menuOrderViewReceived_Click;
            _menuOrderViewReceived.ShortcutKeys = Keys.Alt | Keys.O;
            _menuOrderParent.DropDownItems.Add(_menuOrderViewReceived);

            _menuOrderViewUnpaid = new ToolStripMenuItem(LanguageStrings.AppMenuOrdersUnpaid);
            _menuOrderViewUnpaid.Click += menuOrderViewUnpaid_Click;
            _menuOrderViewUnpaid.ShortcutKeys = Keys.Alt | Keys.U;
            _menuOrderParent.DropDownItems.Add(_menuOrderViewUnpaid);

            _menuSeperator2 = new ToolStripSeparator();
            _menuOrderParent.DropDownItems.Add(_menuSeperator2);

            _menuCreateOrder = new ToolStripMenuItem(LanguageStrings.AppMenuOrderCreate);
            _menuCreateOrder.Click += menuCreateOrder_Click;
            _menuOrderParent.DropDownItems.Add(_menuCreateOrder);
        }

        private void CreateAccountsMenu(ToolStripMenuItem parent)
        {
            menuAccountsInvoiceManager = new ToolStripMenuItem(LanguageStrings.AppMenuInvoiceManager);
            menuAccountsInvoiceManager.Click += menuAccountsInvoiceManager_Click;
            menuAccountsInvoiceManager.ShortcutKeys = Keys.Alt | Keys.I;
            parent.DropDownItems.Insert(0, menuAccountsInvoiceManager);

            menuAccountsInvoiceSeperator1 = new ToolStripSeparator();
            parent.DropDownItems.Insert(1, menuAccountsInvoiceSeperator1);

            menuAccountsInvoiceIssueRefund = new ToolStripMenuItem(LanguageStrings.AppMenuOrderRefund);
            menuAccountsInvoiceIssueRefund.Click += menuAccountsInvoiceIssueRefund_Click;
            menuAccountsInvoiceIssueRefund.ShortcutKeys = Keys.Alt | Keys.R;
            parent.DropDownItems.Insert(2, menuAccountsInvoiceIssueRefund);
        }

        private void menuAccountsInvoiceManager_Click(object sender, EventArgs e)
        {
            _invoiceCard.HomeTabButton.ForceClick();
        }

        private void menuAccountsInvoiceIssueRefund_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.IssueRefund))
            {
                IssueRefundForm refund = new IssueRefundForm();
                try
                {
                    refund.ShowDialog(ParentForm);
                }
                finally
                {
                    refund.Dispose();
                    refund = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppIssueRefund), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _invoiceManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            _invoiceManager = null;
            ParentForm.BringToFront();
        }

        #endregion Private Methods
    }
}
