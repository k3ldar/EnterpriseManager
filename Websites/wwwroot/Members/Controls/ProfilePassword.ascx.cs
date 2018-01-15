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
                //SieraDeltaUtils u = new SieraDeltaUtils();

                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtPassword.Text), 6, Languages.LanguageStrings.CurrentPassword);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtPasswordNew.Text), 6, Languages.LanguageStrings.NewPassword);
                ValidateDetails(SharedUtils.ReplaceHTMLElements(txtPasswordConfirm.Text), 6, Languages.LanguageStrings.ConfirmDelete);

                User user = GetUser();

                if (SharedUtils.ReplaceHTMLElements(txtPassword.Text) == user.Password)
                {
                    if (SharedUtils.ReplaceHTMLElements(txtPasswordNew.Text) == SharedUtils.ReplaceHTMLElements(txtPasswordConfirm.Text))
                    {
                        if (SharedUtils.ReplaceHTMLElements(txtPasswordNew.Text) == user.Password)
                            throw new Exception(Languages.LanguageStrings.NewPasswordSameAsOld);

                        user.Password = SharedUtils.ReplaceHTMLElements(txtPasswordNew.Text);
                        user.Save();
                        DoRedirect("/Account/?profileUpdated=true", true);
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