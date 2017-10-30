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
using Library.BOL.Countries;
using Library.BOL.Orders;

using Shared.Classes;

namespace Website.Library.Classes.PaymentOptions
{
    public sealed class PaymentOptionPaypal : BasePaymentOption
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

                NVPAPICaller test = new NVPAPICaller();
                string retMsg = "";
                string token = "";

                if (order == null)
                    throw new Exception("Invalid Order, can not find order during payment (Paypal)");

                if (order != null)
                {
                    Country country = localData.UserCountry;
                    Currency currency = lib.BOL.Basket.Currencies.Get(new CultureInfo(order.Culture));

                    // regardless of which currency, amounts to paypal are always formatted in English with symbol removed
                    Currency englishCurrency = lib.BOL.Basket.Currencies.Get(new CultureInfo("en-GB"));

                    // set the conversion rate/multiplier to the native one
                    englishCurrency.Multiplier = currency.Multiplier;
                    englishCurrency.ConversionRate = currency.ConversionRate;


                    // always get the total cost using en-GB as paypal does not accept , as a seperator for currencies which
                    // some languages support
                    string amt = SharedUtils.FormatMoney(order.TotalCost, englishCurrency, true, true);

                    bool ret;

                    try
                    {
                        if (amt == SharedUtils.FormatMoney(country.ShippingCosts, englishCurrency, true))
                            throw new Exception("Error with order, shipping cost only detected!");

                        Country payCountry = order.User.Country;

                        if (order.OriginalCountry != order.User.Country.ID)// | order.CurrencyChanged)
                            payCountry = Countries.Get(lib.DAL.DALHelper.DefaultCountry);

                        ret = test.ShortcutExpressCheckout(amt, order.ID.ToString(), ref token, ref retMsg,
                            currency.CurrencyCode, order, payCountry, englishCurrency);

                        if (ret)
                        {
                            webSession["token"] = token;
                            webResponse.Redirect(retMsg, false);
                        }
                        else
                        {
                            webResponse.Redirect("/Basket/BasketPaymentFailed.aspx", false);
                        }
                    }
                    catch (Exception err)
                    {
                        if (err.Message == "boo!")
                        {
                        }

                        Country payCountry = order.User.Country;

                        if (order.OriginalCountry != order.User.Country.ID)// | order.CurrencyChanged)
                            payCountry = Countries.Get(lib.DAL.DALHelper.DefaultCountry);

                        // try again just in case...
                        ret = test.ShortcutExpressCheckout(amt, order.ID.ToString(), ref token, ref retMsg,
                            currency.CurrencyCode, order, payCountry, englishCurrency);

                        if (ret)
                        {
                            webSession["token"] = token;
                            webResponse.Redirect(retMsg, false);
                        }
                        else
                        {
                            webResponse.Redirect("/Basket/BasketPaymentFailed.aspx", false);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err,
                    order, paymentStatus, webSession, webRequest, webResponse);

                throw;
            }
        }

        public bool Redirect()
        {
            return (false);
        }

        public string RedirectURL()
        {
            return (String.Empty);
        }

        public override string Currencies()
        {
            return (NVPAPICaller.DefaultCurrency);
        }
    }
}
