using System;
using System.Web.UI;

using Library.BOL.Salons;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Websites;
using Shared;

namespace SieraDelta.Website
{
    public partial class PageSalons : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebsiteSettings.AllPages.ShowSalonsMenu)
                DoRedirect("/Home/");

            frmSalonFinder.Visible = WebsiteSettings.AllPages.ShowSalonFinder;
            headerSalons.Visible = WebsiteSettings.AllPages.ShowSalonFinder;

            btnFindSalon.Text = Languages.LanguageStrings.Search;
            //headerClients.Visible = GlobalClass.ShowClientHeader;
            headerSalons.Visible = WebsiteSettings.AllPages.ShowSalonHeader;
        }

        protected int GetSalonPage()
        {
            return (SharedUtils.StrToInt((string)Page.RouteData.Values["page"], 1));
        }

        protected int GetSalonID()
        {
            return (SharedUtils.StrToInt((string)Page.RouteData.Values["id"], -1));
        }

        protected string BuildSalonList()
        {
            string Result = "";
            Salon salonID = Salons.Get(GetSalonID());

            //are we after 1 specific salon?
            if (salonID != null)
            {
                Result = BuildSalon(salonID, -1);
                frmSalonFinder.Visible = false;
            }
            else
            {
                if (IsPostBack && txtPostCode.Text != "")
                {
                    //postcode search
                    Result = FindNearestSalons();
                }
                else
                {
                    int Page = GetSalonPage();

                    Salons salons = Salons.Get(Page, 6);

                    foreach (Salon salon in salons)
                    {
                        Result += BuildSalon(salon, -1);
                    }
                }
            }

            return (Result);
        }

        private string FindNearestSalons()
        {
            string Result = "";

            string Postcode = SharedUtils.ReplaceHTMLElements(txtPostCode.Text, CaseType.Upper);

            if (Shared.Utilities.IsValidUKPostcode(Postcode, out Postcode))
            {
                try
                {
                    //only need first part of post code
                    Postcode = Postcode.Substring(0, Postcode.IndexOf(" "));
                    Salons salons = Salons.FindNearest(Postcode);

                    if (salons.Count == 0)
                        return (Languages.LanguageStrings.InvalidPostcode);

                    foreach (Salon salon in salons)
                    {
                        double Distance = Shared.Utilities.ConvertKMtoMiles(salon.Distance);

                        Result += BuildSalon(salon, Distance);
                    }
                }
                catch
                {
                    return (Languages.LanguageStrings.InvalidPostcode);
                }
            }
            else
            {
                return (Languages.LanguageStrings.InvalidPostcode);
            }

            return (Result);
        }

        private string BuildSalon(Salon salon, double Distance)
        {
            //
            //!!!!!!!!!!   changes here need to be made to UpdateSalon.aspx     !!!!!!!!!!!!!!
            //

            string Result = "";

            if (salon.VIPSalon)
                Result = "<li class=\"vip\">";
            else
                Result = "<li>";

            Result += String.Format("<h3>{0}</h3>", salon.Name);

            Result += String.Format("<div class=\"salonImg\"><img src=\"{0}\" alt=\"{1}\" width=\"130\" /></div>", salon.Image == "" ? "/images/Salons/no-salon.gif" : salon.Image, salon.Name);

            string Dist = "";

            if (Distance > -1)
                Dist = String.Format(String.Format("<strong>{0}</strong><br /><br />", Languages.LanguageStrings.ApproximateDistance), Distance.ToString("0.0"));

            Result += String.Format("<div class=\"salonAddress\"><p>{2}{0}<br />{1}</p></div>", salon.Address.Replace("\r", "<br />"), salon.PostCode, Dist);
            
            Result += "<div class=\"salonContact\"><p>";
            
            if (salon.Telephone != "")
                Result += String.Format("<strong>{1}:</strong> {0}<br />", salon.Telephone, Languages.LanguageStrings.Telephone);

            if (salon.Email != "")
                Result += String.Format("<strong>{1}:</strong> <a href=\"mailto:{0}\">{0}</a><br />", salon.Email, Languages.LanguageStrings.Email);
                    
            if (salon.URL != "")
                Result += String.Format("<strong>{1}:</strong> <a href=\"/Redirect/Index.aspx?rd={0}\" target=\"_blank\">{0}</a>", salon.URL, Languages.LanguageStrings.Website);

            string openingTimes = String.Empty;

            if (salon.HasOpeningTimes)
            {
                openingTimes = String.Format("<div class=\"openingHours\"><h3>{0}</h3><ul>", Languages.LanguageStrings.OpeningTimes);

                if (!String.IsNullOrEmpty(salon.OpeningMonday))
                    openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Monday, salon.OpeningMonday);

                if (!String.IsNullOrEmpty(salon.OpeningTuesday))
                    openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Tuesday, salon.OpeningTuesday);

                if (!String.IsNullOrEmpty(salon.OpeningWednesday))
                    openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Wednesday, salon.OpeningWednesday);

                if (!String.IsNullOrEmpty(salon.OpeningThursday))
                    openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Thursday, salon.OpeningThursday);
                
                if (!String.IsNullOrEmpty(salon.OpeningFriday))
                    openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Friday, salon.OpeningFriday);

                if (!String.IsNullOrEmpty(salon.OpeningSaturday))
                    openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Saturday, salon.OpeningSaturday);

                if (!String.IsNullOrEmpty(salon.OpeningSunday))
                    openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Sunday, salon.OpeningSunday);

                openingTimes += "</ul></div>";
            }

            Result += String.Format("</p><p><strong>{1}:</strong> {0}</p>{2}</div><div class=\"clear\"><!-- clear --></div></li>", salon.ContactName, Languages.LanguageStrings.Contact, openingTimes);

            return (Result);
        }
    }
}