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
 *  File: WebVisitLogItem.cs
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

using Shared.Classes;

namespace SharedBase.BOL.SEO
{
    [Serializable]
    public sealed class WebVisitLogItem
    {
        #region Static Items

        #endregion Static Items

        #region Constructors

        public WebVisitLogItem(string platform, string browserVersion, string isCrawler,
            string remoteHost, string method, string path, string query,
            string referer, string userSession, string country)
        {
            Platform = platform;
            BrowserVersion = browserVersion;
            IsCrawler = isCrawler;
            RemoteHost = remoteHost;
            Method = method;
            Path = path;
            Query = query;
            Referer = referer;
            UserSession = userSession;
            Country = country;
            Date = DateTime.Now;
        }

        #endregion Constructors

        #region Properties

        public string Platform { get; private set; }
        public string BrowserVersion { get; private set; }
        public string IsCrawler { get; private set; }
        public string RemoteHost { get; private set; }
        public string Method { get; private set; }
        public string Path { get; private set; }
        public string Query { get; private set; }
        public string Referer { get; private set; }
        public string UserSession { get; private set; }
        public string Country { get; private set; }
        public DateTime Date { get; private set; }

        #endregion Properties

        #region Static Methods

        #endregion Static Methods
    }
}
