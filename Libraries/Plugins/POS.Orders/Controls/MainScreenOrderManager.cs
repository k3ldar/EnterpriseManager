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
 *  File: MainScreenOrderManager.cs
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

using Library;
using Library.BOL.Invoices;
using Library.BOL.Coupons;
using Library.BOL.Statistics;

using Languages;

using Reports.Accounts;
using POS.Base.Classes;
using POS.Base.Controls;
using POS.Base.Labels;
using Library.BOL.StockControl;
using SharedControls.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace POS.Orders.Controls
{
    public partial class OrderDispatchControl : Base.Controls.BaseTabControl
    {
        #region Private Members

        private const int TIMER_TEN_SECONDS = 10000;
        private const int TIMER_ONE_SECOND = 1000;

        private WebsiteAdministration Admin;
        private Invoices _Invoices;
        private Invoice _currentInvoice;
        private bool _Editing = false;
        private int _Total;
        private Stock _currentstock;

        private bool _LabelPrinted = false;
        private bool _invoicePrinted = false;
        private bool _partialDispatch = false;

        #endregion Private Members

        #region Constructors

        public OrderDispatchControl()
        {
            InitializeComponent();

            cbIgnoreChecks.Checked = false;
            cbIgnoreChecks.Visible = AppController.ActiveUser.MemberLevel == MemberLevel.Admin || AppController.ActiveUser.MemberLevel == MemberLevel.AdminUpdateDelete;
            Admin = new Library.WebsiteAdministration(AppController.ActiveUser);
        }

        #endregion Constructors

        #region Properties

        public OrdersPluginModule PluginModule { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCleanAddress.Text = LanguageStrings.AppAddressClean;
            btnDispatch.Text = LanguageStrings.AppOrderDispatch;
            btnNext.Text = LanguageStrings.AppNext;
            btnPrintInvoice.Text = LanguageStrings.AppInvoicePrint;
            btnPrintLabel.Text = LanguageStrings.AppLabelPrint;
            btnStaffNotes.Text = LanguageStrings.AppMenuButtonStaffNotes;

            cbIgnoreChecks.Text = LanguageStrings.AppIgnoreChecks;

            lblName.Text = LanguageStrings.AppName;
            lblOutstandingOrders.Text = LanguageStrings.AppOrdersOutstanding;
        }

        public override void AfterTabShow()
        {
            if (timer1.Interval == TIMER_TEN_SECONDS)
                timer1.Interval = TIMER_ONE_SECOND;

            timer1.Enabled = true;
        }

        public override void BeforeTabHide()
        {
            timer1.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval == TIMER_ONE_SECOND)
                timer1.Interval = TIMER_TEN_SECONDS;

            SimpleStatistics stats = Invoices.InvoicesGetStats(AppController.ActiveUser, -1, -1, false, ProcessStatuses.Processing);

            if (stats.Count != _Total)
            {
                if (!_Editing)
                {
                    _Invoices = Invoices.InvoicesGet(AppController.ActiveUser, ProcessStatuses.Processing | ProcessStatuses.PartialDispatch, true, false);
                    GetFirstOrder();
                }
            }
        }

        private void GetFirstOrder()
        {
            _currentInvoice = _Invoices.First();

            if (_currentInvoice == null)
                this.Height = 78;
            else
            {
                _Total = _Invoices.Count;
                label2.Text = String.Format(LanguageStrings.AppItemOfItemQuantity, 1, _Total);
                _Editing = true;
                this.Height = 448;
                lblCustomer.Text = _currentInvoice.Address(false);
                BuildProductList();

                // show alert if has non discount coupon
                if (!String.IsNullOrEmpty(_currentInvoice.CouponName))
                {
                    Coupon cpn = Coupons.Get(_currentInvoice.CouponName);

                    if (cpn != null)
                    {
                        if (cpn.VoucherType == Enums.InvoiceVoucherType.Footprint)
                        {
                            ShowInformation(LanguageStrings.AppVoucher,
                                String.Format(LanguageStrings.AppInvoiceHasPromotionalCode, cpn.Name));
                        }
                    }
                }


                if (!String.IsNullOrEmpty(_currentInvoice.StaffNotes))
                {
                    ShowInformation(LanguageStrings.AppMenuButtonStaffNotes, LanguageStrings.AppStaffNotesAlert);

                    btnStaffNotes.Enabled = true;
                }
                else
                    btnStaffNotes.Enabled = false;
            }
        }

        private void BuildProductList()
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            this.SuspendDrawing();
            try
            {
                lblDateReceived.Text = String.Format(LanguageStrings.AppDateReceived,
                    _currentInvoice.PurchaseDateTime.ToShortDateString());
                pnlOrderItems.Controls.Clear();
                _partialDispatch = false;

                _currentstock = Stock.Get(AppController.ActiveUser, true);

                foreach (InvoiceItem item in _currentInvoice.InvoiceItems)
                {
                    switch (item.ItemStatus)
                    {
                        case ProcessItemStatus.NotDispatched:
                        case ProcessItemStatus.Dispatching:
                        case ProcessItemStatus.Dispatched:
                        case ProcessItemStatus.OnHold:
                            OrderItem itm = new OrderItem();
                            itm.OnItemStatusChanged += itm_OnItemStatusChanged;

                            itm.Refresh(GetStockAvailable(item), item);
                            itm.Width = pnlOrderItems.Width - 6;

                            pnlOrderItems.Controls.Add(itm);

                            break;
                    }
                }

                MainScreenOrderManager_ResizeEnd(this, EventArgs.Empty);
            }
            finally
            {
                this.ResumeDrawing();
                this.Cursor = Cursors.Arrow;
            }
        }

        void itm_OnItemStatusChanged(object sender, EventArgs e)
        {
            if (_currentInvoice != null)
            {
                OrderItem orderItem = (OrderItem)sender;
                int dispatchingCount = 0;

                foreach (InvoiceItem invItem in _currentInvoice.InvoiceItems)
                {
                    if (invItem.ID == orderItem.ItemID)
                    {
                        invItem.ItemStatus = orderItem.ItemStatus;

                        if (orderItem.ItemStatus != ProcessItemStatus.Dispatching)
                            _partialDispatch = true;
                    }

                    if (invItem.ItemStatus == ProcessItemStatus.Dispatching)
                        dispatchingCount++;
                }

                if (cbIgnoreChecks.Checked)
                    btnDispatch.Enabled = true;
                else
                    btnDispatch.Enabled = dispatchingCount > 0;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentInvoice != null)
            {
                _currentInvoice = _Invoices.Next(_currentInvoice);

                if (_currentInvoice == null)
                    _currentInvoice = _Invoices.First();

                if (_currentInvoice == null)
                    return;

                label2.Text = String.Format(LanguageStrings.AppItemOfItemQuantity,
                    _Invoices.IndexOf(_currentInvoice) + 1, _Total);
                lblCustomer.Text = _currentInvoice.Address(false);
                BuildProductList();
                _Editing = true;
                this.Height = 448;
                _LabelPrinted = false;
                _invoicePrinted = false;

                // show alert if has non discount coupon
                if (!String.IsNullOrEmpty(_currentInvoice.CouponName))
                {
                    Coupon cpn = Coupons.Get(_currentInvoice.CouponName);

                    if (cpn != null)
                    {
                        if (cpn.VoucherType == Enums.InvoiceVoucherType.Footprint)
                        {
                            ShowInformation(LanguageStrings.AppVoucher,
                                String.Format(LanguageStrings.AppInvoiceHasPromotionalCode, cpn.Name));
                        }
                    }
                }

                if (!String.IsNullOrEmpty(_currentInvoice.StaffNotes))
                {
                    ShowInformation(LanguageStrings.AppMenuButtonStaffNotes, LanguageStrings.AppStaffNotesAlert);

                    btnStaffNotes.Enabled = true;
                }
                else
                    btnStaffNotes.Enabled = false;
            }
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            try
            {
                ShippingLabel label = new ShippingLabel(_currentInvoice.DeliveryAddress);
                label.Print();
                _LabelPrinted = true;
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);

                if (err.Message.Contains(StringConstants.ERROR_PRINTER_DELETED))
                    ShowError(LanguageStrings.AppLabelPrinter,
                        LanguageStrings.AppLabelPrinterDeleted);
                else
                    ShowError(LanguageStrings.AppLabelPrinter,
                        String.Format(LanguageStrings.AppLabelPrinterError, err.Message));
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            PDFInvoice inv = new PDFInvoice(_currentInvoice, AppController.LocalSettings.InvoiceHeaderRight,
                AppController.LocalSettings.InvoiceFooter, AppController.LocalSettings.InvoiceAddress,
                AppController.LocalSettings.InvoiceVATRegistrationNumber,
                AppController.LocalSettings.CustomCulture,
                Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices,
                AppController.LocalSettings.InvoiceShowProductDiscount,
                AppController.LocalSettings.InvoiceFooterPaid,
                AppController.LocalSettings.OrderManagerOrderPreparedBy,
                AppController.LocalSettings.OrderManagerPreparedByAlignment,
                AppController.LocalSettings.InvoicePrefix);
            inv.Print();

            _invoicePrinted = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                _currentInvoice.DeliveryAddress.FixAddress(AppController.LocalCulture);
                _currentInvoice.DeliveryAddress.Save();
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_ADDRESS_IN_USE))
                    throw;
            }

            try
            {
                _currentInvoice.User.FixAddress();
                _currentInvoice.User.Save();
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_ADDRESS_IN_USE))
                    throw;
            }

            lblCustomer.Text = _currentInvoice.Address(false);
        }

        private void btnDispatch_Click(object sender, EventArgs e)
        {
            if (!cbIgnoreChecks.Checked)
            {
                if (!_invoicePrinted)
                {
                    MessageBox.Show(LanguageStrings.AppOrderDispatchInvoiceNotPrinted,
                        LanguageStrings.AppErrorOrderDispatch,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (!AppController.LocalSettings.OrderManagerBypassLabel && !_LabelPrinted)
                {
                    MessageBox.Show(LanguageStrings.AppOrderDispatchLabelNotPrinted,
                        LanguageStrings.AppErrorOrderDispatch,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            foreach (Control ctl in pnlOrderItems.Controls)
            {
                OrderItem itm = (OrderItem)ctl;

                if (!itm.IsReady)
                {
                    MessageBox.Show(LanguageStrings.AppOrderDispatchCheckItems,
                        LanguageStrings.AppErrorOrderDispatch,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }


            //update item status
            Forms.InvoiceDispatched id = new Forms.InvoiceDispatched(AppController.ActiveUser, _currentInvoice, _partialDispatch);
            try
            {
                if (id.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _Total--;
                    //remove from list
                    _Invoices.Remove(_currentInvoice);

                    if (PluginModule != null)
                        PluginModule.ResetTrayNotifications();

                    // get next order
                    button1_Click(sender, e);
                }


            }
            catch (Exception err)
            {
                if (err.Message == "Stock Level Can not be less than zero")
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorStockZero);
                else
                    throw;
            }
            finally
            {
                id.Dispose();
                id = null;
            }

            PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_ORDER_DISPATCHED);
        }

        private void MainScreenOrderManager_Activated(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void MainScreenOrderManager_Shown(object sender, EventArgs e)
        {
            timer1_Tick(this, new EventArgs());
            timer1.Enabled = true;
        }

        private void MainScreenOrderManager_ResizeEnd(object sender, EventArgs e)
        {
            int newWidth = pnlOrderItems.Width - 6;

            if (pnlOrderItems.VerticalScroll.Visible)
                newWidth -= 20;

            foreach (OrderItem ctl in pnlOrderItems.Controls)
            {
                ctl.Width = newWidth;

                //reset width based on size of the product name
                Size singleCharWidth = Shared.Utilities.MeasureText("A", ctl.Font);

                Size newSize = Shared.Utilities.MeasureText(ctl.ProductDescription, ctl.Font, ctl.DescriptionWidth);
                ctl.Height = Shared.Utilities.MinimumValue(35, (((newSize.Width / ctl.DescriptionWidth) + 1) * newSize.Height) + 26);
            }
        }

        private void btnStaffNotes_Click(object sender, EventArgs e)
        {
            string notes = _currentInvoice.StaffNotes;

            if (POS.Base.Forms.NotesViewForm.ShowNotes(null, ref notes, false, 32000))
                _currentInvoice.UpdateStaffNotes(notes);
        }

        #endregion Private Methods
    }
}
