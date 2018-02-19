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
 *  File: StaffSettingsHoliday.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

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
