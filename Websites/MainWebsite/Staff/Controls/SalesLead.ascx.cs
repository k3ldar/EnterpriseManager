using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.Users;
using Library.BOL.Trade;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public class ShowNotesEventArgs : EventArgs
    {
        public ShowNotesEventArgs(string s)
        {
            msg = s;
        }
        private string msg;
        public string Notes
        {
            get { return msg; }
        }
    }


    public partial class SalesLead : System.Web.UI.UserControl
    {
        private Client _Client;
        public delegate void EventOnClick(object sender, ShowNotesEventArgs a);

        public event EventOnClick OnClick;

        protected virtual void RaiseOnClick(ShowNotesEventArgs args)
        {
            if (OnClick != null)
                OnClick(this, args);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(Client client)
        {
            _Client = client;
            lblCompany.Text = client.Name;

            if (!String.IsNullOrEmpty(client.Name))
                lblCompany.Text += "<br />";

            User manager = client.AccountManager;

            if (manager != null)
                lblManager.Text = String.Format("Manager: {0}", manager.UserName);

            lblCompany.Text += client.Company;
            lnkView.PostBackUrl = String.Format("/Staff/SalesLead/Index.aspx?ClientID={0}", _Client.ID);

            //special case for already existing client accounts
            User currentAccount = _Client.ClientAccount;

            if (currentAccount != null)
            {
                ClientAction action = _Client.OpenAction(Enums.ClientAction.CreateAccount);

                if (action != null && (_Client.State == Enums.ClientState.ActiveClient || _Client.State == Enums.ClientState.NewClient))
                {
                    //client account already exists.

                    if (currentAccount.MemberLevel < Library.MemberLevel.Distributor)
                    {
                        currentAccount.MemberLevel = Library.MemberLevel.Distributor;
                        currentAccount.Save();
                    }

                    action.Complete(User.UserGet(559407), "");
                }
            }

            LoadActions(client);
        }

        protected void lnkNotes_Click(object sender, EventArgs e)
        {
            RaiseOnClick(new ShowNotesEventArgs(_Client.InitialNotes));
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

        private ClientAction GetClientAction(Enums.ClientAction action)
        {
            ClientAction Result = null;

            //first try for open action
            Result = _Client.OpenAction(action);

            //if not found try for closed (single) action
            if (Result == null)
                Result = _Client.ClosedAction(action);

            return (Result);
        }

        private void SetCellText(ClientAction action, TableCell cell, string Prefix)
        {
            if (action.User == null || action.ActionedDate == DateTime.MinValue)
            {
                cell.Text = String.Format("{0}Due by {1}<br />Staff Member: {2}", Prefix, action.Expires.ToString("dd/MM/yyyy"), action.StaffName);
                SetCellBackColour(StatusCheck(0, action.Expires), cell);
            }
            else
            {
                cell.Text = String.Format("{0}Completed on {1}<br />Staff Member: {2}", Prefix, action.ActionedDate.ToString("dd/MM/yyyy"), action.User.UserName);
                SetCellBackColour(0, cell);
            }
        }

        private void LoadActions(Client client)
        {
            ClientAction action = null;

            action = GetClientAction(Enums.ClientAction.Telephone);

            if (action != null)
            {
                SetCellText(action, tdTelephone, String.Format("Telephone {0}<br />", _Client.Telephone));
            }

            action = GetClientAction(Enums.ClientAction.Visit);

            if (action != null)
            {
                SetCellText(action, tdVisits, "");
            }

            if (client.InfoPack)
            {
                    tdInfoPack.Text = "<img src=\"/images/tick.jpg\" border=\"0\" />";
                    SetCellBackColour(0, tdInfoPack);
            }
            else
            {
                action = GetClientAction(Enums.ClientAction.DetailsSent); 
                SetCellText(action, tdInfoPack, "");
            }
            

            action = GetClientAction(Enums.ClientAction.TakeOn);

            if (action != null)
            {
                if (action.User != null)
                {
                    tdTakeOn.Text = "<img src=\"/images/tick.jpg\" border=\"0\" />";
                    SetCellBackColour(0, tdTakeOn);
                }
                else
                    SetCellText(action, tdTakeOn, "");
            }

            if (!client.Account)
            {
                tdAccount.Text = "<img src=\"/images/cross.jpg\" border=\"0\" />";
                SetCellBackColour(0, tdAccount);
            }
            else
            {
                tdAccount.Text = "<img src=\"/images/tick.jpg\" border=\"0\" />";
                SetCellBackColour(0, tdAccount);
            }

            if (client.Training)
            {
                tdTraining.Text = "<img src=\"/images/tick.jpg\" border=\"0\" />";
                SetCellBackColour(0, tdTraining);
            }
            else
            {
                bool TrainingComplete = client.ClosedAction(Enums.ClientAction.TrainingBSF) != null &&
                    client.ClosedAction(Enums.ClientAction.TrainingDream) != null &&
                    client.ClosedAction(Enums.ClientAction.TrainingLIA) != null;

                tdTraining.Text = "<img src=\"/images/cross.jpg\" border=\"0\" />";
                SetCellBackColour(0, tdTraining);
            }

            if (client.Account)
            {
                tdSalons.Text = "<img src=\"/images/tick.jpg\" border=\"0\" />";
                SetCellBackColour(0, tdSalons);
            }
            else
            {
                tdSalons.Text = "<img src=\"/images/cross.jpg\" border=\"0\" />";
                SetCellBackColour(0, tdSalons);
            }
        }
    }
}