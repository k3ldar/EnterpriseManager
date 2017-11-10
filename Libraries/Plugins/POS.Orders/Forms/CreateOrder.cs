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
 *  File: CreateOrder.cs
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

using SieraDelta.Reports;

using SieraDelta.Languages;

using SieraDelta.Library;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Accounts;
using SieraDelta.Library.BOL.Appointments;
using SieraDelta.Library.BOL.Users;
using SieraDelta.Library.BOL.Treatments;
using SieraDelta.Library.BOL.Products;
using SieraDelta.Library.BOL.Basket;
using SieraDelta.Library.BOL.Countries;
using SieraDelta.Library.BOL.Orders;
using SieraDelta.Library.BOL.Invoices;
using SieraDelta.Library.BOL.StockControl;

using SieraDelta.POS.Classes;
using SieraDelta.POS.Controls;

using SieraDelta.Controls.Forms;

using SieraDelta.Controls.Classes;

namespace SieraDelta.POS.Orders.Forms
{
    public partial class CreateOrder : BaseForm
    {
        #region Private Members

        private User _User = null;
        private User _StaffMember = null;
        private Users _StaffMembers = null;
        private ShoppingBasket _Basket = null;
        private Order _Order = null;
        private Products _Products = null;

        private List<BasketProductButton> _productButtons;

        #endregion Private Members

        #region Constructors

