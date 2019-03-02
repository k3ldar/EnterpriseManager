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
 *  File: AffiliatedItems.cs
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

using SharedBase.BOL.Users;
using Shared.Classes;

namespace SharedBase.BOL.Affiliate
{
    [Serializable]
    public sealed class AffiliatedItems : BaseCollection
    {
        #region Static Methods

        public static Users.Users GetAffiliateUsers()
        {
            return (DAL.FirebirdDB.AffiliatedGetUsers());
        }

        public static User GetAffiliateUser(string affiliateID)
        {
            return (DAL.FirebirdDB.AffiliatedUserGet(affiliateID));
        }

        public static string UniqueID()
        {
            string Result = String.Empty;

            AffiliatedItem testItem = new AffiliatedItem(-1, null, String.Empty, String.Empty, 0, 0, false);
            do
            {
                Result = "AF" + Shared.Utilities.GetRandomWord(8, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            } while (!IsIDUnique(testItem, Result));

            return (Result);
        }

        public static bool IsIDUnique(AffiliatedItem item, string affiliateID)
        {
            return (DAL.FirebirdDB.AffiliateIDIsUnique(item, affiliateID));
        }

        public static AffiliatedItems Get(User user)
        {
            return (DAL.FirebirdDB.AffiliatedSitesGet(user));
        }

        public static string Get(string referringURL)
        {
            if (String.IsNullOrEmpty(referringURL))
                return (String.Empty);

            referringURL = referringURL.ToLower().Replace("www.", "").Replace("http://", "https://").Replace("https://", "");

            if (referringURL.Contains("/"))
                referringURL = referringURL.Substring(0, referringURL.IndexOf("/"));

            CacheItem Result = CachedItemGet(referringURL.ToLower());

            if (Result == null)
            {
                AffiliatedItem affItem = DAL.FirebirdDB.AffiliatedSiteGet(referringURL);

                Result = new CacheItem(referringURL.ToLower(), affItem == null ? null : affItem);
                CachedItemAdd(referringURL.ToLower(), Result);
            }

            if (Result.Value == null)
                return (String.Empty);
            else
                return (((AffiliatedItem)Result.Value).AffiliateID);
        }

        public static AffiliatedItem GetAffiliate(string referringURL)
        {
            if (String.IsNullOrEmpty(referringURL))
                return (null);

            referringURL = referringURL.ToLower().Replace("www.", "").Replace("http://", "https://").Replace("https://", "");

            if (referringURL.Contains("/"))
                referringURL = referringURL.Substring(0, referringURL.IndexOf("/"));

            CacheItem Result = CachedItemGet(referringURL.ToLower());

            if (Result == null)
            {
                AffiliatedItem affItem = DAL.FirebirdDB.AffiliatedSiteGet(referringURL);

                Result = new CacheItem(referringURL.ToLower(), affItem == null ? null : affItem);
                CachedItemAdd(referringURL.ToLower(), Result);
            }

            return ((AffiliatedItem)Result.Value);
        }


        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public AffiliatedItem this[int Index]
        {
            get
            {
                return ((AffiliatedItem)this.InnerList[Index]);
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
        public int Add(AffiliatedItem value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(AffiliatedItem value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, AffiliatedItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(AffiliatedItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(AffiliatedItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Affiliate.AffiliatedItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type AffiliatedItem";


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
