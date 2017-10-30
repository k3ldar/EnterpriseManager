using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Appointments;
using Library.BOL.Therapists;
using Library.Utils;

namespace Heavenskincare.WebsiteTemplate.Appointments.Controls
{
    public partial class Step3 : BaseControlClass
    {
        #region Private Members

        private Therapists _therapists;
        private AppointmentTreatments _treatments;
        private double _startTime;
        private DateTime _date;
        private string _notes;

        #endregion Private Members

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Visible)
                FindAppointment();

            btnTryAgain.Text = Languages.LanguageStrings.TryAgain;
        }

        #region Properties

        public Therapists Therapists
        {
            set
            {
                _therapists = value;
            }
        }

        public AppointmentTreatments Treatments
        {
            set
            {
                _treatments = value;
            }
        }

        public double StartTime
        {
            set
            {
                _startTime = value;
            }
        }

        public DateTime Date
        {
            set
            {
                _date = value;
            }
        }

        public string Notes
        {
            set
            {
                _notes = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Finds next available appointment slot
        /// </summary>
        public void FindAppointment()
        {
            int duration = Duration();
            int count = 0;

            foreach (Therapist therapist in _therapists)
            {
                bool apptFound = false;
                DateTime checkDate = _date;
                double startingTime = _startTime;
                int loopCount = 0;
                do
                {
                    
                    if (therapist.AppointmentNextTimeSlot(checkDate, duration, ref startingTime))
                    {
                        SalonBooking booking = (SalonBooking)LoadControl("~/Appointments/Controls/SalonBooking.ascx");
                        booking.Refresh(therapist.EmployeeID, therapist.EmployeeName, startingTime, checkDate, _treatments, _notes);
                        pAppointments.Controls.Add(booking);
                        count++;
                        apptFound = true;
                    }

                    loopCount++;
                    checkDate = checkDate.AddDays(1);
                    startingTime = _startTime;

                } while (!apptFound || loopCount < 30);
            }

            if (count == 0)
            {
                lblError.Text = String.Format(Languages.LanguageStrings.CouldNotBookAppointment, 
                    _date.AddDays(1).ToString(GetWebsiteDateFormat()));
                lblError.Visible = true;
                pAppointments.Visible = false;
                btnTryAgain.Visible = true;
            }
            else
            {
                lblError.Visible = false;
                pAppointments.Visible = true;
                btnTryAgain.Visible = false;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private int Duration()
        {
            int Result = 0;

            foreach (AppointmentTreatment treat in _treatments)
            {
                Result += treat.Duration;
            }

            return (Result);
        }

        #endregion Private Methods

        protected void btnTryAgain_Click(object sender, EventArgs e)
        {
            if (TryAgain != null)
                TryAgain(this, EventArgs.Empty);
        }

        #region Events

        public event EventHandler TryAgain;

        #endregion Events

    }
}