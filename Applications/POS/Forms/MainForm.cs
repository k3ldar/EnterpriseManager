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
 *  File: MainForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

using PointOfSale.Classes;

using PointOfSale.Forms.Other;

using Languages;

using SharedControls.Classes;
using SharedControls.Interfaces;

using SharedBase;
using SharedBase.BOL.Users;

using POS.Base.Classes;
using POS.Base.Controls;
using POS.Base.Forms;
using POS.Base.Plugins;

using Reports;

#if ERROR_MANAGER
using ErrorManager.ErrorClient;
#endif

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace PointOfSale.Forms
{
    public partial class MainForm : BaseForm, INotifyAction
    {
        #region Constants

        private const int TAB_MARGIN_HEIGHT_OFFSET = 7;

        #endregion Constants

        #region Private / Static / Protected Members

        private object _lockObject = new object();

        private DateTime _dataConnectionErrorMessageNextShow = DateTime.Now.AddDays(-1);

        private List<BaseHomeTabButton> _homeTabButtons = new List<BaseHomeTabButton>();
        private Dictionary<string, List<TabPage>> _userOpenTabs = new Dictionary<string, List<TabPage>>();
        private Dictionary<string, TabPage> _userActiveTab = new Dictionary<string, TabPage>();

        private bool _askPluginsOnClosing = true;

        private StringFormat _tabStringFormat;
        private Font _tabFontSelected;
        private Font _tabFontNormal;
        private TabPage _selectedTab = null;
        private Point _dragStartPosition;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public MainForm()
        {
            DoubleBuffered = true;

#if ERROR_MANAGER
            ErrorClient.GetErrorClient.AdditionalInformation += GetErrorClient_AdditionalInformation;
            ErrorClient.GetErrorClient.ExceptionThrown += GetErrorClient_ExceptionThrown;
#endif

            ErrorHandling.InternalException += ErrorHandling_InternalException;

            Shared.Classes.ThreadManager.ThreadStarted += ThreadManager_ThreadStarted;
            Shared.Classes.ThreadManager.ThreadStopped += ThreadManager_ThreadStopped;
            Shared.Classes.ThreadManager.ThreadForcedToClose += ThreadManager_ThreadForcedToClose;
            Shared.Classes.ThreadManager.ThreadAbortForced += ThreadManager_ThreadAbortForced;

            AppController.UpdateSplashScreen(LanguageStrings.AppValidatingSettings);
            ValidateSettings.Validate();

            AppController.UpdateSplashScreen(LanguageStrings.AppPreparing);
            AppController.ApplicationController.OnUserChanged += User_OnUserChanged;
            AppController.ApplicationController.OnUserTimeout += User_OnUserTimeout;
            AppController.ApplicationController.ShowUserSettings += User_ShowUserSettings;
            AppController.ApplicationController.GiftWrapMissing += User_GiftWrapMissing;
            AppController.ApplicationController.FeaturedProductMissing += User_FeaturedProductMissing;
            AppController.ApplicationController.GiftWrapPriceWrong += User_GiftWrapPriceWrong;
            AppController.ApplicationController.CarouselProductsMissing += User_CarouselProductsMissing;
            AppController.ApplicationController.PosValidationFinished += POSApplication_PosValidationFinished;
            AppController.ApplicationController.OnAutoLogout += User_OnAutoLogout;

#if TRAY_ICON
            AppController.POSApplication.ClientConnectionChanged += User_ClientConnectionChanged;
            AppController.POSApplication.ReplicationStart += User_ReplicationStart;
            AppController.POSApplication.ReplicationComplete += User_ReplicationComplete;
#endif
            AppController.ApplicationController.ShowHomeScreen += POSApplication_ShowHomeScreen;

            InitializeComponent();

            toolStripStatusLabelUser.Tag = new TrayNotificationItem();
            toolStripProgressBarAutoLogout.Tag = new TrayNotificationItem();
            toolStripStatusLabelBackup.Tag = new TrayNotificationItem();

            this.Text = ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_TITLE);

            _tabFontSelected = new Font(this.Font.FontFamily, 9.0f, FontStyle.Bold);
            _tabFontNormal = new Font(this.Font.FontFamily, 9.0f);
            _tabStringFormat = new StringFormat();
            _tabStringFormat.Alignment = StringAlignment.Center;
            _tabStringFormat.LineAlignment = StringAlignment.Center;

            this.MaximizeBox = true;
            int width = Screen.FromControl(this).WorkingArea.Width;
            int height = Screen.FromControl(this).WorkingArea.Height;
            this.MaximumSize = new Size(width, height);
            this.MinimumSize = new Size(width - 100, height - 100);
            this.Size = new Size(width, height);
            this.SaveState = false;
            Left = 0;
            Top = 0;
            WindowState = FormWindowState.Maximized;

            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, homeTabContainer, new object[] { true });

            _homeTabButtons = new List<BaseHomeTabButton>();

            LoadPluginsModules();

            this.Cursor = Cursors.WaitCursor;

            AppController.UpdateSplashScreen(LanguageStrings.AppLoadingLanguages);

#if LANGUAGES
            LoadLanguages();
            menuLanguage.DropDownOpening += new System.EventHandler(this.menuLanguage_DropDownOpening);
#endif 

            AppController.UpdateSplashScreen(LanguageStrings.AppLoading);

            UpdatePluginModulesTabs(PluginManager.HomeTabsGet());

            toolStripStatusLabelUser.Text = String.Format(POS.Base.Classes.StringConstants.USER_NAME,
                LanguageStrings.AppUser, AppController.ActiveUser.UserName);

            statusStripMain.Visible = true;

            toolStripProgressBarAutoLogout.Visible = AppController.AutoLogout;

#if TRAY_ICON
            AppController.UpdateSplashScreen(LanguageStrings.AppUpdatingSystemTray);
            UpdateTrayIcon(AppController.POSApplication.ClientConnected);
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
#endif

            AppController.UpdateSplashScreen(LanguageStrings.AppLoadingReportsEngine);
            LoadReports();

            AppController.UpdateSplashScreen(LanguageStrings.AppLoading);

#if LANGUAGES
            menuLanguage.Visible = AppController.LocalSettings.ShowLanguageMenu;
#else
            menuLanguage.Visible = false;
#endif

            Shared.Classes.ThreadManager.ThreadStart(new ThreadNotificationThread(),
                POS.Base.Classes.StringConstants.THREAD_NOTIFICATIONS_UPDATE, ThreadPriority.Lowest);

            AllowProcess = true;
            HomeTabShowing = true;
        }

#endregion Constructors / Destructors

