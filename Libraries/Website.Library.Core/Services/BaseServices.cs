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
 *  File: BaseServices.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Web;

using Microsoft.AspNetCore.Http;

using lib = Library;
using Library.BOL.Affiliate;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Mail;
using Library.BOL.Users;
using Library.BOL.Websites;
using Library.BOL.IPAddresses;

using Shared.Classes;

using Website.Library.Core;
using Website.Library.Core.Classes;
using Website.Library.Core.Interfaces;

#pragma warning disable IDE0017

namespace Website.Library.Core.Services
{
    public class BaseServices : IBaseServices
    {
        #region Constants

        private const string ENCRYPTION_KEY = "Efa;jsldjifsa;rncasdfm.slzkuerdjm;sdfxj";
        private const string CLOUD_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0b; Windows NT 6.0) sdcloud/";
        private const string WEB_DEFENDER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; " +
            ".NET CLR 2.0.50727) WebMonitor/2.5 (http://www.sieradelta.com/bots.aspx)";

        #endregion Constants

        #region Private Static Members

        private static object _basketLockObject = new object();
        private static Int64 _currentBasketIdentifier = 0;
        private static Int64 _maximumBasketIdendifer = 0;
        private static TimeSpan _basketLockSpan = new TimeSpan(0, 0, 0, 0, 50);

        #endregion Private Static Members

        #region Private Members

        private IGeoIPLocation _geoIPLocation;
        private IMemoryCache _memoryCache;
        private ILocalizedLanguages _localizedLanguages;

        #endregion Private Members

        #region Constructors

