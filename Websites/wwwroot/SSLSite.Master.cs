using System;
using System.Web.UI;
using System.Threading;

using Website.Library.Classes;
using Library.BOL.Websites;
using Shared.Classes;

#pragma warning disable IDE1006

namespace SieraDelta.Website
{
    public partial class SSLSite : BaseMasterClassWebForm
	{
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            aHomeLogo.Title = "";
            aHomeLogo.InnerText = "";

            if (!Request.IsLocal && Request.Url.ToString().ToLower().StartsWith("http://") && WebsiteSettings.UseHTTPS)
            {
                Response.Redirect(Request.Url.ToString().ToLower().Replace("http://", "https://"));
            }

            if (!Request.IsLocal && Request.Url.ToString().ToLower().StartsWith("https://") && !WebsiteSettings.UseHTTPS)
            {
                Response.Redirect(Request.Url.ToString().ToLower().Replace("https://", "http://"));
            }


            btnSearch.ServerClick += btnSearch_ServerClick;

            if (!IsPostBack)
            {
                txtSearchTerms.Text = GetSearchString();
            }

            socialFB.Visible = !String.IsNullOrEmpty(WebsiteSettings.SocialMedia.Facebook.Url);
            socialGPlus.Visible = !String.IsNullOrEmpty(WebsiteSettings.SocialMedia.Google.GPlus);

            UserSession session = GetUserSession();

            liMobileNavigator.Visible = session.MobileRedirect;

            if (Global.AllowMobileWebsite && session.IsMobileDevice)
            {
                pMobileSite.Visible = true;

                if (session.MobileRedirect)
                {
                    pMobileSite.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>",
                        String.Format("/Mobile/Switch.aspx?m=False&l={0}", Request.RawUrl),
                        Languages.LanguageStrings.SwitchToDesktopSite);
                }
                else
                {
                    pMobileSite.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>",
                        String.Format("/Mobile/Switch.aspx?m=True&l={0}", Request.RawUrl),
                        Languages.LanguageStrings.SwitchToMobileSite);
                }
            }
            else
            {
                pMobileSite.Visible = false;
            }

        }

        protected void btnSearch_ServerClick(object sender, ImageClickEventArgs e)
        {
            string terms = txtSearchTerms.Text;

            if (!String.IsNullOrEmpty(terms) & terms != Languages.LanguageStrings.Search + "...")
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
                return ("..." + Languages.LanguageStrings.Search);
            else
                return (Languages.LanguageStrings.Search + "...");
        }

        protected string BaseURL()
        {
            return (Library.BOL.Websites.WebsiteSettings.RootURL);
        }
    }
}