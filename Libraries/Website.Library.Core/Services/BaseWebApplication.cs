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
 *  File: BaseWebApplication.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using lib = Library;
using Library.BOL.Mail;
using Library.BOL.MissingLinks;
using Library.BOL.Websites;

#if ERROR_MANAGER
using ErrorManager.ErrorClient;
#endif

using Shared;
using Shared.Classes;
using Library.BOL.IPAddresses;

using Website.Library.Core.Classes;
using Website.Library.Core.Interfaces;
using Website.Library.Core.Threads;

namespace Website.Library.Core.Services
{
    [Serializable]
    public class BaseWebApplication : IBaseWebApplication
    {
        #region Private Members

        private readonly IMemoryCache _memoryCache;

        private readonly IBaseServices _baseServices;

        private readonly ILocalizedLanguages _localizedLanguages;

        private readonly ILogging _logging;

        private readonly IGeoIPLocation _geoIPLocation;

        /// <summary>
        /// Number of minutes for a session to timeout
        /// </summary>
        private const int SESSION_TIME_OUT_MINUTES = 20;

        /// <summary>
        /// Lock object for exclusive access
        /// </summary>
        private static object _lockObject = new object();

        /// <summary>
        /// Unique ID of website for sites that share a database
        /// </summary>
        private static int _websiteID = 1;

        private static System.Configuration.AppSettingsReader configurationAppSettings;

        private static bool _loadsettings = true;

        private static DateTime _lastLoadAttempt = DateTime.Now.AddDays(-1);
        private static int _loadAttempts = 0;

        private static bool _initialiseThreads = true;

        #endregion Private Members

        #region Internal Members

        internal static BaseWebApplication BaseWebAppInstance { get; set; }

        /// <summary>
        /// Indicates all loaded as expected
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        internal bool IsLoaded
        {
            get
            {
                if (_loadsettings)
                {
                    TimeSpan span = DateTime.Now - _lastLoadAttempt;

                    if (_loadAttempts < 10 && span.TotalSeconds > 180)
                    {
                        _loadAttempts++;

                        if (InitialiseWebsite())
                            _loadsettings = false;

                    }
                }

                return (!_loadsettings);
            }
        }

        internal static object EmailLockObject = new object();

        internal static ArrayList _emailServerHistory = new ArrayList();

        #endregion Internal Members

        #region Public Members

        public static Dictionary<string, Int64> AllRoutes = new Dictionary<string, Int64>();


        public static bool AllowMobileWebsite = false;

        /// <summary>
        /// Determines wether mail subscription is shown on the website or not
        /// </summary>

        public static string CookieRootURL;

        /// <summary>
        /// Date and time website was started
        /// </summary>
        public static DateTime DateLoaded;

        public static string RootHost;


        public static string CookiePrefix { get; set; }



        public static int InvoiceVersion = 6;


        public static string DefaultStyle = "Default";

        public static string CSSCookieName = "style_cookie";



        public static bool ShowDistributorsMenu { get; set; }








        #endregion Public Members

        #region Constructors

        public BaseWebApplication(IMemoryCache memoryCache, IBaseServices baseServices, 
            ILocalizedLanguages localizedLanguages, ILogging logging, IGeoIPLocation geoIPLocation)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _baseServices = baseServices ?? throw new ArgumentNullException(nameof(baseServices));
            _localizedLanguages = localizedLanguages ?? throw new ArgumentNullException(nameof(localizedLanguages));
            _logging = logging ?? throw new ArgumentNullException(nameof(logging));
            _geoIPLocation = geoIPLocation ?? throw new ArgumentNullException(nameof(geoIPLocation));

            // load default settings
            if (_loadsettings)
            {
                try
                {
                    RoutineMaintenance.ImageLocations.Clear();
                    lib.DAL.DALHelper.AllowCaching = true;

                    if (InitialiseWebsite())
                    {
                        _loadsettings = false;

                        RoutineMaintenance.ImageLocations.Add(new ImageCreateLocation(
                            String.Format("{0}Images\\Product\\", WebsiteSettings.RootPath),
                            "*_148.*", "ProductImages", String.Format("{0}Download\\ProductImages.xml",
                            WebsiteSettings.RootPath)));

                        RoutineMaintenance.ImageLocations.Add(new ImageCreateLocation(
                            String.Format("{0}Images\\", WebsiteSettings.RootPath),
                            "*.*", "Images", String.Format("{0}download\\Images.xml",
                            WebsiteSettings.RootPath)));
                    }
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err);
                }
            }

