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
 *  File: StockIn.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.StockControl;
using Library.BOL.Users;
using Library.BOL.Products;
using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.StockControl.Forms
{
    public partial class StockIn : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Stock _CurrentStock;
        private Stock _NewStock;
        private User _CurrentUser;

        #endregion Private Members

        #region Constructors

        public StockIn(ref Stock CurrentStock, User CurrentUser)
        {
            InitializeComponent();
            _CurrentStock = CurrentStock;
            _CurrentUser = CurrentUser;

            _NewStock = Library.BOL.StockControl.Stock.Get(_CurrentUser, true);

            foreach (StockItem item in _NewStock)
            {
                item.Available = 0;
            }

            LoadProductTypes();
            cmbProductType.SelectedIndexChanged += new EventHandler(cmbProductType_SelectedIndexChanged);
            LoadGrid(_NewStock);
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StockIn;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStockMoveStockIn;

            lblFilter.Text = LanguageStrings.AppFilter;
            lblProductType.Text = LanguageStrings.AppProductType;

            //column headers
            gridStock.Columns[0].HeaderText = LanguageStrings.AppStockStoreID;
            gridStock.Columns[1].HeaderText = LanguageStrings.AppStockChanged;
            gridStock.Columns[2].HeaderText = LanguageStrings.AppStockID;
            gridStock.Columns[3].HeaderText = LanguageStrings.AppStockSKU;
            gridStock.Columns[4].HeaderText = LanguageStrings.AppStockName;
            gridStock.Columns[5].HeaderText = LanguageStrings.AppStockSize;
            gridStock.Columns[6].HeaderText = LanguageStrings.AppStockQuantityIn;
            gridStock.Columns[7].HeaderText = LanguageStrings.AppStockMinimumLevel;
            gridStock.Columns[8].HeaderText = LanguageStrings.AppStockOrderQuantity;
            gridStock.Columns[9].HeaderText = LanguageStrings.AppStockProductType;
            gridStock.Columns[10].HeaderText = LanguageStrings.AppStockCost;
            gridStock.Columns[11].HeaderText = LanguageStrings.AppStockHideGlobally;
            gridStock.Columns[12].HeaderText = LanguageStrings.AppStockOutOfStock;            
        }

        #endregion Overridden Methods

        #region Private Methods

        void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid(_NewStock);
            gridStock.Focus();
        }

        private void LoadProductTypes()
        {
            cmbProductType.Items.Clear();

            foreach (ProductCostType item in ProductCostTypes.Get())
            {
                cmbProductType.Items.Add(item);
            }

            cmbProductType.SelectedIndex = 0;
        }

        private void LoadGrid(Stock StockItem)
        {
            ProductCostType type = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];
            Stock FilteredStock = new Stock();

            foreach (StockItem item in StockItem)
            {
                if (item.ProductType.ID == type.ID)
                {
                    string itm = String.Format(StringConstants.STOCK_SEARCH_FILTER, item.Name.ToLower(), item.SKU.ToLower(), item.Size.ToLower(), item.Available);

                    if (itm.ToLower().Contains(txtFilter.Text.ToLower()))
                        FilteredStock.Add(item);
                }
            }

            gridStock.DataSource = FilteredStock;

            if (FilteredStock.Count > 0)
            {
                gridStock.Columns[0].Visible = false;
                gridStock.Columns[1].Visible = false;
                gridStock.Columns[2].Visible = false;
                gridStock.Columns[7].Visible = false;
                gridStock.Columns[8].Visible = false;
                gridStock.Columns[13].Visible = false;
                gridStock.Columns[6].HeaderText = LanguageStrings.AppStockQuantityIn;
                gridStock.Columns[4].Width = gridStock.Columns[2].Width * 2;
                gridStock.Columns[9].Width = 200;
            }

            gridStock.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void gridStock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 6: //available
                    e.Cancel = false;
                    break;
                default: // all others read only
                    e.Cancel = true;
                    break;
            }
        }

        private void gridStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridStock.Columns[e.ColumnIndex].Index.Equals(6)) //currently in stock   4 < 5
            {
                if (e.Value != null)
                {
                    StockItem item = (StockItem)gridStock.Rows[e.RowIndex].DataBoundItem;

                    if ((int)e.Value < item.MinLevel)
                    {
                        //e.CellStyle.BackColor = Color.Red;
                        //e.CellStyle.SelectionBackColor = Color.DarkRed;
                    }
                }
            }

            if (gridStock.Columns[e.ColumnIndex].Index.Equals(9)) // product type
            {
                e.Value = ((ProductCostType)e.Value).Description;
            }

            if (gridStock.Columns[e.ColumnIndex].Index.Equals(10)) // cost
            {
                e.Value = Library.Utils.SharedUtils.FormatMoney(Shared.Utilities.StrToDecimal(e.Value.ToString(), 0.00m), AppController.LocalCurrency);
            }
        }

        private void gridStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void StockIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                gridStock.EndEdit();

                foreach (StockItem NewStockItem in _NewStock)
                {
                    StockItem CurrentStockItem = _CurrentStock.Find(NewStockItem.ID);

                    if (CurrentStockItem != null & NewStockItem.Available > 0)
                        CurrentStockItem.StockAdd(NewStockItem.Available);
                }

                _CurrentStock.Save();
                _NewStock.StockInAudit(_CurrentUser);
            }
            catch (Exception error)
            {
                if (error.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowInformation(LanguageStrings.AppLockConflict, LanguageStrings.AppLockConflictStatement);
                }
                else
                    throw;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            LoadGrid(_NewStock);
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCostType item = (ProductCostType)e.ListItem;
            e.Value = item.Description;
        }

        #endregion Private Methods
    }
}
