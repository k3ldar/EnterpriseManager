using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;

namespace Heavenskincare.Helpdesk.Controls
{
    public partial class LeaveFeedback : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            btnSubmit.Text = Languages.LanguageStrings.Submit;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificationImage1.IsValid)
                {
                    ValidateDetails(txtName.Text, 0, Languages.LanguageStrings.Name);
                    ValidateDetails(txtComments.Text, 0, Languages.LanguageStrings.Comments);

                    long userid = GetUserID();
                    string user = HSCUtils.ReplaceHTMLElements(txtName.Text);
                    string comments = HSCUtils.ReplaceHTMLElements(txtComments.Text);

                    Library.BOL.Helpdesk.CustomerComments.Add(GetUser(), user, comments);
                    DoRedirect("/Helpdesk/Feedback.aspx", true);
                }
            }
            catch (Exception err)
            {
                lblError.Text = err.Message;
                lblError.Visible = true;
            }
        }
    }
}