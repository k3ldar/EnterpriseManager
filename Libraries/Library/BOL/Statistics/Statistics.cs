using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Therapists;


namespace Library.BOL.Statistics
{
    [Serializable]
    public sealed class Statistics
    {
        #region Static Members

        private static object _lockObject = new object();

        #endregion Static Members

        #region Public Methods

        public Takings SalonProductSummary(DateTime from, DateTime to)
        {
            return (DAL.FirebirdDB.StatisticsSalesSalonProducts(from, to));
        }

        public Takings SalonTreatmentSummary(DateTime from, DateTime to)
        {
            return (DAL.FirebirdDB.StatisticsSalesSalonTreatments(from, to));
        }

        public Takings SalonSalesSummary(DateTime from, DateTime to)
        {
            return (DAL.FirebirdDB.StatisticsSalesSalonSummary(from, to));
        }

        /// <summary>
        /// Returns Invoice Summary Per Day
        /// </summary>
        /// <param name="from">From Date</param>
        /// <param name="to">To Date</param>
        /// <param name="countryCode">Country Code, leave blank for all countries</param>
        public void GetInvoiceTotalsDaily(DateTime month, string countryCode)
        {
            DAL.FirebirdDB.StatisticsDailyTotals(this, month, countryCode);
        }

        public void GetInvoiceTotalsMonthly(int year, string countryCode)
        {
            DAL.FirebirdDB.StatisticsMonthlyTotals(this, year, countryCode);
        }

        public void TimeLineEventsGet()
        {
            DAL.FirebirdDB.StatisticsTimeLineEventsGet(this);
        }

