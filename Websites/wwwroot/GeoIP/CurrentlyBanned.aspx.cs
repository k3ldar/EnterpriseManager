using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.CustomWebPages;
using Library.BOL.IPAddresses;
using Library.BOL.Statistics;

namespace SieraDelta.Website.GeoIP
{
    public partial class CurrentlyBanned : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(ProductGroupTypes.Get("Products"));
        }

        protected string GetLocations()
        {
            string Result = String.Empty;

            //SimpleStatistics locations = Library.BOL.Statistics.Statistics.CurrentyBanned();

            //foreach (SimpleStatistic stat in locations)
            //{
            //    string[] ipMask = stat.StringValue1.Split('.');

            //    string ipAddress = ipMask[0] + "." + ipMask[1] + "." + ipMask[2] + ".xxx";

            //    TimeSpan span = DateTime.Now - stat.DateValue;
            //    string image = "0";

            //    if (span.TotalMinutes < 61)
            //        image = "3";
            //    else if (span.TotalHours < 6)
            //        image = "2";
            //    else if (span.TotalHours < 24)
            //        image = "1";

            //    Library.BOL.IPAddresses.IPCity city = Library.BOL.IPAddresses.IPCity.Get(stat.StringValue1, stat.StringValue1);
            //    Result += String.Format("['{0}\\rIP: {3}\\rDate Listed: {4}', {1}, {2}, {5}],", 
            //        stat.Description.Replace("\r", "").Replace("\n", ""), city.Latitude, city.Longitude, ipAddress, 
            //        stat.DateValue.ToString("g", System.Threading.Thread.CurrentThread.CurrentUICulture),
            //        image);
            //}

            //if (Result.EndsWith(","))
            //    Result = Result.Substring(0, Result.Length - 1);

            return (Result);
        }

        protected string CurrentlyBannedNumber()
        {
            Int64 currentlyBanned = 0;
            //Int64 previouslyBanned = 0;

            //Library.BOL.IPAddresses.IPAddresses.CurrentStatistics(ref currentlyBanned, ref previouslyBanned);
            return (currentlyBanned.ToString());
        }
    }
}