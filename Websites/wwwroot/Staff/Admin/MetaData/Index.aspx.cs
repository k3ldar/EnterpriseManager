using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library;

namespace SieraDelta.Website.Staff.Admin.MetaData
{
    public partial class Index : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.MetaData))
                DoRedirect("/Site-Error/Invalid-Permission/", true);

            if (!IsPostBack)
            {
                txtDefaultDescription.Text = Library.LibraryHelperClass.SettingsGetMeta("META_DESCRIPTION");
                txtDefaultKeywords.Text = Library.LibraryHelperClass.SettingsGetMeta("META_KEYWORDS");
            }
        }

        protected void btnUpdateDefaultKeywords_Click(object sender, EventArgs e)
        {
            Library.LibraryHelperClass.SettingsSetMeta("META_KEYWORDS", txtDefaultKeywords.Text);
            //Global.pa
            Library.LibraryHelperClass.SettingsSetMeta("META_DESCRIPTION", txtDefaultDescription.Text);

            Library.LibraryHelperClass.ResetCache();
            BaseMasterClassWebForm.ResetMetaDescriptions();
        }
    }
}