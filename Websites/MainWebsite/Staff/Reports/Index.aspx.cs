using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.WebsiteReports
{
    public partial class Index : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
                DoRedirect("/Error/InvalidPermissions.aspx", true);
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            CustomerReport rpt = new CustomerReport(txtEmailAddress.Text.Replace("@", "-"), txtEmailAddress.Text);

            string fname = rpt.FileName;// "/Staff/Reports/cReports/" + txtEmailAddress.Text.Replace("@", "-");



            string path = fname; // MapPath(fname);
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "application/pdf";

            Response.AppendHeader("content-disposition",
                    "attachment; filename=" + name);
            Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();

        }
    }
}