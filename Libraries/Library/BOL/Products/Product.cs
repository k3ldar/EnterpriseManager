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
 *  File: Product.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

using Library.BOL.Basket;
using Library.BOL.Users;
using Library.BOL.Countries;

namespace Library.BOL.Products
{
    [Serializable]
    public sealed class Product : BaseObject
    {
        #region Private / Protected Members

        private Int64 _id;
        private string _name;
        private string _description;
        private string _seoDescription;
        private string _image;
        private int _popupID;
        private bool _regal;
        private bool _outOfStock;
        private bool _showOnWeb;
        private ProductCosts _productCosts;
        private int _sortOrder;
        private bool _specialOffer;
        private string _sku;
        private bool _bestSeller;
        private bool _newProduct;
        private bool _featured;
        private bool _carousel;
        private ProductGroups _productGroups;
        private ProductGroup _primaryGroup;

        private string _webDescription;
        private string _webFeatures;
        private string _webIngredients;
        private string _webHowToUse;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        /// <summary>
        /// Constructor, used for webservices only
        /// </summary>
        public Product()
        {
            _id = -1;
        }

        public Product(Int64 id, string name)
        {
            _id = id;
            _name = name;
        }

        public Product(Int64 ID, string Name, string Description, bool ShowOnWeb, string Image,
            int SortOrder, bool SpecialOffer, ProductGroup ProductGroup, int PopupID, string SKU,
            bool Regal, bool OutOfStock, bool BestSeller, bool NewProduct, bool Featured, bool Carousel,
            string videoLink, bool preOrder, string features, string ingredients, string howToUse,
            ProductType primaryProductType, bool freeShipping, string pageLink, bool freeProduct)
            : this(ID, Name)
        {
            _description = Description;
            _showOnWeb = ShowOnWeb;
            _image = Image;
            _sortOrder = SortOrder;
            _specialOffer = SpecialOffer;
            _primaryGroup = ProductGroup;
            _popupID = PopupID;
            _sku = SKU;
            _regal = Regal;
            _outOfStock = OutOfStock;
            _bestSeller = BestSeller;
            _newProduct = NewProduct;
            _featured = Featured;
            _carousel = Carousel;

            VideoLink = videoLink;
            PreOrder = preOrder;
            Features = features;
            Ingredients = ingredients;
            HowToUse = howToUse;

            PrimaryProduct = primaryProductType;

            PageLink = pageLink;
            FreeProduct = freeProduct;
            FreeShipping = freeShipping;
        }

        public Product(int ID, string Name, string Description, bool ShowOnWeb, string Image,
            int SortOrder, bool SpecialOffer, ProductGroup ProductGroup, int PopupID, string SKU,
            bool Regal, bool OutOfStock, ProductCosts costs,
            string videoLink, bool preOrder, string features, string ingredients, string howToUse,
            ProductType primaryProductType, bool freeShipping, string pageLink, bool freeProduct)
            : this(ID, Name)
        {
            _description = Description;
            _showOnWeb = ShowOnWeb;
            _image = Image;
            _sortOrder = SortOrder;
            _specialOffer = SpecialOffer;
            _primaryGroup = ProductGroup;
            _popupID = PopupID;
            _sku = SKU;
            _regal = Regal;
            _outOfStock = OutOfStock;
            _productCosts = costs;

            VideoLink = videoLink;
            PreOrder = preOrder;
            Features = features;
            Ingredients = ingredients;
            HowToUse = howToUse;

            PrimaryProduct = primaryProductType;

            PageLink = pageLink;
            FreeProduct = freeProduct;
            FreeShipping = freeShipping;
        }

        #endregion Constructors / Destructors

        #region Properties

        /// <summary>
        /// Primary Product Type
        /// </summary>
        public ProductType PrimaryProduct { get; set; }

        /// <summary>
        /// Link to a video URL to be shown on website
        /// </summary>
        public string VideoLink { get; set; }


        public bool PreOrder { get; set; }

        /// <summary>
        /// Product Features
        /// </summary>
        public string Features { get; set; }

