using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Web;

using Shared;
using Shared.Classes;

using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Products;

namespace Website.Library.Classes
{
    public static class LocalizedLanguages
    {
        #region Private Members

        private static List<Country> _countries = new List<Country>();

        #endregion Private Members

        #region Properties

        /// <summary>
        /// Indicates wether the Localized Languages is active or not
        /// </summary>
        public static bool Active { get; set; }

        #endregion Properties

        #region Methods

        public static int GetPriceColumn(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request)
        {
            UserSession session = (UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION];
            int Result = ((LocalWebSessionData)session.Tag).PriceColumn;
            RaiseSelectPriceColumn(Session, Request, (UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION], Result);
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

            if (!Active)
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
            UserSession session = (UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION];

            if (session == null || session.Status == SessionStatus.Continuing)
            {
                SharedWebBase.UserSessionContinue(Session, Request, Response, ref session);
                UserSessionManager.UpdateSession(session);
            }

            LocalWebSessionData localData = (LocalWebSessionData)session.Tag;

            if (session == null)
                return;

            bool languageSet = localData.Culture != null &&
                Session[StringConstants.SESSION_NAME_WEBSITE_COUNTRY] != null;

            if ((!Active && languageSet) || BaseWebApplication.StaticWebSite)
                return;

            bool changedSettings = !languageSet || 
                (
                    (Country)Session[StringConstants.SESSION_NAME_WEBSITE_COUNTRY]).ID != country.ID ||
                    ((newCurrency != null && Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] != null) &&
                        (
                            ((Currency)Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY]).ID != newCurrency.ID)
                        );

#if DEBUG
            Shared.EventLog.DebugText(String.Format("Changed: {0}", changedSettings.ToString()));
            Shared.EventLog.DebugText(String.Format("Basket Currency: {0}", 
                Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY]));
#endif

            if (changedSettings)
            {
                if (BaseWebApplication.WebsiteCultureOverride)
                {
                    localData.Culture = BaseWebApplication.WebsiteCulture.Name;
                }
                else
                {
                    localData.Culture = country.LocalizedCulture;
                }

                if (newCurrency != null)
                    Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = newCurrency;

                Session[StringConstants.SESSION_NAME_WEBSITE_PRICE_COLUMN] = RaiseSelectPriceColumn(Session, Request,
                    session,
                    newCurrency == null ? country.PriceColumn : newCurrency.PriceColumn); 
                Session[StringConstants.SESSION_NAME_WEBSITE_COUNTRY] = country;
                //for each item in the basket, reset the price depending on the new price option
                localData.PriceColumn = (int)Session[StringConstants.SESSION_NAME_WEBSITE_PRICE_COLUMN];

                localData.Basket.Currency = newCurrency == null ? (Currency)Session[
                    StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] : newCurrency;
                localData.Basket.Country = country;
                localData.Basket.FreeShipping = BaseWebApplication.FreeShippingAllow;
                localData.Basket.Reset(localData.PriceColumn);
                
                
                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(country.LocalizedCulture);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                string currentPath = String.Empty;

                if (Request.UrlReferrer != null && !String.IsNullOrEmpty(Request.UrlReferrer.Query))
                {
                    currentPath = Request.UrlReferrer.Query;
                }

                if (allowRedirect)
                    Response.Redirect(Request.Path + currentPath, true);
            }
        }

        public static void SetLanguage(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request, System.Web.HttpResponse Response)
        {
            Country selectedCountry = (Country)Session[StringConstants.SESSION_NAME_WEBSITE_COUNTRY];

            if (selectedCountry == null)
                selectedCountry = Countries.Get(BaseWebApplication.DefaultCountrySettings);

            SetLanguage(Session, Request, Response, selectedCountry, null, true);

            if (BaseWebApplication.WebsiteCultureOverride)
            {
                Thread.CurrentThread.CurrentUICulture = BaseWebApplication.WebsiteCulture;

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

        internal static int RaiseSelectPriceColumn(System.Web.SessionState.HttpSessionState Session,
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
