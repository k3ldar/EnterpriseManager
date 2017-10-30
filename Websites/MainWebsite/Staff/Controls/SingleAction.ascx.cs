using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.BOL.Users;
using Library.BOL.Trade;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class SingleAction : BaseControlClass
    {
        private ClientAction _action;

        public delegate void EventOnClick(object sender, EventArgs e);

        public event EventOnClick OnComplete;

        protected virtual void RaiseOnComplete(EventArgs args)
        {
            if (OnComplete != null)
                OnComplete(this, args);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            _action.Complete(GetUser(), txtNotes.Text);
            SetActionText(_action, GetUser());
            SetCellBackColour(0, cellDescription);
            SetCellBackColour(0, cellAction);
            RaiseOnComplete(new EventArgs());
        }

        public void Refresh(Client client, User clientUser, ClientAction clientAction)
        {
            if (clientAction == null)
            {
                tblSingleAction.Visible = false;
            }
            else
            {
                if (!tblSingleAction.Visible)
                    tblSingleAction.Visible = true;

                _action = clientAction;
                SetActionText(clientAction, clientUser);

                if (!clientAction.IsActionComplete)
                {
                    // needs to be actioned

                    int Status = StatusCheck(0, clientAction.Expires);
                    SetCellBackColour(Status, cellDescription);
                    SetCellBackColour(Status, cellAction);
                }
                else
                {
                    // already actioned
                    btnComplete.Visible = false;
                    SetCellBackColour(0, cellDescription);
                }
            }
        }

        private int StatusCheck(int CurrentStatus, DateTime Expires)
        {
            int Result = CurrentStatus;

            if (Expires < DateTime.Now.AddDays(10))
            {
                Result = 1;

                if (Expires < DateTime.Now.AddDays(3))
                    Result = 2;
            }

            return (Result);
        }

        private void SetCellBackColour(int Status, TableCell cell)
        {
            switch (Status)
            {
                case 1:
                    cell.BackColor = System.Drawing.Color.Orange;
                    break;
                case 2:
                    cell.BackColor = System.Drawing.Color.Red;
                    break;
                default:
                    cell.BackColor = System.Drawing.Color.White;
                    break;
            }

        }

        private void SetActionText(ClientAction clientAction, User user)
        {
            string sTitle ="";
            string ActionBy = clientAction.IsActionComplete ? clientAction.StaffName : clientAction.Client.AccountManager.UserName;
            DateTime ActionDate = clientAction.IsActionComplete ? clientAction.Expires : clientAction.ActionedDate == DateTime.MinValue ? clientAction.Expires : clientAction.ActionedDate;

            switch (clientAction.Action)
            {
                case Enums.ClientAction.None:
                    sTitle = "No Predefined Action";
                    break;
                case Enums.ClientAction.DetailsSent: 
                    sTitle = "Send Information Pack";
                    break;
                case Enums.ClientAction.TakeOn: 
                    sTitle = "Take on Client";
                    break;
                case Enums.ClientAction.TrainingLIA:
                    sTitle = "Train client in LIA treatment";
                    break;
                case Enums.ClientAction.TrainingBSF: 
                    sTitle = "Train client in BSF treatment";
                    break;
                case Enums.ClientAction.TrainingDream: 
                    sTitle = "Train client in Dream treatment";
                    break;
                case Enums.ClientAction.CreateAccount:
                    sTitle = "Create user account for client";
                    break;
                case Enums.ClientAction.CreateSalon:  
                    sTitle = "Create Salon for Website";
                    break;
                case Enums.ClientAction.LinkAccountToSalon:
                    sTitle = "Link Salon with client";
                    break;
                default:
                    sTitle = "Unknown Action Details";
                    break;
            }

            cellDescription.Text = String.Format("{0} {1} - Staff: {2}; {4}: {3}", !clientAction.IsActionComplete ? "" : "<img src=\"/images/tick.jpg\" align=\"left\" border=\"0\" width=\"50\" height=\"50\" />",
                sTitle, ActionBy, ActionDate.ToString("dd/MM/yyyy"), !clientAction.IsActionComplete ? "Expires" : "Actioned");

            if (clientAction.IsActionComplete)
            {
                cellAction.Visible = false;
                cellDescription.ColumnSpan = 2;

                foreach (ClientNote note in clientAction.Notes)
                    cellDescription.Text += String.Format("<p>{0}</p>", note.Notes);
            }
        }
    }
}