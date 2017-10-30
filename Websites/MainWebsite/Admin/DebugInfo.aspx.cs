using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Basket;
using webLib = Website.Library.Classes.Web;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Admin
{
    public partial class DebugInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            webLib.DebugInfo.PrintDebugInfo(Session, Request, Response);
        }
    }
}