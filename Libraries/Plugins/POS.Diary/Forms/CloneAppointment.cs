using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Users;
using Library.BOL.Appointments;
using Library.BOL.Therapists;
using Library.Utils;
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
                _appointment.Duration, Library.Enums.AppointmentStatus.Requested, 
                _appointment.AppointmentType, _appointment.TreatmentID, _appointment.TreatmentName, 
                _appointment.UserID, _appointment.UserName,
                _appointment.Notes, -1, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
            Appointments.Create(cloned, AppController.ActiveUser);

            foreach (Appointment sub in _appointment.ChildAppointments)
            {
                Appointment clonedChild = new Appointment(-1, sub.EmployeeID, Date, sub.StartTime,
                    sub.Duration, Library.Enums.AppointmentStatus.Requested, 
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
