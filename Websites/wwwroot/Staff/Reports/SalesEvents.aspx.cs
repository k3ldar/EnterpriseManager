using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.DataVisualization.Charting;

using Website.Library.Classes;
using Library.BOL.Statistics;
using Library.BOL.Countries;
using Library.Utils;

using webLib = Website.Library;

namespace SieraDelta.Website.Reports
{
    public partial class SalesEvents : BaseWebFormStaff
    {
        private DataTable _dataTable;
        private Library.BOL.Statistics.Statistics _stats;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Site-Error/Invalid-Permission/");
                return;
            }

            if (!IsPostBack)
            {
                lstRange.Items.Add(new ListItem("Daily"));
                lstRange.Items.Add(new ListItem("Monthly"));
                LoadMonths();


                lstCountry.Items.Clear();
                lstCountry.Items.Add(new ListItem("All", ""));

                foreach (Country cntry in Countries.Get())
                {
                    lstCountry.Items.Add(new ListItem(cntry.Name, cntry.CountryCode));
                }

                RebuildChart();
            }
        }

        void LoadMonths()
        {
            DateTime start = new DateTime(2011, 1, 1);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            lstMonth.Items.Clear();

            while (end > start)
            {
                lstMonth.Items.Add(new ListItem(end.ToString("MM yyyy"), end.ToString("dd/MM/yyyy")));
                end = end.AddMonths(-1);
            }
        }

        void LoadYears()
        {
            DateTime start = new DateTime(2011, 1, 1);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            lstMonth.Items.Clear();

            while (end > start)
            {
                lstMonth.Items.Add(new ListItem(end.ToString("yyyy"), end.ToString("yyyy")));
                end = end.AddYears(-1);
            }
        }

        void _stats_OnTimeLineEvent(object sender, Library.BOL.Statistics.Statistics.TimeLineEventArgs e)
        {
            string hint = e.EventText;

            if (cbShowTextAsHint.Checked)
                hint = String.Format("{0}\r\nDate: {6}\r\n{5}\r\nCost: {1}\r\nSales: {2}\r\nVisits: {3}\r\nCountry: {4}",
                    e.EventDescription, SharedUtils.FormatMoney(e.EventCost, GetWebsiteCurrency(), false), SharedUtils.FormatMoney(e.EventSales, GetWebsiteCurrency(), false),
                    e.EventVisits, Countries.Get(e.EventCountry).Name, e.EventText, e.Date.ToShortDateString());

            switch (lstRange.SelectedValue)
            {
                case "Daily":
                    webLib.Classes.Annotation.AddAnnotation(Chart1, _dataTable, e.Date, e.EventDescription, hint, cbShowRedLine.Checked, false, false, !cbShowTextAsHint.Checked);
                    break;

                case "Monthly":
                    webLib.Classes.Annotation.AddAnnotation(Chart1, _dataTable, e.Date, e.EventDescription, hint, cbShowRedLine.Checked, true, false, !cbShowTextAsHint.Checked);
                    break;
            }
        }

        void _stats_OnDailySalesTotals(object sender, Library.BOL.Statistics.Statistics.InvoiceTotalsByDayArgs e)
        {
            DataRow dr;
            dr = _dataTable.NewRow();
            dr["Date"] = e.Day;
            dr["Total Sales"] = e.TotalSales;

            _dataTable.Rows.Add(dr);
        }


        protected void lstRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstRange.SelectedValue)
            {
                case "Daily":
                    LoadMonths();
                    break;

                case "Monthly":
                    LoadYears();
                    break;
            }

            RebuildChart();
        }

        private void RebuildChart()
        {
            if (String.IsNullOrEmpty(lstMonth.SelectedValue))
                return;

            _dataTable = new DataTable();
            _stats = new Library.BOL.Statistics.Statistics();
            _stats.OnTimeLineEvent += new Library.BOL.Statistics.Statistics.TimeLineEventDelegate(_stats_OnTimeLineEvent);
            _stats.OnDailySalesTotals += new Library.BOL.Statistics.Statistics.InvoiceTotalsByDayDelegate(_stats_OnDailySalesTotals);
            _stats.OnInvoiceTotalsByMonth += new Library.BOL.Statistics.Statistics.InvoiceTotalsByMonthDelegate(_stats_OnInvoiceTotalsByMonth);

            //_dataTable.PrimaryKey = _dataTable["Date"];



            switch (lstRange.SelectedValue)
            {
                case "Daily":
                    _dataTable.Columns.Add("Date", typeof(DateTime));
                    _dataTable.Columns.Add("Total Sales", typeof(double));
                    Chart1.DataMember = "Date";
                    _stats.GetInvoiceTotalsDaily(Convert.ToDateTime(lstMonth.SelectedValue), lstCountry.SelectedValue);
                    break;

                case "Monthly":
                    _dataTable.Columns.Add("Month", typeof(int));
                    _dataTable.Columns.Add("Year", typeof(int));
                    _dataTable.Columns.Add("Total Sales", typeof(double));
                    Chart1.DataMember = "Month";
                    _stats.GetInvoiceTotalsMonthly(Convert.ToInt32(lstMonth.SelectedValue), lstCountry.SelectedValue);
                    break;
            }

            Chart1.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            Chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = System.Web.UI.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            Chart1.ChartAreas[0].AxisX.LineWidth = 0;
            Chart1.ChartAreas[0].AxisY.LineWidth = 0;

            var IEtable = (_dataTable as System.ComponentModel.IListSource).GetList();

            Chart1.ChartAreas[0].AxisX.Interval = 1;


            switch (lstRange.SelectedValue)
            {
                case "Daily":
                    Chart1.DataBindTable(IEtable, "Date");
                    break;

                case "Monthly":
                    Chart1.DataBindTable(IEtable, "Month");
                    break;
            }

            Chart1.Titles[0].Text = String.Format("{0} - {1} - Country: {2}", lstRange.SelectedValue, lstMonth.SelectedItem, lstCountry.SelectedItem);

            Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Area;
            Chart1.Series[0].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
            Chart1.Series[0].Color = Color.CadetBlue;

            _stats.TimeLineEventsGet();
        }

        void _stats_OnInvoiceTotalsByMonth(object sender, Library.BOL.Statistics.Statistics.InvoiceTotalsByMonthArgs e)
        {
            DataRow dr;
            dr = _dataTable.NewRow();
            dr["Month"] = e.Month;
            dr["Year"] = e.Year;
            dr["Total Sales"] = e.Total;

            _dataTable.Rows.Add(dr);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            RebuildChart();
        }

        protected void lstMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebuildChart();
        }

        protected void lstCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebuildChart();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebuildChart();
        }

        protected void cbShowTextAsHint_CheckedChanged(object sender, EventArgs e)
        {
            RebuildChart();
        }
    }
}