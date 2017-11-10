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
 *  File: ParamHandler.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using POS.Base.Classes;
using Shared.Classes;

namespace PointOfSale.Classes
{
    internal static class ParamHandler
    {
        /// <summary>
        /// Called after login 
        /// </summary>
        /// <returns></returns>
        internal static bool ProcessParameters()
        {
            if (Parameters.OptionExists(StringConstants.PARAM_ADMINISTRATION))
            {
                AppController.HideSplashScreen();
                AdminSettingsWrapper.LoadAdminSettings(null);
                return (true);
            }

            return (false);
        }

        /// <summary>
        /// Called initially before login etc
        /// </summary>
        /// <returns></returns>
        internal static bool ProcessParametersInitial()
        {
            if (Parameters.OptionExists(StringConstants.PARAM_CONFIGURE_REPLICATION))
            {
                ProcessInstallFiles();
                return (true);
            }

            if (Parameters.OptionExists(StringConstants.PARAM_ADMIN_SET_USER))
            {
                SetupInitialUser();
                return (true);
            }

            if (Parameters.OptionExists(StringConstants.PARAM_ADMIN_CONFIG))
            {
                AppController.HideSplashScreen();

                Forms.Other.SystemConfig config = new Forms.Other.SystemConfig();
                try
                {
                    config.ShowDialog();
                }
                finally
                {
                    config.Dispose();
                    config = null;
                }
                return (true);
            }

            return (false);
        }

        private static bool SetupInitialUser()
        {
            if (Library.DAL.DALHelper.ConfigureDAL(
                new string[]
                    {
                        "setupSuperUser",
                        Parameters.GetOption(StringConstants.PARAM_ADMIN_FIRST_NAME, String.Empty),
                        Parameters.GetOption(StringConstants.PARAM_ADMIN_LAST_NAME, String.Empty),
                        Parameters.GetOption(StringConstants.PARAM_ADMIN_EMAIL, String.Empty),
                        Parameters.GetOption(StringConstants.PARAM_ADMIN_PASSWORD, String.Empty)
                    }))
                return (true);


            return (false);
        }

        private static bool ProcessInstallFiles()
        {
            string fileName = Parameters.GetOption("installfile", String.Empty);
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    string xmlFile = Shared.Utilities.CurrentPath(true) + "HSCConfig.xml";
                    // get xml values from the config
                    string siteID = Parameters.GetOption(StringConstants.PARAM_SITE_ID, String.Empty);
                    string connString = Shared.XML.GetXMLValue("Connection", "ConnectionString", String.Empty, xmlFile, "SieraDelta");

                    string configFileContents = Shared.Utilities.FileRead(fileName, true);
                    configFileContents = configFileContents.Replace("#SITENUMBER#", siteID);
                    configFileContents = configFileContents.Replace("#LOCALDATABASE#",
                        Shared.Utilities.GetDatabasePart(connString, "Database"));
                    configFileContents = configFileContents.Replace("#LOCALPORT#",
                        Shared.Utilities.GetDatabasePart(connString, "Port"));
                    configFileContents = configFileContents.Replace("#LOCALPORT#",
                        Shared.Utilities.GetDatabasePart(connString, "Port"));

                    string repPath = Shared.Utilities.AddTrailingBackSlash(
                        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)) + "Firebird Replication";
                    configFileContents = configFileContents.Replace("#REPLICATIONINSTALL#",
                        repPath);

                    xmlFile = Shared.Utilities.CurrentPath(true) + "service.xml";
                    connString = Shared.XML.GetXMLValue("Connection", "ReplicationString", String.Empty, xmlFile, "SieraDelta");
                    configFileContents = configFileContents.Replace("#REMOTEDATABASE#",
                        Shared.Utilities.GetDatabasePart(connString, "Database"));

                    configFileContents = configFileContents.Replace("#NAME#", "Client Site " + siteID);

                    Shared.Utilities.FileWrite(fileName, configFileContents);

                    Library.BOL.POSInstall.POSInstaller.PosInstallSetSite(Convert.ToInt32(siteID));
                }
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
                return (false);
            }

            return (true);
        }
    }
}
