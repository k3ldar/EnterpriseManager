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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: WebsiteSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  06/02/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using Shared.Classes;
using System;
using System.Globalization;


namespace SharedBase.BOL.Websites
{
    public static class WebsiteSettings
    {
        #region Properties

        public static string PageTitle { get; set; }

        public static string RootPath { get; set; }

        public static string RootURL { get; set; }

        public static bool WebsiteCultureOverride { get; set; }

        public static string BasketName { get; set; }

        public static string DistributorWebsite { get; set; }

        public static string WebsiteDateFormat { get; set; }

        public static bool UseLeftToRight { get; set; }

        public static bool UseHTTPS { get; set; }

        public static string StyleSheet { get; set; }

        public static bool StaticWebSite { get; set; }

        #endregion Properties

        #region Sub Settings

        public static class HomePage
        {
            #region Properties

            public static bool ShowHomeBanners { get; set; }

            public static bool ShowHomeFeaturedProducts { get; set; }

            #region Page Banners

            public static string PageBanner1 { get; set; }

            public static string PageBanner1Link { get; set; }

            public static string PageBanner2 { get; set; }

            public static string PageBanner2Link { get; set; }

            public static string PageBanner3 { get; set; }

            public static string PageBanner3Link { get; set; }

            #endregion Page Banners

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

            #endregion Properties
        }

        public static class AllPages
        {
            #region Properties

            public static bool ShowTermsAndConditions { get; set; }

            public static bool ShowPrivacyPolicy { get; set; }

            public static bool ShowReturnsPolicy { get; set; }

            public static bool ShowSalonsMenu { get; set; }

            public static bool ShowSalonFinder { get; set; }

            public static bool ShowClientHeader { get; set; }

            public static bool ShowSalonHeader { get; set; }

            public static bool ShowTreatmentsMenu { get; set; }

            public static bool ShowTreatmentsBrochure { get; set; }

            public static bool ShowDistributorsMenu { get; set; }

            public static bool ShowTipsAndTricksMenu { get; set; }

            public static bool ShowDownloadMenu { get; set; }

            public static bool ShowTradePage { get; set; }

            #endregion Properties
        }

        public static class ContactDetails
        {
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
        }

        #region Email

        public static class Email
        {
            #region Properties

            public static string NoReplyName { get; set; }

            public static string NoReplyEmail { get; set; }

            public static string SMTPHost { get; set; }

            public static string SMTPUserName { get; set; }

            public static string SMTPPassword { get; set; }

            public static bool SMTPUseSSL { get; set; }

            public static int SMTPPort { get; set; }

            public static bool SendEmails { get; set; }

            public static string SupportName { get; set; }

            public static string SupportEMail { get; set; }

            #endregion Properties
        }

        #endregion Email

        #region Payment Gateways

        public static class PaymentGateways
        {
            #region Properties

            public static bool ShowPaymentPaypal { get; set; }

            public static bool ShowPaymentPaypoint { get; set; }

            public static bool ShowPaymentCard { get; set; }

            public static bool ShowPaymentCheque { get; set; }

            public static bool ShowPaymentSunTechBuySafe { get; set; }

            public static bool ShowPaymentSunTech24Payment { get; set; }

            public static bool ShowPaymentSunTechWebATM { get; set; }

            public static bool ShowPaymentTelephone { get; set; }

            public static bool ShowPaymentCashOnDelivery { get; set; }

            public static bool ShowPaymentDirectBankTransfer { get; set; }

            public static bool ShowPaymentTestPurchase { get; set; }



            #endregion Properties

            #region Payment Gateways

            public static class WorldPay
            {
                /// <summary>
                /// Currencies available for Paynet
                /// </summary>
                public static string Currencies { get; set; }
            }

            public static class Paypal
            {
                #region Properties

                public static string DefaultCurrency { get; set; }

                public static string APIUsername { get; set; }

                public static string APIPassword { get; set; }

                public static string APISignature { get; set; }

                public static string Subject { get; set; }

                public static string BNCode { get; set; }

                public static string APISuccessURL { get; set; }

                public static string APIFailURL { get; set; }

                #endregion Properties
            }

            public static class Payflow
            {
                #region Properties

                /// <summary>
                /// Determines wether card payment is shown or not
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
                public static string Currencies { get; set; }


                #endregion Properties
            }

            public static class SunTech
            {
                public static class BuySafe
                {
                    #region Properties

                    /// <summary>
                    /// Currencies supported by ChinaPay
                    /// </summary>
                    public static string SupportedCurrencies { get; set; }

                    /// <summary>
                    /// Merchant ID
                    /// </summary>
                    public static string MerchantID { get; set; }

                    /// <summary>
                    /// Merchant Password
                    /// </summary>
                    public static string MerchantPassword { get; set; }

                    /// <summary>
                    /// Time out in seconds for web call, default 30 seconds
                    /// </summary>
                    public static int TimeOut { get; set; }

                    /// <summary>
                    /// Indicates test mode or not
                    /// </summary>
                    public static bool TestMode { get; set; }

                    #endregion Properties
                }

                public static class Payment24
                {
                    #region Properties

                    /// <summary>
                    /// Currencies supported by ChinaPay
                    /// </summary>
                    public static string SupportedCurrencies { get; set; }

                    /// <summary>
                    /// Merchant ID
                    /// </summary>
                    public static string MerchantID { get; set; }

                    /// <summary>
                    /// Merchant Password
                    /// </summary>
                    public static string MerchantPassword { get; set; }

