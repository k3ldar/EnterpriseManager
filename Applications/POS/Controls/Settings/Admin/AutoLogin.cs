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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AutoLogin.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using SharedBase.BOL.Users;
using POS.Base.Classes;

namespace PointOfSale.Controls.Settings.Admin
{
    public partial class AutoLogin : SharedControls.BaseSettings
    {
        public AutoLogin()
        {
            InitializeComponent();

            LoadStaffMembers();
            txtPassword.Text = AppController.LocalSettings.DefaultUserPassword;
            cbAutoLogin.Checked = !String.IsNullOrEmpty(AppController.LocalSettings.DefaultUserName);
            cbAutoLogin_CheckedChanged(this, EventArgs.Empty);
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblLoginDescription.Text = Languages.LanguageStrings.AppAutoLoginDescription;
            cbAutoLogin.Text = Languages.LanguageStrings.AppAutoLogin;
            lblPassword.Text = Languages.LanguageStrings.AppPassword;
            lblUserName.Text = Languages.LanguageStrings.AppUser;
        }

        public override bool SettingsSave()
        {
            if (cbAutoLogin.Checked)
            {
                User selUser = (User)cmbUsers.SelectedItem;
                AppController.LocalSettings.DefaultUserPassword = txtPassword.Text;
                AppController.LocalSettings.DefaultUserID = selUser.ID;
                AppController.LocalSettings.DefaultUserName = selUser.Email;
            }
            else
            {
                AppController.LocalSettings.DefaultUserPassword = String.Empty;
                AppController.LocalSettings.DefaultUserID = -1;
                AppController.LocalSettings.DefaultUserName = String.Empty;
            }

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            txtPassword.Text = AppController.LocalSettings.DefaultUserPassword;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadStaffMembers()
        {
            Users staff = User.StaffMembers(true);
            cmbUsers.Items.Clear();

            foreach (User user in staff)
            {
                int idx = cmbUsers.Items.Add(user);

                if (user.ID == AppController.LocalSettings.DefaultUserID)
                {
                    cmbUsers.SelectedIndex = idx;
                }
            }
        }

        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            cmbUsers.Enabled = cbAutoLogin.Checked;
            lblUserName.Enabled = cbAutoLogin.Checked;
            lblPassword.Enabled = cbAutoLogin.Checked;
            txtPassword.Enabled = cbAutoLogin.Checked;
        }

        private void cmbUsers_Format(object sender, ListControlConvertEventArgs e)
        {
            User item = (User)e.ListItem;
            e.Value = item.UserName;
        }

        #endregion Private Methods
    }
}
