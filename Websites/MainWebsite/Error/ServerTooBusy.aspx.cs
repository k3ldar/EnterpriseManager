using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heavenskincare.WebsiteTemplate.Error
{
    public partial class ServerTooBusy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string TelephoneNumber()
        {
            return (Global.WebsiteTelephoneNumber);
        }

        protected string Email()
        {
            return (Global.WebsiteEmail);
        }
    }
}