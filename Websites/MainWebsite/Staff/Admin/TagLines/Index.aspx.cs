using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.TagLines;
using Website.Library.Classes;

using Heavenskincare.WebsiteTemplate.Controls;

namespace Heavenskincare.WebsiteTemplate.Staff.Admin.TagLines
{
    public partial class Index : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.TagLines))
                DoRedirect("/Error/InvalidPermissions.aspx", true);

            LoadTags();
        }

        protected void btnUpdateMainSite_Click(object sender, EventArgs e)
        {
            DoRedirect("/admin/RefreshTags.aspx?UpdateTags=Yes");
        }

        #region Private Methods

        private void LoadTags()
        {
            foreach(TagLine tag in Library.BOL.TagLines.TagLines.Tags())
            {
                TagLineControl ctl = (TagLineControl)LoadControl("~/Staff/Controls/TagLineControl.ascx");
                ctl.Refresh(tag);
                divControls.Controls.Add(ctl);
            }
        }

        #endregion Private Methods

        protected void btnNew_Click(object sender, EventArgs e)
        {
            TagLine tag = Library.BOL.TagLines.TagLines.New();
            DoRedirect(String.Format("/Staff/Admin/TagLines/EditTagLine.aspx?ID={0}", tag.ID));
        }
    }
}