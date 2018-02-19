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
 *  File: AppointmentTreatment.cs
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

using Library;
using Library.BOL.Therapists;

namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentTreatment : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private bool _IsActive;
        private string _Name;
        private int _Duration;
        private bool _RequireFollowOn;
        private decimal _Cost;
        private int _MaxAvailable;

        private DateTime _lastTreated;
        private string _lastTreatedBy;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public AppointmentTreatment(int id, bool IsActive, string Name, int Duration,
            bool RequireFollowOn, decimal Cost, int MaxAvailable, string image)
        {
            _ID = id;
            _IsActive = IsActive;
            _Name = Name;
            _Duration = Duration;
            _RequireFollowOn = RequireFollowOn;
            _Cost = Cost;
            _MaxAvailable = MaxAvailable;
            Image = image;

            Status = ChangeState.NoChange;
        }

        public AppointmentTreatment(int ID, bool IsActive, string Name, int Duration, bool RequireFollowOn,
            decimal Cost, int MaxAvailable, DateTime LastTreated, string LastTreatedBy, string image)
            : this (ID, IsActive, Name, Duration, RequireFollowOn, Cost, MaxAvailable, image)
        {
            _lastTreated = LastTreated;
            _lastTreatedBy = LastTreatedBy;
        }

        #endregion Constructors / Destructs

        #region Properties

        public int ID
        {
            get
            {
                return (_ID);
            }

            set
            {
                _ID = value;
            }
        }

        public int MaximumTreatments
        {
            get
            {
                return (_MaxAvailable);
            }

            set
            {
                _MaxAvailable = value;

                if (_MaxAvailable < 0)
                    _MaxAvailable = 0;
            }
        }

        public bool IsActive
        {
            get
            {
                return (_IsActive);
            }

            set
            {
                _IsActive = value;
            }
        }

        public string Name
        {
            get
            {
                return (_Name);
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                    _Name = value;
            }
        }

        public int Duration
        {
            get
            {
                return (_Duration);
            }

            set
            {
                if (value > 0)
                    _Duration = value;
            }
        }

        public bool RequireFollowOn
        {
            get
            {
                return (_RequireFollowOn);
            }

            set
            {
                _RequireFollowOn = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return (_Cost);
            }

            set
            {
                if (value > 0.0m)
                    _Cost = value;
            }
        }

        public DateTime LastTreated
        {
            get
            {
                return (_lastTreated);
            }
        }

        public string LastTreatedBy
        {
            get
            {
                return (_lastTreatedBy);
            }
        }

        /// <summary>
        /// Current status of appointment
        /// 
        /// Used when adding/removing appointments treatments from a user
        /// </summary>
        public ChangeState Status { get; set;}

        /// <summary>
        /// Image associated with the treatment
        /// </summary>
        public string Image { get; set; }

        #endregion Properties

        #region Methods

        public bool TherapistAssigned(Therapist therapist)
        {
            bool Result = false;

            Result = DAL.FirebirdDB.AppointmentTreatmentContains(this, therapist);

            return (Result);
        }

        public override void Save()
        {
            DAL.FirebirdDB.AppointmentTreatmentSave(this);
        }

        public void Add(Therapist therapist)
        {
            DAL.FirebirdDB.AppointmentTreatmentAdd(this, therapist);
        }

        public void Remove(Therapist therapist)
        {
            DAL.FirebirdDB.AppointmentTreatmentRemove(this, therapist);
        }

        #endregion Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Treatment: {0}; Active: {1}; Name: {2}; Duration: {3}; Cost: {4}",
                ID, _IsActive.ToString(), _Name, _Duration, _Cost));
        }

        #endregion Overridden Methods
    }
}
