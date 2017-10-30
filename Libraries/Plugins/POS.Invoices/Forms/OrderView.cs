using System;
using System.Windows.Forms;

using Library;
using Library.BOL.Accounts;
using Library.BOL.Orders;
using Library.BOL.Invoices;

using Languages;
using POS.Base.Classes;
using POS.Base.Controls;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace POS.Invoices.Forms
{
    public partial class OrderView : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Order _CurrentOrder;

        #endregion Private Members

        #region Constructors

        public OrderView()
        {
            InitializeComponent();
        }

        public OrderView(Order order)
            : this ()
        {
            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainClose.Image = POS.Base.Icons.CloseIcon();
            toolStripMainMarkPaid.Image = POS.Base.Icons.PaidIcon();
            toolStripMainViewUser.Image = POS.Base.Icons.UserIcon();

            toolStripMainEdit.Enabled = false;

            _CurrentOrder = order;

            LoadOrder();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceOrderView;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblInvoiceDesc.Text = LanguageStrings.AppInvoice;
            lblDateDesc.Text = LanguageStrings.AppDate;
            lblInvoiceAddressDesc.Text = LanguageStrings.AppAddressInvoice;
            lblShipAddressDesc.Text = LanguageStrings.AppAddressShipping;
            lblTelephoneNo.Text = LanguageStrings.AppTelephoneNumber;
            lblEmailAddressDesc.Text = LanguageStrings.AppEmail;
            lblOrderDetailsDesc.Text = LanguageStrings.AppOrderDetails;
            lblDescriptionDesc.Text = LanguageStrings.AppDescription;
            lblPriceDesc.Text = LanguageStrings.AppPrice;
            lblQuantityDesc.Text = LanguageStrings.AppQuantity;
            lblCostDesc.Text = LanguageStrings.AppCost;
            lblPaymentTypeDesc.Text = LanguageStrings.AppPaymentType;
            lblOrderStatusDesc.Text = LanguageStrings.AppOrderStatus;
            lblSubTotalDesc.Text = LanguageStrings.AppSubTotal;
            lblPostageDesc.Text = LanguageStrings.AppPostage;
            lblVATDesc.Text = LanguageStrings.AppTax;
            lblTotalDesc.Text = LanguageStrings.AppTotal;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintCancel;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
            toolStripMainMarkPaid.Text = LanguageStrings.AppHintMarkAsPaid;
            toolStripMainViewUser.Text = LanguageStrings.AppHintViewUser;
            toolStripMainClose.Text = LanguageStrings.AppHintClose;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadOrder()
        {
            toolStripMainDelete.Enabled = _CurrentOrder.Status.ID != 10;

            switch (_CurrentOrder.ProcessStatus)
            {
                case ProcessStatus.OrderReceived:
                    break;
                case ProcessStatus.Processing:
                    break;
                case ProcessStatus.Dispatched:
                case ProcessStatus.Completed:
                    break;
                default:
                    break;
            }

            toolStripMainMarkPaid.Enabled = !_CurrentOrder.Status.IsPaid;

            lblInvoiceNo.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX, 
                AppController.LocalSettings.InvoicePrefix, 
                _CurrentOrder.DisplayID);
            lblInvoiceDate.Text = _CurrentOrder.PurchaseDateTime.ToString(
                System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

            lblAddress.Text = _CurrentOrder.User.Address(false);

            if (_CurrentOrder.DeliveryAddress == null)
                lblShippingAddress.Text = _CurrentOrder.User.Address(false);
            else
                lblShippingAddress.Text = _CurrentOrder.DeliveryAddress.Address(false);

            if (lblAddress.Text == lblShippingAddress.Text)
            {
                lblShipAddressDesc.Visible = false;
                lblShippingAddress.Visible = false;
            }

            lblTelephoneNo.Text = _CurrentOrder.User.Telephone;
            lblEmailAddress.Text = _CurrentOrder.User.Email;

            if (_CurrentOrder.VoucherType == Enums.InvoiceVoucherType.Percent)
            {
                if (_CurrentOrder.DiscountAmount > 0.00m)
                    lblDiscountDesc.Text = String.Format(LanguageStrings.AppDiscountPercent, 
                        _CurrentOrder.Discount, _CurrentOrder.CouponName);
                else
                    lblDiscountDesc.Text = LanguageStrings.AppDiscountNoDiscount;
            }
            else
                lblDiscountDesc.Text = String.Format(LanguageStrings.AppDiscountValue, 
                    AppController.LocalCountry.CurrencySymbol,
                    _CurrentOrder.Discount, _CurrentOrder.CouponName);

            lblDiscountTotal.Text = _CurrentOrder.DiscountAmountStr;

            lblPostageTotal.Text = _CurrentOrder.ShippingCostsStr;

            lblVATDesc.Text = String.Format(LanguageStrings.AppTaxPercentage, _CurrentOrder.VATRate);
            lblVATTotal.Text = _CurrentOrder.VatAmountStr;

            lblTotalTotal.Text = _CurrentOrder.TotalCostStr;

            lblOrderStatus.Text = POS.Base.EnumTranslations.Translate(_CurrentOrder.ProcessStatus);

            lblPaymentType.Text = _CurrentOrder.Status.Description;

            BuildProductList();
        }

        private void BuildProductList()
        {
            pnlOrderItems.Controls.Clear();

            foreach (Library.BOL.Orders.OrderItem item in _CurrentOrder.OrderItems)
            {
                InvoiceOrderItem itm = new InvoiceOrderItem(_CurrentOrder, item);
                itm.Width = pnlOrderItems.Width - 6;

                pnlOrderItems.Controls.Add(itm);
            }

            lblSubtotalTotal.Text = _CurrentOrder.OrderItems.SubTotalStr;
        }

        private void pnlOrderItems_SizeChanged(object sender, EventArgs e)
        {
            int newWidth = pnlOrderItems.Width - 6;

            if (pnlOrderItems.VerticalScroll.Visible)
                newWidth -= 20;

            foreach (Control ctl in pnlOrderItems.Controls)
            {
                ctl.Width = newWidth;
            }
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CancelInvoices))
            {
                if (InvoiceCancel.InvoiceCancelShow(_CurrentOrder))
                {
                    _CurrentOrder = Library.BOL.Orders.Orders.Get(_CurrentOrder.ID);
                    LoadOrder();
                }
            }
            else
            {
                ShowError(LanguageStrings.AppOrderCancel, LanguageStrings.AppPermissionCancelOrder);
            }
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void toolStripMainMarkPaid_Click(object sender, EventArgs e)
        {
            try
            {
                Base.Plugins.NotificationEventArgs args = new POS.Base.Plugins.NotificationEventArgs(
                    StringConstants.PLUGIN_EVENT_SHOW_MARK_AS_PAID, null);

                PluginManager.RaiseEvent(args);

                if ((bool)args.Result)
                {
                    _CurrentOrder.Paid(AppController.ActiveUser, (PaymentStatus)args.Param4, 
                        (string)args.Param5, String.Empty);
                    _CurrentOrder = Orders.Get(_CurrentOrder.ID);

                    Invoice inv = Library.BOL.Invoices.Invoices.Get(_CurrentOrder);
                    ProcessStatus newStatus = ProcessStatus.Completed;

                    foreach (InvoiceItem item in inv.InvoiceItems)
                    {
                        switch (item.ItemType)
                        {
                            case ProductCostItemType.Product:
                            case ProductCostItemType.FreeProduct:
                            case ProductCostItemType.Voucher:
                            case ProductCostItemType.GiftWrap:
                                newStatus = ProcessStatus.OrderReceived;
                                break;

                            default:
                                item.ItemStatus = ProcessItemStatus.Complete;
                                item.Save();
                                break;
                        }

                        if (newStatus == ProcessStatus.OrderReceived)
                            break;
                    }

                    inv.SetProcessStatus(AppController.ActiveUser, newStatus);

                    LoadOrder();
                }
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
                throw;
            }
        }

        private void toolStripMainViewUser_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(_CurrentOrder.User, 
                false, false, LanguageStrings.AppUserView));

        }

        private void toolStripMainClose_Click(object sender, EventArgs e)
        {
            if (this.Modal)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                Close();
        }

        #endregion Private Methods
    }
}
