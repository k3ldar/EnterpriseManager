﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Countries;

namespace Heavenskincare.WebsiteTemplate.Staff.Statistics
{
    public partial class MonthToDateByYear : BaseWebFormStaff
    {
        private bool _lastResults = true;
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

            if (!IsPostBack)
            {
                AddCountries();
                AddYears();
            }
        }

        /// <summary>
        /// Colors a cell red if it's a negative value
        /// </summary>
        /// <param name="cell"></param>
        private void CellTextRed(TableCell cell)
        {
            string Old = cell.Text;

            cell.Text = String.Format("<font color=\"red\">{0}</font>", Old);
        }

        /// <summary>
        /// Resets global variables and adds a totals column
        /// </summary>
        private void UpdateMonthToDateTotals(TableRow rowHeader, TableRow rowPrevious, TableRow rowCurrent, TableRow rowDifference, 
            TableRow rowPercent, bool moneyValue = true)
        {
            int percentage = 0;

            try
            {
                percentage = (int)Math.Round((decimal)(100 * _difference) / _currentYear);
            }
            catch (Exception err)
            {
                if (!err.Message.Contains("Attempted to divide by zero"))
                    Library.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, rowHeader, rowPrevious, rowCurrent,
                        rowDifference, rowPercent, moneyValue, _difference, _currentYear, _lastYear, _lastResults);
            }

            UpdateTable(rowHeader, rowPrevious, rowCurrent, rowDifference, rowPercent, _currentYear, _lastYear, _difference, percentage, 1, DateTime.Now, true, moneyValue);
            _lastResults = false;
            UpdateTable(rowHeader, rowPrevious, rowCurrent, rowDifference, rowPercent, _currentYear, _lastYear, _difference, percentage, 1, DateTime.Now, true, moneyValue);

