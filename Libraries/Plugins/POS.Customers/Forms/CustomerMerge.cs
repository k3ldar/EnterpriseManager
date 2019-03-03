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
 *  File: CustomerMerge.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using SharedBase.BOL.Users;

using POS.Base.Classes;
using POS.Base.Forms;

namespace POS.Customers.Forms
{
    public partial class CustomerMerge : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private User _primary;
        private User _secondary;

        #endregion Private Members

        #region Constructors

        public CustomerMerge()
        {
            InitializeComponent();
            UpdateUI();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.CustomersMerge;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppCustomerMergerAdministration;

            grpPrimary.Text = LanguageStrings.AppCustomerMergePrimaryRecord;
            grpSecondary.Text = LanguageStrings.AppCustomerMergeSecondaryRecord;

            lblPrimaryRecord.Text = String.Format(LanguageStrings.AppCustomerMergerCustomer, 
                LanguageStrings.AppPleaseSelect);
            lblSecondaryRecord.Text = String.Format(LanguageStrings.AppCustomerMergerCustomer, 
                LanguageStrings.AppPleaseSelect);
            lblPrimaryDescription.Text = LanguageStrings.AppCustomerMergePrimaryDescription;
            lblSecondaryDescription.Text = LanguageStrings.AppCustomerMergeSecondaryDescription;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnMerge.Text = LanguageStrings.AppMenuButtonMerge;
            btnSelectPrimary.Text = LanguageStrings.AppMenuButtonSelect;
            btnSelectSecondary.Text = LanguageStrings.AppMenuButtonSelect;
            btnViewPrimary.Text = LanguageStrings.AppMenuButtonView;
            btnViewSecondary.Text = LanguageStrings.AppMenuButtonView;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSelectPrimary_Click(object sender, EventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                _primary = selUser.SelectedUser;

                if (_primary != null)
                {
                    lblPrimaryRecord.Text = String.Format(LanguageStrings.AppCustomerMergerCustomer, _primary.UserName);
                }
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }

            UpdateUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                _secondary = selUser.SelectedUser;

                if (_secondary != null)
                {
                    lblSecondaryRecord.Text = String.Format(LanguageStrings.AppCustomerMergerCustomer, _secondary.UserName);
                }
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }

            UpdateUI();
        }

        private void btnViewPrimary_Click(object sender, EventArgs e)
        {
            if (_primary != null)
            {
                AdminMemberEdit editMember = new AdminMemberEdit(_primary);
                try
                {
                    editMember.ShowDialog(this);
                }
                finally
                {
                    editMember.Dispose();
                    editMember = null;
                }
            }

            UpdateUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_secondary != null)
            {
                AdminMemberEdit editMember = new AdminMemberEdit(_secondary);
                try
                {
                    editMember.ShowDialog(this);
                }
                finally
                {
                    editMember.Dispose();
                    editMember = null;
                }
            }

            UpdateUI();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShowQuestion(LanguageStrings.AppCustomerMerge, LanguageStrings.AppCustomerMergePrompt))
                {
                    Users.Merge(AppController.ActiveUser, _primary, _secondary);

                    //AppController.POSApplication.AllUsers.Remove(_secondary.ID);

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, 
                    String.Format(LanguageStrings.AppCustomerMergeError, err.Message));
            }
        }

        private void UpdateUI()
        {
            btnViewPrimary.Enabled = _primary != null;
            btnViewSecondary.Enabled = _secondary != null;
            btnMerge.Enabled = (_primary != null) && (_secondary != null);
        }

        #endregion Private Methods
    }
}
