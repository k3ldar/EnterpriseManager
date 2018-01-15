using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using Website.Library.Classes;

using Website.Library;
using Shared.Classes;

#if ERROR_MANAGER
using ErrorManager.ErrorClient;
#endif

using Shared;

namespace Heavenskincare.WebsiteTemplate
{
    #region Class Global

    /// <summary>
    /// Summary description for Global.
    /// </summary>
    public class Global : BaseWebApplication
    {
        #region Settings

        /// <summary>
        /// Determines wether the salon finder is visible or not
        /// </summary>
        public static bool ShowSalonFinder;

        /// <summary>
        /// Shows/Hides the Salon header
        /// </summary>
        public static bool ShowSalonHeader;

        /// <summary>
        /// Shows/Hides the Client header
        /// </summary>
        public static bool ShowClientHeader;

        /// <summary>
        /// Determines wether home banners are shown on the home page or not
        /// </summary>
        public static bool ShowHomeBanners;

        /// <summary>
        /// Determines wether there is a clickable treatments brochure on the treatments page.
        /// </summary>
        public static bool ClickableTreatmentBrochure;

        public static bool HideDistributorSalonDetails;

        /// <summary>
        /// Allow users to add giftwrapping at check out
        /// </summary>
        public static bool AllowGiftwrapAtCheckout = false;


        public static string PrismSKU = "P760B";


        public static bool ShowBlackLabelMenu;
        public static bool ShowSalonsMenu;
        public static bool ShowTreatmentsMenu;
        public static bool ShowTreatmentsBrochure;
        public static bool ShowDistributorsMenu;
        public static bool ShowTipsAndTricksMenu;
        public static bool ShowBeeVenomGoldMenu;
        public static bool ShowLondonLashAndBrow = false;
        public static bool ShowHeavenNails;

        #region Online Salon Bookings

        public static bool AllowSalonBookings;
        public static string SalonBookingEmail;
        public static string SalonBookingTelephone;

        #endregion Online Salon Bookings

        public static bool ShowLanguageSelector = false;
        public static bool ShowCurrencySelector = false;
        public static bool ShowLanguageFlag = false;

        public static bool UpdateMarketingEmailTemplates = false;


        /// <summary>
        /// Static Blog Banner
        /// </summary>
        public static string BlogBanner = "banner-blog.png";

        /// <summary>
        /// Static Trade Banner
        /// </summary>
        public static string TradeBanner = "banner-trade.gif";

        /// <summary>
        /// Type of picture used on main page
        /// </summary>
        public static string PictureType = "Jpeg";

        /// <summary>
        /// Determines wether the home page can be shown or not
        /// </summary>
        public static bool AllowHomePage = false;


        public static bool ShowSubTotalOnOrdersAndInvoices = true;


        #region External Affiliate Links


        public static bool AffiliateIncludeExternal = false;

        public static string AffiliateStandardHeader = String.Empty;

        public static string AffiliatePurchaseHeader = String.Empty;

        #endregion External Affiliate Links

        #region Offer Pages

        public static string SpecialOffersPageSKUCodes = String.Empty;
        public static DateTime SpecialOffersPageStart = new DateTime(2015, 12, 26, 0, 0, 0);
        public static DateTime SpecialOffersPageEnd = new DateTime(2016, 1, 6, 23, 59, 59);
        public static string SOPriceColor = "#d83e75";
        public static bool SOToolbar = true;

        /// <summary>
        /// List of SKU's to show on christmas page
        /// </summary>
        public static string ChristmasPageSKUCodes = String.Empty;
        public static DateTime ChristmasPageStart = new DateTime(2015, 12, 1, 0, 0, 0);
        public static DateTime ChristmasPageEnd = new DateTime(2015, 12, 25, 23, 59, 59);

        public static string BoxingDayPageSKUCodes = String.Empty;
        public static DateTime BoxingDayPageStart = new DateTime(2015, 12, 26, 0, 0, 0);
        public static DateTime BoxingDayPageEnd = new DateTime(2016, 1, 6, 23, 59, 59);

        #endregion Offer Pages


        public override void SessionCreated(UserSession session)
        {
            //Library.BOL.SEO.SeoData.SEOSaveSession(session);
        }

        public override void SessionClosed(Shared.Classes.UserSession session)
        {
            base.SessionClosed(session);
            Library.BOL.SEO.SeoData.SEOSaveSession(session);
        }

        public override UserSession SessionRetrieve(string sessionID)
        {
            return (Library.BOL.SEO.SeoData.SeoSessionGet(sessionID));
        }

