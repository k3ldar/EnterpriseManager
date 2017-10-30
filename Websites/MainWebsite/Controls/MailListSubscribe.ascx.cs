using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;
using Library.BOL.MailList;

using Shared;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class MailListSubscribe : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCreateAccount.Text = Languages.LanguageStrings.MailListSubscribe;

            lblError.Visible = false;

            if (!IsPostBack)
            {
                txtEmail.Text = GetFormValue("Email");
                txtName.Text = GetFormValue("Name");
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificationImage1.IsValid)
                {
                    string email = HSCUtils.ReplaceHTMLElements(txtEmail.Text, CaseType.Lower);

                    if (!Shared.Utilities.IsValidEmail(email))
                        throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                    MailLists.Subscribe(HSCUtils.ReplaceHTMLElements(txtName.Text, CaseType.Proper), email);

                    if (OnSubscribed != null)
                        OnSubscribed(this, EventArgs.Empty);
                }
            }
            catch (System.Exception Err)
            {
                lblError.Visible = true;

                if (Err.Message.IndexOf("UNQ_WS_MAIL_SUBSCRIBERS_EMAIL") > 1)
                    lblError.Text = Languages.LanguageStrings.EmailAlreadyRegistered;
                else
                    lblError.Text = Err.Message;
            }
        }

        #region Properties

        public string Email
        {
            get
            {
                return (txtEmail.Text);
            }
        }

        #endregion Properties

        #region Delegates

        public event EventHandler OnSubscribed;

        #endregion Delegates
    }
}