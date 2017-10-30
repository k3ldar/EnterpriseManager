using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Helpdesk;
using Library.BOL.ValidationChecks;
using Reports.Helpdesk;
using POS.Base.Classes;
using POS.HelpDesk.Controls;

namespace POS.HelpDesk.Forms
{
    public partial class Ticket : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private SupportTicket _ticket;
        private User _user;
        private bool _spellCheckComplete = false;

        #endregion Private Members

        #region Constructors

        public Ticket ()
        {
            InitializeComponent();
        }

        public Ticket(User user, SupportTicket ticket)
            : this()
        {
            _ticket = ticket;
            _user = user;

            lblCreatedBy.Text = String.Format(StringConstants.PRODUCT_COST_SIZE_DEFAULT, 
                ticket.CreatedBy, ticket.CreatedByEmail);
            lblKey.Text = ticket.TicketKey;
            lblLastReplier.Text = ticket.LastUpdatedBy;
            lblSubject.Text = ticket.Subject;
            lblLastUpdated.Text = ticket.LastUpdated.ToString(StringConstants.SYMBOL_DATE_FORMAT_G);
            LoadStatuses(ticket.Status);
            LoadDepartments(ticket.Department);
            LoadPriorities(ticket.Priority);
            txtUserName.Text = _user.UserName;

            LoadMessages();

            cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            cmbDepartment.SelectedIndexChanged += new EventHandler(cmbDepartment_SelectedIndexChanged);

            txtReply.Focus();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TicketReply;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppHelpDeskSupportTicket;

            lblDescCreatedBy.Text = LanguageStrings.AppHelpDeskCreatedBy;
            lblDescDepartment.Text = LanguageStrings.AppHelpDeskDepartment;
            lblDescKey.Text = LanguageStrings.AppHelpDeskKey;
            lblDescLastReplier.Text = LanguageStrings.AppHelpDeskLastReplier;
            lblDescLastUpdated.Text = LanguageStrings.AppHelpDeskLastUpdated;
            lblDescPriority.Text = LanguageStrings.AppHelpDeskPriority;
            lblDescStatus.Text = LanguageStrings.AppHelpDeskStatus;
            lblDescSubject.Text = LanguageStrings.AppHelpDeskSubject;

            btnClose.Text = LanguageStrings.AppMenuButtonClose;
            btnfindUser.Text = LanguageStrings.AppMenuButtonFindUser;
            btnPrintPreview.Text = LanguageStrings.AppMenuButtonPrint;
            btnReply.Text = LanguageStrings.AppMenuButtonReply;
            btnSpellCheck.Text = LanguageStrings.AppMenuButtonSpellCheck;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadMessages()
        {
            pnlMessages.Controls.Clear();

            foreach (SupportTicketMessage message in _ticket.Messages)
            {
                TicketEntry entry = new TicketEntry();
                entry.Refresh(message);
                entry.Width = pnlMessages.Width - 6;
                entry.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                pnlMessages.Controls.Add(entry);
            }
        }

        private void LoadStatuses(string Selected)
        {
            cmbStatus.Items.Clear();
            TicketStatuses statuses = SupportTickets.StatusesGet();

            foreach (TicketStatus status in statuses)
            {
                int i = cmbStatus.Items.Add(status);

                if (status.Description == Selected)
                    cmbStatus.SelectedIndex = i;
            }
        }

        private void LoadDepartments(string Selected)
        {
            cmbDepartment.Items.Clear();
            TicketDepartments departments = SupportTickets.DepartmentsGet();

            foreach (TicketDepartment department in departments)
            {
                int i = cmbDepartment.Items.Add(department);

                if (department.Description == Selected)
                    cmbDepartment.SelectedIndex = i;
            }
        }

        private void LoadPriorities(string Selected)
        {
            cmbPriority.Items.Clear();
            TicketPriorities priorities = SupportTickets.PrioritiesGet();

            foreach (TicketPriority priority in priorities)
            {
                int i = cmbPriority.Items.Add(priority);

                if (priority.Description == Selected)
                    cmbPriority.SelectedIndex = i;
            }
        }

        private void cmbStatus_Format(object sender, ListControlConvertEventArgs e)
        {
            TicketStatus status = (TicketStatus)e.ListItem;
            e.Value = status.Description;
        }

        private void cmbPriority_Format(object sender, ListControlConvertEventArgs e)
        {
            TicketPriority priority = (TicketPriority)e.ListItem;
            e.Value = priority.Description;
        }

        private void cmbDepartment_Format(object sender, ListControlConvertEventArgs e)
        {
            TicketDepartment dept = (TicketDepartment)e.ListItem;
            e.Value = dept.Description;
        }

        private void pnlMessages_SizeChanged(object sender, EventArgs e)
        {
            int newWidth = pnlMessages.Width - 6;

            if (pnlMessages.VerticalScroll.Visible)
                newWidth -= 20;

            foreach (Control ctl in pnlMessages.Controls)
            {
                ctl.Width = newWidth;
            }
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (!_spellCheckComplete)
            {
                if (ShowQuestion(LanguageStrings.AppSpellCheck, LanguageStrings.AppSpellCheckPrompt))
                {
                    btnSpellCheck_Click(sender, e);
                    return;
                }
                else
                    POSValidation.Add(AppController.ActiveUser, ValidationReasons.IgnoreSpellCheckTicketReply,
                        String.Format(StringConstants.VALIDATION_CHECK_TICKET, _ticket.ID, _ticket.TicketKey));
            }

            if (txtReply.Text.Length > 0 && txtUserName.Text.Length > 0)
            {
                _ticket.Reply(LibUtils.ReplaceHTMLElements(txtReply.Text), 
                    LibUtils.ReplaceHTMLElements(txtUserName.Text), true);
                txtReply.Text = String.Empty;
                LoadMessages();
            }
            else
                ShowError(LanguageStrings.AppError, LanguageStrings.AppHelpDeskAddReply);
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ticket.SetStatus((TicketStatus)cmbStatus.SelectedItem);
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ticket.SetDepartment((TicketDepartment)cmbDepartment.SelectedItem);
        }

        private void Ticket_Enter(object sender, EventArgs e)
        {
            txtReply.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = User.UserGet(_ticket.CreatedByEmail);

            if (user != null)
            {
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(user));
            }
            else
                ShowInformation(LanguageStrings.AppCustomerFind, LanguageStrings.AppCustomerNotFound);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            PDFSupportTicket pdfTicket = new PDFSupportTicket(_ticket);
            pdfTicket.View();
        }

        private void Ticket_SizeChanged(object sender, EventArgs e)
        {
            foreach (TicketEntry entry in pnlMessages.Controls)
            {
                entry.Width = pnlMessages.Width;
            }
        }

        private void btnSpellCheck_Click(object sender, EventArgs e)
        {
            SharedControls.SpellChecker.SpellChecker.ShowSpellChecker(this,
                AppController.LocalSettings.CustomDictionary,
                AppController.POSFolder(FolderType.Dictionary, true),
                txtReply);
            _spellCheckComplete = true;
        }

        #endregion Private Methods
    }
}
