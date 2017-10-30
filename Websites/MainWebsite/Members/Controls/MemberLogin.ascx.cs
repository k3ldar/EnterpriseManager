using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.BOL.Products;
using Library.BOL.SEO;

using Shared;
using Shared.Classes;
using Website.Library;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
{
    public partial class MemberLogin : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Text = Languages.LanguageStrings.Login;
            btnLostPassword.Text = Languages.LanguageStrings.ForgotPassword;
            lblError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                ShowError(Languages.LanguageStrings.PleaseEnterUsername);
                return;
            }

            if (txtPassword.Text.Length == 0)
            {
                ShowError(Languages.LanguageStrings.PleaseEnterPassword);
                return;
            }

            User user = Library.BOL.Users.User.UserGet(HSCUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Ignore),
                HSCUtils.ReplaceHTMLElements(txtPassword.Text, CaseType.Ignore));

            if (user == null)
            {
                ShowError(Languages.LanguageStrings.InvalidUsernameOrPassword);
                return;
            }

            if (Library.BOL.Users.User.UserLogUserOn(user))
            {
                SharedWebBase.CookieSetValue(Request, Response, 
                    String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, Global.DistributorWebsite),
                    user.ID.ToString(), DateTime.Now.AddDays(60));

                Session["CURRENT_USER"] = user;

                SharedWebBase.UserLogin(Session, user, Request, Response, GetUserSession());

                RaiseAfterLogin();
            }
            else
            {
                ShowError(Languages.LanguageStrings.InvalidUsernameOrPassword);
            }
        }

        protected void btnLostPassword_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                ShowError(Languages.LanguageStrings.PleaseEnterUserNameOrEmail);
                return;
            }

            if (!txtUsername.Text.Contains("@"))
            {
                ShowError(Languages.LanguageStrings.InvalidEmailAddress);
                return;
            }

            // does the password exist?
            User user = Library.BOL.Users.User.UserGet(HSCUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Upper));

            if (user == null)
            {
                ShowError(String.Format("{1}: {0}", HSCUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Ignore), Languages.LanguageStrings.NoRecordExists));
                return;
            }

            string MailMessage = String.Format("Hi {0}<br /><br />At {1} from IP Address: " +
                "{2} you requested your Login Details for Heaven Health & Beauty Ltd Member Area " +
                "<br /><br />Your User Name and Password are:<br /><br />--------------------------------" +
                "<br />Username: {3}<br />Password: {4}<br />--------------------------------<br /><br />" +
                "To login to the members area visit {5}/Members/Login.aspx" +
                "<br /><br />Thanks<br /><br />Heaven Health & Beauty Ltd", user.FirstName,
                DateTime.Now.ToString("dd/MM/yyyy"), Request.ServerVariables["REMOTE_HOST"], 
                HSCUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Ignore), user.Password, Global.RootURL);

            Global.SendEMail(user.UserName, user.Email,
                Languages.LanguageStrings.MemberAccountDetails, MailMessage,
                Global.SupportName, Global.SupportEMail);
            ShowError(Languages.LanguageStrings.LoginDetailsSentByEmail);
        }

        #region Private Methods

        private void ShowError(string Error)
        {
            lblError.Visible = true;
            lblError.Text = Error;
        }

        private void RaiseAfterLogin()
        {
            if (AfterLogin != null)
                AfterLogin(this, new EventArgs());
        }

        #endregion Private Methods

        #region Delegates

        public delegate void AfterLoginArgs(object sender, EventArgs e);

        #endregion Delegates

        #region Events

        public event AfterLoginArgs AfterLogin;

        #endregion Events

    }
}