#region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.SuspendDrawing();
            try
            {
                foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
                {
                    pluginModule.UpdateLanguage(culture);
                }

                //file menu
                menuHome.Text = LanguageStrings.AppMenuHome;
                menuHomeSettings.Text = LanguageStrings.AppMenuSettings;
                menuHomeSettingsAdministration.Text = LanguageStrings.AppMenuSettingsAdministration;
                menuHomeSettingsUserSettings.Text = LanguageStrings.AppMenuSettingsUser;
                menuHomeSwapUser.Text = LanguageStrings.AppMenuUserSwap;
                menuHomeLockUser.Text = LanguageStrings.AppMenuUserLock;
                menuHomeRevertUser.Text = LanguageStrings.AppMenuUserRevert;
                menuHomeChangePassword.Text = LanguageStrings.AppMenuPasswordChange;
                menuHomeClose.Text = LanguageStrings.AppMenuClose;

                //accounts
                menuAccounts.Text = LanguageStrings.AppMenuAccounts;

                //tools menu
                menuTools.Text = LanguageStrings.AppMenuTools;

                //reports
                menuReports.Text = LanguageStrings.AppMenuReports;

                //administration menu
                menuAdministration.Text = LanguageStrings.AppMenuAdministration;
                menuAdministrationTools.Text = LanguageStrings.AppMenuTools;

#if LANGUAGES
                //language menu
                menuLanguage.Text = LanguageStrings.AppLanguage;
#endif

                //help menu
                menuHelp.Text = LanguageStrings.AppMenuHelp;
                menuHelpHelp.Text = LanguageStrings.AppMenuHelp;
                menuHelpHintsTips.Text = LanguageStrings.AppMenuHelpHintsTips;
                menuHelpAbout.Text = LanguageStrings.AppMenuHelpAbout;

                // tray menu
                menuPopupNotifyIconOpenDiary.Text = LanguageStrings.AppMenuOpenDiary;
                menuPopupNotifyIconOpenOrderManager.Text = LanguageStrings.AppMenuOpenOrderManager;
                menuPopupNotifyIconOpenStockControl.Text = LanguageStrings.AppMenuOpenStockControl;
                menuPopupNotifyIconOpenTill.Text = LanguageStrings.AppMenuOpenTill;
                menuPopupNotifyIconExit.Text = LanguageStrings.AppMenuExitApplication;

                toolStripStatusLabelBackup.Text = LanguageStrings.AppBackingUpDatabase;

                Size tabSize = homeTabContainer.ItemSize;

                foreach (HomeCard tab in PluginManager.HomeTabsGet())
                {
                    Size fontSize = Shared.Utilities.MeasureText(tab.GetName(), _tabFontSelected);
                    int newWidth = Shared.Utilities.CheckMinMax(fontSize.Width, tabSize.Width, 200);

                    if (tabSize.Width < (fontSize.Width + 50))
                        tabSize.Width = fontSize.Width + 50;

                    if (tabSize.Height != fontSize.Height + (TAB_MARGIN_HEIGHT_OFFSET * 2))
                        tabSize.Height = fontSize.Height + (TAB_MARGIN_HEIGHT_OFFSET * 2);
                }

                homeTabContainer.ItemSize = tabSize;
            }
            finally
            {
                this.ResumeDrawing();
            }
        }

        protected override void SetPermissions()
        {

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (homeTabContainer.SelectedIndex == 0)
            {
                HelpTopic = String.Empty;
            }
            else
            {
                HomeCard currTab = (HomeCard)homeTabContainer.SelectedTab.Tag;
                HelpTopic = currTab.HepString();
            }
        }

#endregion Overridden Methods

#region Internal Methods

        internal static bool AllowProcess { get; private set; }

        /// <summary>
        /// Determines wether the home tab is showing or not
        /// </summary>
        internal static bool HomeTabShowing { get; private set; }

        internal void UpdateStatusBar()
        {
            foreach (TrayNotification notification in PluginManager.TrayNotificationsGet(true))
            {
                if (notification.Visible)
                    notification.LastUpdated = DateTime.Now.AddDays(-1);
            }

            timerStats_Tick(this, EventArgs.Empty);
        }

        internal void ShowStatusBar(bool isBackup, string text = POS.Base.Classes.StringConstants.SYMBOL_EMPTY_STRING)
        {
            toolStripStatusLabelBackup.Visible = isBackup;
            toolStripStatusLabelBackup.Text = text;
        }

        internal void NewVersionAvailable()
        {
            if (ShowQuestion("New Version", "New version available, update now?"))
            {
                _askPluginsOnClosing = false;
                System.Diagnostics.Process.Start(AppController.POSFolder(FolderType.Root, true) + POS.Base.Classes.StringConstants.POS_NEW_VERSION_FILE);
                Application.Exit();
                Close();
            }
        }

        internal delegate string ToastNotificationHandler(string title, string message, string uniqueID);

        internal string ShowToastNotification(string title, string message, string uniqueID)
        {
            if (this.InvokeRequired)
            {
                ToastNotificationHandler tnh = new ToastNotificationHandler(ShowToastNotification);
                this.Invoke(tnh, new object[] { title, message, uniqueID });

                return (string.Empty);
            }
            else
            {
                return (toastNotification1.Show(message, title, uniqueID));
            }
        }

#endregion Internal Methods

#region Private Methods

#region Licencing Methods

        private void POSApplication_PosValidationFinished(object sender, EventArgs e)
        {
            if (!AppController.POSInstallValid)
            {
                ShowInformation(LanguageStrings.AppLicence, LanguageStrings.AppErrorLicence);
                Application.Exit();
            }
        }

#endregion Licencing Methods

#region Thread Manager Events

        private void ThreadManager_ThreadAbortForced(object sender, Shared.ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format(POS.Base.Classes.StringConstants.THREAD_FORCED_ABORT, e.Thread.Name, e.Thread.ThreadID));
        }

        private void ThreadManager_ThreadForcedToClose(object sender, Shared.ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format(POS.Base.Classes.StringConstants.THREAD_FORCED_CLOSE, e.Thread.Name, e.Thread.ThreadID));
        }

        private void ThreadManager_ThreadStopped(object sender, Shared.ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format(POS.Base.Classes.StringConstants.THREAD_STOP, e.Thread.Name, e.Thread.ThreadID));
        }

        private void ThreadManager_ThreadStarted(object sender, Shared.ThreadManagerEventArgs e)
        {
            Shared.EventLog.Add(String.Format(POS.Base.Classes.StringConstants.THREAD_START, e.Thread.Name, e.Thread.ThreadID));
        }

#endregion Thread Manager Events

#if LANGUAGES
#region Languages

        private void LoadLanguages()
        {
            menuLanguage.DropDownItems.Clear();

            foreach (string culture in LanguageWrapper.GetInstalledLanguages(AppController.POSFolder(FolderType.Languages, true)))
            {
                ToolStripMenuItem langMenu = new ToolStripMenuItem();
                langMenu.Tag = culture;
                langMenu.Click += LanguageSelect;

                try
                {
                    CultureInfo ci = new CultureInfo(culture);
                    langMenu.Text = ci.NativeName;
                    menuLanguage.DropDownItems.Add(langMenu);
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains("Culture is not supported"))
                        throw;
                }
            }
        }

        private void menuLanguage_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in menuLanguage.DropDownItems)
            {
                item.Checked = Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(((string)item.Tag).ToLower());
            }
        }

        private void LanguageSelect(object sender, EventArgs e)
        {
            ToolStripMenuItem langMenu = (ToolStripMenuItem)sender;
            CultureInfo ci = new CultureInfo((string)langMenu.Tag);
            AppController.LocalSettings.CustomUICulture = ci.Name;
            this.LanguageUpdate(ci);

            foreach (BasePlugin pluginModule in PluginManager.PluginsGet())
                pluginModule.UpdateLanguage(ci);
        }

#endregion Languages
#endif

#region Error Methods

        /// <summary>
        /// Determines wether an error message should be ignored i.e. not sent to error manager, or not
        /// </summary>
        /// <param name="ErrorMessage">Error message being processed</param>
        /// <returns>true if error is to be ignored, otherwise false</returns>
        private bool IgnoreError(string ErrorMessage)
        {
            bool Result = false;

            switch (ErrorMessage)
            {
                case POS.Base.Classes.StringConstants.ERROR_INVALID_TRANSACTION_HANDLE:
                case POS.Base.Classes.StringConstants.ERROR_THREAD_BEING_ABORTED:
                case POS.Base.Classes.StringConstants.ERROR_DISPOSED_OBJECT:
                    Result = true;
                    break;
            }

            return (Result);
        }

        private void ErrorHandling_InternalException(object sender, SharedBase.BOLEvents.InternalErrorEventArgs e)
        {
            try
            {
                if (!IgnoreError(e.Message))
                {
                    if (e.Message.Contains(POS.Base.Classes.StringConstants.ERROR_READING_DATA) |
                        e.Message.Contains(POS.Base.Classes.StringConstants.ERROR_NO_NETWORK))
                    {
                        if (_dataConnectionErrorMessageNextShow > DateTime.Now)
                        {
                            e.IgnoreError = true;
                            return;
                        }

                        ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorConnectionLost);
                        _dataConnectionErrorMessageNextShow = DateTime.Now.AddMinutes(2);
                        SharedBase.DAL.DALHelper.ResetDatabasePool(false);

                        return;
                    }

                    Shared.EventLog.Add(String.Format(POS.Base.Classes.StringConstants.ERROR_INTERNAL_1,
                        e.Method, e.Source, e.Parameters, e.CallStack, e.Message));

                    Shared.Utilities.FileWrite(String.Format(POS.Base.Classes.StringConstants.ERROR_FILE,
                        DateTime.Now.ToString(POS.Base.Classes.StringConstants.ERROR_FILE_NAME), CurrentPath()),
                        String.Format(POS.Base.Classes.StringConstants.ERROR_INTERNAL_1,
                        e.Method, e.Source, e.Parameters, e.CallStack, e.Message));

#if ERROR_MANAGER
                    if (!ErrorClient.GetErrorClient.SendError(
                        new Options(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_IP),
                            Shared.Utilities.StrToIntDef(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_PORT), 37789),
                            ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_USER),
                            ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD)),
                        String.Format(StringConstants.ERROR_INTERNAL_2,
                        e.Method, e.Source, e.Parameters, e.CallStack, e.Message, DateTime.Now.ToString(StringConstants.ERROR_FILE_NAME))))
                    {
#endif

                    SharedBase.BOL.Mail.Emails.Add(
                            ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT),
                            ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT),
                            ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_EMAIL_NAME_SENDER),
                            ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER),
                            POS.Base.Classes.StringConstants.ERROR_CANT_SEND,
                        String.Format(POS.Base.Classes.StringConstants.ERROR_INTERNAL_2,
                        e.Method, e.Source, e.Parameters, e.CallStack, e.Message, 
                        DateTime.Now.ToString(POS.Base.Classes.StringConstants.ERROR_FILE_NAME)));
