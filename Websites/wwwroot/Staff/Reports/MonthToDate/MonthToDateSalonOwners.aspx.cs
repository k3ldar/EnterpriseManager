using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;

namespace SieraDelta.Website.Staff.Reports.MonthToDate
{
    public partial class MonthToDateSalonOwners : BaseWebFormStaff
    {
        private bool _lastResults = true;
        private string _lastOwner = "";
        private int _cellCount;
        private object[] _tables;
        private object[] _H3;
        private int _currentRecord = 0;

        private decimal _last12 = 0.00m;
        private decimal _this12 = 0.00m;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Members/InvalidPermissions.aspx");
                return;
            }

            Library.BOL.Statistics.Statistics statistics = new Library.BOL.Statistics.Statistics();

            _tables = new object[150];


            _H3 = new object[150];

            _lastResults = true;

            statistics.OnInvoiceMonthToDateTop5 += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDateSalonOwners);
            statistics.GetInvoiceTotalsMonthToDateSalonOwners(DateTime.Now);
        }

        void statistics_OnInvoiceMonthToDateSalonOwners(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            if (_lastOwner != e.Country || _cellCount == 24)
            {
                // need to create a new control and add it
                SieraDelta.Website.Controls.MonthToDate newMTD = LoadControl("~/Staff/Controls/MonthToDate.ascx") as SieraDelta.Website.Controls.MonthToDate;
                pPlaceHolder.Controls.Add(newMTD);

                if (_lastOwner == "")
                    _currentRecord = 0;
                else
                {
                    _currentRecord++;
                }

                _tables[_currentRecord] = newMTD.tblMonthToDate;
                _H3[_currentRecord] = newMTD.hMTD;
                newMTD.hMTD.InnerText = e.Country;
                _lastOwner = e.Country;

                System.Web.UI.HtmlControls.HtmlGenericControl h3 = (System.Web.UI.HtmlControls.HtmlGenericControl)_H3[_currentRecord];
                _cellCount = 0;
                _last12 = 0.00m;
                _this12 = 0.00m;
            }

            Table CurrentTable = (Table)_tables[_currentRecord];
            TableRow CurrentRow = CurrentTable.Rows[1];
            TableRow PreviousRow = CurrentTable.Rows[2];
            TableRow DiffRow = CurrentTable.Rows[3];
            TableRow PercRow = CurrentTable.Rows[4];
            _cellCount++;

            if (_lastResults)
            {
                TableCell PrevResults = new TableCell();
                PrevResults.Text = SharedUtils.FormatMoney(e.Total, GetWebsiteCurrency());
                PreviousRow.Cells.Add(PrevResults);
                _last12 += e.Total;
            }
            else
            {
                _this12 += e.Total;
                TableCell CurrResults = new TableCell();
                CurrResults.Text = SharedUtils.FormatMoney(e.Total, GetWebsiteCurrency());
                CurrentRow.Cells.Add(CurrResults);

                TableCell Diff = new TableCell();
                Diff.Text = SharedUtils.FormatMoney(e.Difference, GetWebsiteCurrency());

                if (e.Difference < 0.00m)
                    CellTextRed(Diff);

                DiffRow.Cells.Add(Diff);

                TableCell Percent = new TableCell();
                Percent.Text = String.Format("{0}%", e.Percent);

                if (e.Percent < 0)
                    CellTextRed(Percent);

                PercRow.Cells.Add(Percent);

                TableHeaderCell Header = new TableHeaderCell();
                Header.Text = String.Format("{0} {1}/{2}", e.StartDate.ToString("MMM"), e.Year, e.Year - 1);
                CurrentTable.Rows[0].Cells.Add(Header);
            }


            if (_cellCount == 24)
            {
                Table tbl = (Table)_tables[_currentRecord];

                TableHeaderCell summaryH = new TableHeaderCell();
                summaryH.Text = "12 Month Summary";
                tbl.Rows[0].Cells.Add(summaryH);

                TableCell summary = new TableCell();
                summary.Text = SharedUtils.FormatMoney(_this12, GetWebsiteCurrency());
                tbl.Rows[1].Cells.Add(summary);

                summary = new TableCell();
                summary.Text = SharedUtils.FormatMoney(_last12, GetWebsiteCurrency());
                tbl.Rows[2].Cells.Add(summary);

                summary = new TableCell();
                summary.Text = SharedUtils.FormatMoney(_this12 - _last12, GetWebsiteCurrency());
                tbl.Rows[3].Cells.Add(summary);

                summary = new TableCell();

                if (_last12 == 0.00m)
                    summary.Text = "100%";
                else
                {
                    decimal diff = _this12 - _last12;

                    if (diff < 0)
                        diff = 0 - (100 / _last12) * (_last12 - _this12);
                    else
                        diff = (100 / _this12) * diff;

                    summary.Text = String.Format("{0}%", diff.ToString("F0"));

                    if (diff < 0.00m)
                        CellTextRed(summary);
                }

                tbl.Rows[4].Cells.Add(summary);
            }

            _lastResults = !_lastResults;
        }

        private void CellTextRed(TableCell cell)
        {
            string Old = cell.Text;

            cell.Text = String.Format("<font color=\"red\">{0}</font>", Old);
        }
    }
}