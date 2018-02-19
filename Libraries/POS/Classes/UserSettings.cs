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
 *  File: UserSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;


namespace POS.Base.Classes
{
    /// <summary>
    /// Controls application Settings for a user
    /// </summary>
    [Serializable]
    public class UserSettings
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserSettings()
        {
            AutoLogout = false;
            AutoLogoutTimeOut = 5 * 60; //5 minutes default
            AllowBlink = true;
            DefaultUserID = -1;

            ShowDidYouKnowAtStartup = true;

            // order manager
            OrderManagerLinkToStock = false;
            OrderManagerBypassLabel = false;
            OrderManagerOrderPreparedBy = "Your order was prepared by";
            OrderManagerPreparedByAlignment = 0;
            OrderMaximumOpen = 10;

            #region Diary

            //diary appointment colors
            DiaryAppointmentsCache = true;

            DiaryAppointmentRequestedColor = "#0099CC";
            DiaryAppointmentRequestedTextColor = Color.Black.ToArgb().ToString();
            DiaryAppointmentConfirmedColor = "#66FF66";
            DiaryAppointmentConfirmedTextColor = Color.Black.ToArgb().ToString();
            DiaryAppointmentCancelledByUserColor = "#CC0066";
            DiaryAppointmentCancelledByUserTextColor = Color.White.ToArgb().ToString();
            DiaryAppointmentCancelledByStaffColor = "#CC0066";
            DiaryAppointmentCancelledbyStaffTextColor = Color.Black.ToArgb().ToString();
            DiaryAppointmentNoShowColor = "#FF00FF";
            DiaryAppointmentNoShowTextColor = Color.Black.ToArgb().ToString();
            DiaryAppointmentCompletedColor = "#FF9966";
            DiaryAppointmentCompletedTextColor = Color.Black.ToArgb().ToString();
            DiaryAppointmentArrivedColor = "#FF9900";
            DiaryAppointmentArrivedTextColor = Color.Black.ToArgb().ToString();
            DiaryAppointmentDeletedColor = "#000000";
            DiaryAppointmentDeletedTextColor = "#FFFFFF";

            DiaryAppointmentSelectedColor = Color.Aqua.ToArgb().ToString();
            DiaryAppointmentSelectedTextColor = Color.Black.ToArgb().ToString();

            DiaryShowCancelled = false;
            DiaryCalendarStyle = "Blue";
            DiaryWeekStartsOnMonday = true;
            DiaryTeamView = true;
            DiaryShowImageOverlays = true;
            DiaryShowMinutes = true;
            DiaryBirthdayNotification = 14;
            DiaryAppointmentLockTime = 30;
            DiaryAutoCompleteOnPayment = true;
            DiaryScrollAmount = 1;
            DiaryToolTipDelay = 1000;
            DiaryShowNameFirst = true;

            DiaryImageOverlaysHasCancelled = true;
            DiaryImageOverlaysLinked = true;
            DiaryImageOverlaysLocked = true;
            DiaryImageOverlaysNotes = true;
            DiaryImageOverlaysOverridden = true;
            DiaryImageOverlaysNoTreatments = true;
            DiaryAutoHideUsers = String.Empty;
            DiaryMinimumDate = DateTime.Now.AddYears(-1);
            DiaryUseMinimumDate = false;

            DiaryMaximumLunchDuration = 90;

            #endregion Diary

            #region Training Diary

            //training diary
            TrainingDiaryMaximumAttendees = 6;
            TrainingDiaryLeft = 100;
            TrainingDiaryTop = 100;
            TrainingDiaryWidth = 787;
            TrainingDiaryHeight = 403;

            #endregion Training Diary

            #region Currency Watch

            CurrencyBase = "GBP";
            CurrencySelected = "USD";
            CurrencyWatching = "USD;EUR;AUD;DKK";
            CurrencyWatchUpdateMinutes = 30;

            #endregion Currency Watch

            #region Dictionary

            //dictionary
            CustomDictionary = "en_GB.dic";

            CustomCulture = StringConstants.CULTURE_ENGLISH_UK;
            CustomUICulture = StringConstants.CULTURE_ENGLISH_UK;

            #endregion Dictionary

            #region Invoices / Orders

            InvoiceHeaderRight = String.Empty;

            //invoice / orders
            InvoiceHeader = "InvoiceHeader.jpg";
            InvoiceVATRegistrationNumber = String.Empty;

            InvoiceAddress = "";
            InvoiceFooter = String.Empty;
            InvoiceFooterPaid = "Payment Received - Thank You";
            InvoiceFooterInvoiceDue = "Payment due within 3 days of invoice date";
            InvoicePrefix = "WI";
            InvoiceMaximumOpen = 10;

            HideVATOnOrdersAndInvoices = false;
            AllowVATTobeRemoved = true;
            AllowCurrencyToBeConverted = true;
            InvoiceShowProductDiscount = true;
            InvoiceMinimumValueTrackingReference = 0.00m;
            ShippingIsTaxable = true;

            #endregion Invoices / Orders

            //general options
            DefaultCountry = "GB";

            #region Stock Control

            //stock control
            StockHistoryLeft = 100;
            StockHistoryTop = 100;
            StockHistoryShowInternet = true;
            StockItemsHidden = StringConstants.SYMBOL_SEMI_COLON;
            StockLevelLow = 15;

            StockColorVeryLow = Color.Red.ToArgb().ToString();
            StockColorVeryLowSelected = Color.DarkRed.ToArgb().ToString();

            StockColorLow = Color.Orange.ToArgb().ToString();

            StockColorHiddenGloballyBack = Color.Red.ToArgb().ToString();
            StockColorHiddenGloballyFore = Color.White.ToArgb().ToString();

            StockColorHiddenBack = Color.Black.ToArgb().ToString();
            StockColorHiddenFore = Color.White.ToArgb().ToString();

            StockColorOutOfStockBack = Color.OrangeRed.ToArgb().ToString();
            StockColorOutOfStockFore = Color.White.ToArgb().ToString();

            //StockAutoReorder
            StockAutoReOrderUserEmail = String.Empty;
            StockAutoReOrderUserPassword = String.Empty;

            StockAutoReOrder = false;

            #endregion Stock Control

            #region Marketing Campaigns

            Facebook = "http://www.facebook.com/";
            Twitter = "https://twitter.com/#!/";
            GPlus = "https://plus.google.com/u/0/+";
            RSSFeed = "http://myrss.me/feed/";

            Menu1Name = "gift sets";
            Menu1URL = "/Products.aspx?GroupID=11";

            Menu2Name = "products";
            Menu2URL = "/Products.aspx";

            Menu3Name = "Stratosphere";
            Menu3URL = "/Products.aspx?GroupID=91";

            Menu4Name = "Treatments";
            Menu4URL = "/Treatments.aspx";

            Menu5Name = "Salons";
            Menu5URL = "/Salons.aspx";

            MarketingURL = "";

            UpdateMarketingFilesAtStart = false;

            #endregion Marketing Campaigns

            #region Email Server


            #endregion Email Server

            //scanner / barcodes
            ScannerUsesF11Key = true;


            // credit card requirements
            CreditCardAppointmentMinutes = 45;
            CreditCardHoursCancel = 48;
            CreditCardPercent = 50;


            // product checks
            CarouselChecks = false;
            FeaturedProductCheck = false;
            GiftWrapChecks = false;
            GiftWrapLowest = 1.0m;
            GiftWrapMaximum = 10.0m;


            // cash drawer
            CashDrawerForceChecks = false;
            CashDrawerBypassStartOfDay = false;
            CashDrawerMaximumBypassCount = 2;

            // mail chimp
            MailChimpAPI = String.Empty;
            MailChimpFooter = true;


            //Till options
            TillShowButtonImages = true;
            TillShowButtons = true;
            ShowPricesWithoutVAT = true;
            HideOutOfStockProducts = true;
            HideProductsWithZeroStock = true;
            TillShowSummaryBar = true;

            //website options
            ShowWebsiteMenuItem = true;

            //language menu
            ShowLanguageMenu = false;

            TillDefaultUserSystem = false;


            LastBackup = DateTime.Now.AddDays(-10);

            //plugins
            PluginsPromptToLoad = false;
            PluginsLoadNewModules = true;

            //text magic
            TextMagicUsername = String.Empty;
            TextMagicAPI = String.Empty;
            TextMagicSender = String.Empty;


            // staff settings
            LeaveYearStarts = new DateTime(2016, 4, 1);
            LeaveYearEnds = new DateTime(2017, 3, 31);
            LeaveMaximumTakeOnceDays = 21;
            LeaveMaximumTakeOnceHours = 80;
            LeaveAllowBookFuture = 2; // years booked into the future
            LeaveMinimumTakeDays = 0.5; // minimum booking is half day
            LeaveMinimumTakeHours = 4.0;
            LeaveAllowCrossLeaveYears = true;
            LeaveMaxCarryOverHours = 40.0;
            LeaveMaxCarryOverDays = 8.0;


            CommissionOverDueBackColor = Color.Red.ToArgb().ToString();
            CommissionOverDueForeColor = Color.White.ToArgb().ToString();
            CommissionDueSoonBackColor = Color.MidnightBlue.ToArgb().ToString();
            CommissionDueSoonForeColor = Color.White.ToArgb().ToString();
            CommissionSelectedBackColor = Color.DarkSeaGreen.ToArgb().ToString();
            CommissionSelectedForeColor = Color.Magenta.ToArgb().ToString();
            CommissionDueSoonDays = 21;

            #region Affiliates

            AffiliateExternalLinks = true;
            AffiliateURL = String.Empty;

            #endregion Affiliates

            BusinessName = String.Empty;
        }

