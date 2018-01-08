using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.Utils;

namespace SieraDelta.Website.Members.Controls
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
                //SieraDeltaUtils u = new SieraDeltaUtils();

                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtEmail.Text), 0, Languages.LanguageStrings.Email);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtFirstName.Text), 0, Languages.LanguageStrings.FirstName);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtLastName.Text), 0, Languages.LanguageStrings.LastName);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtTelephone.Text), 0, Languages.LanguageStrings.TelephoneNumber);

                if (!SharedUtils.IsValidEmail(SharedUtils.ReplaceHTMLElements(txtEmail.Text)))
                    throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                User user = GetUser();
                user.FirstName = SharedUtils.ReplaceHTMLElements(txtFirstName.Text);
                user.LastName = SharedUtils.ReplaceHTMLElements(txtLastName.Text);
                user.Email = SharedUtils.ReplaceHTMLElements(txtEmail.Text);
                user.Telephone = SharedUtils.ReplaceHTMLElements(txtTelephone.Text);
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