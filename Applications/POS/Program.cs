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
 *  File: Program.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;

using PointOfSale.Forms;
using PointOfSale.Classes;
using PointOfSale.Forms.Other;

using Library.BOL.Users;
using POS.Base.Classes;

#if ERROR_MANAGER
using ErrorManager.ErrorClient;
#endif

namespace PointOfSale
{
    static class Program
    {
#if USE_WIN_API
        [DllImportAttribute(StringConstants.FILE_LIBRARY_USER32)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
#endif

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ConfigurationSettings.LoadStaticConfig();

#if !DEBUG
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
#endif

            // is there a new version
            if (CheckForNewVersion())
            {
                return;
            }

            Shared.Classes.ThreadManager.Initialise();
            try
            {
                bool createdNew = true;
                try
                {
                    Shared.Classes.Parameters.Initialise(args, new char[] { '/', '-' }, new char[] { ':', ' ' });

                    // initial param handler, does not require a login
                    if (ParamHandler.ProcessParametersInitial())
                        return;

                    // The next line ensures that the dal is loaded 
                    Library.DAL.DALHelper.AllowCaching = true;

                    using (Mutex mutex = new Mutex(true, Application.ProductName, out createdNew))
                    {
                        if (!Shared.Classes.Parameters.OptionExists(StringConstants.PARAM_MULTIPLE_INSTANCE) &&
                            createdNew)
                        {
#if ERROR_MANAGER
                            ErrorClient.InitErrorClient(
                                new DisplayOptions(true, false),
                                new Options(
                                    ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_IP),
                                    Shared.Utilities.StrToIntDef(
                                    ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_PORT), 37789),
                                    ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_USER),
                                    ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD))
                                );
#endif

                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);

                            AppController controler = AppController.ApplicationController;

                            // do we need to run the initial setup wizard?
                            InitialSetupWizard.LoadInitialSetup();

                            AppController.ShowSplashScreen();

                            User _User = null;

                            AppController.UpdateSplashScreen(Languages.LanguageStrings.AppLoadingSettings);

                            Library.LibraryHelperClass.InitialiseSettings();

                            //load all users
                            try
                            {
                                AppController.UpdateSplashScreen(Languages.LanguageStrings.AppWaitingLogin);

                                if (LoginForm.DoLogin(ref _User, Languages.LanguageStrings.Login))
                                {
                                    AppController.UpdateSplashScreen(Languages.LanguageStrings.AppInitialising);
                                    AppController.ApplicationController.GetUser = _User;

                                    AppController.PostLogin();

                                    if (ParamHandler.ProcessParameters())
                                        return;

                                    Application.Run(new MainForm());
                                }
                                else
                                {
                                    AppController.ApplicationController.ProgramClosing();
                                }
                            }
                            finally
                            {
                                controler.Dispose();
                            }
                        }

#if USE_WIN_API
                        else
                        {
                            Process current = Process.GetCurrentProcess();
                            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                            {
                                if (process.Id != current.Id)
                                {
                                    SetForegroundWindow(process.MainWindowHandle);
                                    break;
                                }
                            }
                        }
#endif
                    }
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err);

                    if (err.Source == StringConstants.ERROR_FB_CLIENT &&
                        err.Message.StartsWith(StringConstants.ERROR_NO_NETWORK))
                    {
                        MessageBox.Show(Languages.LanguageStrings.AppErrorConnectDatabase,
                            Languages.LanguageStrings.AppError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(err.Message,
                            Languages.LanguageStrings.AppError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            finally
            {
                Shared.Classes.ThreadManager.CancelAll(1);
                Shared.Classes.ThreadManager.Finalise();
                Shared.Classes.Parameters.Finalise();
            }
        }

#if !DEBUG
        private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            // for language resource files only, if not found, look in languages folder,
            // anything else can be ignored here
            AssemblyName assyName = new AssemblyName(args.Name);

            if (!assyName.Name.ToLower().StartsWith(StringConstants.LANGUAGE_RESOURCE_FILE) ||
                (assyName.CultureName == StringConstants.CULTURE_ENGLISH_UK ||
                assyName.CultureName == StringConstants.CULTURE_ENGLISH || 
                String.IsNullOrEmpty(assyName.CultureName)))
            {
                return (null);
            }

            string path = String.Format(StringConstants.FOLDER_PATH, 
                AppController.POSFolder(FolderType.Languages, false),
                assyName.CultureName);
            path = Path.Combine(path, assyName.Name);

            if (!path.EndsWith(StringConstants.FILE_EXTENSION_DLL))
            {
                path = path + StringConstants.FILE_EXTENSION_DLL;
            }

            if (File.Exists(path))
            {
                return (Assembly.LoadFile(path));
            }

            return (null);
        }
#endif

        /// <summary>
        /// Checks for a new version, if a new version has just been installed then it delete's the install file
        /// otherwise it returns that a new version is available.
        /// </summary>
        /// <returns>true if new version found, otherwise false</returns>
        private static bool CheckForNewVersion()
        {
            bool Result = false;

            if (File.Exists(AppController.POSFolder(FolderType.Root, true) + StringConstants.POS_NEW_VERSION_INSTALLED))
            {
                DeleteFile(AppController.POSFolder(FolderType.Root, true) + StringConstants.POS_NEW_VERSION_FILE, 0);
                DeleteFile(AppController.POSFolder(FolderType.Root, true) + StringConstants.POS_NEW_VERSION_INSTALLED, 0);
            }
            else if (File.Exists(AppController.POSFolder(FolderType.Root, true) + StringConstants.POS_NEW_VERSION_FILE))
            {
                Result = true;

                try
                {
                    // confirm the CRC of the downloaded file, compared to the CRC held online, 
                    // if different delete the download as it's probably corrupt
                    string xml = ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_INSTALLER_UPDATE_URL);
                    string newFile = AppController.POSFolder(FolderType.Root, true) +
                        StringConstants.POS_NEW_VERSION_FILE;
                    string crcLocal = Shared.Utilities.FileCRC(newFile, false);
                    string crcRemote = Library.XML.GetXMLValue(xml, StringConstants.SETTINGS_APPLICATION, StringConstants.SETTINGS_CRC);

                    if (crcLocal == crcRemote)
                    {
                        Process.Start(AppController.POSFolder(FolderType.Root, true) +
                            StringConstants.POS_NEW_VERSION_FILE);
                        return (Result);
                    }
                    else
                    {
                        DeleteFile(newFile, 0);
                    }
                }
                catch
                {
                }

            }

            return (Result);
        }

        private static void DeleteFile(string fileName, int iteration)
        {
            Shared.EventLog.Add(String.Format(StringConstants.FILE_DELETE, iteration, fileName));
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
            catch (Exception err)
            {
                if (iteration >= 10)
                {
                    Shared.EventLog.Add(err, fileName);
                }
                else
                {
                    Thread.Sleep(400);
                    DeleteFile(fileName, iteration + 1);
                }
            }
        }
    }

}
