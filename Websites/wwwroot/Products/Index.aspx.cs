using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Products;
using Library.BOL.Users;
using Library.Utils;
using Library.BOL.Countries;
using Library.BOL.Websites;

using Website.Library.Classes;

#pragma warning disable IDE1006

namespace SieraDelta.Website
{
    public partial class PageProduct : BaseWebForm
    {
        private Product _product;

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {            
            OutOfStockNotification1.Visible = false;
            btnAddToBasket.Text = Languages.LanguageStrings.AddToBag;
            _product = Library.BOL.Products.Products.Get(GetFormValue("ID", -1));

            if (_product != null)
            {
                if (!String.IsNullOrEmpty(_product.PageLink))
                    DoRedirect(_product.PageLink);
            }

            if (_product == null)
            {
                // can we look up the product using route name?
                string prodRouteName = (string)Page.RouteData.Values["name"];

                if (BaseWebApplication.AllRoutes.ContainsKey(prodRouteName))
                {
                    Int64 id = BaseWebApplication.AllRoutes[prodRouteName];
                    _product = Library.BOL.Products.Products.Get(id);
                }
                
                // product still not found so bug out
                if (_product == null)
                {
                    DoRedirect("/All-Products/", true);
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

            MediaLinks1.ProductLink = _product;

            divVideoLink.Visible = !String.IsNullOrEmpty(_product.VideoLink.Trim());
            divFeatures.Visible = !String.IsNullOrEmpty(_product.Features.Trim());
            divHowToUse.Visible = !String.IsNullOrEmpty(_product.HowToUse.Trim());
            divIngredients.Visible = !String.IsNullOrEmpty(_product.Ingredients.Trim());

            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(_product.PrimaryGroup.ID, true, GetUserSession().MobileRedirect);
        }

        protected string GetProductDescription()
        {
            return (_product.WebDescription);
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
            return (_product.Image);
        }

        protected string GetProductName()
        {
            return (_product.Name.Trim());
        }

        protected string GetProductGroupName()
        {
            return (_product.PrimaryGroup.Description.Trim());
        }

        protected string GetPrimaryProductGroupName()
        {
            return (_product.PrimaryGroup.SEODescripton);
        }

        protected string ProductSEOLocation()
        {
            return (_product.URL);
        }

        protected string GetPrimaryProductGroup()
        {
            string Result = "<a href=\"/All-Products/Group//\">{1}</a>";

            ProductGroup group = _product.PrimaryGroup;

            if (group != null)
                Result = String.Format(Result, group.ID, group.SEODescripton);

            return (Result);
        }

        protected string GetProductImage()
        {
            string Result = _product.Image;

            //if (!Result.Contains(".png") && !Result.Contains(".jpg"))
            //    Result += "_288.jpg";

            Result = SharedUtils.ResizeImage(Result, 288);

            return (Result);
        }

        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            int Count = SharedUtils.StrToIntDef(lstQuantity.SelectedItem.Text, 1);

            // caused an error if nothing selected
            if (lstProductTypes.SelectedItem == null)
                return;

            // product cost/type
            int prodType = SharedUtils.StrToIntDef(lstProductTypes.SelectedItem.Value, -1);
            _product.UpdateProductCosts(GetUser());
            ProductCost item = ProductCosts.Get(prodType, GetUser());

            if (item.OutOfStock && WebsiteSettings.Stock.OutOfStockAllowNotifyUser)
            {
                if (!WebsiteSettings.Stock.OutOfStockInPage)
                {
                    DoRedirect(String.Format("/Products/OutOfStock.aspx?ItemID={0}", item.ID));
                }
            }
            else
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.Basket.Add(item, Count, GetUser(), Library.ProductCostItemType.Product, 
                    localData.Basket.Currency.PriceColumn);

                if (WebsiteSettings.ShoppingCart.BasketSummaryShow)
                    BasketSummary.Visible = true;
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
            int width = 640;
            int height = 390;

            if (GetUserSession().MobileRedirect)
            {
                width = 280;
                height = 170;
            }

            string Result = _product.VideoLink;

            if (Result.ToLower().StartsWith("https://www.facebook.com/video") || 
                Result.ToLower().StartsWith("http://www.facebook.com/video"))
            {
                //its from facebook
                string fbReference = Result.Replace("video.php?v=", "v/"); // Result.Substring(Result.IndexOf("v=") + 2);
                Result = String.Format("<object width=\"{1}\" height=\"{2}\" ><param name=\"allowfullscreen\" value=\"true\" /> " +
                    "<param name=\"allowscriptaccess\" value=\"always\" /> <param name=\"movie\" value=\"{0}\" /> " +
                    "<embed src=\"{0}\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" " +
                    "allowfullscreen=\"true\" width=\"{1}\" height=\"{2}\"></embed></object>", fbReference, width, height);
            }
            else
            if (!Result.ToLower().StartsWith("http"))
            {
                //assume a you tube link here
                Result = String.Format("<iframe width=\"{1}\" height=\"{2}\" src=\"https://www.youtube.com/embed/{0}\" frameborder=\"0\"></iframe>", Result, width, height);
            }

            return (Result);
        }

        protected string GetProductFeatures()
        {
            return (_product.WebFeatures);
        }

        protected string GetIngredients()
        {
            return (_product.WebIngredients);
        }

        protected string GetHowToUse()
        {
            return (_product.WebHowToUse);
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadPoductTypes()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            lstProductTypes.Items.Clear();

            _product.UpdateProductCosts(GetUser(), WebCountry);
            ListItem item = null;
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

            foreach (ProductCost cost in _product.ProductCosts)
            {
                decimal prodCost = cost.PriceGet(localData.PriceColumn, localData.Basket.Country);

                if (prodCost > 0.00m)
                {
                    if (WebsiteSettings.Tax.PricesIncludeVAT)
                    {
                        prodCost += SharedUtils.VATCalculate(prodCost, WebVATRate);
                    }

                    item = new ListItem(String.Format("{0} ({1})", 
                        GetTranslatedDescription(cost.Size), 
                        SharedUtils.FormatMoney(prodCost, GetWebsiteCurrency())), 
                        cost.ID.ToString()); //??? what is this line

                    lstProductTypes.Items.Add(item);
                }
            }

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

        private void UpdateNotificationSettings()
        {
            if (WebsiteSettings.Stock.OutOfStockAllowNotifyUser && 
                WebsiteSettings.Stock.OutOfStockInPage && 
                lstProductTypes.SelectedIndex > -1)
            {
                //SieraDeltaUtils u = new SieraDeltaUtils();
                int prodType = SharedUtils.StrToIntDef(lstProductTypes.SelectedItem.Value, -1);
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
            UpdateNotificationSettings();
        }

        #endregion Private Methods
    }
}