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
 *  File: CurrencyItems.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

using Shared;

namespace POS.CurrencyWatch.Classes
{
    public sealed class CurrencyItem
    {
        #region Private Members

        public List<decimal> _previousValues = new List<decimal>();
        public decimal _rate = 0.00m;

        #endregion Private Members

        #region Properties

        public string ID { get; set; }

        public string Name { get; set; }

        public decimal Rate 
        { 
            get
            {
                return (_rate);
            }

            set
            {
                if (_rate != 0.0m)
                {
                    if (_rate < value)
                        LastMovement = CurrencyMovement.Up;
                    else if (_rate > value)
                        LastMovement = CurrencyMovement.Down;
                    else
                        LastMovement = CurrencyMovement.Same;

                    _previousValues.Add(_rate);
                }

                _rate = value;
            }
        }

        public string Date { get; set; }

        public string Time { get; set; }

        public decimal Ask { get; set; }

        public decimal Bid { get; set; }

        public CurrencyMovement LastMovement { get; private set; }

        #endregion Properties
    }

    public enum CurrencyMovement {  Same, Up, Down }

    public static class Currencies
    {
        #region Private Members

        /// <summary>
        /// Static list of currencies
        /// </summary>
        private static List<CurrencyItem> _currencies = null;

        #endregion Private Members

        #region Public Methods

        /// <summary>
        /// Loads currency data, or updates the existing currency data
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of CurrencyItem's</returns>
        public static List<CurrencyItem> LoadCurrencies(string fileName)
        {
            CultureInfo culture = new CultureInfo("en-US");
            List<CurrencyItem> currencyItems;
            try
            {
                XDocument xdoc = XDocument.Load(fileName);
                currencyItems = xdoc.Root.Element("results").Elements("rate")
                                    .Select(d => new CurrencyItem
                                    {
                                        ID = ((string)d.Attribute("id")).Substring(3),
                                        Name = (string)d.Element("Name"),
                                        Rate = Utilities.StrToDecimal((string)d.Element("Rate"), 0.0m, culture),
                                        Date = (string)d.Element("Date"),
                                        Time = (string)d.Element("Time"),
                                        Ask = Utilities.StrToDecimal((string)d.Element("Ask"), 0.0m, culture),
                                        Bid = Utilities.StrToDecimal((string)d.Element("Bid"), 0.0m, culture)
                                    }).ToList();
            }
            finally
            {
                culture = null;
            }

            if (_currencies == null)
            {
                // list initially obtained
                _currencies = currencyItems;
            }
            else
            {
                // update the existing items
                foreach (CurrencyItem item in _currencies)
                {
                    UpdateCurrencyValue(item, currencyItems);
                }
            }

            return (_currencies);
        }

        #endregion Public Methods

        #region Private Methods

        private static void UpdateCurrencyValue(CurrencyItem item, List<CurrencyItem> updatedList)
        {
            foreach (CurrencyItem updatedItem in updatedList)
            {
                if (updatedItem.ID == item.ID)
                {
                    if (item.Rate != updatedItem.Rate)
                        item.Rate = updatedItem.Rate;

                    item.Ask = updatedItem.Ask;
                    item.Bid = updatedItem.Bid;
                    item.Date = updatedItem.Date;
                    item.Time = updatedItem.Time;
                    break;
                }
            }
        }

        #endregion Private Methods
    }
}
