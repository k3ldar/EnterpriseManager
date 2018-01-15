using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Salons;
using Library.Utils;
using Website.Library.Classes;

namespace SieraDelta.Website.Redirect
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string webPage = GetFormValue("rd");

            if (webPage.Contains("/ETC/") || webPage.Contains("../") || webPage.ToUpper().Contains("OC/SELF/ENVI"))
            {
                Library.WebsiteAdministration.BanIPAddress(Request.UserHostAddress);
            }

            if (webPage.StartsWith("https://plus.google.com/u/0/ "))
                webPage = webPage.Replace("https://plus.google.com/u/0/ ", "https://plus.google.com/u/0/+");

            if (String.IsNullOrEmpty(webPage))
            {
                if (Request.UrlReferrer == null)
                    webPage = "/Home/";
                else
                    webPage = Request.UrlReferrer.ToString();

                DoRedirect(webPage, true);
            }
            else
            {
                //log redirect
                Library.BOL.Statistics.Statistics.UpdateRedirect(webPage);

                //redirect to website
                DoRedirect(webPage, true);
            }

        }
    }
}