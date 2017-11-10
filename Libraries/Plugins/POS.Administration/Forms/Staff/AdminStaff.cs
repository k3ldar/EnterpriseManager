/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AdminStaff.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
