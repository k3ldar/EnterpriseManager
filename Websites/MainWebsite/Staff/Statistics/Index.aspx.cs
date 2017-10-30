using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.Invoices;
using Library.BOL.Statistics;
using Shared.Classes;

namespace Heavenskincare.WebsiteTemplate.Staff.Statistics
{
    public partial class Index : BaseWebFormAdmin
    {
        private List<UserSession> _sessionCopy;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _sessionCopy = UserSessionManager.Clone;
            }
            catch (LockTimeoutException)
            {
                // ignore
            }

            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }


        protected string GetWebOfferStats()
        {
            string Result = "No Offers At Present Time";

            //if (Global.ShowOffers)
            //{
            //    Result = WebAdmin.GetStats();
            //}

            return (Result);
        }

        protected string GetWebOfferStats(string Campaign)
        {
            return (WebAdmin.GetCampaignStats(Campaign));
        }


        protected string GetWebStats()
        {
            string Result = String.Format("{0}<br /><br />", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            Result += LoadInvoices();
            Result += LoadInvoicesToProcess();
            Result += LoadUnpaidOrderStatistic();
            Result += "<h3>Other Statistics</h3>";
            Result += LoadSalonUpdates();
            Result += LoadMailData();
            Result += LoadSupportTicketData();
            Result += LoadComments();
            Result += LoadAppointments();
            Result += LoadTodaysAppointments();
            Result += LoadNextWeeksAppointments();
            Result += BannedIPAddresses();

            Result += String.Format("<p>Date Loaded: {0}</p>", Global.DateLoaded.ToString("g"));

            return (Result);
        }

        private string LoadNextWeeksAppointments()
        {
            int Appointments = WebAdmin.StatsAppointments(Enums.AppointmentStats.WeeksAppointments);
            return (String.Format("<p>Next 7 Days Appointments: {0}</p>", Appointments));
        }

        private string BannedIPAddresses()
        {
            int ipCount = WebAdmin.StatsBannedIP();
            return (String.Format("<p>Banned IP Addresses: {0}</p>", ipCount));
        }

        private string LoadTodaysAppointments()
        {
            int Appointments = WebAdmin.StatsAppointments(Enums.AppointmentStats.TodaysAppointments);
            return (String.Format("<p>Todays Appointments: {0}</p>", Appointments));
        }

        private string LoadAppointments()
        {
            int Appointments = WebAdmin.StatsAppointments(Enums.AppointmentStats.NewAppointments);
            return (String.Format("<p>New Appointments: {0}</p>", Appointments));
        }

        private string LoadComments()
        {
            int Comments = WebAdmin.StatsComments();
            return (String.Format("<p>New Comments: {0}</p>", Comments));
        }

        private string LoadSupportTicketData()
        {
            string TicketStats = "";

            TicketStats += String.Format("On Hold: {0}; Open: {1}; <br />",
                WebAdmin.StatsTickets(Enums.TicketStatus.OnHold),
                WebAdmin.StatsTickets(Enums.TicketStatus.Open));

            TicketStats = "<p>Support tickets: " + TicketStats + "</p>";
            return (TicketStats);
        }

        private string LoadSalonUpdates()
        {
            int SalonUpdates = WebAdmin.StatsSalonUpdates();
            return (String.Format("<p>Salon Updates: {0}<br /></p>", SalonUpdates));
        }

        private string LoadInvoicesToProcess()
        {
            string Result = "<h3>Invoices To Process</h3>";

            SimpleStatistics stats = Invoices.InvoicesGetStats(GetUser(), -1, -1, false, ProcessStatuses.OrderReceived | ProcessStatuses.Processing);

            foreach (SimpleStatistic stat in stats)
            {
                Result += String.Format("<p>{0} - {1} ({2})</p>", stat.Description, stat.Count,
                    SharedUtils.FormatMoney(stat.Value1, GetWebsiteCurrency()));
            }

            if (stats.Count == 0)
                Result += "<p>None</p>";

            return (Result);
        }

        private string LoadUnpaidOrderStatistic()
        {
            string Result = "<h3>Unpaid Orders</h3>";

            SimpleStatistics stats = Library.BOL.Statistics.Statistics.GetUnpaidOrderStatistics();

            foreach (SimpleStatistic stat in stats)
            {
                Result += String.Format("<p>{0} - {1} ({2})</p>", stat.Description, stat.Count, SharedUtils.FormatMoney(stat.Value1, GetWebsiteCurrency()));
            }

            if (stats.Count == 0)
                Result = String.Empty;

            return (Result);
        }

        private string LoadInvoices()
        {
            string Result = "<h3>Today's Invoices</h3>";

            SimpleStatistics stats = Invoices.InvoicesGetStats(GetUser(), -1, -1, true, ProcessStatuses.OrderReceived | ProcessStatuses.Processing);

            foreach (SimpleStatistic stat in stats)
            {
                Result += String.Format("<p>{0} - {1} ({2})</p>", stat.Description, stat.Count, 
                    SharedUtils.FormatMoney(stat.Value1, GetWebsiteCurrency()));
            }

            if (stats.Count == 0)
                Result += "<p>None</p>";

            return (Result);
        }

        private string LoadMailData()
        {
            int ToProcess = WebAdmin.StatsMailCount(Enums.MailCount.ToProcess);
            int Queued = WebAdmin.StatsMailCount(Enums.MailCount.Queued);
            int Failed = WebAdmin.StatsMailCount(Enums.MailCount.Failed);

            return (String.Format("<p><a href=\"/Admin/Email/Index.aspx\">Mail Status</a>: To Process: {0}; Queued: {1}; Failed: {2}<br /></p>", ToProcess, Queued, Failed));
        }

    }
}