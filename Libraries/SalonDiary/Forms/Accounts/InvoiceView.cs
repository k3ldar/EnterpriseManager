using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Heavenskincare.Library;
using Heavenskincare.Library.Utils;
using Heavenskincare.Library.BOL.Invoices;
using Heavenskincare.Library.BOL.Users;

using SalonDiary.Forms;
using SalonDiary.Controls;

namespace SalonDiary.Forms.Accounts
{
    public partial class InvoiceView : BaseForm
    {
        private Invoice _CurrentInvoice;
        private User _currentuser;

        public InvoiceView(User user, Invoice invoice)
        {
            InitializeComponent();

            _CurrentInvoice = invoice;
            _currentuser = user;

            LoadInvoice();
        }

        private void LoadInvoice()
        {
            HSCUtils u = new HSCUtils();

            switch (_CurrentInvoice.ProcessStatus)
            {
                case Heavenskincare.Library.Enums.ProcessStatus.OrderReceived:
                    btnCancel.Enabled = true;
                    btnTrackingReference.Enabled = false;
                    break;
                case Heavenskincare.Library.Enums.ProcessStatus.Processing:
                    btnCancel.Enabled = true;
                    btnTrackingReference.Enabled = false;
                    break;
                case Heavenskincare.Library.Enums.ProcessStatus.Dispatched:
                    btnCancel.Enabled = true;
                    btnTrackingReference.Enabled = true;
                    break;
                default:
                    btnTrackingReference.Enabled = false;
                    btnCancel.Enabled = false;
                    break;
            }

            lblInvoiceNo.Text = String.Format("WI{0}", _CurrentInvoice.ID);
            lblInvoiceDate.Text = _CurrentInvoice.PurchaseDateTime.ToString("dd/MM/yyyy hh:mm:ss");

            lblAddress.Text = _CurrentInvoice.User.Address(false);

            if (_CurrentInvoice.DeliveryAddress == null)
                lblShippingAddress.Text = _CurrentInvoice.User.Address(false);
            else
                lblShippingAddress.Text = _CurrentInvoice.DeliveryAddress.Address(false);

            if (lblAddress.Text == lblShippingAddress.Text)
            {
                lblShipAddress.Visible = false;
                lblShippingAddress.Visible = false;
            }

            lblTelephoneNo.Text = _CurrentInvoice.User.Telephone;
            lblEmailAddress.Text = _CurrentInvoice.User.Email;

            if (_CurrentInvoice.VoucherType == Enums.InvoiceVoucherType.Percent)
            {
                if (_CurrentInvoice.DiscountAmmount > 0.00)
                    lblDiscount.Text = String.Format("Discount {0}% ({1})", _CurrentInvoice.Discount, _CurrentInvoice.CouponName);
                else
                    lblDiscount.Text = "Discount 0%";
            }
            else
                lblDiscount.Text = String.Format("Discount £{0}", _CurrentInvoice.Discount);

            lblDiscountTotal.Text = u.FormatMoney(_CurrentInvoice.DiscountAmmount, "en-GB", _currentuser.Country.ConversionRate, _currentuser.Country.Multiplier, false);

            lblPostageTotal.Text = u.FormatMoney(_CurrentInvoice.ShippingCosts, "en-GB", _currentuser.Country.ConversionRate, _currentuser.Country.Multiplier, false);

            lblVAT.Text = String.Format("VAT @ {0}%", _CurrentInvoice.VATRate);
            lblVATTotal.Text = u.FormatMoney(_CurrentInvoice.VATAmmount, "en-GB", _currentuser.Country.ConversionRate, _currentuser.Country.Multiplier, false);

            lblTotalTotal.Text = u.FormatMoney(_CurrentInvoice.TotalCost, "en-GB", _currentuser.Country.ConversionRate, _currentuser.Country.Multiplier, false);

            lblOrderStatus.Text = u.SplitCamelCase(_CurrentInvoice.ProcessStatus.ToString());

            if (_CurrentInvoice.ProcessStatus == Enums.ProcessStatus.Dispatched)
                lblOrderStatus.Text = String.Format("Dispatched on {0}", u.DateToStr(_CurrentInvoice.Dateshipped, "en-GB"));

            if (_CurrentInvoice.TrackingReference != "")
            {
                lnkTrackingReference.Text = _CurrentInvoice.TrackingReference;
                lnkTrackingReference.Visible = true;
            }
            else
            {
                lnkTrackingReference.Visible = false;
            }

            lblPaymentType.Text = u.SplitCamelCase(_CurrentInvoice.Status.ToString());

            BuildProductList();
        }

        private void BuildProductList()
        {
            HSCUtils u = new HSCUtils();
            pnlOrderItems.Controls.Clear();
            double subtotal = 0.00;

            foreach (InvoiceItem item in _CurrentInvoice.InvoiceItems)
            {
                InvoiceOrderItem itm = new InvoiceOrderItem(_CurrentInvoice, item);
                itm.Width = pnlOrderItems.Width - 6;

                pnlOrderItems.Controls.Add(itm);
                subtotal += item.Cost * item.Quantity;
            }

            lblSubtotalTotal.Text = u.FormatMoney(u.VATRemove(subtotal, _CurrentInvoice.VATRate > 0.00 ? _CurrentInvoice.VATRate : 20.00), "en-GB", 1.0, 0.0, false);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PDFInvoice inv = new PDFInvoice(_CurrentInvoice);
            //inv.Print();
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            //ShippingLabel lbl = new ShippingLabel(_CurrentInvoice.User);
            //lbl.Print();
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
            if (MessageBox.Show(this, "Are you sure you want to cancel this invoice", "Cancel Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.OK)
            {
                _CurrentInvoice.Cancel();
                _CurrentInvoice = Invoices.Get(_CurrentInvoice.ID);
                LoadInvoice();
            }
        }

        private void btnTrackingReference_Click(object sender, EventArgs e)
        {
            TrackingReference tr = new TrackingReference(_CurrentInvoice.TrackingReference);

            if (tr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _CurrentInvoice.SetDispatched(_currentuser, Heavenskincare.Library.Enums.ProcessStatus.Dispatched, tr.TrackingRef);
            }

            tr = null;
        }

        private void lnkTrackingReference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //execute web page
            string URL = String.Format("http://www.postoffice.co.uk/track-trace?trackNumber={0}&page_type=rml-tracking-details", lnkTrackingReference.Text.Replace(" ", ""));

            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(URL);

            proc.StartInfo = startInfo;

            proc.Start();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            MemberEdit memberEdit = new MemberEdit(_currentuser, new Heavenskincare.Library.WebsiteAdministration(_currentuser), _CurrentInvoice.User);
            memberEdit.Text = "View User";
            memberEdit.ShowDialog();
        }

    }
}
