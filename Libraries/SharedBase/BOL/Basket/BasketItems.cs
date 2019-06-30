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
 *  File: BasketItems.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using SharedBase.BOL.Appointments;
using SharedBase.BOL.Products;

namespace SharedBase.BOL.Basket
{
    [Serializable]
    public sealed class BasketItems : BaseCollection
    {
        #region Private Members

        private ShoppingBasket _basket;

        #endregion Private Members

        #region Constructors

        public BasketItems(ShoppingBasket basket)
        {
            _basket = basket;
        }

        #endregion Constructors

        #region Public Methods

        public BasketItem Get(Int64 id)
        {
            foreach (BasketItem item in this)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public BasketItem Get(ProductCost Item)
        {
            foreach (BasketItem item in this)
            {
                if (item.ItemID == Item.ID && 
                    item.ItemType != ProductCostItemType.FreeProduct &&
                    item.ItemType != ProductCostItemType.Treatment &&
                    item.Description == String.Format("{0} ({1})", Item.Product.Name, Item.Size))
                {
                   return item;
                }
            }

            return null;
        }

        public BasketItem Get(AppointmentTreatment Item)
        {
            foreach (BasketItem item in this)
            {
                if (item.ItemID == Item.ID && item.ItemType == ProductCostItemType.Treatment)
                {
                    return item;
                }
            }

            return null;
        }
        
        /// <summary>
        /// Gets the discount value for the basket
        /// </summary>
        /// <returns></returns>
        public decimal DiscountValue()
        {
            decimal Result = 0.00m;

            foreach (BasketItem item in this)
            {
                if (item.ItemType != ProductCostItemType.FreeProduct)
                    Result += item.UserDiscountValue;
            }

            return Result;
        }

        /// <summary>
        /// Returns the actual discount amounts for product, basket and adhoc user discount
        /// values, for display only
        /// </summary>
        /// <param name="basketDiscount"></param>
        /// <param name="userDiscount"></param>
        /// <param name="productDiscount"></param>
        public void GetDiscountValue()
        {
            _basket.BasketDiscountValue = 0.00m;
            _basket.UserDiscountValue = 0.00m;
            _basket.ProductDiscountValue = 0.00m;

            if ((_basket.DiscountType == BasketDiscountType.Value && _basket.Discount > 0) ||
                (_basket.DiscountType == BasketDiscountType.Coupon &&
                _basket.VoucherType == Enums.InvoiceVoucherType.Value &&
                _basket.Discount > 0))
            {
                _basket.BasketDiscountValue = _basket.Discount;
            }

            foreach (BasketItem item in this)
            {
                if (item.ItemType != ProductCostItemType.FreeProduct)
                {
                    //remove product discount
                    decimal price = item.Price * item.Quantity;
                    bool doNotContinue = false;

                    if (item.ProductDiscount > 0.00m)
                    {
                        decimal prodDisc = price - (price / 100 * item.ProductDiscount);
                        _basket.ProductDiscountValue += price - prodDisc;
                        price = price - (price / 100 * item.ProductDiscount);
                    }

                    // if the product is excluded from the discount, move on...
                    if (item.ItemType == ProductCostItemType.Product &&
                        _basket.CouponUsed != null &&
                        _basket.CouponUsed.ExcludedProducts.Count > 0)
                    {
                        foreach (SharedBase.BOL.Products.ProductCost cost in _basket.CouponUsed.ExcludedProducts)
                        {
                            if (cost.ID == item.ItemID)
                            {
                                doNotContinue = true;
                                break;
                            }
                        }
                    }

                    if (doNotContinue)
                        continue;

                    if (_basket.UseSageDiscountLogic)
                    {
                        decimal sagePrice = price;

                        if ((_basket.DiscountType == BasketDiscountType.Percentage && _basket.Discount > 0) ||
                            (_basket.DiscountType == BasketDiscountType.Coupon &&
                            _basket.VoucherType == Enums.InvoiceVoucherType.Percent &&
                            _basket.Discount > 0))
                        {
                            sagePrice = sagePrice - (sagePrice / 100 * _basket.Discount);
                            _basket.BasketDiscountValue += price - sagePrice;
                        }

                        if (item.UserDiscount > 0.00m)
                        {
                            _basket.UserDiscountValue += sagePrice / 100 * item.UserDiscount;
                            sagePrice = sagePrice - (sagePrice / 100 * item.UserDiscount);
                        }

                        price = sagePrice;
                    }
                    else
                    {
                        decimal discountVal = item.UserDiscount;

                        if (discountVal > 0)
                        {
                            _basket.UserDiscountValue += price / 100 * discountVal;
                        }

                        if ((_basket.DiscountType == BasketDiscountType.Percentage && _basket.Discount > 0) ||
                            (_basket.DiscountType == BasketDiscountType.Coupon &&
                            _basket.VoucherType == Enums.InvoiceVoucherType.Percent &&
                            _basket.Discount > 0))
                        {
                            _basket.BasketDiscountValue += price / 100 * _basket.Discount;
                            discountVal += _basket.Discount;
                        }

                        if (discountVal > 0.00m)
                        {
                            price = price - (price / 100 * discountVal);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the subtotal of the basket
        /// </summary>
        /// <returns></returns>
        public decimal SubTotal()
        {
            decimal Result = 0.00m;

            foreach(BasketItem item in this)
            {
                if (item.ItemType != ProductCostItemType.FreeProduct)
                    Result += item.PriceWithDiscount * item.Quantity;
            }

            return Result;
        }


        public decimal SubTotalVAT(double vatRate)
        {
            decimal Result = 0.00m;

            foreach (BasketItem item in this)
            {
                if (item.ItemType != ProductCostItemType.FreeProduct)
                {
                    if (_basket.UseSageDiscountLogic)
                    {
                        Result += Utils.SharedUtils.VATCalculate(item.PriceWithDiscount * item.Quantity, vatRate);
                    }
                    else
                    {
                        Result += Utils.SharedUtils.BankersRounding(Utils.SharedUtils.VATCalculate(item.PriceWithDiscount * item.Quantity, vatRate), 2);
                    }
                }
            }

            if (_basket.UseSageDiscountLogic)
            {
                return Math.Round(Result, 2, MidpointRounding.AwayFromZero);
            }

            return Utils.SharedUtils.BankersRounding(Result, 2);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>BasketItem object</returns>
        public BasketItem this[int Index]
        {
            get
            {
                return (BasketItem)this.InnerList[Index];
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
        public int Add(BasketItem value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(BasketItem value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, BasketItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(BasketItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(BasketItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return List.Contains(value);
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Basket.BasketItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type BasketItem";


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


        #endregion Static Methods
    }
}
