using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Countries;
using Library.BOL.CustomWebPages;

namespace SieraDelta.Website
{
    public partial class ContactUs : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCustomTranslatedPageData("Contact Us", divTranslated, false);
        }
    }
}