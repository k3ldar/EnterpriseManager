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
 *  File: SessionMiddleware.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

#if TRACE
using System.Diagnostics;
#endif

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Website.Library.Core.Interfaces;

using Shared.Classes;

namespace Website.Library.Core.Services
{
    public class SessionMiddleware
    {
        #region Private Static Members

        private static CacheManager _sessionCache = new CacheManager(
            "Session Cache", new TimeSpan(0, 20, 0), true, false);

        #endregion Private Static Members

        #region Private Members

        private RequestDelegate _next;
        private static int _cookieID;
        private static string _cookieName = "my.custom.cookie";
        private static string _cookieEncryptionKey = "Dfklaosre;lnfsdl;jlfaeu;dkkfcaskxcd3jf";

        private IMemoryCache _memoryCache;
        private IBaseServices _baseService;

        #endregion Private Members

        #region Constructors

        public SessionMiddleware()
        {
            
        }

        public SessionMiddleware(IMemoryCache memoryCache, IBaseServices baseService)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));
        }

        #endregion Constructors

        #region Public Methods

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
#if TRACE
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
#endif
            try
            {
                if (_memoryCache == null)
                    _memoryCache = (IMemoryCache)Initialisation.GetServiceProvider.GetRequiredService<IMemoryCache>();

                if (_baseService == null)
                    _baseService = (IBaseServices)Initialisation.GetServiceProvider.GetService(typeof(IBaseServices));

                if (context.Session != null)
                {
                    string cookieSessionID;
                    CookieOptions options = new CookieOptions
                    {
                        HttpOnly = false
                    };

                    if (context.Request.Cookies.ContainsKey(_cookieName))
                    {
                        cookieSessionID = Shared.Utilities.Decrypt(context.Request.Cookies[_cookieName], _cookieEncryptionKey);
                        context.Response.Cookies.Append(_cookieName,
                            Shared.Utilities.Encrypt(cookieSessionID, _cookieEncryptionKey), options);
                    }
                    else
                    {
                        cookieSessionID = GetNextID(context);
                        context.Response.Cookies.Append(_cookieName,
                            Shared.Utilities.Encrypt(cookieSessionID, _cookieEncryptionKey), options);
                    }

                    context.Items.Add("CookieSessionID", cookieSessionID);

                    CacheItem currentSession = _memoryCache.GetSessionCache().Get(cookieSessionID);
                    UserSession userSession;

                    if (currentSession != null)
                    {
                        userSession = (UserSession)currentSession.Value;
                    }
                    else
                    {
                        userSession = _baseService.GetUserSession(context);
                        _memoryCache.GetSessionCache().Add(cookieSessionID, new CacheItem(cookieSessionID, userSession));
                    }

                    string referrer = context.Request.Headers["Referer"];

                    userSession.PageView(_baseService.GetAbsoluteUri(context).ToString(),
                        referrer ?? String.Empty, false);
                    context.Items.Add("UserSession", userSession);
                }

#if TRACE
                stopwatch.Stop();
                context.Items.Add("UserSessionTimings", stopwatch.ElapsedMilliseconds);
                System.Diagnostics.Debug.WriteLine(String.Format("Total Session Middleware Time {0} ms - Thread ID {1}",
                    stopwatch.ElapsedMilliseconds.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
#endif
            }
            catch (Exception error)
            {
                ILogging logging = (ILogging)Initialisation.GetServiceProvider.GetService(typeof(ILogging));
                logging.LogError(System.Reflection.MethodBase.GetCurrentMethod(), error);
            }
            finally
            {
                await _next(context);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private string GetNextID(HttpContext context)
        {
            return (string.Format("SN{0}{1}", DateTime.Now.ToFileTimeUtc(), _cookieID++));
        }

        #endregion Private Methods
    }
}