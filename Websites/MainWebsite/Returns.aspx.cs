using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.CustomWebPages;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class ReturnsPolicy : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.ShowReturnsPolicy)
                DoRedirect("/Index.aspx");

            if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
            {
                CustomPage customPage = CustomPages.Get("Returns Policy");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
        }
    }
}