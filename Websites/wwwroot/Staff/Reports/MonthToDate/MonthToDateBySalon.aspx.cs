using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;

namespace SieraDelta.Website.Staff.Statistics
{
    public partial class MonthToDateBySalon1 : BaseWebFormStaff
    {
        private bool _lastResults = true;
        private string _lastCountry = "";
        private object[] _tables;
        private object[] _H3;
        private int _currentRecord = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Site-Error/Invalid-Permission/");
                return;
            }

            Library.BOL.Statistics.Statistics statistics = new Library.BOL.Statistics.Statistics();
            statistics.OnInvoiceMonthToDate += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDate);
            statistics.GetInvoiceTotalsMonthToDateSalons(DateTime.Now);

            _tables = new object[5];
            _tables[0] = tblMTDTop51;
            _tables[1] = tblMTDTop52;
            _tables[2] = tblMTDTop53;
            _tables[3] = tblMTDTop54;
            _tables[4] = tblMTDTop55;

            _H3 = new object[5];
            _H3[0] = hMTDTop51;
            _H3[1] = hMTDTop52;
            _H3[2] = hMTDTop53;
            _H3[3] = hMTDTop54;
            _H3[4] = hMTDTop55;

            statistics.OnInvoiceMonthToDateTop5 += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDateTop5);
            statistics.GetInvoiceTotalsMonthToDateTop5Salons(DateTime.Now);
        }

        void statistics_OnInvoiceMonthToDateTop5(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            if (_lastCountry != e.Country)
            {
                if (_lastCountry == "")
                    _currentRecord = 0;
                else
                    _currentRecord++;

                _lastCountry = e.Country;

                System.Web.UI.HtmlControls.HtmlGenericControl h3 = (System.Web.UI.HtmlControls.HtmlGenericControl)_H3[_currentRecord];
                h3.InnerText = e.Country;
            }

            Table CurrentTable = (Table)_tables[_currentRecord];
            TableRow CurrentRow = CurrentTable.Rows[1];
            TableRow PreviousRow = CurrentTable.Rows[2];
            TableRow DiffRow = CurrentTable.Rows[3];
            TableRow PercRow = CurrentTable.Rows[4];

            if (_lastResults)
            {
                TableCell PrevResults = new TableCell();
                PrevResults.Text = SharedUtils.FormatMoney(e.Total, GetWebsiteCurrency());
                PreviousRow.Cells.Add(PrevResults);
            }
            else
            {
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


            _lastResults = !_lastResults;
        }

        private void CellTextRed(TableCell cell)
        {
            string Old = cell.Text;

            cell.Text = String.Format("<font color=\"red\">{0}</font>", Old);
        }

        void statistics_OnInvoiceMonthToDate(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            if (_lastResults)
            {
                TableCell PrevResults = new TableCell();
                PrevResults.Text = SharedUtils.FormatMoney(e.Total, GetWebsiteCurrency());
                tblMTDPreviousRow.Cells.Add(PrevResults);
            }
            else
            {
                TableCell CurrResults = new TableCell();
                CurrResults.Text = SharedUtils.FormatMoney(e.Total, GetWebsiteCurrency());
                tblMTDCurrentRow.Cells.Add(CurrResults);

                TableCell Diff = new TableCell();
                Diff.Text = SharedUtils.FormatMoney(e.Difference, GetWebsiteCurrency());

                if (e.Difference < 0.00m)
                    CellTextRed(Diff);

                tblMTDDiffRow.Cells.Add(Diff);

                TableCell Percent = new TableCell();
                Percent.Text = String.Format("{0}%", e.Percent);

                if (e.Percent < 0)
                    CellTextRed(Percent);

                tblMTDPercent.Cells.Add(Percent);

                TableHeaderCell Header = new TableHeaderCell();
                Header.Text = String.Format("{0} {1}/{2}", e.StartDate.ToString("MMM"), e.Year, e.Year - 1);
                tblMTDHeader.Cells.Add(Header);
            }


            _lastResults = !_lastResults;
        }
    }
}