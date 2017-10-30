using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.Orders;
using Library.Utils;
using Library;
using Library.BOL.Accounts;
using Library.BOL.Invoices;
using Library.BOL.CustomWebPages;
using Library.BOL.Basket;

using Shared.Classes;

namespace Heavenskincare.WebsiteTemplate.Basket
{
    public partial class BasketOrderComplete : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paymentType = GetFormValue("InternalPaymentType");
            pPaypal.Visible = false;
            pCheque.Visible = false;
            pTelephone.Visible = false;
            pDirectTransfer.Visible = false;
            pCashOnDelivery.Visible = false;
            pTestPurchase.Visible = false;

            CustomPage customPage = null;

            if (Session["INVOICE_NUMBER"] == null)
                Response.Redirect("/Members/Invoices.aspx", true);

            Int64 InvoiceID = (Int64)Session["INVOICE_NUMBER"];

            switch (paymentType)
            {
                case "cpo":
                    pCheque.Visible = true;
                    hHeader.InnerText = Languages.LanguageStrings.OrderReceived;
                    pCheque.InnerHtml = String.Format(Languages.LanguageStrings.OrderCompleteCheque, GetWebsiteAddress());

                    break;
            
                case "pbf":
                    pTelephone.Visible = true;
                    hHeader.InnerText = Languages.LanguageStrings.OrderReceived;
                    pTelephone.InnerHtml = String.Format(Languages.LanguageStrings.OrderCompleteTelephone, GetWebsiteTelephoneNumber());

                    break;
                
                case "dbt":
                    pDirectTransfer.Visible = true;

                    customPage = CustomPages.Get("Payment Type - Direct Bank Transfer");

                    if (customPage != null && customPage.IsActive)
                        pDirectTransfer.InnerHtml = customPage.PageText;
                    else
                        pDirectTransfer.InnerHtml = Languages.LanguageStrings.OrderCompleteGeneric;

                    break;

                case "cod":
                    pCashOnDelivery.Visible = true;
                    customPage = CustomPages.Get("Payment Type - Cash On Delivery");

                    if (customPage != null && customPage.IsActive)
                        pCashOnDelivery.InnerHtml = customPage.PageText;
                    else
                        pCashOnDelivery.InnerHtml = Languages.LanguageStrings.OrderCompleteGeneric;

                    break;

                case "testpayment":
                    pTestPurchase.Visible = true;

                    Order order = Orders.Get(InvoiceID);
                    try
                    {
                        if (order != null)
                            AddAffiliateScript(order);
                    }
                    finally
                    {
                        order = null;
                    }

                    break;

                default:
                    try
                    {
                        customPage = CustomPages.Get("Payment Type - Paypal");

                        if (customPage != null && customPage.IsActive)
                            pPaypal.InnerHtml = customPage.PageText;
                        else
                            pPaypal.InnerText = Languages.LanguageStrings.OrderCompletePaypal;

                        pPaypal.Visible = true;
                        MakePaymentViaPaypal();
                    }
                    catch (Exception err)
                    {
                        Shared.EventLog.Add(err);
                    }

                    break;
            }

            try
            {
                ShowShippingAddress();
            }
            catch
            {

            }


            hInvoice.InnerText = String.Format("{1}: #{0}", InvoiceID, Languages.LanguageStrings.OrderNumber);

            Session["Discount_Ammount"] = 0;


            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;

