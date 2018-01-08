using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.DataVisualization.Charting;

using Website.Library.Classes;
using Library.BOL.Statistics;
using Library.BOL.Countries;
using Library.BOL.SEO;

using Library.Utils;

namespace SieraDelta.Website.Controls
{
    public partial class SEOChart : BaseControlClass
    {
        #region Private Members

        private bool _pageLevelData;
        private DataTable _dataTable;
        private SeoReports _reportData;

        #endregion Private Members

        #region Properties

        public bool PageLevelData
        {
            get
            {
                return (_pageLevelData);
            }

            set
            {
                _pageLevelData = value;

                if (_pageLevelData)
                {
                    lstDataType1.Items.Remove("Minimum Pages");
                    lstDataType1.Items.Remove("Maximum Pages");
                    lstDataType1.Items.Remove("Average Pages");

                    lstDataType2.Items.Remove("Minimum Pages");
                    lstDataType2.Items.Remove("Maximum Pages");
                    lstDataType2.Items.Remove("Average Pages");

                    lstDataType3.Items.Remove("Minimum Pages");
                    lstDataType3.Items.Remove("Maximum Pages");
                    lstDataType3.Items.Remove("Average Pages");

                    lstDataType1.Items.Insert(5, "Landing Page");
                    lstDataType2.Items.Insert(5, "Landing Page");
                    lstDataType3.Items.Insert(5, "Landing Page");

                    lstDataType1.Items.Insert(5, "Minimum Seconds");
                    lstDataType1.Items.Insert(6, "Maximum Seconds");
                    lstDataType1.Items.Insert(7, "Average Seconds");

                    lstDataType2.Items.Insert(5, "Minimum Seconds");
                    lstDataType2.Items.Insert(6, "Maximum Seconds");
                    lstDataType2.Items.Insert(7, "Average Seconds");

                    lstDataType3.Items.Insert(5, "Minimum Seconds");
                    lstDataType3.Items.Insert(6, "Maximum Seconds");
                    lstDataType3.Items.Insert(7, "Average Seconds");
                }
                else
                {
                    lstDataType1.Items.Insert(5, "Minimum Pages");
                    lstDataType1.Items.Insert(6, "Maximum Pages");
                    lstDataType1.Items.Insert(7, "Average Pages");

                    lstDataType2.Items.Insert(5, "Minimum Pages");
                    lstDataType2.Items.Insert(6, "Maximum Pages");
                    lstDataType2.Items.Insert(7, "Average Pages");

                    lstDataType3.Items.Insert(5, "Minimum Pages");
                    lstDataType3.Items.Insert(6, "Maximum Pages");
                    lstDataType3.Items.Insert(7, "Average Pages");


                    lstDataType1.Items.Remove("Landing Page");
                    lstDataType2.Items.Remove("Landing Page");
                    lstDataType3.Items.Remove("Landing Page");

                    lstDataType1.Items.Remove("Minimum Seconds");
                    lstDataType1.Items.Remove("Maximum Seconds");
                    lstDataType1.Items.Remove("Average Seconds");

                    lstDataType2.Items.Remove("Minimum Seconds");
                    lstDataType2.Items.Remove("Maximum Seconds");
                    lstDataType2.Items.Remove("Average Seconds");

                    lstDataType3.Items.Remove("Minimum Seconds");
                    lstDataType3.Items.Remove("Maximum Seconds");
                    lstDataType3.Items.Remove("Average Seconds");
                }
            }
        }

        #endregion Properties

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            RebuildChart();
        }

        #endregion Protected Methods

        #region Private Methods

