using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Routing;

using lib = Library;
using Library.Utils;
using Library.BOL.Mail;
using Library.BOL.MissingLinks;
using Classes.RoutineMaintenance;

#if ERROR_MANAGER
using ErrorManager.ErrorClient;
#endif

using Shared;
using Shared.Classes;
using Library.BOL.Products;
using Library.BOL.IPAddresses;

namespace Website.Library.Classes
{
    [Serializable]
    public class BaseWebApplication : System.Web.HttpApplication
    {
        #region Private Members

        /// <summary>
        /// Thread for loading all geoip data into memory
        /// </summary>
        private static GlobalGeoIPCityCache allCityData = new GlobalGeoIPCityCache();

        /// <summary>
        /// Number of minutes for a session to timeout
        /// </summary>
        private const int SESSION_TIME_OUT_MINUTES = 20;

        /// <summary>
        /// Lock object for exclusive access
        /// </summary>
        private static object _lockObject = new object();

        /// <summary>
        /// Unique ID of website for sites that share a database
        /// </summary>
        private static int _websiteID = 1;

        private static System.Configuration.AppSettingsReader configurationAppSettings;

        private static bool _loadsettings = true;

        private static DateTime _lastLoadAttempt = DateTime.Now.AddDays(-1);
        private static int _loadAttempts = 0;

        private static bool _initialiseThreads = true;

        private static bool _allowWebsiteGeoUpdate = false;

        private static MutexEx _mutex = null;

        #endregion Private Members

        #region Internal Members

        internal static BaseWebApplication BaseWebAppInstance { get; set; }

        /// <summary>
        /// Indicates all loaded as expected
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        internal bool IsLoaded
        {
            get
            {
                if (_loadsettings)
                {
                    TimeSpan span = DateTime.Now - _lastLoadAttempt;

                    if (_loadAttempts < 10 && span.TotalSeconds > 180)
                    {
                        _loadAttempts++;

                        if (InitialiseWebsite())
                            _loadsettings = false;

                    }
                }

                return (!_loadsettings);
            }
        }

        internal static object EmailLockObject = new object();

        internal static ArrayList _emailServerHistory = new ArrayList();

        #endregion Internal Members

        #region Public Members

        public static Dictionary<string, Int64> AllRoutes = new Dictionary<string, Int64>();


        public static bool AllowMobileWebsite = false;

        /// <summary>
        /// Address line 1 for master form
        /// </summary>
        public static string AddressLine1 { set; get; }

        /// <summary>
        /// Address line 2 for master form
        /// </summary>
        public static string AddressLine2 { set; get; }

        /// <summary>
        /// Address line 2 for master form
        /// </summary>
        public static string AddressLine3 { set; get; }

        /// <summary>
        /// Enail address used by the website
        /// </summary>
        public static string WebsiteEmail { get; set; }

        /// <summary>
        /// Telephone Number used by website
        /// </summary>
        public static string WebsiteTelephoneNumber { get; set; }

        /// <summary>
        /// Determines wether mail subscription is shown on the website or not
        /// </summary>
        public static bool AllowMailListSubscribers = false;

        /// <summary>
        /// Name of person who supports the application
        /// </summary>
        public static string SupportName { get; set; }

        /// <summary>
        /// Email address of person supporting the application
        /// </summary>
        public static string SupportEMail { get; set; }

        public static string CookieRootURL;

        /// <summary>
        /// Date and time website was started
        /// </summary>
        public static DateTime DateLoaded;

        /// <summary>
        /// Retrieves the page used for login
        /// </summary>
        public static string LoginPage { get; set; }

        public static string RootPath;
        public static string BasketName;
        public static string RootURL;
        public static string RootHost;
        public static bool UseHTTPS;
        public static string Path;

        public static CultureInfo WebsiteCulture = new CultureInfo("en-GB");
        public static bool WebsiteCultureOverride = false;
        public static string DefaultCountrySettings = "GB";

        /// <summary>
        /// if true then the DefaultCountrySettings will be used by default with all new
        /// connections, if false then the initial country (ergo language) will be set from
        /// the users IP address
        /// </summary>
        public static bool ForceInitialDefaultLanguage = false;

        #region VAT/Tax Options

        /// <summary>
        /// Standard VAT Rate for Website
        /// </summary>
        public static Double VatRate;

        /// <summary>
        /// Indicates wether prices include VAT or not
        /// 
        /// If prices include VAT then other vat options will apply to remove VAT when showing etc
        /// </summary>
        public static bool PricesIncludeVAT;


        /// <summary>
        /// if true show items in the basket with VAT, otherwise VAT is removed
        /// </summary>
        public static bool ShowBasketItemsWithVAT = false;

        /// <summary>
        /// If true the subtotal in the basket will be shown with vat
        /// </summary>
        public static bool ShowBasketSubTotalWithVAT = false;


        public static bool ShippingIsTaxable = true;

        #endregion VAT/Tax Options

        #region GeoIP Settings

        public static DateTime GeoIPLastUpdated;
        public static long GeoIPLatestVersion;

        #endregion GeoIP Settings

        /// <summary>
        /// The name of the distributor website
        /// </summary>
        public static string DistributorWebsite { get; set; }

        public static string CookiePrefix = "SD";



        public static int InvoiceVersion = 6;

        public static bool ShowOffers;
        public static bool ShowVoucher;

        /// <summary>
        /// Determines wether the website is in maintenance mode
        /// </summary>
        public static bool MaintenanceMode { get; set; }

        public static string DefaultStyle = "Default";

        public static string CSSCookieName = "style_cookie";
        public static string PageTitle;


        /// <summary>
        /// Shows salon update menu items
        /// </summary>
        public static bool ShowSalonUpdate { get; set; }

        /// <summary>
        /// Show's appointments in user menu items
        /// </summary>
        public static bool ShowAppointments { get; set; }

        /// <summary>
        /// Shows trade download menu in user screen
        /// </summary>
        public static bool ShowTradeDownloads { get; set; }


        /// <summary>
        /// Determines wether custom text is shown on home page scroller
        /// </summary>
        public static bool CustomScrollerStrapLine { get; set; }

        /// <summary>
        /// The custom text to show on home page
        /// </summary>
        public static string CustomScrollerText { get; set; }

        #region Blog

        public static string BlogURL { get; set; }

        #endregion Blog

        #region Affiliate

        public static int AffiliateMaxDays { get; set; }

        #endregion Affiliate

        #region Payment Methods

        #region Payflow

        /// <summary>
        /// Determines wether card payment is shown or not
        /// </summary>
        public static bool ShowPaymentCard;

        /// <summary>
        /// Payflow test mode, if true only staff members and above will see credit card payment pages
        /// </summary>
        public static bool PayflowTestMode { get; set; }

        /// <summary>
        /// Payflow User Name
        /// </summary>
        public static string PayflowUser { get; set; }

        /// <summary>
        /// Payflow Vendor
        /// </summary>
        public static string PayflowVendor { get; set; }

        /// <summary>
        /// Payflow Partner
        /// </summary>
        public static string PayflowPartner { get; set; }

        /// <summary>
        /// Payflow Password
        /// </summary>
        public static string PayflowPassword { get; set; }

        /// <summary>
        /// Acceptable currencies for Pay flow
        /// 
        /// multiple currencies seperted by ;
        /// 
        /// i.e.  USD;GBP;EUR
        /// 
        /// or just GBP
        /// </summary>
        public static string PayflowCurrencies { get; set; }

        #endregion Payflow

        #region Telephone

        public static bool ShowPaymentTelephone;
        public static string PhoneCurrencies;

        #endregion Telephone

        #region Cash On Delivery

        public static bool ShowPaymentCashOnDelivery;
        public static string CashOnDeliveryCurrency;

        #endregion Cash On Delivery

        #region Test Purchase


        public static bool ShowPaymentTestPurchase = false;
        public static string TestPurchaseCurrency;

        #endregion Test Purchase

        #region Cheques

        public static bool ShowPaymentCheque;
        public static string ChequeCurrency;

        #endregion Cheques

        #region Direct Bank Transfer

        public static bool ShowPaymentDirectBankTransfer;
        public static string DirectTransferCurrency;

        #endregion Direct Bank Transfer

        #region Paypal

        //payment methods
        public static bool ShowPaymentPaypal;
        public static bool ShowPaymentPaypoint;

        #endregion Paypal

        #region Suntech

        /// <summary>
        /// SunTech 24Payment Option
        /// </summary>
        public static bool ShowPaymentSunTech24Payment = false;

        /// <summary>
        /// SunTech 24Payment Option
        /// </summary>
        public static bool ShowPaymentSunTechWebATM = false;

        /// <summary>
        /// SunTech 24Payment Option
        /// </summary>
        public static bool ShowPaymentSunTechBuySafe = false;

        #endregion Suntech

        #endregion Payment Methods

        /// <summary>
        /// Is user licence management enabled
        /// </summary>
        public static bool AllowLicences = false;


        public static bool AllowCreditCards;

        /// <summary>
        /// Determines wether Valid From Date for credit cards is hidden or not
        /// </summary>
        public static bool CreditCardHideValidFrom { get; set; }

        /// <summary>
        /// Always shows valid from if user is in the uk
        /// </summary>
        public static bool CreditCardAlwaysShowValidFromForUK { get; set; }

        #region Emails

        /// <summary>
        /// SMTP Host
        /// </summary>
        public static string SMTPHost;

        public static string SMTPUserName;

        public static string SMTPPassword;

        public static bool SMTPUseSSL;

        public static int SMTPPort;

        public static bool SendEmails;

        public static string NoReplyEmail;

        public static string NoReplyName;

        #endregion Emails

        #region Social Media

