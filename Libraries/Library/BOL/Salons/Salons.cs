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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Salons.cs
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
using System.Collections;

namespace Library.BOL.Salons
{
    [Serializable]
    public sealed class Salons : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Returns a page of salons that are available to the public
        /// </summary>
        /// <param name="PageNumber">Current Page number</param>
        /// <param name="PageSize">Size of the Page of Salons</param>
        /// <returns>Salons collection</returns>
        public static Salons Get(int PageNumber, int PageSize)
        {
            return (DAL.FirebirdDB.SalonsGet(PageNumber, PageSize));
        }

        /// <summary>
        /// Returns all Salons where SalonName is a partial match
        /// </summary>
        /// <param name="SalonName"></param>
        /// <returns>Salons collection</returns>
        public static Salons Find(string SalonName)
        {
            return (DAL.FirebirdDB.SalonsFind(SalonName));
        }

        /// <summary>
        /// Returns an individual salon by name
        /// </summary>
        /// <param name="SalonName">Name of Salon to find</param>
        /// <returns>Salon if found, otherwise null</returns>
        public static Salon Get(string SalonName)
        {
            return (DAL.FirebirdDB.SalonFind(SalonName));
        }

        public static Salon Get(int SalonId)
        {
            return (DAL.FirebirdDB.SalonGet(SalonId));
        }

        /// <summary>
        /// Returns the number of salons
        /// </summary>
        /// <returns>int Number of publicly available salons</returns>
        public static int GetCount()
        {
            return (DAL.FirebirdDB.SalonsCount());
        }

        /// <summary>
        /// Finds nearest 10 salons to the given postcode
        /// </summary>
        /// <param name="Postcode">First part of post code, i.e. TF10</param>
        /// <returns></returns>
        public static Salons FindNearest(string Postcode)
        {
            return (DAL.FirebirdDB.SalonsFindNearest(Postcode));
        }

        /// <summary>
        /// Creates a new salon
        /// </summary>
        /// <param name="SalonName"></param>
        /// <returns></returns>
        public static Salon Create(string SalonName, Enums.SalonType SalonType)
        {
            return (DAL.FirebirdDB.AdminSalonCreate(SalonName, SalonType));
        }

        #endregion Static Methods

        #region Public Methods

        public Salon Find(Int64 SalonID)
        {
            Salon Result = null;

            foreach (Salon salon in this)
            {
                if (salon.ID == SalonID)
                {
                    Result = salon;
                    break;
                }
            }


            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public Salon this[int Index]
        {
            get
            {
                return ((Salon)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(Salon value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Salon value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Salon value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Salon value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Salon value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Salons.Salon";
        private const string OBJECT_TYPE_ERROR = "Must be of type Salon";


        #endregion Private Members

        #region Overridden Methods

        /// <summary>
        /// When Inserting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnInsert(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When removing an item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnRemove(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When Setting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            if (newValue.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "newValue");
        }


        /// <summary>
        /// Validates an object
        /// </summary>
        /// <param name="value"></param>
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR);
        }


        #endregion Overridden Methods

        #endregion Generic CollectionBase Code
    }
}