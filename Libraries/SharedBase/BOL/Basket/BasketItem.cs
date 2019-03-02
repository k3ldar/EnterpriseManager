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
 *  File: BasketItem.cs
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

using Library;
using SharedBase.BOL.Products;

namespace SharedBase.BOL.Basket
{
    [Serializable]
    public sealed class BasketItem : BaseObject
    {
        #region Private / Protected Members

        private ShoppingBasket _basket;
        private int _itemID;
        private string _description;
        private decimal _quantity;
        private decimal _price;
        private string _Image;
        private bool _outOfStock;
        private ProductCostItemType _itemType;
        private Int64 _userID;
        private ProductCostType _productCostType;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public BasketItem(ShoppingBasket basket, Int64 id, int ItemID, string Description, decimal Quantity, 
            decimal Price, string Image, bool OutOfStock, ProductCostItemType ItemType, 
            int userID, ProductCostType ProductType, int priceColumn, decimal productDiscount,
            decimal userDiscount)
        {
            ID = id;
            _basket = basket;
            _itemID = ItemID;
            _description = Description;
            _quantity = Quantity;
            _price = Price;
            _Image = Image;
            _outOfStock = OutOfStock;
            _itemType = ItemType;
            _userID = userID;
            _productCostType = ProductType;
            PriceColumn = priceColumn;
            ProductDiscount = productDiscount;
            UserDiscount = userDiscount;
        }

        #endregion Constructors / Destructors

        #region Properties

        /// <summary>
        /// Unique id for item
        /// </summary>
        public Int64 ID { get; private set; }

        public int ItemID
        {
            get
            {
                return (_itemID);
            }
        }

        public string Description
        {
            get
            {
                return (_description);
            }

            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _description = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return (_quantity);
            }

            set
            {
                _quantity = value;
            }
        }

        public decimal PriceWithDiscount
        {
            get
            {
                decimal Result = _price;

                if (ProductDiscount > 0.00m)
                {
                    Result = Result - ((Result / 100) * ProductDiscount);
                }

                // if the product is excluded from the discount, move on...
                if (this.ItemType == ProductCostItemType.Product && 
                    _basket.CouponUsed != null &&
                    _basket.CouponUsed.ExcludedProducts.Count > 0)
                {
                    foreach (ProductCost cost in _basket.CouponUsed.ExcludedProducts)
                    {
                        if (cost.ID == this.ItemID)
                            return (Result);
                    }
                }

                if (_basket.UseSageDiscountLogic)
                {
                    if ((_basket.DiscountType == BasketDiscountType.Percentage && _basket.Discount > 0) ||
                        (_basket.DiscountType == BasketDiscountType.Coupon && 
                        _basket.VoucherType == Enums.InvoiceVoucherType.Percent &&  
                        _basket.Discount > 0))
                    {
                        Result = Result - ((Result / 100) * _basket.Discount);
                    }

                    if (UserDiscount > 0.00m)
                    {
                        Result = Result - ((Result / 100) * UserDiscount);
                    }
                }
                else
                {
                    decimal discountVal = UserDiscount;

                    if ((_basket.DiscountType == BasketDiscountType.Percentage && _basket.Discount > 0) ||
                        (_basket.DiscountType == BasketDiscountType.Coupon &&
                        _basket.VoucherType == Enums.InvoiceVoucherType.Percent &&
                        _basket.Discount > 0))
                    {
                        discountVal += _basket.Discount;
                    }

                    if (discountVal > 0.00m)
                    {
                        Result = Result - ((Result / 100) * (discountVal));
                    }
                }

                return (Result);
            }
        }

        public decimal Price
        {
            get
            {
                return (_price);
            }

            set
            {
                _price = value;
            }
        }

        public string Image
        {
            get
            {
                return (_Image);
            }
        }

        public bool OutOfStock
        {
            get
            {
                return (_outOfStock);
            }
        }

        public ProductCostItemType ItemType
        {
            get
            {
                return (_itemType);
            }
        }

        public Int64 UserID
        {
            get
            {
                return (_userID);
            }

            set
            {
                _userID = value;
            }
        }

        public ProductCostType ProductType
        {
            get
            {
                return (_productCostType);
            }
        }


        public Product Product
        {
            get
            {
                return (BOL.Products.ProductCosts.Get(_itemID).Product);
            }
        }

        public int PriceColumn { get; set; }

        /// <summary>
        /// Discount applied to the product at source
        /// </summary>
        public decimal ProductDiscount { get; set; }

        /// <summary>
        /// Discount given to user when creating order on this product
        /// </summary>
        public decimal UserDiscount { get; set; }


        public decimal UserDiscountValue 
        { 
            get
            {
                decimal Result = 0.00m;

                //if (UserDiscount > 0.00)
                //{
                //    //remove product discount
                //    double price = _Price - ((_Price / 100) * (ProductDiscount));

                //    // get value of user discount
                //    Result = (price / 100) * (UserDiscount);
                //}

                return (Result);
            }
        }

        #endregion Properties

        #region Public Methods

        public void Save(ShoppingBasket basket)
        {
            DAL.FirebirdDB.BasketItemSave(basket, this);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("BasketItem: {0}; Description: {1}; Quantity: {2}; Price: {3}; ItemType: {4}", 
                _itemID, _description, _quantity, _price, _itemType.ToString()));
        }

        #endregion Overridden Methods

    }
}
