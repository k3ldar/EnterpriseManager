using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Error
{
    public partial class InvalidPermissions : BaseWebForm
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