            BaseWebAppInstance = this;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates wether the website is a static website or interactive
        /// </summary>
        

        /// <summary>
        /// Gets the current email status report
        /// </summary>
        public static ArrayList StatusReport
        {
            get
            {
                using (TimedLock.Lock(EmailLockObject))
                {
                    return (_emailServerHistory);
                }
            }
        }


        #endregion Properties

        #region Secondary Background  Tasks


        private void CreateInitializationThread()
        {
            if (ThreadManager.Exists("Auto Rule Update"))
                ThreadManager.Cancel("Auto Rule Update");

            if (ThreadManager.Exists("Routine Maintenance"))
                ThreadManager.Cancel("Routine Maintenance");

            if (ThreadManager.Exists("GeoIP Update"))
                ThreadManager.Cancel("GeoIP Update");

            if (ThreadManager.Exists("Email Send Thread"))
                ThreadManager.Cancel("Email Send Thread");

            if (ThreadManager.Exists("Update Site Map"))
                ThreadManager.Cancel("Update Site Map");

            if (ThreadManager.Exists("Routine Maintenance Campaigns"))
                ThreadManager.Cancel("Routine Maintenance Campaigns");

            if (!ThreadManager.Exists("Website Initialisation Thread Manager"))
                ThreadManager.ThreadStart(new WebsiteInitialisationThreadManager(this, _baseServices, _logging),
                    "Website Initialisation Thread Manager", ThreadPriority.Lowest);
        }


        #endregion Secondary Background Tasks

        #region Public Methods

        #region Global Configuration Settings


        #endregion Global Configuration Settings

        public bool SettingsLoaded()
        {
            return (!_loadsettings);
        }

        public void ReloadSettings()
        {
            try
            {
                if (WebsiteSettings.LoadWebsiteSettingsFromDatabase(_websiteID))
                    CreateInitializationThread();
            }
            catch (Exception error)
            {
                EventLog.Add(error);
            }

            #region Cookies

            CookiePrefix = "SD";

            #endregion Cookies



            BaseWebAppInstance.LoadCustomSettings();

            _memoryCache.ResetCaches();
            _localizedLanguages.ClearCountries();
        }

        public static bool IgnoreMissingPage(string page)
        {
            page = page.ToLower();

            if (page.Contains("scriptresource.axd") || page.Contains("Site-Error/Page-Not-Found/") || page.Contains("webresource.axd"))
                return (true);
            else
                return (false);
        }

        public virtual void LoadCustomSettings()
        {

        }

        /// <summary>
        /// User session created
        /// </summary>
        /// <param name="session">Session created</param>
        public virtual void SessionCreated(UserSession session)
        {

        }

        /// <summary>
        /// User Session closing
        /// </summary>
        /// <param name="session"></param>
        public virtual void SessionClosed(UserSession session)
        {

        }

        /// <summary>
        /// Allows the partial saving of data for the session
        /// </summary>
        /// <param name="session"></param>
        public virtual void SessionSaveData(UserSession session)
        {

        }

        public virtual void SessionSavePage(UserSession session, PageViewData page)
        {

        }

        /// <summary>
        /// Method called when a session needs to be retrieved
        /// </summary>
        /// <param name="session"></param>
        public virtual UserSession SessionRetrieve(string sessionID)
        {
            return (null);
        }

        #endregion Public Methods

        #region Protected Methods

        #region Error Manager

#if ERROR_MANAGER
        public static void InitialiseErrorManager()
        {
            // Code that runs when an unhandled error occurs
            ErrorClient.InitWebErrorClient(new ErrorManager.ErrorClient.Options("em.heavenskincare.com", 37789, "HeavenSkinCare", "Heaven_!3B"));
            ErrorClient.GetErrorClient.AdditionalInformation += new AdditionalInformationHandler(GetErrorClient_AdditionalInformation);
            Library.ErrorHandling.InternalException += ErrorHandling_InternalException;

        }
#endif

