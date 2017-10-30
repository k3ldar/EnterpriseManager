using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Helpdesk;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Helpdesk.Tickets
{
    public partial class PageFind : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = GetUser();

            if (user != null)
            {
                txtEmail.Text = user.Email;
                txtEmail.Enabled = false;
            }

            lblNotFound.Text = Languages.LanguageStrings.TicketNotFound;
            btnSubmit.Text = Languages.LanguageStrings.Submit;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SupportTicket ticket = SupportTickets.Get(txtTicketID.Text, txtEmail.Text);

            if (ticket == null)
            {
                lblNotFound.Visible = true;
            }
            else
            {
                DoRedirect(String.Format("/Helpdesk/Tickets/ShowTicket.aspx?email={0}&ticketid={1}", txtEmail.Text, txtTicketID.Text), true);
            }
        }
    }
}