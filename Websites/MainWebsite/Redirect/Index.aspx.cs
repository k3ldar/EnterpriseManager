using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Salons;
using Library.Utils;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Redirect
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

            if (!String.IsNullOrEmpty(webPage))
            {
                webPage = System.Net.WebUtility.HtmlDecode(Request.QueryString.ToString().Substring(Request.QueryString.ToString().IndexOf("rd=") + 3));
            }

            webPage = Uri.UnescapeDataString(webPage);

            if (webPage.StartsWith("https://plus.google.com/u/0/ "))
                webPage = webPage.Replace("https://plus.google.com/u/0/ ", "https://plus.google.com/u/0/+");

            if (String.IsNullOrEmpty(webPage))
            {
                if (Request.UrlReferrer == null)
                    webPage = "/Index.aspx";
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