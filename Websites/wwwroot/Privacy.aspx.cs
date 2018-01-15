using System;

using Website.Library;
using Website.Library.Classes;

namespace SieraDelta.Website
{
    public partial class Privacy : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalClass.ShowPrivacyPolicy)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Privacy Policy", divTranslated, false);
        }
    }
}