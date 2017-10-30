using System;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library;
using Library.BOL.Campaigns;

namespace Heavenskincare.WebsiteTemplate.Staff.Campaigns
{
    public partial class Index : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pError.Visible = false;

            Session["CAMPAIGN"] = null;

            btnNew.Visible = GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.SaveCampaigns);

            Library.BOL.Campaigns.Campaigns cmps = Library.BOL.Campaigns.Campaigns.Get();

            foreach (Campaign cmp in cmps)
            {
                TableRow r = new TableRow();
                tblCampaigns.Rows.Add(r);

                TableCell cName = new TableCell();
                r.Cells.Add(cName);

                bool isActive = DateTime.Now >= cmp.StartDateTime && cmp.FinishDateTime >= DateTime.Now;


                if (btnNew.Visible)
                    cName.Text = String.Format("<a href=\"/Staff/Campaigns/EditCampaign.aspx?id={0}\">{1}</a>{2}", cmp.ID, cmp.Title, isActive ? " ** active **" : "");
                else
                    cName.Text = cmp.CampaignName;

                TableCell cVisits = new TableCell();
                r.Cells.Add(cVisits);
                cVisits.Text = cmp.Visits.ToString();

                TableCell cSales = new TableCell();
                r.Cells.Add(cSales);
                cSales.Text = SharedUtils.FormatMoney(cmp.Sales, GetWebsiteCurrency());
                
                TableCell cStats = new TableCell();
                r.Cells.Add(cStats);
                cStats.Text = String.Format("<a href=\"/Staff/Reports/SEO/CampaignStats.aspx?id={0}\">Statistics</a>", 
                    cmp.ID); 
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //create a new campaign
                Library.BOL.Campaigns.Campaign campaign = Library.BOL.Campaigns.Campaigns.Create("New Campaign");

                //edit the cmpaign
                DoRedirect(String.Format("{1}/Staff/Campaigns/EditCampaign.aspx?id={0}", campaign.ID, Global.RootURL));
            }
            catch (Exception err)
            {
                if (err.Message.Contains("IDX_CAMPAIGN_STATS_NAME"))
                    pError.InnerText = "You already have a campaign called \"New Campaign\" please rename this campaign and try again";
                else
                    pError.InnerText = err.Message;

                pError.Visible = true;
            }
        }
    }
}