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
 *  File: Settings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  06/02/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

using lib = Library;
using Library.Interfaces;

namespace Library.BOL.Websites
{
    public class Settings
    {
        #region Virtual Methods

        public virtual void WebSiteOptions(string parentName, IWebsiteOptions options)
        {
            switch (parentName)
            {
                #region General Settings

                case "General Settings":
                    options.AddOption("Default Page Title", WebsiteSettings.PageTitle, 
                        "Default title for pages where the title is not set", "Settings.DefaultTitle");
                    options.AddOption("Root URL", WebsiteSettings.RootURL, "Root URL of website", "Settings.RootURL");
                    options.AddOption("Path", WebsiteSettings.RootPath, "Physical Path of website", "Settings.Path", 400);
                    options.AddOption("Website Culture Override", WebsiteSettings.WebsiteCultureOverride,
                        "if ticked the default culture will always be used for language selection",
                        "Settings.WebCultureOverride");
                    options.AddOption("Basket Name", WebsiteSettings.BasketName, 
                        "Name of shopping basket", "Settings.ShoppingBasketName");
                    options.AddOption("Website Date Format", WebsiteSettings.WebsiteDateFormat, 
                        "Date format used on website", "Settings.WebsiteDateFormat", 150);
                    options.AddOption("Distributor Website", WebsiteSettings.DistributorWebsite, 
                        "Website for distributor", "Settings.DistributorWebsite");
                    options.AddOption("Use Left To Right", WebsiteSettings.UseLeftToRight, 
                        "Determines wether text is shown teft to right or right to left", "Settings.UseLeftToRight");
                    options.AddOption("Use HTTPS", WebsiteSettings.UseHTTPS, 
                        "Determines wether the website uses https or not", "Settings.UseHTTPS");
                    options.AddOption("Style Sheet", WebsiteSettings.StyleSheet, 
                        "Current style sheet used by the website.", "SITE.STYLE_SHEET");

                    break;

                #endregion General Settings

                #region Home Page

                case "Home Page":
                    options.AddHeader("Home Page");
                    options.AddDescription("Settings that affect the home page");
                    options.AddOption("Show Fixed Banners", WebsiteSettings.HomePage.ShowHomeBanners,
                        "Fixed Home Banners", "Settings.HomeBanners", false);
                    options.AddOption("Featured Products", WebsiteSettings.HomePage.ShowHomeFeaturedProducts,
                        "Show Featured Products on Homepage", "SETTINGS.HOMEFEATURED");

                    break;

                #endregion Home Page

                #region Contact Details

                case "Contact Details":
                    options.AddHeader("Website Contact Details");

                    options.AddOption("Telephone", WebsiteSettings.ContactDetails.WebsiteTelephoneNumber,
                        "Contact Telephone Details", "Settings.WebsiteTelephoneNumber");

                    options.AddOption("Email", WebsiteSettings.ContactDetails.WebsiteEmail,
                        "Contact Email Address", "Settings.WebsiteEmail");

                    options.AddOption("Address Line 1", WebsiteSettings.ContactDetails.AddressLine1,
                        "Contact Address Line 1.", "Settings.AddressLine1");

                    options.AddOption("Address Line 2", WebsiteSettings.ContactDetails.AddressLine2,
                        "Contact Address Line 2.", "Settings.AddressLine2");

                    options.AddOption("Address Line 3", WebsiteSettings.ContactDetails.AddressLine3,
                        "Contact Address Line 3.", "Settings.AddressLine3");

                    break;

                #endregion Contact Details

                #region All Pages

                case "All Pages":
                    options.AddHeader("All Pages");
                    options.AddDescription("There are certain pages which can be turned off if they are not used or relevant");

                    options.AddOption("Show Terms and Conditions", WebsiteSettings.AllPages.ShowTermsAndConditions,
                        "Shows a page with terms and conditions.", "Settings.ShowTermsAndConditions");
                    options.AddOption("Show Privacy Policy", WebsiteSettings.AllPages.ShowPrivacyPolicy, 
                        "Shows a page with privacy policy information", "Settings.ShowPrivacyPolicy");
                    options.AddOption("Show Returns Policy", WebsiteSettings.AllPages.ShowReturnsPolicy, 
                        "Shows a page with returns policy", "Settings.ShowReturnsPolicy");

                    options.AddOption("Show Treatments Brochure", WebsiteSettings.AllPages.ShowTreatmentsBrochure,
                        "Shows a page with treatments", "Settings.ShowTreatmentBrochure");
                    options.AddOption("Show Trade Page", WebsiteSettings.AllPages.ShowTradePage, 
                        "Shows a page with trade data, also includes a form where new clients can sign up",
                        "Settings.ShowTradePage");

                    break;

                #endregion All Pages

                #region Menu Items

                case "Menu Items":
                    options.AddOption("Show Download Page", WebsiteSettings.AllPages.ShowDownloadMenu,
                        "Show Download Page", "Settings.ShowDownloads");

                    options.AddOption("Show Salons Page", WebsiteSettings.AllPages.ShowSalonsMenu,
                        "Show Salons page", "Settings.ShowSalons");
                    options.AddOption("Show Salon Finder Page", WebsiteSettings.AllPages.ShowSalonFinder,
                        "Show Salon Search on Salon Page", "Settings.ShowSalonFinder");
                    options.AddOption("Show Salon Client Header", WebsiteSettings.AllPages.ShowClientHeader,
                        "Show Salon Client Header", "Settings.ShowSalonClientHeader");
                    options.AddOption("Show Salon Header", WebsiteSettings.AllPages.ShowSalonHeader,
                        "Show Salon Header", "Settings.ShowSalonHeader");

                    options.AddOption("Show Treatments Page", WebsiteSettings.AllPages.ShowTreatmentsMenu,
                        "Show Treatments Page", "Settings.ShowTreatments");
                    options.AddOption("Show Distributors Page", WebsiteSettings.AllPages.ShowDistributorsMenu,
                        "Show Distributors Page", "Settings.ShowDistributors");
                    options.AddOption("Show Tips and Tricks Page", WebsiteSettings.AllPages.ShowTipsAndTricksMenu,
                        "Show Distributors Page", "Settings.ShowTipsAndTricks");

                    break;

                #endregion Menu Items

                #region Email Options

                case "Email Options":
                    options.AddOption("No Reply Name", WebsiteSettings.Email.NoReplyName, 
                        "No reply email address name", "Settings.NoReplyName");
                    options.AddOption("No Reply Email", WebsiteSettings.Email.NoReplyEmail, 
                        "No reply email address", "Settings.NoReplyEmail");
                    options.AddOption("Support Name", WebsiteSettings.Email.SupportName, 
                        "Support email name", "Settings.SupportName");
                    options.AddOption("Support EMail", WebsiteSettings.Email.SupportEMail, 
                        "Support email address", "Settings.SupportEMail");
                    options.AddOption("SMTP Host", WebsiteSettings.Email.SMTPHost, 
                        "SMTP Host", "Settings.SMTPHost");
                    options.AddOption("SMTP User Name", WebsiteSettings.Email.SMTPUserName, 
                        "SMTP User name", "Settings.SMTPUserName");
                    options.AddOption("SMTP Password", WebsiteSettings.Email.SMTPPassword, 
                        "SMTP Password", "Settings.SMTPPassword", 250, true);
                    options.AddOption("SMTP Use SSL", WebsiteSettings.Email.SMTPUseSSL, 
                        "Indicates wether HTTPS is used when sending emails or not", "Settings.SMTPUseSSL");
                    options.AddOption("Send Emails", WebsiteSettings.Email.SendEmails, 
                        "Determines wether emails are sent or not", "Settings.SendEmail");

                    break;

                #endregion Email Options

                #region Marketing

                case "MailChimp":
                    options.AddOption("MailChimp API", WebsiteSettings.Marketing.MailChimp.MailChimpAPI, 
                        "MailChimp API for sending new subscriptions", "Settings.MailChimpAPI");
                    options.AddOption("List Name", WebsiteSettings.Marketing.MailChimp.MailChimpList, 
                        "Name of List for users who Subscribe/Unsubscribe", "Settings.MailChimpList");
                    options.AddDescription("If you have a MailChimp account you can get notifications on " +
                        "Mail Subscriptions/Unsubsriptions.  For security you need to pass aunique key, you " +
                        "can use the randomly generated key below or set your own.");
                    options.AddOption("MailChimp Key", WebsiteSettings.Marketing.MailChimp.MailChimpKey, 
                        "MailChimp Key", "Settings.MailChimpKey");
                    options.AddDescription(String.Format("<p>The WebHook required for your MailChimp account is:</p>" +
                        "<p>{0}/Members/MailChimp/MailChimpHook.aspx?key={1}", WebsiteSettings.RootURL,
                        WebsiteSettings.Marketing.MailChimp.MailChimpKey));
                    options.AddDescription("&nbsp;");
                    options.AddDescription("");
                    options.AddOption("MailChimp Popup", WebsiteSettings.Marketing.MailChimp.MailChimpPopupDialog, 
                        "Code for MailChimp pop up window, prompting user to sign up", 
                        "Settings.MailChimpPopup", 400, false, false, 8);
                    break;

                #endregion Marketing

                #region Payment Gateways

                case "SunTech Payment Provider":
                    options.AddDescription("Only enable if you have an account with SunTech, if TestMode is enabled " +
                        "it will only be shown for Administrators");

                    break;

                case "BuySafe":
                    options.AddOption("BuySafe Merchant ID", WebsiteSettings.PaymentGateways.SunTech.BuySafe.MerchantID, 
                        "Merchant ID for BuySafe", "Settings.BuySafeMerchantID");
                    options.AddOption("BuySafe Merchant Password", WebsiteSettings.PaymentGateways.SunTech.BuySafe.MerchantPassword, 
                        "Merhcant Password for BuySafe", "Settings.BuySafeMerchantPW", 300, true);
                    options.AddOption("BuySafe TestMode", WebsiteSettings.PaymentGateways.SunTech.BuySafe.TestMode, 
                        "Indicates wether test mode or not", "Settings.BuySafeTestMode");

                    break;

                case "24Payment":
                    options.AddOption("24Payment Merchant ID", WebsiteSettings.PaymentGateways.SunTech.Payment24.MerchantID, 
                        "Merchant ID for BuySafe", "Settings.24PaymentMerchantID");
                    options.AddOption("24Payment Merchant Password", WebsiteSettings.PaymentGateways.SunTech.Payment24.MerchantPassword, 
                        "Merhcant Password for BuySafe", "Settings.24PaymentMerchantPW", 300, true);
                    options.AddOption("24Payment TestMode", WebsiteSettings.PaymentGateways.SunTech.Payment24.TestMode, 
                        "Indicates wether test mode or not", "Settings.24PaymentTestMode");

                    break;

                case "WebATM":
                    options.AddOption("WebATM Merchant ID", WebsiteSettings.PaymentGateways.SunTech.WebATM.MerchantID, 
                        "Merchant ID for BuySafe", "Settings.WebATMMerchantID");
                    options.AddOption("WebATM Merchant Password", WebsiteSettings.PaymentGateways.SunTech.WebATM.MerchantPassword, 
                        "Merhcant Password for BuySafe", "Settings.WebATMMerchantPW", 300, true);
                    options.AddOption("WebATM TestMode", WebsiteSettings.PaymentGateways.SunTech.WebATM.TestMode, 
                        "Indicates wether test mode or not", "Settings.WebATMTestMode");

                    break;

                case "Paypal":
                    options.AddOption("API Username", WebsiteSettings.PaymentGateways.Paypal.APIUsername, 
                        "Paypal API Username", "Settings.PaypalAPIUserName");
                    options.AddOption("API Password", WebsiteSettings.PaymentGateways.Paypal.APIPassword, 
                        "Paypal API Password", "Settings.PaypalAPIPassword");
                    options.AddOption("API Signature", WebsiteSettings.PaymentGateways.Paypal.APISignature, 
                        "Paypal API Signature", "Settings.PaypalAPISignature", 500);
                    options.AddOption("Subject", WebsiteSettings.PaymentGateways.Paypal.Subject, 
                        "Paypal API Subject", "Settings.PaypalAPISubject");
                    options.AddOption("BNCode", WebsiteSettings.PaymentGateways.Paypal.BNCode, 
                        "Paypal API BN Code", "Settings.PaypalAPIBNCode");
                    options.AddOption("Default Currency", WebsiteSettings.PaymentGateways.Paypal.DefaultCurrency, 
                        "Paypal API Currency", "Settings.PaypalAPICurrency", 100);
                    options.AddOption("API Success URL", WebsiteSettings.PaymentGateways.Paypal.APISuccessURL, 
                        "URL when payment succesfully made", "Settings.PaypalSuccessURL");
                    options.AddOption("API Fail URL", WebsiteSettings.PaymentGateways.Paypal.APIFailURL, 
                        "URL when payment fails", "Settings.PaypalFailURL");

                    break;

                case "Payflow":
                    options.AddOption("Payflow Test Mode", WebsiteSettings.PaymentGateways.Payflow.PayflowTestMode, 
                        "Payflow test mode, if set to true then only staff members and above will " +
                        "see credit card payment pages, if false everyone can see credit card payment pages", 
                        "Settings.PayflowTestMode");
                    options.AddOption("Payflow Partner", WebsiteSettings.PaymentGateways.Payflow.PayflowPartner, 
                        "Payflow Partner Name", "Settings.PayflowPartner");
                    options.AddOption("Payflow Vendor", WebsiteSettings.PaymentGateways.Payflow.PayflowVendor, 
                        "Payflow Vendor reference", "Settings.PayflowVendor");
                    options.AddOption("Payflow User", WebsiteSettings.PaymentGateways.Payflow.PayflowUser, 
                        "Payflow User reference", "Settings.PayflowUser");
                    options.AddOption("Payflow Password", WebsiteSettings.PaymentGateways.Payflow.PayflowPassword, 
                        "Payflow password", "Settings.PayflowPassword");

                    break;

                case "Payment Gateways":
                    options.AddOption("Show Payment Payflow", WebsiteSettings.PaymentGateways.ShowPaymentCard, 
                        "Take payments via Payflow card processing", "Settings.ShowPaymentCard");
                    options.AddOption("Show Payment Cheque", WebsiteSettings.PaymentGateways.ShowPaymentCheque, 
                        "Take payments via cheque", "Settings.ShowPaymentCheque");
                    options.AddOption("Show Payment Paypoint", WebsiteSettings.PaymentGateways.ShowPaymentPaypoint, 
                        "Take payments via Paypoint", "Settings.ShowPaymentPaypoint");
                    options.AddOption("Show Payment Paypal", WebsiteSettings.PaymentGateways.ShowPaymentPaypal, 
                        "Take payments via paypal", "Settings.ShowPaymentPaypal");
                    options.AddOption("Show Payment Telephone", WebsiteSettings.PaymentGateways.ShowPaymentTelephone, 
                        "Take payments over the telephone", "Settings.ShowPaymentTelephone");
                    options.AddOption("Show Payment Cash On Delivery", WebsiteSettings.PaymentGateways.ShowPaymentCashOnDelivery, 
                        "Take payment via Cash On Delivery", "Settings.ShowPaymentCOD");
                    options.AddOption("Show Payment Direct Bank Transfer", WebsiteSettings.PaymentGateways.ShowPaymentDirectBankTransfer, 
                        "Take payment via direct bank transfer", "Settings.ShowPaymentDBT");
                    options.AddOption("Show Payment SunTech 24 Payment", WebsiteSettings.PaymentGateways.ShowPaymentSunTech24Payment, 
                        "Take payment via SunTech 24Payment", "Settings.AllowSunTech24Payment");
                    options.AddOption("Show Payment SunTech Web ATM", WebsiteSettings.PaymentGateways.ShowPaymentSunTechWebATM, 
                        "Take payment via SunTech WebATM", "Settings.AllowSunTechWebATM");
                    options.AddOption("Show Payment SunTech Buy Safe", WebsiteSettings.PaymentGateways.ShowPaymentSunTechBuySafe, 
                        "Take payment via SunTech Buy Safe", "Settings.AllowSunTechBuySafe");
                    options.AddOption("Show Payment Test Purchase", WebsiteSettings.PaymentGateways.ShowPaymentTestPurchase,
                        "Allow test purchases to be completed on the website", "Settings.TestPurchase");

                    break;

                #endregion Payment Gateways

                #region Credit Cards

                case "Credit Cards":
                    options.AddOption("Allow Credit Cards", WebsiteSettings.CreditCards.AllowCreditCards, 
                        "Allow credit card data to be stored in database", "Settings.AllowCreditCards");
                    options.AddOption("Hide Valid From", WebsiteSettings.CreditCards.CreditCardHideValidFrom, 
                        "Hide's the valid from date from Credit Cards", "Settings.AlwaysHideValidFrom");
                    options.AddOption("Always Show Valid From For UK", WebsiteSettings.CreditCards.CreditCardAlwaysShowValidFromForUK, 
                        "Always show the valid from date for UK visitors", "Settings.AlwaysShowCCForUK");

                    break;

                #endregion Credit Cards

                #region Offers

                case "Offer/Voucher Options":
                    options.AddOption("Show Offers", WebsiteSettings.Offers.ShowOffers, 
                        "Determines wether offers are shown on the website or not", "Settings.ShowOffers");
                    options.AddOption("Show Voucher", WebsiteSettings.Offers.ShowVoucher, 
                        "Determines wether vouchers are shown on the website or not - OBSOLETE", "Settings.ShowVoucher");

                    break;

                #endregion Offers

                #region Licences

                case "Licences":
                    options.AddOption("Allow Licences", WebsiteSettings.Licences.AllowLicences,
                        "Only enable if you sell licenced software on your site", "Settings.AllowLicences");

                    break;

                #endregion Licences

                #region Shopping Basket

                case "Shopping Basket Options":
                    options.AddOption("Hide Shopping Cart", WebsiteSettings.ShoppingCart.HideShoppingCart, 
                        "Determines wether the shopping cart is hidden or not", "Settings.HideShoppingCart");
                    options.AddOption("Free Shipping Allow", WebsiteSettings.ShoppingCart.FreeShippingAllow, 
                        "Determines whether free shipping is allowed or not", "Settings.FreeShippingAllow");
                    options.AddOption("Free Shipping Amount", WebsiteSettings.ShoppingCart.FreeShippingAmount, 
                        "Minimum spend before free shipping is allowed", "Settings.FreeShippingSpend");
                    options.AddOption("Override Cost Multiplier", WebsiteSettings.ShoppingCart.OverrideCostMultiplier, 
                        "Determines wether a cost multiplier is applied globally", "Settings.OverrideCostMultiplier");
                    options.AddOption("Override Cost Multiplier Value", WebsiteSettings.ShoppingCart.OverrideCostMultiplierValue, 
                        "The cost multiplier value, i.e. 0.3 will make all products 30% cheaper", 
                        "Settings.OverrideCostMultiplierValue");
                    options.AddOption("Maximum Item Quantity", WebsiteSettings.ShoppingCart.MaximumItemQuantity, 
                        "Maximum number of items a user can add to their shopping basket.", "Settings.MaximumItemQuantity", 3, 1, 500);
                    options.AddOption("Jump To Basket After Add Item", WebsiteSettings.ShoppingCart.JumpToBasketAfterAddItem, 
                        "If true then after each item is added to a basket the user will be redirected to the basket.", 
                        "Settings.JumpToBasketAfterAddItem");
                    options.AddOption("Alter Text Color Based On Basket Contents",
                        WebsiteSettings.ShoppingCart.AlterTextColorBasedOnBasketContents, "Alter \"Add to Bag\" text color depending " +
                        "on wether the item is in the basket or not.", "Settings.AlterTextColorBasedOnBasketContents");
                    options.AddOption("Item Does Not Exists In Shopping Bag Text Colour",
                        WebsiteSettings.ShoppingCart.ItemDoesNotExistsInShoppingBagTextColour, 
                        "Text color of \"Add to Bag\" button if an item is not in the users shopping basket.<br />" +
                        "<br />AlterTextColorBasedOnBasketContents must be true for this to take effect.", 
                        "Settings.ItemDoesNotExistsInShoppingBagTextColour", 150);
                    options.AddOption("Item Exists In Shopping Bag Text Colour", WebsiteSettings.ShoppingCart.ItemExistsInShoppingBagTextColour, 
                        "Text color of \"Add to Bag\" button if an item is in the users shopping basket.<br /><br />" +
                        "AlterTextColorBasedOnBasketContents must be true for this to take effect.", 
                        "Settings.ItemExistsInShoppingBagTextColour", 150);
                    options.AddOption("Culture Override", lib.DAL.DALHelper.CultureOverride,  
                        "Culture to be used if overridden", "Settings.CultureOverride", 100, false, true, 1, false);
                    options.AddOption("Show Price Data", WebsiteSettings.ShoppingCart.DefaultShowPrices, 
                        "Default action if showing price data can not be determined from the country, if checked " +
                        "then default will show prices, if not checked default is to hide prices", "Settings.ShowPriceDefault");
                    options.AddOption("ClearBasketOnPayment", WebsiteSettings.ShoppingCart.ClearBasketOnPayment, 
                        "If true then the basket will be emptied when payment is confirmed, if false then basket " +
                        "will be emptied when order created (default)", "Settings.ClearBasketOnPayment", true);
                    break;

                #endregion Shopping Baket

                #region Shopping Cart Currencies

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
                    options.AddOption("Paypal Currencies", WebsiteSettings.PaymentGateways.Paypal.DefaultCurrency, 
                        "Accepted paypal currencies, ensure paypal is configured to accept them first", "Settings.PaypalAPICurrency");
                    options.AddOption("Payflow Currencies", WebsiteSettings.PaymentGateways.Payflow.Currencies, 
                        "Valid Payflow currencies, ensure Paypal is configured to accept them", "Settings.PayflowCurrencies");
                    options.AddOption("Phone Currencies", WebsiteSettings.PaymentGateways.Telephone.Currency, 
                        "Valid currencies that can be accepted over the telephone", "Settings.PhoneCurrency");
                    options.AddOption("Cash On Delivery", WebsiteSettings.PaymentGateways.CashOnDelivery.Currency, 
                        "Valid currencies that can be accepted with Cash on Delivery", "Settings.CODCurrency");
                    options.AddOption("Cheque Currency", WebsiteSettings.PaymentGateways.Cheque.Currency, 
                        "Valid currencies that can be accepted via cheque", "Settings.ChequeCurrency");
                    options.AddOption("Direct Transfer", WebsiteSettings.PaymentGateways.DirectTransfer.Currency, 
                        "Valid currencies that can be accepted via direct transfer", "Settings.DTCurrency");
                    options.AddOption("Worldpay", WebsiteSettings.PaymentGateways.WorldPay.Currencies, 
                        "Valid currencies accepted by Paynet", "Settings.PaynetCurrency");
                    options.AddOption("BuySafe Currencies", 
                        WebsiteSettings.PaymentGateways.SunTech.BuySafe.SupportedCurrencies, 
                        "Supported Currencies, i.e. GBP;USD", "Settings.BuySafeCurrencies");
                    options.AddOption("24Payment Currencies",
                        WebsiteSettings.PaymentGateways.SunTech.Payment24.SupportedCurrencies, 
                        "Supported Currencies, i.e. GBP;USD", "Settings.24PaymentCurrencies");
                    options.AddOption("WebATM Currencies",
                        WebsiteSettings.PaymentGateways.SunTech.WebATM.SupportedCurrencies, 
                        "Supported Currencies, i.e. GBP;USD", "Settings.WebATMCurrencies");
                    options.AddOption("Test Purchase Currencies",
                        WebsiteSettings.PaymentGateways.TestPurchase.Currency, 
                        "Supported Currencies i.e. GBP;USD", "Settings.TestPurchaseCurrencies");

                    break;

                #endregion Shopping Cart Currencies

                #region Tax / VAT Options

                case "VAT/Tax Options":
                    options.AddOption("Vat Rate", WebsiteSettings.Tax.VatRate, "VAT/Tax rate applied to the sales on the website", 
                        "Settings.VatRate");
                    options.AddOption("Hide VAT On Website And Invoices", DAL.DALHelper.HideVATOnWebsiteAndInvoices, 
                        "Determines wether VAT/Tax is shown in the basket and on Invoices/Orders", 
                        "Settings.HideVATOnWebsiteAndInvoices");
                    options.AddOption("Shipping Is Taxable", WebsiteSettings.Tax.ShippingIsTaxable,
                        "If ticked, tax is added to shipping costs, if false, no tax is added to shipping costs",
                        "Settings.ShippingIsTaxable");
                    options.AddOption("Prices Include VAT", WebsiteSettings.Tax.PricesIncludeVAT, 
                        "If ticked, then the prices shown on the website will have VAT included", "Settings.PricesIncludeVAT");
                    options.AddDescription("The following two settings also affect the display of " +
                        "invoices/orders within the members area and on reports");
                    options.AddOption("Show Basket Items With VAT", WebsiteSettings.Tax.ShowBasketItemsWithVAT, 
                        "If ticked items within the shopping basket will have VAT/TAX added to them, if not ticked " +
                        "then only the price without VAT/TAX will be shown.", "Settings.ShowBasketItemsWithVAT");
                    options.AddOption("Show Basket SubTotal With VAT", WebsiteSettings.Tax.ShowBasketSubTotalWithVAT, 
                        "if ticked the subtotal in the basket will have VAT/TAX added, if not ticked the VAT/TAX will be removed.", 
                        "Settings.ShowBasketSubTotalWithVAT");
                    break;
                #endregion Tax / VAT Options

                #region Social Media

                case "Social Media Options":
                    options.AddDescription("If any of the following values are blank then the option icon will be hidden");
                    options.AddOption("Facebook", WebsiteSettings.SocialMedia.Facebook.Url, 
                        "Facebook link on page header", "Settings.Facebook");
                    options.AddOption("GPlus", WebsiteSettings.SocialMedia.Google.GPlus, 
                        "GPlus link on page header", "Settings.GPlus");
                    options.AddOption("RSS Feed", WebsiteSettings.SocialMedia.RSS.Feed, 
                        "RSS feed link on page header", "Settings.RSSFeed");
                    options.AddOption("Twitter", WebsiteSettings.SocialMedia.Twitter.Url, 
                        "Twitter link on page header", "Settings.Twitter");
                    options.AddOption("Default Twitter Tags", WebsiteSettings.SocialMedia.Twitter.DefaultTags, 
                        "Default twitter tags, seperated by a comma.  i.e. heaven,skincare", "Settings.TwitterTags");

                    break;

                #endregion Social Media

                #region Maintenance

                case "Maintenance Options":
                    options.AddOption("Allow Routine Maintenance", WebsiteSettings.Maintenance.AllowRoutineMaintenance, 
                        "Determines wether routine maintenance is run each hour or not", "Settings.AllowRoutineMaintenance");
                    options.AddOption("Create XML Image Files", WebsiteSettings.Maintenance.CreateXMLImageFiles, 
                        "Determines wether XML image files are created or not, these are downloaded by the POS application", 
                        "Settings.CreateXMLImageFiles");
                    options.AddOption("Maintenance Mode", WebsiteSettings.Maintenance.MaintenanceMode, 
                        "Determines wether the website is in maintenance mode or not", "Settings.MaintenanceMode");

                    break;

                #endregion Maintenance

                #region Custom Website Pages

                case "Custom Pages":
                    options.AddDescription("Certain pages are customisable into local languages, by default only " +
                        "static content can be shown, you can now customise " +
                        "these default pages to your own layout and design.");
                    options.AddOption("Use Custom Pages", WebsiteSettings.Languages.UseCustomPages, 
                        "Allow use of custom pages", "Settings.CustomPages");

                    break;

                #endregion Custom Website Pages

                #region Languages

                case "Display Multiple Languages":
                    options.AddDescription("You can show multiple languages within the website with a language " +
                        "selector at the top of each page");
                    options.AddOption("Multiple Languages", WebsiteSettings.Languages.Active, 
                        "Display multiple languages", "SITE.LANGUAGES");
                    options.AddOption("Force Initial Language", WebsiteSettings.Languages.ForceInitialDefaultLanguage, 
                        "If true, then the initial language used on the website will be that of the default language, " +
                        "if false then the default language will be retrieved using the users IP Address", 
                        "SITE.FORCEINITIAL.LANGUAGE");

                    break;

                #endregion Languages

                #region Stock

                case "Stock Options":
                    options.AddOption("Out Of Stock Allow Notify User", WebsiteSettings.Stock.OutOfStockAllowNotifyUser, 
                        "Determines wether a user can receive a notification when out of stock items are back in stock.", 
                        "Settings.OutOfStockAllowNotifyUser");
                    options.AddOption("Out Of Stock In Page", WebsiteSettings.Stock.OutOfStockInPage, 
                        "Determines wether out of stock notification is completed in the product page (slower) or within " +
                        "a seperate page (faster).", "Settings.OutOfStockInPage");

                    break;

                #endregion Stock

                #region Google Analytics

                case "Google Analytics":
                    options.AddDescription("Google analytic code that will be included in all pages");
                    options.AddOption("Java Code", WebsiteSettings.Analytics.Google.GoogleAnalytics, 
                        "Do not include the opening/closing &lt;Script&gt; section", "SETTINGS.GOOGLE.ANALYTICS", 
                        600, false, false, 15);

                    break;

                #endregion Google Analytics

                #region Memory Caching

                case "Memory Caching":
                    options.AddDescription("Memory caching can significantly speed up the response of the website by storing " +
                        "data in memory.  The data stored is only the data that is rarely updated.");
                    options.AddOption("Allow Caching", DAL.DALHelper.AllowCaching, 
                        "Allow caching of data in memory", "Setting.AllowCaching", true);
                    options.AddOption("Cache Timeout", DAL.DALHelper.CacheLimit.Minutes, 
                        "The value is the number of minutes that the data is held in memory and can be between 1 and 1440 minutes.", 
                        "Setting.CacheLimit", 1440, 1, 1440, true);

                    break;

                #endregion Memory Caching

                #region Web Farms

                case "Web Farm":
                    options.AddDescription("Web Garden/Farm settings");
                    options.AddOption("Web Farm", WebsiteSettings.WebFarm.IsWebFarm, "Is the website part of a web garden/farm", 
                        "WEB.FARM", true);
                    options.AddOption("Master IP", WebsiteSettings.WebFarm.WebFarmMasterIP, "Master IP Address of server",
                        "WEB.FARM.MASTER", 300, false, false, 1, true);
                    options.AddOption("Mutex", WebsiteSettings.WebFarm.WebFarmMutexName, "Mutex Name",
                        "WEB.FARM.MUTEX", 300, false, false, 1, true);

                    break;

                #endregion Web Farms

                #region Members Menu

                case "Members Menu":
                    options.AddDescription("Member Menu Options");
                    options.AddOption("Shop/Store Update", WebsiteSettings.Members.ShowSalonUpdate,
                        "Show menu allowing distributors to update shop/store details", "Settings.UserMenuSalonUpdates");
                    options.AddOption("Appointments", WebsiteSettings.Members.ShowAppointments,
                        "Settings.UserMenuAppointments", "Allow members to book view and book appointments");
    
                    break;

                #endregion Members Menu

                #region Trade Customers

                case "Trade Customers":
                    options.AddDescription("Options only available to trade customers");
                    options.AddOption("Trade Downloads", WebsiteSettings.TradeCustomers.ShowTradeDownloads,
                        "Download items for trade customers only", "Settings.UserMenuTradeDownloads");

                    break;

                #endregion Trade Customers

                #region Affiliates

                case "Affiliates":
                    options.AddDescription("Affiliate Options");
                    options.AddOption("Maximum Days", WebsiteSettings.Affiliates.MaximumDays,
                        "Maximum days after initial visit that affiliates can claim a sale",
                        "AFFILIATE_LIVE_DAYS", 7, 1, 50);

                    break;

                #endregion Affiliates

                #region Carousel

                case "Carousel":
                    options.AddDescription("Carousel Settings");
                    options.AddOption("Show Custom Text", WebsiteSettings.Carousel.CustomScrollerStrapLine,
                        "Determines wether custom text is shown above the carousel or not",
                        "Settings.CustomIndexScroller");
                    options.AddOption("Custom Text", WebsiteSettings.Carousel.CustomScrollerText,
                        "Text shown above carousel", "Settings.CustomScrollerText");

                    break;

                #endregion Carousel
            }
        }

