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
 *  File: ProductCost.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

using Library;
using SharedBase.BOL.StockControl;

namespace SharedBase.BOL.Products
{
    [Serializable]
    public sealed class ProductCost
    {
        #region Private / Protected Members

        private Int64 _id;
        private Product _product;
        private string _sku;
        private string _size;
        private decimal _cost1;
        private decimal _cost2;
        private decimal _cost3;
        private int _memberLevel;
        private bool _outOfStock;
        private string _barcode;
        private ProductCostType _type;
        private bool _hideGlobally;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public ProductCost(Int64 id, Product product, string sku, string size, decimal cost, int memberLevel, 
            bool outOfStock, ProductCostType type, string barcode, bool hideGlobally, bool giftWrap, 
            decimal cost2, decimal cost3, decimal discount, string additionalText,
            ProductCostItemType itemType, int licenceType, int liceneCount, decimal vatRate, double saving)
        {
            _id = id;
            _product = product;
            _sku = sku;
            _size = size;
            _cost1 = cost;
            _memberLevel = memberLevel;
            _outOfStock = outOfStock;
            _type = type;
            _barcode = barcode;
            _hideGlobally = hideGlobally;
            IsGiftWrapping = giftWrap;
            Cost2 = cost2;
            Cost3 = cost3;
            AdditionalText = additionalText;
            Discount = discount;
            LicenceType = licenceType;
            LiceneCount = liceneCount;
            VATRate = vatRate;
            Saving = saving;
            ItemType = itemType;
        }

        #endregion Constructors / Destructors

        #region Properties

        public Int64 ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Determines wether the product is hidden globally on the local store
        /// 
        /// Does not affect other stores or replication
        /// </summary>
        public bool HideGlobally
        {
            get
            {
                return _hideGlobally;
            }

            set
            {
                _hideGlobally = value;
            }
        }

        /// <summary>
        /// Product where ProductCost belongs to
        /// </summary>
        public Product Product
        {
            get
            {
                if (_product == null)
                    _product = DAL.FirebirdDB.ProductGet(this);

                return _product;
            }
        }

        public Int64 ProductID
        {
            get
            {
                return _product.ID;
            }
        }

        public string SKU
        {
            get
            {
                return _sku;
            }

            set
            {
                if (value.Length > 10)
                    throw new ArithmeticException("SKU can only be 10 Characters long");

                _sku = value;
            }
        }

        public string Size
        {
            get
            {
                return _size;
            }

            set
            {
                if (value.Length > 60)
                    throw new ArithmeticException("Size can only be 60 Characters long");

                _size = value;
            }
        }

        public decimal Cost1
        {
            get
            {
                decimal Result = _cost1;

                //if (Discount > 0.0m)
                //    Result = (Result / 100) * Discount;

                return Result;
            }

            set
            {
                _cost1 = value;
            }
        }

        /// <summary>
        /// Second Price Data - aka international prices
        /// </summary>
        public decimal Cost2
        {
            get
            {
                decimal Result = _cost2;

                //if (Discount > 0.0m)
                //    Result = (Result / 100) * Discount;

                return Result;
            }

            set
            {
                _cost2 = value;
            }
        }

        /// <summary>
        /// Third Price Data
        /// </summary>
        public decimal Cost3
        {
            get
            {
                decimal Result = _cost3;

                //if (Discount > 0.0m)
                //    Result = (Result / 100) * Discount;

                return Result;
            }

            set
            {
                _cost3 = value;
            }
        }

        public int MemberLevel
        {
            get
            {
                return _memberLevel;
            }

            set
            {
                _memberLevel = value;
            }
        }

        /// <summary>
        /// Determines wether the item is out of stock or not
        /// </summary>
        public bool OutOfStock
        {
            get
            {
                return _outOfStock;
            }

            set
            {
                _outOfStock = value;
            }
        }

