using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;
using Library.BOL.Users;
using Library.BOL.Salons;
using Library;

namespace Heavenskincare.WebsiteTemplate.Staff.SalesLead
{
    public partial class AssignAccountManager : BaseWebFormStaff
    {
        #region Private Members

        private Client _client;

        /// <summary>
        /// Current member of staff looking at the record
        /// </summary>
        private User _staffMember;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            _client = Clients.Get(GetFormValue("ClientID", -1));

            _staffMember = GetUser();

            if (_client == null)
                DoRedirect("/Staff/Index.aspx");

            if (!IsPostBack)
                LoadStaff();
        }

        protected string GetCustomerName()
        {
            return (_client.Name);
        }

        protected Int64 GetClientID()
        {
            return (_client.ID);
        }

        protected string GetContactDetails()
        {
            return (String.Format("<p>{4}<br />{0}<br />{1}</p><p>Telephone: {2}<br />Email: <a href=\"mailto:{3}\">{3}</a></p>",
                _client.Address.Replace("\r\n", "<br />"), _client.Postcode, _client.Telephone, _client.Email, _client.Company));
        }

        protected void btnAssignClient_Click(object sender, EventArgs e)
        {
            User staff = Library.BOL.Users.User.UserGet(lstStaff.SelectedValue);

            _client.AccountManager = staff;

            DoRedirect(String.Format("/Staff/SalesLead/Index.aspx?ClientID={0}", _client.ID), true);
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadStaff()
        {
            lstStaff.Items.Clear();


            Users staffMembers = Library.BOL.Users.User.StaffMembers(true);

            foreach (User staff in staffMembers)
            {
                ListItem item = new ListItem(staff.UserName, staff.Email);
                lstStaff.Items.Add(item);
            }
        }

        #endregion Private Methods
    }
}