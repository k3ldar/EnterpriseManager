using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Basket
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

            string actualCurrencySymbol = Library.Utils.SharedUtils.GetCurrencySymbol(Culture);

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
            return (String.Format("id: {0}; IsActive: {1}; CurrencyCode: {2}; Culture: {3}; CurrencySymbol: {4}", ID, IsActive, CurrencyCode, Culture, CurrencySymbol));
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
                return (_multiplier);
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
