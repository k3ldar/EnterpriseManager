using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Salons;

namespace SieraDelta.Website.Controls
{
    public partial class ViewSalon : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(Salon salon)
        {
            ulSalon.InnerHtml = BuildSalon(salon, -1);
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

            string img = salon.Image;
            if (!img.StartsWith("http://"))
                img = "http://www.SieraDelta.com" + img;

            Result += String.Format("<div class=\"salonImg\"><img src=\"{0}\" alt=\"{1}\" width=\"130\" /></div>", String.IsNullOrEmpty(salon.Image) ? "http://www.SieraDelta.com/images/Salons/no-salon.png" : img, salon.Name);

            string Dist = "";

            if (Distance > -1)
                Dist = String.Format("<strong>Approximately {0} miles</strong><br /><br />", Distance.ToString("0.0"));

            Result += String.Format("<div class=\"salonAddress\"><p>{2}{0}<br />{1}</p></div>", salon.Address.Replace("\r", "<br />"), salon.PostCode, Dist);

            Result += "<div class=\"salonContact\"><p>";

            if (salon.Telephone != "")
                Result += String.Format("<strong>Tel:</strong> {0}<br />", salon.Telephone);

            if (salon.Email != "")
                Result += String.Format("<strong>Email:</strong> <a href=\"mailto:{0}\">{0}</a><br />", salon.Email);

            if (salon.URL != "")
                Result += String.Format("<strong>Website:</strong> <a href=\"{0}\" target=\"_blank\">{0}</a>", salon.URL);

            Result += String.Format("</p><p><strong>Contact:</strong> {0}</p></div><div class=\"clear\"><!-- clear --></div></li>", salon.ContactName);

            Result += String.Format("<p>Type: {0}</p>", salon.SalonType.ToString());
            return (Result);
        }

    }
}