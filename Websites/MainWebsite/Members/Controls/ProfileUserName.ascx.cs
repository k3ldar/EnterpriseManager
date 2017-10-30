using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.Utils;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
{
    public partial class ProfileUserName : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = Languages.LanguageStrings.Submit;
            lblError.Visible = false;

            if (!IsPostBack)
            {
                User user = GetUser();
                txtEmail.Text = user.Email;
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtTelephone.Text = user.Telephone;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtEmail.Text), 0, Languages.LanguageStrings.Email);
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtFirstName.Text), 0, Languages.LanguageStrings.FirstName);
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtLastName.Text), 0, Languages.LanguageStrings.LastName);
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtTelephone.Text), 0, Languages.LanguageStrings.TelephoneNumber);

                if (!Shared.Utilities.IsValidEmail(HSCUtils.ReplaceHTMLElements(txtEmail.Text)))
                    throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                User user = GetUser();
                user.FirstName = HSCUtils.ReplaceHTMLElements(txtFirstName.Text);
                user.LastName = HSCUtils.ReplaceHTMLElements(txtLastName.Text);
                user.Email = HSCUtils.ReplaceHTMLElements(txtEmail.Text);
                user.Telephone = HSCUtils.ReplaceHTMLElements(txtTelephone.Text);
                user.Save();
                DoRedirect("/Members/Index.aspx?profileUpdated=true", true);
            }
            catch (Exception err)
            {
                lblError.Text = err.Message;
                lblError.Visible = true;
            }
        }
    }
}