using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

using lib = Library;
using Library.BOL.Accounts;
using Library.BOL.Orders;

using Shared.Classes;

namespace Website.Library.Classes.PaymentOptions
{
    /// <summary>
    /// Payment class for an invoice that has already been paid and merely 
    /// redirects user to the invoices section of the website
    /// </summary>
    public sealed class PaymentOptionRedirectInvoices : BasePaymentOption
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
                webResponse.Redirect(GlobalClass.RootURL + "/Members/Invoices.aspx", false);
            }
            catch (Exception err)
            {
                lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err,
                    order, paymentStatus, webSession, webRequest, webResponse);

                throw;
            }
        }

        /// <summary>
        /// This method should not be called in this context as it 
        /// is used for invoices that have already been paid
        /// </summary>
        /// <returns></returns>
        public override string Currencies()
        {
            throw new NotImplementedException();
        }
    }
}
