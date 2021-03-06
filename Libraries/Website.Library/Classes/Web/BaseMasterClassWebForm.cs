﻿using System;
using System.Globalization;
using System.Threading;
using System.Reflection;

using Languages;

using Shared.Classes;

using lib = Library;
using Library.Utils;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.HashTags;
using Library.BOL.Statistics;
using Library.BOL.Websites;

namespace Website.Library.Classes
{
    public class BaseMasterClassWebForm : System.Web.UI.MasterPage
    {
        #region Private Members

        //private string _currentCSS = "style6.css";

        #endregion Private Members

        #region Protected Methods

#if DISPLAY_DEBUG_INFO
        protected string GetDebugInfo()
        {
            UserSession session = GetUserSession();
            LocalWebSessionData localData = (LocalWebSessionData)session.Tag;

            string Result = String.Format("<p>Process ID: {0}<br />Session: {1}<br />LocalData: {2}<br />IP Address: {3}" +
                "<br />Session Start: {4}<br />Basket Currency: {5}<br />Price Column: {6}<br />WebSite Country: {7}</p>",
                System.Diagnostics.Process.GetCurrentProcess().Id,
                session == null ? "Unknown" : session.InternalSessionID.ToString(),
                session.Tag == null ? "Unknown" : "Present",
                session.IPAddress,
                Session[StringConsts.SESSION_NAME_SESSION_INITIATED],
                Session[StringConsts.SESSION_NAME_USER_BASKET_CURRENCY],
                Session[StringConsts.SESSION_NAME_WEBSITE_PRICE_COLUMN], 
                Session[StringConsts.SESSION_NAME_WEBSITE_COUNTRY]);
                
            if (localData != null)
            {
                Result += String.Format("<p>Country Code: {1}<br />User Country: {0}<br />" +
                    "Price Column: {2}<br />Vat: {3}<br />Member Level: {4}<br />Logged In: {5}" +
                    "<br />Delivery Address: {6}<br />Basket: {7}</p>",
                    localData.UserCountry == null ? "Unknown" : localData.UserCountry.CountryCode,
                    String.IsNullOrEmpty(localData.CountryCode) ? "Unknown" : localData.CountryCode,
                    localData.PriceColumn,
                    localData.VATRate,
                    localData.MemberLevel,
                    localData.LoggedIn,
                    localData.DeliveryAddressID,
                    localData.Basket == null ? "null" : localData.Basket.ID.ToString());
            }

            if (session == null || session.Tag == null)
            {
                Response.Write(Result);
                Response.End();
            }

            return (Result);
        }
#endif

        protected int GetScrollCount()
        {
            if (GetUserSession().MobileRedirect)
                return (1);
            else
                return (4);
        }

        protected string GetHighlightedItems()
        {
            if (GlobalClass.ShowTopProducts)
                return (GetTopProducts());
            else
                return (GetProductCategories());
        }

        protected string GetTopProducts()
        {
            SimpleStatistics topProducts = Products.TopProducts(15);
            string Result = String.Empty;

            foreach (SimpleStatistic topProduct in topProducts)
            {
                Result += String.Format("<li><a href=\"/All-Products/Group/{0}/{1}/\">{2}</a></li>",
                    topProduct.Name1, SharedUtils.SEOName(topProduct.Description), topProduct.Description);
            }

            return (Result);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (WebsiteSettings.StaticWebSite)
                return;

            if (WebsiteSettings.Maintenance.AutoMaintenanceMode &&
                BaseWebApplication.BaseWebAppInstance != null &&
                !BaseWebApplication.BaseWebAppInstance.IsLoaded)
            {
                DoRedirect("/Maintenance.htm", true);
            }

            string newCulture = GetFormValue("country", String.Empty).ToUpper();

            if (!String.IsNullOrEmpty(newCulture))
            {
                Country selectedCountry = Countries.Get(newCulture);

                if (!selectedCountry.CanLocalize)
                    selectedCountry = Countries.Get(WebsiteSettings.Languages.DefaultCountrySettings);


                LocalizedLanguages.SetLanguage(Session, Request, Response, selectedCountry, null);
            }
            else
            {
                LocalizedLanguages.SetLanguage(Session, Request, Response);
            }
        }


        /// <summary>
        /// Get's the current user session
        /// </summary>
        /// <returns>UserSession instance for current users session</returns>
        protected UserSession GetUserSession()
        {
            return ((UserSession)Session[lib.StringConsts.SESSION_NAME_USER_SESSION]);
        }


