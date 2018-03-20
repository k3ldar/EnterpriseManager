using System;

using Microsoft.AspNetCore.Mvc;

using Library.BOL.Countries;
using Library.BOL.POSInstall;

using Website.Library.Core.Interfaces;

using Shared.Classes;


namespace Shifoo.Systems.Website.Controllers.api
{
    [Route("api/[controller]")]
    public class SBMController : Controller
    {
        #region Constants

        private const string FIREBIRD_DB_CONF_FILE = "C:\\Program Files\\Firebird\\Firebird_3_0\\databases.conf";

        #endregion Constants

        #region Private Members

        private IBaseServices _baseServices;
        private IBaseWebApplication _baseWebApplication;

        #endregion Private Members

        #region Constructors

        public SBMController(IBaseServices baseServices, IBaseWebApplication baseWebApplication)
        {
            _baseServices = baseServices ?? throw new ArgumentNullException(nameof(baseServices));
            _baseWebApplication = baseWebApplication ?? throw new ArgumentNullException(nameof(baseWebApplication));
        }

        #endregion Constructors

        #region Public API Methods

        [HttpGet]
        [Route("HelloWorld")]
        public string Get()
        {
            return ("Hello World");
        }

        [HttpGet]
        [Route("InstallValid")]
        public bool InstallValid(int storeID)
        {
            return (POSInstaller.InstallValid(storeID.ToString()));
        }

        [HttpGet]
        [Route("SystemInstall")]
        public string SystemInstall(string action, string computerName, string serverName, string email,
            string password, string installType, string path, string firstName, string lastName, string websiteUrl)
        {
            string remoteDB = String.Empty;
            string server = String.Empty;
            string storeID = String.Empty;
            string tillID = String.Empty;
            POSInstall install = null;

            try
            {
                if (password.Length < 7)
                    throw new Exception("Password must be at least 7 characters long");

                if (String.IsNullOrEmpty(email))
                    throw new Exception("Invalid email address");

                //try and login
                Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(email);

                if (user != null)
                {
                    if (user.Password.CompareTo(password) != 0)
                        throw new Exception("Invalid username/password, please try again or contact support.");
                }
                else
                {
                    if (String.IsNullOrEmpty(firstName))
                        throw new Exception("First name is not valid");

                    if (String.IsNullOrEmpty(lastName))
                        throw new Exception("Last name is not valid");

                    //UserSession session = _baseServices.GetUserSession(Request);

                    //Country country = Countries.Get(session.CountryCode);

                    int countryID = 0;

                    user = Library.BOL.Users.User.UserCreateAccount(firstName, lastName, String.Empty, email, password,
                        password, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
                        String.Empty, String.Empty, countryID, false, false, false, Library.Enums.UserRecordType.SBMGenerated,
                        DateTime.MinValue, String.Empty);
                    POSInstaller.AddUserLicences(user, ValidateString(user.Email) + ".fdb");
                }

                switch (action)
                {
                    case "Cloud":
                        install = POSInstaller.InstallCloudClient(email, password, computerName);
                        break;
                    case "Server":
                        install = POSInstaller.InstallServer(email, password, computerName);
                        break;

                    case "Client":
                        install = POSInstaller.InstallClient(email, password, computerName, serverName);
                        break;

                    case "Servers":
                        install = POSInstaller.ServerList(email, password);
                        break;

                    default:
                        throw new Exception("Invalid Install Type");
                }

                if (install == null)
                    throw new Exception("Failed to install, please contact support");

                if (!install.Allowed)
                    throw new Exception("Install not allowed");

                if (action != "Cloud")
                    remoteDB = CreateServerClientDatabase(install.RemoteDatabase, email);

                server = install.Server;
                storeID = install.StoreID.ToString();
                tillID = install.TillID.ToString();

                switch (action)
                {
                    case "Cloud":
                        remoteDB = CreateCloudClientDatabase(websiteUrl, email);
                        server = "109.228.47.69";
                        return (CreateCloudClientXML(remoteDB, server, storeID, tillID, path));

                    case "Server":
                        return (CreateServerXML(path, remoteDB, server, storeID, tillID));

                    case "Client":
                        return (CreateClientXML(path, remoteDB, server, storeID, tillID));

                    case "Servers":
                        return (install.Servers);

                    default:

                        return ("999Unknown Action Type");
                }
            }
            catch (Exception err)
            {
                return(String.Format("999{0}", err.Message));
            }

        }

        #endregion Public API Methods

        #region Private Methds

