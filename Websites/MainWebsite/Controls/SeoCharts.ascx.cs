using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.DataVisualization.Charting;

using Website.Library.Classes;

using Library;
using Library.BOL.Campaigns;
using Library.BOL.Countries;
using Library.BOL.SEO;
using Library.BOL.Statistics;

using Library.Utils;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class SeoCharts : BaseControlClass
    {
        #region Private Members

        private const string VISITOR_OPTIONS = "None;Total Visits;User Visits;Mobile Visits;Bot Visits;Bounced;Sales;" +
            "Total Pages;Conversions;Mobile Conversions;Percent Converted;Percent Converted Mobile;Refer Google;" +
            "Refer Twitter;Refer Facebook;Refer Bing;Refer Yahoo;Refer Organic;Refer Direct;Referral;Refer Unknown";

        private bool _pageLevelData;
        private DataTable _dataTable;
        private SeoReports _reportData;
        private bool _retrieveData;
        private bool _isMap;
        private MapReportType _reportType;

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


        public int Year { get; set; }


        public int Month { get; set; }

        #endregion Properties

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            _retrieveData = true;

            if (!IsPostBack)
            {
                UpdateOptions();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            RebuildChart();

            if (_isMap)
                RegisterMapScripts(true, 1, String.Empty);
        }

        protected string GetLocations()
        {
            string Result = String.Empty;

            if (_reportData == null || _reportData.Count == 0 || !_isMap)
                return (Result);

            foreach (SeoReport report in _reportData)
            {
                string image = "green";
                switch (_reportType)
                {
                    case MapReportType.City:
                        Result += String.Format("['City: {0}\\rVisits: {1}', {2}, {3}, '{4}'],",
                            report.City.Replace("'", " "),
                            report.TotalVisits,
                            report.Latitude,
                            report.Longitude,
                            image);
                        break;
                    case MapReportType.Country:
                        Result += String.Format("['Country: {0}\\rVisits: {1}', {2}, {3}, '{4}'],",
                            report.City.Replace("'", " "),
                            report.TotalVisits,
                            report.Latitude,
                            report.Longitude,
                            image);
                        break;
                    case MapReportType.Currency:
                        Result += String.Format("['Currency: {0}\\rTotal Sales: {1}', {2}, {3}, '{4}'],",
                            report.Currency,
                            report.Sales,
                            report.Latitude,
                            report.Longitude,
                            image);
                        break;
                    default:
                        throw new Exception("Invalid Report Type");
                }
            }

            if (Result.EndsWith(","))
                Result = Result.Substring(0, Result.Length - 1);

            return (Result);
        }

        #endregion Protected Methods

        #region Public Methods

        public void AutoUpdate(Campaign campaign, SeoReports data)
        {
            AutoUpdate(MapReportType.City, data, true, campaign.ID, campaign.CampaignName);

            divRawData.Visible = true;

            foreach (SeoReport reportData in data)
            {
                TableRow r = new TableRow();
                tblRawData.Rows.Add(r);

                TableCell cCountry = new TableCell();
                r.Cells.Add(cCountry);
                cCountry.Text = reportData.Country;

                TableCell cCity = new TableCell();
                r.Cells.Add(cCity);
                cCity.Text = reportData.City;

                TableCell cVisits = new TableCell();
                r.Cells.Add(cVisits);
                cVisits.Text = reportData.TotalVisits.ToString();

                TableCell cCurrency = new TableCell();
                r.Cells.Add(cCurrency);
                cCurrency.Text = reportData.Currency;

                TableCell cSales = new TableCell();
                r.Cells.Add(cSales);

                if (!String.IsNullOrEmpty(reportData.Currency) && reportData.Sales > 0.0m)
                {
                    Library.BOL.Basket.Currency curr = Library.BOL.Basket.Currencies.Get(reportData.Currency);
                    cSales.Text = SharedUtils.FormatMoney(reportData.Sales, curr);
                }
            }

        }

        public void AutoUpdate(MapReportType reportType, SeoReports data, bool includeAPI, int uniqueID, string title)
        {
            divRawData.Visible = false;

            if (data.Count == 0)
            {
                this.Visible = false;
                return;
            }

            _reportType = reportType;
            _retrieveData = false;
            _reportData = data;
            _isMap = true;

            SelectListItem(lstRange, "Monthly");

            SelectListItem(lstDataType1, "Total Visits");
            SelectListItem(lstBarType1, "Line");
            lstType.SelectedIndex = 2;
            RebuildChart();
            UpdateOptions();
            divSelectCriteria.Visible = false;
            RegisterMapScripts(includeAPI, uniqueID, title);
        }

        public void AutoUpdate(SeoReports data, string reportType = "Daily",
            string data1Data = "Total Visits", string data1Type = "Line",
            string data2Data = "None", string data2Type = "Line",
            string data3Data = "None", string data3Type = "Line",
            string data4Data = "None", string data4Type = "Line",
            string data5Data = "None", string data5Type = "Line",
            string data6Data = "None", string data6Type = "Line")
        {
            divRawData.Visible = false;

            if (data.Count == 0)
            {
                this.Visible = false;
                return;
            }

            _retrieveData = false;
            _reportData = data;
            _isMap = false;

            UpdateOptions();
            SelectListItem(lstRange, reportType);

            SelectListItem(lstDataType1, data1Data);
            SelectListItem(lstDataType2, data2Data);
            SelectListItem(lstDataType3, data3Data);
            SelectListItem(lstDataType4, data4Data);
            SelectListItem(lstDataType5, data5Data);
            SelectListItem(lstDataType6, data6Data);

            SelectListItem(lstBarType1, data1Type);
            SelectListItem(lstBarType2, data2Type);
            SelectListItem(lstBarType3, data3Type);
            SelectListItem(lstBarType4, data4Type);
            SelectListItem(lstBarType5, data5Type);
            SelectListItem(lstBarType6, data6Type);

            RebuildChart();

            divSelectCriteria.Visible = false;
        }

        #endregion Public Methods

        #region Private Methods

        private void RegisterMapScripts(bool includeAPI, int uniqueID, string title)
        {
            //if (includeAPI)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "gmap",
            //        "<script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyBDtmYlTGa71O_OyqX0JPXAToiwE_0QYIc'></script>", false);
            //}

            divMap.InnerHtml = String.Format("<h2>{1}</h2><div style=\"float:right;overflow:hidden;height:500px;width:800px;" +
                "padding-bottom:10px;\"><div id=\"gmap_canvas{0}\" style=\"height:500px;width:800px;\"></div>" +
                "</div>", uniqueID, title);

            string script = "" + //<script type=\"text/javascript\">\r\n" +
                "        function init_map" + uniqueID.ToString() + "() {\r\n" +
                "            var locations = [" + GetLocations() + "];\r\n" +
                "\r\n" +
                "            if (locations.length == 0)\r\n" +
                "                return;\r\n" +
                "\r\n" +
                "            var myOptions = { zoom: 2, center: new google.maps.LatLng(0, 0), mapTypeId: google.maps.MapTypeId.ROADMAP };\r\n" +
                "            map = new google.maps.Map(document.getElementById('gmap_canvas" + uniqueID.ToString() + "'), myOptions);\r\n" +
                "            var mapIcon = 'https://maps.google.com/mapfiles/ms/icons/red.png';\r\n" +
                "\r\n" +
                "            for (var i = 0; i < locations.length; i++) {\r\n" +
                "                var location = locations[i];\r\n" +
                "                var contentString = location[0];\r\n" +
                "                mapIcon = 'https://maps.google.com/mapfiles/ms/icons/' + location[3] + '.png';\r\n" +
                "\r\n" +
                "                var marker = new google.maps.Marker({\r\n" +
                "                    position: { lat: location[1], lng: location[2] },\r\n" +
                "                    map: map,\r\n" +
                "                    title: location[0],\r\n" +
                "                    optimized: false,\r\n" +
                "                    buborek: contentString\r\n" +
                "                });\r\n" +
                "\r\n" +
                "                marker.setIcon(mapIcon);\r\n" +
                "\r\n" +
                "                google.maps.event.addListener(marker, 'click', function () {\r\n" +
                "                    infowindow.setContent(this.buborek);\r\n" +
                "                    infowindow.open(map, this);\r\n" +
                "                });\r\n" +
                "            }\r\n" +
                "        } google.maps.event.addDomListener(window, 'load', init_map" + uniqueID.ToString() + ");\r\n" +
                "    ";//</script>\r\n";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "map" + uniqueID.ToString(), script, true);
        }

        private void SelectListItem(DropDownList list, string itemName)
        {
            foreach (ListItem item in list.Items)
            {
                if (item.Value == itemName)
                {
                    list.SelectedIndex = list.Items.IndexOf(item);
                    break;
                }
            }
        }

        private void PopulateList(DropDownList list, string[] items, int selectedIndex)
        {
            list.Items.Clear();

            foreach (string item in items)
            {
                if (String.IsNullOrEmpty(item))
                    continue;

                list.Items.Add(new ListItem(item));
            }

            if (list.Items.Count > 0 && selectedIndex <= list.Items.Count)
                list.SelectedIndex = selectedIndex;
        }

        private void RebuildChart()
        {
            if (divSeriesOptions.Visible && String.IsNullOrEmpty(lstDataType1.SelectedValue))
                return;

            Year = DateTime.Now.Year - lstYears.SelectedIndex;
            Month = lstMonths.SelectedIndex + 1;


            _dataTable = new DataTable();

            switch (lstRange.SelectedValue)
            {
                case "Hourly":
                    _dataTable.Columns.Add("Hourly", typeof(string));
                    _dataTable.Columns.Add(lstDataType1.SelectedValue.Replace(" ", ""), lstDataType1.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

                    Chart1.DataMember = "HourDescription";

                    if (_retrieveData)
                    {
                        _reportData = SeoReports.SEODataHourly();
                        _reportData.Reverse();
                    }

                    break;

                case "Daily":
                    _dataTable.Columns.Add("Date", typeof(DateTime));
                    _dataTable.Columns.Add(lstDataType1.SelectedValue.Replace(" ", ""), lstDataType1.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

                    Chart1.DataMember = "Date";

                    if (_retrieveData)
                    {
                        _reportData = SeoReports.SEODataDaily();
                    }

                    break;

                case "Weekly":
                    _dataTable.Columns.Add("Week", typeof(string));
                    _dataTable.Columns.Add(lstDataType1.SelectedValue.Replace(" ", ""), lstDataType1.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

                    Chart1.DataMember = "Week";

                    if (_retrieveData)
                    {
                        _reportData = SeoReports.SEOWeekly();
                        _reportData.Reverse();
                    }

                    break;

                case "Monthly":
                    _dataTable.Columns.Add("Month", typeof(string));
                    _dataTable.Columns.Add(lstDataType1.SelectedValue.Replace(" ", ""), lstDataType1.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

                    Chart1.DataMember = "Month";

                    if (_retrieveData)
                    {
                        switch (lstType.SelectedIndex)
                        {
                            case 0: // visitors
                                _reportData = SeoReports.SEOMonthly();
                                _reportData.Reverse();
                                break;
                            case 1: // Visits by Countries
                                _isMap = true;
                                _reportData = SeoReports.SEOMonthlyVisitsByCountry(Year, Month);
                                return;
                            case 2: // Visits by Cities
                                _isMap = true;
                                _reportData = SeoReports.SEOMonthlyVisitsByCity(Year, Month);
                                return;
                            case 3: // Sales By Countries
                                _isMap = true;
                                _reportData = SeoReports.SEOMonthlySalesByCountry(Year, Month);
                                return;
                            case 4: // Sales By Cities
                                _isMap = true;
                                _reportData = SeoReports.SEOMonthlySalesByCity(Year, Month);
                                return;
                        }
                    }
                    else
                    {
                        if (_isMap)
                            return;
                    }

                    break;
            }


            if (lstDataType2.SelectedValue != "None")
                _dataTable.Columns.Add(lstDataType2.SelectedValue.Replace(" ", ""), lstDataType2.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

            if (lstDataType3.SelectedValue != "None")
                _dataTable.Columns.Add(lstDataType3.SelectedValue.Replace(" ", ""), lstDataType3.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

            if (lstDataType4.SelectedValue != "None")
                _dataTable.Columns.Add(lstDataType4.SelectedValue.Replace(" ", ""), lstDataType4.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

            if (lstDataType5.SelectedValue != "None")
                _dataTable.Columns.Add(lstDataType5.SelectedValue.Replace(" ", ""), lstDataType5.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));

            if (lstDataType6.SelectedValue != "None")
                _dataTable.Columns.Add(lstDataType6.SelectedValue.Replace(" ", ""), lstDataType6.SelectedValue.Contains("Percent") ? typeof(double) : typeof(Int64));


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
                string valueName4 = lstDataType4.SelectedValue.Replace(" ", "");
                string valueName5 = lstDataType5.SelectedValue.Replace(" ", "");
                string valueName6 = lstDataType6.SelectedValue.Replace(" ", "");

                string colNameFirst = _dataTable.Columns[0].Caption;
                dr[colNameFirst] = report.GetType().GetProperty(colNameFirst).GetValue(report, null);

                dr[valueName1] = report.GetType().GetProperty(valueName1).GetValue(report, null);

                if (lstDataType2.SelectedValue != "None")
                    dr[valueName2] = report.GetType().GetProperty(valueName2).GetValue(report, null);

                if (lstDataType3.SelectedValue != "None" && lstDataType2.SelectedValue != "None")
                    dr[valueName3] = report.GetType().GetProperty(valueName3).GetValue(report, null);

                if (lstDataType4.SelectedValue != "None" && lstDataType3.SelectedValue != "None")
                    dr[valueName4] = report.GetType().GetProperty(valueName4).GetValue(report, null);

                if (lstDataType5.SelectedValue != "None" && lstDataType4.SelectedValue != "None")
                    dr[valueName5] = report.GetType().GetProperty(valueName5).GetValue(report, null);

                if (lstDataType6.SelectedValue != "None" && lstDataType5.SelectedValue != "None")
                    dr[valueName6] = report.GetType().GetProperty(valueName6).GetValue(report, null);

                _dataTable.Rows.Add(dr);
            }

            DataView IEtable = (DataView)(_dataTable as System.ComponentModel.IListSource).GetList();

            Chart1.ChartAreas[0].AxisX.Interval = 1;


            switch (lstRange.SelectedValue)
            {
                case "Hourly":
                    Chart1.DataBindTable(IEtable, "Hourly");
                    break;

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

            if (lstDataType4.SelectedValue != "None" && lstDataType3.SelectedValue != "None")
            {
                Chart1.Series[3].ChartType = SetBarType(lstBarType4.SelectedValue);
                Chart1.Series[3].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
                Chart1.Series[3].IsValueShownAsLabel = true;
                Chart1.Series[3].Color = Color.Black;
            }

            if (lstDataType5.SelectedValue != "None" && lstDataType4.SelectedValue != "None")
            {
                Chart1.Series[4].ChartType = SetBarType(lstBarType5.SelectedValue);
                Chart1.Series[4].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
                Chart1.Series[4].IsValueShownAsLabel = true;
                Chart1.Series[4].Color = Color.Orange;
            }

            if (lstDataType6.SelectedValue != "None" && lstDataType5.SelectedValue != "None")
            {
                Chart1.Series[5].ChartType = SetBarType(lstBarType6.SelectedValue);
                Chart1.Series[5].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
                Chart1.Series[5].IsValueShownAsLabel = true;
                Chart1.Series[5].Color = Color.DarkViolet;
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

        protected void lstRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOptions();
        }

        protected void UpdateOptions()
        {
            divType.Visible = lstRange.SelectedIndex == 3;

            switch (lstRange.SelectedIndex)
            {
                case 0: // hourly
                case 1: // daily
                case 2: // weekly
                    PopulateList(lstDataType1, VISITOR_OPTIONS.Split(';'), 1);
                    PopulateList(lstDataType2, VISITOR_OPTIONS.Split(';'), 2);
                    PopulateList(lstDataType3, VISITOR_OPTIONS.Split(';'), 0);
                    PopulateList(lstDataType4, VISITOR_OPTIONS.Split(';'), 0);
                    PopulateList(lstDataType5, VISITOR_OPTIONS.Split(';'), 0);
                    PopulateList(lstDataType6, VISITOR_OPTIONS.Split(';'), 0);
                    divMap.Visible = false;
                    pChart.Visible = true;
                    divMonthSelection.Visible = false;

                    break;
                case 3: // monthly
                    switch (lstType.SelectedIndex)
                    {
                        case 0: // Visitors
                            PopulateList(lstDataType1, VISITOR_OPTIONS.Split(';'), 1);
                            PopulateList(lstDataType2, VISITOR_OPTIONS.Split(';'), 2);
                            PopulateList(lstDataType3, VISITOR_OPTIONS.Split(';'), 0);
                            PopulateList(lstDataType4, VISITOR_OPTIONS.Split(';'), 0);
                            PopulateList(lstDataType5, VISITOR_OPTIONS.Split(';'), 0);
                            PopulateList(lstDataType6, VISITOR_OPTIONS.Split(';'), 0);
                            divMap.Visible = false;
                            pChart.Visible = true;
                            divMonthSelection.Visible = false;

                            break;

                        default:
                            PopulateList(lstDataType1, String.Empty.Split(';'), 1);
                            PopulateList(lstDataType2, String.Empty.Split(';'), 2);
                            PopulateList(lstDataType3, String.Empty.Split(';'), 0);
                            PopulateList(lstDataType4, String.Empty.Split(';'), 0);
                            PopulateList(lstDataType5, String.Empty.Split(';'), 0);
                            PopulateList(lstDataType6, String.Empty.Split(';'), 0);
                            divMap.Visible = true;
                            pChart.Visible = false;
                            divMonthSelection.Visible = true;


                            lstYears.Items.Clear();

                            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 5; i--)
                            {
                                lstYears.Items.Add(new ListItem(i.ToString()));
                            }

                            lstMonths.Items.Clear();

                            for (int i = 1; i < 13; i++)
                            {
                                DateTime mon = new DateTime(2017, i, 1);
                                lstMonths.Items.Add(new ListItem(mon.ToString("MMMM")));
                            }

                            break;

                    }

                    break;

                default:
                    throw new Exception("Invalid Option");
            } // switch

            divSeriesOptions.Visible = lstDataType6.Items.Count > 0;
        }

        #endregion Private Methods
    }
}