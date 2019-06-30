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
 *  File: PaymentStatuses.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Reflection;
using System.Web;
#if NET461
using System.Web.SessionState;
#endif
using SharedBase.BOL.Orders;
using Shared.Classes;

namespace SharedBase.BOL.Accounts
{
    [Serializable]
    public sealed class PaymentStatuses : BaseCollection
    {
        #region Private Members

        #endregion Private Members

        #region Static Methods

#if NET461
        public static void ExecutePaymentMethod(Order order, PaymentStatus paymentStatus,
            HttpSessionState webSession, HttpRequest webRequest, HttpResponse webResponse,
            UserSession session)
        {
            Assembly ass = null;
            Type trp = null;

            try
            {
                ass = Assembly.LoadFrom(DAL.DALHelper.Path + "\\Website.Library.dll");
                try
                {
                    trp = ass.GetType(paymentStatus.ProviderNamespace);
                    try
                    {
                        object paymentStatusObject = Activator.CreateInstance(trp);
                        MethodInfo methodExecute = trp.GetMethod("Execute");
                        try
                        {
                            methodExecute.Invoke(paymentStatusObject, new object[] { order, paymentStatus, webSession, 
                                webRequest, webResponse, session });
                        }
                        finally
                        {
                            methodExecute = null;
                        }
                    }
                    finally
                    {
                        trp = null;
                    }
                }
                finally
                {
                    ass = null;
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains("Thread was being aborted"))
                {
                    ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, order, paymentStatus, webSession,
                        webRequest, webResponse, ass, trp, paymentStatus.ProviderNamespace);
                    throw;
                }
            }
        }
#endif
        /// <summary>
        /// Retrieves all Statuses
        /// </summary>
        /// <returns>
        /// PaymentStatuses collection</returns>
        public static PaymentStatuses Get()
        {
            CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(Consts.CACHE_NAME_PAYMENT_STATUS);

            if (DAL.DALHelper.AllowCaching && cachedResult == null)
            {
                cachedResult = new CacheItem(Consts.CACHE_NAME_PAYMENT_STATUS, DAL.FirebirdDB.PaymentStatusesGet());
                DAL.DALHelper.InternalCache.Add(Consts.CACHE_NAME_PAYMENT_STATUS, cachedResult);
            }


            if (cachedResult != null)
                return (PaymentStatuses)cachedResult.Value;
            else
                return DAL.FirebirdDB.PaymentStatusesGet();
        }

        /// <summary>
        /// Returns a status based on it's description
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PaymentStatus Get(string name)
        {
            foreach (PaymentStatus status in Get())
            {
                if (status.Description.ToLower() == name.ToLower())
                {
                    return status;
                }
            }

            // default to unknown
            return Get(999);
        }

        /// <summary>
        /// Returns a status based on it's description
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PaymentStatus Get(int id)
        {
            foreach (PaymentStatus status in Get())
            {
                if (status.ID == id)
                {
                    return status;
                }
            }

            // default to 999 - Unknown
            foreach (PaymentStatus status in Get())
            {
                if (status.ID == 999)
                {
                    return status;
                }
            }

            return null;
        }


        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public PaymentStatus this[int Index]
        {
            get
            {
                return (PaymentStatus)this.InnerList[Index];
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
        public int Add(PaymentStatus value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(PaymentStatus value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, PaymentStatus value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(PaymentStatus value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(PaymentStatus value)
        {
            foreach (PaymentStatus status in this)
            {
                if (status.ID == value.ID)
                    return true;
            }

            // If value is not of type OBJECT_TYPE, this will return false.
            return false;
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Accounts.PaymentStatus";
        private const string OBJECT_TYPE_ERROR = "Must be of type PaymentStatus";


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
