using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using SieraDelta.Shared.Classes;

namespace SieraDelta.Website.Library.Classes
{
    
    public class UserSessionManager : ThreadManager
    {
        #region Private Members

        private static object _lockObject = new object();

        private static List<UserSession> _userSessions = new List<UserSession>();

        private static object _tempLockObject = new object();

        private static List<UserSession> _tempUserSessions = new List<UserSession>();

        private static CacheManager _userSessionCacheManager = null;

        private static UserSessionManager _instance = null;

        #endregion Private Members

        #region Constructors

        public UserSessionManager()
            :base(null, new TimeSpan(0, 0, 5))
        {
            this.HangTimeout = 0;
            SieraDelta.Shared.Classes.ThreadManager.ThreadStart(this, "UserSessionManager", System.Threading.ThreadPriority.Lowest);
            _instance = this;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            using (TimedLock.Lock(_tempLockObject))
            {
                int moveCount = 0;

                for (int i = _tempUserSessions.Count -1; i >= 0; i--)
                {
                    moveCount++;

                    if (moveCount >= 200)
                        break;

                    using (TimedLock.Lock(_lockObject))
                    {
                        _userSessions.Add(_tempUserSessions[i]);
                    }

                    _tempUserSessions.RemoveAt(i);
                }
            }

            using (TimedLock.Lock(_lockObject))
            {
                for (int i = _userSessions.Count -1; i >= 0; i--)
                {
                    UserSession session = _userSessions[i];

                    switch (session.Status)
                    {
                        case SessionStatus.Updated:
                            _userSessions.Remove(session);
                            break;
                        case SessionStatus.Initialising:
                            InitialiseSession(session);
                            _userSessions.Remove(session);
                            break;
                        case SessionStatus.Closing:
                            FinaliseSession(session);
                            _userSessions.Remove(session);
                            session.Dispose();
                            session = null;
                            break;
                    }
                }
            }

            return (!this.HasCancelled());
        }

        #endregion Overridden Methods

        #region Private Methods

        /// <summary>
        /// Called in a seperate thread to website, updates thread with basic data to stop blocking the website
        /// </summary>
        /// <param name="session"></param>
        private void InitialiseSession(UserSession session)
        {
            if (session == null)
                return;

            try
            {
                if (!SieraDelta.Website.Library.Classes.BaseWebApplication.StaticWebSite)
                {
                    SieraDelta.Library.BOL.IPAddresses.IPCity city = SieraDelta.Library.BOL.IPAddresses.IPCity.Get(session.IPAddress, session.IPAddress);

                    session.Latitude = city.Latitude;
                    session.Longitude = city.Longitude;
                    session.Region = city.Region;
                    session.City = city.City;
                    session.CountryCode = city.Country;
                }

                // is it a bot
                session.IsBot = session.UserAgent.Contains("googlebot") ||
                            session.UserAgent.Contains("bingpreview") ||
                            session.UserAgent.Contains("/bingbot.htm") ||
                            session.UserAgent.Contains("ahrefs.com") ||
                            session.UserAgent.Contains("google.com/bot.html") ||
                            session.UserAgent.Contains("baidu.com/search/spider.html") ||
                            session.UserAgent.Contains("baidu.");

                // referral type
                if (String.IsNullOrEmpty(session.InitialReferrer))
                    session.Referal = ReferalType.Direct;

                //Direct, Organic, Referal

            }
            catch (Exception err)
            {
                SieraDelta.Shared.EventLog.Add(err);
            }
            finally
            {
                session.Status = SessionStatus.Updated;
            }
        }

        /// <summary>
        /// Session is closing, are we saving any data from it?
        /// </summary>
        /// <param name="session"></param>
        private void FinaliseSession(UserSession session)
        {

            session.Status = SessionStatus.Updated;
        }

        #endregion Private Methods

        #region Internal Methods

        internal void UpdateSession(UserSession session)
        {
            if (session.Status == SessionStatus.Updated)
                return;

            using (TimedLock.Lock(_tempLockObject))
            {
                _tempUserSessions.Add(session);
            }
        }

        #endregion Internal Methods

        #region Static Methods

        /// <summary>
        /// Initialises the SessionManager
        /// </summary>
        /// <param name="sessionDuration">Duration of session</param>
        public static void InitialiseSessionManager(TimeSpan sessionDuration)
        {
            if (_userSessionCacheManager == null)
            {
                _userSessionCacheManager = new CacheManager("Web User Sessions", sessionDuration, true, false);
                _userSessionCacheManager.ItemRemoved += _userSessionManger_ItemRemoved;
            }
        }