        #endregion Error Manager

        #region Application Events

        public void ApplicationStart()
        {
            // only keep logs for 7 days
            EventLog.Initialise(7);

            UserSessionManager.InitialiseSessionManager(new TimeSpan(0, SESSION_TIME_OUT_MINUTES, 0));

            using (TimedLock.Lock(_lockObject))
            {
                Shared.EventLog.Add("ApplicationStart");
                try
                {
                    if (_initialiseThreads)
                    {
                        EventLog.Add("Initialise Thread Manager");
                        ThreadManager.ThreadExceptionRaised += ThreadManager_ThreadExceptionRaised;
                        ThreadManager.ThreadAbortForced += ThreadManager_ThreadAbortForced;
                        ThreadManager.ThreadCancellAll += ThreadManager_ThreadCancellAll;
                        ThreadManager.ThreadForcedToClose += ThreadManager_ThreadForcedToClose;
                        ThreadManager.ThreadStarted += ThreadManager_ThreadStarted;
                        ThreadManager.ThreadStopped += ThreadManager_ThreadStopped;
                        ThreadManager.Initialise();
                        ThreadManager.AllowThreadPool = true;
                        ThreadManager.MaximumPoolSize = 100000;
                        _initialiseThreads = false;
                    }

                    //InitialiseWebDefender();
#if ERROR_MANAGER
                    InitialiseErrorManager();
#endif
                    
                    _baseServices.ApplicationStart();
                }
                catch (Exception err)
                {
                    EventLog.Add(err);
                }

                WebsiteSettings.WebFarm.Initialise();
            }
        }

        public void ApplicationEnd()
        {
            EventLog.Add("ApplicationEnd");

            WebsiteSettings.WebFarm.Close();

            // close session manager
            UserSessionManager.CancelAll();
            UserSessionManager.Finalise();

            //shut down internal threads
            Shared.EventLog.Add("Finalise Thread Manager");
            ThreadManager.Finalise();

            ThreadManager.ThreadAbortForced -= ThreadManager_ThreadAbortForced;
            ThreadManager.ThreadCancellAll -= ThreadManager_ThreadCancellAll;
            ThreadManager.ThreadForcedToClose -= ThreadManager_ThreadForcedToClose;
            ThreadManager.ThreadStarted -= ThreadManager_ThreadStarted;
            ThreadManager.ThreadStopped -= ThreadManager_ThreadStopped;
            _initialiseThreads = true;
        }

        #endregion Application Events

        protected bool IgnoreErrorMessage(string Error)
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

        public string CanRedirect(string File)
        {
            string Result = "";

            string s = File;

            //get the missing page
            int pos = s.IndexOf("'") + 1;

            s = s.Substring(pos);
            int i = 0;

            while (s.Contains("'"))
            {
                s = s.Substring(0, s.Length - 1);

                //as a safety precaution break out the loop after thirty iterations
                i++;

                if (i > 30)
                    break;
            }

            MissingLink link = MissingLinks.MissingLinkGet(s);

            if (link != null)
                Result = link.RedirectLink;

            return (Result);
        }

        protected void SetUserLastVisit(int iteration)
        {
#warning update the following code
            try
            {
                int Result = -1;

                //if (Request.Cookies[String.Format("{0}{1}Session", CookiePrefix, WebsiteSettings.DistributorWebsite)] != null)
                //{
                //    if (Request.Cookies[String.Format("{0}{1}Session", CookiePrefix, WebsiteSettings.DistributorWebsite)].Expires.Year != (DateTime.Now.Year - 1))
                //    {
                //        string s1 = Shared.Utilities.Decrypt(HttpUtility.UrlDecode(Request.Cookies[String.Format("{0}{1}Session", CookiePrefix, WebsiteSettings.DistributorWebsite)].Value));

                //        if (s1 != "")
                //        {
                //            Result = SharedUtils.StrToIntDef(s1, -1);
                //        }
                //    }
                //}

                if (Result > -1)
                {

                    lib.BOL.Users.User user = lib.BOL.Users.User.UserGet(Result);

                    if (user != null)
                    {
                        user.LastVisit = DateTime.Now;
                    }
                }
            }
            catch (Exception err)
            {
                if (err.Message.Contains("update conflicts with concurrent update"))
                {
                    if (iteration < 10)
                    {
                        SetUserLastVisit(iteration + 1);
                    }
                    else
                        throw;
                }
                else
                    throw;
            }
        }

