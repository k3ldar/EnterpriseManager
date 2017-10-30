using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using WebChart;
using Library;
using Library.Utils;
using Website.Library.Classes;


namespace Heavenskincare.WebsiteTemplate.Statistics
{
    public partial class Charts : BaseWebFormStaff
    {
        private Library.BOL.Statistics.Statistics _statistics;
        private LineChart _lineChart;
        private LineChart _lineChartLast;
        private LineChart _lineChart3;
        private LineChart _lineChart4;
        private LineChart _lineChart5;
        private int _top5Count;
        private string _top5Name;

        private ColumnChart _barChart;
        private bool _last;
        private bool _lastResults = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Error/InvalidPermissions.aspx");
                return;
            }

            _statistics = new Library.BOL.Statistics.Statistics();
            _statistics.OnInvoiceTotalsByMonth += new Library.BOL.Statistics.Statistics.InvoiceTotalsByMonthDelegate(_statistics_OnInvoiceTotalsByMonth);
            _statistics.OnInvoiceCountByDay += new Library.BOL.Statistics.Statistics.InvoiceCountByDayDelegate(_statistics_OnInvoiceCountByDay);
            _statistics.OnVisitorTotalsByCountry += new Library.BOL.Statistics.Statistics.VisitorTotalsByCountryDelegate(_statistics_OnVisitorTotalsByCountry);

            _statistics.OnInvoiceMonthToDate += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(_statistics_OnInvoiceMonthToDate);
            _statistics.OnInvoiceMonthtoDateCount += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateCountDelegate(_statistics_OnInvoiceMonthtoDateCount);
            _statistics.OnInvoiceMonthToDateOffice += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(_statistics_OnInvoiceMonthToDateOffice);
            _statistics.OnInvoiceMonthToDateOnline += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(_statistics_OnInvoiceMonthToDateOnline);
            _statistics.OnInvoiceMonthToDateSalon += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(_statistics_OnInvoiceMonthToDateSalon);
            _statistics.OnInvoiceMonthToDateTop5 += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(_statistics_OnInvoiceMonthToDateTop5);

