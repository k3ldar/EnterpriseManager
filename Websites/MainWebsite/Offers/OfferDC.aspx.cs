using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.Orders;
using Library.BOL.Coupons;
using Library.BOL.Basket;
using Website.Library.Classes;
using Library.BOL.Accounts;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class OfferDC : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pError.Visible = false;
            divSuccess.Visible = false;
            divOffer.Visible = true;

            string code = GetFormValue("code", String.Empty);

            if (Session["DCCODE"] == null || (string)Session["DCCODE"] == "")
                Session["DCCODE"] = code;

            string dcCode = Session["DCCODE"].ToString();

                if (!IsPostBack)
                    txtDCCode.Text = dcCode;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //validate code
                Coupon cpn = Coupons.Get(txtDCCode.Text);

                if (cpn == null)
                    throw new Exception("Invalid coupon code");

                if (cpn.VoucherUsage > 0)
                    throw new Exception("Coupon has already been used");

                if (cpn.VoucherType != Library.Enums.InvoiceVoucherType.SpecialOffer)
                    throw new Exception("Invalid coupon code");

                //clear existing basket
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.Basket.Empty();

                //add special items
                localData.Basket.Add(Library.BOL.Products.ProductCosts.Get(1852), 1, GetUser(),
                    Enums.BasketType.Product, localData.Basket.Currency.PriceColumn);
                localData.Basket.Add(Library.BOL.Products.ProductCosts.Get(1858), 1, GetUser(),
                    Enums.BasketType.Product, localData.Basket.Currency.PriceColumn);


                string resultText = String.Empty;
                localData.Basket.ValidateCouponCode(cpn.Name, ref resultText);

                Order order = localData.Basket.ConvertToOrder(PaymentStatuses.Get("Credit Card Not Paid"), Session.SessionID, 
                    Request.ServerVariables["REMOTE_HOST"], WebCountry.Culture);
                order.Status = PaymentStatuses.Get("Credit Card Paid");

                divOffer.Visible = false;
                divSuccess.Visible = true;

                Session["DCCODE"] = cpn.Name;
            }
            catch (Exception err)
            {
                pError.Visible = true;
                pError.InnerText = err.Message;
            }
        }
    }
}