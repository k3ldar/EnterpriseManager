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
