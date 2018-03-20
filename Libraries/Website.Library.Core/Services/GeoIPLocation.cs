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
 *  File: GeoIPLocation.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  18/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.IPAddresses;

using Website.Library.Core.Interfaces;
using Website.Library.Core.Threads;

namespace Website.Library.Core.Services
{
    public class GeoIPLocation : IGeoIPLocation
    {
        #region Private Members

        /// <summary>
        /// Thread for loading all geoip data into memory
        /// </summary>
        private GlobalGeoIPCityCache _globalGeoIpData;

        #endregion Private Members

        #region Constructors

        public GeoIPLocation()
        {
            _globalGeoIpData = new GlobalGeoIPCityCache();

#warning check settings to see if thread should be activated
        }

        #endregion Constructors

        #region Public Methods

        public IPCity GetIPCity(string ipAddress)
        {
            return (_globalGeoIpData.GetIPCity(ipAddress));
        }

        #endregion Public Methods
    }
}
