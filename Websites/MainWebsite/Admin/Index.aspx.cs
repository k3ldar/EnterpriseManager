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

namespace Heavenskincare.WebsiteTemplate.Admin
{
    public partial class Index : BaseWebFormAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoRedirect("/staff/statistics/index.aspx", true);

            //LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            //LeftContainerControl1.SubOptions = GetAccountOptions();

            //if (GetFormValue("UpdateTags") == "Yes")
            //    Library.BOL.TagLines.TagLines.Reset();

            //DoRedirect("/staff/Statistics/Index.aspx");
        }

        protected string GetWebStats()
        {
            string Result = String.Format("{0}<br /><br />", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            
            Result += LoadInvoices();
            Result += LoadInvoicesToProcess();
            Result += LoadSalonUpdates();
            Result += LoadMailData();
            Result += LoadSupportTicketData();
            Result += LoadComments();
            Result += LoadAppointments();

            return (Result);
        }

        private string LoadAppointments()
        {
            int Appointments = WebAdmin.StatsAppointments(Enums.AppointmentStats.NewAppointments);
            return (String.Format("New Appointments: {0}<br />", Appointments));
        }

        private string LoadComments()
        {
            int Comments = WebAdmin.StatsComments();
            return (String.Format("New Comments: {0}<br />", Comments));
        }

        private string LoadSupportTicketData()
        {
            string TicketStats = "";

            TicketStats += String.Format("On Hold: {0}; Open: {1}; <br />",
                WebAdmin.StatsTickets(Enums.TicketStatus.OnHold),
                WebAdmin.StatsTickets(Enums.TicketStatus.Open));

            TicketStats = "Support tickets: " + TicketStats;
            return (TicketStats);
        }

        private string LoadSalonUpdates()
        {
            int SalonUpdates = WebAdmin.StatsSalonUpdates();
            return (String.Format("Salon Updates: {0}<br />", SalonUpdates));
        }

        private string LoadInvoicesToProcess()
        {
            decimal totalCost = 0.00m;
            int totalCount = 0;

            Invoices.InvoicesGetStats(GetUser(), -1, -1, false, ProcessStatuses.OrderReceived | ProcessStatuses.Processing);

            return (String.Format("Invoices To Process: {0} ({1})<br />", totalCount, SharedUtils.FormatMoney(totalCost, GetWebsiteCurrency())));
        }

        private string LoadInvoices()
        {
            decimal totalCost = 0.00m;
            int totalCount = 0;

            Invoices.InvoicesGetStats(GetUser(), -1, -1, true, ProcessStatuses.OrderReceived | ProcessStatuses.Processing);

            return (String.Format("Todays Invoices: {0} ({1})<br />", totalCount, SharedUtils.FormatMoney(totalCost, GetWebsiteCurrency())));
        }

        private string LoadMailData()
        {
            int ToProcess = WebAdmin.StatsMailCount(Enums.MailCount.ToProcess);
            int Queued = WebAdmin.StatsMailCount(Enums.MailCount.Queued);
            int Failed = WebAdmin.StatsMailCount(Enums.MailCount.Failed);

            return (String.Format("<a href=\"/Admin/Email/Index.aspx\">Mail Status</a>: To Process: {0}; Queued: {1}; Failed: {2}<br />", ToProcess, Queued, Failed));
        }


    }
}