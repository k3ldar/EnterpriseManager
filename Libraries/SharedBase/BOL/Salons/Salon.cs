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
 *  File: Salon.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Web;

using SharedBase.Utils;
using SharedBase.BOL.Users;

namespace SharedBase.BOL.Salons
{
    [Serializable]
    public class Salon
    {
        #region Private / Protected Members

        private int _ID;
        private string _Name;
        private string _Image;
        private string _ContactName;
        private string _Address;
        private string _Telephone;
        private string _Fax;
        private string _Email;
        private string _URL;
        private bool _SalonStockist;
        private int _Location;
        private int _SortOrder;
        private string _PostCode;
        private bool _VIPSalon;
        private float _Distance;
        private bool _ShowOnWeb;
        private int _UserID = -1;
        private Enums.SalonType _SalonType;
        private string _openingTimes;

        #endregion Private / Protected Members

        #region Constructor / Destructor

        public Salon(int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, string PostCode, string openingTimes)
        {
            _ID = ID;
            _Name = Name;
            _Image = Image;
            _ContactName = ContactName;

            if (Address.Contains("\r"))
            {
                Address = Address.Trim().Replace("\n", "");
                Address = Address.Replace("\r\r", "\r").Replace("\r\r", "\r");
                Address = Address.Replace("\r", "\r\n");
            }

            _Address = Address.Trim();
            _Telephone = Telephone;
            _Fax = Fax;
            _Email = Email;
            _URL = URL;
            _PostCode = PostCode;
            OpeningTimes = openingTimes;
        }

        public Salon(int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, bool SalonStockist, int Location, int SortOrder,
            string PostCode, bool VIPSalon, bool ShowOnWeb, Enums.SalonType SalonType, string openingTimes)
            :this (ID, Name, Image, ContactName, Address, Telephone, Fax, Email, URL, PostCode, openingTimes)
        {
            _SalonStockist = SalonStockist;
            _Location = Location;
            _SortOrder = SortOrder;
            _VIPSalon = VIPSalon;
            _ShowOnWeb = ShowOnWeb;
            _SalonType = SalonType;
        }

        public Salon(int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, bool SalonStockist, int Location, int SortOrder,
             string PostCode, bool VIPSalon, float Distance, Enums.SalonType SalonType, string openingTimes)
            :this (ID, Name, Image, ContactName, Address, Telephone, Fax, Email, URL, PostCode, openingTimes)
        {
            _SalonStockist = SalonStockist;
            _Location = Location;
            _SortOrder = SortOrder;
            _VIPSalon = VIPSalon;
            _Distance = Distance;
            _SalonType = SalonType;
        }

        public Salon(int UserID, int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, string PostCode, string openingTimes)
            :this (ID, Name, Image, ContactName, Address, Telephone, Fax, Email, URL, PostCode, openingTimes)
        {
            _UserID = UserID;
        }

        #endregion Constructor / Destructor

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

