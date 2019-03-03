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
 *  File: InvoicesReceived.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using SharedBase;
using SharedBase.BOL.Accounts;
using SharedBase.BOL.Invoices;
using SharedBase.BOL.StockControl;
using Reports.Accounts;
using POS.Base.Classes;
using POS.Base.Forms;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Forms
{
    public partial class InvoicesReceived : BaseForm
    {
        #region Private Members

        private Stock _currentstock;

        #endregion Private Members

        #region Constructors

        public InvoicesReceived()
        {
            InitializeComponent();
            LoadPaymentTypes();

            cmbProcessStatus.SelectedIndex = 0;

            ResetList();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoicesReceived;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppInvoicesReceived;

            lblPaymentStatus.Text = LanguageStrings.AppPaymentStatus;
            lblProcessStatus.Text = LanguageStrings.AppProcessStatus;

            btnPrint.Text = LanguageStrings.AppMenuButtonPrint;
            btnProcessing.Text = LanguageStrings.AppMenuButtonProcessing;
            btnOnHold.Text = LanguageStrings.OnHold;

            chInvoice.Text = LanguageStrings.AppInvoiceNumber;
            chInvoiceAmount.Text = LanguageStrings.AppInvoiceAmount;
            chPurchaseDate.Text = LanguageStrings.AppPurchaseDate;
            chCustomer.Text = LanguageStrings.AppCustomer;
            chPaymentType.Text = LanguageStrings.AppPaymentType;
            chProcessStatus.Text = LanguageStrings.Status;
        }

        #endregion Overridden Methods

        #region Private Methods

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

            cmbPaymentStatus.SelectedIndex = 0;
        }

        private void ResetList()
        {

            ProcessStatuses statuses = ProcessStatuses.None;

            switch (cmbProcessStatus.SelectedIndex)
            {
                case 1:
                    statuses = ProcessStatuses.OrderReceived;
                    break;
                case 2:
                    statuses = ProcessStatuses.OnHold;
                    break;
                case 3:
                    statuses = ProcessStatuses.PartialDispatch;
                    break;
                default:
                    statuses = ProcessStatuses.OrderReceived | ProcessStatuses.PartialDispatch | ProcessStatuses.OnHold;
                    break;
            }

            SharedBase.BOL.Invoices.Invoices invoices;
            _currentstock = Stock.Get(AppController.ActiveUser, true);

            this.Cursor = Cursors.WaitCursor;
            try
            {
                lstInvoices.BeginUpdate();
                try
                {
                    PaymentStatus status = (PaymentStatus)cmbPaymentStatus.SelectedItem;

                    if (status.ID == -1)
                    {
                        invoices = SharedBase.BOL.Invoices.Invoices.InvoicesGet(AppController.ActiveUser, statuses, true, false);
                    }
                    else
                    {
                        invoices = SharedBase.BOL.Invoices.Invoices.InvoicesGet(AppController.ActiveUser, statuses, status);
                    }

                    lstInvoices.Items.Clear();

                    decimal total = 0.00m;

                    foreach (Invoice inv in invoices)
                    {
                        ListViewItem lvi = lstInvoices.Items.Add(String.Format(StringConstants.INVOICE_NAME_ID_WITH_PREFIX, 
                            LanguageStrings.AppInvoice, AppController.LocalSettings.InvoicePrefix, inv.ID));

                        lvi.SubItems.Add(inv.User.UserName);
                        lvi.SubItems.Add(inv.PurchaseDateTime.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat));
                        lvi.SubItems.Add(inv.TotalCostStr);
                        lvi.SubItems.Add(inv.Status.Description);
                        lvi.SubItems.Add(Shared.Utilities.SplitCamelCase(inv.ProcessStatus.ToString()));
                        lvi.SubItems.Add(inv.ID.ToString());
                        total += inv.TotalCost * Convert.ToDecimal(inv.CostMultiplier);
                        
                        InvoiceStockStatus stockStatus = GetStockStatus(inv);
                        lvi.Tag = stockStatus;

                        if (stockStatus.AllStockAvailable)
                        {
                            switch (inv.ProcessStatus)
                            {
                                case ProcessStatus.OnHold:
                                    lvi.ForeColor = Color.DarkGray;
                                    break;
                                case ProcessStatus.PartialDispatch:
                                    lvi.ForeColor = Color.Blue;
                                    break;
                                default:
                                    lvi.ForeColor = Color.Black;
                                    break;
                            }
                        }
                        else
                        {
                            lvi.ForeColor = Color.Red;
                        }
                    }

                    toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppInvoicesFound, invoices.Count);
                    toolStripStatusLabelSelected.Text = LanguageStrings.AppInvoiceSelectedNone;
                }
                finally
                {
                    lstInvoices.EndUpdate();
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private InvoiceStockStatus GetStockStatus(Invoice invoice)
        {
            InvoiceStockStatus Result = new InvoiceStockStatus();

            foreach (InvoiceItem invItem in invoice.InvoiceItems)
            {
                switch (invItem.ProductCostType.ItemType)
                {
                    case ProductCostItemType.Product:
                    case ProductCostItemType.Voucher:
                    case ProductCostItemType.FreeProduct:

                        if (GetStockAvailable(invItem) < 1)
                            Result.MissingStock.Add(invItem.Description);

                        break;
                }
            }

            Result.AllStockAvailable = Result.MissingStock.Count != invoice.InvoiceItems.Count;

            return (Result);
        }

        private int GetStockAvailable(InvoiceItem item)
        {
            if (item.ItemType != ProductCostItemType.Treatment)
            {
                foreach (StockItem stockItem in _currentstock)
                {
                    if (stockItem.ID == item.ItemID)
                        return (stockItem.Available);
                }
            }

            return (0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SharedBase.BOL.Invoices.Invoices invoices = new SharedBase.BOL.Invoices.Invoices();

            foreach (ListViewItem item in lstInvoices.SelectedItems)
            {
                int invoiceID = Convert.ToInt32(item.SubItems[6].Text);

                Invoice invoice = SharedBase.BOL.Invoices.Invoices.Get(invoiceID);
                invoices.Add(invoice);
            }

            try
            {
                PDFInvoice report = new PDFInvoice(invoices, AppController.LocalSettings.InvoiceHeaderRight,
                        AppController.LocalSettings.InvoiceFooter, AppController.LocalSettings.InvoiceAddress,
                        AppController.LocalSettings.InvoiceVATRegistrationNumber,
                        AppController.LocalSettings.CustomCulture,
                    SharedBase.DAL.DALHelper.HideVATOnWebsiteAndInvoices,
                    AppController.LocalSettings.InvoiceShowProductDiscount, String.Empty, String.Empty, 1,
                    AppController.LocalSettings.InvoicePrefix);
                report.Print();
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_NO_PAGES))
                {
                    ShowError(LanguageStrings.AppOrderCreate, LanguageStrings.AppErrorInvoiceCreateFailed);
                }
                else
                {
                    SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, sender, e);
                    throw;
                }
            }
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(LanguageStrings.AppInvoiceMarkAsProcessing, 
                    LanguageStrings.AppConfirm, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (ListViewItem item in lstInvoices.SelectedItems)
                    {
                        int invoiceID = Convert.ToInt32(item.SubItems[6].Text);

                        SharedBase.BOL.Invoices.Invoice invoice = SharedBase.BOL.Invoices.Invoices.Get(invoiceID);

                        if (invoice != null)
                            invoice.SetProcessStatus(AppController.ActiveUser, ProcessStatus.Processing);
                    }

                    ResetList();
                }
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_UPDATE_CONFLICTS))
                {
                    ShowError(LanguageStrings.AppUpdateFailed, LanguageStrings.AppErrorInvoiceUpdateFailed);
                }
                else
                    throw;
            }
        }

        private void lstInvoices_DoubleClick(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in lstInvoices.SelectedItems)
            {
                string file = String.Format(StringConstants.FILE_INVOICE_LOCATION,
                    Shared.Utilities.CurrentPath(true), 
                    StringConstants.FOLDER_INVOICES,
                    String.Format(StringConstants.FILE_INVOICE_PART,
                    DateTime.Now.ToString(StringConstants.FILE_NAME_DATE)));
                Invoice inv = SharedBase.BOL.Invoices.Invoices.Get(
                    Convert.ToInt32(itm.SubItems[6].Text));

                if (inv != null)
                {
                    PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                        StringConstants.PLUGIN_EVENT_VIEW_INVOICE, inv));
                }
            }
        }

        private void lstInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabelSelected.Text = String.Format(LanguageStrings.AppInvoicesSelected, 
                lstInvoices.SelectedItems.Count);
        }

        private void cmbPaymentStatus_Format(object sender, ListControlConvertEventArgs e)
        {
            PaymentStatus status = (PaymentStatus)e.ListItem;
            e.Value = status.Description;
        }

        private void cmbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetList();      
        }

        private void btnOnHold_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(LanguageStrings.AppInvoiceMarkAsOnHold,
                    LanguageStrings.AppConfirm, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (ListViewItem item in lstInvoices.SelectedItems)
                    {
                        int invoiceID = Convert.ToInt32(item.SubItems[6].Text);

                        Invoice invoice = SharedBase.BOL.Invoices.Invoices.Get(invoiceID);

                        if (invoice != null)
                            invoice.SetProcessStatus(AppController.ActiveUser, ProcessStatus.OnHold);
                    }

                    ResetList();
                }
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_UPDATE_CONFLICTS))
                {
                    ShowError(LanguageStrings.AppUpdateFailed, LanguageStrings.AppErrorInvoiceUpdateFailed);
                }
                else
                    throw;
            }
        }

        private void lstInvoices_ToolTipShow(object sender, Shared.ToolTipEventArgs e)
        {
            if (e.ListViewItem == null)
            {
                lstInvoices.ShowItemToolTips = false;
                return;
            }

            InvoiceStockStatus status = (InvoiceStockStatus)e.ListViewItem.Tag;

            e.Title = "Invoice " + e.ListViewItem.Text;
            Point currPos = this.PointToClient(MousePosition);

            if (status.AllStockAvailable)
            {
                e.Text = "All stock available";
            }
            else
            {
                string message = "The following stock is not available\r\n\r\n";

                foreach (string s in status.MissingStock)
                    message += String.Format("{0}\r\n", s);

                e.Text = message;
            }
        }

        #endregion Private Methods
    }
}
