using System;
using System.Collections.Generic;

using lib = Library;

namespace Website.Library.Classes
{
    public class WebsiteSettings
    {
        #region Virtual Methods

        public virtual void WebSiteOptions(string parentName, WebsiteOptions options)
        {
            switch (parentName)
            {
                case "General Settings":
                    options.AddOption("Default Page Title", BaseWebApplication.PageTitle, 
                        "Default title for pages where the title is not set", "Settings.DefaultTitle");
                    options.AddOption("Root Path", BaseWebApplication.RootPath, "Path of website on server", "Settings.RootPath");
                    options.AddOption("Root URL", BaseWebApplication.RootURL, "Root URL of website", "Settings.RootURL");
                    options.AddOption("Path", BaseWebApplication.Path, "Physical Path of website", "Settings.Path", 400);
                    options.AddOption("Website Culture Override", BaseWebApplication.WebsiteCultureOverride,
                        "if ticked the default culture (above) will always be used for language selection",
                        "Settings.WebCultureOverride");
                    options.AddOption("Basket Name", Website.Library.GlobalClass.BasketName, 
                        "Name of shopping basket", "Settings.ShoppingBasketName");
                    options.AddOption("Website Date Format", Website.Library.GlobalClass.WebsiteDateFormat, 
                        "Date format used on website", "Settings.WebsiteDateFormat", 150);
                    options.AddOption("Distributor Website", BaseWebApplication.DistributorWebsite, 
                        "Website for distributor", "Settings.DistributorWebsite");
                    options.AddOption("Use Left To Right", BaseWebApplication.UseLeftToRight, 
                        "Determines wether text is shown teft to right or right to left", "Settings.UseLeftToRight");
                    options.AddOption("Use HTTPS", BaseWebApplication.UseHTTPS, 
                        "Determines wether the website uses https or not", "Settings.UseHTTPS");
                    options.AddOption("Style Sheet", Website.Library.GlobalClass.StyleSheet, 
                        "Current style sheet used by the website.", "SITE.STYLE_SHEET");

                    break;

                case "Pages":
                    options.AddHeader("Pages");
                    options.AddDescription("There are certain pages which can be turned off if they are not used or relevant");

                    options.AddOption("Show Salons Page", GlobalClass.ShowSalonsMenu,
                        "Show Salons page", "Settings.ShowSalons");
                    options.AddOption("Show Salon Finder Page", GlobalClass.ShowSalonFinder,
                        "Show Salon Search on Salon Page", "Settings.ShowSalonFinder");
                    options.AddOption("Show Salon Client Header", GlobalClass.ShowClientHeader,
                        "Show Salon Client Header", "Settings.ShowSalonClientHeader");
                    options.AddOption("Show Salon Header", GlobalClass.ShowSalonHeader,
                        "Show Salon Header", "Settings.ShowSalonHeader");

                    options.AddOption("Show Treatments Page", GlobalClass.ShowTreatmentsMenu,
                        "Show Treatments Page", "Settings.ShowTreatments");
                    options.AddOption("Show Distributors Page", GlobalClass.ShowDistributorsMenu,
                        "Show Distributors Page", "Settings.ShowDistributors");
                    options.AddOption("Show Tips and Tricks Page", GlobalClass.ShowTipsAndTricksMenu,
                        "Show Distributors Page", "Settings.ShowTipsAndTricks");
                    options.AddOption("Show Download Page", GlobalClass.ShowDownloadMenu,
                        "Show Download Page", "Settings.ShowDownloads");

                    options.AddOption("Show Treatments Brochure", GlobalClass.ShowTreatmentsBrochure,
                        "Shows a page with treatments", "Settings.ShowTreatmentBrochure");
                    options.AddOption("Show Terms and Conditions", GlobalClass.ShowTermsAndConditions,
                        "Shows a page with terms and conditions.", "Settings.ShowTermsAndConditions");
                    options.AddOption("Show Privacy Policy", GlobalClass.ShowPrivacyPolicy, 
                        "Shows a page with privacy policy information", "Settings.ShowPrivacyPolicy");
                    options.AddOption("Show Returns Policy", GlobalClass.ShowReturnsPolicy, 
                        "Shows a page with returns policy", "Settings.ShowReturnsPolicy");
                    options.AddOption("Show Trade Page", GlobalClass.ShowTradePage, 
                        "Shows a page with trade data, also includes a form where new clients can sign up",
                        "Settings.ShowTradePage");

                    break;

                case "Menu Items":

                    break;

                case "Email Options":
                    options.AddOption("No Reply Name", BaseWebApplication.NoReplyName, 
                        "No reply email address name", "Settings.NoReplyName");
                    options.AddOption("No Reply Email", BaseWebApplication.NoReplyEmail, 
                        "No reply email address", "Settings.NoReplyEmail");
                    options.AddOption("Support Name", BaseWebApplication.SupportName, 
                        "Support email name", "Settings.SupportName");
                    options.AddOption("Support EMail", BaseWebApplication.SupportEMail, 
                        "Support email address", "Settings.SupportEMail");
                    options.AddOption("SMTP Host", BaseWebApplication.SMTPHost, 
                        "SMTP Host", "Settings.SMTPHost");
                    options.AddOption("SMTP User Name", BaseWebApplication.SMTPUserName, 
                        "SMTP User name", "Settings.SMTPUserName");
                    options.AddOption("SMTP Password", BaseWebApplication.SMTPPassword, 
                        "SMTP Password", "Settings.SMTPPassword", 250, true);
                    options.AddOption("SMTP Use SSL", BaseWebApplication.SMTPUseSSL, 
                        "Indicates wether HTTPS is used when sending emails or not", "Settings.SMTPUseSSL");
                    options.AddOption("Send Emails", BaseWebApplication.SendEmails, 
                        "Determines wether emails are sent or not", "Settings.SendEmail");

                    break;

                case "MailChimp":
                    options.AddOption("MailChimp API", BaseWebApplication.MailChimpAPI, 
                        "MailChimp API for sending new subscriptions", "Settings.MailChimpAPI");
                    options.AddOption("List Name", BaseWebApplication.MailChimpList, 
                        "Name of List for users who Subscribe/Unsubscribe", "Settings.MailChimpList");
                    options.AddDescription("If you have a MailChimp account you can get notifications on " +
                        "Mail Subscriptions/Unsubsriptions.  For security you need to pass aunique key, you " +
                        "can use the randomly generated key below or set your own.");
                    options.AddOption("MailChimp Key", BaseWebApplication.MailChimpKey, 
                        "MailChimp Key", "Settings.MailChimpKey");
                    options.AddDescription(String.Format("<p>The WebHook required for your MailChimp account is:</p>" +
                        "<p>{0}/Members/MailChimp/MailChimpHook.aspx?key={1}", BaseWebApplication.RootURL, 
                        BaseWebApplication.MailChimpKey));
                    options.AddDescription("&nbsp;");
                    options.AddDescription("");
                    options.AddOption("MailChimp Popup", BaseWebApplication.MailChimpPopupDialog, 
                        "Code for MailChimp pop up window, prompting user to sign up", 
                        "Settings.MailChimpPopup", 400, false, false, 8);
                    break;

                case "SunTech Payment Provider":
                    options.AddDescription("Only enable if you have an account with SunTech, if TestMode is enabled " +
                        "it will only be shown for Administrators");

                    break;

                case "BuySafe":
                    options.AddOption("BuySafe Merchant ID", PaymentOptions.PaymentOptionSunTechBuySafe.MerchantID, 
                        "Merchant ID for BuySafe", "Settings.BuySafeMerchantID");
                    options.AddOption("BuySafe Merchant Password", PaymentOptions.PaymentOptionSunTechBuySafe.MerchantPassword, 
                        "Merhcant Password for BuySafe", "Settings.BuySafeMerchantPW", 300, true);
                    options.AddOption("BuySafe TestMode", PaymentOptions.PaymentOptionSunTechBuySafe.TestMode, 
                        "Indicates wether test mode or not", "Settings.BuySafeTestMode");

                    break;

                case "24Payment":
                    options.AddOption("24Payment Merchant ID", PaymentOptions.PaymentOptionSunTech24Payment.MerchantID, 
                        "Merchant ID for BuySafe", "Settings.24PaymentMerchantID");
                    options.AddOption("24Payment Merchant Password", PaymentOptions.PaymentOptionSunTech24Payment.MerchantPassword, 
                        "Merhcant Password for BuySafe", "Settings.24PaymentMerchantPW", 300, true);
                    options.AddOption("24Payment TestMode", PaymentOptions.PaymentOptionSunTech24Payment.TestMode, 
                        "Indicates wether test mode or not", "Settings.24PaymentTestMode");

                    break;

                case "WebATM":
                    options.AddOption("WebATM Merchant ID", PaymentOptions.PaymentOptionSunTechWebATM.MerchantID, 
                        "Merchant ID for BuySafe", "Settings.WebATMMerchantID");
                    options.AddOption("WebATM Merchant Password", PaymentOptions.PaymentOptionSunTechWebATM.MerchantPassword, 
                        "Merhcant Password for BuySafe", "Settings.WebATMMerchantPW", 300, true);
                    options.AddOption("WebATM TestMode", PaymentOptions.PaymentOptionSunTechWebATM.TestMode, 
                        "Indicates wether test mode or not", "Settings.WebATMTestMode");

                    break;

                case "Offer/Voucher Options":
                    options.AddOption("Show Offers", BaseWebApplication.ShowOffers, 
                        "Determines wether offers are shown on the website or not", "Settings.ShowOffers");
                    options.AddOption("Show Voucher", BaseWebApplication.ShowVoucher, 
                        "Determines wether vouchers are shown on the website or not - OBSOLETE", "Settings.ShowVoucher");

                    break;

                case "Paypal Options":
                    options.AddOption("API Username", NVPAPICaller.APIUsername, 
                        "Paypal API Username", "Settings.PaypalAPIUserName");
                    options.AddOption("API Password", NVPAPICaller.APIPassword, 
                        "Paypal API Password", "Settings.PaypalAPIPassword");
                    options.AddOption("API Signature", NVPAPICaller.APISignature, 
                        "Paypal API Signature", "Settings.PaypalAPISignature", 500);
                    options.AddOption("Subject", NVPAPICaller.Subject, 
                        "Paypal API Subject", "Settings.PaypalAPISubject");
                    options.AddOption("BNCode", NVPAPICaller.BNCode, 
                        "Paypal API BN Code", "Settings.PaypalAPIBNCode");
                    options.AddOption("Default Currency", NVPAPICaller.DefaultCurrency, 
                        "Paypal API Currency", "Settings.PaypalAPICurrency", 100);
                    options.AddOption("API Success URL", NVPAPICaller.APISuccessURL, 
                        "URL when payment succesfully made", "Settings.PaypalSuccessURL");
                    options.AddOption(".API Fail URL", NVPAPICaller.APIFailURL, 
                        "URL when payment fails", "Settings.PaypalFailURL");

                    break;

                case "Payflow":
                    options.AddOption("Payflow Test Mode", BaseWebApplication.PayflowTestMode, 
                        "Payflow test mode, if set to true then only staff members and above will " +
                        "see credit card payment pages, if false everyone can see credit card payment pages", 
                        "Settings.PayflowTestMode");
                    options.AddOption("Payflow Partner", BaseWebApplication.PayflowPartner, 
                        "Payflow Partner Name", "Settings.PayflowPartner");
                    options.AddOption("Payflow Vendor", BaseWebApplication.PayflowVendor, 
                        "Payflow Vendor reference", "Settings.PayflowVendor");
                    options.AddOption("Payflow User", BaseWebApplication.PayflowUser, 
                        "Payflow User reference", "Settings.PayflowUser");
                    options.AddOption("Payflow Password", BaseWebApplication.PayflowPassword, 
                        "Payflow password", "Settings.PayflowPassword");

                    break;

                case "Payment Options":
                    options.AddOption("Show Payment Card", BaseWebApplication.ShowPaymentCard, 
                        "Take payments via Payflow card processing", "Settings.ShowPaymentCard");
                    options.AddOption("Show Payment Cheque", BaseWebApplication.ShowPaymentCheque, 
                        "Take payments via cheque", "Settings.ShowPaymentCheque");
                    options.AddOption("Show Payment Paypoint", BaseWebApplication.ShowPaymentPaypoint, 
                        "Take payments via Paypoint", "Settings.ShowPaymentPaypoint");
                    options.AddOption("Show Payment Paypal", BaseWebApplication.ShowPaymentPaypal, 
                        "Take payments via paypal", "Settings.ShowPaymentPaypal");
                    options.AddOption("Show Payment Telephone", BaseWebApplication.ShowPaymentTelephone, 
                        "Take payments over the telephone", "Settings.ShowPaymentTelephone");
                    options.AddOption("Show Payment Cash On Delivery", BaseWebApplication.ShowPaymentCashOnDelivery, 
                        "Take payment via Cash On Delivery", "Settings.ShowPaymentCOD");
                    options.AddOption("Show Payment Direct Bank Transfer", BaseWebApplication.ShowPaymentDirectBankTransfer, 
                        "Take payment via direct bank transfer", "Settings.ShowPaymentDBT");
                    options.AddOption("Show Payment SunTech 24 Payment", BaseWebApplication.ShowPaymentSunTech24Payment, 
                        "Take payment via SunTech 24Payment", "Settings.AllowSunTech24Payment");
                    options.AddOption("Show Payment SunTech Web ATM", BaseWebApplication.ShowPaymentSunTechWebATM, 
                        "Take payment via SunTech WebATM", "Settings.AllowSunTechWebATM");
                    options.AddOption("Show Payment SunTech Buy Safe", BaseWebApplication.ShowPaymentSunTechBuySafe, 
                        "Take payment via SunTech Buy Safe", "Settings.AllowSunTechBuySafe");
                    options.AddOption("Show Payment Test Purchase", BaseWebApplication.ShowPaymentTestPurchase,
                        "Allow test purchases to be completed on the website", "Settings.TestPurchase");

                    break;
                case "Credit Cards":
                    options.AddOption("Allow Credit Cards", BaseWebApplication.AllowCreditCards, 
                        "Allow credit card data to be stored in database", "Settings.AllowCreditCards");
                    options.AddOption("Hide Valid From", BaseWebApplication.CreditCardHideValidFrom, 
                        "Hide's the valid from date from Credit Cards", "Settings.AlwaysHideValidFrom");
                    options.AddOption("Always Show Valid From For UK", BaseWebApplication.CreditCardAlwaysShowValidFromForUK, 
                        "Always show the valid from date for UK visitors", "Settings.AlwaysShowCCForUK");

                    break;

                case "Licences":
                    options.AddOption("Allow Licences", BaseWebApplication.AllowLicences,
                        "Only enable if you sell licenced software on your site", "Settings.AllowLicences");

                    break;

                case "Shopping Basket Options":
                    options.AddOption("Hide Shopping Cart", BaseWebApplication.HideShoppingCart, 
                        "Determines wether the shopping cart is hidden or not", "Settings.HideShoppingCart");
                    options.AddOption("Free Shipping Allow", BaseWebApplication.FreeShippingAllow, 
                        "Determines whether free shipping is allowed or not", "Settings.FreeShippingAllow");
                    options.AddOption("Free Shipping Amount", BaseWebApplication.FreeShippingAmount, 
                        "Minimum spend before free shipping is allowed", "Settings.FreeShippingSpend");
                    options.AddOption("Override Cost Multiplier", lib.DAL.DALHelper.OverrideCostMultiplier, 
                        "Determines wether a cost multiplier is applied globally", "Settings.OverrideCostMultiplier");
                    options.AddOption("Override Cost Multiplier Value", lib.DAL.DALHelper.OverrideCostMultiplierValue, 
                        "The cost multiplier value, i.e. 0.3 will make all products 30% cheaper", 
                        "Settings.OverrideCostMultiplierValue");
                    options.AddOption("Maximum Item Quantity", BaseWebApplication.MaximumItemQuantity, 
                        "Maximum number of items a user can add to their shopping basket.", "Settings.MaximumItemQuantity", 3, 1, 500);
                    options.AddOption("Jump To Basket After Add Item", BaseWebApplication.JumpToBasketAfterAddItem, 
                        "If true then after each item is added to a basket the user will be redirected to the basket.", 
                        "Settings.JumpToBasketAfterAddItem");
                    options.AddOption("Alter Text Color Based On Basket Contents",
                        BaseWebApplication.AlterTextColorBasedOnBasketContents, "Alter \"Add to Bag\" text color depending " +
                        "on wether the item is in the basket or not.", "Settings.AlterTextColorBasedOnBasketContents");
                    options.AddOption("Item Does Not Exists In Shopping Bag Text Colour", 
                        BaseWebApplication.ItemDoesNotExistsInShoppingBagTextColour, 
                        "Text color of \"Add to Bag\" button if an item is not in the users shopping basket.<br />" +
                        "<br />AlterTextColorBasedOnBasketContents must be true for this to take effect.", 
                        "Settings.ItemDoesNotExistsInShoppingBagTextColour", 150);
                    options.AddOption("Item Exists In Shopping Bag Text Colour", BaseWebApplication.ItemExistsInShoppingBagTextColour, 
                        "Text color of \"Add to Bag\" button if an item is in the users shopping basket.<br /><br />" +
                        "AlterTextColorBasedOnBasketContents must be true for this to take effect.", 
                        "Settings.ItemExistsInShoppingBagTextColour", 150);
                    options.AddOption("Culture Override", lib.DAL.DALHelper.CultureOverride, 
                        "Culture to be used if overridden", "Settings.CultureOverride", 100);
                    options.AddOption("Show Price Data", BaseWebApplication.DefaultShowPrices, 
                        "Default action if showing price data can not be determined from the country, if checked " +
                        "then default will show prices, if not checked default is to hide prices", "Settings.ShowPriceDefault");
                    options.AddOption("ClearBasketOnPayment", BaseWebApplication.ClearBasketOnPayment, 
                        "If true then the basket will be emptied when payment is confirmed, if false then basket " +
                        "will be emptied when order created (default)", "Settings.ClearBasketOnPayment", true);
                    break;

                case "Shopping Basket Currencies":
                    options.AddDescription("<p>Each payment provide can now accept 1 or more currency codes, you can add multiple currency codes by seperating them with a semi colon</p>" +
                        "<p>For example a valid value could be:  GBP;USD;EUR<br /><br />If you wish this payment provider to use that currency</p>" +
                        "<P>PLEASE NOTE, YOU MUST HAVE THE CURRENCY ENABLED WITHIN THE ADMIN SECTION OF THAT PAYMENT PROVIDER FOR IT TO WORK</p>" +
                        "<p>Valid codes are:</p>" +
                        "<p><table border=0><tr><td>Country</td><td>Currency Code</td></tr><tr><td>Australian Dollar</td><td>AUD</td></tr>" +
                        "<tr><td>Canadian Dollar</td><td>CAD</td></tr><tr><td>Czech Koruna</td><td>CZK</td></tr><tr>" +
                        "<td>Danish Krone</td><td>DKK</td></tr><tr><td>Euro</td><td>EUR</td></tr><tr><td>Hong Kong Dollar</td><td>HKD</td></tr>" +
                        "<tr><td>Hungarian Forint</td><td>HUF</td></tr><tr><td>Japanese Yen</td><td>JPY</td></tr>" +
                        "<tr><td>Norwegian Krone</td><td>NOK</td></tr><tr><td>New Zealand Dollar</td><td>NZD</td></tr>" +
                        "<tr><td>Polish Zloty</td><td>PLN</td></tr><tr><td>Pound Sterling</td><td>GBP</td></tr>" +
                        "<tr><td>Singapore Dollar</td><td>SGD</td></tr><tr><td>Swedish Krona</td><td>SEK</td></tr>" +
                        "<tr><td>Swiss Franc</td><td>CHF</td></tr><tr><td>U.S. Dollar</td><td>USD</td></tr></table></p>");
                    options.AddOption("Paypal Currencies", NVPAPICaller.DefaultCurrency, 
                        "Accepted paypal currencies, ensure paypal is configured to accept them first", "Settings.PaypalAPICurrency");
                    options.AddOption("Payflow Currencies", BaseWebApplication.PayflowCurrencies, 
                        "Valid Payflow currencies, ensure Paypal is configured to accept them", "Settings.PayflowCurrencies");
                    options.AddOption("Phone Currencies", BaseWebApplication.PhoneCurrencies, 
                        "Valid currencies that can be accepted over the telephone", "Settings.PhoneCurrency");
                    options.AddOption("Cash On Delivery", BaseWebApplication.CashOnDeliveryCurrency, 
                        "Valid currencies that can be accepted with Cash on Delivery", "Settings.CODCurrency");
                    options.AddOption("Cheque Currency", BaseWebApplication.ChequeCurrency, 
                        "Valid currencies that can be accepted via cheque", "Settings.ChequeCurrency");
                    options.AddOption("Direct Transfer", BaseWebApplication.DirectTransferCurrency, 
                        "Valid currencies that can be accepted via direct transfer", "Settings.DTCurrency");
                    options.AddOption("Paynet", Website.Library.Classes.Paypoint.ValCard.Currencies, 
                        "Valid currencies accepted by Paynet", "Settings.PaynetCurrency");
                    options.AddOption("BuySafe Currencies", 
                        Classes.PaymentOptions.PaymentOptionSunTechBuySafe.SupportedCurrencies, 
                        "Supported Currencies, i.e. GBP;USD", "Settings.BuySafeCurrencies");
                    options.AddOption("24Payment Currencies", 
                        Classes.PaymentOptions.PaymentOptionSunTech24Payment.SupportedCurrencies, 
                        "Supported Currencies, i.e. GBP;USD", "Settings.24PaymentCurrencies");
                    options.AddOption("WebATM Currencies", 
                        Classes.PaymentOptions.PaymentOptionSunTechWebATM.SupportedCurrencies, 
                        "Supported Currencies, i.e. GBP;USD", "Settings.WebATMCurrencies");
                    options.AddOption("Test Purchase Currencies",
                        Classes.PaymentOptions.PaymentOptionTestPurchase.SupportedCurrencies, 
                        "Supported Currencies i.e. GBP;USD", "Settings.TestPurchaseCurrencies");

                    break;

                case "VAT/Tax Options":
                    options.AddOption("Vat Rate", BaseWebApplication.VatRate, "VAT/Tax rate applied to the sales on the website", 
                        "Settings.VatRate");
                    options.AddOption("Hide VAT On Website And Invoices", lib.DAL.DALHelper.HideVATOnWebsiteAndInvoices, 
                        "Determines wether VAT/Tax is shown in the basket and on Invoices/Orders", 
                        "Settings.HideVATOnWebsiteAndInvoices");
                    options.AddOption("Shipping Is Taxable", BaseWebApplication.ShippingIsTaxable,
                        "If ticked, tax is added to shipping costs, if false, no tax is added to shipping costs",
                        "Settings.ShippingIsTaxable");
                    options.AddOption("Prices Include VAT", BaseWebApplication.PricesIncludeVAT, 
                        "If ticked, then the prices shown on the website will have VAT included", "Settings.PricesIncludeVAT");
                    options.AddDescription("The following two settings also affect the display of " +
                        "invoices/orders within the members area and on reports");
                    options.AddOption("Show Basket Items With VAT", BaseWebApplication.ShowBasketItemsWithVAT, 
                        "If ticked items within the shopping basket will have VAT/TAX added to them, if not ticked " +
                        "then only the price without VAT/TAX will be shown.", "Settings.ShowBasketItemsWithVAT");
                    options.AddOption("Show Basket SubTotal With VAT", BaseWebApplication.ShowBasketSubTotalWithVAT, 
                        "if ticked the subtotal in the basket will have VAT/TAX added, if not ticked the VAT/TAX will be removed.", 
                        "Settings.ShowBasketSubTotalWithVAT");
                    break;

                case "Social Media Options":
                    options.AddDescription("If any of the following values are blank then the option icon will be hidden");
                    options.AddOption("Facebook", BaseWebApplication.SocialMediaFacebook, 
                        "Facebook link on page header", "Settings.Facebook");
                    options.AddOption("Twitter", BaseWebApplication.SocialMediaTwitter, 
                        "Twitter link on page header", "Settings.Twitter");
                    options.AddOption("GPlus", BaseWebApplication.SocialMediaGPlus, 
                        "GPlus link on page header", "Settings.GPlus");
                    options.AddOption("RSS Feed", BaseWebApplication.SocialMediaRSSFeed, 
                        "RSS feed link on page header", "Settings.RSSFeed");
                    options.AddOption("Default Twitter Tags", BaseWebApplication.TwitterDefaultTags, 
                        "Default twitter tags, seperated by a comma.  i.e. heaven,skincare", "Settings.TwitterTags");

                    break;

                case "Maintenance Options":
                    options.AddOption("Allow Routine Maintenance", Website.Library.GlobalClass.AllowRoutineMaintenance, 
                        "Determines wether routine maintenance is run each hour or not", "Settings.AllowRoutineMaintenance");
                    options.AddOption("Create XML Image Files", Website.Library.GlobalClass.CreateXMLImageFiles, 
                        "Determines wether XML image files are created or not, these are downloaded by the POS application", 
                        "Settings.CreateXMLImageFiles");
                    options.AddOption("Maintenance Mode", BaseWebApplication.MaintenanceMode, 
                        "Determines wether the website is in maintenance mode or not", "Settings.MaintenanceMode");

                    break;

                case "Stock Options":
                    options.AddOption("Out Of Stock Allow Notify User", BaseWebApplication.OutOfStockAllowNotifyUser, 
                        "Determines wether a user can receive a notification when out of stock items are back in stock.", 
                        "Settings.OutOfStockAllowNotifyUser");
                    options.AddOption("Out Of Stock In Page", BaseWebApplication.OutOfStockInPage, 
                        "Determines wether out of stock notification is completed in the product page (slower) or within " +
                        "a seperate page (faster).", "Settings.OutOfStockInPage");

                    break;

                case "Memory Caching":
                    options.AddDescription("Memory caching can significantly speed up the response of the website by storing " +
                        "data in memory.  The data stored is only the data that is rarely updated.");
                    options.AddOption("Allow Caching", lib.DAL.DALHelper.AllowCaching, 
                        "Allow caching of data in memory", "Setting.AllowCaching");
                    options.AddOption("Cache Timeout", lib.DAL.DALHelper.CacheLimit.Minutes, 
                        "The value is the number of minutes that the data is held in memory and can be between 1 and 1440 minutes.", 
                        "Setting.CacheLimit", 1440, 1, 1440);

                    break;

                case "Custom Pages":
                    options.AddDescription("Certain pages are customisable into local languages, by default only " +
                        "static content can be shown, you can now <a href=\"/Staff/Admin/CustomPages.aspx\">customise " +
                        "these default pages</a> to your own layout and design.");
                    options.AddOption("Use Custom Pages", lib.BOL.CustomWebPages.CustomPages.UseCustomPages, 
                        "Allow use of custom pages", "Settings.CustomPages");

                    break;

                case "Display Multiple Languages":
                    options.AddDescription("You can show multiple languages within the website with a language " +
                        "selector at the top of each page");
                    options.AddOption("Multiple Languages", LocalizedLanguages.Active, 
                        "Display multiple languages", "SITE.LANGUAGES");
                    options.AddOption("Force Initial Language", BaseWebApplication.ForceInitialDefaultLanguage, 
                        "If true, then the initial language used on the website will be that of the default language, " +
                        "if false then the default language will be retrieved using the users IP Address", 
                        "SITE.FORCEINITIAL.LANGUAGE");

                    break;

                case "Google Analytics":
                    options.AddDescription("Google analytic code that will be included in all pages");
                    options.AddOption("Java Code", BaseWebApplication.GoogleAnalytics, 
                        "Do not include the opening/closing &lt;Script&gt; section", "SETTINGS.GOOGLE.ANALYTICS", 
                        600, false, false, 15);

                    break;

                case "Web Farm":
                    options.AddDescription("Web Garden/Farm settings");
                    options.AddOption("Web Farm", BaseWebApplication.WebFarm, "Is the website part of a web garden/farm", 
                        "WEB.FARM", true);
                    options.AddOption("Master IP", BaseWebApplication.WebFarmMasterIP, "Master IP Address of server",
                        "WEB.FARM.MASTER", 300, false, false, 1, true);
                    options.AddOption("Mutex", BaseWebApplication.WebFarmMutexName, "Mutex Name",
                        "WEB.FARM.MUTEX", 300, false, false, 1, true);

                    break;
            }
        }