        /// <summary>
        /// Get's or set's the product type
        /// </summary>
        public ProductCostType ProductCostType
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;

                ItemType = _type.ItemType;
            }
        }

        /// <summary>
        /// Get's or Set's the barcode for the product item
        /// </summary>
        public string Barcode
        {
            get
            {
                return _barcode;
            }

            set
            {
                _barcode = value;
            }
        }

        /// <summary>
        /// Retreives a collection of items used to build this product item
        /// </summary>
        public CreateStock StockCreationItems
        {
            get
            {
                return DAL.FirebirdDB.StockCreateItemsGet(this);
            }
        }

        /// <summary>
        /// Determines if this product is gift wrapping
        /// </summary>
        public bool IsGiftWrapping { get; set; }

        /// <summary>
        /// Additional Text associated with the product
        /// </summary>
        public string AdditionalText { get; set; }

        /// <summary>
        /// Product Item's discounted value
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Determines wether the product item is a licence or not
        /// </summary>
        public bool IsLicence { get; set; }

        /// <summary>
        /// Determines the type of licence if the product type is a licence
        /// </summary>
        public int LicenceType { get; set; }

        /// <summary>
        /// Determines the number of licences the product type will generate if is a licence type
        /// </summary>
        public int LiceneCount { get; set; }

        /// <summary>
        /// Individual product vat rate
        /// </summary>
        public decimal VATRate { get; set; }

        /// <summary>
        /// Saving made on this product, to display on website etc
        /// </summary>
        public double Saving { get; set; }

        /// <summary>
        /// Type of product item
        /// </summary>
        public ProductCostItemType ItemType { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Returns the current stock level, for this item in the specified store
        /// </summary>
        /// <param name="storeID">Store where stock level is being checked</param>
        /// <returns></returns>
        public int GetStockLevel(int storeID)
        {
            int Result = 0;

            StockItem item = DAL.FirebirdDB.StockGetItemStock(storeID, this);

            if (item != null)
                Result = item.Available;

            return Result;
        }

        /// <summary>
        /// Soft deletes the item so it is never shown
        /// </summary>
        public void SoftDelete()
        {
            DAL.FirebirdDB.AdminProductCostSoftDelete(this);
        }

        public void PriceSet(Countries.Country country, decimal price)
        {
            switch (country.PriceColumn)
            {
                case 0:
                    Cost1 = price;
                    break;

                case 1:
                    Cost2 = price;
                    break;

                case 2:
                    Cost3 = price;
                    break;

                default:
                    throw new Exception("Invalid Cost Requested");
            }
        }

        public decimal PriceGet(Countries.Country country)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            return PriceGet(country.PriceColumn, country);
        }

        public decimal PriceGet(int priceColumn, Countries.Country country)
        {
            decimal multiplier = country == null ? 1.0m : (decimal)country.Multiplier;

            switch (priceColumn)
            {
                case 0:
                    return Cost1 * multiplier;
                case 1:
                    return Cost2 * multiplier;
                case 2:
                    return Cost3 * multiplier;
                default:
                    throw new Exception("Invalid Cost Requested");
            }
        }

        public void Save()
        {
            SKU = SKU.Trim();
            Size = Size.Trim();
            Barcode = Barcode.Trim();
            AdditionalText = AdditionalText.Trim();

            DAL.FirebirdDB.AdminProductCostUpdate(this);
        }

        public void Delete()
        {
            DAL.FirebirdDB.AdminProductCostDelete(this);
        }

        public ProductCosts FreeProducts()
        {
            return DAL.FirebirdDB.ProductCostsGetFree(this);
        }

        public decimal PriceGetDecimal(int priceColumn, Countries.Country country)
        {
            return PriceGet(priceColumn, country);
        }

        public decimal PriceGetDecimal(Countries.Country country)
        {
            return PriceGet(country);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("ProductCost: {0}; Product ID: {1}", ID, _product.ID);
        }

        #endregion Overridden Methods
    }
}