        /// <summary>
        /// Ingredients for product
        /// </summary>
        public string Ingredients { get; set; }

        /// <summary>
        /// Details on how to use the product
        /// </summary>
        public string HowToUse { get; set; }

        public ProductCosts ProductCosts
        {
            get
            {
                if (_productCosts == null)
                    _productCosts = Library.DAL.FirebirdDB.ProductCostsGet(this);

                return (_productCosts);
            }

            set
            {
                _productCosts = value;
            }
        }

        public Int64 ID
        {
            get
            {
                return (_id);
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return (_name);
            }

            set
            {
                _name = value;
            }
        }

        public string NameSEO
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_seoDescription))
                    _seoDescription = Utils.SharedUtils.SEOName(_name);

                return (_seoDescription);
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
                _description = value;
            }
        }

        public string Image
        {
            get
            {
                return (_image);
            }

            set
            {
                _image = value;
            }
        }

        public int PopUpID
        {
            get
            {
                return (_popupID);
            }

            set
            {
                _popupID = value;
            }
        }

        public bool Regal
        {
            get
            {
                return (_regal);
            }

            set
            {
                _regal = value;
            }
        }

        public bool OutOfStock
        {
            get
            {
                return (_outOfStock);
            }

            set
            {
                _outOfStock = value;
            }
        }

        public string SKU
        {
            get
            {
                return (_sku);
            }

            set
            {
                _sku = value;
            }
        }

        public bool ShowOnWebsite
        {
            get
            {
                return (_showOnWeb);
            }

            set
            {
                _showOnWeb = value;
            }
        }

        public int SortOrder
        {
            get
            {
                return (_sortOrder);
            }

            set
            {
                _sortOrder = value;
            }
        }

        public bool SpecialOffer
        {
            get
            {
                return (_specialOffer);
            }

            set
            {
                _specialOffer = value;
            }
        }

        public ProductGroups ProductGroups
        {
            get
            {
                if (_productGroups == null)
                    _productGroups = DAL.FirebirdDB.AdminProductGroupsGet(this);

                ProductGroups Result = _productGroups;
                return (Result);
            }

            set
            {
                _productGroups = value;
            }
        }

        public bool BestSeller
        {
            get
            {
                return (_bestSeller);
            }

            set
            {
                _bestSeller = value;
            }
        }

        public bool NewProduct
        {
            get
            {
                return (_newProduct);
            }

            set
            {
                _newProduct = value;
            }
        }

        public bool Featured
        {
            get
            {
                return (_featured);
            }

            set
            {
                _featured = value;
            }
        }

        public bool Carousel
        {
            get
            {
                return (_carousel);
            }

            set
            {
                _carousel = value;
            }
        }

        public ProductGroup PrimaryGroup
        {
            get
            {
                return (_primaryGroup);
            }

            set
            {
                _primaryGroup = value;
            }
        }


        /// <summary>
        /// Indicates wether the product comes with free shipping or not
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// Custom Web Page, if the product has it's own web page and does not use the generic page
        /// </summary>
        public string PageLink { get; set; }


        public string URL
        {
            get
            {
                if (String.IsNullOrEmpty(PageLink))
                {
                    return (String.Format("/All-Products/Group/{0}/{1}/", PrimaryGroup.SEODescripton, NameSEO));
                }
                else
                {
                    return (PageLink);
                }
            }
        }

        /// <summary>
        /// Indicates the product is free
        /// </summary>
        public bool FreeProduct { get; set; }

        #region Website Only Properties

        public string WebDescription
        {
            get
            {
                if (_webDescription == null)
                {
                    string[] lines = Description.Trim().Replace("\n", String.Empty).Split('\r');
                    string description = String.Empty;

                    foreach (string line in lines)
                    {
                        if (String.IsNullOrEmpty(line.Trim()))
                            continue;

                        description += String.Format("<p>{0}</p>", line.Trim());
                    }

                    _webDescription = Library.Utils.LibUtils.PreProcessPost(description);
                }

                return (_webDescription);
            }
        }

        public string WebFeatures
        {
            get
            {
                if (_webFeatures == null)
                {
                    _webFeatures = String.Empty;
                    string[] lines = Features.Trim().Split('\r');

                    foreach (string line in lines)
                    {
                        if (String.IsNullOrEmpty(line.Trim()))
                            continue;

                        _webFeatures += String.Format("<li>{0}</li>", line.Trim());
                    }
                }

                return (_webFeatures);
            }
        }

        public string WebIngredients
        {
            get
            {
                if (_webIngredients == null)
                    _webIngredients = Ingredients.Trim().Replace("\r", "<br />");

                return (_webIngredients);
            }
        }

        public string WebHowToUse
        {
            get
            {
                if (_webHowToUse == null)
                    _webHowToUse = HowToUse.Trim().Replace("\r", "<br />");

                return (_webHowToUse);
            }
        }


        #endregion Website Only Properties

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Removes the product form all lists without deleting it
        /// </summary>
        public void SoftDelete()
        {
            DAL.FirebirdDB.AdminProductSoftDelete(this);
        }

        public void Delete(User user)
        {
            Utils.LibUtils.CanDelete(user);
            DAL.FirebirdDB.AdminProductDelete(this);
        }

        public void Save(User user)
        {
            Utils.LibUtils.CanUpdate(user);

            Name = Name.Trim();
            Description = Description.Trim();
            SKU = SKU.Trim();
            Features = Features.Trim();
            Ingredients = Ingredients.Trim();
            HowToUse = HowToUse.Trim();
            PageLink = PageLink.Trim();
            VideoLink = VideoLink.Trim();

            DAL.FirebirdDB.AdminProductUpdate(this);
        }

        public void UpdateProductCosts(User user)
        {
            _productCosts = DAL.FirebirdDB.ProductCostsGet(this, user);
        }

        public void UpdateProductCosts(User user, Country country)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string name = String.Format("Product Cost Cache {0} {1}", _id, user == null ? country.CountryCode : user.Country.CountryCode);
                Shared.Classes.CacheItem item = CachedItemGetShort(name);

                if (item == null)
                {
                    item = new Shared.Classes.CacheItem(name, DAL.FirebirdDB.ProductCostsGet(this, user, country));
                    CachedItemAddShort(name, item);
                }

                _productCosts = (ProductCosts)item.Value;
            }
            else
            {
                _productCosts = DAL.FirebirdDB.ProductCostsGet(this, user, country);
            }
        }

        public ProductCost NewProductCostInfo(User user, string productItemName, ProductCostType costType)
        {
            Utils.LibUtils.CanCreate(user);
            _productCosts = null;
            return (DAL.FirebirdDB.AdminProductCostCreate(this, productItemName, costType));
        }

        public void UpdateProductCostInfo(User user)
        {
            _productCosts = DAL.FirebirdDB.ProductCostsGet(this, user);
        }

        public void UpdateProductCostInfo(MemberLevel memberLevel)
        {
            _productCosts = DAL.FirebirdDB.ProductCostsGet(this, memberLevel);
        }

        /// <summary>
        /// determines wether product is visible to all members
        /// </summary>
        /// <returns></returns>
        public bool VisibleToAllUsers()
        {
            decimal Result = 1000000.0m;

            foreach (ProductCost cost in ProductCosts)
            {
                if (cost.MemberLevel == 0 && cost.Cost1 > 0.00m)
                    Result = cost.Cost1;
            }

            return (Result < 1000000.0m);
        }

        public decimal LowestPrice(Currency currency, int priceColumn, Country country)
        {
            decimal Result = 1000000.0m;

            foreach (ProductCost cost in ProductCosts)
            {

                if (cost.PriceGet(priceColumn, country) > 0.00m && cost.PriceGet(priceColumn, country) < Result)
                    Result = cost.PriceGet(priceColumn, country);
            }

            //if the result is still a million then no product cost info so hide.
            if (Result == 1000000.0m)
                ShowOnWebsite = false;

            return (Result);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Product: {0}; Description: {1}", ID, _description));
        }

        #endregion Overridden Methods

    }
}