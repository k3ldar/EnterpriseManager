using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Mail;

namespace Heavenskincare.WebsiteTemplate.Admin.Email
{
    public partial class Index : BaseWebFormAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetStatusReport()
        {
            string reports = "";

            if (Global.StatusReport == null)
                reports += "No Email Server Messages";
            else
            {
                for (int i = 0; i < Global.StatusReport.Count; i++)
                {
                    EmailStatusReport e = (EmailStatusReport)Global.StatusReport[i];

                    foreach (StatusReportEntry entry in e)
                    {
                        reports += String.Format("<br /> {0} - {1} : {2}", entry.Time.ToString(), entry.To, entry.Subject);
                    }
                }
            }

            return (reports);
        }
    }
}