        #endregion Constructors

        #region Business Details

        /// <summary>
        /// no explanaton necessary
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// no explanaton necessary
        /// </summary>
        public string BusinessAddress { get; set; }

        /// <summary>
        /// no explanaton necessary
        /// </summary>
        public string BusinessTelephone { get; set; }

        /// <summary>
        /// no explanaton necessary
        /// </summary>
        public string BusinessEmail { get; set; }

        /// <summary>
        /// Business Registration No
        /// </summary>
        public string BusinessRegNo { get; set; }

        /// <summary>
        /// VAT / Tax registration number
        /// </summary>
        public string BusinessVatNo { get; set; }

        #endregion Business Details

        #region Email Server

        public string EmailServer { get; set; }

        public string EmailUser { get; set; }

        public string EmailPassword { get; set; }

        public int EmailPort { get; set; }

        public bool EmailSSL { get; set; }

        #endregion Email Server

        #region Accounts

        /// <summary>
        /// Start day/month of an accounting year
        /// </summary>
        public DateTime AccountYearStart { get; set; }

        /// <summary>
        /// End day/month of an accounting year
        /// </summary>
        public DateTime AccountYearEnd { get; set; }

        #endregion Accounts

        #region Affiliates

        public bool AffiliateExternalLinks { get; set; }

