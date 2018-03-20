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
 *  File: GeoIPUpdateThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

namespace Website.Library.Core.Threads
{
#if GeoIPUpdates
    /// <summary>
    /// Thread that runs and checks for GeoIP updates, the actual update will only 
    /// take place once every 24 hours, but the thread will execute every 30 minutes
    /// to see if an update exists
    /// 
    /// Also encrypts the latest download versions for others to download
    /// </summary>
    internal class GeoIPUpdateThread : Shared.Classes.ThreadManager
    {
        make logging injectible!!
        private DateTime lastCheckedDownload = DateTime.Now.AddDays(-1);
        private DateTime lastCheckedEncrypt = DateTime.Now.AddDays(-1);

        private string geoPath = String.Format("{0}Admin\\GeoUpdate\\", 
            Shared.Utilities.AddTrailingBackSlash(GlobalClass.RootPath));
        private string encPath = String.Format("{0}Download\\Files\\GeoIP\\", 
            Shared.Utilities.AddTrailingBackSlash(GlobalClass.RootPath));
        private string fileVersions = String.Format("{0}Download\\Versions.xml", 
            Shared.Utilities.AddTrailingBackSlash(GlobalClass.RootPath));
        private string dbConnection = lib.DAL.DALHelper.ConnectionString(DatabaseType.GeoIPUpdates);

        internal GeoIPUpdateThread()
            : base(null, new TimeSpan(0, 30, 0))
        {
            this.HangTimeout = 0;
            RunAtStartup = true;
            ContinueIfGlobalException = true;
        }

        protected override bool Run(object parameters)
        {
            //run the geoupdate
            try
            {
                TimeSpan span = DateTime.Now - lastCheckedDownload;

                if (span.TotalMinutes > 30)
                {
                    GeoIP.GeoIP geo = new GeoIP.GeoIP(geoPath, dbConnection, "WS_IPTOCOUNTRY_EXTERNAL", -20);
                    try
                    {
                        geo.ConnectToFirebird();
                        geo.DownloadLatest();
                        geo.DisconnectFromFirebird();
                    }
                    catch (Exception errDownload)
                    {
                        Shared.EventLog.Add(errDownload);
                    }
                    finally
                    {
                        geo.Dispose();
                        geo = null;
                    }

                    lastCheckedDownload = DateTime.Now;
                }

                span = DateTime.Now - lastCheckedEncrypt;

                if (span.TotalMinutes >= 60.0)
                {
                    GeoIP.GeoIP geo = new GeoIP.GeoIP(fileVersions, encPath, dbConnection);
                    try
                    {
                        geo.ConnectToFirebird();
                        geo.UpdateMissingCityVersions();
                        long latestVersion = BaseWebApplication.GeoIPLatestVersion;
                        DateTime lastUpdated = BaseWebApplication.GeoIPLastUpdated;

                        if (geo.GenerateEncryptedInstalls(ref latestVersion, ref lastUpdated))
                        {
                            BaseWebApplication.GeoIPLastUpdated = lastUpdated;
                            BaseWebApplication.GeoIPLatestVersion = latestVersion;
                        }

                        geo.DisconnectFromFirebird();
                        lastCheckedEncrypt = DateTime.Now;
                    }
                    catch (Exception geoError)
                    {
                        Shared.EventLog.Add(geoError);
                    }
                    finally
                    {
                        geo.Dispose();
                        geo = null;
                    }
                }
            }
            catch (Exception err)
            {
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }
    }

#endif
}