        public virtual List<string> WebSiteSubOptions(string parentName)
        {
            List<string> Result = new List<string>();

            switch (parentName)
            {
                case "Payment Options":
                    Result.Add("Paypal Options");
                    Result.Add("Payflow");
                    Result.Add("Credit Cards");
                    Result.Add("SunTech Payment Provider");

                    break;

                case "SunTech Payment Provider":
                    Result.Add("BuySafe");
                    Result.Add("24Payment");
                    Result.Add("WebATM");

                    break;
            }

            return (Result);
        }

        public virtual List<string> WebSiteOptionHeaders()
        {
            List<string> Result = new List<string>
            {
                "General Settings",
                "Pages",
                "Menu Items"
            };

            if (!BaseWebApplication.StaticWebSite)
            {
                Result.Add("Email Options");
                Result.Add("Offer/Voucher Options");
                Result.Add("Payment Options");
                Result.Add("Shopping Basket Options");
                Result.Add("Shopping Basket Currencies");
                Result.Add("VAT/Tax Options");
                Result.Add("Maintenance Options");
                Result.Add("Stock Options");
                Result.Add("Custom Pages");
                Result.Add("Web Farm");
            }

            Result.Add("Social Media Options");
            Result.Add("Memory Caching");
            Result.Add("Display Multiple Languages");
            Result.Add("Google Analytics");
            Result.Add("MailChimp");
            Result.Add("Licences");

            return (Result);
        }

        #endregion Virtual Methods
    }
}
