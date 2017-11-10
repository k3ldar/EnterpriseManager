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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: OrderView.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Library;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Accounts;
using SieraDelta.Library.BOL.Orders;
using SieraDelta.Library.BOL.Users;

using SieraDelta.Languages;

using SieraDelta.Reports;
using SieraDelta.POS.Classes;
using SieraDelta.POS.Controls;

namespace SieraDelta.POS.Orders.Forms
{
    public partial class OrderView : SieraDelta.POS.Forms.BaseForm
    {
        #region Private Members

        private Order _CurrentOrder;

        #endregion Private Members

        #region Constructors

        public OrderView(Order order)
        {
            InitializeComponent();

            _CurrentOrder = order;

            LoadOrder();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppCancel;
            btnClose.Text = LanguageStrings.AppClose;
            btnMaskAsPaid.Text = LanguageStrings.AppMarkAsPaid;
            btnViewUser.Text = LanguageStrings.AppUserView;

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
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadOrder()
        {
            btnCancel.Enabled = _CurrentOrder.Status.ID != 10;

            switch (_CurrentOrder.ProcessStatus)
            {
                case ProcessStatus.OrderReceived:
                    break;
                case ProcessStatus.Processing:
                    break;
                case ProcessStatus.Dispatched:
                    break;
                default:
                    break;
            }

            btnMaskAsPaid.Enabled = !_CurrentOrder.Status.IsPaid;

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

            lblOrderStatus.Text = SieraDelta.POS.Translations.EnumTranslations.TranslatedText(_CurrentOrder.ProcessStatus);

            lblPaymentType.Text = _CurrentOrder.Status.Description;

            BuildProductList();
        }

        private void BuildProductList()
        {
            pnlOrderItems.Controls.Clear();

            foreach (SieraDelta.Library.BOL.Orders.OrderItem item in _CurrentOrder.OrderItems)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CancelInvoices))
            {
                if (MessageBox.Show(this, LanguageStrings.AppOrderCancelConfirm, LanguageStrings.AppOrderCancel, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.OK)
                {
                    _CurrentOrder.Cancel();
                    _CurrentOrder = SieraDelta.Library.BOL.Orders.Orders.Get(_CurrentOrder.ID);
                    LoadOrder();
                }
            }
            else
            {
                ShowError(LanguageStrings.AppOrderCancel, LanguageStrings.AppPermissionCancelOrder);
            }
        }

        private void btnMaskAsPaid_Click(object sender, EventArgs e)
        {
            Plugins.NotificationEventArgs args = new Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_SHOW_MARK_AS_PAID, null);

            PluginManager.RaiseEvent(args);

            if ((bool)args.Result)
            {
                _CurrentOrder.Paid(AppController.ActiveUser, (PaymentStatus)args.Param8, (string)args.Param9);
                _CurrentOrder = SieraDelta.Library.BOL.Orders.Orders.Get(_CurrentOrder.ID);
                LoadOrder();
            }
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_EDIT_CUSTOMER, _CurrentOrder.User, LanguageStrings.AppUserView));
        }

        #endregion Private Methods
    }
}