        public override void SessionSaveData(UserSession session)
        {
            Library.BOL.SEO.SeoData.SEOSaveSession(session);
        }

        public override void SessionSavePage(UserSession session, PageViewData page)
        {
            Library.BOL.SEO.SeoData.SEOSavePage(session, page);
        }

        public override void LoadCustomSettings()
        {
            AllowMobileWebsite = ConfigSettingGet("Settings.MobileWebsite", false);

            BaseWebApplication.CookiePrefix = "Heaven";

            BaseWebApplication.CookieRootURL = ".heavenskincare.com";

            ShowHomeBanners = ConfigSettingGet("Settings.ShowHomeBanners", false, true);

            ShowSalonsMenu = ConfigSettingGet("Settings.ShowSalons", false);
            ShowTreatmentsMenu = ConfigSettingGet("Settings.ShowTreatments", true);
            ShowTreatmentsBrochure = ConfigSettingGet("Settings.ShowTreatmentBrochure", true);
            ShowDistributorsMenu = ConfigSettingGet("Settings.ShowDistributors", true);
            ShowTipsAndTricksMenu = ConfigSettingGet("Settings.ShowTipsAndTricks", true);
            ShowBeeVenomGoldMenu = ConfigSettingGet("Settings.ShowBeeVenomGold", true);
            ShowLondonLashAndBrow = ConfigSettingGet("Settings.LondonLashBrow", true);
            ShowHeavenNails = ConfigSettingGet("Settings.HeavenNails", true);
            GlobalClass.StyleSheetLocation = "https://static.heavenskincare.com/css/";

            #region Online Appointment Bookings

            AllowSalonBookings = ConfigSettingGet("Settings.AllowSalonBookings", true);

            if (AllowSalonBookings)
            {
                SalonBookingEmail = ConfigSettingGet("Settings.SalonBookingEmail", String.Empty);
                SalonBookingTelephone = ConfigSettingGet("Settings.SalonBookingTelephone", String.Empty);
            }

            #endregion Online Appointment Bookings

            ShowLanguageSelector = ConfigSettingGet("Settings.LanguageSelector", false);
            ShowCurrencySelector = ConfigSettingGet("Settings.CurrencySelector", false);

            LocalizedLanguages.Active = ShowLanguageSelector || ShowCurrencySelector;

            ShowLanguageFlag = ConfigSettingGet("Settings.ShowLanguageFlag", true);

            UpdateMarketingEmailTemplates = ConfigSettingGet("Settings.UpdateMarketingEmailTemplates", false);


            Global.PageTitle = "HeavenSkincare TM inventors of Bee Venom mask, derived from ABEETOXIN (R) for young looking, healthy skin, mind, body and soul.";
            GlobalClass.DefaultMetaKeyWords = "Heaven, Skincare, Beauty, Treatments, ";

            AllowHomePage = ConfigSettingGet("Settings.HomePage", false);

            ShowSalonFinder = ConfigSettingGet("Settings.ShowSalonFinder", true);
            ClickableTreatmentBrochure = ConfigSettingGet("Settings.ClickableTreatmentBrochure", true);
            ShowSalonHeader = ConfigSettingGet("Settings.ShowSalonHeader", true);
            ShowClientHeader = ConfigSettingGet("Settings.ShowClientHeader", true);

            AllowGiftwrapAtCheckout = ConfigSettingGet("Settings.AllowGiftwrapAtCheckout", false);
            HideDistributorSalonDetails = ConfigSettingGet("Settings.HideDistributorSalonDetails", false);
            ShowBasketItemsWithVAT = ConfigSettingGet("Settings.ShowBasketItemsWithVAT", false);
            ShowBasketSubTotalWithVAT = ConfigSettingGet("Settings.ShowBasketSubTotalWithVAT", false);

            BlogBanner = ConfigSettingGet("BlogBanner", String.Empty);
            TradeBanner = ConfigSettingGet("TradeBanner", String.Empty);
            PictureType = ConfigSettingGet("SITE.PICTURE_TYPE", "Jpeg");

            ShowSubTotalOnOrdersAndInvoices = ConfigSettingGet("SubtotalOrderInvoice", true);

            #region Offer Pages

            SpecialOffersPageSKUCodes = ConfigSettingGet("SpecialOffersPageSKUCodes", String.Empty, true);
            SpecialOffersPageStart = ConfigSettingGet("SpecialOffersPageStart", SpecialOffersPageStart, true);
            SpecialOffersPageEnd = ConfigSettingGet("SpecialOffersPageEnd", SpecialOffersPageEnd, true);
            SOPriceColor = ConfigSettingGet("SOPriceColor", "pink", true);
            SOToolbar = ConfigSettingGet("SOToolbar", true, true); 

            ChristmasPageSKUCodes = ConfigSettingGet("ChristmasPageSKUCodes", String.Empty, true);
            ChristmasPageStart = ConfigSettingGet("ChristmasPageStart", ChristmasPageStart, true);
            ChristmasPageEnd = ConfigSettingGet("ChristmasPageEnd", ChristmasPageEnd, true);

            BoxingDayPageSKUCodes = ConfigSettingGet("BoxingDayPageSKUCodes", String.Empty, true);
            BoxingDayPageStart = ConfigSettingGet("BoxingDayPageStart", BoxingDayPageStart, true);
            BoxingDayPageEnd = ConfigSettingGet("BoxingDayPageEnd", BoxingDayPageEnd, true);

            #endregion Offer Pages

            #region External Affiliate Links


            AffiliateIncludeExternal = ConfigSettingGet("AffiliateIncExt", false, true);

            if (AffiliateIncludeExternal)
            {
                AffiliateStandardHeader = ConfigSettingGet("AffiliateExtHdr", String.Empty, true);

                AffiliatePurchaseHeader = ConfigSettingGet("AffiliateExtPur", String.Empty, true);
            }

            #endregion External Affiliate Links


            GlobalClass.StyleSheet = "Style18.css";

            GlobalClass.Address = String.Format("{0} {1} {2}",
                BaseWebApplication.AddressLine1,
                BaseWebApplication.AddressLine2,
                BaseWebApplication.AddressLine3);
        }