                    /// <summary>
                    /// Time out in seconds for web call, default 30 seconds
                    /// </summary>
                    public static int TimeOut { get; set; }

                    /// <summary>
                    /// Indicates test mode or not
                    /// </summary>
                    public static bool TestMode { get; set; }

                    /// <summary>
                    /// The number of days added to current date to set duedate
                    /// </summary>
                    public static int DueDateDays { get; set; }

                    #endregion Properties
                }

                public static class WebATM
                {
                    #region Properties

                    /// <summary>
                    /// Currencies supported by ChinaPay
                    /// </summary>
                    public static string SupportedCurrencies { get; set; }

                    /// <summary>
                    /// Merchant ID
                    /// </summary>
                    public static string MerchantID { get; set; }

                    /// <summary>
                    /// Merchant Password
                    /// </summary>
                    public static string MerchantPassword { get; set; }

                    /// <summary>
                    /// Time out in seconds for web call, default 30 seconds
                    /// </summary>
                    public static int TimeOut { get; set; }

                    /// <summary>
                    /// Indicates test mode or not
                    /// </summary>
                    public static bool TestMode { get; set; }

                    /// <summary>
                    /// The number of days added to current date to set duedate
                    /// </summary>
                    public static int DueDateDays { get; set; }

                    /// <summary>
                    /// The number of days added to current date to set duedate
                    /// </summary>
                    public static int BillDateDays { get; set; }

                    #endregion Properties
                }

            }

            public static class Cheque
            {
                public static string Currency { get; set; }
            }

            public static class DirectTransfer
            {
                public static string Currency { get; set; }
            }

            public static class CashOnDelivery
            {
                public static string Currency { get; set; }

            }

            public static class TestPurchase
            {
                public static string Currency { get; set; }
            }

            public static class Telephone
            {
                public static string Currency { get; set; }
            }

            #endregion Payment Gateways
        }

        #endregion Payment Gateways

        #region Web Farms

        public static class WebFarm
        {
            #region Private Members

#if NET461
            private static MutexEx _mutex = null;
#endif
            #endregion Private Members

            #region Properties

            public static bool IsWebFarm { get; set; }

            public static string WebFarmMasterIP { get; set; }

            public static string WebFarmMutexName { get; set; }

            #endregion Properties

            #region Public Methods

            public static bool WebFarmMaster()
            {
#if NET461
                if (!IsWebFarm || _mutex == null)
                    return (true);

                if (_mutex.Exists && _mutex.MutexCreated)
                    return (true);
#endif

                return (false);
            }

            public static void Initialise()
            {

                if (IsWebFarm &&
                    !String.IsNullOrEmpty(WebFarmMutexName) &&
                    Shared.Utilities.LocalIPAddress(WebFarmMasterIP))
                {
                    // if the application is part of a web farm/garden, then only one process in the entire farm
                    // can be the "master" process.  The master process is determined when WebFarmMasterIP ip address
                    // matches the ip address on the computer it is loaded on.  Further, on that single computer
                    // a global mutex is created, the first process on the computer that matches the ip address wins, all 
                    // others will not be the master controller.
#if NET461
                    _mutex = new MutexEx(WebFarmMutexName);

                    if (!_mutex.Exists)
                    {
                        _mutex.CreateMutex();
                    }

                    Shared.EventLog.Add(String.Format("Process ID: {0}; Created: {1}; Name: {2}",
                        System.Diagnostics.Process.GetCurrentProcess().Id, _mutex.MutexCreated, _mutex.Name));
#endif
                }
            }

            public static void Close()
            {
#if NET461
                if (_mutex != null)
                    _mutex.Dispose();
#endif
            }

            #endregion Public Methods
        }

        #endregion Web Farms

        #region Analytics

        public static class Analytics
        {
            public static class Google
            {
                public static string GoogleAnalytics { get; set; }
            }
        }

        #endregion Analytics

        #region Stock

        public static class Stock
        {
            #region Properties

            /// <summary>
            /// If true user can opt to be notified when the item is back in stock
            /// </summary>
            public static bool OutOfStockAllowNotifyUser { get; set; }

            /// <summary>
            /// If true then out of stock will be handled in the product page, otherwise in an external page (faster)
            /// </summary>
            public static bool OutOfStockInPage { get; set; }

            #endregion Properties
        }

        #endregion Stock

        #region Credit Cards

        public static class CreditCards
        {
            #region Properties

            public static bool AllowCreditCards { get; set; }

            public static bool CreditCardHideValidFrom { get; set; }

            public static bool CreditCardAlwaysShowValidFromForUK { get; set; }

            #endregion Properties
        }

        #endregion Credit Cards

        #region Licences

        public static class Licences
        {
            /// <summary>
            /// Is user licence management enabled
            /// </summary>
            public static bool AllowLicences { get; set; }
        }

        #endregion LIcences

        #region Marketing

        public static class Marketing
        {
            public static bool AllowMailListSubscribers { get; set; }

            #region Mail Chimp

            public static class MailChimp
            {

                public static string MailChimpAPI { get; set; }

                public static string MailChimpList { get; set; }

                public static string MailChimpKey { get; set; }

                public static string MailChimpPopupDialog { get; set; }
            }

            #endregion Mail Chimp
        }

        #endregion Marketing

        #region Offers

        public static class Offers
        {
            public static bool ShowOffers { get; set; }

            public static bool ShowVoucher { get; set; }
        }

        #endregion Offers

