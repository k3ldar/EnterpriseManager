using System;
using System.Web;
using System.Web.SessionState;

using lib = Library;
using Library.BOL.Accounts;
using Library.BOL.Orders;
using Library.BOL.Websites;

using Shared.Classes;

namespace Website.Library.Classes.PaymentOptions
{
    public sealed class PaymentOptionTestPurchase : BasePaymentOption
    {
        #region Static Properties

        /// <summary>
        /// Currencies supported by ChinaPay
        /// </summary>
        public static string SupportedCurrencies { get; set; }

        #endregion Static Properties

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
                webResponse.Redirect(WebsiteSettings.RootURL + "/Shopping/Basket/Order-Complete/Payment-Type/testpayment/", false);
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
            return (SupportedCurrencies);
        }
    }
}
