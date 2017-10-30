using System;
using System.Windows.Forms;

using POS.Base.Classes;
using Languages;
using Library.BOL.Users;
using Library.BOL.Helpdesk;

namespace POS.HelpDesk.Forms
{
    public partial class Tickets : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private User _user;

        #endregion Private Members

        #region Constructors

        public Tickets()
        {
            InitializeComponent();
        }

        public Tickets(User user)
            : this()
        {
            _user = user;

            SearchTickets();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppHelpDeskTicketsFound, lstTickets.Items.Count);

            btnSearch.Text = LanguageStrings.AppMenuButtonSearch;

            rbClosed.Text = LanguageStrings.AppHelpDeskTicketClosed;
            rbOnHold.Text = LanguageStrings.AppHelpDeskTicketOnHold;
            rbOpen.Text = LanguageStrings.AppHelpDeskTicketOpen;

            lblFindTicket.Text = LanguageStrings.AppHelpDeskTicketFindByKey;

            colHeaderDepartment.Text = LanguageStrings.AppHelpDeskDepartment;
            colHeaderKey.Text = LanguageStrings.AppHelpDeskKey;
            colHeaderLastUpdated.Text = LanguageStrings.AppHelpDeskLastUpdated;
            colHeaderLastUpdatedBy.Text = LanguageStrings.AppHelpDeskLastUpdatedBy;
            colHeaderReplies.Text = LanguageStrings.AppHelpDeskReplies;
            colHeaderTitle.Text = LanguageStrings.AppHelpDeskTitle;
            colHeaderUser.Text = LanguageStrings.AppHelpDeskUser;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTickets();
        }

        private void SearchTickets()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Library.BOL.Helpdesk.SupportTickets tickets = null;

                if (txtKey.Text == String.Empty)
                    tickets = AppController.Administration.HelpdeskSupportTicketsGet(rbOnHold.Checked, rbClosed.Checked, rbOpen.Checked);
                else
                {
                    tickets = SupportTickets.Get(_user, txtKey.Text);
                    txtKey.Text = String.Empty;
                }

                lstTickets.BeginUpdate();
                try
                {
                    lstTickets.Items.Clear();

                    toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppHelpDeskTicketsFound, tickets.Count);

                    foreach (SupportTicket ticket in tickets)
                    {
                        ListViewItem lvi = lstTickets.Items.Add(ticket.TicketKey);
                        lvi.Tag = ticket;
                        lvi.SubItems.Add(ticket.Department.ToString());
                        lvi.SubItems.Add(ticket.CreatedBy);
                        lvi.SubItems.Add(ticket.Subject);
                        lvi.SubItems.Add(ticket.Messages.Count.ToString());
                        lvi.SubItems.Add(ticket.LastUpdated.ToShortDateString());
                        lvi.SubItems.Add(ticket.LastUpdatedBy);
                        lvi.SubItems.Add(ticket.ID.ToString());
                    }
                }
                finally
                {
                    lstTickets.EndUpdate();
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstTickets_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstTickets.SelectedItems)
            {
                SupportTicket ticket = (SupportTicket)itm.Tag;

                if (ticket != null)
                {
                    string oldStatus = ticket.Status;
                    Ticket supportTicket = new Ticket(_user, ticket);
                    try
                    {
                        supportTicket.ShowDialog(this);

                        if (ticket.Status != oldStatus)
                        {
                            lstTickets.Items.Remove(itm);
                        }
                    }
                    finally
                    {
                        supportTicket.Dispose();
                        supportTicket = null;
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