        /// <summary>
        /// Determines whether to auto ban an ip address
        /// </summary>
        /// <param name="path">path of file being sought</param>
        /// <param name="ipAddress">ip address of user</param>
        /// <returns>true if ip address should be banned, otherwise false</returns>
        public static bool AutoBanIPAddress(string path, string ipAddress, bool ForceBan = false)
        {
            if (path.ToLower().Contains("/staff/"))
                return (false);

            if (path.ToLower().Contains("/admin/"))
                return (false);

            if (path.ToLower().Contains(".axd"))
                return (false);

            return (lib.WebsiteAdministration.AutoBanIPAddress(path, ipAddress, ForceBan));
        }

        /// <summary>
        /// Initialises all settings for the website
        /// </summary>
        protected bool InitialiseWebsite()
        {
            bool Result = false;

            try
            {
                WebsiteSettings.Maintenance.AutoMaintenanceMode = true;

                _lastLoadAttempt = DateTime.Now;

                if (!lib.DAL.DALHelper.TestConnection())
                    throw new Exception("TestConnection Failed");

                DateLoaded = DateTime.Now;

                try
                {
                    configurationAppSettings = new System.Configuration.AppSettingsReader();
                    _websiteID = ((int)(configurationAppSettings.GetValue("Settings.WebsiteID", typeof(int))));
                }
                catch
                {
                    _websiteID = 1;
                }

                lib.DAL.DALHelper.WebsiteID = _websiteID;

                if (!WebsiteSettings.LoadWebsiteSettingsFromDatabase(_websiteID))
                    throw new Exception("Failed to load settings from database");

                _memoryCache.GetCache().MaximumAge = lib.DAL.DALHelper.CacheLimit;

                LoadCustomSettings();

                // the following line will put currencies in cache for speed when
                // starting user sessions
                lib.BOL.Basket.Currencies.Get();

                UserSessionManager.InitialiseWebsite = false;
                UserSessionManager.Instance.IPAddressDetails += Instance_IPAddressDetails;

#if SAVE_SESSION_DATA
                UserSessionManager.Instance.OnSessionCreated += Instance_OnSessionCreated;
                UserSessionManager.Instance.OnSessionClosing += Instance_OnSessionClosing;
                UserSessionManager.Instance.OnSessionRetrieve += Instance_OnSessionRetrieve;
                UserSessionManager.Instance.OnSessionSave += Instance_OnSessionSave;
                UserSessionManager.Instance.OnSavePage += Instance_OnSavePage;
#endif

                ThreadManager.ThreadCpuChanged += ThreadManager_ThreadCpuChanged;
                Result = true;
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);

            }

            return (Result);
        }

        void ThreadManager_ThreadCpuChanged(object sender, EventArgs e)
        {
            //if (e.Thread.Name != "Management Thread")
            //{
            //Shared.EventLog.Add(String.Format("Thread Usage - Name: {0}; Process Usage: {1}; Previous Process Usage: {2}; System Usage: {3}",
            //    e.Thread.Name, e.Thread.ProcessCpuUsage.ToString("n1"), e.Thread.PreviousProcessCpuUsage.ToString("n1"), e.Thread.SystemCpuUsage.ToString("n1")));
            //}
        }

        #region SessionManager Events

        private void Instance_IPAddressDetails(object sender, IpAddressArgs e)
        {
#if CACHE_IP_CITY_DATA
            IPCity city = _geoIPLocation.GetIPCity(e.IPAddress, true);
#else
            IPCity city = _geoIPLocation.GetIPCity(e.IPAddress);
#endif

            if (city != null)
            {
                e.IPUniqueID = city.ID;
                e.Latitude = city.Latitude;
                e.Longitude = city.Longitude;
                e.Region = city.Region;
                e.CityName = city.City;
                e.CountryCode = city.Country;
            }
            else
                e.CountryCode = "ZZ";
        }