        public bool ShowOnWeb
        {
            get
            {
                return (_ShowOnWeb);
            }

            set
            {
                _ShowOnWeb = value;
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

        public string ContactName
        {
            get
            {
                return (_ContactName);
            }

            set
            {
                _ContactName = value;
            }
        }

        public string Address
        {
            get
            {
                return (_Address);
            }

            set
            {
                _Address = value;
            }
        }

        public string Telephone
        {
            get
            {
                return (_Telephone);
            }

            set
            {
                _Telephone = value;
            }
        }

        public string Fax
        {
            get
            {
                return (_Fax);
            }

            set
            {
                _Fax = value;
            }
        }

        public string Email
        {
            get
            {
                return (_Email);
            }

            set
            {
                _Email = value;
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

        public bool SalonStockist
        {
            get
            {
                return (_SalonStockist);
            }

            set
            {
                _SalonStockist = value;
            }
        }

        public int Location
        {
            get
            {
                return (_Location);
            }

            set
            {
                _Location = value;
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

        public string PostCode
        {
            get
            {
                return (_PostCode);
            }

            set
            {
                Shared.Utilities.IsValidUKPostcode(value, out _PostCode);
                //_PostCode = value;
            }
        }

        public bool VIPSalon
        {
            get
            {
                return (_VIPSalon);
            }

            set
            {
                _VIPSalon = value;
            }
        }

        public SalonDiscount SalonDiscount
        {
            get
            {
                SalonDiscount Result = null;

                //if (_VIPSalon)
                //{
                    Result = DAL.FirebirdDB.SalonDiscountGet(this);
                //}

                return (Result);
            }
        }

        public float Distance
        {
            get
            {
                return (_Distance);
            }

            set
            {
                _Distance = value;
            }
        }

        public User User
        {
            get
            {
                User Result = null;

                if (_UserID > -1)
                    Result = DAL.FirebirdDB.UserGet(_UserID);

                return (Result);
            }
        }

        public Enums.SalonType SalonType
        {
            get
            {
                return (_SalonType);
            }

            set
            {
                _SalonType = value;
            }
        }

        /// <summary>
        /// Salon has opening times listed
        /// </summary>
        public bool HasOpeningTimes { get; private set; }

        /// <summary>
        /// Raw opening times for salon
        /// </summary>
        internal string OpeningTimes 
        { 
            get
            {
                return (_openingTimes);
            }
            
            set
            {
                _openingTimes = value;

                if (String.IsNullOrEmpty(_openingTimes))
                {
                    HasOpeningTimes = false;
                    return;
                }
                else
                    HasOpeningTimes = true;

                //MON:Closed;TUE:9-6;WED:9-8;THU:9-9;FRI:9-6;SAT:9-5;SUN:Closed
                string[] days = _openingTimes.Split(';');

                foreach (string day in days)
                {
                    string dayName = day.Substring(0, 3);
                    string times = day.Substring(4);

                    if (String.IsNullOrEmpty(times))
                        continue;

                    //'MON:;TUE:9am - 6pm;WED:9am - 8pm;THU:9am - 9pm;FRI:9am - 6pm;SAT:9am - 5pm;SUN:'
                    switch (dayName)
                    {
                        case "MON":
                            OpeningMonday = times;
                            break;
                        case "TUE":
                            OpeningTuesday = times;
                            break;
                        case "WED":
                            OpeningWednesday = times;
                            break;
                        case "THU":
                            OpeningThursday = times;
                            break;
                        case "FRI":
                            OpeningFriday = times;
                            break;
                        case "SAT":
                            OpeningSaturday = times;
                            break;
                        case "SUN":
                            OpeningSunday = times;
                            break;
                    }
                }

                if (String.IsNullOrEmpty(OpeningFriday) && String.IsNullOrEmpty(OpeningMonday) && String.IsNullOrEmpty(OpeningSaturday) &&
                    String.IsNullOrEmpty(OpeningSunday) && String.IsNullOrEmpty(OpeningThursday) && String.IsNullOrEmpty(OpeningTuesday) &&
                    String.IsNullOrEmpty(OpeningWednesday))
                {
                    HasOpeningTimes = false;
                }
            }
        }

        /// <summary>
        /// Monday Opening Times
        /// </summary>
        public string OpeningMonday { get; private set; }

        /// <summary>
        /// Monday Opening Times
        /// </summary>
        public string OpeningTuesday { get; private set; }

        /// <summary>
        /// Monday Opening Times
        /// </summary>
        public string OpeningWednesday { get; private set; }

        /// <summary>
        /// Monday Opening Times
        /// </summary>
        public string OpeningThursday { get; private set; }

        /// <summary>
        /// Monday Opening Times
        /// </summary>
        public string OpeningFriday { get; private set; }

        /// <summary>
        /// Monday Opening Times
        /// </summary>
        public string OpeningSaturday { get; private set; }

        /// <summary>
        /// Monday Opening Times
        /// </summary>
        public string OpeningSunday { get; private set; }
        
        #endregion Properties

        #region Public Members

        public User UpdateOwner()
        {
            return (DAL.FirebirdDB.AdminSalonOwnerGet(this));
        }

        public void Delete()
        {
            DAL.FirebirdDB.AdminSalonDelete(this);
        }

        public void Save()
        {
            DAL.FirebirdDB.AdminSalonUpdate(this);
        }

        /// <summary>
        /// Set's the opening hours for a Salon
        /// </summary>
        /// <param name="monday"></param>
        /// <param name="tuesday"></param>
        /// <param name="wednesday"></param>
        /// <param name="thursday"></param>
        /// <param name="friday"></param>
        /// <param name="saturday"></param>
        /// <param name="sunday"></param>
        public void SetOpeningHours(string monday, string tuesday, string wednesday, string thursday,
            string friday, string saturday, string sunday)
        {
            OpeningTimes = String.Format("MON:{0};TUE:{1};WED:{2};THU:{3};FRI:{4};SAT:{5};SUN:{6}",
                monday, tuesday, wednesday, thursday, friday, saturday, sunday);
        }

        #endregion Public Members

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Salon: {0}; Name: {1}", ID, _Name));
        }

        #endregion Overridden Methods

    }
}