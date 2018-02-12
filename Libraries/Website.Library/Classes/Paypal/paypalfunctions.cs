using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Web;

using PayPal.Payments.Common.Utility;
using PayPal.Payments.Communication;

using lib = Library;
using Library.Utils;
using Library.BOL.Countries;
using Library.BOL.Orders;
using Library.BOL.Websites;

using Shared.Classes;

#pragma warning disable IDE1006
#pragma warning disable IDE0028

namespace Website.Library.Classes
{
    /// <summary>
    /// Summary description for NVPAPICaller
    /// </summary>
    public class NVPAPICaller
    {
        #region Private / Protected Members

        //private static readonly ILog log = LogManager.GetLogger(typeof(NVPAPICaller));

        private string pendpointurl = "https://api-3t.paypal.com/nvp";
        private const string CVV2 = "CVV2";

        //Flag that determines the PayPal environment (live or sandbox)

        private const string SIGNATURE = "SIGNATURE";
        private const string PWD = "PWD";
        private const string ACCT = "ACCT";

        //HttpWebRequest Timeout specified in milliseconds 
        private const int Timeout = 10000;
        private static readonly string[] SECURED_NVPS = new string[] { ACCT, CVV2, SIGNATURE, PWD };

        private const string VERSION = "98";

        #endregion Private / Protected Members

        #region Private Methods

        /// <summary>
        /// Credentials added to the NVP string
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        private string buildCredentialsNVPString()
        {
            NVPCodec codec = new NVPCodec();

            if (!IsEmpty(WebsiteSettings.PaymentGateways.Paypal.APIUsername))
                codec["USER"] = WebsiteSettings.PaymentGateways.Paypal.APIUsername;

            if (!IsEmpty(WebsiteSettings.PaymentGateways.Paypal.APIPassword))
                codec[PWD] = WebsiteSettings.PaymentGateways.Paypal.APIPassword;

            if (!IsEmpty(WebsiteSettings.PaymentGateways.Paypal.APISignature))
                codec[SIGNATURE] = WebsiteSettings.PaymentGateways.Paypal.APISignature;

            if (!IsEmpty(WebsiteSettings.PaymentGateways.Paypal.Subject))
                codec["SUBJECT"] = WebsiteSettings.PaymentGateways.Paypal.Subject;

            codec["VERSION"] = VERSION;

            return codec.Encode();
        }

        private NameValueCollection GetPayPalCollection(string payPalInfo)
        {
            //place the responses into collection
            NameValueCollection PayPalCollection = 
		    new System.Collections.Specialized.NameValueCollection();
            string[] ArrayReponses = payPalInfo.Split('&');

            for (int i = 0; i < ArrayReponses.Length; i++)
            {
                string[] Temp = ArrayReponses[i].Split('=');
                PayPalCollection.Add(Temp[0], Temp[1]);
            }

            return (PayPalCollection);
        }

        #endregion Private Methods

        #region Public Methods

        #region Static

        /// <summary>
        /// Returns if a string is empty or null
        /// </summary>
        /// <param name="s">the string</param>
        /// <returns>true if the string is not null and is not empty or just whitespace</returns>
        public static bool IsEmpty(string s)
        {
            return s == null || s.Trim() == string.Empty;
        }

        #endregion Static

        public bool ProcessCreditCard(string amt, string orderID, string cardNumber, string validTo, 
            string last3Digits, string currency,
            ref string returnMessage, ref string errors)
        {
            bool Result = false;

            string PayPalRequest = String.Format("TRXTYPE=S&TENDER=C&ACCT={0}&EXPDATE={1}&CVV2={2}&AMT={3}&COMMENT1=Order #{4}" +
                "&USER={5}&VENDOR={6}&PARTNER={7}&PWD={8}&CURRENCY={9}",
                cardNumber, validTo.Replace("/", ""), last3Digits, amt, orderID,
                WebsiteSettings.PaymentGateways.Payflow.PayflowUser, 
                WebsiteSettings.PaymentGateways.Payflow.PayflowVendor, 
                WebsiteSettings.PaymentGateways.Payflow.PayflowPartner,
                WebsiteSettings.PaymentGateways.Payflow.PayflowPassword, currency);

            // Create an instance of PayflowNETAPI.
            PayflowNETAPI PayflowNETAPI = new PayflowNETAPI();

            // RequestId is a unique string that is required for each & every transaction. 
            // The merchant can use her/his own algorithm to generate 
            // this unique request id or use the SDK provided API to generate this
            // as shown below (PayflowUtility.RequestId).
            string PayPalResponse = PayflowNETAPI.SubmitTransaction(PayPalRequest, PayflowUtility.RequestId);
            
            //place data from PayPal into a namevaluecollection
            NameValueCollection RequestCollection = GetPayPalCollection(PayflowNETAPI.TransactionRequest);
            NameValueCollection ResponseCollection = GetPayPalCollection(PayPalResponse);

            //show transaction errors if any
            errors = PayflowNETAPI.TransactionContext.ToString();
            returnMessage = PayPalResponse;

            Result = ResponseCollection["RESULT"] == "0";

            return (Result);
        }