        /// <summary>
        /// Add's a new session to the Session Manager
        /// </summary>
        /// <param name="session"></param>
        public static void Add(UserSession session)
        {
            _userSessionCacheManager.Add(session.SessionID, new CacheItem(session.SessionID, session));
        }

        /// <summary>
        /// Called after a user logs in to update the username and email for the live session
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="username">Visitors Name</param>
        /// <param name="email">Visitors Email Address</param>
        public static void Login(string sessionID, string username, string email)
        {
            CacheItem cachedItem = _userSessionCacheManager.Get(sessionID);

            if (cachedItem != null)
            {
                UserSession session = (UserSession)cachedItem.Value;
                session.UserName = username;
                session.UserEmail = email;
            }
        }

        /// <summary>
        /// Event called when a user session is removed from cache for inactivity etc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void _userSessionManger_ItemRemoved(object sender, Shared.CacheItemArgs e)
        {
            //save statistics on user session
            if (e.CachedItem == null || e.CachedItem.Value == null)
                return;

            UserSession session = (UserSession)e.CachedItem.Value;
            session.Status = SessionStatus.Closing;
            _instance.UpdateSession(session);
        }

        #endregion Static Methods

        #region Static Properties

        /// <summary>
        /// CacheManager for user sessions
        /// </summary>
        public static List<UserSession> Clone
        {
            get
            {
                List<UserSession> Result = new List<UserSession>();

                BinaryFormatter bFormatter = new BinaryFormatter();
                try
                {
                    using (TimedLock.Lock(_lockObject))
                    {
                        foreach (CacheItem item in _userSessionCacheManager.CopyItems)
                        {
                            MemoryStream stream = new MemoryStream();
                            try
                            {
                                bFormatter.Serialize(stream, (UserSession)item.Value);
                                stream.Seek(0, SeekOrigin.Begin);
                                Result.Add((UserSession)bFormatter.Deserialize(stream));
                            }
                            finally
                            {
                                stream.Dispose();
                                stream = null;
                            }
                        }
                    }
                }
                finally
                {
                    bFormatter = null;
                }

                return (Result);
            }
        }

        /// <summary>
        /// Returns all cache manager items
        /// </summary>
        public static CacheManager UserSessions
        {
            get
            {
                return (_userSessionCacheManager);
            }
        }

        /// <summary>
        /// Count of active user sessions
        /// </summary>
        public static int Count
        {
            get
            {
                return (_userSessionCacheManager.Count);
            }
        }

        #endregion Static Properties
    }

    [Serializable]
    public class UserSession : IDisposable
    {
        #region Private Static Members