        public static string SocialMediaFacebook;
        public static string SocialMediaTwitter;
        public static string SocialMediaGPlus;
        public static string SocialMediaRSSFeed;

        /// <summary>
        /// Default twitter tags
        /// </summary>
        public static string TwitterDefaultTags;

        /// <summary>
        /// Google analytics code
        /// </summary>
        public static string GoogleAnalytics = "(function (i, s, o, g, r, a, m) {\r\n" +
            "i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {\r\n" +
            "    (i[r].q = i[r].q || []).push(arguments)\r\n" +
            "}, i[r].l = 1 * new Date(); a = s.createElement(o),\r\n" +
            "m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)\r\n" +
            "})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');\r\n" +
            "ga('create', 'UA-45181427-1', '');\r\n" +
            "ga('send', 'pageview');\r\n";

        #endregion Social Media

        /// <summary>
        /// are characters left to right or right to left??
        /// </summary>
        public static bool UseLeftToRight = true;


        /// <summary>
        /// Determines wether the website will automatically update the geo update table
        /// </summary>
        public static bool AllowWebsiteGeoUpdate
        {
            get
            {
                return (_allowWebsiteGeoUpdate);
            }

            set
            {
                _allowWebsiteGeoUpdate = value;

                if (value)
                {
                    string rootPath = Utilities.AddTrailingBackSlash(RootPath);
                    GeoIPLatestVersion = Shared.XML.GetXMLValue("Version", "GeoIPData", (long)0, rootPath + "download\\Versions.xml");
                    string file = String.Format("{0}Download\\Files\\GeoIP\\GeoIP_{1}.dat", rootPath, GeoIPLatestVersion);

                    if (System.IO.File.Exists(file))
                    {
                        System.IO.FileInfo info = new System.IO.FileInfo(file);
                        GeoIPLastUpdated = info.LastWriteTime;
                    }
                }
            }
        }

        /// <summary>
        /// Determines wether prices are shown if default can not be determined for country
        /// </summary>
        public static bool DefaultShowPrices = true;

        #region Out of Stock

        /// <summary>
        /// If true user can opt to be notified when the item is back in stock
        /// </summary>
        public static bool OutOfStockAllowNotifyUser = false;

        /// <summary>
        /// If true then out of stock will be handled in the product page, otherwise in an external page (faster)
        /// </summary>
        public static bool OutOfStockInPage = false;

        #endregion Out of Stock

        #region Basket Options

        /// <summary>
        /// Determines wether the basket is cleared when order is paid (true) or 
        /// when order is created (false)
        /// </summary>
        public static bool ClearBasketOnPayment = false;

        /// <summary>
        /// Wether free shipping is allowed or not
        /// </summary>
        public static bool FreeShippingAllow { get; set; }

        /// <summary>
        /// The minimum spend before free shipping is applied
        /// </summary>
        public static decimal FreeShippingAmount { get; set; }

        /// <summary>
        /// If true then after an item is added to the basket a redirct to the basket takes place
        /// </summary>
        public static bool JumpToBasketAfterAddItem = false;

        /// <summary>
        /// Maximum number of items of a specific item type that can be added to the basket
        /// 
        /// With fraud this was set to a default of 3
        /// </summary>
        public static int MaximumItemQuantity { get; set; }

        /// <summary>
        /// If true the color of the add to bag button changes depending on the contents of the basket
        /// </summary>
        public static bool AlterTextColorBasedOnBasketContents = false;

        /// <summary>
        /// The text color for the add to bag button if the item does not exist in the shopping bag
        /// </summary>
        public static string ItemDoesNotExistsInShoppingBagTextColour = "white";

        /// <summary>
        /// The text color for the add to bag button if the item already exists in the shopping bag
        /// </summary>
        public static string ItemExistsInShoppingBagTextColour = "red";

        /// <summary>
        /// Allows admins to hide the shopping cart
        /// </summary>
        public static bool HideShoppingCart = false;

        /// <summary>
        /// Shows summary after user adds item
        /// </summary>
        public static bool BasketSummaryShow = true;

        /// <summary>
        /// Hides the basket summary after nn milli seconds
        /// </summary>
        public static int BasketSummaryTimeOut = 10;

        /// <summary>
        /// Auto hides basket summary
        /// </summary>
        public static bool BasketSummaryAutoHide = true;

        /// <summary>
        /// Number of basket id's to retrieve in one go
        /// </summary>
        public static int BasketIDIncrement = 1000;

        #endregion Basket Options

        #region Mail Chimp

        public static string MailChimpAPI = "";
        public static string MailChimpList = "";
        public static string MailChimpKey = "";

        /// <summary>
        /// Optional pop up on main /index.aspx and /offers/offers.aspx page
        /// </summary>
        public static string MailChimpPopupDialog = "";

        #endregion Mail Chimp

        #region Maintenance

        public static bool AutoMaintenanceMode;

        #endregion Maintenance

        #region Rotating Home Banners

        /// <summary>
        /// Static Home Page Banner 1
        /// </summary>
        public static string HomeBanner1 = "";

        /// <summary>
        /// Static Home Page Banner 2
        /// </summary>
        public static string HomeBanner2 = "";

        /// <summary>
        /// Static Home Page Banner 3
        /// </summary>
        public static string HomeBanner3 = "";

        /// <summary>
        /// Static Home Page Banner 4
        /// </summary>
        public static string HomeBanner4 = "";

        /// <summary>
        /// Static Home Page Banner 5
        /// </summary>
        public static string HomeBanner5 = "";


        /// <summary>
        /// Static Home Page Banner 1
        /// </summary>
        public static string HomeBanner1Link = "";

        /// <summary>
        /// Static Home Page Banner 2
        /// </summary>
        public static string HomeBanner2Link = "";

        /// <summary>
        /// Static Home Page Banner 3
        /// </summary>
        public static string HomeBanner3Link = "";

        /// <summary>
        /// Static Home Page Banner 4
        /// </summary>
        public static string HomeBanner4Link = "";

        /// <summary>
        /// Static Home Page Banner 5
        /// </summary>
        public static string HomeBanner5Link = "";

        #endregion Rotating Home Banners

        #region Web Farm/Garden

        public static bool WebFarm = false;

        public static string WebFarmMasterIP;

        public static string WebFarmMutexName;

        #endregion Web Farm/Garden

        #endregion Public Members

        #region Constructors

        public BaseWebApplication()
        {
            // load default settings
            if (_loadsettings)
            {
                try
                {
                    RoutineMaintenance.ImageLocations.Clear();
                    lib.DAL.DALHelper.AllowCaching = true;

                    if (InitialiseWebsite())
                    {
                        _loadsettings = false;

                        RoutineMaintenance.ImageLocations.Add(new ImageCreateLocation(String.Format("{0}Images\\Product\\", GlobalClass.RootPath),
                            "*_148.*", "ProductImages", String.Format("{0}Download\\ProductImages.xml", GlobalClass.RootPath)));

                        RoutineMaintenance.ImageLocations.Add(new ImageCreateLocation(String.Format("{0}Images\\", GlobalClass.RootPath),
                            "*.*", "Images", String.Format("{0}download\\Images.xml", GlobalClass.RootPath)));
                    }
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err);
                }
            }

            BaseWebAppInstance = this;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates wether the website is a static website or interactive
        /// </summary>
        public static bool StaticWebSite { get; set; }

        /// <summary>
        /// Gets the current email status report
        /// </summary>
        public static ArrayList StatusReport
        {
            get
            {
                using (TimedLock.Lock(EmailLockObject))
                {
                    return (_emailServerHistory);
                }
            }
        }


        #endregion Properties

        #region Secondary Background  Tasks


        private static void CreateInitializationThread()
        {
            if (ThreadManager.Exists("Auto Rule Update"))
                ThreadManager.Cancel("Auto Rule Update");

            if (ThreadManager.Exists("Routine Maintenance"))
                ThreadManager.Cancel("Routine Maintenance");

            if (ThreadManager.Exists("GeoIP Update"))
                ThreadManager.Cancel("GeoIP Update");

            if (ThreadManager.Exists("Email Send Thread"))
                ThreadManager.Cancel("Email Send Thread");

            if (ThreadManager.Exists("Update Site Map"))
                ThreadManager.Cancel("Update Site Map");

            if (ThreadManager.Exists("Routine Maintenance Campaigns"))
                ThreadManager.Cancel("Routine Maintenance Campaigns");

            if (!ThreadManager.Exists("Website Initialisation Thread Manager"))
                ThreadManager.ThreadStart(new WebsiteInitialisationThreadManager(),
                    "Website Initialisation Thread Manager", ThreadPriority.Lowest);
        }


        #endregion Secondary Background Tasks

        #region Public Methods

        #region Configuration Settings


