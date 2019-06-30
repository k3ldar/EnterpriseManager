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
 *  File: OrderItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using SharedBase.BOL.Products;
using SharedBase.Utils;

namespace SharedBase.BOL.Orders
{
    [Serializable]
    public sealed class OrderItem
    {
        #region Private / Protected Members

        private int _id;
        private Order _order;
        private string _description;
        private decimal _cost;
        private decimal _quantity;
        private decimal _price;
        private int _itemID;
        private ProductCostType _productCostType;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public OrderItem(int ID, Order order, string Description, decimal Cost, decimal Quantity,
            decimal Price, int ItemID, ProductCostType ProductCostType,
            decimal userDiscount, decimal productDiscount, ProcessItemStatus itemStatus)
        {
            _id = ID;
            _order = order;
            _description = Description;
            _cost = Cost;
            _quantity = Quantity;
            _price = Price;
            _itemID = ItemID;
            _productCostType = ProductCostType;
            UserDiscount = userDiscount;
            ProductDiscount = productDiscount;
            ItemStatus = itemStatus;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public string CostStr
        {
            get
            {
                return SharedUtils.FormatMoney(Cost, Order.Currency);
            }
        }

        public string PriceStr
        {
            get
            {
                return SharedUtils.FormatMoney(Price, Order.Currency);
            }
        }


        public Order Order
        {
            get
            {
                return _order;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public decimal Cost
        {
            get
            {
                decimal Result = _cost;

                if (ProductDiscount > 0.00m)
                {
                    Result = Result - (Result / 100 * ProductDiscount);
                }

                if (UserDiscount > 0.00m)
                {
                    Result = Result - (Result / 100 * UserDiscount);
                }

                return Result;
            }
        }

        public decimal Quantity
        {
            get
            {
                return _quantity;
            }
        }

        public decimal Price
        {
            get
            {
                decimal Result = _price;

                if (ProductDiscount > 0.00m)
                {
                    Result = Result - (Result / 100 * ProductDiscount);
                }

                if (UserDiscount > 0.00m)
                {
                    Result = Result - (Result / 100 * UserDiscount);
                }

                return Result;
            }
        }

        public int ItemID
        {
            get
            {
                return _itemID;
            }
        }

        public ProductCostType ProductCostType
        {
            get
            {
                return _productCostType;
            }
        }

        /// <summary>
        /// Product Discount given to product at time of sale
        /// </summary>
        public decimal ProductDiscount { get; private set; }

        /// <summary>
        /// Percentage of discount given to user for this item
        /// </summary>
        public decimal UserDiscount { get; private set; }

        /// <summary>
        /// Status of item
        /// </summary>
        public ProcessItemStatus ItemStatus { get; set; }

        public decimal DiscountCost
        {
            get
            {
                decimal Result = _cost * (decimal)_order.CostMultiplier;

                if (ProductDiscount > 0.0m)
                {
                    Result = Result - (Result / 100 * ProductDiscount);
                }

                if (_order.Options.HasFlag(InvoiceOptions.SageDiscountType))
                {
                    if (_order.Discount > 0 && _order.VoucherType == Enums.InvoiceVoucherType.Percent)
                    {
                        Result = Result - (Result / 100 * (decimal)_order.Discount);
                    }

                    if (UserDiscount > 0)
                    {
                        Result = Result - (Result / 100 * UserDiscount);
                    }
                }
                else
                {
                    decimal totalDiscount = UserDiscount;

                    if (_order.Discount > 0 && _order.VoucherType == Enums.InvoiceVoucherType.Percent)
                    {
                        totalDiscount += (decimal)_order.Discount;
                    }

                    if (totalDiscount > 0.00m)
                    {
                        Result = Result - (Result / 100 * totalDiscount);
                    }
                }

                return Result;
            }
        }

        public string VatStr
        {
            get
            {
                return SharedUtils.FormatMoney(SharedUtils.VATCalculate(Price, _order.VATRate),
                    _order.Currency, false, true);
            }
        }

        public decimal UserDiscountValue
        {
            get
            {
                if (UserDiscount == 0)
                    return 0;

                decimal Result = _cost * (decimal)Quantity;

                if (ProductDiscount > 0.0m)
                {
                    Result = Result - (Result / 100 * ProductDiscount);
                }

                if (_order.Options.HasFlag(InvoiceOptions.SageDiscountType))
                {
                    if (_order.Discount > 0 && _order.VoucherType == Enums.InvoiceVoucherType.Percent)
                    {
                        Result = Result - (Result / 100 * (decimal)_order.Discount);
                    }

                    if (UserDiscount > 0)
                    {
                        Result = Result / 100 * UserDiscount;
                    }
                }
                else
                {
                    if (UserDiscount > 0.00m)
                    {
                        Result = Result / 100 * UserDiscount;
                    }
                }

                return Result;
            }
        }

        public decimal ProductDiscountValue
        {
            get
            {
                if (ProductDiscount > 0)
                    return _cost * (decimal)_order.CostMultiplier * (decimal)Quantity / 100 * ProductDiscount;
                else
                    return 0;
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("OrderItem: {0}; Description: {1}", ID, _description);
        }

        #endregion Overridden Methods

    }
}