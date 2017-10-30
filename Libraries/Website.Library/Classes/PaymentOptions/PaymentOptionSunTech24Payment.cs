using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.SessionState;

using lib = Library;
using Library.Utils;
using Library.BOL.Accounts;
using Library.BOL.Basket;
using Library.BOL.Users;
using Library.BOL.Countries;
using Library.BOL.Orders;

using Shared;
using Shared.Classes;

namespace Website.Library.Classes.PaymentOptions
{
    public class PaymentOptionSunTech24Payment : BasePaymentOption
    {
        #region Static Properties

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

        #endregion Static Properties

        #region Public Static Methods


        public static string CreateCheckValue(string finalPaymentAmount)
        {
            string Result = String.Format("{0}{1}{2}", MerchantID, MerchantPassword, finalPaymentAmount); //S1512149038

            Result = Hash(Result);

            return (Result);
        }

        public static string CreateCheckValue(string buysafeCode, string finalPaymentAmount)
        {
            string Result = String.Format("{0}{1}{2}{3}", MerchantID, MerchantPassword, buysafeCode, finalPaymentAmount);

            Result = Hash(Result);

            return (Result);
        }

        #endregion Public Static Methods

        #region Public Methods

        public override string ExecuteTest(NVPCodec codec)
        {
            return (ConfirmPayment(codec));
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
                    throw new Exception("Invalid Order, can not find order during payment (ChinaPay)");

                Country country = localData.UserCountry;
                Currency currency = lib.BOL.Basket.Currencies.Get(new CultureInfo(order.Culture));

                // regardless of which currency, amounts to paypal are always formatted in English with symbol removed
                Currency englishCurrency = lib.BOL.Basket.Currencies.Get(new CultureInfo("en-GB"));

                // set the conversion rate/multiplier to the native one
                englishCurrency.Multiplier = currency.Multiplier;
                englishCurrency.ConversionRate = currency.ConversionRate;

                string amt = SharedUtils.FormatMoney(order.TotalCost,
                    lib.BOL.Basket.Currencies.Get(new CultureInfo("en-GB")), true, true);

                if (amt == SharedUtils.FormatMoney(country.ShippingCosts, 
                    lib.BOL.Basket.Currencies.Get(new CultureInfo(order.Culture)), true))
                    throw new Exception("Error with order, shipping cost only detected!");

                string message = String.Empty;
                string errors = String.Empty;

                CreditCard card = (CreditCard)webSession["CREDIT_CARD_DETAILS"];

                Country payCountry = order.User.Country;

                if (order.OriginalCountry != order.User.Country.ID)
                    payCountry = Countries.Get(lib.DAL.DALHelper.DefaultCountry);

                ConfirmPayment(webResponse, order, amt.Replace(".", "").Replace(",", ""));
            }
            catch (Exception err)
            {
                if (!TestMode)
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err,
                        order, paymentStatus, webSession, webRequest, webResponse);

                throw;
            }
        }


        public override string Currencies()
        {
            return (SupportedCurrencies);
        }

        #endregion Public Methods

        #region Private Methods

        private static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        private string GetOrderInfo(Order order)
        {
            string Result = String.Format("{0} Items", order.OrderItems.Count);

            if (Result.Length > 399)
                Result = Result.Substring(0, 398);

            return (Result);
        }

        private string ConfirmPayment(NVPCodec encoder)
        {
            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = String.Empty;

            try
            { 
                string url = "https://www.esafe.com.tw/Service/Etopm.aspx";

                if (TestMode)
                    url = "https://test.esafe.com.tw/Service/Etopm.aspx";

                pStresponsenvp = Shared.Communication.HttpPost.Post(url, pStrrequestforNvp);

                return (String.Format("Request:\r\n{0}\r\n\r\nResponse:\r\n{1}", pStrrequestforNvp, pStresponsenvp));
            }
            catch (Exception err)
            {
                pStresponsenvp = err.Message;
                return (String.Format("Request:\r\n{0}\r\n\r\nResponse:\r\n{1}", pStrrequestforNvp, pStresponsenvp));
            }
        }

        private void ConfirmPayment(HttpResponse response, Order order, string finalPaymentAmount)
        {
            NVPCodec encoder = new NVPCodec();
            encoder["web"] = MerchantID;
            encoder["MN"] = finalPaymentAmount;
            encoder["OrderInfo"] = GetOrderInfo(order);
            encoder["Td"] = order.ID.ToString();
            encoder["sna"] = order.User.FirstName;
            encoder["sdt"] = order.User.Telephone.Replace(" ", "");
            encoder["email"] = order.User.Email;
            encoder["note1"] = String.Format("Order {0}", order.ID);
            encoder["note2"] = String.Format("Order {0}", order.ID);
            encoder["DueDate"] = DateTime.Now.AddDays(DueDateDays).ToString("yyyyMMdd");

            int i = 1;

            Currency currency = lib.BOL.Basket.Currencies.Get(new CultureInfo("en-gb"));

            if (order.ShippingCosts > 0.00m)
            {
                encoder[String.Format("ProductName{0}", i)] = "Postage";
                encoder[String.Format("ProductPrice{0}", i)] = SharedUtils.FormatMoney(order.ShippingCosts, currency, true).Replace(",", "").Replace(".", "");
                encoder[String.Format("ProductQuantity{0}", i)] = "1";

                i++;
            }

            foreach (OrderItem item in order.OrderItems)
            {
                encoder[String.Format("ProductName{0}", i)] = Shared.Validation.Validate(item.Description, ValidationTypes.AlphaNumeric);
                encoder[String.Format("ProductPrice{0}", i)] = SharedUtils.FormatMoney(item.Cost, currency, true).Replace(",", "").Replace(".", "");
                encoder[String.Format("ProductQuantity{0}", i)] = item.Quantity.ToString();

                i++;

                if (i > 10)
                    break;
            }

            encoder["ChkValue"] = CreateCheckValue(finalPaymentAmount);

            string url = "https://www.esafe.com.tw/Service/Etopm.aspx";

            if (TestMode)
                url = "https://test.esafe.com.tw/Service/Etopm.aspx";

            Shared.Communication.HttpPost.PostRedirect(response, url, encoder);
        }

        #endregion Private Methods
    }
}
