using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace SieraDelta.Website.Error
{
    public partial class Error : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pErrorDescription.InnerHtml = String.Format(Languages.LanguageStrings.ErrorUnexpectedDescription,
                "<a href=\"/ContactUs.aspx\">", "</a>");
        }
    }
}