/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: SEOReport.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.SEO
{
    [Serializable]
    public sealed class SeoReport
    {
        #region Constructors

        /// <summary>
        /// Sales by country
        /// </summary>
        /// <param name="city"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="count"></param>
        /// <param name="currency"></param>
        /// <param name="totalSales"></param>
        public SeoReport(string city, double latitude, double longitude, int year, int month, 
            string currency, decimal totalSales)
        {
            City = city;
            Latitude = latitude;
            Longitude = longitude;
            Year = year;
            MonthNumber = month;
            Currency = currency;
            Sales = totalSales;
        }

        /// <summary>
        /// Sales by city
        /// </summary>
        /// <param name="city"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="count"></param>
        /// <param name="currency"></param>
        /// <param name="totalSales"></param>
        public SeoReport(string city, double latitude, double longitude, int year, int month, int count, 
            string currency, decimal totalSales)
            :this (city, latitude, longitude, year, month, currency, totalSales)
        {
            InvoiceCount = count;
        }

        /// <summary>
        /// Hourly
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <param name="quarter"></param>
        /// <param name="totalVisits"></param>
        /// <param name="humanVisits"></param>
        /// <param name="mobileVisits"></param>
        /// <param name="botVisits"></param>
        /// <param name="bounced"></param>
        /// <param name="totalPages"></param>
        /// <param name="dailySales"></param>
        /// <param name="conversions"></param>
        /// <param name="mobileConversions"></param>
        /// <param name="referUnknown"></param>
        /// <param name="referDirect"></param>
        /// <param name="referral"></param>
        /// <param name="referOrganic"></param>
        /// <param name="referBing"></param>
        /// <param name="referGoogle"></param>
        /// <param name="referYahoo"></param>
        /// <param name="referFacebook"></param>
        /// <param name="referTwitter"></param>
        public SeoReport(DateTime date, DateTime date2, int hour, Int64 totalVisits, Int64 humanVisits, Int64 mobileVisits, 
            Int64 botVisits,
            Int64 bounced, Int64 totalPages, decimal dailySales, Int64 conversions, Int64 mobileConversions,
            Int64 referUnknown, Int64 referDirect, Int64 referral, Int64 referOrganic, Int64 referBing, Int64 referGoogle,
            Int64 referYahoo, Int64 referFacebook, Int64 referTwitter)
        {
            Date = date;
            Hour = hour;
            //HourQuarter = quarter;
            TotalVisits = totalVisits;
            UserVisits = humanVisits;
            MobileVisits = mobileVisits;
            BotVisits = botVisits;
            Bounced = bounced;
            TotalPages = totalPages;
            Sales = dailySales;
            Conversions = conversions;
            MobileConversions = mobileConversions;
            ReferUnknown = referUnknown;
            ReferDirect = referDirect;
            Referral = referral;
            ReferOrganic = referOrganic;
            ReferBing = referBing;
            ReferGoogle = referGoogle;
            ReferYahoo = referYahoo;
            ReferFacebook = referFacebook;
            ReferTwitter = referTwitter;
        }



        /// <summary>
        /// Daily
        /// </summary>
        /// <param name="date"></param>
        /// <param name="totalVisits"></param>
        /// <param name="humanVisits"></param>
        /// <param name="mobileVisits"></param>
        /// <param name="botVisits"></param>
        /// <param name="bounced"></param>
        /// <param name="totalPages"></param>
        /// <param name="dailySales"></param>
        /// <param name="conversions"></param>
        /// <param name="mobileConversions"></param>
        /// <param name="referUnknown"></param>
        /// <param name="referDirect"></param>
        /// <param name="referral"></param>
        /// <param name="referOrganic"></param>
        /// <param name="referBing"></param>
        /// <param name="referGoogle"></param>
        /// <param name="referYahoo"></param>
        /// <param name="referFacebook"></param>
        /// <param name="referTwitter"></param>
        public SeoReport(DateTime date, Int64 totalVisits, Int64 humanVisits, Int64 mobileVisits, Int64 botVisits, 
            Int64 bounced, Int64 totalPages, decimal dailySales, Int64 conversions,  Int64 mobileConversions, 
            Int64 referUnknown, Int64 referDirect, Int64 referral, Int64 referOrganic, Int64 referBing, Int64 referGoogle, 
            Int64  referYahoo, Int64 referFacebook, Int64 referTwitter)
        {
            Date = date;
            TotalVisits = totalVisits;
            UserVisits = humanVisits;
            MobileVisits = mobileVisits;
            BotVisits = botVisits;
            Bounced = bounced;
            TotalPages = totalPages;
            Sales = dailySales;
            Conversions = conversions;
            MobileConversions = mobileConversions;
            ReferUnknown = referUnknown;
            ReferDirect = referDirect;
            Referral = referral;
            ReferOrganic = referOrganic;
            ReferBing = referBing;
            ReferGoogle = referGoogle;
            ReferYahoo = referYahoo;
            ReferFacebook = referFacebook;
            ReferTwitter = referTwitter;
        }

        /// <summary>
        /// Monthly
        /// </summary>
        /// <param name="date"></param>
        /// <param name="totalVisits"></param>
        /// <param name="botVisits"></param>
        /// <param name="bounced"></param>
        /// <param name="minimumPages"></param>
        /// <param name="maximumPages"></param>
        /// <param name="averagePages"></param>
        /// <param name="totalPages"></param>
        /// <param name="timedVisits"></param>
        /// <param name="conversions"></param>
        /// <param name="mobileConversions"></param>
        /// <param name="mobileVisits"></param>
        /// <param name="referUnknown"></param>
        /// <param name="referDirect"></param>
        /// <param name="referral"></param>
        /// <param name="referOrganic"></param>
        /// <param name="referBing"></param>
        /// <param name="referGoogle"></param>
        public SeoReport(int year, Int16 month, Int64 totalVisits, Int64 humanVisits, Int64 mobileVisits, Int64 botVisits, 
            Int64 bounced, Int64 totalPages, decimal dailySales, Int64 conversions,  Int64 mobileConversions, 
            Int64 referUnknown, Int64 referDirect, Int64 referral, Int64 referOrganic, Int64 referBing, Int64 referGoogle, 
            Int64  referYahoo, Int64 referFacebook, Int64 referTwitter)
        {
            Year = year;
             
            MonthNumber = month;
            TotalVisits = totalVisits;
            UserVisits = humanVisits;
            MobileVisits = mobileVisits;
            BotVisits = botVisits;
            Bounced = bounced;
            TotalPages = totalPages;
            Sales = dailySales;
            Conversions = conversions;
            MobileConversions = mobileConversions;
            ReferUnknown = referUnknown;
            ReferDirect = referDirect;
            Referral = referral;
            ReferOrganic = referOrganic;
            ReferBing = referBing;
            ReferGoogle = referGoogle;
            ReferYahoo = referYahoo;
            ReferFacebook = referFacebook;
            ReferTwitter = referTwitter;
        }

        /// <summary>
        /// Constructor for Weekly Reports
        /// </summary>
        /// <param name="date"></param>
        /// <param name="totalVisits"></param>
        /// <param name="botVisits"></param>
        /// <param name="bounced"></param>
        /// <param name="minimumPages"></param>
        /// <param name="maximumPages"></param>
        /// <param name="averagePages"></param>
        /// <param name="totalPages"></param>
        /// <param name="timedVisits"></param>
        /// <param name="conversions"></param>
        /// <param name="mobileConversions"></param>
        /// <param name="mobileVisits"></param>
        /// <param name="referUnknown"></param>
        /// <param name="referDirect"></param>
        /// <param name="referral"></param>
        /// <param name="referOrganic"></param>
        /// <param name="referBing"></param>
        /// <param name="referGoogle"></param>
        public SeoReport(int year, int week, Int64 totalVisits, Int64 humanVisits, Int64 mobileVisits, Int64 botVisits,
            Int64 bounced, Int64 totalPages, decimal dailySales, Int64 conversions, Int64 mobileConversions,
            Int64 referUnknown, Int64 referDirect, Int64 referral, Int64 referOrganic, Int64 referBing, Int64 referGoogle,
            Int64 referYahoo, Int64 referFacebook, Int64 referTwitter)
        {
            Year = year;
            WeekNumber = week;
            TotalVisits = totalVisits;
            UserVisits = humanVisits;
            MobileVisits = mobileVisits;
            BotVisits = botVisits;
            Bounced = bounced;
            TotalPages = totalPages;
            Sales = dailySales;
            Conversions = conversions;
            MobileConversions = mobileConversions;
            ReferUnknown = referUnknown;
            ReferDirect = referDirect;
            Referral = referral;
            ReferOrganic = referOrganic;
            ReferBing = referBing;
            ReferGoogle = referGoogle;
            ReferYahoo = referYahoo;
            ReferFacebook = referFacebook;
            ReferTwitter = referTwitter;
        }

        public SeoReport(string city, double latitude, double longitude, Int64 count)
        {
            City = city;
            Latitude = latitude;
            Longitude = longitude;
            TotalVisits = count;
        }

        public SeoReport(string country, string city, double latitude, double longitude, string name, 
            int visitors, string currency, decimal sales)
        {
            Country = country;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
            CampaignName = name;
            TotalVisits = visitors;
            Currency = currency;
            Sales = sales;
        }

        #endregion Constructors

        #region Properties

        public DateTime Date { get; private set; }

        public int MonthNumber { get; private set; }

        public string Month
        {
            get
            {
                DateTime date = new DateTime(Year, MonthNumber, 1);
                return (date.ToString("MMM yyyy"));
            }
        }

        public int WeekNumber { get; private set; }

        public int Year { get; private set; }

        public string Week 
        { 
            get
            {
                return (String.Format("Week {0} - {1}", WeekNumber, Year));
            }
        }

        public int Hour { get; private set; }

        public string Hourly
        {
            get
            {
                return (String.Format("{0} {1}.00 - {1}.59", Date.ToString("ddd"), Hour));
            }
        }

        public int HourQuarter { get; set; }

        public Int64 TotalVisits { get; private set; }

        public Int64 UserVisits { get; private set; }

        public Int64 BotVisits { get; private set; }

        public Int64 Bounced { get; private set; }

        public Int64 MinimumPages { get; private set; }

        public Int64 MaximumPages { get; private set; }

        public Int64 AveragePages { get; private set; }

        public Int64 TotalPages { get; private set; }

        public Int64 TimedVisits { get; private set; }

        public Int64 Conversions { get; private set; }

        public Int64 MobileConversions { get; private set; }

        public double PercentConverted
        {
            get
            {
                return (Shared.Utilities.Percentage(Convert.ToDouble(UserVisits), Convert.ToDouble(Conversions)));
            }
        }

        public double PercentConvertedMobile
        {
            get
            {
                try
                {
                    return (Shared.Utilities.Percentage(Convert.ToDouble(Conversions), Convert.ToDouble(MobileConversions)));
                }
                catch
                {
                    return (0.00);
                }
            }
        }

        public Int64 MobileVisits { get; private set; }

        public Int64 ReferUnknown { get; private set; }

        public Int64 ReferDirect { get; private set; }

        public Int64 Referral { get; private set; }

        public Int64 ReferOrganic { get; private set; }

        public Int64 ReferBing { get; private set; }

        public Int64 ReferGoogle { get; private set; }

        public Int64 ReferYahoo { get; private set; }

        public Int64 ReferFacebook { get; private set; }

        public Int64 ReferTwitter { get; private set; }

        public decimal Sales { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Currency { get; private set; }

        public int InvoiceCount { get; set; }

        public string CampaignName { get; set; }

        #endregion Properties
    }
}
