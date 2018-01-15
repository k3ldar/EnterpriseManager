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
    public partial class ReturnsPolicy : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalClass.ShowReturnsPolicy)
                DoRedirect("/Home/");

            UpdateCustomTranslatedPageData("Returns Policy", divTranslated, false);
        }
    }
}