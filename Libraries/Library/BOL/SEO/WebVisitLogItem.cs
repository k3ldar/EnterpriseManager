using System;
using System.Collections.Generic;
using System.Text;

using Shared.Classes;

namespace Library.BOL.SEO
{
    [Serializable]
    public sealed class WebVisitLogItem
    {
        #region Static Items

        #endregion Static Items

        #region Constructors

        public WebVisitLogItem(string platform, string browserVersion, string isCrawler,
            string remoteHost, string method, string path, string query,
            string referer, string userSession, string country)
        {
            Platform = platform;
            BrowserVersion = browserVersion;
            IsCrawler = isCrawler;
            RemoteHost = remoteHost;
            Method = method;
            Path = path;
            Query = query;
            Referer = referer;
            UserSession = userSession;
            Country = country;
            Date = DateTime.Now;
        }

        #endregion Constructors

        #region Properties

        public string Platform { get; private set; }
        public string BrowserVersion { get; private set; }
        public string IsCrawler { get; private set; }
        public string RemoteHost { get; private set; }
        public string Method { get; private set; }
        public string Path { get; private set; }
        public string Query { get; private set; }
        public string Referer { get; private set; }
        public string UserSession { get; private set; }
        public string Country { get; private set; }
        public DateTime Date { get; private set; }

        #endregion Properties

        #region Static Methods

        #endregion Static Methods
    }
}
