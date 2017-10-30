using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Campaigns;
using Library.BOL.SEO;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Staff.Reports.SEO
{
    public partial class CampaignStats : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Campaign cmp = Campaign.Get(GetFormValue("id", -1));

            if (cmp == null)
                DoRedirect("/staff/campaigns/Index.aspx", true);

            SeoReports reports = SeoReports.SEOCampaign(cmp);
            chartCampaign.AutoUpdate(cmp, reports);
        }
    }
}