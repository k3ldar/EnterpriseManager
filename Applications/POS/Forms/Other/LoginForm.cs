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
 *  File: LoginForm.cs
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

using SharedBase.BOL.Users;
using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace PointOfSale.Forms.Other
{
    public partial class LoginForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private User _StaffMember;
        private bool _allowCancel;
        private bool _allowAutoLogin;

        #endregion Private Members

        #region Constructors

        public LoginForm(ref User StaffMember)
        {
            InitializeComponent();

            if (AppController.SplashScreenShowing())
                TopMost = true;

            BuildStaffMembers();
        }

        #endregion Constructors

        #region Static Methods

        public static bool DoLogin(ref User StaffMember, string Title, 
            bool AllowAutoLogin = true, bool AllowCancel = true)
        {
            LoginForm frmLogin = new LoginForm(ref StaffMember);
            try
            {
                frmLogin._allowCancel = AllowCancel;
                frmLogin._allowAutoLogin = AllowAutoLogin;
                AppController.ApplicationController.BarcodeReceived += frmLogin.User_BarcodeReceived;
                AppController.AutoLogout = AppController.LocalSettings.AutoLogout;
                frmLogin.BringToFront();

                frmLogin.btnCancel.Enabled = AllowCancel;
                frmLogin.ControlBox = AllowCancel;

                frmLogin.Text = Title;

                if (frmLogin.LoadFromUserFile())
                {
                    StaffMember = frmLogin.GetUser;
                    return (true);
                }
                else
                {
                    frmLogin.ShowDialog();

                    if (frmLogin.DialogResult == DialogResult.OK)
                    {
                        StaffMember = frmLogin.GetUser;
                        return (true);
                    }
                }
            }
            finally
            {
                AppController.ApplicationController.BarcodeReceived -= frmLogin.User_BarcodeReceived;
                frmLogin.Dispose();
                frmLogin = null;
            }

            return (false);
        }

        #endregion Static Methods

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.Login;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppLogin;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnLogin.Text = LanguageStrings.AppMenuButtonOK;

            lblPassword.Text = LanguageStrings.AppPassword;
            lblUserName.Text = LanguageStrings.AppUserName;
        }

        #endregion Overridden Methods

        #region Properties

        public User GetUser
        {
            get
            {
                return (_StaffMember);
            }
        }

        #endregion Properties

        #region Private Methods

        private bool LoadFromUserFile()
        {
            if (!_allowAutoLogin)
                return (false);

            if (!String.IsNullOrEmpty(AppController.LocalSettings.DefaultUserName))
            {
                User user = User.UserGet(AppController.LocalSettings.DefaultUserID);

                if (user == null)
                    return (false);

                foreach (User usr in cmbUser.Items)
                {
                    if (usr.ID == user.ID)
                    {
                        _StaffMember = usr;
                        return (true);
                    }
                }
            }

            return (false);
        }

        private void BuildStaffMembers()
        {
            Users _StaffMembers = User.StaffMembers(true);

            cmbUser.Items.Clear();

            foreach (User user in _StaffMembers)
            {
                cmbUser.Items.Add(user);
            }
        }

        private void cmbUser_Format(object sender, ListControlConvertEventArgs e)
        {
            User user = (User)e.ListItem;

            e.Value = user.UserName;
        }

        private bool AutoLogin()
        {
            bool Result = false;

            int UserID = Shared.Utilities.StrToIntDef(GetXMLValue(XMLFile, 
                StringConstants.SETTINGS_AUTO_LOGIN, StringConstants.SETTINGS_USER_ID), -1);
            string UserEmail = GetXMLValue(XMLFile, StringConstants.SETTINGS_AUTO_LOGIN, StringConstants.SETTINGS_USER_EMAIL);
            string Password = GetXMLValue(XMLFile, StringConstants.SETTINGS_AUTO_LOGIN, StringConstants.SETTINGS_USER_PASSWORD);

            if (UserID > -1)
            {
                _StaffMember = User.UserGet(UserID);

                if (_StaffMember != null && _StaffMember.Email.ToLower() == UserEmail && _StaffMember.Password == Password)
                {
                    Result = true;
                }
            }

            return (Result);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _StaffMember = (User)cmbUser.SelectedItem;

            if (_StaffMember != null && (_StaffMember.Password == txtPassword.Text))
            {
                _allowCancel = true;
                DialogResult = DialogResult.OK;
            }
            else
            {
                txtPassword.Focus();
                ShowError(LanguageStrings.AppError, LanguageStrings.InvalidUsernameOrPassword);
            }
        }

        private void User_BarcodeReceived(object sender, AppController.BarcodeEventArgs e)
        {
            _StaffMember = User.UserFindByBarcode(e.Barcode);

            if (_StaffMember != null)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUser.SelectedItem != null)
                txtPassword.Focus();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (_allowAutoLogin && !String.IsNullOrEmpty(txtPassword.Text))
                btnLogin_Click(this, EventArgs.Empty);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_allowCancel;
        }

        #endregion Private Methods
    }
}
