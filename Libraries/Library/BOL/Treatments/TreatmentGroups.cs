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
 *  File: TreatmentGroups.cs
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

using Library.BOL.Users;

namespace Library.BOL.Treatments
{
    [Serializable]
    public sealed class TreatmentGroups : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Returns a collection of Product Groups
        /// </summary>
        /// <returns>ProductGroups collection</returns>
        public static TreatmentGroups Get()
        {
            return (DAL.FirebirdDB.TreatmentGroupsGet());
        }

        /// <summary>
        /// Returns an individual ProductGroup item
        /// </summary>
        /// <param name="ProductGroupID">ID of ProductGroup to retrieve</param>
        /// <returns>ProductGroup if found, otherwise null</returns>
        public static TreatmentGroup Get(int TreatmentGroupID)
        {
            return (DAL.FirebirdDB.TreatmentGroupGet(TreatmentGroupID));
        }

        /// <summary>
        /// Creates a new Treatment Group
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static TreatmentGroup Create(User user, string Description)
        {
            Utils.LibUtils.CanCreate(user);
            return (DAL.FirebirdDB.AdminTreatmentGroupCreate(Description));
        }

        /// <summary>
        /// Deletes a Treatment Group
        /// </summary>
        /// <param name="Group"></param>
        public static void Delete(User user, TreatmentGroup Group)
        {
            Utils.LibUtils.CanDelete(user); 
            DAL.FirebirdDB.AdminTreatmentGroupDelete(Group);
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public TreatmentGroup this[int Index]
        {
            get
            {
                return ((TreatmentGroup)this.InnerList[Index]);
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
        public int Add(TreatmentGroup value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(TreatmentGroup value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, TreatmentGroup value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(TreatmentGroup value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(TreatmentGroup value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Treatments.TreatmentGroup";
        private const string OBJECT_TYPE_ERROR = "Must be of type TreatmentGroup";


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
