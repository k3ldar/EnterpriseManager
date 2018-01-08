using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.Helpdesk;
using Library.Utils;

namespace SieraDelta.Website.Helpdesk.Tickets
{
    public partial class Submit : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (!IsPostBack)
            {
                User user = GetUser();

                if (user != null)
                {
                    txtEmail.Text = user.Email;
                    txtEmail.Enabled = false;
                    txtName.Text = user.UserName;
                    txtName.Enabled = false;
                }

                LoadPriorities();
                LoadDepartments();
            }

            btnSubmit.Text = Languages.LanguageStrings.Submit;
        }


        private void LoadPriorities()
        {
            lstPriority.Items.Clear();
            TicketPriorities priorities = TicketPriorities.Get();

            foreach(TicketPriority priority in priorities)
            {
                ListItem item = new ListItem(priority.Description, priority.ID.ToString());
                lstPriority.Items.Add(item);
            }
        }

        private void LoadDepartments()
        {
            lstDepartment.Items.Clear();
            TicketDepartments departments = TicketDepartments.Get();

            foreach (TicketDepartment dept in departments)
            {
                ListItem item = new ListItem(dept.Description, dept.ID.ToString());
                lstDepartment.Items.Add(item);
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (VerificationImage1.IsValid)
            {
                //SieraDeltaUtils u = new SieraDeltaUtils();

                try
                {
                    string Subject = SharedUtils.ReplaceHTMLElements(txtSubject.Text);
                    string Content = SharedUtils.ReplaceHTMLElements(txtMessage.Text);
                    string UserName = SharedUtils.ReplaceHTMLElements(txtName.Text);
                    string Email = SharedUtils.ReplaceHTMLElements(txtEmail.Text);

                    //validate the email address
                    if (!SharedUtils.IsValidEmail(Email))
                        throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                    string TicketID = SharedUtils.GetRandomKey();
                    int Dept = SharedUtils.StrToInt(lstDepartment.SelectedValue, 0);
                    int Status = 1;
                    int Priority = SharedUtils.StrToInt(lstPriority.SelectedValue, 0);

                    ValidateDetails(Subject, 0, Languages.LanguageStrings.Subject);
                    ValidateDetails(Content, 0, Languages.LanguageStrings.Message);
                    ValidateDetails(UserName, 0, Languages.LanguageStrings.Username);
                    ValidateDetails(Email, 0, Languages.LanguageStrings.Email);

                    SupportTicket ticket = SupportTickets.Create(TicketID, Subject, Content, UserName, Dept, Status, Priority, Email);


                    //Send email to user
                    string EMail = String.Format(@"{0},<br /><br />Your ticket has been received, one of the staff members will review it and reply accordingly. " +
                        "Listed below are details of this ticket.<br /><br /><b>Ticket ID</b>: {1}<br /><b>Subject</b>: {2}<br /><b>Department</b>: {3}<br />" +
                        "<b>Priority</b>: {4}<br /><b>Status</b>: Open<br /><br />You can check the status or reply to this ticket online at: " +
                        "http://www.SieraDelta.com/helpdesk/Tickets/Showticket.aspx?TicketID={1}&Email={5}<br /><br />kind regards,<br /><br />SieraDelta.com",
                        UserName, TicketID, Subject, lstDepartment.SelectedItem.Text, lstPriority.SelectedItem.Text, Email);
                    Global.SendEMail(UserName, Email, String.Format("{0}: {1}", TicketID, Subject), EMail);
                    DoRedirect(String.Format("/Helpdesk/Tickets/ShowTicket.aspx?Email={0}&TicketID={1}", Email, TicketID), true);
                }
                catch (Exception err)
                {
                    lblError.Text = err.Message;
                    lblError.Visible = true;
                }
            }
        }

    }
}