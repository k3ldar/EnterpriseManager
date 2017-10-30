using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Appointments;
using Library.Utils;

namespace Heavenskincare.WebsiteTemplate.Appointments.Controls
{
    public partial class SalonBooking : BaseControlClass
    {
        private Int64 _employeeID;
        private string _employee;
        private double _time;
        private DateTime _date;
        private AppointmentTreatments _treatments;
        private string _notes;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSelect.Text = Languages.LanguageStrings.BookAppointment;
        }

        public void Refresh(Int64 EmployeeID, string Employee, double Time, DateTime Date, AppointmentTreatments Treatments, string Notes)
        {
            _employeeID = EmployeeID;
            _employee = Employee;
            _time = Time;
            _date = Date;
            _treatments = Treatments;
            _notes = Notes;

            lblDescription.InnerHtml = String.Format("{0}<br />{1} - {2}", Employee, Shared.Utilities.DoubleToTime(Time), 
                Date.ToString(GetWebsiteDateFormat()));
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Int64 masterID = -1;

            foreach (AppointmentTreatment treat in _treatments)
            {
                Appointment appt = new Appointment(-1, _employeeID, _date, _time, treat.Duration, Library.Enums.AppointmentStatus.Requested,
                    0, treat.ID, treat.Name, GetUserID(), GetUser().UserName, _notes, masterID, DateTime.Now, DateTime.Now, -1, DateTime.Now.AddYears(-100));
                Library.BOL.Appointments.Appointments.Create(appt, GetUser());

                //get master id for next appointment (if there is one)
                if (masterID == -1)
                    masterID = appt.ID;

                //add the duration to the time
                _time += ((appt.Duration / 15) * .25);
            }

            
            Global.SendEMail("Heaven Salon", "salon@heavenskincare.com", "Online Appointment Created",
                String.Format("An appointment has been created online<br />Date: {0}<br />Please review and change status to Confirmed, contact user if there is a problem!",
                _date.ToShortDateString()));


            DoRedirect("/members/SalonAppointments.aspx");
        }
    }
}