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
 *  File: Treatment.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

using Library.BOL.Users;

namespace Library.BOL.Treatments
{
    [Serializable]
    public sealed class Treatment : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private string _Name;
        private string _Price;
        private string _TreatmentLength;
        private string _Description;
        private string _Image;
        private string _URL;
        private int _SortOrder;
        private int _Duration;
        private bool _SpaDay;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public Treatment(int ID, string Name, string Price, string TreatmentLength, string Description,
            string Image, string URL, int SortOrder, int Duration, bool SpaDay)
        {
            _ID = ID;
            _Name = Name;
            _Price = Price;
            _TreatmentLength = TreatmentLength;
            _Description = Description;
            _Image = Image;
            _URL = URL;
            _SortOrder = SortOrder;
            _Duration = Duration;
            _SpaDay = SpaDay;
        }


        #endregion Constructors / Destructors

        #region Properties

        public int Duration
        {
            get
            {
                return (_Duration);
            }

            set
            {
                _Duration = value;
            }
        }

        public int SortOrder
        {
            get
            {
                return (_SortOrder);
            }

            set
            {
                _SortOrder = value;
            }
        }

        public string URL
        {
            get
            {
                return (_URL);
            }

            set
            {
                _URL = value;
            }
        }

        public string Image
        {
            get
            {
                return (_Image);
            }

            set
            {
                _Image = value;
            }
        }

        public string Description
        {
            get
            {
                return (_Description);
            }

            set
            {
                _Description = value;
            }
        }

        public string TreatmentLength
        {
            get
            {
                return (_TreatmentLength);
            }

            set
            {
                _TreatmentLength = value;
            }
        }

        public string Price
        {
            get
            {
                return (_Price);
            }

            set
            {
                _Price = value;
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
                _Name = value;
            }
        }

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

        public bool SpaDay
        {
            get
            {
                return (_SpaDay);
            }
        }

        /// <summary>
        /// Returns a list of Treatment Groups that this treatment belongs to
        /// </summary>
        public TreatmentGroups Groups
        {
            get
            {
                return (DAL.FirebirdDB.AdminTreatmentGroupsGet(this));
            }
        }

        #endregion Properties

        #region Public Methods

        public void Save(User user)
        {
            Utils.LibUtils.CanUpdate(user);
            DAL.FirebirdDB.AdminTreatmentUpdate(this);
        }

        public void Delete(User user)
        {
            Utils.LibUtils.CanDelete(user);
            DAL.FirebirdDB.AdminTreatmentDelete(this);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Treatment: {0}; Description: {1}", ID, _Description));
        }

        #endregion Overridden Methods

    }
}