        public CreateOrder(User staffMember, User user, Int64 basketID = 0)
        {
            InitializeComponent();
                        
            WaitInputDialog.ShowWaitScreen();
            try
            {
                WaitInputDialog.UpdateWaitScreen(LanguageStrings.AppProductsLoading);

                _productButtons = new List<BasketProductButton>();

                _StaffMember = staffMember;
                _User = user;
                _StaffMembers = User.StaffMembers();

                if (_User.AutoDiscount > 0)
                {
                    btnApplyDiscount.Enabled = false;
                }

                //create new basket
                if (basketID == 0)
                {
                    _Basket = new ShoppingBasket(AppController.LocalCountry, AppController.LocalCurrency);
                }
                else
                {
                    _Basket = new ShoppingBasket(basketID, AppController.LocalCountry, AppController.LocalCurrency);

                    BuildBasket(false);
                }

                _Basket.IgnoreBasketQuantityRestrictions = true;
                _Basket.IgnoreCostMultiplier = true;
                _Basket.User = user;
                _Basket.RemoveVATFromPostage = AppController.LocalSettings.RemoveVATFromPostage;

                this.Text += String.Format(StringConstants.CREATE_ORDER_TITLE, user.UserName, user.Email);

                LoadProductTypes();
                cmbProductType.SelectedIndexChanged += new EventHandler(cmbProductType_SelectedIndexChanged);
                BuildProductList();
                BuildProducts();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                SieraDelta.Shared.EventLog.Add(err);
            }
            finally
            {
                WaitInputDialog.HideWaitScreen();
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the cost multiplier for the user
        /// </summary>
        public decimal GetMultiplier
        {
            get
            {
                if (_Basket.IgnoreCostMultiplier)
                    return (0.00m);

                return (AppController.LocalCurrency.Multiplier);
            }
        }

        #endregion

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnClearBasket.Text = LanguageStrings.AppBasketClear;
            btnCreateOrder.Text = LanguageStrings.AppOrderCreate;
            btnApplyDiscount.Text = LanguageStrings.AppMenuButtonApplyDiscount;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            grpProducts.Text = LanguageStrings.AppProducts;
            lblCurrentSale.Text = LanguageStrings.AppCurrentSale;
            lblDiscountDesc.Text = LanguageStrings.AppDiscount;
            lblFilter.Text = LanguageStrings.AppFilter;
            lblProductType.Text = LanguageStrings.AppProductType;
            lblSubtotalDesc.Text = LanguageStrings.AppSubTotal;
            lblPostageDesc.Text = LanguageStrings.AppPostageAndPackaging;
            lblTotalDesc.Text = LanguageStrings.AppTotal;
        }


        protected override void LoadSettings()
        {
            flowLayoutButtons.Visible = AppController.LocalSettings.TillShowButtons;
            lstProducts.Visible = !AppController.LocalSettings.TillShowButtons;
        }

        #endregion Overridden Methods

        #region Private Methods

        private ShoppingBasketItem FindBasketItem(BasketItem basketItem)
        {
            ShoppingBasketItem Result = null;

            foreach (ShoppingBasketItem basket in pnlBasket.Controls)
            {
                if (basket.Item.ItemID == basketItem.ItemID)
                {
                    Result = basket;
                    Result.UpdateQuantity(basketItem.Quantity);
                    break;
                }
            }

            if (Result == null)
            {
                Result = new ShoppingBasketItem(_StaffMembers, AppController.ActiveUser);
                Result.IgnoreCostMultiplier = _Basket.IgnoreCostMultiplier;

                Result.Item = basketItem;
                Result.Basket = _Basket;
                Result.Updated += new EventHandler(itm_Updated);
                Result.Deleted += new EventHandler(itm_Deleted);
                pnlBasket.Controls.Add(Result);
            }

            ResizeBasketItems();

            return (Result);
        }

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildProducts();
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

        private void BuildBasket(bool TotalsOnly)
        {
            if (_Basket == null)
                return;

            if (!TotalsOnly)
            {
                pnlBasket.Controls.Clear();

                foreach (BasketItem item in _Basket.Items)
                {
                    ShoppingBasketItem itm = new ShoppingBasketItem(_StaffMembers, _User);

                    itm.IgnoreCostMultiplier = _Basket.IgnoreCostMultiplier;

                    itm.Item = item;
                    itm.Basket = _Basket;
                    itm.Updated += new EventHandler(itm_Updated);
                    itm.Deleted += new EventHandler(itm_Deleted);
                    pnlBasket.Controls.Add(itm);
                    ResizeBasketItems();
                }
            }

            _Basket.Reset();
            lblPostageTotal.Text = _Basket.ShippingCost;
            lblSubtotalValue.Text = _Basket.SubTotalMinusVATCost;
            lblVATTotal.Text = _Basket.VATCost;
            lblTotalTotal.Text = _Basket.TotalCost;
            lblVATDesc.Text = String.Format(LanguageStrings.AppTaxPercentage, _Basket.VATRate);
            lblDiscountTotal.Text = _Basket.DiscountCost;

            ResizeBasketItems();

            if (String.IsNullOrEmpty(_Basket.DiscountCouponName))
                lblDiscountDesc.Text = LanguageStrings.AppDiscount;
            else
                lblDiscountDesc.Text = String.Format(StringConstants.DISCOUNT, 
                    _Basket.DiscountCouponName, _Basket.Discount, 
                    _Basket.VoucherType == Enums.InvoiceVoucherType.Percent ? 
                    StringConstants.SYMBOL_PERCENT : String.Empty);
        }

        private void itm_Deleted(object sender, EventArgs e)
        {
            ShoppingBasketItem itemToDelete = (ShoppingBasketItem)sender;
            pnlBasket.Controls.Remove(itemToDelete);
            ResizeBasketItems();
            BuildBasket(true);
        }

        private void ResetUser()
        {
            //if the user is a newly created user, check to see if its replicated and the id has changed
            if (_User.ID < 0)
            {
                _User = User.UserGet(_User.Email);
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShowQuestion(LanguageStrings.AppOrderPaid, LanguageStrings.AppOrderPaidQuestion))
                {
                    try
                    {
                        _Order = _Basket.ConvertToOrder(PaymentStatuses.Get(
                            StringConstants.PAYMENT_OFFICE_NOT_PAID),
                            _User.Email, StringConstants.PAYMENT_OFFICE,
                            AppController.LocalSettings.CustomCulture);

                    }
                    catch (Exception err)
                    {
                        //second chance
                        if (err.Message.Contains(StringConstants.ERROR_VIOLATION_FOREIGN_KEY))
                        {
                            ResetUser();
                            _Basket.User = _User;
                            _Order = _Basket.ConvertToOrder(
                                PaymentStatuses.Get(StringConstants.PAYMENT_OFFICE_PAID), 
                                _User.Email, StringConstants.PAYMENT_OFFICE,
                                AppController.LocalSettings.CustomCulture);
                        }
                        else
                            throw;
                    }

                    _Order.Paid(_User, PaymentStatuses.Get(StringConstants.PAYMENT_OFFICE_PAID), String.Empty);

                    Invoice inv = Invoices.Get(_Order);
                    inv.SetProcessStatus(_User, ProcessStatus.OrderReceived);

                    btnClearBasket_Click(sender, e);
                    _Basket.User = _User;
                }
                else
                {
                    try
                    {
                        _Order = _Basket.ConvertToOrder(PaymentStatuses.Get(
                            StringConstants.PAYMENT_OFFICE_PAID), _User.Email, 
                            StringConstants.PAYMENT_OFFICE, 
                            AppController.LocalSettings.CustomCulture);

                    }
                    catch (Exception err)
                    {
                        //second chance
                        if (err.Message.Contains(StringConstants.ERROR_VIOLATION_FOREIGN_KEY))
                        {
                            ResetUser();
                            _Basket.User = _User;
                            _Order = _Basket.ConvertToOrder(PaymentStatuses.Get(
                                StringConstants.PAYMENT_OFFICE_PAID), 
                                _User.Email, StringConstants.PAYMENT_OFFICE, 
                                AppController.LocalSettings.CustomCulture);
                        }
                        else
                            throw;
                    }

                }

                Close();
            }
            catch (Exception error)
            {
                if (error.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowInformation(LanguageStrings.AppLockConflict, LanguageStrings.AppErrorLockConflictDesc);
                }
                else if (error.Message.Contains(StringConstants.ERROR_USER_FOREIGN_VIOLATION))
                {
                    ShowError(LanguageStrings.AppErrorFindUser, LanguageStrings.AppErrorOrderSaveUser);
                }
                else
                    throw;
            }

        }

