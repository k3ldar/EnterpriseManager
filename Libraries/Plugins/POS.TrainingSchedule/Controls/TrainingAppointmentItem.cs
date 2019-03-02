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
 *  File: TrainingAppointmentItem.cs
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

using SharedBase.BOL.Salons;
using SharedBase.BOL.Training;
using SharedBase.Utils;

using POS.Base.Classes;

namespace POS.TrainingSchedule.Controls
{
    public partial class TrainingAppointmentItem : SharedControls.BaseControl
    {
        #region Private Members

        private Course _course;
        private Attendee _attendee;

        #endregion Private Members

        #region Constructors

        public TrainingAppointmentItem(Course course, Attendee attendee, bool isLocked)
        {
            InitializeComponent();

            _course = course;
            _attendee = attendee;

            numericUpDown1.Enabled = !isLocked;
            picDelete.Enabled = !isLocked;

            lblSalonName.Text = attendee.Salon.Name;
            numericUpDown1.Value = attendee.NumberOfAttendees;
            UpdateCosts();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblNoOfAttendees.Text = Languages.LanguageStrings.AppNoOfAttendees;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void UpdateCosts()
        {
            double totalCost = _course.CourseType.CourseCost;

            if (_attendee.NumberOfAttendees > _course.CourseType.MaximumSalonAttendees)
            {
                totalCost += ((_attendee.NumberOfAttendees - _course.CourseType.MaximumSalonAttendees) * _course.CourseType.AdditionalAttendeeCost);
            }

            lblCourseFee.Text = String.Format(Languages.LanguageStrings.AppTotalCost, totalCost.ToString(StringConstants.SYMBOL_MONEY_FORMAT_CURRENCY));
            lblTotalPaid.Text = String.Format(Languages.LanguageStrings.AppTotalPaid, _attendee.TotalPaid.ToString(StringConstants.SYMBOL_MONEY_FORMAT_CURRENCY));
            lblBalance.Text = String.Format(Languages.LanguageStrings.AppBalance, (totalCost - _attendee.TotalPaid).ToString(StringConstants.SYMBOL_MONEY_FORMAT_CURRENCY));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (_attendee.NumberOfAttendees != Convert.ToInt32(numericUpDown1.Value))
            {
                if ((_course.TotalAttendees < _course.CourseType.MaximumAttendees) || (_attendee.NumberOfAttendees > Convert.ToInt32(numericUpDown1.Value)))
                {
                    _attendee.NumberOfAttendees = Convert.ToInt32(numericUpDown1.Value);
                    RaiseAttendeeCountChanged();
                    UpdateCosts();
                }
                else
                {
                    ShowError(Languages.LanguageStrings.AppCourseCapacity, Languages.LanguageStrings.AppCourseCapacityDescription);
                    numericUpDown1.Value = _attendee.NumberOfAttendees;
                }
            }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (ShowHardConfirm(Languages.LanguageStrings.AppSalonRemove, 
                String.Format(Languages.LanguageStrings.AppRemoveFromCourse, _attendee.Salon.Name)))
            {
                RaiseSalonRemove();
            }
        }

        #endregion Private Methods

        #region Properties

        /// <summary>
        /// Current Attendee for this object
        /// </summary>
        public Attendee Attendee
        {
            get
            {
                return (_attendee);
            }
        }

        #endregion Properties

        #region Event Raise Methods

        private void RaiseAttendeeCountChanged()
        {
            if (AttendeeCountChanged != null)
                AttendeeCountChanged(this, EventArgs.Empty);
        }

        private void RaiseSalonRemove()
        {
            if (SalonRemove != null)
                SalonRemove(this, EventArgs.Empty);
        }

        #endregion Event Raise Methods

        #region Events

        /// <summary>
        /// Event raised when course attendee capacity changes
        /// </summary>
        public event EventHandler AttendeeCountChanged;

        /// <summary>
        /// Event raised when a salon should be removed from the course
        /// </summary>
        public event EventHandler SalonRemove;

        #endregion Events

    }
}