#if ERROR_MANAGER
                    }
#endif
                }
            }
            catch (Exception err)
            {
                SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, sender, e);
            }
        }

#if ERROR_MANAGER
        private void GetErrorClient_AdditionalInformation(object sender, AdditionalInformationEventArgs e)
        {
            e.Information = String.Format(StringConstants.ERROR_INFO,
                Application.ProductVersion, WebsiteAdministration.DatabaseVersion, 
                DateTime.Now.ToString(StringConstants.SYMBOL_DATE_FORMAT_G),
                AppController.POSApplication.ClientConnected, WebsiteAdministration.StoreID, 
                WebsiteAdministration.TillID,
                AppController.ActiveUser == null ? LanguageStrings.AppNotLoggedIn : AppController.ActiveUser.UserName);

            //get pos uptime
            TimeSpan uptime = DateTime.Now - _uptime;
            e.Information += String.Format(StringConstants.ERROR_INFO_UPTIME, uptime.ToString());

            // load all modules used by this exe
            ProcessModuleCollection modules = Process.GetCurrentProcess().Modules;

            foreach (ProcessModule module in modules)
            {
                e.Information += String.Format(StringConstants.ERROR_INFO_MODULE, module.FileName, 
                    module.FileVersionInfo.FileVersion.ToString());
            }
        }

        private void GetErrorClient_ExceptionThrown(object sender, OnExceptionEventArgs e)
        {
            //by default always send to server
            e.Continue = true;

            //option not to send errors to error service here
            if (e.Error.Message.Contains(StringConstants.ERROR_EXPECTING_TRANSACTION_START))
            {
                e.Continue = false;
            }
            else if (e.Error.Message.Contains(StringConstants.ERROR_INVALID_TRANSACTION))
            {
                e.Continue = false;
            }
            else if (e.Error.Message.Contains(StringConstants.ERROR_INPUT_STREAM))
            {
                e.Continue = false;
            }
            else if (e.Error.Message.Contains(StringConstants.ERROR_UPDATE_CONFLICTS))
            {
                e.Continue = false;
            }
            else if (e.Error.Message.Contains(StringConstants.ERROR_THREAD_BEING_ABORTED) ||
                e.Error.Message.Contains(StringConstants.ERROR_DISPOSED_OBJECT))
            {
                e.Continue = false;
            }

            if (!e.Continue)
            {
                SharedBase.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), e.Error, sender, e);
                ShowError(LanguageStrings.AppErrorUnexpected, LanguageStrings.AppErrorUnexpectedDescription);
            }
        }
#endif
#endregion Error Methods

#region Plugin Modules

        private void LoadPluginsModules()
        {
            PluginManager.PluginLoad += PluginManager_PluginLoad;
            PluginManager.PluginUnload += PluginManager_PluginUnload;

            // load internal plugin
            PluginManager.LoadPlugin(new Plugins.InternalPlugin(this));

            // load all plugins
            try
            {
                PluginManager.LoadPlugins(this);
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
                ShowError(LanguageStrings.Error, String.Format(LanguageStrings.AppPluginFailedToLoad, err.Message));
            }

            UpdatePluginNotifications(PluginManager.TrayNotificationsGet(true));

            foreach (HomeCard tab in PluginManager.HomeTabsGet())
            {
                BaseHomeTabButton homeTabButton = new BaseHomeTabButton(tab, homeTabContainer);
                homeTabButton.Name = tab.GetName();
                homeTabButton.MouseDown += homeButtonPanel_MouseDown;
                homeTabButton.MouseUp += homeButtonPanel_MouseUp;
                homeTabButton.DragOver += homeButtonPanel_DragOver;
                homeTabButton.DragEnter += homeButtonPanel_DragEnter;
                _homeTabButtons.Add(homeTabButton);
            }

            TabPanelAndToolbarDataLoad();

            menuAdministration.DropDownItems.Remove(menuAdministrationToolsSep);
            menuAdministration.DropDownItems.Remove(menuAdministrationTools);
            menuAdministration.DropDownItems.Add(menuAdministrationToolsSep);
            menuAdministration.DropDownItems.Add(menuAdministrationTools);
        }

        private void PluginManager_PluginUnload(object sender, PluginManagerEventArgs e)
        {
            menuAccounts.Visible = menuAccounts.DropDownItems.Count > 0;
            menuTools.Visible = menuTools.DropDownItems.Count > 0;
            menuAdministration.Visible = menuAdministration.DropDownItems.Count > 0;

            TrayNotificationCollection notifications = e.Module.PluginModuleInstance.TrayNotifications();

            if (notifications != null)
            {
                foreach (TrayNotification notification in notifications)
                {
                    for (int i = statusStripMain.Items.Count - 1; i > 0; i--)
                    {
                        ToolStripItem oldLabel = (ToolStripItem)statusStripMain.Items[i];

                        if (oldLabel.Tag == notification)
                            statusStripMain.Items.Remove(oldLabel);
                    }
                }
            }
        }

        private void PluginManager_PluginLoad(object sender, PluginManagerEventArgs e)
        {
            // call methods so plugin can register menu items
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.Root, menuMain);
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.File, menuHome);
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.Accounts, menuAccounts);
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.Tools, menuTools);
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.Reports, menuReports);
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.Administration, menuAdministration);
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.AdministrationTools, menuAdministrationTools);
            e.Module.PluginModuleInstance.MenuAdd(PluginMenuType.Help, menuHelp);

            menuAccounts.Visible = menuAccounts.DropDownItems.Count > 0;
            menuTools.Visible = menuTools.DropDownItems.Count > 0;
            menuAdministration.Visible = menuAdministration.DropDownItems.Count > 0;
        }

        private void UpdatePluginNotifications(TrayNotificationCollection notifications)
        {
            for (int i = statusStripMain.Items.Count - 1; i >= 0; i--)
            {
                ToolStripItem oldLabel = (ToolStripItem)statusStripMain.Items[i];
                TrayNotificationItem itemData = (TrayNotificationItem)oldLabel.Tag;

                if (itemData.ItemType == NotificationItemType.Plugn)
                {
                    TrayNotificationItem nItem = (TrayNotificationItem)((ToolStripStatusLabel)oldLabel).Tag;

                    if (nItem.ItemType == NotificationItemType.Plugn)
                    {
                        TrayNotification notification = nItem.NotificationItem;

                        if (notification.CanUnload())
                        {
                            notification.Unload();
                            statusStripMain.Items.Remove(oldLabel);
                        }
                    }
                }
            }

            foreach (TrayNotification notification in notifications)
            {
                if (notification.Visible)
                {
                    if (notification.CanLoad())
                    {
                        // notify the tray icon it is loading
                        notification.Load();

                        ToolStripStatusLabel newLabel = new ToolStripStatusLabel(notification.StatusText());
                        notification.StatusLabel = newLabel;
                        notification.LastUpdated = DateTime.Now;
                        newLabel.Tag = new TrayNotificationItem(notification);
                        newLabel.DoubleClickEnabled = true;
                        newLabel.DoubleClick += toolStripStatusLabel_DoubleClick;
                        newLabel.TextAlign = ContentAlignment.MiddleCenter;
                        newLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
                        newLabel.BorderStyle = Border3DStyle.Flat;
                        int currStatusCount = statusStripMain.Items.Count - 2;
                        statusStripMain.Items.Insert(notification.Position > currStatusCount ? currStatusCount : notification.Position, newLabel);
                        newLabel.MouseEnter += toolStripStatusLabelMouseEnter;
                    }
                }
            }
        }

        private void toolStripStatusLabelMouseEnter(object sender, EventArgs e)
        {
            TrayNotificationItem data = (TrayNotificationItem)((ToolStripStatusLabel)sender).Tag;

            if (data.ItemType == NotificationItemType.Plugn)
            {
                ((ToolStripStatusLabel)sender).ToolTipText = data.NotificationItem.HintText();
            }
        }

        private void toolStripStatusLabel_DoubleClick(object sender, EventArgs e)
        {
            TrayNotificationItem data = (TrayNotificationItem)((ToolStripStatusLabel)sender).Tag;

            switch (data.ItemType)
            {
                case NotificationItemType.Plugn:
                    data.NotificationItem.DoubleClick();
                    break;
                case NotificationItemType.Tab:
                    data.Tab.StatusPanelDoubleClick(data.Index);
                    break;
            }
        }

        private void UpdatePluginModulesTabs(HomeCards tabs)
        {
            homeButtonPanel.SuspendDrawing();
            try
            {
                homeButtonPanel.Controls.Clear();
                List<BaseHomeTabButton> userButtons = new List<BaseHomeTabButton>();

                foreach (BaseHomeTabButton button in _homeTabButtons)
                {
                    if (button.TabPage.ValidateSecurity(AppController.ActiveUser))
                    {
                        userButtons.Add(button);
                    }
                }

                // sort the buttons
                foreach (BaseHomeTabButton btn in userButtons)
                {
                    string settingName = String.Format(POS.Base.Classes.StringConstants.PREFIX_AND_SUFFIX_SPACE,
                        AppController.ActiveUser.ID.ToString(), btn.Name);
                    //btn.SortOrder = SharedBase.LibraryHelperClass.SettingsGetInt(settingName, 1000);
                }

                userButtons.Sort();

                foreach (BaseHomeTabButton btn in userButtons)
                    homeButtonPanel.Controls.Add(btn);

                using (Shared.Classes.TimedLock.Lock(_lockObject))
                {
                    if (!_userOpenTabs.ContainsKey(AppController.ActiveUser.Email))
                    {
                        _userOpenTabs.Add(AppController.ActiveUser.Email, new List<TabPage>());
                        _userActiveTab.Add(AppController.ActiveUser.Email, null);
                    }


                    foreach (TabPage page in _userOpenTabs[AppController.ActiveUser.Email])
                    {
                        homeTabContainer.TabPages.Add(page);
                    }

                    if (_userActiveTab[AppController.ActiveUser.Email] != null)
                        homeTabContainer.SelectedTab = _userActiveTab[AppController.ActiveUser.Email];
                }
            }
            finally
            {
                homeButtonPanel.ResumeDrawing();
            }

            //homeTabContainer.SelectedIndex = 0;
        }

