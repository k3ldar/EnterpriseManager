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
 *  File: LocalWebSessionData.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Users;

namespace Website.Library.Core.Classes
{
    /// <summary>
    /// Class to hold local web session data for each user
    /// </summary>
    [Serializable]
    public sealed class LocalWebSessionData
    {
        #region Private Members

        private int _priceColumn;

        #endregion Private Members

        #region Constructors

        public LocalWebSessionData()
        {
            LoggedIn = false;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Users shopping basket
        /// </summary>
        public ShoppingBasket Basket { get; set; }

        /// <summary>
        /// User Account for logged on user
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Current users country
        /// </summary>
        public Country UserCountry { get; set; }

        /// <summary>
        /// Current Users Country Code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Users selected price column
        /// </summary>
        public int PriceColumn
        {
            get
            {
                return (_priceColumn);
            }

            set
            {
                _priceColumn = value;
            }
        }

        /// <summary>
        /// Affiliate ID
        /// </summary>
        public string AffiliateID { get; set; }

        /// <summary>
        /// User defined VAT Rate
        /// </summary>
        public double VATRate { get; set; }

        /// <summary>
        /// Delivery Address ID
        /// </summary>
        public long DeliveryAddressID { get; set; }

        /// <summary>
        /// Member Level
        /// </summary>
        public int MemberLevel { get; set; }

        /// <summary>
        /// Users culture
        /// </summary>
        //public CultureInfo Culture { get; set; }
#warning tidy up
        public string Culture { get; set; }

        /// <summary>
        /// Discount Coupon Name
        /// </summary>
        public string DiscountCoupon { get; set; }

        /// <summary>
        /// User is logged in
        /// </summary>
        public bool LoggedIn { get; set; }


        public Currency Currency { get; set; }

        #endregion Properties
    }
}
