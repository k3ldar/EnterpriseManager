using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using Library.BOL.Staff;

namespace POS.Staff.Controls.Wizards.StaffAdd
{
    public partial class Step3 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private StaffMember _staffMember;

        #endregion Private Members

        #region Constructors

        public Step3(StaffMember staff)
        {
            InitializeComponent();

            _staffMember = staff;

        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            LoadEmploymentTypes();
            LoadPayPeriods();

            lblJobTitle.Text = LanguageStrings.AppStaffJobTitle;
            lblLocation.Text = LanguageStrings.AppStaffLocation;
            cbPartTime.Text = LanguageStrings.AppStaffPartTime;
            lblWeeklyHours.Text = LanguageStrings.AppStaffWeeklyHours;
            lblPayrollNumber.Text = LanguageStrings.AppStaffPayRollNumber;
            lblPayPeriod.Text = LanguageStrings.AppStaffPayPeriod;
            lblDateJoined.Text = LanguageStrings.AppStaffDateJoined;
            lblDatePermanent.Text = LanguageStrings.AppStaffDatePermanent;
            lblDateProbationEnds.Text = LanguageStrings.AppStaffProbationEnds;
            lblEmploymentType.Text = LanguageStrings.AppStaffEmploymentType;
        }

        public override bool NextClicked()
        {
            if (String.IsNullOrEmpty(txtJobTitle.Text))
            {
                ShowError(LanguageStrings.AppStaffMemberCreate, LanguageStrings.AppStaffMemberCreateJobTitle);
                return (false);
            }
            
            
            if (String.IsNullOrEmpty(txtLocation.Text))
            {
                ShowError(LanguageStrings.AppStaffMemberCreate, LanguageStrings.AppStaffMemberCreateLocation);
                return (false);
            }

            if (String.IsNullOrEmpty(txtPayrollNumber.Text))
            {
                ShowError(LanguageStrings.AppStaffMemberCreate, LanguageStrings.AppStaffMemberCreatePayrollNumber);
                return (false);
            }

            if (udWeeklyHours.Value == 0.0m && (EmploymentType)cmbEmploymentType.SelectedIndex != EmploymentType.ZeroHours)
            {
                ShowError(LanguageStrings.AppStaffMemberCreate, LanguageStrings.AppStaffMemberCreateWeeklyHours);
                return (false);
            }

            if (cmbPayPeriod.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppStaffMemberCreate, LanguageStrings.AppStaffMemberCreatePayPeriod);
                cmbPayPeriod.DroppedDown = true;
                return (false);
            }

            if (cmbEmploymentType.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppStaffMemberCreate, LanguageStrings.AppStaffMemberCreateEmploymentType);
                cmbEmploymentType.DroppedDown = true;
                return (false);
            }

            _staffMember.Title = txtJobTitle.Text;
            _staffMember.Location = txtLocation.Text;
            _staffMember.PartTime = cbPartTime.Checked;
            _staffMember.WeeklyHours = udWeeklyHours.Value;
            _staffMember.PayrollNumber = txtPayrollNumber.Text;
            _staffMember.PayPeriod = (PayPeriod)cmbPayPeriod.SelectedIndex;
            _staffMember.EmploymentType = (EmploymentType)cmbEmploymentType.SelectedIndex;
            _staffMember.DateJoined = dtpDateJoined.Value;
            _staffMember.DatePermanent = dtpDatePermanent.Value;
            _staffMember.DateProbationEnd = dtpDateProbationEnds.Value; 

            return base.NextClicked();
        }

        public override bool CanGoNext()
        {

            return base.CanGoNext();
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep3;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadEmploymentTypes()
        {
            cmbEmploymentType.Items.Clear();

            foreach (EmploymentType employmentType in Enum.GetValues(typeof(EmploymentType)))
            {
                cmbEmploymentType.Items.Add(Base.EnumTranslations.Translate(employmentType));
            }
        }

        private void LoadPayPeriods()
        {
            cmbPayPeriod.Items.Clear();

            foreach (PayPeriod period in Enum.GetValues(typeof(PayPeriod)))
            {
                cmbPayPeriod.Items.Add(Base.EnumTranslations.Translate(period));
            }
        }

        private void dtpDateJoined_ValueChanged(object sender, EventArgs e)
        {
            dtpDatePermanent.MinDate = dtpDateJoined.Value;
            dtpDateProbationEnds.MinDate = dtpDateJoined.Value;
        }

        #endregion Private Methods
    }
}