        public string AffiliateURL { get; set; }

        #endregion Affiliates

        #region Commission

        public string CommissionOverDueBackColor { get; set; }

        public string CommissionDueSoonBackColor { get; set; }

        public string CommissionOverDueForeColor { get; set; }

        public string CommissionDueSoonForeColor { get; set; }

        public string CommissionSelectedBackColor { get; set; }

        public string CommissionSelectedForeColor { get; set; }

        public int CommissionDueSoonDays { get; set; }

        #endregion Commission

        #region Staff Settings

        #region Holidays

        public DateTime LeaveYearStarts { get; set; }

        public DateTime LeaveYearEnds { get; set; }

        public double LeaveMaximumTakeOnceDays { get; set; }

        public double LeaveMaximumTakeOnceHours { get; set; }

        public int LeaveAllowBookFuture { get; set; } // YEARS that can booked into the future

        public double LeaveMinimumTakeDays { get; set; } // minimum booking is half day

        public double LeaveMinimumTakeHours { get; set; }

        public bool LeaveAllowCrossLeaveYears { get; set; }

        public double LeaveMaxCarryOverHours { get; set; }

        public double LeaveMaxCarryOverDays { get; set; }

        #endregion Holidays

        #region Mileage

        public decimal ExpensesMileageRate1 { get; set; }

        public decimal ExpensesMileageRate2 { get; set; }

        public decimal ExpensesMileageFirstX { get; set; }

        #endregion Mileage

        #endregion Staff Settings

        #region Text Magic

        /// <summary>
        /// Text Magic SMS Sender Details
        /// </summary>
        public string TextMagicUsername { get; set; }

        /// <summary>
        /// Text Magic API Number
        /// </summary>
        public string TextMagicAPI { get; set; }