        public static DateTime ConfigSettingGet(string name, DateTime defaultValue, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            DateTime Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = lib.LibraryHelperClass.SettingsGetDateTime(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static decimal ConfigSettingGet(string name, decimal defaultValue, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            decimal Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = lib.LibraryHelperClass.SettingsGetDecimal(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static double ConfigSettingGet(string name, double defaultValue, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            double Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = lib.LibraryHelperClass.SettingsGetDouble(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static int ConfigSettingGet(string name, int defaultValue, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            int Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = lib.LibraryHelperClass.SettingsGetInt(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static bool ConfigSettingGet(string name, bool defaultValue, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            bool Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                if (lib.LibraryHelperClass.SettingsExist(keyName))
                {
                    Result = lib.LibraryHelperClass.SettingsGetBool(keyName, defaultValue);
                }
                else
                {
                    lib.LibraryHelperClass.SettingsSet(keyName, defaultValue.ToString());
                }
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static string ConfigSettingGet(string name, string defaultValue, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            string Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                if (lib.LibraryHelperClass.SettingsExist(keyName))
                    Result = lib.LibraryHelperClass.SettingsGet(keyName, defaultValue);
                else
                    lib.LibraryHelperClass.SettingsSet(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static bool ConfigSettingExists(string name, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            if (keyName.Length > 50)
                keyName = keyName.Substring(0, 50);

            return (lib.LibraryHelperClass.SettingsExist(keyName));
        }

        public static void ConfigSettingSet(string name, decimal value, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), isGlobal);
        }

        public static void ConfigSettingSet(string name, double value, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), isGlobal);
        }

        public static void ConfigSettingSet(string name, int value, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), isGlobal);
        }

        public static void ConfigSettingSet(string name, bool value, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), isGlobal);
        }

        public static void ConfigSettingSet(string name, string value, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", _websiteID, name);

            if (keyName.Length > 50)
                keyName = keyName.Substring(0, 50);

            lib.LibraryHelperClass.SettingsSet(keyName, value);
        }

        #endregion Configuration Settings

        #region Global Configuration Settings


        #endregion Global Configuration Settings

        public static void ReloadSettings()
        {
            LoadWebsiteSettingsFromDatabase();
            BaseWebAppInstance.LoadCustomSettings();

            SharedWebBase.ResetWebTitleCache();
            LocalizedLanguages.ClearCountries();
        }

        public static bool IgnoreMissingPage(string page)
        {
            page = page.ToLower();

            if (page.Contains("scriptresource.axd") || page.Contains("error404.aspx") || page.Contains("webresource.axd"))
                return (true);
            else
                return (false);
        }

        public static bool LoadWebsiteSettingsFromDatabase()
        {
            bool Result = false;
            try
            {
                StaticWebSite = false;

                lib.LibraryHelperClass.ResetCache();

                lib.LibraryHelperClass.InitialiseSettings();

                BaseWebApplication.CookiePrefix = "SD";

                #region Default Page Title

                #region Caching

                // caching
                lib.DAL.DALHelper.AllowCaching = ConfigSettingGet("Setting.AllowCaching", true);
                lib.DAL.DALHelper.CacheLimit = new TimeSpan(0, ConfigSettingGet("Setting.CacheLimit", 30), 0);

                #endregion Caching

                //page title
                string pageTitle = ConfigSettingGet("Settings.DefaultTitle", PageTitle);

                if (String.IsNullOrEmpty(pageTitle))
                    pageTitle = PageTitle;

                PageTitle = pageTitle;

                #endregion Default Page Title

                #region Language / Culture Options

                lib.BOL.CustomWebPages.CustomPages.UseCustomPages = ConfigSettingGet("Settings.CustomPages", false);

                WebsiteCulture = new CultureInfo(ConfigSettingGet("Settings.WebsiteCulture", "en-GB"));
                WebsiteCultureOverride = ConfigSettingGet("Settings.WebCultureOverride", false);
                lib.DAL.DALHelper.CultureOverride = ConfigSettingGet("Settings.CultureOverride", "en-GB");

                lib.BOL.Countries.Country defCountry = lib.BOL.Countries.Countries.Get(ConfigSettingGet("Settings.DefaultCountry", "GB"));

                if (defCountry == null)
                    DefaultCountrySettings = "GB";
                else
                    DefaultCountrySettings = defCountry.CountryCode;

                ForceInitialDefaultLanguage = lib.LibraryHelperClass.SettingsGetBool("SITE.FORCEINITIAL.LANGUAGE", false);

                //localized pages

                // indicates wether the change language/currency bar is visible or not
                LocalizedLanguages.Active = lib.LibraryHelperClass.SettingsGetBool("SITE.LANGUAGES", false);

                #endregion Language / Culture Options

                #region Email Settings

                SMTPHost = ConfigSettingGet("Settings.SMTPHost", String.Empty);
                SMTPUserName = ConfigSettingGet("Settings.SMTPUserName", String.Empty);
                SMTPPassword = ConfigSettingGet("Settings.SMTPPassword", String.Empty);
                SMTPUseSSL = ConfigSettingGet("Settings.SMTPSSL", false);
                SMTPPort = ConfigSettingGet("Settings.SMTPPort", 25);
                SendEmails = ConfigSettingGet("Settings.SendEmail", false);

                #endregion Email Settings

                #region Shopping Cart

                MaximumItemQuantity = ConfigSettingGet("Settings.MaximumItemQuantity", 5);
                JumpToBasketAfterAddItem = ConfigSettingGet("Settings.JumpToBasketAfterAddItem", false);
                BasketName = ConfigSettingGet("Settings.ShoppingBasketName", String.Empty);
                Website.Library.GlobalClass.BasketName = ConfigSettingGet("Settings.ShoppingBasketName", String.Empty);
                HideShoppingCart = ConfigSettingGet("Settings.HideShoppingCart", false);

                BasketSummaryShow = ConfigSettingGet("Settings.BasketSummaryShow", true);
                BasketSummaryAutoHide = ConfigSettingGet("Settings.BasketSummaryAutoHide", false);
                BasketSummaryTimeOut = Shared.Utilities.CheckMinMax(ConfigSettingGet("SettingsBasketSummaryTimeout", 10), 5, 25);
                BasketIDIncrement = Shared.Utilities.CheckMinMax(ConfigSettingGet("Settings.BasketIDCount", 500), 100, 10000);

                #endregion Shopping Cart

                #region Payment Providers

                #region Payment Providers Paypal

                //paypal settings
                ShowPaymentPaypal = ConfigSettingGet("Settings.ShowPaymentPaypal", true);

                if (ShowPaymentPaypal)
                {
                    NVPAPICaller.APIUsername = ConfigSettingGet("Settings.PaypalAPIUserName", String.Empty);
                    NVPAPICaller.APIPassword = ConfigSettingGet("Settings.PaypalAPIPassword", String.Empty);
                    NVPAPICaller.APISignature = ConfigSettingGet("Settings.PaypalAPISignature", String.Empty);
                    NVPAPICaller.Subject = ConfigSettingGet("Settings.PaypalAPISubject", String.Empty);
                    NVPAPICaller.BNCode = ConfigSettingGet("Settings.PaypalAPIBNCode", String.Empty);
                    NVPAPICaller.DefaultCurrency = ConfigSettingGet("Settings.PaypalAPICurrency", "GBP;USD");
                    NVPAPICaller.APISuccessURL = ConfigSettingGet("Settings.PaypalSuccessURL", String.Empty);
                    NVPAPICaller.APIFailURL = ConfigSettingGet("Settings.PaypalFailURL", String.Empty);
                    Classes.Paypoint.ValCard.Currencies = ConfigSettingGet("Settings.PaynetCurrency", "GBP");
                }

                #endregion Payment Providers Paypal

                #region Payment Providers Cheque

                ShowPaymentCheque = ConfigSettingGet("Settings.ShowPaymentCheque", true);
                ChequeCurrency = ConfigSettingGet("Settings.ChequeCurrency", "USD");

                #endregion Payment Providers Cheque

                #region Paypoint

                ShowPaymentPaypoint = ConfigSettingGet("Settings.ShowPaymentPaypoint", false);

                #endregion Paypoint

                #region Payment Provider Telephone

                ShowPaymentTelephone = ConfigSettingGet("Settings.ShowPaymentTelephone", true);
                PhoneCurrencies = ConfigSettingGet("Settings.PhoneCurrency", "GBP");

                #endregion Payment Provider Telephone

                #region Payment Provider Cash On Delivery

                ShowPaymentCashOnDelivery = ConfigSettingGet("Settings.ShowPaymentCOD", false);
                ShowPaymentDirectBankTransfer = ConfigSettingGet("Settings.ShowPaymentDBT", false);
                CashOnDeliveryCurrency = ConfigSettingGet("Settings.CODCurrency", "GBP");

                #endregion Payment Provider Cash On Delivery

                #region Payment Provider Payflow

                //payflow
                ShowPaymentCard = ConfigSettingGet("Settings.ShowPaymentCard", false);

                if (ShowPaymentCard)
                {
                    PayflowTestMode = ConfigSettingGet("Settings.PayflowTestMode", true);
                    PayflowPartner = ConfigSettingGet("Settings.PayflowPartner", String.Empty);
                    PayflowVendor = ConfigSettingGet("Settings.PayflowVendor", String.Empty);
                    PayflowUser = ConfigSettingGet("Settings.PayflowUser", String.Empty);
                    PayflowPassword = ConfigSettingGet("Settings.PayflowPassword", String.Empty);
                    PayflowCurrencies = ConfigSettingGet("Settings.PayflowCurrencies", "GBP;USD");
                }

                #endregion Payment Provider Payflow

                #region Direct Bank Transfer

                //currencies for payment providers
                DirectTransferCurrency = ConfigSettingGet("Settings.DTCurrency", "NZD");

                #endregion Direct Bank Transfer

                #region Payment Providers Sun Tech

                //Sun Tech Buy Safe
                ShowPaymentSunTechBuySafe = ConfigSettingGet("Settings.AllowSunTechBuySafe", false);

                if (ShowPaymentSunTechBuySafe)
                {
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechBuySafe.SupportedCurrencies = ConfigSettingGet("Settings.BuySafeCurrencies", "GBP");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechBuySafe.MerchantID = ConfigSettingGet("Settings.BuySafeMerchantID", "");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechBuySafe.MerchantPassword = ConfigSettingGet("Settings.BuySafeMerchantPW", "");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechBuySafe.TestMode = ConfigSettingGet("Settings.BuySafeTestMode", true);
                }

                //Sun Tech 24Payment
                ShowPaymentSunTech24Payment = ConfigSettingGet("Settings.AllowSunTech24Payment", false);

                if (ShowPaymentSunTech24Payment)
                {
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTech24Payment.SupportedCurrencies = ConfigSettingGet("Settings.24PaymentCurrencies", "GBP");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTech24Payment.MerchantID = ConfigSettingGet("Settings.24PaymentMerchantID", "");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTech24Payment.MerchantPassword = ConfigSettingGet("Settings.24PaymentMerchantPW", "");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTech24Payment.TestMode = ConfigSettingGet("Settings.24PaymentTestMode", true);
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTech24Payment.DueDateDays = ConfigSettingGet("Settings.24PaymentDueDays", 30);
                }

                //Sun Tech WebATM
                ShowPaymentSunTechWebATM = ConfigSettingGet("Settings.AllowSunTechWebATM", false);

                if (ShowPaymentSunTechWebATM)
                {
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechWebATM.SupportedCurrencies = ConfigSettingGet("Settings.WebATMCurrencies", "GBP");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechWebATM.MerchantID = ConfigSettingGet("Settings.WebATMMerchantID", "");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechWebATM.MerchantPassword = ConfigSettingGet("Settings.WebATMMerchantPW", "");
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechWebATM.TestMode = ConfigSettingGet("Settings.WebATMTestMode", true);
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechWebATM.BillDateDays = ConfigSettingGet("Settings.WebATMBillDays", 30);
                    Website.Library.Classes.PaymentOptions.PaymentOptionSunTechWebATM.DueDateDays = ConfigSettingGet("Settings.WebAMTDueDays", 30);
                }

                #endregion Payment Providers Sun Tech

                #region Credit Card Options

                //credit cards
                CreditCardAlwaysShowValidFromForUK = ConfigSettingGet("Settings.AlwaysShowCCForUK", true);
                CreditCardHideValidFrom = ConfigSettingGet("Settings.AlwaysHideValidFrom", false);
                AllowCreditCards = ConfigSettingGet("Settings.AllowCreditCards", true);

                #endregion Credit Card Options

                #region Test Purchase Options

                ShowPaymentTestPurchase = ConfigSettingGet("Settings.TestPurchase", false);
                Classes.PaymentOptions.PaymentOptionTestPurchase.SupportedCurrencies = ConfigSettingGet(
                    "Settings.TestPurchaseCurrencies", String.Empty);

                #endregion Test Purchase Options

                #endregion Payment Providers

                #region General Contact Details

                WebsiteTelephoneNumber = ConfigSettingGet("Settings.WebsiteTelephoneNumber", String.Empty);
                WebsiteEmail = ConfigSettingGet("Settings.WebsiteEmail", String.Empty);
                AddressLine1 = ConfigSettingGet("Settings.AddressLine1", String.Empty);
                AddressLine2 = ConfigSettingGet("Settings.AddressLine2", String.Empty);
                AddressLine3 = ConfigSettingGet("Settings.AddressLine3", String.Empty);

                #endregion General Contact Details

                #region Social Media

                SocialMediaFacebook = ConfigSettingGet("Settings.Facebook", "http://www.facebook.com/Heavenskincare");
                SocialMediaTwitter = ConfigSettingGet("Settings.Twitter", "https://twitter.com/#!/Heavenskincare");
                SocialMediaGPlus = ConfigSettingGet("Settings.GPlus", "https://plus.google.com/u/0/+DeborahMitchellheaven/posts");
                SocialMediaRSSFeed = ConfigSettingGet("Settings.RSSFeed", "http://heavenbydeborahmitchell.me/feed/");

                TwitterDefaultTags = ConfigSettingGet("Settings.TwitterTags", String.Empty);

                #endregion Social Media

                #region Maintenance Options

                AutoMaintenanceMode = true;
                MaintenanceMode = ConfigSettingGet("Settings.MaintenanceMode", false);

                Website.Library.GlobalClass.AllowRoutineMaintenance = ConfigSettingGet("Settings.AllowRoutineMaintenance", true);
                Website.Library.GlobalClass.CreateXMLImageFiles = ConfigSettingGet("Settings.CreateXMLImageFiles", false);

                #endregion Maintenance Options

                #region Geo Update

                AllowWebsiteGeoUpdate = false;



                #endregion Geo Update

                #region Rotating Home Page Banners

                HomeBanner1 = ConfigSettingGet("HomeBanner1", String.Empty);
                HomeBanner2 = ConfigSettingGet("HomeBanner2", String.Empty);
                HomeBanner3 = ConfigSettingGet("HomeBanner3", String.Empty);
                HomeBanner4 = ConfigSettingGet("HomeBanner4", String.Empty);
                HomeBanner5 = ConfigSettingGet("HomeBanner5", String.Empty);

                HomeBanner1Link = ConfigSettingGet("HomeBanner1Link", String.Empty);
                HomeBanner2Link = ConfigSettingGet("HomeBanner2Link", String.Empty);
                HomeBanner3Link = ConfigSettingGet("HomeBanner3Link", String.Empty);
                HomeBanner4Link = ConfigSettingGet("HomeBanner4Link", String.Empty);
                HomeBanner5Link = ConfigSettingGet("HomeBanner5Link", String.Empty);

                #endregion Rotating Home Page Banners

                #region Google Analytics

                GoogleAnalytics = ConfigSettingGet("SETTINGS.GOOGLE.ANALYTICS", GoogleAnalytics);

                #endregion Google Analytics

                #region Mail List Subscribers

                // mail list subscription
                AllowMailListSubscribers = ConfigSettingGet("SETTINGS.MAILLIST.ALLOW", false);

                #endregion Mail List Subscribers

                #region Mail Chimp integration

                //mail chimp
                MailChimpAPI = ConfigSettingGet("Settings.MailChimpAPI", String.Empty);
                MailChimpList = ConfigSettingGet("Settings.MailChimpList", String.Empty);
                MailChimpKey = ConfigSettingGet("Settings.MailChimpKey", String.Empty);
                MailChimpPopupDialog = ConfigSettingGet("Settings.MailChimpPopup", String.Empty);

                if (String.IsNullOrEmpty(MailChimpKey))
                {
                    MailChimpKey = Shared.Utilities.RandomPassword(25);
                    ConfigSettingSet("Settings.MailChimpKey", MailChimpKey);
                }

                #endregion Mail Chimp Integration

                #region User Menu Items

                ShowSalonUpdate = ConfigSettingGet("Settings.UserMenuSalonUpdates", true);
                ShowAppointments = ConfigSettingGet("Settings.UserMenuAppointments", true);
                ShowTradeDownloads = ConfigSettingGet("Settings.UserMenuTradeDownloads", true);

                #endregion User Menu Items


                LoginPage = ConfigSettingGet("Settings.LoginPage", "/Members/Login.aspx");
                RootPath = ConfigSettingGet("Settings.RootPath", String.Empty);

                //email/smtp settings
                SupportName = ConfigSettingGet("Settings.SupportName", String.Empty);
                SupportEMail = ConfigSettingGet("Settings.SupportEMail", String.Empty);

                #region VAT/Tax Settings

                lib.DAL.DALHelper.HideVATOnWebsiteAndInvoices = ConfigSettingGet("Settings.HideVATOnWebsiteAndInvoices", false);
                VatRate = ConfigSettingGet("Settings.VatRate", 20.0);
                PricesIncludeVAT = ConfigSettingGet("Settings.PricesIncludeVAT", false);
                ShippingIsTaxable = ConfigSettingGet("Settings.ShippingIsTaxable", ShippingIsTaxable);
                ShowBasketItemsWithVAT = ConfigSettingGet("Settings.ShowBasketItemsWithVAT", ShowBasketItemsWithVAT);
                ShowBasketSubTotalWithVAT = ConfigSettingGet("Settings.ShowBasketSubTotalWithVAT", ShowBasketSubTotalWithVAT);

                #endregion VAT/Tax Settings

                RootURL = ConfigSettingGet("Settings.RootURL", String.Empty);
                UseHTTPS = ConfigSettingGet("Settings.UseHTTPS", true);
                Path = ConfigSettingGet("Settings.Path", String.Empty);
                ShowOffers = ConfigSettingGet("Settings.ShowOffers", true);
                ShowVoucher = ConfigSettingGet("Settings.ShowVoucher", false);

                if (!String.IsNullOrEmpty(RootURL))
                {
                    Uri u = new Uri(RootURL);
                    RootHost = u.Host;
                }

                Website.Library.GlobalClass.WebsiteDateFormat = ConfigSettingGet("Settings.WebsiteDateFormat", String.Empty);

                Website.Library.GlobalClass.RootPath = Path;
                Website.Library.GlobalClass.RootURL = RootURL;


                lib.DAL.DALHelper.RegisterWebsite(GlobalClass.RootURL);

                DistributorWebsite = ConfigSettingGet("Settings.DistributorWebsite", String.Empty);

                NoReplyName = ConfigSettingGet("Settings.NoReplyName", String.Empty);
                Website.Library.GlobalClass.NoReplyName = NoReplyName;

                NoReplyEmail = ConfigSettingGet("Settings.NoReplyEmail", String.Empty);
                Website.Library.GlobalClass.NoReplyEmail = NoReplyEmail;

                UseLeftToRight = ConfigSettingGet("Settings.UseLeftToRight", true);
                Website.Library.GlobalClass.UseLeftToRight = UseLeftToRight;

                #region Basket

                FreeShippingAllow = ConfigSettingGet("Settings.FreeShippingAllow", false);

                FreeShippingAmount = ConfigSettingGet("Settings.FreeShippingSpend", 100.00m);

                ClearBasketOnPayment = ConfigSettingGet("Settings.ClearBasketOnPayment", false, true);

                #endregion Basket

                lib.DAL.DALHelper.OverrideCostMultiplier = ConfigSettingGet("Settings.OverrideCostMultiplier", false);
                lib.DAL.DALHelper.OverrideCostMultiplierValue = ConfigSettingGet("Settings.OverrideCostMultiplierValue", 0.0);

                lib.DAL.DALHelper.WebsiteAddress = RootURL;

                #region Global Page Options

                GlobalClass.ShowSalonsMenu = ConfigSettingGet("Settings.ShowSalons", true);
                GlobalClass.ShowTreatmentsMenu = ConfigSettingGet("Settings.ShowTreatments", false);
                GlobalClass.ShowDistributorsMenu = ConfigSettingGet("Settings.ShowDistributors", false);
                GlobalClass.ShowTipsAndTricksMenu = ConfigSettingGet("Settings.ShowTipsAndTricks", false);
                GlobalClass.ShowDownloadMenu = ConfigSettingGet("Settings.ShowDownloads", false);
                GlobalClass.ShowTradeMenu = ConfigSettingGet("Settings.ShowTrade", false);

                GlobalClass.ShowTreatmentsBrochure = ConfigSettingGet("Settings.ShowTreatmentBrochure", true);
                GlobalClass.ShowTermsAndConditions = ConfigSettingGet("Settings.ShowTermsAndConditions", false);
                GlobalClass.ShowPrivacyPolicy = ConfigSettingGet("Settings.ShowPrivacyPolicy", false);
                GlobalClass.ShowReturnsPolicy = ConfigSettingGet("Settings.ShowReturnsPolicy", false);

                #endregion Global Page Options

                AlterTextColorBasedOnBasketContents = ConfigSettingGet("Settings.AlterTextColorBasedOnBasketContents", false);
                ItemDoesNotExistsInShoppingBagTextColour = ConfigSettingGet("Settings.ItemDoesNotExistsInShoppingBagTextColour", "white");
                ItemExistsInShoppingBagTextColour = ConfigSettingGet("Settings.ItemExistsInShoppingBagTextColour", "white");

                // out of stock options
                OutOfStockAllowNotifyUser = ConfigSettingGet("Settings.OutOfStockAllowNotifyUser", false);
                OutOfStockInPage = ConfigSettingGet("Settings.OutOfStockInPage", false);

                GlobalClass.InternalCache.MaximumAge = lib.DAL.DALHelper.CacheLimit;

                DefaultShowPrices = ConfigSettingGet("Settings.ShowPriceDefault", true);

                GlobalClass.StyleSheet = ConfigSettingGet("SITE.STYLE_SHEET", "Style9.css");
                GlobalClass.StyleSheetLocation = ConfigSettingGet("SITE.STYLE_SHEET_LOCATION", GlobalClass.StyleSheetLocation);

                CustomScrollerStrapLine = ConfigSettingGet("Settings.CustomIndexScroller", false);
                CustomScrollerText = ConfigSettingGet("Settings.CustomScrollerText",
                    Languages.LanguageStrings.CheckOutLatestGreatest);

                #region Blog

                BlogURL = ConfigSettingGet("BlogURL", String.Empty, true);

                #endregion Blog

                #region Affiliates

                AffiliateMaxDays = Shared.Utilities.StrToInt(lib.LibraryHelperClass.SettingsGet(
                    StringConstants.AFFILIATE_LIVE_DAYS, StringConstants.SYMBOL_SEVEN), 7);


                #endregion Affiliates

                #region Web Farm/Garden

                WebFarm = ConfigSettingGet("WEB.FARM", false, true);
                WebFarmMasterIP = ConfigSettingGet("WEB.FARM.MASTER", String.Empty, true);
                WebFarmMutexName = ConfigSettingGet("WEB.FARM.MUTEX", "WEB_FARM_MUTEX", true);

                #endregion Web Farm/Garden

                CreateInitializationThread();

                Result = true;

            }
            catch (Exception error)
            {
                EventLog.Add(error);
            }

            return (Result);
        }

        public virtual void LoadCustomSettings()
        {

        }

        /// <summary>
        /// User session created
        /// </summary>
        /// <param name="session">Session created</param>
        public virtual void SessionCreated(UserSession session)
        {

        }

        /// <summary>
        /// User Session closing
        /// </summary>
        /// <param name="session"></param>
        public virtual void SessionClosed(UserSession session)
        {

        }

        /// <summary>
        /// Allows the partial saving of data for the session
        /// </summary>
        /// <param name="session"></param>
        public virtual void SessionSaveData(UserSession session)
        {

        }

        public virtual void SessionSavePage(UserSession session, PageViewData page)
        {

        }

        /// <summary>
        /// Method called when a session needs to be retrieved
        /// </summary>
        /// <param name="session"></param>
        public virtual UserSession SessionRetrieve(string sessionID)
        {
            return (null);
        }

        #endregion Public Methods

        #region Protected Methods

        #region Error Manager

#if ERROR_MANAGER
        public static void InitialiseErrorManager()
        {
            // Code that runs when an unhandled error occurs
            ErrorClient.InitWebErrorClient(new ErrorManager.ErrorClient.Options("em.heavenskincare.com", 37789, "HeavenSkinCare", "Heaven_!3B"));
            ErrorClient.GetErrorClient.AdditionalInformation += new AdditionalInformationHandler(GetErrorClient_AdditionalInformation);
            Library.ErrorHandling.InternalException += ErrorHandling_InternalException;

        }
#endif

        #endregion Error Manager

        #region Application Events

        protected void ApplicationStart()
        {
            // only keep logs for 7 days
            EventLog.Initialise(7);

            UserSessionManager.InitialiseSessionManager(new TimeSpan(0, SESSION_TIME_OUT_MINUTES, 0));

            using (TimedLock.Lock(_lockObject))
            {
                Shared.EventLog.Add("ApplicationStart");
                try
                {
                    if (_initialiseThreads)
                    {
                        EventLog.Add("Initialise Thread Manager");
                        ThreadManager.ThreadExceptionRaised += ThreadManager_ThreadExceptionRaised;
                        ThreadManager.ThreadAbortForced += ThreadManager_ThreadAbortForced;
                        ThreadManager.ThreadCancellAll += ThreadManager_ThreadCancellAll;
                        ThreadManager.ThreadForcedToClose += ThreadManager_ThreadForcedToClose;
                        ThreadManager.ThreadStarted += ThreadManager_ThreadStarted;
                        ThreadManager.ThreadStopped += ThreadManager_ThreadStopped;
                        ThreadManager.Initialise();
                        ThreadManager.AllowThreadPool = true;
                        ThreadManager.MaximumPoolSize = 100000;
                        _initialiseThreads = false;
                    }

                    //InitialiseWebDefender();
#if ERROR_MANAGER
                    InitialiseErrorManager();
#endif
                    SharedWebBase.ApplicationStart();
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err);
                }

                if (WebFarm &&
                    !String.IsNullOrEmpty(WebFarmMutexName) &&
                    Shared.Utilities.LocalIPAddress(WebFarmMasterIP))
                {
                    // if the application is part of a web farm/garden, then only one process in the entire farm
                    // can be the "master" process.  The master process is determined when WebFarmMasterIP ip address
                    // matches the ip address on the computer it is loaded on.  Further, on that single computer
                    // a global mutex is created, the first process on the computer that matches the ip address wins, all 
                    // others will not be the master controller.

                    _mutex = new MutexEx(WebFarmMutexName);

                    if (!_mutex.Exists)
                    {
                        _mutex.CreateMutex();
                    }

                    Shared.EventLog.Add(String.Format("Process ID: {0}; Created: {1}; Name: {2}",
                        System.Diagnostics.Process.GetCurrentProcess().Id, _mutex.MutexCreated, _mutex.Name));
                }

            }


            RegisterRoutes(RouteTable.Routes);
        }

        protected void ApplicationEnd()
        {
            EventLog.Add("ApplicationEnd");

            if (_mutex != null)
                _mutex.Dispose();

            // close session manager
            UserSessionManager.CancelAll();
            UserSessionManager.Finalise();

            //shut down internal threads
            Shared.EventLog.Add("Finalise Thread Manager");
            ThreadManager.Finalise();

            ThreadManager.ThreadAbortForced -= ThreadManager_ThreadAbortForced;
            ThreadManager.ThreadCancellAll -= ThreadManager_ThreadCancellAll;
            ThreadManager.ThreadForcedToClose -= ThreadManager_ThreadForcedToClose;
            ThreadManager.ThreadStarted -= ThreadManager_ThreadStarted;
            ThreadManager.ThreadStopped -= ThreadManager_ThreadStopped;
            _initialiseThreads = true;
        }

        #endregion Application Events

        protected bool IgnoreErrorMessage(string Error)
        {
            return (SharedWebBase.IgnoreErrorMessage(Error));
        }

        protected string CanRedirect(string File)
        {
            string Result = "";

            string s = File;

            //get the missing page
            int pos = s.IndexOf("'") + 1;

            s = s.Substring(pos);
            int i = 0;

            while (s.Contains("'"))
            {
                s = s.Substring(0, s.Length - 1);

                //as a safety precaution break out the loop after thirty iterations
                i++;

                if (i > 30)
                    break;
            }

            MissingLink link = MissingLinks.MissingLinkGet(s);

            if (link != null)
                Result = link.RedirectLink;

            return (Result);
        }

        protected void SetUserLastVisit(int iteration)
        {
            try
            {
                int Result = -1;

                if (Request.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, DistributorWebsite)] != null)
                {
                    if (Request.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, DistributorWebsite)].Expires.Year != (DateTime.Now.Year - 1))
                    {
                        string s1 = Shared.Utilities.Decrypt(HttpUtility.UrlDecode(Request.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, DistributorWebsite)].Value));