#if SAVE_SESSION_DATA
        void Instance_OnSessionRetrieve(object sender, UserSessionRequiredArgs e)
        {
            e.Session = SessionRetrieve(e.SessionID);
        }

        private void Instance_OnSessionClosing(object sender, Shared.UserSessionArgs e)
        {
            SessionClosed(e.Session);
        }

        private void Instance_OnSessionCreated(object sender, Shared.UserSessionArgs e)
        {
            SessionCreated(e.Session);
        }

        private void Instance_OnSavePage(object sender, UserPageViewArgs e)
        {
            SessionSavePage(e.Session, e.Page);
        }

        private void Instance_OnSessionSave(object sender, UserSessionArgs e)
        {
            SessionSaveData(e.Session);
        }
#endif

        #endregion SessionManager Events

        #endregion Protected Methods

        #region Internal Methods

        #endregion Internal Methods

        #region Public Methods

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
            SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, 
                Title, Msg, WebsiteSettings.Email.NoReplyName, WebsiteSettings.Email.NoReplyEmail);
        }

        public static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg, string FromName, string FromEMail)
        {
            Emails.Add(ToName, ToEMail, FromName, FromEMail, Title, Msg);

            if (!WebsiteSettings.Email.SendEmails)
                return;
        }

        #endregion Send Emails

        #endregion Public Methods

        #region Private Methods


        #region Thread Manager Events

        void ThreadManager_ThreadExceptionRaised(object sender, ThreadManagerExceptionEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Exception: {0}", e.Thread.ToString()));
            Shared.EventLog.Add(e.Error);
        }

        void ThreadManager_ThreadStopped(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Stopped: {0}", e.Thread.ToString()));
        }

        void ThreadManager_ThreadStarted(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Started: {0}", e.Thread.ToString()));
        }

        void ThreadManager_ThreadForcedToClose(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Forced To Close: {0}", e.Thread.ToString()));
        }

        void ThreadManager_ThreadCancellAll(object sender, EventArgs e)
        {
            Shared.EventLog.Add("Thread Cancell All: {0}");
        }

        void ThreadManager_ThreadAbortForced(object sender, ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format("Thread Abort Forced: {0}", e.Thread.ToString()));
        }

        #endregion Thread Manager Events


#if ERROR_MANAGER
        private static void GetErrorClient_AdditionalInformation(object sender, AdditionalInformationEventArgs e)
        {
            e.Information = DateTime.Now.ToString("g");
        }
#endif

        private static void ErrorHandling_InternalException(object sender, lib.BOLEvents.InternalErrorEventArgs e)
        {
            string msg = String.Format("Internal Exception in Website - {5}\r\n\r\nMethod: {0}\r\n\r\nMessage: {4}\r\n\r\nSource: {1}\r\n\r\nParameters:\r\n\r\n{2}\r\n\r\nCallstack:\r\n\r\n{3}",
                e.Method, e.Source, e.Parameters, e.CallStack, e.Message, WebsiteSettings.DistributorWebsite);

            try
            {
#if ERROR_MANAGER
                if (!ErrorClient.GetErrorClient.SendError(
                    new ErrorManager.ErrorClient.Options("em.heavenskincare.com", 37789, "Heavenskincare", "Heaven_!3B"),
                    msg))
                {
                    //Failed to send error details to server
                    SendEMail(SupportName, SupportEMail, String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
                        msg, SupportName, SupportEMail);
                }
#else
                SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, 
                    String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
                    msg, WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail);
#endif
            }
            catch (Exception err)
            {
                if (err.Message.Contains("Could not load file or assembly 'TCPMessageServer"))
                {
                    //Failed to send error details to server
                    SendEMail(WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail, 
                        String.Format("Website Error ({0})", WebsiteSettings.DistributorWebsite),
                        msg, WebsiteSettings.Email.SupportName, WebsiteSettings.Email.SupportEMail);
                }
                else
                    throw;
            }
        }

        #endregion Private Methods
    }
}
