using System;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;

using Shared;

namespace SieraDelta.Website.Members.Controls
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


            //SieraDeltaUtils u = new SieraDeltaUtils();
            User user = Library.BOL.Users.User.UserGet(SharedUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Ignore),
                SharedUtils.ReplaceHTMLElements(txtPassword.Text, CaseType.Ignore));

            if (user == null)
            {
                ShowError(Languages.LanguageStrings.InvalidUsernameOrPassword);
                return;
            }

            if (Library.BOL.Users.User.UserLogUserOn(user))
            {
                SharedWebBase.CookieSetValue(Request, Response, 
                    String.Format("SD{0}Session", Global.DistributorWebsite),
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

            // does the password exist?
            //SieraDeltaUtils u = new SieraDeltaUtils();

            User user = Library.BOL.Users.User.UserGet(SharedUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Upper));

            if (user == null)
            {
                ShowError(String.Format("{1}: {0}", SharedUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Ignore), Languages.LanguageStrings.NoRecordExists));
                return;
            }

            string MailMessage = String.Format("Hi {0}<br /><br />At {1} from IP Address: " +
                "{2} you requested your Login Details for Heaven Health & Beauty Ltd Member Area " +
                "<br /><br />Your User Name and Password are:<br /><br />--------------------------------" +
                "<br />Username: {3}<br />Password: {4}<br />--------------------------------<br /><br />" +
                "To login to the members area visit {5}/Account/Login/" +
                "<br /><br />Thanks<br /><br />Heaven Health & Beauty Ltd", user.FirstName,
                DateTime.Now.ToString("dd/MM/yyyy"), Request.ServerVariables["REMOTE_HOST"], 
                SharedUtils.ReplaceHTMLElements(txtUsername.Text, CaseType.Ignore), user.Password, Global.RootURL);

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

        #region Properties

        public bool SignupVisible
        {
            get
            {
                return (aSignUpLink.Visible);
            }

            set
            {
                aSignUpLink.Visible = value;
            }
        }

        #endregion Properties
    }
}