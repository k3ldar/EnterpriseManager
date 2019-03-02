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
 *  File: WorkingDay.cs
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

using SharedBase.BOLEvents;

namespace SharedBase.BOL.Therapists
{
    [Serializable]
    public sealed class WorkingDay : BaseObject
    {
        #region Private Members

        private Therapist _user;
        private DateTime _date;
        private double _startTime;
        private double _finishTime;
        private Enums.AppointmentRepeatType _repeatOption;
        private int _repeatDuration;
        private WorkingDays _owner;
        private int _id;
        private bool _allowTreatments;

        #endregion Private Members

        #region Constructors

        public WorkingDay(int id, Therapist user, DateTime date, double startTime, double finishTime, Enums.AppointmentRepeatType repeatOption, int repeatDuration,
            bool allowTreatments)
        {
            _user = user;
            _date = date;
            _startTime = startTime;
            _finishTime = finishTime;
            _repeatOption = repeatOption;
            _repeatDuration = repeatDuration;
            _id = id;
            _allowTreatments = allowTreatments;
        }

        #endregion Constructors

        #region Properties

        public Therapist User
        {
            get
            {
                return (_user);
            }
        }

        /// <summary>
        /// Determines wether the therapist can do treatments on the date
        /// </summary>
        public bool AllowTreatments
        {
            get
            {
                return (_allowTreatments);
            }

            set
            {
                _allowTreatments = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return (_date);
            }

            set
            {
                _date = value;
            }
        }

        public double StartTime
        {
            get
            {
                return (_startTime);
            }

            set
            {
                _startTime = value;
            }
        }

        public double FinishTime
        {
            get
            {
                return (_finishTime);
            }

            set
            {
                _finishTime = value;
            }
        }

        public Enums.AppointmentRepeatType RepeatOption
        {
            get
            {
                return (_repeatOption);
            }

            set
            {
                _repeatOption = value;
            }
        }

        public int RepeatDuration
        {
            get
            {
                return (_repeatDuration);
            }

            set
            {
                _repeatDuration = value;
            }
        }

        public WorkingDays Owner
        {
            get
            {
                return (_owner);
            }

            set
            {
                _owner = value;
            }
        }

        public int ID
        {
            get
            {
                return (_id);
            }
        }

        #endregion Properties

        #region Overridden methods

        public override void Save()
        {
            DAL.FirebirdDB.TherapistsWorkingDaysSave(this);

            if (OnSave != null)
                OnSave(this, new WorkingDayEventArgs(this));
        }

        public override void Delete()
        {
            DAL.FirebirdDB.TherapistsWorkingDaysDelete(this);

            if (OnDelete != null)
                OnDelete(this, new WorkingDayEventArgs(this));
        }

        public override string ToString()
        {
            return (String.Format("WorkingDay: {0}; Staff: {1}", ID, _user.EmployeeID));
        }

        #endregion Overridden Methods

        #region Events

        public event WorkingDayEventDelegate OnSave;

        public event WorkingDayEventDelegate OnDelete;

        #endregion Events
    }
}