#endregion Plugin Modules

#region Reports

        private void LoadReports()
        {
            ReportEngine engine = new ReportEngine();

            foreach (ReportItem item in engine.Reports())
            {
                ToolStripMenuItem newReportItem = new ToolStripMenuItem();
                newReportItem.Text = item.Name;
                newReportItem.Click += newReportItem_Click;
                newReportItem.Tag = item;
                newReportItem.Name = String.Format(POS.Base.Classes.StringConstants.REPORT_MENU_NAME,
                    item.Name.Replace(POS.Base.Classes.StringConstants.SYMBOL_SPACE, String.Empty));
                menuReports.DropDownItems.Add(newReportItem);
            }
        }

        private void newReportItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            if (menu.Tag != null)
            {
                ReportItem item = (ReportItem)menu.Tag;

                if (AppController.ActiveUser.HasPermissionReport(item.Permission))
                {
                    try
                    {
                        HelpTopic = item.HelpTopic;
                        object rpt = Activator.CreateInstance(item.ClassType);
                        MethodInfo method = item.ClassType.GetMethod(item.Method);

                        // sending vouchers???
                        PropertyInfo property = rpt.GetType().GetProperty(POS.Base.Classes.StringConstants.REPORT_PROPERTY_VOUCHER_COUNTRY);

                        if (property != null)
                            property.SetValue(rpt, SharedBase.BOL.Countries.Countries.Get(
                                AppController.LocalSettings.DefaultCountry), null);

                        // sending appointments???
                        property = rpt.GetType().GetProperty(POS.Base.Classes.StringConstants.REPORT_PROPERTY_ALL_APPOINTMENTS);

                        if (property != null)
                            property.SetValue(rpt, AppController.ApplicationController.AllAppointments, null);

                        MethodInfo showDialogMethod = item.ClassType.GetMethod(POS.Base.Classes.StringConstants.REPORT_METHOD_SHOW_DIALOG,
                            BindingFlags.Instance | BindingFlags.Public,
                            null,
                            new Type[] { },// Method ToString() without parameters
                            null);

                        if (showDialogMethod == null)
                        {
                            if (item.SendActiveUser)
                            {
                                method.Invoke(rpt, new object[] { AppController.ActiveUser });
                            }
                            else
                            {
                                if (property != null && property.Name != POS.Base.Classes.StringConstants.REPORT_PROPERTY_ALL_APPOINTMENTS)
                                {
                                    object[] parameters = new object[1] { SharedBase.BOL.Countries.Countries.Get(
                                        AppController.LocalSettings.DefaultCountry) };
                                    method.Invoke(rpt, parameters);
                                }
                                else
                                    method.Invoke(rpt, null);
                            }
                        }
                        else
                        {
                            showDialogMethod.Invoke(rpt, null);
                            rpt = null;
                        }
                    }
                    catch (Exception err)
                    {
                        if (err.Message.Contains(POS.Base.Classes.StringConstants.ERROR_DEBUG_STOP))
                        {

                        }
                        else
                            throw;
                    }
                    finally
                    {
                        HelpTopic = String.Empty;
                    }
                }
                else
                    ShowError(LanguageStrings.AppErrorReport,
                        String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                        LanguageStrings.AppPermissionReport));
            }

        }

#endregion Reports

#region Tray Icon

#if TRAY_ICON
        private void UpdateTrayIcon(bool isConnected)
        {
            if (imageList1.Images.Count == 0)
            {
                trayIcon.Visible = false;
                return;
            }

            trayIcon.Visible = true;

            if (isConnected)
            {
                trayIcon.Text = StringConstants.TRAY_ICON_CONNECTED;
                trayIcon.BalloonTipText = trayIcon.Text;
                trayIcon.Icon = Icon.FromHandle(((Bitmap)imageList1.Images[0]).GetHicon());
            }
            else
            {
                trayIcon.Text = StringConstants.TRAY_ICON_NOT_CONNECTED;
                trayIcon.BalloonTipText = trayIcon.Text;
                trayIcon.Icon = Icon.FromHandle(((Bitmap)imageList1.Images[1]).GetHicon());
            }
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Activate();
            this.BringToFront();
        }
#endif

#endregion Tray Icon

#region AppController Events

        private void POSApplication_ShowHomeScreen(object sender, EventArgs e)
        {
            homeTabContainer.SelectedTab = tabPageMain;
        }

