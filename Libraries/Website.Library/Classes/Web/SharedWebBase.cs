using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

using lib = Library;
using Library.Utils;
using Library.BOL.Affiliate;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Users;
using Library.BOL.Email;
using Library.BOL.SEO;

#if ERROR_MANAGER
using ErrorManager.ErrorClient;
#endif

using Shared.Classes;

namespace Website.Library.Classes
{
    /// <summary>
    /// Static methods shared between all base classes (Master/Form/Class)
    /// </summary>
    public static class SharedWebBase
    {
        #region Private / Protected Members

        private static lib.LibraryHelperClass _web;


        private const string CLOUD_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0b; Windows NT 6.0) sdcloud/";
        private const string WEB_DEFENDER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; " +
            ".NET CLR 2.0.50727) WebMonitor/2.5 (http://www.sieradelta.com/bots.aspx)";


        #endregion Private / Protected Members

        #region Properties

        public static lib.LibraryHelperClass Web
        {
            get
            {
                if (_web == null)
                    _web = new lib.LibraryHelperClass();

                return (_web);
            }
        }

        #endregion Properties

        #region Public Static Methods

        /// <summary>
        /// Resets the website's title cache
        /// </summary>
        public static void ResetWebTitleCache()
        {
            GlobalClass.InternalCache.Clear();
            GlobalClass.InternalCacheShort.Clear();
        }

        /// <summary>
        /// retrieves the web title cache
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static string GetWebTitle(System.Web.HttpRequest Request)
        {
            string page = Request.Url.ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            CacheItem item = GlobalClass.InternalCache.Get(String.Format("Page Title: {0}", page));

            if (item != null)
                return ((string)item.Value);

            string Result = String.IsNullOrEmpty(BaseWebApplication.PageTitle) ? "Heavenskincare.com" : BaseWebApplication.PageTitle;
            string customTitle = lib.LibraryHelperClass.SettingsGetMeta(String.Format("TITLE:{0}", page));

            if (!String.IsNullOrEmpty(customTitle))
                Result = customTitle;

            GlobalClass.InternalCache.Add(String.Format("Page Title: {0}", page), new CacheItem(String.Format("Page Title: {0}", page), Result));

            return (Result);
        }

