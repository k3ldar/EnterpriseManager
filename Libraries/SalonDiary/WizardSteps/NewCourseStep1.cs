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
 *  File: NewCourseStep1.cs
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

using SalonDiary.Classes;

using SharedControls.WizardBase;

using Languages;
using SharedBase.BOL.Users;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Training;

namespace SalonDiary.WizardSteps
{
    public partial class NewCourseStep1 : BaseWizardPage
    {
        #region Private Members

        private NewCourseOptions _options;

        #endregion Private Members

        #region Constructor

        public NewCourseStep1(NewCourseOptions options)
        {
            InitializeComponent();

            _options = options;

            LoadCourses();
            LoadTrainers();

            dtpStartDate.Value = _options.StartDate;
            cbConsecutiveDays.Checked = _options.ConsecutiveDays;
            cbExcludeSaturday.Checked = _options.ExcludeSaturday;
            cbExcludeSunday.Checked = _options.ExcludeSunday;
            cbAutoExtendStaffHours.Checked = _options.ChangeWorkingHours;
        }

        #endregion Constructor

        #region Public Methods

        public override bool NextClicked()
        {
            // assume failure
            bool Result = false;

            //validate entries and set options
            if (cmbCourse.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCourseSelect);
                cmbCourse.DroppedDown = true;
                return (Result);
            }

            if (cmbTrainer.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCourseTrainerSelect);
                cmbTrainer.DroppedDown = true;
                return (Result);
            }

            if (dtpStartDate.Value.Date <= DateTime.Now.Date)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCoursePastDate);
                return (Result);
            }

            _options.Course = (TrainingCourse)cmbCourse.SelectedItem;
            _options.Trainer = (Therapist)cmbTrainer.SelectedItem;
            _options.StartDate = dtpStartDate.Value;
            _options.ConsecutiveDays = cbConsecutiveDays.Checked;
            _options.ExcludeSaturday = cbExcludeSaturday.Checked;
            _options.ExcludeSunday = cbExcludeSunday.Checked;
            _options.ChangeWorkingHours = cbAutoExtendStaffHours.Checked;

            Result = true;

            return (Result);
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbAutoExtendStaffHours.Text = LanguageStrings.AppDiaryCourseAdjustStaffHours;
            cbExcludeSunday.Text = LanguageStrings.AppDiaryCourseExcludeSundayPrompt;
            cbExcludeSaturday.Text = LanguageStrings.AppDiaryCourseExcludeSaturdayPrompt;
            cbConsecutiveDays.Text = LanguageStrings.AppDiaryCourseConsecutiveDaysPrompt;
            lblStartDate.Text = LanguageStrings.AppDiaryCourseStartDatePrompt;
            lblCourseTrainer.Text = LanguageStrings.AppDiaryCourseSelectTrainer;
            lblCourseSelect.Text = LanguageStrings.AppDiaryCourseSelectCourse;
        }

        #endregion Public Methods

        #region Private Methods

        private void LoadCourses()
        {
            cmbCourse.Items.Clear();

            TrainingCourses courses = TrainingCourses.Get();

            foreach (TrainingCourse course in courses)
                cmbCourse.Items.Add(course);

            foreach (TrainingCourse selCourse in cmbCourse.Items)
            {
                if (_options.Course != null && selCourse.ID == _options.Course.ID)
                {
                    cmbCourse.SelectedItem = selCourse;
                    break;
                }
            }
        }

        private void LoadTrainers()
        {
            cmbTrainer.Items.Clear();

            Therapists staff = Therapists.Get();

            foreach (Therapist staffMember in staff)
                cmbTrainer.Items.Add(staffMember);

            foreach (Therapist selUser in cmbTrainer.Items)
            {
                if (_options.Trainer != null && selUser.EmployeeID == _options.Trainer.EmployeeID)
                {
                    cmbTrainer.SelectedItem = selUser;
                    break;
                }
            }
        }

        private void cmbCourse_Format(object sender, ListControlConvertEventArgs e)
        {
            TrainingCourse course = (TrainingCourse)e.ListItem;
            e.Value = course.Name;
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrainingCourse course = (TrainingCourse)cmbCourse.SelectedItem;
            cbConsecutiveDays.Enabled = course.CourseLength > 1;
        }

        private void cmbTrainer_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist trainer = (Therapist)e.ListItem;
            e.Value = trainer.EmployeeName;
        }

        #endregion Private Methods

    }
}