        #endregion Settings

        #region Constructors/Destructors

        /// <summary>
		/// Required designer variable.
		/// </summary>
		public Global()
		{
			InitializeComponent();
		}	
		


		#endregion Constructors/Destructors

        #region Private Methods

        void ErrorHandling_InternalException(object sender, Library.BOLEvents.InternalErrorEventArgs e)
        {
            string msg = String.Empty;

            try
            {
                msg = String.Format("Internal Exception in Website - {5}\r\n\r\nMethod: {0}\r\n\r\nMessage: {4}\r\n\r\nSource: {1}\r\n\r\nParameters:\r\n\r\n{2}\r\n\r\nCallstack:\r\n\r\n{3}",
                    e.Method, e.Source, e.Parameters, e.CallStack, e.Message, DistributorWebsite);
#if ERROR_MANAGER
                if (!ErrorClient.GetErrorClient.SendError(
                    new ErrorManager.ErrorClient.Options("em.heavenskincare.com", 37789, "Heavenskincare", "Heaven_!3B"),
                    msg))
                {
                    //Failed to send error details to server
                    Global.SendEMail(Global.SupportName, Global.SupportEMail, String.Format("Website Error ({0})", Global.DistributorWebsite),
                        msg, Global.SupportName, Global.SupportEMail);
                }
#else
                Global.SendEMail(Global.SupportName, Global.SupportEMail, String.Format("Website Error ({0})", Global.DistributorWebsite),
                    msg, Global.SupportName, Global.SupportEMail);
#endif
            }
            catch (Exception err)
            {
                msg += String.Format("\r\n\r\n{0}", err.Message);
                Global.SendEMail(Global.SupportName, Global.SupportEMail, String.Format("Website Error ({0})", Global.DistributorWebsite),
                    msg, Global.SupportName, Global.SupportEMail);
            }
        }


        #endregion Private Methods

        #region WebAppEvents

