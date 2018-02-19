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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CustomerSearch.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Users;
using POS.Base.Classes;
using POS.Base.Forms;

namespace POS.Customers.Controls
{
    public partial class CustomerSearchControl : Base.Controls.BaseTabControl
    {
        #region Constructors

        public CustomerSearchControl()
        {
            InitializeComponent();

            lstUsers.Height = lstUsers.Height + 25;
            statusStripCustomer.Visible = false;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppCustomersAdministration;

            btnCreate.Text = LanguageStrings.AppMenuButtonCreate;
            btnSearch.Text = LanguageStrings.AppMenuButtonSearch;

            cbFastSearch.Text = LanguageStrings.AppFastSearch;

            lblEmailAddress.Text = LanguageStrings.AppUserEmail;
            lblName.Text = LanguageStrings.AppName;
            lblTelephoneNumber.Text = LanguageStrings.TelephoneNumber;

            colHeaderCountry.Text = LanguageStrings.Country;
            colHeaderEmailAddress.Text = LanguageStrings.AppEmail;
            colHeaderFirstName.Text = LanguageStrings.FirstName;
            colHeaderLastName.Text = LanguageStrings.LastName;
            colHeaderTelephone.Text = LanguageStrings.TelephoneNumber;
        }

        #endregion Overridden Methods

        #region Public Methods

        public override int GetStatusCount()
        {
            return (statusStripCustomer.Items.Count);
        }

        public override string GetStatusText(int index)
        {
            return (statusStripCustomer.Items[index].Text);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStripCustomer.Items[index].ToolTipText);
        }

        #endregion Public Methods

        #region Private Methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SearchUsers();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void SearchUsers()
        {
            txtTelephone.Text = txtTelephone.Text.ToLower();
            txtEmail.Text = txtEmail.Text.ToLower();

            string[] name = txtName.Text.Trim().ToLower().Trim().Split(StringConstants.SYMBOL_SPACE_CHAR);
            string lastName = String.Empty;
            string firstName = String.Empty;

            if (name.Length > 0)
                firstName = name[0].Trim().ToLower();

            if (name.Length > 1)
                lastName = name[1].Trim().ToLower();

            lstUsers.Items.Clear();

            int count = 0;

            Users users = User.UserSearch(firstName, lastName, txtEmail.Text, txtTelephone.Text, 100);
            foreach (User user in users)
            {
                if ((String.IsNullOrEmpty(txtName.Text.Trim()) | user.NameContains(firstName, lastName)) &&
                    (String.IsNullOrEmpty(txtTelephone.Text.Trim()) |
                    user.Telephone.ToLower().Replace(StringConstants.SYMBOL_SPACE, String.Empty).Contains(
                    txtTelephone.Text.Replace(StringConstants.SYMBOL_SPACE, String.Empty))) &&
                    (String.IsNullOrEmpty(txtEmail.Text.Trim()) |
                    user.Email.ToLower().Contains(txtEmail.Text)) &&
                    user.MemberLevel != MemberLevel.System)
                {
                    ListViewItem item = lstUsers.Items.Add(user.FirstName);
                    item.SubItems.Add(user.LastName);
                    item.SubItems.Add(user.Email);
                    item.SubItems.Add(user.Country.Name);
                    item.SubItems.Add(user.Telephone);
                    item.SubItems.Add(user.ID.ToString());
                    item.Tag = user;
                    count++;

                    if (cbFastSearch.Checked && count > 99)
                        break;
                }
            }

            string StatusText = LanguageStrings.AppCustomersFound;

            if (count == 1)
                StatusText = LanguageStrings.AppCustomerFound;

            toolStripStatusLabelCount.Text = String.Format(StatusText, count);
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstUsers.SelectedItems)
            {

                User member = itm.Tag as User;

                if (member != null)
                {
                    PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(member));
                    //AdminMemberEdit memberEdit = new AdminMemberEdit(member);
                    //try
                    //{
                    //    if (memberEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.Abort)
                    //    {
                    //        //LoadProducts();
                    //        break;
                    //    }
                    //}
                    //finally
                    //{
                    //    memberEdit.Dispose();
                    //    memberEdit = null;
                    //}
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateUser newuser = new CreateUser();
            try
            {
                newuser.ShowDialog(this);
            }
            finally
            {
                newuser.Dispose();
                newuser = null;
            }
        }

        #endregion Private Methods
    }
}
