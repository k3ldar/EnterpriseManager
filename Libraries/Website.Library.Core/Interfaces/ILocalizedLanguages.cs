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
 *  File: ILocalizedLanguages.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Library.BOL.Countries;
using Library.BOL.Basket;

using Microsoft.AspNetCore.Http;

using Shared.Classes;

using Website.Library.Core.Classes;

namespace Website.Library.Core.Interfaces
{
    public interface ILocalizedLanguages
    {
        #region Public Methods

        void ClearCountries();

        int GetPriceColumn(HttpContext context, UserSession userSession);

        string GetLanguageLinks();

        string SetLanguage(HttpContext context, UserSession userSession, Uri uri, Country country,
            Currency newCurrency, bool allowRedirect = true);

        string SetLanguage(HttpContext context, UserSession userSession, Uri uri);

        #endregion Public Methods


        #region Events

        /// <summary>
        /// Allows clients to override the price column in use
        /// </summary>
        event PriceColumnOverrideDelegate OnSelectPriceColumn;

        #endregion Events

    }
}
