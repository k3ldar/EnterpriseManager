using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Heavenskincare.Library;
using Heavenskincare.Library.Utils;
using Heavenskincare.Library.BOL.Orders;
using Heavenskincare.Library.BOL.Users;

using SalonDiary.Forms;
using SalonDiary.Controls;

namespace SalonDiary.Forms.Accounts
{
    public partial class OrderView : BaseForm
    {
        private Order _CurrentOrder;
        private User _currentuser;

        public OrderView(User user, Order order)
        {
            InitializeComponent();

            _CurrentOrder = order;
            _currentuser = user;

            LoadOrder();
        }

        private void LoadOrder()
        {
            HSCUtils u = new HSCUtils();

            switch (_CurrentOrder.ProcessStatus)
            {
                case Enums.ProcessStatus.OrderReceived:
                    btnCancel.Enabled = true;
                    break;
                case Enums.ProcessStatus.Processing:
                    btnCancel.Enabled = true;
                    break;
                case Enums.ProcessStatus.Dispatched:
                    btnCancel.Enabled = false;
                    break;
                default:
                    btnCancel.Enabled = false;
                    break;
            }

            switch (_CurrentOrder.Status)
            {
                case Enums.PaymentStatus.ChequePaid:
                case Enums.PaymentStatus.InStorePaidCard:
                case Enums.PaymentStatus.InStorePaidCash:
                case Enums.PaymentStatus.InStorePaidCheque:
                case Enums.PaymentStatus.Paid:
                case Enums.PaymentStatus.PaynetPaid:
                case Enums.PaymentStatus.PaypalPaid:
                case Enums.PaymentStatus.PhonePaid:
                    btnMaskAsPaid.Enabled = false;
                    break;
                default:
                    btnMaskAsPaid.Enabled = true;
                    break;
            }

            lblInvoiceNo.Text = String.Format("WI{0}", _CurrentOrder.ID);
            lblInvoiceDate.Text = _CurrentOrder.PurchaseDateTime.ToString("dd/MM/yyyy hh:mm:ss");

            lblAddress.Text = _CurrentOrder.User.Address(false);

            if (_CurrentOrder.DeliveryAddress == null)
                lblShippingAddress.Text = _CurrentOrder.User.Address(false);
            else
                lblShippingAddress.Text = _CurrentOrder.DeliveryAddress.Address(false);

            if (lblAddress.Text == lblShippingAddress.Text)
            {
                lblShipAddress.Visible = false;
                lblShippingAddress.Visible = false;
            }

            lblTelephoneNo.Text = _CurrentOrder.User.Telephone;
            lblEmailAddress.Text = _CurrentOrder.User.Email;

            if (_CurrentOrder.VoucherType == Enums.InvoiceVoucherType.Percent)
            {
                if (_CurrentOrder.DiscountAmmount > 0.00)
                    lblDiscount.Text = String.Format("Discount {0}% ({1})", _CurrentOrder.Discount, _CurrentOrder.CouponName);
                else
                    lblDiscount.Text = "Discount 0%";
            }
            else
                lblDiscount.Text = String.Format("Discount £{0}", _CurrentOrder.Discount);

            lblDiscountTotal.Text = u.FormatMoney(_CurrentOrder.DiscountAmmount, "en-GB", _CurrentOrder.ConversionRate, _CurrentOrder.CostMultiplier, false);

            lblPostageTotal.Text = u.FormatMoney(_CurrentOrder.ShippingCosts, "en-GB", _CurrentOrder.ConversionRate, _CurrentOrder.CostMultiplier, false);

            lblVAT.Text = String.Format("VAT @ {0}%", _CurrentOrder.VATRate);
            lblVATTotal.Text = u.FormatMoney(_CurrentOrder.VATAmmount, "en-GB", _CurrentOrder.ConversionRate, _CurrentOrder.CostMultiplier, false);

            lblTotalTotal.Text = u.FormatMoney(_CurrentOrder.TotalCost, "en-GB", _CurrentOrder.ConversionRate, _CurrentOrder.CostMultiplier, false);

            lblOrderStatus.Text = u.SplitCamelCase(_CurrentOrder.ProcessStatus.ToString());

            lblPaymentType.Text = u.SplitCamelCase(_CurrentOrder.Status.ToString());

            BuildProductList();
        }

        private void BuildProductList()
        {
            HSCUtils u = new HSCUtils();
            pnlOrderItems.Controls.Clear();
            double subtotal = 0.00;

            foreach (Heavenskincare.Library.BOL.Orders.OrderItem item in _CurrentOrder.OrderItems)
            {
                InvoiceOrderItem itm = new InvoiceOrderItem(_CurrentOrder, item);
                itm.Width = pnlOrderItems.Width - 6;

                pnlOrderItems.Controls.Add(itm);
                subtotal += item.Cost * item.Quantity;
            }

            lblSubtotalTotal.Text = u.FormatMoney(u.VATRemove(subtotal, _CurrentOrder.VATRate > 0.00 ? _CurrentOrder.VATRate : 20.00), "en-GB", _CurrentOrder.ConversionRate, _CurrentOrder.CostMultiplier, false);

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
            if (MessageBox.Show(this, "Are you sure you want to cancel this order", "Cancel Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.OK)
            {
                _CurrentOrder.Cancel();
                _CurrentOrder = Orders.Get(_CurrentOrder.ID);
                LoadOrder();
            }
        }

        private void btnMaskAsPaid_Click(object sender, EventArgs e)
        {
            MarkAsPaidForm frm = new MarkAsPaidForm(false);
            frm.ShowDialog(this);

            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                _CurrentOrder.Paid(_currentuser, frm.PaymentStatus, frm.AdditionalPaymentInformation);
                _CurrentOrder.ProcessStatus = Enums.ProcessStatus.Processing;
                _CurrentOrder = Orders.Get(_CurrentOrder.ID);
                LoadOrder();
            }
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            MemberEdit memberEdit = new MemberEdit(_currentuser, new WebsiteAdministration(_currentuser), _CurrentOrder.User);
            memberEdit.Text = "View User";
            memberEdit.Show();
        }
    }
}
