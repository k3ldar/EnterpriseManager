using System;

using Website.Library.Classes;
using Library.BOL.Websites;

namespace SieraDelta.Website
{
    public partial class PageTrade : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebsiteSettings.AllPages.ShowTradePage)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Trade Advantage", divTranslated, true);

            
        }
    }
}