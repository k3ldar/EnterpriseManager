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
 *  File: BaseCollection.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections;

using Shared.Classes;

namespace SharedBase.BOL
{
	/// <summary>
	/// BaseBOLCollection is the base class for all BOL collection classes.
	/// </summary>
    [Serializable]
	public class BaseCollection : CollectionBase
    {
        #region Constructors

        /// <summary>
		/// Constructor for BaseBOLCollection
		/// </summary>
		public BaseCollection()
		{

		}

		#endregion Constructors

        #region Caching

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

        #region Public Methods

        public void Reverse()
        {
            this.InnerList.Reverse();
        }

        #endregion Public Methods
    }
}
