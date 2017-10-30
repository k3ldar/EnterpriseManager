using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

using SieraDelta.Library;
using SieraDelta.Library.BOL.Users;

namespace SieraDelta.POS.Administration.Forms.Staff
{
    public partial class AdminStaff : SieraDelta.POS.Forms.BaseForm
    {
        #region Private Members

        private WebsiteAdministration _Admin;

        #endregion Private Members

        #region Constructors

        public AdminStaff(WebsiteAdministration admin)
        {
            _Admin = admin;
            InitializeComponent();
            SearchUsers();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStaffAdmin;

            btnSearch.Text = LanguageStrings.AppMenuButtonSearch;

            lblEmail.Text = LanguageStrings.AppEmail;
            lblFirstName.Text = LanguageStrings.FirstName;
            lblLastName.Text = LanguageStrings.LastName;

            colHeaderEmail.Text = LanguageStrings.AppEmail;
            colHeaderFirstName.Text = LanguageStrings.FirstName;
            colHeaderLastName.Text = LanguageStrings.LastName;

            toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppStaffNumberFound, 
                lstStaff.Items.Count);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void SearchUsers()
        {
            lstStaff.Items.Clear();

            Users users;
            
            users = User.StaffMembers();

            foreach (User user in users)
            {
                ListViewItem item = lstStaff.Items.Add(user.FirstName);
                item.SubItems.Add(user.LastName);
                item.SubItems.Add(user.Email);
                item.SubItems.Add(user.ID.ToString());
            }

            toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppStaffNumberFound, users.Count);
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstStaff.SelectedItems)
            {
                SieraDelta.Library.BOL.Users.User member = User.UserGet(
                    Convert.ToInt32(itm.SubItems[3].Text));

                if (member != null)
                {
                    AdminStaffEdit staffEdit = new AdminStaffEdit(_Admin);
                    try
                    {
                        if (staffEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.Abort)
                        {
                            SearchUsers();
                            break;
                        }
                    }
                    finally
                    {
                        staffEdit.Dispose();
                        staffEdit = null;
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
