using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heavenskincare.WebsiteTemplate.Error
{
    public partial class Insecure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetSecureLink()
        {
            return (String.Format(Languages.LanguageStrings.InvalidPermissionDescription, "http://tinyurl.com/nmu7djf"));
        }
    }
}