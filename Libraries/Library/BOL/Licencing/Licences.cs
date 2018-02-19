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
 *  File: Licences.cs
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
using Library.BOL.Users;

using Shared;

namespace Library.BOL.Licencing
{
    [Serializable]
    public sealed class Licences : BaseCollection
    {
        #region Public Methods

        /// <summary>
        /// Finds a licence by licence id
        /// </summary>
        /// <param name="InvoiceID">int LicenceID of licence to find</param>
        /// <returns>Licence object if found otherwise null</returns>
        public Licence Find(int licenceID)
        {
            Licence Result = null;

            foreach (Licence licence in this)
            {
                if (licence.ID == licenceID)
                {
                    Result = licence;
                    break;
                }
            }

            return (Result);
        }


        #endregion Public Methods

        #region Static Methods

        public static void CreateTrial(User user, LicenceType licenceType)
        {
            DAL.FirebirdDB.LicenceCreateTrial(licenceType, user);
        }

        /// <summary>
        /// Determins wether a user has a trial licence for a product
        /// </summary>
        /// <param name="user">User being tested</param>
        /// <param name="licenceType">Type of Licence</param>
        /// <returns>True if user has a trial licence, otherwise false</returns>
        public static bool HasTrialLicence(User user, LicenceType licenceType)
        {
            bool Result = false;

            Licences currentLicences = Get(user);

            foreach (Licence licence in currentLicences)
            {
                if (licence.LicenceType == (int)licenceType && licence.IsTrial)
                {
                    Result = true;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Retrieves all licences for a user
        /// </summary>
        /// <param name="user">User who's licences are sought</param>
        /// <returns>Licences collection</returns>
        public static Licences Get(User user)
        {
            return (DAL.FirebirdDB.LicenceGet(user));
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public Licence this[int Index]
        {
            get
            {
                return ((Licence)this.InnerList[Index]);
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
        public int Add(Licence value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Licence value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Licence value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Licence value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Licence value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Licencing.Licence";
        private const string OBJECT_TYPE_ERROR = "Must be of type Licence";


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