                        if (s1 != "")
                        {
                            Result = SharedUtils.StrToIntDef(s1, -1);
                        }
                    }
                }

                if (Result > -1)
                {

                    lib.BOL.Users.User user = lib.BOL.Users.User.UserGet(Result);

                    if (user != null)
                    {
                        user.LastVisit = DateTime.Now;
                    }
                }
            }
            catch (Exception err)
            {
                if (err.Message.Contains("update conflicts with concurrent update"))
                {
                    if (iteration < 10)
                    {
                        SetUserLastVisit(iteration + 1);
                    }
                    else
                        throw;
                }
                else
                    throw;
            }
        }

        /// <summary>
        /// Determines whether to auto ban an ip address
        /// </summary>
        /// <param name="path">path of file being sought</param>
        /// <param name="ipAddress">ip address of user</param>
        /// <returns>true if ip address should be banned, otherwise false</returns>
        protected static bool AutoBanIPAddress(string path, string ipAddress, bool ForceBan = false)
        {
            if (path.ToLower().Contains("/staff/"))
                return (false);

            if (path.ToLower().Contains("/admin/"))
                return (false);

            if (path.ToLower().Contains(".axd"))
                return (false);

            return (lib.WebsiteAdministration.AutoBanIPAddress(path, ipAddress, ForceBan));
        }

        /// <summary>
        /// Initialises all settings for the website
        /// </summary>
        protected bool InitialiseWebsite()
        {
            bool Result = false;

            try
            {
                AutoMaintenanceMode = true;

                _lastLoadAttempt = DateTime.Now;

                if (!lib.DAL.DALHelper.TestConnection())
                    throw new Exception("TestConnection Failed");

                DateLoaded = DateTime.Now;

                configurationAppSettings = new System.Configuration.AppSettingsReader();
                _websiteID = ((int)(configurationAppSettings.GetValue("Settings.WebsiteID", typeof(int))));
                lib.DAL.DALHelper.WebsiteID = _websiteID;

                if (!LoadWebsiteSettingsFromDatabase())
                    throw new Exception("Failed to load settings from database");

                LoadCustomSettings();

                // the following line will put currencies in cache for speed when
                // starting user sessions
                lib.BOL.Basket.Currencies.Get();

                UserSessionManager.InitialiseWebsite = false;
                UserSessionManager.Instance.OnSessionCreated += Instance_OnSessionCreated;
                UserSessionManager.Instance.OnSessionClosing += Instance_OnSessionClosing;
                UserSessionManager.Instance.IPAddressDetails += Instance_IPAddressDetails;
                UserSessionManager.Instance.OnSessionRetrieve += Instance_OnSessionRetrieve;
                UserSessionManager.Instance.OnSessionSave += Instance_OnSessionSave;
                UserSessionManager.Instance.OnSavePage += Instance_OnSavePage;
                ThreadManager.ThreadCpuChanged += ThreadManager_ThreadCpuChanged;
                Result = true;
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);

            }

            return (Result);
        }

        void ThreadManager_ThreadCpuChanged(object sender, EventArgs e)
        {
            //if (e.Thread.Name != "Management Thread")
            //{
            //Shared.EventLog.Add(String.Format("Thread Usage - Name: {0}; Process Usage: {1}; Previous Process Usage: {2}; System Usage: {3}",
            //    e.Thread.Name, e.Thread.ProcessCpuUsage.ToString("n1"), e.Thread.PreviousProcessCpuUsage.ToString("n1"), e.Thread.SystemCpuUsage.ToString("n1")));
            //}
        }

        #region SessionManager Events

        private void Instance_IPAddressDetails(object sender, IpAddressArgs e)
        {
#if CACHE_IP_CITY_DATA
            IPCity city = GlobalGeoIPCityCache.GetIPCity(e.IPAddress, true);
#else
            IPCity city = GlobalGeoIPCityCache.GetIPCity(e.IPAddress);
#endif

            if (city != null)
            {
                e.IPUniqueID = city.ID;
                e.Latitude = city.Latitude;
                e.Longitude = city.Longitude;
                e.Region = city.Region;
                e.CityName = city.City;
                e.CountryCode = city.Country;
            }
            else
                e.CountryCode = "ZZ";
        }

        void Instance_OnSessionRetrieve(object sender, UserSessionRequiredArgs e)
        {
            e.Session = SessionRetrieve(e.SessionID);
        }

        private void Instance_OnSessionClosing(object sender, Shared.UserSessionArgs e)
        {
            SessionClosed(e.Session);
        }

        private void Instance_OnSessionCreated(object sender, Shared.UserSessionArgs e)
        {
            SessionCreated(e.Session);
        }

        private void Instance_OnSavePage(object sender, UserPageViewArgs e)
        {
            SessionSavePage(e.Session, e.Page);
        }

        private void Instance_OnSessionSave(object sender, UserSessionArgs e)
        {
            SessionSaveData(e.Session);
        }

        #endregion SessionManager Events

        #endregion Protected Methods

        #region Internal Methods

        internal static bool WebFarmMaster()
        {
            if (!WebFarm || _mutex == null)
                return (true);

            if (_mutex.Exists && _mutex.MutexCreated)
                return (true);

            return (false);
        }

        #endregion Internal Methods

        #region Public Methods

        #region Send Emails

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="ErrorMessage">Error Message</param>
        public static void SendEmail(string ErrorMessage)
        {
            SendEMail(SupportName, SupportEMail, String.Format("Website Error ({0})", DistributorWebsite), ErrorMessage);
        }

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Title">Title of email</param>
        public static void SendEmail(string Title, string Message)
        {
            SendEMail(SupportName, SupportEMail, Title, Message);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg)
        {
            SendEMail(ToName, ToEMail, Title, Msg, NoReplyName, NoReplyEmail);
        }

        public static void SendEMail(string Title, string Msg)
        {
            SendEMail(SupportName, SupportEMail, Title, Msg, NoReplyName, NoReplyEmail);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg, string FromName, string FromEMail)
        {
            Emails.Add(ToName, ToEMail, FromName, FromEMail, Title, Msg);

            if (!SendEmails)
                return;
        }

        #endregion Send Emails

        #endregion Public Methods

        #region Private Methods


        #region Thread Manager Events

        void ThreadManager_ThreadExceptionRaised(object sender, ThreadManagerExceptionEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Exception: {0}", e.Thread.ToString()));
            Shared.EventLog.Add(e.Error);
        }

        void ThreadManager_ThreadStopped(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Stopped: {0}", e.Thread.ToString()));
        }

        void ThreadManager_ThreadStarted(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Started: {0}", e.Thread.ToString()));
        }

        void ThreadManager_ThreadForcedToClose(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Forced To Close: {0}", e.Thread.ToString()));
        }

        void ThreadManager_ThreadCancellAll(object sender, EventArgs e)
        {
            Shared.EventLog.Add("Thread Cancell All: {0}");
        }

        void ThreadManager_ThreadAbortForced(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Abort Forced: {0}", e.Thread.ToString()));
        }

        #endregion Thread Manager Events

        private void RegisterRoutes(RouteCollection routes)
        {
            using (routes.GetWriteLock())
            {
                routes.MapPageRoute("homeRoute",
                    "Home/",
                    "~/Index.aspx");

                routes.MapPageRoute("contactUsRoute",
                    "Contact-Us/",
                    "~/ContactUs.aspx");

                routes.MapPageRoute("aboutRoute",
                    "About/",
                    "~/About.aspx");

                routes.MapPageRoute("termsRoute",
                    "Terms/",
                    "~/Terms.aspx");

                routes.MapPageRoute("productsGroupRoute",
                    "All-Products/Group/{group}/{name}/",
                    "~/Products/Index.aspx");

                foreach (ProductType productType in ProductTypes.Get())
                {
                    Products allProducts = Products.Get(productType, 1, 10000);

                    foreach (Product product in allProducts)
                    {
                        if (!AllRoutes.ContainsKey(product.NameSEO))
                        {
                            // add primary product
                            AllRoutes.Add(product.NameSEO, product.ID);

                            // add primary group/product
                            AllRoutes.Add(String.Format("{0}{1}", product.PrimaryGroup.Description,
                                product.NameSEO), product.ID);
                        }
                    }
                }
                
                routes.MapPageRoute("groupPageRoute",
                    "All-Products/Group/{group}/Page/{page}/",
                    "~/Products.aspx");

                routes.MapPageRoute("groupRoute",
                    "All-Products/Group/{group}/",
                    "~/Products.aspx");

                foreach (lib.MemberLevel mLevel in Enum.GetValues(typeof(lib.MemberLevel)))
                {
                    foreach (ProductGroup group in ProductGroups.Get(mLevel, true))
                    {
                        string keyName = String.Format("{0}{1}", mLevel.ToString(), group.SEODescripton);

                        if (!AllRoutes.ContainsKey(keyName))
                            AllRoutes.Add(keyName, group.ID);
                    }
                }

                routes.MapPageRoute("productsRoute",
                    "All-Products/",
                    "~/Products.aspx");

                routes.MapPageRoute("productsPageRoute",
                    "All-Products/Page/{page}/",
                    "~/Products.aspx");

                // basket
                routes.MapPageRoute("basketShopping",
                    "Shopping/Basket/",
                    "~/Basket/Basket.aspx");

                routes.MapPageRoute("basketShoppingSignIn",
                    "Shopping/Basket/SignIn/",
                    "~/Basket/BasketSignIn.aspx");

                routes.MapPageRoute("basketShoppingAddress",
                    "Shopping/Basket/Delivery-Address/",
                    "~/Basket/BasketDeliveryAddress.aspx");

                routes.MapPageRoute("basketShoppingSummary",
                    "Shopping/Basket/Confirm-Order/",
                    "~/Basket/BasketCheckout.aspx");

                routes.MapPageRoute("basketShoppingOrderComplete",
                    "Shopping/Basket/Order-Complete/",
                    "~/Basket/BasketOrderComplete.aspx");

                routes.MapPageRoute("basketShoppingOrderCompleteType",
                    "Shopping/Basket/Order-Complete/Payment-Type/{type}/",
                    "~/Basket/BasketOrderComplete.aspx");

                // help desk
                routes.MapPageRoute("helpDeskFeedback",
                    "Helpdesk/Feedback/",
                    "~/Helpdesk/Feedback.aspx");

                routes.MapPageRoute("helpDeskFeedbackPage",
                    "Helpdesk/Feedback/Page/{page}/",
                    "~/Helpdesk/Feedback.aspx");
            }
        }


