using System;
using System.Web.UI.WebControls;
using Website.Library.Classes;
using Shared;

namespace SieraDelta.Website.Members.Controls
{
    public partial class LicenceRequestTrial : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCreateTrialLicence.Text = Languages.LanguageStrings.LicenceCreateTrial;

            if (!IsPostBack)
            {
                ddlLicenceType.Items.Clear();

                foreach (LicenceType lType in Enum.GetValues(typeof(LicenceType)))
                {
                    if (!Library.BOL.Licencing.Licences.HasTrialLicence(GetUser(), lType))
                    {
                        ListItem item = new ListItem(lType.ToString(), ((int)lType).ToString());
                        ddlLicenceType.Items.Add(item);
                    }
                }

                this.Visible = AvailableCount > 0;
            }
        }

        /// <summary>
        /// Returns the total number of trial licences available
        /// </summary>
        public int AvailableCount
        {
            get
            {
                return (ddlLicenceType.Items.Count);
            }
        }

        protected void btnCreateTrialLicence_Click(object sender, EventArgs e)
        {
            ListItem selected = ddlLicenceType.Items[ddlLicenceType.SelectedIndex];
            LicenceType trialType = (LicenceType)Convert.ToInt32(selected.Value);
            Library.BOL.Licencing.Licences.CreateTrial(GetUser(), trialType);
            DoRedirect("/Account/Licences/", true);
        }
    }
}