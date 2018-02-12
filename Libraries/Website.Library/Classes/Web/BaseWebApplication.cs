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
using Library.BOL.Websites;
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
        /// Determines wether mail subscription is shown on the website or not
        /// </summary>

        public static string CookieRootURL;

        /// <summary>
        /// Date and time website was started
        /// </summary>
        public static DateTime DateLoaded;

        public static string RootHost;


        public static string CookiePrefix { get; set; }



        public static int InvoiceVersion = 6;


        public static string DefaultStyle = "Default";

        public static string CSSCookieName = "style_cookie";



        public static bool ShowDistributorsMenu { get; set; }








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

                        RoutineMaintenance.ImageLocations.Add(new ImageCreateLocation(
                            String.Format("{0}Images\\Product\\", WebsiteSettings.RootPath),
                            "*_148.*", "ProductImages", String.Format("{0}Download\\ProductImages.xml",
                            WebsiteSettings.RootPath)));

                        RoutineMaintenance.ImageLocations.Add(new ImageCreateLocation(
                            String.Format("{0}Images\\", WebsiteSettings.RootPath),
                            "*.*", "Images", String.Format("{0}download\\Images.xml",
                            WebsiteSettings.RootPath)));
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

            if (page.Contains("scriptresource.axd") || page.Contains("Site-Error/Page-Not-Found/") || page.Contains("webresource.axd"))
                return (true);
            else
                return (false);
        }

        public static bool LoadWebsiteSettingsFromDatabase()
        {
            bool Result = false;
            try
            {
                WebsiteSettings.StaticWebSite = false;

                lib.LibraryHelperClass.ResetCache();

                lib.LibraryHelperClass.InitialiseSettings();

                #region Base Website Options

                WebsiteSettings.PageTitle = ConfigSettingGet("Settings.DefaultTitle", String.Empty);

                WebsiteSettings.RootURL = ConfigSettingGet("Settings.RootURL", String.Empty);

                WebsiteSettings.RootPath = ConfigSettingGet("Settings.RootPath", String.Empty);

                WebsiteSettings.WebsiteCultureOverride = ConfigSettingGet("Settings.WebCultureOverride", false);

                WebsiteSettings.BasketName = ConfigSettingGet("Settings.ShoppingBasketName", String.Empty);

                WebsiteSettings.DistributorWebsite = ConfigSettingGet("Settings.DistributorWebsite", String.Empty);

                WebsiteSettings.WebsiteDateFormat = ConfigSettingGet("Settings.WebsiteDateFormat", String.Empty);

                WebsiteSettings.UseLeftToRight = ConfigSettingGet("Settings.UseLeftToRight", true);

                WebsiteSettings.UseHTTPS = ConfigSettingGet("Settings.UseHTTPS", true);

                WebsiteSettings.StyleSheet = ConfigSettingGet("SITE.STYLE_SHEET", "StyleMain.css");

                #endregion Base Website Options

                #region Home Page Settings

                WebsiteSettings.HomePage.ShowHomeBanners = ConfigSettingGet("Settings.HomeBanners", true);

                WebsiteSettings.HomePage.ShowHomeFeaturedProducts = ConfigSettingGet("SETTINGS.HOMEFEATURED", false);

                #region Page Banners

                WebsiteSettings.HomePage.PageBanner1 = ConfigSettingGet("PAGEBANNER1", String.Empty);
                WebsiteSettings.HomePage.PageBanner1Link = ConfigSettingGet("PAGEBANNER1LINK", String.Empty);

                WebsiteSettings.HomePage.PageBanner2 = ConfigSettingGet("PAGEBANNER2", String.Empty);
                WebsiteSettings.HomePage.PageBanner2Link = ConfigSettingGet("PAGEBANNER2LINK", String.Empty);

                WebsiteSettings.HomePage.PageBanner3 = ConfigSettingGet("PAGEBANNER3", String.Empty);
                WebsiteSettings.HomePage.PageBanner3Link = ConfigSettingGet("PAGEBANNER3LINK", String.Empty);

                #endregion Page Banners

                #region Rotating Home Page Banners

                WebsiteSettings.HomePage.HomeBanner1 = ConfigSettingGet("HomeBanner1", String.Empty);
                WebsiteSettings.HomePage.HomeBanner2 = ConfigSettingGet("HomeBanner2", String.Empty);
                WebsiteSettings.HomePage.HomeBanner3 = ConfigSettingGet("HomeBanner3", String.Empty);
                WebsiteSettings.HomePage.HomeBanner4 = ConfigSettingGet("HomeBanner4", String.Empty);
                WebsiteSettings.HomePage.HomeBanner5 = ConfigSettingGet("HomeBanner5", String.Empty);

                WebsiteSettings.HomePage.HomeBanner1Link = ConfigSettingGet("HomeBanner1Link", String.Empty);
                WebsiteSettings.HomePage.HomeBanner2Link = ConfigSettingGet("HomeBanner2Link", String.Empty);
                WebsiteSettings.HomePage.HomeBanner3Link = ConfigSettingGet("HomeBanner3Link", String.Empty);
                WebsiteSettings.HomePage.HomeBanner4Link = ConfigSettingGet("HomeBanner4Link", String.Empty);
                WebsiteSettings.HomePage.HomeBanner5Link = ConfigSettingGet("HomeBanner5Link", String.Empty);

                #endregion Rotating Home Page Banners

                #endregion Home Page Settings

                #region Global Page Options

                WebsiteSettings.AllPages.ShowTermsAndConditions = ConfigSettingGet("Settings.ShowTermsAndConditions", true);
                WebsiteSettings.AllPages.ShowPrivacyPolicy = ConfigSettingGet("Settings.ShowPrivacyPolicy", true);
                WebsiteSettings.AllPages.ShowReturnsPolicy = ConfigSettingGet("Settings.ShowReturnsPolicy", true);

                WebsiteSettings.AllPages.ShowSalonsMenu = ConfigSettingGet("Settings.ShowSalons", true);
                WebsiteSettings.AllPages.ShowSalonFinder = ConfigSettingGet("Settings.ShowSalonFinder", true);
                WebsiteSettings.AllPages.ShowClientHeader = ConfigSettingGet("Settings.ShowSalonClientHeader", true);
                WebsiteSettings.AllPages.ShowSalonHeader = ConfigSettingGet("Settings.ShowSalonHeader", true);

                WebsiteSettings.AllPages.ShowTreatmentsMenu = ConfigSettingGet("Settings.ShowTreatments", true);
                WebsiteSettings.AllPages.ShowTreatmentsBrochure = ConfigSettingGet("Settings.ShowTreatmentBrochure", true);
                WebsiteSettings.AllPages.ShowDistributorsMenu = ConfigSettingGet("Settings.ShowDistributors", true);
                WebsiteSettings.AllPages.ShowTipsAndTricksMenu = ConfigSettingGet("Settings.ShowTipsAndTricks", true);
                WebsiteSettings.AllPages.ShowDownloadMenu = ConfigSettingGet("Settings.ShowDownloads", false);

                WebsiteSettings.AllPages.ShowTradePage = ConfigSettingGet("Settings.ShowTradePage", true);

                #endregion Global Page Options

                #region General Contact Details

                WebsiteSettings.ContactDetails.WebsiteTelephoneNumber = ConfigSettingGet("Settings.WebsiteTelephoneNumber", String.Empty);
                WebsiteSettings.ContactDetails.WebsiteEmail = ConfigSettingGet("Settings.WebsiteEmail", String.Empty);
                WebsiteSettings.ContactDetails.AddressLine1 = ConfigSettingGet("Settings.AddressLine1", String.Empty);
                WebsiteSettings.ContactDetails.AddressLine2 = ConfigSettingGet("Settings.AddressLine2", String.Empty);
                WebsiteSettings.ContactDetails.AddressLine3 = ConfigSettingGet("Settings.AddressLine3", String.Empty);

                #endregion General Contact Details

                #region Email Settings

                WebsiteSettings.Email.SupportName = ConfigSettingGet("Settings.SupportName", String.Empty);
                WebsiteSettings.Email.SupportEMail = ConfigSettingGet("Settings.SupportEMail", String.Empty);
                WebsiteSettings.Email.SMTPHost = ConfigSettingGet("Settings.SMTPHost", String.Empty);
                WebsiteSettings.Email.SMTPUserName = ConfigSettingGet("Settings.SMTPUserName", String.Empty);
                WebsiteSettings.Email.SMTPPassword = ConfigSettingGet("Settings.SMTPPassword", String.Empty);
                WebsiteSettings.Email.SMTPUseSSL = ConfigSettingGet("Settings.SMTPSSL", false);
                WebsiteSettings.Email.SMTPPort = ConfigSettingGet("Settings.SMTPPort", 25);
                WebsiteSettings.Email.SendEmails = ConfigSettingGet("Settings.SendEmail", false);

                WebsiteSettings.Email.NoReplyName = ConfigSettingGet("Settings.NoReplyName", String.Empty);

                WebsiteSettings.Email.NoReplyEmail = ConfigSettingGet("Settings.NoReplyEmail", String.Empty);

                #endregion Email Settings

                #region Payment Gateways

                WebsiteSettings.PaymentGateways.ShowPaymentPaypal = ConfigSettingGet("Settings.ShowPaymentPaypal", true);
                WebsiteSettings.PaymentGateways.ShowPaymentCard = ConfigSettingGet("Settings.ShowPaymentCard", false);
                WebsiteSettings.PaymentGateways.ShowPaymentPaypoint = ConfigSettingGet("Settings.ShowPaymentPaypoint", false);
                WebsiteSettings.PaymentGateways.ShowPaymentSunTechBuySafe = ConfigSettingGet("Settings.AllowSunTechBuySafe", false);
                WebsiteSettings.PaymentGateways.ShowPaymentSunTech24Payment = ConfigSettingGet("Settings.AllowSunTech24Payment", false);
                WebsiteSettings.PaymentGateways.ShowPaymentSunTechWebATM = ConfigSettingGet("Settings.AllowSunTechWebATM", false);
                WebsiteSettings.PaymentGateways.ShowPaymentTelephone = ConfigSettingGet("Settings.ShowPaymentTelephone", true);
                WebsiteSettings.PaymentGateways.ShowPaymentCashOnDelivery = ConfigSettingGet("Settings.ShowPaymentCOD", false);
                WebsiteSettings.PaymentGateways.ShowPaymentDirectBankTransfer = ConfigSettingGet("Settings.ShowPaymentDBT", false);
                WebsiteSettings.PaymentGateways.ShowPaymentTestPurchase = ConfigSettingGet("Settings.TestPurchase", false);
                WebsiteSettings.PaymentGateways.ShowPaymentCheque = ConfigSettingGet("Settings.ShowPaymentCheque", true);


                #region Payflow

                if (WebsiteSettings.PaymentGateways.ShowPaymentCard)
                {
                    WebsiteSettings.PaymentGateways.Payflow.PayflowTestMode = ConfigSettingGet("Settings.PayflowTestMode", true);
                    WebsiteSettings.PaymentGateways.Payflow.PayflowPartner = ConfigSettingGet("Settings.PayflowPartner", String.Empty);
                    WebsiteSettings.PaymentGateways.Payflow.PayflowVendor = ConfigSettingGet("Settings.PayflowVendor", String.Empty);
                    WebsiteSettings.PaymentGateways.Payflow.PayflowUser = ConfigSettingGet("Settings.PayflowUser", String.Empty);
                    WebsiteSettings.PaymentGateways.Payflow.PayflowPassword = ConfigSettingGet("Settings.PayflowPassword", String.Empty);
                    WebsiteSettings.PaymentGateways.Payflow.Currencies = ConfigSettingGet("Settings.PayflowCurrencies", "GBP;USD");
                }

                #endregion Payflow

                #region Payment Providers Paypal

                if (WebsiteSettings.PaymentGateways.ShowPaymentPaypal)
                {
                    WebsiteSettings.PaymentGateways.Paypal.APIUsername = ConfigSettingGet("Settings.PaypalAPIUserName", String.Empty);
                    WebsiteSettings.PaymentGateways.Paypal.APIPassword = ConfigSettingGet("Settings.PaypalAPIPassword", String.Empty);
                    WebsiteSettings.PaymentGateways.Paypal.APISignature = ConfigSettingGet("Settings.PaypalAPISignature", String.Empty);
                    WebsiteSettings.PaymentGateways.Paypal.Subject = ConfigSettingGet("Settings.PaypalAPISubject", String.Empty);
                    WebsiteSettings.PaymentGateways.Paypal.BNCode = ConfigSettingGet("Settings.PaypalAPIBNCode", String.Empty);
                    WebsiteSettings.PaymentGateways.Paypal.DefaultCurrency = ConfigSettingGet("Settings.PaypalAPICurrency", "GBP;USD");
                    WebsiteSettings.PaymentGateways.Paypal.APISuccessURL = ConfigSettingGet("Settings.PaypalSuccessURL", String.Empty);
                    WebsiteSettings.PaymentGateways.Paypal.APIFailURL = ConfigSettingGet("Settings.PaypalFailURL", String.Empty);
                }

                #endregion Payment Providers Paypal

                #region WorldPay

                WebsiteSettings.PaymentGateways.WorldPay.Currencies = ConfigSettingGet("Settings.PaynetCurrency", "GBP");

                #endregion WorldPay

                #region Payment Providers Cheque

                WebsiteSettings.PaymentGateways.Cheque.Currency = ConfigSettingGet("Settings.ChequeCurrency", "USD");

                #endregion Payment Providers Cheque

                #region Payment Providers Sun Tech

                if (WebsiteSettings.PaymentGateways.ShowPaymentSunTechBuySafe)
                {
                    WebsiteSettings.PaymentGateways.SunTech.BuySafe.SupportedCurrencies = ConfigSettingGet("Settings.BuySafeCurrencies", "GBP");
                    WebsiteSettings.PaymentGateways.SunTech.BuySafe.MerchantID = ConfigSettingGet("Settings.BuySafeMerchantID", "");
                    WebsiteSettings.PaymentGateways.SunTech.BuySafe.MerchantPassword = ConfigSettingGet("Settings.BuySafeMerchantPW", "");
                    WebsiteSettings.PaymentGateways.SunTech.BuySafe.TestMode = ConfigSettingGet("Settings.BuySafeTestMode", true);
                }

                if (WebsiteSettings.PaymentGateways.ShowPaymentSunTech24Payment)
                {
                    WebsiteSettings.PaymentGateways.SunTech.Payment24.SupportedCurrencies = ConfigSettingGet("Settings.24PaymentCurrencies", "GBP");
                    WebsiteSettings.PaymentGateways.SunTech.Payment24.MerchantID = ConfigSettingGet("Settings.24PaymentMerchantID", "");
                    WebsiteSettings.PaymentGateways.SunTech.Payment24.MerchantPassword = ConfigSettingGet("Settings.24PaymentMerchantPW", "");
                    WebsiteSettings.PaymentGateways.SunTech.Payment24.TestMode = ConfigSettingGet("Settings.24PaymentTestMode", true);
                    WebsiteSettings.PaymentGateways.SunTech.Payment24.DueDateDays = ConfigSettingGet("Settings.24PaymentDueDays", 30);
                }

                if (WebsiteSettings.PaymentGateways.ShowPaymentSunTechWebATM)
                {
                    WebsiteSettings.PaymentGateways.SunTech.WebATM.SupportedCurrencies = ConfigSettingGet("Settings.WebATMCurrencies", "GBP");
                    WebsiteSettings.PaymentGateways.SunTech.WebATM.MerchantID = ConfigSettingGet("Settings.WebATMMerchantID", "");
                    WebsiteSettings.PaymentGateways.SunTech.WebATM.MerchantPassword = ConfigSettingGet("Settings.WebATMMerchantPW", "");
                    WebsiteSettings.PaymentGateways.SunTech.WebATM.TestMode = ConfigSettingGet("Settings.WebATMTestMode", true);
                    WebsiteSettings.PaymentGateways.SunTech.WebATM.BillDateDays = ConfigSettingGet("Settings.WebATMBillDays", 30);
                    WebsiteSettings.PaymentGateways.SunTech.WebATM.DueDateDays = ConfigSettingGet("Settings.WebAMTDueDays", 30);
                }

                #endregion Payment Providers Sun Tech

                #region Payment Provider Telephone

                WebsiteSettings.PaymentGateways.Telephone.Currency = ConfigSettingGet("Settings.PhoneCurrency", "GBP");

                #endregion Payment Provider Telephone

                #region Payment Provider Cash On Delivery

                WebsiteSettings.PaymentGateways.CashOnDelivery.Currency = ConfigSettingGet("Settings.CODCurrency", "GBP");

                #endregion Payment Provider Cash On Delivery

                #region Direct Bank Transfer

                //currencies for payment providers
                WebsiteSettings.PaymentGateways.DirectTransfer.Currency = ConfigSettingGet("Settings.DTCurrency", "NZD");

                #endregion Direct Bank Transfer

                #region Credit Card Options

                WebsiteSettings.CreditCards.CreditCardAlwaysShowValidFromForUK = ConfigSettingGet("Settings.AlwaysShowCCForUK", true);
                WebsiteSettings.CreditCards.CreditCardHideValidFrom = ConfigSettingGet("Settings.AlwaysHideValidFrom", false);
                WebsiteSettings.CreditCards.AllowCreditCards = ConfigSettingGet("Settings.AllowCreditCards", true);

                #endregion Credit Card Options

                #region Test Purchase Options

                Classes.PaymentOptions.PaymentOptionTestPurchase.SupportedCurrencies = ConfigSettingGet(
                    "Settings.TestPurchaseCurrencies", String.Empty);

                #endregion Test Purchase Options


                #endregion Payment Gateways

                #region Web Farm/Garden

                WebsiteSettings.WebFarm.IsWebFarm = ConfigSettingGet("WEB.FARM", false, true);
                WebsiteSettings.WebFarm.WebFarmMasterIP = ConfigSettingGet("WEB.FARM.MASTER", String.Empty, true);
                WebsiteSettings.WebFarm.WebFarmMutexName = ConfigSettingGet("WEB.FARM.MUTEX", "WEB_FARM_MUTEX", true);

                #endregion Web Farm/Garden

                #region Google Analytics

                WebsiteSettings.Analytics.Google.GoogleAnalytics = ConfigSettingGet("SETTINGS.GOOGLE.ANALYTICS", String.Empty);

                #endregion Google Analytics

                #region Caching

                // caching
                lib.DAL.DALHelper.AllowCaching = ConfigSettingGet("Setting.AllowCaching", true);
                lib.DAL.DALHelper.CacheLimit = new TimeSpan(0, ConfigSettingGet("Setting.CacheLimit", 30), 0);

                GlobalClass.InternalCache.MaximumAge = lib.DAL.DALHelper.CacheLimit;

                #endregion Caching

                #region Stock

                WebsiteSettings.Stock.OutOfStockAllowNotifyUser = ConfigSettingGet("Settings.OutOfStockAllowNotifyUser", false);
                WebsiteSettings.Stock.OutOfStockInPage = ConfigSettingGet("Settings.OutOfStockInPage", false);

                #endregion Stock

                #region Licence Options

                WebsiteSettings.Licences.AllowLicences = ConfigSettingGet("Settings.AllowLicences", false);

                #endregion Licence Options

                #region Offers

                WebsiteSettings.Offers.ShowOffers = ConfigSettingGet("Settings.ShowOffers", true);
                WebsiteSettings.Offers.ShowVoucher = ConfigSettingGet("Settings.ShowVoucher", false);

                #endregion Offers

                #region Mail List Subscribers

                // mail list subscription
                WebsiteSettings.Marketing.AllowMailListSubscribers = ConfigSettingGet("SETTINGS.MAILLIST.ALLOW", false);

                #endregion Mail List Subscribers

                #region Mail Chimp integration

                WebsiteSettings.Marketing.MailChimp.MailChimpAPI = ConfigSettingGet("Settings.MailChimpAPI", String.Empty);
                WebsiteSettings.Marketing.MailChimp.MailChimpList = ConfigSettingGet("Settings.MailChimpList", String.Empty);
                WebsiteSettings.Marketing.MailChimp.MailChimpKey = ConfigSettingGet("Settings.MailChimpKey", String.Empty);
                WebsiteSettings.Marketing.MailChimp.MailChimpPopupDialog = ConfigSettingGet("Settings.MailChimpPopup", String.Empty);

                if (String.IsNullOrEmpty(WebsiteSettings.Marketing.MailChimp.MailChimpKey))
                {
                    WebsiteSettings.Marketing.MailChimp.MailChimpKey = Shared.Utilities.RandomPassword(25);
                    ConfigSettingSet("Settings.MailChimpKey", WebsiteSettings.Marketing.MailChimp.MailChimpKey);
                }

                #endregion Mail Chimp Integration

                #region Shopping Cart

                WebsiteSettings.ShoppingCart.MaximumItemQuantity = ConfigSettingGet("Settings.MaximumItemQuantity", 5);

                WebsiteSettings.ShoppingCart.JumpToBasketAfterAddItem = ConfigSettingGet("Settings.JumpToBasketAfterAddItem", false);

                WebsiteSettings.ShoppingCart.HideShoppingCart = ConfigSettingGet("Settings.HideShoppingCart", false);

                WebsiteSettings.ShoppingCart.BasketSummaryShow = ConfigSettingGet("Settings.BasketSummaryShow", true);

                WebsiteSettings.ShoppingCart.BasketSummaryAutoHide = ConfigSettingGet("Settings.BasketSummaryAutoHide", false);

                WebsiteSettings.ShoppingCart.BasketSummaryTimeOut = Shared.Utilities.CheckMinMax(ConfigSettingGet("SettingsBasketSummaryTimeout", 10), 5, 25);

                WebsiteSettings.ShoppingCart.BasketIDIncrement = Shared.Utilities.CheckMinMax(ConfigSettingGet("Settings.BasketIDCount", 500), 100, 10000);

                WebsiteSettings.ShoppingCart.FreeShippingAllow = ConfigSettingGet("Settings.FreeShippingAllow", false);

                WebsiteSettings.ShoppingCart.FreeShippingAmount = ConfigSettingGet("Settings.FreeShippingSpend", 100.00m);

                WebsiteSettings.ShoppingCart.ClearBasketOnPayment = ConfigSettingGet("Settings.ClearBasketOnPayment", false, true);

                WebsiteSettings.ShoppingCart.AlterTextColorBasedOnBasketContents = ConfigSettingGet("Settings.AlterTextColorBasedOnBasketContents", false);

                WebsiteSettings.ShoppingCart.ItemDoesNotExistsInShoppingBagTextColour = ConfigSettingGet("Settings.ItemDoesNotExistsInShoppingBagTextColour", "white");

                WebsiteSettings.ShoppingCart.ItemExistsInShoppingBagTextColour = ConfigSettingGet("Settings.ItemExistsInShoppingBagTextColour", "white");

                WebsiteSettings.ShoppingCart.DefaultShowPrices = ConfigSettingGet("Settings.ShowPriceDefault", true);

                WebsiteSettings.ShoppingCart.OverrideCostMultiplier = ConfigSettingGet("Settings.OverrideCostMultiplier", false);

                WebsiteSettings.ShoppingCart.OverrideCostMultiplierValue = ConfigSettingGet("Settings.OverrideCostMultiplierValue", 0.0);

                #endregion Shopping Cart

                #region VAT/Tax Settings

                lib.DAL.DALHelper.HideVATOnWebsiteAndInvoices = ConfigSettingGet("Settings.HideVATOnWebsiteAndInvoices", false);
                WebsiteSettings.Tax.VatRate = ConfigSettingGet("Settings.VatRate", 20.0);
                WebsiteSettings.Tax.PricesIncludeVAT = ConfigSettingGet("Settings.PricesIncludeVAT", false);
                WebsiteSettings.Tax.ShippingIsTaxable = ConfigSettingGet("Settings.ShippingIsTaxable", true);
                WebsiteSettings.Tax.ShowBasketItemsWithVAT = ConfigSettingGet("Settings.ShowBasketItemsWithVAT", false);
                WebsiteSettings.Tax.ShowBasketSubTotalWithVAT = ConfigSettingGet("Settings.ShowBasketSubTotalWithVAT", true);

                #endregion VAT/Tax Settings

                #region Social Media

                WebsiteSettings.SocialMedia.Facebook.Url = ConfigSettingGet("Settings.Facebook", "http://www.facebook.com/Heavenskincare");
                WebsiteSettings.SocialMedia.Google.GPlus = ConfigSettingGet("Settings.GPlus", "https://plus.google.com/u/0/+DeborahMitchellheaven/posts");
                WebsiteSettings.SocialMedia.RSS.Feed = ConfigSettingGet("Settings.RSSFeed", "http://heavenbydeborahmitchell.me/feed/");
                WebsiteSettings.SocialMedia.Twitter.Url = ConfigSettingGet("Settings.Twitter", "https://twitter.com/#!/Heavenskincare");
                WebsiteSettings.SocialMedia.Twitter.DefaultTags = ConfigSettingGet("Settings.TwitterTags", String.Empty);
                WebsiteSettings.SocialMedia.Blog.Url = ConfigSettingGet("BlogURL", String.Empty, true);

                #endregion Social Media

                #region Maintenance Options

                WebsiteSettings.Maintenance.AutoMaintenanceMode = true;
                WebsiteSettings.Maintenance.MaintenanceMode = ConfigSettingGet("Settings.MaintenanceMode", false);

                WebsiteSettings.Maintenance.AllowRoutineMaintenance = ConfigSettingGet("Settings.AllowRoutineMaintenance", true);
                WebsiteSettings.Maintenance.CreateXMLImageFiles = ConfigSettingGet("Settings.CreateXMLImageFiles", false);

                #endregion Maintenance Options

                #region Languages

                // indicates wether the change language/currency bar is visible or not
                WebsiteSettings.Languages.Active = ConfigSettingGet("SITE.LANGUAGES", false);

                WebsiteSettings.Languages.ForceInitialDefaultLanguage = ConfigSettingGet("SITE.FORCEINITIAL.LANGUAGE", false);

                WebsiteSettings.Languages.UseCustomPages = ConfigSettingGet("Settings.CustomPages", true);

                WebsiteSettings.Languages.WebsiteCulture = new CultureInfo(ConfigSettingGet("Settings.WebsiteCulture", "en-GB"));

                lib.BOL.Countries.Country defCountry = lib.BOL.Countries.Countries.Get(ConfigSettingGet("Settings.DefaultCountry", "GB"));

                if (defCountry == null)
                    WebsiteSettings.Languages.DefaultCountrySettings = "GB";
                else
                    WebsiteSettings.Languages.DefaultCountrySettings = defCountry.CountryCode;

                lib.DAL.DALHelper.CultureOverride = ConfigSettingGet("Settings.CultureOverride", "en-GB");

                #endregion Languages

                #region Trade Customers

                WebsiteSettings.TradeCustomers.ShowTradeDownloads = ConfigSettingGet("Settings.UserMenuTradeDownloads", true);

                #endregion Trade Customers

                #region Memberer Menu Items

                WebsiteSettings.Members.ShowSalonUpdate = ConfigSettingGet("Settings.UserMenuSalonUpdates", true);
                WebsiteSettings.Members.ShowAppointments = ConfigSettingGet("Settings.UserMenuAppointments", true);

                #endregion Member Menu Items

                #region Affiliates

                WebsiteSettings.Affiliates.MaximumDays = Shared.Utilities.StrToInt(lib.LibraryHelperClass.SettingsGet(
                    StringConstants.AFFILIATE_LIVE_DAYS, StringConstants.SYMBOL_SEVEN), 7);

                #endregion Affiliates

                #region Carousel

                WebsiteSettings.Carousel.CustomScrollerStrapLine = ConfigSettingGet("Settings.CustomIndexScroller", false);
                WebsiteSettings.Carousel.CustomScrollerText = ConfigSettingGet("Settings.CustomScrollerText",
                    Languages.LanguageStrings.CheckOutLatestGreatest);

                #endregion Carousel

                #region Cookies

                CookiePrefix = "SD";

                #endregion Cookies

                #region Geo Update

                WebsiteSettings.GeoIP.AllowWebsiteGeoUpdate = ConfigSettingGet("Settings.GeoIPUpdates", false);

                #endregion Geo Update

                lib.DAL.DALHelper.RegisterWebsite(WebsiteSettings.RootURL);

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
                    EventLog.Add(err);
                }

                WebsiteSettings.WebFarm.Initialise();
            }


            RegisterRoutes(RouteTable.Routes);
        }

        protected void ApplicationEnd()
        {
            EventLog.Add("ApplicationEnd");

            WebsiteSettings.WebFarm.Close();

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

                if (Request.Cookies[String.Format("{0}{1}Session", CookiePrefix, WebsiteSettings.DistributorWebsite)] != null)
                {
                    if (Request.Cookies[String.Format("{0}{1}Session", CookiePrefix, WebsiteSettings.DistributorWebsite)].Expires.Year != (DateTime.Now.Year - 1))
                    {
                        string s1 = Shared.Utilities.Decrypt(HttpUtility.UrlDecode(Request.Cookies[String.Format("{0}{1}Session", CookiePrefix, WebsiteSettings.DistributorWebsite)].Value));

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
                WebsiteSettings.Maintenance.AutoMaintenanceMode = true;

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
                UserSessionManager.Instance.IPAddressDetails += Instance_IPAddressDetails;

#if SAVE_SESSION_DATA
                UserSessionManager.Instance.OnSessionCreated += Instance_OnSessionCreated;
                UserSessionManager.Instance.OnSessionClosing += Instance_OnSessionClosing;
                UserSessionManager.Instance.OnSessionRetrieve += Instance_OnSessionRetrieve;
                UserSessionManager.Instance.OnSessionSave += Instance_OnSessionSave;
                UserSessionManager.Instance.OnSavePage += Instance_OnSavePage;
#endif

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

#if SAVE_SESSION_DATA
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
#endif

        #endregion SessionManager Events

        #endregion Protected Methods

        #region Internal Methods

        #endregion Internal Methods

        #region Public Methods

        #region Send Emails

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="ErrorMessage">Error Message</param>
        public static void SendEmail(string ErrorMessage)
        {
            SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, 
                String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite), ErrorMessage);
        }

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Title">Title of email</param>
        public static void SendEmail(string Title, string Message)
        {
            SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, Title, Message);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg)
        {
            SendEMail(ToName, ToEMail, Title, Msg, WebsiteSettings.Email.NoReplyName, WebsiteSettings.Email.NoReplyEmail);
        }

        public static void SendEMail(string Title, string Msg)
        {
            SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, 
                Title, Msg, WebsiteSettings.Email.NoReplyName, WebsiteSettings.Email.NoReplyEmail);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg, string FromName, string FromEMail)
        {
            Emails.Add(ToName, ToEMail, FromName, FromEMail, Title, Msg);

            if (!WebsiteSettings.Email.SendEmails)
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

                routes.MapPageRoute("tipsRoute",
                    "Tips-And-Tricks/",
                    "~/Tips/TipsnTricks.aspx");

                routes.MapPageRoute("tipsPageRoute",
                    "Tips-And-Tricks/Page/{page}/",
                    "~/Tips/TipsnTricks.aspx");

                routes.MapPageRoute("tradeCustomerRoute",
                    "Trade-Customers/",
                    "~/Trade.aspx");

                routes.MapPageRoute("tradeCustomerSignupRoute",
                    "Trade-Customers/Sign-up/",
                    "~/Trade/Signup.aspx");

                routes.MapPageRoute("distributorsRoute",
                    "Distributors/",
                    "~/Distributors.aspx");

                routes.MapPageRoute("contactUsRoute",
                    "Company/Contact-Us/",
                    "~/ContactUs.aspx");

                routes.MapPageRoute("aboutRoute",
                    "Company/About/",
                    "~/About.aspx");

                routes.MapPageRoute("termsRoute",
                    "Company/Terms-And-Conditions/",
                    "~/Terms.aspx");

                routes.MapPageRoute("privacyRoute",
                    "Company/Privacy-Policy/",
                    "~/Privacy.aspx");

                routes.MapPageRoute("returnsRoute",
                    "Company/Returns-Policy/",
                    "~/Returns.aspx");

                routes.MapPageRoute("salonsRoute",
                    "Salons/",
                    "~/Salons.aspx");

                routes.MapPageRoute("salonsPageRoute",
                    "Salons/Page/{page}/",
                    "~/Salons.aspx");

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

                // treatments
                routes.MapPageRoute("treatmentsRoute",
                    "Treatments/",
                    "~/Treatments.aspx");

                routes.MapPageRoute("treatmentsPageRoute",
                    "Treatments/Page/{page}/",
                    "~/Treatments.aspx");

                routes.MapPageRoute("treatmentsGroupRoute",
                    "Treatments/Group/{group}/",
                    "~/Treatments.aspx");

                routes.MapPageRoute("treatmentsGroupPageRoute",
                    "Treatments/Group/{group}/Page/{page}/",
                    "~/Treatments.aspx");

                routes.MapPageRoute("offersRoute",
                    "Special-Offers/",
                    "~/Offers/Offers.aspx");

                // basket
                routes.MapPageRoute("basketShoppingRoute",
                    "Shopping/Basket/",
                    "~/Basket/Basket.aspx");

                routes.MapPageRoute("basketShoppingSignInRoute",
                    "Shopping/Basket/SignIn/",
                    "~/Basket/BasketSignIn.aspx");

                routes.MapPageRoute("basketShoppingAddressRoute",
                    "Shopping/Basket/Delivery-Address/",
                    "~/Basket/BasketDeliveryAddress.aspx");

                routes.MapPageRoute("basketShoppingSummaryRoute",
                    "Shopping/Basket/Confirm-Order/",
                    "~/Basket/BasketCheckout.aspx");

                routes.MapPageRoute("basketShoppingOrderCompleteRoute",
                    "Shopping/Basket/Order-Complete/",
                    "~/Basket/BasketOrderComplete.aspx");

                routes.MapPageRoute("basketShoppingOrderCompleteTypeRoute",
                    "Shopping/Basket/Order-Complete/Payment-Type/{type}/",
                    "~/Basket/BasketOrderComplete.aspx");

                // Members
                routes.MapPageRoute("customerAccountRoute",
                    "Account/",
                    "~/Members/Index.aspx");

                routes.MapPageRoute("customerAccountAddressRoute",
                    "Account/Address/Billing/",
                    "~/Members/Address.aspx");

                routes.MapPageRoute("customerAccountCardDetailsRoute",
                    "Account/Card/",
                    "~/Members/CardDetails.aspx");

                routes.MapPageRoute("customerAccountCookiesRoute",
                    "Account/Cookies/",
                    "~/Members/Cookies.aspx");

                routes.MapPageRoute("customerAccountDeliveryAddressRoute",
                    "Account/Address/Delivery/",
                    "~/Members/DeliveryAddress.aspx");

                routes.MapPageRoute("customerAccountDeliveryAddressEditRoute",
                    "Account/Address/Delivery/Edit/{id}/",
                    "~/Members/DeliveryAddressEdit.aspx");

                routes.MapPageRoute("customerAccountInvoicesRoute",
                    "Account/Invoices/",
                    "~/Members/Invoices.aspx");

                routes.MapPageRoute("customerAccountInvoicesViewRoute",
                    "Account/Invoices/View/{invoice}/",
                    "~/Members/InvoiceView.aspx");

                routes.MapPageRoute("customerAccountInvoicesPageRoute",
                    "Account/Invoices/Page/{page}/",
                    "~/Members/Invoices.aspx");

                routes.MapPageRoute("customerAccountLicencesRoute",
                    "Account/Licences/",
                    "~/Members/Licences.aspx");

                routes.MapPageRoute("customerAccountLicenceEditRoute",
                    "Account/Licences/Edit/{id}/",
                    "~/Members/LicenceEdit.aspx");

                routes.MapPageRoute("customerAccountLicencesPageRoute",
                    "Account/Licences/Page/{page}/",
                    "~/Members/Licences.aspx");

                routes.MapPageRoute("customerAccountLoginRoute",
                    "Account/Login/",
                    "~/Members/Login.aspx");

                routes.MapPageRoute("customerAccountLogoutRoute",
                    "Account/Logout/",
                    "~/Members/Logout.aspx");

                routes.MapPageRoute("customerAccountDetailsRoute",
                    "Account/Details/",
                    "~/Members/MemberDetails.aspx");

                routes.MapPageRoute("customerAccountOrdersRoute",
                    "Account/Orders/",
                    "~/Members/Orders.aspx");

                routes.MapPageRoute("customerAccountOrdersViewRoute",
                    "Account/Orders/View/{order}/",
                    "~/Members/OrderView.aspx");

                routes.MapPageRoute("customerAccountOrdersPageRoute",
                    "Account/Orders/Page/{page}/",
                    "~/Members/Orders.aspx");

                routes.MapPageRoute("customerAccountPasswordRoute",
                    "Account/Password/",
                    "~/Members/Password.aspx");

                routes.MapPageRoute("customerAccountSignupRoute",
                    "Account/Signup/",
                    "~/Members/Signup.aspx");

#warning add all offer pages
                routes.MapPageRoute("customerAccountOffersRoute",
                    "Account/Special-Offers/",
                    "~/Members/SpecialOffers.aspx");

#warning add papers


#warning add press

#warning add services

#warning add modules

#warning add redirect


#warning add appointments

#warning add download


                routes.MapPageRoute("customerAccountSupportTicketsRoute",
                    "Account/Help-Desk/Tickets/",
                    "~/Members/SupportTickets.aspx");

                routes.MapPageRoute("customerAccountAppointmentsRoute",
                    "Account/Appointments/",
                    "~/Members/Appointments.aspx");

                routes.MapPageRoute("customerAccountAppointmentsViewRoute",
                    "Account/Appointments/View/{id}/",
                    "~/Members/AppointmentsView.aspx");

                routes.MapPageRoute("customerAccountAppointmentsPageRoute",
                    "Account/Appointments/Page/{page}/",
                    "~/Members/Appointments.aspx");

                routes.MapPageRoute("customerAccountSystemHooksRoute",
                    "Account/System/Hooks/",
                    "~/Members/SystemHooks.aspx");

                routes.MapPageRoute("customerAccountSystemHooksActionRoute",
                    "Account/System/Hooks/Action/{action}/{id}/",
                    "~/Members/SystemHooks.aspx");

                routes.MapPageRoute("customerAccountUnsubscribeRoute",
                    "Account/Unsubscribe/",
                    "~/Members/Unsubscribe.aspx");

                routes.MapPageRoute("customerAccountDistributorOutletsRoute",
                    "Account/Distributor/Outlet/",
                    "~/Members/Outlets.aspx");

                routes.MapPageRoute("customerAccountDistributorOutletsViewRoute",
                    "Account/Distributor/Outlet/View/{salonid}/",
                    "~/Members/Outlets.aspx");

                // help desk
                routes.MapPageRoute("helpdeskMainRoute",
                    "Help-Desk/",
                    "~/Helpdesk/Index.aspx");

                routes.MapPageRoute("helpDeskFeedbackRoute",
                    "Help-Desk/Feedback/",
                    "~/Helpdesk/Feedback.aspx");

                routes.MapPageRoute("helpDeskFeedbackPageRoute",
                    "Help-Desk/Feedback/Page/{page}/",
                    "~/Helpdesk/Feedback.aspx");

                routes.MapPageRoute("helpDeskLeaveFeedbackPageRoute",
                    "Help-Desk/Feedback/Leave/",
                    "~/Helpdesk/Comments/LeaveFeedback.aspx");

                routes.MapPageRoute("helpDeskTicketSubmitRoute",
                    "Help-Desk/Tickets/Submit/",
                    "~/Helpdesk/Tickets/Submit.aspx");

                routes.MapPageRoute("helpDeskTicketShowRoute",
                    "Help-Desk/Tickets/View/",
                    "~/Helpdesk/Tickets/ShowTicket.aspx");

                routes.MapPageRoute("helpDeskTicketShowTicketRoute",
                    "Help-Desk/Tickets/View/Email/{email}/Ticket/{ticketid}/",
                    "~/Helpdesk/Tickets/ShowTicket.aspx");

                routes.MapPageRoute("helpDeskTicketFindRoute",
                    "Help-Desk/Tickets/Find/",
                    "~/Helpdesk/Tickets/Find.aspx");

                routes.MapPageRoute("helpDeskFAQRoute",
                    "Help-Desk/Frequently-Asked-Questions/",
                    "~/Helpdesk/FAQ/Index.aspx");

                routes.MapPageRoute("helpDeskFAQViewGroupRoute",
                    "Help-Desk/Frequently-Asked-Questions/Group/{itemid}/{name}/",
                    "~/Helpdesk/FAQ/FAQ.aspx");

                routes.MapPageRoute("helpDeskFAQViewItemRoute",
                    "Help-Desk/Frequently-Asked-Questions/View/{itemid}/{name}/",
                    "~/Helpdesk/FAQ/ViewFAQItem.aspx");

                // errors
                routes.MapPageRoute("errorRoute",
                    "Site-Error/",
                    "~/Error/Error.aspx");

                routes.MapPageRoute("errorMessageRoute",
                    "Site-Error/Message/{message}/",
                    "~/Error/Error.aspx");

                routes.MapPageRoute("errorNoFoundRoute",
                    "Site-Error/Page-Not-Found/",
                    "~/Error/Error404.aspx");

                routes.MapPageRoute("errorPermissionRoute",
                    "Site-Error/Invalid-Permission/",
                    "~/Error/InvalidPermissions.aspx");

                routes.MapPageRoute("errorIPBannedRoute",
                    "Site-Error/IP-Banned/",
                    "~/Error/IPIsBaned.aspx");
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
                e.Method, e.Source, e.Parameters, e.CallStack, e.Message, WebsiteSettings.DistributorWebsite);

            try
            {
#if ERROR_MANAGER
                if (!ErrorClient.GetErrorClient.SendError(
                    new ErrorManager.ErrorClient.Options("em.heavenskincare.com", 37789, "Heavenskincare", "Heaven_!3B"),
                    msg))
                {
                    //Failed to send error details to server
                    SendEMail(SupportName, SupportEMail, String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
                        msg, SupportName, SupportEMail);
                }
#else
                SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, 
                    String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
                    msg, WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail);