        private void itm_Updated(object sender, EventArgs e)
        {
            BuildBasket(true);
        }

        /// <summary>
        /// Finds an item in the shopping bag, if one exists
        /// </summary>
        /// <param name="basketItem">Shopping basket Item to Find</param>
        /// <returns>ShoppingBasketItem if exists, otherwise null</returns>
        //private ShoppingBasketItem FindShoppingBasketItem(BasketItem basketItem)
        //{
        //    ShoppingBasketItem Result = null;

        //    foreach(ShoppingBasketItem item in pnlBasket.Controls)
        //    {
        //        if (item.Item.ItemID == basketItem.ItemID)
        //        {
        //            Result = item;
        //            break;
        //        }
        //    }

        //    return (Result);
        //}

        private void lstProducts_DoubleClick(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selected = new ListBox.SelectedObjectCollection(lstProducts);

            foreach (Object obj in selected)
            {
                ProductCost costitem = (ProductCost)obj;

                BasketItem item = _Basket.Add(costitem, 1, _StaffMember, AppController.LocalCountry.PriceColumn);

                ShoppingBasketItem itm = FindBasketItem(item);
                    
                //if (itm == null)
                //    itm = new ShoppingBasketItem(_StaffMembers, _User);

                //itm.IgnoreCostMultiplier = _Basket.IgnoreCostMultiplier;

                //if (_Basket.Items.Count > 5)
                //    itm.Width = pnlBasket.Width - 30;
                //else
                //    itm.Width = pnlBasket.Width - 10;

                //itm.Item = item;
                //itm.Basket = _Basket;
                //itm.Updated += new EventHandler(itm_Updated);
                //itm.Deleted += new EventHandler(itm_Deleted);
                //pnlBasket.Controls.Add(itm);
            }

            BuildBasket(true);
        }

        private void BuildProductList()
        {
            lstProducts.BeginUpdate();
            try
            {
                flowLayoutButtons.SuspendDrawing();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    flowLayoutButtons.Controls.Clear();
                    lstProducts.Items.Clear();

                    _Products = AppController.Administration.ProductsGet();

                    ProductCostType type = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];

                    int I = 1;

                    foreach (Product product in _Products)
                    {
                        WaitInputDialog.UpdateWaitScreen(String.Format(LanguageStrings.AppProductLoadingName, product.Name), I);

                        product.UpdateProductCostInfo(_StaffMember);

                        foreach (ProductCost cost in product.ProductCosts)
                        {
                            BasketProductButton button = new BasketProductButton();
                            button.Product = cost;
                            button.AddProductToBasket += button_AddProductToBasket;
                            _productButtons.Add(button);

                            if (cost.ProductCostType == type)
                                lstProducts.Items.Add(cost);
                        }

                        I++;
                    }
                }
                finally
                {
                    flowLayoutButtons.ResumeDrawing();
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                lstProducts.EndUpdate();
            }
        }

        private void button_AddProductToBasket(object sender, EventArgs e)
        {
            BasketProductButton button = (BasketProductButton)sender;

            BasketItem newBasketItem = _Basket.Add(button.Product, 1, AppController.ActiveUser, AppController.LocalCountry.PriceColumn);

            FindBasketItem(newBasketItem);

            BuildBasket(true);
            flowLayoutButtons.Focus();
        }

