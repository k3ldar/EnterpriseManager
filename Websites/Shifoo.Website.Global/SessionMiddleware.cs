using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Shifoo.Website.Global;
using Shared.Classes;

namespace Shifoo.Website.Global
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

        #endregion Private Members

        #region Public Methods

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string cookieID;
            CookieOptions options = new CookieOptions
            {
                HttpOnly = false
            };

            if (!context.Request.Cookies.ContainsKey(_cookieName))
            {
                cookieID = GetNextID(context);
                context.Response.Cookies.Append(_cookieName,
                    Shared.Utilities.Encrypt(cookieID, _cookieEncryptionKey), options);
            }
            else
            {
                cookieID = Shared.Utilities.Decrypt(context.Request.Cookies[_cookieName], _cookieEncryptionKey);
                context.Response.Cookies.Append(_cookieName,
                    Shared.Utilities.Encrypt(cookieID, _cookieEncryptionKey), options);
            }

            context.Items.Add("SessionID", cookieID);

            await _next(context);
        }

        #endregion Public Methods

        #region Private Methods

        private string GetNextID(HttpContext context)
        {
            return (string.Format("SN{0}{1}", DateTime.Now.ToString("ddMMyyyyhhmmss"), _cookieID++));
        }

        #endregion Private Methods
    }
}