        #region URL Parameters

        protected string GetGoogleAnalyticsCode()
        {
            return (WebsiteSettings.Analytics.Google.GoogleAnalytics);
        }

        protected DateTime GetFormValue(string Name, DateTime Default)
        {
            DateTime Result;

            string sDate = GetFormValue(Name, Default.ToString("dd/MM/yyyy"));

            try
            {
                Result = Shared.Utilities.StrToDateTime(sDate, "en-gb");
            }
            catch
            {
                Result = Default;
            }

            return (Result);
        }

        protected bool GetFormValue(string Name, bool Default)
        {
            return (GetFormValue(Name, Default.ToString()) == "True");
        }

        protected string GetFormValue(string Name, string Default)
        {
            if (Request[Name] != null && Request[Name] != String.Empty)
                return (Request[Name]);
            else
                return (Default);
        }

        protected string GetFormValue(string Name)
        {
            return (GetFormValue(Name, String.Empty));
        }

        protected int GetFormValue(string Name, int Default)
        {
            string Value = String.Empty;

            if (Request[Name] != null && Request[Name] != String.Empty)
                Value = Request[Name];
            else
                Value = String.Empty;

            if (Value.IndexOf("#") > 0)
                Value = Value.Substring(0, Value.IndexOf("#"));

            return (Shared.Utilities.StrToIntDef(Value, Default));
        }

        protected Int64 GetFormValue(string Name, Int64 Default)
        {
            string Value = String.Empty;

            if (Request[Name] != null && Request[Name] != String.Empty)
                Value = Request[Name];
            else
                Value = String.Empty;

            if (Value.IndexOf("#") > 0)
                Value = Value.Substring(0, Value.IndexOf("#"));

            return (Shared.Utilities.StrToIntDef(Value, Default));
        }


        #endregion URL Parameters


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

        protected string GetCurrentLanguageName()
        {
            Country country = (Country)Session[lib.StringConsts.SESSION_NAME_WEBSITE_COUNTRY];

            if (country == null)
                return (Thread.CurrentThread.CurrentUICulture.NativeName);
            else
                return (country.LocalizedLanguage);
        }

        protected string GetTermsAndConditions()
        {
            string Result = String.Empty;

            if (WebsiteSettings.AllPages.ShowTermsAndConditions)
                Result = String.Format(" - <a href=\"/Company/Terms-And-Conditions/\">{0}</a>", LanguageStrings.Terms);

            return (Result);
        }

        protected string GetPrivacyPolicy()
        {
            string Result = String.Empty;

            if (WebsiteSettings.AllPages.ShowPrivacyPolicy)
                Result = String.Format(" - <a href=\"/Company/Privacy-Policy/\">{0}</a>", LanguageStrings.Privacy);

            return (Result);
        }

        protected string GetReturnsPolicy()
        {
            string Result = String.Empty;

            if (WebsiteSettings.AllPages.ShowReturnsPolicy)
                Result = String.Format(" - <a href=\"/Company/Returns-Policy/\">{0}</a>", Languages.LanguageStrings.Returns);

            return (Result);
        }

        protected string GetStyleSheet()
        {
            string Result = String.Empty;

            if (WebsiteSettings.UseLeftToRight) // || Request.Path.Contains("/Staff/"))
                Result = String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />",
                    WebsiteSettings.StyleSheet);
            else
                Result = String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />",
                    WebsiteSettings.StyleSheet.Replace(".css", "rtl.css"));

            Result += "\r<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/combined.css\" type=\"text/css\" media=\"screen\" />";

            UserSession session = GetUserSession();

            if (session.MobileRedirect)
                Result = Result.Replace(".css", "_m.css");

