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
 *  File: POSInstaller.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.POSInstall
{
    [Serializable]
    public sealed class POSInstaller : BaseObject
    {
        public static void AddUserLicences(Users.User user, string fileName)
        {
            DAL.FirebirdDB.POSInstallerAddLicence(user, fileName);
        }

        public static POSInstall InstallServer(string email, string password, string computerName)
        {
            return (DAL.FirebirdDB.POSInstallerAdd(email, password, computerName, computerName, "Server"));
        }


        public static POSInstall InstallClient(string email, string password, string computerName, string serverName)
        {
            return (DAL.FirebirdDB.POSInstallerAdd(email, password, computerName, serverName, "Client"));
        }

        public static POSInstall ServerList(string email, string password)
        {
            return (DAL.FirebirdDB.POSInstallerServers(email, password));
        }

        public static bool InstallValid(string storeID)
        {
            return (DAL.FirebirdDB.POSInstallValid(storeID));
        }

        public static void PosInstallSetSite(int siteID)
        {
            DAL.FirebirdDB.POSInstallSetSiteID(siteID);
        }
    }
}
