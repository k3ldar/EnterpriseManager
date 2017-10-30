using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.CustomWebPages;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Countries;

using Website.Library;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class PageProduct : BaseWebForm
    {
        #region Private Members

        private Product _product;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            OutOfStockNotification1.Visible = false;
            btnAddToBasket.Text = Languages.LanguageStrings.AddToBag;
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(false, false);
            _product = Library.BOL.Products.Products.Get(GetFormValue("ID", 1));

            if (_product == null)
                DoRedirect("/Products.aspx?GroupID=1", true);

            if (!_product.ShowOnWebsite)
                DoRedirect("/Products.aspx?GroupID=1", true);

            //If it's not a professional product redirect to another page
            if (_product.PrimaryProduct != ProductTypes.Get("Professional"))
            {
                if (TreatAsStratosphereProduct(_product.PrimaryProduct))
                {
                    DoRedirect(String.Format("/Products/Stratosphere.aspx?ID={0}", _product.ID));
                }
            }

            pPreOrder.Visible = _product.PreOrder;

            if (!IsPostBack)
            {
                LoadPoductTypes();
                LoadQuantities();
            }
            else
            {
                UpdateNotificationSettings();
            }

            MediaLinks1.ProductLink = _product;
            Country country = Countries.Get(GetUserCountry());

            if (Global.HideShoppingCart || !AllowShowCostData() || !ShowPriceData)
            {
                pProductCost.Visible = false;
            }

            // do we change the button color depending on contents of the shopping basket OR
            // do inpage sign up for out of stock notifications 
            if (Global.AlterTextColorBasedOnBasketContents | (Global.OutOfStockAllowNotifyUser && Global.OutOfStockInPage))
            {
                lstProductTypes.AutoPostBack = true;
                lstProductTypes.SelectedIndexChanged += lstProductTypes_SelectedIndexChanged;
            }
        }


        protected string GetProductDescription()
        {
            string Result = _product.Description;

            if (BaseWebApplication.WebsiteCultureOverride)
            {
                CustomPage page = CustomPages.Get(Countries.Get(BaseWebApplication.WebsiteCulture),
                    _product, Library.CustomPagesType.ProductDescription);

                if (page != null && page.IsActive)
                {
                    return (page.PageText.Replace("\r", "<br />"));
                }
            }

            Result = HSCUtils.PreProcessPost(Result);

            return (Result);
        }

        protected string GetOGDescription()
        {
            string Result = _product.Description;
            try
            {
                if (Result.IndexOf("\r") == -1)
                {
                    Result = Result.Substring(0, 100);

                    while (Result.Length > 2 && !Result.EndsWith(" "))
                        Result = Result.Substring(0, Result.Length - 1);
                }
                else
                    Result = Result.Substring(0, Result.IndexOf("\r"));
            }
            catch 
            {
                Result = _product.Name;
            }

            return (Result.Trim());
        }

        protected string GetImage()
        {
            string result = _product.Image;
            return (result);
        }

        protected string GetProductName()
        {
            string Result = _product.Name;

            return (Result);
        }

        protected string GetProductGroupLink()
        {
            string Result = "<a href=\"/Products.aspx?GroupID={0}\">{1}</a>";

            ProductGroup group = _product.PrimaryGroup;

            if (group != null)
                Result = String.Format(Result, group.ID, group.Description);

            return (Result);
        }

        protected string GetProductGroupName()
        {
            string Result = "{0}";

            if (_product.PrimaryGroup != null)
                Result = String.Format(Result, _product.PrimaryGroup.Description);
            else
                Result = String.Format(Result, Languages.LanguageStrings.Unknown);

            return (Result);
        }

        protected string GetProductImage()
        {
            string Result = _product.Image;

            //if (!Result.Contains(".png") && !Result.Contains(".jpg"))
            //    Result += "_288.jpg";

            Result = HSCUtils.ResizeImage(Result, 288);

            return (Result);
        }

        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            int Count = Shared.Utilities.StrToIntDef(lstQuantity.SelectedItem.Text, 1);

            // caused an error if nothing selected
            if (lstProductTypes.SelectedItem == null)
                return;

            // product cost/type
            int prodType = Shared.Utilities.StrToIntDef(lstProductTypes.SelectedItem.Value, -1);
            _product.UpdateProductCosts(GetUser());
            ProductCost item = ProductCosts.Get(prodType, GetUser());

            if (item.OutOfStock && Global.OutOfStockAllowNotifyUser)
            {
                if (!Global.OutOfStockInPage)
                {
                    DoRedirect(String.Format("/Products/OutOfStock.aspx?ItemID={0}", item.ID));
                }
            }
            else
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag; 
                int priceColumn = localData.PriceColumn;
                localData.Basket.Add(item, Count, GetUser(), priceColumn);

                if (Global.JumpToBasketAfterAddItem)
                    DoRedirect("/Basket/Basket.aspx");
            }

            if (Global.BasketSummaryShow)
                BasketSummary.Visible = true;
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadPoductTypes()
        {
            lstProductTypes.Items.Clear();

            _product.UpdateProductCosts(GetUser(), WebCountry);
            ListItem item = null;

            foreach (ProductCost cost in _product.ProductCosts)
            {
                decimal prodCost = cost.PriceGet(((LocalWebSessionData)GetUserSession().Tag).PriceColumn, WebCountry);

                string saving = String.Empty;
                
                if (cost.Saving > 0.00d)
                    saving = String.Format(Languages.LanguageStrings.ProductSaving, cost.Saving);

                if (cost.Discount > 0.0m)
                    prodCost = (prodCost / 100) * cost.Discount;

                if (BaseWebApplication.PricesIncludeVAT)
                {
                    prodCost += SharedUtils.VATCalculate(prodCost, WebVATRate);
                }

                if (prodCost > 0.00m)
                {
                    if (cost.ProductCostType.ID == ProductCostTypes.Get("Silver").ID)
                        item = new ListItem(String.Format("{0} ({1}){2}", cost.Size,
                            SharedUtils.FormatMoney(prodCost, GetWebsiteCurrency(), false),
                            String.IsNullOrEmpty(saving) ? String.Empty : " " + saving), 
                            cost.ID.ToString());
                    else
                        item = new ListItem(String.Format("{2} {0} ({1}){3}", cost.Size,
                            SharedUtils.FormatMoney(prodCost, GetWebsiteCurrency(), false), 
                            cost.ProductCostType.Description,
                            String.IsNullOrEmpty(saving) ? String.Empty : " " + saving),
                            cost.ID.ToString());

                    lstProductTypes.Items.Add(item);
                }
            }

            UpdateButtonTextColor();
            UpdateNotificationSettings();
        }

        private void LoadQuantities()
        {
            lstQuantity.Items.Clear();
            User user = GetUser();
            int Count = 3;

            if (user != null && user.MemberLevel >= Library.MemberLevel.Reseller)
                Count = 20;

            for (int i = 1; i <= Count; i++)
            {
                ListItem item = new ListItem(i.ToString());
                lstQuantity.Items.Add(item);
            }
        }

        private void UpdateButtonTextColor()
        {
            if (Global.AlterTextColorBasedOnBasketContents && lstProductTypes.SelectedItem != null)
            {
                int prodType = Shared.Utilities.StrToIntDef(lstProductTypes.SelectedItem.Value, -1);
                _product.UpdateProductCosts(GetUser());
                ProductCost prodItem = ProductCosts.Get(prodType, GetUser());

                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

                if (localData.Basket.Contains(prodItem))
                    btnAddToBasket.ForeColor = System.Drawing.Color.FromName(Global.ItemExistsInShoppingBagTextColour);
                else
                    btnAddToBasket.ForeColor = System.Drawing.Color.FromName(Global.ItemDoesNotExistsInShoppingBagTextColour);
            }
        }

        private void UpdateNotificationSettings()
        {
            if (Global.OutOfStockAllowNotifyUser && Global.OutOfStockInPage && lstProductTypes.SelectedIndex > -1)
            {
                int prodType = Shared.Utilities.StrToIntDef(lstProductTypes.SelectedItem.Value, -1);
                ProductCost prodItem = ProductCosts.Get(prodType, GetUser());

                if (prodItem.OutOfStock)
                {
                    OutOfStockNotification1.Visible = true;
                    OutOfStockNotification1.SetItem(prodItem);
                    spanNotifications.Visible = false;
                    pProductCost.Style.Add("height", "60px");
                }
                else
                {
                    OutOfStockNotification1.Visible = false;
                    spanNotifications.Visible = true;
                    pProductCost.Style.Remove("height");
                }
            }

        }

        private void lstProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonTextColor();
            UpdateNotificationSettings();
        }

        #endregion Private Methods
    }
}