#endif
            }
            catch (Exception err)
            {
                if (err.Message.Contains("Could not load file or assembly 'TCPMessageServer"))
                {
                    //Failed to send error details to server
                    SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, 
                        String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
                        msg, WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail);
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
            if (!WebsiteSettings.StaticWebSite)
            {
                try
                {
                    if (WebsiteSettings.WebFarm.WebFarmMaster())
                    {
                        ThreadManager.ThreadStart(new UpdateAutoRulesThread(),
                            "Auto Rule Update", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new UpdateCustomPagesThread(),
                            "Update Custom Pages", ThreadPriority.Lowest);
                    }

                    if (!WebsiteSettings.WebFarm.IsWebFarm && WebsiteSettings.Maintenance.AllowRoutineMaintenance)
                    {
                        // if the site is part of a web farm then routine maintenance must be handled via a task scheduler
                        ThreadManager.ThreadStart(new RoutineMaintenanceThread(),
                            "Routine Maintenance", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new RoutineMaintenanceCampaignsThread(),
                            "Routine Maintenance Campaigns", ThreadPriority.Lowest);
                    }

                    if (WebsiteSettings.WebFarm.WebFarmMaster())
                    {
#if GeoIPUpdates
                        if (BaseWebApplication.AllowWebsiteGeoUpdate)
                            ThreadManager.ThreadStart(new GeoIPUpdateThread(),
                                "GeoIP Update", ThreadPriority.Lowest);
#endif

                        if (WebsiteSettings.Email.SendEmails)
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

#if CACHE_IP_CITY_DATA
        private static IPCity[] _allCityData;
        private static int _count = 0;
#endif

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
            string siteMapData = WebsiteSettings.RootPath + "admin\\sitemap.dat";

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
                    url = HTMLEncode(WebsiteSettings.RootURL + defaultRow[0]);

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
                                    url = String.Format("{0}/Products/Stratosphere.aspx?ID={1}",
                                        WebsiteSettings.RootURL, prod.ID);
                                    break;
                                default:
                                    url = String.Format("{0}/Products/Product.aspx?ID={1}",
                                        WebsiteSettings.RootURL, prod.ID);
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
                    url = String.Format("{0}/Celebrities/ViewCeleb.aspx?ID={1}", WebsiteSettings.RootURL, celeb.ID);
                    string newXMLEntry = String.Format("  <url>\r\n    <loc>{0}</loc>\r\n    <changefreq>weekly</changefreq>\r\n" +
                        "    <priority>0.6</priority>\r\n  </url>\r\n", HTMLEncode(url));

                    newSiteMapXML += newXMLEntry;
                }

                // salons


                // distributors

                newSiteMapXML += "</urlset>\r\n";

                Utilities.FileWrite(WebsiteSettings.RootPath + "sitemap_location.xml", newSiteMapXML);

                // update robots.txt
                siteMapData = WebsiteSettings.RootPath + "robots.txt";
                string robots = Utilities.FileRead(siteMapData, true);

                // remove first line, upto first \r\n
                robots = robots.Substring(robots.IndexOf('\r'));
                robots = String.Format("Sitemap: {0}/sitemap_location.xml{1}",
                    WebsiteSettings.RootURL, robots);
                Utilities.FileWrite(siteMapData, robots);
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
            _emailSettings = EmailSettingsSingletonClass.GetInstance(WebsiteSettings.Email.SMTPHost,
                WebsiteSettings.Email.SMTPPort, WebsiteSettings.Email.SMTPUserName,
                WebsiteSettings.Email.SMTPPassword, WebsiteSettings.Email.SMTPUseSSL);
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