        private string CreateCloudClientXML(string remoteDB, string server, string storeID, string tillID, string path)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<SieraDelta>\r\n" +
                "  <Connection>\r\n" +
                "    <DatabaseClass>Library.DAL.FirebirdDB</DatabaseClass>\r\n" +
                "    <ConnectionString>User=SHIFOO_ERM;Password={0};Database={REMOTE_DATABASE};" +
                "DataSource={SERVER};Charset=UTF8;Port=3060;Dialect=3;Pooling=true;Connection Lifetime=0;Packet Size=8192</ConnectionString>\r\n" +
                "    <Password>R{lt+){</Password>\r\n" +
                "  </Connection>\r\n" +
                "  <Options>\r\n" +
                "    <Replicate>False</Replicate>\r\n" +
                "    <StoreID>{STORE}</StoreID>\r\n" +
                "    <TillID>{TILL}</TillID>\r\n" +
                "  </Options>\r\n" +
                "  <Application>\r\n" +
                "    <MainApplication>{PATH}\\Shifoo.SBM.exe</MainApplication>\r\n" +
                "    <VersionInfo>http://www.sieradelta.com/Download/SBM/SBMVersion.xml</VersionInfo>\r\n" +
                "    <Adobe>C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader\\AcroRd32.exe</Adobe>\r\n" +
                "  </Application>\r\n" +
                "</SieraDelta>\r\n";

            xml = xml.Replace("{REMOTE_DATABASE}", remoteDB);
            xml = xml.Replace("{SERVER}", server);
            xml = xml.Replace("{PATH}", path);
            xml = xml.Replace("{STORE}", storeID);
            xml = xml.Replace("{TILL}", tillID);
            return (xml);
        }

        private string CreateClientXML(string path, string remoteDB, string server, string storeID, string tillID)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<SieraDelta>\r\n" +
                "  <Connection>\r\n" +
                "    <DatabaseClass>Library.DAL.FirebirdDB</DatabaseClass>\r\n" +
                "    <ConnectionString>User=SHIFOO_ERM;Password={0};Database={DBPATH}\\Databases\\SBMDatabase.FDB;" +
                "DataSource={SERVER};Charset=UTF8;Port=7091;Dialect=3;Pooling=true;Connection Lifetime=0;Packet Size=8192</ConnectionString>\r\n" +
                "    <Password>R{lt+){</Password>\r\n" +
                "  </Connection>\r\n" +
                "  <Options>\r\n" +
                "    <Replicate>False</Replicate>\r\n" +
                "    <StoreID>{STORE}</StoreID>\r\n" +
                "    <TillID>{TILL}</TillID>\r\n" +
                "  </Options>\r\n" +
                "  <Application>\r\n" +
                "    <MainApplication>{PATH}\\Shifoo.SBM.exe</MainApplication>\r\n" +
                "    <VersionInfo>http://www.SieraDelta.com/Download/SBM/SBMVersion.xml</VersionInfo>\r\n" +
                "    <Adobe>C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader\\AcroRd32.exe</Adobe>\r\n" +
                "  </Application>\r\n" +
                "</SieraDelta>\r\n";

