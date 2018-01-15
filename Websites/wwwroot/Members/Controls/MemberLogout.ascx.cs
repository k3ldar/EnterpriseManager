using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.Utils;

namespace SieraDelta.Website.Members.Controls
{
    public partial class MemberLogout : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAccountLogout.Text = Languages.LanguageStrings.Logout;

            if (GetUser() == null)
                DoRedirect("/Account/Login/", true);
        }

        protected void btnAccountLogout_Click(object sender, EventArgs e)
        {
            SharedWebBase.CookieSetValue(Request, Response, 
                String.Format("SD{0}Session", Global.DistributorWebsite), "-1", 
                DateTime.Now.AddYears(-10));

            SharedWebBase.UserLogout(Session, Request, GetUserSession());

            LocalizedLanguages.SetLanguage(Session, Request, Response,
                Library.BOL.Countries.Countries.Get(GetUserCountry()),
                SharedWebBase.WebsiteCurrency(Session, Request), false);

            DoRedirect("/Home/");
        }
    }
}