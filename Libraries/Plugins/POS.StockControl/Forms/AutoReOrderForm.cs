using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Library.BOL.StockControl;

using Languages;
using POS.Base.Classes;

using POS.StockControl.Classes;

namespace POS.StockControl.Forms
{
    public partial class AutoReOrderForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Color _notIncludedBack;
        private Color _notIncludedFore;

        #endregion Private Members

        #region Constructors

        public AutoReOrderForm()
        {
            InitializeComponent();

            _notIncludedBack = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorOutOfStockBack);
            _notIncludedFore = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorOutOfStockFore);

            LoadGrid(GetStock());
        }

        #endregion Constructors

        #region Static Methods

        public static void ShowReOrderForm(Form parent)
        {
            AutoReOrderForm frm = new AutoReOrderForm();
            try
            {
                frm.ShowDialog(parent);
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StockAutoReOrder;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStockReOrderDescription;

            //column headers
            gridStock.Columns[0].HeaderText = LanguageStrings.AppStockStoreID;
            gridStock.Columns[1].HeaderText = LanguageStrings.AppStockReOrderAddToOrder;
            gridStock.Columns[2].HeaderText = LanguageStrings.AppStockID;
            gridStock.Columns[3].HeaderText = LanguageStrings.AppStockSKU;
            gridStock.Columns[4].HeaderText = LanguageStrings.AppStockName;
            gridStock.Columns[5].HeaderText = LanguageStrings.AppStockSize;
            gridStock.Columns[6].HeaderText = LanguageStrings.AppStockAvailable;
            gridStock.Columns[7].HeaderText = LanguageStrings.AppStockMinimumLevel;
            gridStock.Columns[8].HeaderText = LanguageStrings.AppStockOrderQuantity;
            gridStock.Columns[9].HeaderText = LanguageStrings.AppStockProductType;
            gridStock.Columns[10].HeaderText = LanguageStrings.AppStockCost;
            gridStock.Columns[11].HeaderText = LanguageStrings.AppStockHideGlobally;
            gridStock.Columns[12].HeaderText = LanguageStrings.AppStockOutOfStock;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ShowInformation(LanguageStrings.AppStockControl, StockWrapper.ReOrderLowStock(GetReorderStock()));
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private Stock GetReorderStock()
        {
            Stock Result = new Stock();

            Stock current = (Stock)gridStock.DataSource;

            foreach (StockItem item in current)
            {
                if (item.Changed && item.OrderQuantity > 0)
                {
                    Result.Add(item);
                }
            }

            return (Result);
        }

        private Stock GetStock()
        {
            Stock Result = new Stock();

            Stock currentStock = Stock.Get(AppController.ActiveUser, true);
            try
            {
                foreach (StockItem item in currentStock)
                {
                    if (item.AutoRestock && !String.IsNullOrEmpty(item.SKU) && item.SKU != StringConstants.STOCK_SKU)
                    {
                        if (item.Available < (item.MinLevel + AppController.LocalSettings.StockLevelLow))
                        {
                            decimal quantityRequired = item.OrderQuantity;
                            decimal orderQuantity = item.OrderQuantity;

                            while (quantityRequired < item.MinLevel)
                                quantityRequired += orderQuantity;

                            item.OrderQuantity = quantityRequired;
                            item.Changed = true;

                            //getting low, need to reorder
                            Result.Add(item);
                        }
                    }
                }
            }
            finally
            {
                currentStock.Clear();
                currentStock = null;
            }

            return (Result);
        }

        private void LoadGrid(Stock reOrderStock)
        {
            gridStock.DataSource = reOrderStock;

            gridStock.Columns[9].Visible = false;
            gridStock.Columns[10].Visible = false;
            gridStock.Columns[11].Visible = false;
            gridStock.Columns[12].Visible = false;
            gridStock.Columns[13].Visible = false;

            gridStock.Columns[0].Visible = false;
            gridStock.Columns[1].Visible = true;
            gridStock.Columns[2].Visible = false;
            gridStock.Columns[7].Visible = true;
            gridStock.Columns[8].Visible = true;
            gridStock.Columns[6].HeaderText = LanguageStrings.AppStockQuantityReOrder;
            gridStock.Columns[6].Width = 120;
            gridStock.Columns[4].Width = gridStock.Columns[2].Width * 2;
            gridStock.Columns[9].Width = 200;

            gridStock.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void gridStock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1: //changed i.e. include in order
                case 8: //available
                    e.Cancel = false;
                    break;
                default: // all others read only
                    e.Cancel = true;
                    break;
            }
        }

        private void gridStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StockItem item = (StockItem)gridStock.Rows[e.RowIndex].DataBoundItem;

            if (item != null && !item.Changed)
            {
                e.CellStyle.BackColor = _notIncludedBack;
                e.CellStyle.ForeColor = _notIncludedFore;
            }

        }

        private void gridStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void gridStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            gridStock.Invalidate();
        }

        #endregion Private Methods
    }
}
