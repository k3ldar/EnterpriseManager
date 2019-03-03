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
 *  File: InvoiceView.cs
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
using SharedBase.BOL.Invoices;

using Languages;

using Reports.Accounts;
using POS.Base.Classes;
using POS.Base.Forms;
using POS.Base.Labels;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace POS.Invoices.Forms
{
    public partial class InvoiceView : BaseForm
    {
        #region Private Members

        private Invoice _CurrentInvoice;

        #endregion Private Members

        #region Constructors

        public InvoiceView()
        {
            InitializeComponent();
        }

        public InvoiceView(Invoice invoice)
            : this ()
        {
            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainMarkPaid.Image = POS.Base.Icons.PaidIcon();
            toolStripMainViewUser.Image = POS.Base.Icons.UserIcon();
            toolStripMainPrintLabel.Image = POS.Base.Icons.PrintLabelIcon();
            toolStripMainPrintInvoice.Image = POS.Base.Icons.PrintIcon();
            toolStripMainNotes.Image = POS.Base.Icons.NotesIcon();
            toolStripMainUserNotes.Image = POS.Base.Icons.UserNotesIcon();
            toolStripMainChangeSalesPerson.Image = POS.Base.Icons.ChangeSalesPersonIcon();
            toolStripMainRefund.Image = POS.Base.Icons.RefundIcon();
            toolStripMainTracking.Image = POS.Base.Icons.TrackingIcon();
            toolStripMainChangeDate.Image = POS.Base.Icons.DateIcon();
            toolStripMainClose.Image = POS.Base.Icons.CloseIcon();
            

            toolStripMainEdit.Enabled = false;

            _CurrentInvoice = invoice;

            LoadInvoice();

            dtpInvoiceDate.Enabled = AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ChangeInvoiceDate);
            toolStripMainChangeSalesPerson.Enabled = AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.ChangeSalesPerson);
            toolStripMainChangeDate.Enabled = false;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceView;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblInvoiceDesc.Text = LanguageStrings.AppInvoice;
            lblDateDesc.Text = LanguageStrings.AppDate;
            lblInvoiceAddressDesc.Text = LanguageStrings.AppAddressInvoice;
            lblShipAddressDesc.Text = LanguageStrings.AppAddressShipping;
            lblTelephoneNumber.Text = LanguageStrings.AppTelephoneNumber;
            lblEmailAddressDesc.Text = LanguageStrings.AppEmail;
            lblOrderDetailsDesc.Text = LanguageStrings.AppOrderDetails;
            lblPaymentTypeDesc.Text = LanguageStrings.AppPaymentType;
            lblOrderStatusDesc.Text = LanguageStrings.AppOrderStatus;
            lblSubTotalDesc.Text = LanguageStrings.AppSubTotal;
            lblPostageDesc.Text = LanguageStrings.AppPostage;
            lblVATDesc.Text = LanguageStrings.AppTax;
            lblTotalDesc.Text = LanguageStrings.AppTotal;
            lblCompletedBy.Text = LanguageStrings.AppSaleCompletedBy;


            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintCancel;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
            toolStripMainMarkPaid.Text = LanguageStrings.AppHintMarkAsPaid;
            toolStripMainViewUser.Text = LanguageStrings.AppHintViewUser;
            toolStripMainPrintLabel.Text = LanguageStrings.AppHintPrintLabel;
            toolStripMainPrintInvoice.Text = LanguageStrings.AppHintPrintInvoice;
            toolStripMainUserNotes.Text = LanguageStrings.AppHintUserNotes;
            toolStripMainNotes.Text = LanguageStrings.AppHintStaffNotes;
            toolStripMainChangeSalesPerson.Text = LanguageStrings.AppHintChangeSalesPerson;
            toolStripMainRefund.Text = LanguageStrings.AppHintRefund;
            toolStripMainTracking.Text = LanguageStrings.AppHintTracking;
            toolStripMainChangeDate.Text = LanguageStrings.AppHintChangeInvoiceDate;
            toolStripMainClose.Text = LanguageStrings.AppHintClose;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadInvoice()
        {
            toolStripMainDelete.Enabled = _CurrentInvoice.Status.ID != 10;

            switch (_CurrentInvoice.ProcessStatus)
            {
                case ProcessStatus.OrderReceived:
                    toolStripMainTracking.Enabled = false;
                    break;
                case ProcessStatus.Processing:
                    toolStripMainTracking.Enabled = false;
                    break;
                case ProcessStatus.Dispatched:
                    toolStripMainTracking.Enabled = true;
                    break;
                default:
                    toolStripMainTracking.Enabled = false;
                    break;
            }

            lblInvoiceNo.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX, 
                AppController.LocalSettings.InvoicePrefix, 
                _CurrentInvoice.DisplayID);
            dtpInvoiceDate.Value = _CurrentInvoice.PurchaseDateTime;

            lblAddress.Text = _CurrentInvoice.User.Address(false);

            if (_CurrentInvoice.DeliveryAddress == null)
                lblShippingAddress.Text = _CurrentInvoice.User.Address(false);
            else
                lblShippingAddress.Text = _CurrentInvoice.DeliveryAddress.Address(false);

            if (lblAddress.Text == lblShippingAddress.Text)
            {
                lblShipAddressDesc.Visible = false;
                lblShippingAddress.Visible = false;
            }

            lblTelephoneNo.Text = _CurrentInvoice.User.Telephone;
            lblEmailAddress.Text = _CurrentInvoice.User.Email;

            if (_CurrentInvoice.VoucherType == Enums.InvoiceVoucherType.Percent)
            {
                if (_CurrentInvoice.DiscountAmount > 0.00m)
                    lblDiscountDesc.Text = String.Format(LanguageStrings.AppDiscountPercent, 
                        _CurrentInvoice.Discount, _CurrentInvoice.CouponName);
                else
                    lblDiscountDesc.Text = LanguageStrings.AppDiscountNoDiscount;
            }
            else
                lblDiscountDesc.Text = String.Format(LanguageStrings.AppDiscountValue,
                    AppController.LocalCountry.CurrencySymbol, 
                    _CurrentInvoice.Discount, _CurrentInvoice.CouponName);

            lblDiscountTotal.Text = _CurrentInvoice.DiscountAmountStr;

            lblPostageTotal.Text = _CurrentInvoice.ShippingCostsStr;

            lblVATDesc.Text = String.Format(LanguageStrings.AppTaxPercentage, _CurrentInvoice.VATRate);
            lblVATTotal.Text = _CurrentInvoice.VatAmountStr;

            lblTotalTotal.Text = _CurrentInvoice.TotalCostStr;

            lblOrderStatus.Text = POS.Base.EnumTranslations.Translate(_CurrentInvoice.ProcessStatus);

            if (_CurrentInvoice.ProcessStatus == ProcessStatus.Dispatched || _CurrentInvoice.ProcessStatus== ProcessStatus.Completed)
                lblOrderStatus.Text = String.Format(LanguageStrings.AppInvoiceDispatchedOn, 
                    Shared.Utilities.DateToStr(_CurrentInvoice.Dateshipped, 
                    System.Threading.Thread.CurrentThread.CurrentUICulture.Name)); 

            if (!String.IsNullOrEmpty(_CurrentInvoice.TrackingReference))
            {
                lnkTrackingReference.Text = _CurrentInvoice.TrackingReference;
                lnkTrackingReference.Visible = true;
            }
            else
            {
                lnkTrackingReference.Visible = false;
            }

            lblPaymentType.Text = _CurrentInvoice.Status.Description;

            lblCompletedByName.Text = _CurrentInvoice.RemoteHost;

            bool showNames = _CurrentInvoice.Status.IsOffice || _CurrentInvoice.Status.IsTill;
            lblCompletedByName.Visible = showNames;
            lblCompletedBy.Visible = showNames;

            toolStripMainUserNotes.Enabled = !String.IsNullOrEmpty(_CurrentInvoice.Notes);

            BuildProductList();
        }

        private void BuildProductList()
        {
            gridInvoiceItems.DataSource = InvoiceViewItems.Get(_CurrentInvoice.InvoiceItems);

            gridInvoiceItems.Columns[0].Width = Shared.Utilities.MeasureText(LanguageStrings.AppSKU, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[0].HeaderText = LanguageStrings.AppSKU;
            gridInvoiceItems.Columns[1].Width = Shared.Utilities.CheckMinMax(
                Shared.Utilities.MeasureText(LanguageStrings.AppDescription, gridInvoiceItems.Font).Width + 10, 200, 500);
            gridInvoiceItems.Columns[1].HeaderText = LanguageStrings.AppDescription;
            gridInvoiceItems.Columns[2].Width = Shared.Utilities.MeasureText(LanguageStrings.AppPrice, gridInvoiceItems.Font).Width + 10; 
            gridInvoiceItems.Columns[2].HeaderText = LanguageStrings.AppPrice;
            gridInvoiceItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridInvoiceItems.Columns[3].Width = Shared.Utilities.MeasureText(LanguageStrings.AppQuantity, gridInvoiceItems.Font).Width + 10; 
            gridInvoiceItems.Columns[3].HeaderText = LanguageStrings.AppQuantity;
            gridInvoiceItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridInvoiceItems.Columns[4].Width = Shared.Utilities.MeasureText(LanguageStrings.AppCost, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[4].HeaderText = LanguageStrings.AppCost;
            gridInvoiceItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridInvoiceItems.Columns[5].Width = Shared.Utilities.MeasureText(LanguageStrings.AppItemType, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[5].HeaderText = LanguageStrings.AppItemType;
            gridInvoiceItems.Columns[6].Width = Shared.Utilities.MeasureText(LanguageStrings.AppSalesPerson, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[6].HeaderText = LanguageStrings.AppSalesPerson;
            gridInvoiceItems.Columns[7].Width = Shared.Utilities.MeasureText(LanguageStrings.AppUserDiscountPercent, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[7].HeaderText = LanguageStrings.AppUserDiscountPercent;
            gridInvoiceItems.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridInvoiceItems.Columns[8].Width = Shared.Utilities.MeasureText(LanguageStrings.AppUserDiscountValue, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[8].HeaderText = LanguageStrings.AppUserDiscountValue;
            gridInvoiceItems.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridInvoiceItems.Columns[9].Width = Shared.Utilities.MeasureText(LanguageStrings.AppProductDiscountPercent, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[9].HeaderText = LanguageStrings.AppProductDiscountPercent;
            gridInvoiceItems.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridInvoiceItems.Columns[10].Width = Shared.Utilities.MeasureText(LanguageStrings.AppProductDiscountValue, gridInvoiceItems.Font).Width + 10;
            gridInvoiceItems.Columns[10].HeaderText = LanguageStrings.AppProductDiscountValue;
            gridInvoiceItems.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            switch (_CurrentInvoice.Version)
            {
                case Consts.INVOICE_VERSION_VAT_ADD_OPTIONS:
                    lblSubtotalTotal.Text = _CurrentInvoice.SubTotalAmountStr;
                    break;
                default:
                    lblSubtotalTotal.Text = _CurrentInvoice.InvoiceItems.SubTotalStr;
                    break;
            }

        }

        private void lnkTrackingReference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //execute web page
            string URL = _CurrentInvoice.TrackingURL;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(URL);
            proc.StartInfo = startInfo;
            proc.Start();
        }

        private void dtpInvoiceDate_ValueChanged(object sender, EventArgs e)
        {
            toolStripMainChangeDate.Enabled = dtpInvoiceDate.Value != _CurrentInvoice.PurchaseDateTime;
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CancelInvoices))
            {
                if (InvoiceCancel.InvoiceCancelShow(_CurrentInvoice))
                {
                    _CurrentInvoice = SharedBase.BOL.Invoices.Invoices.Get(_CurrentInvoice.ID);
                    LoadInvoice();
                }
            }
            else
            {
                ShowError(LanguageStrings.AppInvoiceCancel, LanguageStrings.AppPermissionCancelInvoice);
            }
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoice();
        }

        private void toolStripMainMarkPaid_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainViewUser_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                _CurrentInvoice.User));
        }

        private void toolStripMainPrintLabel_Click(object sender, EventArgs e)
        {
            try
            {
                ShippingLabel lbl = new ShippingLabel(_CurrentInvoice.DeliveryAddress);
                lbl.Print();
            }
            catch (Exception error)
            {
                if (String.IsNullOrEmpty(SharedBase.XML.GetXMLValue(
                    Shared.Utilities.CurrentPath(true) + StringConstants.XML_CONFIG_FILE,
                    StringConstants.XML_LABEL_PRINTER, StringConstants.XML_LABEL_NAME)))
                {
                    if (ShowErrorMessage(LanguageStrings.AppLabelPrint, LanguageStrings.AppLabelPrinterSetup))
                    {
                        try
                        {
                            POS.Base.Plugins.NotificationEventArgs args = new POS.Base.Plugins.NotificationEventArgs(
                                StringConstants.PLUGIN_EVENT_LOAD_ADMIN_SETTINGS, null);

                            PluginManager.RaiseEvent(args);

                            if ((bool)args.Result)
                                ShowInformation(LanguageStrings.AppLabelPrint, LanguageStrings.AppLabelPrinterRePrint);
                        }
                        catch (Exception err)
                        {
                            ShowError(LanguageStrings.AppLabelPrinter, err.Message);
                        }
                    }
                }
                else
                {
                    ShowError(LanguageStrings.AppLabelPrint,
                        String.Format(LanguageStrings.AppLabelPrinterError, error.Message));
                }
            }
        }

        private void toolStripMainPrintInvoice_Click(object sender, EventArgs e)
        {
            PDFInvoice inv = new PDFInvoice(_CurrentInvoice, AppController.LocalSettings.InvoiceHeaderRight,
                        AppController.LocalSettings.InvoiceFooter, AppController.LocalSettings.InvoiceAddress,
                        AppController.LocalSettings.InvoiceVATRegistrationNumber,
                        AppController.LocalSettings.CustomCulture,
                SharedBase.DAL.DALHelper.HideVATOnWebsiteAndInvoices,
                AppController.LocalSettings.InvoiceShowProductDiscount, String.Empty, String.Empty, 1,
                AppController.LocalSettings.InvoicePrefix);
            inv.Print();
        }

        private void toolStripMainNotes_Click(object sender, EventArgs e)
        {
            string notes = _CurrentInvoice.StaffNotes;

            if (NotesViewForm.ShowNotes(this, ref notes, false, 32000))
                _CurrentInvoice.UpdateStaffNotes(notes);
        }

        private void toolStripMainUserNotes_Click(object sender, EventArgs e)
        {
            string notes = _CurrentInvoice.Notes;
            NotesViewForm.ShowNotes(this, ref notes, true, 10000);
        }

        private void toolStripMainChangeSalesPerson_Click(object sender, EventArgs e)
        {
            ChangeSalesPerson changeForm = new ChangeSalesPerson(_CurrentInvoice);
            try
            {
                changeForm.ShowDialog(this);
            }
            finally
            {
                changeForm.Dispose();
                changeForm = null;
            }
        }

        private void toolStripMainRefund_Click(object sender, EventArgs e)
        {
            IssueRefundForm refundForm = new IssueRefundForm(_CurrentInvoice);
            try
            {
                refundForm.ShowDialog();
            }
            finally
            {
                refundForm.Dispose();
                refundForm = null;
            }
        }

        private void toolStripMainTracking_Click(object sender, EventArgs e)
        {
            TrackingReference tr = new TrackingReference(_CurrentInvoice.TrackingReference);
            try
            {
                if (tr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _CurrentInvoice.SetDispatched(AppController.ActiveUser, ProcessStatus.Dispatched, tr.TrackingRef);
                }
            }
            finally
            {
                tr.Dispose();
                tr = null;
            }
        }

        private void toolStripMainChangeDate_Click(object sender, EventArgs e)
        {
            _CurrentInvoice.SetDate(dtpInvoiceDate.Value);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.Modal)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                Close();
        }

        #endregion Private Methods
    }
}