        public BaseServices(IMemoryCache memoryCache, ILocalizedLanguages localizedLanguages, 
            IGeoIPLocation geoIPLocation)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _localizedLanguages = localizedLanguages ?? throw new ArgumentNullException(nameof(localizedLanguages));
            _geoIPLocation = geoIPLocation ?? throw new ArgumentNullException(nameof(geoIPLocation));
        }

        #endregion Constructors

        #region Public Methods

        public bool IgnoreErrorMessage(string Error)
        {
            if (Error.Contains("This is an invalid webresource"))
                return (true);
            else if (Error.Contains("This is an invalid script resource request"))
                return (true);
            else if (Error.Contains("' does not exist."))
                return (true);
            else if (Error.ToLower().Contains("dxr.axd"))
                return (true);
            else if (Error.Contains("The given path's format is not supported."))
                return (true);
            else if (Error.Contains("Thread was being aborted."))
                return (true);
            else if (Error.Contains("Invalid viewstate"))
                return (true);
            else if (Error.Contains("This is an invalid webresource request"))
                return (true);
            else if (Error.Contains("Request timed out"))
                return (true);
            else if (Error.Contains("The length of the URL for this request exceeds the configured maxUrlLength"))
                return (true);
            else if (Error.Contains("A potentially dangerous Request"))
                return (true);
            else if (Error.ToLower().Contains("webresource.axd"))
                return (true);

            return (false);
        }

        public void ResetWebTitleCache()
        {

        }

        public Uri GetAbsoluteUri(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            UriBuilder uriBuilder = new UriBuilder(context.Request.Scheme, context.Request.Host.Host);
            uriBuilder.Path = context.Request.Path.ToString();
            uriBuilder.Query = context.Request.QueryString.ToString();
            return (uriBuilder.Uri);
        }

        public string GetUserAgent(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return (context.Request.Headers["User-Agent"].ToString());
        }

        /// <summary>
        /// retrieves the web title cache
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public string GetWebTitle(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            string page = GetAbsoluteUri(context).ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            CacheItem item = _memoryCache.GetCache().Get(String.Format("Page Title: {0}", page));

            if (item != null)
                return ((string)item.Value);

            string Result = String.IsNullOrEmpty(WebsiteSettings.PageTitle) ?
                "Website" : WebsiteSettings.PageTitle;
            string customTitle = lib.LibraryHelperClass.SettingsGetMeta(String.Format("TITLE:{0}", page));

            if (!String.IsNullOrEmpty(customTitle))
                Result = customTitle;

            _memoryCache.GetCache().Add(String.Format("Page Title: {0}", page), 
                new CacheItem(String.Format("Page Title: {0}", page), Result));

            return (Result);
        }

        #region Cookies

        public void CookieSetValue(HttpContext context, string cookieName, string value, 
            DateTime expires, bool isSessionCookie = false)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (String.IsNullOrEmpty(cookieName))
                throw new ArgumentNullException(nameof(cookieName));

            if (expires < DateTime.Now)
            {
                context.Response.Cookies.Delete(cookieName);
            }
            else
            {
                CookieOptions options = new CookieOptions();

                if (!Shared.Utilities.LocalIPAddress(context.Connection.RemoteIpAddress.ToString()))
                    options.Domain = BaseWebApplication.CookieRootURL;

                if (!isSessionCookie)
                    options.Expires = expires;

                options.Path = "/";
                context.Response.Cookies.Append(cookieName, Encrypt(value), options);
            }
        }

        /// <summary>
        /// Retrieves a cookie value
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        /// <param name="cookieName">Name of cookie</param>
        /// <param name="defaultValue">Default value if not available</param>
        /// <returns></returns>
        public string CookieGetValue(HttpContext context, string cookieName, string defaultValue)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (String.IsNullOrEmpty(cookieName))
                throw new ArgumentNullException(nameof(cookieName));

            if (context.Request.Cookies[cookieName] != null)
            {
                return (Decrypt(context.Request.Cookies[cookieName]));
            }

            return (defaultValue);
        }


        public int CookieGetValue(HttpContext context, string cookieName, int defaultValue)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (String.IsNullOrEmpty(cookieName))
                throw new ArgumentNullException(nameof(cookieName));

            string cookieValue = CookieGetValue(context, cookieName, defaultValue.ToString());

            if (int.TryParse(cookieValue, out int Result))
                return (Result);

            return (defaultValue);
        }

        public Int64 CookieGetValue(HttpContext context, string cookieName, Int64 defaultValue)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (String.IsNullOrEmpty(cookieName))
                throw new ArgumentNullException(nameof(cookieName));

            string cookieValue = CookieGetValue(context, cookieName, defaultValue.ToString());

            if (Int64.TryParse(cookieValue, out Int64 Result))
                return (Result);

            return (defaultValue);
        }

        public bool CookieExists(HttpContext context, string cookieName)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (String.IsNullOrEmpty(cookieName))
                throw new ArgumentNullException(nameof(cookieName));

            return (context.Request.Cookies[cookieName] != null);
        }

        #endregion Cookies

        #region Users

        public UserSession GetUserSession(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            string sessionId = context.Items["CookieSessionID"].ToString();

            CacheItem sessionCacheItem = _memoryCache.GetSessionCache().Get(sessionId);

            if (sessionCacheItem != null && sessionCacheItem.Value != null)
                return ((UserSession)sessionCacheItem.Value);

            UserSession Result = null;

            try
            {
#if TRACE
                DateTime startSessionTimer = DateTime.Now;
#endif
                string userAgent = context.Request.Headers["User-Agent"].ToString();

                if (!String.IsNullOrEmpty(userAgent) && userAgent.StartsWith(CLOUD_USER_AGENT))
                {
                    return (Result);
                }

#if DISPLAY_DEBUG_INFO
                Session[StringConsts.SESSION_NAME_SESSION_INITIATED] = "Start Session";
#endif

                Result = new UserSessionCore(context);

                //context.Session.SetString(lib.StringConsts.SESSION_NAME_USER_SESSION, 
                //    Newtonsoft.Json.JsonConvert.DeserializeObject<UserSession>(Result));

                UserSessionManager.Add(Result);

                if (WebsiteSettings.StaticWebSite)
                    return (Result);

                Result.Tag = new LocalWebSessionData();

                _memoryCache.GetSessionCache().Add(sessionId, new CacheItem(sessionId, Result));
                LocalWebSessionData localData = (LocalWebSessionData)Result.Tag;

                localData.CurrentUser = GetUser(context);

                if (localData.CurrentUser != null)
                {
                    Result.Login(localData.CurrentUser.ID, localData.CurrentUser.UserName, localData.CurrentUser.Email);
                    localData.UserCountry = localData.CurrentUser.Country;
                    localData.CountryCode = localData.UserCountry.CountryCode;
                    localData.MemberLevel = (int)localData.CurrentUser.MemberLevel;
                    localData.LoggedIn = true;

                    if (localData.CurrentUser.MemberLevel == lib.MemberLevel.GoldUser)
                    {
                        localData.Basket.ApplyDiscount(localData.CurrentUser.AutoDiscount, "Gold Club");
                    }
                }
                else
                {
#if FAKE_ADDRESS
                    Result.IPAddress = GetFormValue(Request, "FakeAddress", ipAddress);
#endif

                    IPCity city = _geoIPLocation.GetIPCity(Result.IPAddress);

                    if (city != null)
                    {
                        localData.CountryCode = city.Country == "Unknown" ? "ZZ" : city.Country;
                    }
                    else
                    {
                        localData.CountryCode = lib.LibraryHelperClass.IPAddressToCountry(Result.IPAddress);
                    }

                    localData.UserCountry = Countries.Get(localData.CountryCode);
                    localData.LoggedIn = false;
                }

                UserSessionManager.Instance.InitialiseSession(Result);

                if (!Result.IsBot)
                {
                    localData.Basket = GetShoppingBasket(context);

                    #region Affiliate

                    string affiliate = CookieGetValue(context,
                        String.Format(lib.StringConsts.COOKIE_AFFILIATE,
                        WebsiteSettings.DistributorWebsite), String.Empty);

                    if (String.IsNullOrEmpty(affiliate))
                    {
                        if (!String.IsNullOrEmpty(context.Request.Query["aff"]))
                        {
                            affiliate = context.Request.Query["aff"];
                        }
                        else if (!String.IsNullOrEmpty(Result.InitialReferrer))
                        {
                            affiliate = AffiliatedItems.Get(Result.InitialReferrer);
                        }

                        if (!String.IsNullOrEmpty(affiliate))
                        {
                            AffiliatedItem affItem = AffiliatedItems.GetAffiliate(affiliate);

                            if (affItem != null)
                            {
                                affItem.AddWebClick(Result.IPAddress);

                                CookieSetValue(context,
                                    String.Format(lib.StringConsts.COOKIE_AFFILIATE,
                                    WebsiteSettings.DistributorWebsite),
                                    affiliate, DateTime.Now.AddDays(WebsiteSettings.Affiliates.MaximumDays));
                            }
                        }
                    }

                    localData.AffiliateID = affiliate;

                    #endregion Affiliate
                }

                Country defaultCountry = WebCountry(context);
                Currency defaultCurrency = Currencies.Get(defaultCountry.DefaultCurrency);

                string userLanguage = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_USER_LANGUAGE,
                    WebsiteSettings.DistributorWebsite),
                    defaultCountry.CountryCode);
                string userCurrency = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_USER_CURRENCY,
                    WebsiteSettings.DistributorWebsite),
                    defaultCurrency.CurrencyCode);

                // get user lang/currency settings if they exist
                Country userSelectedCountry = Countries.Get(userLanguage);

                Currency userSelectedCurrency = Currencies.Get(userCurrency);

                if (localData.UserCountry == null)
                {
                    localData.VATRate = lib.DAL.DALHelper.DefaultVATRate;
                }
                else
                {
                    localData.VATRate = localData.UserCountry.VATRate;
                }

                if (!userSelectedCurrency.IsActive)
                {
                    userSelectedCurrency = defaultCurrency;
                }

                localData.DeliveryAddressID = -1;

                if (WebsiteSettings.WebsiteCultureOverride)
                {
                    localData.Culture = WebsiteSettings.Languages.WebsiteCulture.Name;
                }
                else
                {
                    localData.Culture = Currencies.Get(localData.UserCountry.DefaultCurrency).Culture;
                }

                if (!Result.IsBot)
                {
                    localData.Basket.Country = localData.UserCountry;

                    localData.Basket.Currency = Currencies.Get(localData.UserCountry.DefaultCurrency);

                    int priceCol = _localizedLanguages.GetPriceColumn(context, Result);
                    localData.PriceColumn = priceCol;
                    localData.Basket.Reset(localData.PriceColumn);
                }

                _localizedLanguages.SetLanguage(context, Result,
                    GetAbsoluteUri(context),
                    userSelectedCountry ?? defaultCountry,
                    userSelectedCurrency ?? defaultCurrency, true);

