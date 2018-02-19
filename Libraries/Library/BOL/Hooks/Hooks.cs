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
 *  File: Hooks.cs
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

using Library.BOL.Mail;
using Library.BOL.Users;

using Shared.Classes;

namespace Library.BOL.Hooks
{
    public sealed class Hooks : BaseCollection
    {
        #region StaticMethods

        public static void HookNotification(HookEvent hookEvent, string additionalData)
        {
            string cacheName = String.Format("Hook Users {0}", hookEvent.ToString());

            CacheItem item = CachedItemGet(cacheName);
            Users.Users userNotifications = null;

            if (item == null)
            {
                userNotifications = Users.Users.Get(hookEvent);

                if (userNotifications == null)
                    return;

                item = new CacheItem(cacheName, userNotifications);
                CachedItemAdd(cacheName, item);
            }
            else
            {
                userNotifications = (Users.Users)item.Value;
            }

            if (userNotifications.Count > 0)
            {
                DAL.FirebirdDB.EmailAdd(userNotifications, "system", "system",
                    String.Format("System Notification {0}",
                    Shared.Utilities.SplitCamelCase(hookEvent.ToString())),
                    additionalData.Replace("\r", "<br />").Replace("\n", "<br />"));
            }
        }

        public static Hooks Get(User user)
        {
            return (DAL.FirebirdDB.HooksGet(user));
        }

        public static void Add(HookEvent eventName, User user)
        {
            DAL.FirebirdDB.HookAdd(eventName, user);
        }

        public static void Remove(HookEvent eventName, User user)
        {
            DAL.FirebirdDB.HookRemove(eventName, user);
        }

        #endregion StaticMethods

        #region Generic CollectionBase Code

        #region Properties

        public Hook this[int Index]
        {
            get
            {
                return ((Hook)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Discovers wether the list contains the specified hook
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public bool Exists(HookEvent eventName)
        {
            foreach (Hook hook in this)
            {
                if (hook.EventName == eventName)
                    return (true);
            }

            return (false);
        }

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(Hook value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Hook value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Hook value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Hook value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Hook value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Hooks.Hook";
        private const string OBJECT_TYPE_ERROR = "Must be of type Hook";


        #endregion Private Members

        #region Overridden Methods

        /// <summary>
        /// When Inserting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnInsert(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When removing an item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnRemove(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When Setting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            if (newValue.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "newValue");
        }


        /// <summary>
        /// Validates an object
        /// </summary>
        /// <param name="value"></param>
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR);
        }


        #endregion Overridden Methods

        #endregion Generic CollectionBase Code
    }
}
