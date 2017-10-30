using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using POS.StockControl.Classes;
using POS.StockControl.Controls;

using Library;
using Library.BOL.Products;
using Library.BOL.StockControl;
using POS.Base.Classes;

namespace POS.StockControl.Forms
{
    public partial class CreateStockForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Products _products;
        private Stock _currentStock;
        private bool _allStockAvailable = false;

        #endregion Private Members

        #region Constructors

        public CreateStockForm(ref Stock currentStock)
        {
            InitializeComponent();

            _currentStock = currentStock;

            _products = AppController.Administration.ProductsGet();

            foreach (Product prod in _products)
                prod.UpdateProductCostInfo(AppController.ActiveUser);

            LoadProductTypes();
            PopulateProducts();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StockCreate;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStockCreate;

            btnCreateStock.Text = LanguageStrings.AppStockCreate;

            lblAllProducts.Text = LanguageStrings.AppStockAllProducts;
            lblItemsUsed.Text = LanguageStrings.AppStockItemsUsed;
            lblMainProductType.Text = LanguageStrings.AppStockMainProductType;
            lblNoOfUnits.Text = LanguageStrings.AppStockNoOfUnits;
            lblProductType.Text = LanguageStrings.AppStockProductType;
            lblStockBeingCreated.Text = LanguageStrings.AppStockStockBeingCreated;
        }

        #endregion Ovdrridden Methods

        #region Private Methods

        private void LoadProductTypes()
        {
            ProductCostTypes types = ProductCostTypes.Get();

            cmbProductTypes.Items.Clear();
            cmbMainProductType.Items.Clear();

            foreach (ProductCostType type in types)
            {
                cmbProductTypes.Items.Add(type);
                cmbMainProductType.Items.Add(type);
            }

            cmbMainProductType.SelectedIndex = 0;
            cmbProductTypes.SelectedIndex = 0;
        }

        private void PopulateProducts()
        {
            lstStockBeingCreated.Items.Clear();
            ProductCostType selProdType = (ProductCostType)cmbMainProductType.Items[cmbMainProductType.SelectedIndex];

            foreach (Product prod in _products)
            {
                foreach (ProductCost cost in prod.ProductCosts)
                {
                    if (cost.ProductCostType.ID == selProdType.ID)
                    {
                        lstStockBeingCreated.Items.Add(cost);
                    }
                }
            }
        }

        private void lstStockBeingCreated_SelectedIndexChanged(object sender, EventArgs e)
        {
            layoutDependencies.Controls.Clear();

            if (lstStockBeingCreated.SelectedIndex == -1)
                return;

            int maxAvailable = 1000000;

            ProductCost cost = (ProductCost)lstStockBeingCreated.SelectedItem;

            foreach (CreateStockItem item in cost.StockCreationItems)
            {
                foreach (Product product in _products)
                {
                    foreach (ProductCost prodCost in product.ProductCosts)
                    {
                        if (prodCost.ID == item.SubProductCost)
                        {
                            int stockAvailable = GetStockQuantity(prodCost);
                            CreateStockItemControl ctl = new CreateStockItemControl();

                            if (!ctl.Reset(cost, prodCost, item.Quantity, stockAvailable))
                            {
                                _allStockAvailable = false;
                            }

                            ctl.DeleteItem += ctl_DeleteItem;
                            layoutDependencies.Controls.Add(ctl);
                            ctl.Width = layoutDependencies.Width - 20;

                            if (stockAvailable < maxAvailable)
                                maxAvailable = Library.Utils.SharedUtils.MinimumValue(0, stockAvailable);
                        }
                    }
                }
            }

            spinNumberCreated.Maximum = Convert.ToDecimal(Library.Utils.SharedUtils.MinimumValue(0, maxAvailable));

            btnCreateStock.Enabled = spinNumberCreated.Maximum > 0;
        }

        /// <summary>
        /// Returns the number available in stock for the item
        /// </summary>
        /// <param name="costItem"></param>
        /// <returns></returns>
        private int GetStockQuantity(ProductCost costItem)
        {
            int Result = 0;

            foreach (StockItem item in _currentStock)
            {
                if (item.ID == costItem.ID)
                {
                    Result = item.Available;
                    break;
                }
            }

            return (Result);
        }

        private void ctl_DeleteItem(object sender, EventArgs e)
        {
            layoutDependencies.Controls.Remove((CreateStockItemControl)sender);
        }