        /// <summary>
        /// Sender name for text magic
        /// </summary>
        public string TextMagicSender { get; set; }

        #endregion Text Magic

        #region Backup

        public DateTime LastBackup;

        #endregion Backup

        #region Currency Watch

        /// <summary>
        /// Base currency used when obtaining conversion rates
        /// </summary>
        public string CurrencyBase { get; set; }

        /// <summary>
        /// Selected currency used in toolbar for conversion
        /// </summary>
        public string CurrencySelected { get; set; }

        /// <summary>
        /// Currencies being actively watched
        /// </summary>
        public string CurrencyWatching { get; set; }

        /// <summary>
        /// Number of minutes between updates of main conversion file
        /// </summary>
        public int CurrencyWatchUpdateMinutes { get; set; }

        #endregion Currency Watch

        #region Plugins

        /// <summary>
        /// Check for new plugins when updating 
        /// </summary>
        public bool PluginsLoadNewModules { get; set; }

        /// <summary>
        /// Determines wether a prompt to load plugins is made, if new
        /// plugins are found, if false all plugins are loaded automatically
        /// </summary>
        public bool PluginsPromptToLoad { get; set; }

        #endregion Plugins

        #region Language

        public bool ShowLanguageMenu { get; set; }

        #endregion Language

        #region Website Options

        public bool ShowWebsiteMenuItem { get; set; }

        #endregion Website Options

        #region Till

        /// <summary>
        /// Show/Hide Summary Status Strip on Till
        /// </summary>
        public bool TillShowSummaryBar { get; set; }

        /// <summary>
        /// Shows prices within till and create order without VAT
        /// </summary>
        public bool ShowPricesWithoutVAT { get; set; }

        /// <summary>
        /// Hides any item from till and create order where stock level is zero
        /// </summary>
        public bool HideProductsWithZeroStock { get; set; }

        /// <summary>
        /// Hides items from create order and till where they are marked as out of stock
        /// </summary>
        public bool HideOutOfStockProducts { get; set; }

        /// <summary>
        /// Determines wether buttons or a list is shown for products in the till
        /// </summary>
        public bool TillShowButtons { get; set; }

        /// <summary>
        /// Determines wether images are shown on buttons or not
        /// </summary>
        public bool TillShowButtonImages { get; set; }

        /// <summary>
        /// Determines wether items added to till are defaulted to system user
        /// </summary>
        public bool TillDefaultUserSystem { get; set; }

        #endregion Till

        #region Mail Chimp Integration

        /// <summary>
        /// Mail Chimp API for integrated campaigns
        /// </summary>
        public string MailChimpAPI { get; set; }

        /// <summary>
        /// Determines wether MAilChimp automatically adds a footer
        /// </summary>
        public bool MailChimpFooter { get; set; }

        #endregion Mail Chimp Integration

        #region Cash Drawer

        /// <summary>
        /// Indicates wether Cash Drawer Checks are forced or not
        /// </summary>
        public bool CashDrawerForceChecks { get; set; }

        /// <summary>
        /// Indicates wether a user HAS to do start of day cash drawer checks or not
        /// </summary>
        public bool CashDrawerBypassStartOfDay { get; set; }

        /// <summary>
        /// Maximum number of times a user can bypass cash drawer checks
        /// </summary>
        public int CashDrawerMaximumBypassCount { get; set; }

        #endregion Cash Drawer

        #region Product Checks

        /// <summary>
        /// Indicates wether carousel checks are conducted
        /// </summary>
        public bool CarouselChecks { get; set; }

        public bool FeaturedProductCheck { get; set; }
        public bool GiftWrapChecks { get; set; }
        public decimal GiftWrapLowest { get; set; }
        public decimal GiftWrapMaximum { get; set; }

        #endregion Product Checks

        #region Credit Card Requirements

        public int CreditCardAppointmentMinutes { get; set; }
        public int CreditCardHoursCancel { get; set; }
        public int CreditCardPercent { get; set; }

        #endregion Credit Card Requirements

        #region Barcodes

        //Indicates that the F11 key can also be used to initiate barcode scan
        public bool ScannerUsesF11Key { get; set; }


        #endregion Barcodes

        #region Marketing

        /// <summary>
        /// Indicates wether marketing files should be updated when the application starts
        /// </summary>
        public bool UpdateMarketingFilesAtStart { get; set; }

