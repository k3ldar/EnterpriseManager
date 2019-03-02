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
 *  File: Clients.cs
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
using System.Collections;

using Shared.Classes;

namespace SharedBase.BOL.Trade
{
    [Serializable]
    public sealed class Clients : BaseCollection
    {
        #region Private Static Members


        #endregion Private Static Members

        #region Public Static Methods

        /// <summary>
        /// Get a list of all trade managers
        /// </summary>
        /// <returns></returns>
        public static Users.Users TradeClientManagers()
        {
            return (DAL.FirebirdDB.TradeClientManagersGet());
        }

        public static void AutoLinkAccounts()
        {
            DAL.FirebirdDB.TradeClientsAutoLinkAccounts();
        }

        public static Client New(string Name, string CompanyName, string Telephone, string Email, string Address, string Postcode, string Notes)
        {
            Hooks.Hooks.HookNotification(HookEvent.TradeClientCreated,
                String.Format("Name: {0}", Name));

            return (DAL.FirebirdDB.TradeClientCreate(Name, CompanyName, Telephone, Email, Address, Postcode, Notes));
        }

        public static Clients Get(Users.User manager)
        {
            string cacheName = String.Format("CachedClients {0}", manager.UserName);
            CacheItem cachedItem = CachedItemGet(cacheName);

            if (cachedItem == null)
            {
                cachedItem = new CacheItem(cacheName, manager.GetTradeClients());
                CachedItemAdd(cacheName, cachedItem);
            }

            return ((Clients)cachedItem.Value);
        }

        public static Clients Get(Enums.ClientState State)
        {
            CacheItem cachedItem = CachedItemGet(State.ToString());

            if (cachedItem == null)
            {
                cachedItem = new CacheItem(State.ToString(), DAL.FirebirdDB.TradeClientsGet(State));
                CachedItemAdd(State.ToString(), cachedItem);
            }

            return ((Clients)cachedItem.Value);
        }

        public static Client Get(Int64 ID)
        {
            string cacheName = String.Format("CachedClient {0}", ID);
            CacheItem cachedItem = CachedItemGet(cacheName);

            if (cachedItem == null)
            {
                cachedItem = new CacheItem(cacheName, DAL.FirebirdDB.TradeClientGet(ID));
                CachedItemAdd(cacheName, cachedItem);
            }

            return ((Client)cachedItem.Value);
        }

        #endregion Public Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public Client this[int Index]
        {
            get
            {
                return ((Client)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(Client value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Client value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Client value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Client value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Client value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Trade.Client";
        private const string OBJECT_TYPE_ERROR = "Must be of type Client";


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