            //reset variables
            _currentYear = 0.00m;
            _lastYear = 0.00m;
            _difference = 0.00m;
            _lastResults = true;
        }

        void statistics_OnInvoiceMonthToDateOffice(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            UpdateTable(tblMTDOfficeHeader, tblMTDOfficePreviousRow, tblMTDOfficeCurrentRow, tblMTDOfficeDiffRow, tblMTDOfficePercent, e.Total, e.Total, e.Difference, e.Percent, e.Year, e.StartDate);
        }

        void statistics_OnInvoiceMonthToDateSalon(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            UpdateTable(tblMTDSalonHeader, tblMTDSalonPreviousRow, tblMTDSalonCurrentRow, tblMTDSalonDiffRow, tblMTDSalonPercent, e.Total, e.Total, e.Difference, e.Percent, e.Year, e.StartDate);
        }

        void statistics_OnInvoiceMonthToDateOnline(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            UpdateTable(tblMTDOnlineHeader, tblMTDOnlinePreviousRow, tblMTDOnlineCurrentRow, tblMTDOnlineDiffRow, tblMTDOnlinePercent, e.Total, e.Total, e.Difference, e.Percent, e.Year, e.StartDate);
        }

        void statistics_OnInvoiceMonthToDate(object sender, Library.BOL.Statistics.Statistics.InvoiceMonthToDateArgs e)
        {
            UpdateTable(tblMTDHeader, tblMTDPreviousRow, tblMTDCurrentRow, tblMTDDiffRow, tblMTDPercent, e.Total, e.Total, e.Difference, e.Percent, e.Year, e.StartDate);
        }

        private void UpdateTable(TableRow rowHeader, TableRow rowPrevious, TableRow rowCurrent, TableRow rowDifference, TableRow rowPercent,
            decimal totalCurrent, decimal totalPrevious, decimal totalDifference, int percentage, int year, DateTime startDate, 
            bool summary = false, bool moneyValue = true)
        {
            if (_lastResults)
            {
                _lastYear += totalPrevious;

                TableCell PrevResults = new TableCell();

                if (moneyValue)
                    PrevResults.Text = SharedUtils.FormatMoney(totalPrevious, GetWebsiteCurrency());
                else
                    PrevResults.Text = totalPrevious.ToString();

                rowPrevious.Cells.Add(PrevResults);
            }
            else
            {
                bool isNewer = startDate.Date.AddMonths(1).AddDays(-1) > System.DateTime.Now.Date;

                _currentYear += totalCurrent;
                _difference += totalDifference;

                TableCell CurrResults = new TableCell();

                if (moneyValue)
                    CurrResults.Text = SharedUtils.FormatMoney(totalCurrent, GetWebsiteCurrency());
                else
                    CurrResults.Text = totalCurrent.ToString();

                rowCurrent.Cells.Add(CurrResults);

                TableCell Diff = new TableCell();

                if (moneyValue)
                    Diff.Text = SharedUtils.FormatMoney(totalDifference, GetWebsiteCurrency());
                else
                    Diff.Text = totalDifference.ToString();

                if (totalDifference < 0.00m)
                    CellTextRed(Diff);

                if (isNewer)
                    Diff.Text = String.Empty;

                rowDifference.Cells.Add(Diff);

                TableCell Percent = new TableCell();
                Percent.Text = String.Format("{0}%", percentage);

                if (percentage < 0)
                    CellTextRed(Percent);

                if (isNewer)
                    Percent.Text = String.Empty;

                rowPercent.Cells.Add(Percent);

                TableHeaderCell Header = new TableHeaderCell();

                if (summary)
                    Header.Text = "Summary";
                else
                    Header.Text = String.Format("{0} {1}/{2}", startDate.ToString("MMM"), year, year - 1);

                rowHeader.Cells.Add(Header);
            }

            _lastResults = !_lastResults;
        }

        private void AddCountries()
        {
            ddlCountries.Items.Clear();

            ddlCountries.Items.Add(new ListItem("All", String.Empty));

            foreach (Country country in Countries.Get())
            {
                ddlCountries.Items.Add(new ListItem(country.Name, country.CountryCode));
            }

            ddlCountries.SelectedIndex = 0;
        }

        private void AddYears()
        {
            ddlYears.Items.Clear();

            for (int i = 0; i > -8; i--)
            {
                ddlYears.Items.Add(new ListItem(DateTime.Now.AddYears(i).Year.ToString()));

            }

            ddlYears.SelectedIndex = 0;

            ddlYears_SelectedIndexChanged(this, EventArgs.Empty);
        }

        protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
        {

            Library.BOL.Statistics.Statistics statistics = new Library.BOL.Statistics.Statistics();
            statistics.OnInvoiceMonthToDate += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDate);
            statistics.OnInvoiceMonthToDateOnline += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDateOnline);
            statistics.OnInvoiceMonthToDateSalon += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDateSalon);
            statistics.OnInvoiceMonthToDateOffice += new Library.BOL.Statistics.Statistics.InvoiceMonthToDateDelegate(statistics_OnInvoiceMonthToDateOffice);

            DateTime year;
            int yr = DateTime.Now.Year;

            if (ddlYears.SelectedIndex != -1)
                yr = Shared.Utilities.StrToInt(ddlYears.SelectedItem.Text, yr);

            year = new DateTime(yr, 12, 31);

            string country = String.Empty;

            if (ddlCountries.SelectedIndex != -1)
                country = ddlCountries.SelectedItem.Value;

            statistics.GetInvoiceTotalsMonthToDateByYear(year, country, 0);
            UpdateMonthToDateTotals(tblMTDHeader, tblMTDPreviousRow, tblMTDCurrentRow, tblMTDDiffRow, tblMTDPercent);

            statistics.GetInvoiceTotalsMonthToDateByYear(year, country, 3);
            UpdateMonthToDateTotals(tblMTDOnlineHeader, tblMTDOnlinePreviousRow, tblMTDOnlineCurrentRow, tblMTDOnlineDiffRow, tblMTDOnlinePercent);

            statistics.GetInvoiceTotalsMonthToDateByYear(year, country, 2);
            UpdateMonthToDateTotals(tblMTDSalonHeader, tblMTDSalonPreviousRow, tblMTDSalonCurrentRow, tblMTDSalonDiffRow, tblMTDSalonPercent);

            statistics.GetInvoiceTotalsMonthToDateByYear(year, country, 1);
            UpdateMonthToDateTotals(tblMTDOfficeHeader, tblMTDOfficePreviousRow, tblMTDOfficeCurrentRow, tblMTDOfficeDiffRow, tblMTDOfficePercent);
        }
    }
}