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
 *  File: EditTrainingAppointment.cs
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

using SharedBase.BOL.Appointments;
using SharedBase.BOL.Users;
using SharedBase.BOL.Training;
using POS.Base.Classes;

using POS.TrainingSchedule.Controls;

namespace POS.TrainingSchedule.Forms
{
    public partial class EditTrainingAppointment : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Course _course;
        private bool _isLocked;

        #endregion Private Members

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trainingAppointment">Appointment being edited</param>
        /// <param name="Locked">Determines wether the appointment is locked from editing or not</param>
        public EditTrainingAppointment(Appointment trainingAppointment, bool isLocked)
        {
            InitializeComponent();
            _isLocked = isLocked;

            Appointment appt = trainingAppointment;

            if (appt.MasterAppointment != -1)
                appt = Appointments.Get(appt.MasterAppointment);

            _course = Course.Get(appt.ID);

            LoadStaffMembers();
            LoadCourses();
            LoadAtendees(isLocked);

            cmbTrainer.Enabled = !isLocked;
            btnAddCompany.Enabled = !isLocked;
            btnSave.Enabled = !isLocked;

            cmbCourse.Enabled = false;

            item_AttendeeCountChanged(this, EventArgs.Empty);
        }

        #endregion Constructor

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TrainingScheduleEditAppointment;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppDiaryTrainingCourse;

            if (_isLocked)
                this.Text += String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE, this.Text, LanguageStrings.AppDiaryCourseLocked);

            btnAddCompany.Text = LanguageStrings.AppMenuButtonAddAttendees;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;

            lblTrainerDesc.Text = LanguageStrings.AppDiaryCourseTrainer1;
            lblCourseDesc.Text = LanguageStrings.AppDiaryCourse;
            lblAttendees.Text = LanguageStrings.AppDiaryAttendees;

            item_AttendeeCountChanged(this, EventArgs.Empty);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadAtendees(bool isLocked)
        {
            foreach (Attendee company in _course.CourseAttendees)
            {
                TrainingAppointmentItem item = new TrainingAppointmentItem(_course, company, isLocked);
                item.AttendeeCountChanged += item_AttendeeCountChanged;
                item.SalonRemove += item_SalonRemove;
                flowLayoutPanelAttendees.Controls.Add(item);
            }
        }

        private void LoadCourses()
        {
            cmbCourse.Items.Clear();

            TrainingCourses courses = TrainingCourses.Get();

            foreach (TrainingCourse course in courses)
                cmbCourse.Items.Add(course);

            foreach (TrainingCourse course in cmbCourse.Items)
            {
                if (course.ID == _course.CourseType.ID)
                {
                    cmbCourse.SelectedIndex = cmbCourse.Items.IndexOf(course);
                    break;
                }
            }
        }

        private void LoadStaffMembers()
        {
            if (_course.Trainer == null)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCourseTrainerInvalid);
            }

            Users staff = User.StaffMembers(false);

            foreach (User staffMember in staff)
                cmbTrainer.Items.Add(staffMember);

            foreach (User user in cmbTrainer.Items)
            {
                if (_course.Trainer != null && user.ID == _course.Trainer.EmployeeID)
                {
                    cmbTrainer.SelectedIndex = cmbTrainer.Items.IndexOf(user);
                    break;
                }
            }
        }

        private void cmbTrainer_Format(object sender, ListControlConvertEventArgs e)
        {
            User staff = (User)e.ListItem;
            e.Value = staff.UserName;
        }

        #endregion Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbTrainer.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCourseTrainerSelect);
                cmbTrainer.DroppedDown = true;
                return;
            }

            if (cmbCourse.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCourseSelect);
                cmbCourse.DroppedDown = true;
                return;
            }

            _course.Save();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cmbCourse_Format(object sender, ListControlConvertEventArgs e)
        {
            TrainingCourse course = (TrainingCourse)e.ListItem;
            e.Value = course.Name;
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            if (_course.SpacesAvailable > 0)
            {
                AdminSelectSalon selectSalon = new AdminSelectSalon();
                try
                {
                    selectSalon.ShowDialog(this);

                    if (selectSalon.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        //is the salon already part of the course
                        foreach (Attendee salons in _course.CourseAttendees)
                        {
                            if (salons.Salon.ID == selectSalon.SelectedSalon.ID)
                            {
                                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCourseMemberExists);
                                return;
                            }
                        }

                        Attendee attendee = new Attendee(selectSalon.SelectedSalon, 1, 0.00);
                        _course.CourseAttendees.Add(attendee);
                        TrainingAppointmentItem item = new TrainingAppointmentItem(_course, attendee, false);
                        item.AttendeeCountChanged += item_AttendeeCountChanged;
                        item.SalonRemove += item_SalonRemove;
                        flowLayoutPanelAttendees.Controls.Add(item);
                        item_AttendeeCountChanged(this, EventArgs.Empty);
                    }
                }
                finally
                {
                    selectSalon.Dispose();
                    selectSalon = null;
                }
            }
            else
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryCourseNoSpaces);
            }
        }

        private void item_SalonRemove(object sender, EventArgs e)
        {
            flowLayoutPanelAttendees.Controls.Remove((TrainingAppointmentItem)sender);
            _course.CourseAttendees.Remove(((TrainingAppointmentItem)sender).Attendee);
        }

        private void item_AttendeeCountChanged(object sender, EventArgs e)
        {
            lblTotalAttendees.Text = String.Format(LanguageStrings.AppDiaryCourseTotalAttendees, _course.TotalAttendees);
            lblPlacesAvailable.Text = String.Format(LanguageStrings.AppDiaryCoursePlacesAvailable, _course.SpacesAvailable);
        }
    }
}