            xml = xml.Replace("{DBPATH}", path.Replace("\\ERM", String.Empty));
            xml = xml.Replace("{PATH}", path);
            xml = xml.Replace("{REMOTE_DATABASE}", remoteDB);
            xml = xml.Replace("{SERVER}", server);
            xml = xml.Replace("{STORE}", storeID);
            xml = xml.Replace("{TILL}", tillID);
            return (xml);
        }

        private string CreateServerXML(string path, string remoteDB, string server, string storeID, string tillID)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<SieraDelta>\r\n" +
                "  <Connection>\r\n" +
                "    <DatabaseClass>Library.DAL.FirebirdDB</DatabaseClass>\r\n" +
                "    <ConnectionString>User=SHIFOO_ERM;Password={0};Database={DBPATH}\\Databases\\SBMDatabase.FDB;DataSource={SERVER};Charset=UTF8;Port=7095;Dialect=3;Pooling=true;Connection Lifetime=0;Packet Size=8192</ConnectionString>\r\n" +
                "    <ReplicationString>User=REPLICATION;Password={0};Database={REMOTE_DATABASE};DataSource=firebird.sieradelta.com;Charset=UTF8;Port=3050;Dialect=3;Pooling=true;Connection Lifetime=0;Packet Size=8192</ReplicationString>\r\n" +
                "    <Password>R{lt+){</Password>\r\n" +
                "    <ReplicationPassword>y{hn*-#</ReplicationPassword>\r\n" +
                "  </Connection>\r\n" +
                "  <Options>\r\n" +
                "    <Replicate>True</Replicate>\r\n" +
                "    <StoreID>{STORE}</StoreID>\r\n" +
                "    <TillID>{TILL}</TillID>\r\n" +
                "  </Options>\r\n" +
                "  <Application>\r\n" +
                "    <MainApplication>{PATH}\\Shifoo.SBM.exe</MainApplication>\r\n" +
                "    <VersionInfo>http://www.heavenskincare.com/Download/SBM/SBMVersion.xml</VersionInfo>\r\n" +
                "  </Application>\r\n" +
                "</SieraDelta>\r\n";

            xml = xml.Replace("{DBPATH}", path.Replace("\\ERM", String.Empty));
            xml = xml.Replace("{PATH}", path);
            xml = xml.Replace("{REMOTE_DATABASE}", remoteDB);
            xml = xml.Replace("{SERVER}", server);
            xml = xml.Replace("{STORE}", storeID);
            xml = xml.Replace("{TILL}", tillID);
            return (xml);
        }

        private string ValidateString(string s)
        {
            string AcceptableChars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ.-_";

            string Result = String.Empty;

            foreach (char c in s)
            {
                if (AcceptableChars.Contains(c.ToString()))
                    Result += c;
                else
                    Result += "_";
            }

            return (Result);
        }

        private string CreateServerClientDatabase(string databaseName, string email)
        {
            string databaseNamePath = String.Empty;
            string path = "c:\\databases\\";
            string Result = String.Empty;

            path += Shared.Utilities.AddTrailingBackSlash(email.Replace("@", "_"));
            Result = databaseName;
            databaseNamePath = path + Result;

            databaseNamePath += ".fdb";

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            if (!System.IO.File.Exists(databaseNamePath))
                System.IO.File.Copy("c:\\databases\\SHIFOO.STORE.1.FDB", databaseNamePath);

            //Append link to database.conf
            string dbConf = Shared.Utilities.FileRead(FIREBIRD_DB_CONF_FILE, true);
            dbConf += String.Format("\r\n\r\n{0} = {1}\r\n" +
                "{\r\n\tDefaultDbCachePages = 50000\r\n\tDatabaseGrowthIncrement = 128M\r\n" +
                "\tFileSystemCacheThreshold = 64K\r\n\tAuthClient = Srp\r\n" +
                "\tUserManager = Srp\r\n\tDeadlockTimeout = 10\r\n" +
                "\tMaxUnflushedWriteTime = 5\r\n\tLockMemSize = 9M\r\n" +
                "\tLockHashSlots = 30011\r\n\tEventMemSize = 64K\r\n" +
                "\tGCPolicy = combined\r\n}\r\n", Result, databaseNamePath);
            Shared.Utilities.FileWrite(FIREBIRD_DB_CONF_FILE, dbConf);

            return (Result);
        }

        private string CreateCloudClientDatabase(string website, string email)
        {
            string databaseNamePath = String.Empty;
            string path = "c:\\databases\\";
            string Result = String.Empty;

            if (!String.IsNullOrEmpty(website))
            {
                Uri web = new Uri(website);
                path += Shared.Utilities.AddTrailingBackSlash(web.Authority.Replace("www.", String.Empty));
                Result = web.Authority.Replace("www.", String.Empty);
                databaseNamePath = path + Result;
            }
            else
            {
                path += Shared.Utilities.AddTrailingBackSlash(email);
                Result = email.Replace("@", "_");
                databaseNamePath = path + Result;
            }

            databaseNamePath += ".fdb";

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            if (!System.IO.File.Exists(databaseNamePath))
                System.IO.File.Copy("c:\\databases\\SHIFOO.STORE.1.FDB", databaseNamePath);

            //Append link to database.conf
            string dbConf = Shared.Utilities.FileRead(FIREBIRD_DB_CONF_FILE, true);

            if (!dbConf.Contains($"{Result} = {databaseNamePath}"))
            {
                dbConf += $"\r\n\r\n{Result} = {databaseNamePath}\r\n" +
                    "{\r\n\tDefaultDbCachePages = 50000\r\n\tDatabaseGrowthIncrement = 128M\r\n" +
                    "\tFileSystemCacheThreshold = 64K\r\n\tAuthClient = Srp\r\n" +
                    "\tUserManager = Srp\r\n\tDeadlockTimeout = 10\r\n" +
                    "\tMaxUnflushedWriteTime = 5\r\n\tLockMemSize = 9M\r\n" +
                    "\tLockHashSlots = 30011\r\n\tEventMemSize = 64K\r\n" +
                    "\tGCPolicy = combined\r\n}\r\n";
                Shared.Utilities.FileWrite(FIREBIRD_DB_CONF_FILE, dbConf);
            }

            return (Result);
        }

        #endregion Private Methods
    }
}
