using System;
using System.Collections.Generic;
using System.Threading;

using Shared;
using Shared.Classes;

using lib = Library;
using Library.BOL.Websites;
using Library.BOL.Basket;
using Library.BOL.Countries;

namespace Website.Library.Classes
{
    public static class LocalizedLanguages
    {
        #region Private Members

        private static List<Country> _countries = new List<Country>();

        #endregion Private Members

        #region Properties

        #endregion Properties

        #region Methods

        public static int GetPriceColumn(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request)
        {
            UserSession session = (UserSession)Session[lib.StringConsts.SESSION_NAME_USER_SESSION];
            int Result = ((LocalWebSessionData)session.Tag).PriceColumn;
            RaiseSelectPriceColumn(Session, Request, (UserSession)Session[lib.StringConsts.SESSION_NAME_USER_SESSION], Result);
            return (Result);
        }

        public static void ClearCountries()
        {
            using (TimedLock.Lock(_countries))
            {
                _countries.Clear();
            }
        }

        public static string GetLanguageLinks()
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

        public static void SetLanguage(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request, System.Web.HttpResponse Response, Country country,
            Currency newCurrency, bool allowRedirect = true)
        {
            int extra = 0;
            int extra2 = 0;
            try
            {
                extra = 1;
                UserSession session = (UserSession)Session[lib.StringConsts.SESSION_NAME_USER_SESSION];
                extra = 2;

                if (session == null || session.Status == SessionStatus.Continuing)
                {
                    extra = 3;
                    SharedWebBase.UserSessionContinue(Session, Request, Response, ref session);
                    UserSessionManager.UpdateSession(session);
                }

                extra = 4;
                LocalWebSessionData localData = (LocalWebSessionData)session.Tag;

                extra = 5;
                if (session == null)
                    return;

                extra = 6;
                bool languageSet = localData.Culture != null &&
                    Session[lib.StringConsts.SESSION_NAME_WEBSITE_COUNTRY] != null;

                extra = 7;
                if ((!WebsiteSettings.Languages.Active && languageSet) || WebsiteSettings.StaticWebSite)
                    return;

                extra = 8;
                bool changedSettings = !languageSet ||
                    (
                        (Country)Session[lib.StringConsts.SESSION_NAME_WEBSITE_COUNTRY]).ID != country.ID ||
                        ((newCurrency != null && Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] != null) &&
                            (
                                ((Currency)Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY]).ID != newCurrency.ID)
                            );

#if DEBUG
            Shared.EventLog.DebugText(String.Format("Changed: {0}", changedSettings.ToString()));
            Shared.EventLog.DebugText(String.Format("Basket Currency: {0}", 
                Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY]));
#endif
                extra = 9;

                if (changedSettings)
                {
                    extra = 10;

                    if (WebsiteSettings.WebsiteCultureOverride)
                    {
                        extra = 11;
                        localData.Culture = WebsiteSettings.Languages.WebsiteCulture.Name;
                    }
                    else
                    {
                        extra = 12;
                        localData.Culture = country.LocalizedCulture;
                    }

                    extra = 13;
                    if (newCurrency != null)
                        Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] = newCurrency;
                    extra = 14;

                    Session[lib.StringConsts.SESSION_NAME_WEBSITE_PRICE_COLUMN] = RaiseSelectPriceColumn(Session, Request,
                        session,
                        newCurrency == null ? country.PriceColumn : newCurrency.PriceColumn);
                    extra = 15;
                    Session[lib.StringConsts.SESSION_NAME_WEBSITE_COUNTRY] = country;
                    //for each item in the basket, reset the price depending on the new price option
                    extra = 16;
                    localData.PriceColumn = (int)Session[lib.StringConsts.SESSION_NAME_WEBSITE_PRICE_COLUMN];

                    extra = 17;

                    if (newCurrency == null)
                        extra2 = 1;

                    if (Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] == null)
                    {
                        if (extra2 == 1)
                            extra2 = 20;
                        else
                            extra2 = 5;
                    }

                    
                    localData.Basket.Currency = newCurrency ?? (Currency)Session[
                        lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY];
                    extra = 18;
                    localData.Basket.Country = country;
                    extra = 19;
                    localData.Basket.FreeShipping = WebsiteSettings.ShoppingCart.FreeShippingAllow;
                    extra = 20;
                    localData.Basket.Reset(localData.PriceColumn);

                    extra = 21;

                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(country.LocalizedCulture);
                    extra =22;
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    extra = 23;

                    string currentPath = String.Empty;
                    extra = 24;

                    if (Request.UrlReferrer != null && !String.IsNullOrEmpty(Request.UrlReferrer.Query))
                    {
                        extra = 25;
                        currentPath = Request.UrlReferrer.Query;
                    }
                    extra = 26;

                    if (allowRedirect)
                        Response.Redirect(Request.Path + currentPath, true);
                }
                extra = 27;
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err, String.Format("extra {0}; extra2 {1}", extra, extra2));
            }
        }

        public static void SetLanguage(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request, System.Web.HttpResponse Response)
        {
            Country selectedCountry = (Country)Session[lib.StringConsts.SESSION_NAME_WEBSITE_COUNTRY];

            if (selectedCountry == null)
                selectedCountry = Countries.Get(WebsiteSettings.Languages.DefaultCountrySettings);

            SetLanguage(Session, Request, Response, selectedCountry, null, true);

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
        }

        #endregion Methods

        #region Internal Methods

        public static int RaiseSelectPriceColumn(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request, UserSession session, int priceColumn)
        {
            int Result = priceColumn;

            if (OnSelectPriceColumn != null)
            {
                PriceColumnOverrideArgs args = new PriceColumnOverrideArgs(Session, Request, 
                    priceColumn, Session.SessionID, false, session);

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
        public static event PriceColumnOverrideDelegate OnSelectPriceColumn;

        #endregion Events

    }
}
