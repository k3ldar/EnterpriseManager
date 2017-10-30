using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library.BOL.Distributors;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class PageDistributors : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.ShowDistributorsMenu)
                DoRedirect("/Index.aspx");

            pDescriptionA.InnerHtml = String.Format(Languages.LanguageStrings.DistributorsDescriptionA, "<a href=\"/Trade.aspx\">", "</a>");
            headerSalons.Visible = !Global.HideDistributorSalonDetails;
            salonsDescription.Visible = !Global.HideDistributorSalonDetails;
        }

        protected string BuildDistributorList()
        {
            string Result = "";

            int Page = GetFormValue("Page", 1);

            Distributors dists = Distributors.Get(Page, 6);

            foreach (Distributor dist in dists)
            {
                Result += BuildDistributor(dist);
            }

            return (Result);
        }

        private string BuildDistributor(Distributor distributor)
        {
            //
            //!!!!!!!!!!   changes here need to be made to UpdateSalon.aspx     !!!!!!!!!!!!!!
            //

            string Result = "";

            if (distributor.VIPSalon)
                Result = "<li class=\"vip\">";
            else
                Result = "<li>";

            Result += String.Format("<h3>{0}</h3>", distributor.Name);

            Result += String.Format("<div class=\"salonImg\"><img src=\"{0}\" alt=\"{1}\" width=\"130\" /></div>", distributor.Image == "" ? "/images/Salons/no-salon.gif" : distributor.Image, distributor.Name);

            string Dist = "";

            Result += String.Format("<div class=\"salonAddress\"><p>{2}{0}<br />{1}</p></div>", distributor.Address.Replace("\r", "<br />"), distributor.PostCode, Dist);

            Result += "<div class=\"salonContact\"><p>";

            if (distributor.Telephone != "")
                Result += String.Format("<strong>Tel:</strong> {0}<br />", distributor.Telephone);

            if (distributor.Email != "")
                Result += String.Format("<strong>Email:</strong> <a href=\"mailto:{0}\">{0}</a><br />", distributor.Email);

            if (distributor.URL != "")
                Result += String.Format("<strong>Website:</strong> <a href=\"/Redirect/Index.aspx?rd={0}\" target=\"_blank\">{0}</a>", distributor.URL);

            if (distributor.ContactName != "")
                Result += String.Format("</p><p><strong>Contact:</strong> {0}</p>", distributor.ContactName);

            Result += "</div><div class=\"clear\"><!-- clear --></div></li>";

            return (Result);
        }
    }
}