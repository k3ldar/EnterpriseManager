using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Reflection;
using System.ServiceProcess;

using ICSharpCode.SharpZipLib.Zip;
using POS.Base.Classes;

using PointOfSale.Classes;

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
                        Library.FileDownload.Download(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_BASE_WEB_SERVICE_UPDATE) + serviceFile, _path + serviceFile);
                    }

                    // stop service guard


                    // stop replication service 

                    //update the files
                    Library.ZipFiles.Unpack(_path + serviceFile, _path);
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

                Library.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, serviceFile);
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
