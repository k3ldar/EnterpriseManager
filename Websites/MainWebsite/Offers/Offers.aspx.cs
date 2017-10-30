using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Campaigns;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class Offers : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetOffers()
        {
            string Result = String.Empty;

            Campaigns currentCampaigns = Campaign.GetActive(Library.BOL.Countries.Countries.Get(GetUserCountry()));

            foreach (Campaign currentCampaign in currentCampaigns)
            {
                if (currentCampaign != null)
                {
                    string OfferImage = "";

                    if (!String.IsNullOrEmpty(currentCampaign.ImageOffersPage))
                        OfferImage = String.Format("<h2>{1}</h2><img src=\"{0}\" border=\"0\" alt=\"\" />", 
                            currentCampaign.ImageOffersPage, currentCampaign.Title);

                    Result += String.Format("<p>{0}</p><p>{1}</p>",
                        OfferImage, currentCampaign.OffersPageText.Replace("\r\n", "<br />"));
                }
            }

            if (String.IsNullOrEmpty(Result))
                Result = String.Format("<p>{0}</p>", Languages.LanguageStrings.NoOffers);

            return (Result);
        }
    }
}