#if TRAY_ICON
        void User_ReplicationComplete(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_ReplicationComplete);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                trayIcon.Text = StringConstants.TRAY_ICON_CONNECTED;
                trayIcon.BalloonTipText = trayIcon.Text;
                trayIcon.Icon = Icon.FromHandle(((Bitmap)imageList1.Images[0]).GetHicon());
            }
        }

        void User_ReplicationStart(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_ReplicationStart);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                trayIcon.Text = StringConstants.TRAY_ICON_REPLICATING;
                trayIcon.BalloonTipText = trayIcon.Text;
                trayIcon.Icon = Icon.FromHandle(((Bitmap)imageList1.Images[2]).GetHicon());
            }
        }

#endif

        void User_OnAutoLogout(object sender, AppController.AutoLogoutTimeOutEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    AppController.AutoLogoutHandler alh = new AppController.AutoLogoutHandler(User_OnAutoLogout);
                    this.Invoke(alh, new object[] { sender, e });
                }
                else
                {
                    if (toolStripProgressBarAutoLogout.Maximum != AppController.ApplicationController.UserTimeOut)
                        toolStripProgressBarAutoLogout.Maximum = (int)AppController.ApplicationController.UserTimeOut;

                    toolStripProgressBarAutoLogout.Value = Shared.Utilities.CheckMinMax(e.TimeRemaining,
                        0, (int)AppController.ApplicationController.UserTimeOut);
                }
            }
            catch
            {
                //ignore
            }
        }

#if TRAY_ICON
        void User_ClientConnectionChanged(object sender, AppController.ConnectedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AppController.ClientConnectionChangedHandler ccch = new AppController.ClientConnectionChangedHandler(User_ClientConnectionChanged);
                this.Invoke(ccch, new object[] { sender, e });
            }
            else
            {
                UpdateTrayIcon(e.IsConnected);
            }
        }
#endif

        void User_ShowUserSettings(object sender, EventArgs e)
        {
            LocalSettingsWrapper.LoadLocalSettings(this);
        }

        void User_OnUserTimeout(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_OnUserTimeout);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                User newUser = null;

                if (LoginForm.DoLogin(ref newUser, LanguageStrings.AppLogin, false, false))
                {

                    //logged in as new user
                    AppController.ApplicationController.GetUser = newUser;
                }
            }
        }

        void User_OnUserChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_OnUserChanged);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                toolStripStatusLabelUser.Text = String.Format(POS.Base.Classes.StringConstants.USER_NAME,
                    LanguageStrings.AppUser, AppController.ActiveUser.UserName);

                UpdatePluginModulesTabs(PluginManager.HomeTabsGet());
                SetPermissions();
            }
        }

        void User_CarouselProductsMissing(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_CarouselProductsMissing);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                SharedControls.Forms.Notification notify = new SharedControls.Forms.Notification(
                    this, String.Empty, LanguageStrings.AppErrorNoCarouselProducts);
                notify.BackColor = System.Drawing.Color.Black;
                notify.TextColor = System.Drawing.Color.White;
                notify.OpacitySpeed = 0.2;
                notify.FadeOut = true;
                notify.AutomaticallyClose = 60;

                notify.NotifyPosition = Shared.NotificationPosition.BottomRight;

                notify.NotifyEffect = Shared.NotificationEffect.Slide;
                notify.Show();
            }
        }

        void User_GiftWrapPriceWrong(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_GiftWrapPriceWrong);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                SharedControls.Forms.Notification notify = new SharedControls.Forms.Notification(
                    this, String.Empty, LanguageStrings.AppErrorGiftWrapPriceWrong);
                notify.BackColor = System.Drawing.Color.Black;
                notify.TextColor = System.Drawing.Color.White;
                notify.OpacitySpeed = 0.2;
                notify.FadeOut = true;
                notify.AutomaticallyClose = 60;

                notify.NotifyPosition = Shared.NotificationPosition.BottomRight;

                notify.NotifyEffect = Shared.NotificationEffect.Slide;
                notify.Show();
            }
        }

        void User_FeaturedProductMissing(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_FeaturedProductMissing);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                SharedControls.Forms.Notification notify = new SharedControls.Forms.Notification(
                    this, String.Empty, LanguageStrings.AppErrorNoFeaturedProduct);
                notify.BackColor = System.Drawing.Color.Black;
                notify.TextColor = System.Drawing.Color.White;
                notify.OpacitySpeed = 0.2;
                notify.FadeOut = true;
                notify.AutomaticallyClose = 60;
                //notify.no

                notify.NotifyPosition = Shared.NotificationPosition.BottomRight;

                notify.NotifyEffect = Shared.NotificationEffect.Slide;
                notify.Show();
            }
        }

        void User_GiftWrapMissing(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_GiftWrapMissing);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                SharedControls.Forms.Notification notify = new SharedControls.Forms.Notification(
                    this, String.Empty, LanguageStrings.AppErrorGiftWrapNoProduct);
                notify.BackColor = System.Drawing.Color.Black;
                notify.TextColor = System.Drawing.Color.White;
                notify.OpacitySpeed = 0.2;
                notify.FadeOut = true;
                notify.AutomaticallyClose = 60;

                notify.NotifyPosition = Shared.NotificationPosition.BottomRight;

                notify.NotifyEffect = Shared.NotificationEffect.Slide;
                notify.Show();
            }
        }

#endregion AppController Events

#region Tray Notification Methods

        private void timerStats_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            foreach (TrayNotification notification in PluginManager.TrayNotificationsGet(true))
            {
                try
                {
                    if (notification.Visible)
                    {
                        if (currentTime - notification.LastUpdated > notification.UpdateFrequency)
                        {
                            if (notification.StatusLabel != null)
                            {
                                notification.StatusLabel.Text = notification.StatusText();
                                notification.LastUpdated = currentTime;
                            }
                        }

                        if (notification.StatusLabel != null && (notification.CanBlink ||
                            (!notification.CanBlink && notification.StatusLabel.ForeColor == System.Drawing.Color.Red)))
                        {
                            DoBlinkStatus(notification.StatusLabel, notification.Blinking);
                            notification.Blinking = !notification.Blinking;
                        }
                    }
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err);
                }
            }
        }

        private void DoBlinkStatus(ToolStripStatusLabel lbl, bool blinking)
        {
            if (!blinking)
            {
                lbl.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                if (lbl.ForeColor == System.Drawing.Color.Black)
                    lbl.ForeColor = System.Drawing.Color.Red;
                else
                    lbl.ForeColor = System.Drawing.Color.Black;
            }
        }

#endregion Tray Notification Methods

