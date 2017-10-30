using System;
using System.Web.UI.WebControls;

using Library.BOL.Countries;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.Utils;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Products
{
    public partial class MayBankHoliday : BaseWebFormOffers
    {
        #region Private Members

        private Product _product;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            PageExpires = new DateTime(2015, 6, 1);
            OutOfStockNotification1.Visible = false;
            btnAddToBasket.Text = Languages.LanguageStrings.AddToBag;
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(false, false);
            _product = Library.BOL.Products.Products.Get(375);

            if (_product == null)
                DoRedirect("/Products.aspx?GroupID=1", true);

            //if it's not a stratosphere product redirect to another page
            if (_product.PrimaryProduct.ID != ProductTypes.Get("Stratosphere").ID)
            {
                if (_product.PrimaryProduct.ID == ProductTypes.Get("Professional").ID)
                {
                    DoRedirect(String.Format("/Products/Product.aspx?ID={0}", _product.ID));
                }
            }

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

            if (!AllowShowCostData() || !ShowPriceData)
            {
                pProductCost.Visible = false;
            }

            hContains.Visible = !String.IsNullOrEmpty(_product.Ingredients.Trim());
            divVideoLink.Visible = !String.IsNullOrEmpty(_product.VideoLink.Trim());
            divFeatures.Visible = !String.IsNullOrEmpty(_product.Features.Trim());;
            divHowToUse.Visible = !String.IsNullOrEmpty(_product.HowToUse.Trim());;
            divIngredients.Visible = !String.IsNullOrEmpty(_product.Ingredients.Trim());


            // do we change the button color depending on contents of the shopping basket OR
            // do inpage sign up for out of stock notifications 
            if (Global.AlterTextColorBasedOnBasketContents | (Global.OutOfStockAllowNotifyUser && Global.OutOfStockInPage))
            {
                lstProductTypes.AutoPostBack = true;
                lstProductTypes.SelectedIndexChanged += lstProductTypes_SelectedIndexChanged;
            }
        }

        protected string GetFullVideoLink()
        {
            string Result = _product.VideoLink;

            if (!Result.StartsWith("http"))
            {
                //assume a you tube link here
                Result = String.Format("https://www.youtube.com/watch?v={0}", Result);
            }

            return (Result);
        }

        protected string GetVideoLink()
        {
            string Result = _product.VideoLink;

            if (Result.ToLower().StartsWith("https://www.facebook.com/video") || Result.ToLower().StartsWith("http://www.facebook.com/video"))
            {
                //its from facebook
                string fbReference = Result.Replace("video.php?v=", "v/"); // Result.Substring(Result.IndexOf("v=") + 2);
                Result = String.Format("<object width=\"640\" height=\"390\" ><param name=\"allowfullscreen\" value=\"true\" /> " +
                    "<param name=\"allowscriptaccess\" value=\"always\" /> <param name=\"movie\" value=\"{0}\" /> " +
                    "<embed src=\"{0}\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" " +
                    "allowfullscreen=\"true\" width=\"640\" height=\"390\"></embed></object>", fbReference);
            }
            else
                if (!Result.ToLower().StartsWith("http"))
                {
                    //assume a you tube link here
                    Result = String.Format("<iframe width=\"640\" height=\"390\" src=\"https://www.youtube.com/embed/{0}\" frameborder=\"0\"></iframe>", Result);
                }

            return (Result);
        }

        protected string GetProductDescription()
        {
            string Result = _product.Description;

            Result = HSCUtils.PreProcessPost(Result).Trim();

            if (String.IsNullOrEmpty(Result))
                divDescription.Visible = false;

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

            ProductGroup group = _product.ProductGroups.First();

            if (group != null)
                Result = String.Format(Result, group.ID, group.Description);

            return (Result);
        }

        protected string GetProductGroupName()
        {
            string Result = "{0}";

            Result = String.Format(Result, _product.PrimaryGroup.Description);

            return (Result);
        }

        protected string GetProductImage()
        {
            string Result = _product.Image.ToLower();

            if (!Result.Contains(".png") && !Result.Contains(".jpg"))
                Result += "_288.png";

            Result = HSCUtils.ResizeImage(Result, 288);

            return (Result);
        }

        protected string GetIngredients()
        {
            string Result = _product.Ingredients.Replace("\r", "<br />").Trim();

            return (Result);
        }

        protected string GetHowToUse()
        {
            string Result = _product.HowToUse.Replace("\r", "<br />").Trim();

            return (Result);
        }

        protected string GetProductFeatures()
        {
            string Result = String.Format("<li>{0}</li>", _product.Features.Trim().Replace("\r", "</li><li>")).Trim();

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
                localData.Basket.Add(item, Count, localData.CurrentUser, localData.PriceColumn);

                if (Global.JumpToBasketAfterAddItem)
                    DoRedirect("/Basket/Basket.aspx");
            }
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

                if (prodCost > 0.00m)
                {
                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        prodCost += SharedUtils.VATCalculate(prodCost, WebVATRate);
                    }

                    item = new ListItem(String.Format("{0} ({1})", cost.Size, 
                        SharedUtils.FormatMoney(prodCost, GetWebsiteCurrency(), false)), 
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