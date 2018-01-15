using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using Website.Library;
using Website.Library.Classes;
using Library.BOL.Products;
using Library.Utils;
using Library.BOL.Countries;
using Shared.Classes;

using AjaxControlToolkit;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class SSLSite : BaseMasterClassWebForm
	{
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            CountryLanguageSelect1.Visible = LocalizedLanguages.Active;

            if (LocalizedLanguages.Active)
            {
                CountryLanguageSelect1.ShowFlags = Global.ShowLanguageFlag;
                CountryLanguageSelect1.ShowLanguageSelector = Global.ShowLanguageSelector;
                CountryLanguageSelect1.ShowCurrencySelector = Global.ShowCurrencySelector;
            }

            divShoppingCart.Visible = !Global.HideShoppingCart;

            if (!Request.IsLocal && Request.Url.ToString().ToLower().StartsWith("http://") && Global.UseHTTPS)
            {
                Response.Redirect(Request.Url.ToString().ToLower().Replace("http://", "https://"));
            }

            btnSearch.ServerClick += btnSearch_ServerClick;

            if (!IsPostBack)
            {
                txtSearchTerms.Text = GetSearchString();
            }

            UserSession session = GetUserSession();

            liMobileNavigator.Visible = session.MobileRedirect;
            liSearch.Visible = liMobileNavigator.Visible;
            hCategories.Visible = !liMobileNavigator.Visible;

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

            string script = GetAffiliateHeader();

            if (!String.IsNullOrEmpty(script))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "affiliate", script, false);
            }
        }

        protected string GetAffiliateHeader()
        {
            if (Global.AffiliateIncludeExternal && !String.IsNullOrEmpty(Global.AffiliateStandardHeader))
                return (String.Format("<script type=\"text/javascript\">{0}</script>", Global.AffiliateStandardHeader));
            else
                return (String.Empty);
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
            try
            {
                Page.Header.DataBind();
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
                Response.Redirect("/Error/ServerTooBusy.aspx", true);
            }
		}

        protected string GetSearchString()
        {
            if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                return ("..." + Languages.LanguageStrings.Search);
            else
                return (Languages.LanguageStrings.Search + "...");
        }

        protected string BaseURL()
        {
            return (GlobalClass.RootURL);
        }


        /// <summary>
        /// Returns menu if Treatments are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowTreatments()
        {
            if (!Global.ShowTreatmentsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Treatments.aspx\">{1}</a></li>", Global.RootURL, Languages.LanguageStrings.Treatments));
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowSalons()
        {
            if (!Global.ShowSalonsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Salons.aspx\">{1}</a></li>", Global.RootURL, Languages.LanguageStrings.Salons));
        }

        /// <summary>
        /// Returns menu if salons are shown or not
        /// </summary>
        /// <returns></returns>
        protected string ShowTipsAndTricks()
        {
            if (!Global.ShowTipsAndTricksMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/TipsnTricks.aspx\">{1}</a></li>", Global.RootURL, Languages.LanguageStrings.TipsAndTricks));
        }
	}
}