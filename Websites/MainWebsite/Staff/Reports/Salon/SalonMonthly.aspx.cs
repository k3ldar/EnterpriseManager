using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Therapists;
using Reports.Salons;

namespace Heavenskincare.WebsiteTemplate.Staff.Reports.Salon
{
    public partial class SalonMonthly : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Members/InvalidPermissions.aspx");
                return;
            }

            if (!IsPostBack)
            {
                DateTime start = new DateTime(2013, 3, 1);
                DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                lstMonth.Items.Clear();

                while (end > start)
                {
                    lstMonth.Items.Add(end.ToString("MM yyyy"));
                    end = end.AddMonths(-1);
                }
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

            string[] selMonth = lstMonth.SelectedValue.Split(' ');
            DateTime reportDate = new DateTime(Convert.ToInt32(selMonth[1]), Convert.ToInt32(selMonth[0]), 1);

            string path = PDFSalonReport.CurrentPath.Replace("bin", "Staff\\Reports\\cReports");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            PDFDailySalonReport rpt = new PDFDailySalonReport(reportDate.Date, reportDate.AddMonths(1).AddDays(-1).Date, therapists, path);

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