        public virtual List<string> WebSiteSubOptions(string parentName)
        {
            List<string> Result = new List<string>();

            switch (parentName)
            {
                case "Payment Gateways":
                    Result.Add("Paypal");
                    Result.Add("Payflow");
                    Result.Add("Credit Cards");
                    Result.Add("SunTech Payment Provider");

                    break;

                case "SunTech Payment Provider":
                    Result.Add("BuySafe");
                    Result.Add("24Payment");
                    Result.Add("WebATM");

                    break;

                case "Marketing":
                    Result.Add("MailChimp");

                    break;
            }

            return (Result);
        }

        public virtual List<string> WebSiteOptionHeaders()
        {
            List<string> Result = new List<string>
            {
                "General Settings",
                "Contact Details",
                "All Pages",
                "Home Page",
                "Menu Items"
            };

            if (!WebsiteSettings.StaticWebSite)
            {
                Result.Add("Email Options");
                Result.Add("Offer/Voucher Options");
                Result.Add("Payment Gateways");
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
            Result.Add("Marketing");
            Result.Add("Licences");
            Result.Add("Trade Customers");
            Result.Add("Members Menu");
            Result.Add("Affiliates");
            Result.Add("Carousel");

            return (Result);
        }

        #endregion Virtual Methods
    }
}
