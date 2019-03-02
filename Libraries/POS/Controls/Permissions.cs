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
 *  File: Permissions.cs
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

using SharedBase;
using SharedBase.BOL.Users;

#pragma warning disable IDE1006

namespace POS.Base.Controls
{
    public partial class Permissions : SharedControls.BaseControl
    {
        #region Private Members

        private User _user;
        private SecurityEnums.SecurityPermissionsAccounts _account;
        private SecurityEnums.SecurityPermissionsCalendar _calendar;
        private SecurityEnums.SecurityPermissionsPOS _pos;
        private SecurityEnums.SecurityPermissionsWebsite _website;
        private SecurityEnums.SecurityPermissionsReports _reports;
        private SecurityEnums.SecurityPermissionsStockControl _stock;
        private SecurityEnums.SecurityPermissionsStaff _staff;

        #endregion Private Members

        #region Constructors

        public Permissions()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPermissionType.Text = LanguageStrings.AppPermissionType;
            lblAvailable.Text = LanguageStrings.AppAvailable;
            lblAssigned.Text = LanguageStrings.AppAssigned;
            btnAssign.Text = String.Format(Classes.StringConstants.BUTTON_ASSIGN, LanguageStrings.AppAssign);
            btnRemove.Text = String.Format(Classes.StringConstants.BUTTON_UNASSIGN, LanguageStrings.AppRemove);
        }

        #endregion Overridden Methods

        #region Properties

        public bool WebOnly
        {
            set
            {
                if (value)
                {
                    cmbPermissions.Items.Clear();
                    cmbPermissions.Items.Add(LanguageStrings.AppWebsite);
                    cmbPermissions.SelectedIndex = 0;
                    LoadPermissionsWebsite();
                }
            }
        }

        public User User
        {
            set
            {
                _user = value;

                if (_user == null)
                {
                    _account = 0;
                    _calendar = 0;
                    _pos = 0;
                    _website = 0;
                    _stock = 0;
                    _staff = 0;
                }
                else
                {
                    _account = _user.PermissionsAccounts;
                    _calendar = _user.PermissionsCalendar;
                    _pos = _user.Permissions;
                    _website = _user.PermissionsWebsite;
                    _reports = _user.PermissionsReports;
                    _stock = _user.PermissionsStock;
                    _staff = _user.PermissionsStaff;

                    cmbPermissions.SelectedIndex = 0;
                    LoadPermissions();
                }
            }
        }

        #endregion Properties

        #region Public Methods

        public void Save()
        {
            _user.Permissions = _pos;
            _user.PermissionsAccounts = _account;
            _user.PermissionsCalendar = _calendar;
            _user.PermissionsWebsite = _website;
            _user.PermissionsReports = _reports;
            _user.PermissionsStock = _stock;
            _user.PermissionsStaff = _staff;
        }

        #endregion Public Methods

        #region Private Methods

        private void LoadPermissions()
        {
            lstAvailableSecurity.Items.Clear();
            lstSelectedSecurity.Items.Clear();

            foreach (string item in Enum.GetNames(typeof(SecurityEnums.SecurityPermissionsPOS)))
            {
                SecurityEnums.SecurityPermissionsPOS perm = (SecurityEnums.SecurityPermissionsPOS)Enum.Parse(typeof(SecurityEnums.SecurityPermissionsPOS), item);

                if ((_pos & perm) == perm)
                    lstSelectedSecurity.Items.Add(perm);
                else
                    lstAvailableSecurity.Items.Add(perm);
            }
        }

        private void LoadPermissionsCalendar()
        {
            lstAvailableSecurity.Items.Clear();
            lstSelectedSecurity.Items.Clear();

            foreach (string item in Enum.GetNames(typeof(SecurityEnums.SecurityPermissionsCalendar)))
            {
                SecurityEnums.SecurityPermissionsCalendar perm = (SecurityEnums.SecurityPermissionsCalendar)Enum.Parse(typeof(SecurityEnums.SecurityPermissionsCalendar), item);

                if ((_calendar & perm) == perm)
                    lstSelectedSecurity.Items.Add(perm);
                else
                    lstAvailableSecurity.Items.Add(perm);
            }
        }

        private void LoadPermissionsAccounts()
        {
            lstAvailableSecurity.Items.Clear();
            lstSelectedSecurity.Items.Clear();

            foreach (string item in Enum.GetNames(typeof(SecurityEnums.SecurityPermissionsAccounts)))
            {
                SecurityEnums.SecurityPermissionsAccounts perm = (SecurityEnums.SecurityPermissionsAccounts)Enum.Parse(typeof(SecurityEnums.SecurityPermissionsAccounts), item);

                if ((_account & perm) == perm)
                    lstSelectedSecurity.Items.Add(perm);
                else
                    lstAvailableSecurity.Items.Add(perm);
            }
        }

