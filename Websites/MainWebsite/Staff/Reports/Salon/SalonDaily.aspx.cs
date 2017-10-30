using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Therapists;
using Reports.Salons;

namespace Heavenskincare.WebsiteTemplate.Staff.Reports.Salon
{
    public partial class SalonDaily : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Members/InvalidPermissions.aspx");
                return;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Therapists salonTherapists = Therapists.Get();
            Therapists therapists = new Therapists();

            foreach (Therapist therapist in salonTherapists)
            {
                if (therapist.Group.Description == "Shifnal Salon")
                    therapists.Add(therapist);
            }

            string path = PDFSalonReport.CurrentPath.Replace("bin", "staff\\Reports\\cReports");
            PDFDailySalonReport rpt = new PDFDailySalonReport(calDate.SelectedDate.Date, calDate.SelectedDate.Date, therapists, path);

            string fname = rpt.FileName;



            path = fname; // MapPath(fname);
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