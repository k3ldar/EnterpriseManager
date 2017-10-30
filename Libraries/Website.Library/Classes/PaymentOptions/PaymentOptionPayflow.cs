using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.SessionState;

using PayPal.Payments;

using lib = Library;
using Library.Utils;
using Library.BOL.Accounts;
using Library.BOL.Basket;
using Library.BOL.Users;
using Library.BOL.Countries;
using Library.BOL.Orders;

using Shared.Classes;

namespace Website.Library.Classes.PaymentOptions
{
    public sealed class PaymentOptionPayflow : BasePaymentOption
    {

        /// <summary>
        /// Debug Execute Methods
        /// </summary>
        /// <returns></returns>
        public override string ExecuteTest(NVPCodec codec)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes the payment method
        /// </summary>
        /// <param name="order">Order being changed/updated</param>
        /// <param name="paymentStatus">Payment Status being set</param>
        /// <param name="webRequest">HTTP Web Request</param>
        /// <param name="webResponse">HTTP Web Response</param>
        public override void Execute(Order order, PaymentStatus paymentStatus,
            HttpSessionState webSession, HttpRequest webRequest,
            HttpResponse webResponse, UserSession userSession)
        {
            try
            {
                LocalWebSessionData localData = (LocalWebSessionData)userSession.Tag;

                if (localData.CurrentUser == null)
                    throw new Exception("User is not logged in.");

                if (order == null)
                    throw new Exception("Invalid Order, can not find order during payment (Payflow)");

                Country country = localData.UserCountry;
                Currency currency = lib.BOL.Basket.Currencies.Get(new CultureInfo(order.Culture));

                // regardless of which currency, amounts to paypal are always formatted in English with symbol removed
                Currency englishCurrency = lib.BOL.Basket.Currencies.Get(new CultureInfo("en-GB"));

                // set the conversion rate/multiplier to the native one
                englishCurrency.Multiplier = currency.Multiplier;
                englishCurrency.ConversionRate = currency.ConversionRate;

                string amt = SharedUtils.FormatMoney(order.TotalCost, englishCurrency, true, true);

                string message = String.Empty;
                string errors = String.Empty;

                NVPAPICaller caller = new NVPAPICaller();

                CreditCard card = (CreditCard)webSession["CREDIT_CARD_DETAILS"];

                caller.ProcessCreditCard(amt, order.ID.ToString(), card.CardNumberDecoded(localData.CurrentUser), card.ValidTo,
                    card.Last3Digits, currency.CurrencyCode, ref message, ref errors);

                webResponse.Redirect(String.Format("/Basket/BasketCC.aspx?{0}&OrderID={1}&SYSERROR={2}", 
                    message, order.ID, Shared.Utilities.Encrypt(errors)), false);
            }
            catch (Exception err)
            {
                lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err,
                    order, paymentStatus, webSession, webRequest, webResponse);

                throw;
            }
        }


        public override string Currencies()
        {
            return (NVPAPICaller.DefaultCurrency);
        }
    }
}
