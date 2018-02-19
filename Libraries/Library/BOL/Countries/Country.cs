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
 *  File: Country.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

using Library.BOL.USAStates;
using Library.BOL.CashDrawer;

namespace Library.BOL.Countries
{
    [Serializable]
    public sealed class Country : BaseObject
    {
        #region Private / Protected Members

        private int _id;
        private string _countryCode;
        private string _name;
        private int _sortOrder;
        private decimal _shippingCosts;
        private bool _showOnWeb;
        private string _autoRedirect;
        //private string _culture;
        private double _conversionRate;
        private double _vatRate;
        private bool _showPriceData;
        private double _multiplier;
        private string _currencySymbol;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public Country(int ID, string CountryCode, string Name, int SortOrder, decimal ShippingCosts, bool ShowOnWeb,
            string AutoRedirect, string Culture, double ConversionRate, double VATRate, bool ShowPriceData, double CostMultiplier,
            int priceColumn, bool canLocalize, AddressOptions addressSettings, string currencySymbol, bool allowVATRemoval,
            bool allowFreeSpend, double freeSpendAmount, bool allowCurrencyConversion, string defaultCurrency,
            string localizedCulture, string localizedLanguage)
        {
            _id = ID;
            _countryCode = CountryCode;
            _name = Name;
            _sortOrder = SortOrder;
            _shippingCosts = ShippingCosts;
            _showOnWeb = ShowOnWeb;
            _autoRedirect = AutoRedirect;
            //_culture = Culture;
            _conversionRate = ConversionRate;
            _vatRate = VATRate;
            _showPriceData = ShowPriceData;
            _multiplier = CostMultiplier;
            PriceColumn = priceColumn;
            CanLocalize = canLocalize;

            if (String.IsNullOrEmpty(currencySymbol))
            {
                CustomSybmol = false;
                CultureInfo cultureInfo = new CultureInfo(DAL.DALHelper.DefaultCulture);
                _currencySymbol = cultureInfo.NumberFormat.CurrencySymbol;
            }
            else
            {
                _currencySymbol = currencySymbol;
                CustomSybmol = true;
            }

            AllowFreeSpend = allowFreeSpend;
            FreeSpendAmount = freeSpendAmount;
            AllowCurrencyConversion = allowCurrencyConversion;
            DefaultCurrency = defaultCurrency;
            AddressSettings = addressSettings;
            LocalizedCulture = localizedCulture;
            LocalizedLanguage = localizedLanguage;
        }

        #endregion Constructors / Destructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID
        {
            get
            {
                return (_id);
            }
        }

        public string CountryCode
        {
            get
            {
                return (_countryCode);
            }
        }

        public double Multiplier
        {
            get
            {
                return (_multiplier);
            }

            set
            {
                _multiplier = value;
            }
        }

        public string Name
        {
            get
            {
                return (_name);
            }
        }

        public int SortOrder
        {
            get
            {
                return (-_sortOrder);
            }

            set
            {
                _sortOrder = value;
            }
        }

        public decimal ShippingCosts
        {
            get
            {
                return (_shippingCosts);
            }

            set
            {
                _shippingCosts = value;
            }
        }

        public bool ShowOnWeb
        {
            get
            {
                return (_showOnWeb);
            }
        }

        public string AutoRedirect
        {
            get
            {
                return (_autoRedirect);
            }
        }

        //[Obsolete("This is now obsolete and the culture should be gotten from the active currency culture")]
        //public string Culture
        //{
        //    get
        //    {
        //        return (_culture);
        //    }
        //}

        public double ConversionRate
        {
            get
            {
                return (_conversionRate);
            }

            set
            {
                _conversionRate = value;
            }
        }

        public double VATRate
        {
            get
            {
                return (_vatRate);
            }

            set
            {
                _vatRate = value;
            }
        }

        public bool ShowPrices
        {
            get
            {
                return (_showPriceData);
            }

            set
            {
                _showPriceData = value;
            }
        }

        /// <summary>
        /// Indicates which price data to use
        /// 
        /// 0 = english
        /// 1 = international
        /// 2 = future use
        /// </summary>
        public int PriceColumn { get; set; }

        /// <summary>
        /// Indicates wether the country is localizable or not
        /// </summary>
        public bool CanLocalize { get; set; }

        /// <summary>
        /// Culture to be used for localized country
        /// </summary>
        public string LocalizedCulture { get; set; }

        public AddressOptions AddressSettings { get; set; }

        /// <summary>
        /// Determines wether a custom currency symbol is being used
        /// </summary>
        public bool CustomSybmol { get; private set; }

        /// <summary>
        /// currency symbol to be used for this country
        /// </summary>
        public string CurrencySymbol
        {
            get
            {
                if (String.IsNullOrEmpty(_currencySymbol))
                {

                }

                return (_currencySymbol);
            }

            set
            {
                _currencySymbol = value;
            }
        }

        /// <summary>
        /// If true then once the free spend amount is reached then shipping is free
        /// </summary>
        public bool AllowFreeSpend { get; set; }

        /// <summary>
        /// The amount, in local currency for a free shipping if allow free spend is true
        /// </summary>
        public double FreeSpendAmount { get; set; }

        /// <summary>
        /// If true then currency conversion is allowed, if false then currency conversion is 
        /// not allowed, except when the default currency is not allowed, in that case currency 
        /// conversion will take place using the default currency for the POS
        /// </summary>
        public bool AllowCurrencyConversion { get; set; }

        /// <summary>
        /// This is the default currency for the country, if the POS payment method accepts this 
        /// currency then that will be used, otherwise the default currency for the POS will be used
        /// and the values will be converted to that currency
        /// </summary>
        public string DefaultCurrency { get; set; }

        /// <summary>
        /// Language display name
        /// </summary>
        public string LocalizedLanguage { get; set; }

        /// <summary>
        /// Retrieves all currency denominations for a country
        /// </summary>
        public CashDenominations CurrencyDenominations
        {
            get
            {
                return (DAL.FirebirdDB.CashDenominationsGet(this));
            }
        }

        #endregion Properties

        #region Public Methods


        /// <summary>
        /// Determines if a specific option is set for the address
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>true if the option is set, otherwise false</returns>
        public bool HasOption(AddressOptions option)
        {
            return (((AddressSettings & option) == option));
        }

        /// <summary>
        /// Determines wether price data is shown or not
        /// </summary>
        /// <returns></returns>
        public bool ShowPriceData()
        {
            return (_showPriceData);
        }

        /// <summary>
        /// Save's country information/data
        /// </summary>
        public override void Save()
        {
            DAL.FirebirdDB.CountrySet(this);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Country: {0}; Country Code: {1}; Country Name: {2}; Price Column: {3}", ID, _countryCode, _name, PriceColumn));
        }

        #endregion Overridden Methods

    }
}