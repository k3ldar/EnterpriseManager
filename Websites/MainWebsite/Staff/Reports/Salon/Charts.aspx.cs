using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebChart;

using Website.Library.Classes;
using Library.BOL.Therapists;

namespace Heavenskincare.WebsiteTemplate.Staff.Reports.Salon
{
    public partial class Charts : BaseWebFormStaff
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

            RebuildChart();
        }


        protected void lstMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RebuildChart();
        }

        private void RebuildChart()
        {
            Therapists salonTherapists = Therapists.Get();
            Therapists therapists = new Therapists();

            foreach (Therapist therapist in salonTherapists)
            {
                if (therapist.Group.Description == "Shifnal Salon")
                    therapists.Add(therapist);
            }

            DataTable dt = new DataTable();
            DataColumn dc;

            dc = new DataColumn();
            dc.ColumnName = "Name";
            dt.Columns.Add(dc);

            dt.Columns.Add("Products", typeof(double));
            dt.Columns.Add("Treatments", typeof(double));
            dt.Columns.Add("Combined", typeof(double));

            Chart1.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            Chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = System.Web.UI.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = true;

            string[] selMonth = lstMonth.SelectedValue.Split(' ');
            DateTime reportDate = new DateTime(Convert.ToInt32(selMonth[1]), Convert.ToInt32(selMonth[0]), 1);

            foreach (Therapist therapist in therapists)
            {
                TherapistTakings sales = therapist.TotalDiscounts(reportDate.Date, reportDate.AddMonths(1).AddDays(-1).Date);
                //Chart1.Series.Add(therapist.EmployeeName);
                DataRow dr;
                dr = dt.NewRow();
                dr["Name"] = therapist.EmployeeName;
                dr["Products"] = sales.Products;
                dr["Treatments"] = sales.Treatments;
                dr["Combined"] = sales.Treatments + sales.Products;

                dt.Rows.Add(dr);
            }

            var IEtable = (dt as System.ComponentModel.IListSource).GetList();

            Chart1.ChartAreas[0].AxisX.Interval = 1;
            //Chart1.ChartAreas[0].
            //Chart1.Series["Series1"].XValueMember = "Name";
            //Chart1.Series["Series1"].YValueMembers = "Total";

            //Chart1.DataSource = dt;
            //Chart1.DataBind();
            Chart1.DataBindTable(IEtable, "Name");
            Chart1.Series["Products"].IsValueShownAsLabel = true;
            Chart1.Series["Treatments"].IsValueShownAsLabel = true;
            Chart1.Series["Combined"].IsValueShownAsLabel = true;
            Chart1.Titles[0].Text = String.Format("Salon Takings - {0}", reportDate.ToString("MMMM yyyy"));
        }
    }
}