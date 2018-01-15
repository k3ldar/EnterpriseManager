using System;

using Website.Library;
using Website.Library.Classes;

namespace SieraDelta.Website
{
    public partial class PageTrade : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalClass.ShowTradePage)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Trade Advantage", divTranslated, true);

            
        }
    }
}