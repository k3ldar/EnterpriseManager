using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Helpdesk;

namespace SieraDelta.Website.Helpdesk
{
    public partial class Feedback : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetFeedback()
        {
            string Result = "";

            string feedbackPage = (string)Page.RouteData.Values["page"] ?? "1";

            CustomerComments comments = CustomerComments.Get(Shared.Utilities.StrToInt(feedbackPage, 1), 6);

            foreach (CustomerComment comment in comments)
            {
            	Result += String.Format("<blockquote>{0}<cite>- {1}</cite></blockquote>", comment.Comments, comment.UserName);
            }

            if (String.IsNullOrEmpty(Result))
                Result = String.Format("<p>{0}</p>", Languages.LanguageStrings.BeFirstForFeedback);

            return (Result);
        }
    }
}