using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Admin
{
    public partial class RefreshTags : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Library.BOL.TagLines.TagLines.Reset();
            if (GetFormValue("UpdateTags") == "Yes")
                Library.BOL.TagLines.TagLines.Reset();
        }
    }
}