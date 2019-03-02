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
 *  File: CloneAppointment.cs
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using SharedBase.BOL.Users;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Therapists;
using SharedBase.Utils;
using POS.Base.Classes;

namespace POS.Diary.Forms
{
    public partial class CloneAppointment : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Appointment _appointment;

        #endregion Private Members

        #region Constructors

        public CloneAppointment()
        {
            InitializeComponent();

        }

        public CloneAppointment(Appointment appt)
            : this ()
        {
            _appointment = appt;
            monthCalendar1.SelectionStart = DateTime.Now;
            LoadTherapistTimes();
        }

        #endregion Costructors

        #region Properties

        public DateTime Date
        {
            get
            {
                return (monthCalendar1.SelectionStart);
            }
        }

        #endregion Properties

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.DiaryApptClone;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppDiaryApptClone;

            lblSelectDate.Text = LanguageStrings.AppDiaryApptCloneDate;
            lblSelectTime.Text = LanguageStrings.AppDiaryApptCloneTime;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnClone.Text = LanguageStrings.AppMenuButtonClone;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnClone_Click(object sender, EventArgs e)
        {
            double Newtime = (double)cmbTimes.SelectedItem;

            //clone the appointment
            Appointment cloned = new Appointment(-1, _appointment.EmployeeID, Date, Newtime,
                _appointment.Duration, SharedBase.Enums.AppointmentStatus.Requested, 
                _appointment.AppointmentType, _appointment.TreatmentID, _appointment.TreatmentName, 
                _appointment.UserID, _appointment.UserName,
                _appointment.Notes, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
            Appointments.Create(cloned, AppController.ActiveUser);

            foreach (Appointment sub in _appointment.ChildAppointments)
            {
                Appointment clonedChild = new Appointment(-1, sub.EmployeeID, Date, sub.StartTime,
                    sub.Duration, SharedBase.Enums.AppointmentStatus.Requested, 
                    sub.AppointmentType,
                    sub.TreatmentID, sub.TreatmentName, sub.UserID, sub.UserName,
                    sub.Notes, cloned.ID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                Appointments.Create(clonedChild, AppController.ActiveUser);
            }


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LoadTherapistTimes()
        {
            Therapist therapist = _appointment.Therapist;

            cmbTimes.Items.Clear();

            for (Double t = therapist.StartTime; t <= therapist.EndTime; t = t + 0.25)
            {
                int idx = cmbTimes.Items.Add(t);

                if (_appointment.StartTime == t)
                    cmbTimes.SelectedIndex = idx;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadTherapistTimes();
        }

        private void cmbTimes_Format(object sender, ListControlConvertEventArgs e)
        {
            double t = (double)e.ListItem;
            e.Value = Shared.Utilities.DoubleToTime(t);
        }

        #endregion Private Members
    }
}
