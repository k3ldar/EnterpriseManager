using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Products;
using Library.BOL.Campaigns;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class PageIndex : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetUserSession().MobileRedirect)
            {
                DoRedirect("/Mobile.aspx", true);
            }

            homeBanners.Visible = Global.ShowHomeBanners;

            linkSalonBookings.Title = Languages.LanguageStrings.BookYourTreatment;
            linkSalonBookings.Visible = Global.AllowSalonBookings;

            if (!Global.AllowSalonBookings)
            {
                if (Global.ShowSalonsMenu)
                {
                    linkSalonBookings.HRef = "/Salons.aspx";
                    linkSalonBookings.Visible = true;
                }
            }

            linkSalonBookings.Attributes.Add("class", "banner4" + Global.PictureType.ToLower());
            linkSalonBookinsDiv.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";
            linkSalonBookinsSpan.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";

            linkMoisturisersDiv.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";
            linkMoisturisersSpan.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";

            linkProductsDiv.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";
            linkProductsSpan.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";

            linkCleansersDiv.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";
            linkCleansersSpan.Visible = Global.PictureType.ToUpper() != "GIFANIMATED";
        }


        protected string BannerType()
        {
            return (Global.PictureType.ToLower());
        }

        protected string BannerOverlay()
        {
            if (Global.PictureType.ToUpper() == "GIFANIMATED")
                return (String.Empty);
            else
                return ("overlay");
        }
    }
}