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
 *  File: BaseObject.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#region License
// dnfBB 
// 
// The contents of this file are subject to the Initial Developer's Public License Version 1.0 
// (the "License"); you may not use this file except in compliance with the License. You may 
// obtain a copy of the License from dnfBB Project website.
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT 
// WARRANTY OF ANY KIND, either express or implied. See the License for the specific language 
// governing rights and limitations under the License.
// 
// The Original Code is part of dnfBB .
// 
// The Initial Developer of the Original Code is Simon Carter.
// 
// Portions created by Simon Carter (http://www.tectsoft.net/) are 
// Copyright (C) 2005 - 2006. Simon Carter. All Rights Reserved.
// 
// All Rights Reserved.
// 
// Contributor(s): Simon Carter.

#endregion License

using System;

using Shared.Classes;

namespace Library.BOL
{

	/// <summary>
	/// BaseBOLObject is the base class for all BOL Objects, excluding Collections.
	/// </summary>
    [Serializable]
	public abstract class BaseObject
	{
		#region Private Members

		private bool _isdirty;

		#endregion Private Members

		#region Properties

		/// <summary>
		/// Indicates wether the object has changed
		/// </summary>
		public bool IsDirty
		{
			get
			{
				return (_isdirty);
			}
		}

        public int StoreID
        {
            get
            {
                return (DAL.DALHelper.StoreID);
            }
        }

        /// <summary>
        /// Generic object for user defined data
        /// </summary>
        public object Tag { get; set; }

		#endregion Properties

		#region Constructors
		
		
		/// <summary>
		/// Constructor for BaseBOLObject
		/// </summary>
		public BaseObject()
		{
			_isdirty = false;
		}

		#endregion Constructors

		#region Protected Methods

		/// <summary>
		/// Indicates that the object has changed
		/// </summary>
		protected void Changed()
		{
			_isdirty = true;
		}

		#endregion Protected Methods

		#region Public Abstract Methods

		/// <summary>
		/// Saves the current object
		/// </summary>
        public virtual void Save()
        {
            CacheClear();
        }

		/// <summary>
		/// Forces the object to revert previous unchanged state, rolls back any changes
		/// </summary>
        public virtual void Refresh()
        {
        }

        /// <summary>
        /// Deletes the current object
        /// </summary>
        public virtual void Delete()
        {
        }

		#endregion Public Abstract Methods

        #region Caching

        /// <summary>
        /// Clears the cache
        /// </summary>
        protected static void CacheClear()
        {
            DAL.DALHelper.InternalCache.Clear();
            DAL.DALHelper.InternalCacheShort.Clear();
        }

        /// <summary>
        /// Returns an item from the cache
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static CacheItem CachedItemGet(string name)
        {
            return (DAL.DALHelper.InternalCache.Get(name));
        }

        /// <summary>
        /// Adds an item to the cache
        /// </summary>
        /// <param name="name"></param>
        /// <param name="item"></param>
        protected static void CachedItemAdd(string name, CacheItem item)
        {
            DAL.DALHelper.InternalCache.Add(name, item);
        }


        /// <summary>
        /// Returns an item from the cache
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static CacheItem CachedItemGetShort(string name)
        {
            return (DAL.DALHelper.InternalCacheShort.Get(name));
        }

        /// <summary>
        /// Adds an item to the cache
        /// </summary>
        /// <param name="name"></param>
        /// <param name="item"></param>
        protected static void CachedItemAddShort(string name, CacheItem item)
        {
            DAL.DALHelper.InternalCacheShort.Add(name, item);
        }

        /// <summary>
        /// Determines wether caching is available or not
        /// </summary>
        protected static bool CacheAvailable
        {
            get
            {
                return (DAL.DALHelper.AllowCaching);
            }
        }

        #endregion Caching
	}
}
