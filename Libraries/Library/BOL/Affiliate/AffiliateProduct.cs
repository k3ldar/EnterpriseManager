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
 *  File: AffiliateProduct.cs
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
