using System;
using System.Collections.Generic;
using System.Text;

using SharedControls.Interfaces;

using Library.BOL.Appointments;
using Library.BOL.Therapists;

namespace SalonDiary.Controls
{
    public class EditAppointmentEventArgs
    {
        public EditAppointmentEventArgs(Appointment appointment, bool isLocked) { Appointment = appointment; IsLocked = isLocked; }

        public Appointment Appointment { private set; get; }

        public bool IsLocked { private set; get; }
    }

    public class CreateAppointmentEventArgs
    {
        private DateTime _appointmentDate;
        public CreateAppointmentEventArgs(DateTime dateTime, Therapist therapist) { Therapist = therapist; AppointmentDateTime = dateTime; }
        public Therapist Therapist { private set; get; }
        public DateTime AppointmentDateTime { set { _appointmentDate = value; } get { return (_appointmentDate); } }
    }

    public class CloneAppointmentEventArgs
    {
        private DateTime _clonedDate;
        public CloneAppointmentEventArgs(Appointment appointment) { Appointment = appointment; ClonedDate = appointment.AppointmentDate; }
        public Appointment Appointment { private set; get; }
        public DateTime ClonedDate { set {_clonedDate = value; } get{return (_clonedDate);} }
    }

    public class AppointmentUserEventArgs
    {
        public AppointmentUserEventArgs(Appointment appointment) { Appointment = appointment; }
        public Appointment Appointment { private set; get; }
    }

    public class AppointmentStatusChangedEventArgs
    {
        public AppointmentStatusChangedEventArgs(Appointment appointment) { Appointment = appointment; }
        public Appointment Appointment { private set; get; }
    }

    public class EditEmployeeEventArgs
    {
        public EditEmployeeEventArgs(Therapist therapist) { Therapist = therapist; }
        public Therapist Therapist { private set; get; }
    }

    public class EditWorkingHoursEventArgs
    {
        public EditWorkingHoursEventArgs(Therapist therapist, DateTime date) { Therapist = therapist; Date = date; }
        public Therapist Therapist { private set; get; }
        public DateTime Date { private set; get; }
    }


    public class AppointmentPayNowEventArgs
    {
        public AppointmentPayNowEventArgs(Library.BOL.Appointments.Appointment appointment) { Appointment = appointment; }
        public Library.BOL.Appointments.Appointment Appointment { private set; get; }
    }

    public delegate void PayNowEventHandler(object sender, AppointmentPayNowEventArgs e);

    public class SalonAppointmentEventArgs
    {
        public SalonAppointmentEventArgs(Library.BOL.Appointments.Appointment appointment) { Appointment = appointment; }
        public Library.BOL.Appointments.Appointment Appointment { private set; get; }
    }

    public delegate void SalonAppointmentEventHandler (object sender, SalonAppointmentEventArgs e);

    public class NotesGetEventArgs
    {
        private string _notes;
        public NotesGetEventArgs(string title, bool required) { Title = title; Required = required; }

        /// <summary>
        /// Are notes required?
        /// </summary>
        public bool Required { private set; get; }

        /// <summary>
        /// Title on window
        /// </summary>
        public string Title { private set; get; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes 
        { 
            set 
            { 
                _notes = value; 
            } 
            
            get 
            { 
                return (_notes); 
            } 
        }

        /// <summary>
        /// Result of showing notes, true then notes accepted, false notes not accepted
        /// </summary>
        public bool Result
        {
            get;
            set;
        }
    }

    public class SalonUserEventArgs
    {
        public SalonUserEventArgs(Library.BOL.Users.User User) { AppointmentUser = User; }

        public Library.BOL.Users.User AppointmentUser
        {
            get;
            private set;
        }
    }



    public sealed class SMSSendEventArgs
    {
        public ISMSSend SendInterface { get; set; }
    }

    public delegate void SMSSenderDelegate(object sender, SMSSendEventArgs e);

}