        private static UserSessionManager _sessionManager = new UserSessionManager();
        private static Regex MobileCheck = new Regex(@"android|(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
        private static Regex MobileVersionCheck = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

        #endregion Private Static Members

        #region Private Members

        private List<PageViewData> _pageViews = new List<PageViewData>();

        #endregion Private Members

        #region Constructor

        public UserSession(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request)
        {
            Bounced = true;
            Status = SessionStatus.Initialising;

            SieraDelta.Library.BOL.Users.User currUser = SharedWebBase.GetUser(Session, Request);

            if (currUser != null)
            {
                UserName = currUser.UserName;
                UserEmail = currUser.Email;
            }

            SessionID = Session.SessionID;
            IPAddress = Request.UserHostAddress;

            if (IPAddress == "::1")
                IPAddress = "127.0.0.1";

            HostName = Request.UserHostName;
            UserAgent = Request.UserAgent;
            IsMobileDevice = CheckIfMobileDevice(Request);
            IsBrowserMobile = Request.Browser.IsMobileDevice;

            MobileRedirect = IsMobileDevice | IsBrowserMobile;

            MobileManufacturer = Request.Browser.MobileDeviceManufacturer;
            MobileModel = Request.Browser.MobileDeviceModel;
            ScreenHeight = Request.Browser.ScreenPixelsHeight;
            ScreenWidth = Request.Browser.ScreenPixelsWidth;


            if (Request.UrlReferrer == null)
                Referal = ReferalType.Unknown;
            else
                InitialReferrer = Request.UrlReferrer.ToString();

            _sessionManager.UpdateSession(this);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// internal indicator on wether it's been processed by the UserSessionManger or not
        /// </summary>
        internal SessionStatus Status { get; set; }

        /// <summary>
        /// Unique Session ID
        /// </summary>
        public string SessionID { get; private set; }

        /// <summary>
        /// IP Address of User
        /// </summary>
        public string IPAddress { get; private set; }

        /// <summary>
        /// Host computer name for user
        /// </summary>
        public string HostName { get; private set; }

        /// <summary>
        /// User Agent
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// Is mobile device
        /// </summary>
        public bool IsMobileDevice { get; private set; }

        /// <summary>
        /// Is mobile device based on browser capabilities
        /// </summary>
        public bool IsBrowserMobile { get; private set; }

        /// <summary>
        /// Determines wether the user should be redirected to the mobile site
        /// </summary>
        public bool MobileRedirect { get; set; }

        /// <summary>
        /// Type of referral for session
        /// </summary>
        public ReferalType Referal { get; internal set; }

        /// <summary>
        /// Initial referring website
        /// </summary>
        public string InitialReferrer { get; set; }

        /// <summary>
        /// Bounced indicates wether the user came to the page and left the site without doing anything else
        /// </summary>
        public bool Bounced { get; private set; }

        /// <summary>
        /// User session is a bot
        /// </summary>
        public bool IsBot { get; internal set; }

        /// <summary>
        /// Country for visitor
        /// </summary>
        public string CountryCode { get; internal set; }

        /// <summary>
        /// Visitor Region
        /// </summary>
        public string Region { get; internal set; }

        /// <summary>
        /// Visitor city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Latitude for ip address
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude for ip address
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Name of logged on user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email for logged on user
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Mobile device manufacturer
        /// </summary>
        public string MobileManufacturer { get; private set; }

        /// <summary>
        /// Mobile device model
        /// </summary>
        public string MobileModel { get; private set; }

        /// <summary>
        /// Width of users screen
        /// </summary>
        public int ScreenWidth { get; private set; }

        /// <summary>
        /// Height of users screen
        /// </summary>
        public int ScreenHeight { get; private set; }

        /// <summary>
        /// List of pages visited by user
        /// </summary>
        public List<PageViewData> Pages 
        { 
            get
            {
                return (_pageViews);
            }
        }

        #endregion Properties

        #region Public Methods

        public void PageView(string page, string referrer, bool isPostBack)
        {
            _pageViews.Add(new PageViewData(page, referrer, isPostBack));
            int pages = _pageViews.Count -1;

            if (pages >= 1)
            {
                // calculate page time for previous page
                PageViewData previousPage = _pageViews[pages -1];
                previousPage.TotalTime = DateTime.Now - previousPage.TimeStamp;

                // not a bounce as already moved onto another page
                if (Bounced)
                    Bounced = false;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Detects wether the user session is from a mobile device or not
        /// 
        /// Stores the result as session state
        /// </summary>
        /// <param name="session">Current user session</param>
        /// <param name="request">WebRequest</param>
        /// <returns>bool, true if mobile device, otherwise false</returns>
        public static bool CheckIfMobileDevice(System.Web.HttpRequest request)
        {
            bool Result = false;

            string userAgent = request.ServerVariables["HTTP_USER_AGENT"];

            if (userAgent == null)
            {
                return (false);
            }

            if (userAgent.Length >= 4)
            {
                Result = (MobileCheck.IsMatch(userAgent) || MobileVersionCheck.IsMatch(userAgent.Substring(0, 4)));
            }

            return (Result);
        }


        #endregion Private Methods

        #region IDisposable

        public void Dispose()
        {
            _pageViews.Clear();
            _pageViews = null;
        }

        #endregion IDisposable
    }

    [Serializable]
    public sealed class PageViewData
    {
        #region Constructors

        public PageViewData(string url, string referringPage, bool isPostBack)
        {
            URL = url;
            Referrer = referringPage;
            IsPostBack = isPostBack;
            TimeStamp = DateTime.Now;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Page being viewed
        /// </summary>
        public string URL { get; private set; }

        /// <summary>
        /// Time page viewed
        /// </summary>
        public DateTime TimeStamp { get; private set; }

        /// <summary>
        /// Total time spent on page
        /// </summary>
        public TimeSpan TotalTime { get; internal set; }

        /// <summary>
        /// Referring web page, if any
        /// </summary>
        public string Referrer { get; private set; }

        /// <summary>
        /// Indicates wether it's a post back or not
        /// </summary>
        public bool IsPostBack { get; private set; }

        #endregion Properties

        #region Public Methods

        

        #endregion Public Methods
    }

    public enum ReferalType 
    { 
        /// <summary>
        /// Not a clue
        /// </summary>
        Unknown, 
        
        /// <summary>
        /// User typed url directly into the browser
        /// </summary>
        Direct, 
        
        /// <summary>
        /// Referral from a search engine
        /// </summary>
        Organic, 
        
        /// <summary>
        /// From a.n. other website
        /// </summary>
        Referal 
    }

    public enum SessionStatus { Initialising, Updated, Closing }
}
