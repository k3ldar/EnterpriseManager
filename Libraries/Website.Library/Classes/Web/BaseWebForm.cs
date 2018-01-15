using System;
using System.Globalization;
using System.Threading;
using System.Web.UI.HtmlControls;
using System.Web;

using Languages;

using Shared.Classes;

using lib = Library;
using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Countries;
using Library.BOL.Products;
using Library.BOL.Basket;
using Library.BOL.Treatments;
using Library.BOL.Campaigns;
using Library.BOL.HashTags;
using Library.BOL.Orders;
using Library.BOL.Search;
using Library.BOL.CustomWebPages;
using Library.BOL.Helpdesk;

namespace Website.Library.Classes
{
    /// <summary>
    /// Base class for all web forms
    /// </summary>
    public class BaseWebForm : System.Web.UI.Page
    {

        #region Private / Protected Members

        private bool _IPIsBanned = false;
        private int _BanType = 1;
        private static lib.LibraryHelperClass _Web;

        private static string _carouselText = Languages.LanguageStrings.CheckOutLatestGreatest;

        #endregion Private / Protected Members

        /// <summary>
        /// Get's the current user session
        /// </summary>
        /// <returns>UserSession instance for current users session</returns>
        protected UserSession GetUserSession()
        {
            try
            {
                return ((UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION]);
            }
            catch (Exception err)
            {
                string msg = String.Format("Exception Get User Session {0}\r\n" +
                    "Session {1}\r\nSession ID {2}",
                    err.Message,
                    Session == null ? "No Session" : Session.ToString(),
                    Session == null ? "No Session" :
                        String.IsNullOrEmpty(Session.SessionID) ? "Session ID is Null" : Session.SessionID);
                Shared.EventLog.Add(msg);
            }

            return (null);
        }

        protected string GetAffiliateID()
        {
            UserSession sesssion = GetUserSession();

            if (sesssion == null)
                return (String.Empty);

            LocalWebSessionData local = (LocalWebSessionData)sesssion.Tag;

            if (local == null)
                return (String.Empty);

            return (local.AffiliateID);
        }

        protected int GetScrollCount(int defaultValue = 3)
        {
            if (GetUserSession().MobileRedirect)
                return (1);
            else
                return (defaultValue);
        }

        private void RegisterPageView(UserSession userSession, string url, string request, bool isPostback, int attempt = 0)
        {
            if (userSession == null)
                return;

            if (url.Length > 999)
                url = url.Substring(0, 998);

            try
            {
                userSession.PageView(url, request, isPostback);
            }
            catch (Exception err)
            {
                if (attempt < 10)
                {
                    RegisterPageView(userSession, url, request, isPostback, attempt + 1);
                }
                else
                {
                    if (!err.Message.Contains("The hostname could not be parsed"))
                        Shared.EventLog.Add(err, userSession == null ? "Session not known" : userSession.SessionID);
                }
            }
        }

        protected string GroupBreadCrumb(KBGroup group)
        {
            string Result = String.Format("<li><a href=\"/Help-Desk/FAQ/FAQ.aspx?GroupID={0}\">{1}</a></li>", group.ID, group.Name);
            KBGroup root = group;

            while (root.Parent != null)
            {
                root = root.Parent;
                Result = String.Format("<li><a href=\"/Help-Desk/FAQ/FAQ.aspx?GroupID={2}\">{0}</a></li><li>&rsaquo;</li>{1}", root.Name, Result, root.ID);
            }

            return (Result);
        }

        protected override void OnLoad(EventArgs e)
        {
            RegisterPageView(GetUserSession(), Request.Url.ToString(), GetReferrer(Request), IsPostBack);

            base.OnLoad(e);

            if (Website.Library.Classes.BaseWebApplication.StaticWebSite)
            {
                return;
            }
        }

        #region Properties

        public bool IgnoreWebLog { get; set; }

        public lib.LibraryHelperClass Web
        {
            get
            {
                if (_Web == null)
                    _Web = new lib.LibraryHelperClass();

                return (_Web);
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

        public string WebCurrency
        {
            get
            {
                string Result = NVPAPICaller.DefaultCurrency;

                //if (CountryCode == "US" || CountryCode == "ZZ")
                //    Result = "USD";

                return (Result);
            }
        }

        public CultureInfo WebCulture
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (new CultureInfo(localData.Culture));
            }
        }

        public decimal WebConversionRate
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

        public string CountryCode
        {
            get
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                return (localData.CountryCode);
            }
        }

        public Country WebCountry
        {
            get
            {
                return (SharedWebBase.WebCountry(Session, Request));
            }
        }

        #endregion Properties

        #region Constructors / Destructors

        public BaseWebForm()
        {

        }


        #endregion Constructors / Destructors

        protected string GetReferrer(HttpRequest request)
        {
            try
            {
                return (Request.UrlReferrer == null ? String.Empty : Request.UrlReferrer.ToString());
            }
            catch
            {
                return (string.Empty);
            }
        }

        protected string GetMailChimpPopupIntegration()
        {
            return (BaseWebApplication.MailChimpPopupDialog);
        }

        /// <summary>
        /// Gets the website currency, currently being used by the active user
        /// </summary>
        /// <returns></returns>
        protected Currency GetWebsiteCurrency()
        {
            return (SharedWebBase.WebsiteCurrency(Session, Request));
        }


        protected string GetBuyitNowCSSLink()
        {
            string Result = "/css/buyitnow.css";

            if (GetUserSession().MobileRedirect)
                Result = "/css/buyitnow_m.css";

            return (Result);
        }

        /// <summary>
        /// Returns the email address used by the website
        /// </summary>
        /// <returns>string - email address</returns>
        protected string WebsiteEmailAddress()
        {
            return (BaseWebApplication.WebsiteEmail);
        }

        /// <summary>
        /// Returns the postal address used by the website
        /// </summary>
        /// <returns></returns>
        protected string WebsitePostalAddress()
        {
            return (GlobalClass.Address);
        }

        /// <summary>
        /// Returns the current year
        /// </summary>
        /// <returns></returns>
        protected string CurrentYear()
        {
            return (DateTime.Now.Year.ToString());
        }


