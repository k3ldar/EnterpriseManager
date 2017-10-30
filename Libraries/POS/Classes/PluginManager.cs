using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Shared;
using Shared.Classes;
using Languages;
using POS.Base.Plugins;

namespace POS.Base.Classes
{
    public static class PluginManager
    {
        #region Private Members

        private static HomeCards _homeCards = null;

        /// <summary>
        /// Tray Notification Collection
        /// </summary>
        private static TrayNotificationCollection _trayNotifications = new TrayNotificationCollection();

        /// <summary>
        /// Lock object for thread safe operations
        /// </summary>
        private static object _lockObject = new object();

        /// <summary>
        /// object which contains plugins
        /// </summary>
        private static List<PluginModule> _pluginModules = new List<PluginModule>();

        /// <summary>
        /// collection of notifications including the plugins which are interested in receiving them
        /// </summary>
        private static Dictionary<string, List<PluginModule>> _pluginNotifications = new Dictionary<string, List<PluginModule>>();

        #endregion Private Members

        #region Static Methods

        /// <summary>
        /// Loads all available plugins for the pos
        /// 
        /// Will only load those as marked for loading
        /// </summary>
        public static void LoadPlugins(Form parentForm)
        {
            string pluginData = AppController.POSFolder(FolderType.Root, false) + StringConstants.FILE_PLUGIN_DATA;

            if (File.Exists(pluginData))
            {
                string[] lines = Shared.Utilities.FileRead(pluginData, false).Replace(
                    StringConstants.SYMBOL_CRLF, StringConstants.SYMBOL_RETURN).Split(StringConstants.SYMBOL_RETURN_CHAR);

                foreach (string pluginFile in lines)
                {
                    string[] plugin = pluginFile.Split(StringConstants.SYMBOL_HASH_CHAR);

                    plugin[0] = ResetPluginLocation(plugin[0]);

                    if (File.Exists(plugin[0]) && !PluginClassExists(plugin[1]))
                    {
                        PluginModule newModule = new PluginModule(plugin[0], plugin[1]);

                        // is it disabled?
                        if (plugin[3] == StringConstants.TRUE)
                        {
                            using (TimedLock.Lock(_lockObject))
                            {
                                newModule.Disabled = true;
                                newModule.IsActive = false;
                                newModule.IsLoaded = false;
                                newModule.CanLoad = false;
                                _pluginModules.Add(newModule);
                            }

                            continue;
                        }

                        if (plugin[2] == StringConstants.TRUE)
                        {
                            using (TimedLock.Lock(_lockObject))
                            {
                                newModule.CanLoad = true;

                                if (String.IsNullOrEmpty(plugin[0]))
                                {
                                    Assembly plA = Assembly.GetExecutingAssembly();
                                    Type trp = plA.GetType(plugin[1]);
                                    newModule.PluginModuleInstance = (BasePlugin)Activator.CreateInstance(trp, parentForm);
                                }
                                else
                                {
                                    Assembly pluginAssembly = LoadAssembly(plugin[0]);
                                    Type trp = pluginAssembly.GetType(plugin[1]);

                                    if (trp != null)
                                        newModule.PluginModuleInstance = (BasePlugin)Activator.CreateInstance(trp, parentForm);
                                }

                                if (newModule.PluginModuleInstance != null)
                                {
                                    LoadPlugin(newModule);

                                    _pluginModules.Add(newModule);
                                }
                            }

                        }
                        else
                        {
                            using (TimedLock.Lock(_lockObject))
                            {
                                Assembly pluginAssembly = LoadAssembly(plugin[0]);
                                Type trp = pluginAssembly.GetType(plugin[1]);
                                newModule.PluginModuleInstance = (BasePlugin)Activator.CreateInstance(trp, parentForm);
                                newModule.CanLoad = false;

                                _pluginModules.Add(newModule);
                            }
                        }
                    }
                }
            } // plugin data file not found

#if !DEBUG
            if (!Parameters.OptionExists("IgnoreNewPlugins"))
                CheckForNewPlugins(parentForm);
#endif

            _trayNotifications.Sort();

            // launch plugin update thread
            //Shared.Classes.ThreadManager.ThreadStart(new UpdatePOS(), 
            //    StringConstants.PLUGIN_UPDATER_THREAD, System.Threading.ThreadPriority.Lowest);

            // launch plugin alert thread
            Shared.Classes.ThreadManager.ThreadStart(new PluginAlertsThread(),
                StringConstants.PLUGIN_ALERT_THREAD, System.Threading.ThreadPriority.Lowest);
        }

