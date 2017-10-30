using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

using Library.BOL.Accounts;
using Library.BOL.Orders;

using Shared.Classes;


namespace Website.Library.Classes.PaymentOptions
{
    public abstract class BasePaymentOption
    {
        /// <summary>
        /// Returns the accepted currencies for the payment option, seperated by ;
        /// 
        /// i.e.  GPB;USD  or GBP  or GBP;USD;EUR
        /// </summary>
        /// <returns>i.e.  GPB;USD  or GBP  or GBP;USD;EUR</returns>
        public abstract string Currencies();

        /// <summary>
        /// Test Execute Method for debugging
        /// </summary>
        /// <returns></returns>
        public abstract string ExecuteTest(NVPCodec codec);

        /// <summary>
        /// Abstract execute method
        /// </summary>
        /// <param name="order"></param>
        /// <param name="paymentStatus"></param>
        /// <param name="webSession"></param>
        /// <param name="webRequest"></param>
        /// <param name="webResponse"></param>
        /// <param name="userSession"></param>
        public abstract void Execute(Order order, PaymentStatus paymentStatus,
            HttpSessionState webSession, HttpRequest webRequest,
            HttpResponse webResponse, UserSession userSession);

    }
}
