﻿using System;
using System.Windows.Forms;
using Languages;
using Library.BOL.Invoices;
using Library.BOL.Orders;
using Library.BOL.StockControl;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Forms
{
    public partial class InvoiceCancel : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Stock _stock;
        private Invoice _invoice = null;
        private Order _order = null;

        #endregion Private Members

        #region Constructors

        public InvoiceCancel()
        {
            InitializeComponent();
        }

        public InvoiceCancel(Order order)
            :this()
        {
            gbMoveStockBackIn.Enabled = order.ProcessStatus == Library.ProcessStatus.Dispatched;

            _invoice = Library.BOL.Invoices.Invoices.Get(order);
            _order = order;
            LoadStockReturnItems();

            UpdateUI();
        }

        public InvoiceCancel(Invoice invoice)
            : this ()
        {
            _invoice = invoice;
            _order = Orders.Get(invoice.OrderID);

            gbMoveStockBackIn.Enabled = invoice.ProcessStatus == Library.ProcessStatus.Dispatched ||
                invoice.ProcessStatus == Library.ProcessStatus.PartialDispatch;

            LoadStockReturnItems();

            UpdateUI();
        }

        #endregion Constructors

        #region Static Methods

        public static bool InvoiceCancelShow(Invoice invoice)
        {
            InvoiceCancel form = new InvoiceCancel(invoice);
            try
            {
                return (form.ShowDialog() == DialogResult.Yes);
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }

        public static bool InvoiceCancelShow(Order order)
        {
            InvoiceCancel form = new InvoiceCancel(order);
            try
            {
                return (form.ShowDialog() == DialogResult.Yes);
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceCancel;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppInvoiceCancel;
            lblPrompt.Text = LanguageStrings.AppInvoiceCancelConfirm;
            gbMoveStockBackIn.Text = LanguageStrings.AppStockMoveCancelledStockBackIn;

            btnYes.Text = LanguageStrings.AppYes;
            btnNo.Text = LanguageStrings.AppNo;

            //column headers

            if (_stock != null)
            {
                gridStock.Columns[0].Visible = false;
                gridStock.Columns[1].Visible = false;
                gridStock.Columns[2].Visible = false;
                gridStock.Columns[3].HeaderText = LanguageStrings.AppStockSKU;
                gridStock.Columns[4].HeaderText = LanguageStrings.AppStockName;
                gridStock.Columns[4].Width = 350;
                gridStock.Columns[5].Visible = false;
                gridStock.Columns[6].HeaderText = LanguageStrings.AppStockAvailable;
                gridStock.Columns[7].Visible = false;
                gridStock.Columns[8].Visible = false;
                gridStock.Columns[9].Visible = false;
                gridStock.Columns[10].Visible = false;
                gridStock.Columns[11].Visible = false;
                gridStock.Columns[12].Visible = false;
                gridStock.Columns[13].Visible = false;
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void UpdateUI()
        {
            if (_stock == null || !gbMoveStockBackIn.Enabled)
            {
                this.Height = 112;
                this.Width = 480;
            }
        }

        private void LoadStockReturnItems()
        {
            if (_invoice == null)
                return;

            if (_invoice.ProcessStatus == Library.ProcessStatus.Dispatched ||
                _invoice.ProcessStatus == Library.ProcessStatus.PartialDispatch)
            {
                _stock = new Stock();

                foreach (InvoiceItem item in _invoice.InvoiceItems)
                {
                    if (item.ItemStatus == Library.ProcessItemStatus.Dispatched)
                    {
                        _stock.Add(new StockItem(item.ItemID, item.SKU, item.Description, String.Empty, 0, 0, item.Quantity,
                            Library.DAL.DALHelper.StoreID, item.ProductCostType, false, false, false, String.Empty));
                    }
                    else
                    {
                        _stock.Add(new StockItem(item.ItemID, item.SKU, item.Description, String.Empty, 0, 0, item.Quantity,
                            Library.DAL.DALHelper.StoreID, item.ProductCostType, false, false, false, String.Empty));
                    }
                }
            }

            gridStock.DataSource = _stock;
        }

        private void gridStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StockItem item = (StockItem)gridStock.Rows[e.RowIndex].DataBoundItem;

            item.Available = Shared.Utilities.CheckMinMax(item.Available, 0, item.MinLevel);
            btnYes.Enabled = true;
            gridStock.Invalidate();
        }

        private void gridStock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 6: // qty to return
                    e.Cancel = false;
                    btnYes.Enabled = false;
                    break;
                default: // all others read only
                    e.Cancel = true;
                    break;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (_invoice == null)
                {
                    _order.Cancel();
                }
                else
                {
                    _invoice.Cancel(_stock, POS.Base.Classes.AppController.ActiveUser);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                //_CurrentInvoice.Cancel();
                //_CurrentOrder.Cancel();
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion Private Methods
    }
}
