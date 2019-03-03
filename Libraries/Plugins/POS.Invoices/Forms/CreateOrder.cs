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
 *  File: CreateOrder.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using SharedControls.Classes;

using Languages;
using SharedBase;
using SharedBase.Utils;
using SharedBase.BOL.Accounts;
using SharedBase.BOL.Users;
using SharedBase.BOL.Products;
using SharedBase.BOL.Basket;
using SharedBase.BOL.Orders;
using SharedBase.BOL.Invoices;

using POS.Base.Forms;
using POS.Base.Classes;
using POS.Base.Controls;

using SharedControls.Forms;
using Shared;
using System.Globalization;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Forms
{
    public partial class CreateOrder : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private bool _isDirty;
        private User _user = null;
        private User _staffMember = null;
        private Users _staffMembers = null;
        private ShoppingBasket _basket = null;
        private Order _order = null;
        private Products _products = null;
        private bool _postageReminder = false;

        private List<BasketProductButton> _productButtons;

        #endregion Private Members

        #region Constructors

        public CreateOrder()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            RequiresSave = false;

            _productButtons = new List<BasketProductButton>();
            _staffMembers = User.StaffMembers(false);

            LoadProductTypes();
            cmbProductType.SelectedIndexChanged += new EventHandler(cmbProductType_SelectedIndexChanged);
            BuildProductList();
            BuildProducts();

            IsDirty = false;
        }

        public CreateOrder(User staffMember, User user, Int64 basketID = 0)
            : this()
        {
            LoadData(staffMember, basketID, user);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the cost multiplier for the user
        /// </summary>
        private decimal GetMultiplier
        {
            get
            {
                if (_basket.IgnoreCostMultiplier)
                    return (1.00m);

                return (AppController.LocalCurrency.Multiplier);
            }
        }

        /// <summary>
        /// True if dirty and needs saving, otherwise false
        /// </summary>
        private bool IsDirty
        {
            get
            {
                return (_isDirty);
            }

            set
            {
                _isDirty = value;
                UpdateUI();
            }
        }

        private bool RequiresSave { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            btnClearBasket.Text = LanguageStrings.AppBasketClear;
            btnCreateOrder.Text = LanguageStrings.AppOrderCreate;
            btnApplyDiscount.Text = LanguageStrings.AppMenuButtonApplyDiscount;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            btnNew.Text = LanguageStrings.AppMenuButtonNew;
            btnPostage.Text = LanguageStrings.AppMenuButtonPostage;
            btnVATRate.Text = LanguageStrings.AppMenuButtonVATRate;

            menuPopupMimicSage.Text = LanguageStrings.AppMenuMimicSage;
            menuPopupRefresh.Text = LanguageStrings.AppMenuRefresh;
            menuPopupRemoveUserDiscounts.Text = LanguageStrings.AppMenuRemoveUserDiscounts;
            menuPopupSetUserDiscounts.Text = LanguageStrings.AppMenuSetUserDiscounts;

            grpProducts.HeaderText = LanguageStrings.AppProducts;
            pnlCurrentSale.Text = LanguageStrings.AppCurrentSale;
            lblDiscountDesc.Text = LanguageStrings.AppDiscount;
            lblUserDiscountDesc.Text = LanguageStrings.AppUserDiscount;
            lblFilter.Text = LanguageStrings.AppFilter;
            lblProductType.Text = LanguageStrings.AppProductType;
            lblSubtotalDesc.Text = LanguageStrings.AppSubTotal;
            lblPostageDesc.Text = LanguageStrings.AppPostageAndPackaging;
            lblTotalDesc.Text = LanguageStrings.AppTotal;

            BuildBasket(true);
        }

        public override void AfterTabShow()
        {
            if (_user == null)
            {

            }

            if (_basket == null)
                LoadData(AppController.ActiveUser, 0, null);
        }

        public override void BeforeTabHide()
        {
            if (RequiresSave && IsDirty && ShowQuestion(LanguageStrings.AppOrderSave, LanguageStrings.AppOrderSavePrompt))
            {
                btnSave_Click(this, EventArgs.Empty);
            }
        }

        protected override void LoadSettings()
        {
            flowLayoutButtons.Visible = AppController.LocalSettings.TillShowButtons;
            lstProducts.Visible = !AppController.LocalSettings.TillShowButtons;
        }

        #endregion Overridden Methods

        #region Public Methods

        public void ProductsUpdated()
        {
            BuildProductList();
            BuildProducts();
        }

        #endregion Public Methods

        #region Private Methods

        private void LoadData(User staffMember, Int64 basketID, User user)
        {
            try
            {
                if (user == null)
                    return;

                IsDirty = true;
                _staffMember = staffMember;
                _user = user;

                //create new basket
                if (basketID == 0)
                {
                    _basket = new ShoppingBasket(AppController.LocalCountry, AppController.LocalCurrency,
                        AppController.LocalSettings.ShippingIsTaxable);
                }
                else
                {
                    _basket = new ShoppingBasket(basketID, AppController.LocalCountry, AppController.LocalCurrency,
                        AppController.LocalSettings.ShippingIsTaxable);

                    BuildBasket(false);
                }

                _basket.BasketUpdated += _Basket_BasketUpdated;
                _basket.IgnoreBasketQuantityRestrictions = true;
                _basket.IgnoreCostMultiplier = true;
                _basket.IgnoreAutoDiscount = true;
                _basket.User = user;
                _basket.UseSageDiscountLogic = true;
                _basket.ShippingCosts = 0;

                if (user != null && user.MemberLevel >= SharedBase.MemberLevel.Distributor && user.AutoDiscount > 0)
                {
                    _basket.ApplyDiscount(user.AutoDiscount, StringConstants.STORE_DISCOUNT);
                    BuildBasket(true);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                EventLog.Add(err);
            }
        }

        private void _Basket_BasketUpdated(object sender, EventArgs e)
        {
            //BuildBasket(true);
        }

        private ShoppingBasketItem FindBasketItem(BasketItem basketItem)
        {
            ShoppingBasketItem Result = null;

            foreach (ShoppingBasketItem basket in pnlBasket.Controls)
            {
                if (basket.Item.ItemID == basketItem.ItemID &&
                    basket.Item.Description == basketItem.Description &&
                    basket.Item.ItemType == basketItem.ItemType)
                {
                    Result = basket;
                    Result.UpdateQuantity(basketItem.Quantity);
                    break;
                }
            }

            if (Result == null)
            {
                Result = new ShoppingBasketItem(_staffMembers, AppController.ActiveUser);
                Result.ContextMenuStrip = menuPopup;
                Result.IgnoreCostMultiplier = _basket.IgnoreCostMultiplier;
                Result.BeforeNameChange += Result_BeforeNameChange;
                Result.Basket = _basket;
                Result.Item = basketItem;
                Result.Updated += new EventHandler(itm_Updated);
                Result.Deleted += new EventHandler(itm_Deleted);
                pnlBasket.Controls.Add(Result);
            }

            ResizeBasketItems();

            return (Result);
        }

        private void Result_BeforeNameChange(object sender, Base.NameChangeEventArgs e)
        {
            foreach (ShoppingBasketItem basket in pnlBasket.Controls)
            {
                if (basket.Item.ID != e.ID && basket.Item.Description.Trim() == e.Name)
                {
                    e.Allowed = false;
                    return;
                }
            }

            e.Allowed = true;
        }

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildProductList();
            BuildProducts();
            lstProducts.Focus();
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
            if (_basket == null)
                return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                pnlBasket.SuspendDrawing();


                if (!TotalsOnly)
                {
                    pnlBasket.Controls.Clear();

                    foreach (BasketItem item in _basket.Items)
                    {
                        ShoppingBasketItem itm = new ShoppingBasketItem(_staffMembers, _user);

                        itm.IgnoreCostMultiplier = _basket.IgnoreCostMultiplier;

                        itm.Basket = _basket;
                        itm.Item = item;
                        itm.Updated += new EventHandler(itm_Updated);
                        itm.Deleted += new EventHandler(itm_Deleted);
                        pnlBasket.Controls.Add(itm);
                        ResizeBasketItems();
                    }
                }

                _basket.Reset(_basket.Currency.PriceColumn);

                lblPostageTotal.Text = _basket.ShippingCost;
                lblSubtotalValue.Text = _basket.SubTotalCost;
                lblVATTotal.Text = _basket.VATCost;
                lblTotalTotal.Text = _basket.TotalCost;
                lblVATDesc.Text = String.Format(LanguageStrings.AppTaxPercentage, _basket.VATRate);

                lblDiscountTotal.Text = SharedUtils.FormatMoney(_basket.BasketDiscountValue,
                    POS.Base.Classes.AppController.LocalCurrency);
                lblUserDiscount.Text = SharedUtils.FormatMoney(_basket.UserDiscountValue,
                    POS.Base.Classes.AppController.LocalCurrency);

                ResizeBasketItems();

                if (String.IsNullOrEmpty(_basket.DiscountCouponName))
                {
                    lblDiscountDesc.Text = LanguageStrings.AppDiscount;
                }
                else
                {
                    lblDiscountDesc.Text = String.Format(StringConstants.DISCOUNT,
                        _basket.DiscountCouponName, _basket.Discount,
                        _basket.VoucherType == Enums.InvoiceVoucherType.Percent ?
                        StringConstants.SYMBOL_PERCENT : String.Empty);
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                pnlBasket.ResumeDrawing();
                UpdateUI();
            }
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
            if (_user.ID < 0)
            {
                _user = User.UserGet(_user.Email);
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
                        _order = _basket.ConvertToOrder(PaymentStatuses.Get(
                            StringConstants.PAYMENT_OFFICE_NOT_PAID),
                            _user.Email, StringConstants.PAYMENT_OFFICE,
                            AppController.LocalSettings.CustomCulture);

                    }
                    catch (Exception err)
                    {
                        //second chance
                        if (err.Message.Contains(StringConstants.ERROR_VIOLATION_FOREIGN_KEY))
                        {
                            ResetUser();
                            _basket.User = _user;
                            _order = _basket.ConvertToOrder(
                                PaymentStatuses.Get(StringConstants.PAYMENT_OFFICE_PAID),
                                _user.Email, StringConstants.PAYMENT_OFFICE,
                                AppController.LocalSettings.CustomCulture);
                        }
                        else
                            throw;
                    }

                    _order.Paid(_user, PaymentStatuses.Get(StringConstants.PAYMENT_OFFICE_PAID), String.Empty, String.Empty);

                    Invoice inv = SharedBase.BOL.Invoices.Invoices.Get(_order);
                    ProcessStatus newStatus = ProcessStatus.Completed;

                    foreach (InvoiceItem item in inv.InvoiceItems)
                    {
                        switch (item.ItemType)
                        {
                            case ProductCostItemType.Product:
                            case ProductCostItemType.FreeProduct:
                            case ProductCostItemType.Voucher:
                            case ProductCostItemType.GiftWrap:
                                newStatus = ProcessStatus.OrderReceived;
                                break;

                            default:
                                item.ItemStatus = ProcessItemStatus.Complete;
                                item.Save();
                                break;
                        }

                        if (newStatus == ProcessStatus.OrderReceived)
                            break;
                    }

                    inv.SetProcessStatus(_user, newStatus);

                    string notes = inv.StaffNotes;

                    if (NotesViewForm.ShowNotes(null, ref notes, false, 32000))
                    {
                        if (!String.IsNullOrEmpty(notes))
                            inv.UpdateStaffNotes(notes);
                    }

                    btnClearBasket_Click(sender, e);
                    _basket.User = _user;
                }
                else
                {
                    try
                    {
                        _order = _basket.ConvertToOrder(PaymentStatuses.Get(
                            StringConstants.PAYMENT_OFFICE_NOT_PAID), _user.Email,
                            StringConstants.PAYMENT_OFFICE,
                            AppController.LocalSettings.CustomCulture);

                    }
                    catch (Exception err)
                    {
                        //second chance
                        if (err.Message.Contains(StringConstants.ERROR_VIOLATION_FOREIGN_KEY))
                        {
                            ResetUser();
                            _basket.User = _user;
                            _order = _basket.ConvertToOrder(PaymentStatuses.Get(
                                StringConstants.PAYMENT_OFFICE_NOT_PAID),
                                _user.Email, StringConstants.PAYMENT_OFFICE,
                                AppController.LocalSettings.CustomCulture);
                        }
                        else
                            throw;
                    }

                }

                btnClearBasket_Click(this, EventArgs.Empty);
                RequiresSave = false;
                IsDirty = false;
                UpdateUI();

                PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_INVOICE_CREATED);
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

        private void lstProducts_DoubleClick(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selected = new ListBox.SelectedObjectCollection(lstProducts);

            foreach (Object obj in selected)
            {
                ProductCost costitem = (ProductCost)obj;

                BasketItem item = _basket.Add(costitem, 1, _staffMember, AppController.LocalCountry.PriceColumn);

                ShoppingBasketItem itm = FindBasketItem(item);
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

                    _products = AppController.Administration.ProductsGet();

                    ProductCostType type = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];
                    _productButtons.Clear();
                    int I = 1;

                    foreach (Product product in _products)
                    {
                        WaitInputDialog.UpdateWaitScreen(String.Format(LanguageStrings.AppProductLoadingName, product.Name), I);

                        product.UpdateProductCostInfo(_staffMember);

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

            BasketItem newBasketItem = _basket.Add(button.Product, 1, AppController.ActiveUser, AppController.LocalCountry.PriceColumn);

            if (!_postageReminder)
            {
                switch (button.Product.ItemType)
                {
                    case ProductCostItemType.Product:
                    case ProductCostItemType.Voucher:
                        if (_basket.ShippingCosts == 0.00m)
                        {
                            if (ShowQuestion(LanguageStrings.Postage, LanguageStrings.AppPostageSetNow))
                            {
                                btnPostage_Click(this, EventArgs.Empty);
                            }
                        }

                        _postageReminder = true;

                        break;
                }
            }

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

            if (!type.HasStock())
                return (Result);

            if (Result && AppController.LocalSettings.HideOutOfStockProducts &&
                (product.OutOfStock || cost.OutOfStock))
            {
                Result = false;
            }

            if (Result && AppController.LocalSettings.HideProductsWithZeroStock &&
                (cost.GetStockLevel(SharedBase.DAL.DALHelper.StoreID) < 1))
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

                    foreach (Product product in _products)
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
            _basket.Empty();
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

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_SHOW_TILL_DISCOUNT, _basket));

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
                    _basket.ShippingCosts = Convert.ToDecimal(Result.Text);
                    _postageReminder = true;
                }
                catch (Exception err)
                {
                    ShowError(LanguageStrings.AppShippingCosts,
                        String.Format(LanguageStrings.AppErrorShippingAmount,
                        Result.Text, err.Message));
                }
            }

            BuildBasket(true);
        }

        private void btnVATRate_Click(object sender, EventArgs e)
        {
            PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_SHOW_CUSTOM_VAT_RATE, _basket));
            BuildBasket(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _basket.SaveBasket(String.Format(LanguageStrings.AppOrderSaveAs,
                _basket.User.UserName, AppController.ActiveUser.UserName,
                DateTime.Now.ToString(StringConstants.SYMBOL_DATE_FORMAT_G)));
            RequiresSave = false;
            UpdateUI();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (IsDirty && ShowQuestion(LanguageStrings.AppOrderSave, LanguageStrings.AppOrderSavePrompt))
            {
                btnSave_Click(sender, e);
            }

            SelectUser getUserForm = new SelectUser(false);
            try
            {
                if (getUserForm.ShowDialog() == DialogResult.Cancel)
                    return;

                User invoiceUser = getUserForm.SelectedUser;

                if (invoiceUser.DeliveryAddresses.Count == 0)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorNoDeliveryAddresses);
                    return;
                }

                if (invoiceUser == null)
                    return;

                DateTime invoiceCheck = DateTime.Now.AddDays(-1);

                int invoiceCount = invoiceUser.InvoiceCountSinceDate(invoiceCheck);

                if (invoiceCount > 0)
                {
                    if (MessageBox.Show(String.Format(LanguageStrings.AppOrderCreateHasRecent,
                        invoiceCount, invoiceCheck.ToString(StringConstants.SYMBOL_DATE_FORMAT_M), invoiceUser.UserName),
                        LanguageStrings.AppOrderCreate, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                LoadData(AppController.ActiveUser, 0, invoiceUser);
            }
            finally
            {
                getUserForm.Dispose();
                getUserForm = null;
                UpdateUI();
                RequiresSave = true;
                _postageReminder = false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (IsDirty && ShowQuestion(LanguageStrings.AppOrderSave, LanguageStrings.AppOrderSavePrompt))
            {
                btnSave_Click(sender, e);
            }

            Int64 basketID = 0;
            User invoiceUser = null;

            SavedBasketOrdersForm selSavedOrder = new SavedBasketOrdersForm();
            try
            {
                DialogResult result = selSavedOrder.ShowDialog(ParentForm);

                if (result == DialogResult.Cancel)
                    return;

                if (result == DialogResult.Yes)
                {
                    basketID = selSavedOrder.BasketID;
                    invoiceUser = User.UserGet(selSavedOrder.UserID);

                    LoadData(AppController.ActiveUser, basketID, invoiceUser);
                }
            }
            finally
            {
                selSavedOrder.Dispose();
                selSavedOrder = null;
                UpdateUI();
                RequiresSave = true;
                _postageReminder = false;
            }
        }

        private void UpdateUI()
        {
            grpProducts.Enabled = IsDirty;
            btnApplyDiscount.Enabled = IsDirty;
            btnClearBasket.Enabled = IsDirty;
            btnCreateOrder.Enabled = IsDirty && _basket != null && _basket.HasItems();
            btnPostage.Enabled = IsDirty;
            btnSave.Enabled = IsDirty;
            btnVATRate.Enabled = IsDirty;
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCostType item = (ProductCostType)e.ListItem;
            e.Value = item.Description;
        }

        #region Popup Menu

        private void menuPopup_Opening(object sender, CancelEventArgs e)
        {
            menuPopupMimicSage.Checked = _basket.UseSageDiscountLogic;
        }

        private void menuPopupSetUserDiscounts_Click(object sender, EventArgs e)
        {
            InputBoxResult Result = InputBox.Show(LanguageStrings.AppOrderUserDiscount,
                LanguageStrings.AppOrderEnterNewUserDiscount);

            if (Result.ReturnCode == DialogResult.OK)
            {
                try
                {
                    int newDiscount = Utilities.StrToInt(Result.Text, -1);

                    if (newDiscount < 0 || newDiscount > 100)
                    {
                        throw new Exception(LanguageStrings.AppErrorOrderSetUserDiscount);
                    }

                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        pnlBasket.SuspendDrawing();

                        foreach (ShoppingBasketItem basketItem in pnlBasket.Controls)
                        {
                            basketItem.Updated -= itm_Updated;
                            try
                            {
                                basketItem.UpdateUserDiscount(newDiscount);
                            }
                            finally
                            {
                                basketItem.Updated += new EventHandler(itm_Updated);
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Arrow;
                        pnlBasket.ResumeDrawing();
                    }
                }
                catch
                {
                    ShowError(LanguageStrings.AppOrderUserDiscount,
                        String.Format(LanguageStrings.AppErrorOrderSetUserDiscount,
                        Result.Text));
                }

                BuildBasket(true);
            }
        }

        private void menuPopupRemoveUserDiscounts_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                pnlBasket.SuspendDrawing();
                foreach (ShoppingBasketItem basketItem in pnlBasket.Controls)
                {
                    basketItem.Updated -= itm_Updated;
                    try
                    {
                        basketItem.UpdateUserDiscount(0);
                    }
                    finally
                    {
                        basketItem.Updated += new EventHandler(itm_Updated);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                pnlBasket.ResumeDrawing();
            }

            BuildBasket(true);
        }

        private void menuPopupMimicSage_Click(object sender, EventArgs e)
        {
            _basket.UseSageDiscountLogic = !_basket.UseSageDiscountLogic;
            BuildBasket(true);
        }

        private void menuPopupRefresh_Click(object sender, EventArgs e)
        {
            BuildBasket(false);
        }

        #endregion Popup Menu

        private void pnlCurrentSale_BeforeCollapse(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void grpProducts_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control child in grpProducts.Controls)
            {
                if (child.Location.X > 10)
                    child.Left = child.Location.X - 26;
            }
        }

        private void pnlCurrentSale_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control child in pnlCurrentSale.Controls)
            {
                if (child.Location.X > 10)
                    child.Left = child.Location.X - 26;
            }
        }

        #endregion Private Methods
    }
}