        /// <summary>
        /// Loads and initialises an individual plugin
        /// </summary>
        /// <param name="newPlugin"></param>
        public static void LoadPlugin(Plugins.BasePlugin newPlugin)
        {
            PluginModule newModule = new PluginModule("PointOfSale.Plugins." + newPlugin.GetType().Name);
            newModule.PluginModuleInstance = newPlugin;
            newModule.PluginFile = Shared.Utilities.CurrentPath(true) + "PointOfSale.exe";
            LoadPlugin(newModule);
            newModule.IsActive = newModule.IsLoaded;

            using (TimedLock.Lock(_lockObject))
            {
                _pluginModules.Add(newModule);
            }
        }

        /// <summary>
        /// Loads and initialises an individual plugin
        /// </summary>
        /// <param name="module"></param>
        public static void LoadPlugin(PluginModule module)
        {
            using (TimedLock.Lock(_lockObject))
            {
                //can we load the plugin???
                bool canLoad = module.PluginModuleInstance.Version() == PluginVersion.VersionInternal ||
                    Shared.XML.GetXMLValue(StringConstants.XML_PLUGINS,
                    Shared.Validation.Validate(module.PluginClassName, ValidationTypes.AtoZ), true,
                    AppController.POSFolder(FolderType.Root, true) + StringConstants.FILE_CONFIG_PLUGIN);

                if (canLoad && module.PluginModuleInstance != null)
                {
                    if (module.PluginModuleInstance.BeforeLoad())
                    {
                        module.IsLoaded = true;
                        module.IsActive = true;
                        AppController.UpdateSplashScreen(String.Format(Languages.LanguageStrings.AppPluginLoading,
                            module.PluginModuleInstance.PluginName()));

                        List<string> names = new List<string>();
                        module.PluginModuleInstance.NotificationsGet(ref names);

                        using (TimedLock.Lock(_lockObject))
                        {
                            foreach (string name in names)
                            {
                                if (String.IsNullOrWhiteSpace(name))
                                    continue;

                                if (!_pluginNotifications.ContainsKey(name))
                                {
                                    _pluginNotifications.Add(name, new List<PluginModule>());
                                }

                                _pluginNotifications[name].Add(module);
                            }
                        }

                        // wire up events
                        module.PluginModuleInstance.PluginUsage += pluginModule_PluginUsage;
                        module.PluginModuleInstance.POSBringToFront += pluginModule_BringToFront;
                        module.PluginModuleInstance.EventNotification += RaiseEventNotification;

                        // any tray notifications
                        TrayNotificationCollection notifications = module.PluginModuleInstance.TrayNotifications();

                        if (notifications != null)
                        {
                            foreach (TrayNotification notification in notifications)
                            {
                                _trayNotifications.Add(notification);

                                notification.Position = Shared.XML.GetXMLValue(StringConstants.XML_PLUGIN_TRAY_ICON,
                                    String.Format(StringConstants.XML_PLUGIN_TRAY_ICON_POSITION,
                                    Shared.Validation.Validate(notification.ToString(), ValidationTypes.AtoZ)),
                                    _trayNotifications.Count, AppController.POSFolder(FolderType.Root, true) + StringConstants.FILE_CONFIG_PLUGIN);

                                notification.Visible = Shared.XML.GetXMLValue(StringConstants.XML_PLUGIN_TRAY_ICON,
                                    String.Format(StringConstants.XML_PLUGIN_TRAY_ICON_VISIBLE,
                                    Shared.Validation.Validate(notification.ToString(), ValidationTypes.AtoZ)),
                                    false, AppController.POSFolder(FolderType.Root, true) + StringConstants.FILE_CONFIG_PLUGIN);
                            }
                        }

                        RaisePluginLoad(module);
                        module.PluginModuleInstance.AfterLoad();
                    }
                }
                else
                {
                    module.IsLoaded = module.PluginModuleInstance != null;
                }
            }
        }

