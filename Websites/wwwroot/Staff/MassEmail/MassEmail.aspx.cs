using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.BOL.Countries;

namespace SieraDelta.Website.WebsiteMassEmail
{
    public partial class MassEmail : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.SendMassEmail))
            {
                DoRedirect("/Error/InvalidPermissions.aspx", true);
            }

            if (!IsPostBack && GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.SendMassEmailSalonOwners))
            {
                ListItem item = new ListItem("All Salon Owners", "5");
                cmbRecipients.Items.Add(item);
            }

            if (!IsPostBack && GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.SendMassEmailAllUsers))
            {
                ListItem item = new ListItem("All Members", "0");
                cmbRecipients.Items.Add(item);
            }

            if (!IsPostBack)
                LoadCountries();
        }

        private void LoadCountries()
        {
            ListItem item = new ListItem("All Countries", "-1");
            cmbCountry.Items.Add(item);

            foreach (Country country in Countries.Get())
            {
                cmbCountry.Items.Add(new ListItem(country.Name, country.ID.ToString()));
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Int64 Sent = 0;
            MemberLevel level = (MemberLevel)Enum.Parse(typeof(MemberLevel), cmbRecipients.SelectedValue, true);

            if (cmbCountry.SelectedValue == "-1")
            {
                if (cbAdvancedSend.Checked)
                {
                    Sent = Library.BOL.Mail.Emails.MassEmail(txtTitle.Text, txtMessage.Text, level, true);
                }
                else
                {
                    Sent = Library.BOL.Mail.Emails.MassEmail(GetUser(), txtTitle.Text, txtMessage.Text, level);
                }
            }
            else
            {
                Sent = Library.BOL.Mail.Emails.MassEmail(txtTitle.Text, txtMessage.Text, Countries.Get(Convert.ToInt32(cmbCountry.SelectedValue)));
            }

            pMsg.InnerText = String.Format("{0} Messages Sent at {1}", Sent, DateTime.Now.ToString());
        }

        protected void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAdvancedSend.Enabled = cmbCountry.SelectedIndex == 0;
            cmbRecipients.Enabled = cmbCountry.SelectedIndex == 0;
        }
    }
}