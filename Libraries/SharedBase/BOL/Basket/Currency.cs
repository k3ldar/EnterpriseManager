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
 *  File: Currency.cs
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

namespace SharedBase.BOL.Basket
{
    [Serializable]
    public sealed class Currency : BaseObject
    {
        #region Private Members

        private decimal _multiplier;

        #endregion Private Members

        #region Constructors

        public Currency (int id, bool isActive, string currencyCode, string culture, string currencySymbol, 
            int priceColumn, decimal conversionRate, decimal multiplier)
        {
#if DEBUG
            System.Diagnostics.Debug.Assert(multiplier != 0);
#endif
            ID = id;
            IsActive = isActive;
            CurrencyCode = currencyCode;
            Culture = culture;
            CurrencySymbol = currencySymbol;

            string actualCurrencySymbol = SharedBase.Utils.SharedUtils.GetCurrencySymbol(Culture);

            if (String.IsNullOrEmpty(CurrencySymbol))
                CurrencySymbol = actualCurrencySymbol;

            IsCustomSybmol = CurrencySymbol != actualCurrencySymbol;
            PriceColumn = priceColumn;
            ConversionRate = conversionRate;
            Multiplier = multiplier;
        }

        #endregion Constructors

        #region Public Methods


        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("id: {0}; IsActive: {1}; CurrencyCode: {2}; Culture: {3}; CurrencySymbol: {4}", ID, IsActive, CurrencyCode, Culture, CurrencySymbol);
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Indicates wether active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Culture for currency
        /// </summary>
        public string Culture { get; private set; }

        /// <summary>
        /// Unique currency code
        /// </summary>
        public string CurrencyCode { get; private set; }

        /// <summary>
        /// Currency Symbol used
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Determines wether the currency symbol is the default one or wether it has been overridden
        /// </summary>
        public bool IsCustomSybmol { get; private set; }

        /// <summary>
        /// Price column used by currency
        /// </summary>
        public int PriceColumn { get; set; }

        /// <summary>
        /// if other than 1.0 then the final amount is multiplied by this amount
        /// 
        /// This will support currencies which don't fall into one of the three price brackets
        /// allowed by the system
        /// </summary>
        public decimal ConversionRate { get; set; }

        /// <summary>
        /// if value is set then the final currency amount is multiplied by this value
        /// 
        /// Artificially inflate/deflate prices
        /// </summary>
        public decimal Multiplier 
        {
            get
            {
                return _multiplier;
            }

            set
            {
                _multiplier = value;

                if (_multiplier == 0.0m)
                    _multiplier = 1.0m;
            }
        }

        #endregion Properties
    }
}
