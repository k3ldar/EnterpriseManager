using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library;
using Website.Library.Classes;

namespace SieraDelta.Website
{
    public partial class Terms : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalClass.ShowTermsAndConditions)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Terms and Conditions", divTranslated, false);
        }
    }
}