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
 *  File: MainStockControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.StockControl;
using Library.BOL.Locations;
using Library.BOL.Products;
using POS.Base.Classes;
using POS.StockControl.Forms;

namespace POS.StockControl.Controls
{
    public partial class MainStockControl : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        Stock _currentstock;

        // colors
        private Color _colorVeryLow;
        private Color _colorVeryLowSelected;
        private Color _colorLow;
        private Color _colorHiddenGloballyBack;
        private Color _colorHiddenGloballyFore;
        private Color _colorHiddenBack;
        private Color _colorHiddenFore;
        private Color _colorOutOfStockBack;
        private Color _colorOutOfStockFore;
        private Color _colorReOrderBack;
        private Color _colorReOrderFore;

        #endregion Private Members

        #region Constructors

        public MainStockControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Public Methods

        public void InvoiceCreated()
        {
            cmbLocation_SelectedIndexChanged(this, EventArgs.Empty);
        }

        public void ProductsUpdated()
        {
            cmbLocation_SelectedIndexChanged(this, EventArgs.Empty);
        }

        public override void Initialise()
        {
            if (!DesignMode)
            {
                LoadProductTypes();

                gridStock.Height = gridStock.Height + 25;
                statusStripStock.Visible = false;

                cmbProductType.Format += cmbProductType_Format;
                cmbProductType.SelectedIndexChanged += new EventHandler(cmbProductType_SelectedIndexChanged);
                LoadLocations();

                if (AppController.LocalSettings.StockMainFormType < cmbProductType.Items.Count)
                    cmbProductType.SelectedIndex = AppController.LocalSettings.StockMainFormType;
                else
                    cmbProductType.SelectedIndex = 0;

                menuContextHideGlobally.Visible = AppController.ActiveUser.HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl.HideStockItemsGlobally);
                menuContextUnhideGlobally.Visible = AppController.ActiveUser.HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl.HideStockItemsGlobally);
                toolStripSeparatorHideGlobal.Visible = AppController.ActiveUser.HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl.HideStockItemsGlobally);

                _colorVeryLow = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorVeryLow);
                _colorVeryLowSelected = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorVeryLowSelected);
                _colorLow = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorLow);
                _colorHiddenGloballyBack = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorHiddenGloballyBack);
                _colorHiddenGloballyFore = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorHiddenGloballyFore);
                _colorHiddenBack = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorHiddenBack);
                _colorHiddenFore = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorHiddenFore);
                _colorOutOfStockBack = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorOutOfStockBack);
                _colorOutOfStockFore = ColorTranslator.FromHtml(AppController.LocalSettings.StockColorOutOfStockFore);


                _colorReOrderBack = Color.DarkSeaGreen;
                _colorReOrderFore = Color.Black;
            }

        }

        public override int GetStatusCount()
        {
            return (statusStripStock.Items.Count);
        }

        public override string GetStatusText(int index)
        {
            return (statusStripStock.Items[index].Text);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStripStock.Items[index].ToolTipText);
        }

        public override void Closing()
        {
            BeforeTabHide();
        }

        public override void BeforeTabHide()
        {
            _currentstock.Save();

            AppController.LocalSettings.StockMainFormLocation = cmbLocation.SelectedIndex;
            AppController.LocalSettings.StockMainFormType = cmbProductType.SelectedIndex;

        }

        #endregion Public Methods

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            if (!DesignMode)
            {
                if (AppController.ActiveUser == null || gridStock.Columns.Count == 0)
                    return;

                this.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                    LanguageStrings.AppStockControl, AppController.ActiveUser.UserName);

                lblFilter.Text = LanguageStrings.AppFilter;
                lblProductType.Text = LanguageStrings.AppProductType;
                lblSelectLocation.Text = LanguageStrings.AppStockSelectLocation;

                cbShowHidden.Text = LanguageStrings.AppStockShowHiddenItems;

                btnAudit.Text = LanguageStrings.AppStockAudit;
                btnStockIn.Text = LanguageStrings.AppStockIn;
                btnCreateStock.Text = LanguageStrings.AppStockCreate;
                btnStockOut.Text = LanguageStrings.AppStockOut;

                //column headers
                gridStock.Columns[0].HeaderText = LanguageStrings.AppStockStoreID;
                gridStock.Columns[1].HeaderText = LanguageStrings.AppStockChanged;
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
                gridStock.Columns[13].HeaderText = LanguageStrings.AppStockAutoRenew;
                gridStock.Columns[14].HeaderText = LanguageStrings.Location;

                menuContextEditProduct.Text = LanguageStrings.AppMenuEditProduct;
                menuContextHide.Text = LanguageStrings.AppMenuHide;
                menuContextHideGlobally.Text = LanguageStrings.AppMenuHideGlobally;
                menuContextHistory.Text = LanguageStrings.AppMenuHistory;
                menuContextInStock.Text = LanguageStrings.AppMenuInStock;
                menuContextOutOfStock.Text = LanguageStrings.AppMenuOutOfStock;
                menuContextUnHide.Text = LanguageStrings.AppMenuUnHide;
                menuContextUnhideGlobally.Text = LanguageStrings.AppMenuUnHideGlobally;
                menuContextUpdateMinimumLevel.Text = LanguageStrings.AppMenuUpdateMinimumLevel;
                menuContextUpdateOrderQuantity.Text = LanguageStrings.AppMenuUpdateOrderQuantity;
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadLocations()
        {
            cmbLocation.Items.Clear();

            foreach (StoreLocation location in Locations.Get())
            {
                cmbLocation.Items.Add(location);
            }

            if (AppController.LocalSettings.StockMainFormLocation > cmbLocation.Items.Count - 1)
                cmbLocation.SelectedIndex = 0;
            else
                cmbLocation.SelectedIndex = AppController.LocalSettings.StockMainFormLocation;
        }

        private void LoadProductTypes()
        {
            cmbProductType.Items.Clear();

            foreach (ProductCostType item in ProductCostTypes.Get())
            {
                switch (item.ItemType)
                {
                    case ProductCostItemType.Product:
                    case ProductCostItemType.Voucher:
                        cmbProductType.Items.Add(item);
                        break;
                }
            }

            cmbProductType.SelectedIndex = 0;
        }

        private void LoadGrid(Stock StockItem)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                bool allowGlobalHide = AppController.ActiveUser.HasPermissionStock(
                    SecurityEnums.SecurityPermissionsStockControl.HideStockItemsGlobally);
                int hidden = 0;
                int total = 0;

                ProductCostType type = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];
                Stock FilteredStock = new Stock();

                foreach (StockItem item in StockItem)
                {
                    if (item.ProductType.ID == type.ID)
                    {
                        if (IsFiltered(item, txtFilter.Text))
                        {
                            bool canShow = (!AppController.LocalSettings.StockItemsHidden.Contains(
                                String.Format(StringConstants.STOCK_HIDDEN_FORMAT, item.ID)));

                            if (canShow && item.HideGlobally)
                            {
                                canShow = allowGlobalHide ? cbShowHidden.Checked && allowGlobalHide : false;//(!item.HideGlobally && allowGlobalHide) || 
                            }

                            if ((cbShowHidden.Checked & !item.HideGlobally) | canShow)
                            {
                                total++;
                                FilteredStock.Add(item);
                            }
                            else
                            {
                                total++;
                                hidden++;
                            }
                        }
                    }
                }

                gridStock.DataSource = FilteredStock;

                if (FilteredStock.Count > 0)
                {
                    gridStock.Columns[0].Visible = false;
                    gridStock.Columns[1].Visible = false;
                    gridStock.Columns[2].Visible = false;
                    gridStock.Columns[4].Width = gridStock.Columns[2].Width * 2;
                    gridStock.Columns[9].Width = 200;
                    gridStock.Columns[11].Visible = false;
                }

                statusLabelTotal.Text = String.Format(LanguageStrings.AppStockTotalItems, total);
                statusLabelHidden.Text = String.Format(LanguageStrings.AppStockHiddenItems, hidden);
                statusLabelFilter.Text = String.IsNullOrEmpty(txtFilter.Text) ? String.Empty : LanguageStrings.AppFiltered;

                gridStock.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private bool IsFiltered(StockItem item, string filter)
        {
            string itm = String.Format(StringConstants.STOCK_SEARCH_FILTER, item.Name.ToLower(), item.SKU.ToLower(), item.Size.ToLower(), item.Available);

            if (itm.Contains(txtFilter.Text.ToLower()))
                return (true);


            return (false);
        }

        private void gridStock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 7: //re-order ammount
                    e.Cancel = false;
                    break;
                case 8: // min stock level
                    e.Cancel = false;
                    break;
                case 13: // auto renew
                    e.Cancel = !btnStockIn.Enabled;
                    break;
                case 14: // location
                    e.Cancel = false;
                    break;
                default: // all others read only
                    e.Cancel = true;
                    break;
            }
        }

        private void gridStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.SelectionBackColor = Color.Navy;
                e.CellStyle.SelectionForeColor = Color.White;

                StockItem item = (StockItem)gridStock.Rows[e.RowIndex].DataBoundItem;

                if (gridStock.Columns[e.ColumnIndex].Index.Equals(6)) //currently in stock   4 < 5
                {
                    if (e.Value != null)
                    {
                        if ((int)e.Value < item.MinLevel)
                        {
                            e.CellStyle.BackColor = _colorVeryLow;
                            e.CellStyle.SelectionBackColor = _colorVeryLowSelected;
                        }
                        else
                        {
                            if ((int)e.Value < (item.MinLevel + AppController.LocalSettings.StockLevelLow))
                            {
                                //e.CellStyle.BackColor = Color.Salmon;
                                e.CellStyle.BackColor = _colorLow;
                            }
                        }
                    }
                }

                if (gridStock.Columns[e.ColumnIndex].Index.Equals(9)) // product type
                {
                    e.Value = ((ProductCostType)e.Value).Description;
                }

                if (item != null && item.HideGlobally && e.ColumnIndex == 4)
                {
                    e.CellStyle.BackColor = _colorHiddenGloballyBack;
                    e.CellStyle.ForeColor = _colorHiddenGloballyFore;
                }
                else
                {
                    if (e.ColumnIndex == 4)
                    {
                        if (item != null && AppController.LocalSettings.StockItemsHidden.Contains(
                            String.Format(StringConstants.STOCK_HIDDEN_FORMAT, item.ID)))
                        {
                            e.CellStyle.BackColor = _colorHiddenBack;
                            e.CellStyle.ForeColor = _colorHiddenFore;
                        }
                    }
                }


                if (item != null && item.AutoRestock)
                {
                    if (e.ColumnIndex < 5 | e.ColumnIndex > 12)
                    {
                        e.CellStyle.BackColor = _colorReOrderBack;
                        e.CellStyle.ForeColor = _colorReOrderFore;
                    }
                    else if (item.OutOfStock)
                    {
                        e.CellStyle.BackColor = _colorOutOfStockBack;
                        e.CellStyle.ForeColor = _colorOutOfStockFore;
                    }
                }
                else
                {
                    // out of stock
                    if (item != null && item.OutOfStock)
                    {
                        e.CellStyle.BackColor = _colorOutOfStockBack;
                        e.CellStyle.ForeColor = _colorOutOfStockFore;
                    }
                }

                if (gridStock.Columns[e.ColumnIndex].Index.Equals(10)) // cost
                {
                    e.Value = Library.Utils.SharedUtils.FormatMoney(Shared.Utilities.StrToDecimal(e.Value.ToString(), 0.00m, null),
                        AppController.LocalCurrency);
                }
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
        }

        private void gridStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;
        }

        private void gridStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RefreshGrid();
        }

        private void gridStock_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];

                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
            }
        }

        private void gridStock_Scroll(object sender, ScrollEventArgs e)
        {
            RefreshGrid();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            Forms.StockIn stockIn = new Forms.StockIn(ref _currentstock, AppController.ActiveUser);
            try
            {
                stockIn.ShowDialog();
            }
            finally
            {
                stockIn.Dispose();
                stockIn = null;
            }

            gridStock.Refresh();
            PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            POS.StockControl.Forms.StockOut form = new POS.StockControl.Forms.StockOut(ref _currentstock, AppController.ActiveUser);
            try
            {
                form.ShowDialog();
                gridStock.Refresh();
            }
            finally
            {
                form.Dispose();
                form = null;
            }

            PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            StockAudit form = new StockAudit(ref _currentstock);
            try
            {
                form.ShowDialog();
                gridStock.Refresh();
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((StoreLocation)e.ListItem).StoreName;
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Retrieve Data for the location
                int Store = ((StoreLocation)cmbLocation.SelectedItem).ID;
                bool allowMove = AppController.ActiveUser.HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl.MoveStockInAndOut);

                btnAudit.Enabled = Store == WebsiteAdministration.StoreID & allowMove;
                btnStockIn.Enabled = Store == WebsiteAdministration.StoreID & allowMove;
                btnStockOut.Enabled = Store == WebsiteAdministration.StoreID & allowMove;
                btnCreateStock.Enabled = Store == WebsiteAdministration.StoreID & allowMove;

                if (_currentstock != null)
                    _currentstock.Save();

                _currentstock = Stock.Get(AppController.ActiveUser, Store);
                LoadGrid(_currentstock);
                gridStock.Focus();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid(_currentstock);
            gridStock.Focus();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            LoadGrid(_currentstock);
        }

        private void btnCreateStock_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                CreateStockForm frm = new CreateStockForm(ref _currentstock);
                try
                {
                    frm.ShowDialog(this);

                    int Store = ((StoreLocation)cmbLocation.SelectedItem).ID;

                    _currentstock = Stock.Get(AppController.ActiveUser, Store);
                    LoadGrid(_currentstock);
                    gridStock.Focus();
                    gridStock.Refresh();
                }
                finally
                {
                    frm.Dispose();
                    frm = null;
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((ProductCostType)e.ListItem).Description;
        }

        private void MainScreenStockControl_Shown(object sender, EventArgs e)
        {
            StoreLocation currentLocation = (StoreLocation)cmbLocation.Items[cmbLocation.SelectedIndex];

            if (currentLocation.ID != Library.DAL.DALHelper.StoreID)
            {
                StoreLocation ownLocation = Locations.Get(Library.DAL.DALHelper.StoreID);

                if (ShowHardConfirm(LanguageStrings.AppStockLocation,
                    String.Format(LanguageStrings.AppStockViewWrongLocation, currentLocation.StoreName,
                    ownLocation.StoreName)))
                {
                    for (int i = 0; i < cmbLocation.Items.Count; i++)
                    {
                        StoreLocation location = (StoreLocation)cmbLocation.Items[i];

                        if (location.ID == Library.DAL.DALHelper.StoreID)
                        {
                            cmbLocation.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }

            RefreshGrid();
        }

        /// <summary>
        /// Show history for a stock item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                StoreLocation currentLocation = (StoreLocation)cmbLocation.Items[cmbLocation.SelectedIndex];
                StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;

                StockHistory history = StockHistory.Get(item, currentLocation, true, true);
                StockHistory historyTotals = StockHistory.Get(item);

                StockHistoryForm.Show(item, history, historyTotals);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerProducts))
            {
                StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;
                ProductCost prodCost = ProductCosts.Get(item.ID, MemberLevel.Admin);

                if (prodCost == null)
                {
                    ShowError(LanguageStrings.AppProductEdit, LanguageStrings.AppProductEditNotFound);
                }
                else
                {
                    POS.Base.Classes.PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                        StringConstants.PLUGIN_EVENT_EDIT_PRODUCT_ITEM, prodCost.Product));
                }
            }
            else
                ShowError(LanguageStrings.AppProductView, LanguageStrings.AppPermissionProducts);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;
            AppController.LocalSettings.StockItemsHidden += String.Format(StringConstants.STOCK_UNHIDE_FORMAT, item.ID);
            LoadGrid(_currentstock);
        }

        private void cbShowHidden_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid(_currentstock);
        }

        private void toolStripMenuItemUnHide_Click(object sender, EventArgs e)
        {
            StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;
            AppController.LocalSettings.StockItemsHidden = AppController.LocalSettings.StockItemsHidden.Replace(
                String.Format(StringConstants.STOCK_UNHIDE_FORMAT, item.ID), StringConstants.SYMBOL_SEMI_COLON);
            LoadGrid(_currentstock);
        }

        private void contextMenuStripStock_Opening(object sender, CancelEventArgs e)
        {
            StockItem item = null;

            if (gridStock.CurrentCell != null)
                item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;

            menuContextUnHide.Enabled = AppController.LocalSettings.StockItemsHidden.Contains(
                String.Format(StringConstants.STOCK_HIDDEN_FORMAT, item.ID));
            menuContextHide.Enabled = !menuContextUnHide.Enabled;

            if (item == null)
            {
                menuContextUnhideGlobally.Enabled = false;
                menuContextHideGlobally.Enabled = false;
                menuContextOutOfStock.Enabled = false;
                menuContextInStock.Enabled = false;
            }
            else
            {
                menuContextHideGlobally.Enabled = !item.HideGlobally;
                menuContextUnhideGlobally.Enabled = item.HideGlobally;
                menuContextInStock.Enabled = (item.StoreID == Library.DAL.DALHelper.StoreID) && item.OutOfStock;
                menuContextOutOfStock.Enabled = (item.StoreID == Library.DAL.DALHelper.StoreID) && !item.OutOfStock;
            }
        }

        private void toolStripMenuItemHideGlobally_Click(object sender, EventArgs e)
        {
            StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;
            item.HideGlobally = true;
        }

        private void toolStripMenuItemUnhideGlobally_Click(object sender, EventArgs e)
        {
            StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;
            item.HideGlobally = false;
        }

        private void changeToOutOfStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl.UpdateStockInOutStatus))
            {
                StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;
                item.OutOfStock = true;
                ProductCost costItem = ProductCosts.Get(item.ID, MemberLevel.Admin);

                if (costItem == null)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppStockChangeOutOfStockFailed);
                }
                else
                {
                    costItem.OutOfStock = true;
                    costItem.Save();
                    RefreshGrid();
                }
            }
            else
                ShowError(LanguageStrings.AppError, LanguageStrings.AppStockNoPermissionInOut);
        }

        private void changeToInStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl.UpdateStockInOutStatus))
            {
                StockItem item = (StockItem)gridStock.Rows[gridStock.CurrentCell.RowIndex].DataBoundItem;
                item.OutOfStock = false;
                ProductCost costItem = ProductCosts.Get(item.ID, MemberLevel.Admin);

                if (costItem == null)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppStockChangeInStockFailed);
                }
                else
                {
                    costItem.OutOfStock = false;
                    costItem.Save();
                    RefreshGrid();
                }
            }
            else
                ShowError(LanguageStrings.AppError, LanguageStrings.AppStockNoPermissionInOut);
        }

        private void menuContextUpdateOrderQuantity_Click(object sender, EventArgs e)
        {
            int orderQuantity = 10;
            bool update = SharedControls.Forms.EnterNumberForm.ShowEnterNumber(null,
                LanguageStrings.AppStockEnterOrderQuantity,
                LanguageStrings.AppStockEnterOrderQuantityPrompt, ref orderQuantity);

            if (update)
            {
                foreach (DataGridViewRow item in gridStock.Rows)
                {
                    StockItem stockItem = (StockItem)item.DataBoundItem;
                    stockItem.OrderQuantity = orderQuantity;
                }

                RefreshGrid();
            }
        }

        private void menuContextUpdateMinimumLevel_Click(object sender, EventArgs e)
        {
            int minimumLevel = 10;
            bool update = SharedControls.Forms.EnterNumberForm.ShowEnterNumber(null,
                LanguageStrings.AppStockEnterMinimumLevel,
                LanguageStrings.AppStockEnterMinimumLevelPrompt, ref minimumLevel);

            if (update)
            {
                foreach (DataGridViewRow item in gridStock.Rows)
                {
                    StockItem stockItem = (StockItem)item.DataBoundItem;
                    stockItem.MinLevel = minimumLevel;
                }

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            gridStock.Invalidate();
        }

        #endregion Private Methods
    }
}
