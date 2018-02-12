using System;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Orders;
using Library.BOL.Accounts;
using Library.BOL.Websites;

namespace SieraDelta.Website.Basket
{
    public partial class BasketCC : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetFormValue("RESULT") != "0")
            {
                //transaction not authorised
                TransactionNotAuthorised();
            }
            else
            {
                // all worked, create an invoice etc
                //SieraDeltaUtils u = new SieraDeltaUtils();
                int orderID = SharedUtils.StrToInt(GetFormValue("OrderID"), -1);

                try
                {
                    string referrer = GetUserSession().InitialReferrer;

                    Order order = Orders.Get(orderID);
                    order.Paid(null, PaymentStatuses.Get("Credit Card Paid"), String.Format("{0} : {1} : {2} : {3} : {4} : {5}", 
                        GetFormValue("RESULT"), GetFormValue("PNREF"), GetFormValue("RESPMSG"), GetFormValue("AUTHCODE"),
                        GetFormValue("CVV2MATCH"), GetFormValue("IAVS")), referrer);

                    PaymentReceived();
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("alid Invoice ID") > 0)
                    {
                        pPaymentText.InnerHtml = String.Format(Languages.LanguageStrings.PaynetReceivedNoOrder + "</a>", "<a href=\"/ContactUs.aspx\">");
                    }
                    else
                        throw;
                }
            }
        }

        #region Private Methods

        private void PaymentReceived()
        {
            pPaymentText.InnerHtml = String.Format(Languages.LanguageStrings.OrderCompleteCreditCard + "</a>.", "<a href=\"/Account/Address/\">");
        }

        private void TransactionNotAuthorised()
        {
            pPaymentText.InnerHtml = String.Format(Languages.LanguageStrings.PaynetNotAuthorised1 + "</a>", "<a href=\"/ContactUs.aspx\">");

            pPaymentText.InnerHtml += String.Format("<p>Message: {0}<br />Details: {1} </p>", 
                GetFormValue("RESPMSG"), GetFormValue("PREFPSMSG"));

            string Msg = String.Format("Transaction Failed\n\nOrderID: {5}\n\nResult: {0}\n\nPNREF: {1}\n\nRESPMSG: {2}\n\nPREFPSMSG: {3}\n\nSYSERROR: {4}",
                GetFormValue("RESULT"), GetFormValue("PNREF"), GetFormValue("RESPMSG"), GetFormValue("PREFPSMSG"), SharedUtils.Decrypt(GetFormValue("SYSERROR")),
                GetFormValue("OrderID"));
            Msg = Msg.Replace("\n", "\r\n");

            Global.SendEMail(WebsiteSettings.ContactDetails.WebsiteEmail, WebsiteSettings.ContactDetails.WebsiteEmail, "Transaction Failed", Msg);
            Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), Msg);
        }

        #endregion Private Methods
    }
}