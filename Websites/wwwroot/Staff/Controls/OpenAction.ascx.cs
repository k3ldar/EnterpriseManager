using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;

namespace SieraDelta.Website.Controls
{
    public partial class OpenAction : BaseControlClass
    {
        private ClientAction _action;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool ShowBookVisit
        {
            get
            {
                return (btnBookVisit.Visible);
            }

            set
            {
                btnBookVisit.Visible = value;
            }
        }

        public ClientAction Action
        {
            set
            {
                _action = value;

                if (_action != null)
                    pData.InnerHtml = String.Format("{0}<br />Due By: {2}<br />Staff Member: {1}", _action.Action.ToString(), _action.StaffName, _action.Expires.ToString("dd/MM/yyyy"));

                foreach (ClientNote note in _action.Notes)
                    pData.InnerHtml += String.Format("<br /><br />{0} - {1}<br />{2}", note.NotesDate.ToString("dd/MM/yyyy HH:mm"), note.User.UserName, note.Notes);
            }
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNewNotes.Text))
            {
                _action.Complete(GetUser(), txtNewNotes.Text);
                DoRedirect(String.Format("/Staff/SalesLead/Index.aspx?ClientID={0}", GetFormValue("ClientID", -1)));
            }
        }

        protected void btnAddNotes_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNewNotes.Text))
            {
                _action.Add(GetUser(), txtNewNotes.Text);
                DoRedirect(String.Format("/Staff/SalesLead/Index.aspx?ClientID={0}", GetFormValue("ClientID", -1)));
            }
        }

        protected void btnBookVisit_Click(object sender, EventArgs e)
        {
            DoRedirect(String.Format("/Staff/StaffDiary/BookVisit.aspx?ClientID={0}", GetFormValue("ClientID", -1)));
        }
    }
}