        #region Shopping Cart

        public static class ShoppingCart
        {
            #region Properties

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
            public static bool BasketSummaryAutoHide { get; set; }

            /// <summary>
            /// Number of basket id's to retrieve in one go
            /// </summary>
            public static int BasketIDIncrement = 1000;

            /// <summary>
            /// Determines wether prices are shown if default can not be determined for country
            /// </summary>
            public static bool DefaultShowPrices { get; set; }

            public static bool OverrideCostMultiplier { get; set; }

            public static double OverrideCostMultiplierValue { get; set; }

            #endregion Properties
        }

        #endregion Shopping Cart

        #region Tax/VAT Options

        public static class Tax
        {

            #region Properties

            /// <summary>
            /// Standard VAT Rate for Website
            /// </summary>
            public static Double VatRate { get; set; }

            /// <summary>
            /// Indicates wether prices include VAT or not
            /// 
            /// If prices include VAT then other vat options will apply to remove VAT when showing etc
            /// </summary>
            public static bool PricesIncludeVAT { get; set; }


            /// <summary>
            /// if true show items in the basket with VAT, otherwise VAT is removed
            /// </summary>
            public static bool ShowBasketItemsWithVAT { get; set; }

            /// <summary>
            /// If true the subtotal in the basket will be shown with vat
            /// </summary>
            public static bool ShowBasketSubTotalWithVAT { get; set; }


            public static bool ShippingIsTaxable { get; set; }

            #endregion Properties
        }

        #endregion Tax/VAT Options

        #region Social Media

        public static class SocialMedia
        {
            public static class Facebook
            {
                public static string Url { get; set; }

            }

            public static class Twitter
            {
                public static string Url { get; set; }

                /// <summary>
                /// Default twitter tags
                /// </summary>
                public static string DefaultTags { get; set; }
            }

            public static class Google
            {
                public static string GPlus { get; set; }

            }

            public static class RSS
            {
                public static string Feed { get; set; }
            }

            public static class Blog
            {
                #region Properties

                public static string Url { get; set; }

                #endregion Properties
            }
        }

        #endregion Social Media

        #region Maintenance Mode

        public static class Maintenance
        {
            public static bool AutoMaintenanceMode;

            /// <summary>
            /// Determines wether the website is in maintenance mode
            /// </summary>
            public static bool MaintenanceMode { get; set; }


            /// <summary>
            /// Determines wether XML Image Files are created
            /// </summary>
            public static bool CreateXMLImageFiles { get; set; }

            /// <summary>
            /// Determines wether routine database maintenance is run
            /// 
            /// Used for websites that share a database
            /// </summary>
            public static bool AllowRoutineMaintenance { get; set; }
        }

        #endregion Maintenance Mode

        #region Languages

        public static class Languages
        {

            /// <summary>
            /// Indicates wether the Localized Languages is active or not
            /// </summary>
            public static bool Active { get; set; }

            /// <summary>
            /// if true then the DefaultCountrySettings will be used by default with all new
            /// connections, if false then the initial country (ergo language) will be set from
            /// the users IP address
            /// </summary>
            public static bool ForceInitialDefaultLanguage { get; set; }

            public static bool UseCustomPages { get; set; }

            public static CultureInfo WebsiteCulture { get; set; }

            public static string DefaultCountrySettings { get; set; }
        }

        #endregion Languages

        #region Trade Customers

        public static class TradeCustomers
        {
            /// <summary>
            /// Shows trade download menu in user screen
            /// </summary>
            public static bool ShowTradeDownloads { get; set; }
        }

        #endregion Trade Customers

        #region Members Area

        public static class Members
        {
            /// <summary>
            /// Shows salon update menu items
            /// </summary>
            public static bool ShowSalonUpdate { get; set; }

            /// <summary>
            /// Show's appointments in user menu items
            /// </summary>
            public static bool ShowAppointments { get; set; }

        }

        #endregion Members Area

        #region Affiliate

        public static class Affiliates
        {

            public static int MaximumDays { get; set; }

        }

        #endregion Affiliate

        #region Carousel

        public static class Carousel
        {
            /// <summary>
            /// Determines wether custom text is shown on home page scroller
            /// </summary>
            public static bool CustomScrollerStrapLine { get; set; }

            /// <summary>
            /// The custom text to show on home page
            /// </summary>
            public static string CustomScrollerText { get; set; }
        }

        #endregion Carousel

        #region Geo Update

        public static class GeoIP
        {
            #region Private Members

            private static bool _allowWebsiteGeoUpdate = false;

            private static DateTime GeoIPLastUpdated;
            private static long GeoIPLatestVersion;

            #endregion Private Members

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
                        string rootPath = Shared.Utilities.AddTrailingBackSlash(WebsiteSettings.RootPath);
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
        }

        #endregion GeoUpdate

        #endregion Sub Settings

        #region Static Methods


        #region Configuration Settings