        protected void Application_Start(Object sender, EventArgs e)
		{
            EventLog.Add("Application Starting");

            if (String.IsNullOrEmpty(Global.WebsiteTelephoneNumber))
                WebsiteTelephoneNumber = "+44(0) 1952 462505 or +44(0) 1952 463574";

            if (String.IsNullOrEmpty(Global.WebsiteEmail))
                WebsiteEmail = "sales@heavenskincare.com";

            LocalizedLanguages.OnSelectPriceColumn += LocalizedLanguages_OnSelectPriceColumn;

            ApplicationStart();
            SharedWebBase.ApplicationStart();

            WebChart.ChartControl.PhysicalPath = Global.Path + @"Admin\Reports\WebChartGraphs\";
            WebChart.ChartControl.VirtualPath = Global.RootURL + @"/Admin/Reports/WebChartGraphs/";

            Library.ErrorHandling.InternalException += ErrorHandling_InternalException;
            ThreadManager.ThreadStart(new WebsiteThreadManager(),
                "Website Thread Manager", ThreadPriority.Lowest);
                                            
            string ProductImages = "C:\\HostingSpaces\\heaven\\static.heavenskincare.com\\wwwroot\\Images\\Products\\";

            if (Directory.Exists(ProductImages))
            {
                EventLog.Add(String.Format("Directory {0} exists", ProductImages));

                Classes.RoutineMaintenance.RoutineMaintenance.ImageLocations.Add(
                    new Classes.RoutineMaintenance.ImageCreateLocation(ProductImages,
                        "*_148.*", "ProductImages", String.Format("{0}download\\Products.xml", GlobalClass.RootPath)));
            }
            else
            {
                EventLog.Add(String.Format("Directory {0} does not exist", ProductImages));
            }

            Classes.RoutineMaintenance.RoutineMaintenance.ImageLocations.Add(
                new Classes.RoutineMaintenance.ImageCreateLocation(String.Format("{0}Images\\Stratosphere\\", GlobalClass.RootPath),
                "*_148.*", "ProductImages", String.Format("{0}download\\StratosphereImages.xml", GlobalClass.RootPath)));
            Classes.RoutineMaintenance.RoutineMaintenance.ImageLocations.Add(
                new Classes.RoutineMaintenance.ImageCreateLocation(String.Format("{0}Images\\Distributors\\", GlobalClass.RootPath),
                "*.*", "DistributorImages", String.Format("{0}Download\\DistributorImages.xml", GlobalClass.RootPath)));
            Classes.RoutineMaintenance.RoutineMaintenance.ImageLocations.Add(
                new Classes.RoutineMaintenance.ImageCreateLocation(String.Format("{0}Images\\Treatments\\", GlobalClass.RootPath),
                "*.*", "TreatmentImages", String.Format("{0}Download\\TreatmentImages.xml", GlobalClass.RootPath)));
            Classes.RoutineMaintenance.RoutineMaintenance.ImageLocations.Add(
                new Classes.RoutineMaintenance.ImageCreateLocation(String.Format("{0}Images\\GiftSets\\", GlobalClass.RootPath),
                "*.*", "Images", String.Format("{0}download\\ImageGiftSets.xml", GlobalClass.RootPath)));
            Classes.RoutineMaintenance.RoutineMaintenance.ImageLocations.Add(
                new Classes.RoutineMaintenance.ImageCreateLocation(String.Format("{0}Images\\Celebs\\", GlobalClass.RootPath),
                "*.*", "CelebrityImages", String.Format("{0}Download\\CelebrityImages.xml", GlobalClass.RootPath)));
        }

        void LocalizedLanguages_OnSelectPriceColumn(object sender, PriceColumnOverrideArgs e)
        {
            try
            {
                e.OverridePriceColumn = true;
                Library.BOL.Basket.Currency currency = null;
                Library.BOL.Countries.Country country = null;

                LocalWebSessionData localData = (LocalWebSessionData)e.UserSession.Tag;

                if (e.Session != null)
                {
                    currency = SharedWebBase.WebsiteCurrency(e.Session, e.Request);
                    country = localData.UserCountry;
                }
                else
                {
                    if (e.UserSession == null || localData == null || localData.Basket == null)
                        return;

                    currency = Library.BOL.Basket.Currencies.Get(localData.UserCountry.DefaultCurrency);

                    if (String.IsNullOrEmpty(localData.CountryCode))
                        country = Library.BOL.Countries.Countries.Get("ZZ");
                    else
                        country = Library.BOL.Countries.Countries.Get(localData.CountryCode);
                }

                if (currency.CurrencyCode == country.DefaultCurrency)
                {
                    e.PriceColumn = country.PriceColumn;
                }
                else
                {

#warning this is a bodge, if two of the currencies are the same then problem, i.e. price 1 and 2 are both GBP

                    if (country.PriceColumn > 0 && currency.PriceColumn == 0)
                        e.PriceColumn = currency.PriceColumn + 1;
                    else
                        e.PriceColumn = currency.PriceColumn;
                }
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
                e.PriceColumn = 1;
            }
        }