        private void RebuildChart()
        {
            if (String.IsNullOrEmpty(lstDataType1.SelectedValue))
                return;

            _dataTable = new DataTable();

            switch (lstRange.SelectedValue)
            {
                case "Daily":
                    _dataTable.Columns.Add("Date", typeof(DateTime));
                    _dataTable.Columns.Add(lstDataType1.SelectedValue.Replace(" ", ""), lstDataType1.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

                    Chart1.DataMember = "Date";
                    _reportData = SeoReports.SEODataDaily();
                    break;

                case "Weekly":
                    _dataTable.Columns.Add("Week", typeof(string));
                    _dataTable.Columns.Add(lstDataType1.SelectedValue.Replace(" ", ""), lstDataType1.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

                    Chart1.DataMember = "Week";
                    _reportData = SeoReports.SEOWeekly();
                    break;

                case "Monthly":
                    _dataTable.Columns.Add("Month", typeof(string));
                    _dataTable.Columns.Add(lstDataType1.SelectedValue.Replace(" ", ""), lstDataType1.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

                    Chart1.DataMember = "Month";
                    _reportData = SeoReports.SEOMonthly();
                    break;
            }


            if (lstDataType2.SelectedValue != "None")
                _dataTable.Columns.Add(lstDataType2.SelectedValue.Replace(" ", ""), lstDataType2.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

            if (lstDataType3.SelectedValue != "None")
                _dataTable.Columns.Add(lstDataType3.SelectedValue.Replace(" ", ""), lstDataType3.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));


            Chart1.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            Chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = System.Web.UI.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            Chart1.ChartAreas[0].AxisX.LineWidth = 0;
            Chart1.ChartAreas[0].AxisY.LineWidth = 0;

            foreach (SeoReport report in _reportData)
            {
                DataRow dr = _dataTable.NewRow();

                string valueName1 = lstDataType1.SelectedValue.Replace(" ", "");
                string valueName2 = lstDataType2.SelectedValue.Replace(" ", "");
                string valueName3 = lstDataType3.SelectedValue.Replace(" ", "");

                string colNameFirst = _dataTable.Columns[0].Caption;
                dr[colNameFirst] = report.GetType().GetProperty(colNameFirst).GetValue(report, null);

                dr[valueName1] = report.GetType().GetProperty(valueName1).GetValue(report, null);

                if (lstDataType2.SelectedValue != "None")
                    dr[valueName2] = report.GetType().GetProperty(valueName2).GetValue(report, null);

                if (lstDataType3.SelectedValue != "None" && lstDataType2.SelectedValue != "None")
                    dr[valueName3] = report.GetType().GetProperty(valueName3).GetValue(report, null);

                _dataTable.Rows.Add(dr);
            }

            var IEtable = (_dataTable as System.ComponentModel.IListSource).GetList();

            Chart1.ChartAreas[0].AxisX.Interval = 1;


            switch (lstRange.SelectedValue)
            {
                case "Daily":
                    Chart1.DataBindTable(IEtable, "Date");
                    break;

                case "Weekly":
                    Chart1.DataBindTable(IEtable, "Week");
                    break;

                case "Monthly":
                    Chart1.DataBindTable(IEtable, "Month");
                    break;
            }

            Chart1.Titles[0].Text = String.Format("{0} - {1} / {2}",
                lstRange.SelectedValue, lstDataType1.SelectedItem,
                lstDataType2.SelectedValue);

            Chart1.Series[0].ChartType = SetBarType(lstBarType1.SelectedValue);
            Chart1.Series[0].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.Series[0].Color = Color.CadetBlue;

            if (lstDataType2.SelectedValue != "None")
            {
                Chart1.Series[1].ChartType = SetBarType(lstBarType2.SelectedValue);
                Chart1.Series[1].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
                Chart1.Series[1].IsValueShownAsLabel = true;
                Chart1.Series[1].Color = Color.Red;
            }

            if (lstDataType3.SelectedValue != "None" && lstDataType2.SelectedValue != "None")
            {
                Chart1.Series[2].ChartType = SetBarType(lstBarType3.SelectedValue);
                Chart1.Series[2].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
                Chart1.Series[2].IsValueShownAsLabel = true;
                Chart1.Series[2].Color = Color.Green;
            }

        }

        private SeriesChartType SetBarType(string userType)
        {
            switch (userType)
            {
                case "Area":
                    return (System.Web.UI.DataVisualization.Charting.SeriesChartType.Area);
                case "Bar":
                    return (System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar);
                case "Column":
                    return (System.Web.UI.DataVisualization.Charting.SeriesChartType.Column);
                case "Line":
                    return (System.Web.UI.DataVisualization.Charting.SeriesChartType.Line);

                default:
                    throw new Exception("Invalid Selection");
            }
        }

        #endregion Private Methods
    }
}