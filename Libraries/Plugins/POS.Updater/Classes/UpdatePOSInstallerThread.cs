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
 *  File: UpdatePOSInstallerThread.cs
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
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;

using Shared.Classes;
using POS.Base.Classes;

namespace POS.UpdateImages.Classes
{

    public class UpdatePOSInstallerThread : ThreadManager
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public UpdatePOSInstallerThread()
            : base (null, new TimeSpan(0, 60, 0), null, 20000)
        {
            this.HangTimeout = 70;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            if (HasCancelled())
                return (false);

            try
            {
                string xml = ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_INSTALLER_UPDATE_URL);
                string verRemote = SharedBase.XML.GetXMLValue(xml, "Application", "Version");

                POS.Base.Plugins.NotificationEventArgs args = new POS.Base.Plugins.NotificationEventArgs(
                    StringConstants.PLUGIN_EVENT_HOST_VERSION, null);
                PluginManager.RaiseEvent(args);

                if (!String.IsNullOrEmpty(verRemote))
                {

                    Version VerLocal = new Version((string)args.Result);
                    Version VerRemote = new Version(String.IsNullOrEmpty(verRemote) ? "1.0.0.0" : verRemote);

                    if (VerRemote.CompareTo(VerLocal) > 0)
                    {
                        Shared.FileDownload.Download(SharedBase.XML.GetXMLValue(xml, "Application", "Location"),
                            AppController.POSFolder(FolderType.Root, true) + StringConstants.POS_NEW_VERSION_FILE,
                            500, 500);

                        PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(
                            StringConstants.PLUGIN_EVENT_NEW_POS_VERSION, null));
                    }
                }
            }
            catch (Exception err)
            {
                // on error assume that problem communicating with website
                if (err.Message.Contains("asdf"))
                {
                    
                }
            }

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods


        #endregion Private Methods
    }
}