#if ERROR_MANAGER
        private static void GetErrorClient_AdditionalInformation(object sender, AdditionalInformationEventArgs e)
        {
            e.Information = DateTime.Now.ToString("g");
        }
#endif

        private static void ErrorHandling_InternalException(object sender, lib.BOLEvents.InternalErrorEventArgs e)
        {
            string msg = String.Format("Internal Exception in Website - {5}\r\n\r\nMethod: {0}\r\n\r\nMessage: {4}\r\n\r\nSource: {1}\r\n\r\nParameters:\r\n\r\n{2}\r\n\r\nCallstack:\r\n\r\n{3}",
                e.Method, e.Source, e.Parameters, e.CallStack, e.Message, DistributorWebsite);

            try
            {
#if ERROR_MANAGER
                if (!ErrorClient.GetErrorClient.SendError(
                    new ErrorManager.ErrorClient.Options("em.heavenskincare.com", 37789, "Heavenskincare", "Heaven_!3B"),
                    msg))
                {
                    //Failed to send error details to server
                    SendEMail(SupportName, SupportEMail, String.Format("Website Error ({0})", DistributorWebsite),
                        msg, SupportName, SupportEMail);
                }
#else
                SendEMail(SupportName, SupportEMail, String.Format("Website Error ({0})", DistributorWebsite),
                    msg, SupportName, SupportEMail);
#endif
            }
            catch (Exception err)
            {
                if (err.Message.Contains("Could not load file or assembly 'TCPMessageServer"))
                {
                    //Failed to send error details to server
                    SendEMail(SupportName, SupportEMail, String.Format("Website Error ({0})", DistributorWebsite),
                        msg, SupportName, SupportEMail);
                }
                else
                    throw;
            }
        }

        #endregion Private Methods
    }

    /// <summary>
    /// Thread that only initialises other threads required by the website
    /// 
    /// This thread will wait 30 seconds after loaded, then load other 
    /// threads, once other threads have loaded it will close itself
    /// </summary>
    internal class WebsiteInitialisationThreadManager : Shared.Classes.ThreadManager
    {
        internal WebsiteInitialisationThreadManager()
            : base(null, new TimeSpan(0, 0, 30))
        {
            RunAtStartup = false;
        }

        protected override bool Run(object parameters)
        {
            if (!BaseWebApplication.StaticWebSite)
            {
                try
                {
                    if (BaseWebApplication.WebFarmMaster())
                    {
                        ThreadManager.ThreadStart(new UpdateAutoRulesThread(),
                            "Auto Rule Update", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new UpdateCustomPagesThread(),
                            "Update Custom Pages", ThreadPriority.Lowest);
                    }

                    if (!BaseWebApplication.WebFarm && Website.Library.GlobalClass.AllowRoutineMaintenance)
                    {
                        // if the site is part of a web farm then routine maintenance must be handled via a task scheduler
                        ThreadManager.ThreadStart(new RoutineMaintenanceThread(),
                            "Routine Maintenance", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new RoutineMaintenanceCampaignsThread(),
                            "Routine Maintenance Campaigns", ThreadPriority.Lowest);
                    }

                    if (BaseWebApplication.WebFarmMaster())
                    {
#if GeoIPUpdates
                        if (BaseWebApplication.AllowWebsiteGeoUpdate)
                            ThreadManager.ThreadStart(new GeoIPUpdateThread(),
                                "GeoIP Update", ThreadPriority.Lowest);
#endif

                        if (BaseWebApplication.SendEmails)
                            ThreadManager.ThreadStart(new SendEmailThread(),
                                "Email Send Thread", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new UpdateSiteMapThread(), "Update Site Map", ThreadPriority.Lowest);
                    }
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err);
                }
            }

            return (false);
        }
    }

    /// <summary>
    /// Thread runs on start, and every 24 hours to reload city IP data into memory.
    /// 
    /// When data is fully loaded, lookups will be from memory only.
    /// </summary>
    public sealed class GlobalGeoIPCityCache : Shared.Classes.ThreadManager
    {
        #region Private Static Members

        private static bool _initialised = false;
        private static IPCity[] _allCityData;
        private static int _count = 0;

        #endregion Private Static Members

        #region Constructors

        internal GlobalGeoIPCityCache()
            : base(null, new TimeSpan(24, 0, 0), null, 0, 200, true, false)
        {
            ThreadManager.ThreadStart(this, "Load All GeoIP Data", System.Threading.ThreadPriority.Lowest);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
#if CACHE_IP_CITY_DATA
            List<IPCity> alldata = IPCity.GetAll();
            alldata.Sort();
            _allCityData = alldata.ToArray();
            _count = _allCityData.Length;
            _initialised = true;

            return (true);
#else
            return (false);
#endif
        }

        #endregion Overridden Methods

        #region Internal Methods
#if CACHE_IP_CITY_DATA
        internal static IPCity GetIPCity(string ipAddress, bool useMemory = true)
        {
            if (ipAddress == "::1")
                ipAddress = "127.0.0.1";

            if (useMemory && _initialised && _count > 0)
            {
                return (GetMemoryCity(ipAddress));
            }
            else
            {
                return (IPCity.Get(ipAddress, ipAddress));
            }
        }
#else
        internal static IPCity GetIPCity(string ipAddress)
        {
            if (ipAddress == "::1")
                ipAddress = "127.0.0.1";

            return (IPCity.Get(ipAddress, ipAddress));
        }

#endif

        #endregion Internal Methods

        #region Properties

        internal bool Initialised { get { return (_initialised); } }

        #endregion Properties

        #region Private Methods

#if CACHE_IP_CITY_DATA
        private static IPCity GetMemoryCity(string ipAddress)
        {
            long ip = Shared.Utilities.IPToLong(ipAddress);

            long min = 0;
            long max = _allCityData.Length - 1;
            long mid = 0;

            while (min <= max)
            {
                mid = (min + max) / 2;

                if (ip <= _allCityData[mid].EndBlock && ip >= _allCityData[mid].StartBlock)
                {
                    return (_allCityData[mid]);
                }

                if (ip < _allCityData[mid].StartBlock)
                {
                    max = mid - 1;
                    continue;
                }

                if (ip > _allCityData[mid].EndBlock)
                {
                    min = mid + 1;
                }
            }

            return (null);
        }
#endif

        #endregion Private Methods
    }

    internal class UpdateSiteMapThread : Shared.Classes.ThreadManager
    {
        internal UpdateSiteMapThread()
            : base(null, new TimeSpan(0, 1, 0))
        {
            RunAtStartup = true;
        }

        protected override bool Run(object parameters)
        {
            // rebuild site map
            string siteMapData = GlobalClass.RootPath + "admin\\sitemap.dat";

            if (System.IO.File.Exists(siteMapData))
            {
                string defaultData = Shared.Utilities.FileRead(siteMapData, false).Replace("\n", "");

                string newSiteMapXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?> \r\n" +
                    "<urlset \r\n" +
                    "      xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" \r\n" +
                    "      xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" \r\n" +
                    "      xsi:schemaLocation=\"http://www.sitemaps.org/schemas/sitemap/0.9 \r\n" +
                    "            http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd\"> \r\n";


                string[] lines = defaultData.Split('\r');
                string url;

                foreach (string line in lines)
                {
                    if (String.IsNullOrEmpty(line.Trim()) || line.StartsWith("#"))
                        continue;

                    string[] defaultRow = line.Split('#');

                    double prior = Math.Round(SharedUtils.StrToDblDef(defaultRow[1], 0.5d), 2);

                    if (prior < 0.0d || prior > 1.0d)
                        prior = 0.5d;

                    string priority = prior.ToString();
                    url = HTMLEncode(GlobalClass.RootURL + defaultRow[0]);

                    string newXMLEntry = String.Format("  <url>\r\n    <loc>{0}</loc>\r\n    <changefreq>{1}</changefreq>\r\n" +
                        "    <priority>{2}</priority>\r\n  </url>\r\n", url, defaultRow[2], priority);

                    newSiteMapXML += newXMLEntry;
                }


                // products
                lib.BOL.Products.ProductTypes prodTypes = lib.BOL.Products.ProductTypes.Get();

                foreach (lib.BOL.Products.ProductType pType in prodTypes)
                {
                    lib.BOL.Products.Products products = lib.BOL.Products.Products.Get(pType, 1, 1000);

                    foreach (lib.BOL.Products.Product prod in products)
                    {
                        if (prod.VisibleToAllUsers())
                        {
                            switch (prod.PrimaryProduct.Description)
                            {
                                case "Stratosphere":
                                case "MensHeaven":
                                    url = String.Format("{0}/Products/Stratosphere.aspx?ID={1}", GlobalClass.RootURL, prod.ID);
                                    break;
                                default:
                                    url = String.Format("{0}/Products/Product.aspx?ID={1}", GlobalClass.RootURL, prod.ID);
                                    break;
                            }


                            string newXMLEntry = String.Format("  <url>\r\n    <loc>{0}</loc>\r\n    <changefreq>weekly</changefreq>\r\n" +
                                "    <priority>0.7</priority>\r\n  </url>\r\n", HTMLEncode(url));

                            newSiteMapXML += newXMLEntry;

                        }
                    }
                }

                // celebrities
                lib.BOL.Celebrities.Celebrities celebs = lib.BOL.Celebrities.Celebrities.Get();

                foreach (lib.BOL.Celebrities.Celebrity celeb in celebs)
                {
                    url = String.Format("{0}/Celebrities/ViewCeleb.aspx?ID={1}", GlobalClass.RootURL, celeb.ID);
                    string newXMLEntry = String.Format("  <url>\r\n    <loc>{0}</loc>\r\n    <changefreq>weekly</changefreq>\r\n" +
                        "    <priority>0.6</priority>\r\n  </url>\r\n", HTMLEncode(url));

                    newSiteMapXML += newXMLEntry;
                }

                // salons


                // distributors

                newSiteMapXML += "</urlset>\r\n";

                Shared.Utilities.FileWrite(GlobalClass.RootPath + "sitemap_location.xml", newSiteMapXML);

                // update robots.txt
                siteMapData = GlobalClass.RootPath + "robots.txt";
                string robots = Shared.Utilities.FileRead(siteMapData, true);

                // remove first line, upto first \r\n
                robots = robots.Substring(robots.IndexOf('\r'));
                robots = String.Format("Sitemap: {0}/sitemap_location.xml{1}", GlobalClass.RootURL, robots);
                Shared.Utilities.FileWrite(siteMapData, robots);
            }

            return (false);
        }

        private static readonly string[] find = { "&", "'", "\"", ">", "<" };
        private static readonly string[] replace = { "&amp;", "&apos;", "&quot;", "&gt;", "&lt;" };

        private string HTMLEncode(string s)
        {
            for (int i = 0; i < find.Length; i++)
            {
                s = s.Replace(find[i], replace[i]);
            }

            return (s);
        }
    }

    internal class SendEmailThread : Shared.Classes.ThreadManager
    {
        private static EmailSettingsSingletonClass _emailSettings;


        private static EmailMessage _emailClass;

        //private static Int64 _emailQueueSize = 0;
        private static int _emailMaxHistorySize = 50;

        internal SendEmailThread()
            : base(null, new TimeSpan(0, 1, 0))
        {
            HangTimeout = 0;
            RunAtStartup = false;
            _emailSettings = EmailSettingsSingletonClass.GetInstance(BaseWebApplication.SMTPHost,
                BaseWebApplication.SMTPPort, BaseWebApplication.SMTPUserName,
                BaseWebApplication.SMTPPassword, BaseWebApplication.SMTPUseSSL);
        }

        protected override bool Run(object parameters)
        {
            try
            {
                // Create new Email Object
                _emailClass = new EmailMessage
                {
                    // Set SMTP Sever Settings
                    SMTPServerName = _emailSettings.SMTPServer,
                    SMTPServerPort = _emailSettings.SMTPServerPort,
                    SMTPUserName = _emailSettings.SMTPUsername,
                    SMTPUserPassword = _emailSettings.SMTPPassword,
                    SMTPSSL = _emailSettings.SMTPSslConnection,
                    MaximumSendAttempts = _emailSettings.EmailMaxSendAttempt
                };

                // Send email and record any errors

                EmailStatusReport _mailServerMesages = _emailClass.Send();

                if (_mailServerMesages.Count > 0)
                {
                    using (TimedLock.Lock(BaseWebApplication.EmailLockObject))
                    {
                        if (BaseWebApplication._emailServerHistory.Count > _emailMaxHistorySize)
                            BaseWebApplication._emailServerHistory.Clear();

                        BaseWebApplication._emailServerHistory.Add(_mailServerMesages);
                    }
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_THREAD_ABORTED))
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }
    }

