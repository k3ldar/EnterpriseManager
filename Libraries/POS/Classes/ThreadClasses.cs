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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: ThreadClasses.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Threading;
using System.IO;
using Shared.Classes;

using Library;
using Library.BOL.Products;

#pragma warning disable IDE1005

namespace POS.Base.Classes
{
    public class POSInstallationValidThread : ThreadManager
    {
        public POSInstallationValidThread()
            : base(null, new TimeSpan(), null, 20000)
        {

        }

        protected override bool Run(object parameters)
        {
            AppController._validInstall = Library.Utils.LibUtils.GetInstallValid(Library.DAL.DALHelper.StoreID);

            return (false);
        }
    }

    public class CashDrawerRandomCheckThread : ThreadManager
    {
        #region Private Members

        private DateTime _nextSpotCheck;

        private int _bypassedChecks = 0;

        #endregion Private Members

        #region Constructors

        public CashDrawerRandomCheckThread()
            : base(null, new TimeSpan(0, 0, 10))
        {
            HangTimeout = 0;
            Random rnd = new Random(DateTime.Now.Second);
            int next = rnd.Next(4) + 1;
            _nextSpotCheck = DateTime.Now.AddHours(next);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            if (AppController.ActiveUser.ID != -1 &&
                AppController.LocalSettings.CashDrawerForceChecks &&
                DateTime.Now > _nextSpotCheck)
            {
                if (CheckCashDrawer != null)
                {
                    Random rnd = new Random(DateTime.Now.Second);

                    if (Library.BOL.CashDrawer.CashDrawers.CheckedInLast10Minutes())
                    {
                        _bypassedChecks = 0;
                        _nextSpotCheck = DateTime.Now.AddHours(rnd.Next(4) + 1);
                    }
                    else
                    {
                        ValidateCashDrawer options = new ValidateCashDrawer(_bypassedChecks < AppController.LocalSettings.CashDrawerMaximumBypassCount);
                        CheckCashDrawer(this, options);

                        if (options.Result)
                        {
                            _bypassedChecks = 0;
                            _nextSpotCheck = DateTime.Now.AddHours(rnd.Next(15) + 10);
                        }
                        else
                        {
                            _bypassedChecks++;

                            _nextSpotCheck = DateTime.Now.AddMinutes(rnd.Next(10) + 3);
                        }
                    }
                }
            }

            if (HasCancelled())
                return (false);

            return (true);
        }

        /// <summary>
        /// Indicate not hanging if pinging
        /// </summary>
        /// <returns></returns>
        protected override bool Ping()
        {
            IndicateNotHanging();
            return (true);
        }

        #endregion Overridden Methods

        #region Events

        public event CheckCashDrawerHandler CheckCashDrawer;

        #endregion Events
    }

    public class ValidateCashDrawer
    {
        public ValidateCashDrawer(bool allowByPass)
        {
            AllowByPass = allowByPass;
            Result = false;
        }

        public bool Result { get; set; }

        public bool AllowByPass { get; private set; }
    }

    public delegate void CheckCashDrawerHandler(object sender, ValidateCashDrawer e);

    public class CashDrawerStartOfDayChecksThread : ThreadManager
    {
        #region Constructors

        public CashDrawerStartOfDayChecksThread()
            : base(null, new TimeSpan(), null, 500)
        {
            HangTimeout = 0;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            // if the last check was previous day then force a check
            if (AppController.LocalSettings.CashDrawerForceChecks &&
                !AppController.LocalSettings.CashDrawerBypassStartOfDay &&
                !Library.BOL.CashDrawer.CashDrawers.StartOfDayComplete(CashDrawerType.Till))
            {
                if (ForceStartOfDay != null)
                    ForceStartOfDay(this, EventArgs.Empty);
            }

            return (false);
        }

        /// <summary>
        /// Indicate not hanging if pinging
        /// </summary>
        /// <returns></returns>
        protected override bool Ping()
        {
            IndicateNotHanging();
            return (true);
        }

        #endregion Overridden Methods

        #region Events

        public event EventHandler ForceStartOfDay;

        #endregion Events
    }

    public class MaintenanceThreadClass : ThreadManager
    {
        public MaintenanceThreadClass()
            : base(null, new TimeSpan(0, 10, 0))
        {
            HangTimeout = 0;
        }

        protected override bool Ping()
        {
            IndicateNotHanging();
            return (true);
        }

