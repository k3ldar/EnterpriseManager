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
 *  File: GlobalGeoIPCityCache.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.IPAddresses;

using Shared.Classes;

namespace Website.Library.Core.Threads
{
    /// <summary>
    /// Thread runs on start, and every 24 hours to reload city IP data into memory.
    /// 
    /// When data is fully loaded, lookups will be from memory only.
    /// </summary>
    public sealed class GlobalGeoIPCityCache : ThreadManager
    {
        #region Private Static Members

        private static bool _initialised = false;

#if CACHE_IP_CITY_DATA
        private static IPCity[] _allCityData;
        private static int _count = 0;
#endif

        #endregion Private Static Members

        #region Constructors

        internal GlobalGeoIPCityCache()
            : base(null, new TimeSpan(24, 0, 0), null, 0, 200, true, false)
        {
            ThreadManager.ThreadStart(this, "Load All GeoIP Data", System.Threading.ThreadPriority.Lowest);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
#if CACHE_IP_CITY_DATA
            List<IPCity> alldata = IPCity.GetAll();
            alldata.Sort();
            _allCityData = alldata.ToArray();
            _count = _allCityData.Length;
            _initialised = true;

            return (true);
#else
            return (false);
#endif
        }

        #endregion Overridden Methods

        #region public Methods

#if CACHE_IP_CITY_DATA
        public IPCity GetIPCity(string ipAddress, bool useMemory = true)
        {
            if (ipAddress == "::1")
                ipAddress = "127.0.0.1";

            if (useMemory && _initialised && _count > 0)
            {
                return (GetMemoryCity(ipAddress));
            }
            else
            {
                return (IPCity.Get(ipAddress, ipAddress));
            }
        }
#else
        public IPCity GetIPCity(string ipAddress)
        {
            if (String.IsNullOrEmpty(ipAddress) || ipAddress == "::1")
                ipAddress = "127.0.0.1";

            return (IPCity.Get(ipAddress, ipAddress));
        }

#endif

        #endregion Public Methods

        #region Properties

        internal bool Initialised { get { return (_initialised); } }

        #endregion Properties

        #region Private Methods

#if CACHE_IP_CITY_DATA
        private static IPCity GetMemoryCity(string ipAddress)
        {
            long ip = Shared.Utilities.IPToLong(ipAddress);

            long min = 0;
            long max = _allCityData.Length - 1;
            long mid = 0;

            while (min <= max)
            {
                mid = (min + max) / 2;

                if (ip <= _allCityData[mid].EndBlock && ip >= _allCityData[mid].StartBlock)
                {
                    return (_allCityData[mid]);
                }

                if (ip < _allCityData[mid].StartBlock)
                {
                    max = mid - 1;
                    continue;
                }

                if (ip > _allCityData[mid].EndBlock)
                {
                    min = mid + 1;
                }
            }

            return (null);
        }
#endif

        #endregion Private Methods
    }
}
