using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Website.Library.Classes;
using Library.BOL.TagLines;

namespace SieraDelta.Website.Staff.Admin.TagLines
{
    public partial class EditTagLine : BaseWebFormStaff
    {
        private TagLine _tag;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.TagLines))
                DoRedirect("/Site-Error/Invalid-Permission/", true);

            Int64 id = GetFormValue("ID", -1);
            _tag = Library.BOL.TagLines.TagLines.Find(id);

            if (_tag == null)
                DoRedirect("/Admin/TagLines/Index.aspx");

            if (!IsPostBack)
            {
                txtTagLine.Text = _tag.Text;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _tag.Text = txtTagLine.Text;
            _tag.Save();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Library.BOL.TagLines.TagLines.Delete(_tag);
            DoRedirect("/Admin/TagLines/Index.aspx");
        }
    }
}