        /// <summary>
        /// Base URL for website
        /// </summary>
        public string MarketingURL { get; set; }

        #endregion Marketing

        #region Menu Names

        /// <summary>
        /// Name for Menu 1
        /// </summary>
        public string Menu1Name { get; set; }

        /// <summary>
        /// URL for Menu 1
        /// </summary>
        public string Menu1URL { get; set; }

        /// <summary>
        /// Name for Menu 2
        /// </summary>
        public string Menu2Name { get; set; }

        /// <summary>
        /// URL for Menu 2
        /// </summary>
        public string Menu2URL { get; set; }

        /// <summary>
        /// Name for Menu 3
        /// </summary>
        public string Menu3Name { get; set; }

        /// <summary>
        /// URL for Menu 3
        /// </summary>
        public string Menu3URL { get; set; }

        /// <summary>
        /// Name for Menu 4
        /// </summary>
        public string Menu4Name { get; set; }

        /// <summary>
        /// URL for Menu 4
        /// </summary>
        public string Menu4URL { get; set; }

        /// <summary>
        /// Name for Menu 5
        /// </summary>
        public string Menu5Name { get; set; }

        /// <summary>
        /// URL for Menu 5
        /// </summary>
        public string Menu5URL { get; set; }

        #endregion Menu Names

        #region Social Media

        /// <summary>
        /// 
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Twitter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GPlus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RSSFeed { get; set; }

        #endregion Social Media

        #region Custom Colors

        /// <summary>
        /// Custom colors used by the user
        /// </summary>
        public int[] CustomColors { get; set; }

        #endregion Custom Colors

        #region Properties

        #region Order Manager

        /// <summary>
        /// Allows users to bypass the label printing
        /// </summary>
        public bool OrderManagerBypassLabel { get; set; }

        /// <summary>
        /// If true, prevents stock being dispatched, when there is none
        /// </summary>
        public bool OrderManagerLinkToStock { get; set; }

        /// <summary>
        /// Text to be appended to an invoice if printed via the order manager
        /// </summary>
        public string OrderManagerOrderPreparedBy { get; set; }

        /// <summary>
        /// Alignment for order manager prepared by text
        /// </summary>
        public int OrderManagerPreparedByAlignment { get; set; }

        /// <summary>
        /// Maximum number of open orders
        /// </summary>
        public int OrderMaximumOpen { get; set; }

        #endregion Order Manager

        #region Stock Control

        /// <summary>
        /// List of hidden stock items
        /// </summary>
        public string StockItemsHidden { get; set; }

        #region Stock History

        /// <summary>
        /// Left position of the stock history form
        /// </summary>
        public int StockHistoryLeft { get; set; }

        /// <summary>
        /// Top position of the stock history form
        /// </summary>
        public int StockHistoryTop { get; set; }

        /// <summary>
        /// Determines wether Internet Sales are shown or not
        /// </summary>
        public bool StockHistoryShowInternet { get; set; }

        /// <summary>
        /// Value which indicates stock is low
        /// </summary>
        public int StockLevelLow { get; set; }

        /// <summary>
        /// Color for low/out of stock (below min level)
        /// </summary>
        public string StockColorVeryLow  { get; set; }

        /// <summary>
        /// Selected color for low/out of stock (below min level)
        /// </summary>
        public string StockColorVeryLowSelected { get; set; }

        /// <summary>
        /// Colour for low stock
        /// </summary>
        public string StockColorLow { get; set; }

        /// <summary>
        /// back color for globally hidden item
        /// </summary>
        public string StockColorHiddenGloballyBack { get; set; }

        /// <summary>
        /// fore color for globally hidden items
        /// </summary>
        public string StockColorHiddenGloballyFore { get; set; }

        /// <summary>
        /// back color for locally hidden items
        /// </summary>
        public string StockColorHiddenBack { get; set; }
            
        /// <summary>
        /// fore color for locally hidden items
        /// </summary>
        public string StockColorHiddenFore { get; set; }

        /// <summary>
        /// back color for out of stock items
        /// </summary>
        public string StockColorOutOfStockBack { get; set; }

        /// <summary>
        /// fore color for out of stock items
        /// </summary>
        public string StockColorOutOfStockFore { get; set; }

        #endregion Stock History

