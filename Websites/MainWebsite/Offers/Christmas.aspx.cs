using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using Languages;
using Library;
using Library.BOL.Basket;
using Library.BOL.Products;
using Library.BOL.Countries;
using Library.BOL.TagLines;
using Library.Utils;
using Shared.Classes;
using Website.Library;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class Christmas : BaseWebFormOffers
    {
        #region Private Members

        private static object _featuredProductLockObjct = new object();
        private static DateTime _featuredProductLastUpdated;
        private static string _featuredProduct;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            PageAvailable = Global.ChristmasPageStart;
            PageExpires = Global.ChristmasPageEnd;

            string[] skuList = Global.ChristmasPageSKUCodes.Split(';');

            if (skuList.Length == 0)
                DoRedirect("/Index.aspx", true);

            LoadProductSKUs(skuList);

            Page.Header.DataBind();
            divTagLine.InnerHtml = String.Format("&ldquo;&nbsp;{0}&nbsp;&rdquo;", TagLines.RandomTagLine().Text);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            CountryLanguageSelect1.Visible = LocalizedLanguages.Active;

            if (LocalizedLanguages.Active)
            {
                CountryLanguageSelect1.ShowFlags = Global.ShowLanguageFlag;
                CountryLanguageSelect1.ShowLanguageSelector = Global.ShowLanguageSelector;
                CountryLanguageSelect1.ShowCurrencySelector = Global.ShowCurrencySelector;
            }

            divShoppingCart.Visible = !Global.HideShoppingCart;

            btnSearch.ServerClick += btnSearch_ServerClick;

            if (!IsPostBack)
            {
                txtSearchTerms.Text = GetSearchString();
            }

            UpdateSocialMediaIcons();

            UserSession session = GetUserSession();

            liMobileNavigator.Visible = session.MobileRedirect;
            liSearch.Visible = liMobileNavigator.Visible;
            hCategories.Visible = !liMobileNavigator.Visible;

            if (Global.AllowMobileWebsite && session.IsMobileDevice)
            {
                pMobileSite.Visible = true;

                if (session.MobileRedirect)
                {
                    pMobileSite.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>",
                        String.Format("/Mobile/Switch.aspx?m=False&l={0}", Request.RawUrl),
                        Languages.LanguageStrings.SwitchToDesktopSite);
                }
                else
                {
                    pMobileSite.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>",
                        String.Format("/Mobile/Switch.aspx?m=True&l={0}", Request.RawUrl),
                        Languages.LanguageStrings.SwitchToMobileSite);
                }
            }
            else
            {
                pMobileSite.Visible = false;
            }
        }

        protected string GetStyleSheet()
        {
            string Result = String.Empty;

            if (GlobalClass.UseLeftToRight) // || Request.Path.Contains("/Staff/"))
                Result = String.Format("<link rel=\"stylesheet\" href=\"/css/Christmas.css\" type=\"text/css\" media=\"screen\" />",
                    GlobalClass.StyleSheet);
            else
                Result = String.Format("<link rel=\"stylesheet\" href=\"/css/Christmas.css\" type=\"text/css\" media=\"screen\" />",
                    GlobalClass.StyleSheet.Replace(".css", "rtl.css"));

            Result += "\r<link rel=\"stylesheet\" href=\"/css/ChristmasCombined.css\" type=\"text/css\" media=\"screen\" />";
            Result += "\r<link rel=\"stylesheet\" href=\"/css/BuyItNow.css\" type=\"text/css\" media=\"screen\" />";

            UserSession session = GetUserSession();

            if (session.MobileRedirect)
                Result = Result.Replace(".css", "_m.css");

            return (Result);
        }

        private void UpdateSocialMediaIcons()
        {
            socialFB.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaFacebook);
            socialTwitter.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaTwitter);
            socialGPlus.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaGPlus);
            socialRSS.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaRSSFeed);
        }

        protected void btnSearch_ServerClick(object sender, ImageClickEventArgs e)
        {
            string terms = txtSearchTerms.Text;

            if (!String.IsNullOrEmpty(terms) & terms != Languages.LanguageStrings.Search + "...")
            {
                DoRedirect(String.Format("/Search/SearchResults.aspx?search={0}", terms), true);
            }
        }

        protected string GetSearchString()
        {
            if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                return ("..." + Languages.LanguageStrings.Search);
            else
                return (Languages.LanguageStrings.Search + "...");
        }

        protected string BaseURL()
        {
            return (Global.RootURL);
        }

        /// <summary>
        /// Returns menu if Treatments are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowTreatments()
        {
            if (!Global.ShowTreatmentsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Treatments.aspx\">{1}</a></li>", Global.RootURL, Languages.LanguageStrings.Treatments));
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowSalons()
        {
            if (!Global.ShowSalonsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Salons.aspx\">{1}</a></li>", Global.RootURL, Languages.LanguageStrings.Salons));
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowTipsAndTricks()
        {
            if (!Global.ShowTipsAndTricksMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/TipsnTricks.aspx\">{1}</a></li>", Global.RootURL, Languages.LanguageStrings.TipsAndTricks));
        }


        protected string GetURL()
        {
            return (Request.Url.ToString());
        }

        protected string BasketInfo()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            decimal cost = 0.00m;

            if (localData.Basket.HasItems())
                cost = localData.Basket.TotalAmount;

            if (BaseWebApplication.PricesIncludeVAT)
            {
                cost += SharedUtils.VATCalculate(cost, WebVATRate);
            }

            string Result = String.Format("{2}: {0} <strong>{1}</strong>", localData.Basket.Items.Count,
                SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                Languages.LanguageStrings.Items);

            return (Result);
        }

        protected string GetTermsAndConditions()
        {
            string Result = String.Empty;

            if (BaseWebApplication.ShowTermsAndConditions)
                Result = String.Format(" - <a href=\"/Terms.aspx\">{0}</a>", Languages.LanguageStrings.Terms);

            return (Result);
        }

        protected string GetPrivacyPolicy()
        {
            string Result = String.Empty;

            if (BaseWebApplication.ShowPrivacyPolicy)
                Result = String.Format(" - <a href=\"/Privacy.aspx\">{0}</a>", Languages.LanguageStrings.Privacy);

            return (Result);
        }

        protected string GetReturnsPolicy()
        {
            string Result = String.Empty;

            if (BaseWebApplication.ShowReturnsPolicy)
                Result = String.Format(" - <a href=\"/Returns.aspx\">{0}</a>", Languages.LanguageStrings.Returns);

            return (Result);
        }

        protected string GetFeaturedProduct()
        {
            return (GetFeaturedProduct(ProductTypes.Get("Professional")));
        }

        /// <summary>
        /// Returns the featured product for a primary product type
        /// </summary>
        /// <param name="primaryProductType"></param>
        /// <returns>string</returns>
        protected string GetFeaturedProduct(ProductType primaryProductType)
        {
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;
            string name = String.Format("featured{0}{1}", priceColumn, WebCountry.CountryCode);
            CacheItem featuredCache = GlobalClass.InternalCache.Get(name);

            if (featuredCache != null)
            {
                return ((string)featuredCache.Value);
            }

            if (Library.DAL.DALHelper.AllowCaching && 
                    ((DateTime.Now - _featuredProductLastUpdated) < Library.DAL.DALHelper.CacheLimit && !String.IsNullOrEmpty(_featuredProduct)))
                return (_featuredProduct);

            string Result;

            using (TimedLock.Lock(_featuredProductLockObjct))
            {
                Product featured = Library.BOL.Products.Products.GetFeatured();

                if (featured == null)
                {
                    Result = "<img src=\"/Images/Product/no_image_148.jpg\" alt=\"\" border=\"0\" />";
                    return (Result);
                }

                string image = featured.Image.ToLower();

                if (!image.Contains(".png") && !image.Contains(".jpg"))
                    image += "_148.jpg";

                image = HSCUtils.ResizeImage(image, 148);

                Result = String.Format("<a href=\"/Products/Product.aspx?ID={0}\">", featured.ID);

                Result += String.Format("<img src=\"https://static.heavenskincare.com/Images/Products/{0}\" alt=\"\" border=\"0\" width=\"148\" height=\"114\"/>", image);

                if (ShowPriceData)
                {
                    decimal lowestPrice = featured.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        lowestPrice += SharedUtils.VATCalculate(lowestPrice, WebVATRate);
                    }

                    if (primaryProductType.ID == ProductTypes.Get("Stratosphere").ID)
                    {
                        Result += String.Format("<p>{0}<strong>{2} {1}</strong></p></a>",
                            featured.Name, SharedUtils.FormatMoney(lowestPrice, GetWebsiteCurrency(), false),
                            Languages.LanguageStrings.From);
                    }
                    else
                    {
                        Result += String.Format("{0}<strong>{2} {1}</strong></a>",
                            featured.Name, SharedUtils.FormatMoney(lowestPrice, GetWebsiteCurrency(), false),
                            Languages.LanguageStrings.From);
                    }
                }
                else
                    Result += String.Format("{0}</a>", featured.Name);

                _featuredProductLastUpdated = DateTime.Now;
                _featuredProduct = Result;
            }

            GlobalClass.InternalCache.Add(name, new CacheItem(name, Result), true);

            return (Result);
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowDistributors()
        {
            if (!GlobalClass.ShowDistributorsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Distributors.aspx\">{1}</a></li>", GlobalClass.RootURL, Languages.LanguageStrings.Distributors));
        }

        protected string GetGoogleAnalyticsCode()
        {
            return (BaseWebApplication.GoogleAnalytics);
        }

        protected string GetMobileOnlyScripts()
        {
            string Result = String.Empty;

            try
            {
                UserSession session = GetUserSession();

                if (session.MobileRedirect)
                {
                    Result = "<script type=\"text/javascript\"> " +
                        "$(document).ready(function () { " +
                        "p = navigator.platform; " +
                        "if (p === 'iPad' || p === 'iPhone' || p === 'iPod') { " +
                        "$(\"div.navigation\").each(function () { " +
                        "var onClick;  " +
                        "var firstClick = function () { " +
                        "onClick = secondClick; " +
                        "return false; }; " +
                        "var secondClick = function () { " +
                        "onClick = firstClick; " +
                        "return true; }; " +
                        "onClick = firstClick; " +
                        "$(this).click(function () { " +
                        "return onClick(); " +
                        "}); }); } }); </script> ";

                    Result += "<script type=\"text/javascript\">function openToolbar() { var tb = document.getElementById(\"leftToolbar\"); " +
                        "tb.style.width = \"176px\";" +
                        "tb.style.border = \"2px solid #111\";" +
                        "tb.style.padding = \"6px 6px 6px 6px\"; document.getElementById(\"divMobileShowColumn\").className = \"mobileShowColumnHidden\"; } " +
                        "function closeToolbar() { var tb = document.getElementById(\"leftToolbar\"); tb.style.width = \"0\";" +
                        "tb.style.border = \"0px\";" +
                        "tb.style.padding = \"0px\"; document.getElementById(\"divMobileShowColumn\").className = \"mobileShowColumn\";}</script>";

                    Result += "<script type=\"text/javascript\"> function openNavigation() { " +
                        " var x = document.getElementById(\"topNav\"); var sub = document.getElementById(\"subMenu\"); " +
                        " if (x.className === \"topNav\") { x.className += \" responsive\"; sub.className = \"subShow\"; " +
                        " } else { x.className = \"topNav\"; sub.className = \"sub\"; } } </script>";
                }
            }
            catch //(Exception err)
            {

            }

            return (Result);
        }

        protected string GetCookieConsent()
        {
            string Result = String.Empty;

            if (Request.Cookies["cookieconsent_dismissed"] != null)
                return (Result);

            Result = "<script type=\"text/javascript\" src=\"/js/cookieconsent.min.js\"></script>\r\n" +
                "<script type=\"text/javascript\">" +
                "window.cookieconsent_options = { \"message\": \"" + LanguageStrings.CookieMessage + "\", \"dismiss\": \"" +
                LanguageStrings.CookieAccept + "\", \"learnMore\": \"More info\", \"link\": null, \"theme\": \"dark-bottom\" };" +
                "</script>";

            return (Result);
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadProductSKUs(string[] skuList)
        {
            foreach (string sku in skuList)
            {
                Heavenskincare.WebsiteTemplate.Controls.BuyItNow bin = (Heavenskincare.WebsiteTemplate.Controls.BuyItNow)LoadControl("~/Controls/BuyItNow.ascx");
                bin.UseProductName = true;
                bin.PriceFontColour = "purple";
                bin.Product = Library.BOL.Products.ProductCosts.GetBySKU(sku);

                divBuyItNowItems.Controls.Add(bin);
            }
        }

        #endregion Private Methds
    }
}