        public static DateTime ConfigSettingGet(string name, DateTime defaultValue, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            DateTime Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = LibraryHelperClass.SettingsGetDateTime(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static decimal ConfigSettingGet(string name, decimal defaultValue, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            decimal Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = LibraryHelperClass.SettingsGetDecimal(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static double ConfigSettingGet(string name, double defaultValue, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            double Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = LibraryHelperClass.SettingsGetDouble(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static int ConfigSettingGet(string name, int defaultValue, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            int Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                Result = LibraryHelperClass.SettingsGetInt(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static bool ConfigSettingGet(string name, bool defaultValue, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            bool Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                if (LibraryHelperClass.SettingsExist(keyName))
                {
                    Result = LibraryHelperClass.SettingsGetBool(keyName, defaultValue);
                }
                else
                {
                    LibraryHelperClass.SettingsSet(keyName, defaultValue.ToString());
                }
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static string ConfigSettingGet(string name, string defaultValue, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            string Result = defaultValue;

            try
            {
                if (keyName.Length > 50)
                    keyName = keyName.Substring(0, 50);

                if (LibraryHelperClass.SettingsExist(keyName))
                    Result = LibraryHelperClass.SettingsGet(keyName, defaultValue);
                else
                    LibraryHelperClass.SettingsSet(keyName, defaultValue);
            }
            catch
            {
                //ignore, default setting already set above;
            }

            return (Result);
        }

        public static bool ConfigSettingExists(string name, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            if (keyName.Length > 50)
                keyName = keyName.Substring(0, 50);

            return (LibraryHelperClass.SettingsExist(keyName));
        }

        public static void ConfigSettingSet(string name, decimal value, int websiteID, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), websiteID, isGlobal);
        }

        public static void ConfigSettingSet(string name, double value, int websiteID, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), websiteID, isGlobal);
        }

        public static void ConfigSettingSet(string name, int value, int websiteID, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), websiteID, isGlobal);
        }

        public static void ConfigSettingSet(string name, bool value, int websiteID, bool isGlobal = false)
        {
            ConfigSettingSet(name, value.ToString(), websiteID, isGlobal);
        }

        public static void ConfigSettingSet(string name, string value, int websiteID, bool isGlobal = false)
        {
            string keyName = name;

            if (!isGlobal)
                keyName = String.Format("{0}.{1}", websiteID, name);

            if (keyName.Length > 50)
                keyName = keyName.Substring(0, 50);

            LibraryHelperClass.SettingsSet(keyName, value);
        }


        public static bool LoadWebsiteSettingsFromDatabase(int websiteID)
        {
            bool Result = false;

            StaticWebSite = false;

            LibraryHelperClass.ResetCache();

            LibraryHelperClass.InitialiseSettings();

            #region Base Website Options

            PageTitle = ConfigSettingGet("Settings.DefaultTitle", String.Empty, websiteID);

            RootURL = ConfigSettingGet("Settings.RootURL", String.Empty, websiteID);

            RootPath = ConfigSettingGet("Settings.RootPath", String.Empty, websiteID);

            WebsiteCultureOverride = ConfigSettingGet("Settings.WebCultureOverride", false, websiteID);

            BasketName = ConfigSettingGet("Settings.ShoppingBasketName", String.Empty, websiteID);

            DistributorWebsite = ConfigSettingGet("Settings.DistributorWebsite", String.Empty, websiteID);

            WebsiteDateFormat = ConfigSettingGet("Settings.WebsiteDateFormat", String.Empty, websiteID);

            UseLeftToRight = ConfigSettingGet("Settings.UseLeftToRight", true, websiteID);

            UseHTTPS = ConfigSettingGet("Settings.UseHTTPS", true, websiteID);

            StyleSheet = ConfigSettingGet("SITE.STYLE_SHEET", "StyleMain.css", websiteID);

            #endregion Base Website Options

            #region Home Page Settings

            HomePage.ShowHomeBanners = ConfigSettingGet("Settings.HomeBanners", true, websiteID);

            HomePage.ShowHomeFeaturedProducts = ConfigSettingGet("SETTINGS.HOMEFEATURED", false, websiteID);

            #region Page Banners

            HomePage.PageBanner1 = ConfigSettingGet("PAGEBANNER1", String.Empty, websiteID);
            HomePage.PageBanner1Link = ConfigSettingGet("PAGEBANNER1LINK", String.Empty, websiteID);

            HomePage.PageBanner2 = ConfigSettingGet("PAGEBANNER2", String.Empty, websiteID);
            HomePage.PageBanner2Link = ConfigSettingGet("PAGEBANNER2LINK", String.Empty, websiteID);

            HomePage.PageBanner3 = ConfigSettingGet("PAGEBANNER3", String.Empty, websiteID);
            HomePage.PageBanner3Link = ConfigSettingGet("PAGEBANNER3LINK", String.Empty, websiteID);

            #endregion Page Banners

            #region Rotating Home Page Banners

            HomePage.HomeBanner1 = ConfigSettingGet("HomeBanner1", String.Empty, websiteID);
            HomePage.HomeBanner2 = ConfigSettingGet("HomeBanner2", String.Empty, websiteID);
            HomePage.HomeBanner3 = ConfigSettingGet("HomeBanner3", String.Empty, websiteID);
            HomePage.HomeBanner4 = ConfigSettingGet("HomeBanner4", String.Empty, websiteID);
            HomePage.HomeBanner5 = ConfigSettingGet("HomeBanner5", String.Empty, websiteID);

            HomePage.HomeBanner1Link = ConfigSettingGet("HomeBanner1Link", String.Empty, websiteID);
            HomePage.HomeBanner2Link = ConfigSettingGet("HomeBanner2Link", String.Empty, websiteID);
            HomePage.HomeBanner3Link = ConfigSettingGet("HomeBanner3Link", String.Empty, websiteID);
            HomePage.HomeBanner4Link = ConfigSettingGet("HomeBanner4Link", String.Empty, websiteID);
            HomePage.HomeBanner5Link = ConfigSettingGet("HomeBanner5Link", String.Empty, websiteID);

            #endregion Rotating Home Page Banners

            #endregion Home Page Settings

            #region Global Page Options

            AllPages.ShowTermsAndConditions = ConfigSettingGet("Settings.ShowTermsAndConditions", true, websiteID);
            AllPages.ShowPrivacyPolicy = ConfigSettingGet("Settings.ShowPrivacyPolicy", true, websiteID);
            AllPages.ShowReturnsPolicy = ConfigSettingGet("Settings.ShowReturnsPolicy", true, websiteID);

            AllPages.ShowSalonsMenu = ConfigSettingGet("Settings.ShowSalons", true, websiteID);
            AllPages.ShowSalonFinder = ConfigSettingGet("Settings.ShowSalonFinder", true, websiteID);
            AllPages.ShowClientHeader = ConfigSettingGet("Settings.ShowSalonClientHeader", true, websiteID);
            AllPages.ShowSalonHeader = ConfigSettingGet("Settings.ShowSalonHeader", true, websiteID);

            AllPages.ShowTreatmentsMenu = ConfigSettingGet("Settings.ShowTreatments", true, websiteID);
            AllPages.ShowTreatmentsBrochure = ConfigSettingGet("Settings.ShowTreatmentBrochure", true, websiteID);
            AllPages.ShowDistributorsMenu = ConfigSettingGet("Settings.ShowDistributors", true, websiteID);
            AllPages.ShowTipsAndTricksMenu = ConfigSettingGet("Settings.ShowTipsAndTricks", true, websiteID);
            AllPages.ShowDownloadMenu = ConfigSettingGet("Settings.ShowDownloads", false, websiteID);

            AllPages.ShowTradePage = ConfigSettingGet("Settings.ShowTradePage", true, websiteID);

            #endregion Global Page Options

            #region General Contact Details

            ContactDetails.WebsiteTelephoneNumber = ConfigSettingGet("Settings.WebsiteTelephoneNumber", String.Empty, websiteID);
            ContactDetails.WebsiteEmail = ConfigSettingGet("Settings.WebsiteEmail", String.Empty, websiteID);
            ContactDetails.AddressLine1 = ConfigSettingGet("Settings.AddressLine1", String.Empty, websiteID);
            ContactDetails.AddressLine2 = ConfigSettingGet("Settings.AddressLine2", String.Empty, websiteID);
            ContactDetails.AddressLine3 = ConfigSettingGet("Settings.AddressLine3", String.Empty, websiteID);

            #endregion General Contact Details

            #region Email Settings

            Email.SupportName = ConfigSettingGet("Settings.SupportName", String.Empty, websiteID);
            Email.SupportEMail = ConfigSettingGet("Settings.SupportEMail", String.Empty, websiteID);
            Email.SMTPHost = ConfigSettingGet("Settings.SMTPHost", String.Empty, websiteID);
            Email.SMTPUserName = ConfigSettingGet("Settings.SMTPUserName", String.Empty, websiteID);
            Email.SMTPPassword = ConfigSettingGet("Settings.SMTPPassword", String.Empty, websiteID);
            Email.SMTPUseSSL = ConfigSettingGet("Settings.SMTPSSL", false, websiteID);
            Email.SMTPPort = ConfigSettingGet("Settings.SMTPPort", 25, websiteID);
            Email.SendEmails = ConfigSettingGet("Settings.SendEmail", false, websiteID);

            Email.NoReplyName = ConfigSettingGet("Settings.NoReplyName", String.Empty, websiteID);

            Email.NoReplyEmail = ConfigSettingGet("Settings.NoReplyEmail", String.Empty, websiteID);

            #endregion Email Settings

            #region Payment Gateways

            PaymentGateways.ShowPaymentPaypal = ConfigSettingGet("Settings.ShowPaymentPaypal", true, websiteID);
            PaymentGateways.ShowPaymentCard = ConfigSettingGet("Settings.ShowPaymentCard", false, websiteID);
            PaymentGateways.ShowPaymentPaypoint = ConfigSettingGet("Settings.ShowPaymentPaypoint", false, websiteID);
            PaymentGateways.ShowPaymentSunTechBuySafe = ConfigSettingGet("Settings.AllowSunTechBuySafe", false, websiteID);
            PaymentGateways.ShowPaymentSunTech24Payment = ConfigSettingGet("Settings.AllowSunTech24Payment", false, websiteID);
            PaymentGateways.ShowPaymentSunTechWebATM = ConfigSettingGet("Settings.AllowSunTechWebATM", false, websiteID);
            PaymentGateways.ShowPaymentTelephone = ConfigSettingGet("Settings.ShowPaymentTelephone", true, websiteID);
            PaymentGateways.ShowPaymentCashOnDelivery = ConfigSettingGet("Settings.ShowPaymentCOD", false, websiteID);
            PaymentGateways.ShowPaymentDirectBankTransfer = ConfigSettingGet("Settings.ShowPaymentDBT", false, websiteID);
            PaymentGateways.ShowPaymentTestPurchase = ConfigSettingGet("Settings.TestPurchase", false, websiteID);
            PaymentGateways.ShowPaymentCheque = ConfigSettingGet("Settings.ShowPaymentCheque", true, websiteID);


            #region Payflow

            if (PaymentGateways.ShowPaymentCard)
            {
                PaymentGateways.Payflow.PayflowTestMode = ConfigSettingGet("Settings.PayflowTestMode", true, websiteID);
                PaymentGateways.Payflow.PayflowPartner = ConfigSettingGet("Settings.PayflowPartner", String.Empty, websiteID);
                PaymentGateways.Payflow.PayflowVendor = ConfigSettingGet("Settings.PayflowVendor", String.Empty, websiteID);
                PaymentGateways.Payflow.PayflowUser = ConfigSettingGet("Settings.PayflowUser", String.Empty, websiteID);
                PaymentGateways.Payflow.PayflowPassword = ConfigSettingGet("Settings.PayflowPassword", String.Empty, websiteID);
                PaymentGateways.Payflow.Currencies = ConfigSettingGet("Settings.PayflowCurrencies", "GBP;USD", websiteID);
            }

            #endregion Payflow

            #region Payment Providers Paypal

            if (PaymentGateways.ShowPaymentPaypal)
            {
                PaymentGateways.Paypal.APIUsername = ConfigSettingGet("Settings.PaypalAPIUserName", String.Empty, websiteID);
                PaymentGateways.Paypal.APIPassword = ConfigSettingGet("Settings.PaypalAPIPassword", String.Empty, websiteID);
                PaymentGateways.Paypal.APISignature = ConfigSettingGet("Settings.PaypalAPISignature", String.Empty, websiteID);
                PaymentGateways.Paypal.Subject = ConfigSettingGet("Settings.PaypalAPISubject", String.Empty, websiteID);
                PaymentGateways.Paypal.BNCode = ConfigSettingGet("Settings.PaypalAPIBNCode", String.Empty, websiteID);
                PaymentGateways.Paypal.DefaultCurrency = ConfigSettingGet("Settings.PaypalAPICurrency", "GBP;USD", websiteID);
                PaymentGateways.Paypal.APISuccessURL = ConfigSettingGet("Settings.PaypalSuccessURL", String.Empty, websiteID);
                PaymentGateways.Paypal.APIFailURL = ConfigSettingGet("Settings.PaypalFailURL", String.Empty, websiteID);
            }

            #endregion Payment Providers Paypal

            #region WorldPay

            PaymentGateways.WorldPay.Currencies = ConfigSettingGet("Settings.PaynetCurrency", "GBP", websiteID);

            #endregion WorldPay

            #region Payment Providers Cheque

            PaymentGateways.Cheque.Currency = ConfigSettingGet("Settings.ChequeCurrency", "GBP", websiteID);

            #endregion Payment Providers Cheque

            #region Payment Providers Sun Tech

            if (PaymentGateways.ShowPaymentSunTechBuySafe)
            {
                PaymentGateways.SunTech.BuySafe.SupportedCurrencies = ConfigSettingGet("Settings.BuySafeCurrencies", "GBP", websiteID);
                PaymentGateways.SunTech.BuySafe.MerchantID = ConfigSettingGet("Settings.BuySafeMerchantID", "", websiteID);
                PaymentGateways.SunTech.BuySafe.MerchantPassword = ConfigSettingGet("Settings.BuySafeMerchantPW", "", websiteID);
                PaymentGateways.SunTech.BuySafe.TestMode = ConfigSettingGet("Settings.BuySafeTestMode", true, websiteID);
            }

            if (PaymentGateways.ShowPaymentSunTech24Payment)
            {
                PaymentGateways.SunTech.Payment24.SupportedCurrencies = ConfigSettingGet("Settings.24PaymentCurrencies", "GBP", websiteID);
                PaymentGateways.SunTech.Payment24.MerchantID = ConfigSettingGet("Settings.24PaymentMerchantID", "", websiteID);
                PaymentGateways.SunTech.Payment24.MerchantPassword = ConfigSettingGet("Settings.24PaymentMerchantPW", "", websiteID);
                PaymentGateways.SunTech.Payment24.TestMode = ConfigSettingGet("Settings.24PaymentTestMode", true, websiteID);
                PaymentGateways.SunTech.Payment24.DueDateDays = ConfigSettingGet("Settings.24PaymentDueDays", 30, websiteID);
            }

            if (PaymentGateways.ShowPaymentSunTechWebATM)
            {
                PaymentGateways.SunTech.WebATM.SupportedCurrencies = ConfigSettingGet("Settings.WebATMCurrencies", "GBP", websiteID);
                PaymentGateways.SunTech.WebATM.MerchantID = ConfigSettingGet("Settings.WebATMMerchantID", "", websiteID);
                PaymentGateways.SunTech.WebATM.MerchantPassword = ConfigSettingGet("Settings.WebATMMerchantPW", "", websiteID);
                PaymentGateways.SunTech.WebATM.TestMode = ConfigSettingGet("Settings.WebATMTestMode", true, websiteID);
                PaymentGateways.SunTech.WebATM.BillDateDays = ConfigSettingGet("Settings.WebATMBillDays", 30, websiteID);
                PaymentGateways.SunTech.WebATM.DueDateDays = ConfigSettingGet("Settings.WebAMTDueDays", 30, websiteID);
            }

            #endregion Payment Providers Sun Tech

            #region Payment Provider Telephone

            PaymentGateways.Telephone.Currency = ConfigSettingGet("Settings.PhoneCurrency", "GBP", websiteID);

            #endregion Payment Provider Telephone

            #region Payment Provider Cash On Delivery

            PaymentGateways.CashOnDelivery.Currency = ConfigSettingGet("Settings.CODCurrency", "GBP", websiteID);

            #endregion Payment Provider Cash On Delivery

            #region Direct Bank Transfer

            //currencies for payment providers
            PaymentGateways.DirectTransfer.Currency = ConfigSettingGet("Settings.DTCurrency", "GBP", websiteID);

            #endregion Direct Bank Transfer

            #region Credit Card Options

            CreditCards.CreditCardAlwaysShowValidFromForUK = ConfigSettingGet("Settings.AlwaysShowCCForUK", true, websiteID);
            CreditCards.CreditCardHideValidFrom = ConfigSettingGet("Settings.AlwaysHideValidFrom", false, websiteID);
            CreditCards.AllowCreditCards = ConfigSettingGet("Settings.AllowCreditCards", true, websiteID);

            #endregion Credit Card Options

            #region Test Purchase Options

            PaymentGateways.TestPurchase.Currency = ConfigSettingGet(
                "Settings.TestPurchaseCurrencies", String.Empty, websiteID);

            #endregion Test Purchase Options


            #endregion Payment Gateways

            #region Web Farm/Garden

            WebFarm.IsWebFarm = ConfigSettingGet("WEB.FARM", false, websiteID, true);
            WebFarm.WebFarmMasterIP = ConfigSettingGet("WEB.FARM.MASTER", String.Empty, websiteID, true);
            WebFarm.WebFarmMutexName = ConfigSettingGet("WEB.FARM.MUTEX", "WEB_FARM_MUTEX", websiteID, true);

            #endregion Web Farm/Garden

            #region Google Analytics

            Analytics.Google.GoogleAnalytics = ConfigSettingGet("SETTINGS.GOOGLE.ANALYTICS", String.Empty, websiteID);

            #endregion Google Analytics

            #region Caching

            // caching
            DAL.DALHelper.AllowCaching = ConfigSettingGet("Setting.AllowCaching", true, websiteID);
            DAL.DALHelper.CacheLimit = new TimeSpan(0, ConfigSettingGet("Setting.CacheLimit", 30, websiteID), 0);

            #endregion Caching

            #region Stock

            Stock.OutOfStockAllowNotifyUser = ConfigSettingGet("Settings.OutOfStockAllowNotifyUser", false, websiteID);
            Stock.OutOfStockInPage = ConfigSettingGet("Settings.OutOfStockInPage", false, websiteID);

            #endregion Stock

            #region Licence Options

            Licences.AllowLicences = ConfigSettingGet("Settings.AllowLicences", false, websiteID);

            #endregion Licence Options

            #region Offers

            Offers.ShowOffers = ConfigSettingGet("Settings.ShowOffers", true, websiteID);
            Offers.ShowVoucher = ConfigSettingGet("Settings.ShowVoucher", false, websiteID);

            #endregion Offers

            #region Mail List Subscribers

            // mail list subscription
            Marketing.AllowMailListSubscribers = ConfigSettingGet("SETTINGS.MAILLIST.ALLOW", false, websiteID);

            #endregion Mail List Subscribers

            #region Mail Chimp integration

            Marketing.MailChimp.MailChimpAPI = ConfigSettingGet("Settings.MailChimpAPI", String.Empty, websiteID);
            Marketing.MailChimp.MailChimpList = ConfigSettingGet("Settings.MailChimpList", String.Empty, websiteID);
            Marketing.MailChimp.MailChimpKey = ConfigSettingGet("Settings.MailChimpKey", String.Empty, websiteID);
            Marketing.MailChimp.MailChimpPopupDialog = ConfigSettingGet("Settings.MailChimpPopup", String.Empty, websiteID);

            if (String.IsNullOrEmpty(Marketing.MailChimp.MailChimpKey))
            {
                Marketing.MailChimp.MailChimpKey = Shared.Utilities.RandomPassword(25);
                ConfigSettingSet("Settings.MailChimpKey", Marketing.MailChimp.MailChimpKey, websiteID);
            }

            #endregion Mail Chimp Integration

            #region Shopping Cart

            ShoppingCart.MaximumItemQuantity = ConfigSettingGet("Settings.MaximumItemQuantity", 5, websiteID);

            ShoppingCart.JumpToBasketAfterAddItem = ConfigSettingGet("Settings.JumpToBasketAfterAddItem", false, websiteID);

            ShoppingCart.HideShoppingCart = ConfigSettingGet("Settings.HideShoppingCart", false, websiteID);

            ShoppingCart.BasketSummaryShow = ConfigSettingGet("Settings.BasketSummaryShow", true, websiteID);

            ShoppingCart.BasketSummaryAutoHide = ConfigSettingGet("Settings.BasketSummaryAutoHide", false, websiteID);

            ShoppingCart.BasketSummaryTimeOut = Shared.Utilities.CheckMinMax(ConfigSettingGet("SettingsBasketSummaryTimeout", 10, websiteID), 5, 25);

            ShoppingCart.BasketIDIncrement = Shared.Utilities.CheckMinMax(ConfigSettingGet("Settings.BasketIDCount", 500, websiteID), 100, 10000);

            ShoppingCart.FreeShippingAllow = ConfigSettingGet("Settings.FreeShippingAllow", false, websiteID);

            ShoppingCart.FreeShippingAmount = ConfigSettingGet("Settings.FreeShippingSpend", 100.00m, websiteID);

            ShoppingCart.ClearBasketOnPayment = ConfigSettingGet("Settings.ClearBasketOnPayment", false, websiteID, true);

            ShoppingCart.AlterTextColorBasedOnBasketContents = ConfigSettingGet("Settings.AlterTextColorBasedOnBasketContents", false, websiteID);

            ShoppingCart.ItemDoesNotExistsInShoppingBagTextColour = ConfigSettingGet("Settings.ItemDoesNotExistsInShoppingBagTextColour", "white", websiteID);

            ShoppingCart.ItemExistsInShoppingBagTextColour = ConfigSettingGet("Settings.ItemExistsInShoppingBagTextColour", "white", websiteID);

            ShoppingCart.DefaultShowPrices = ConfigSettingGet("Settings.ShowPriceDefault", true, websiteID);

            ShoppingCart.OverrideCostMultiplier = ConfigSettingGet("Settings.OverrideCostMultiplier", false, websiteID);

            ShoppingCart.OverrideCostMultiplierValue = ConfigSettingGet("Settings.OverrideCostMultiplierValue", 0.0, websiteID);

            #endregion Shopping Cart

            #region VAT/Tax Settings

            DAL.DALHelper.HideVATOnWebsiteAndInvoices = ConfigSettingGet("Settings.HideVATOnWebsiteAndInvoices", false, websiteID);
            Tax.VatRate = ConfigSettingGet("Settings.VatRate", 20.0, websiteID);
            Tax.PricesIncludeVAT = ConfigSettingGet("Settings.PricesIncludeVAT", false, websiteID);
            Tax.ShippingIsTaxable = ConfigSettingGet("Settings.ShippingIsTaxable", true, websiteID);
            Tax.ShowBasketItemsWithVAT = ConfigSettingGet("Settings.ShowBasketItemsWithVAT", false, websiteID);
            Tax.ShowBasketSubTotalWithVAT = ConfigSettingGet("Settings.ShowBasketSubTotalWithVAT", true, websiteID);

            #endregion VAT/Tax Settings

            #region Social Media

            SocialMedia.Facebook.Url = ConfigSettingGet("Settings.Facebook", "", websiteID);
            SocialMedia.Google.GPlus = ConfigSettingGet("Settings.GPlus", "", websiteID);
            SocialMedia.RSS.Feed = ConfigSettingGet("Settings.RSSFeed", "", websiteID);
            SocialMedia.Twitter.Url = ConfigSettingGet("Settings.Twitter", "", websiteID);
            SocialMedia.Twitter.DefaultTags = ConfigSettingGet("Settings.TwitterTags", String.Empty, websiteID);
            SocialMedia.Blog.Url = ConfigSettingGet("BlogURL", String.Empty, websiteID, true);

            #endregion Social Media

            #region Maintenance Options

            Maintenance.AutoMaintenanceMode = true;
            Maintenance.MaintenanceMode = ConfigSettingGet("Settings.MaintenanceMode", false, websiteID);

            Maintenance.AllowRoutineMaintenance = ConfigSettingGet("Settings.AllowRoutineMaintenance", true, websiteID);
            Maintenance.CreateXMLImageFiles = ConfigSettingGet("Settings.CreateXMLImageFiles", false, websiteID);

            #endregion Maintenance Options

            #region Languages

            // indicates wether the change language/currency bar is visible or not
            Languages.Active = ConfigSettingGet("SITE.LANGUAGES", false, websiteID);

            Languages.ForceInitialDefaultLanguage = ConfigSettingGet("SITE.FORCEINITIAL.LANGUAGE", false, websiteID);

            Languages.UseCustomPages = ConfigSettingGet("Settings.CustomPages", true, websiteID);

            Languages.WebsiteCulture = new CultureInfo(ConfigSettingGet("Settings.WebsiteCulture", "en-GB", websiteID));

            BOL.Countries.Country defCountry = BOL.Countries.Countries.Get(ConfigSettingGet("Settings.DefaultCountry", "GB", websiteID));

            if (defCountry == null)
                Languages.DefaultCountrySettings = "GB";
            else
                Languages.DefaultCountrySettings = defCountry.CountryCode;

            DAL.DALHelper.CultureOverride = ConfigSettingGet("Settings.CultureOverride", "en-GB", websiteID);

            #endregion Languages

            #region Trade Customers

            TradeCustomers.ShowTradeDownloads = ConfigSettingGet("Settings.UserMenuTradeDownloads", true, websiteID);

            #endregion Trade Customers

            #region Memberer Menu Items

            Members.ShowSalonUpdate = ConfigSettingGet("Settings.UserMenuSalonUpdates", true, websiteID);
            Members.ShowAppointments = ConfigSettingGet("Settings.UserMenuAppointments", true, websiteID);

            #endregion Member Menu Items

            #region Affiliates

            Affiliates.MaximumDays = WebsiteSettings.ConfigSettingGet(StringConsts.AFFILIATE_LIVE_DAYS, 7, websiteID);

            #endregion Affiliates

            #region Carousel

            Carousel.CustomScrollerStrapLine = ConfigSettingGet("Settings.CustomIndexScroller", false, websiteID);
            Carousel.CustomScrollerText = ConfigSettingGet("Settings.CustomScrollerText",
                "Out latest Products", websiteID);

            #endregion Carousel

            #region Geo Update

            GeoIP.AllowWebsiteGeoUpdate = ConfigSettingGet("Settings.GeoIPUpdates", false, websiteID);

            #endregion Geo Update

            DAL.DALHelper.RegisterWebsite(WebsiteSettings.RootURL);
            Result = true;


            return (Result);
        }

        #endregion Configuration Settings

        #endregion Static Methods
    }
}
