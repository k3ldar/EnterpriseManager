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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: EventHandlerWrappers.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using POS.Base.Classes;
using SharedBase.BOL.Users;
using Shared;

namespace POS.Base.Plugins
{
    public class NotificationEventArgs : EventArgs
    {
        #region Constructors

        public NotificationEventArgs(string eventName)
        {
            AllowContinue = true;
            EventName = eventName;
        }

        /// <summary>
        /// Standard Constructor
        /// </summary>
        /// <param name="name">Notification Name</param>
        /// <param name="value">Primary Value</param>
        /// <param name="values">Additional Parameters</param>
        public NotificationEventArgs (string eventName, object value, params object[] values)
            : this (eventName)
        {
            EventValue = value;

            for (int i = 1; i <= values.Length; i++)
            {
                PropertyInfo pInfo = this.GetType().GetProperty(String.Format("Param{0}", i));
                pInfo.SetValue(this, values[i -1], null);

                if (i == 10)
                    break;
            }
        }

        /// <summary>
        /// Notification args for editing a user
        /// </summary>
        /// <param name="user">User to be edited</param>
        /// <param name="showNotes">bool, is it to show the notes page initially</param>
        /// <param name="isModal">bool, is the dialog box being shown modally or not</param>
        /// <param name="newTitle">New title to be used for form</param>
        public NotificationEventArgs(User user, bool showNotes = false, bool isModal = false, 
            string newTitle = StringConstants.SYMBOL_EMPTY_STRING)
            : this (StringConstants.PLUGIN_EVENT_EDIT_CUSTOMER)
        {
            EventValue = user;
            Param1 = showNotes;
            Param2 = newTitle;
            Param3 = isModal;
        }

        /// <summary>
        /// Toast Notification
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public NotificationEventArgs(ToastEventType eventType, string title, string message, string uniqueID)
            : this (StringConstants.PLUGIN_EVENT_TOAST_NOTIFICATION)
        {
            EventValue = eventType;
            Param1 = title;
            Param2 = message;
            Param3 = uniqueID;
        }

        public NotificationEventArgs(ToastEventType eventType, string uniqueID)
            :this(eventType, String.Empty, String.Empty, uniqueID)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Name of the event
        /// </summary>
        public string EventName { get; private set; }

        /// <summary>
        /// Value for Event
        /// </summary>
        public object EventValue { get; private set; }

        /// <summary>
        /// User defined result
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Determines wether the event is passed to other plugins or not
        /// 
        /// If a plugin does not want this event to be passed to other plugins, after it has been processed, then it
        /// should set AllowContinue to false
        /// </summary>
        public bool AllowContinue { get; set; }

        /// <summary>
        /// Parameter Value 1
        /// 
        /// Read Only
        /// </summary>
        public object Param1 { get; private set; }

        /// <summary>
        /// Parameter Value 2
        /// 
        /// Read Only
        /// </summary>
        public object Param2 { get; private set; }

        /// <summary>
        /// Parameter Value 3
        /// 
        /// Read Only
        /// </summary>
        public object Param3 { get; private set; }

        /// <summary>
        /// Parameter Value 8
        /// 
        /// Read/Write
        /// </summary>
        public object Param4 { get; set; }

        /// <summary>
        /// Parameter Value 9
        /// 
        /// Read/Write
        /// </summary>
        public object Param5 { get; set; }

        #endregion Properties
    }

    public delegate void EventHandlerPluginEvent(object sender, NotificationEventArgs e);


    public class PluginUsageEventArgs : EventArgs
    {
        #region Constructors

        public PluginUsageEventArgs(string name)
        {
            Name = name;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Name of item being used
        /// </summary>
        public string Name { get; private set; }

        #endregion Properties
    }

    public delegate void EventHandlerPluginUsage(object sender, PluginUsageEventArgs e);
}
