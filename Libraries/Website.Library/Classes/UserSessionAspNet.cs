using System;

using Shared.Classes;



namespace Website.Library.Classes
{
    public class UserSessionAspNet : UserSession
    {

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public UserSessionAspNet()
            : base ()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="created"></param>
        /// <param name="sessionID"></param>
        /// <param name="userAgent"></param>
        /// <param name="initialReferer"></param>
        /// <param name="ipAddress"></param>
        /// <param name="hostName"></param>
        /// <param name="isMobile"></param>
        /// <param name="isBrowserMobile"></param>
        /// <param name="mobileRedirect"></param>
        /// <param name="referralType"></param>
        /// <param name="bounced"></param>
        /// <param name="isBot"></param>
        /// <param name="mobileManufacturer"></param>
        /// <param name="mobileModel"></param>
        /// <param name="userID"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        /// <param name="saleCurrency"></param>
        /// <param name="saleAmount"></param>
        public UserSessionAspNet(long id, DateTime created, string sessionID, string userAgent, string initialReferer,
            string ipAddress, string hostName, bool isMobile, bool isBrowserMobile, bool mobileRedirect,
            ReferalType referralType, bool bounced, bool isBot, string mobileManufacturer, string mobileModel,
            long userID, int screenWidth, int screenHeight, string saleCurrency, decimal saleAmount)
            : base (id, created, sessionID, userAgent, initialReferer, ipAddress, hostName, isMobile,
                  isBrowserMobile, mobileRedirect, referralType, bounced, isBot, mobileManufacturer, mobileModel,
                  userID, screenWidth, screenHeight, saleCurrency, saleAmount)
        {
        }

        /// <summary>
        /// Constructor
        /// 
        /// Allows passing of user defined object
        /// </summary>
        /// <param name="Session">Current User Session</param>
        /// <param name="Request">Current Web Request</param>
        /// <param name="tag">User defined object</param>
        public UserSessionAspNet(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request, object tag)
            : this(Session, Request)
        {
            Tag = tag;
            InternalSessionID = -1;
        }

        /// <summary>
        /// Constructor
        /// 
        /// Allows passing of user name and email
        /// </summary>
        /// <param name="Session">Current User Session</param>
        /// <param name="Request">Current Web Request</param>
        /// <param name="userName">Current user's name</param>
        /// <param name="userEmail">Current user's email address</param>
        /// <param name="userID">Current user's unique id</param>
        public UserSessionAspNet(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request, string userName, string userEmail,
            Int64 userID)
            : this(Session, Request)
        {
            UserName = userName;
            UserEmail = userEmail;
            UserID = userID;
        }

        /// <summary>
        /// Constructor
        /// 
        /// Standard constructor
        /// </summary>
        /// <param name="Session">Current User Session</param>
        /// <param name="Request">Current Web Request</param>
        public UserSessionAspNet(System.Web.SessionState.HttpSessionState Session,
            System.Web.HttpRequest Request)
            : base ()
        {
            Created = DateTime.Now;
            Bounced = true;
            CurrentSale = 0.00m;
            CurrentSaleCurrency = String.Empty;
            Tag = null;

            SessionID = Session.SessionID;
            IPAddress = Request.UserHostAddress;

            if (IPAddress == "::1")
                IPAddress = "127.0.0.1";

#if FAKE_ADDRESS
            IPAddress = GetFormValue(Request, "FakeAddress", IPAddress);
#endif

            HostName = Request.UserHostName;
            UserAgent = Request.UserAgent;
            IsMobileDevice = CheckIfMobileDevice(UserAgent);
            IsBrowserMobile = Request.Browser.IsMobileDevice;

            MobileRedirect = IsMobileDevice | IsBrowserMobile;

            MobileManufacturer = Request.Browser.MobileDeviceManufacturer;
            MobileModel = Request.Browser.MobileDeviceModel;
            ScreenHeight = Request.Browser.ScreenPixelsHeight;
            ScreenWidth = Request.Browser.ScreenPixelsWidth;

            try
            {
                if (Request.UrlReferrer == null)
                    Referal = ReferalType.Unknown;
                else
                    InitialReferrer = Request.UrlReferrer.ToString();
            }
            catch (Exception err)
            {
                if (!err.Message.Contains("The hostname could not be parsed"))
                    throw;
            }

            CountryCode = String.Empty;

            UserName = String.Empty;
            UserEmail = String.Empty;
            UserID = -1;

            UserSessionManager.UpdateSession(this);

            SaveStatus = SaveStatus.Pending;
            PageSaveStatus = SaveStatus.Saved;
            InternalSessionID = Int64.MinValue;
        }

        #endregion Constructor

        #region Private Methods

#if FAKE_ADDRESS
        
        /// <summary>
        /// Retrieves a form value
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="Name"></param>
        /// <param name="Default"></param>
        /// <returns></returns>
        private static string GetFormValue(System.Web.HttpRequest Request, string Name, string Default)
        {
            string Result = String.Empty;

            if (Request[Name] != null && Request[Name] != String.Empty)
                Result = Request[Name];
            else
                Result = Default;

            return (Result);
        }

#endif

        #endregion Private Methods
    }
}
