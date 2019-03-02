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
 *  File: Step1.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Staff;

using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SicknessWizardSettings _returnToWork;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();
        }

        public Step1(SicknessWizardSettings returnToWork)
            : this()
        {
            _returnToWork = returnToWork;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblStaffMember.Text = LanguageStrings.AppStaffMemberSelect;
        }

        public override bool SkipPage()
        {
            return (_returnToWork.Staff != null);
        }

        public override void PageShown()
        {
            if (!_returnToWork.AllowSelectStaff)
                MainWizardForm.SelectNextPage();

            LoadStaff();

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffSickStep1;
        }

        public override bool NextClicked()
        {
            if (!_returnToWork.AllowSelectStaff)
                return (true);

            if (cmbStaffMember.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppStaffMember, LanguageStrings.AppStaffSelect);
                return (false);
            }

            _returnToWork.Staff = (StaffMember)cmbStaffMember.SelectedItem;
            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadStaff()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                cmbStaffMember.Items.Clear();

                SharedBase.BOL.Staff.StaffMembers allStaff = SharedBase.BOL.Staff.StaffMembers.All();

                foreach (StaffMember member in allStaff)
                {
                    cmbStaffMember.Items.Add(member);
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmbStaffMember_Format(object sender, ListControlConvertEventArgs e)
        {
            StaffMember staff = (StaffMember)e.ListItem;
            e.Value = staff.UserRecord.UserName;
        }

        #endregion Private Methods
    }
}
