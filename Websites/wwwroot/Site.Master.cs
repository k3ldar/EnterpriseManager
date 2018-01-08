using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using SieraDelta.Library;
using SieraDelta.Website.Library.Classes;
using SieraDelta.Library.BOL.Products;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Countries;
using SieraDelta.Library.BOL.TagLines;

namespace SieraDelta.Website
{
    public partial class Site : BaseMasterClassWebForm
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            btnSearch.ServerClick += btnSearch_ServerClick;

            if (!IsPostBack)
            {
                txtSearchTerms.Text = GetSearchString();
            }

            socialFB.Visible = !String.IsNullOrEmpty(SieraDelta.Website.Global.SocialMediaFacebook);
            socialGPlus.Visible = !String.IsNullOrEmpty(SieraDelta.Website.Global.SocialMediaGPlus);
            socialRSS.Visible = !String.IsNullOrEmpty(SieraDelta.Website.Global.SocialMediaRSSFeed);
            socialTwitter.Visible = !String.IsNullOrEmpty(SieraDelta.Website.Global.SocialMediaTwitter);
        }

        protected void btnSearch_ServerClick(object sender, ImageClickEventArgs e)
        {
            Global.ValidateHackAttempt(Request, "btnSearch_ServerClick", "txtSearchTerms", txtSearchTerms.Text, Request.UserHostAddress.ToString());

            string terms = txtSearchTerms.Text;

            if (!String.IsNullOrEmpty(terms) & terms != SieraDelta.Languages.LanguageStrings.Search + "...")
            {
                DoRedirect(String.Format("/Search/SearchResults.aspx?search={0}", terms), true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetSearchString()
        {
            if (Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft)
                return ("..." + SieraDelta.Languages.LanguageStrings.Search);
            else
                return (SieraDelta.Languages.LanguageStrings.Search + "...");
        }

        protected string BaseURL()
        {
            return (SieraDelta.Website.Library.GlobalClass.RootURL);
        }
    }
}