#if TRACE
                TimeSpan span = DateTime.Now - startSessionTimer;
                System.Diagnostics.Debug.WriteLine(String.Format("Total Session Create Time {0} ms - Thread ID {1}",
                    span.TotalMilliseconds.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
#endif
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }

            // Save the session here, it may slow session creation 
            // stuff down a little, but better that than lose data
            // also the session could be required across web garden /
            // web farm, in that case it's best to save the initial 
            // session id so that the processes in garden/farm can 
            // save their individual pages and update if required
            {
                //if (Result.SaveStatus != SaveStatus.Saved)
                //    Result.SaveStatus = SaveStatus.RequiresSave;


                if (UserSessionManager.SaveImmediately)
                    lib.BOL.SEO.SeoData.SEOSaveSession(Result);
            }

            return (Result);
        }

        public LocalWebSessionData GetUserLocalData(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return (GetUserLocalData(GetUserSession(context)));
        }

        public LocalWebSessionData GetUserLocalData(UserSession userSession)
        {
            if (userSession == null)
                throw new ArgumentNullException(nameof(userSession));

            return ((LocalWebSessionData)userSession.Tag);
        }

        /// <summary>
        /// Retrieves the active user ID
        /// </summary>
        /// <returns></returns>
        public Int64 GetUserID(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            string cookieName = String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, WebsiteSettings.DistributorWebsite);
            Int64 defaultValue = -1;
            return (CookieGetValue(context, cookieName, defaultValue));
        }

        /// <summary>
        /// Retrieves the active user, if there is one
        /// </summary>
        /// <returns></returns>
        public User GetUser(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return (User.UserGet(GetUserID(context)));
        }

        /// <summary>
        /// Determines wether a user is logged in or not
        /// </summary>
        /// <returns></returns>
        public bool UserIsLoggedOn(UserSession session)
        {
            if (session == null)
                return (false);

            LocalWebSessionData userData = (LocalWebSessionData)session.Tag;

            return (userData.LoggedIn);
        }

        public bool UserIsLoggedOn(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return (UserIsLoggedOn(GetUserSession(context)));
        }

        /// <summary>
        /// Retrieves the country for the user
        /// </summary>
        /// <returns></returns>
        public string GetUserCountry(HttpContext context, UserSession userSession)
        {
            string remoteIP = context.Connection.RemoteIpAddress.ToString();

#if FAKE_ADDRESS
            remoteIP = GetFormValue(Request, "FakeAddress", remoteIP);
#endif

            IPCity city = _geoIPLocation.GetIPCity(remoteIP);

            string country = city == null ? "ZZ" : city.Country;

            if (country == "Unknown")
                country = "ZZ";

            if (!UserIsLoggedOn(context))
            {
                return (country);
                //return (lib.Website.IPAddressToCountry(remoteIP));
            }
            else
            {
                User user = GetUser(context);

                if (user == null)
                {
                    return (country);
                }
                else
                {
                    if (user.Country == null)
                    {
                        return (country);
                    }
                    else
                    {
                        return (GetUser(context).Country.CountryCode);
                    }
                }
            }
        }

        #endregion Users

        /// <summary>
        /// Retrieves the website Country
        /// </summary>
        public Country WebCountry(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Country Result = null;

            string ipAddress = context.Connection.RemoteIpAddress.ToString();

#if FAKE_ADDRESS
            ipAddress = GetFormValue(Request, "FakeAddress", ipAddress);
#endif

            Result = Countries.Get(lib.LibraryHelperClass.IPAddressToCountry(ipAddress));

            if (Result == null || Result.CountryCode == "ZZ" || WebsiteSettings.Languages.ForceInitialDefaultLanguage)
                Result = Countries.Get(WebsiteSettings.Languages.DefaultCountrySettings);

            return (Result);
        }

        public Currency WebsiteCurrency(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Currency Result = null;

            LocalWebSessionData localWebSessionData = GetUserLocalData(context);

            if (localWebSessionData == null)
            {
                Result = Currencies.Get(WebCountry(context).DefaultCurrency);
                localWebSessionData.Currency = Result;
            }
            else
            {
                Result = localWebSessionData.Currency;
            }

            if (!Result.IsActive)
            {
                Result = Currencies.Get(WebCountry(context).DefaultCurrency);
            }

            return (Result);
        }


        #endregion Public Methods


        #region Public Static Methods

        public void ApplicationStart()
        {
            Countries.Get();

            using (TimedLock.Lock(_basketLockObject))
            {
                _maximumBasketIdendifer = lib.LibraryHelperClass.GetBasketID(WebsiteSettings.ShoppingCart.BasketIDIncrement);
                _currentBasketIdentifier = _maximumBasketIdendifer - WebsiteSettings.ShoppingCart.BasketIDIncrement;
            }
        }

        private static Int64 GetNextBasketID()
        {
            try
            {
                using (TimedLock.Lock(_basketLockObject, _basketLockSpan))
                {
                    if (_maximumBasketIdendifer == 0 || _currentBasketIdentifier == _maximumBasketIdendifer)
                    {
                        _maximumBasketIdendifer = lib.LibraryHelperClass.GetBasketID(WebsiteSettings.ShoppingCart.BasketIDIncrement);
                        _currentBasketIdentifier = _maximumBasketIdendifer - WebsiteSettings.ShoppingCart.BasketIDIncrement;
                    }

                    _currentBasketIdentifier++;
                    return (_currentBasketIdentifier);
                }
            }
            catch (LockTimeoutException)
            {
                return (0 - (Environment.TickCount + DateTime.Now.Millisecond));
            }
        }

        public UserSession StartUserSession(HttpContext context)
        {
            UserSession Result = null;

            try
            {
#if TRACE
                DateTime startSessionTimer = DateTime.Now;
#endif
                string userAgent = GetUserAgent(context);

                if (!String.IsNullOrEmpty(userAgent) && userAgent.StartsWith(CLOUD_USER_AGENT))
                {
                    return (Result);
                }

#if DISPLAY_DEBUG_INFO
                Session[StringConsts.SESSION_NAME_SESSION_INITIATED] = "Start Session";
#endif
                Result = new UserSession();

                UserSessionManager.Add(Result);

                if (WebsiteSettings.StaticWebSite)
                    return (Result);

                Result.Tag = new LocalWebSessionData();
                LocalWebSessionData localData = (LocalWebSessionData)Result.Tag;

                localData.CurrentUser = GetUser(context);

                if (localData.CurrentUser != null)
                {
                    Result.Login(localData.CurrentUser.ID, localData.CurrentUser.UserName, localData.CurrentUser.Email);
                    localData.UserCountry = localData.CurrentUser.Country;
                    localData.CountryCode = localData.UserCountry.CountryCode;
                    localData.MemberLevel = (int)localData.CurrentUser.MemberLevel;
                    localData.LoggedIn = true;

                    if (localData.CurrentUser.MemberLevel == lib.MemberLevel.GoldUser)
                    {
                        localData.Basket.ApplyDiscount(localData.CurrentUser.AutoDiscount, "Gold Club");
                    }
                }
                else
                {
                    string ipAddress = context.Connection.RemoteIpAddress.ToString();

#if FAKE_ADDRESS
                ipAddress = GetFormValue(Request, "FakeAddress", ipAddress);
#endif

                    IPCity city = _geoIPLocation.GetIPCity(ipAddress);

                    if (city != null)
                    {
                        localData.CountryCode = city.Country == "Unknown" ? "ZZ" : city.Country;
                    }
                    else
                    {
                        localData.CountryCode = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
                    }

                    localData.UserCountry = Countries.Get(localData.CountryCode);
                    localData.LoggedIn = false;
                }

                localData.Basket = GetShoppingBasket(context);

                #region Affiliate

                string affiliate = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_AFFILIATE,
                    WebsiteSettings.DistributorWebsite), String.Empty);

                if (String.IsNullOrEmpty(affiliate))
                {
                    if (!String.IsNullOrEmpty(context.Request.Query["aff"]))
                    {
                        affiliate = context.Request.Query["aff"];
                    }
                    else if (!String.IsNullOrEmpty(Result.InitialReferrer))
                    {
                        affiliate = AffiliatedItems.Get(Result.InitialReferrer);
                    }

                    if (!String.IsNullOrEmpty(affiliate))
                    {
                        AffiliatedItem affItem = AffiliatedItems.GetAffiliate(affiliate);

                        if (affItem != null)
                        {
                            affItem.AddWebClick(Result.IPAddress);

                            CookieSetValue(context,
                                String.Format(lib.StringConsts.COOKIE_AFFILIATE,
                                WebsiteSettings.DistributorWebsite),
                                affiliate, DateTime.Now.AddDays(WebsiteSettings.Affiliates.MaximumDays));
                        }
                    }
                }

                localData.AffiliateID = affiliate;

                #endregion Affiliate

                Country defaultCountry = WebCountry(context);
                Currency defaultCurrency = lib.BOL.Basket.Currencies.Get(defaultCountry.DefaultCurrency);

                string userLanguage = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_USER_LANGUAGE,
                    WebsiteSettings.DistributorWebsite),
                    defaultCountry.CountryCode);
                string userCurrency = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_USER_CURRENCY,
                    WebsiteSettings.DistributorWebsite),
                    defaultCurrency.CurrencyCode);

                // get user lang/currency settings if they exist
                Country userSelectedCountry = Countries.Get(userLanguage);

                Currency userSelectedCurrency = Currencies.Get(userCurrency);

                if (localData.UserCountry == null)
                {
                    localData.VATRate = lib.DAL.DALHelper.DefaultVATRate;
                }
                else
                {
                    localData.VATRate = localData.UserCountry.VATRate;
                }

                if (!userSelectedCurrency.IsActive)
                {
                    userSelectedCurrency = defaultCurrency;
                }

                localData.DeliveryAddressID = -1;

                if (WebsiteSettings.WebsiteCultureOverride)
                {
                    localData.Culture = WebsiteSettings.Languages.WebsiteCulture.Name;
                }
                else
                {
                    localData.Culture = Currencies.Get(localData.UserCountry.DefaultCurrency).Culture;
                }

                localData.Basket.Country = localData.UserCountry;

                localData.Basket.Currency = Currencies.Get(localData.UserCountry.DefaultCurrency);

                int priceCol = _localizedLanguages.GetPriceColumn(context, Result);

                _localizedLanguages.SetLanguage(context, Result, GetAbsoluteUri(context),
                    userSelectedCountry ?? defaultCountry,
                    userSelectedCurrency ?? defaultCurrency, true);

