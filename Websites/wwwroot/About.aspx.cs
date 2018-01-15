using System;

using Website.Library.Classes;

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