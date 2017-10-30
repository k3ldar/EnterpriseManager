using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Helpdesk;

namespace Heavenskincare.WebsiteTemplate.Helpdesk
{
    public partial class Feedback : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetFeedback()
        {
            string Result = "";

            CustomerComments comments = CustomerComments.Get(GetFormValue("Page", 1), 6);

            foreach (CustomerComment comment in comments)
            {
            	Result += String.Format("<blockquote>{0}<cite>- {1}</cite></blockquote>\r\n", comment.Comments, comment.UserName);
            }

            if (String.IsNullOrEmpty(Result))
                Result = String.Format("<p>{0}</p>", Languages.LanguageStrings.BeFirstForFeedback);

            return (Result);
        }
    }
}