using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.BOL.Products;
using Website.Library;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
{
    public partial class MemberLogout : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAccountLogout.Text = Languages.LanguageStrings.Logout;

            if (GetUser() == null)
                DoRedirect("/Members/Login.aspx", true);
        }

        protected void btnAccountLogout_Click(object sender, EventArgs e)
        {
            SharedWebBase.CookieSetValue(Request, Response, 
                String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, Global.DistributorWebsite),
                "-1", DateTime.Now.AddYears(-10));

            SharedWebBase.UserLogout(Session, Request, GetUserSession());

            LocalizedLanguages.SetLanguage(Session, Request, Response, 
                Library.BOL.Countries.Countries.Get(GetUserCountry()), 
                SharedWebBase.WebsiteCurrency(Session, Request), false);

            DoRedirect("/Index.aspx");
            
        }
    }
}