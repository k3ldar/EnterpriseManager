using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;
using Library.BOL.Users;
using Library.BOL.Salons;
using Library;

namespace SieraDelta.Website.SalesLead
{
    public partial class Index : BaseWebFormStaff
    {
        private Client _client;
        private User _clientUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            _client = Clients.Get(GetFormValue("ClientID", -1));

            if (_client == null)
                DoRedirect("/Staff/Index.aspx");

            _clientUser = Library.BOL.Users.User.UserGet(_client.Email);

            LoadContactDetails();
            LoadGeneralNotes();
            LoadTelephoneCalls();
            LoadVisits();
            LoadTraining();
            LoadInvoices();
            LoadOrders();

            LoadSalons();

            saClientTakeOn.OnComplete += new SieraDelta.Website.Controls.SingleAction.EventOnClick(saClientTakeOn_OnComplete);
            saCreateAccount.OnComplete += new SieraDelta.Website.Controls.SingleAction.EventOnClick(saClientTakeOn_OnComplete);
            saTrainingBSF.OnComplete += new SieraDelta.Website.Controls.SingleAction.EventOnClick(saClientTakeOn_OnComplete);
            saTrainingDream.OnComplete += new SieraDelta.Website.Controls.SingleAction.EventOnClick(saClientTakeOn_OnComplete);
            saTrainingLIA.OnComplete += new SieraDelta.Website.Controls.SingleAction.EventOnClick(saClientTakeOn_OnComplete);
            saSendInfoPack.OnComplete += new SieraDelta.Website.Controls.SingleAction.EventOnClick(saClientTakeOn_OnComplete);

            RefreshSingleActions();
            OpenActionTelephone.Action = GetClientAction(Enums.ClientAction.Telephone);
            OpenActionVisits.Action = GetClientAction(Enums.ClientAction.Visit);

            AccountType1.Refresh(_client);

            pSignupNotes.InnerHtml = _client.InitialNotes;
        }

        private void LoadContactDetails()
        {
            string details = String.Format("<p>{4}<br />{0}<br />{1}</p><p>Telephone: {2}<br />Email: <a href=\"mailto:{3}\">{3}</a></p>",
                _client.Address.Replace("\r\n", "<br />"), _client.Postcode, _client.Telephone, _client.Email, _client.Company);
            pContactDetails.InnerHtml = details;
        }

        private void LoadSalons()
        {
            pnlCreateSalons.Controls.Clear();

            if (_clientUser != null)
            {

                foreach (Salon salon in _clientUser.Salons)
                {
                    // load all salons
                    Controls.ViewSalon viewSalon = (Controls.ViewSalon)LoadControl("~/Staff/Controls/ViewSalon.ascx");
                    viewSalon.Refresh(salon);
                    pnlCreateSalons.Controls.Add(viewSalon);
                }
            }
                //load create salon control
            Controls.CreateSalon createsalon = (Controls.CreateSalon)LoadControl("~/Staff/Controls/CreateSalon.ascx");
                createsalon.Refresh(_client, _clientUser);
                createsalon.OnCreateSalon += new Controls.CreateSalon.EventOnCreateSalon(CreateSalon1_OnCreateSalon);
                pnlCreateSalons.Controls.Add(createsalon);
        }

        void CreateSalon1_OnCreateSalon(object sender, EventArgs e)
        {
            LoadSalons();
            RefreshSingleActions();
        }

