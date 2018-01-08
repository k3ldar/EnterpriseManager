using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library.BOL.Helpdesk;
using Library.BOL.Users;
using Library.Utils;

namespace SieraDelta.Website.Helpdesk.Tickets
{
    public partial class ShowTicket : BaseWebForm
    {
        private SupportTicket _ticket;

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            _ticket = SupportTickets.Get(GetFormValue("TicketID"), GetFormValue("Email"));

            if (_ticket == null)
                DoRedirect("/Helpdesk/Index.aspx", true);

            if (!IsPostBack)
                LoadStatuses();

            GetTicketPosts();

            User user = GetUser();
            if (user != null)
            {
                txtReplyName.Text = user.UserName;
                txtReplyName.Enabled = false;
            }

            btnSubmit.Text = Languages.LanguageStrings.Submit;
        }

        protected string GetTicketKey()
        {
            return (_ticket.TicketKey);
        }

        protected string GetTicketDepartment()
        {
            return (_ticket.Department);
        }

        protected string GetTicketSubject()
        {
            return (_ticket.Subject);
        }

        protected string GetTicketPriority()
        {
            return (_ticket.Priority);
        }

        protected string GetLastReplier()
        {
            return (_ticket.LastUpdatedBy);
        }

        protected string GetLastUpdated()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            return (SharedUtils.DateTimeToStr(_ticket.LastUpdated, WebCulture));
        }

        protected void GetTicketPosts()
        {
            foreach (SupportTicketMessage message in _ticket.Messages)
            {
                HtmlTableRow r = new HtmlTableRow();
                tblPosts.Rows.Add(r);
                HtmlTableCell c = CreateCell(r, "");
                c.ColSpan = 1;

                SieraDelta.Helpdesk.Controls.HelpdeskTicketPost tp = (SieraDelta.Helpdesk.Controls.HelpdeskTicketPost)LoadControl("~/Helpdesk/Controls/HelpdeskTicketPost.ascx");
                tp.Refresh(message);
                c.Controls.Add(tp);
            }
        }

        protected void lstStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            TicketStatus newStatus = TicketStatuses.Get(lstStatus.SelectedItem.Text);
            _ticket.SetStatus(newStatus);
        }
        
        #endregion Protected Methods

        #region Private Methods

        private void LoadStatuses()
        {
            lstStatus.Items.Clear();
            TicketStatuses statuses = TicketStatuses.Get();

            foreach (TicketStatus status in statuses)
            {
                ListItem item = new ListItem(status.Description, status.ID.ToString());
                lstStatus.Items.Add(item);
            }

            foreach (ListItem item in lstStatus.Items)
                item.Selected = _ticket.Status == item.Text;
        }

        #endregion Private Methods

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //SieraDeltaUtils u = new SieraDeltaUtils();

                string ticketid = GetFormValue("TicketID");
                string email = GetFormValue("Email");
                SupportTicket ticket = SupportTickets.Get(ticketid, email);

                string Name = SharedUtils.ReplaceHTMLElements(txtReplyName.Text).Trim();
                string Message = SharedUtils.ReplaceHTMLElements(txtReply.Text).Trim();

                ValidateDetails(Name, 0, Languages.LanguageStrings.Name);
                ValidateDetails(Message, 0, Languages.LanguageStrings.Message);

                ticket.Reply(Message, Name, false);

                DoRedirect(String.Format("/Helpdesk/Tickets/ShowTicket.aspx?Email={0}&TicketID={1}", email, ticketid));
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = err.Message;
            }
        }

    }
}