        /// <summary>
        /// Sets the API Credentials
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="Pwd"></param>
        /// <param name="Signature"></param>
        /// <returns></returns>
        public void SetCredentials(string Userid, string Pwd, string Signature)
        {
            WebsiteSettings.PaymentGateways.Paypal.APIUsername = Userid;
            WebsiteSettings.PaymentGateways.Paypal.APIPassword = Pwd;
            WebsiteSettings.PaymentGateways.Paypal.APISignature = Signature;
        }


        /// <summary>
        /// ShortcutExpressCheckout: The method that calls SetExpressCheckout API
        /// </summary>
        /// <param name="amt"></param>
        /// <param ref name="token"></param>
        /// <param ref name="retMsg"></param>
        /// <returns></returns>
        public bool ShortcutExpressCheckout(string amt, string Invoice, ref string token, ref string retMsg,
            string currency, Order order, Country country, lib.BOL.Basket.Currency englishCurrency)
        {
            string host = "www.paypal.com";

            NVPCodec encoder = new NVPCodec();
            encoder["VERSION"] = VERSION;
            encoder["METHOD"] = "SetExpressCheckout";
            encoder["RETURNURL"] = WebsiteSettings.PaymentGateways.Paypal.APISuccessURL;
            encoder["CANCELURL"] = WebsiteSettings.PaymentGateways.Paypal.APIFailURL;
            encoder["AMT"] = amt;
            encoder["PAYMENTACTION"] = "Sale";
            encoder["CURRENCYCODE"] = currency;
            //encoder["INVOICE"] = "WI" + Invoice;


            encoder["PAYMENTREQUEST_0_AMT"] = amt;
            encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
            encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = currency;

            //encoder["PAYMENTREQUEST_0_ITEMAMT"] = ApplyDiscount(RemoveCurrencySymbolAndMakeUKFormat(order.OrderItems.SubTotal, englishCurrency), order);
            //encoder["PAYMENTREQUEST_0_TAXAMT"] = ApplyDiscount(RemoveCurrencySymbolAndMakeUKFormat(order.VATAmount, englishCurrency), order);
            //encoder["PAYMENTREQUEST_0_SHIPPINGAMT"] = ApplyDiscount(RemoveCurrencySymbolAndMakeUKFormat(order.ShippingCosts, englishCurrency), order);
            //encoder["PAYMENTREQUEST_0_HANDLINGAMT"] = "0.00";
            //encoder["PAYMENTREQUEST_0_INSURANCEAMT"] = "0.00";
            //encoder["PAYMENTREQUEST_n_SHIPDISCAMT"] = RemoveCurrencySymbolAndMakeUKFormat(order.DiscountAmount, englishCurrency);

            //int i = 0;

            //foreach (OrderItem item in order.OrderItems)
            //{
            //    encoder["L_PAYMENTREQUEST_0_NAME" + i.ToString()] = item.Description;
            //    //encoder["L_PAYMENTREQUEST_0_DESC" + i.ToString()] = item.Description;// String.Format("Order #{0} from www.heavenskincare.com", order.ID);
            //    encoder["L_PAYMENTREQUEST_0_AMT" + i.ToString()] =ApplyDiscount( RemoveCurrencySymbolAndMakeUKFormat(item.Cost, englishCurrency);
            //    encoder["L_PAYMENTREQUEST_0_QTY" + i.ToString()] = item.Quantity.ToString();
            //    encoder["L_PAYMENTREQUEST_0_TAXAMT" + i.ToString()] = ApplyDiscount(RemoveCurrencySymbolAndMakeUKFormat(SharedUtils.VATCalculate(item.Cost * item.Quantity, country), englishCurrency);
            //    //encoder["L_PAYMENTREQUEST_0_NUMBER" + i.ToString()] = item.ID.ToString();
            //    i++;
            //}

            encoder["L_PAYMENTREQUEST_0_NAME0"] = String.Format("Order: #{0}", Invoice);
            encoder["L_PAYMENTREQUEST_0_AMT0"] = amt;
            encoder["L_PAYMENTREQUEST_0_QTY0"] = "1";

            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            NVPCodec decoder = new NVPCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"].ToLower();

            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                token = decoder["TOKEN"];


                string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout&" + "&token=" + token;

                retMsg = ECURL;
                return true;
            }
            else
            {
                retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                    "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                    "Desc2=" + decoder["L_LONGMESSAGE0"];

                return false;
            }
        }