        /// <summary>
        /// Retrieves the active user ID
        /// </summary>
        /// <returns></returns>
        private static Int64 GetUserID(System.Web.HttpRequest request, System.Web.HttpResponse response)
        {
            Int64 Result = -1;

            if (response != null)
            {
                if (response.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, BaseWebApplication.DistributorWebsite)] != null)
                {
                    HttpCookie cookie = response.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, BaseWebApplication.DistributorWebsite)];

                    //if (cookie.Expires.Year == 1)
                    //{

                    //}
                }
            }

            if (request.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, BaseWebApplication.DistributorWebsite)] != null)
            {
                HttpCookie cookie = request.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, BaseWebApplication.DistributorWebsite)];

                if (cookie.Expires.Year == 1 || cookie.Expires >= DateTime.Now)
                {
                    string s1 = GlobalClass.Decrypt(HttpUtility.UrlDecode(request.Cookies[String.Format("{0}{1}Session", BaseWebApplication.CookiePrefix, BaseWebApplication.DistributorWebsite)].Value));

                    if (s1 != String.Empty)
                    {
                        Result = Shared.Utilities.StrToInt64(s1, -1);
                    }
                }
            }

            return (Result);
        }

        /// <summary>
        /// Retrieves the active user, if there is one
        /// </summary>
        /// <returns></returns>
        private static User GetUser(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request,  System.Web.HttpResponse Response, UserSession session)
        {
            return (lib.BOL.Users.User.UserGet(GetUserID(Request, Response)));
        }

        /// <summary>
        /// Determines wether a user is logged in or not
        /// </summary>
        /// <returns></returns>
        private static bool UserIsLoggedOn(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request, System.Web.HttpResponse Response, UserSession session)
        {
            LocalWebSessionData userData = (LocalWebSessionData)session.Tag;
            return (userData.LoggedIn);
        }

        /// <summary>
        /// Retrieves the country for the user
        /// </summary>
        /// <returns></returns>
        private static string GetUserCountry(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request, System.Web.HttpResponse Response, UserSession userSession)
        {
            string remoteIP = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
            remoteIP = GetFormValue(Request, "FakeAddress", remoteIP);
#endif

            lib.BOL.IPAddresses.IPCity city = GlobalGeoIPCityCache.GetIPCity(remoteIP);

            string country = city == null ? "ZZ" : city.Country;

            if (country == "Unknown")
                country = "ZZ";

            if (!UserIsLoggedOn(Session, Request, Response, userSession))
            {
                return (country);
                //return (lib.Website.IPAddressToCountry(remoteIP));
            }
            else
            {
                User user = GetUser(Session, Request, Response, (UserSession)Session[StringConstants.SESSION_NAME_USER_SESSION]);

                if (user == null)
                {
                    return (country);
                    //return (lib.Website.IPAddressToCountry(remoteIP));
                }
                else
                {
                    if (user.Country == null)
                    {
                        return (country);
                        //return (lib.Website.IPAddressToCountry(remoteIP));
                    }
                    else
                    {
                        return (GetUser(Session, Request, Response, userSession).Country.CountryCode);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the website Country
        /// </summary>
        public static Country WebCountry(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request)
        {
            Country Result = null;

            if (Session[StringConstants.SESSION_NAME_WEBSITE_COUNTRY] != null)
                return ((Country)Session[StringConstants.SESSION_NAME_WEBSITE_COUNTRY]);
            else
            {
                string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
                ipAddress = GetFormValue(Request, "FakeAddress", ipAddress);
#endif

                Result = Countries.Get(lib.LibraryHelperClass.IPAddressToCountry(ipAddress));

                if (Result == null || Result.CountryCode == "ZZ" || BaseWebApplication.ForceInitialDefaultLanguage)
                    Result = Countries.Get(BaseWebApplication.DefaultCountrySettings);

                Session[StringConstants.SESSION_NAME_WEBSITE_COUNTRY] = Result;
            }

            return (Result);
        }

        public static void CookieSetValue(HttpRequest Request, HttpResponse Response,
            string cookieName, string value, DateTime expires, bool isSessionCookie = false)
        {
            HttpCookie cookie = new HttpCookie(cookieName, HttpUtility.UrlEncode(SharedUtils.Encrypt(value)));

            if (!Request.IsLocal)
                cookie.Domain = BaseWebApplication.CookieRootURL;

            if (!isSessionCookie)
                cookie.Expires = expires;

            cookie.Path = "/";
            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Retrieves a cookie value
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        /// <param name="CookieName">Name of cookie</param>
        /// <param name="Default">Default value if not available</param>
        /// <returns></returns>
        public static string CookieGetValue(
            HttpRequest Request, HttpResponse Response, 
            string CookieName, string Default)
        {
            string Result = String.Empty;

            if (Request.Cookies[CookieName] != null)
            {
                Result = Request.Cookies[CookieName].Value;
            }

            // if its not found check if its just been added
            if (String.IsNullOrEmpty(Result))
            {
                if (Response.Cookies[CookieName] != null)
                    Result = Response.Cookies[CookieName].Value;
            }

            if (String.IsNullOrEmpty(Result))
                return (Default);

            Result = SharedUtils.Decrypt(HttpUtility.UrlDecode(Result));

            // if its still not found return the default value
            if (String.IsNullOrEmpty(Result) || Result.Length == 0)
                Result = Default;


            return (Result);
        }

        #region Private Consts


        #endregion Private Consts


        public static void ApplicationStart()
        {
            lib.BOL.Countries.Countries.Get();

            using (TimedLock.Lock(_basketLockObject))
            {
                _maximumBasketIdendifer = lib.LibraryHelperClass.GetBasketID(BaseWebApplication.BasketIDIncrement);
                _currentBasketIdentifier = _maximumBasketIdendifer - BaseWebApplication.BasketIDIncrement;
            }
        }

        private static object _basketLockObject = new object();
        private static Int64 _currentBasketIdentifier = 0;
        private static Int64 _maximumBasketIdendifer = 0;
        private static TimeSpan _basketLockSpan = new TimeSpan(0, 0, 0, 0, 50);

        private static Int64 GetNextBasketID()
        {
            try
            {
                using (TimedLock.Lock(_basketLockObject, _basketLockSpan))
                {
                    if (_maximumBasketIdendifer == 0 || _currentBasketIdentifier == _maximumBasketIdendifer)
                    {
                        _maximumBasketIdendifer = lib.LibraryHelperClass.GetBasketID(BaseWebApplication.BasketIDIncrement);
                        _currentBasketIdentifier = _maximumBasketIdendifer - BaseWebApplication.BasketIDIncrement;
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

        public static UserSession StartUserSession(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request, System.Web.HttpResponse Response)
        {
            UserSession Result = null;

            try
            {
#if TRACE
                DateTime startSessionTimer = DateTime.Now;
#endif
                if (Request.UserAgent != null && Request.UserAgent.StartsWith(CLOUD_USER_AGENT))
                {
                    return (Result);
                }

#if DISPLAY_DEBUG_INFO
                Session[StringConstants.SESSION_NAME_SESSION_INITIATED] = "Start Session";
#endif
                Result = new UserSession(Session, Request);

                UserSessionManager.Add(Result);
                Session[StringConstants.SESSION_NAME_USER_SESSION] = Result;

                if (Website.Library.Classes.BaseWebApplication.StaticWebSite)
                    return (Result);

                Result.Tag = new LocalWebSessionData();
                LocalWebSessionData localData = (LocalWebSessionData)Result.Tag;

                localData.CurrentUser = GetUser(Session, Request, Response, Result);
                localData.Basket = GetShoppingBasket(Session, Request, Response, Result);

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
                    string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
                ipAddress = GetFormValue(Request, "FakeAddress", ipAddress);
#endif

                    lib.BOL.IPAddresses.IPCity city = Library.Classes.GlobalGeoIPCityCache.GetIPCity(ipAddress);

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


                #region Affiliate

                string affiliate = SharedWebBase.CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_AFFILIATE, BaseWebApplication.DistributorWebsite), String.Empty);

                if (String.IsNullOrEmpty(affiliate))
                {
                    if (!String.IsNullOrEmpty(Request["aff"]))
                    {
                        affiliate = Request["aff"];
                    }
                    else if (!String.IsNullOrEmpty(Result.InitialReferrer))
                    {
                        affiliate = lib.BOL.Affiliate.AffiliatedItems.Get(Result.InitialReferrer);
                    }

                    if (!String.IsNullOrEmpty(affiliate))
                    {
                        AffiliatedItem affItem = lib.BOL.Affiliate.AffiliatedItems.GetAffiliate(affiliate);

                        if (affItem != null)
                        {
                            affItem.AddWebClick(Result.IPAddress);

                            SharedWebBase.CookieSetValue(Request, Response,
                                String.Format(StringConstants.COOKIE_AFFILIATE, BaseWebApplication.DistributorWebsite),
                                affiliate, DateTime.Now.AddDays(BaseWebApplication.AffiliateMaxDays));
                        }
                    }
                }

                localData.AffiliateID = affiliate;

                #endregion Affiliate

                lib.BOL.Countries.Country defaultCountry = SharedWebBase.WebCountry(Session, Request);
                Currency defaultCurrency = lib.BOL.Basket.Currencies.Get(defaultCountry.DefaultCurrency);

                string userLanguage = CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_USER_LANGUAGE, BaseWebApplication.DistributorWebsite),
                    defaultCountry.CountryCode);
                string userCurrency = CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_USER_CURRENCY, BaseWebApplication.DistributorWebsite),
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

                if (BaseWebApplication.WebsiteCultureOverride)
                {
                    localData.Culture = BaseWebApplication.WebsiteCulture.Name;
                }
                else
                {
                    localData.Culture = localData.UserCountry.Culture;
                }

                localData.Basket.Country = localData.UserCountry;

                localData.Basket.Currency = Currencies.Get(localData.UserCountry.DefaultCurrency);
                Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = localData.Basket.Currency;

                LocalizedLanguages.SetLanguage(Session, Request, Response,
                    localData.UserCountry,
                    SharedWebBase.WebsiteCurrency(Session, Request), false);

                // default sesion data
                Session["CurrentPage"] = 1;
                Session["Discount_Ammount"] = 0;
                Session["USER_DISCOUNT"] = 0;
                Session["INVOICE_NUMBER"] = 0;
                Session["SHOPPINGBASKET_ID"] = 0;
                Session["PRODUCT_FILTER"] = 0;

                int priceCol = LocalizedLanguages.RaiseSelectPriceColumn(Session, Request, Result,
                    userSelectedCurrency == null ? defaultCurrency.PriceColumn : userSelectedCurrency.PriceColumn);
                localData.PriceColumn = priceCol; 
                Session[StringConstants.SESSION_NAME_WEBSITE_PRICE_COLUMN] = localData.PriceColumn;
                localData.Basket.Reset(localData.PriceColumn);

                LocalizedLanguages.SetLanguage(Session, Request, Response,
                    userSelectedCountry == null ? defaultCountry : userSelectedCountry,
                    userSelectedCurrency == null ? defaultCurrency : userSelectedCurrency, true);

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

        public static void UserSessionContinue(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request, System.Web.HttpResponse Response, ref UserSession session)
        {
            try
            {

#if DISPLAY_DEBUG_INFO
                Session[StringConstants.SESSION_NAME_SESSION_INITIATED] = "Resume Session";
#endif

                if (Request.UserAgent != null && Request.UserAgent.StartsWith(CLOUD_USER_AGENT))
                    return;

                if (session == null)
                {
                    session = StartUserSession(Session, Request, Response);
                }

                Session[StringConstants.SESSION_NAME_USER_SESSION] = session;

                if (Website.Library.Classes.BaseWebApplication.StaticWebSite)
                    return;

                session.Tag = new LocalWebSessionData();
                LocalWebSessionData localData = (LocalWebSessionData)session.Tag;

                localData.CurrentUser = GetUser(Session, Request, Response, session);
                localData.Basket = GetShoppingBasket(Session, Request, Response, session);

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
                    string ipAddress = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
                    ipAddress = GetFormValue(Request, "FakeAddress", ipAddress);
#endif

                    localData.CountryCode = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
                    localData.UserCountry = Countries.Get(localData.CountryCode);
                    localData.LoggedIn = false;
                }

                #region Affiliate

                string affiliate = SharedWebBase.CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_AFFILIATE, BaseWebApplication.DistributorWebsite), String.Empty);

                if (String.IsNullOrEmpty(affiliate))
                {
                    if (!String.IsNullOrEmpty(Request["aff"]))
                    {
                        affiliate = Request["aff"];
                    }
                    else if (!String.IsNullOrEmpty(session.InitialReferrer))
                    {
                        affiliate = lib.BOL.Affiliate.AffiliatedItems.Get(session.InitialReferrer);
                    }

                    if (!String.IsNullOrEmpty(affiliate))
                    {
                        AffiliatedItem affItem = lib.BOL.Affiliate.AffiliatedItems.GetAffiliate(affiliate);

                        if (affItem != null)
                        {
                            SharedWebBase.CookieSetValue(Request, Response,
                                String.Format(StringConstants.COOKIE_AFFILIATE, BaseWebApplication.DistributorWebsite),
                                affiliate, DateTime.Now.AddDays(BaseWebApplication.AffiliateMaxDays));
                        }
                    }
                }

                localData.AffiliateID = affiliate;

                #endregion Affiliate

                lib.BOL.Countries.Country defaultCountry = SharedWebBase.WebCountry(Session, Request);
                Currency defaultCurrency = lib.BOL.Basket.Currencies.Get(defaultCountry.DefaultCurrency);

                string userLanguage = CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_USER_LANGUAGE, BaseWebApplication.DistributorWebsite),
                    defaultCountry.CountryCode);
                string userCurrency = CookieGetValue(Request, Response,
                    String.Format(StringConstants.COOKIE_USER_CURRENCY, BaseWebApplication.DistributorWebsite),
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
                localData.Culture = localData.UserCountry.Culture;
                localData.Basket.Country = localData.UserCountry;

                localData.Basket.Currency = Currencies.Get(localData.UserCountry.DefaultCurrency);
                Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = localData.Basket.Currency;

                // default sesion data
                Session["CurrentPage"] = 1;
                Session["Discount_Ammount"] = 0;
                Session["USER_DISCOUNT"] = 0;
                Session["INVOICE_NUMBER"] = 0;
                Session["SHOPPINGBASKET_ID"] = 0;
                Session["PRODUCT_FILTER"] = 0;

                //Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = userSelectedCurrency ==
                //    null ? defaultCurrency : userSelectedCurrency;

                int priceCol = LocalizedLanguages.RaiseSelectPriceColumn(Session, Request, session,
                    userSelectedCurrency == null ? defaultCurrency.PriceColumn : userSelectedCurrency.PriceColumn);
                localData.PriceColumn = priceCol;
                localData.Basket.Reset(localData.PriceColumn);
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }
        }

        public static void ResetDeliveryAddress(System.Web.SessionState.HttpSessionState Session, 
            UserSession userSession)
        {
            LocalWebSessionData localData = (LocalWebSessionData)userSession.Tag;
            localData.DeliveryAddressID = -1;
            localData.Basket.ShippingAddress = null;
        }

        public static void UserLogin(System.Web.SessionState.HttpSessionState session, User user,
            System.Web.HttpRequest request, System.Web.HttpResponse response, UserSession userSession)
        {

            UserSessionManager.Login(session.SessionID, user.UserName, user.Email, user.ID);
            LocalWebSessionData localData = (LocalWebSessionData)userSession.Tag;

            localData.CurrentUser = user;
            localData.UserCountry = user.Country;
            localData.CountryCode = user.Country.CountryCode;
            localData.MemberLevel = (int)user.MemberLevel;
            localData.LoggedIn = true;
            localData.Basket.User = user;

            localData.Culture = user.Country.Culture;

            //for each item in the basket, reset the price depending on the new price option
            localData.Basket.Reset(localData.PriceColumn);

            if (user.MemberLevel == lib.MemberLevel.GoldUser)
            {
                localData.Basket.ApplyDiscount(user.AutoDiscount, "Gold Club");
            }

            LocalizedLanguages.SetLanguage(session, request, response,
                localData.UserCountry,
                SharedWebBase.WebsiteCurrency(session, request), false);
        }

        public static void UserLogout(System.Web.SessionState.HttpSessionState session,
            System.Web.HttpRequest request, UserSession userSession)
        {
            LocalWebSessionData localData = (LocalWebSessionData)userSession.Tag;
            localData.CurrentUser = null;

            string ipAddress = request.ServerVariables["REMOTE_HOST"];
            localData.CountryCode = lib.LibraryHelperClass.IPAddressToCountry(ipAddress);
            localData.UserCountry = lib.BOL.Countries.Countries.Get(localData.CountryCode);

            localData.Culture = localData.UserCountry.Culture;
            
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
        /// Changes the currency for the website
        /// </summary>
        /// <param name="Session">Current Users Session</param>
        /// <param name="forceChange">if true then the change is forced, if false it looks to see 
        /// if previously set and if not set's it</param>
        public static void SetCurrency(System.Web.SessionState.HttpSessionState Session, Currency currency, bool forceChange)
        {
            if (currency == null)
                throw new InvalidOperationException();

            // if, and only if there is no currency, then set it now
            if (forceChange || Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] == null)
            {
                // default currency is users country currency, if it's accepted
                if (currency != null && currency.IsActive)
                {
                    Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = currency;
                }
            }

        }

        /// <summary>
        /// Retrieves the shopping basket for the current user
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="Request"></param>
        /// <returns></returns>
        private static ShoppingBasket GetShoppingBasket(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request, System.Web.HttpResponse Response, UserSession userSession)
        {
            ShoppingBasket Result = null;

            LocalWebSessionData userData = null;

            if (userSession != null && userSession.Tag != null)
            {
                userData = (LocalWebSessionData)userSession.Tag;

                if (userData.Basket != null)
                    return (userData.Basket);
            }

            Currency basketCurrency = null;

            if (Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] == null)
            {
                basketCurrency = Currencies.Get(System.Threading.Thread.CurrentThread.CurrentUICulture);
                Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = basketCurrency;
            }
            else
            {
                basketCurrency = (Currency)Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY];
            }

            if (Session[StringConstants.SESSION_NAME_SHOPPING_ID] == null)
            {
                if (userData.CurrentUser != null)
                {
                    if (userData.Basket != null)
                    {
                        Result = GetUser(Session, Request, Response, userSession).Basket;

                        if (Result.FreeShipping != BaseWebApplication.FreeShippingAllow)
                            Result.FreeShipping = BaseWebApplication.FreeShippingAllow;

                        if (Result.FreeShippingAmount != BaseWebApplication.FreeShippingAmount)
                            Result.FreeShippingAmount = BaseWebApplication.FreeShippingAmount;

                        return (Result);
                    }
                }

                string BasketID = "new";
                Country country = userData.UserCountry;

                if (country == null)
                    country = Countries.Get(GetUserCountry(Session, Request, Response, userSession));

                // has the user got a cookie
                if (Request.Cookies[GlobalClass.BasketName] != null)
                {
                    BasketID = GlobalClass.Decrypt(HttpUtility.UrlDecode(Request.Cookies[GlobalClass.BasketName].Value));

                    if (BasketID == null || BasketID.Length == 0)
                    {
                        BasketID = "new";
                    }
                }

                if (BasketID == "new")
                {
                    Result = new ShoppingBasket(GetNextBasketID(), country, Currencies.Get(country.DefaultCurrency), 
                        BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount, 
                        BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, true);

                    CookieSetValue(Request, Response, GlobalClass.BasketName, Result.ID.ToString(), DateTime.Now.AddDays(365));
                }
                else
                {
                    if (!basketCurrency.IsActive)
                    {
                        basketCurrency = lib.BOL.Basket.Currencies.Get(
                            WebCountry(Session, Request).DefaultCurrency);
                        Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = basketCurrency;
                    }

                    try
                    {

                        Result = new ShoppingBasket(Convert.ToInt32(BasketID), userData.UserCountry, 
                            basketCurrency, BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount,
                            BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, false);

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
                        Result = new ShoppingBasket(-1, WebCountry(Session, Request), basketCurrency, 
                            BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount, 
                            BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, true);

                        SharedWebBase.CookieSetValue(Request, Response, GlobalClass.BasketName, Result.ID.ToString(), 
                            DateTime.Now.AddDays(365));
                    }

                }

                if (userData.CurrentUser != null)
                {
                    Result.User = userData.CurrentUser;
                }

                Session[StringConstants.SESSION_NAME_SHOPPING_ID] = Result.ID;
            }
            else
            {
                Int64 basketID = (Int64)Session[StringConstants.SESSION_NAME_SHOPPING_ID];
                Result = new ShoppingBasket(Convert.ToInt32(basketID), userData.UserCountry, 
                    basketCurrency, BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount,
                    BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, false);
            }

            if (Result.MaximumItemQuantity != BaseWebApplication.MaximumItemQuantity)
                Result.MaximumItemQuantity = BaseWebApplication.MaximumItemQuantity;

            if (Result.User == null)
            {
                User user = userData.CurrentUser;

                if (user != null)
                    Result.User = user;
            }

            Result.WebSessionID = Session.SessionID;

            Result.ClearBasketOnPayment = BaseWebApplication.ClearBasketOnPayment;

            if (userData.CurrentUser != null && userData.DeliveryAddressID > -1)
            {
                Result.ShippingAddress = lib.BOL.DeliveryAddress.DeliveryAddresses.Get(userData.DeliveryAddressID);
            }

            if (userData != null && userData.Basket == null)
                userData.Basket = Result;

            return (Result);
        }

        public static ShoppingBasket GetShoppingBasket(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request, System.Web.HttpResponse Response)
        {
            ShoppingBasket Result = null;

            Currency basketCurrency = null;

            if (Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] == null)
            {
                basketCurrency = Currencies.Get(System.Threading.Thread.CurrentThread.CurrentUICulture);
                Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = basketCurrency;
            }
            else
            {
                basketCurrency = (Currency)Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY];
            }

            string remoteIP = Request.ServerVariables["REMOTE_HOST"];