        private void lstStockBeingCreated_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCost cost = (ProductCost)e.ListItem;

            e.Value = String.Format(StringConstants.STOCK_ITEM_WITH_SKU, 
                cost.SKU, cost.Product.Name, cost.Size);
        }

        private void cmbProductTypes_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((ProductCostType)e.ListItem).Description;
        }

        private void cmbProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load all products for type
            lstAvailableProducts.Items.Clear();
            ProductCostType selProdType = (ProductCostType)cmbProductTypes.Items[cmbProductTypes.SelectedIndex];

            foreach (Product prod in _products)
            {
                foreach (ProductCost cost in prod.ProductCosts)
                {
                    if (!cost.OutOfStock && !cost.HideGlobally && cost.ProductCostType.ID == selProdType.ID)
                    {
                        lstAvailableProducts.Items.Add(cost);
                    }
                }
            }
        }

        private void cmbMainProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load all products for type
            _allStockAvailable = true;
            lstStockBeingCreated.Items.Clear();
            ProductCostType selProdType = (ProductCostType)cmbMainProductType.Items[cmbMainProductType.SelectedIndex];

            foreach (Product prod in _products)
            {
                foreach (ProductCost cost in prod.ProductCosts)
                {
                    if (!cost.HideGlobally && cost.ProductCostType.ID == selProdType.ID)
                    {
                        lstStockBeingCreated.Items.Add(cost);
                    }
                }
            }
        }

        private void lstAvailableProducts_DoubleClick(object sender, EventArgs e)
        {
            if (lstStockBeingCreated.SelectedIndex == -1)
                return;

            ProductCost sub = (ProductCost)lstAvailableProducts.SelectedItem;
            ProductCost primary = (ProductCost)lstStockBeingCreated.SelectedItem;

            if (sub.ID == primary.ID)
            {
                ShowError(LanguageStrings.AppStockCreate, LanguageStrings.AppStockItemPrimaryIsSub);
                return;
            }

            CreateStockItem newitem = primary.StockCreationItems.Add(primary, sub, 1);

            if (newitem != null)
            {
                CreateStockItemControl ctl = new CreateStockItemControl();
                int stockAvailable = GetStockQuantity(sub);

                if (!ctl.Reset(primary, sub, 1, stockAvailable))
                {
                    _allStockAvailable = false;
                }

                ctl.DeleteItem += ctl_DeleteItem;
                layoutDependencies.Controls.Add(ctl);
                ctl.Width = layoutDependencies.Width - 20;
            }
        }

        private void btnCreateStock_Click(object sender, EventArgs e)
        {
            if (lstStockBeingCreated.SelectedIndex == -1)
                return;

            if (!_allStockAvailable)
            {
                ShowError(LanguageStrings.AppStockCreate, LanguageStrings.AppStockCreateErrorLowStock);
                return;
            }

            ProductCost cost = (ProductCost)lstStockBeingCreated.SelectedItem;

            string stockAdd = LanguageStrings.AppStockItemsToBeIncluded +
                StringConstants.SYMBOL_CRLF + StringConstants.SYMBOL_CRLF;

            stockAdd += String.Format(StringConstants.STOCK_ITEM_REMOVED, 
                (int)spinNumberCreated.Value, cost.Product.Name, cost.Size);

            List<StockRemoveItem> removeItems = new List<StockRemoveItem>();

            foreach (CreateStockItem item in cost.StockCreationItems)
            {
                foreach (Product product in _products)
                {
                    foreach (ProductCost prodCost in product.ProductCosts)
                    {
                        if (prodCost.ID == item.SubProductCost)
                        {
                            removeItems.Add(new StockRemoveItem(product.Name, prodCost.Size, 
                                item.Quantity * (double)spinNumberCreated.Value));
                        }
                    }
                }
            } // last foreach

            if (StockCreateConfirm.ConfirmStockCreate(stockAdd, removeItems))
            {
                StockItem primary = _currentStock.Find(cost.ID);
                try
                {
                    Stock.CreateStock(primary, AppController.ActiveUser, (int)spinNumberCreated.Value);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_STOCK_CREATE_NOT_FOUND))
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppStockCreateError);
                    else
                        throw;
                }
            }

            lstStockBeingCreated.SelectedIndex = -1;
        }

        #endregion Private Methods

        private void layoutDependencies_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in layoutDependencies.Controls)
            {
                ctl.Width = layoutDependencies.Width - 20;
            }
        }
    }
}
