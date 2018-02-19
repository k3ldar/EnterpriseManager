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
 *  File: BasePlugin.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using SharedControls.Forms;
using POS.Base.Classes;
using Shared;

namespace POS.Base.Plugins
{
    public abstract class BasePlugin
    {
        #region Constructors

        public BasePlugin(Form parent)
        {
            ToastActions = new List<PluginToastAction>();
            ParentForm = parent;
            RaiseAlerts = false;
            AlertFrequency = new TimeSpan(1, 0, 0);
            AlertLastRun = DateTime.Now.AddDays(-10);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Parent Form
        /// </summary>
        public Form ParentForm { get; private set; }

        /// <summary>
        /// does the plugin want alerts
        /// </summary>
        public bool RaiseAlerts { get; set; }

        /// <summary>
        /// How often are we alerting the plugiin
        /// </summary>
        public TimeSpan AlertFrequency { get; set; }

        /// <summary>
        /// Last time the alert was run
        /// </summary>
        public DateTime AlertLastRun { get; set; }

        /// <summary>
        /// Plugin specific toast actions
        /// </summary>
        private List<PluginToastAction> ToastActions { get; set; }

        #endregion Properties

        #region General Plugin Methods

        /// <summary>
        /// Version of plugin, for backward compatibility
        /// </summary>
        /// <returns></returns>
        public abstract PluginVersion Version();

        /// <summary>
        /// Gets the name of the Plugin
        /// </summary>
        /// <returns></returns>
        public abstract string PluginName();

        /// <summary>
        /// Determines wether the plugin can be unloaded
        /// 
        /// Core plugins should return false
        /// </summary>
        /// <returns>true if the plugin can be unloaded</returns>
        public abstract bool CanUnload();

        /// <summary>
        /// Requests that the plugin unloads
        /// </summary>
        public abstract void Unload();

        /// <summary>
        /// Method called After plugin module loaded into memory, prior to any actions taking place
        /// </summary>
        /// <returns>bool if the plugin can continue to load, otherwise false</returns>
        public abstract bool BeforeLoad();

        /// <summary>
        /// Method called after the plugin module is loaded
        /// </summary>
        public abstract void AfterLoad();


        public virtual void Alert()
        {
        }

        #endregion General Plugin Methods

        #region Notification Events

        public virtual void Notification(NotificationEventArgs e)
        {
            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_TOAST_NOTIFICATION:
                    if ((ToastEventType)e.EventValue == ToastEventType.None)
                        return;

                    if (ProcessToastNotificaton((ToastEventType)e.EventValue, (string)e.Param3))
                    {
                        e.AllowContinue = false;
                    }

                    break;
            }
        }

        public virtual void NotificationsGet(ref List<string> names)
        {
            names.Clear();
        }

        #endregion Notification Events

        #region Language / Culture

        /// <summary>
        /// Method for update of culture
        /// </summary>
        /// <param name="culture"></param>
        public abstract void UpdateLanguage(CultureInfo culture);

        #endregion Language / Culture

        #region Settings

        /// <summary>
        /// Allows the plugin to Load settings within the Administration Settings Panel
        /// </summary>
        /// <param name="settingsForm"></param>
        public abstract void LoadAdministrationSettings(FormSettings settingsForm);

        /// <summary>
        /// Allows the plugin to load settings within the user settings panel
        /// </summary>
        /// <param name="settingsForm"></param>
        public abstract void LoadUserSettings(FormSettings settingsForm);

        /// <summary>
        /// Determines wether the plugin will allow the application to close or not
        /// </summary>
        /// <returns>true if plugin can close, otherwise false</returns>
        public abstract bool CanClose();

        #endregion Settings

        #region Menu

        public abstract void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu);

        public abstract void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu);

        public abstract void MenuDropDown(PluginMenuType menuType);

        #endregion Menu

        #region Home Cards

        public abstract HomeCards HomeCards();

        #endregion Home Cards

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public abstract TrayNotificationCollection TrayNotifications();

        #endregion Notification Items

        #region Toast Notifications

        protected void AddToastNotification(string notificationMessage, Action<object> notificationMethod, object data)
        {
            NotificationEventArgs args = new NotificationEventArgs(ToastEventType.None, String.Empty, notificationMessage, Guid.NewGuid().ToString());
            PluginManager.RaiseEvent(args);
            ToastActions.Add(new PluginToastAction((string)args.Param3, notificationMethod, data));
        }

        #endregion Toast Notifications

        #region Event Wrappers

        protected virtual void OnRaisePluginUsage(PluginUsageEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<PluginUsageEventArgs> handler = PluginUsage;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnRaiseBringToFront(EventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<EventArgs> handler = POSBringToFront;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public virtual void RaiseEventNotification(NotificationEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<NotificationEventArgs> handler = EventNotification;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Event Wrappers

        #region Events

        /// <summary>
        /// Event raised to show plugin usage
        /// </summary>
        public event EventHandler<PluginUsageEventArgs> PluginUsage;

        /// <summary>
        /// Event raised when the parent needs to be bought to the front
        /// </summary>
        public event EventHandler<EventArgs> POSBringToFront;

        /// <summary>
        /// Event raised when a plugin fires an event
        /// </summary>
        public event EventHandler<NotificationEventArgs> EventNotification;

        #endregion Events

        #region Private Methods

        private bool ProcessToastNotificaton(ToastEventType eventType, string uniqueID)
        {
            foreach (PluginToastAction action in ToastActions)
            {
                if (action.UniqueID == uniqueID)
                {
                    ToastActions.Remove(action);

                    if (action.Method != null)
                        if (eventType == ToastEventType.Clicked)
                            action.Method(action.Data);

                    return (true);
                }
            }

            return (false);
        }

        #endregion Private Methods
    }
}
