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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AppController.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

using SharedBase.BOL.Users;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Basket;
using SharedBase.BOL.Countries;
using SharedBase.BOLEvents;
using SharedBase;

using Shared;
using Shared.Communication;
using Shared.Classes;
using POS.Base.Forms;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Base.Classes
{
    public class AppController : IMessageFilter, IDisposable
    {
        #region Constants

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_SETFOCUS = 0x0007;

        private const int VK_TAB = 0x09;


        #endregion Constants

        #region Private Members

        private User _user;
        private User _previousUser;
        
        internal MessageClient _client;
        private bool _isBarcode = false;
        private string _scanBuffer;
        private Appointments _allAppointments = null;

        internal DateTime _loggedOn;
        internal DateTime _lastActivity;

        #endregion Private Members

        #region Static Members

        internal static bool _validInstall = false;

        private static bool _isApplicationRunning = false;

        private static bool _isShuttingDown = false;
        private static Forms.SplashScreen _splash = null;

        internal static AppController _appController;
        private static bool _autoLogout = false;

        private static UserSettings _localSettings;

        /// <summary>
        /// Default System User Account
        /// </summary>
        private static User _defaultSystemUser;

        private static Country _localCountry;
        private static Currency _localCurrency;

        /// <summary>
        /// Lock object for thread safe operations
        /// </summary>
        private static object _lockObject = new object();

        #endregion Static Members

        #region Static Methods

        /// <summary>
        /// Returns the physical folder location for a folder used by the pos
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="addBackSlash"></param>
        /// <returns></returns>
        public static string POSFolder(FolderType folder, bool addBackSlash)
        {
            string Result = Shared.Utilities.CurrentPath(true);

            switch (folder)
            {
                case FolderType.Root:
                    break;
                case FolderType.Dictionary:
                    Result += StringConstants.FOLDER_DICTIONARY;
                    break;
                case FolderType.Images:
                    Result += StringConstants.FOLDER_IMAGES;
                    break;
                case FolderType.Backups:
                    Result += StringConstants.FOLDER_BACKUPS;
                    break;
                case FolderType.Marketing:
                    Result += StringConstants.FOLDER_MARKETING;
                    break;
                case FolderType.Languages:
#if !DEBUG
                    Result += StringConstants.FOLDER_LANGUAGES;
#endif
                    break;
                case FolderType.Error:
                    Result += StringConstants.FOLDER_ERRORS;
                    break;
                case FolderType.Plugins:
                    Result += StringConstants.FOLDER_PLUGIN;
                    break;
                case FolderType.Temp:
                    Result += StringConstants.FOLDER_TEMP;
                    break;
                case FolderType.Help:
                    Result += StringConstants.FOLDER_HELP;
                    break;
                default:
                    throw new Exception(StringConstants.ERROR_INVALID_FOLDER_TYPE);
            }

            if (addBackSlash)
                Result = Shared.Utilities.AddTrailingBackSlash(Result);

            if (!System.IO.Directory.Exists(Result))
                System.IO.Directory.CreateDirectory(Result);

            return (Result);
        }


        public static string POSFolder(ImageTypes imageType)
        {
            string Result = POSFolder(FolderType.Images, true);
            Result = Utilities.AddTrailingBackSlash(Result) + imageType.ToString();
            return (Utilities.AddTrailingBackSlash(Result));
        }

        /// <summary>
        /// Determines wether the splash screen is showing or not
        /// </summary>
        /// <returns></returns>
        public static bool SplashScreenShowing()
        {
            return (_splash != null);
        }

        /// <summary>
        /// Shows the splash screen
        /// </summary>
        public static void ShowSplashScreen()
        {
            if (_splash == null)
            {
                _splash = new Forms.SplashScreen();
            }

            _splash.Show();
            _splash.Update(Languages.LanguageStrings.AppInitialising, 0);
        }

        /// <summary>
        /// Updates the splash screen
        /// </summary>
        /// <param name="message"></param>
        /// <param name="progressPosition"></param>
        public static void UpdateSplashScreen(string message, int progressPosition = 0)
        {
            if (_splash != null && !_isShuttingDown)
            {
                _splash.Update(message, progressPosition);
            }
        }

        /// <summary>
        /// hides the splash screen
        /// </summary>
        public static void HideSplashScreen()
        {
            if (_splash != null)
            {
                System.Threading.Thread.Sleep(1000);

                if (_splash != null)
                {
                    _splash.Hide();
                    _splash.Dispose();
                    _splash = null;
                }
            }
        }

        /// <summary>
        /// Logs out of the POS
        /// </summary>
        public static void Logout()
        {
            if (_appController._client.IsConnected)
                _appController._client.StopListening();

            _appController.CloseLogoutThread();
        }

        /// <summary>
        /// Sets the local country which defines the local culture
        /// </summary>
        public static void UpdateCountry()
        {
            _localCountry = Countries.Get(_localSettings.DefaultCountry);
        }

        #endregion Static Methods

        #region Public Static Properties

        /// <summary>
        /// Determines wether the pos install is valid or not (i.e. licenced)
        /// </summary>
        public static bool POSInstallValid
        {
            get
            {
                return (_validInstall);
            }
        }

        /// <summary>
        /// Determines wether the pos installation can be validated or not
        /// 
        /// i.e. has the validation thread finished running?
        /// 
        /// returns true if the POSInstallValid parameter can be reliably read or not
        /// </summary>
        public static bool CanValidatePOS
        {
            get
            {
                ThreadManager validationThread = ThreadManager.Find(StringConstants.THREAD_NAME_INSTALL_VALID);

                if (validationThread == null)
                    return (true);
                else
                    return (false);
            }
        }

        /// <summary>
        /// Get's current user
        /// </summary>
        public static AppController ApplicationController
        {
            get
            {
                using (TimedLock.Lock(_lockObject))
                {
                    if (_appController == null)
                    {
                        _appController = new AppController();
                        Application.AddMessageFilter(_appController);
                        _appController.UserTimeOut = LocalSettings.AutoLogoutTimeOut;

                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(LocalSettings.CustomUICulture);
                    }
                }

                return (_appController);
            }
        }

        public static bool ApplicationRunning
        {
            get
            {
                return (_isApplicationRunning);
            }
        }

        /// <summary>
        /// Gets local settings for installation/user
        /// </summary>
        public static UserSettings LocalSettings
        {
            get
            {
                if (_localSettings == null)
                {
                    _localSettings = UserSettings.LoadSettings();

                    // after loading local settings, some of them can be replaced with what is in the database
                    LoadDatabaseSettings(_localSettings);
                }

                if (_localCountry == null)
                {
                    _localCountry = Countries.Get(_localSettings.DefaultCountry);
                }

                return (_localSettings);
            }
        }

        /// <summary>
        /// Returns the currently active user
        /// </summary>
        public static User ActiveUser
        {
            get
            {
                if (_appController._user == null)
                    _appController._user = new User(-1, StringConstants.USER_DEFAULT_NO_EMAIL,
                        StringConstants.USER_DEFAULT_FIRST_NAME, StringConstants.USER_DEFAULT_LAST_NAME, String.Empty,
                        DateTime.Now, String.Empty, String.Empty, String.Empty, String.Empty,
                        String.Empty, String.Empty, String.Empty, MemberLevel.StaffMember,
                        0, String.Empty, false, false, false, false, DateTime.Now, String.Empty,
                        Enums.UserRecordType.Default, 0);

                return (_appController._user);
            }
        }

        /// <summary>
        /// Default system user account
        /// </summary>
        public static User DefaultSystemUser
        {
            get
            {
                return (_defaultSystemUser);
            }
        }

        /// <summary>
        /// determines wether the user can auto logout or not
        /// </summary>
        public static bool AutoLogout
        {
            set
            {
                _autoLogout = value;
            }

            get
            {
                return (_autoLogout);
            }
        }

        /// <summary>
        /// Local currency for creating invoices and orders
        /// </summary>
        public static Currency LocalCurrency
        {
            get
            {
                if (_localCurrency == null)
                    _localCurrency = Currencies.Get(LocalCountry.DefaultCurrency);

                return (_localCurrency);
            }
        }

        /// <summary>
        /// Local country for creating orders
        /// </summary>
        public static Country LocalCountry
        {
            get
            {
                return (_localCountry);
            }

        }

        /// <summary>
        /// Local culture used by POS
        /// </summary>
        public static CultureInfo LocalCulture
        {
            get
            {
                return (System.Threading.Thread.CurrentThread.CurrentUICulture);
            }
        }

        /// <summary>
        /// Returns an instance of the Administration Object
        /// </summary>
        public static WebsiteAdministration Administration { get; private set; }

        /// <summary>
        /// Active form within the POS
        /// </summary>
        public static BaseForm ActiveForm { get; set; }

        public static string ActiveHelpTopic { get; set; }

        public static bool IsShuttingDown
        {
            get
            {
                return (_isShuttingDown);
            }
        }

        #endregion Public Static Properties

        #region Constructors

        public AppController()
        {
            _isApplicationRunning = true;

            ThreadManager.ThreadStopped += ThreadManager_ThreadStopped;
            ThreadManager valThread = new POSInstallationValidThread();
            valThread.HangTimeout = 1;
            ThreadManager.ThreadStart(valThread,
                StringConstants.THREAD_NAME_INSTALL_VALID, ThreadPriority.Highest);

            _isBarcode = false;

            _client = new MessageClient(WebsiteAdministration.Server, 3424);
            try
            {
                _client.ClientIDChanged += _client_ClientIDChanged;
                _client.OnError += _client_OnError;
                _client.MessageReceived += _client_MessageReceived;
                _client.Connected += _client_Connected;
                _client.Disconnected += _client_Disconnected;
                //_client.StartListening();
            }
            catch
            {
                //ignore if can't connect
            }

            CreateServiceListnerThread();

            InterceptBarcodes = true;

            SharedBase.DAL.DALHelper.HideVATOnWebsiteAndInvoices = LocalSettings.HideVATOnOrdersAndInvoices;
            SharedBase.BOL.Appointments.Appointments.OnNewAppointment += Appointments_OnNewAppointment;

            _defaultSystemUser = SharedBase.BOL.Users.User.SystemUser();
        }

        ~AppController()
        {
            if (_client != null && _client.IsConnected)
            {
                _client.StopListening();
                _client = null;
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Returns the client ID
        /// </summary>
        public string ClientID
        {
            get
            {
                return (_client.ClientID);
            }
        }

        /// <summary>
        /// Determines wether the client TCP is connected or not
        /// </summary>
        public bool ClientConnected
        {
            get
            {
                if (_client == null)
                    return (false);
                else
                    return (_client.IsRunning & _client.IsConnected);
            }
        }

        /// <summary>
        /// Current User
        /// </summary>
        public User GetUser
        {
            get
            {
                return (_user);
            }

            set
            {
                _previousUser = value == null ? null : _user != null && _user.ID == -1 ? null : _user;
                _user = value;

                if (_user == null)
                {
                    SharedBase.DAL.DALHelper.RoleName = String.Empty;
                    Administration = null;
                    User sysUser = User.UserGet("System_User");
                    Administration = new WebsiteAdministration(sysUser);
                }
                else
                {
                    Administration = new WebsiteAdministration(_user);

                    if (!Parameters.OptionExists(StringConstants.PARAM_IGNORE_ROLE))
                    { 
                        SharedBase.DAL.DALHelper.RoleName = String.Format("{0}",
                            _user.Email, _user.LastName).Replace("@", "$").Replace(".", "_").Replace("-", "_").ToUpper();
                    }
                }

                SharedBase.DAL.DALHelper.SetCurrentUser(_user);
                _lastActivity = DateTime.Now;
                RaiseOnUserChanged();

                if (value != null)
                {
                    if (ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.CreateNewProducts))
                        CreateProductWatchThread();

                    CreateAutoLogoutThread();
                }
            }
        }

        /// <summary>
        /// Length of time in seconds before user times out for inactivity
        /// </summary>
        public uint UserTimeOut
        {
            get;
            set;
        }

        /// <summary>
        /// If true barcodes are intercepted and raised as an event
        /// </summary>
        public bool InterceptBarcodes
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves all users
        /// </summary>
        //public Users AllUsers
        //{
        //    get
        //    {
        //        return (_allUsers);
        //    }

        //    internal set
        //    {
        //        _allUsers = value;
        //    }
        //}

        /// <summary>
        /// Returns all appointments
        /// </summary>
        public Appointments AllAppointments
        {
            get
            {
                return (_allAppointments);
            }

            internal set
            {
                _allAppointments = value;
            }
        }

        #endregion Properties

        #region Private Methods

        #region Help

        public static void ShowHelpFile()
        {
            const string defaultPage = "userinterface";

            string activetopic = String.IsNullOrEmpty(ActiveHelpTopic) ? defaultPage : ActiveHelpTopic;

            Help.ShowHelp(ActiveForm, POSFolder(FolderType.Help, true) + "sbm.chm",
                HelpNavigator.Topic, activetopic + ".html");
        }

        #endregion Help

        #region Event Handlers

        /// <summary>
        /// Thread stopped running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadManager_ThreadStopped(object sender, ThreadManagerEventArgs e)
        {
            if (e.Thread.Name == StringConstants.THREAD_NAME_INSTALL_VALID)
            {
                if (!_isShuttingDown && PosValidationFinished != null)
                    PosValidationFinished(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// On New Appointment Created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Appointments_OnNewAppointment(object sender, NewAppointmentArgs e)
        {
            if (_allAppointments != null && _allAppointments.Find(e.Appointment.ID) == null)
            {
                _allAppointments.Add(e.Appointment);
            }
        }

        #endregion Event Handlers

        #region Thread Methods

        private void CreateProductWatchThread()
        {
            if (ThreadManager.Exists(StringConstants.THREAD_NAME_PRODUCT_WATCH))
            {
                ValidateProductsForWebsite thread = (ValidateProductsForWebsite)ThreadManager.Find(StringConstants.THREAD_NAME_PRODUCT_WATCH);
                thread.FeaturedProductMissing -= productWatchThread_FeaturedProductMissing;
                thread.GiftWrapMissing -= productWatchThread_GiftWrapMissing;
                thread.GiftWrapPriceWrong -= productWatchThread_GiftWrapPriceWrong;
                thread.CarouselProductsMissing -= productWatchThread_CarouselProductsMissing;

                ThreadManager.Cancel(StringConstants.THREAD_NAME_PRODUCT_WATCH);
            }

            ValidateProductsForWebsite productWatchThread = new ValidateProductsForWebsite(false);
            productWatchThread.FeaturedProductMissing += productWatchThread_FeaturedProductMissing;
            productWatchThread.GiftWrapMissing += productWatchThread_GiftWrapMissing;
            productWatchThread.GiftWrapPriceWrong += productWatchThread_GiftWrapPriceWrong;
            productWatchThread.CarouselProductsMissing += productWatchThread_CarouselProductsMissing;
            ThreadManager.ThreadStart(productWatchThread, StringConstants.THREAD_NAME_PRODUCT_WATCH, ThreadPriority.Lowest);
        }

        void productWatchThread_CarouselProductsMissing(object sender, EventArgs e)
        {
            if (ApplicationController.CarouselProductsMissing != null)
                ApplicationController.CarouselProductsMissing(this, e);
        }

        private void productWatchThread_GiftWrapPriceWrong(object sender, EventArgs e)
        {
            if (ApplicationController.GiftWrapPriceWrong != null)
                ApplicationController.GiftWrapPriceWrong(this, e);
        }

        private void productWatchThread_GiftWrapMissing(object sender, EventArgs e)
        {
            if (ApplicationController.GiftWrapMissing != null)
                ApplicationController.GiftWrapMissing(this, e);
        }

        private void productWatchThread_FeaturedProductMissing(object sender, EventArgs e)
        {
            if (ApplicationController.FeaturedProductMissing != null)
                ApplicationController.FeaturedProductMissing(this, e);
        }

        private void CreateServiceListnerThread()
        {
            if (!ThreadManager.Exists(StringConstants.THREAD_NAME_COMMUNICATION_LISTENER))
            {
                CommunicationServiceThreadClass service = new CommunicationServiceThreadClass();
                ThreadManager.ThreadStart(service, StringConstants.THREAD_NAME_COMMUNICATION_LISTENER, ThreadPriority.Lowest);
            }
        }

        private void CreateAutoLogoutThread()
        {
            if (_autoLogout)
            {
                CloseLogoutThread();
                _loggedOn = DateTime.Now;
                _lastActivity = DateTime.Now;

                AutoLogoutThreadClass autoLogout = new AutoLogoutThreadClass();
                ThreadManager.ThreadStart(autoLogout, StringConstants.THREAD_NAME_AUTO_LOGOUT, ThreadPriority.Lowest);
            }
        }

        public void CloseLogoutThread()
        {
            if (ThreadManager.Exists(StringConstants.THREAD_NAME_AUTO_LOGOUT))
                ThreadManager.Cancel(StringConstants.THREAD_NAME_AUTO_LOGOUT);
        }

        #endregion Thread Methods

        #region TCP Client Methods

        private void _client_Disconnected(object sender, EventArgs e)
        {
            if (!_isShuttingDown)
                RaiseClientConnectionChanged();
        }

        private void _client_Connected(object sender, EventArgs e)
        {
            RaiseClientConnectionChanged();
            _client.SendMessage(new Shared.Communication.Message(StringConstants.REPLICATION_IS_REPLICATING, String.Empty, MessageType.Command));
        }

        private void ProcessCommandMessages(Shared.Communication.Message message)
        {
            if (message.Title == StringConstants.REPLICATION_ID_CHANGED)
            {
                string[] paramaters = message.Contents.Split(StringConstants.SYMBOL_DOLLAR_CHAR);
                Int64 oldID = Convert.ToInt64(paramaters[0]);
                Int64 newID = Convert.ToInt64(paramaters[1]);
                string table = paramaters[2];

                switch (table)
                {
                    case StringConstants.REPLICATION_APPOINTMENTS:
                        RaiseAppointmentIDChanged(oldID, newID);
                        break;

                    case StringConstants.REPLICATION_USERS:
                        //using (TimedLock.Lock(_allUsers))
                        //{
                        //    foreach (User user in _allUsers)
                        //    {
                        //        if (user.ID == oldID)
                        //        {
                        //            user.ID = newID;
                        //            break;
                        //        }
                        //    }
                        //}

                        RaiseUserIDChanged(oldID, newID);
                        break;
                    default:
                        RaiseReplicationIDChanged(table, oldID, newID);
                        break;
                }
            }
        }

        private void _client_MessageReceived(object sender, Shared.Communication.Message message)
        {
            switch (message.Type)
            {
                case MessageType.Command:
                    ProcessCommandMessages(message);

                    break;
                case MessageType.Info:
                    switch (message.Contents)
                    {
                        case StringConstants.REPLICATION_END:
                            RaiseReplicationComplete();
                            break;

                        case StringConstants.REPLICATION_RUN:
                            RaiseReplicationStart();
                            break;
                    }

                    break;
                case MessageType.Acknowledge:
                    switch (message.Title)
                    {
                        case StringConstants.REPLICATION_IS_REPLICATING:
                            if (message.Contents == StringConstants.TRUE)
                                RaiseReplicationStart();

                            break;
                    }

                    break;
            }

            //send message to everything that wants it
            RaiseOnMessageReceived(message);
        }

        private void _client_OnError(object sender, ErrorEventArgs e)
        {
            e.Continue = !e.Error.Message.Contains(StringConstants.ERROR_INVALID_INPUT_STREAM);
        }

        private void _client_ClientIDChanged(object sender, EventArgs e)
        {

        }

        #endregion TCP Client Methods

        #region All Users / Appointments

        private void LoadAllAppointments()
        {
            DateTime maxAge = LocalSettings.DiaryMinimumDate;

            if (!LocalSettings.DiaryUseMinimumDate)
                maxAge = DateTime.Now.AddMonths(-1);

            LoadAllAppointmentsThread allAppointments = new LoadAllAppointmentsThread(maxAge);
            allAppointments.ThreadFinishing += allAppointments_ThreadFinishing;
            ThreadManager.ThreadStart(allAppointments, StringConstants.THREAD_NAME_LOAD_ALL_APPOINTMENTS, ThreadPriority.Highest);
        }

        void allAppointments_ThreadFinishing(object sender, Shared.ThreadManagerEventArgs e)
        {
            if (_splash != null && !_isShuttingDown)
                _splash.AppointmentsLoaded();
        }

        private void progress_OnProgress(object sender, ProgressEventArgs e)
        {
            //if (_splash != null)
                _splash.Update(e.Max, e.Percent);

                Application.DoEvents();
        }

        #endregion All Users / Appointments

        #region Local Settings

        /// <summary>
        /// Some settings are saved in the database and shared across all installations
        /// </summary>
        /// <param name="settings"></param>
        private static void SaveDatabaseSettings(UserSettings settings)
        {
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_BUSINESS_NAME, 
                settings.BusinessName);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_BUSINESS_ADDRESS, 
                settings.BusinessAddress);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_BUSINESS_TELEPHONE, 
                settings.BusinessTelephone);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_BUSINESS_EMAIL, 
                settings.BusinessEmail);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_BUSINESS_REG_NO, 
                settings.BusinessRegNo);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_BUSINESS_VAT_NO,
                settings.BusinessVatNo);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_LEAVEYEAR_STARTS, 
                Utilities.DateTimeToStr(settings.LeaveYearStarts, StringConstants.CULTURE_ENGLISH_UK));
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_LEAVAE_YEAR_ENDS, 
                Utilities.DateTimeToStr(settings.LeaveYearEnds, StringConstants.CULTURE_ENGLISH_UK));
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MAX_DAYS, 
                settings.LeaveMaximumTakeOnceDays.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MAX_HOURS, 
                settings.LeaveMaximumTakeOnceHours.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_FUTURE_YEARS, 
                settings.LeaveAllowBookFuture.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MINIMUM_DAYS, 
                settings.LeaveMinimumTakeDays.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MINIMUM_HOURS, 
                settings.LeaveMinimumTakeHours.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_XLEAVE_YEARS, 
                settings.LeaveAllowCrossLeaveYears.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_CROSSOVER_DAY, 
                settings.LeaveMaxCarryOverHours.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_CROSSOVER_HOURS, 
                settings.LeaveMaxCarryOverDays.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_VAT_NUMBER, 
                settings.InvoiceVATRegistrationNumber);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_INVOICE_ADDRESS, 
                settings.InvoiceAddress);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_INVOICE_FOOTER, 
                settings.InvoiceFooter);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MIN_TRACKING_VALUE, 
                settings.InvoiceMinimumValueTrackingReference.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_INV_PREFIX, 
                settings.InvoicePrefix);
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MILEAGE_RATE_1, 
                settings.ExpensesMileageRate1.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MILEAGE_RATE_2, 
                settings.ExpensesMileageRate2.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_MILEAGE_FIRSTX, 
                settings.ExpensesMileageFirstX.ToString());
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_ACCOUNT_YEAR_START,
                Utilities.DateTimeToStr(settings.AccountYearStart, StringConstants.CULTURE_ENGLISH_UK));
            LibraryHelperClass.SettingsSet(StringConstants.POS_SETTING_ACCOUNT_YEAR_END,
                Utilities.DateTimeToStr(settings.AccountYearEnd, StringConstants.CULTURE_ENGLISH_UK));
        }

        private static void LoadDatabaseSettings(UserSettings settings)
        {
            settings.BusinessName = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_BUSINESS_NAME);
            settings.BusinessAddress = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_BUSINESS_ADDRESS);
            settings.BusinessTelephone = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_BUSINESS_TELEPHONE);
            settings.BusinessEmail = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_BUSINESS_EMAIL);
            settings.BusinessRegNo = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_BUSINESS_REG_NO);
            settings.BusinessVatNo = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_BUSINESS_VAT_NO);

            settings.LeaveYearStarts = LibraryHelperClass.SettingsGetDateTime(
                StringConstants.POS_SETTING_LEAVEYEAR_STARTS, settings.LeaveYearStarts);
            settings.LeaveYearEnds = LibraryHelperClass.SettingsGetDateTime(
                StringConstants.POS_SETTING_LEAVAE_YEAR_ENDS, settings.LeaveYearEnds);
            settings.LeaveMaximumTakeOnceDays = LibraryHelperClass.SettingsGetDouble(
                StringConstants.POS_SETTING_MAX_DAYS, settings.LeaveMaximumTakeOnceDays);
            settings.LeaveMaximumTakeOnceHours = LibraryHelperClass.SettingsGetDouble(
                StringConstants.POS_SETTING_MAX_HOURS, settings.LeaveMaximumTakeOnceHours);
            settings.LeaveAllowBookFuture = LibraryHelperClass.SettingsGetInt(
                StringConstants.POS_SETTING_FUTURE_YEARS, settings.LeaveAllowBookFuture);
            settings.LeaveMinimumTakeDays = LibraryHelperClass.SettingsGetDouble(
                StringConstants.POS_SETTING_MINIMUM_DAYS, settings.LeaveMinimumTakeDays);
            settings.LeaveMinimumTakeHours = LibraryHelperClass.SettingsGetDouble(
                StringConstants.POS_SETTING_MINIMUM_HOURS, settings.LeaveMinimumTakeHours);
            settings.LeaveAllowCrossLeaveYears = LibraryHelperClass.SettingsGetBool(
                StringConstants.POS_SETTING_XLEAVE_YEARS, settings.LeaveAllowCrossLeaveYears);
            settings.LeaveMaxCarryOverHours = LibraryHelperClass.SettingsGetDouble(
                StringConstants.POS_SETTING_CROSSOVER_DAY, settings.LeaveMaxCarryOverHours);
            settings.LeaveMaxCarryOverDays = LibraryHelperClass.SettingsGetDouble(
                StringConstants.POS_SETTING_CROSSOVER_HOURS, settings.LeaveMaxCarryOverDays);
            settings.InvoiceAddress = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_INVOICE_ADDRESS, settings.InvoiceAddress);
            settings.InvoiceVATRegistrationNumber = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_VAT_NUMBER, settings.InvoiceVATRegistrationNumber);
            settings.InvoiceFooter = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_INVOICE_FOOTER, settings.InvoiceFooter);
            settings.InvoiceMinimumValueTrackingReference = LibraryHelperClass.SettingsGetDecimal(
                StringConstants.POS_SETTING_MIN_TRACKING_VALUE, 
                settings.InvoiceMinimumValueTrackingReference);
            settings.InvoicePrefix = LibraryHelperClass.SettingsGet(
                StringConstants.POS_SETTING_INV_PREFIX, settings.InvoicePrefix);
            settings.ExpensesMileageRate1 = LibraryHelperClass.SettingsGetDecimal(
                StringConstants.POS_SETTING_MILEAGE_RATE_1, 0.42m);
            settings.ExpensesMileageRate2 = LibraryHelperClass.SettingsGetDecimal(
                StringConstants.POS_SETTING_MILEAGE_RATE_2, 0.42m);
            settings.ExpensesMileageFirstX = LibraryHelperClass.SettingsGetDecimal(
                StringConstants.POS_SETTING_MILEAGE_FIRSTX, 10000);
            settings.AccountYearStart = LibraryHelperClass.SettingsGetDateTime(
                StringConstants.POS_SETTING_ACCOUNT_YEAR_START,
                new DateTime(2000, 4, 6));
            settings.AccountYearEnd = LibraryHelperClass.SettingsGetDateTime(
                StringConstants.POS_SETTING_ACCOUNT_YEAR_END,
                new DateTime(2001, 4, 5));
        }

        #endregion Local Settings

        #endregion Private Methods

        #region Public Methods

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    if (InterceptBarcodes)
                    {
                        Keys keyData;
                        
                        if ((Keys)((int)m.WParam) != Control.ModifierKeys)
                            keyData = (Keys)((int)m.WParam) | Control.ModifierKeys;
                        else
                            keyData = (Keys)((int)m.WParam);

                        if ((keyData == Keys.F23 || (_localSettings.ScannerUsesF11Key && keyData == Keys.F11)) && !_isBarcode)   //f23 = start of barcode
                        {
                            _isBarcode = true;
                            _scanBuffer = String.Empty;
                        }
                        else
                        {
                            if (_isBarcode && (keyData == Keys.F24 || (_localSettings.ScannerUsesF11Key && keyData == Keys.Tab))) //f24 = end of barcode
                            {
                                //_scanBuffer = "HV120-09A2-GY-16YP-4M2"; //test barcode £100 only
                                _isBarcode = false;
                                RaiseBarcodeReceived(_scanBuffer);
                                _scanBuffer = String.Empty;
                            }
                            else
                            {
                                if (_isBarcode && (keyData != Keys.F24 || (_localSettings.ScannerUsesF11Key && keyData == Keys.Tab))) // f24 = end of barcode
                                {
                                    if (((int)m.WParam >= 32 && (int)m.WParam <= 126))
                                    {
                                        _scanBuffer += (char)m.WParam;
                                        return (true);
                                    }
                                }
                            }
                        }
                    }

                    _lastActivity = DateTime.Now;

                    switch ((int)m.WParam)
                    {
                        case 112: //f1
                            ShowHelpFile();                            
                            break;

                        case 114: //f3
                            RaiseShowHome();
                            break;

                        case 122: //f11
                            _client.StopListening();
                            _client.StartListening();
                            break;

                        case 123: //f12
                            _client.SendMessage(Shared.Communication.Message.Command(StringConstants.REPLICATION_REPLICATE));
                            break;
                    }

                    break;
                case WM_LBUTTONDOWN:
                    _lastActivity = DateTime.Now;

                    break;

                case WM_SETFOCUS:
                    RaiseOnControlFocusChanged();

                    break;
            }

            return (false);
        }


        public static void PostLogin()
        {
            _appController.LoadAllAppointments();
        }

        /// <summary>
        /// Reverts to previously logged on user, if there is one
        /// </summary>
        public void Revert()
        {
            if (_previousUser != null)
            {
                _user = _previousUser;
                _previousUser = null;
                RaiseOnUserChanged();
            }
        }

        public bool CanRevert()
        {
            return (_previousUser != null);
        }

        /// <summary>
        /// Logs the current user out and displays the login screen
        /// </summary>
        public void UserLock()
        {
            GetUser = null;
            RaisOnUserTimeout();
        }

        /// <summary>
        /// Saves settings when program is closing
        /// </summary>
        public void ProgramClosing()
        {
            if (ThreadManager.Exists(StringConstants.THREAD_NAME_INSTALL_VALID))
            {
                ThreadManager.Cancel(StringConstants.THREAD_NAME_INSTALL_VALID);
            }

            HideSplashScreen();
            _isShuttingDown = true;

            SaveSettings();

            if (_client.IsConnected)
                _client.StopListening();

            Shared.Classes.ThreadManager.CancelAll(0);
        }


        public static void SaveSettings()
        {
            if (!_isShuttingDown)
                SaveDatabaseSettings(_localSettings);

            UserSettings.SaveSettings(_localSettings);
        }

        #endregion Public Methods

        #region Event Raise Methods

        private void RaiseOnControlFocusChanged()
        {
            if (ActiveControlChanged != null)
            {
                ActiveControlChanged(this, EventArgs.Empty);
            }
        }

        private void RaiseShowHome()
        {
            if (ShowHomeScreen != null)
            {
                ShowHomeScreen(this, EventArgs.Empty);
            }
        }

        private void RaiseShowUserSettings()
        {
            if (ShowUserSettings != null)
            {
                ShowUserSettings(this, EventArgs.Empty);
            }
        }

        private void RaiseUserIDChanged(Int64 oldID, Int64 newID)
        {
            if (UserIDChanged != null)
                UserIDChanged(this, new IDChangedEventArgs(oldID, newID));
        }

        private void RaiseAppointmentIDChanged(Int64 oldID, Int64 newID)
        {
            if (AppointmentIDChanged != null)
                AppointmentIDChanged(this, new IDChangedEventArgs(oldID, newID));
        }

        private void RaiseReplicationIDChanged(string table, Int64 oldID, Int64 newID)
        {
            if (TableIDChanged != null)
                TableIDChanged(this, new TableIDChangedEventArgs(table, oldID, newID));
        }

        private void RaiseOnUserChanged()
        {
            if (OnUserChanged != null)
                OnUserChanged(this, EventArgs.Empty);
        }

        private void RaisOnUserTimeout()
        {
            if (OnUserTimeout != null)
                OnUserTimeout(this, EventArgs.Empty);
        }

        internal void RaiseOnAutoLogout(int Seconds)
        {
            if (OnAutoLogout != null)
                OnAutoLogout(this, new AutoLogoutTimeOutEventArgs(Seconds));
        }

        private void RaiseReplicationComplete()
        {
            if (ReplicationComplete != null)
                ReplicationComplete(this, EventArgs.Empty);
        }

        private void RaiseReplicationStart()
        {
            if (ReplicationStart != null)
                ReplicationStart(this, EventArgs.Empty);
        }

        private void RaiseOnMessageReceived(Shared.Communication.Message message)
        {
            if (ServerMessageReceived != null)
                ServerMessageReceived(this, new ServerMessageArgs(String.Format(
                    StringConstants.PREFIX_AND_SUFFIX_HYPHEN, message.Title, message.Contents)));
        }

        private void RaiseBarcodeReceived(string barcode)
        {
            //if the current user scans their barcode log them out
            if ((_user != null && _user.Barcode == barcode))
            {
                Logout();
                RaiseOnAutoLogout((int)UserTimeOut);
            }
            else
            {
                User staffMember = null;

                if (barcode.StartsWith(StringConstants.TILL_BARCODE_PREFIX_HHB))
                {
                    staffMember = SharedBase.BOL.Users.User.UserFindByBarcode(barcode);

                    if (staffMember != null)
                    {
                        GetUser = staffMember;
                    }
                }

                if (BarcodeReceived != null)
                    BarcodeReceived(this, new BarcodeEventArgs(barcode));
            }
        }

        private void RaiseClientConnectionChanged()
        {
            if (ClientConnectionChanged != null)
                ClientConnectionChanged(this, new ConnectedEventArgs(ClientConnected));
        }

        #endregion Event Raise Methods

        #region Event Arguements

        public class AutoLogoutTimeOutEventArgs
        {
            public AutoLogoutTimeOutEventArgs(int remainingTime) { TimeRemaining = remainingTime; }

            /// <summary>
            /// Time remaining until auto logout
            /// </summary>
            public int TimeRemaining { private set; get; }
        }

        public class BarcodeEventArgs
        {
            public BarcodeEventArgs(string barcode) { Barcode = barcode; }

            public string Barcode
            {
                private set;
                get;
            }
        }

        public class ServerMessageArgs
        {
            public ServerMessageArgs (string message)
            {
                ServerMessage = message;
            }

            public string ServerMessage { get; private set; }
        }

        public class ConnectedEventArgs
        {
            public ConnectedEventArgs(bool isConnected)
            {
                IsConnected = isConnected;
            }

            /// <summary>
            /// Indicates wether the client is connected or not
            /// </summary>
            public bool IsConnected
            {
                get;
                private set;
            }
        }

        /// <summary>
        /// Represents change to Object ID
        /// </summary>
        public class IDChangedEventArgs
        {
            public IDChangedEventArgs(Int64 oldID, Int64 newID)
            {
                OldID = oldID;
                NewID = newID;
            }

            public Int64 OldID
            {
                private set;
                get;
            }

            public Int64 NewID
            {
                private set;
                get;
            }
        }

                /// <summary>
        /// Represents change to Object ID
        /// </summary>
        public class TableIDChangedEventArgs
        {
            public TableIDChangedEventArgs(string tableName, Int64 oldID, Int64 newID)
            {
                OldID = oldID;
                NewID = newID;
                Table = tableName;
            }

            public string Table
            {
                private set; 
                get;
            }

            public Int64 OldID
            {
                private set;
                get;
            }

            public Int64 NewID
            {
                private set;
                get;
            }
        }

        #endregion Event Arguements

        #region Event Delegates

        public delegate void IDChangedHandler(object sender, IDChangedEventArgs e);
        public delegate void TableIDChangedHandler(object sender, TableIDChangedEventArgs e);
        public delegate void AutoLogoutHandler(object sender, AutoLogoutTimeOutEventArgs e);
        public delegate void BarcodeHandler(object sender, BarcodeEventArgs e);
        public delegate void ClientConnectionChangedHandler(object sender, ConnectedEventArgs e);
        public delegate void ServerMessageHandler (object sender, ServerMessageArgs e);

        #endregion Event Delegates

        #region Events

        public event EventHandler OnUserChanged;
        public event EventHandler OnUserTimeout;
        public event AutoLogoutHandler OnAutoLogout;
        public event IDChangedHandler AppointmentIDChanged;
        public event IDChangedHandler UserIDChanged;
        public event TableIDChangedHandler TableIDChanged;
        public event EventHandler ReplicationComplete;
        public event EventHandler ReplicationStart;
        public event BarcodeHandler BarcodeReceived;
        public event ClientConnectionChangedHandler ClientConnectionChanged;
        public event ServerMessageHandler ServerMessageReceived;

        public event EventHandler ShowUserSettings;
        public event EventHandler ShowHomeScreen;
        public event EventHandler ActiveControlChanged;

        public event EventHandler FeaturedProductMissing;

        public event EventHandler GiftWrapMissing;

        public event EventHandler GiftWrapPriceWrong;

        public event EventHandler CarouselProductsMissing;

        public event EventHandler PosValidationFinished;

        #endregion Events

        #region Dispose

        public void Dispose()
        {
            if (_client != null && _client.IsConnected)
            {
                _client.StopListening();
                _client = null;
            }
        }

        #endregion Dispose
    }
}