            if (localData.Basket.ClearBasketOnPayment && localData.Basket.HasItems())
                localData.Basket.Empty();

        }

        private void ShowShippingAddress()
        {
            User user = GetUser();
            Order inv = Orders.Get((Int64)Session["INVOICE_NUMBER"]);
            string ShippingAddress = Languages.LanguageStrings.UnknownShippingAddress;

            if (inv != null)
            {
                ShippingAddress = inv.DeliveryAddress.Address(true);
            }

            pPostalAddress.InnerHtml = String.Format(Languages.LanguageStrings.DeliveryAddressUpdate + 
                "<br /><br />", "<a href=\"/Members/DeliveryAddress.aspx\">", "</a>");
            pPostalAddress.InnerHtml += ShippingAddress;
        }

        private void MakePaymentViaPaypal()
        {
            NVPAPICaller test = new NVPAPICaller();

            string retMsg = "";
            string token = "";
            string payerId = "";
            string Street1 = String.Empty;
            string Street2 = String.Empty;
            string City = String.Empty;
            string County = String.Empty;
            string PostCode = String.Empty;

            // error on next line when no order type specified
            try
            {
                token = GetFormValue("token", String.Empty);

                if (String.IsNullOrEmpty(token))
                    DoRedirect("/Basket/BasketPaymentFailed.aspx");
            }
            catch (Exception err)
            {
                if ( err.InnerException != null && err.InnerException.ToString().IndexOf("") > 1)
                {
                    DoRedirect("/Basket/BasketPaymentFailed.aspx");
                }
                else
                    throw;
            }


            Session["payerid"] = GetFormValue("PayerID", String.Empty);
            string finalPaymentAmount = "";
            NVPCodec decoder = null;

            token = GetFormValue("token", String.Empty);
            payerId = GetFormValue("payerid", String.Empty);

            //Mark payment as complete
            Int64 InvoiceID = (Int64)Session["INVOICE_NUMBER"];

            Order order = Orders.Get(InvoiceID);

            if (order != null)
            {
                Currency englishCurrency = Library.BOL.Basket.Currencies.Get(new CultureInfo("en-GB"));

                // set the conversion rate/multiplier to the native one
                finalPaymentAmount = SharedUtils.FormatMoney(order.TotalCost, 
                    englishCurrency, true);

                // get the final payment
                string transactionId = "unknown";
                string paymentType = "none";

                bool ret = test.ConfirmPayment(finalPaymentAmount, token, payerId, 
                    GetWebsiteCurrency().CurrencyCode, ref decoder, ref retMsg);

                if (ret)
                {
                    // Unique transaction ID of the payment. Note:  If the PaymentAction 
                    //of the request was Authorization or Order, this value is your AuthorizationID 
                    //for use with the Authorization & Capture APIs. 
                    transactionId = decoder["TRANSACTIONID"];

                    // The type of transaction Possible values: l  cart l  express-checkout 
                    string transactionType = decoder["TRANSACTIONTYPE"];

                    // Indicates whether the payment is instant or delayed. Possible values: l  none l  echeck l  instant 
                    paymentType = decoder["PAYMENTTYPE"];

                    // Time/date stamp of payment
                    string orderTime = decoder["ORDERTIME"];

                    // The final amount charged, including any shipping and taxes from your Merchant Profile.
                    string amt = decoder["AMT"];

                    string currency = decoder["CURRENCY"];

                    if (String.IsNullOrEmpty(currency))
                    {
                        currency = decoder["CURRENCYCODE"];
                    }

                    // A three-character currency code for one of the currencies listed in 
                    //PayPay-Supported Transactional Currencies. Default: USD.    
                    string currencyCode = decoder["CURRENCYCODE"];

                    // PayPal fee amount charged for the transaction    
                    string feeAmt = decoder["FEEAMT"];

                    // Amount deposited in your PayPal account after a currency conversion.    
                    string settleAmt = decoder["SETTLEAMT"];

                    // Tax charged on the transaction.    
                    string taxAmt = decoder["TAXAMT"];

                    //' Exchange rate if a currency conversion occurred. Relevant only if 
                    //your are billing in their non-primary currency. If 
                    string exchangeRate = decoder["EXCHANGERATE"];
                }
                else
                {
#warning send to page giving user friendly error message
                    DoError(retMsg);
                }

                Session["Discount_Ammount"] = 0;

                PaymentStatus ps;

                if (paymentType == "instant")
                    ps = PaymentStatuses.Get("Paypal Paid");
                else
                    ps = PaymentStatuses.Get("Paypal Pending");

                order.Paid(null, ps, transactionId, GetAffiliateID());
                
                AddAffiliateScript(order);
            }
        }

        protected void AddAffiliateScript(Order order)
        {
            string script = GetAffiliateExternalPurchase(order);

            if (!String.IsNullOrEmpty(script))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aff", script, false);
            }
        }

        protected string GetAffiliateExternalPurchase(Order order)
        {
            if (Global.AffiliateIncludeExternal)
            {
                if (order == null)
                    return (String.Empty);

                Invoice invoice = Invoices.Get(order);

                if (invoice == null)
                    return (String.Empty);

                string Result = String.Format("<script type=\"text/javascript\">{0}</script>", Global.AffiliatePurchaseHeader);
                Result = Result.Replace("[ORDER_ID]", invoice.ID.ToString());
                Result = Result.Replace("[CURRENCY]", invoice.Currency.CurrencyCode);

                decimal subTotal = invoice.SubTotal;

                //if (invoice.Version < Consts.INVOICE_VERSION_VAT_ADD)
                //{
                //    subTotal = SharedUtils.VATRemove(subTotal, invoice.VATRate);
                //}

                //subTotal = subTotal - (invoice.ShippingCosts + invoice.DiscountAmount + invoice.VATAmount);
                Result = Result.Replace("[TOTAL]", Math.Round(subTotal, 2).ToString());
                Result = Result.Replace("[CODE]", invoice.CouponName);

                return (Result);
            }
            else
            {
                return (String.Empty);
            }
        }
    }
}