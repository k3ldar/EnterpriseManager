using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Languages;
using Shared.Classes;
using Website.Library.Classes;
using Library;
using Library.BOL.TagLines;
using Library.BOL.Products;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class Mobile : BaseWebForm
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            pMobileSite.InnerHtml = String.Format("<a href=\"{0}\">{1}</a>",
                String.Format("/Mobile/Switch.aspx?m=False&l={0}", Request.RawUrl),
                Languages.LanguageStrings.SwitchToDesktopSite);

            if (!IsPostBack)
            {
                txtSearchTerms.Text = GetSearchString();
            }

            UpdateSocialMediaIcons();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUserSession().MobileRedirect)
            {
                DoRedirect("/Index.aspx", true);
            }
                    
            btnSearch.ServerClick += btnSearch_ServerClick;

            if (!IsPostBack)
            {
                txtSearchTerms.Text = GetSearchString();
            }

            Page.Header.DataBind();  
            divTagLine.InnerHtml = String.Format("&ldquo;&nbsp;{0}&nbsp;&rdquo;", TagLines.RandomTagLine().Text);
        }

        protected string GetProductGroupsHome()
        {
            string Result = String.Empty;

            Result += GetProductCategories(false, true);

            Result += "\r\n<li class=\"Other\"><a href=\"http://heavenbydeborahmitchell.wordpress.com/\"><span>&nbsp;</span>Read Deborah's blog</a></li>";

            if (Global.ShowSalonFinder)
            {
                Result += String.Format("\r\n<li class=\"Other\"><a href=\"/Salons.aspx\"><span>{0}</a></li>",
                    Languages.LanguageStrings.Salons);
            }

            if (Global.ShowAppointments)
            {
                Result += String.Format("\r\n<li class=\"Other\"><a href=\"/Appointments/Index.aspx\"><span>{0}</a></li>",
                    Languages.LanguageStrings.BookAppointment);
            }

            Result = Result.Replace("</span><br />", " ").Replace("</a>", "</span></a>").Replace("&nbsp;</span>", "");
            Result = Result.Replace("<span>", "<span><div class=\"fullHeight\">").Replace("</span>", "</div></span>");
            return (Result.Replace("<span style=\"vertical-align: bottom;\">", "<span><div class=\"fullHeight\" style=\"vertical-align: bottom;\">"));
        }

        protected string GetSearchString()
        {
            if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                return ("..." + Languages.LanguageStrings.Search);
            else
                return (Languages.LanguageStrings.Search + "...");
        }

        private void UpdateSocialMediaIcons()
        {
            socialFB.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaFacebook);
            socialTwitter.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaTwitter);
            socialGPlus.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaGPlus);
            socialRSS.Visible = !String.IsNullOrEmpty(Heavenskincare.WebsiteTemplate.Global.SocialMediaRSSFeed);
        }

        protected void btnSearch_ServerClick(object sender, ImageClickEventArgs e)
        {
            string terms = txtSearchTerms.Text;

            if (!String.IsNullOrEmpty(terms) & terms != Languages.LanguageStrings.Search + "...")
            {
                DoRedirect(String.Format("/Search/SearchResults.aspx?search={0}", terms), true);
            }
        }

        protected string GetTermsAndConditions()
        {
            string Result = String.Empty;

            if (BaseWebApplication.ShowTermsAndConditions)
                Result = String.Format(" - <a href=\"/Terms.aspx\">{0}</a>", Languages.LanguageStrings.Terms);

            return (Result);
        }

        protected string GetPrivacyPolicy()
        {
            string Result = String.Empty;

            if (BaseWebApplication.ShowPrivacyPolicy)
                Result = String.Format(" - <a href=\"/Privacy.aspx\">{0}</a>", Languages.LanguageStrings.Privacy);

            return (Result);
        }

        protected string GetReturnsPolicy()
        {
            string Result = String.Empty;

            if (BaseWebApplication.ShowReturnsPolicy)
                Result = String.Format(" - <a href=\"/Returns.aspx\">{0}</a>", Languages.LanguageStrings.Returns);

            return (Result);
        }

        protected string GetCookieConsent()
        {
            string Result = String.Empty;

            if (Request.Cookies["cookieconsent_dismissed"] != null)
                return (Result);

            if (true)
            {
                Result = "<script type=\"text/javascript\" src=\"/js/cookieconsent.min.js\"></script>\r\n" +
                    "<script type=\"text/javascript\">" +
                    "window.cookieconsent_options = { \"message\": \"" + LanguageStrings.CookieMessage + "\", \"dismiss\": \"" +
                    LanguageStrings.CookieAccept + "\", \"learnMore\": \"More info\", \"link\": null, \"theme\": \"dark-bottom\" };" +
                    "</script>";

                //Result = String.Format(Result, , );
            }

            return (Result);
        }

        protected string GetGoogleAnalyticsCode()
        {
            return (BaseWebApplication.GoogleAnalytics);
        }

        protected string GetMobileOnlyScripts()
        {
            string Result = String.Empty;

            try
            {
                UserSession session = GetUserSession();

                if (session.MobileRedirect)
                {
                    Result = "<script type=\"text/javascript\"> " +
                        "$(document).ready(function () { " +
                        "p = navigator.platform; " +
                        "if (p === 'iPad' || p === 'iPhone' || p === 'iPod') { " +
                        "$(\"div.navigation\").each(function () { " +
                        "var onClick;  " +
                        "var firstClick = function () { " +
                        "onClick = secondClick; " +
                        "return false; }; " +
                        "var secondClick = function () { " +
                        "onClick = firstClick; " +
                        "return true; }; " +
                        "onClick = firstClick; " +
                        "$(this).click(function () { " +
                        "return onClick(); " +
                        "}); }); } }); </script> ";

                    Result += "<script type=\"text/javascript\">function openToolbar() { var tb = document.getElementById(\"leftToolbar\"); " +
                        "tb.style.width = \"176px\";" +
                        "tb.style.border = \"2px solid #111\";" +
                        "tb.style.padding = \"6px 6px 6px 6px\"; document.getElementById(\"divMobileShowColumn\").className = \"mobileShowColumnHidden\"; } " +
                        "function closeToolbar() { var tb = document.getElementById(\"leftToolbar\"); tb.style.width = \"0\";" +
                        "tb.style.border = \"0px\";" +
                        "tb.style.padding = \"0px\"; document.getElementById(\"divMobileShowColumn\").className = \"mobileShowColumn\";}</script>";

                    Result += "<script type=\"text/javascript\"> function openNavigation() { " +
                        " var x = document.getElementById(\"topNav\"); var sub = document.getElementById(\"subMenu\"); " +
                        " if (x.className === \"topNav\") { x.className += \" responsive\"; sub.className = \"subShow\"; " +
                        " } else { x.className = \"topNav\"; sub.className = \"sub\"; } } </script>";
                }
            }
            catch //(Exception err)
            {

            }

            return (Result);
        }
    }
}