            LoadSalesMonthToDateOverall();

        }

        void _statistics_OnInvoiceMonthToDateTop5(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            if (!_lastResults)
            {
                if (_top5Name != e.Country)
                {
                    _top5Name = e.Country;
                    _top5Count++;
                }

                LineChart currChart = null;

                switch (_top5Count)
                {
                    case 1:
                        currChart = _lineChart;
                        break;
                    case 2:
                        currChart = _lineChartLast;
                        break;
                    case 3:
                        currChart = _lineChart3;
                        break;
                    case 4:
                        currChart = _lineChart4;
                        break;
                    case 5:
                        currChart = _lineChart5;
                        break;
                }

                if (currChart != null)
                {
                    currChart.Name = e.Country;
                    currChart.Legend = e.Country;

                    Enums.Month month = (Enums.Month)e.Month;

                    currChart.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
                }
                else
                {
                    Library.BOL.Mail.Emails.Add("s1cart3r@gmail.com", "Simon", "heaven", "noreply@heavenskincare.com", "Error _statistics_OnInvoiceMonthToDateTop5",
                        String.Format("Country: {0}<br />Difference: {1}<br />Month: {2}<br />Total: {3}<br />Year: {4}<br />", e.Country, e.Difference, e.Month, e.Total, e.Year));
                }
            }

            _lastResults = !_lastResults;
        }

        void _statistics_OnInvoiceMonthToDateSalon(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            Enums.Month month = (Enums.Month)e.Month;

            if (_lastResults)
                _lineChartLast.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
            else
                _lineChart.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));


            _lastResults = !_lastResults;
        }

        void _statistics_OnInvoiceMonthToDateOnline(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            Enums.Month month = (Enums.Month)e.Month;

            if (_lastResults)
                _lineChartLast.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
            else
                _lineChart.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));


            _lastResults = !_lastResults;
        }

        void _statistics_OnInvoiceMonthToDateOffice(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            Enums.Month month = (Enums.Month)e.Month;

            if (_lastResults)
                _lineChartLast.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
            else
                _lineChart.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));


            _lastResults = !_lastResults;
        }

        void _statistics_OnInvoiceMonthtoDateCount(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateCountArgs e)
        {
            Enums.Month month = (Enums.Month)e.Month;

            if (_lastResults)
                _lineChartLast.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
            else
                _lineChart.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));


            _lastResults = !_lastResults;
        }

        void _statistics_OnInvoiceMonthToDate(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            Enums.Month month = (Enums.Month)e.Month;

            if (_lastResults)
                _lineChartLast.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
            else
                _lineChart.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));


            _lastResults = !_lastResults;
        }

        protected void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbChartType.SelectedValue)
            {
                case "1":
                    LoadInvoiceTotalsByMonth();
                    break;
                case "2":
                    LoadInvoiceCountByDay();
                    break;
                case "3":
                    LoadVisitorsByCountry();
                    break;
                case "4":
                    LoadVisitorsByCountryToday();
                    break;
                case "5":
                    LoadInvoiceTotalsByMonthLastYear();
                    break;
                case "6":
                    LoadSalesMonthToDateOverall();
                    break;
                case "7":
                    LoadSalesMonthToDateInvoiceCount();
                    break;
                case "8":
                    LoadSalesMonthToDateOnline();
                    break;
                case "9":
                    LoadSalesMonthToDateOffice();
                    break;
                case "10":
                    LoadSalesMonthToDateSalon();
                    break;
                case "11":
                    LoadSalesMonthToDateTop5Salons();
                    break;
                case "12":
                    //>Sales Month To Date Top 5 Countries</asp:ListItem>
                    LoadSalesMonthToDateTop5Countries();
                    break;
                case "13":
                    LoadSalesMonthToDateAllSalons();
                    break;
            }
        }

        private void LoadSalesMonthToDateOverall()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Sales Month to Date (Overall)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalsMonthToDate(DateTime.Now);
            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadSalesMonthToDateOnline()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Totals By Month (Online)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalsMonthToDateOnline(DateTime.Now);
            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadSalesMonthToDateAllSalons()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Totals By Month (All Salons)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalsMonthToDateSalons(DateTime.Now);
            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadSalesMonthToDateTop5Countries()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Totals By Month (Top 5 Salons)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _top5Count = 0;
            _top5Name = "";

            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;

            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            _lineChart3 = new LineChart();
            _lineChart3.Line.Color = Color.Green;
            _lineChart3.Legend = "Last Year";
            _lineChart3.ShowLegend = true;
            _lineChart3.DataLabels.ShowLegend = true;
            _lineChart3.Name = _lineChart3.Legend;

            _lineChart4 = new LineChart();
            _lineChart4.Line.Color = Color.Blue;
            _lineChart4.ShowLegend = true;
            _lineChart4.DataLabels.ShowLegend = true;
            _lineChart4.Name = _lineChart4.Legend;

            _lineChart5 = new LineChart();
            _lineChart5.Line.Color = Color.Chocolate;
            _lineChart5.ShowLegend = true;
            _lineChart5.DataLabels.ShowLegend = true;
            _lineChart5.Name = _lineChart5.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 180;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalsMonthToDateTop5(DateTime.Now);

            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);
            ChartControl1.Charts.Add(_lineChart3);
            ChartControl1.Charts.Add(_lineChart4);
            ChartControl1.Charts.Add(_lineChart5);

            ChartControl1.RedrawChart();
        }

        private void LoadSalesMonthToDateTop5Salons()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Totals By Month (Top 5 Salons)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _top5Count = 0;
            _top5Name = "";

            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;

            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            _lineChart3 = new LineChart();
            _lineChart3.Line.Color = Color.Green;
            _lineChart3.Legend = "Last Year";
            _lineChart3.ShowLegend = true;
            _lineChart3.DataLabels.ShowLegend = true;
            _lineChart3.Name = _lineChart3.Legend;

            _lineChart4 = new LineChart();
            _lineChart4.Line.Color = Color.Blue;
            _lineChart4.ShowLegend = true;
            _lineChart4.DataLabels.ShowLegend = true;
            _lineChart4.Name = _lineChart4.Legend;

            _lineChart5 = new LineChart();
            _lineChart5.Line.Color = Color.Chocolate;
            _lineChart5.ShowLegend = true;
            _lineChart5.DataLabels.ShowLegend = true;
            _lineChart5.Name = _lineChart5.Legend;
            
            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 180;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalsMonthToDateTop5Salons(DateTime.Now);

            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);
            ChartControl1.Charts.Add(_lineChart3);
            ChartControl1.Charts.Add(_lineChart4);
            ChartControl1.Charts.Add(_lineChart5);

            ChartControl1.RedrawChart();
        }

        private void LoadSalesMonthToDateOffice()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Totals By Month (Office)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalsMonthToDateOffice(DateTime.Now);
            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadSalesMonthToDateSalon()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Totals By Month (Salon)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalsMonthToDateSalon(DateTime.Now);
            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadSalesMonthToDateInvoiceCount()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Count (Overall)";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Invoices";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = "Current Year";
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = "Last Year";
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _statistics.GetInvoiceTotalCountMonthToDate(DateTime.Now);
            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadInvoiceTotalsByMonth()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Month To Date - Invoice Totals By Month";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = String.Format("Year {0}", DateTime.Now.Year);
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = String.Format("Year {0}", DateTime.Now.Year - 1);
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _last = false;
            _statistics.GetInvoicesTotalsByMonth(DateTime.Now);
            ChartControl1.Charts.Add(_lineChart);

            _last = true;
            _statistics.GetInvoicesTotalsByMonth(DateTime.Now.AddYears(-1));
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadInvoiceTotalsByMonthLastYear()
        {
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Invoice Totals By Month";
            ChartControl1.XTitle.Text = "Month";
            ChartControl1.YTitle.Text = "Total Sales (£)";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _lineChart = new LineChart();
            _lineChart.Line.Color = Color.Black;
            _lineChart.Legend = String.Format("Year {0}", DateTime.Now.Year - 1);
            _lineChart.ShowLegend = true;
            _lineChart.DataLabels.ShowLegend = true;
            _lineChart.Name = _lineChart.Legend;
            _lineChartLast = new LineChart();
            _lineChartLast.Line.Color = Color.Red;
            _lineChartLast.Legend = String.Format("Year {0}", DateTime.Now.Year - 2);
            _lineChartLast.ShowLegend = true;
            _lineChartLast.DataLabels.ShowLegend = true;
            _lineChartLast.Name = _lineChartLast.Legend;

            ChartControl1.Legend.Position = LegendPosition.Right;
            ChartControl1.Legend.Width = 100;
            ChartControl1.HasChartLegend = true;

            _last = false;
            _statistics.GetInvoicesTotalsByMonth(DateTime.Now.AddYears(-1));
            ChartControl1.Charts.Add(_lineChart);

            _last = true;
            _statistics.GetInvoicesTotalsByMonth(DateTime.Now.AddYears(-2));
            ChartControl1.Charts.Add(_lineChartLast);

            ChartControl1.RedrawChart();
        }

        private void LoadInvoiceCountByDay()
        {
            ChartControl1.HasChartLegend = false;
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Invoice Count By Day";
            ChartControl1.XTitle.Text = "Date";
            ChartControl1.YTitle.Text = "Total Invoices";
            ChartControl1.XValuesInterval = 4;
            ChartControl1.XTicksInterval = 4;

            ChartControl1.Legend.Position = LegendPosition.Bottom;
            ChartControl1.Legend.Width = 200;

            _lineChart = new LineChart();
            _lineChartLast = new LineChart();
            _statistics.GetInvoiceCountByDay(40, DateTime.Now);

            ChartControl1.Charts.Add(_lineChart);
            ChartControl1.RedrawChart();
        }

        private void LoadVisitorsByCountry()
        {
            ChartControl1.HasChartLegend = false;
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Visitors By Country";
            ChartControl1.XTitle.Text = "Country";
            ChartControl1.YTitle.Text = "Total Visitors";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _barChart = new ColumnChart();

            _statistics.GetVisitorsByCountry(10);

            ChartControl1.Charts.Add(_barChart);
            ChartControl1.RedrawChart();
        }

        private void LoadVisitorsByCountryToday()
        {
            ChartControl1.HasChartLegend = false;
            ChartControl1.Charts.Clear();
            ChartControl1.ChartTitle.Text = "Visitors By Country (Today)";
            ChartControl1.XTitle.Text = "Country";
            ChartControl1.YTitle.Text = "Total Visitors";
            ChartControl1.XValuesInterval = 0;
            ChartControl1.XTicksInterval = 0;
            _barChart = new ColumnChart();

            _statistics.GetVisitorsByCountryToday(10);

            ChartControl1.Charts.Add(_barChart);
            ChartControl1.RedrawChart();
        }

        private void _statistics_OnInvoiceTotalsByMonth(object sender, Library.BOL.Statistics.Statistics.InvoiceTotalsByMonthArgs e)
        {
            Enums.Month month = (Enums.Month)e.Month;

            if (_last)
                _lineChartLast.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
            else
                _lineChart.Data.Add(new ChartPoint(String.Format("{0}", month.ToString()), (float)e.Total));
        }

        private void _statistics_OnInvoiceCountByDay(object sender, Library.BOL.Statistics.Statistics.InvoiceCountByDayArgs e)
        {
            _lineChart.Data.Add(new ChartPoint(e.Date.ToString("dd/MM/yyyy"), (float)e.Count));
        }

        private void _statistics_OnVisitorTotalsByCountry(object sender, Library.BOL.Statistics.Statistics.VisitorTotalsByCountryArgs e)
        {
            _barChart.Data.Add(new ChartPoint(e.Country, (float)e.Count));
        }
    }
}