#region Form Events

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.Invalidate();
                Application.DoEvents();

                homeTabContainer_SizeChanged(sender, e);

                Shared.Classes.ThreadManager.ThreadStart(new MaintenanceThreadClass(),
                    POS.Base.Classes.StringConstants.THREAD_NAME_MAINTENANCE, ThreadPriority.Lowest);

                //prompt to change password if default password is in use
                if (AppController.ActiveUser.Password == POS.Base.Classes.StringConstants.PASSWORD_DEFAULT)
                {
                    ShowInformation(LanguageStrings.AppPassword, LanguageStrings.AppPasswordDefaultChange);
                    ChangePasswordForm.ChangePassword(true);
                }

                AppController.HideSplashScreen();
                this.Cursor = Cursors.Arrow;
                this.Enabled = true;

                if (AppController.LocalSettings.ShowDidYouKnowAtStartup)// || AppController.LocalSettings.VersionChanged(Application.ProductVersion))
                {
                    HintsAndTipsForm frm = new HintsAndTipsForm();
                    try
                    {
                        frm.ShowDialog(this);
                    }
                    finally
                    {
                        frm.Dispose();
                        frm = null;
                    }
                }

                // notify all plugins that we have loaded and are showing
                PluginManager.RaiseEvent(new NotificationEventArgs(POS.Base.Classes.StringConstants.PLUGIN_EVENT_MAIN_FORM_SHOWING, null));
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Library.Backup.DatabaseBackupThread.BackupInProgress(POS.Base.Classes.StringConstants.BACKUP_NAME))
            {
                ShowInformation(LanguageStrings.AppCanNotClose, LanguageStrings.AppCloseBackingUp);
                e.Cancel = true;
                return;
            }

            if (_askPluginsOnClosing)
            {
                // ask all plugins if it's ok to close
                foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
                {
                    if (!pluginModule.CanClose())
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }

            if (!e.Cancel)
            {
                foreach (BaseHomeTabButton btn in _homeTabButtons)
                {
                    btn.IsClosing = true;
                }

                HomeCards cards = PluginManager.HomeTabsGet();

                foreach (HomeCard card in cards)
                {
                    card.Closing();
                }

                HomeTabShowing = false;

#if MOVING_NOTIFICATIONS
                AllowProcess = false;

                Shared.Classes.ThreadManager.Cancel(StringConstants.THREAD_NOTIFICATIONS_UPDATE);

                for (int i = 0; i < 10; i++)
                {
                    if (Shared.Classes.ThreadManager.Exists(StringConstants.THREAD_NOTIFICATIONS_UPDATE))
                        System.Threading.Thread.Sleep(100);
                    else
                        break;
                }
#endif

                AppController.ApplicationController.OnAutoLogout -= User_OnAutoLogout;

#if TRAY_ICON
                AppController.POSApplication.ClientConnectionChanged -= User_ClientConnectionChanged;
                AppController.POSApplication.ReplicationStart -= User_ReplicationStart;
                AppController.POSApplication.ReplicationComplete -= User_ReplicationComplete;
#endif

                AppController.ApplicationController.OnUserChanged -= User_OnUserChanged;
                AppController.ApplicationController.OnUserTimeout -= User_OnUserTimeout;

#if ERROR_MANAGER
                ErrorClient.GetErrorClient.ExceptionThrown -= GetErrorClient_ExceptionThrown;
#endif

                Shared.Classes.ThreadManager.ThreadStarted -= ThreadManager_ThreadStarted;
                Shared.Classes.ThreadManager.ThreadStopped -= ThreadManager_ThreadStopped;
                Shared.Classes.ThreadManager.ThreadForcedToClose -= ThreadManager_ThreadForcedToClose;
                Shared.Classes.ThreadManager.ThreadAbortForced -= ThreadManager_ThreadAbortForced;

                AppController.Logout();
            }

            _askPluginsOnClosing = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppController.ApplicationController.ProgramClosing();

#if TRAY_ICON
            trayIcon.Visible = false;
#endif
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            Invalidate(true);
        }

#endregion Form Events

#region Menu Items

#region File Menu

        private void menuHome_DropDownOpening(object sender, EventArgs e)
        {
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.MenuDropDown(PluginMenuType.File);
            }
        }

        private void menuHomeSettingsAdministration_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdminSettingsWrapper.LoadAdminSettings(this))
                {
                    PluginManager.RaiseEvent(new NotificationEventArgs(POS.Base.Classes.StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_ADMIN, null));
                }

                timerStats_Tick(sender, e);
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppAdministrationSettings, err.Message);
            }
        }

        private void menuHomeSettingsUser_Click(object sender, EventArgs e)
        {
            if (LocalSettingsWrapper.LoadLocalSettings(this))
            {
                PluginManager.RaiseEvent(new NotificationEventArgs(POS.Base.Classes.StringConstants.PLUGIN_EVENT_SETTINGS_CHANGED_USER, null));

#if LANGUAGES
                menuLanguage.Visible = AppController.LocalSettings.ShowLanguageMenu;
#endif
            }
        }

        private void menuHomeUserSwap_Click(object sender, EventArgs e)
        {
            User newUser = null;

            if (Other.LoginForm.DoLogin(ref newUser, LanguageStrings.AppSwapUser, false))
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // save current users layout
                    SaveUserLayout();

                    //logged in as new user
                    AppController.ApplicationController.GetUser = newUser;
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void menuHomeUserRevert_Click(object sender, EventArgs e)
        {
            SaveUserLayout();

            AppController.ApplicationController.Revert();
        }

        private void menuHomeChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm.ChangePassword(false);
        }

        private void menuHomeUserLock_Click(object sender, EventArgs e)
        {
            SaveUserLayout();
            AppController.ApplicationController.UserLock();
        }

        private void menuHomeClose_Click(object sender, EventArgs e)
        {
            SaveUserLayout();
            Application.Exit();
        }

        private void menuHome_Click(object sender, EventArgs e)
        {
            // enables / disables Menus's under File Menu
            menuHomeSettingsAdministration.Enabled = (int)AppController.ActiveUser.MemberLevel >= (int)MemberLevel.AdminReadOnly;
            menuHomeRevertUser.Enabled = AppController.ApplicationController.CanRevert();
        }

#endregion File Menu

#region Accounts Menu

        private void menuAccounts_DropDownOpening(object sender, EventArgs e)
        {
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.MenuDropDown(PluginMenuType.Accounts);
            }
        }

#endregion Accounts Menu

#region Tools Menu

        private void menuTools_DropDownOpening(object sender, EventArgs e)
        {
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.MenuDropDown(PluginMenuType.Tools);
            }
        }

#endregion Tools Menu

#region Reports Menu

        private void menuReports_DropDownOpening(object sender, EventArgs e)
        {
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.MenuDropDown(PluginMenuType.Reports);
            }
        }

#endregion Reports Menu

#region Administration Menu

        private void menuAdministration_DropDownOpening(object sender, EventArgs e)
        {
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.MenuDropDown(PluginMenuType.Administration);
            }

            menuAdministrationTools.Visible = menuAdministrationTools.DropDownItems.Count > 0;
            menuAdministrationToolsSep.Visible = menuAdministrationTools.DropDownItems.Count > 0;
        }


        private void menuAdministrationTools_DropDownOpening(object sender, EventArgs e)
        {
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.MenuDropDown(PluginMenuType.AdministrationTools);
            }
        }


#endregion Administration Menu

#region Help Menu

        private void menuHelp_DropDownOpening(object sender, EventArgs e)
        {
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.MenuDropDown(PluginMenuType.Help);
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AppController.ShowHelpFile();
        }

        private void hintsTipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HintsAndTipsForm frm = new HintsAndTipsForm();
            try
            {
                frm.ShowDialog(this);
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        private void menuHelpManual_Click(object sender, EventArgs e)
        {
            string manual = AppController.POSFolder(FolderType.Root, true) + POS.Base.Classes.StringConstants.FILE_POS_MANUAL;
            System.Diagnostics.Process.Start(manual);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string AboutText = String.Format(POS.Base.Classes.StringConstants.ABOUT_TEXT,
                Application.ProductVersion, WebsiteAdministration.DatabaseVersion,
                WebsiteAdministration.StoreID, WebsiteAdministration.TillID,
                String.IsNullOrEmpty(AppController.ApplicationController.ClientID) ? LanguageStrings.AppNotConnected : AppController.ApplicationController.ClientID,
                WebsiteAdministration.LocalDatabase,
                SharedBase.WebsiteAdministration.DatabaseVersionCorrect ? String.Empty : LanguageStrings.AppOutOfDate,
                ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_TITLE).Replace(POS.Base.Classes.StringConstants.SYMBOL_HYPHON_SPACES,
                POS.Base.Classes.StringConstants.SYMBOL_CRLF_DOUBLE),
                System.Environment.Is64BitProcess ? POS.Base.Classes.StringConstants.APP_64BIT : POS.Base.Classes.StringConstants.APP_32BIT);
            MessageBox.Show(AboutText,
                LanguageStrings.AppMenuHelpAbout.Replace(POS.Base.Classes.StringConstants.SYMBOL_AMPERSAND,
                    POS.Base.Classes.StringConstants.SYMBOL_EMPTY_STRING), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

#endregion Help Menu

#region Context Menu Items

        private void contextMenuStripPluginSettings_Opening(object sender, CancelEventArgs e)
        {
            Point p = this.PointToClient(Cursor.Position);
            Control item = (Control)this.GetChildAtPoint(p);

            if (item.GetType() == typeof(Button))
                pluginSettingsEditMenuStrip.Tag = true;
            else
                pluginSettingsEditMenuStrip.Tag = false;

        }

        private void pluginSettingsEditMenuStrip_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.MemberLevel < MemberLevel.AdminReadOnly)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppNoPermissionsAdminSettings);
                return;
            }

            if (PluginSettingsWrapper.LoadPluginSettings(this, (bool)pluginSettingsEditMenuStrip.Tag))
            {
                PluginManager.SavePluginConfiguration();
                UpdatePluginNotifications(PluginManager.TrayNotificationsGet(true));
            }
        }

