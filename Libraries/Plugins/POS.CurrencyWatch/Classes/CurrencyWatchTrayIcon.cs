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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CurrencyWatchTrayIcon.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using Shared.Classes;
using Languages;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.CurrencyWatch.Classes
{
    public class CurrencyWatchTrayIcon : TrayNotification
    {
        #region Private Members

        private static object _lockObject = new object();
        private static Dictionary<string, decimal> _previousValues = new Dictionary<string, decimal>();
        private List<CurrencyItem> _currencies = new List<CurrencyItem>();

        #endregion Private Members

        #region Constructors

        public CurrencyWatchTrayIcon(BasePlugin parent)
            : base(parent)
        {
            this.CanBlink = false;
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
        }

        #endregion Constructors

        #region Overridden Methods

        public override string StatusText()
        {
            try
            {
                CurrencyItem activeCurrency = null;

                using (TimedLock.Lock(_lockObject))
                {
                    _currencies = Currencies.LoadCurrencies(AppController.POSFolder(FolderType.Temp, true) + 
                        StringConstants.FILE_YAHOO_CURRENCIES);

                    foreach (CurrencyItem currency in _currencies)
                    {
                        if (AppController.LocalSettings.CurrencyWatching.Contains(currency.ID))
                        {
                            using (TimedLock.Lock(_lockObject))
                            {
                                if (_previousValues.ContainsKey(currency.ID))
                                {
                                    if (_previousValues[currency.ID] != currency.Rate)
                                    {
                                        _previousValues[currency.ID] = currency.Rate;
                                        LastUpdated = DateTime.Now.AddDays(-1); // force update
                                        CanBlink = true;
                                    }
                                }
                            }
                        }

                        if (currency.ID == AppController.LocalSettings.CurrencySelected)
                        {
                            activeCurrency = currency;
                        }
                    }
                }

                if (activeCurrency == null)
                    return (String.Empty);

                return (String.Format(StringConstants.CURRENCY_CONVERSION, 
                    AppController.LocalSettings.CurrencyBase, activeCurrency.Rate, activeCurrency.ID,
                    activeCurrency.LastMovement == CurrencyMovement.Same ? StringConstants.CURRENCY_SAME : 
                    activeCurrency.LastMovement == CurrencyMovement.Up ? StringConstants.CURRENCY_UP : 
                    StringConstants.CURRENCY_DOWN));
            }
            catch
            {
                return (String.Empty);
            }
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayCurrencyWatch);
        }

        public override void DoubleClick()
        {
            CurrencyWatchUpdaterThread currencyThread = (CurrencyWatchUpdaterThread)ThreadManager.Find(StringConstants.THREAD_NAME_CURRENCY_CONVERSION);
            currencyThread.ForceRun();            
        }

        public override string HintText()
        {
            try
            {
                CanBlink = false;
                string Result = String.Empty;

                using (TimedLock.Lock(_lockObject))
                {
                    _currencies = Currencies.LoadCurrencies(AppController.POSFolder(FolderType.Temp, true) + StringConstants.FILE_YAHOO_CURRENCIES);

                    foreach (CurrencyItem currency in _currencies)
                    {
                        if (AppController.LocalSettings.CurrencyWatching.Contains(currency.ID))
                        {
                            if (String.IsNullOrEmpty(Result))
                            {
                                Result = String.Format(StringConstants.CURRENCY_CONVERSION,
                                    AppController.LocalSettings.CurrencyBase, currency.Rate, currency.ID,
                                    currency.LastMovement == CurrencyMovement.Same ? StringConstants.CURRENCY_SAME : currency.LastMovement == CurrencyMovement.Up ? StringConstants.CURRENCY_UP : StringConstants.CURRENCY_DOWN);
                            }
                            else
                            {
                                Result += String.Format(StringConstants.SYMBOL_CRLF + StringConstants.CURRENCY_CONVERSION,
                                    AppController.LocalSettings.CurrencyBase, currency.Rate, currency.ID,
                                    currency.LastMovement == CurrencyMovement.Same ? StringConstants.CURRENCY_SAME : currency.LastMovement == CurrencyMovement.Up ? StringConstants.CURRENCY_UP : StringConstants.CURRENCY_DOWN);
                            }
                        }
                    }
                }

                return (Result);
            }
            catch
            {
                return (String.Empty);
            }
        }

        public override bool CanLoad()
        {

            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override void Load()
        {
            using (TimedLock.Lock(_lockObject))
            {
                _currencies = Currencies.LoadCurrencies(AppController.POSFolder(FolderType.Temp, true) + 
                    StringConstants.FILE_YAHOO_CURRENCIES);

                foreach (CurrencyItem currency in _currencies)
                {
                    if (AppController.LocalSettings.CurrencyWatching.Contains(currency.ID))
                    {
                        _previousValues.Add(currency.ID, currency.Rate);
                    }

                }

                CanBlink = false;
            }
        }

        #endregion Overridden Methods

        #region Internal Methods

        internal void SettingsUpdated()
        {
            // cancel existing thread
            ThreadManager.Cancel(StringConstants.THREAD_NAME_CURRENCY_CONVERSION);

            // reload the thread
            CurrencyWatchUpdaterThread currencyThread = new CurrencyWatchUpdaterThread(AppController.LocalSettings.CurrencyBase);
            currencyThread.AfterUpdate += CurrencyUpdateThread_AfterUpdate;

            ThreadManager.ThreadStart(
                currencyThread,
                StringConstants.THREAD_NAME_CURRENCY_CONVERSION,
                System.Threading.ThreadPriority.Lowest);
        }

        internal string ButtonText(ref string header)
        {
            try
            {
                string Result = String.Empty;

                header = String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE,
                1, AppController.LocalSettings.CurrencyBase);
                Result += StringConstants.SYMBOL_CRLF_DOUBLE;

                using (TimedLock.Lock(_lockObject))
                {

                    foreach (CurrencyItem currency in _currencies)
                    {
                        if (AppController.LocalSettings.CurrencyWatching.Contains(currency.ID))
                        {
                            Result += String.Format(StringConstants.CURRENCY_CONVERSION_ALT,
                                currency.LastMovement == CurrencyMovement.Same ? StringConstants.CURRENCY_SAME : currency.LastMovement == CurrencyMovement.Up ? StringConstants.CURRENCY_UP : StringConstants.CURRENCY_DOWN,
                                currency.ID, currency.Rate);
                            Result += StringConstants.SYMBOL_CRLF;
                        }
                    }
                }

                return (Result);
            }
            catch
            {
                return (String.Empty);
            }
        }

        /// <summary>
        /// Force the text to update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void CurrencyUpdateThread_AfterUpdate(object sender, EventArgs e)
        {
            LastUpdated = DateTime.Now.AddDays(-1);
            StatusText();
        }

        #endregion Internal Methods
    }
}
