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
 *  File: IBaseServices.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Microsoft.AspNetCore.Http;

using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Users;

using Shared.Classes;

using Website.Library.Core.Classes;

namespace Website.Library.Core.Interfaces
{
    public interface IBaseServices
    {
        #region Public Methods

        void ApplicationStart();

        #region User Session

        UserSession GetUserSession(HttpContext context);

        void UserSessionContinue(HttpContext context, ref UserSession session);

        UserSession StartUserSession(HttpContext context);

        #endregion User Session

        bool IgnoreErrorMessage(string Error);

        void ResetWebTitleCache();

        string GetWebTitle(HttpContext context);

        Uri GetAbsoluteUri(HttpContext context);

        string GetUserAgent(HttpContext context);

        Country WebCountry(HttpContext context);

        Currency WebsiteCurrency(HttpContext context);

        ShoppingBasket GetShoppingBasket(HttpContext context);

        #region Cookies

        void CookieSetValue(HttpContext context, string cookieName, string value, DateTime expires, bool isSessionCookie = false);

        string CookieGetValue(HttpContext context, string cookieName, string defaultValue);

        int CookieGetValue(HttpContext context, string cookieName, int defaultValue);

        Int64 CookieGetValue(HttpContext context, string cookieName, Int64 defaultValue);

        bool CookieExists(HttpContext context, string cookieName);

        #endregion Cookies

        #region Users

        Int64 GetUserID(HttpContext context);

        User GetUser(HttpContext context);

        bool UserIsLoggedOn(UserSession session);

        bool UserIsLoggedOn(HttpContext context);

        string GetUserCountry(HttpContext context, UserSession userSession);

        LocalWebSessionData GetUserLocalData(UserSession userSession);

        LocalWebSessionData GetUserLocalData(HttpContext context);

        void ResetDeliveryAddress(HttpContext context);

        void UserLogin(HttpContext context, User user);

        void UserLogout(HttpContext context, User user);

        #endregion Users

        #endregion Public Methods
    }
}
