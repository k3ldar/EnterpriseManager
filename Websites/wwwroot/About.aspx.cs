using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.CustomWebPages;

namespace SieraDelta.Website
{
    public partial class PageAbout : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCustomTranslatedPageData("About Us", divTranslated, false);
        }
    }
}