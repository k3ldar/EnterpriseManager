using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.SessionState;

using Website.Library.Classes.Paypoint;

using lib = Library;
using Library.Utils;
using Library.BOL.Accounts;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Orders;

using Shared.Classes;

namespace Website.Library.Classes.PaymentOptions
{
    public sealed class PaymentOptionPaynet : BasePaymentOption
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

                if (localData.CurrentUser != null)
                {
                    if (order == null)
                        throw new Exception("Invalid Order, can not find order during payment (Paypoint)");

                    if (order != null)
                    {
                        Country country = localData.UserCountry;
                        Currency currency = lib.BOL.Basket.Currencies.Get(new CultureInfo(order.Culture));

                        // regardless of which currency, amounts to paypal are always formatted in English with symbol removed
                        Currency englishCurrency = lib.BOL.Basket.Currencies.Get(new CultureInfo("en-GB"));

                        // set the conversion rate/multiplier to the native one
                        englishCurrency.Multiplier = currency.Multiplier;
                        englishCurrency.ConversionRate = currency.ConversionRate;

                        string amt = SharedUtils.FormatMoney(order.TotalCost, englishCurrency, true, true);

                        if (amt == SharedUtils.FormatMoney(country.ShippingCosts, englishCurrency, true))
                            throw new Exception("Error with order, shipping cost only detected!");


                        if (order.TotalCost != 0.00m)
                        {
                            ValCard vc = new ValCard(localData.CurrentUser, order.ID.ToString(), 
                                Shared.Utilities.StrToDbl(amt), "GBP");

                            string ret;
                            ret = vc.GetURL();
                            webResponse.Redirect(ret, false);
                        }
                    }
                }
                else
                    webResponse.Redirect("/Basket/BasketSignIn.aspx", false);
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
            return (ValCard.Currencies);
        }
    }
}