        /// <summary>
        /// Email used for auto reorder
        /// </summary>
        public string StockAutoReOrderUserEmail { get; set; }

        /// <summary>
        /// Password for user for auto re-order
        /// </summary>
        public string StockAutoReOrderUserPassword { get; set; }

        /// <summary>
        /// Is stock auto reorder enabled or not?
        /// </summary>
        public bool StockAutoReOrder { get; set; }

        #endregion Stock Control

        #region General Settings

        /// <summary>
        /// Default country setting for shopping basket within pos
        /// </summary>
        public string DefaultCountry { get; set; }

        #endregion General Settings

        #region Invoice / Orders

        /// <summary>
        /// Minimum Value in which a tracking reference is required
        /// </summary>
        public decimal InvoiceMinimumValueTrackingReference { get; set; }

        /// <summary>
        /// Determines wether product discount value is shown on invoices/orders
        /// </summary>
        public bool InvoiceShowProductDiscount { get; set; }

        /// <summary>
        /// Allows monetary values to be converted to other values
        /// </summary>
        public bool AllowCurrencyToBeConverted { get; set; }

        /// <summary>
        /// Allows VAT rate to be removed from monetary values
        /// </summary>
        public bool AllowVATTobeRemoved { get; set; }

        /// <summary>
        /// Determines wether VAT is shown/hidded on invoices
        /// </summary>
        public bool HideVATOnOrdersAndInvoices { get; set; }

        /// <summary>
        /// If true shipping costs are taxable
        /// </summary>
        public bool ShippingIsTaxable { get; set; }

        /// <summary>
        /// Image used for invoice header
        /// </summary>
        public string InvoiceHeader { get; set; }

        /// <summary>
        /// Image used for invoice header
        /// </summary>
        public string InvoiceHeaderRight { get; set; }

        /// <summary>
        /// Footer displayed at bottom of invoice
        /// </summary>
        public string InvoiceFooter { get; set; }

        /// <summary>
        /// Footer text for paid invoice
        /// </summary>
        public string InvoiceFooterPaid { get; set; }

        /// <summary>
        /// Footer for when payment is due
        /// </summary>
        public string InvoiceFooterInvoiceDue { get; set; }

        /// <summary>
        /// Invoice Prefix
        /// </summary>
        public string InvoicePrefix { get; set; }

        /// <summary>
        /// Maximum number of open invoices
        /// </summary>
        public int InvoiceMaximumOpen { get; set; }

        /// <summary>
        /// Vat registration number
        /// </summary>
        public string InvoiceVATRegistrationNumber { get; set; }

        /// <summary>
        /// Invoice Address
        /// </summary>
        public string InvoiceAddress { get; set; }

        #endregion Invoice / Orders

        #region Cultures

        /// <summary>
        /// User defined culture
        /// </summary>
        public string CustomCulture { get; set; }


        /// <summary>
        /// Current UI Culture
        /// </summary>
        public string CustomUICulture { get; set; }

        #endregion Cultures

        #region Dictionary

        /// <summary>
        /// Users custom dictionary
        /// </summary>
        public string CustomDictionary { get; set; }

        #endregion Dictionary

        #region Training Diary

        /// <summary>
        /// Maximum Number of Attendees for a Course
        /// </summary>
        public int TrainingDiaryMaximumAttendees { get; set;}

        /// <summary>
        /// Training Diary Top Position
        /// </summary>
        public int TrainingDiaryTop { get; set; }

        /// <summary>
        /// Training Diary Left Position
        /// </summary>
        public int TrainingDiaryLeft { get; set; }

        /// <summary>
        /// Training Diary Width
        /// </summary>
        public int TrainingDiaryWidth { get; set; }

        /// <summary>
        /// Training Diary Height
        /// </summary>
        public int TrainingDiaryHeight { get; set; }


        #endregion Training Diary

        #region Default Login

        /// <summary>
        /// Default logon user id
        /// </summary>
        public Int64 DefaultUserID
        {
            get;
            set;
        }

        /// <summary>
        /// Default logon user password
        /// </summary>
        public string DefaultUserPassword
        {
            get;
            set;
        }

        /// <summary>
        /// Default logon username
        /// </summary>
        public string DefaultUserName
        {
            get;
            set;
        }

        #endregion Default Login

        #region Main Form

