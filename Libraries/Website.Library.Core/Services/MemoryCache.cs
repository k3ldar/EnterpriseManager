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
 *  File: MemoryCache.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using lib = Library;

using Shared.Classes;

using Website.Library.Core.Interfaces;

namespace Website.Library.Core.Services
{
    public class MemoryCache : IMemoryCache
    {
        #region Private Members

        private CacheManager _cacheShort;

        private CacheManager _cache;

        private CacheManager _cacheSession;

        #endregion Private Members

        #region Public Methods

        public CacheManager GetCache()
        {
            if (_cache == null)
                _cache = new CacheManager("Website Internal Cache", lib.DAL.DALHelper.CacheLimit);

            return (_cache);
        }

        public CacheManager GetShortCache()
        {
            if (_cacheShort == null)
                _cacheShort = new CacheManager("Website Internal Cache 5 Minutes", new TimeSpan(0, 5, 0));

            return (_cacheShort);
        }

        public CacheManager GetSessionCache()
        {
            if (_cacheSession == null)
                _cacheSession = new CacheManager("Website Session Cache 30 minutes", new TimeSpan(0, 30, 0), true, false);

            return (_cacheSession);
        }

        public void ResetCaches()
        {
            _cacheShort.Clear();
            _cache.Clear();
        }

        #endregion Public Methods
    }
}