        /// <summary>
        /// Determines wether the item is shown
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        private bool CanShowItem(Product product, ProductCost cost, ProductCostType type)
        {
            bool Result = false;

            if (cost.ProductCostType.ID == type.ID)
            {
                if (product.Name.ToLower().Contains(txtFilter.Text.ToLower()) ||
                    cost.Size.ToLower().Contains(txtFilter.Text.ToLower()))
                {
                    Result = true;
                }
            }

            if (Result && AppController.LocalSettings.HideOutOfStockProducts &&
                (product.OutOfStock || cost.OutOfStock))
            {
                Result = false;
            }

            if (Result && AppController.LocalSettings.HideProductsWithZeroStock &&
                (cost.GetStockLevel(SieraDelta.Library.DAL.DALHelper.StoreID) < 1))
            {
                Result = false;
            }

            return (Result);
        }

        private void ShowBasketButton(ProductCost cost)
        {
            foreach (BasketProductButton button in _productButtons)
            {
                if (button.Product.ID == cost.ID)
                {
                    flowLayoutButtons.Controls.Add(button);
                    break;
                }
            }
        }

        private void BuildProducts()
        {
            lstProducts.BeginUpdate();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                flowLayoutButtons.SuspendDrawing();
                try
                {
                    flowLayoutButtons.Controls.Clear();
                    lstProducts.Items.Clear();
                    ProductCostType type = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];

                    foreach (Product product in _Products)
                    {
                        foreach (ProductCost cost in product.ProductCosts)
                        {
                            if (CanShowItem(product, cost, type))
                            {
                                lstProducts.Items.Add(cost);
                                ShowBasketButton(cost);
                            }
                        }
                    }
                }
                finally
                {
                    flowLayoutButtons.ResumeDrawing();
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                lstProducts.EndUpdate();
            }
        }

        private void lstProducts_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCost cost = (ProductCost)e.ListItem;

            e.Value = String.Format(StringConstants.PRODUCT_COST_SIZE_TYPE,
                cost.ProductCostType.Description, cost.Product.Name, cost.Size);
        }

        private void btnClearBasket_Click(object sender, EventArgs e)
        {
            _Basket.Empty();
            BuildBasket(false);
        }

        private void CreateInvoice_Resize(object sender, EventArgs e)
        {
            ResizeBasketItems();
        }

        private void ResizeBasketItems()
        {
            foreach (ShoppingBasketItem basket in pnlBasket.Controls)
            {
                if (pnlBasket.VerticalScroll.Visible)
                    basket.Width = pnlBasket.Width - 30;
                else
                    basket.Width = pnlBasket.Width - 10;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            BuildProducts();
        }

        private void cmbProductType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lstProducts.Focus();
        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new SieraDelta.POS.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_SHOW_TILL_DISCOUNT, _Basket));

            BuildBasket(true);
        }

        private void btnPostage_Click(object sender, EventArgs e)
        {
            InputBoxResult Result = InputBox.Show(LanguageStrings.AppShippingCostsEnter,
                LanguageStrings.AppShippingCosts);

            if (Result.ReturnCode == DialogResult.OK)
            {
                try
                {
                    _Basket.ShippingAmount = Convert.ToDecimal(Result.Text);
                }
                catch (Exception err)
                {
                    ShowErrorMessage(LanguageStrings.AppShippingCosts,
                        String.Format(LanguageStrings.AppErrorShippingAmount,
                        Result.Text, err.Message));
                }
            }

            BuildBasket(true);
        }

        private void btnVATRate_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new SieraDelta.POS.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_SHOW_CUSTOM_VAT_RATE, _Basket));
            BuildBasket(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Basket.SaveBasket(String.Format(LanguageStrings.AppOrderSaveAs, 
                _Basket.User.UserName, AppController.ActiveUser.UserName, 
                DateTime.Now.ToString(StringConstants.SYMBOL_DATE_FORMAT_G)));
        }

        private void CreateOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Basket != null && _Basket.HasItems())
            {
                if (ShowQuestion(LanguageStrings.AppOrderSave, LanguageStrings.AppOrderSavePrompt))
                {
                    btnSave_Click(sender, e);
                }
            }
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCostType item = (ProductCostType)e.ListItem;
            e.Value = item.Description;
        }

        #endregion Private Methods
    }
}
