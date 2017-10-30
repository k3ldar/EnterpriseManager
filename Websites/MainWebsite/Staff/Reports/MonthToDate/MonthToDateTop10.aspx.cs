using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Staff.Statistics
{
    public partial class MonthToDateTop10 : BaseWebFormStaff
    {
        private bool _lastResults = true;
        private string _lastCountry = "";
        private object[] _tables;
        private object[] _H3;
        private int _currentRecord = 0;
        private decimal _currentYear = 0.00m;
        private decimal _lastYear = 0.00m;
        private decimal _difference = 0.00m;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Members/InvalidPermissions.aspx");
                return;
            }

            Library.BOL.Statistics.Statistics statistics = new Library.BOL.Statistics.Statistics();

            _tables = new object[10];
            _tables[0] = tblMTDTop51;
            _tables[1] = tblMTDTop52;
            _tables[2] = tblMTDTop53;
            _tables[3] = tblMTDTop54;
            _tables[4] = tblMTDTop55;
            _tables[5] = tblMTDTop56;
            _tables[6] = tblMTDTop57;
            _tables[7] = tblMTDTop58;
            _tables[8] = tblMTDTop59;
            _tables[9] = tblMTDTop510;

            _H3 = new object[10];
            _H3[0] = hMTDTop51;
            _H3[1] = hMTDTop52;
            _H3[2] = hMTDTop53;
            _H3[3] = hMTDTop54;
            _H3[4] = hMTDTop55;
            _H3[5] = hMTDTop56;
            _H3[6] = hMTDTop57;
            _H3[7] = hMTDTop58;
            _H3[8] = hMTDTop59;
            _H3[9] = hMTDTop510;


            _lastResults = true;

            statistics.OnInvoiceMonthToDateTop10 += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDateTop10);
            statistics.GetInvoiceTotalsMonthToDateTop10(DateTime.Now);
            AddSummary();
        }

        void statistics_OnInvoiceMonthToDateTop10(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            if (_lastCountry != e.Country)
            {
                if (_lastCountry == "")
                {
                    _currentRecord = 0;
                }
                else
                {
                    AddSummary();
                    _currentRecord++;
                }

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
                _lastYear += e.Total;
                TableCell PrevResults = new TableCell();
                PrevResults.Text = SharedUtils.FormatMoney(e.Total, GetWebsiteCurrency());
                PreviousRow.Cells.Add(PrevResults);
            }
            else
            {
                _currentYear += e.Total;
                _difference += e.Difference;

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

        private void AddSummary()
        {
            Table CurrentTable = (Table)_tables[_currentRecord];
            TableRow CurrentRow = CurrentTable.Rows[1];
            TableRow PreviousRow = CurrentTable.Rows[2];
            TableRow DiffRow = CurrentTable.Rows[3];
            TableRow PercRow = CurrentTable.Rows[4];


            TableCell PrevResults = new TableCell();
            PrevResults.Text = SharedUtils.FormatMoney(_lastYear, GetWebsiteCurrency());
            PreviousRow.Cells.Add(PrevResults);


            TableCell CurrResults = new TableCell();
            CurrResults.Text = SharedUtils.FormatMoney(_currentYear, GetWebsiteCurrency());
            CurrentRow.Cells.Add(CurrResults);

            TableCell Diff = new TableCell();
            Diff.Text = SharedUtils.FormatMoney(_difference, GetWebsiteCurrency());

            if (_difference < 0.00m)
                CellTextRed(Diff);

            DiffRow.Cells.Add(Diff);

            TableCell Percent = new TableCell();
            double perc;
            
            if (_difference < 0)
                perc = Shared.Utilities.Percentage((double)_lastYear, (double)_difference);
            else
                perc = Shared.Utilities.Percentage((double)_currentYear, (double)_difference);

            Percent.Text = String.Format("{0}%", perc);

            if (perc < 0)
                CellTextRed(Percent);

            PercRow.Cells.Add(Percent);

            TableHeaderCell Header = new TableHeaderCell();
            Header.Text = "Summary";
            CurrentTable.Rows[0].Cells.Add(Header);



            _currentYear = 0;
            _lastYear = 0;
            _difference = 0;

        }

        private void CellTextRed(TableCell cell)
        {
            string Old = cell.Text;

            cell.Text = String.Format("<font color=\"red\">{0}</font>", Old);
        }
    }
}