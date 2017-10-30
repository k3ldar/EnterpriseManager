using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Affiliate
{
    [Serializable]
    public sealed class AffiliateProduct : BaseObject
    {
        #region Constructors

        public AffiliateProduct (string sku, string title, decimal price, decimal discountPrice, 
            string description, string availability, string imageLink, string productLink)
        {
            SKU = sku;
            Title = title;
            Price = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            DiscountPrice = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
            Description = description;
            Availability = availability;
            ImageLink = imageLink;
            ProductLink = productLink;
        }

        #endregion Constructors

        #region Properties

        public string SKU { get; private set; }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public decimal DiscountPrice { get; private set; }

        public string Description { get; private set; }

        public string Availability { get; private set; }

        public string ImageLink { get; private set; }

        public string ProductLink { get; private set; }

        #endregion Properties

    }
}
