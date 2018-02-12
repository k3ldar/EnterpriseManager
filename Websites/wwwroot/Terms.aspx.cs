using System;

using Website.Library.Classes;
using Library.BOL.Websites;

namespace SieraDelta.Website
{
    public partial class Terms : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebsiteSettings.AllPages.ShowTermsAndConditions)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Terms and Conditions", divTranslated, false);
        }
    }
}