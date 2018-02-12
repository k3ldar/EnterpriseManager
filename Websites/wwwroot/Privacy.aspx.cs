using System;

using Website.Library.Classes;

using Library.BOL.Websites;

namespace SieraDelta.Website
{
    public partial class Privacy : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebsiteSettings.AllPages.ShowPrivacyPolicy)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Privacy Policy", divTranslated, false);
        }
    }
}