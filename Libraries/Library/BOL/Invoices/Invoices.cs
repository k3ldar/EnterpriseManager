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
 *  File: Invoices.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

using Library.BOL.Users;
using Library.BOL.Coupons;
using Library.BOL.Accounts;
using Library.BOL.Statistics;

namespace Library.BOL.Invoices
{
    [Serializable]
    public sealed class Invoices : BaseCollection
    {
        #region Static Methods

        public static int GetCount(User user)
        {
            return (DAL.FirebirdDB.InvoiceGetCount(user));
        }

        public static Invoice Get(Int64 InvoiceID)
        {
            return (DAL.FirebirdDB.InvoiceGet(InvoiceID));
        }

        /// <summary>
        /// Retrieves all invoices for a specific user
        /// </summary>
        /// <returns></returns>
        public static Invoices Get(User user)
        {
            return (DAL.FirebirdDB.InvoicesGet(user));
        }

        public static void InvoiceUpdateProcessStatus(ProcessStatus ProcessStatus, Invoice invoice)
        {
            DAL.FirebirdDB.InvoiceUpdateProcessStatus(ProcessStatus, invoice);
        }

        public static void InvoiceUpdatePaymentStatus(PaymentStatus PaymentStatus, Invoice invoice)
        {
            DAL.FirebirdDB.InvoiceUpdatePaymentStatus(PaymentStatus, invoice);
        }

        public static InvoiceItems Get(Invoice invoice)
        {
            return (DAL.FirebirdDB.InvoiceItemsGet(invoice));
        }

        public static Invoice Get(Orders.Order order)
        {
            return (DAL.FirebirdDB.InvoiceGet(order));
        }

        #region Administration

        public static int InvoicesCount(User user, int UserID, int InvoiceID, bool TodayOnly, ProcessStatuses statuses)
        {
            return (DAL.FirebirdDB.AdminInvoicesGetCount(UserID, InvoiceID, TodayOnly, statuses));
        }

        public static SimpleStatistics InvoicesGetStats(User user, int UserID, int InvoiceID, bool TodayOnly, ProcessStatuses statuses)
        {
            return (DAL.FirebirdDB.AdminInvoicesGetStats(UserID, InvoiceID, TodayOnly, statuses));
        }

        public static Invoices InvoicesGet(User user, int PageNumber, int PageSize, int UserID, int InvoiceID, bool TodayOnly,
            ProcessStatuses statuses)
        {
            return (DAL.FirebirdDB.AdminInvoicesGet(PageNumber, PageSize, UserID, InvoiceID, TodayOnly, statuses));
        }

        public static Invoices InvoicesGet(User user, ProcessStatuses statuses, bool SortAscending, bool showCancelled)
        {
            return (DAL.FirebirdDB.AdminInvoicesGet(statuses, SortAscending, showCancelled));
        }

        public static Invoices InvoicesGetAll(User user, ProcessStatuses statuses)
        {
            return (DAL.FirebirdDB.AdminInvoicesGetAll(statuses));
        }

        public static Invoices InvoicesGet(User user, ProcessStatuses processStatuses, PaymentStatus PaymentStatus)
        {
            return (DAL.FirebirdDB.AdminInvoicesGet(processStatuses, PaymentStatus));
        }

        public static Invoices InvoicesGet(User user, DateTime DateFrom, DateTime DateTo, ProcessStatuses processStatuses, 
            int PaymentType, Coupon coupon, bool showCancelled)
        {
            return (DAL.FirebirdDB.AdminInvoicesGet(DateFrom, DateTo, processStatuses, PaymentType, coupon, showCancelled));
        }

        #endregion Administration


        #endregion Static Methods

        #region Public Methods

        public bool VoucherUsed(string voucherCode)
        {
            voucherCode = voucherCode.ToLower();

            foreach (Invoice inv in this)
            {
                if (inv.CouponName.ToLower() == voucherCode)
                    return (true);
            }

            return (false);
        }

        public Invoice First()
        {
            Invoice Result = null;

            foreach (Invoice invoice in this)
            {
                Result = invoice;
                break;
            }

            return (Result);
        }

        public Invoice Next(Invoice Current)
        {
            bool Next = false;

            Invoice Result = null;

            foreach (Invoice invoice in this)
            {
                if (invoice.ID == Current.ID)
                    Next = true;
                else
                    if (Next)
                    {
                        Result = invoice;
                        break;
                    }
            }

            return (Result);
        }

        public decimal Total()
        {
            decimal Result = 0.00m;

            foreach (Invoice invoice in this)
            {
                Result += invoice.TotalCost;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public Invoice this[int Index]
        {
            get
            {
                return ((Invoice)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Finds an orde by Order number
        /// </summary>
        /// <param name="InvoiceID">int InvoiceID of invoice to find</param>
        /// <returns>Order object if found otherwise null</returns>
        public Invoice Find(int InvoiceID)
        {
            Invoice Result = null;

            foreach (Invoice invoice in this)
            {
                if (invoice.ID == InvoiceID)
                {
                    Result = invoice;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(Invoice value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Invoice value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Invoice value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Invoice value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Invoice value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Invoices.Invoice";
        private const string OBJECT_TYPE_ERROR = "Must be of type Invoice";


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