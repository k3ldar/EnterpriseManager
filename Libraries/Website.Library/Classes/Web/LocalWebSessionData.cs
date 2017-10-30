using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Users;

namespace Website.Library.Classes
{
    /// <summary>
    /// Class to hold local web session data for each user
    /// </summary>
    [Serializable]
    public class LocalWebSessionData
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

        #endregion Properties
    }
}
