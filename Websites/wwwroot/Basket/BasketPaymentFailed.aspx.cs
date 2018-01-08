using System;

using Library.BOL.Orders;
using Library.BOL.Accounts;

using Website.Library.Classes;

#pragma warning disable IDE1006

namespace SieraDelta.Website.Basket
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
                int InvoiceID = (int)Session["INVOICE_NUMBER"];

                Order order = Orders.Get(InvoiceID);
                PaymentStatuses.ExecutePaymentMethod(order, order.Status, Session, Request, Response, GetUserSession());
            }
            else
                DoRedirect("/Shopping/Basket/SignIn/");
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            int InvoiceID = (int)Session["INVOICE_NUMBER"];
            Order order = Library.BOL.Orders.Orders.Get(InvoiceID);

            if (order != null)
                order.Status = PaymentStatuses.Get("Cancelled");

            DoRedirect("/All-Products/");
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            int InvoiceID = (int)Session["INVOICE_NUMBER"];
            Order order = Library.BOL.Orders.Orders.Get(InvoiceID);

            if (order != null)
                order.Status = PaymentStatuses.Get("Phone Not Paid");

            DoRedirect("/Shopping/Basket/Order-Complete/Payment-Type/pbf/");
        }
    }
}