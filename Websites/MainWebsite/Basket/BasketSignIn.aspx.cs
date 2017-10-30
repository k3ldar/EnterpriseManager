using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Shared.Classes;
using Website.Library.Classes;
using Library.BOL.Coupons;

using Heavenskincare.WebsiteTemplate.Controls;

namespace Heavenskincare.WebsiteTemplate.Basket
{
    public partial class BasketSignIn : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetUser() != null)
                DoRedirect("/Basket/BasketDeliveryAddress.aspx", true);

            CreateAccount1.AfterCreateAccount += new Members.Controls.CreateAccount.AfterCreateAccountDelegate(CreateAccount1_AfterCreateAccount);
            MemberLogin1.AfterLogin += new Members.Controls.MemberLogin.AfterLoginArgs(MemberLogin1_AfterLogin);
        }

        private void MemberLogin1_AfterLogin(object sender, EventArgs e)
        {
            // if the user has a basket code, which is single use, and they have used it previously,
            // redirect them to a new page telling them so, 
            UserSession session = GetUserSession();
            LocalWebSessionData lData = (LocalWebSessionData)session.Tag;

            // no coupon then move on...
            if (String.IsNullOrEmpty(lData.Basket.DiscountCouponName))
                DoRedirect("/Basket/BasketDeliveryAddress.aspx", false);

            Coupon cpn = Coupons.Get(lData.Basket.DiscountCouponName);

            if (cpn != null && cpn.RestrictUserUsage &&
                lData.CurrentUser.Invoices.VoucherUsed(lData.Basket.DiscountCouponName))
            {
                lData.Basket.ApplyDiscount(0, String.Empty);
                DoRedirect("/Basket/Basket.aspx?message=The coupon you entered has already been used.", false);
            }
            else
            {
                DoRedirect("/Basket/BasketDeliveryAddress.aspx", false);
            }
        }

        private void CreateAccount1_AfterCreateAccount(object sender, Members.Controls.CreateAccount.CreateAccountArgs e)
        {
            //if the user did not login then will be automatically redirected to login page
            DoRedirect("/Basket/BasketDeliveryAddress.aspx", false);
        }
    }
}