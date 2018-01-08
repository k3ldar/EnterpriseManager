using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;

namespace SieraDelta.Website.Staff
{
    public partial class SalesLeads : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Clients.AutoLinkAccounts();

            BuildSalesList();
        }

        protected void lnkOriginalNotes_Click(object sender, EventArgs e)
        {

        }

        private void BuildSalesList()
        {
            Clients clients = Clients.Get((Library.Enums.ClientState)Convert.ToInt32(cmbClientType.SelectedValue));

            foreach (Client client in clients)
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
    }
}