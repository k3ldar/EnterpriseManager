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
 *  File: Coupons.cs
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
using System.Text;

using Library.BOL.Products;
using Library.BOL.Users;

namespace Library.BOL.Coupons
{
    [Serializable]
    public sealed class Coupons : BaseCollection
    {
        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public Coupon this[int Index]
        {
            get
            {
                return ((Coupon)this.InnerList[Index]);
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
        public int Add(Coupon value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Coupon value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Coupon value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Coupon value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Coupon value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Coupons.Coupon";
        private const string OBJECT_TYPE_ERROR = "Must be of type Coupon";


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

        #region Static Methods

        /// <summary>
        /// Returns all Coupons
        /// </summary>
        /// <returns>Coupons Collection</returns>
        public static Coupons Get(bool IncludeUsers)
        {
            if (IncludeUsers)
                return (DAL.FirebirdDB.AdminCouponsGet(1, 1000));
            else
                return (DAL.FirebirdDB.AdminCouponsGet());
        }

        public static Coupon ValidateCoupon(string CouponCode)
        {
            return (DAL.FirebirdDB.BasketValidateCouponCode(CouponCode));
        }

        public static Coupon Get(string CouponCode)
        {
            if (String.IsNullOrEmpty(CouponCode))
                return (null);
            else
                return (DAL.FirebirdDB.AdminCouponGet(CouponCode));
        }

        public static Coupon CreateCoupon(string voucherCode, DateTime expires)
        {
            Coupon Result = new Coupon(voucherCode);

            DAL.FirebirdDB.AdminCouponCreate(voucherCode);
            Result = Get(voucherCode);
            Result.FreePostage = true;
            Result.Expires = expires;
            Result.IsActive = true;
            Result.VoucherType = Enums.InvoiceVoucherType.SpecialOffer;
            Result.Save();

            return (Result);
        }

        public static ProductCost FreeProduct(string CouponCode)
        {
            ProductCost Result = null;
            Coupons coupons = Get(false);

            foreach (Coupon coupon in coupons)
            {
                if (coupon.Name.ToLower() == CouponCode.ToLower() && coupon.IsActive && coupon.FreeProduct != null)
                {
                    Result = coupon.FreeProduct;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Generates a coupon for a specific user
        /// </summary>
        /// <param name="value">Value of the coupon (i.e. 10 = £10)</param>
        /// <param name="user">User who is to receive the coupon</param>
        /// <param name="expires">DateTime the coupon expires</param>
        /// <returns></returns>
        public static string GenerateCoupon(int value, User user, DateTime starts, DateTime expires)
        {
            if (value < 0.01)
                throw new Exception("Voucher has invalid value");

            string Result = String.Empty;

            int attempts = 0;

            while (true)
            {
                // only 500 attempts (should be enough)
                if (attempts > 500)
                    throw new Exception("Failed to generate unique coupon code.");

                try
                {
                    Result = Library.Utils.LibUtils.GetRandomDiscountCoupon();
                    DAL.FirebirdDB.AdminCouponCreate(Result, value, user, expires, starts);
                    break;
                }
                catch (Exception err)
                {
                    if (err.Message.Contains("violation of PRIMARY or UNIQUE KEY constraint"))
                    {
                        attempts++;
                    }
                    else
                        throw;
                }
            }

            return (Result);
        }

        #endregion Static Methods
    }
}
