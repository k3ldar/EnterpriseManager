using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Staff
{
    public partial class SalesLeads : BaseWebFormSalesAdvisor
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Text = Languages.LanguageStrings.Search;

            if (!IsPostBack)
            {
                Clients.AutoLinkAccounts();

                BuildVisibleList();

                if (Session["CLIENT_LIST"] != null)
                {
                    for (int i = 0; i < cmbClientType.Items.Count; i++)
                    {
                        ListItem item = cmbClientType.Items[i];

                        if (item.Value == (string)Session["CLIENT_LIST"])
                        {
                            cmbClientType.SelectedIndex = i;
                            break;
                        }
                    }
                }

                BuildSalesList();
            }
        }

        protected void lnkOriginalNotes_Click(object sender, EventArgs e)
        {

        }

        private void BuildVisibleList()
        {
            cmbClientType.Items.Clear();

            cmbClientType.Items.Add(new ListItem("My Clients", GetUser().Email));

            if (GetUser().MemberLevel > Library.MemberLevel.SalesAdvisor)
            {
                cmbClientType.Items.Add(new ListItem("New Clients", "0"));
                cmbClientType.Items.Add(new ListItem("Current Clients", "10"));
                cmbClientType.Items.Add(new ListItem("New Distributors", "30"));
                cmbClientType.Items.Add(new ListItem("Current Distributors", "40"));
                cmbClientType.Items.Add(new ListItem("Archived Distributors", "50"));
                cmbClientType.Items.Add(new ListItem("Archived Clients", "20"));
                cmbClientType.Items.Add(new ListItem("Current @Home", "60"));
                cmbClientType.Items.Add(new ListItem("Archived @Home", "70"));

                Users clientManagers = Clients.TradeClientManagers();

                foreach (Library.BOL.Users.User manager in clientManagers)
                {
                    cmbClientType.Items.Add(new ListItem(manager.UserName, manager.Email));
                }
            }
        }

        private void BuildSalesList()
        {
            Clients clients = null;

            if (Shared.Utilities.StrToInt(cmbClientType.SelectedValue, -1) > -1)
            {
                clients = Clients.Get((Library.Enums.ClientState)Convert.ToInt32(cmbClientType.SelectedValue));
            }
            else
            {
                User user = Library.BOL.Users.User.UserGet(cmbClientType.SelectedValue);
                clients = user.GetTradeClients();
            }

            Session["CLIENT_LIST"] = cmbClientType.SelectedValue;

            foreach (Client client in clients)
            {
                if (String.IsNullOrEmpty(txtSearch.Text) || (MatchesSearchCriteria(client)))
                {
                    TableRow Row = new TableRow();
                    tblTracker.Rows.Add(Row);

                    //Add Company
                    TableCell cellCompany = new TableCell();
                    Row.Cells.Add(cellCompany);
                    Controls.SalesLead newLead = (Controls.SalesLead)LoadControl("~/Staff/Controls/SalesLead.ascx");
                    newLead.Refresh(client);
                    newLead.OnClick += new Controls.SalesLead.EventOnClick(newLead_OnClick);
                    cellCompany.Controls.Add(newLead);
                }
            }
        }

        private bool MatchesSearchCriteria(Client client)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                return (true);

            bool Result = true;

            string[] searchWords = txtSearch.Text.Split(' ');

            foreach (string word in searchWords)
            {
                if (!client.ToString().ToLower().Contains(word.Trim().ToLower()))
                {
                    Result = false;
                    break;
                }
            }


            return (Result);
        }

        void newLead_OnClick(object sender, Controls.ShowNotesEventArgs a)
        {
            string Notes = a.Notes;

            if (String.IsNullOrEmpty(Notes))
                Notes = "No Notes on System!";
            else
            {
                Notes = a.Notes.Replace("<p>", "<p><font size=\"2\">");
                Notes = Notes.Replace("</p>", "</Font></p>");
            }
            pSignupNotes.InnerHtml = "<font size=\"small\">" + Notes + "</Font>";

            ModalPopupExtender1.Show();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BuildSalesList();
        }
    }
}