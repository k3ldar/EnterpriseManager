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

        private Int64 _ID;
        private string _Name;
        private string _Description;
        private string _Image;
        private int _PopupID;
        private bool _Regal;
        private bool _OutOfStock;
        private bool _ShowOnWeb;
        private ProductCosts _ProductCosts;
        private int _SortOrder;
        private bool _SpecialOffer;
        private string _SKU;
        private bool _BestSeller;
        private bool _NewProduct;
        private bool _Featured;
        private bool _Carousel;
        private ProductGroups _ProductGroups;
        private ProductGroup _PrimaryGroup;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        /// <summary>
        /// Constructor, used for webservices only
        /// </summary>
        public Product()
        {
            _ID = -1;
        }

        public Product(Int64 ID, string Name, string Description, bool ShowOnWeb, string Image,
            int SortOrder, bool SpecialOffer, ProductGroup ProductGroup, int PopupID, string SKU,
            bool Regal, bool OutOfStock, bool BestSeller, bool NewProduct, bool Featured, bool Carousel,
            string videoLink, bool preOrder, string features, string ingredients, string howToUse,
            ProductType primaryProductType, bool freeShipping, string pageLink, bool freeProduct)
        {
            _ID = ID;
            _Name = Name;
            _Description = Description;
            _ShowOnWeb = ShowOnWeb;
            _Image = Image;
            _SortOrder = SortOrder;
            _SpecialOffer = SpecialOffer;
            _PrimaryGroup = ProductGroup;
            _PopupID = PopupID;
            _SKU = SKU;
            _Regal = Regal;
            _OutOfStock = OutOfStock;
            _BestSeller = BestSeller;
            _NewProduct = NewProduct;
            _Featured = Featured;
            _Carousel = Carousel;

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
        {
            _ID = ID;
            _Name = Name;
            _Description = Description;
            _ShowOnWeb = ShowOnWeb;
            _Image = Image;
            _SortOrder = SortOrder;
            _SpecialOffer = SpecialOffer;
            _PrimaryGroup = ProductGroup;
            _PopupID = PopupID;
            _SKU = SKU;
            _Regal = Regal;
            _OutOfStock = OutOfStock;
            _ProductCosts = costs;

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
                if (_ProductCosts == null)
                    _ProductCosts = Library.DAL.FirebirdDB.ProductCostsGet(this);

                return (_ProductCosts);
            }

            set
            {
                _ProductCosts = value;
            }
        }

        public Int64 ID
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

        public string Description
        {
            get
            {
                return (_Description);
            }

            set
            {
                _Description = value;
            }
        }

        public string Image
        {
            get
            {
                return (_Image);
            }

            set
            {
                _Image = value;
            }
        }

        public int PopUpID
        {
            get
            {
                return (_PopupID);
            }

            set
            {
                _PopupID = value;
            }
        }

        public bool Regal
        {
            get
            {
                return (_Regal);
            }

            set
            {
                _Regal = value;
            }
        }

        public bool OutOfStock
        {
            get
            {
                return (_OutOfStock);
            }

            set
            {
                _OutOfStock = value;
            }
        }

        public string SKU
        {
            get
            {
                return (_SKU);
            }

            set
            {
                _SKU = value;
            }
        }

        public bool ShowOnWebsite
        {
            get
            {
                return (_ShowOnWeb);
            }

            set
            {
                _ShowOnWeb = value;
            }
        }

        public int SortOrder
        {
            get
            {
                return (_SortOrder);
            }

            set
            {
                _SortOrder = value;
            }
        }

        public bool SpecialOffer
        {
            get
            {
                return (_SpecialOffer);
            }

            set
            {
                _SpecialOffer = value;
            }
        }

        public ProductGroups ProductGroups
        {
            get
            {
                if (_ProductGroups == null)
                    _ProductGroups = DAL.FirebirdDB.AdminProductGroupsGet(this);

                ProductGroups Result = _ProductGroups;
                return (Result);
            }

            set
            {
                _ProductGroups = value;
            }
        }

        public bool BestSeller
        {
            get
            {
                return (_BestSeller);
            }

            set
            {
                _BestSeller = value;
            }
        }

        public bool NewProduct
        {
            get
            {
                return (_NewProduct);
            }

            set
            {
                _NewProduct = value;
            }
        }

        public bool Featured
        {
            get
            {
                return (_Featured);
            }

            set
            {
                _Featured = value;
            }
        }

        public bool Carousel
        {
            get
            {
                return (_Carousel);
            }

            set
            {
                _Carousel = value;
            }
        }

        public ProductGroup PrimaryGroup
        {
            get
            {
                return (_PrimaryGroup);
            }

            set
            {
                _PrimaryGroup = value;
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
                    return (String.Format("/Products/Index.aspx?ID={0}", ID));
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
            _ProductCosts = DAL.FirebirdDB.ProductCostsGet(this, user);
        }

        public void UpdateProductCosts(User user, Country country)
        {
            if (DAL.DALHelper.AllowCaching)
            {
                string name = String.Format("Product Cost Cache {0} {1}", _ID, user == null ? country.CountryCode : user.Country.CountryCode);
                Shared.Classes.CacheItem item = CachedItemGetShort(name);

                if (item == null)
                {
                    item = new Shared.Classes.CacheItem(name, DAL.FirebirdDB.ProductCostsGet(this, user, country));
                    CachedItemAddShort(name, item);
                }

                _ProductCosts = (ProductCosts)item.Value;
            }
            else
            {
                _ProductCosts = DAL.FirebirdDB.ProductCostsGet(this, user, country);
            }
        }

        public ProductCost NewProductCostInfo(User user, string productItemName, ProductCostType costType)
        {
            Utils.LibUtils.CanCreate(user);
            _ProductCosts = null;
            return (DAL.FirebirdDB.AdminProductCostCreate(this, productItemName, costType));
        }

        public void UpdateProductCostInfo(User user)
        {
            _ProductCosts = DAL.FirebirdDB.ProductCostsGet(this, user);
        }

        public void UpdateProductCostInfo(MemberLevel memberLevel)
        {
            _ProductCosts = DAL.FirebirdDB.ProductCostsGet(this, memberLevel);
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
            return (String.Format("Product: {0}; Description: {1}", ID, _Description));
        }

        #endregion Overridden Methods

    }
}