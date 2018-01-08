using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.Orders;
using Library.Utils;
using Library;
using Library.BOL.Accounts;
using Library.BOL.CustomWebPages;

using Shared.Classes;

namespace SieraDelta.Website.Basket
{
    public partial class BasketOrderComplete : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paymentType = (string)Page.RouteData.Values["type"] ?? "unknown";
            pPaypal.Visible = false;
            pCheque.Visible = false;
            pTelephone.Visible = false;
            pDirectTransfer.Visible = false;
            pCashOnDelivery.Visible = false;

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
                    pDirectTransfer.InnerHtml = CustomPages.Get("Payment Type - Direct Bank Transfer").PageText;

                    break;

                case "cod":
                    pCashOnDelivery.Visible = true;
                    pCashOnDelivery.InnerHtml = CustomPages.Get("Payment Type - Cash On Delivery").PageText;

                    break;

                default:
                    pPaypal.Visible = true;
                    MakePaymentViaPaypal();

                    break;
            }

            try
            {
                ShowShippingAddress();
            }
            catch
            {

            }


            Int64 InvoiceID = (Int64)Session["INVOICE_NUMBER"];
            hInvoice.InnerText = String.Format("{1}: #{0}", InvoiceID, Languages.LanguageStrings.OrderNumber);


            Session["Discount_Ammount"] = 0;
        }

        private void ShowShippingAddress()
        {
            User user = GetUser();
            Order inv = Orders.Get((int)Session["INVOICE_NUMBER"]);
            string ShippingAddress = Languages.LanguageStrings.UnknownShippingAddress;

            if (inv != null)
            {
                ShippingAddress = inv.DeliveryAddress.Address(true);
            }

            pPostalAddress.InnerHtml = String.Format(Languages.LanguageStrings.DeliveryAddressUpdate + "<br /><br />", "<a href=\"/Members/DeliveryAddress.aspx\">", "</a>");
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
                if (Session["token"] == null)
                    DoRedirect("/Basket/BasketPaymentFailed.aspx");
                else
                    token = Session["token"].ToString();
            }
            catch (Exception err)
            {
                if (err.InnerException != null && err.InnerException.ToString().IndexOf("") > 1)
                {
                    DoRedirect("/Basket/BasketPaymentFailed.aspx");
                }
                else
                    throw;
            }


            bool ret = test.GetShippingDetails(token, ref payerId, ref retMsg,
                out Street1, out Street2, out City, out County, out PostCode);

            if (ret)
            {
                // try and update the user address following payment
                try
                {
                    User user = Library.BOL.Users.User.UserGet(GetUserID());
                    user.AddressLine1 = Street1;
                    user.AddressLine2 = Street2;
                    user.City = City;
                    user.County = County;
                    user.PostCode = PostCode;
                    user.Save();
                }
                catch (Exception Err)
                {
                    try
                    {
                        string Inner = "Unknown";
                        string Message = "Error Updating Address following payment";
                        string Source = "Unknown";
                        string StackTrace = "Unknown";
                        string TargetSite = "Unknown";

                        if (Err != null)
                        {
                            Inner = Err.InnerException.ToString();
                            Message = Err.Message;
                            Source = Err.Source;
                            StackTrace = Err.StackTrace;
                            TargetSite = Err.TargetSite.ToString();
                        }
                        string Msg = String.Format("<P>Error Message: {0}</P>" +
                            "<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
                            "<P>StackTrace: {3}</P><P>Target Site: {4}</P>",
                            Message, Inner, Source, StackTrace, TargetSite);
                    }
                    catch
                    {
                        // ignore error, we have tried
                    }
                }

                Session["payerid"] = GetFormValue("PayerID", String.Empty);
                string finalPaymentAmount = "";
                NVPCodec decoder = null;

                token = Session["token"].ToString();
                payerId = Session["payerid"].ToString();

                //Mark payment as complete
                int InvoiceID = (int)Session["INVOICE_NUMBER"];
                Order order = Orders.Get(InvoiceID);

                if (order != null)
                {
                    finalPaymentAmount = SharedUtils.FormatMoney(order.TotalCost, GetWebsiteCurrency());

                    // get the final payment
                    string transactionId = "unknown";
                    string paymentType = "none";

                    ret = test.ConfirmPayment(finalPaymentAmount, token, payerId, WebCountry.DefaultCurrency, ref decoder, ref retMsg);

                    if (ret)
                    {
                        // Unique transaction ID of the payment. Note:  If the PaymentAction of the request was Authorization or Order, this value is your AuthorizationID for use with the Authorization & Capture APIs. 
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

                        // A three-character currency code for one of the currencies listed in PayPay-Supported Transactional Currencies. Default: USD.    
                        string currencyCode = decoder["CURRENCYCODE"];

                        // PayPal fee amount charged for the transaction    
                        string feeAmt = decoder["FEEAMT"];

                        // Amount deposited in your PayPal account after a currency conversion.    
                        string settleAmt = decoder["SETTLEAMT"];

                        // Tax charged on the transaction.    
                        string taxAmt = decoder["TAXAMT"];

                        //' Exchange rate if a currency conversion occurred. Relevant only if your are billing in their non-primary currency. If 
                        string exchangeRate = decoder["EXCHANGERATE"];
                    }
                    else
                    {
                        //TODO: send to page giving user friendly error message
                        DoError(retMsg);
                    }

                    Session["Discount_Ammount"] = 0;

                    PaymentStatus ps;

                    if (paymentType == "instant")
                        ps = PaymentStatuses.Get("Paypal Paid");
                    else
                        ps = PaymentStatuses.Get("Paypal Pending");

                    string referrer = GetUserSession().InitialReferrer;

                    order.Paid(null, ps, transactionId, referrer);
                }
            }
            else
            {
                DoRedirect("/Members/");
            }
        }

    }
}