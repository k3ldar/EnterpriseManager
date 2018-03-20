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
 *  File: BaseController.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  18/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Shared.Classes;

using Microsoft.AspNetCore.Mvc;

using Website.Library.Core.Classes;

namespace Website.Library.Core.Controllers
{
    public class BaseController : Controller
    {
        #region Protected Methods

        protected UserSession GetUserSession()
        {
            return ((UserSession)HttpContext.Items["UserSession"]);
        }

        protected LocalWebSessionData GetWebSessionData()
        {
            return ((LocalWebSessionData)GetUserSession().Tag);
        }

        #endregion Protected Methods
    }
}
