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
 *  File: InvoicesReceived.cs
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

using SieraDelta.Languages;

using SieraDelta.Library;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Accounts;
using SieraDelta.Library.BOL.Users;
using SieraDelta.Library.BOL.Invoices;
using SieraDelta.Reports.Accounts;
using SieraDelta.POS.Classes;

namespace SieraDelta.POS.Orders.Forms
{
    public partial class InvoicesReceived : SieraDelta.Controls.Forms.BaseForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public InvoicesReceived()
        {
            InitializeComponent();
            LoadPaymentTypes();

            ResetList();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppInvoicesReceived;

            lblPaymentStatus.Text = LanguageStrings.AppPaymentStatus;

            btnPrint.Text = LanguageStrings.AppMenuButtonPrint;
            btnProcessing.Text = LanguageStrings.AppMenuButtonProcessing;

            chInvoice.Text = LanguageStrings.AppInvoiceNumber;
            chInvoiceAmount.Text = LanguageStrings.AppInvoiceAmount;
            chPurchaseDate.Text = LanguageStrings.AppPurchaseDate;
            chCustomer.Text = LanguageStrings.AppCustomer;
            chPaymentType.Text = LanguageStrings.AppPaymentType;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadPaymentTypes()
        {
            cmbPaymentStatus.Items.Clear();
            PaymentStatus paymentAny = new PaymentStatus(-1, LanguageStrings.AppInvoiceAnyPayment,
                0, true, String.Empty, true, true, true);
            cmbPaymentStatus.Items.Add(paymentAny);

            foreach (PaymentStatus status in PaymentStatuses.Get())
            {
                if (status.IsPaid)
                    cmbPaymentStatus.Items.Add(status);
            }

            cmbPaymentStatus.SelectedIndex = 0;
        }

        private void ResetList()
        {
            Invoices invoices;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                lstInvoices.BeginUpdate();
                try
                {
                    PaymentStatus status = (PaymentStatus)cmbPaymentStatus.SelectedItem;

                    if (status.ID == -1)
                    {
                        invoices = Invoices.InvoicesGet(AppController.ActiveUser, true, false, false, false, true);
                    }
                    else
                    {
                        invoices = Invoices.InvoicesGet(AppController.ActiveUser, true, false, false, false, status);
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
                        lvi.SubItems.Add(inv.ID.ToString());
                        total += inv.TotalCost * Convert.ToDecimal(inv.CostMultiplier);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Invoices invoices = new Invoices();

            foreach (ListViewItem item in lstInvoices.SelectedItems)
            {
                int invoiceID = Convert.ToInt32(item.SubItems[5].Text);

                Invoice invoice = Invoices.Get(invoiceID);
                invoices.Add(invoice);
            }

            try
            {
                PDFInvoice report = new PDFInvoice(invoices, AppController.LocalSettings.InvoiceHeader,
                    AppController.LocalSettings.InvoiceFooter, AppController.LocalSettings.CustomCulture,
                    SieraDelta.Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices,
                    AppController.LocalSettings.InvoiceShowProductDiscount);
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
                    SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, sender, e);
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
                        int invoiceID = Convert.ToInt32(item.SubItems[5].Text);

                        Invoice invoice = Invoices.Get(invoiceID);

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
                    SieraDelta.Shared.Utilities.CurrentPath(true), 
                    StringConstants.FOLDER_INVOICES,
                    String.Format(StringConstants.FILE_INVOICE_PART,
                    DateTime.Now.ToString(StringConstants.FILE_NAME_DATE)));
                Invoice inv = SieraDelta.Library.BOL.Invoices.Invoices.Get(
                    Convert.ToInt32(itm.SubItems[5].Text));

                if (inv != null)
                {
                    PluginManager.RaiseEvent(new Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_VIEW_INVOICE, inv));
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

        #endregion Private Methods
    }
}
