using System;

using POS.Base.Classes;
using Shared.Classes;

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

            string fileContents = Shared.Utilities.FileRead(AppController.POSFolder(FolderType.Temp, true) + StringConstants.FILE_YAHOO_CURRENCIES_TEMP, false);

            if (!String.IsNullOrEmpty(fileContents))
                Shared.Utilities.FileWrite(AppController.POSFolder(FolderType.Temp, true) + StringConstants.FILE_YAHOO_CURRENCIES, fileContents);

            System.IO.File.Delete(AppController.POSFolder(FolderType.Temp, true) + StringConstants.FILE_YAHOO_CURRENCIES_TEMP);

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
