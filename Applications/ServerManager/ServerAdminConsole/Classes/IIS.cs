using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Web.Administration;

namespace ServerAdminConsole
{
    internal static class IIS
    {
        internal static bool CreateWebsite(string websiteName, string poolName, string rootPath, string logPath)
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    Site webSite = serverManager.Sites[websiteName];

                    if (webSite == null)
                    {
                        webSite = serverManager.Sites.Add(websiteName, "http", "*:80:www." + websiteName, rootPath);
                        webSite.Bindings.Add("*:80:" + websiteName, "http");
                    }

                    webSite.ApplicationDefaults.ApplicationPoolName = poolName;
                    webSite.LogFile.Directory = logPath;

                    serverManager.CommitChanges();

                    if (webSite.State == ObjectState.Stopped)
                        webSite.Start();

                    return (true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error Creating Website {0} {1}", poolName, error.Message);
                return (false);
            }
        }

        internal static bool CreateApplicationPool(string poolName, string userName, string password)
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    ApplicationPool applicationPool = serverManager.ApplicationPools[poolName];

                    if (applicationPool == null)
                        applicationPool = serverManager.ApplicationPools.Add(poolName);

                    applicationPool.ManagedRuntimeVersion = "v4.0";
                    applicationPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
                    applicationPool.ProcessModel.UserName = String.Format("{0}\\{1}", Environment.MachineName, userName);
                    applicationPool.ProcessModel.Password = password;

                    serverManager.CommitChanges();

                    return (true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error Creating App Pool {0} {1}", poolName, error.Message);
                return (false);
            }
        }
    }
}
