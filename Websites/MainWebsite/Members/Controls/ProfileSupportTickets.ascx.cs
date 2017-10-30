using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Helpdesk;
using Library.BOL.Products;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
{
    public partial class ProfileSupportTickets : BaseControlClass
    {
        private Library.BOL.Helpdesk.SupportTickets _tickets;

        protected void Page_Load(object sender, EventArgs e)
        {
            _tickets = Library.BOL.Helpdesk.SupportTickets.Get(GetUser());

            BuildSupportTickets();
        }

        private void BuildSupportTickets()
        {
            int Start = GetFormValue("Page", 1);

            int Finish = (Start * 10) - 1;
            Start = Finish - 9;
            int i = 0;

            foreach (Library.BOL.Helpdesk.SupportTicket ticket in _tickets)
            {
                if (i >= Start && i <= Finish)
                {
                    //new row
                    HtmlTableRow r = new HtmlTableRow();
                    tblInvoices.Rows.Add(r);

                    //created date
                    HtmlTableCell cCreateDate = new HtmlTableCell();
                    cCreateDate.InnerText = Shared.Utilities.DateToStr(ticket.Created, WebCulture);
                    r.Cells.Add(cCreateDate);

                    //last reply date
                    HtmlTableCell cReplyDate = new HtmlTableCell();
                    cReplyDate.InnerText = Shared.Utilities.DateToStr(ticket.LastUpdated, WebCulture);
                    r.Cells.Add(cReplyDate);

                    //last replier
                    HtmlTableCell cLastReplier = new HtmlTableCell();
                    cLastReplier.InnerText = ticket.LastUpdatedBy;
                    r.Cells.Add(cLastReplier);

                    //subject
                    HtmlTableCell cSubject = new HtmlTableCell();
                    cSubject.InnerText = ticket.Subject;
                    r.Cells.Add(cSubject);

                    //status
                    HtmlTableCell cStatus = new HtmlTableCell();
                    cStatus.InnerText = ticket.Status;
                    r.Cells.Add(cStatus);

                    //view
                    HtmlTableCell cDescription = new HtmlTableCell();
                    r.Cells.Add(cDescription);
                    cDescription.InnerHtml = String.Format("<a href=\"/Helpdesk/Tickets/ShowTicket.aspx?Email={2}&TicketID={1}\">{0}</a>",
                        Languages.LanguageStrings.View, ticket.TicketKey, ticket.CreatedByEmail);
                }

                i++;
            }
        }

    }
}