		protected void Session_Start(Object sender, EventArgs e)
		{
            try
            {
                // add a test cookie to see if cookies are enabled.
                HttpCookie Cookie = new HttpCookie("HEAVEN_TEST_COOKIE", HttpUtility.UrlEncode(
                    Shared.Utilities.Encrypt("CookiesEnabled" + Session.SessionID)));

                if (!Request.IsLocal)
                {
                    Cookie.Domain = BaseWebApplication.CookieRootURL;
                    Cookie.Secure = UseHTTPS;
                }

                Cookie.Path = "/";
                Response.Cookies.Add(Cookie);

                UserSession session = SharedWebBase.StartUserSession(Session, Request, Response);

                if (session.MobileRedirect && !AllowMobileWebsite)
                    session.MobileRedirect = false;
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
            if (Global.MaintenanceMode)
            {
                if (SharedWebBase.CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_BYPASS_MAINTENANCE, BaseWebApplication.DistributorWebsite),
                    "notfound") == "notfound")
                {
                    string email = (string)Request["user"];
                    string password = (string)Request["password"];

                    Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(email, password);

                    if (user == null || user.MemberLevel < Library.MemberLevel.StaffMember)
                    {
                        Response.Redirect("/maintenance.htm", true);
                        Response.End();
                    }
                    else
                    {
                        SharedWebBase.CookieSetValue(Request, Response, 
                            String.Format(StringConstants.COOKIE_BYPASS_MAINTENANCE, BaseWebApplication.DistributorWebsite),
                            "yes", DateTime.Now.AddDays(10));
                    }
                }
            } // end maintenance mode

            if (Global.RootHost != Request.Url.Host)
            {
                Response.Redirect(Global.RootURL + Request.Url.AbsolutePath);
            }
           
