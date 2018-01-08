using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Security.Principal;

using Shared.Classes;

namespace ServerAdminConsole
{
    class Program
    {
        private static string CACHE_HEADER = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
            "<configuration>\r\n" +
            "    <system.webServer>\r\n" +
            "        <httpProtocol>\r\n" +
            "            <customHeaders>\r\n" +
            "                <add name = \"Cache-Control\" value=\"max-age=8000\" />\r\n" +
            "            </customHeaders>\r\n" +
            "        </httpProtocol>\r\n" +
            "    </system.webServer>\r\n" +
            "</configuration>\r\n";

        static void Main(string[] args)
        {
            Parameters.Initialise(args, new char[] { '/', '-' }, new char[] { ':' }, false);
            try
            {
                string url = Parameters.GetOption("url", String.Empty);

                if (String.IsNullOrEmpty(url))
                    throw new ArgumentException("Invalid Parameter,", nameof(url));

                string password = "Ealfoej!ldka@renruinf23Gf";
                string winUserName = ServerUsers.CreateUserName(url);

                Console.WriteLine("Creating User {0}", winUserName);

                if (ServerUsers.CreateLocalWindowsAccount(winUserName, password, winUserName, false, false))
                {
                    //Create Folders
                    string rootFolder = "C:\\WebHosting\\Shifoo\\{0}";
                    string directoryName = String.Format(rootFolder, url);
                    Console.WriteLine("Creating Directory {0}", directoryName);
                    Directory.CreateDirectory(directoryName);

                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
                    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                    directorySecurity.AddAccessRule(new FileSystemAccessRule(winUserName,
                        FileSystemRights.FullControl,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None, AccessControlType.Allow));
                    directoryInfo.SetAccessControl(directorySecurity);

                    rootFolder += "\\{1}";
                    string[] subFolders = { "wwwroot", "logs\\W3SVC34", "data", "wwwroot\\css", "wwwroot\\js", "wwwroot\\images" };
                    int cacheFolders = 3;

                    for (int i = 0; i < subFolders.Length; i++)
                    {
                        string subFolder = subFolders[i];
                        directoryName = String.Format(rootFolder, url, subFolder);
                        Console.WriteLine("Creating Directory {0}", directoryName);
                        Directory.CreateDirectory(directoryName);

                        if (i >= cacheFolders)
                        {
                            Console.WriteLine("Adding Cache Settings to {0}", subFolder);
                            Shared.Utilities.FileWrite(directoryName + "\\web.config", CACHE_HEADER);
                        }
                    }

                    Console.WriteLine("Creating App Pool {0}", url);
                    if (!IIS.CreateApplicationPool(url, winUserName, password))
                        throw new Exception("Failed to create app pool");

                    Console.WriteLine("Creating Website");

                    if (!IIS.CreateWebsite(url, url,
                        String.Format(rootFolder, url, subFolders[0]),
                        String.Format(rootFolder, url, subFolders[1])))
                        throw new Exception("failed to create website");

                    if (!FileZilla.AddFTPSite(url, String.Format(rootFolder, url, String.Empty)))
                        throw new Exception("failed to add ftp");
                }
                else
                    Console.WriteLine("Failed to create user {0}", winUserName);
            }
            catch (ArgumentException argError)
            {
                Console.WriteLine(argError.Message.Replace("\r\n", " "));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.Message);
            }
        }
    }
}
