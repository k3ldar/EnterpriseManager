using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library;

namespace Heavenskincare.WebsiteTemplate.Staff.Admin.MetaData
{
    public partial class Index : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.MetaData))
                DoRedirect("http://www.heavenskincare.com/Error/InvalidPermissions.aspx", true);

            if (!IsPostBack)
            {
                txtDefaultDescription.Text = Library.LibraryHelperClass.SettingsGet("META_DESCRIPTION", String.Empty);
                txtDefaultKeywords.Text = Library.LibraryHelperClass.SettingsGet("META_KEYWORDS", String.Empty);
            }
        }

        protected void btnUpdateDefaultKeywords_Click(object sender, EventArgs e)
        {
            Library.LibraryHelperClass.SettingsSet("META_KEYWORDS", txtDefaultKeywords.Text);
            //Global.pa
            Library.LibraryHelperClass.SettingsSet("META_DESCRIPTION", txtDefaultDescription.Text);

            Library.LibraryHelperClass.ResetCache();
            BaseMasterClassWebForm.ResetMetaDescriptions();
        }
    }
}