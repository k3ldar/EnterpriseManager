using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Website.Library.Classes.PaymentOptions;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class DebugTestOnly : BaseWebFormAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PaymentOptionSunTechBuySafe cp = new PaymentOptionSunTechBuySafe();
            try
            {
                PaymentOptionSunTechBuySafe.MerchantPassword = "S1512149038";
                PaymentOptionSunTechBuySafe.MerchantID = "88888888";
                cp.Execute(Library.BOL.Orders.Orders.Get(104942),
                    Library.BOL.Accounts.PaymentStatuses.Get(1),
                    Session, Request, Response, GetUserSession());
            }
            finally
            {
                cp = null;
            }
        }
    }
}