        public void GetInvoiceTotalsMonthToDateTop5Salons(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateTop5Salons(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateSalons(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthtoDateBySalons(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateByYear(DateTime Date, string countryCode, int type)
        {
            DAL.FirebirdDB.StatisticsMonthToDate(this, Date, countryCode, type);
        }

        public void GetInvoiceTotalsMonthToDate(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDate(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateOnline(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateOnline(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateSalon(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateSalon(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateOffice(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateOffice(this, Date);
        }

        public void GetInvoiceTotalCountMonthToDate(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateCount(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateSalonOwners(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateBySalonOwners(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateTop5(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateTop5Countries(this, Date);
        }

        public void GetInvoiceTotalsMonthToDateTop10(DateTime Date)
        {
            DAL.FirebirdDB.StatisticsMonthToDateTop10Countries(this, Date);
        }

        public void GetInvoicesTotalsByMonth(DateTime Month)
        {
            DAL.FirebirdDB.StatisticsInvoiceTotalByMonth(this, Month);
        }

        public void GetInvoiceCountByDay(int TotalDays, DateTime DateFrom)
        {
            DAL.FirebirdDB.StatisticsInvoiceCountByDay(this, TotalDays, DateFrom);
        }

        public void GetVisitorsByCountry(int Count)
        {
            DAL.FirebirdDB.StatisticsVisitorsByCountry(this, Count);
        }

        public void GetVisitorsByCountryToday(int Count)
        {
            DAL.FirebirdDB.StatisticsVisitorsByCountryToday(this, Count);
        }

        public SimpleStatistics GetAppointmentTotals(DateTime startDate, DateTime endDate)
        {
            return (DAL.FirebirdDB.StatisticsAppointmentSummary(startDate, endDate));
        }


        public static SimpleStatistics GetSEOStatistics()
        {
            return (DAL.FirebirdDB.StatisticsSEOStatistics());
        }

        #endregion Public Methods

        #region Events Wrappers

        internal void DoInvoiceMonthToDate(int Year, int Month, decimal Total, 
            decimal Difference, int Percent, DateTime Start, DateTime End)
        {
            if (OnInvoiceMonthToDate != null)
                OnInvoiceMonthToDate(this, new InvoiceMonthToDateArgs(Year, Month, Total, Difference, Percent, Start, End));
        }

        internal void DoInvoiceMonthToDateOnline(int Year, int Month, decimal Total, 
            decimal Difference, int Percent, DateTime Start, DateTime End)
        {
            if (OnInvoiceMonthToDateOnline != null)
                OnInvoiceMonthToDateOnline(this, new InvoiceMonthToDateArgs(Year, Month, Total, Difference, Percent, Start, End));
        }

        internal void DoInvoiceMonthToDateSalon(int Year, int Month, decimal Total, 
            decimal Difference, int Percent, DateTime Start, DateTime End)
        {
            if (OnInvoiceMonthToDateSalon != null)
                OnInvoiceMonthToDateSalon(this, new InvoiceMonthToDateArgs(Year, Month, Total, Difference, Percent, Start, End));
        }

        internal void DoInvoiceMonthToDateOffice(int Year, int Month, decimal Total, 
            decimal Difference, int Percent, DateTime Start, DateTime End)
        {
            if (OnInvoiceMonthToDateOffice != null)
                OnInvoiceMonthToDateOffice(this, new InvoiceMonthToDateArgs(Year, Month, Total, Difference, Percent, Start, End));
        }

        internal void DoInvoiceMonthToDateTop10(string Country, int Year, int Month,
            decimal Total, decimal Difference, int Percent, DateTime Start, DateTime End)
        {
            if (OnInvoiceMonthToDateTop10 != null)
                OnInvoiceMonthToDateTop10(this, new InvoiceMonthToDateArgs(Country, Year, Month, Total, Difference, Percent, Start, End));
        }

        internal void DoInvoiceMonthToDateTop5(string Country, int Year, int Month,
            decimal Total, decimal Difference, int Percent, DateTime Start, DateTime End)
        {
            if (OnInvoiceMonthToDateTop5 != null)
                OnInvoiceMonthToDateTop5(this, new InvoiceMonthToDateArgs(Country, Year, Month, Total, Difference, Percent, Start, End));
        }

        internal void DoInvoicesTotalsByMonth(int Year, int Month, decimal Total)
        {
            if (OnInvoiceTotalsByMonth != null)
                OnInvoiceTotalsByMonth(this, new InvoiceTotalsByMonthArgs(Year, Month, Total));
        }

        internal void DoInvoiceTotalCountByMonth(int Year, int Month, int Count, int Difference, 
            int Percent, DateTime Start, DateTime End)
        {
            if (OnInvoiceMonthtoDateCount != null)
                OnInvoiceMonthtoDateCount(this, new InvoiceMonthToDateCountArgs(Year, Month, Count, Difference, Percent, Start, End));
        }

        internal void DoInvoiceCountByDay(DateTime Date, int Total)
        {
            if (OnInvoiceCountByDay != null)
                OnInvoiceCountByDay(this, new InvoiceCountByDayArgs(Date, Total));
        }

        internal void DoVisitorTotalsByCountry(string Country, string CountryCode, int Count)
        {
            if (OnVisitorTotalsByCountry != null)
                OnVisitorTotalsByCountry(this, new VisitorTotalsByCountryArgs(Country, CountryCode, Count));
        }

        internal void DoDailySalesTotal(DateTime date, decimal totalSales)
        {
            if (OnDailySalesTotals != null)
                OnDailySalesTotals(this, new InvoiceTotalsByDayArgs(date, totalSales));
        }

        internal void DoTimeLineEvent(Int64 id, DateTime date, string eventDescription, string eventText,
            decimal eventCost, Int32 eventVisits, decimal eventSales, int eventCountry, Int64 eventCirculation)
        {
            if (OnTimeLineEvent != null)
                OnTimeLineEvent(this, new TimeLineEventArgs(id, date, eventDescription, eventText, 
                    eventCost, eventVisits, eventSales, eventCountry, eventCirculation));
        }

        #endregion Events Wrappers

        #region Delegate Parameters

        public sealed class TimeLineEventArgs : EventArgs
        {
            public TimeLineEventArgs(Int64 id, DateTime date, string eventDescription, string eventText,
                decimal eventCost, Int32 eventVisits, decimal eventSales, int eventCountry, 
                Int64 eventCirculation) 
            { 
                ID = id; 
                Date = date; 
                EventDescription = eventDescription; 
                EventText = eventText; 

                EventCost = eventCost;
                EventVisits = eventVisits;
                EventSales = eventSales;
                EventCountry = eventCountry;
                EventCirculation = eventCirculation;
            }

            public Int64 ID { get; private set; }
            public DateTime Date { get; private set; }
            public string EventDescription { get; private set; }
            public string EventText { get; private set; }
            public decimal EventCost { get; private set; }
            public Int32 EventVisits { get; private set; }
            public decimal EventSales {get; private set; }
            public int EventCountry {get; private set; }
            public Int64 EventCirculation { get; private set; }
        }

        public sealed class InvoiceTotalsByDayArgs : EventArgs
        {
            public InvoiceTotalsByDayArgs(DateTime day, decimal totalSales) { Day = day; TotalSales = totalSales; }

            public DateTime Day { get; private set; }
            public decimal TotalSales { get; private set; }
        }

        public sealed class InvoiceTotalsByMonthArgs : EventArgs
        {
            public InvoiceTotalsByMonthArgs(int year, int month, decimal total) { Year = year; Month = month; Total = total; }

            public int Month { get; private set; }
            public int Year { get; private set; }
            public decimal Total { get; private set; }
        }

        public sealed class InvoiceCountByDayArgs : EventArgs
        {
            public InvoiceCountByDayArgs(DateTime date, int count) { Date = date; Count = count; }

            public DateTime Date { get; private set; }
            public int Count { get; private set; }
        }

        public sealed class InvoiceMonthToDateArgs : EventArgs
        {
            public InvoiceMonthToDateArgs(int year, int month, decimal total, decimal difference, int percent, DateTime startDate, DateTime endDate) { Year = year; Month = month; Total = total; Difference = difference; Percent = percent; StartDate = startDate; EndDate = endDate; }
            public InvoiceMonthToDateArgs(string country, int year, int month, decimal total, decimal difference, int percent, DateTime startDate, DateTime endDate) { Country = country; Year = year; Month = month; Total = total; Difference = difference; Percent = percent; StartDate = startDate; EndDate = endDate; }

            public string Country { get; private set; }
            public int Month { get; private set; }
            public int Year { get; private set; }
            public decimal Total { get; private set; }
            public decimal Difference { get; private set; }
            public int Percent { get; private set; }
            public DateTime StartDate { get; private set; }
            public DateTime EndDate { get; private set; }
        }

        public sealed class InvoiceMonthToDateCountArgs : EventArgs
        {
            public InvoiceMonthToDateCountArgs(int year, int month, int total, int difference, int percent, DateTime startDate, DateTime endDate) { Year = year; Month = month; Total = total; Difference = difference; Percent = percent; StartDate = startDate; EndDate = endDate; }
            public InvoiceMonthToDateCountArgs(string country, int year, int month, int total, int difference, int percent, DateTime startDate, DateTime endDate) { Country = country; Year = year; Month = month; Total = total; Difference = difference; Percent = percent; StartDate = startDate; EndDate = endDate; }

            public string Country { get; private set; }
            public int Month { get; private set; }
            public int Year { get; private set; }
            public int Total { get; private set; }
            public int Difference { get; private set; }
            public int Percent { get; private set; }
            public DateTime StartDate { get; private set; }
            public DateTime EndDate { get; private set; }
        }

        public sealed class VisitorTotalsByCountryArgs : EventArgs
        {
            public VisitorTotalsByCountryArgs(string country, string countryCode, int count) { Country = country; CountryCode = countryCode; Count = count; }

            public string Country { get; private set; }
            public string CountryCode { get; private set; }
            public int Count { get; private set; }
        }

        #endregion Delegate Parameters

        #region Delegates

        public delegate void InvoiceTotalsByMonthDelegate(object sender, InvoiceTotalsByMonthArgs e);
        public delegate void InvoiceCountByDayDelegate(object sender, InvoiceCountByDayArgs e);
        public delegate void VisitorTotalsByCountryDelegate(object sender, VisitorTotalsByCountryArgs e);
        public delegate void InvoiceMonthToDateDelegate(object sender, InvoiceMonthToDateArgs e);
        public delegate void InvoiceMonthToDateCountDelegate(object sender, InvoiceMonthToDateCountArgs e);
        public delegate void InvoiceTotalsByDayDelegate(object sender, InvoiceTotalsByDayArgs e);
        public delegate void TimeLineEventDelegate(object sender, TimeLineEventArgs e);

        #endregion Delegates

        #region Events 

        public event InvoiceTotalsByMonthDelegate OnInvoiceTotalsByMonth;
        public event InvoiceCountByDayDelegate OnInvoiceCountByDay;
        public event VisitorTotalsByCountryDelegate OnVisitorTotalsByCountry;
        public event InvoiceMonthToDateDelegate OnInvoiceMonthToDate;
        public event InvoiceMonthToDateDelegate OnInvoiceMonthToDateTop5;
        public event InvoiceMonthToDateDelegate OnInvoiceMonthToDateTop10;
        public event InvoiceMonthToDateCountDelegate OnInvoiceMonthtoDateCount;
        public event InvoiceMonthToDateDelegate OnInvoiceMonthToDateSalon;
        public event InvoiceMonthToDateDelegate OnInvoiceMonthToDateOffice;
        public event InvoiceMonthToDateDelegate OnInvoiceMonthToDateOnline;
        public event InvoiceTotalsByDayDelegate OnDailySalesTotals;
        public event TimeLineEventDelegate OnTimeLineEvent;

        #endregion Events

        #region Static Methods

        public static BOL.Statistics.SimpleStatistics TopProducts(int number, int days)
        {
            return (DAL.FirebirdDB.StatisticsGetTopProducts(number, days, false));
        }

        public static void TopProductsSet(int number, int days)
        {
            DAL.FirebirdDB.StatisticsGetTopProducts(number, days, true);
        }


        /// <summary>
        /// Gets visitor location statistics
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static SimpleStatistics GetVisitorLocations(decimal age)
        {
            return (DAL.FirebirdDB.GetVisitorLocations(age));
        }

        /// <summary>
        /// Get's unpaid order statistics
        /// </summary>
        /// <returns></returns>
        public static SimpleStatistics GetUnpaidOrderStatistics()
        {
            return (DAL.FirebirdDB.GetUnpaidStatistics());
        }

        /// <summary>
        /// updates a hit count for a redirect
        /// </summary>
        /// <param name="url">url being redirected</param>
        public static void UpdateRedirect(string url)
        {
            if (url.Length > 499)
                url = url.Substring(0, 499);

            using (Shared.Classes.TimedLock.Lock(_lockObject))
            {
                DAL.FirebirdDB.StatisticsUpdateRedirectHitCount(url);
            }
        }

        public static int RedirectHitCount(string url)
        {
            if (url.Length > 499)
                url = url.Substring(0, 499);

            using (Shared.Classes.TimedLock.Lock(_lockObject))
            {
                return (DAL.FirebirdDB.StatisticsRedirectGetHitCount(url));
            }
        }

        #endregion Static Methods
    }
}
