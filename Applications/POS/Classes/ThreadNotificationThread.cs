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
 *  File: ThreadNotificationThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

using POS.Base.Classes;
using POS.Base.Plugins;

using Shared.Classes;

namespace PointOfSale.Classes
{
    /// <summary>
    /// Updates home Tab Button Notification Counts
    /// </summary>
    public class ThreadNotificationThread : ThreadManager
    {
        private HomeCards _tabs;
        private List<HomeCard> _activeTabs;
        private DateTime _lastCheck = DateTime.Now.AddMinutes(-5);

        public ThreadNotificationThread()
#if MOVING_NOTIFICATIONS
            : base (null, new TimeSpan(0, 0, 0, 0, 50))
#else
            : base(null, new TimeSpan(0, 0, 0, 30))
#endif
        {
            _activeTabs = new List<HomeCard>();
            _tabs = PluginManager.HomeTabsGet();
        }

        protected override bool Run(object parameters)
        {
            if (!Forms.MainForm.HomeTabShowing)
                return (!HasCancelled());

            TimeSpan span = DateTime.Now - _lastCheck;

            if (span.TotalSeconds > 60)
            {
                foreach (HomeCard tab in _tabs)
                {
                    int notifications = tab.GetNotificationCount();

                    if (!Forms.MainForm.AllowProcess)
                        return (false);

                    if (notifications > 0)
                    {
                        if (!_activeTabs.Contains(tab))
                            _activeTabs.Add(tab);
                    }
                    else
                    {
                        if (!_activeTabs.Contains(tab))
                            _activeTabs.Remove(tab);
                    }

                    tab.HomeTabButton.ShowNotifications(notifications);
                }

                _lastCheck = DateTime.Now;
            }

#if MOVING_NOTIFICATIONS
            foreach (HomeTab tab in _activeTabs)
            {
                tab.HomeTabButton.UpdateNotification();

                if (HasCancelled())
                    return (false);
            }
#endif

            return (!HasCancelled());
        }
    }
}
