using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Orders;
using Library.BOL.Countries;
using Library.BOL.Accounts;

namespace SieraDelta.Website.Basket
{
    public partial class BasketPayByPaypal : BaseWebFormMember
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
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            int InvoiceID = (int)Session["INVOICE_NUMBER"];
            Order inv = Orders.Get(InvoiceID);
            DoRedirect("/Members/Index.aspx");
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            int InvoiceID = (int)Session["INVOICE_NUMBER"];
            Order inv = Orders.Get(InvoiceID);
            inv.Status = PaymentStatuses.Get("Phone Not Paid");
            DoRedirect("/Shopping/Basket/Order-Complete/Payment-Type/pbf/");
        }
    }
}