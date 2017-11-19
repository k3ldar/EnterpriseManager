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
 *  File: ShoppingBasket.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using Shared.Classes;

using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Countries;
using Library.BOL.Orders;
using Library.BOL.Products;
using Library.BOL.Appointments;
using Library.BOL.Salons;
using Library.BOL.Coupons;
using Library.BOL.Accounts;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified

namespace Library.BOL.Basket
{
    [Serializable]
    public sealed class ShoppingBasket : BaseObject
    {
        #region Private / Protected Members

        private BasketDiscountType _discountType = BasketDiscountType.None;
        private Currency _currency = null;
        private Int64 _ID;
        private decimal _discount;
        private string _DiscountCouponName = "";
        private DeliveryAddress.DeliveryAddress _ShippingAddress;
        private User _user;
        private Country _Country;
        private double _vatRate;

        //private decimal _discountAmount;
        private decimal _Subtotal;
        private decimal _vat;
        private decimal _Total;
        private decimal _shipping;
        private bool _shippingValueSet = false;

        private bool _IgnoreBasketQuantityRestrictions;
        private bool _IgnoreCostMultiplier;

        [NonSerialized]
        private BasketItems _basketItems = null;

        private int _maximumItemQuantity = 3;

        private Enums.InvoiceVoucherType _VoucherType;

        private string _deliveryInstructions;

        private bool _freeShipping = false;
        private decimal _freeShippingAmount;

        private ProductCost _giftWrapProduct;


        private bool _currencyAccepted = true;

        private bool _overrideVAT = false;

        private double _overriddenVATRate;

        #endregion Private / Protected Members

        #region Constructor / Destructor

        public ShoppingBasket()
        {
            CouponUsed = null;
        }

        /// <summary>
        /// Constructor from website
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="country"></param>
        /// <param name="currency"></param>
        /// <param name="freeShipping"></param>
        /// <param name="freeShippingAmount"></param>
        public ShoppingBasket(Int64 id, Country country, Currency currency, 
            bool freeShipping, decimal freeShippingAmount, bool showVatOnProducts,
            bool shippingIsTaxable, bool isNewID)
            : this()
        {
            UseSageDiscountLogic = false;
            SaleIsFromShopFront = false;

            if (id == -1)
            {
                _ID = DAL.FirebirdDB.BasketGetNextID(1);
                _basketItems = new BasketItems(this);
            }
            else
            {
                _ID = id;

                if (isNewID)
                    _basketItems = new BasketItems(this);
            }

            _Country = country;
            IgnoreAutoDiscount = false;
            _DiscountCouponName = String.Empty;
            _IgnoreBasketQuantityRestrictions = false;
            _IgnoreCostMultiplier = false;
            _freeShippingAmount = freeShippingAmount;
            _freeShipping = freeShipping;
            Currency = currency;
            ResetBasketValues();

            _giftWrapProduct = GiftWrapProduct();

            if (_giftWrapProduct != null)
            {
                GiftWrappingPrice = _giftWrapProduct.PriceGet(currency.PriceColumn, country);
            }

            ShippingIsTaxable = shippingIsTaxable;
        }

        public ShoppingBasket(Int64 ID, Country country, Currency currency, bool shippingIsTaxable)
            : this()
        {
            UseSageDiscountLogic = false;
            SaleIsFromShopFront = false;
            _ID = ID;
            _Country = country;
            IgnoreAutoDiscount = false;
            _DiscountCouponName = String.Empty;
            _IgnoreBasketQuantityRestrictions = false;
            _IgnoreCostMultiplier = false;
            _freeShippingAmount = 0.00m;
            Currency = currency;
            ResetBasketValues();

            _giftWrapProduct = GiftWrapProduct();

            if (_giftWrapProduct != null)
            {
                GiftWrappingPrice = _giftWrapProduct.PriceGet(currency.PriceColumn, country);
            }

            ShippingIsTaxable = shippingIsTaxable;
        }

        public ShoppingBasket(Country country, Currency currency, bool shippingIsTaxable)
            : this()
        {
            UseSageDiscountLogic = false;
            SaleIsFromShopFront = false;
            _ID = DAL.FirebirdDB.BasketGetNextID(1);

            if (country == null)
                _Country = BOL.Countries.Countries.Get("ZZ");
            else
                _Country = country;

            Currency = currency;

            ResetBasketValues();
            _IgnoreBasketQuantityRestrictions = false;
            _IgnoreCostMultiplier = false;
            _giftWrapProduct = GiftWrapProduct();

            if (_giftWrapProduct != null)
            {
                GiftWrappingPrice = _giftWrapProduct.PriceGet(currency.PriceColumn, country);
            }

            ShippingIsTaxable = shippingIsTaxable;
        }

        #endregion Constructor / Destructor

        #region Properties

        /// <summary>
        /// The current coupon being used
        /// </summary>
        public Coupon CouponUsed { get; private set; }

        /// <summary>
        /// Type of discount within the basket
        /// </summary>
        public BasketDiscountType DiscountType { get { return (_discountType); } }

        /// <summary>
        /// Represents the total user discount on an individual product item (all items)
        /// </summary>
        public decimal UserDiscountValue { get; internal set; }

        /// <summary>
        /// Represents the total product discount for all product items, this is applied 
        /// prior to all other discounts
        /// </summary>
        public decimal ProductDiscountValue { get; internal set; }

        /// <summary>
        /// Basket Discunt value, if the discount type is percentage based on users 
        /// auto amount or user defined discount then it is the total for all items 
        /// in the basket
        /// </summary>
        public decimal BasketDiscountValue { get; internal set; }

        /// <summary>
        /// If a web session, it's the users web session id
        /// </summary>
        public string WebSessionID { get; set; }