#if FAKE_ADDRESS
            remoteIP = GetFormValue(Request, "FakeAddress", remoteIP);
#endif

            Country country = Countries.Get(lib.LibraryHelperClass.IPAddressToCountry(remoteIP));

            if (Session[StringConstants.SESSION_NAME_SHOPPING_ID] == null)
            {
                string BasketID = "new";

                // has the user got a cookie
                if (Request.Cookies[GlobalClass.BasketName] != null)
                {
                    BasketID = GlobalClass.Decrypt(HttpUtility.UrlDecode(Request.Cookies[GlobalClass.BasketName].Value));

                    if (BasketID == null || BasketID.Length == 0)
                    {
                        BasketID = "new";
                    }
                }

                if (BasketID == "new")
                {
                    Result = new ShoppingBasket(GetNextBasketID(), country, Currencies.Get(country.DefaultCurrency),
                        BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount,
                        BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, true);

                    CookieSetValue(Request, Response, GlobalClass.BasketName, Result.ID.ToString(), DateTime.Now.AddDays(365));
                }
                else
                {
                    if (!basketCurrency.IsActive)
                    {
                        basketCurrency = lib.BOL.Basket.Currencies.Get(
                            WebCountry(Session, Request).DefaultCurrency);
                        Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = basketCurrency;
                    }

                    try
                    {

                        Result = new ShoppingBasket(Convert.ToInt32(BasketID), country,
                            basketCurrency, BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount,
                            BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, false);
                    }
                    catch
                    {
                        //problem getting users basket, create a new one
                        Result = new ShoppingBasket(-1, WebCountry(Session, Request), basketCurrency,
                            BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount,
                            BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, true);

                        SharedWebBase.CookieSetValue(Request, Response, GlobalClass.BasketName, Result.ID.ToString(),
                            DateTime.Now.AddDays(365));
                    }

                }

                Session[StringConstants.SESSION_NAME_SHOPPING_ID] = Result.ID;
            }
            else
            {
                Int64 basketID = (Int64)Session[StringConstants.SESSION_NAME_SHOPPING_ID];
                Result = new ShoppingBasket(Convert.ToInt32(basketID), country,
                    basketCurrency, BaseWebApplication.FreeShippingAllow, BaseWebApplication.FreeShippingAmount,
                    BaseWebApplication.PricesIncludeVAT, BaseWebApplication.ShippingIsTaxable, false);
            }

            if (Result.MaximumItemQuantity != BaseWebApplication.MaximumItemQuantity)
                Result.MaximumItemQuantity = BaseWebApplication.MaximumItemQuantity;

            Result.WebSessionID = Session.SessionID;

            Result.ClearBasketOnPayment = BaseWebApplication.ClearBasketOnPayment;

            return (Result);
        }

        /// <summary>
        /// Returns the current website currency used for payment
        /// </summary>
        public static Currency WebsiteCurrency(System.Web.SessionState.HttpSessionState Session, 
            System.Web.HttpRequest Request)
        {
            Currency Result = null;

            if (Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] == null)
            {
                Result = Currencies.Get(WebCountry(Session, Request).DefaultCurrency);
                Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY] = Result;
            }
            else
            {
                Result = (Currency)Session[StringConstants.SESSION_NAME_USER_BASKET_CURRENCY];
            }

            if (!Result.IsActive)
            {
                Result = lib.BOL.Basket.Currencies.Get(WebCountry(Session, Request).DefaultCurrency);
            }

            return (Result);
        }

        /// <summary>
        /// Global handler for error handling
        /// </summary>
        /// <param name="error"></param>
        /// <param name="Session"></param>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        public static void HandleException(Exception error, int httpErrorCode)
        {
            string fullMessage = error.Message;
            try
            {
                string Inner = "Unknown";
                string Message = "Unknown";
                string Source = "Unknown";
                string StackTrace = "Unknown";
                string TargetSite = "Unknown";
                string _session = "Unknown";

                if (error != null)
                {
                    Inner = error.InnerException == null ? "InnerException is null" : error.InnerException.ToString();
                    Message = error.Message;
                    Source = error.Source;
                    StackTrace = error.StackTrace;
                    TargetSite = error.TargetSite == null ? "TargetSite is null" : error.TargetSite.ToString();
                }

                fullMessage += " " + Inner;

                // invalid view state?  if so ignore  or dangerous request
                if (fullMessage.Contains("viewstate MAC failed") || Message.Contains("state information is invalid for this page"))
                {
                    HttpContext.Current.Response.Redirect(BaseWebApplication.RootURL + HttpContext.Current.Request.Path, true);
                    return;
                }

                try
                {
                    // can't connect to the database, clear all connections from the pool
                    if (fullMessage.Contains("connection shutdown") ||
                        fullMessage.Contains("Error reading data from the connection") ||
                        fullMessage.Contains("Unable to complete network request to host"))
                    {
                        lib.DAL.DALHelper.ResetDatabasePool(false);
                    }

                    if (fullMessage.Contains("Database is probably already opened by another engine instance in another Windows session"))
                    {
                        // special case, clear all connections and kill all connections in the database
                        lib.DAL.DALHelper.ResetDatabasePool(true);
                    }

                    if (fullMessage.Contains("Unable to connect to database"))
                    {
                        HttpContext.Current.Response.Redirect(BaseWebApplication.RootURL + "/Error/ServerTooBusy.aspx", true);
                        return;
                    }

                    if (fullMessage.Contains("Connection pool is full"))
                    {
                        HttpContext.Current.Response.Redirect(BaseWebApplication.RootURL + "/Error/ServerTooBusy.aspx", true);
                        return;
                    }
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains("no permission for DELETE access to TABLE"))
                        throw;
                }


                // not interested in some messages so filter them here
                if (!IgnoreErrorMessage(fullMessage))
                {
                    string UserData = "";

                    string Msg = String.Format("<P>User Session: {5}</P><P>Error Message: {0}</P>" +
                        "<P>Inner Exception: {1}</P><P>Source: {2}</P>" +
                        "<P>StackTrace: {3}</P><P>Target Site: {4}</P><h2>User Data</h2>{5}<h2>Path</h2><p>{6}</p>",
                        Message, Inner, Source, StackTrace, TargetSite, _session, UserData,
                        HttpContext.Current.Request != null ? HttpContext.Current.Request.Url.ToString() : String.Empty);

#if ERROR_MANAGER
                    BaseWebApplication.InitialiseErrorManager();
#endif

                   Shared.EventLog.Add(error);

#if ERROR_MANAGER
                   if (!ErrorClient.GetErrorClient.SendWebError(error, _session, Request.Url.AbsoluteUri, Request.Path))
                   {
                       try
                       {
                           //Failed to send error details to server
                           SendEMail(BaseWebApplication.SupportName, BaseWebApplication.SupportEMail,
                               String.Format("Website Error ({0})", BaseWebApplication.DistributorWebsite),
                               Msg, BaseWebApplication.SupportName, BaseWebApplication.SupportEMail);
                       }
                       catch
                       {
                           // do nothing, it is logged anyway
                       }
                    }
#else
                   SendEMail(BaseWebApplication.SupportName, BaseWebApplication.SupportEMail,
                       String.Format("Website Error ({0})", BaseWebApplication.DistributorWebsite),
                       Msg, BaseWebApplication.SupportName, BaseWebApplication.SupportEMail);

#endif
                }
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(error, "Original Error");
                Shared.EventLog.Add(err);
            }
        }



        public static bool IgnoreErrorMessage(string Error)
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


        #region Send Emails

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="ErrorMessage">Error Message</param>
        public static void SendEmail(string ErrorMessage)
        {
            SendEMail(BaseWebApplication.SupportName, BaseWebApplication.SupportEMail, 
                String.Format("Website Error ({0})", BaseWebApplication.DistributorWebsite), ErrorMessage);
        }

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Title">Title of email</param>
        public static void SendEmail(string Title, string Message)
        {
            SendEMail(BaseWebApplication.SupportName, BaseWebApplication.SupportEMail, Title, Message);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg)
        {
            SendEMail(ToName, ToEMail, Title, Msg, BaseWebApplication.NoReplyName, BaseWebApplication.NoReplyEmail);
        }

        public static void SendEMail(string Title, string Msg)
        {
            SendEMail(BaseWebApplication.SupportName, BaseWebApplication.SupportEMail, Title, Msg, 
                BaseWebApplication.NoReplyName, BaseWebApplication.NoReplyEmail);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg, string FromName, string FromEMail)
        {
            lib.BOL.Mail.Emails.Add(ToName, ToEMail, FromName, FromEMail, Title, Msg);

            if (!BaseWebApplication.SendEmails)
                return;
        }

        #endregion Send Emails

        #endregion Public Static Methods

        #region Private Static Methods

#if FAKE_ADDRESS
        private static string GetFormValue(System.Web.HttpRequest Request, string Name, string Default)
        {
            if (Request[Name] != null && Request[Name] != String.Empty)
                return (Request[Name]);
            else
                return (Default);
        }
#endif

        #endregion Private Static Methods
    }
}