#if GeoIPUpdates
    /// <summary>
    /// Thread that runs and checks for GeoIP updates, the actual update will only 
    /// take place once every 24 hours, but the thread will execute every 30 minutes
    /// to see if an update exists
    /// 
    /// Also encrypts the latest download versions for others to download
    /// </summary>
    internal class GeoIPUpdateThread : Shared.Classes.ThreadManager
    {
        private DateTime lastCheckedDownload = DateTime.Now.AddDays(-1);
        private DateTime lastCheckedEncrypt = DateTime.Now.AddDays(-1);

        private string geoPath = String.Format("{0}Admin\\GeoUpdate\\", 
            Shared.Utilities.AddTrailingBackSlash(GlobalClass.RootPath));
        private string encPath = String.Format("{0}Download\\Files\\GeoIP\\", 
            Shared.Utilities.AddTrailingBackSlash(GlobalClass.RootPath));
        private string fileVersions = String.Format("{0}Download\\Versions.xml", 
            Shared.Utilities.AddTrailingBackSlash(GlobalClass.RootPath));
        private string dbConnection = lib.DAL.DALHelper.ConnectionString(DatabaseType.GeoIPUpdates);

        internal GeoIPUpdateThread()
            : base(null, new TimeSpan(0, 30, 0))
        {
            this.HangTimeout = 0;
            RunAtStartup = true;
            ContinueIfGlobalException = true;
        }

        protected override bool Run(object parameters)
        {
            //run the geoupdate
            try
            {
                TimeSpan span = DateTime.Now - lastCheckedDownload;

                if (span.TotalMinutes > 30)
                {
                    GeoIP.GeoIP geo = new GeoIP.GeoIP(geoPath, dbConnection, "WS_IPTOCOUNTRY_EXTERNAL", -20);
                    try
                    {
                        geo.ConnectToFirebird();
                        geo.DownloadLatest();
                        geo.DisconnectFromFirebird();
                    }
                    catch (Exception errDownload)
                    {
                        Shared.EventLog.Add(errDownload);
                    }
                    finally
                    {
                        geo.Dispose();
                        geo = null;
                    }

                    lastCheckedDownload = DateTime.Now;
                }

                span = DateTime.Now - lastCheckedEncrypt;

                if (span.TotalMinutes >= 60.0)
                {
                    GeoIP.GeoIP geo = new GeoIP.GeoIP(fileVersions, encPath, dbConnection);
                    try
                    {
                        geo.ConnectToFirebird();
                        geo.UpdateMissingCityVersions();
                        long latestVersion = BaseWebApplication.GeoIPLatestVersion;
                        DateTime lastUpdated = BaseWebApplication.GeoIPLastUpdated;

                        if (geo.GenerateEncryptedInstalls(ref latestVersion, ref lastUpdated))
                        {
                            BaseWebApplication.GeoIPLastUpdated = lastUpdated;
                            BaseWebApplication.GeoIPLatestVersion = latestVersion;
                        }

                        geo.DisconnectFromFirebird();
                        lastCheckedEncrypt = DateTime.Now;
                    }
                    catch (Exception geoError)
                    {
                        Shared.EventLog.Add(geoError);
                    }
                    finally
                    {
                        geo.Dispose();
                        geo = null;
                    }
                }
            }
            catch (Exception err)
            {
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }
    }

#endif


    /// <summary>
    /// Thread that runs every hour and performs routine maintenance
    /// </summary>
    internal class RoutineMaintenanceThread : Shared.Classes.ThreadManager
    {
        internal RoutineMaintenanceThread()
            : base(null, new TimeSpan(1, 0, 0), null, 30000)
        {
            HangTimeout = 0;
            RunAtStartup = true;
        }

        protected override bool Run(object parameters)
        {
            try
            {
                //run the background tasks
                RoutineMaintenance rm = new RoutineMaintenance();
                try
                {
                    rm.Run();
                }
                finally
                {
                    rm = null;
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_THREAD_ABORTED))
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }
    }

    /// <summary>
    /// Thread that runs every hour and performs routine maintenance
    /// </summary>
    internal class UpdateAutoRulesThread : Shared.Classes.ThreadManager
    {
        internal UpdateAutoRulesThread()
            : base(null, new TimeSpan(0, 10, 0), null, 0)
        {
            HangTimeout = 0;
            RunAtStartup = true;
        }

        protected override bool Run(object parameters)
        {
            try
            {
                lib.BOL.DatabaseUpdates.AutoUpdateRules.ExecuteSQL();
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_THREAD_ABORTED))
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }
    }

    /// <summary>
    /// Thread that runs every hour and performs routine maintenance for campaigns
    /// </summary>
    internal class RoutineMaintenanceCampaignsThread : Shared.Classes.ThreadManager
    {
        internal RoutineMaintenanceCampaignsThread()
            : base(null, new TimeSpan(1, 0, 0), null, 30000)
        {
            HangTimeout = 0;
            RunAtStartup = true;
        }

        protected override bool Run(object parameters)
        {
            try
            {
                //run the background tasks
                RoutineMaintenance rm = new RoutineMaintenance();
                try
                {
                    rm.RunCampaigns();
                }
                finally
                {
                    rm = null;
                }
            }
            catch (Exception err)
            {
                lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }
    }

    /// <summary>
    /// Class to update custom pages at start, only runs once and then closes
    /// </summary>
    internal class UpdateCustomPagesThread : Shared.Classes.ThreadManager
    {
        internal UpdateCustomPagesThread()
            : base(null, new TimeSpan(0, 0, 10))
        {

        }

        protected override bool Run(object parameters)
        {
            // add missing custome pages
            lib.DAL.DALHelper.SetCustomPages();

            return (false);
        }
    }

    #region Class WebsiteError

    public class WebsiteError : System.Exception
    {

    }


    #endregion Class WebsiteError

}
