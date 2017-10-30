using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Staff;

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