        /// <summary>
        /// Unloads a plugin and set's its active to false
        /// </summary>
        /// <param name="module"></param>
        public static void UnLoadPlugin(PluginModule module)
        {
            if (!module.IsLoaded)
                return;

            if (module.PluginModuleInstance.CanUnload())
            {
                module.PluginModuleInstance.Unload();

                // unplug events
                module.PluginModuleInstance.PluginUsage -= pluginModule_PluginUsage;
                module.PluginModuleInstance.POSBringToFront -= pluginModule_BringToFront;
                module.PluginModuleInstance.EventNotification -= RaiseEventNotification;

                // remove status bar items
                TrayNotificationCollection notifications = module.PluginModuleInstance.TrayNotifications();

                if (notifications != null)
                    foreach (TrayNotification notification in notifications)
                        if (_trayNotifications.Contains(notification))
                            _trayNotifications.Remove(notification);

                // clean up
                module.IsLoaded = false;
                RaisePluginUnload(module);
            }
        }

        /// <summary>
        /// Determines wether a plugin is loaded or not
        /// </summary>
        /// <param name="pluginName">Name of plugin</param>
        /// <returns>bool, true if plugin loaded and activated, otherwise false</returns>
        public static bool PluginLoaded(string pluginName)
        {
            foreach (PluginModule module in _pluginModules)
            {
                if (module.IsLoaded && module.PluginModuleInstance.PluginName() == pluginName)
                {
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// Saves the current plugin configuration
        /// </summary>
        public static void SavePluginConfiguration()
        {
            string pluginData = AppController.POSFolder(FolderType.Root, false) + StringConstants.FILE_PLUGIN_DATA;
            string newData = String.Empty;

            using (TimedLock.Lock(_lockObject))
            {
                _trayNotifications.Sort();

                foreach (TrayNotification notification in _trayNotifications)
                {
                    Shared.XML.SetXMLValue(StringConstants.XML_PLUGIN_TRAY_ICON,
                        String.Format(StringConstants.XML_PLUGIN_TRAY_ICON_POSITION,
                        Shared.Validation.Validate(notification.ToString(), ValidationTypes.AtoZ)),
                        notification.Position.ToString(),
                        AppController.POSFolder(FolderType.Root, true) + StringConstants.FILE_CONFIG_PLUGIN);

                    Shared.XML.SetXMLValue(StringConstants.XML_PLUGIN_TRAY_ICON,
                        String.Format(StringConstants.XML_PLUGIN_TRAY_ICON_VISIBLE,
                        Shared.Validation.Validate(notification.ToString(), ValidationTypes.AtoZ)),
                        notification.Visible.ToString(),
                        AppController.POSFolder(FolderType.Root, true) + StringConstants.FILE_CONFIG_PLUGIN);
                }

                foreach (PluginModule module in _pluginModules)
                {
                    // if it's an internal plugin then don't save the data
                    if (module.PluginVersion() == PluginVersion.VersionInternal)
                        continue;

                    Shared.XML.SetXMLValue(StringConstants.XML_PLUGINS,
                        Shared.Validation.Validate(module.PluginClassName, ValidationTypes.AtoZ),
                        module.CanLoad.ToString(),
                        AppController.POSFolder(FolderType.Root, true) + StringConstants.FILE_CONFIG_PLUGIN);

                    newData += String.Format(StringConstants.PLUGIN_DATA, module.PluginFile, module.PluginClassName,
                        module.CanLoad.ToString(), module.Disabled.ToString());

                    // load/unload at startup only
                    //if (module.IsLoaded && !module.IsActive)
                    //    UnLoadPlugin(module);
                    //else if (!module.IsLoaded && module.IsActive)
                    //    LoadPlugin(module);

                }


            }

            Shared.Utilities.FileWrite(pluginData, newData);
        }

        /// <summary>
        /// Returns a list of all available and active plugins
        /// </summary>
        /// <returns></returns>
        public static List<BasePlugin> PluginsGet()
        {
            List<BasePlugin> Result = new List<BasePlugin>();

            using (TimedLock.Lock(_lockObject))
            {
                foreach (PluginModule module in _pluginModules)
                {
                    if (module.IsActive)
                        Result.Add(module.PluginModuleInstance);
                }
            }

            return (Result);
        }

        /// <summary>
        /// Retruns a collection of plugins which can raise alerts
        /// </summary>
        /// <returns></returns>
        public static List<BasePlugin> PluginsGetAlert()
        {
            List<BasePlugin> Result = new List<BasePlugin>();

            using (TimedLock.Lock(_lockObject))
            {
                foreach (PluginModule module in _pluginModules)
                {
                    if (module.IsActive && module.PluginModuleInstance.RaiseAlerts)
                        Result.Add(module.PluginModuleInstance);
                }
            }

            return (Result);
        }

        /// <summary>
        /// Returns a list of all plugin modules
        /// </summary>
        /// <returns></returns>
        public static List<PluginModule> PluginModulesGet()
        {
            return (_pluginModules);
        }

        public static HomeCards HomeTabsGet()
        {
            if (_homeCards == null)
            {
                _homeCards = new HomeCards();

                foreach (PluginModule module in _pluginModules)
                {
                    HomeCards moduleTabs = module.PluginModuleInstance.HomeCards();

                    if (moduleTabs != null)
                    {
                        foreach (HomeCard tab in moduleTabs)
                            _homeCards.Add(tab);
                    }
                }
            }


            return (_homeCards);
        }

        /// <summary>
        /// Returns the currently configured Notification Items
        /// </summary>
        /// <param name="selectedOnly">returns user selected notifications if true, otherwise all of them</param>
        /// <returns></returns>
        public static TrayNotificationCollection TrayNotificationsGet(bool selectedOnly)
        {
            TrayNotificationCollection Result = new TrayNotificationCollection();

            foreach (TrayNotification item in _trayNotifications)
            {
                if (selectedOnly && item.Visible)
                    Result.Add(item);
                else if (!selectedOnly)
                    Result.Add(item);
            }

            return (Result);
        }

        /// <summary>
        /// Raises an event for all plugins
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void RaiseEvent(NotificationEventArgs e)
        {
            RaiseEventNotification(null, e);
        }

        public static void RaiseEvent(string eventName)
        {
            RaiseEvent(new NotificationEventArgs(eventName));
        }

        public static bool WebsitesEnabled()
        {
            NotificationEventArgs args = new NotificationEventArgs(StringConstants.PLUGIN_EVENT_WEBSITE_COUNT);
            args.Result = -1;
            PluginManager.RaiseEvent(args);

            if ((int)args.Result < 1)
                return (false);
            else
                return (true);
        }

        #endregion Static Methods

        #region Private Methods

        /// <summary>
        /// Looks for new plugins, within the plugins folder, and prompts to load them 
        /// </summary>
        private static void CheckForNewPlugins(Form parentForm)
        {
            AppController.UpdateSplashScreen(LanguageStrings.AppPluginCheckNewModules);

            try
            {
                // get all dll files in the plugin directory
                string[] pluginFiles = System.IO.Directory.GetFiles(
                    AppController.POSFolder(FolderType.Plugins, true),
                    StringConstants.FILE_SEARCH_DLL.Substring(
                    StringConstants.FILE_SEARCH_DLL.IndexOf(StringConstants.SYMBOL_PIPE) + 1),
                    SearchOption.TopDirectoryOnly);

                string newPlugins = String.Empty;
                bool promptGiven = false;

                foreach (string pluginFile in pluginFiles)
                {
                    if (!PluginModuleLoaded(pluginFile))
                    {
                        // new plugins found, prompt to load and move on
                        if (!promptGiven)
                        {
                            promptGiven = true;

                            if (AppController.LocalSettings.PluginsPromptToLoad &&
                                MessageBox.Show(LanguageStrings.AppPluginsNewModulesFound,
                                LanguageStrings.AppPluginsNewFoundPrompt, MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                            {
                                // user doesn't want to load new modules, exit and carry on
                                return;
                            }
                        }

                        using (TimedLock.Lock(_lockObject))
                        {
                            // user wants to load all new plugins
                            Assembly pluginAssembly = LoadAssembly(pluginFile);

                            if (pluginAssembly == null)
                                continue;

                            try
                            {
                                // get the class names
                                Type[] foundClasses = pluginAssembly.GetTypes();

                                // loop through all class names
                                foreach (Type type in foundClasses)
                                {
                                    // check to see if we have already loaded the class
                                    if (PluginClassExists(type.FullName))
                                        continue;

                                    try
                                    {
                                        if (type.BaseType != null && type.BaseType.FullName == typeof(BasePlugin).FullName)
                                        {
                                            PluginModule newModule = new PluginModule(pluginFile, type.ToString());
                                            newModule.Disabled = false;
                                            newModule.CanLoad = true;
                                            Type trp = pluginAssembly.GetType(type.ToString());
                                            newModule.PluginModuleInstance = (BasePlugin)Activator.CreateInstance(trp, parentForm);

                                            LoadPlugin(newModule);
                                            _pluginModules.Add(newModule);

                                            // only one plugin module per dll so quit now we have found one
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        //ignore this module and move on
                                    }
                                }
                            }
                            catch (System.Reflection.ReflectionTypeLoadException rErr)
                            {
                                string sLoadErr = pluginFile + StringConstants.SYMBOL_LINE_FEED;

                                foreach (Exception lErr in rErr.LoaderExceptions)
                                {
                                    sLoadErr += lErr.Message + StringConstants.SYMBOL_LINE_FEED;
                                }

                                Shared.EventLog.Add(rErr, sLoadErr);
                            }
                            catch (Exception err)
                            {
                                Shared.EventLog.Add(err);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }
        }

        /// <summary>
        /// Determines wether the plugin file is already loaded or not
        /// </summary>
        /// <param name="pluginFile"></param>
        /// <returns></returns>
        private static bool PluginModuleLoaded(string pluginFile)
        {
            foreach (PluginModule module in _pluginModules)
            {
                if (module.PluginFile.ToLower() == pluginFile.ToLower())
                    return (true);
            }

            return (false);
        }

        /// <summary>
        /// Determines wether the class name is already loaded to prevent duplicates
        /// </summary>
        /// <param name="pluginClass"></param>
        /// <returns></returns>
        private static bool PluginClassExists(string pluginClass)
        {
            foreach (PluginModule module in _pluginModules)
            {
                if (module.PluginClassName.ToLower() == pluginClass.ToLower())
                    return (true);
            }

            return (false);
        }

        /// <summary>
        /// Dynamically loads an assembly
        /// </summary>
        /// <param name="assemblyName">name of assembly</param>
        /// <returns>Assembly instance</returns>
        private static Assembly LoadAssembly(string assemblyName)
        {
            return (Assembly.Load(System.IO.File.ReadAllBytes(assemblyName)));
            //return (Assembly.LoadFile(assemblyName));
        }

        /// <summary>
        /// Checks to see if the file exists, if not, looks in Plugins folder for calling application
        /// 
        /// if the file is found in plugins folder, returns a string to that location, otherwise,
        /// original location is returned
        /// </summary>
        /// <param name="pluginFileName"></param>
        /// <returns></returns>
        private static string ResetPluginLocation(string pluginFileName)
        {
            if (System.IO.File.Exists(pluginFileName))
                return (pluginFileName);

            // original file not found look in plugins folder
            string newPluginFile = AppController.POSFolder(FolderType.Plugins, true) + System.IO.Path.GetFileName(pluginFileName);

            if (System.IO.File.Exists(newPluginFile))
                return (newPluginFile);
            else
                return (pluginFileName);
        }

        private static void RaiseEventNotification(object sender, NotificationEventArgs e)
        {
            List<PluginModule> interestedModules = null;

            using (TimedLock.Lock(_lockObject))
            {
                // notify all other listners and plugins that the event has occurred
                if (_pluginNotifications.ContainsKey(e.EventName))
                {
                    interestedModules = _pluginNotifications[e.EventName];
                }
            }

            if (interestedModules == null)
                return;

            foreach (PluginModule module in interestedModules)
            {
                if (module.IsLoaded && (sender == null ||
                    ((BasePlugin)sender).PluginName() != module.PluginModuleInstance.PluginName()))
                {
                    module.PluginModuleInstance.Notification(e);

                    if (!e.AllowContinue)
                        break;
                }
            }
        }

        private static void pluginModule_PluginUsage(object sender, POS.Base.Plugins.PluginUsageEventArgs e)
        {

        }

        private static void pluginModule_BringToFront(object sender, EventArgs e)
        {
            ((BasePlugin)sender).ParentForm.BringToFront();
        }

        private static void RaisePluginLoad(PluginModule module)
        {
            RaiseEventNotification(module.PluginModuleInstance, new NotificationEventArgs(StringConstants.PLUGIN_EVENT_PLUGIN_LOADED, null));

            if (PluginLoad != null)
                PluginLoad(null, new PluginManagerEventArgs(module));
        }

        private static void RaisePluginUnload(PluginModule module)
        {
            RaiseEventNotification(module.PluginModuleInstance, new NotificationEventArgs(StringConstants.PLUGIN_EVENT_PLUGIN_UNLOADED, null));

            if (PluginUnload != null)
                PluginUnload(null, new PluginManagerEventArgs(module));
        }

        #endregion Private Methods

        #region Events

        /// <summary>
        /// Event raised when a plugin is loaded
        /// </summary>
        public static event PluginManagerEventDelegate PluginLoad;

        /// <summary>
        /// Event raised when plugin is unloaded
        /// </summary>
        public static event PluginManagerEventDelegate PluginUnload;

        #endregion Events
    }
}
