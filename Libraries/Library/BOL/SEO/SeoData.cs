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
 *  File: SeoData.cs
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

namespace Library.BOL.SEO
{
    [Serializable]
    public sealed class SeoData
    {
        #region Static Members

        private static TimeSpan _sessionLockTime = new TimeSpan(0, 0, 0, 0, 100);

        #endregion Static members

        #region Static Methods

        public static void SEOSavePage(UserSession session, PageViewData page)
        {
            DAL.FirebirdDB.SeoSessionSavePage(session, page);
        }

        public static void SEOSaveSession(UserSession session, int iteration = 0)
        {
            if (iteration > 10)
                return;

            try
            {
                using (TimedLock.Lock(session, _sessionLockTime))
                {
                    DAL.FirebirdDB.SeoSessionInsertUpdate(session);
                }
            }
            catch (LockTimeoutException)
            {
                // if we can't get a lock, we will try saving again next time
                return;
            }
            catch (Exception err)
            {
                if (err.Message.Contains("update conflicts with concurrent update"))
                {
                    SEOSaveSession(session, iteration + 1);
                }
            }
        }

        public static UserSession SeoSessionGet(string sessionID)
        {
            return (DAL.FirebirdDB.SeoSessionRetrieve(sessionID));
        }

        #endregion Static Methods
    }
}
