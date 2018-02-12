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
using System;
using System.Globalization;

using Shared.Classes;


namespace Library.BOL.Websites
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

            private static MutexEx _mutex = null;

            #endregion Private Members

            #region Properties

            public static bool IsWebFarm { get; set; }

            public static string WebFarmMasterIP { get; set; }

            public static string WebFarmMutexName { get; set; }

            #endregion Properties

            #region Public Methods

            public static bool WebFarmMaster()
            {
                if (!IsWebFarm || _mutex == null)
                    return (true);

                if (_mutex.Exists && _mutex.MutexCreated)
                    return (true);

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

                    _mutex = new MutexEx(WebFarmMutexName);

                    if (!_mutex.Exists)
                    {
                        _mutex.CreateMutex();
                    }

                    Shared.EventLog.Add(String.Format("Process ID: {0}; Created: {1}; Name: {2}",
                        System.Diagnostics.Process.GetCurrentProcess().Id, _mutex.MutexCreated, _mutex.Name));
                }
            }

            public static void Close()
            {
                if (_mutex != null)
                    _mutex.Dispose();
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
    }
}
