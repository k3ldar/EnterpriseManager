
using Languages;
using POS.Base.Classes;

namespace POS.Staff.Controls.Settings
{
    public partial class StaffSettingsHoliday : SharedControls.BaseSettings
    {
        #region Constructors

        public StaffSettingsHoliday()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblBookAhead.Text = LanguageStrings.AppStaffLeaveBookAhead;
            lblCarryOverDays.Text = LanguageStrings.Days;
            lblCarryOverHours.Text = LanguageStrings.Hours;
            lblLeaveYearEnds.Text = LanguageStrings.AppStaffLeaveYearEnds;
            lblLeaveYearStarts.Text = LanguageStrings.AppStaffLeaveYearStarts;
            lblMaxTakeDays.Text = LanguageStrings.Days;
            lblMaxTakeHours.Text = LanguageStrings.Hours;
            lblMinTakeDays.Text = LanguageStrings.Days;
            lblMinTakeHours.Text = LanguageStrings.Hours;
            cbAllowBookAcrossYears.Text = LanguageStrings.AppStaffLeaveBookAcrossYears;

            gbCarryOver.Text = LanguageStrings.AppStaffLeaveAllowCarryOver;
            gbLeaveYear.Text = LanguageStrings.AppStaffLeaveYear;
            gbMaxTake.Text = LanguageStrings.AppStaffLeaveMaximumAllowedTake;
            gbMinTake.Text = LanguageStrings.AppStaffLeaveMinimumAllowedTake;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.LeaveAllowBookFuture = (int)udBookAhead.Value;
            AppController.LocalSettings.LeaveAllowCrossLeaveYears = cbAllowBookAcrossYears.Checked;
            AppController.LocalSettings.LeaveMaxCarryOverDays = (double)udCarryOverDays.Value;
            AppController.LocalSettings.LeaveMaxCarryOverHours = (double)udCarryOverHours.Value;
            AppController.LocalSettings.LeaveMaximumTakeOnceDays = (double)udMaxTakeDays.Value;
            AppController.LocalSettings.LeaveMaximumTakeOnceHours = (double)udMaxTakeHours.Value;
            AppController.LocalSettings.LeaveMinimumTakeDays = (double)udMinTakeDays.Value;
            AppController.LocalSettings.LeaveMinimumTakeHours = (double)udMinTakeHours.Value;
            AppController.LocalSettings.LeaveYearEnds = dtpEnd.Value;
            AppController.LocalSettings.LeaveYearStarts = dtpStart.Value;

            return (base.SettingsSave());
        }

        public override void SettingsLoaded()
        {
            udBookAhead.Value = AppController.LocalSettings.LeaveAllowBookFuture;
            cbAllowBookAcrossYears.Checked = AppController.LocalSettings.LeaveAllowCrossLeaveYears;
            udCarryOverDays.Value = (decimal)AppController.LocalSettings.LeaveMaxCarryOverDays;
            udCarryOverHours.Value = (decimal)AppController.LocalSettings.LeaveMaxCarryOverHours;
            udMaxTakeDays.Value = (decimal)AppController.LocalSettings.LeaveMaximumTakeOnceDays;
            udMaxTakeHours.Value = (decimal)AppController.LocalSettings.LeaveMaximumTakeOnceHours;
            udMinTakeDays.Value = (decimal)AppController.LocalSettings.LeaveMinimumTakeDays;
            udMinTakeHours.Value = (decimal)AppController.LocalSettings.LeaveMinimumTakeHours;
            dtpEnd.Value = AppController.LocalSettings.LeaveYearEnds;
            dtpStart.Value = AppController.LocalSettings.LeaveYearStarts;
        }

        #endregion Overridden Methods
    }
}
