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
    public partial class MailListUnsubscribe : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUnsubscribe.Text = Languages.LanguageStrings.MailListUnSubscribe;

            if (!IsPostBack)
                txtEmail.Text = GetFormValue("Email");

            lblError.Visible = false;
        }

        protected void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                string email = HSCUtils.ReplaceHTMLElements(txtEmail.Text, CaseType.Lower);

                if (!Shared.Utilities.IsValidEmail(email))
                    throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                if (MailLists.UnSubscribe(HSCUtils.ReplaceHTMLElements(txtEmail.Text, CaseType.Ignore), 
                    HSCUtils.ReplaceHTMLElements(txtReason.Text, CaseType.Ignore)))
                {
                    if (OnUnsubscribe != null)
                        OnUnsubscribe(this, null);
                }
                else
                {
                    if (OnUnsubscribeFailed != null)
                        OnUnsubscribeFailed(this, null);
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

        #region Events

        public event EventHandler OnUnsubscribe;


        public event EventHandler OnUnsubscribeFailed;

        #endregion Events
    }
}