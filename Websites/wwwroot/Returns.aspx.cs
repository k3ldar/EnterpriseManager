using System;
using Website.Library.Classes;

using Library.BOL.Websites;

namespace SieraDelta.Website
{
    public partial class ReturnsPolicy : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebsiteSettings.AllPages.ShowReturnsPolicy)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Returns Policy", divTranslated, false);
        }
    }
}