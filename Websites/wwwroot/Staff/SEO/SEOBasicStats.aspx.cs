using System;

using Library;
using Library.BOL.SEO;
using webLib = Website.Library.Classes;

namespace SieraDelta.Website.Staff.SEO
{
    public partial class SEOBasicStats : webLib.BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SeoReports hourlyData = SeoReports.SEODataHourly();
            hourlyData.Reverse();
            SeoReports dailyData = SeoReports.SEODataDaily();
            SeoReports weeklyData = SeoReports.SEOWeekly();
            weeklyData.Reverse();
            SeoReports monthlyData = SeoReports.SEOMonthly();
            monthlyData.Reverse();

            chartHourlyUsers.AutoUpdate(hourlyData, "Hourly", "User Visits", "Area", "Mobile Visits", "Line");
            chartDailyUsers.AutoUpdate(dailyData, "Daily", "User Visits", "Area", "Mobile Visits", "Line");
            chartWeeklyUsers.AutoUpdate(weeklyData, "Weekly", "User Visits", "Area", "Mobile Visits", "Line");
            chartMonthlyUsers.AutoUpdate(monthlyData, "Monthly", "User Visits", "Area", "Mobile Visits", "Line");

            chartSalesHourly.AutoUpdate(hourlyData, "Hourly", "Sales", "Bar");
            chartSalesDaily.AutoUpdate(dailyData, "Daily", "Sales", "Bar");
            chartSalesWeekly.AutoUpdate(weeklyData, "Weekly", "Sales", "Bar");
            chartSalesMonthly.AutoUpdate(monthlyData, "Monthly", "Sales", "Bar");

            chartConvertHourly.AutoUpdate(hourlyData, "Hourly", "Conversions", "Area", "Mobile Conversions", "Line",
                "Percent Converted", "Line", "Percent Converted Mobile", "Line");
            chartConvertDaily.AutoUpdate(dailyData, "Daily", "Conversions", "Area", "Mobile Conversions", "Line",
                "Percent Converted", "Line", "Percent Converted Mobile", "Line");
            chartConvertWeekly.AutoUpdate(weeklyData, "Weekly", "Conversions", "Area", "Mobile Conversions", "Line",
                "Percent Converted", "Line", "Percent Converted Mobile", "Line");
            chartConvertMonthly.AutoUpdate(monthlyData, "Monthly", "Conversions", "Area", "Mobile Conversions", "Line",
                "Percent Converted", "Line", "Percent Converted Mobile", "Line");

            chartReferGenHourly.AutoUpdate(hourlyData, "Hourly", "Refer Organic", "Line", "Refer Direct", "Line",
                "Referral", "Line", "Refer Unknown", "Line");
            chartReferGenDaily.AutoUpdate(dailyData, "Daily", "Refer Organic", "Line", "Refer Direct", "Line",
                "Referral", "Line", "Refer Unknown", "Line");
            chartReferGenWeekly.AutoUpdate(weeklyData, "Weekly", "Refer Organic", "Line", "Refer Direct", "Line",
                "Referral", "Line", "Refer Unknown", "Line");
            chartReferGenMonthly.AutoUpdate(monthlyData, "Monthly", "Refer Organic", "Line", "Refer Direct", "Line",
                "Referral", "Line", "Refer Unknown", "Line");

            chartReferSpHourly.AutoUpdate(hourlyData, "Hourly", "Refer Google", "Line", "Refer Twitter", "Line",
                "Refer Facebook", "Line", "Refer Bing", "Line", "Refer Yahoo", "Line");
            chartReferSpDaily.AutoUpdate(dailyData, "Daily", "Refer Google", "Line", "Refer Twitter", "Line",
                "Refer Facebook", "Line", "Refer Bing", "Line", "Refer Yahoo", "Line");
            chartReferSpWeekly.AutoUpdate(weeklyData, "Weekly", "Refer Google", "Line", "Refer Twitter", "Line",
                "Refer Facebook", "Line", "Refer Bing", "Line", "Refer Yahoo", "Line");
            chartReferSpMonthly.AutoUpdate(monthlyData, "Monthly", "Refer Google", "Line", "Refer Twitter", "Line",
                "Refer Facebook", "Line", "Refer Bing", "Line", "Refer Yahoo", "Line");

            chartBotDaily.AutoUpdate(dailyData, "Daily", "Bot Visits");
            chartBotWeekly.AutoUpdate(weeklyData, "Weekly", "Bot Visits");
            chartBotMonthly.AutoUpdate(monthlyData, "Monthly", "Bot Visits");

            DateTime now = DateTime.Now;

            chartVisitsByCountry.AutoUpdate(MapReportType.Country, 
                SeoReports.SEOMonthlyVisitsByCountry(now.Year, now.Month), true, 1,
                String.Format("Visitors By Country {0} {1}", now.ToString("MMMM"), now.Year));
            chartVisitsByCity.AutoUpdate(MapReportType.City,
                SeoReports.SEOMonthlyVisitsByCity(now.Year, now.Month), false, 2,
                String.Format("Visitors By City {0} {1}", now.ToString("MMMM"), now.Year));
            chartSalesByCountry.AutoUpdate(MapReportType.Currency,
                SeoReports.SEOMonthlySalesByCountry(now.Year, now.Month), false, 5,
                String.Format("Sales By Country {0} {1}", now.ToString("MMMM"), now.Year));
            chartSalesByCity.AutoUpdate(MapReportType.Currency,
                SeoReports.SEOMonthlySalesByCity(now.Year, now.Month), false, 6,
                String.Format("Sales By City {0} {1}", now.ToString("MMMM"), now.Year));


            now = now.AddMonths(-1);

            chartVisitsByCountryPrevious.AutoUpdate(MapReportType.Country,
                SeoReports.SEOMonthlyVisitsByCountry(now.Year, now.Month), false, 3,
                String.Format("Visitors By Country {0} {1}", now.ToString("MMMM"), now.Year));
            chartVisitsByCityPrevious.AutoUpdate(MapReportType.City,
                SeoReports.SEOMonthlyVisitsByCity(now.Year, now.Month), false, 4,
                String.Format("Visitors By City {0} {1}", now.ToString("MMMM"), now.Year));
            chartSalesByCountryPrevious.AutoUpdate(MapReportType.Currency,
                SeoReports.SEOMonthlySalesByCountry(now.Year, now.Month), false, 7,
                String.Format("Sales By Country {0} {1}", now.ToString("MMMM"), now.Year));
            chartSalesByCityPrevious.AutoUpdate(MapReportType.Currency,
                SeoReports.SEOMonthlySalesByCity(now.Year, now.Month), false, 8,
                String.Format("Sales By City {0} {1}", now.ToString("MMMM"), now.Year));
        }
    }
}