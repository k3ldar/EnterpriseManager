using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Trade;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class AccountType : BaseControlClass
    {
        private Client _client;

        protected void Page_Load(object sender, EventArgs e)
        {
            User staffMember = GetUser();

            ddlClientType.Enabled = staffMember.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.UpdateClientType);
            btnChange.Enabled = staffMember.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.UpdateClientType);
            ddlManagers.Enabled = staffMember.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.UpdateAccountManager);
            btnAssignManager.Enabled = staffMember.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.UpdateAccountManager);
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            int type = Shared.Utilities.StrToIntDef(ddlClientType.SelectedItem.Value, 0);

            _client.State = (Enums.ClientState)type;
        }

        protected void btnAssignManager_Click(object sender, EventArgs e)
        {
            User staff = User.UserGet(ddlManagers.SelectedValue);

            _client.AccountManager = staff;
        }

        public void Refresh(Client client)
        {
            _client = client;

            if (!IsPostBack)
            {
                LoadStaff();

                foreach (ListItem item in ddlClientType.Items)
                {
                    if (Shared.Utilities.StrToIntDef(item.Value, -1) == (int)_client.State)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        #region Private Methods

        private void LoadStaff()
        {
            ddlManagers.Items.Clear();

            Users staffMembers = Library.BOL.Users.User.StaffMembers(true);

            foreach (User staff in staffMembers)
            {
                ListItem item = new ListItem(staff.UserName, staff.Email);
                ddlManagers.Items.Add(item);

                if (_client.AccountManager != null && _client.AccountManager.Email == staff.Email)
                    item.Selected = true;
            }
        }

        #endregion Private Methods
    }
}