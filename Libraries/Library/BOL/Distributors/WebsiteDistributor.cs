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
 *  File: WebsiteDistributor.cs
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

namespace Library.BOL.Distributors
{
    [Serializable]
    public sealed class WebsiteDistributor : BaseObject
    {
        #region Constructors

        public WebsiteDistributor (Int64 id, string countryCode, string name, string url, bool isActive, string continent, bool autoRedirect)
        {
            ID = id;
            CountryCode = countryCode;
            Name = name;
            URL = url;
            IsActive = isActive;
            Continent = continent;
            AutoRedirect = autoRedirect;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID { get; private set; }
        
        public string CountryCode { get; private set; }
        
        public string Name { get; private set; }
        
        public string URL { get; private set; }

        public bool IsActive { get; private set; }

        public string Continent { get; private set; }

        public bool AutoRedirect { get; private set; }

        #endregion Properties
    }
}