        private void LoadPermissionsStock()
        {
            lstAvailableSecurity.Items.Clear();
            lstSelectedSecurity.Items.Clear();

            foreach (string item in Enum.GetNames(typeof(SecurityEnums.SecurityPermissionsStockControl)))
            {
                SecurityEnums.SecurityPermissionsStockControl perm = (SecurityEnums.SecurityPermissionsStockControl)Enum.Parse(typeof(SecurityEnums.SecurityPermissionsStockControl), item);

                if ((_stock & perm) == perm)
                    lstSelectedSecurity.Items.Add(perm);
                else
                    lstAvailableSecurity.Items.Add(perm);
            }
        }

        private void LoadPermissionsWebsite()
        {
            lstAvailableSecurity.Items.Clear();
            lstSelectedSecurity.Items.Clear();

            foreach (string item in Enum.GetNames(typeof(SecurityEnums.SecurityPermissionsWebsite)))
            {
                SecurityEnums.SecurityPermissionsWebsite perm = (SecurityEnums.SecurityPermissionsWebsite)Enum.Parse(typeof(SecurityEnums.SecurityPermissionsWebsite), item);

                if ((_website & perm) == perm)
                    lstSelectedSecurity.Items.Add(perm);
                else
                    lstAvailableSecurity.Items.Add(perm);
            }
        }

        private void LoadPermissionsReports()
        {
            lstAvailableSecurity.Items.Clear();
            lstSelectedSecurity.Items.Clear();

            foreach (string item in Enum.GetNames(typeof(SecurityEnums.SecurityPermissionsReports)))
            {
                SecurityEnums.SecurityPermissionsReports perm = (SecurityEnums.SecurityPermissionsReports)Enum.Parse(typeof(SecurityEnums.SecurityPermissionsReports), item);

                if ((_reports & perm) == perm)
                    lstSelectedSecurity.Items.Add(perm);
                else
                    lstAvailableSecurity.Items.Add(perm);
            }
        }

        private void LoadPermissionsStaff()
        {
            lstAvailableSecurity.Items.Clear();
            lstSelectedSecurity.Items.Clear();

            foreach (string item in Enum.GetNames(typeof(SecurityEnums.SecurityPermissionsStaff)))
            {
                SecurityEnums.SecurityPermissionsStaff perm = (SecurityEnums.SecurityPermissionsStaff)Enum.Parse(typeof(SecurityEnums.SecurityPermissionsStaff), item);

                if ((_staff & perm) == perm)
                    lstSelectedSecurity.Items.Add(perm);
                else
                    lstAvailableSecurity.Items.Add(perm);
            }
        }

