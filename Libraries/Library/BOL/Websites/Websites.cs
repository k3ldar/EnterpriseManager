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
 *  File: Websites.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Library.BOL.Orders;
using Shared.Classes;

namespace Library.BOL.Websites
{
    /// <summary>
    /// Split Payments Collection
    /// </summary>
    [Serializable]
    public sealed class Websites : BaseCollection
    {
        #region Public Static Methods

        /// <summary>
        /// Creates a new instance of Website
        /// </summary>
        /// <returns>Website instance</returns>
        public static Website Create(string description, string ftpHost, int ftpPort, string ftpUsername, string ftpPassword, string rootPath)
        {
            ftpPassword = Website.EncryptPassword(ftpPassword);
            return (DAL.FirebirdDB.WebsiteInsert(description, ftpHost, ftpPort, ftpUsername, ftpPassword, rootPath));
        }

        /// <summary>
        /// Inserts an instance of Website into the database
        /// </summary>
        /// <returns>Website instance</returns>
        public static Website InsertUpdate(Website item)
        {
            return (DAL.FirebirdDB.WebsiteInsertUpdate(item));
        }

        /// <summary>
        /// Returns all records from table WEBSITES
        /// </summary>
        /// <returns>Websites collection of Website items</returns>
        public static Websites All()
        {
            return (DAL.FirebirdDB.WebsiteSelectAll());
        }

        public static Website Primary()
        {
            if (CacheAvailable)
            {
                string cacheName = "Websites Primary Website";
                CacheItem primary = CachedItemGet(cacheName);

                if (primary == null)
                {
                    primary = new CacheItem(cacheName, DAL.FirebirdDB.WebsiteSelectPrimary());
                    CachedItemAdd(cacheName, primary);
                }

                return ((Website)primary.Value);
            }
            else
            {
                return (DAL.FirebirdDB.WebsiteSelectPrimary());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Website Get(string url)
        {
            foreach (Website site in All())
            {
                if (site.URL == url.ToLower())
                    return (site);
            }

            return (null);
        }

        /// <summary>
        /// Returns a specific record from table WEBSITES
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Website item if found, otherwise null</returns>
        public static Website Get(int item)
        {
            return (DAL.FirebirdDB.WebsiteSelect(item));
        }

        #endregion Public Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public Website this[int Index]
        {
            get
            {
                return ((Website)this.InnerList[Index]);
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
        public int Add(Website value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Website value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Website value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Website value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Website value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Websites.Website";
        private const string OBJECT_TYPE_ERROR = "Must be of type Website";


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