        private void RefreshSingleActions()
        {
            saCreateAccount.Refresh(_client, _clientUser, GetClientAction(Enums.ClientAction.CreateAccount));
            saTrainingBSF.Refresh(_client, _clientUser, GetClientAction(Enums.ClientAction.TrainingBSF));
            saTrainingDream.Refresh(_client, _clientUser, GetClientAction(Enums.ClientAction.TrainingDream));
            saTrainingLIA.Refresh(_client, _clientUser, GetClientAction(Enums.ClientAction.TrainingLIA));
            saClientTakeOn.Refresh(_client, _clientUser, GetClientAction(Enums.ClientAction.TakeOn));
            saSendInfoPack.Refresh(_client, _clientUser, GetClientAction(Enums.ClientAction.DetailsSent));
            CreateAccount1.AfterCreateAccount += new Members.Controls.CreateAccount.AfterCreateAccountDelegate(CreateAccount1_AfterCreateAccount);

            acAccount.Visible = _client.OpenAction(Enums.ClientAction.CreateAccount) != null;

            if (acAccount.Visible && !IsPostBack)
            {
                CreateAccount1.Refresh(_client);
            }

            saCreateAccount.Visible = !acAccount.Visible;
            acTraining.Visible = _client.ClosedAction(Enums.ClientAction.TakeOn) != null;
            acSalons.Visible = !acAccount.Visible & _client.ClosedAction(Enums.ClientAction.TakeOn) != null;
        }

        void CreateAccount1_AfterCreateAccount(object sender, Members.Controls.CreateAccount.CreateAccountArgs e)
        {
            _client.OpenAction(Enums.ClientAction.CreateAccount).Complete(GetUser(), "Account Created");
            e.NewAccount.MemberLevel = Library.MemberLevel.Distributor;
            e.NewAccount.Save();
            RefreshSingleActions();
        }

        protected void saClientTakeOn_OnComplete(object sender, EventArgs e)
        {
            RefreshSingleActions();
        }

        private ClientAction GetClientAction(Enums.ClientAction action)
        {
            ClientAction Result = null;

            //first try for open action
            Result = _client.OpenAction(action);

            //if not found try for closed (single) action
            if (Result == null)
                Result = _client.ClosedAction(action);

            return (Result);
        }



        protected string GetCustomerName()
        {
            return (_client.Name);
        }

        protected Int64 GetClientID()
        {
            return (_client.ID);
        }
        
        private void LoadInvoices()
        {
            if (_clientUser == null)
                acOrders.Visible = false;
            else
                ClientInvoices1.Refresh(_client, _clientUser);
        }

        private void LoadOrders()
        {
            if (_clientUser != null)
                ClientOrders1.Refresh(_client, _clientUser);
        }

        private void LoadVisits()
        {
            ClientActions Visits = _client.ClosedActions(Library.Enums.ClientAction.Visit);

            foreach (ClientAction action in Visits)
            {
                SieraDelta.Website.Controls.ClosedAction newClosedAction = (Controls.ClosedAction)LoadControl("~/Staff/Controls/ClosedAction.ascx");
                newClosedAction.Refresh(action);
                pnlVisits.Controls.Add(newClosedAction);
            }

            OpenActionVisits.ShowBookVisit = true;
        }

        private void LoadTraining()
        {
            foreach (ClientAction action in _client.ClosedActions(Library.Enums.ClientAction.TrainingBSF))
            {
                SieraDelta.Website.Controls.ClosedAction newClosedAction = (Controls.ClosedAction)LoadControl("~/Staff/Controls/ClosedAction.ascx");
                newClosedAction.Refresh(action);
                pnlTraining.Controls.Add(newClosedAction);
            }
        }

        private void LoadTelephoneCalls()
        {
            ClientActions closed = _client.ClosedActions(Library.Enums.ClientAction.Telephone);

            foreach (ClientAction action in closed)
            {
                SieraDelta.Website.Controls.ClosedAction newClosedAction = (Controls.ClosedAction)LoadControl("~/Staff/Controls/ClosedAction.ascx");
                newClosedAction.Refresh(action);
                pnlTelephone.Controls.Add(newClosedAction);
            }

            OpenActionTelephone.ShowBookVisit = false;
        }

        private void LoadGeneralNotes()
        {
            foreach (ClientNote note in _client.Notes)
            {
                SieraDelta.Website.Controls.Notes newNotes = (SieraDelta.Website.Controls.Notes)LoadControl("~/Staff/Controls/Notes.ascx");
                newNotes.Refresh(note);
                pnlNotes.Controls.AddAt(pnlNotes.Controls.Count-2, newNotes);
            }
        }
    }
}