        private void cmbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPermissions.SelectedIndex)
            {
                case 0: // general
                    LoadPermissions();
                    break;
                case 1: //accounts
                    LoadPermissionsAccounts();
                    break;
                case 2: //calendar
                    LoadPermissionsCalendar();
                    break;
                case 3: //website
                    LoadPermissionsWebsite();
                    break;
                case 4: //reports
                    LoadPermissionsReports();
                    break;
                case 5: // stock
                    LoadPermissionsStock();
                    break;
                case 6: // staff
                    LoadPermissionsStaff();
                    break;
            }
        }

        private void lstAvailableSecurity_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailableSecurity.SelectedIndex > -1)
            {
                switch (cmbPermissions.SelectedIndex)
                {
                    case 0: // general
                        SecurityEnums.SecurityPermissionsPOS sel = (SecurityEnums.SecurityPermissionsPOS)lstAvailableSecurity.Items[lstAvailableSecurity.SelectedIndex];
                        _pos |= sel;
                        LoadPermissions();
                        break;
                    case 1: //accounts
                        SecurityEnums.SecurityPermissionsAccounts selA = (SecurityEnums.SecurityPermissionsAccounts)lstAvailableSecurity.Items[lstAvailableSecurity.SelectedIndex];
                        _account |= selA;
                        LoadPermissionsAccounts();
                        break;
                    case 2: //calendar
                        SecurityEnums.SecurityPermissionsCalendar selC = (SecurityEnums.SecurityPermissionsCalendar)lstAvailableSecurity.Items[lstAvailableSecurity.SelectedIndex];
                        _calendar |= selC;
                        LoadPermissionsCalendar();
                        break;
                    case 3: //website
                        SecurityEnums.SecurityPermissionsWebsite selW = (SecurityEnums.SecurityPermissionsWebsite)lstAvailableSecurity.Items[lstAvailableSecurity.SelectedIndex];
                        _website |= selW;
                        LoadPermissionsWebsite();
                        break;
                    case 4: //reports
                        SecurityEnums.SecurityPermissionsReports selR = (SecurityEnums.SecurityPermissionsReports)lstAvailableSecurity.Items[lstAvailableSecurity.SelectedIndex];
                        _reports |= selR;
                        LoadPermissionsReports();
                        break;

                    case 5: // Stock
                        SecurityEnums.SecurityPermissionsStockControl selS = (SecurityEnums.SecurityPermissionsStockControl)lstAvailableSecurity.Items[lstAvailableSecurity.SelectedIndex];
                        _stock |= selS;
                        LoadPermissionsStock();
                        break;

                    case 6: // Staff
                        SecurityEnums.SecurityPermissionsStaff selSt = (SecurityEnums.SecurityPermissionsStaff)lstAvailableSecurity.Items[lstAvailableSecurity.SelectedIndex];
                        _staff |= selSt;
                        LoadPermissionsStaff();
                        break;
                }
            }

            if (OnPermissionsChanged != null)
                OnPermissionsChanged(this, EventArgs.Empty);
        }

        private void lstSelectedSecurity_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelectedSecurity.SelectedIndex > -1)
            {
                switch (cmbPermissions.SelectedIndex)
                {
                    case 0: // general
                        SecurityEnums.SecurityPermissionsPOS sel = (SecurityEnums.SecurityPermissionsPOS)lstSelectedSecurity.Items[lstSelectedSecurity.SelectedIndex];
                        _pos &= ~sel;
                        LoadPermissions();
                        break;
                    case 1: //accounts
                        SecurityEnums.SecurityPermissionsAccounts selA = (SecurityEnums.SecurityPermissionsAccounts)lstSelectedSecurity.Items[lstSelectedSecurity.SelectedIndex];
                        _account &= ~selA;
                        LoadPermissionsAccounts();
                        break;
                    case 2: //calendar
                        SecurityEnums.SecurityPermissionsCalendar selC = (SecurityEnums.SecurityPermissionsCalendar)lstSelectedSecurity.Items[lstSelectedSecurity.SelectedIndex];
                        _calendar &= ~selC;
                        LoadPermissionsCalendar();
                        break;
                    case 3: //website
                        SecurityEnums.SecurityPermissionsWebsite selW = (SecurityEnums.SecurityPermissionsWebsite)lstSelectedSecurity.Items[lstSelectedSecurity.SelectedIndex];
                        _website &= ~selW;
                        LoadPermissionsWebsite();
                        break;
                    case 4: //reports
                        SecurityEnums.SecurityPermissionsReports selR = (SecurityEnums.SecurityPermissionsReports)lstSelectedSecurity.Items[lstSelectedSecurity.SelectedIndex];
                        _reports &= ~selR;
                        LoadPermissionsReports();
                        break;
                    case 5: //stock
                        SecurityEnums.SecurityPermissionsStockControl selS = (SecurityEnums.SecurityPermissionsStockControl)lstSelectedSecurity.Items[lstSelectedSecurity.SelectedIndex];
                        _stock &= ~selS;
                        LoadPermissionsStock();
                        break;

                    case 6: //Staff
                        SecurityEnums.SecurityPermissionsStaff selSt = (SecurityEnums.SecurityPermissionsStaff)lstSelectedSecurity.Items[lstSelectedSecurity.SelectedIndex];
                        _staff &= ~selSt;
                        LoadPermissionsStaff();
                        break;

                }

                if (OnPermissionsChanged != null)
                    OnPermissionsChanged(this, EventArgs.Empty);
            }
        }

        private void lstSelectedSecurity_Format(object sender, ListControlConvertEventArgs e)
        {
            string val = String.Empty;

            switch (cmbPermissions.SelectedIndex)
            {
                case 0: // general
                    SecurityEnums.SecurityPermissionsPOS sel = (SecurityEnums.SecurityPermissionsPOS)e.ListItem;
                    val = sel.ToString();
                    break;
                case 1: //accounts
                    SecurityEnums.SecurityPermissionsAccounts selA = (SecurityEnums.SecurityPermissionsAccounts)e.ListItem;
                    val = selA.ToString();
                    break;
                case 2: //calendar
                    SecurityEnums.SecurityPermissionsCalendar selC = (SecurityEnums.SecurityPermissionsCalendar)e.ListItem;
                    val = selC.ToString();
                    break;
                case 3: //website
                    SecurityEnums.SecurityPermissionsWebsite selW = (SecurityEnums.SecurityPermissionsWebsite)e.ListItem;
                    val = selW.ToString();
                    break;
                case 4: //reports
                    SecurityEnums.SecurityPermissionsReports selR = (SecurityEnums.SecurityPermissionsReports)e.ListItem;
                    val = selR.ToString();
                    break;
                case 5: //stock
                    SecurityEnums.SecurityPermissionsStockControl selS = (SecurityEnums.SecurityPermissionsStockControl)e.ListItem;
                    val = selS.ToString();
                    break;
                case 6: //staff
                    SecurityEnums.SecurityPermissionsStaff selSt = (SecurityEnums.SecurityPermissionsStaff)e.ListItem;
                    val = selSt.ToString();
                    break;
            }

            e.Value = Shared.Utilities.SplitCamelCase(val);
        }

        #endregion Private Methods

        #region Events

        public event EventHandler OnPermissionsChanged;

        #endregion Events
    }
}