            if (Request.Path.ToLower().IndexOf("get_aspx_ver.aspx") >= 0)
				Response.End();
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

        }

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
            try
            {
                HttpException ex = Server.GetLastError() as HttpException;

                // if 404 error check if we can redirect the user
                if (ex != null && ex.GetHttpCode() == 404)
                {
                    //should we autoban some users depending what they are searching for?
                    if (AutoBanIPAddress(Request.Path, Request.UserHostAddress))
                    {
                        HttpContext.Current.Response.Redirect(String.Format("{0}/Error/IPIsBanned.aspx", Global.RootURL), true);
                        return;
                    }

                    string file = ex.Message;
                    file = CanRedirect(file);

                    if (file != "")
                    {
                        // a file to redirect to has been found, redirect and exit the procedure
                        HttpContext.Current.Response.Redirect(file, true);
                        return;
                    }
                }

                Exception Err = Server.GetLastError();

                SharedWebBase.HandleException(Err, ex.GetHttpCode());
            }
            catch (Exception error)
            {
                string Msg = String.Format("<P>Error Message: {0}</P>" +
                    "<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
                    "<P>StackTrace: {3}</P><P>Target Site: {4}</P>",
                    error.Message, error.InnerException == null ? "" : error.InnerException.ToString(),
                    error.Source, error.StackTrace, error.TargetSite.ToString());

                try
                {
                    Global.SendEMail(Global.SupportName, Global.SupportEMail, 
                        String.Format("Website Error ({0})", Global.DistributorWebsite),
                        Msg, Global.SupportName, Global.SupportEMail);
                }
                catch
                {
                    Shared.EventLog.Add(error);
                }
            }
        }

		protected void Session_End(Object sender, EventArgs e)
		{
            
		}

		protected void Application_End(Object sender, EventArgs e)
		{
            ApplicationEnd();
		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
        }

		#endregion

		#endregion WebAppEvents
	}

    internal class HeavenWebsiteSettings : WebsiteSettings
    {

        #region Virtual Methods

        public override void WebSiteOptions(string parentName, WebsiteOptions options)
        {
            switch (parentName)
            {
                case "Online Salon Bookings":
                    options.AddOption("AllowSalonBookings", Global.AllowSalonBookings, 
                        "Determines wether users can book online appointments or not", "Settings.AllowSalonBookings");
                    options.AddOption("Salon Email Address", Global.SalonBookingEmail, 
                        "Email address to show on appoingment booking page", "Settings.SalonBookingEmail");
                    options.AddOption("Salon Telephone Number", Global.SalonBookingTelephone, 
                        "Email address to show on appoingment booking page", "Settings.SalonBookingTelephone");
                    break;

                case "Distributor Options":
                    options.AddOption("WebsiteTelephoneNumber", Global.WebsiteTelephoneNumber, 
                        "Telephone number shown on website", "Settings.WebsiteTelephoneNumber");
                    options.AddOption("WebsiteEmail", Global.WebsiteEmail, 
                        "E-Mail address shown on website", "Settings.WebsiteEmail");
                    options.AddOption("AddressLine1", Global.AddressLine1, 
                        "Address Line 1 shown on website", "Settings.AddressLine1");
                    options.AddOption("AddressLine2", Global.AddressLine2, 
                        "Address Line 2 shown on website", "Settings.AddressLine2");
                    options.AddOption("AddressLine3", Global.AddressLine3, 
                        "Address Line 3 shown on website", "Settings.AddressLine3");

                    break;

                case "Menu Items":
                    options.AddOption("ShowSalonsMenu", Global.ShowSalonsMenu, 
                        "Determines wether the Salons menu item is shown or not", "Settings.ShowSalons", true);
                    options.AddOption("ShowTreatmentsMenu", Global.ShowTreatmentsMenu, 
                        "Determines wether the treatments menu item is shown or not", "Settings.ShowTreatments", true);
                    options.AddOption("ShowDistributorsMenu", Global.ShowDistributorsMenu, 
                        "Determines wether the Distributors menu item is shown or not", "Settings.ShowDistributors", true);
                    options.AddOption("ShowTipsAndTricksMenu", Global.ShowTipsAndTricksMenu, 
                        "Determines wether the Tips and Tricks menu item is shown or not", "Settings.ShowTipsAndTricks", true);
                    options.AddOption("ShowBeeVenomGoldMenu", Global.ShowBeeVenomGoldMenu, 
                        "Determines wether Bee Venom Gold Menu is shown or not", "Settings.ShowBeeVenomGold", true);
                    options.AddOption("ShowLondonLashAndBrow", Global.ShowLondonLashAndBrow, 
                        "Determines wether London Lash and Brow page is visible or not", "Settings.LondonLashBrow", true);
                    options.AddOption("ShowHeavenNails", Global.ShowHeavenNails, 
                        "Determines wether the heaven nails page is shown or not", "Settings.HeavenNails", true);

                    break;

                case "Page Options":
                    options.AddOption("ShowSalonFinder", Global.ShowSalonFinder, 
                        "Shows/hides the Find Salon option on the salon page", "Settings.ShowSalonFinder");
                    options.AddOption("ClickableTreatmentBrochure", Global.ClickableTreatmentBrochure, 
                        "Determines if a link to a treatment brochure is shown or not", "Settings.ClickableTreatmentBrochure");
                    options.AddOption("HideDistributorSalonDetails", Global.HideDistributorSalonDetails, 
                        "Shows/hides the salons section from the top of the Distributor page.", 
                        "Settings.HideDistributorSalonDetails");
                    options.AddOption("ShowClientHeader", Global.ShowClientHeader, 
                        "Shows/hides the Client header from the top of the Salons page.", "Settings.ShowClientHeader");
                    options.AddOption("ShowSalonHeader", Global.ShowSalonHeader, 
                        "Shows/hides the Salon header from the top of the Salons page", "Settings.ShowSalonHeader");
                    options.AddOption("ShowBrochureLinkonTreatments", Global.ShowTreatmentsBrochure, 
                        "Shows/hides the clickable brochure on treatments page", "Settings.ShowTreatmentBrochure");
                    options.AddOption("ShowTermsAndConditions", Global.ShowTermsAndConditions, 
                        "Indicates wether Terms and Conditions are shown or not.", "Settings.ShowTermsAndConditions");
                    options.AddOption("ShowPrivacyPolicy", Global.ShowPrivacyPolicy, 
                        "Indicates wether Privacy Policy is shown or not.", "Settings.ShowPrivacyPolicy");
                    options.AddOption("ShowReturnsPolicy", Global.ShowReturnsPolicy, 
                        "Indicates wether Returns Policy is shown or not.", "Settings.ShowReturnsPolicy");

                    break;
            
                case "Homepage":
                    options.AddDescription("Settings which affect the main home page");
                    options.AddOption("Custom Strapline on Scroller", Global.CustomScrollerStrapLine, 
                        "Show custom scroller text on home page", "Settings.CustomIndexScroller");
                    options.AddOption("Custom Scroller Text", Global.CustomScrollerText, 
                        "Text to show above scroller on home page", "Settings.CustomScrollerText");
                    options.AddOption("Picture Type", Global.PictureType, 
                        "Picture type used for home page images, valid values are<ul><li>Jpeg</li><li>Gif</li><li>PNG</li>" +
                        "<li>GifAnimated</li></ul>", "SITE.PICTURE_TYPE");
                    options.AddOption("Home Banners", Global.ShowHomeBanners, 
                        "Determines wether home banners are shown or not", "Settings.ShowHomeBanners");

                    break;
                case "Multi Language/Multi Currency":
                    options.AddDescription("Options for multiple languages and currencies");
                    options.AddOption("ShowLanguageSelector", Global.ShowLanguageSelector, 
                        "Allows users to select different languages", "Settings.LanguageSelector");
                    options.AddOption("ShowCurrencySelector", Global.ShowCurrencySelector, 
                        "Allows users to select different currencies", "Settings.CurrencySelector");
                    options.AddOption("ShowLanguageFlag", Global.ShowLanguageFlag, 
                        "Shows a country flag if ticked, otherwise the language name is shown", "Settings.ShowLanguageFlag");

                    break;

                case "Invoice/Order Options":
                    options.AddDescription("This setting only affects the viewing of invoices and order on the website by the customer");
                    options.AddOption("ShowSubTotalOnOrdersAndInvoices", Global.ShowSubTotalOnOrdersAndInvoices, 
                        "Determines wether the subtotal field is shown within orders/invoices", "Settings.SubtotalOrderInvoice");

                    break;

                case "Mail Lists":
                    options.AddOption("Allow Mail List Subscribers", Global.AllowMailListSubscribers, 
                        "Determines wether mail list subscription is shown in the left toolbar on all pages or not", 
                        "SETTINGS.MAILLIST.ALLOW");

                    break;

                case "Shopping Basket Options":
                    base.WebSiteOptions(parentName, options);
                    options.AddOption("AllowGiftwrapAtCheckout", Global.AllowGiftwrapAtCheckout, 
                        "Provides the customer with an option to add giftwrapping to their purchase at checkout", 
                        "Settings.AllowGiftwrapAtCheckout");

                    options.AddOption("Show Basket Summary", Global.BasketSummaryShow, 
                        "Shows a basket summary after an item is added to the basket", "Settings.BasketSummaryShow");
                    options.AddOption("Basket Summary Auto Hide", Global.BasketSummaryAutoHide, 
                        "Automatically hides the basket summary", "Settings.BasketSummaryAutoHide");
                    options.AddOption("Basket Summary Timeout", Global.BasketSummaryTimeOut, 
                        "Number of seconds that the basket summary will auto hide", "SettingsBasketSummaryTimeout", 10, 5, 25);
                    options.AddOption("Basket ID Count", Global.BasketIDIncrement,
                        "Number of Basket ID's to store in memory", "Settings.BasketIDCount", 500, 100, 10000);

                    break;

                case "Mobile Website":
                    options.AddDescription("Settings for mobile website");

                    options.AddOption("Enable Mobile Website", Global.AllowMobileWebsite, 
                        "Determines wether visitors using mobile's can view a mobile friendly version of the website or not", 
                        "Settings.MobileWebsite");
                    
                    break;

                case "Special Offers":
                    options.AddHeader("Settings for Special Offers Page");

                    options.AddDescription("SKU's must be seperated by a colon, i.e. C280;C290;C300");
                    options.AddOption("Special Offers Page Product SKU's", Global.SpecialOffersPageSKUCodes, 
                        "List of product SKU's to show on the Special Offers page.", "SpecialOffersPageSKUCodes", 
                        300, false, false, 1, true);
                    options.AddOption("Special Offers Page Start Date/Time", Global.SpecialOffersPageStart, 
                        "Date/Time that Special Offers page will be visible to public", "SpecialOffersPageStart", true);
                    options.AddOption("Special Offers Page End Date/Time", Global.SpecialOffersPageEnd, 
                        "Date/Time that Special Offers page will be hidden to public", "SpecialOffersPageEnd", true);
                    options.AddOption("Special Offers Page Price Colour", Global.SOPriceColor, 
                        "The price of the price colour", "SOPriceColor", 300, false, false, 1, true);
                    options.AddOption("Special Offers Show Toolbar", Global.SOToolbar, 
                        "If ticked the toolbar on the left will be shown", "SOToolbar", true);
                    break;
                case "Christmas":
                    options.AddHeader("Settings for Christmas Page");

                    options.AddDescription("SKU's must be seperated by a colon, i.e. C280;C290;C300");
                    options.AddOption("Christmas Page Product SKU's", Global.ChristmasPageSKUCodes, 
                        "List of product SKU's to show on the christmas page.", "ChristmasPageSKUCodes", 
                        300, false, false, 1, true);
                    options.AddOption("Christmas Page Start Date/Time", Global.ChristmasPageStart, 
                        "Date/Time that christmas page will be visible to public", "ChristmasPageStart", true);
                    options.AddOption("Christmas Page End Date/Time", Global.ChristmasPageEnd, 
                        "Date/Time that christmas page will be hidden to public", "ChristmasPageEnd", true);
                    break;
                case "Boxing Day":
                    options.AddHeader("Settings for Boxing Day Page");

                    options.AddDescription("SKU's must be seperated by a colon, i.e. C280;C290;C300");
                    options.AddOption("Boxing Day Page Product SKU's", Global.BoxingDayPageSKUCodes, 
                        "List of product SKU's to show on the Boxing Day page.", "BoxingDayPageSKUCodes", 
                        300, false, false, 1, true);
                    options.AddOption("Boxing Day Page Start Date/Time", Global.BoxingDayPageStart, 
                        "Date/Time that Boxing Day page will be visible to public", "BoxingDayPageStart", true);
                    options.AddOption("Boxing Day Page End Date/Time", Global.BoxingDayPageEnd, 
                        "Date/Time that Boxing Day page will be hidden to public", "BoxingDayPageEnd", true);
                    break;
                case "External Affiliate":
                    options.AddDescription("Options for Inegrating External Affiliates");
                    options.AddOption("Integrate External Affiliates", Global.AffiliateIncludeExternal, 
                        "If ticked then external affiliation script will be included in every page", "AffiliateIncExt", true);
                    options.AddOption("External Affiliate Header", Global.AffiliateStandardHeader, 
                        "Java script to be included on the page", "AffiliateExtHdr", 500, false, false, 10, true);
                    options.AddOption("External Affiliate Purchase Header", Global.AffiliatePurchaseHeader, 
                        "Java script to be included on the page", "AffiliateExtPur", 500, false, false, 10, true);
                    break;
                default:
                    base.WebSiteOptions(parentName, options);

                    break;
            }
        }

        public override List<string> WebSiteSubOptions(string parentName)
        {
            List<string> Result = base.WebSiteSubOptions(parentName);


            switch (parentName)
            {
                case "Distributor Options":
                case "Menu Items":
                case "Page Options":
                case "Homepage":
                case "Mail Lists":
                case "Invoice/Order Options":
                case "Mobile Website":
                    break;
                case "Offer/Voucher Options":
                    Result.Add("Special Offers");
                    Result.Add("Christmas");
                    Result.Add("Boxing Day");

                    break;
            }

            return (Result);
        }

        public override List<string> WebSiteOptionHeaders()
        {
            List<string> Result = base.WebSiteOptionHeaders();

            Result.Add("Online Salon Bookings");
            Result.Add("Distributor Options");
            Result.Add("Menu Items");
            Result.Add("Page Options");
            Result.Add("Homepage");
            Result.Add("Mail Lists");
            Result.Add("Invoice/Order Options");
            Result.Add("Multi Language/Multi Currency");
            Result.Add("Mobile Website");
            Result.Add("External Affiliate");

            return (Result);
        }

        #endregion Virtual Methods
    }

    /// <summary>
    /// Thread that only initialises other threads required by the website
    /// 
    /// This thread will wait 30 seconds after loaded, then load other 
    /// threads, once other threads have loaded it will close itself
    /// </summary>
    internal class WebsiteThreadManager : Shared.Classes.ThreadManager
    {
        internal WebsiteThreadManager()
            :base (null, new TimeSpan(0, 0, 30))
        {
            RunAtStartup = false;
        }

        protected override bool Run(object parameters)
        {
            if (Global.UpdateMarketingEmailTemplates)
                Shared.Classes.ThreadManager.ThreadStart(new UpdateMarketingEmailTemplates(Global.Path),
                    "Marketing Template Folders", ThreadPriority.Lowest);

            return (false);
        }
    }

    /// <summary>
    /// Threaded class which updates markeing info with latest templates
    /// </summary>
    internal class UpdateMarketingEmailTemplates : Shared.Classes.ThreadManager
    {
        #region Constants

        private const string TEMPLATE_FOLDER = "Images\\Emails";
        private const string TEMPLATE_FOLDER_START_WITH = "template";
        private const string TEMPLATE_FOLDER_FILE_LIST = "templates.xml";

        #endregion Constants

        #region Private Members

        private string _templateFolder;

        #endregion Private Members

        #region Constructors

        internal UpdateMarketingEmailTemplates(string rootPath)
            : base (null, new TimeSpan(1, 0, 0))
        {
            ContinueIfGlobalException = false;
            HangTimeout = 0;
            _templateFolder = Utilities.AddTrailingBackSlash(
                Utilities.AddTrailingBackSlash(rootPath) + 
                TEMPLATE_FOLDER);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            string folderList = String.Empty;
            string[] paths = Directory.GetDirectories(_templateFolder);

            foreach (string s in paths)
            {
                string template = s.Replace(_templateFolder, String.Empty).ToLower();

                if (template.StartsWith(TEMPLATE_FOLDER_START_WITH))
                {
                    folderList += String.Format(template + "\n");
                }
            }

            //save current folder list
            Utilities.FileEncryptedWrite(_templateFolder + TEMPLATE_FOLDER_FILE_LIST, folderList, String.Empty);

            return (true);
        }

        #endregion Overridden Methods
    }

	#endregion Class Global
}

