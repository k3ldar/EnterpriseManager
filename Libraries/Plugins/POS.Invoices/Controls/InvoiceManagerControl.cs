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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: InvoiceManagerControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using SharedBase;
using SharedBase.BOL.Accounts;
using SharedBase.BOL.Invoices;
using SharedBase.BOL.Coupons;
using Languages;

using Reports.Accounts;

using POS.Base.Plugins;
using POS.Base.Classes;
using POS.Base;

namespace POS.Invoices.Controls
{
    public partial class InvoiceManagerControl : POS.Base.Controls.BaseTabControl
    {
        #region Private / Protected Members


        #endregion Private / Protected Members

        #region Constructors / Destructors

        public InvoiceManagerControl()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;


            statusStripInvoices.Visible = false;
            lstInvoices.Height = lstInvoices.Height + 26;

            this.cmbPaymentStatus.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPaymentStatus_Format);
            this.cmbDiscount.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDiscount_Format);

            LoadPaymentTypes();
            LoadDiscounts();
            LoadSearchSettings();
        }

        #endregion Constructors / Destructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppInvoiceManager;

            btnPrintAll.Text = LanguageStrings.AppMenuButtonPrintAll;
            btnReset.Text = LanguageStrings.AppMenuButtonReset;
            btnSearch.Text = LanguageStrings.AppMenuButtonSearch;

            chInvoice.Text = LanguageStrings.AppInvoiceNumber;
            chInvoiceAmount.Text = LanguageStrings.AppInvoiceAmount;
            chPaymentType.Text = LanguageStrings.AppPaymentType;
            chPurchaseDate.Text = LanguageStrings.AppPurchaseDate;
            chUserName.Text = LanguageStrings.AppCustomer;
            chStatus.Text = LanguageStrings.AppStatus;

            gbOptions.Text = LanguageStrings.AppOptions;
            gbDateRange.Text = LanguageStrings.AppDateRange;
            gbDiscount.Text = LanguageStrings.AppDiscount;
            gbOrderStatus.Text = LanguageStrings.AppOrderStatus;
            gbPaymentStatus.Text = LanguageStrings.AppPaymentStatus;

            lblInvoiceNumber.Text = LanguageStrings.AppInvoiceNumber;

            cbDispatched.Text = LanguageStrings.AppDispatched;
            cbOrderCancelled.Text = LanguageStrings.AppCancelled;
            cbOrderReceived.Text = LanguageStrings.AppReceived;
            cbProcessing.Text = LanguageStrings.AppProcessing;

            rbAnyDate.Text = LanguageStrings.AppDateAny;
            rbDateRange.Text = LanguageStrings.AppDateRange;
            rbSpecifyDate.Text = LanguageStrings.AppDateSpecific;
            rbTodayOnly.Text = LanguageStrings.AppDateTodayOnly;
        }

        public override int GetStatusCount()
        {
            return (statusStripInvoices.Items.Count);
        }

        public override string GetStatusText(int index)
        {
            return (statusStripInvoices.Items[index].Text);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStripInvoices.Items[index].ToolTipText);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!cbDispatched.Checked && !cbOrderCancelled.Checked && !cbOrderReceived.Checked && !cbProcessing.Checked)
                    cbOrderReceived.Checked = true;

                // Save Settings
                SaveSearchSettings();

                DisplayInvoices();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region Search Settings

        private void LoadSearchSettings()
        {
            cbDispatched.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DISPATCHED, XMLFile));
            cbOrderCancelled.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_ORDER_CANCELLED, XMLFile));
            cbOrderReceived.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_ORDER_RECEIVED, XMLFile));
            cbProcessing.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_ORDER_PROCESSISNG, XMLFile));

            rbAnyDate.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_ANY, XMLFile));
            rbDateRange.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_RANGE, XMLFile));
            rbSpecifyDate.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_SPECIFIC, XMLFile));
            rbTodayOnly.Checked = Shared.Utilities.StrToBool(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_TODAY, XMLFile));

            cmbPaymentStatus.SelectedIndex = Shared.Utilities.StrToIntDef(Shared.XML.GetXMLValue(XMLFile,
                String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_PAYMENT_TYPE), 0);

            if (cmbPaymentStatus.SelectedIndex == -1)
                cmbPaymentStatus.SelectedIndex = 0;

            cmbDiscount.SelectedIndex = Shared.Utilities.StrToIntDef(Shared.XML.GetXMLValue(XMLFile,
                String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DISCOUNT_CODE), 0);

            DateTime date;

            if (DateTime.TryParse(Shared.XML.GetXMLValue(String.Format(
                StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_FROM, XMLFile), out date))
                dtpStart.Value = date;

            if (DateTime.TryParse(Shared.XML.GetXMLValue(String.Format
                (StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_TO, XMLFile), out date))
                dtpFinish.Value = date;

            if (!rbAnyDate.Checked && !rbDateRange.Checked && !rbSpecifyDate.Checked && !rbTodayOnly.Checked)
                rbAnyDate.Checked = true;

            rbDateType_CheckedChanged(null, new EventArgs());
        }

        private void SaveSearchSettings()
        {
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DISPATCHED, cbDispatched.Checked.ToString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_ORDER_CANCELLED, cbOrderCancelled.Checked.ToString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_ORDER_RECEIVED, cbOrderReceived.Checked.ToString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_ORDER_PROCESSISNG, cbProcessing.Checked.ToString(), XMLFile);

            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_ANY, rbAnyDate.Checked.ToString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_RANGE, rbDateRange.Checked.ToString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_SPECIFIC, rbSpecifyDate.Checked.ToString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_TODAY, rbTodayOnly.Checked.ToString(), XMLFile);

            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_FROM, dtpStart.Value.ToShortDateString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DATE_TO, dtpFinish.Value.ToShortDateString(), XMLFile);

            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_PAYMENT_TYPE, cmbPaymentStatus.SelectedIndex.ToString(), XMLFile);
            Shared.XML.SetXMLValue(String.Format(StringConstants.INVOICE_MANAGER_FORM_PROPERTIES, Name),
                StringConstants.INVOICE_MANAGER_SETTINGS_DISCOUNT_CODE, cmbDiscount.SelectedIndex.ToString(), XMLFile);
        }

        #endregion Search Settings

        private SharedBase.BOL.Invoices.Invoices SearchInvoices()
        {
            SharedBase.BOL.Invoices.Invoices Result = null;

            int PaymentType = -1;

            PaymentStatus status = (PaymentStatus)cmbPaymentStatus.SelectedItem;
            PaymentType = status.ID;
            ProcessStatuses statuses = ProcessStatuses.None;

            if (cbDispatched.Checked)
                statuses |= ProcessStatuses.Dispatched;

            if (cbOrderCancelled.Checked)
                statuses |= ProcessStatuses.Cancelled;

            if (cbOrderReceived.Checked)
                statuses |= ProcessStatuses.OrderReceived;

            if (cbProcessing.Checked)
                statuses |= ProcessStatuses.Processing;

            if (txtInvoiceNumber.Text != String.Empty)
            {
                Result = SharedBase.BOL.Invoices.Invoices.InvoicesGet(AppController.ActiveUser, 1, 10, -1,
                    Shared.Utilities.StrToIntDef(txtInvoiceNumber.Text, -1), false, statuses);
            }
            else
            {
                Coupon cpn = (Coupon)cmbDiscount.SelectedItem;

                if (cpn.ID == -2)
                    cpn = null;

                if (rbAnyDate.Checked)
                    Result = SharedBase.BOL.Invoices.Invoices.InvoicesGet(AppController.ActiveUser,
                        statuses, true, cbOrderCancelled.Checked);

                if (rbTodayOnly.Checked)
                    Result = SharedBase.BOL.Invoices.Invoices.InvoicesGet(AppController.ActiveUser,
                        DateTime.Now, DateTime.MinValue, statuses, PaymentType, cpn, cbOrderCancelled.Checked);

                if (rbSpecifyDate.Checked)
                    Result = SharedBase.BOL.Invoices.Invoices.InvoicesGet(AppController.ActiveUser,
                        dtpStart.Value, DateTime.MinValue, statuses, PaymentType, cpn, cbOrderCancelled.Checked);

                if (rbDateRange.Checked)
                    Result = SharedBase.BOL.Invoices.Invoices.InvoicesGet(AppController.ActiveUser,
                        dtpStart.Value, dtpFinish.Value, statuses, PaymentType, cpn, cbOrderCancelled.Checked);
            }

            return (Result);
        }

        private void DisplayInvoices()
        {
            SharedBase.BOL.Invoices.Invoices invoices = SearchInvoices();

            lstInvoices.BeginUpdate();
            try
            {
                lstInvoices.Items.Clear();

                if (invoices != null)
                {
                    decimal total = 0.00m;

                    foreach (Invoice inv in invoices)
                    {
                        ListViewItem lvi = lstInvoices.Items.Add(String.Format(StringConstants.INVOICE_NAME_ID_WITH_PREFIX,
                            LanguageStrings.AppInvoice, AppController.LocalSettings.InvoicePrefix, inv.ID));
                        lvi.SubItems.Add(inv.User.UserName);
                        lvi.SubItems.Add(inv.PurchaseDateTime.ToString(
                            System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat));
                        lvi.SubItems.Add(inv.TotalCostStr);
                        lvi.SubItems.Add(EnumTranslations.Translate(inv.Status));
                        lvi.SubItems.Add(EnumTranslations.Translate(inv.ProcessStatus));
                        total += inv.TotalCost;
                    }

                    toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppInvoicesFound, invoices.Count);
                }
                else
                {
                    toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppInvoicesFound, 0);
                }
            }
            finally
            {
                lstInvoices.EndUpdate();
            }

            this.BringToFront();
        }

        private void LoadDiscounts()
        {
            cmbDiscount.Items.Clear();

            Coupons coupons = Coupons.Get(false);
            coupons.Insert(0, new Coupon(-1, LanguageStrings.AppInvoiceAnyCouponCode,
                DateTime.MaxValue, true, 0, null, null, 0, 0, false, 1, 0.00m, -1, DateTime.MinValue, false));
            coupons.Insert(0, new Coupon(-2, LanguageStrings.AppInvoiceIgnoreDiscount,
                DateTime.MaxValue, true, 0, null, null, 0, 0, false, 1, 0.00m, -1, DateTime.MinValue, false));

            foreach (Coupon cpn in coupons)
            {
                cmbDiscount.Items.Add(cpn);
            }

            cmbDiscount.SelectedIndex = -1;
        }

        private void LoadPaymentTypes()
        {
            cmbPaymentStatus.Items.Clear();
            PaymentStatus paymentAny = new PaymentStatus(-1, LanguageStrings.AppInvoiceAnyPayment,
                0, true, String.Empty, true, true, true, false, MemberLevel.StandardUser);
            cmbPaymentStatus.Items.Add(paymentAny);

            foreach (PaymentStatus status in PaymentStatuses.Get())
            {
                if (status.IsPaid || (!status.IsPaid && status.CreateInvoice))
                    cmbPaymentStatus.Items.Add(status);
            }
        }

        private void rbDateType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAnyDate.Checked)
            {
                lblDateFrom.Enabled = false;
                dtpStart.Enabled = false;
                cmbPaymentStatus.Enabled = false;
                cmbDiscount.Enabled = false;
            }
            else
            {
                cmbPaymentStatus.Enabled = true;
                cmbDiscount.Enabled = true;
            }

            if (rbTodayOnly.Checked)
            {
                lblDateFrom.Enabled = false;
                dtpStart.Enabled = false;
            }

            if (rbSpecifyDate.Checked)
            {
                lblDateFrom.Enabled = true;
                dtpStart.Enabled = true;
            }

            if (rbDateRange.Checked)
            {
                lblDateFrom.Enabled = true;
                dtpStart.Enabled = true;
                lblDateTo.Visible = true;
                dtpFinish.Visible = true;
            }
            else
            {
                lblDateTo.Visible = false;
                dtpFinish.Visible = false;
            }
        }

        private void lstInvoices_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstInvoices.SelectedItems)
            {
                Invoice inv = SharedBase.BOL.Invoices.Invoices.Get(Convert.ToInt32(itm.Text.Substring(10)));

                if (inv != null)
                {
                    PluginManager.RaiseEvent(new NotificationEventArgs(StringConstants.PLUGIN_EVENT_VIEW_INVOICE, inv));
                }
            }
        }

        private void cmbDiscount_Format(object sender, ListControlConvertEventArgs e)
        {
            Coupon cpn = (Coupon)e.ListItem;

            e.Value = cpn.Name;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInvoiceNumber.Text = String.Empty;
            cbProcessing.Checked = true;
            cbOrderReceived.Checked = true;
            cbOrderCancelled.Checked = false;
            cbDispatched.Checked = false;

            cmbDiscount.SelectedIndex = 0;
            cmbPaymentStatus.SelectedIndex = 0;
            rbAnyDate.Checked = true;

            rbDateType_CheckedChanged(this, new EventArgs());
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            SharedBase.BOL.Invoices.Invoices invoices = SearchInvoices();

            if (invoices != null)
            {
                PDFInvoice inv = new PDFInvoice(invoices, AppController.LocalSettings.InvoiceHeaderRight,
                        AppController.LocalSettings.InvoiceFooter, AppController.LocalSettings.InvoiceAddress,
                        AppController.LocalSettings.InvoiceVATRegistrationNumber, AppController.LocalSettings.CustomCulture,
                    SharedBase.DAL.DALHelper.HideVATOnWebsiteAndInvoices,
                    AppController.LocalSettings.InvoiceShowProductDiscount, String.Empty, String.Empty, 1,
                    AppController.LocalSettings.InvoicePrefix);
                inv.Print();
            }
        }

        private void cmbPaymentStatus_Format(object sender, ListControlConvertEventArgs e)
        {
            PaymentStatus status = (PaymentStatus)e.ListItem;
            e.Value = status.Description;
        }

        #endregion Private Methods
    }
}
