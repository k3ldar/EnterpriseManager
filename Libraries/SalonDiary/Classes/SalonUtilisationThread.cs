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
 *  File: SalonUtilisationThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

using Languages;

using Library.BOL.Therapists;
using Library.BOL.Appointments;

namespace SalonDiary.Classes
{
    public class SalonUtilisationThread
    {
        private Int64[] _therapists;
        private DateTime _startDate;
        private DateTime _endDate;
        private Thread salonUtilisationThread;
        public event UtilisationEventHandler OnUtilisation;

        private void RaiseOnUtilisation(string name, DateTime date, double hours, double lunch, double treatments, double otherHours)
        {
            if (OnUtilisation != null)
                OnUtilisation(this, new UtilisationEventArgs(name, date, hours, lunch, treatments, otherHours));
        }

        private void DoUtilisationReplication()
        {
            // declared at the top for purposes of error handling reporting below
            double totalHours = 0.00;
            double totalLunch = 0.00;
            double totalTreatments = 0.00;
            double totalOtherHours = 0.00;
            bool canTreat = true;
            Therapist therapist = null;
            DateTime currentDate;
            DateTime start;
            DateTime finish;
            Appointments therapistAppointments = null;

            try
            {
                foreach (Int64 employeeID in _therapists)
                {
                    try
                    {
                        therapist = Therapist.Get(employeeID);
                    }
                    catch (Exception error)
                    {
                        Shared.EventLog.Add(error, String.Format(StringConstants.EMPLOYEE_ID, employeeID));
                        continue;
                    }

                    if (therapist == null || therapist.Treatments.Count == 0)
                        continue;

                    currentDate = _startDate;

                    do
                    {
                        double hours = 0.00;
                        double lunch = 0.00;
                        double treatments = 0.00;
                        double otherHours = 0.00;

                        if (therapist.WorkingOverride(currentDate, out start, out finish, out canTreat))
                        {
                            TimeSpan sp = finish - start;
                            hours = sp.TotalHours;
                        }
                        else
                        {
                            if (therapist.AllowCreateAppointment(currentDate))
                                hours = therapist.EndTime - therapist.StartTime;
                        }

                        if (hours > 0)
                            lunch = (double)therapist.LunchDuration / 60;

                        therapistAppointments = Appointments.Get(currentDate, therapist, false);

                        foreach (Appointment appt in therapistAppointments)
                        {
                            switch (appt.AppointmentType)
                            {
                                case 0:
                                    treatments += (double)appt.Duration / 60;
                                    break;
                                case 3:
                                case 4:
                                case 5:
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                    otherHours += (double)appt.Duration / 60;
                                    break;
                                case 6:
                                case 7:
                                case 8:
                                    hours -= (double)appt.Duration / 60;
                                    lunch = 0.00;
                                    break;
                            }
                        }

                        RaiseOnUtilisation(therapist.EmployeeName, currentDate, hours, lunch, treatments, otherHours);

                        totalHours += hours;
                        totalLunch += lunch;
                        totalTreatments += treatments;
                        totalOtherHours += otherHours;
                        currentDate = currentDate.AddDays(1);
                    } while (currentDate.Date < _endDate.Date);
                }

                RaiseOnUtilisation(LanguageStrings.Total, _startDate, totalHours, totalLunch, totalTreatments, totalOtherHours);
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_THREAD_ABORT))
                    return;

                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err,
                    totalHours, totalLunch, totalTreatments, totalOtherHours, canTreat, therapist, therapistAppointments);

                if (err.Message.Contains(StringConstants.ERROR_READING_DATA_FROM_CONNECTION) ||
                    err.Message.Contains(StringConstants.ERROR_INVALID_TRANSACTION_HANDLE) ||
                    err.Message.Contains(StringConstants.ERROR_THREAD_ABORT))
                {
                    //ignore should reset
                }
                else if (!err.Message.Contains(StringConstants.ERROR_HANDLE_NOT_CREATED))
                    throw;
            }
        }

        public void Stop()
        {
            if (salonUtilisationThread != null)
            {
                if (salonUtilisationThread.IsAlive)
                {
                    salonUtilisationThread.Abort();
                }

                salonUtilisationThread = null;
            }
        }

        public void Start(Therapists therapists, DateTime start, DateTime finish)
        {
            //Stop the thread if its already running
            Stop();

            _startDate = start;
            _endDate = finish;

            _therapists = new Int64[therapists.Count];
            int idx = 0;

            foreach (Therapist therapist in therapists)
            {
                _therapists[idx] = therapist.EmployeeID;
                ++idx;
            }

            
            salonUtilisationThread = new Thread(new ThreadStart(DoUtilisationReplication)); // Create new thread
            salonUtilisationThread.Priority = ThreadPriority.BelowNormal; // Set priority to low
            salonUtilisationThread.IsBackground = true; // Set it to a background thread
            salonUtilisationThread.Name = StringConstants.THREAD_NAME_SALON_UTILISATION; // Name the thread
            salonUtilisationThread.Start();
        }
    }

    public delegate void UtilisationEventHandler (object sender, UtilisationEventArgs e);

    public class UtilisationEventArgs
    {
        public UtilisationEventArgs()
        {
            Name = String.Empty;
            Date = DateTime.Now;
            Hours = 0.00;
            Lunch = 0.00;
            Treatments = 0.00;
            OtherHours = 0.00;
        }

        public UtilisationEventArgs(string name, DateTime date, double hours, double lunch, double treatments, double otherHours)
        {
            Name = name;
            Date = date;
            Hours = hours;
            Lunch = lunch;
            Treatments = treatments;
            OtherHours = otherHours;
        }

        public string Name { private set; get; }
        public DateTime Date { private set; get; }
        public double Hours { private set; get; }
        public double Lunch { private set; get; }
        public double Treatments { private set; get; }
        public double OtherHours { private set; get; }
    }
}