#endregion Context Menu Items

#endregion Menu Items

#region Notify Methods

        internal void RaiseLogoutWarning(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(RaiseLogoutWarning);
                Invoke(eh, new object[] { sender, e });
            }
            else
            {
                SharedControls.Forms.Notification notify = new SharedControls.Forms.Notification(
                    this, String.Empty, LanguageStrings.AppAutoLogoutWarning);
                notify.BackColor = Color.Black;
                notify.TextColor = Color.White;
                notify.OpacitySpeed = 0.2;
                notify.FadeOut = true;
                notify.AutomaticallyClose = 8;

                notify.NotifyPosition = Shared.NotificationPosition.BottomRight;

                notify.NotifyEffect = Shared.NotificationEffect.Slide;
                notify.Show();
            }
        }

        internal void RaiseUpdateStatusBars(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler eh = new EventHandler(RaiseLogoutWarning);
                Invoke(eh, new object[] { sender, e });
            }
            else
            {
                //this.SuspendDrawing();
                //try
                //{
                TabPanelAndToolbarDataUpdate();
                //}
                //finally
                //{
                //    this.ResumeDrawing();
                //}
            }
        }

        public void NotifyClicked(object sender, EventArgs e)
        {
            ((SharedControls.Forms.Notification)sender).Close();
        }

        public void NotifyCancelled(object sender, EventArgs e)
        {

        }

        public void NotifyFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        public void NotifyTimeOut(object sender, EventArgs e)
        {

        }

#endregion Notify Methods

#region Toast Notification

        private void toastNotification1_OnFocus(object sender, Shared.ToastNotificationArgs e)
        {
            if (Form.ActiveForm != null)
                Form.ActiveForm.Focus();
        }

        private void toastNotification1_OnTimeOut(object sender, Shared.ToastNotificationArgs e)
        {
            PluginManager.RaiseEvent(new NotificationEventArgs(e.EventType, e.UniqueID));
        }

        private void toastNotification1_OnClicked(object sender, Shared.ToastNotificationArgs e)
        {
            PluginManager.RaiseEvent(new NotificationEventArgs(e.EventType, e.UniqueID));
        }

        private void toastNotification1_OnCancelled(object sender, Shared.ToastNotificationArgs e)
        {
            PluginManager.RaiseEvent(new NotificationEventArgs(e.EventType, e.UniqueID));
        }

#endregion Toast Notification

#region User Settings

        private void SaveUserLayout()
        {
            // get index for home page items
            for (int i = homeButtonPanel.Controls.Count - 1; i >= 0; i--)
            {
                BaseHomeTabButton btn = (BaseHomeTabButton)homeButtonPanel.Controls[i];
                string settingName = String.Format(POS.Base.Classes.StringConstants.PREFIX_AND_SUFFIX_SPACE,
                    AppController.ActiveUser.ID.ToString(), btn.Name);
                SharedBase.LibraryHelperClass.SettingsSet(settingName,
                    homeButtonPanel.Controls.GetChildIndex(btn).ToString());
            }

            using (Shared.Classes.TimedLock.Lock(_lockObject))
            {
                _userOpenTabs[AppController.ActiveUser.Email].Clear();
                _userActiveTab[AppController.ActiveUser.Email] = homeTabContainer.SelectedTab;

                foreach (TabPage page in homeTabContainer.TabPages)
                {
                    if (page == tabPageMain)
                        continue;

                    _userOpenTabs[AppController.ActiveUser.Email].Add(page);
                }
            }

            for (int i = homeTabContainer.TabPages.Count - 1; i > 0; i--)
            {
                homeTabContainer.TabPages.RemoveAt(i);
            }
        }

#endregion User Settings 