        /// <summary>
        /// If currency is not accepted then the value of all items is divisible by 
        /// the exchange rate, regardless of wether the exchange rate is used or not
        /// in a normal capacity.
        /// 
        /// The culture is also set to the default culture for the default currency
        /// 
        /// i.e.
        /// 
        /// user selects USD payment country and then selects paynet which only
        /// accepts GBP
        /// 
        /// culture goes from en-US to en-GB 
        /// </summary>
        public bool CurrencyAccepted 
        { 
            get
            {
                return (_currencyAccepted);
            }
            
            set
            {
                _currencyAccepted = value;

                foreach (BasketItem item in Items)
                {
                    item.Price = item.Price / Currency.ConversionRate;
                }

                ResetBasketValues();
            }
        }

        /// <summary>
        /// Currency associated with the sale
        /// </summary>
        public Currency Currency 
        {
            get
            {
                return (_currency);
            }

            set
            {
                _currency = value;
            }
        }

        /// <summary>
        /// Cost of Gift Wrapping
        /// </summary>
        public decimal GiftWrappingPrice { get; private set; }

        /// <summary>
        /// Maximum number of items that can be added to a basket by a user
        /// 
        /// Introduced to prevent fraudulant users
        /// </summary>
        public int MaximumItemQuantity
        {
            get
            {
                return (_maximumItemQuantity);
            }

            set
            {
                _maximumItemQuantity = value;
            }
        }

        /// <summary>
        /// Delivery Instructions
        /// </summary>
        public string DeliveryInstructions
        {
            get
            {
                return (_deliveryInstructions == null ? "" : _deliveryInstructions);
            }

            set
            {
                _deliveryInstructions = value;
            }
        }

        /// <summary>
        /// Returns the basket ID
        /// </summary>
        public Int64 ID
        {
            get
            {
                return (_ID);
            }
        }

