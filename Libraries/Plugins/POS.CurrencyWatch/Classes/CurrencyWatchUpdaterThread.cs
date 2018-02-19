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
 *  File: CurrencyWatchUpdaterThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using POS.Base.Classes;
using Shared.Classes;

#pragma warning disable IDE1005

namespace POS.CurrencyWatch.Classes
{
    public class CurrencyWatchUpdaterThread : ThreadManager
    {
        #region Constants

        private const string UPDATE_URL = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20" +
            "where%20pair%20in%20({0})&env=store://datatables.org/alltableswithkeys";

        #endregion Constants

        #region Private Members

        private string _baseCurrency;

        #endregion Private Members

        #region Constructors

        public CurrencyWatchUpdaterThread (string baseCurrency)
            : base(null, new TimeSpan(0, AppController.LocalSettings.CurrencyWatchUpdateMinutes, 0))
        {
            this.HangTimeout = 70;
            _baseCurrency = baseCurrency;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            string[] allCurrencies = StringConstants.YAHOO_CURRENCIES.Split(StringConstants.SYMBOL_SEMI_COLON_CHAR);
            string currencies = String.Empty;

            foreach (string currency in allCurrencies)
            {
                if (String.IsNullOrEmpty(currency))
                    continue;

                string[] currencyNameSymbol = currency.Split(StringConstants.SYMBOL_HASH_CHAR);

                if (currencyNameSymbol[0] != _baseCurrency)
                {
                    if (currencies.Length == 0)
                    {
                        currencies = String.Format(StringConstants.YAHOO_CURRENCY_REQUEST, _baseCurrency, currencyNameSymbol[0]);
                    }
                    else
                    {
                        currencies += String.Format(StringConstants.YAHOO_CURRENCY_REQUEST_SUBSEQUENT, _baseCurrency, currencyNameSymbol[0]);
                    }
                }
            }

            Shared.FileDownload.Download(String.Format(UPDATE_URL, currencies),
                AppController.POSFolder(FolderType.Temp, true) + StringConstants.FILE_YAHOO_CURRENCIES_TEMP, 100, 250);

            string fileContents = Shared.Utilities.FileRead(AppController.POSFolder(FolderType.Temp, true) + 
                StringConstants.FILE_YAHOO_CURRENCIES_TEMP, false);

            if (!String.IsNullOrEmpty(fileContents))
                Shared.Utilities.FileWrite(AppController.POSFolder(FolderType.Temp, true) + 
                    StringConstants.FILE_YAHOO_CURRENCIES, fileContents);

            try
            {
                System.IO.File.Delete(AppController.POSFolder(FolderType.Temp, true) +
                    StringConstants.FILE_YAHOO_CURRENCIES_TEMP);
            }
            catch (System.IO.IOException)
            {
                //ignore
            }
            catch
            {
                throw;
            }
            if (AfterUpdate != null)
                AfterUpdate(this, EventArgs.Empty);

            return (true);
        }

        #endregion Overridden Methods

        #region Internal Methods


        /// <summary>
        /// Forces the thread to execute
        /// </summary>
        internal void ForceRun()
        {
            LastRun = DateTime.Now.AddDays(-1);
        }


        #endregion Internal Methods

        #region Internal Events

        /// <summary>
        /// Event raised when the currency data is updated
        /// </summary>
        internal event EventHandler AfterUpdate;

        #endregion Internal Events
    }
}
