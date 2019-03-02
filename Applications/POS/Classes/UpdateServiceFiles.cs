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
 *  File: UpdateServiceFiles.cs
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
using System.Reflection;
using POS.Base.Classes;

namespace PointOfSale.Classes
{
    internal static class UpdateServiceFiles
    {
        private static string _path = String.Empty;
        private static int _currVersionRemote = 1;

        
        
        internal static void UpdateService(string Path)
        {
            _path = Shared.Utilities.AddTrailingBackSlash(Path);
            Thread LauncherThread = new Thread(new ThreadStart(DoUpdateServiceFiles)); // Create new thread
            LauncherThread.Priority = ThreadPriority.Normal; // Set priority to normal
            LauncherThread.IsBackground = true; // Set it to a background thread
            LauncherThread.Name = StringConstants.THREAD_NAME_UPDATE_SERVICE; // Name the thread
            LauncherThread.Start();
        }

        private static void DoUpdateServiceFiles()
        {
            string serviceFile = StringConstants.FILE_SERVICE_UPDATE;

            try
            {
                if (!ServiceUptoDate())
                {
                    serviceFile = String.Format(serviceFile, _currVersionRemote);

                    if (!File.Exists(_path + serviceFile))
                    {
                        SharedBase.FileDownload.Download(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_BASE_WEB_SERVICE_UPDATE) + serviceFile, _path + serviceFile);
                    }

                    // stop service guard


                    // stop replication service 

                    //update the files
                    SharedBase.ZipFiles.Unpack(_path + serviceFile, _path);
                    File.Delete(_path + serviceFile);

                    //start replication service


                    // start service guard
                    XMLManipulation.SetXMLValue(_path + StringConstants.XML_CONFIG_FILE,
                        StringConstants.SETTINGS_SERVICE_FILES, StringConstants.SETTINGS_VERSION, _currVersionRemote.ToString());
                }
            }
            catch (Exception err)
            {
                if (File.Exists(_path + serviceFile))
                    File.Delete(_path + serviceFile);

                SharedBase.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, serviceFile);
            }
        }

        private static bool ServiceUptoDate()
        {
            bool Result = false;

            int currVersionLocal = XMLManipulation.GetXMLValue(_path + StringConstants.XML_CONFIG_FILE,
                StringConstants.SETTINGS_SERVICE_FILES, StringConstants.SETTINGS_VERSION, 1);
            _currVersionRemote = XMLManipulation.GetXMLValue(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_BASE_WEB_POS_VERSION),
                StringConstants.SETTINGS_SERVICE_FILES, StringConstants.SETTINGS_VERSION, 1);

            Result = (currVersionLocal >= _currVersionRemote);

            return (Result);
        }
    }
}
