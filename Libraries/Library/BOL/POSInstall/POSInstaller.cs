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
