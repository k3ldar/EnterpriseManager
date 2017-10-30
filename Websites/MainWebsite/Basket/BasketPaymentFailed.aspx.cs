using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.BOL.Orders;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Accounts;

using PayPal.Payments;

namespace Heavenskincare.WebsiteTemplate.Basket
{
    public partial class BasketPaymentFailed : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancelOrder.Text = Languages.LanguageStrings.CancelOrder;
            btnContactUs.Text = Languages.LanguageStrings.ContactUs;
            btnPayNow.Text = Languages.LanguageStrings.PayNow;
        }

        protected void btnPayNow_Click(object sender, EventArgs e)
        {
            if (UserIsLoggedOn())
            {
                Int64 orderID = (Int64)Session["INVOICE_NUMBER"];

                Order order = Orders.Get(orderID);
                PaymentStatuses.ExecutePaymentMethod(order, order.Status, Session, Request, Response, GetUserSession());
            }
            else
                DoRedirect("/Basket/BasketSignIn.aspx");
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Int64 InvoiceID = (Int64)Session["INVOICE_NUMBER"];
            Order order = Library.BOL.Orders.Orders.Get(InvoiceID);

            if (order != null)
                order.Status = PaymentStatuses.Get("Cancelled");

            DoRedirect("/Products.aspx");
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            Int64 InvoiceID = (Int64)Session["INVOICE_NUMBER"];
            Order order = Library.BOL.Orders.Orders.Get(InvoiceID);

            if (order != null)
                order.Status = PaymentStatuses.Get("Phone Not Paid");

            DoRedirect("/Basket/BasketOrderComplete.aspx?InternalPaymentType=pbf");
        }
    }
}