#if TRACE
                TimeSpan span = DateTime.Now - startSessionTimer;
                System.Diagnostics.Debug.WriteLine(String.Format("Total Session Create Time {0} ms - Thread ID {1}",
                    span.TotalMilliseconds.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
#endif
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }

            // Save the session here, it may slow session creation 
            // stuff down a little, but better that than lose data
            // also the session could be required across web garden /
            // web farm, in that case it's best to save the initial 
            // session id so that the processes in garden/farm can 
            // save their individual pages and update if required
            {
                //if (Result.SaveStatus != SaveStatus.Saved)
                //    Result.SaveStatus = SaveStatus.RequiresSave;

                UserSessionManager.Instance.InitialiseSession(Result);

                if (UserSessionManager.SaveImmediately)
                    lib.BOL.SEO.SeoData.SEOSaveSession(Result);
            }

            return (Result);
        }

        public void UserSessionContinue(HttpContext context, ref UserSession session)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            try
            {

#if DISPLAY_DEBUG_INFO
                Session[StringConsts.SESSION_NAME_SESSION_INITIATED] = "Resume Session";
#endif
                string userAgent = GetUserAgent(context);

                if (!String.IsNullOrEmpty(userAgent) && userAgent.StartsWith(CLOUD_USER_AGENT))
                    return;

                if (session == null)
                {
                    session = StartUserSession(context);
                }

                if (WebsiteSettings.StaticWebSite)
                    return;

                session.Tag = new LocalWebSessionData();
                LocalWebSessionData localData = (LocalWebSessionData)session.Tag;

                localData.CurrentUser = GetUser(context);
                localData.Basket = GetShoppingBasket(context);

                if (localData.CurrentUser != null)
                {
                    session.Login(localData.CurrentUser.ID, localData.CurrentUser.UserName, localData.CurrentUser.Email);
                    localData.UserCountry = localData.CurrentUser.Country;
                    localData.CountryCode = localData.UserCountry.CountryCode;
                    localData.MemberLevel = (int)localData.CurrentUser.MemberLevel;
                    localData.LoggedIn = true;

                    if (localData.CurrentUser.MemberLevel == lib.MemberLevel.GoldUser)
                    {
                        localData.Basket.ApplyDiscount(localData.CurrentUser.AutoDiscount, "Gold Club");
                    }
                }
                else
                {
                    string ipAddress = context.Connection.RemoteIpAddress.ToString();

#if FAKE_ADDRESS
                    ipAddress = GetFormValue(Request, "FakeAddress", ipAddress);
#endif

                    localData.CountryCode = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
                    localData.UserCountry = Countries.Get(localData.CountryCode);
                    localData.LoggedIn = false;
                }

                #region Affiliate

                string affiliate = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_AFFILIATE,
                    WebsiteSettings.DistributorWebsite), String.Empty);

                if (String.IsNullOrEmpty(affiliate))
                {
                    if (!String.IsNullOrEmpty(context.Request.Query["aff"]))
                    {
                        affiliate = context.Request.Query["aff"];
                    }
                    else if (!String.IsNullOrEmpty(session.InitialReferrer))
                    {
                        affiliate = AffiliatedItems.Get(session.InitialReferrer);
                    }

                    if (!String.IsNullOrEmpty(affiliate))
                    {
                        AffiliatedItem affItem = AffiliatedItems.GetAffiliate(affiliate);

                        if (affItem != null)
                        {
                            CookieSetValue(context,
                                String.Format(lib.StringConsts.COOKIE_AFFILIATE,
                                WebsiteSettings.DistributorWebsite),
                                affiliate, DateTime.Now.AddDays(WebsiteSettings.Affiliates.MaximumDays));
                        }
                    }
                }

                localData.AffiliateID = affiliate;

                #endregion Affiliate

                Country defaultCountry = WebCountry(context);
                Currency defaultCurrency = Currencies.Get(defaultCountry.DefaultCurrency);

                string userLanguage = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_USER_LANGUAGE,
                    WebsiteSettings.DistributorWebsite),
                    defaultCountry.CountryCode);
                string userCurrency = CookieGetValue(context,
                    String.Format(lib.StringConsts.COOKIE_USER_CURRENCY,
                    WebsiteSettings.DistributorWebsite),
                    defaultCurrency.CurrencyCode);

                // get user lang/currency settings if they exist
                Country userSelectedCountry = Countries.Get(userLanguage);
                Currency userSelectedCurrency = Currencies.Get(userCurrency);

                if (localData.UserCountry == null)
                {
                    localData.VATRate = lib.DAL.DALHelper.DefaultVATRate;
                }
                else
                {
                    localData.VATRate = localData.UserCountry.VATRate;
                }

                if (!userSelectedCurrency.IsActive)
                {
                    userSelectedCurrency = defaultCurrency;
                }

                localData.DeliveryAddressID = -1;
                localData.Culture = localData.Culture;
                localData.Basket.Country = localData.UserCountry;

                localData.Basket.Currency = Currencies.Get(localData.UserCountry.DefaultCurrency);

                int priceCol = _localizedLanguages.GetPriceColumn(context, session);
                localData.PriceColumn = priceCol;
                localData.Basket.Reset(localData.PriceColumn);
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }
        }

        public void ResetDeliveryAddress(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            LocalWebSessionData localData = GetUserLocalData(context);
            localData.DeliveryAddressID = -1;
            localData.Basket.ShippingAddress = null;
        }

        public void UserLogin(HttpContext context, User user)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            UserSession userSession = GetUserSession(context);
            UserSessionManager.Login(context.Items["CookieSessionID"].ToString(), user.UserName, user.Email, user.ID);
            LocalWebSessionData localData = (LocalWebSessionData)userSession.Tag;

            localData.CurrentUser = user;
            localData.UserCountry = user.Country;
            localData.CountryCode = user.Country.CountryCode;
            localData.MemberLevel = (int)user.MemberLevel;
            localData.LoggedIn = true;
            localData.Basket.User = user;

            localData.Culture = lib.DAL.DALHelper.DefaultCulture;// GlobalClass user.Culture;

            //for each item in the basket, reset the price depending on the new price option
            localData.Basket.Reset(localData.PriceColumn);

            if (user.MemberLevel == lib.MemberLevel.GoldUser)
            {
                localData.Basket.ApplyDiscount(user.AutoDiscount, "Gold Club");
            }

            _localizedLanguages.SetLanguage(context,userSession, 
                GetAbsoluteUri(context),
                localData.UserCountry,
                WebsiteCurrency(context), false);
        }

        public void UserLogout(HttpContext context, User user)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            UserSession userSession = GetUserSession(context);

            LocalWebSessionData localData = (LocalWebSessionData)userSession.Tag;
            localData.CurrentUser = null;

            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            localData.CountryCode = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
            localData.UserCountry = Countries.Get(localData.CountryCode);

            localData.Culture = localData.Culture;

            //for each item in the basket, reset the price depending on the new price option
            localData.Basket.ApplyDiscount(0, String.Empty);
            localData.Basket.Reset(localData.PriceColumn);
            localData.DeliveryAddressID = -1;
            localData.Basket.ShippingAddress = null;
            localData.Basket.User = null;
            localData.MemberLevel = 0;
            localData.LoggedIn = false;
            localData.DiscountCoupon = String.Empty;
        }

        /// <summary>
        /// Retrieves the shopping basket for the current user
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ShoppingBasket GetShoppingBasket(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            UserSession userSession = GetUserSession(context);

            if (userSession == null)
                throw new ArgumentNullException(nameof(userSession));

            ShoppingBasket Result = null;

            LocalWebSessionData userData = null;

            if (userSession != null && userSession.Tag != null)
            {
                userData = (LocalWebSessionData)userSession.Tag;

                if (userData.Basket != null)
                    return (userData.Basket);
            }

            Currency basketCurrency = null;

            if (userData.Currency == null)
            {
                basketCurrency = Currencies.Get(System.Threading.Thread.CurrentThread.CurrentUICulture);
            }
            else
            {
                basketCurrency = userData.Currency;
            }

            if (userData.CurrentUser != null)
            {
                if (userData.Basket != null)
                {
                    Result = GetUser(context).Basket;

                    if (Result.FreeShipping != WebsiteSettings.ShoppingCart.FreeShippingAllow)
                        Result.FreeShipping = WebsiteSettings.ShoppingCart.FreeShippingAllow;

                    if (Result.FreeShippingAmount != WebsiteSettings.ShoppingCart.FreeShippingAmount)
                        Result.FreeShippingAmount = WebsiteSettings.ShoppingCart.FreeShippingAmount;

                    return (Result);
                }
            }

            string BasketID = "new";
            Country country = userData.UserCountry;

            if (country == null)
                country = Countries.Get(GetUserCountry(context, userSession));

            // has the user got a cookie
            if (CookieExists(context, WebsiteSettings.BasketName))
            {
                BasketID = CookieGetValue(context, WebsiteSettings.BasketName, "new");

                if (BasketID == null || BasketID.Length == 0)
                {
                    BasketID = "new";
                }
            }

            if (BasketID == "new")
            {
                Result = new ShoppingBasket(GetNextBasketID(), country,
                    Currencies.Get(country.DefaultCurrency),
                    WebsiteSettings.ShoppingCart.FreeShippingAllow,
                    WebsiteSettings.ShoppingCart.FreeShippingAmount,
                    WebsiteSettings.Tax.PricesIncludeVAT,
                    WebsiteSettings.Tax.ShippingIsTaxable, true);

                CookieSetValue(context, WebsiteSettings.BasketName, Result.ID.ToString(), DateTime.Now.AddDays(365));
            }
            else
            {
                if (!basketCurrency.IsActive)
                {
                    basketCurrency = Currencies.Get(WebCountry(context).DefaultCurrency);
                }

                try
                {

                    Result = new ShoppingBasket(Convert.ToInt32(BasketID), userData.UserCountry,
                        basketCurrency,
                        WebsiteSettings.ShoppingCart.FreeShippingAllow,
                        WebsiteSettings.ShoppingCart.FreeShippingAmount,
                        WebsiteSettings.Tax.PricesIncludeVAT,
                        WebsiteSettings.Tax.ShippingIsTaxable, false);

                    if (!String.IsNullOrEmpty(userData.DiscountCoupon))
                    {
                        string resultText = String.Empty;

                        if (!Result.ValidateCouponCode(userData.DiscountCoupon, ref resultText))
                            userData.DiscountCoupon = String.Empty;
                    }
                }
                catch
                {
                    //problem getting users basket, create a new one
                    Result = new ShoppingBasket(-1, WebCountry(context), basketCurrency,
                        WebsiteSettings.ShoppingCart.FreeShippingAllow,
                        WebsiteSettings.ShoppingCart.FreeShippingAmount,
                        WebsiteSettings.Tax.PricesIncludeVAT,
                        WebsiteSettings.Tax.ShippingIsTaxable, true);

                    CookieSetValue(context, WebsiteSettings.BasketName, Result.ID.ToString(),
                        DateTime.Now.AddDays(365));
                }

            }

            if (userData.CurrentUser != null)
            {
                Result.User = userData.CurrentUser;
            }

            if (Result.MaximumItemQuantity != WebsiteSettings.ShoppingCart.MaximumItemQuantity)
                Result.MaximumItemQuantity = WebsiteSettings.ShoppingCart.MaximumItemQuantity;

            if (Result.User == null)
            {
                User user = userData.CurrentUser;

                if (user != null)
                    Result.User = user;
            }

            Result.WebSessionID = context.Items["CookieSessionID"].ToString();

            Result.ClearBasketOnPayment = WebsiteSettings.ShoppingCart.ClearBasketOnPayment;

            if (userData.CurrentUser != null && userData.DeliveryAddressID > -1)
            {
                Result.ShippingAddress = lib.BOL.DeliveryAddress.DeliveryAddresses.Get(userData.DeliveryAddressID);
            }

            if (userData != null && userData.Basket == null)
                userData.Basket = Result;

            return (Result);
        }

        /// <summary>
        /// Changes the currency for the website
        /// </summary>
        /// <param name="Session">Current Users Session</param>
        /// <param name="forceChange">if true then the change is forced, if false it looks to see 
        /// if previously set and if not set's it</param>
        //        public static void SetCurrency(System.Web.SessionState.HttpSessionState Session, Currency currency, bool forceChange)
        //        {
        //            if (currency == null)
        //                throw new InvalidOperationException();

        //            // if, and only if there is no currency, then set it now
        //            if (forceChange || Session[Librlibary.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] == null)
        //            {
        //                // default currency is users country currency, if it's accepted
        //                if (currency != null && currency.IsActive)
        //                {
        //                    Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] = currency;
        //                }
        //            }

        //        }

        //        public static ShoppingBasket GetShoppingBasket(System.Web.SessionState.HttpSessionState Session,
        //            System.Web.HttpRequest Request, System.Web.HttpResponse Response)
        //        {
        //            ShoppingBasket Result = null;

        //            Currency basketCurrency = null;

        //            if (Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] == null)
        //            {
        //                basketCurrency = Currencies.Get(System.Threading.Thread.CurrentThread.CurrentUICulture);
        //                Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] = basketCurrency;
        //            }
        //            else
        //            {
        //                basketCurrency = (Currency)Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY];
        //            }

        //            string remoteIP = context.Connection.RemoteIpAddress.ToString();

        //#if FAKE_ADDRESS
        //            remoteIP = GetFormValue(Request, "FakeAddress", remoteIP);
        //#endif

        //            Country country = Countries.Get(Library.LibraryHelperClass.IPAddressToCountry(remoteIP));

        //            if (Session[lib.StringConsts.SESSION_NAME_SHOPPING_ID] == null)
        //            {
        //                string BasketID = "new";

        //                // has the user got a cookie
        //                if (Request.Cookies[WebsiteSettings.BasketName] != null)
        //                {
        //                    BasketID = GlobalClass.Decrypt(HttpUtility.UrlDecode(Request.Cookies[WebsiteSettings.BasketName].Value));

        //                    if (BasketID == null || BasketID.Length == 0)
        //                    {
        //                        BasketID = "new";
        //                    }
        //                }

        //                if (BasketID == "new")
        //                {
        //                    Result = new ShoppingBasket(GetNextBasketID(), country,
        //                        Currencies.Get(country.DefaultCurrency),
        //                        WebsiteSettings.ShoppingCart.FreeShippingAllow,
        //                        WebsiteSettings.ShoppingCart.FreeShippingAmount,
        //                        WebsiteSettings.Tax.PricesIncludeVAT,
        //                        WebsiteSettings.Tax.ShippingIsTaxable, true);

        //                    CookieSetValue(Request, Response, WebsiteSettings.BasketName, Result.ID.ToString(), DateTime.Now.AddDays(365));
        //                }
        //                else
        //                {
        //                    if (!basketCurrency.IsActive)
        //                    {
        //                        basketCurrency = lib.BOL.Basket.Currencies.Get(
        //                            WebCountry(Session, Request).DefaultCurrency);
        //                        Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] = basketCurrency;
        //                    }

        //                    try
        //                    {

        //                        Result = new ShoppingBasket(Convert.ToInt32(BasketID), country,
        //                            basketCurrency, WebsiteSettings.ShoppingCart.FreeShippingAllow,
        //                            WebsiteSettings.ShoppingCart.FreeShippingAmount,
        //                            WebsiteSettings.Tax.PricesIncludeVAT, WebsiteSettings.Tax.ShippingIsTaxable, false);
        //                    }
        //                    catch
        //                    {
        //                        //problem getting users basket, create a new one
        //                        Result = new ShoppingBasket(-1, WebCountry(Session, Request), basketCurrency,
        //                            WebsiteSettings.ShoppingCart.FreeShippingAllow,
        //                            WebsiteSettings.ShoppingCart.FreeShippingAmount,
        //                            WebsiteSettings.Tax.PricesIncludeVAT,
        //                            WebsiteSettings.Tax.ShippingIsTaxable, true);

        //                        CookieSetValue(context, WebsiteSettings.BasketName, Result.ID.ToString(),
        //                            DateTime.Now.AddDays(365));
        //                    }

        //                }

        //                Session[lib.StringConsts.SESSION_NAME_SHOPPING_ID] = Result.ID;
        //            }
        //            else
        //            {
        //                Int64 basketID = (Int64)Session[lib.StringConsts.SESSION_NAME_SHOPPING_ID];
        //                Result = new ShoppingBasket(Convert.ToInt32(basketID), country,
        //                    basketCurrency, WebsiteSettings.ShoppingCart.FreeShippingAllow,
        //                    WebsiteSettings.ShoppingCart.FreeShippingAmount,
        //                    WebsiteSettings.Tax.PricesIncludeVAT,
        //                    WebsiteSettings.Tax.ShippingIsTaxable, false);
        //            }

        //            if (Result.MaximumItemQuantity != WebsiteSettings.ShoppingCart.MaximumItemQuantity)
        //                Result.MaximumItemQuantity = WebsiteSettings.ShoppingCart.MaximumItemQuantity;

        //            Result.WebSessionID = Session.SessionID;

        //            Result.ClearBasketOnPayment = WebsiteSettings.ShoppingCart.ClearBasketOnPayment;

        //            return (Result);
        //        }

        /// <summary>
        /// Returns the current website currency used for payment
        /// </summary>
        //public static Currency WebsiteCurrency(HttpContext context)
        //{
        //    Currency Result = null;

        //    if (Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] == null)
        //    {
        //        Result = Currencies.Get(WebCountry(Session, Request).DefaultCurrency);
        //        Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY] = Result;
        //    }
        //    else
        //    {
        //        Result = (Currency)Session[lib.StringConsts.SESSION_NAME_USER_BASKET_CURRENCY];
        //    }

        //    if (!Result.IsActive)
        //    {
        //        Result = lib.BOL.Basket.Currencies.Get(WebCountry(context).DefaultCurrency);
        //    }

        //    return (Result);
        //}

        /// <summary>
        /// Global handler for error handling
        /// </summary>
        /// <param name="error"></param>
        /// <param name="Session"></param>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        //        public static void HandleException(Exception error, int httpErrorCode)
        //        {
        //            string fullMessage = error.Message;
        //            try
        //            {
        //                string Inner = "Unknown";
        //                string Message = "Unknown";
        //                string Source = "Unknown";
        //                string StackTrace = "Unknown";
        //                string TargetSite = "Unknown";
        //                string _session = "Unknown";

        //                if (error != null)
        //                {
        //                    Inner = error.InnerException == null ? "InnerException is null" : error.InnerException.ToString();
        //                    Message = error.Message;
        //                    Source = error.Source;
        //                    StackTrace = error.StackTrace;
        //                    TargetSite = error.TargetSite == null ? "TargetSite is null" : error.TargetSite.ToString();
        //                }

        //                fullMessage += " " + Inner;

        //                // invalid view state?  if so ignore  or dangerous request
        //                if (fullMessage.Contains("viewstate MAC failed") || Message.Contains("state information is invalid for this page"))
        //                {
        //                    HttpContext.Current.Response.Redirect(WebsiteSettings.RootURL + HttpContext.Current.Request.Path, true);
        //                    return;
        //                }

        //                try
        //                {
        //                    // can't connect to the database, clear all connections from the pool
        //                    if (fullMessage.Contains("connection shutdown") ||
        //                        fullMessage.Contains("Error reading data from the connection") ||
        //                        fullMessage.Contains("Unable to complete network request to host"))
        //                    {
        //                        Library.DAL.DALHelper.ResetDatabasePool(false);
        //                    }

        //                    if (fullMessage.Contains("Database is probably already opened by another engine instance in another Windows session"))
        //                    {
        //                        // special case, clear all connections and kill all connections in the database
        //                        Library.DAL.DALHelper.ResetDatabasePool(true);
        //                    }

        //                    if (fullMessage.Contains("Unable to connect to database"))
        //                    {
        //                        HttpContext.Current.Response.Redirect(WebsiteSettings.RootURL + "/Error/ServerTooBusy.aspx", true);
        //                        return;
        //                    }

        //                    if (fullMessage.Contains("Connection pool is full"))
        //                    {
        //                        HttpContext.Current.Response.Redirect(WebsiteSettings.RootURL + "/Error/ServerTooBusy.aspx", true);
        //                        return;
        //                    }
        //                }
        //                catch (Exception err)
        //                {
        //                    if (!err.Message.Contains("no permission for DELETE access to TABLE"))
        //                        throw;
        //                }


        //                // not interested in some messages so filter them here
        //                if (!IgnoreErrorMessage(fullMessage))
        //                {
        //                    string UserData = "";

        //                    string Msg = String.Format("<P>User Session: {5}</P><P>Error Message: {0}</P>" +
        //                        "<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
        //                        "<P>StackTrace: {3}</P><P>Target Site: {4}</P><h2>User Data</h2>{5}<h2>Path</h2><p>{6}</p>",
        //                        Message, Inner, Source, StackTrace, TargetSite, _session, UserData,
        //                        HttpContext.Current.Request != null ? HttpContext.Current.Request.Url.ToString() : String.Empty);

        //#if ERROR_MANAGER
        //                    BaseWebApplication.InitialiseErrorManager();
        //#endif

        //                    Shared.EventLog.Add(error);

        //#if ERROR_MANAGER
        //                   if (!ErrorClient.GetErrorClient.SendWebError(error, _session, Request.Url.AbsoluteUri, Request.Path))
        //                   {
        //                       try
        //                       {
        //                           //Failed to send error details to server
        //                           SendEMail(BaseWebApplication.SupportName, WebsiteSettings.SupportEMail,
        //                               String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
        //                               Msg, BaseWebApplication.SupportName, WebsiteSettings.SupportEMail);
        //                       }
        //                       catch
        //                       {
        //                           // do nothing, it is logged anyway
        //                       }
        //                    }
        //#else
        //                    SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail,
        //                       String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
        //                       Msg, WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail);

        //#endif
        //                }
        //            }
        //            catch (Exception err)
        //            {
        //                Shared.EventLog.Add(error, "Original Error");
        //                Shared.EventLog.Add(err);
        //            }
        //        }



        #region Send Emails

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="ErrorMessage">Error Message</param>
        public static void SendEmail(string ErrorMessage)
        {
            SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail,
                String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite), ErrorMessage);
        }

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Title">Title of email</param>
        public static void SendEmail(string Title, string Message)
        {
            SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, Title, Message);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg)
        {
            SendEMail(ToName, ToEMail, Title, Msg, WebsiteSettings.Email.NoReplyName, WebsiteSettings.Email.NoReplyEmail);
        }

        public static void SendEMail(string Title, string Msg)
        {
            SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, Title, Msg,
                WebsiteSettings.Email.NoReplyName, WebsiteSettings.Email.NoReplyEmail);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg, string FromName, string FromEMail)
        {
            Emails.Add(ToName, ToEMail, FromName, FromEMail, Title, Msg);

            if (!WebsiteSettings.Email.SendEmails)
                return;
        }

        #endregion Send Emails

        #endregion Public Static Methods

        #region Private Methods

        private string Encrypt(string valueToencrypt)
        {
            
            return (Shared.Utilities.Encrypt(HttpUtility.HtmlEncode(valueToencrypt), ENCRYPTION_KEY));
        }

        private string Decrypt(string valueToDecrypt)
        {
            return (HttpUtility.HtmlDecode(Shared.Utilities.Decrypt(valueToDecrypt, ENCRYPTION_KEY)));
        }

        #endregion Private Methods
    }
}
