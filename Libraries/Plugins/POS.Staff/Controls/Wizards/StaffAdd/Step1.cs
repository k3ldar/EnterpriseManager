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
 *  File: Step1.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using SharedBase.BOL.Staff;
using SharedBase.BOL.Users;
using POS.Base.Forms;

namespace POS.Staff.Controls.Wizards.StaffAdd
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private User _newStaffMember = null;
        private StaffMember _staffMember;

        #endregion Private Members

        #region Constructors

        public Step1(StaffMember staff)
        {
            InitializeComponent();

            _staffMember = staff;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectNewStaffMember.Text = LanguageStrings.AppStaffSelectNewStaffMember;
            btnSelect.Text = LanguageStrings.AppMenuButtonSelect;
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep1;
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep1;
        }

        public override bool NextClicked()
        {
            if (_newStaffMember == null)
            {
                ShowError(LanguageStrings.AppStaffCreateNew, LanguageStrings.AppStaffSelectNewStaffMember);
                return (false);
            }

            if (_newStaffMember.MemberLevel >= SharedBase.MemberLevel.StaffMember)
            {
                ShowError(LanguageStrings.AppStaffCreateNew, LanguageStrings.AppStaffCreateNewAlreadyStaff);
                return (false);
            }

            _staffMember.UserID = _newStaffMember.ID;

            return (true);
        }

        public override bool CanGoNext()
        {
            return (_newStaffMember != null);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                _newStaffMember = selUser.SelectedUser;

                if (_newStaffMember != null)
                    txtStaffMemberName.Text = _newStaffMember.UserName;
                else
                    txtStaffMemberName.Text = String.Empty;

                MainWizardForm.UpdateUI();
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }
        }

        #endregion Private Methods
    }
}
