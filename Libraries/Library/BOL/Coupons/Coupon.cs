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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Coupon.cs
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

using Library.BOL.Products;

namespace Library.BOL.Coupons
{
    [Serializable]
    public sealed class Coupon : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private string _Name;
        private DateTime _Expires;
        private bool _IsActive;
        private int _Discount;
        private ProductCost _FreeProduct;
        private ProductCost _MainProduct;
        private Enums.InvoiceVoucherType _VoucherType;
        private int _VoucherUsage;
        private bool _freePostage;
        private int _maxUsage;
        private decimal _minSpend;
        private ProductCosts _requiredProducts;
        private ProductCosts _excludedProducts;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public Coupon(int ID, string Name, DateTime Expires, bool IsActive, int Discount, 
            ProductCost FreeProduct, ProductCost MainProduct, Enums.InvoiceVoucherType VoucherType,
            int VoucherUsage, bool freePostage, int maxUsage, decimal minSpend, Int64 userID, 
            DateTime startDateTime, bool restrictUserUsage)
        {
            _ID = ID;
            _Name = Name;
            _Expires = Expires;
            _IsActive = IsActive;
            _Discount = Discount;
            _FreeProduct = FreeProduct;
            _MainProduct = MainProduct;
            _VoucherType = VoucherType;
            _VoucherUsage = VoucherUsage;
            _freePostage = freePostage;
            _maxUsage = maxUsage;
            _minSpend = minSpend;
            UserID = userID;
            StartDateTime = startDateTime;
            RestrictUserUsage = restrictUserUsage;
        }

        /// <summary>
        /// Constructor used when creating new Coupon
        /// </summary>
        /// <param name="Name"></param>
        public Coupon(string Name)
        {
            _Name = Name;
            _maxUsage = 5000;
        }

        #endregion Constructors / Destructors

        #region Properties

        /// <summary>
        /// ID Of coupon
        /// </summary>
        public int ID
        {
            get
            {
                return (_ID);
            }

            set
            {
                _ID = value;
            }
        }

        /// <summary>
        /// Indicates wether free postage applies to this offer
        /// </summary>
        public bool FreePostage
        {
            get
            {
                return (_freePostage);
            }

            set
            {
                _freePostage = value;
            }
        }

        public string Name
        {
            get
            {
                return (_Name);
            }

            set
            {
                _Name = value;
            }
        }

        public DateTime Expires
        {
            get
            {
                return (_Expires);
            }

            set
            {
                _Expires = value;
            }
        }

        /// <summary>
        /// Date/Time coupon is valid from
        /// </summary>
        public DateTime StartDateTime { get; set; }

        public bool IsActive
        {
            get
            {
                return (_IsActive);
            }

            set
            {
                _IsActive = value;
            }
        }

        public int Discount
        {
            get
            {
                return (_Discount);
            }

            set
            {
                _Discount = value;

                if (VoucherType == Enums.InvoiceVoucherType.Footprint)
                    _Discount = 0;
            }
        }

        public ProductCost FreeProduct
        {
            get
            {
                return (_FreeProduct);
            }

            set
            {
                _FreeProduct = value;
            }
        }

        /// <summary>
        /// Type of Voucher
        /// </summary>
        public Enums.InvoiceVoucherType VoucherType
        {
            get
            {
                return (_VoucherType);
            }

            set
            {
                _VoucherType = value;

                if (value == Enums.InvoiceVoucherType.Footprint)
                    _Discount = 0;
            }
        }

        /// <summary>
        /// Indicates the number of times a voucher has been used
        /// </summary>
        public int VoucherUsage
        {
            get
            {
                return (_VoucherUsage);
            }
        }

        /// <summary>
        /// Indicates the maximum number of times a voucher can be used
        /// </summary>
        public int MaxUsage
        {
            get
            {
                return (_maxUsage);
            }

            set
            {
                _maxUsage = value;
            }
        }

        /// <summary>
        /// Minimum spend for voucher to apply
        /// </summary>
        public decimal MinimumSpend
        {
            get
            {
                return (_minSpend);
            }

            set
            {
                _minSpend = value;
            }
        }

        /// <summary>
        /// The userID associated with the code
        /// </summary>
        public Int64 UserID
        {
            private set;
            get;
        }

        /// <summary>
        /// Products required in order to activate this coupon
        /// </summary>
        public ProductCosts RequiredProducts
        {
            get
            {
                if (_requiredProducts == null)
                    _requiredProducts = DAL.FirebirdDB.AdminCouponGetRequiredProducts(this);

                return (_requiredProducts);
            }
        }

        /// <summary>
        /// List of products specifically excluded from this coupon
        /// </summary>
        public ProductCosts ExcludedProducts
        {
            get
            {
                if (_excludedProducts == null)
                    _excludedProducts = DAL.FirebirdDB.AdminCouponGetExcludedProducts(this);

                return (_excludedProducts);
            }
        }

        /// <summary>
        /// If true, the user can only use a specific voucher once, after this it will not be allowed
        /// </summary>
        public bool RestrictUserUsage
        {
            get;
            set;
        }

        #endregion Properties

        #region Public Methods

        public override void Save()
        {
            DAL.FirebirdDB.AdminCouponUpdate(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.AdminCouponDelete(this);
        }

        public bool Valid()
        {
            return (_IsActive && DateTime.Now < _Expires && DateTime.Now > StartDateTime && VoucherUsage < MaxUsage);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Coupon: {0}; Name: {1}; Active: {2}; Expires: {3}; Discount: {4}", 
                ID, _Name, _IsActive, _Expires.ToShortDateString(), _Discount));
        }

        #endregion Overridden Methods

    }
}
