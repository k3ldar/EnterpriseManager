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
 *  File: AppointmentHistoryItem.cs
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

namespace SharedBase.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentChangeItem : BaseObject
    {
        private Int64 _id;
        private DateTime _date;
        private double _startTime;
        private int _duration;
        private Enums.AppointmentStatus _status;
        private int _type;
        private string _employee;
        private string _treatment;
        private string _notes;
        private DateTime _lastAltered;
        private string _alteredBy;

        public AppointmentChangeItem(Int64 id, DateTime date, double startTime, int duration, 
            Enums.AppointmentStatus status,
            int type, string employee, string treatment, string notes, DateTime lastAltered, string alteredBy)
        {
            _id = id;
            _date = date;
            _startTime = startTime;
            _duration = duration;
            _status = status;
            _type = type;
            _employee = employee;
            _treatment = treatment;
            _notes = notes;
            _lastAltered = lastAltered;
            _alteredBy = alteredBy;
        }

        #region Properties

        public Int64 Id
        {
            get
            {
                return _id;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
        }

        public double StartTime
        {
            get
            {
                return _startTime;
            }
        }

        public int Duration
        {
            get
            {
                return _duration;
            }
        }

        public Enums.AppointmentStatus Status
        {
            get
            {
                return _status;
            }
        }

        public int Type
        {
            get
            {
                return _type;
            }
        }

        public string Employee
        {
            get
            {
                return _employee;
            }
        }

        public string Treatment
        {
            get
            {
                return _treatment;
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
        }

        public DateTime LastAltered
        {
            get
            {
                return _lastAltered;
            }
        }

        public string AlteredBy
        {
            get
            {
                return _alteredBy;
            }
        }


        #endregion

        #region Public Methods

        public bool StatusArrivedCompleteConfirmed(Appointment appointment)
        {
            if (_date.Date != appointment.AppointmentDate.Date)
                return true;

            if (_startTime != appointment.StartTime)
                return true;

            if (_duration != appointment.Duration)
                return true;

            if (_type != appointment.AppointmentType)
                return true;

            if (_employee != appointment.EmployeeName)
                return true;

            if (_treatment != appointment.TreatmentName)
                return true;

            if (_notes != appointment.Notes)
                return true;

            if (_status == Enums.AppointmentStatus.Completed | 
                _status == Enums.AppointmentStatus.Arrived | 
                _status == Enums.AppointmentStatus.Confirmed)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Returns the differences between an appointment and this change item
        /// </summary>
        /// <param name="appointment">Appointment being compared to</param>
        /// <returns></returns>
        public string FindChanges(Appointment appointment)
        {
            string Result = String.Empty;

            if (_date.Date != appointment.AppointmentDate.Date)
                Result += String.Format("Date changed from: {0}\r\n", _date.ToString("dd/MM/yyyy"));

            if (_startTime != appointment.StartTime)
                Result += String.Format("Time changed from: {0}\r\n", Shared.Utilities.DoubleToTime(_startTime));

            if (_duration != appointment.Duration)
                Result += String.Format("Duration changed from: {0} minutes\r\n", _duration.ToString());

            if (_status != appointment.Status)
                Result += String.Format("Status changed from: {0}\r\n", Shared.Utilities.SplitCamelCase(_status.ToString()));

            if (_type != appointment.AppointmentType)
                Result += String.Format("Appointment type changed from: {0}\r\n", AppointmentTypes.Get(_type).Description);

            if (_employee != appointment.EmployeeName)
                Result += String.Format("Therapist changed from: {0}\r\n", _employee);

            if (_treatment != appointment.TreatmentName)
                Result += String.Format("Treatment changed from: {0}\r\n", _treatment);

            if (_notes != appointment.Notes)
                Result += String.Format("Notes changed from: {0}\r\n", _notes);

            Result = Result.Trim();

            return Result;
        }

        #endregion Public Methods

        #region Overridden Methods

        //public override string ToString()
        //{
        //    string Result = String.Format("");

        //    return (Result);
        //}

        #endregion Overridden Methods
    }
}