#region Tabs

        private void homeTabContainer_SizeChanged(object sender, EventArgs e)
        {
            foreach (TabPage page in homeTabContainer.TabPages)
            {
                if (page.Controls.Count == 0 || page.Tag == null)
                    continue;

                BaseTabControl child = (BaseTabControl)page.Controls[0];
                child.SuspendDrawing();
                try
                {
                    child.Width = page.Width - 6;
                    child.Height = page.Height - 6;
                    child.Top = 3;
                    child.Left = 3;
                    child.AfterResize();
                }
                finally
                {
                    child.ResumeDrawing();
                }
            }
        }

        private void TabPanelAndToolbarDataRemove()
        {
            // remove custom status bar elements
            for (int i = statusStripMain.Items.Count - 1; i >= 0; i--)
            {
                TrayNotificationItem data = (TrayNotificationItem)statusStripMain.Items[i].Tag;

                if (data.ItemType == NotificationItemType.Tab)
                {
                    statusStripMain.Items.RemoveAt(i);
                }
            }


            // remove custom tool bar elements


        }

        private void TabPanelAndToolbarDataUpdate()
        {
            if (homeTabContainer.SelectedTab.Tag == null)
                return;

            HomeCard tab = (HomeCard)homeTabContainer.SelectedTab.Tag;

            // remove custom status bar elements
            for (int i = statusStripMain.Items.Count - 1; i >= 0; i--)
            {
                TrayNotificationItem data = (TrayNotificationItem)statusStripMain.Items[i].Tag;

                if (data.ItemType == NotificationItemType.Tab)
                {
                    statusStripMain.Items[data.Index].Text = tab.StatusPanelText(data.Index);
                    statusStripMain.Items[data.Index].ToolTipText = tab.StatusPanelHint(data.Index);
                }
            }


            // remove custom tool bar elements


        }

        private void TabPanelAndToolbarDataLoad()
        {
            // add custom status bar elements
            if (homeTabContainer.SelectedTab.Tag == null)
                return;

            HomeCard tab = (HomeCard)homeTabContainer.SelectedTab.Tag;
            int count = tab.StatusPanelCount();

            for (int i = count - 1; i >= 0; i--)
            {
                ToolStripStatusLabel panel = new ToolStripStatusLabel();
                panel.Tag = new TrayNotificationItem(tab, i);

                panel.Text = tab.StatusPanelText(i);
                panel.ToolTipText = tab.StatusPanelHint(i);
                panel.DoubleClick += toolStripStatusLabel_DoubleClick;
                panel.TextAlign = ContentAlignment.MiddleCenter;
                panel.BorderSides = ToolStripStatusLabelBorderSides.Right;
                panel.BorderStyle = Border3DStyle.Flat;

                statusStripMain.Items.Insert(0, panel);
            }

            // add custom tool bar elements
        }

        private void homeTabContainer_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush txt_brush;
            Brush box_brush;
            Pen box_pen;

            // We draw in the TabRect rather than on e.Bounds
            // so we can use TabRect later in MouseDown.
            Rectangle tabHeaderRect = homeTabContainer.GetTabRect(e.Index);

            // Allow room for margins.
            RectangleF layout_rect = new RectangleF(
                tabHeaderRect.Left + TAB_MARGIN_HEIGHT_OFFSET,
                tabHeaderRect.Y + TAB_MARGIN_HEIGHT_OFFSET,
                tabHeaderRect.Width - 2 * TAB_MARGIN_HEIGHT_OFFSET,
                tabHeaderRect.Height - 2 * TAB_MARGIN_HEIGHT_OFFSET);


            Brush tabBrush = e.State == DrawItemState.Selected ? Brushes.LightBlue : Brushes.LightGray;
            Icon tabIcon = null;

            if (homeTabContainer.TabPages[e.Index].Tag != null)
            {
                HomeCard tab = (HomeCard)homeTabContainer.TabPages[e.Index].Tag;

                tabIcon = tab.GetIcon();

                if (tab.TabColour() != Color.LightGray)
                    tabBrush = new SolidBrush(tab.TabColour());
            }

            e.Graphics.FillRectangle(tabBrush, tabHeaderRect);

            // Draw the background.
            // Pick appropriate pens and brushes.
            if (e.State == DrawItemState.Selected)
            {
                e.DrawFocusRectangle();

#if LINEAR_TAB
                using (LinearGradientBrush aGB = new LinearGradientBrush(tabHeaderRect,
                    Color.LightBlue, Color.DarkBlue, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(aGB, tabHeaderRect);
                }
#else
                RectangleF headerLineRect = new RectangleF(
                    tabHeaderRect.Left,
                    tabHeaderRect.Top,
                    tabHeaderRect.Width,
                    3);

                e.Graphics.FillRectangle(Brushes.DarkBlue, headerLineRect);
#endif
            }

            txt_brush = Brushes.Black;
            box_brush = Brushes.Silver;
            box_pen = Pens.Black;

            // Draw the tab's text centered.
            e.Graphics.DrawString(
                homeTabContainer.TabPages[e.Index].Text,
                e.State == DrawItemState.Selected ? _tabFontSelected : _tabFontNormal,
                txt_brush,
                layout_rect,
                _tabStringFormat);

            if (tabIcon != null)
            {

            }

            // finally draw close button
            if (homeTabContainer.TabPages[e.Index].Tag != null)
            {
                Point pointClose = new Point((int)layout_rect.Right - 15, (int)layout_rect.Bottom - 15);
                e.Graphics.DrawImage(Properties.Resources.close, pointClose);
            }
        }

        private TabPage GetTabAt(Point pt)
        {
            //Point mouseLocation = homeTabContainer.PointToClient(pt);

            for (int i = 0; i < homeTabContainer.TabPages.Count; i++)
            {
                TabPage page = homeTabContainer.TabPages[i];
                Rectangle tabRect = homeTabContainer.GetTabRect(i);

                if (tabRect.Contains(pt))
                {
                    return (page);
                }
            }

            return (null);
        }

        private void homeTabContainer_MouseDown(object sender, MouseEventArgs e)
        {
            // are we closing a tab
            TabPage currPage = GetTabAt(e.Location);

            if (currPage == null || currPage.Tag == null)
                return;

            Rectangle tabRect = homeTabContainer.GetTabRect(homeTabContainer.TabPages.IndexOf(currPage));

            Rectangle closeRect = new Rectangle(tabRect.Right - 23, tabRect.Bottom - 23, 16, 16);

            if (closeRect.Contains(e.Location))
            {
                if (homeTabContainer.SelectedIndex > 0)
                {
                    _selectedTab = homeTabContainer.SelectedTab;
                    BaseTabControl ctl = (BaseTabControl)_selectedTab.Controls[0];
                    ctl.BeforeTabHide();
                }

                homeTabContainer.TabPages.Remove(currPage);
                return;
            }


            if (homeTabContainer.AllowDrop)
            {
                _dragStartPosition = new Point(e.X, e.Y);
                homeTabContainer.DoDragDrop(homeTabContainer.SelectedTab, DragDropEffects.Move);
            }
        }

        private void homeTabContainer_MouseUp(object sender, MouseEventArgs e)
        {
            if (homeTabContainer.AllowDrop)
            {
                this._dragStartPosition = Point.Empty;
            }
        }

        private void homeTabContainer_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                Point pagePoint = homeTabContainer.PointToClient(new Point(e.X, e.Y));
                TabPage currMousePage = GetTabAt(pagePoint);

                if (currMousePage == null || currMousePage.Tag == null)
                    e.Effect = DragDropEffects.None;
                else
                    e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void homeTabContainer_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                e.Effect = DragDropEffects.Move;

                TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));

                Point pagePoint = homeTabContainer.PointToClient(new Point(e.X, e.Y));
                TabPage currMousePage = GetTabAt(pagePoint);

                if (currMousePage == null || currMousePage == dragTab)
                {
                    return;
                }

                //	Capture insert point and adjust for removal of tab
                //	We cannot assess this after removal as differeing tab sizes will cause
                //	inaccuracies in the activeTab at insert point.
                int insertPoint = homeTabContainer.TabPages.IndexOf(currMousePage);

                if (insertPoint < 1)
                {
                    insertPoint = 1;
                }

                //	Remove from current position (could be another tabcontrol)
                ((TabControl)dragTab.Parent).TabPages.Remove(dragTab);

                //	Add to current position
                homeTabContainer.TabPages.Insert(insertPoint, dragTab);
                homeTabContainer.SelectedTab = dragTab;

                // save position
                string settingName = String.Format(POS.Base.Classes.StringConstants.TRACKING_REFERENCE,
                    AppController.ActiveUser.ID.ToString(), homeTabContainer.SelectedTab.Text, "P");
                SharedBase.LibraryHelperClass.SettingsSet(settingName,
                    homeTabContainer.TabPages.IndexOf(homeTabContainer.SelectedTab).ToString());
            }
        }

        private void homeTabContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (homeTabContainer.AllowDrop && e.Button == MouseButtons.Left)
            {
                if (!_dragStartPosition.IsEmpty)
                {
                    TabPage dragTab = homeTabContainer.SelectedTab;

                    if (dragTab != null)
                    {
                        //	Test for movement greater than the drag activation trigger area
                        Rectangle dragTestRect = new Rectangle(this._dragStartPosition, Size.Empty);
                        dragTestRect.Inflate(SystemInformation.DragSize);
                        Point pt = this.PointToClient(Control.MousePosition);
                    }
                }
            }
        }

        private void homeTabContainer_Selecting(object sender, TabControlCancelEventArgs e)
        {
            BaseTabControl ctl = null;

            if (_selectedTab != null)
            {
                if (_selectedTab.HasChildren)
                {
                    ctl = (BaseTabControl)_selectedTab.Controls[0];
                    ctl.BeforeTabHide();
                    _selectedTab = null;
                }

                TabPanelAndToolbarDataRemove();
            }

            HomeTabShowing = e.TabPageIndex == 0;

            if (e.TabPageIndex > 0)
            {
                _selectedTab = homeTabContainer.SelectedTab;
                ctl = (BaseTabControl)_selectedTab.Controls[0];
                ctl.BeforeTabShow();

                TabPanelAndToolbarDataLoad();
            }
            else
            {
                HelpTopic = String.Empty;
                return;
            }

            HomeCard currTab = (HomeCard)homeTabContainer.SelectedTab.Tag;
            HelpTopic = currTab.HepString();

            if (homeTabContainer.SelectedIndex > 0)
            {
                ctl.AfterTabShow();
                ctl.AfterResize();
            }

        }

#endregion Tabs

#region Drag Drop Home Tab Buttons

        private void homeButtonPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (homeButtonPanel.AllowDrop && e.Button == MouseButtons.Left)
            {
                Point controlPos = homeButtonPanel.PointToClient(Cursor.Position);
                _dragStartPosition = new Point(controlPos.X, controlPos.Y);
                BaseHomeTabButton homeTabButton = (BaseHomeTabButton)homeButtonPanel.GetChildAtPoint(controlPos);

                if (homeTabButton != null && homeTabButton.MouseOverHeader)
                    homeButtonPanel.DoDragDrop(homeTabButton, DragDropEffects.Move);
            }
        }

        private void homeButtonPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (homeButtonPanel.AllowDrop && e.Button == MouseButtons.Left)
            {
                this._dragStartPosition = Point.Empty;
            }
        }

        private void homeButtonPanel_DragDrop(object sender, DragEventArgs e)
        {
            BaseHomeTabButton data = (BaseHomeTabButton)e.Data.GetData(typeof(BaseHomeTabButton));
            FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
            Point p = _destination.PointToClient(new Point(e.X, e.Y));
            var item = _destination.GetChildAtPoint(p);
            int index = _destination.Controls.GetChildIndex(item, false);
            _destination.Controls.SetChildIndex(data, index);
            _destination.Invalidate();
        }

        private void homeButtonPanel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(BaseHomeTabButton)) ||
                e.Data.GetDataPresent(typeof(FlowLayoutPanel)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void homeButtonPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

#endregion Drag Drop Home Tab Buttons

#endregion Private Methods
    }

}
