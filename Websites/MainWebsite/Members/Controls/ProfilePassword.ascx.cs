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
    public partial class ProfilePassword : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = Languages.LanguageStrings.Submit;
            lblError.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtPassword.Text), 6, Languages.LanguageStrings.CurrentPassword);
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtPasswordNew.Text), 6, Languages.LanguageStrings.NewPassword);
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtPasswordConfirm.Text), 6, Languages.LanguageStrings.ConfirmDelete);

                User user = GetUser();

                if (HSCUtils.ReplaceHTMLElements(txtPassword.Text) == user.Password)
                {
                    if (HSCUtils.ReplaceHTMLElements(txtPasswordNew.Text) == HSCUtils.ReplaceHTMLElements(txtPasswordConfirm.Text))
                    {
                        if (HSCUtils.ReplaceHTMLElements(txtPasswordNew.Text) == user.Password)
                            throw new Exception(Languages.LanguageStrings.NewPasswordSameAsOld);

                        user.Password = HSCUtils.ReplaceHTMLElements(txtPasswordNew.Text);
                        user.Save();
                        DoRedirect("/Members/Index.aspx?profileUpdated=true", true);
                    }
                    else
                        throw new Exception(Languages.LanguageStrings.NewPasswordNotConfirmed);
                }
                else
                    throw new Exception(Languages.LanguageStrings.PasswordDoesNotMatch);
            }
            catch (Exception err)
            {
                lblError.Text = err.Message;
                lblError.Visible = true;
            }
        }
    }
}