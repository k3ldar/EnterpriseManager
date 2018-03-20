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
 *  File: IMemoryCache.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Shared.Classes;

namespace Website.Library.Core.Interfaces
{
    public interface IMemoryCache
    {
        #region Public Methods

        /// <summary>
        /// Five minute cache
        /// </summary>
        /// <returns></returns>
        CacheManager GetShortCache();
       
        /// <summary>
        /// User defined cache limit
        /// </summary>
        /// <returns></returns>
        CacheManager GetCache();

        /// <summary>
        /// Session Cache
        /// </summary>
        /// <returns></returns>
        CacheManager GetSessionCache();

        /// <summary>
        /// Resets all caches, clears all items
        /// </summary>
        void ResetCaches();

        #endregion Public Methods
    }
}
