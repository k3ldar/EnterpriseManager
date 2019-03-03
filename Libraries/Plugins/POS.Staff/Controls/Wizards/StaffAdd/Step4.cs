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
 *  File: Step4.cs
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

namespace POS.Staff.Controls.Wizards.StaffAdd
{
    public partial class Step4 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private StaffMember _staffMember;

        #endregion Private Members

        #region Constructors

        public Step4(StaffMember staff)
        {
            InitializeComponent();

            _staffMember = staff;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblLeaveEntitlement.Text = LanguageStrings.AppStaffLeaveEntitlement;
            cbLeaveAccrues.Text = LanguageStrings.AppStaffLeaveAccrues;
            cbLeaveCarriesOver.Text = LanguageStrings.AppStaffLeaveCarriesOver;
            rbLeaveDays.Text = LanguageStrings.Days;
            rbLeaveHours.Text = LanguageStrings.Hours;
        }

        public override bool NextClicked()
        {
            _staffMember.LeaveAccrues = cbLeaveAccrues.Checked;
            _staffMember.LeaveCarryOver = cbLeaveCarriesOver.Checked;
            _staffMember.LeaveEntitlement = udLeaveEntitlement.Value;
            _staffMember.EntitlementType = rbLeaveHours.Checked;

            return (true);
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep4;
        }

        #endregion Overridden Methods
    }
}
