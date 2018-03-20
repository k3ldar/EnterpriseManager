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
 *  File: LocalizedLanguages.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Threading;

using Microsoft.AspNetCore.Http;

using Shared;
using Shared.Classes;

using lib = Library;
using Library.BOL.Websites;
using Library.BOL.Basket;
using Library.BOL.Countries;

using Website.Library.Core.Classes;
using Website.Library.Core.Interfaces;

namespace Website.Library.Core.Services
{
    public sealed class LocalizedLanguages : ILocalizedLanguages
    {
        #region Private Members

        private List<Country> _countries = new List<Country>();
        private readonly ILogging _logging;

        #endregion Private Members

        #region Constructors

        public LocalizedLanguages(ILogging logging)
        {
            _logging = logging ?? throw new ArgumentNullException(nameof(logging));
        }

        #endregion Constructors

        #region Properties

        #endregion Properties

        #region Methods

        public int GetPriceColumn(HttpContext context, UserSession userSession)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (userSession == null)
                throw new ArgumentNullException(nameof(userSession));

            int Result = ((LocalWebSessionData)userSession.Tag).PriceColumn;
            RaiseSelectPriceColumn(context, userSession, Result);

            return (Result);
        }

        public void ClearCountries()
        {
            using (TimedLock.Lock(_countries))
            {
                _countries.Clear();
            }
        }

        public string GetLanguageLinks()
        {
            string Result = String.Empty;

            if (!WebsiteSettings.Languages.Active)
                return (Result);

            if (_countries.Count == 0)
            {
                using (TimedLock.Lock(_countries))
                {
                    Countries localizedCountries = Countries.GetLocalized();

                    foreach (Country country in localizedCountries)
                    {
                        _countries.Add(country);
                    }
                }
            }


            foreach(Country country in _countries)
            {
                Result += String.Format("<li><a href=\"?country={0}\">{1}</a></li>", 
                    country.CountryCode, country.LocalizedLanguage);
            }

            return (Result);
        }

        public string SetLanguage(HttpContext context, UserSession userSession, Uri uri, Country country,
            Currency newCurrency, bool allowRedirect = true)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (userSession == null)
                throw new ArgumentNullException(nameof(userSession));

            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            try
            { 
                LocalWebSessionData localData = (LocalWebSessionData)userSession.Tag;

                bool languageSet = localData.Culture != null;

                if ((!WebsiteSettings.Languages.Active && languageSet) || WebsiteSettings.StaticWebSite)
                    return (String.Empty);

                bool changedSettings = !languageSet ||
                    (
                        localData.CountryCode != country.CountryCode ||
                        ((newCurrency != null && localData.Currency != null) &&
                            (
                                (localData.Currency.ID != newCurrency.ID)
                            ))
                     );

                if (changedSettings)
                {
                    if (WebsiteSettings.WebsiteCultureOverride)
                    {
                        localData.Culture = WebsiteSettings.Languages.WebsiteCulture.Name;
                    }
                    else
                    {
                        localData.Culture = country.LocalizedCulture;
                    }

                    if (newCurrency != null)
                        localData.Currency = newCurrency;

                    localData.PriceColumn = RaiseSelectPriceColumn(context, userSession,
                        newCurrency == null ? country.PriceColumn : newCurrency.PriceColumn);

                    localData.UserCountry = country;

                    localData.Basket.Currency = newCurrency ?? localData.Currency;

                    localData.Basket.Country = country;

                    localData.Basket.FreeShipping = WebsiteSettings.ShoppingCart.FreeShippingAllow;

                    localData.Basket.Reset(localData.PriceColumn);

                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(country.LocalizedCulture);

                    Thread.CurrentThread.CurrentUICulture = cultureInfo;

                    string referer = context.Request.Headers["Referer"].ToString();

                    if (!String.IsNullOrEmpty(referer))
                    {
                        string currentPath = String.Empty;

                        currentPath = referer;

                        if (allowRedirect)
                            return (uri.ToString() + currentPath);
                    }
                }
            }
            catch (Exception err)
            {
                _logging.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (String.Empty);
        }

        public string SetLanguage(HttpContext context, UserSession userSession, Uri uri)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (userSession == null)
                throw new ArgumentNullException(nameof(userSession));

            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            Country selectedCountry = ((LocalWebSessionData)userSession.Tag).UserCountry;

            if (selectedCountry == null)
                selectedCountry = Countries.Get(WebsiteSettings.Languages.DefaultCountrySettings);

            string redirect = SetLanguage(context, userSession, uri, selectedCountry, null, true);

            if (!String.IsNullOrEmpty(redirect))
                return (redirect);

            if (WebsiteSettings.WebsiteCultureOverride)
            {
                Thread.CurrentThread.CurrentUICulture = WebsiteSettings.Languages.WebsiteCulture;
            }
            else if (selectedCountry.LocalizedCulture.ToLower() != Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(
                     selectedCountry.LocalizedCulture);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }

            return (String.Empty);
        }

        #endregion Methods

        #region Internal Methods

        public int RaiseSelectPriceColumn(HttpContext context, UserSession session, int priceColumn)
        {
            int Result = priceColumn;

            if (OnSelectPriceColumn != null)
            {
                Classes.PriceColumnOverrideArgs args = new Classes.PriceColumnOverrideArgs(context, priceColumn, session.SessionID, false, session);

                OnSelectPriceColumn(null, args);

                if (args.OverridePriceColumn)
                    return (args.PriceColumn);
            }

            return (Result);
        }

        #endregion Internal Methods

        #region Events

        /// <summary>
        /// Allows clients to override the price column in use
        /// </summary>
        public event Classes.PriceColumnOverrideDelegate OnSelectPriceColumn;

        #endregion Events

    }
}
