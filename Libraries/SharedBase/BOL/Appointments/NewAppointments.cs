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
 *  File: NewAppointments.cs
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

using SharedBase.BOL.Therapists;

namespace SharedBase.BOL.Appointments
{
    public class NewAppointmentOptions
    {
        #region Constructors

        public NewAppointmentOptions()
        {
            Treatments = new AppointmentTreatments();
            Staff = new BOL.Therapists.Therapists();
            MaximumDays = 30;
            MaximumAppointments = 0;
        }

        #endregion Constructors

        #region Properties

        public AppointmentTreatments Treatments { get; set; }

        public BOL.Therapists.Therapists Staff { get; set; }

        public double PreferredStartTime { get; set; }

        public DateTime PreferredDate { get; set; }

        public int MaximumDays { get; set; }

        public int MaximumAppointments { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Finds next available appointment slot
        /// </summary>
        public void FindAppointments()
        {
            int duration = Duration();
            int count = 0;

            foreach (Therapist therapist in Staff)
            {
                count = 0;
                bool apptFound = false;
                DateTime checkDate = DateTime.Now.Date;
                double startingTime = PreferredStartTime;
                int loopCount = 0;
                do
                {
                    DateTime startTime;
                    DateTime finishTime;
                    bool allowTreat;
                    if (therapist.WorkingOverride(checkDate, out startTime, out finishTime, out allowTreat))
                    {
                        double newStart = Shared.Utilities.TimeToDouble(String.Format("{0}:{1}", startTime.Hour, startTime.Minute));

                        if (newStart > startingTime)
                            startingTime = newStart;
                    }

                    if (allowTreat)
                    {
                        if (therapist.AppointmentNextTimeSlot(checkDate, duration, ref startingTime))
                        {
                            if (AppointmentFound != null)
                            {
                                NewWizardAppointmentEventArgs args = new NewWizardAppointmentEventArgs(therapist, startingTime, checkDate);
                                AppointmentFound(this, args);
                                count++;
                                apptFound = true;
                            }
                        }
                    }

                    loopCount++;
                    checkDate = checkDate.AddDays(1);
                    startingTime = PreferredStartTime;

                } while (((MaximumAppointments == 0 && !apptFound) || (count < MaximumAppointments)) && loopCount < MaximumDays);
            }

            if (AppointmentSearchFinished != null)
                AppointmentSearchFinished(this, EventArgs.Empty);
        }

        #endregion Public Methods

        #region Private Methods

        private int Duration()
        {
            int Result = 0;

            foreach (AppointmentTreatment treat in Treatments)
            {
                Result += treat.Duration;
            }

            return Result;
        }

        #endregion Private Methods

        #region Events

        public event NewAppointmentEventDelegate AppointmentFound;


        public event EventHandler AppointmentSearchFinished;

        #endregion Events
    }

    public sealed class NewWizardAppointmentEventArgs : EventArgs
    {
        public NewWizardAppointmentEventArgs(Therapist therapist, double time, DateTime date)
        {
            Therapist = therapist;
            StartTime = time;
            Date = date;
        }

        /// <summary>
        /// Selected Therapist
        /// </summary>
        public Therapist Therapist { get; private set; }

        /// <summary>
        /// Appointment Start Time
        /// </summary>
        public Double StartTime { get; private set; }

        /// <summary>
        /// Appointment Date
        /// </summary>
        public DateTime Date { get; private set; }
    }

    public delegate void NewAppointmentEventDelegate(object sender, NewWizardAppointmentEventArgs e);
}