            return (Result);
        }

        [Obsolete("Use GetStyleSheet() instead", true)]
        protected string GetSSLStyleSheet()
        {
            if (Request.IsLocal)
            {
                if (WebsiteSettings.UseLeftToRight)
                    return (String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />",
                        WebsiteSettings.StyleSheet));
                else
                    return (String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />",
                        WebsiteSettings.StyleSheet.Replace(".css", "rtl.css")));
            }
            else
            {
                if (WebsiteSettings.UseLeftToRight)
                    return (String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />",
                        WebsiteSettings.StyleSheet));
                else
                    return (String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />", 
                        WebsiteSettings.StyleSheet.Replace(".css", "rtl.css")));
            }
        }

        protected string GetMetaKeyWords()
        {
            string MetaTag = GlobalClass.DefaultMetaKeyWords;

            HashTags tags = HashTags.GetPageTags(Request.Url);
            MetaTag += tags.HashTagList(true) + ", ";
            MetaTag += lib.LibraryHelperClass.MetaKeyWords();

            MetaTag = MetaTag.Trim();

            if (MetaTag.EndsWith(","))
                MetaTag = MetaTag.Substring(0, MetaTag.Length - 1);

            return (MetaTag);
        }

        private static object _featuredProductLockObjct = new object();
        private static TimeSpan _featuredLockTime = new TimeSpan(0, 0, 0, 0, 100);

        protected string GetFeaturedProduct()
        {
            return (GetFeaturedProduct(ProductTypes.Get("All")));
        }

        /// <summary>
        /// Returns the featured product for a primary product type
        /// </summary>
        /// <param name="primaryProductType"></param>
        /// <returns>string</returns>
        protected string GetFeaturedProduct(ProductType primaryProductType)
        {
            UserSession session = GetUserSession();
            int priceColumn = ((LocalWebSessionData)session.Tag).PriceColumn;

            string name = String.Format("featured {0} {1} {2}", 
                SharedWebBase.WebsiteCurrency(Session, Request).CurrencyCode, 
                priceColumn, WebCountry.CountryCode);
            CacheItem featuredCache = Website.Library.GlobalClass.InternalCache.Get(name);

            if (featuredCache != null)
            {
                return ((string)featuredCache.Value);
            }

            string Result = String.Empty;

            try
            {
                using (TimedLock.Lock(_featuredProductLockObjct, _featuredLockTime))
                {
                    Product featured = lib.BOL.Products.Products.GetFeatured();

                    if (featured == null)
                    {
                        Result = "<img src=\"/Images/Product/no_image_148.jpg\" alt=\"\" border=\"0\" />";
                        return (Result);
                    }

                    string image = featured.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_148.jpg";

                    image = LibUtils.ResizeImage(image, 148);

                    Result = String.Format("<a href=\"/Products/Product.aspx?ID={0}\">", featured.ID);

                    Result += String.Format("<img src=\"/Images/Products/{0}\" " +
                        "alt=\"I\" border=\"0\" width=\"148\" height=\"114\"/>", image);

                    if (ShowPriceData)
                    {
                        decimal lowestPrice = featured.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                        if (WebsiteSettings.Tax.PricesIncludeVAT)
                        {
                            lowestPrice += SharedUtils.VATCalculate(lowestPrice, WebVATRate);
                        }

                        if (primaryProductType.ID == ProductTypes.Get("All").ID)
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

                    Website.Library.GlobalClass.InternalCache.Add(name, new CacheItem(name, Result), true);
                }
            }
            catch (Shared.Classes.LockTimeoutException)
            {
                // if we can't lock, then show no featured product
            }

            return (Result);
        }

        /// <summary>
        /// Returns menu if Treatments are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowTreatments()
        {
            if (!WebsiteSettings.AllPages.ShowTreatmentsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Treatments/\">{0}</a></li>", Languages.LanguageStrings.Treatments));
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowSalons()
        {
            if (!WebsiteSettings.AllPages.ShowSalonsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Salons/\">{0}</a></li>", Languages.LanguageStrings.Salons));
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowTipsAndTricks()
        {
            if (!WebsiteSettings.AllPages.ShowTipsAndTricksMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Tips-And-Tricks/\">{0}</a></li>", Languages.LanguageStrings.TipsAndTricks));
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowDistributors()
        {
            if (!WebsiteSettings.AllPages.ShowDistributorsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Distributors/\">{0}</a></li>", LanguageStrings.Distributors));
        }

        protected string ShowTrade()
        {
            if (!WebsiteSettings.AllPages.ShowTradePage)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Trade-Customers/\">{0}</a></li>", LanguageStrings.Trade));
        }

        protected string ShowDownloads()
        {
            if (!WebsiteSettings.AllPages.ShowDownloadMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Download/Index.aspx\">{0}</a></li>", Languages.LanguageStrings.Downloads));
        }

        /// <summary>
        /// Returns the email address used by the website
        /// </summary>
        /// <returns>string - email address</returns>
        protected string WebsiteEmailAddress()
        {
            return (WebsiteSettings.ContactDetails.WebsiteEmail);
        }

        /// <summary>
        /// Returns the postal address used by the website
        /// </summary>
        /// <returns></returns>
        protected string WebsitePostalAddress()
        {
            return (GlobalClass.Address);
        }

        public static void ResetMetaDescriptions()
        {
            GlobalClass.InternalCache.Clear();
        }

        protected virtual string GetMetaDescription()
        {
            string MetaDescription = "";
            string page = "";

            try
            {
                //which page are we looking for?
                page = Request.Url.ToString();

                if (page.Length > 38)
                {
                    page = page.Substring(page.Length - 38);
                }

                string name = String.Format("META_DESCRIPTION {0}", page.ToUpper());

                CacheItem cache = GlobalClass.InternalCache.Get(name);

                if (cache == null)
                {
                    MetaDescription = lib.LibraryHelperClass.SettingsGetMeta(
                        String.Format("DESCRIPTION:{0}", page), String.Empty).Trim();

                    if (String.IsNullOrEmpty(MetaDescription))
                        MetaDescription = lib.LibraryHelperClass.SettingsGetMeta("META_DESCRIPTION", String.Empty);

                    cache = new CacheItem(name, MetaDescription);
                    GlobalClass.InternalCache.Add(name, cache);
                }

                return ((string)cache.Value);
            }
            catch (Exception err)
            {
                lib.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, page, MetaDescription);
                return (lib.LibraryHelperClass.SettingsGetMeta("META_DESCRIPTION", String.Empty));
            }
        }

        protected string GetWebTitle()
        {
            return (String.Empty);//SharedWebBase.GetWebTitle(Request));
        }

        /// <summary>
        /// Gets the website currency, currently being used by the active user
        /// </summary>
        /// <returns></returns>
        protected Currency GetWebsiteCurrency()
        {
            return (SharedWebBase.WebsiteCurrency(Session, Request));
        }

        protected string GetProductCategories()
        {
            User user = GetUser();
            string memberLevel = user == null ? lib.MemberLevel.StandardUser.ToString() : user.MemberLevel.ToString();
            string cacheName = String.Format(lib.Consts.CACHE_NAME_PRODUCT_CATEGORIES, memberLevel, Thread.CurrentThread.CurrentUICulture);

            CacheItem cachedResult = GlobalClass.InternalCache.Get(cacheName);

            if (lib.DAL.DALHelper.AllowCaching && cachedResult == null)
            {
                cachedResult = new CacheItem(cacheName, GetProductCategories(user));
                GlobalClass.InternalCache.Add(cacheName, cachedResult);
            }


            if (cachedResult != null)
                return ((string)cachedResult.Value);
            else
                return (GetProductCategories(user));
        }

        protected string GetProductCategories(User user)
        {
            string Result = String.Empty;
            ProductGroups groups = ProductGroups.Get(user == null ? lib.MemberLevel.StandardUser : user.MemberLevel, true);
            ProductGroupType prodTypeOther = ProductGroupTypes.Get("General") ?? ProductGroupTypes.Get()[0];

            foreach (ProductGroup group in groups)
            {
                string translatedName = GetTranslatedDescription(group.Description);
                string groupColor = group.GroupType.Description.Replace(" ", "");
                string description = group.GroupType.ID == prodTypeOther.ID ? translatedName : String.Format("<span class=\"prodGroupFontSmall\">{0}</span><span class=\"prodGroupLineHeightSmall\" style=\"height: 5px;\"></span><span class=\"prodGroupFontLarge\">{1}</span>", group.SubHeader, group.MainHeader.ToUpper());

                if (String.IsNullOrEmpty(group.URL))
                {
                    Result += String.Format("<li class=\"{3}\"><a href=\"{2}/All-Products/Group/{0}/\">{1}</a></li>\r\n",
                        group.SEODescripton, description, WebsiteSettings.RootURL, groupColor);
                }
                else
                {
                    Result += String.Format("<li class=\"{2}\"><a href=\"{0}\">{1}</a></li>\r\n",
                        group.URL, description, groupColor);
                }
            }

            return (Result);
        }

        /// <summary>
        /// Attempts to translate a string
        /// </summary>
        /// <param name="stringToTranslate">String to translate</param>
        /// <returns>If a translation exists returns the translated text, otherwise returns the original text</returns>
        public string GetTranslatedDescription(string stringToTranslate)
        {
            string Result = null;

            // if the string starts with a number, remove the number and try and translate what's left
            if (SharedUtils.StartsWithNumber(stringToTranslate))
            {
                string num = stringToTranslate;

                if (stringToTranslate.Contains(" "))
                    num = stringToTranslate.Substring(0, stringToTranslate.IndexOf(" "));

                Result = LanguageStrings.ResourceManager.GetString(stringToTranslate.Substring(num.Length).Replace(" ", ""), Thread.CurrentThread.CurrentUICulture);

                if (!String.IsNullOrEmpty(Result))
                    Result = String.Format("{0} {1}", num, Result);
            }
            else
            {
                //get a translation
                Result = LanguageStrings.ResourceManager.GetString(stringToTranslate.Replace(" ", ""), Thread.CurrentThread.CurrentUICulture);
            }

            // if we still can't translate then return the string that came in
            if (String.IsNullOrEmpty(Result))
                Result = stringToTranslate;

            return (Result);
        }

        protected string BasketInfo()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            ShoppingBasket basket = localData.Basket;

            decimal Cost = 0.00m;

            if (basket != null && basket.HasItems())
                Cost = basket.TotalAmount;

            string Result = String.Format("{2}: {0} <strong>{1}</strong>", basket == null ? 0 : basket.Items.Count,
                SharedUtils.FormatMoney(Cost, GetWebsiteCurrency(), false),
                Languages.LanguageStrings.Items);

            return (Result);
        }

        protected long GetUserID()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

            if (localData.CurrentUser == null)
                return (-1);
            else
                return (localData.CurrentUser.ID);
        }

        /// <summary>
        /// Returns the current year
        /// </summary>
        /// <returns></returns>
        protected string CurrentYear()
        {
            return (DateTime.Now.Year.ToString());
        }

        #endregion Protected Methods

        private static lib.LibraryHelperClass _Web;
        

        public lib.LibraryHelperClass Web
        {
            get
            {
                if (_Web == null)
                    _Web = new lib.LibraryHelperClass();

                return (_Web);
            }
        }

        protected void DoRedirect(string URL, bool EndResponse)
        {
            try
            {
                Response.Redirect(URL, EndResponse);
            }
            catch (Exception err)
            {
                if (err.Message.Contains("Cannot use a leading .. to exit above the top directory"))
                {
                    lib.WebsiteAdministration.AutoBanIPAddress(Request.Path, Request.UserHostAddress, true);
                    Response.Redirect("/Error/IPIsBanned.aspx", true);
                }
            }
        }


        #region Private Methods

        #endregion Private Methods

        #region Properties

        protected Country WebCountry
        {
            get
            {
                return (SharedWebBase.WebCountry(Session, Request));
            }
        }

        protected decimal WebConversionRate
        {
            get
            {
                decimal Result = 1.0m;

                Currency currency = SharedWebBase.WebsiteCurrency(Session, Request);

                if (currency != null)
                {
                    Result = currency.ConversionRate;
                }

                return (Result);
            }
        }

        protected bool ShowPriceData
        {
            get
            {
                string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
                    ipAddress = GetFormValue("FakeAddress", ipAddress);
#endif

                Country country = Countries.Get(lib.LibraryHelperClass.IPAddressToCountry(ipAddress));

                if (country != null)
                    return (country.ShowPriceData());
                else
                    return (WebsiteSettings.ShoppingCart.DefaultShowPrices);
            }
        }

        protected User GetUser()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.CurrentUser);
        }

        protected bool UserIsLoggedOn()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.CurrentUser != null);
        }


        protected CultureInfo WebCulture
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (new CultureInfo(localData.Culture));
            }
        }


        public double WebVATRate
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (localData.VATRate);
            }
        }

        public string CountryCode
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (localData.CountryCode);
            }
        }

        protected string GetURL()
        {
            return (Request.Url.ToString());
        }

        #endregion Properties

        [Obsolete("No longer used")]
        public void AddToWebLog(string Value, string SubValue)
        {
            AddToWebLog("DEBUG", Value, "");
        }

        [Obsolete("No longer used")]
        public void AddToWebLog(string Method, string Value, string SubValue)
        {
            string Referrer = "";
            
            if (Request.UrlReferrer != null)
                Referrer = Request.UrlReferrer.ToString();

            if (Referrer.Length > 255)
                Referrer = Referrer.Substring(0, 255);

            string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
            ipAddress = GetFormValue("FakeAddress", ipAddress);
#endif
        }

    }
}