        /// <summary>
        /// Main Form items flash red if there are any
        /// </summary>
        public bool AllowBlink { get; set; }

        /// <summary>
        /// Determines wether the Did You Know dialog is shown when the application starts
        /// </summary>
        public bool ShowDidYouKnowAtStartup { get; set; }

        /// <summary>
        /// Displays the latest pos version
        /// </summary>
        public string LastVersion { get; set; }

        /// <summary>
        /// Determines if a new version of the POS has been found
        /// </summary>
        /// <returns>Returns true if a new version is loaded, otherwise false</returns>
        public bool VersionChanged(string currentVersion)
        {
            if (LastVersion == currentVersion)
                return (false);
            else
            {
                LastVersion = currentVersion;
                return (true);
            }
        }

        /// <summary>
        /// Determines wethe auto logout is set or not
        /// </summary>
        public bool AutoLogout { get; set; }

        /// <summary>
        /// Length of time in seconds before autologout
        /// </summary>
        public uint AutoLogoutTimeOut { get; set; }

        #endregion Main Form

        #region Calendar

        /// <summary>
        /// Determines wether the Diary caches appointments or not
        /// </summary>
        public bool DiaryAppointmentsCache { get; set; }

        /// <summary>
        /// Tooltip Delay
        /// </summary>
        public int DiaryToolTipDelay { get; set; }

        /// <summary>
        /// Specifies the maximum allowed duration for a lunch break
        /// </summary>
        public int DiaryMaximumLunchDuration { get; set; }

        /// <summary>
        /// Specifies which employees to view within the diary
        /// </summary>
        public string DiaryViewEmployees { get; set; }

        public bool DiaryViewEmployee(string employeeName)
        {
            bool Result = false;

            if (String.IsNullOrEmpty(employeeName))
                return (Result);

            if (String.IsNullOrEmpty(DiaryViewEmployees))
                return (Result);

            string[] employee = DiaryViewEmployees.Split('$');

            foreach (string emp in employee)
            {
                if (emp.StartsWith(employeeName))
                {
                    string[] values = emp.Split('=');
                    Result = bool.TryParse(values[1], out Result);
                    break;
                }
            }

            return (Result);
        }

        public bool DiaryWeekStartsOnMonday { get; set; }

        public bool DiaryTeamView { get; set; }

        public int DiaryBirthdayNotification { get; set; }

        public int DiaryAppointmentLockTime { get; set; }

        public DateTime DiaryMinimumDate { get; set; }

        /// <summary>
        /// By default the date from DiaryMinimumDate is used if true, if false 1 month max age for appointments
        /// </summary>
        public bool DiaryUseMinimumDate { get; set; }

        public bool DiaryIgnoreworkingHours { get; set; }

        public bool DiaryShowCancelled { get; set; }

        public string DiaryCalendarStyle { get; set; }
                
        public bool DiaryMultiView { get; set; }

        public bool DiaryMondayStartsWeek { get; set; }

        public bool DiaryShowImageOverlays { get; set; }

        public bool DiaryShowMinutes { get; set; }

        public int DiaryToolBarOptions_X { get; set; }

        public int DiaryToolBarOptions_Y { get; set; }

        public int DiaryToolBarSettings_X { get; set; }

        public int DiaryToolBarSettings_Y { get; set; }

        public int DiaryBirthdayAlert { get; set; }

        public int DiaryAutoLock { get; set; }

        public bool DiaryAutoCompleteOnPayment { get; set; }

        public int DiaryScrollAmount { get; set; }

        public bool DiaryOverlayCancelled { get; set; }

        public bool DiaryOverlayLinkedAppoitnment { get; set; }

        public bool DiaryOverlayLockedAppointment { get; set; }

        public bool DiaryOverlayUserNotes { get; set; }

        public bool DiaryOverlayOverriddenHours { get; set; }

        public bool DiaryOverlayNoTreatments { get; set; }

        public string DiaryAutoHideUsers { get; set; }

        public bool DiaryImageOverlaysHasCancelled { get; set; }

        public bool DiaryImageOverlaysLinked { get; set; }

        public bool DiaryImageOverlaysLocked { get; set; }

        public bool DiaryImageOverlaysNotes { get; set; }

        public bool DiaryImageOverlaysOverridden { get; set; }

        public bool DiaryImageOverlaysNoTreatments { get; set; }

