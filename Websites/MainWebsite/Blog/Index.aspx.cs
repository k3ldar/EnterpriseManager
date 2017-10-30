using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Blog
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoRedirect(GetBlogURL());
        }
    }
}