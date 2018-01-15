using System;
using System.Threading;
using System.Web.UI;
using Website.Library;
using Website.Library.Classes;
using Library.BOL.Products;
using Library.Utils;
using Library.BOL.USAStates;
using Library.BOL.Countries;
using Library.BOL.TagLines;
using Library.BOL.Distributors;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class Home : BaseWebForm
    {
        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.AllowHomePage)
                DoRedirect("/Index.aspx");

            Country country = Countries.Get(GetUserCountry());

            if (country != null)
            {
                if (!String.IsNullOrEmpty(country.AutoRedirect))
                {
                    Response.Redirect(country.AutoRedirect, true);
                }
            }

            if (!Request.IsLocal && Request.Url.ToString().ToLower().StartsWith("https://"))
            {
                Response.Redirect(Request.Url.ToString().ToLower().Replace("https://", "http://"));
            }

            btnSearch.ServerClick += btnSearch_ServerClick;

            if (!IsPostBack)
            {
                txtSearchTerms.Text = GetSearchString();
                SelectDefaultCountry();
            }

            divTagLine.InnerHtml = String.Format("<img src=\"/images/Speech-mark.png\" alt=\"I\" style=\"top: -12px;\" />{0}&nbsp;&rdquo;", 
                TagLines.RandomTagLine().Text);
        }

        protected string GetAmericanStates()
        {
            string Result = "";

            USStates states = USStates.Get();

            foreach (USState state in states)
            {
                if (state.Name != "UNKNOWN")
                    Result += String.Format("<li><a href=\"{0}\">{1}</a></li>", state.RedirectURL, state.Name);
            }

            return (Result);
        }

        protected string GetDistributorCountries(string continent)
        {
            string Result = "";

            WebsiteDistributors distributors = WebsiteDistributors.Get();

            foreach (WebsiteDistributor dist in distributors)
            {
                if (dist.Continent == continent)
                {
                    Result += String.Format("<li><a href=\"{0}\">{1}</a></li>", dist.URL, dist.Name);
                }
            }

            return (Result);
        }

        protected string GetStyleSheet()
        {
            if (GlobalClass.UseLeftToRight) // || Request.Path.Contains("/Staff/"))
                return (String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />", 
                    GlobalClass.StyleSheet));
            else
                return (String.Format("<link property=\"stylesheet\" rel=\"stylesheet\" href=\"/css/{0}\" type=\"text/css\" media=\"screen\" />", 
                    GlobalClass.StyleSheet.Replace(".css", "rtl.css")));
        }

        /// <summary>
        /// Returns the featured product for a primary product type
        /// </summary>
        /// <param name="primaryProductType"></param>
        /// <returns>string</returns>
        protected string GetFeaturedProduct(ProductType primaryProductType)
        {
            string Result;
            Product featured = Library.BOL.Products.Products.GetFeatured();
            int priceColumn = ((LocalWebSessionData)GetUserSession().Tag).PriceColumn;

            Result = String.Format("<a href=\"/Products/Product.aspx?ID={0}\">", featured.ID);
            Result += String.Format("<img src=\"https://static.heavenskincare.com/images/products/{0}_148.jpg\" alt=\"\" border=\"0\" width=\"148\" height=\"114\"/>", featured.Image);

            if (ShowPriceData)
            {
                decimal cost = featured.LowestPrice(SharedWebBase.WebsiteCurrency(Session, Request), priceColumn, WebCountry);

                if (BaseWebApplication.PricesIncludeVAT)
                {
                    cost += SharedUtils.VATCalculate(cost, WebVATRate);
                }

                if (primaryProductType == ProductTypes.Get("Stratosphere"))
                {
                    Result += String.Format("<p>{0}<strong>{2} {1}</strong></p></a>",
                        featured.Name, SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                        Languages.LanguageStrings.From);
                }
                else
                {
                    Result += String.Format("{0}<strong>{2} {1}</strong></a>",
                        featured.Name, SharedUtils.FormatMoney(cost, GetWebsiteCurrency(), false),
                        Languages.LanguageStrings.From);
                }
            }
            else
                Result += String.Format("{0}</a>", featured.Name);

            if (primaryProductType == ProductTypes.Get("Stratosphere"))
                Result = Result.Replace(".jpg", ".png").Replace("/Products/Product.aspx", "/Products/Stratosphere.aspx");

            return (Result);
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
        protected string ShowDistributors()
        {
            if (!Global.ShowDistributorsMenu)
                return (String.Empty);

            return (String.Format("<li><a href=\"/Distributors.aspx\">{1}</a></li>", Global.RootURL, Languages.LanguageStrings.Distributors));
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

        #endregion Protected Methods

        #region Private Methods

        private void SelectDefaultCountry()
        {
            string currCountry = GetUserCountry();

            foreach (WebsiteDistributor dist in WebsiteDistributors.Get())
            {
                if (currCountry == dist.CountryCode && dist.IsActive)
                {
                    if (dist.AutoRedirect)
                    {
                        DoRedirect(dist.URL, true);
                    }
                }
            }
        }

        private void btnSearch_ServerClick(object sender, ImageClickEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearchTerms.Text) & txtSearchTerms.Text != "Search...")
            {
                DoRedirect(String.Format("/Search/SearchResults.aspx?search={0}", txtSearchTerms.Text), true);
            }
        }

        #endregion Private Methods

    }
}