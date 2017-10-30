using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Statistics;

namespace Heavenskincare.WebsiteTemplate.Staff.Reports
{
    public partial class MetaStatistics : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetProductInformation()
        {
            string Result = String.Empty;

            SimpleStatistics stats = Library.BOL.Statistics.Statistics.GetSEOStatistics();

            foreach (SimpleStatistic stat in stats)
            {
                if (stat.Count == 0 || stat.Count < 5 || String.IsNullOrEmpty(stat.Name2) || String.IsNullOrEmpty(stat.Name3))
                    Result += String.Format("<h3>{0}</h3><p>Title: {1}</p><p>HashTagCount: {2}</p><p>Description: {3}</p><p><a href=\"{4}\" targt=\"_blank\">Visit Product Page</a></p>",
                        stat.Description, stat.Name2, stat.Count, stat.Name3, stat.Name1);
            }

            return (Result);
        }
    }
}