        /// <summary>
        /// MarkExpressCheckout: The method that calls SetExpressCheckout API, invoked from the 
        /// Billing Page EC placement
        /// </summary>
        /// <param name="amt"></param>
        /// <param ref name="token"></param>
        /// <param ref name="retMsg"></param>
        /// <returns></returns>
        public bool MarkExpressCheckout(string amt,
            string shipToName, string shipToStreet, string shipToStreet2,
            string shipToCity, string shipToState, string shipToZip,
            string shipToCountryCode, ref string token, ref string retMsg, string currency)
        {
            string host = "www.paypal.com";

            NVPCodec encoder = new NVPCodec();
            encoder["METHOD"] = "SetExpressCheckout";
            encoder["RETURNURL"] = WebsiteSettings.PaymentGateways.Paypal.APISuccessURL;
            encoder["CANCELURL"] = WebsiteSettings.PaymentGateways.Paypal.APIFailURL;
            encoder["AMT"] = amt;
            encoder["PAYMENTACTION"] = "Sale";
            encoder["CURRENCYCODE"] = currency;

            //Optional Shipping Address entered on the merchant site
            encoder["SHIPTONAME"] = shipToName;
            encoder["SHIPTOSTREET"] = shipToStreet;
            encoder["SHIPTOSTREET2"] = shipToStreet2;
            encoder["SHIPTOCITY"] = shipToCity;
            encoder["SHIPTOSTATE"] = shipToState;
            encoder["SHIPTOZIP"] = shipToZip;
            encoder["SHIPTOCOUNTRYCODE"] = shipToCountryCode;


            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            NVPCodec decoder = new NVPCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"].ToLower();
            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                token = decoder["TOKEN"];

                string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout&" + "&token=" + token;

                retMsg = ECURL;
                return true;
            }
            else
            {
                retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                    "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                    "Desc2=" + decoder["L_LONGMESSAGE0"];

                return false;
            }
        }


        /// <summary>
        /// GetShippingDetails: The method that calls SetExpressCheckout API, invoked from the 
        /// Billing Page EC placement
        /// </summary>
        /// <param name="token"></param>
        /// <param ref name="retMsg"></param>
        /// <returns></returns>
        public bool GetShippingDetails(string token, ref string PayerId,
            ref string retMsg,
            out string Street1, out string Street2, out string City,
            out string County, out string PostCode)
        {
            Street1 = String.Empty;
            Street2 = String.Empty;
            City = String.Empty;
            County = String.Empty;
            PostCode = String.Empty;

            NVPCodec encoder = new NVPCodec();
            encoder["METHOD"] = "GetExpressCheckoutDetails";
            encoder["TOKEN"] = token;

            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            NVPCodec decoder = new NVPCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"].ToLower();

            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                Street1 = decoder["SHIPTOSTREET"];
                Street2 = decoder["SHIPTOSTREET2"];
                City = decoder["SHIPTOCITY"];
                County = decoder["SHIPTOSTATE"];
                PostCode = decoder["SHIPTOZIP"];

                return true;
            }
            else
            {
                retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                    "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                    "Desc2=" + decoder["L_LONGMESSAGE0"];

                return false;
            }
        }


        /// <summary>
        /// ConfirmPayment: The method that calls SetExpressCheckout API, invoked from the 
        /// Billing Page EC placement
        /// </summary>
        /// <param name="token"></param>
        /// <param ref name="retMsg"></param>
        /// <returns></returns>
        public bool ConfirmPayment(string finalPaymentAmount, string token, string PayerId, string currency, 
            ref NVPCodec decoder, ref string retMsg)
        {
            NVPCodec encoder = new NVPCodec();
            encoder["METHOD"] = "DoExpressCheckoutPayment";
            encoder["TOKEN"] = token;
            encoder["PAYMENTACTION"] = "Sale";
            encoder["PAYERID"] = PayerId;
            encoder["AMT"] = finalPaymentAmount;
            encoder["CURRENCYCODE"] = currency;

            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            decoder = new NVPCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"].ToLower();
            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                return true;
            }
            else
            {
                retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                    "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                    "Desc2=" + decoder["L_LONGMESSAGE0"];

                return false;
            }
        }


        /// <summary>
        /// HttpCall: The main method that is used for all API calls
        /// </summary>
        /// <param name="NvpRequest"></param>
        /// <returns></returns>
        public string HttpCall(string NvpRequest) //CallNvpServer
        {
            string url = pendpointurl;

            //To Add the credentials from the profile
            string strPost = NvpRequest + "&" + buildCredentialsNVPString();
            strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode(WebsiteSettings.PaymentGateways.Paypal.BNCode);

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Timeout = Timeout;
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;

            try
            {
                using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
                {
                    myWriter.Write(strPost);
                }
            }
            catch /*(Exception e)*/
            {
                /*
                        if (log.IsFatalEnabled)
                        {
                                log.Fatal(e.Message, this);
                        }*/
            }

            //Retrieve the Response returned from the NVP API call to PayPal
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            string result;
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }

            //Logging the response of the transaction
            /* if (log.IsInfoEnabled)
                 {
                         log.Info("Result :" +
                                             " Elapsed Time : " + (DateTime.Now - startDate).Milliseconds + " ms" +
                                            result);
                 }
                 */
            return result;
        }


        #endregion Public Methods

        #region Private Methods

        private string ApplyDiscount(string amount, Order order)
        {
            decimal value = Decimal.Parse(amount);

            if (order.Discount > 0)
                value = (value / 100) * order.Discount;

            return (value.ToString());
        }

        private string RemoveCurrencySymbolAndMakeUKFormat(decimal value, lib.BOL.Basket.Currency englishCurrency)
        {
            return (SharedUtils.FormatMoney(value, englishCurrency, true, true));
        }

        #endregion Private Methods
    }
}