        protected override bool Run(object parameters)
        {
            string currentPath = Shared.Utilities.CurrentPath(true);

            if (!Directory.Exists(currentPath + StringConstants.FOLDER_INVOICES))
                Directory.CreateDirectory(currentPath + StringConstants.FOLDER_INVOICES);

            string[] files = System.IO.Directory.GetFiles(Shared.Utilities.AddTrailingBackSlash(currentPath + StringConstants.FOLDER_INVOICES));

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                if (info.CreationTime < DateTime.Now.AddMinutes(-30))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    { }
                }
            }

            // play nicely
            if (HasCancelled())
                return (false);

            return (true);
        }
    }

    // superceded by POS.Updater plugin
    //public class CheckForUpdatesThreadClass : ThreadManager
    //{
    //    public CheckForUpdatesThreadClass()
    //        : base (null, new TimeSpan(0, 15, 0))
    //    {
    //        HangTimeout = 0;
    //    }

    //    protected override bool Ping()
    //    {
    //        IndicateNotHanging();
    //        return (true);
    //    }

    //    protected override bool Run(object parameters)
    //    {
    //        try
    //        {
    //            if (NewVersionAvailable(Application.ExecutablePath, Utilities.CurrentPath(true) + StringConstants.FILE_CONFIG_2))
    //            {
    //                MessageBox.Show(LanguageStrings.AppNewVersionAvailable, LanguageStrings.AppNewVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            }

    //            // play nicely
    //            if (HasCancelled())
    //                return (false);
    //        }
    //        catch (Exception err)
    //        {
    //            if (!err.Message.Contains(StringConstants.ERROR_RESOLVE_REMOTE_NAME))
    //            {
    //                throw;
    //            }
    //        }
    //        return (true);
    //    }

    //    private bool NewVersionAvailable(string LocalFile, string LocalConfigFile)
    //    {
    //        bool Result = false;

    //        if (!File.Exists(LocalFile))
    //        {
    //            return (true);
    //        }

    //        FileVersionInfo verLocal = FileVersionInfo.GetVersionInfo(LocalFile);
    //        Version VerLocal = new Version(verLocal.FileVersion);
    //        string verInfo = GetXMLValue(GetXMLValue(LocalConfigFile,
    //            StringConstants.SETTINGS_APPLICATION, StringConstants.SETTINGS_VERSION_INFO),
    //            StringConstants.SETTINGS_APPLICATION, StringConstants.SETTINGS_VERSION);
    //        Version VerRemote = new Version(String.IsNullOrEmpty(verInfo) ? "1.0" : verInfo);

    //        Result = VerRemote.CompareTo(VerLocal) > 0;

    //        return (Result);
    //    }

    //    private string GetXMLValue(string ConfigFile, string ParentName, string KeyName)
    //    {
    //        string Result = String.Empty;

    //        XmlDocument xmldoc = new XmlDocument();
    //        xmldoc.Load(ConfigFile);
    //        XmlNode Root = xmldoc.DocumentElement;

    //        if (Root != null & Root.Name == StringConstants.XML_ROOT_NODE_NAME)
    //        {
    //            for (int i = 0; i <= Root.ChildNodes.Count - 1; i++)
    //            {
    //                XmlNode Child = Root.ChildNodes[i];

    //                if (Child.Name == ParentName)
    //                {
    //                    for (int j = 0; j <= Child.ChildNodes.Count - 1; j++)
    //                    {
    //                        XmlNode Item = Child.ChildNodes[j];

    //                        if (Item.Name == KeyName)
    //                        {
    //                            Result = Item.InnerText;
    //                            return (Result);
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        return (Result);
    //    }

    //}

    public class CommunicationServiceThreadClass : ThreadManager
    {
        private const int SERVICE_THREAD_CHECK_INTERVAL = 10;

        private DateTime _lastChecked = DateTime.Now.AddSeconds(30);

        #region Constructors

        public CommunicationServiceThreadClass()
            : base(null, new TimeSpan(0, 0, 1), null, 5000)
        {
            _lastChecked = DateTime.Now;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            if (AppController._appController == null)
                return (true);

            if (AppController._appController._client != null &&
                (!AppController._appController._client.IsRunning | !AppController._appController._client.IsConnected))
            {
                TimeSpan span = DateTime.Now - _lastChecked;

                if (span.TotalSeconds >= SERVICE_THREAD_CHECK_INTERVAL)
                {
                    AppController._appController._client.StartListening();
                    _lastChecked = DateTime.Now;
                }
            }


            if (AppController._appController._client != null &&
                AppController._appController._client.IsConnected &&
                AppController._appController._client.IsRunning &&
                String.IsNullOrEmpty(AppController._appController._client.ClientID))
            {
                Thread.Sleep(3000);

                if (AppController._appController._client.IsConnected && AppController._appController._client.IsRunning && String.IsNullOrEmpty(AppController._appController._client.ClientID))
                    AppController._appController._client.StopListening();
            }

            // play nicely
            if (HasCancelled())
                return (false);

            return (true);
        }

        protected override bool Ping()
        {
            IndicateNotHanging();
            return (true);
        }

        #endregion Overridden Methods
    }

    internal class AutoLogoutThreadClass : ThreadManager
    {
        #region Private Members

        private DateTime _lastWarning = DateTime.Now.AddDays(-1);

        #endregion Private Members

        #region Constructors

        public AutoLogoutThreadClass()
            : base(null, new TimeSpan(0, 0, 1))
        {
            //AppController._appController._lastActivity = DateTime.Now.AddMinutes(1);
            HangTimeout = 0;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            TimeSpan span = DateTime.Now - AppController._appController._lastActivity;
            TimeSpan lastwarning = DateTime.Now - _lastWarning;

            if ((span.TotalSeconds + 30) >= AppController._appController.UserTimeOut && lastwarning.TotalSeconds > (AppController._appController.UserTimeOut - 30))
            {
                _lastWarning = DateTime.Now;
                POS.Base.Classes.PluginManager.RaiseEvent(new Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_RAISE_LOGOUT_WARNING, null));
            }

            if (span.TotalSeconds >= AppController._appController.UserTimeOut)
            {
                AppController._appController.UserLock();
                return (true);
            }

            AppController._appController.RaiseOnAutoLogout((int)span.TotalSeconds);

            // play nicely
            if (HasCancelled())
                return (false);

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }

    //internal class LoadAllUsersThread : ThreadManager
    //{
    //    internal LoadAllUsersThread()
    //        : base(null, new TimeSpan())
    //    {

    //    }

    //    protected override bool Run(object parameters)
    //    {
    //        //Users users = Users.Get(null);
    //        //AppController.POSApplication.AllUsers = users;
    //        return (false);
    //    }
    //}

    internal class LoadAllAppointmentsThread : ThreadManager
    {
        internal LoadAllAppointmentsThread(DateTime maximumAge)
            : base(maximumAge, new TimeSpan())
        {

        }

        protected override bool Run(object parameters)
        {
            AppController.ApplicationController.AllAppointments = Library.BOL.Appointments.Appointments.Get((DateTime)parameters, null);
            return (false);
        }
    }

    internal class ValidateProductsForWebsite : ThreadManager
    {
        #region Constructors

        internal ValidateProductsForWebsite(bool oneOfCheck)
            : base(oneOfCheck, new TimeSpan(0, 30, 0), null, 30000)
        {
            HangTimeout = 0;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            if (AppController.LocalSettings.FeaturedProductCheck)
            {
                Product featuredProduct = Products.GetFeatured();

                if (featuredProduct == null)
                {
                    if (FeaturedProductMissing != null)
                        FeaturedProductMissing(this, EventArgs.Empty);
                }
            }

            if (AppController.LocalSettings.GiftWrapChecks)
            {
                ProductCost giftWrapProduct = ProductCosts.GiftWrapProduct();

                if (giftWrapProduct == null)
                {
                    if (GiftWrapMissing != null)
                        GiftWrapMissing(this, EventArgs.Empty);
                }
                else
                {
                    if (giftWrapProduct.Cost1 < AppController.LocalSettings.GiftWrapLowest || giftWrapProduct.Cost1 > AppController.LocalSettings.GiftWrapMaximum)
                    {
                        if (GiftWrapPriceWrong != null)
                            GiftWrapPriceWrong(this, EventArgs.Empty);
                    }
                }
            }

            if (AppController.LocalSettings.CarouselChecks)
            {
                Products carousel = Products.GetCarousel();

                if (carousel == null || carousel.Count < 5)
                    if (CarouselProductsMissing != null)
                        CarouselProductsMissing(this, EventArgs.Empty);
            }

            // play nicely
            if (HasCancelled())
                return (false);

            return (!(bool)parameters);
        }

        protected override bool Ping()
        {
            IndicateNotHanging();
            return (true);
        }

        #endregion Overridden Methods

        #region Events

        internal event EventHandler FeaturedProductMissing;


        internal event EventHandler GiftWrapMissing;


        internal event EventHandler GiftWrapPriceWrong;


        internal event EventHandler CarouselProductsMissing;

        #endregion Events
    }
}
