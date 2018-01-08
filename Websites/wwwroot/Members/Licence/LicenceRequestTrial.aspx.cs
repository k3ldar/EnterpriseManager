using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SieraDelta.Website.Members
{
    public partial class LicenceRequestTrial : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            string ipAddress = Request.UserHostAddress.ToString();

            Response.Write("999#You have already requested a trial licence for this server!");
            //Response.Write("Your trial licence");
            Response.End();
        }
    }
}