        /// <summary>
        /// Voucher Type (% discount or £ value discount)
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
            }
        }

        /// <summary>
        /// Returns a collection of BasketItems
        /// </summary>
        public BasketItems Items
        {
            get
            {
                if (_basketItems == null)
                    _basketItems = DAL.FirebirdDB.BasketItemsGet(this);

                return (_basketItems);
            }
        }

        /// <summary>
        /// Name of discount coupon
        /// </summary>
        public string DiscountCouponName
        {
            get
            {
                return (_DiscountCouponName);
            }
        }

        public decimal SubTotalMinusVATDecimal
        {
            get
            {
                decimal Result = 0.00m;

                foreach (BasketItem item in Items)
                {
                    Result += item.PriceWithDiscount + (item.Price * (decimal)GetMultiplier()) * item.Quantity;
                }

                return (Result);
            }
        }

        public decimal SubTotalMinusVAT
        {
            get
            {
                decimal Result = 0.00m;

                foreach (BasketItem item in Items)
                {
                    decimal Price = (item.PriceWithDiscount * (decimal)GetMultiplier()) * item.Quantity;
                    Result += Price;
                }

                //is there a monetary discount?
                if ((_discountType == BasketDiscountType.Value && _discount > 0) ||
                    (_discountType == BasketDiscountType.Coupon &&
                    _VoucherType == Enums.InvoiceVoucherType.Value &&
                    _discount > 0))
                {
                    if (SaleIsFromShopFront)
                    {
                        // if there is a monetary discount then this is from the total value
                        // and not from the sub total (i.e. before vat)
                        // back calculate the new subtotal now
                        decimal shopVAT = SharedUtils.VATCalculate(Result, _vatRate);
                        shopVAT = Math.Round(shopVAT, 2, MidpointRounding.AwayFromZero);

                        decimal total = (Result + shopVAT + ShippingCosts) - _discount;
                        Result = SharedUtils.VATRemove(total, _vatRate);
                    }
                }

                return (Result);
            }
        }

        /// <summary>
        /// Determines wether the countries cost multiplier is ignored or not
        /// </summary>
        public bool IgnoreCostMultiplier
        {
            get
            {
                return (_IgnoreCostMultiplier);
            }

            set 
            {
                _IgnoreCostMultiplier = value;
            }
        }

        /// <summary>
        /// Shopping Basket Discount amount
        /// </summary>
        public decimal Discount
        {
            get
            {
                return (_discount);
            }
        }

        public DeliveryAddress.DeliveryAddress ShippingAddress
        {
            get
            {
                return (_ShippingAddress);
            }

            set
            {
                _ShippingAddress = value;
                ResetBasketValues();
            }
        }

        /// <summary>
        /// User who basket applies to
        /// </summary>
        public User User
        {
            get
            {
                return (_user);
            }

            set
            {
                _user = value;

                //set delivery address if its not already set and the user is changed.
                if (_user != null)
                {
                    Country = _user.Country;
                    _ShippingAddress = _user.DeliveryAddresses.First();
                    UpdateVATRate();
                }

                if (_user != null && _user.MemberLevel == MemberLevel.GoldUser)
                {
                    if (_user.AutoDiscount > 0)
                    {
                        _VoucherType = Enums.InvoiceVoucherType.Percent;
                        _DiscountCouponName = "Gold User";
                        _discount = _user.AutoDiscount;
                        _discountType = BasketDiscountType.Percentage;
                    }
                }
                else
                {
                    if ((!IgnoreAutoDiscount && _user != null && _user.MemberLevel >= MemberLevel.Distributor && _user.AutoDiscount > 0))
                    {
                        ApplyDiscount(_user.AutoDiscount, "Salon Discount");
                        _VoucherType = Enums.InvoiceVoucherType.Percent;
                        _DiscountCouponName = "Salon Discount";
                        _discount = _user.AutoDiscount;
                    }
                }

                ResetBasketValues();
            }
        }

        public Country Country
        {
            get
            {
                if (!SaleIsFromShopFront && _user != null)
                    return (_user.Country);
                else
                    return (_Country);
            }

            set
            {
                if (!SaleIsFromShopFront) 
                    _Country = value;

                ResetBasketValues();
            }
        }

        /// <summary>
        /// Returns the total discount amount
        /// </summary>
        public decimal DiscountAmount
        {
            get
            {
                decimal Result = 0;

                if (DiscountType == BasketDiscountType.Value)
                {
                    BasketDiscountValue = Discount;
                }

                if (UseSageDiscountLogic)
                {
                    Result += SharedUtils.BankersRounding(ProductDiscountValue, 2);
                    Result += SharedUtils.BankersRounding(UserDiscountValue, 2);
                    Result += SharedUtils.BankersRounding(BasketDiscountValue, 2);
                }
                else
                {
                    Result = SharedUtils.BankersRounding(ProductDiscountValue +
                        UserDiscountValue + BasketDiscountValue, 2);
                }
                    
                return (Result);
            }

            //private set
            //{
            //    _discountAmount = value;
            //}
        }

        public decimal SubTotalAmount
        {
            get
            {
                return (_Subtotal);
            }
        }

        public decimal VATAmount
        {
            get
            {
                return (_vat);
            }
        }

        public double VATRate
        {
            get
            {
                return (_vatRate);
            }
        }

        public decimal TotalAmount
        {
            get
            {
                if (_Total < 0.00m)
                {
                    return (0.00m);
                }
                else
                {
                    return (_Total);
                }
            }
        }

        /// <summary>
        /// if true, shipping is taxable, if false, there is no tax on shipping
        /// </summary>
        public bool ShippingIsTaxable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ShippingCosts
        {
            set
            {
                _shipping = value;
                _shippingValueSet = true;
            }

            get
            {
                return (_shipping);
            }
        }

        /// <summary>
        /// Returns discount amount as a string
        /// </summary>
        public string DiscountCost
        {
            get
            {
                return (SharedUtils.FormatMoney(DiscountAmount, Currency));
            }
        }

        /// <summary>
        /// Subtotal as string
        /// </summary>
        public string SubTotalCost
        {
            get
            {
                return (SharedUtils.FormatMoney(SubTotalAmount, Currency));
            }
        }

        /// <summary>
        /// Vat Amount as String
        /// </summary>
        public string VATCost
        {
            get
            {
                decimal value = VATAmount;

                return (SharedUtils.FormatMoney(value, Currency));
            }
        }

        /// <summary>
        /// Total Amount as string
        /// </summary>
        public string TotalCost
        {
            get
            {
                return (SharedUtils.FormatMoney(TotalAmount, Currency));
            }
        }

        /// <summary>
        /// Shipping amount as string
        /// </summary>
        public string ShippingCost
        {
            get
            {
                decimal value = ShippingCosts;

                return (SharedUtils.FormatMoney(value, Currency));
            }
        }

        public string SubTotalMinusVATCost
        {
            get
            {
                return (SharedUtils.FormatMoney(SharedUtils.BankersRounding(SubTotalMinusVAT, 2), Currency));
            }
        }


        /// <summary>
        /// Indicates wether the sale allows multi currencies or not
        /// 
        /// Sales on a website could allow multiple currencies, sales in 
        /// an office or salon will only allow a single currency to be used
        /// </summary>
        public bool MultiCurrency { get; set; }

        /// <summary>
        /// The sale is from a shop front, if true postage will never be applied
        /// </summary>
        public bool SaleIsFromShopFront { get; set; }

        /// <summary>
        /// Can we have free shipping or not
        /// </summary>
        public bool FreeShipping
        {
            get
            {
                if (SaleIsFromShopFront)
                {
                    return (true);
                }

                return (_freeShipping);
            }

            set
            {
                _freeShipping = value;

                if (_freeShipping && _freeShippingAmount == 0.00m)
                    _freeShippingAmount = 125.00m;

                if (!_freeShipping)
                    _freeShippingAmount = 0.00m;

                ResetBasketValues();
            }
        }

        /// <summary>
        /// The minimum spend before Free Shipping is applied
        /// </summary>
        public decimal FreeShippingAmount 
        {
            get
            {
                return (_freeShippingAmount);
            }

            set
            {
                _freeShippingAmount = value;
                
                ResetBasketValues();
            }
        }

        /// <summary>
        /// If true the users automatic discount is the only value that can be set, this 
        /// prevents users having a discount, and then applying another discount using a 
        /// coupon code etc, if false, the user can set the discount using coupons etc
        /// 
        /// Website = false
        /// Till = true
        /// Create Order = true
        /// </summary>
        public bool IgnoreAutoDiscount { get; set; }

        /// <summary>
        /// Indicates wether restriction on quantity for an individual item is ignored or not
        /// </summary>
        public bool IgnoreBasketQuantityRestrictions
        {
            get
            {
                return (_IgnoreBasketQuantityRestrictions);
            }

            set
            {
                _IgnoreBasketQuantityRestrictions = value;
            }
        }

        /// <summary>
        /// Determines wether VAT rate is overridden or not
        /// </summary>
        public bool OverrideVATRate
        {
            get
            {
                return (_overrideVAT);
            }

            set
            {
                _overrideVAT = value;
                UpdateVATRate();
                RaiseBasketUpdated();
            }
        }

        /// <summary>
        /// If vat rate is overridden then this is the vat rate
        /// </summary>
        public double OverriddenVatRate
        {
            get
            {
                return (_overriddenVATRate);
            }

            set
            {
                _overriddenVATRate = value;
                UpdateVATRate();
                RaiseBasketUpdated();
            }
        }

        /// <summary>
        /// If true then if the user has an automatic discount then this is applied
        /// to the unit price, a further reduction via the user discount is then 
        /// applied to the net amount of the product cost.
        /// 
        /// If false, the discount and user discount are added together to discount the
        /// net product cost
        /// </summary>
        public bool UseSageDiscountLogic { get; set; }


        public InvoiceOptions Options
        {
            get
            {
                InvoiceOptions Result = InvoiceOptions.Unused;

                if (UseSageDiscountLogic)
                    Result |= InvoiceOptions.SageDiscountType;

                if ((int)Result > 1)
                    Result &= ~InvoiceOptions.Unused;

                return (Result);
            }
        }

        /// <summary>
        /// If true, then the basket will not be cleared until the payment is confirmed, the order will still be created
        /// though.
        /// 
        /// If false, the basket will be cleared immediately after creating an order
        /// </summary>
        public bool ClearBasketOnPayment { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("ShoppingBasket: {0}; Discount: {1}; Coupon Name: {2}; Discount Ammount: {3}; Subtotal: {4}; VAT: {5}, Vat Rate: {6}; Total: {7}; Shipping: {8}; Voucher Type: {9}; Currency: {10}",
                ID, _discount, _DiscountCouponName, DiscountAmount, _Subtotal, _vat, _vatRate, _Total, ShippingCosts, _VoucherType, Currency.CurrencyCode));
        }

        #endregion Overridden Methods

        #region Public Methods

        /// <summary>
        /// Saves the basket for future use
        /// </summary>
        /// <param name="description">Name of saved order</param>
        public void SaveBasket(string description, bool autoOrder = false)
        {
            DAL.FirebirdDB.OrderSave(this, description, autoOrder);
        }

        #region Gift Wrapping

        /// <summary>
        /// Determines wether there is a gift wrapping product available
        /// </summary>
        /// <returns></returns>
        public bool GiftWrappingProductAvailable()
        {
            bool Result = false;

            if (_giftWrapProduct != null)
            {
                Result = HasItems() && !GiftWrappingIncluded();
            }

            return (Result);
        }

        public bool GiftWrappingIncluded()
        {
            bool Result = false;

            if (_giftWrapProduct != null)
            {
                Result = ContainsProduct(_giftWrapProduct);
            }

            return (Result);
        }

        public void GiftWrappingAdd(int priceColumn)
        {
            Add(_giftWrapProduct, 1, _user, ProductCostItemType.GiftWrap, RaiseSelectPriceColumn(priceColumn));
        }

        public void GiftWrappingRemove()
        {
            Delete(_giftWrapProduct.ID, ProductCostItemType.GiftWrap, true);
        }

        #endregion Gift Wrapping

        /// <summary>
        /// Determines wether the shopping basket contains a product cost
        /// </summary>
        /// <param name="item">Item searching for</param>
        /// <returns>true if the item is in the basket, otherwise false</returns>
        public bool Contains(ProductCost item)
        {
            bool Result = false;

            foreach (BasketItem basketItem in Items)
            {
                if (basketItem.ItemID == item.ID)
                {
                    Result = true;
                    break;
                }
            }

            return (Result);
        }

        public bool IsEmpty()
        {
            return (DAL.FirebirdDB.BasketGetTotalItems(this.ID) == 0);
        }

        /// <summary>
        /// Reset's the basket by updating all values
        /// </summary>
        public void Reset(int priceColumn)
        {
            //try
            //{
            //    priceColumn = RaiseSelectPriceColumn(priceColumn);
            //}
            //catch
            //{
            //    priceColumn = Currency.PriceColumn;
            //}

            //for each item in the basket, reset the price depending on the new price option
            for (int i = Items.Count -1; i >= 0; i--)
            {
                BasketItem item = Items[i];

                if (item.ItemType == ProductCostItemType.Treatment)
                    continue;

                bool changed = false;

                ProductCost pCost = ProductCosts.Get(item.ItemID);

                if (pCost == null)
                {
                    // product no longer available, move on
                    Items.RemoveAt(i);
                    Delete(item);
                    continue;
                }

                decimal price = pCost.PriceGet(priceColumn, Country);

                if (price != item.Price)
                {
                    item.Price = price;
                    changed = true;
                }

                if (priceColumn != item.PriceColumn)
                {
                    item.PriceColumn = priceColumn;
                    changed = true;
                }
                
                if (changed)
                    item.Save(this);
            }

            ResetBasketValues();
        }

        /// <summary>
        /// Updates prices based on user and country price options
        /// </summary>
        /// <param name="user">Current user, if there is one</param>
        /// <param name="newCountry">Current Country</param>
        [Obsolete("Replaced with similar method where price column is specified")]
        public void Reset(User user, Country newCountry)
        {
            User = user;
            Country = newCountry;
            int col = RaiseSelectPriceColumn(Currency.PriceColumn);

            //for each item in the basket, reset the price depending on the new price option
            foreach (BasketItem item in Items)
            {
                item.PriceColumn = col;
                item.Price = ProductCosts.Get(item.ItemID).PriceGet(col, Country);
                item.Save(this);
            }

            Reset(col);
        }

        /// <summary>
        /// Validates a coupon code and gets the discount associated.
        /// </summary>
        /// <param name="CouponCode">Coupon Code to be validated</param>
        /// <returns>true if valid discount coupon code, otherwise false.</returns>
        public bool ValidateCouponCode(string CouponCode, ref string resultText)
        {
            CouponUsed = null;

            resultText = String.Empty;
            VoucherType = Enums.InvoiceVoucherType.Percent;

            if ((!IgnoreAutoDiscount && _user != null && _user.MemberLevel >= MemberLevel.Distributor && _user.AutoDiscount > 0))
                return (true);

            if (CouponCode.Length > 30)
                CouponCode = CouponCode.Substring(0, 29);

            CouponCode = CouponCode.Replace("'", "").Replace("\"", "");

            //remove any free products
            RemoveFreeProducts(false);

            Coupon cpn = Coupons.Coupons.ValidateCoupon(CouponCode);

            if (cpn != null)
            {
                _discount = 0;
                _discountType = BasketDiscountType.Coupon;
                _DiscountCouponName = String.Empty;

                if (cpn.RestrictUserUsage && _user != null)
                {
                    if (_user.Invoices.VoucherUsed(CouponCode))
                    {
                        resultText = "Voucher already used by client";
                        return (false);
                    }
                }

                if (cpn.UserID > -1 && _user != null && cpn.UserID != _user.ID)
                {
                    resultText = "Coupon is for a specific user";
                    return (false);
                }

                if (cpn.MinimumSpend != 0.00m && TotalWithoutShipping() < cpn.MinimumSpend)
                {
                    resultText = String.Format("Minimim spend of {0} not met.", 
                        SharedUtils.FormatMoney(cpn.MinimumSpend, Currency));
                    return (false);
                }

                //if the code is linked to a product make sure the product is in the basket
                if (!ContainsProduct(cpn))
                {
                    resultText = "This coupon requires specific products in the basket";

                    return (false);
                }

                //is there a free product with the code
                if (cpn != null && cpn.Valid() && cpn.FreeProduct != null &&
                    ContainsProduct(cpn) && !ContainsProduct(cpn.FreeProduct))
                {
                    //add the free product
                    Add(cpn.FreeProduct, _user, _Country);
                }

                _discount = cpn.Discount;
                
                _DiscountCouponName = CouponCode;

                if (cpn.VoucherType == Enums.InvoiceVoucherType.Value)
                {
                    _discount = cpn.Discount;

                    if (cpn.MaxUsage > cpn.VoucherUsage)
                    {
                        CouponUsed = cpn;
                        VoucherType = cpn.VoucherType;
                    }
                    else
                    {
                        if (cpn.VoucherUsage == 0)
                        {
                            CouponUsed = cpn;
                            VoucherType = cpn.VoucherType;
                        }
                        else
                        {
                            _discount = 0;
                            return (false);
                        }
                    }
                }
                else
                {
                    CouponUsed = cpn;
                    VoucherType = cpn.VoucherType;
                }
            }
            else
            {
                //is there a salon discount
                SalonDiscount salonDiscount = SalonDiscount.Get(CouponCode);

                if (salonDiscount != null)
                {
                    if (salonDiscount.Salon.ShowOnWeb)
                    {
                        _discountType = BasketDiscountType.Coupon;
                        _discount = salonDiscount.CustomerDiscount;
                        _DiscountCouponName = CouponCode;
                    }
                    else
                    {
                        _DiscountCouponName = String.Empty;
                    }
                }
                else
                {
                    Coupon coupon = Coupons.Coupons.Get(CouponCode);

                    if (coupon != null && coupon.Valid() && coupon.FreeProduct != null &&
                        ContainsProduct(coupon))
                    {
                        //add the free product
                        Add(coupon.FreeProduct, _user, _Country);
                    }
                    else
                    {
                        if (_user != null && _user.MemberLevel != MemberLevel.GoldUser)
                        {
                            _DiscountCouponName = String.Empty;
                            _discount = 0;
                        }

                        if (coupon == null)
                            resultText = "Invalid Discount Coupon";
                    }
                }
            }

            ResetBasketValues();

            switch (_VoucherType)
            {
                case Enums.InvoiceVoucherType.Percent:
                case Enums.InvoiceVoucherType.Value:
                    return (_discount > 0);
                case Enums.InvoiceVoucherType.Footprint:
                    return (true);
                case Enums.InvoiceVoucherType.SpecialOffer:
                    return (true);
                case Enums.InvoiceVoucherType.FreeProduct:
                    return (true);
                default:
                    throw new Exception("Discount Voucher Type not known");
            }
        }

        /// <summary>
        /// Determines wether ALL products have free shipping or not
        /// </summary>
        /// <returns></returns>
        public bool ProductsHaveShipping()
        {
            bool Result = false;

            foreach (BasketItem item in Items)
            {
                ProductCost cost = ProductCosts.Get(item.ItemID);

                if (cost != null)
                {
                    Product product = cost.Product;

                    if (!product.FreeShipping)
                    {
                        Result = true;
                        break;

                    }
                }
            }

            return (Result);
        }

        public void RemoveFreeProducts(bool validate)
        {
            //add the free product
            foreach (BasketItem item in Items)
            {
                if (item.ItemType == ProductCostItemType.FreeProduct)
                {
                    Delete(item.ItemID, ProductCostItemType.FreeProduct, validate);
                }
            }
        }

        /// <summary>
        /// Applies a monetary value discount
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="reason"></param>
        public void ApplyDiscount(decimal discount, string reason)
        {
            if ((!IgnoreAutoDiscount && _user != null && _user.MemberLevel >= MemberLevel.Distributor && _user.AutoDiscount > 0))
                return;
            _discountType = BasketDiscountType.Value;

            VoucherType = Enums.InvoiceVoucherType.Value;
            _discount = discount;
            _DiscountCouponName = reason;
            ResetBasketValues();
        }

        /// <summary>
        /// Applies a percentage discount
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="reason"></param>
        public void ApplyDiscount(int discount, string reason)
        {
            CouponUsed = null;

            if (discount == 0)
            {
                _discountType = BasketDiscountType.None;
                _discount = 0;
                _DiscountCouponName = reason;
                ResetBasketValues();
            }
            else
            {
                if ((!IgnoreAutoDiscount && _user != null && _user.MemberLevel >= MemberLevel.Distributor && _user.AutoDiscount > 0))
                    return;

                _discountType = BasketDiscountType.Percentage;
                _discount = discount;
                _DiscountCouponName = reason;
                ResetBasketValues();
            }
        }

        /// <summary>
        /// Updates a basket item
        /// </summary>
        /// <param name="item">Basket Item</param>
        /// <param name="quantity">Quantity being sold</param>
        /// <param name="user">User making the sale</param>
        public void Update(BasketItem item, decimal quantity, User user)
        {
            decimal NewQuantity = SetQuantity(quantity);

            item.Quantity = NewQuantity;
            DAL.FirebirdDB.BasketUpdateBasket(_ID, item, user);

            foreach (BasketItem bItem in Items)
            {
                if (bItem.ItemID == item.ItemID)
                {
                    bItem.Quantity = quantity;
                    bItem.ProductDiscount = item.ProductDiscount;
                    bItem.UserDiscount = item.UserDiscount;
                    bItem.UserID = user.ID;
                    bItem.Description = item.Description;

                    break;
                }
            }

            ResetBasketValues();
        }

        public BasketItem Add(ProductCost Item, decimal Quantity, User user, int priceColumn)
        {
            return (Add(Item, Quantity, user, Item.ItemType, RaiseSelectPriceColumn(priceColumn)));
        }

        public BasketItem Add(ProductCost Item, decimal Quantity, User user, ProductCostItemType productType,
            int priceColumn)
        {
            BasketItem bItem = Items.Get(Item);

            decimal NewQuantity = SetQuantity(Quantity + (bItem == null ? 0 : bItem.Quantity));

            if (priceColumn == -1)
                priceColumn = _Country.PriceColumn;

            BasketItem newItem =  DAL.FirebirdDB.BasketAddToBasket(this, Item.ID, NewQuantity, productType, user, 
                RaiseSelectPriceColumn(priceColumn), String.Format("{0} ({1})", Item.Product.Name, Item.Size));

            //does the product come with any free offers?
            ProductCosts free = Item.FreeProducts();

            foreach (ProductCost cost in free)
            {
                Add(cost, user, _Country);
            }

            if (bItem == null)
            {
                _basketItems.Add(newItem);
            }
            else
            {
                bItem.Quantity = newItem.Quantity;
                newItem = bItem;
            }

            Reset(priceColumn);

            return (newItem);
        }

        public BasketItem Add(AppointmentTreatment Item, int Quantity, User user, int priceColumn)
        {
            BasketItem bItem = Items.Get(Item);

            decimal NewQuantity = SetQuantity(Quantity + (bItem == null ? 0 : bItem.Quantity));

            if (priceColumn == -1)
                priceColumn = _Country.PriceColumn;

            DAL.FirebirdDB.BasketAddToBasket(this, Item.ID, NewQuantity, ProductCostItemType.Treatment, user,
                RaiseSelectPriceColumn(priceColumn), Item.Name);

            decimal newQuantity = Quantity;

            foreach (BasketItem item in _basketItems)
            {
                if (item.ItemID == Item.ID && item.ItemType == ProductCostItemType.Treatment)
                {
                    newQuantity += item.Quantity;
                    break;
                }
            }

            BasketItem newItem =  DAL.FirebirdDB.BasketAddToBasket(this, Item.ID, newQuantity,
                ProductCostItemType.Treatment, user, 
                RaiseSelectPriceColumn(_Country.PriceColumn),
                Item.Name);
            _basketItems.Add(newItem);

            Reset(priceColumn);

            return (newItem);
        }

        /// <summary>
        /// DecreaseQuantity
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Quantity"></param>
        /// <param name="user"></param>
        /// <param name="priceColumn"></param>
        /// <returns></returns>
        public void DecreaseQuantity(ProductCost Item, decimal Quantity, User user, int priceColumn = -1)
        {
            BasketItem bItem = Items.Get(Item);

            decimal NewQuantity = SetQuantity(Quantity);

            if (priceColumn == -1)
                priceColumn = _Country.PriceColumn;

            DAL.FirebirdDB.BasketAddToBasket(this, Item.ID, Quantity, ProductCostItemType.Product, user,
                RaiseSelectPriceColumn(priceColumn), Item.Size);

            //does the product come with any free offers?
            ProductCosts free = Item.FreeProducts();

            foreach (ProductCost cost in free)
            {
                Add(cost, user, _Country);
            }

            BasketItem Result = Items.Get(Item);

            if (Quantity < 1)
            {
                Delete(Result);
            }

            ResetBasketValues();
        }

        public void Delete(Int64 ItemID, ProductCostItemType ItemType, bool validate)
        {
            BasketItem item = Items.Get(ItemID);
            DAL.FirebirdDB.BasketDeleteFromBasket(item);
            _basketItems = null;
            ResetBasketValues();
            string resultText = String.Empty;
            
            if (validate)
                ValidateCouponCode(_DiscountCouponName, ref resultText);
        }

        public void Delete(BasketItem item)
        {
            DAL.FirebirdDB.BasketDeleteFromBasket(item);

            //does this item have free products attached
            ProductCost itemcost = DAL.FirebirdDB.ProductCostGet(item.ItemID);

            if (itemcost != null)
            {
                ProductCosts free = itemcost.FreeProducts();


                foreach (ProductCost cost in free)
                {
                    Delete(cost.ID, ProductCostItemType.FreeProduct, true);
                }
            }

            // gift wrap can not be in there by it's self
            if (Items.Count == 1 && GiftWrappingIncluded())
                Empty();

            string resultText = String.Empty;
            ValidateCouponCode(_DiscountCouponName, ref resultText);

            _basketItems = null;

            ResetBasketValues();
        }

        public void Empty()
        {
            DAL.FirebirdDB.BasketEmpty(this.ID);
            _discountType = BasketDiscountType.None;
            _DiscountCouponName = String.Empty;
            _basketItems = null;
            ResetBasketValues();
        }

        public bool HasItems()
        {
            return (Items.Count > 0);
        }

        public Order ConvertToOrder(PaymentStatus PayMethod, string UserSession, string RemoteHost, string culture)
        {
            if (TotalAmount == 0.00m && RemoteHost == "shop")
            {
                User _staff = User.UserGet(UserSession);

                foreach (BasketItem item in Items)
                {
                    item.UserID = _staff.ID;
                }
            }

            Order Result = null;

            ResetBasketValues();

            if (_user == null)
                throw new ArgumentNullException("User can not be null");

            if (ProductsHaveShipping() && !_freeShipping && _ShippingAddress == null)
                throw new ArgumentNullException("Shipping Address can not be null");

            Result = DAL.FirebirdDB.BasketSendEmailForPayment(this, PayMethod, UserSession, 
                RemoteHost, VoucherType, Currency, Consts.INVOICE_VERSION_VAT_ADD_OPTIONS);

            if (Result != null && !ClearBasketOnPayment)
            {
                Empty();
                ResetBasketValues();
            }

            Hooks.Hooks.HookNotification(HookEvent.OrderCreated,
                String.Format("Order: {0}; Payment Type: {1}", 
                    Result.ID, PayMethod.Description));

            return (Result);
        }

        #endregion Public Methods

        #region Private Methods

        private ProductCost GiftWrapProduct()
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string cacheName = "DAL Gift Wrap Product";
                CacheItem item = DAL.DALHelper.InternalCache.Get(cacheName);

                if (item != null)
                    return ((ProductCost)item.Value);

                ProductCost Result = DAL.FirebirdDB.ProductCostGetGiftWrap();
                DAL.DALHelper.InternalCache.Add(cacheName, new CacheItem(cacheName, Result));

                return (Result);
            }

            return (DAL.FirebirdDB.ProductCostGetGiftWrap());
        }

        private decimal GetMultiplier()
        {
            if (DAL.DALHelper.OverrideCostMultiplier)
            {
                return ((decimal)DAL.DALHelper.OverrideCostMultiplierValue);
            }

            if (_IgnoreCostMultiplier || Currency == null)
                return (1.00m);

            return (Currency.Multiplier);
        }

        private bool ContainsProduct(Coupon coupon)
        {
            bool Result = false;

            if (coupon.RequiredProducts.Count == 0)
                return (true);

            foreach (ProductCost couponItem in coupon.RequiredProducts)
            {
                foreach (BasketItem basketItem in Items)
                {
                    if (basketItem.ItemID == couponItem.ID)
                    {
                        return (true);
                    }
                }
            }

            return (Result);
        }

        private bool ContainsProduct(ProductCost cost)
        {
            foreach (BasketItem basketItem in Items)
            {
                if (basketItem.ItemID == cost.ID)
                {
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// Adds a free product to the basket
        /// </summary>
        /// <param name="Item">Free Item</param>
        /// <param name="user">Current User</param>
        private void Add(ProductCost Item, User user, Country country)
        {
            BasketItem bItem = Items.Get(Item);

            decimal NewQuantity = SetQuantity(1 + (bItem == null ? 0 : bItem.Quantity));

            Item.PriceSet(country, 0.00m);

            BasketItem newItem = DAL.FirebirdDB.BasketAddToBasket(this, Item.ID, NewQuantity,
                ProductCostItemType.FreeProduct, user, RaiseSelectPriceColumn(_Country.PriceColumn), Item.Size);
            _basketItems.Add(newItem);
        }

        private decimal SetQuantity(decimal Quantity)
        {
            decimal Result = Quantity;

            if (!_IgnoreBasketQuantityRestrictions && Result > MaximumItemQuantity)
            {
                if (_user == null)
                {
                    Result = MaximumItemQuantity;
                }
                else
                {
                    if (_user.MemberLevel < MemberLevel.Distributor)
                        Result = MaximumItemQuantity;
                }
            }

            return (Result);
        }

        private void ResetBasketValues()
        {
            _Subtotal = Items.SubTotal();

            _Subtotal = (_Subtotal * (decimal)GetMultiplier());

            //is there a monetary discount?
            if ((_discountType == BasketDiscountType.Value && _discount > 0) ||
                (_discountType == BasketDiscountType.Coupon && 
                _VoucherType == Enums.InvoiceVoucherType.Value &&
                _discount > 0))
            {
                if (SaleIsFromShopFront)
                {
                    // if there is a monetary discount then this is from the total value
                    // and not from the sub total (i.e. before vat)
                    // back calculate the new subtotal now
                    decimal shopVAT = SharedUtils.VATCalculate(_Subtotal, _vatRate);
                    shopVAT = Math.Round(shopVAT, 2, MidpointRounding.AwayFromZero);

                    decimal total = (_Subtotal + shopVAT + ShippingCosts) - _discount;
                    _Subtotal = SharedUtils.VATRemove(total, _vatRate);
                }
                else
                {
                    _Subtotal -= _discount;
                }
            }

            UpdateVATRate();

            if (!UseSageDiscountLogic)
            {
                _vat = SharedUtils.VATCalculate(_Subtotal, _vatRate);
                _vat = Math.Round(_vat, 2, MidpointRounding.AwayFromZero);
            }
            else if (_discountType == BasketDiscountType.Value)
            {
                _vat = SharedUtils.VATCalculate(_Subtotal, _vatRate);
            }
            else 
            {
                _vat = Items.SubTotalVAT(_vatRate);
            }

            if (ShippingIsTaxable)
                _vat += SharedUtils.VATCalculate(ShippingCosts, _vatRate);

            _vat = SharedUtils.BankersRounding(_vat, 2);

            if (UseSageDiscountLogic)
            {
                _Subtotal = SharedUtils.BankersRounding(_Subtotal, 2);
            }
            else
            {
                _Subtotal = Math.Round(_Subtotal, 2, MidpointRounding.ToEven);
            }

            // finally calculate shipping costs
            CalculateShippingCosts();

            Items.GetDiscountValue();

            _Total = SharedUtils.BankersRounding(_Subtotal + _vat + ShippingCosts, 2);

            RaiseBasketUpdated();
        }

        private void CalculateShippingCosts()
        {
            if (_shippingValueSet)
            {
                return;
            }
            else
            {
                if (SaleIsFromShopFront)
                {
                    _shipping = 0.00m;
                    return;
                }

                // if option to allow free shipping on spend above xx amount then allow 
                // it if there is enough goods in the basket
                if (!SaleIsFromShopFront && (_freeShipping && _freeShippingAmount > 0.0m) && (TotalWithoutShipping() >= _freeShippingAmount))
                {
                    _shipping = 0.00m;
                    return;
                }

                if (CanApplyDiscount() && !String.IsNullOrEmpty(_DiscountCouponName))
                {
                    Coupon cpn = Coupons.Coupons.Get(_DiscountCouponName);

                    if (cpn != null)
                    {
                        if (cpn.FreePostage && TotalWithoutShipping() >= cpn.MinimumSpend)
                        {
                            _shipping = 0.00m;
                            return;
                        }
                    }
                }

                if (!ProductsHaveShipping())
                {
                    _shipping = 0.00m;
                    return;
                }

                if (_ShippingAddress != null)
                {
                    _shipping = _ShippingAddress.Country.ShippingCosts;

                    if (!CurrencyAccepted)
                        _shipping = _shipping / Currency.ConversionRate;
                }
                else
                {
                    if (_Country == null)
                        _shipping = 9.0m;
                    else
                        _shipping = _Country.ShippingCosts;
                }
            }

            // final check for postage
            //
            // if a websale then the only free shipping for a user is via a coupon or if _freeShipping is false
            if (!SaleIsFromShopFront && _shipping == 0.00m && (_freeShipping && _freeShippingAmount > 0.0m) && (TotalWithoutShipping() < _freeShippingAmount))
                //!SaleIsFromShopFront && (String.IsNullOrEmpty(_CouponCode) && ShippingAmount == 0.00m && !_freeShipping))
            {
                // is it free shipping through the coupon code?
                if (CanApplyDiscount() && !String.IsNullOrEmpty(_DiscountCouponName))
                {
                    Coupon cpn = Coupons.Coupons.Get(_DiscountCouponName);

                    if (cpn != null)
                    {
                        if (cpn.FreePostage && cpn.MinimumSpend >= TotalWithoutShipping())
                            return;
                    }
                }

                if (User != null)
                {
                    if (_ShippingAddress == null)
                        _shipping = _user.Country.ShippingCosts;
                    else
                        _shipping = _ShippingAddress.Country.ShippingCosts;
                }
                else
                {
                    if (Country == null)
                        Country = Countries.Countries.Get("ZZ");

                    _shipping = Country.ShippingCosts;
                }
            }
        }

        private bool CanApplyDiscount()
        {
            if (_user == null)
                return (true);

            if (_user.MemberLevel >= MemberLevel.Reseller)
                return (false);
            else
                return (true);
        }

        /// <summary>
        /// Returns the basket total minus the shipping amount
        /// </summary>
        /// <returns>double - Subtotal + VAT</returns>
        private decimal TotalWithoutShipping()
        {
            return (_Subtotal + _vat + DiscountAmount);
        }

        private void UpdateVATRate()
        {
            _vatRate = 0.00;

            if (_overrideVAT)
            {
                _vatRate = _overriddenVATRate;
            }
            else
            {
                if (_ShippingAddress != null)
                {
                    _vatRate = _ShippingAddress.Country.VATRate;

                    if (_user != null)
                    {
                        if (_vatRate < _user.Country.VATRate)
                            _vatRate = _user.Country.VATRate;
                    }
                }
                else
                {
                    if (_user != null)
                    {
                        _vatRate = _user.Country.VATRate;
                    }
                    else
                    {
                        if (_Country == null)
                            _vatRate = DAL.DALHelper.DefaultVATRate;
                        else
                            _vatRate = _Country.VATRate;
                    }
                }
            }
        }

        #endregion Private Methods

        #region Event Wrappers

        private int RaiseSelectPriceColumn(int priceColumn)
        {
            int Result = priceColumn;

            //if (OnSelectPriceColumn != null)
            //{
            //    PriceColumnOverrideArgs args = new PriceColumnOverrideArgs(null, null, priceColumn, WebSessionID, false);

            //    OnSelectPriceColumn(null, args);

            //    if (args.OverridePriceColumn)
            //        Result = args.PriceColumn;
            //}

            return (Result);
        }

        private void RaiseBasketUpdated()
        {
            if (BasketUpdated != null)
                BasketUpdated(this, new EventArgs());
        }

        #endregion Event Wrappers

        #region Events

        // <summary>
        // Allows clients to override the price column in use
        // </summary>
        //public event PriceColumnOverrideDelegate OnSelectPriceColumn;

        public event EventHandler BasketUpdated;

        #endregion
    }
}