        public bool DiaryShowNameFirst { get; set; }

        #endregion Calendar

        #region Diary Appointment Colors

        public string DiaryAppointmentSelectedColor { get; set; }

        public string DiaryAppointmentSelectedTextColor { get; set; }

        public string DiaryAppointmentRequestedColor { get; set; }

        public string DiaryAppointmentRequestedTextColor { get; set; }

        public string DiaryAppointmentConfirmedColor { get; set; }

        public string DiaryAppointmentConfirmedTextColor { get; set; }

        public string DiaryAppointmentCancelledByUserColor { get; set; }

        public string DiaryAppointmentCancelledByUserTextColor { get; set; }

        public string DiaryAppointmentCancelledByStaffColor { get; set; }

        public string DiaryAppointmentCancelledbyStaffTextColor { get; set; }

        public string DiaryAppointmentNoShowColor { get; set; }

        public string DiaryAppointmentNoShowTextColor { get; set; }

        public string DiaryAppointmentCompletedColor { get; set; }

        public string DiaryAppointmentCompletedTextColor { get; set; }

        public string DiaryAppointmentArrivedColor { get; set; }

        public string DiaryAppointmentArrivedTextColor { get; set; }

        public string DiaryAppointmentDeletedColor { get; set; }

        public string DiaryAppointmentDeletedTextColor { get; set; }

        #endregion Diary Appointment Colors

        #region Stock Reports

        /// <summary>
        /// Left position for stock form
        /// </summary>
        public int StockSearchFormLeft { get; set; }

        /// <summary>
        /// Top position for stock form
        /// </summary>
        public int StockSearchFormTop { get; set; }

        /// <summary>
        /// Index of stock location
        /// </summary>
        public int StockSearchFormLocation { get; set; }

        /// <summary>
        /// Index of stock type
        /// </summary>
        public int StockSearchFormType { get; set; }

        /// <summary>
        /// Index of stock options
        /// </summary>
        public int StockSearchFormOptions { get; set; }

        #endregion Stock Reports

        #region Stock Forms

        /// <summary>
        /// Index of main stock from location
        /// </summary>
        public int StockMainFormLocation { get; set; }

        /// <summary>
        /// Index of main stock form type
        /// </summary>
        public int StockMainFormType { get; set; }


        #endregion StockForms

        #endregion Properties

        #region Static Methods

        /// <summary>
        /// Loads user settings
        /// </summary>
        /// <returns></returns>
        public static UserSettings LoadSettings()
        {
            UserSettings Result = null;

            String path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + 
                StringConstants.FILE_USER_SETTINGS_CONFIG;

            if (File.Exists(path))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));

                    StreamReader reader = new StreamReader(path);
                    try
                    {
                        Result = (UserSettings)serializer.Deserialize(reader);
                    }
                    finally
                    {
                        reader.Close();
                        reader.Dispose();
                        reader = null;
                    }
                }
                catch
                {
                    Result = new UserSettings();
                }
            }
            else
            {
                Result = new UserSettings();
            }


            // fix a bug

            if (String.IsNullOrEmpty(Result.StockColorVeryLow))
                Result.StockColorVeryLow = Color.Red.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorVeryLowSelected))
                Result.StockColorVeryLowSelected = Color.DarkRed.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorLow))
                Result.StockColorLow = Color.Orange.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorHiddenGloballyBack))
                Result.StockColorHiddenGloballyBack = Color.Red.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorHiddenGloballyFore))
                Result.StockColorHiddenGloballyFore = Color.White.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorHiddenBack))
                Result.StockColorHiddenBack = Color.Black.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorHiddenFore))
                Result.StockColorHiddenFore = Color.White.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorOutOfStockBack))
                Result.StockColorOutOfStockBack = Color.OrangeRed.ToArgb().ToString();

            if (String.IsNullOrEmpty(Result.StockColorOutOfStockFore))
                Result.StockColorOutOfStockFore = Color.White.ToArgb().ToString();

            return (Result);
        }

        /// <summary>
        /// Saves user settings
        /// </summary>
        /// <param name="settings">settings to be saved</param>
        public static void SaveSettings(UserSettings settings)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + 
                StringConstants.FILE_USER_SETTINGS_CONFIG;

            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));

            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, settings);
            }
        }

        #endregion Static Methods
    }
}
