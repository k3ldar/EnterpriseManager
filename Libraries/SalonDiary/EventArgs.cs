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
 *  File: EventArgs.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using SharedControls.Interfaces;

using SharedBase.BOL.Appointments;
using SharedBase.BOL.Therapists;

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
        public AppointmentPayNowEventArgs(SharedBase.BOL.Appointments.Appointment appointment) { Appointment = appointment; }
        public SharedBase.BOL.Appointments.Appointment Appointment { private set; get; }
    }

    public delegate void PayNowEventHandler(object sender, AppointmentPayNowEventArgs e);

    public class SalonAppointmentEventArgs
    {
        public SalonAppointmentEventArgs(SharedBase.BOL.Appointments.Appointment appointment) { Appointment = appointment; }
        public SharedBase.BOL.Appointments.Appointment Appointment { private set; get; }
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
        public SalonUserEventArgs(SharedBase.BOL.Users.User User) { AppointmentUser = User; }

        public SharedBase.BOL.Users.User AppointmentUser
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