        protected void UpdateCustomTranslatedPageData(string name, HtmlGenericControl control, bool hideIfEmpty = true)
        {
            CustomPage page = CustomPages.Get(name);

            if (page != null && page.IsActive)
                control.InnerHtml = page.PageText;

            if (hideIfEmpty)
                control.Visible = !String.IsNullOrEmpty(control.InnerHtml.Trim());
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
                int length = stringToTranslate.IndexOf(" ");
                string num = stringToTranslate.Substring(0, length == -1 ? stringToTranslate.Length : length);

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

        /// <summary>
        /// Pay for an order using Pay Point
        /// </summary>
        /// <param name="order">order being paid for</param>
        public void PayByPayPoint(Order order)
        {
            if (UserIsLoggedOn())
            {
                if (order == null)
                    throw new Exception("Invalid Order, can not find order during payment (Paypoint)");

                if (order != null)
                {
                    Country country = Countries.Get(GetUserCountry());

                    string amt = SharedUtils.FormatMoney(order.TotalCost, GetWebsiteCurrency());

                    if (amt == SharedUtils.FormatMoney(Countries.Get(GetUserCountry()).ShippingCosts,
                        GetWebsiteCurrency()))
                        throw new Exception("Error with order, shipping cost only detected!");


                    if (order.TotalCost != 0.00m)
                    {
                        Website.Library.Classes.Paypoint.ValCard vc = new Website.Library.Classes.Paypoint.ValCard(
                            GetUser(), order.ID.ToString(), SharedUtils.StrToDbl(amt), "GBP");

                        string ret;
                        ret = vc.GetURL();
                        Response.Redirect(ret, true);
                    }
                }
            }
            else
                DoRedirect("/Shopping/Basket/SignIn/");
        }

        protected string GetWebsiteTelephoneNumber()
        {
            return (BaseWebApplication.WebsiteTelephoneNumber);
        }

        protected string GetExtraBasketInformation()
        {
            //<p>Please note, due to unprecedented demand there is currently a 21 day delay in the dispatch of orders.</p>
            return (String.Empty);
        }

        protected string GetWebsiteDateFormat()
        {
            return (GlobalClass.WebsiteDateFormat);
        }

        protected string GetWebsiteAddress()
        {
            return (GlobalClass.Address);
        }

        public string GetBlogURL()
        {
            return (BaseWebApplication.BlogURL);
        }

        protected string DoSearch(string searchTerms, bool useAnd)
        {
            string terms = searchTerms;

            MemberLevel memberLevel = (MemberLevel)GetUsersMemberLevel();
            lib.BOL.Search.Search searchResult = lib.BOL.Search.Search.SubmitSearch(memberLevel, terms, useAnd);
            string results = String.Empty;


            foreach (SearchItem item in searchResult)
            {
                string link = "";

                switch (item.Type)
                {
                    case Enums.SearchResultType.Celebrities:
                        link = String.Format("/Celebrities/ViewCeleb.aspx?ID={0}", item.ID);
                        break;

                    case Enums.SearchResultType.Feedback:
                        link = String.Format("/Help-Desk/Feedback/{0}/", item.ID);
                        break;

                    case Enums.SearchResultType.HashTags:
                        link = item.URL.ToLower();
                        break;

                    case Enums.SearchResultType.KnowledgeBase:
                        link = String.Format("/Help-Desk/Frequently-Asked-Questions/View/{0}/{1}/", item.ID, item.Description);
                        break;

                    case Enums.SearchResultType.Products:
                        Product product = Products.Get(item.ID);

                        if (product == null)
                            throw new NullReferenceException(nameof(product));

                        if (String.IsNullOrEmpty(item.URL))
                            link = String.Format("/All-Products/Group/{0}/{1}/",
                                product.PrimaryGroup.SEODescripton, product.NameSEO);
                        else
                            link = String.Format("{0}", item.URL);

                        break;

                    case Enums.SearchResultType.Salons:
                        link = String.Format("/Salons/?ID={0}", item.ID);
                        break;

                    case Enums.SearchResultType.Treatments:
                        link = String.Format("/Treatments/Group/{0}/", item.ID);
                        break;

                    default:
                        throw new Exception("Invalid SearchResult Type");
                }

                results += String.Format("<li><h3>{0}</h3><div class=\"searchType\">{1}</div><div><a href=\"{2}\" style=\"    font-size: 1.4em;\">{0}</a></div></li>",
                    item.Description, SharedUtils.SplitCamelCase(item.Type.ToString()), link);
            }

            return (results);
        }

        public string GetRedirectURL()
        {
            string Result = "";

            Country country = Countries.Get(GetUserCountry());

            if (country != null && country.AutoRedirect != String.Empty)
            {
                Result = country.AutoRedirect;
            }

            return (Result);
        }

        #region Professional

        protected string GetTreatmentGroupTagLine()
        {
            if (Page.RouteData.Values["group"] == null)
                return (String.Empty);

            string s = (string)Page.RouteData.Values["group"];

            TreatmentGroup group = TreatmentGroups.Get(GetFormValue("GroupID", -1));

            if (group != null)
            {
                if (group.TagLine.Trim() != "")
                    return (String.Format("<h4>{0}</h4>", group.TagLine.Trim()));
            }

            return (String.Empty);
        }

        protected string GetCarouselText()
        {
            return (_carouselText);
        }

        protected string GetCarouselProducts()
        {
            string currency = GetWebsiteCurrency().CurrencyCode;

            CacheItem cachedResult = GlobalClass.InternalCache.Get(String.Format(Consts.CACHE_NAME_CAROUSEL, currency, Thread.CurrentThread.CurrentUICulture));

            if (lib.DAL.DALHelper.AllowCaching && cachedResult == null)
            {
                Products carousel = Products.GetCarousel();
                cachedResult = new CacheItem(String.Format(Consts.CACHE_NAME_CAROUSEL, currency,
                    Thread.CurrentThread.CurrentUICulture), GetCarouselProducts(carousel));
                GlobalClass.InternalCache.Add(String.Format(Consts.CACHE_NAME_CAROUSEL, currency,
                    Thread.CurrentThread.CurrentUICulture), cachedResult);
            }


            if (cachedResult != null)
            {
                return ((string)cachedResult.Value);
            }
            else
            {
                Products carousel = Products.GetCarousel();
                return (GetCarouselProducts(carousel));
            }
        }

        protected string GetCarouselProducts(Products carousel)
        {
            string Result = "";

            // rebuild the carousel for the country

            if (BaseWebApplication.CustomScrollerStrapLine)
                _carouselText = BaseWebApplication.CustomScrollerText;

            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            foreach (Product product in carousel)
            {
                string image = product.Image.ToLower();

                if (!image.Contains(".png") && !image.Contains(".jpg"))
                    image += "_200.jpg";

                image = LibUtils.ResizeImage(image, 200);
                string item = String.Format("<li>\r<a href=\"/Products/Product.aspx?ID={0}\">\r", product.ID);

                item += String.Format("<img src=\"/Images/Products/{0}\" alt=\"I\" border=\"0\" width=\"200\" height=\"145\"/>\r", image);

                if (product.NewProduct)
                    item += String.Format("<span class=\"new\" style=\"display:block;\">{0}</span>\r", LanguageStrings.NewProduct);
                //else
                //    item += "<span class=\"new\">new product</span>\r";

                if (!product.NewProduct && product.BestSeller)
                    item += String.Format("<span class=\"best\" style=\"display:block;\">{0}</span>\r", LanguageStrings.BestSeller);
                //else
                //    item += "<span class=\"best\">best seller</span>\r";

                if (ShowPriceData)
                {
                    decimal lowestPrice = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                    if (BaseWebApplication.PricesIncludeVAT)
                    {
                        lowestPrice += SharedUtils.VATCalculate(lowestPrice, WebVATRate);
                    }

                    item += String.Format("<br /><div class=\"textDirection\">{0}<strong>{2} {1}</strong></div>\r</a>\r</li>\r",
                        product.Name,
                        SharedUtils.FormatMoney(lowestPrice, GetWebsiteCurrency(), false),
                        LanguageStrings.From);
                }
                else
                {
                    item += String.Format("<br /><div class=\"textDirection\">{0}</div>\r</a>\r</li>\r", product.Name);
                }

                if (product.ShowOnWebsite)
                    Result += item;
            }

            return (Result);
        }

        protected string GetProductsStratosphere(ProductType primaryProductType, int size)
        {
            string Result = "";

            Products products = Products.Get(primaryProductType, GetFormValue("Page", 1), 12);
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            foreach (Product product in products)
            {
                if (TreatAsStratosphereProduct(product.PrimaryProduct))
                {
                    string PriceFrom = "";

                    if (ShowPriceData)
                    {
                        decimal priceFrom = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                        if (priceFrom == 1000000.0m)
                            continue;

                        if (BaseWebApplication.PricesIncludeVAT)
                        {
                            priceFrom += SharedUtils.VATCalculate(priceFrom, WebVATRate);
                        }

                        PriceFrom = String.Format("<strong>{1} {0}</strong>",
                            SharedUtils.FormatMoney(priceFrom, GetWebsiteCurrency(), false),
                            LanguageStrings.From);
                    }

                    string image = product.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_178.jpg";

                    image = LibUtils.ResizeImage(image, size);

                    Result += String.Format("<li class=\"professional\"><a href=\"/Products/stratosphere.aspx?ID={0}\"><img src=\"/Images/Products/{1}\" alt=\"I\" border=\"0\" width=\"178\" height=\"128\"/>" +
                        "<span class=\"new\" {5}>{6}</span><span class=\"best\" {4}>{7}</span>{2}{3}</a></li>\r\n",
                        product.ID, image, product.Name, PriceFrom,
                        product.BestSeller ? " style=\"display:block;\"" : "", product.NewProduct ? " style=\"display:block;\"" : "",
                        LanguageStrings.NewProduct, LanguageStrings.BestSeller);
                }
            }

            return (Result);
        }

        protected bool TreatAsStratosphereProduct(ProductType primaryProductType)
        {
            bool Result = false;

            switch (primaryProductType.Description)
            {
                case "Stratosphere":
                case "MensHeaven":
                    Result = true;
                    break;
            }

            return (Result);
        }

        protected string GetProductsStratosphere(int ProductGroupID, int size)
        {
            string Result = "";
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            if (ProductGroupID == -1)
                Result = GetProductsStratosphere(ProductTypes.Get("Stratosphere"), size);
            else
            {
                ProductGroup group = ProductGroups.Get(ProductGroupID);
                Products products = Products.Get(ProductTypes.Get("Stratosphere"), GetFormValue("Page", 1), 12, group);

                foreach (Product product in products)
                {
                    string PriceFrom = "";

                    if (ShowPriceData)
                    {
                        decimal priceFrom = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                        if (priceFrom == 1000000.0m)
                            continue;

                        if (BaseWebApplication.PricesIncludeVAT)
                        {
                            priceFrom += SharedUtils.VATCalculate(priceFrom, WebVATRate);
                        }

                        PriceFrom = String.Format("<strong>{1} {0}</strong>",
                            SharedUtils.FormatMoney(priceFrom, GetWebsiteCurrency(), false),
                            LanguageStrings.From);
                    }

                    string image = product.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_178.jpg";

                    image = LibUtils.ResizeImage(image, size);

                    Result += String.Format("<li class=\"professional\"><a href=\"/Products/stratosphere.aspx?ID={0}\"><img src=\"/Images/Products/{1}\" alt=\"I\" border=\"0\" width=\"178\" height=\"128\"/>" +
                        "<span class=\"new\" {5}>{6}</span><span class=\"best\" {4}>{7}</span>{2}{3}</a></li>\r\n",
                        product.ID, image, product.Name, PriceFrom,
                        product.BestSeller ? " style=\"display:block;\"" : "", product.NewProduct ? " style=\"display:block;\"" : "",
                        LanguageStrings.NewProduct, LanguageStrings.BestSeller);
                }
            }

            return (Result);
        }

        protected string GetProductGroupProfessional()
        {
            string Result = "";

            ProductGroup group = ProductGroups.Get(GetFormValue("GroupID", -1));

            if (group != null)
            {
                Result = String.Format("<li>&rsaquo;</li>\r\n<li><a href=\"/All-Products/Group/{0}/\">{1}</a></li>", 
                    group.SEODescripton, group.Description);
            }

            return (Result);
        }


        protected string GetProductsProfessional(ProductType primaryProductType, int size)
        {
            string Result = "";
            ProductType professionalGroup = ProductTypes.Get("Professional");
            lib.BOL.Products.Products products = lib.BOL.Products.Products.Get(professionalGroup, GetFormValue("Page", 1), 12);
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            foreach (Product product in products)
            {
                if (product.PrimaryProduct.ID == professionalGroup.ID)
                {
                    string PriceFrom = "";

                    if (ShowPriceData)
                    {
                        decimal priceFrom = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                        if (BaseWebApplication.PricesIncludeVAT)
                        {
                            priceFrom += SharedUtils.VATCalculate(priceFrom, WebVATRate);
                        }

                        PriceFrom = String.Format("<strong>{1} {0}</strong>",
                            SharedUtils.FormatMoney(priceFrom, GetWebsiteCurrency(), false),
                            LanguageStrings.From);
                    }

                    string image = product.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_178.jpg";

                    image = LibUtils.ResizeImage(image, size);

                    Result += String.Format("<li><a href=\"/Products/Product.aspx?ID={0}\"><img src=\"/Images/Products/{1}\" alt=\"I\" border=\"0\" width=\"178\" height=\"128\"/>" +
                        "<span class=\"new\" {5}>{6}</span><span class=\"best\" {4}>{7}</span>{2}{3}</a></li>\r\n",
                        product.ID, image, product.Name, PriceFrom,
                        product.BestSeller ? " style=\"display:block;\"" : "", product.NewProduct ? " style=\"display:block;\"" : "",
                        LanguageStrings.NewProduct, LanguageStrings.BestSeller);
                }
            }

            return (Result);
        }

        protected string GetProductsProfessional(int ProductGroupID, int size)
        {
            Country localCountry = WebCountry;
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            ProductType professionalGroup = ProductTypes.Get("Professional");
            string Result = "";

            if (ProductGroupID == -1)
                Result = GetProductsProfessional(professionalGroup, size);
            else
            {
                ProductGroup group = ProductGroups.Get(ProductGroupID);
                Products products = Products.Get(professionalGroup, GetFormValue("Page", 1), 12, group);

                foreach (Product product in products)
                {
                    string PriceFrom = "";

                    if (ShowPriceData)
                    {
                        decimal priceFrom = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                        if (priceFrom > 999999.0m)
                        {
                            continue;
                        }

                        if (BaseWebApplication.PricesIncludeVAT)
                        {
                            priceFrom += SharedUtils.VATCalculate(priceFrom, WebVATRate);
                        }

                        PriceFrom = String.Format("<strong>{1} {0}</strong>",
                            SharedUtils.FormatMoney(priceFrom, GetWebsiteCurrency(), false),
                            LanguageStrings.From);
                    }

                    string image = product.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_178.jpg";

                    image = LibUtils.ResizeImage(image, size);

                    Result += String.Format("<li class=\"professional\"><a href=\"/Products/Product.aspx?ID={0}\"><img src=\"/Images/Products/{1}\" alt=\"I\" border=\"0\" width=\"178\" height=\"128\"/>" +
                        "<span class=\"new\" {5}>{6}</span><span class=\"best\" {4}>{7}</span>{2}{3}</a></li>\r\n",
                        product.ID, image, product.Name, PriceFrom,
                        product.BestSeller ? " style=\"display:block;\"" : "", product.NewProduct ? " style=\"display:block;\"" : "",
                        LanguageStrings.NewProduct, LanguageStrings.BestSeller);
                }
            }

            return (Result);
        }

        #endregion Professional

        #region HTML Table wrapper functions

#if TABLE_WRAPPERS

        protected HtmlTable CreateTable(string ClassName, int CellSpacing)
        {
            HtmlTable Result = new HtmlTable();
            Result.Attributes.Add("class", ClassName);
            Result.CellPadding = 0;
            Result.CellSpacing = CellSpacing;
            Result.Border = 0;
            Result.Width = "100%";

            return (Result);
        }


        protected HtmlTableRow CreateRow(HtmlTable Table)
        {
            return (CreateRow(Table, String.Empty, 0));
        }


        protected HtmlTableRow CreateRow(HtmlTable Table, string ClassName)
        {
            return (CreateRow(Table, ClassName, 0));
        }


        protected HtmlTableRow CreateRow(HtmlTable Table, string ClassName, int Height)
        {
            HtmlTableRow Result = new HtmlTableRow();

            if (ClassName != String.Empty)
                Result.Attributes.Add("class", ClassName);

            if (Height != 0)
                Result.Height = Height.ToString();

            Table.Rows.Add(Result);

            return (Result);
        }

#endif


        protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, string Text)
        {
            return (CreateCell(Row, ClassName, CellAlign.Left, 0, Text, false));
        }

        protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, string Text, bool IsHTML)
        {
            return (CreateCell(Row, ClassName, CellAlign.Left, 0, Text, IsHTML));
        }

        protected HtmlTableCell CreateCell(HtmlTableRow Row, string Text)
        {
            return (CreateCell(Row, String.Empty, CellAlign.Left, 0, 0, Text, false));
        }


        protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, CellAlign Alignment,
            int Width, string Text, bool IsHTML)
        {
            return (CreateCell(Row, ClassName, Alignment, Width, 0, Text, IsHTML));
        }


        protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, CellAlign Alignment,
            int Width, string Text)
        {
            return (CreateCell(Row, ClassName, Alignment, Width, 0, Text, false));
        }


        protected HtmlTableCell CreateCell(HtmlTableRow Row, string ClassName, CellAlign Alignment,
            int Width, int Height, string Text, bool IsHTML)
        {
            HtmlTableCell Result = new HtmlTableCell();

            if (ClassName != String.Empty)
                Result.Attributes.Add("class", ClassName);

            // alignment
            Result.Align = Alignment.ToString();

            if (Width != 0)
                Result.Width = Width == -1 ? "100%" : Width.ToString();

            if (Height != 0)
                Result.Height = Height.ToString();

            if (IsHTML || Text == String.Empty)
                Result.InnerHtml = Text == String.Empty ? "&nbsp;" : Text;
            else
                Result.InnerText = Text;

            // add the cell to the row
            Row.Cells.Add(Result);

            return (Result);
        }


        #endregion HTML Table wrapper functions

        #region Cookie management

        protected string CookieGetValue(string CookieName, string Default)
        {
            return (SharedWebBase.CookieGetValue(Request, Response, CookieName, Default));
        }


        #endregion Cookie management

        #region Virtual Methods

        protected virtual void Localize()
        {
        }

        #endregion Virtual Methods

        #region Protected Methods

        #region Treatments Page

        protected int GetTreatmentGroupID()
        {
            return (SharedUtils.StrToInt((string)Page.RouteData.Values["group"], -1));
        }

        protected int GetTreatmentPage()
        {
            return (SharedUtils.StrToInt((string)Page.RouteData.Values["page"], 1));
        }

        protected string GetTreatments(int PageSize)
        {
            string Result = "";
            Treatments treats;

            TreatmentGroup group = TreatmentGroups.Get(GetTreatmentGroupID());

            if (group == null)
                treats = Treatments.Get(GetTreatmentPage(), PageSize);
            else
                treats = Treatments.Get(GetTreatmentPage(), PageSize, group);

            int i = 1;

            foreach (Treatment treat in treats)
            {
                Result += BuildTreatment(treat, i < PageSize);
                i++;
            }

            return (Result);
        }

        protected string GetProductGroupTagLine()
        {
            lib.MemberLevel level = lib.MemberLevel.StandardUser;

            if (GetUser() != null)
                level = GetUser().MemberLevel;

            string keyName = String.Format("{0}{1}", 
                level.ToString(), 
                (string)Page.RouteData.Values["group"] ?? String.Empty);

            long groupID = -1;

            if (BaseWebApplication.AllRoutes.ContainsKey(keyName))
                groupID = BaseWebApplication.AllRoutes[keyName];

            ProductGroup group = ProductGroups.Get(groupID);

            if (group != null)
            {
                if (group.TagLine.Trim() != "")
                    return (String.Format("<h4 class=\"{1}\">{0}</h4>", group.TagLine.Trim(), group.GroupType.Description.Trim()));
            }

            return (String.Empty);
        }

        private string BuildTreatment(Treatment treatment, bool AddLine)
        {
            string Result = "";

            string TreatmentPrice = "";

            if (treatment.Price != "")
                TreatmentPrice += String.Format("<strong>{1}: </strong>{0}<br />", treatment.Price, Languages.LanguageStrings.Price);

            string TreatmentLength = "";

            if (treatment.TreatmentLength != "")
                TreatmentLength = String.Format("<strong>{1}: </strong>{0} **<br />",
                    treatment.TreatmentLength, Languages.LanguageStrings.TreatmentLength);

            string MoreInfo = "";

            if (treatment.URL != "")
                MoreInfo = String.Format("<strong><a href=\"{0}\" >{1}</a></strong><br />", treatment.URL, Languages.LanguageStrings.ClickForInfo);


            Result += String.Format("<ul class=\"treatmentList\"><li><h3>{0}</h3>", treatment.Name);

            Result += String.Format("<div class=\"treatmentImg\"><img src=\"/images/Treatments/{0}\" alt=\"{1}\" width=\"130\" /></div>", treatment.Image == "" ? "blank.png" : treatment.Image, treatment.Name);

            Result += String.Format("<div class=\"treatmentDetails\">{1}{2}<br />{0}<br /><br />{3}</div>", SharedUtils.PreProcessPost(GlobalClass.RootURL, treatment.Description), TreatmentPrice, TreatmentLength, MoreInfo);

            Result += "<div class=\"clear\"></div></li></ul>";

            if (AddLine)
                Result += "<hr />";

            return (Result);

        }

        protected string GetTreatmentGroup()
        {
            string Result = "";

            TreatmentGroup group = TreatmentGroups.Get(GetFormValue("GroupID", -1));

            if (group != null)
            {
                Result = String.Format("<li>&rsaquo;</li>\r\n<li><a href=\"/Treatments/Group/{0}/\">{1}</a></li>", group.ID, group.Description);
            }

            return (Result);
        }

        protected string GetTreatmentCategories()
        {
            string Result = "";
            int Current = GetFormValue("GroupID", 1);

            TreatmentGroups groups = TreatmentGroups.Get();

            foreach (TreatmentGroup group in groups)
            {
                if (group.ID == Current)
                    Result += String.Format("<li class=\"current\"><a href=\"/Treatments/Group/{0}/\">{1}</a></li>\r\n", group.ID, group.Description);
                else
                    Result += String.Format("<li><a href=\"/Treatments/Group/{0}/\">{1}</a></li>\r\n", group.ID, group.Description);
            }
            return (Result);
        }

        #endregion Treatments Page

        protected string GetHomePageImages(int width = 0, int height = 0, bool auto = false)
        {
            UserSession session = (UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION];

            if (auto && width > 0)
            {
                if (session.MobileRedirect)
                {
                    width = 300;
                    height = 126;
                }
                else
                {
                    width = 700;
                    height = 320;
                }
            }

            string Result = "";

            // static home page images
            Result += GetNivoBannerLink(BaseWebApplication.HomeBanner1, auto, width, height);

            Result += GetNivoBannerLink(BaseWebApplication.HomeBanner2, auto, width, height);

            Campaigns currentCampaigns = Campaign.GetActive(lib.BOL.Countries.Countries.Get(GetUserCountry()));

            foreach (Campaign currentCampaign in currentCampaigns)
            {
                if (currentCampaign != null)
                {
                    if (!String.IsNullOrEmpty(currentCampaign.ImageMainPage))
                    {
                        if (width > 0 && height > 0 && (width != 700 && height != 320))
                        {
                            Result += String.Format("<a href=\"{2}{3}cmp={0}\" title=\"{0}\"><img src=\"/Controls/ImageResize.aspx?image={1}&width={4}&height={5}\" alt=\"{0}\" style=\"width:700px;height:320px;\" />" +
                                "</a>", currentCampaign.CampaignName, currentCampaign.ImageMainPage, currentCampaign.WebLink,
                                currentCampaign.WebLink.Contains("?") ? "&" : "?", width, height);
                        }
                        else
                        {
                            Result += String.Format("<a href=\"{2}{3}cmp={0}\" title=\"{0}\"><img src=\"{1}\" alt=\"{0}\" style=\"width:700px;height:320px;\" />" +
                                "</a>", currentCampaign.CampaignName, currentCampaign.ImageMainPage, currentCampaign.WebLink,
                                currentCampaign.WebLink.Contains("?") ? "&" : "?");
                        }
                    }
                }
            }

            // static home page images
            Result += GetNivoBannerLink(BaseWebApplication.HomeBanner3, auto, width, height);

            Result += GetNivoBannerLink(BaseWebApplication.HomeBanner4, auto, width, height);

            Result += GetNivoBannerLink(BaseWebApplication.HomeBanner5, auto, width, height);

            if (!Request.IsLocal && Request.IsSecureConnection)
                Result = Result.ToLower().Replace("http://", "https://");

            if (session.MobileRedirect)
            {
                Result = Result.Replace("style=\"width:700px;height:320px;\"", "style=\"width:280px;height:128px;\"");
            }

            return (Result);
        }

        private string GetNivoBannerLink(string url, bool isResize, int width, int height)
        {
            if (String.IsNullOrEmpty(url))
                return (String.Empty);

            if (isResize && (width != 700 && height != 320))
                return (String.Format("<img src=\"/Controls/ImageResize.aspx?image={0}&width={1}&height={2}\" alt=\"\" width=\"{1}\" height=\"{2}\" />",
                    url, width, height));
            else
                return (String.Format("<img src=\"{0}\" alt=\"\" width=\"{1}\" height=\"{2}\" />", url, 700, 320));
        }

        private string CreateHomeImage(string url, string title, string image, string imageDescription)
        {
            return (String.Format("<a href=\"{0}\" title=\"{3}\"><img src=\"{1}\" alt=\"{2}\" width=\"700\" height=\"320\" />" +
                "</a>", url, image, imageDescription, title));

        }

        protected string GetPromotionalOffer()
        {
            string Result = "";

            Campaigns currentCampaigns = Campaign.GetActive(lib.BOL.Countries.Countries.Get(GetUserCountry()));

            foreach (Campaign currentCampaign in currentCampaigns)
            {
                if (currentCampaign != null)
                {
                    if (!String.IsNullOrEmpty(currentCampaign.ImageLeftMenu))
                        Result += String.Format("<a href=\"{2}?cmp={1}\"><img src=\"{0}\" border=\"0\" alt=\"\" /></a><br /><br /><br />",
                            currentCampaign.ImageLeftMenu, currentCampaign.CampaignName, currentCampaign.WebLink);
                }
            }

            if (!Request.IsLocal && Request.IsSecureConnection)
                Result = Result.ToLower().Replace("http://", "https://");

            return (Result);
        }

        protected virtual string BuildPagination(int PageCount, int ItemsPerPage, int CurrentPage, string Page, bool routing)
        {
            return (BuildPagination(PageCount, ItemsPerPage, CurrentPage, Page, "", routing));
        }

        protected virtual string BuildPagination(int PageCount, int ItemsPerPage, int CurrentPage, 
            string Page, string Parameters, bool routing)
        {
            string Result = "";
            PageCount = SharedUtils.RoundUp(PageCount, ItemsPerPage);

            if (PageCount < 1)
                PageCount = 1;

            if (Parameters != "")
            {
                if (!Parameters.StartsWith("&"))
                    Parameters = "&" + Parameters;
            }

            if (CurrentPage == 1 || PageCount == 1)
            {
                Result += String.Format("<li class=\"disabled\"><a href=\"javascript: void(0)\">&laquo; {0}</a></li>", LanguageStrings.Previous);
            }
            else
            {
                if (routing)
                    Result += String.Format("<li><a href=\"{0}Page/{1}/{2}\">&laquo; {3}</a></li>", Page, CurrentPage - 1, Parameters, LanguageStrings.Previous);
                else
                    Result += String.Format("<li><a href=\"{0}?Page={1}{2}\">&laquo; {3}</a></li>", Page, CurrentPage - 1, Parameters, Languages.LanguageStrings.Previous);
            }

            //can only allow max of 7 items normal page and 5 for mobile
            int startFrom = 1;
            int endAt = PageCount;
            int maxAllowed = GetUserSession().MobileRedirect ? 5 : 7;
            int currPage = maxAllowed == 5 ? 2 : 4;
            int pageOffset = maxAllowed == 5 ? 1 : 3;

            if (PageCount > maxAllowed)
            {
                if (CurrentPage > currPage)
                {
                    if (CurrentPage >= PageCount)
                    {
                        startFrom = PageCount - maxAllowed;
                        endAt = PageCount;
                    }
                    else
                    {
                        startFrom = CurrentPage - pageOffset;
                        endAt = CurrentPage + pageOffset;

                        if (endAt > PageCount)
                        {
                            startFrom = PageCount - maxAllowed;
                            endAt = PageCount;
                        }
                    }
                }
                else
                {
                    startFrom = 1;
                    endAt = maxAllowed;
                }
            }

            for (int i = startFrom; i <= endAt; i++)
            {
                if (i == CurrentPage)
                {
                    Result += String.Format("<li class=\"current\"><a href=\"{0}Page/{1}/{2}\">{1}</a></li>", Page, i, Parameters);
                }
                else
                {
                    if (routing)
                        Result += String.Format("<li><a href=\"{0}Page/{1}/{2}\">{1}</a></li>", Page, i, Parameters);
                    else
                        Result += String.Format("<li><a href=\"{0}?Page={1}{2}\">{1}</a></li>", Page, i, Parameters);
                }
            }

            if (CurrentPage >= PageCount)
            {
                Result += String.Format("<li class=\"disabled\"><a href=\"javascript: void(0)\">{0} &raquo;</a></li>", LanguageStrings.Next);
            }
            else
            {
                if (routing)
                    Result += String.Format("<li><a href=\"{0}Page/{1}/{2}\">{3} &raquo;</a></li>", Page, CurrentPage + 1, Parameters, LanguageStrings.Next);
                else
                    Result += String.Format("<li><a href=\"{0}?Page={1}{2}\">{3} &raquo;</a></li>", Page, CurrentPage + 1, Parameters, LanguageStrings.Next);
            }

            return (Result);
        }

        protected string GetProductCategories(Int64 groupID, bool addStyles, bool isMobile)
        {
            User user = GetUser();

            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;
            string name = String.Format("Product Category Cache {0} {1} {2} {3}",
                user == null ? 0 : user.MemberLevel, addStyles, isMobile, priceColumn);

            if (lib.DAL.DALHelper.AllowCaching)
            {
                CacheItem cached = GlobalClass.InternalCache.Get(name);

                if (cached != null)
                {
                    return ((string)cached.Value);
                }
            }

            string Result = "";

            if (groupID == -1) // group not found
            {
                Int64 prodID = GetFormValue("ID", -1);

                if (prodID > -1) // there is a product
                {
                    Product currProduct = Products.Get(prodID);

                    if (currProduct != null)
                        groupID = currProduct.PrimaryGroup.ID;
                }
            }

            ProductGroups groups = ProductGroups.Get(user == null ? lib.MemberLevel.StandardUser : user.MemberLevel, true);
            bool first = !isMobile;
            ProductGroupType prodTypeOther = ProductGroupTypes.Get("General");

            foreach (ProductGroup group in groups)
            {
                if (isMobile && !group.MobileWebsite)
                    continue;

                string translatedName = GetTranslatedDescription(group.Description);
                bool nameMatch = !String.IsNullOrEmpty(group.URL) && Request.Path.ToLower().Contains(group.URL.ToLower());
                string image = String.Empty;

                if (isMobile && !String.IsNullOrEmpty(group.MobileImage))
                {
                    image = String.Format(" style=\"background-image: url('/images/product/{0}');" +
                        "background-repeat: no-repeat;background-position: top center;opacity: 0.7;vertical-align: bottom;\"", group.MobileImage);
                }

                string groupColor = group.GroupType.Description;
                string description = String.Empty;

                if (addStyles)
                {
                    description = group.GroupType.ID == prodTypeOther.ID ? translatedName : String.Format("<span>{0}</span><br />{1}", group.SubHeader, group.MainHeader.ToUpper());
                }
                else
                {
                    description = group.GroupType.ID == prodTypeOther.ID ? String.Format("<span>&nbsp;</span>{0}", translatedName) : String.Format("<span>&nbsp;</span>{0}<br />{1}", group.SubHeader, group.MainHeader.ToUpper());

                    if (!addStyles && !description.Contains("<span>"))
                    {
                        if (isMobile && !String.IsNullOrEmpty(group.MobileImage))
                            description = "<span style=\"vertical-align: bottom;\">&nbsp;</span>" + description;
                        else
                            description = "<span>&nbsp;</span>" + description;
                    }
                    else if (isMobile && !String.IsNullOrEmpty(group.MobileImage))
                    {
                        description = description.Replace("<span>", "<span style=\"vertical-align: bottom;\">");
                    }

                    if (String.IsNullOrEmpty(groupColor))
                        groupColor = "General";
                }

                string groupStyle = addStyles ? group.GroupType.ID == prodTypeOther.ID ? String.Empty : "style=\"display: block; width: 130px; text-align: center;\"" : "";

                if (String.IsNullOrEmpty(group.URL))
                {
                    if (group.ID == groupID || (nameMatch) || (groupID == -1 && first))
                        Result += String.Format("<li class=\"current{3}\"{5}><a {4} href=\"{2}/All-Products/Group/{0}/\">{1}</a></li>\r\n",
                            group.SEODescripton, description, GlobalRootURL(), " " + groupColor, groupStyle, image);
                    else
                        Result += String.Format("<li class=\"{3}\"{5}><a {4} href=\"{2}/All-Products/Group/{0}/\">{1}</a></li>\r\n",
                            group.SEODescripton, description, GlobalRootURL(), " " + groupColor, groupStyle, image);
                }
                else
                {
                    if (group.ID == groupID || (nameMatch))
                        Result += String.Format("<li class=\"current{2}\"{3}><a href=\"{0}\">{1}</a></li>\r\n",
                            group.URL, description, " " + groupColor, image);
                    else
                        Result += String.Format("<li class=\"{2}\"{3}><a href=\"{0}\">{1}</a></li>\r\n",
                            group.URL, description, groupColor, image);
                }

                first = false;
            }

            if (lib.DAL.DALHelper.AllowCaching)
            {
                Result = Result.Replace("current ", String.Empty);

                GlobalClass.InternalCache.Add(name, new CacheItem(name, Result));
            }

            return (Result);
        }

        protected string GetProductCategories(ProductGroupType productGroupType)
        {
            return (GetProductCategories(GetFormValue("GroupID", -1), productGroupType));
        }

        protected string GetProductCategories(Int64 current, ProductGroupType productGroupType)
        {
            string Result = String.Empty;

            lib.BOL.Users.User user = GetUser();

            ProductGroups groups = ProductGroups.Get(productGroupType, 
                user == null ? lib.MemberLevel.StandardUser : user.MemberLevel);
            bool first = true;


            foreach (ProductGroup group in groups)
            {
                if (group.GroupType.ID == productGroupType.ID)
                {
                    string translatedName = GetTranslatedDescription(group.Description);
                    bool nameMatch = !String.IsNullOrEmpty(group.URL) && Request.Path.ToLower().Contains(group.URL.ToLower());

                    if (String.IsNullOrEmpty(group.URL))
                    {
                        if (group.ID == current || (nameMatch) || (current == -1 && first))
                            Result += String.Format("<li class=\"current\"><a href=\"{1}/All-Products/Group/{2}/\">{0}</a></li>\r\n",
                                translatedName, GlobalRootURL(), SharedUtils.SEOName(group.SEODescripton));
                        else
                            Result += String.Format("<li><a href=\"{1}/All-Products/Group/{2}/\">{0}</a></li>\r\n",
                                translatedName, GlobalRootURL(), SharedUtils.SEOName(group.SEODescripton));
                    }
                    else
                    {
                        if (group.ID == current || (nameMatch))
                            Result += String.Format("<li class=\"current\"><a href=\"{0}\">{1}</a></li>\r\n",
                                group.URL, translatedName);
                        else
                            Result += String.Format("<li><a href=\"{0}\">{1}</a></li>\r\n",
                                group.URL, translatedName);
                    }

                    first = false;
                }
            }

            return (Result);
        }

        protected string GetProductCategories(Int64 current)
        {
            string Result = String.Empty;

            lib.BOL.Users.User user = GetUser();

            ProductGroups groups = ProductGroups.Get(
                user == null ? lib.MemberLevel.StandardUser : user.MemberLevel,
                true);
            bool first = true;


            foreach (ProductGroup group in groups)
            {
                string translatedName = GetTranslatedDescription(group.Description);
                bool nameMatch = !String.IsNullOrEmpty(group.URL) && Request.Path.ToLower().Contains(group.URL.ToLower());

                if (String.IsNullOrEmpty(group.URL))
                {
                    if (group.ID == current || (nameMatch) || (current == -1 && first))
                        Result += String.Format("<li class=\"current\"><a href=\"{1}/All-Products/Group/{2}/\">{0}</a></li>\r\n",
                            translatedName, GlobalRootURL(), SharedUtils.SEOName(group.SEODescripton));
                    else
                        Result += String.Format("<li><a href=\"{1}/All-Products/Group/{2}/\">{0}</a></li>\r\n",
                            translatedName, GlobalRootURL(), SharedUtils.SEOName(group.SEODescripton));
                }
                else
                {
                    if (group.ID == current || (nameMatch))
                        Result += String.Format("<li class=\"current\"><a href=\"{0}\">{1}</a></li>\r\n",
                            group.URL, translatedName);
                    else
                        Result += String.Format("<li><a href=\"{0}\">{1}</a></li>\r\n",
                            group.URL, translatedName);
                }

                first = false;
            }

            return (Result);
        }

        #region Product Specific

        #region Professional

        protected string GetProducts(ProductType primaryProductType, int size)
        {
            string Result = "";

            int productPage = GetFormValue("Page", 1);

            if (Page.RouteData.Values.ContainsKey("Page"))
                productPage = SharedUtils.StrToIntDef((string)Page.RouteData.Values["page"], productPage);

            lib.BOL.Products.Products products = lib.BOL.Products.Products.Get(
                ProductTypes.Get("All"), productPage, 12);
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            foreach (Product product in products)
            {
                if (product.PrimaryProduct.ID == ProductTypes.Get("All").ID)
                {
                    string PriceFrom = "";

                    if (ShowPriceData)
                    {
                        decimal priceFrom = product.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                        if (BaseWebApplication.PricesIncludeVAT)
                        {
                            priceFrom += SharedUtils.VATCalculate(priceFrom, WebVATRate);
                        }

                        if (product.FreeProduct)
                            PriceFrom = "<strong>Free</strong>";
                        else
                            PriceFrom = String.Format("<strong>{1} {0}</strong>",
                                SharedUtils.FormatMoney(priceFrom, GetWebsiteCurrency(), false),
                                Languages.LanguageStrings.From);
                    }

                    string image = product.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_178.jpg";

                    image = SharedUtils.ResizeImage(image, size);

                    Result += String.Format("<li><a href=\"{0}\"><img src=\"/Images/Products/{1}\" alt=\"I\" border=\"0\" width=\"178\" height=\"128\"/>" +
                        "<span class=\"new\" {5}>{6}</span><span class=\"best\" {4}>{7}</span>{2}{3}</a></li>\r\n",
                        product.URL, image, product.Name, PriceFrom,
                        product.BestSeller ? " style=\"display:block;\"" : "", product.NewProduct ? " style=\"display:block;\"" : "",
                        LanguageStrings.NewProduct, LanguageStrings.BestSeller);
                }
            }

            return (Result);
        }

        protected string GetProductGroup()
        {
            string Result = "";

            ProductGroup group = ProductGroups.Get(GetFormValue("GroupID", -1));

            if (group != null)
            {
                Result = String.Format("<li>&rsaquo;</li>\r\n<li><a href=\"/All-Products/Group/{0}/\">{1}</a></li>", 
                    group.SEODescripton, group.Description);
            }

            return (Result);
        }



        #endregion Professional

        #endregion Product Specific

        protected bool AllowShowCostData()
        {
            bool Result = true;

            Country country = Countries.Get(CountryCode);

            if (country != null)
            {
                Result = country.ShowPriceData();
            }


            return (Result);
        }

        protected void ValidateDetails(string s, int MinLength, string Field)
        {
            if (s == null || s == String.Empty)
            {
                if (MinLength == 0)
                    throw (new System.Exception(String.Format("{0} is a mandatory field.", Field)));
                else
                {
                    if (s.Length < MinLength)
                    {
                        throw (new System.Exception(String.Format("{0} is a mandatory field and should " +
                            "be at least {1} characters long.", Field, MinLength)));
                    }
                }
            }
        }

        protected int GetUsersMemberLevel()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.MemberLevel);
        }

        protected string GetLastError()
        {
            string result = "";

            if (Session["LASTERROR"] != null)
                result = (string)Session["LASTERROR"];

            return (result);
        }

        protected void SetErrorMessage()
        {
            string result = "";

            try
            {
                Exception Err = Server.GetLastError();
                string Inner;
                string Message;
                string Source;
                string StackTrace;
                string TargetSite;

                if (Err != null)
                {
                    Inner = Err.InnerException.ToString();
                    Message = Err.Message;
                    Source = Err.Source;
                    StackTrace = Err.StackTrace;
                    TargetSite = Err.TargetSite.ToString();
                }
                else
                {
                    Inner = "Unknown";
                    Message = "Unknown Error";
                    Source = "Unknown";
                    StackTrace = "Unknown";
                    TargetSite = "Unknown";
                }
                result = String.Format("<P>Error Message: {0}</P>" +
                    "<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
                    "<P>StackTrace: {3}</P><P>Target Site: {4}</P>",
                    Message, Inner, Source, StackTrace, TargetSite);
            }
            catch (Exception error)
            {
                result = String.Format("<P>Error Message: {0}</P>" +
                    "<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
                    "<P>StackTrace: {3}</P><P>Target Site: {4}</P>",
                    error.Message, error.InnerException.ToString(),
                    error.Source, error.StackTrace, error.TargetSite.ToString());
            }

            Session["LASTERROR"] = result;
        }

        protected void SelectFromDropDownList(System.Web.UI.WebControls.DropDownList dropdownlist, string SelectItem)
        {
            if (dropdownlist != null)
            {
                try
                {
                    dropdownlist.SelectedValue = SelectItem;
                }
                catch
                {
                    dropdownlist.SelectedIndex = 0;
                }
            }
        }

        protected void DoError(string error)
        {
            DoRedirect($"/Site-Error/Message/{error}/");
        }


        /// <summary>
        /// Redirects user to login page and once logged in back to referring page
        /// </summary>
        protected void DoRedirect()
        {
            if (Request.IsLocal)
                DoRedirect(String.Format("/Account/Login/?Redirect={0}", Request.Url.ToString()), true);
            else
                DoRedirect(String.Format("/Account/Login/?Redirect={0}", Request.Url.ToString()), true);
        }


        protected void DoRedirect(string URL)
        {
            DoRedirect(URL, true);
        }

        protected void DoRedirectPermanently(string URL)
        {
            Response.RedirectPermanent(URL, true);
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
                    WebsiteAdministration.AutoBanIPAddress(Request.Path, Request.UserHostAddress, true);
                    DoRedirect(String.Format("{0}/Error/IPIsBanned.aspx", GlobalClass.RootURL), true);
                }
            }
        }


        /// <summary>
        /// IPAddressIsBanned
        /// </summary>
        /// <param name="IPAddress">User's IP Address</param>
        /// <param name="BanType">Returns BanType; 0 = Softban (not allowed to input); 1 = Hardban (not allowed access to site)</param>
        /// <returns></returns>
        protected bool IPAddressIsBanned(string IPAddress)
        {
            _IPIsBanned = lib.LibraryHelperClass.IPAddressIsBanned(IPAddress, out _BanType);
            return (_IPIsBanned);
        }


        protected bool UserIsLoggedOn()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.CurrentUser != null);
        }

        /// <summary>
        /// Returns the currently logged in user
        /// </summary>
        /// <returns></returns>
        protected User GetUser()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.CurrentUser);
        }

        protected long GetUserID()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

            if (localData.CurrentUser == null)
                return (-1);
            else
                return (localData.CurrentUser.ID);
        }


        protected virtual string GetWebTitle()
        {
            return (SharedWebBase.GetWebTitle(Request));
        }


        protected virtual string GetMetaDescription()
        {
            string MetaTag = lib.LibraryHelperClass.SettingsGetMeta("META_DESCRIPTION");

            HashTags tags = HashTags.GetPageTags(Request.Url.ToString());
            MetaTag += tags.HashTagList(true);

            return (MetaTag);
        }


        protected void SetNameValue(string Name, string Value)
        {
            lib.LibraryHelperClass.SettingsSet(Name, Value);
        }


        protected string GetNameValue(string Name)
        {
            string Result = lib.LibraryHelperClass.SettingsGet(Name);

            return (Result);
        }


        protected string GetMetaKeyWords()
        {
            string MetaTag = "";

            HashTags tags = HashTags.GetPageTags(Request.Url.ToString());
            MetaTag += tags.HashTagList(true) + " ";
            MetaTag += lib.LibraryHelperClass.SettingsGetMeta("META_KEYWORDS");

            return (MetaTag);
        }


        protected string GlobalRootURL()
        {
            return (GlobalClass.RootURL);
        }


        protected DateTime GetFormValue(string Name, DateTime Default)
        {
            DateTime Result;

            string sDate = GetFormValue(Name, Default.ToString("dd/MM/yyyy"));

            try
            {
                Result = SharedUtils.StrToDateTime(sDate, "en-gb");
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

        protected string GetAllFormValues()
        {
            string Result = "<h1>Parameters</h1>";

            foreach (string s in Request.Params)
            {
                Result += String.Format("<p>{0}={1}</p>", s, GetFormValue(s));
            }

            Result += "<h1>Headers</h1>";

            foreach (string s in Request.Headers)
            {
                Result += String.Format("<p>{0}={1}</p>", s, Request.Headers[s]);
            }

            return (Result);
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

            return (SharedUtils.StrToIntDef(Value, Default));
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

            Int64 result = SharedUtils.StrToIntDef(Value, Default);

            return (result);
        }


        protected decimal GetFormValue(string Name, decimal Default)
        {
            string Value = String.Empty;

            if (Request[Name] != null && Request[Name] != String.Empty)
                Value = Request[Name];
            else
                Value = String.Empty;

            if (Value.IndexOf("#") > 0)
                Value = Value.Substring(0, Value.IndexOf("#"));

            decimal result = SharedUtils.StrToDecimal(Value, Default);

            return (result);
        }

        protected string GetUserCountry()
        {
            UserSession session = GetUserSession();

            if (session == null)
                return ("ZZ");

            LocalWebSessionData localData = (LocalWebSessionData)session.Tag;
            return (localData.CountryCode);
        }


        protected string GetTermsAndConditions()
        {
            string Result = String.Empty;

            if (GlobalClass.ShowTermsAndConditions)
                Result = String.Format(" - <a href=\"/Terms.aspx\">{0}</a>", Languages.LanguageStrings.Terms);

            return (Result);
        }

        protected string GetPrivacyPolicy()
        {
            string Result = String.Empty;

            if (GlobalClass.ShowPrivacyPolicy)
                Result = String.Format(" - <a href=\"/Privacy.aspx\">{0}</a>", Languages.LanguageStrings.Privacy);

            return (Result);
        }

        protected string GetReturnsPolicy()
        {
            string Result = String.Empty;

            if (GlobalClass.ShowReturnsPolicy)
                Result = String.Format(" - <a href=\"/Returns.aspx\">{0}</a>", Languages.LanguageStrings.Returns);

            return (Result);
        }


        #endregion Protected Methods

        #region Public Methods

        public bool BasketHasItems()
        {
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            return (localData.Basket.HasItems());
        }

        #endregion Public Methods

        #region Public Properties

        public bool ShowPriceData
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
                    return (true);
            }
        }

        /// <summary>
        /// Gets the status of ban type
        /// </summary>
        public bool IPAddressBanned
        {
            get
            {
                return (_IPIsBanned);
            }
        }


        public int IPAddressBanType
        {
            get
            {
                return (_BanType);
            }
        }


        public int MemberLevel
        {
            get
            {
                return (GetUsersMemberLevel());
            }
        }


        #endregion Public Properties
    }
}
