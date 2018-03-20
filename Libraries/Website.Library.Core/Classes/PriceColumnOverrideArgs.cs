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
 *  File: PriceColumnOverrideArgs.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Microsoft.AspNetCore.Http;

using Shared.Classes;

namespace Website.Library.Core.Classes
{
    public sealed class PriceColumnOverrideArgs : EventArgs
    {
        #region Constructors

        public PriceColumnOverrideArgs(HttpContext context, int priceColumn, string webSessionID, 
            bool allowOverride, UserSession userSession)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            PriceColumn = priceColumn;
            OverridePriceColumn = allowOverride;
            UserSession = userSession;
            WebSessionID = webSessionID;
        }

        #endregion Construcors

        #region Properties

        public HttpContext Context { get; private set; }

        public bool OverridePriceColumn { get; set; }

        public int PriceColumn { get; set; }

        public string WebSessionID { get; set; }

        public UserSession UserSession { get; set; }

        #endregion Properties
    }

    public delegate void PriceColumnOverrideDelegate(object sender, PriceColumnOverrideArgs e);
}
