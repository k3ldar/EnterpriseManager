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
