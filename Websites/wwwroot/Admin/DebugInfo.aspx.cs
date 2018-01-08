using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using webLib = Website.Library;

namespace SieraDelta.Website.Admin
{
    public partial class DebugInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            webLib.Classes.Web.DebugInfo.PrintDebugInfo(Session, Request, Response);
        }
    }
}