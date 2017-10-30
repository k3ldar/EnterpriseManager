using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Heavenskincare.Website.Library.Classes;
using Heavenskincare.Library.BOL.POSInstall;

namespace Heavenskincare.WebsiteTemplate.Website.Staff.Installer.POS
{
    public partial class PosValidation : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = GetFormValue("Action");
            string computerName = GetFormValue("ComputerName");
            string serverName = GetFormValue("ServerName");
            string distributor = GetFormValue("Distributor");
            string password = GetFormValue("Password");
            string installType = GetFormValue("InstallType");
            string path = GetFormValue("Path");

            //
            // if error return 999Error Message
            //

            string remoteDB = String.Empty;
            string server = String.Empty;
            string storeID = String.Empty;
            string tillID = String.Empty;
            POSInstall install = null;

            try
            {
                //try and login
                if (Heavenskincare.Library.BOL.Users.User.UserGet(distributor, password) == null)
                    throw new Exception("Invalid username/password, please try again or contact support.");


                switch (action)
                {
                    case "Server":
                        install = POSInstaller.InstallServer(distributor, password, computerName);
                        break;

                    case "Client":
                        install = POSInstaller.InstallClient(distributor, password, computerName, serverName);
                        break;

                    case "Servers":
                        install = POSInstaller.ServerList(distributor, password);
                        break;

                    default:
                        throw new Exception("Invalid Install Type");
                }

                if (install == null)
                    throw new Exception("Failed to install, please contact support");

                if (!install.Allowed)
                    throw new Exception("Install not allowed");

                remoteDB = install.RemoteDatabase;
                server = install.Server;
                storeID = install.StoreID.ToString();
                tillID = install.TillID.ToString();

                switch (action)
                {
                    case "Server":
                        Response.Write(CreateServerXML(path, remoteDB, server, storeID, tillID));
                        break;

                    case "Client":
                        Response.Write(CreateClientXML(path, remoteDB, server, storeID, tillID));
                        break;

                    case "Servers":
                        Response.Write(install.Servers);
                        break;

                    default:

                        Response.Write("999Unknown Action Type");

                        break;
                }
            }
            catch (Exception err)
            {
                Response.Write(String.Format("999{0}", err.Message));
            }

            Response.End();
        }

        private string CreateClientXML(string path, string remoteDB, string server, string storeID, string tillID)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<Heavenskincare>\r\n" +
                "  <Connection>\r\n" +
                "    <DatabaseClass>Heavenskincare.Library.DAL.FirebirdDB</DatabaseClass>\r\n" +
                "    <ConnectionString>User=HEAVEN_SALON;Password={0};Database={PATH}\\Database\\POSDATABASE.FDB;DataSource={SERVER};Charset=UTF8;Port=8095;Dialect=3;Pooling=true;Connection Lifetime=0;Packet Size=8192</ConnectionString>\r\n" +
                "    <Password>R{lt+){</Password>\r\n" +
                "  </Connection>\r\n" +
                "  <Options>\r\n" +
                "    <Replicate>False</Replicate>\r\n" +
                "    <StoreID>{STORE}</StoreID>\r\n" +
                "    <TillID>{TILL}</TillID>\r\n" +
                "  </Options>\r\n" +
                "  <Application>\r\n" +
                "    <MainApplication>{PATH}\\POS\\Heavenskincare.PointOfSale.exe</MainApplication>\r\n" +
                "    <VersionInfo>http://www.heavenskincare.com/Download/POS/POSVersion.xml</VersionInfo>\r\n" +
                "    <Adobe>C:\\Program Files (x86)\\Adobe\\Reader 11.0\\Reader\\AcroRd32.exe</Adobe>\r\n" +
                "  </Application>\r\n" +
                "</Heavenskincare>\r\n";

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
                "<Heavenskincare>\r\n" +
                "  <Connection>\r\n" +
                "    <DatabaseClass>Heavenskincare.Library.DAL.FirebirdDB</DatabaseClass>\r\n" +
                "    <ConnectionString>User=HEAVEN_SALON;Password={0};Database={PATH}\\Database\\POSDATABASE.FDB;DataSource={SERVER};Charset=UTF8;Port=8095;Dialect=3;Pooling=true;Connection Lifetime=0;Packet Size=8192</ConnectionString>\r\n" +
                "    <ReplicationString>User=REPLICATION;Password={0};Database={REMOTE_DATABASE};DataSource=firebird.heavenskincare.com;Charset=UTF8;Port=3050;Dialect=3;Pooling=true;Connection Lifetime=0;Packet Size=8192</ReplicationString>\r\n" +
                "    <Password>R{lt+){</Password>\r\n" +
                "    <ReplicationPassword>y{hn*-#</ReplicationPassword>\r\n" +
                "  </Connection>\r\n" +
                "  <Options>\r\n" +
                "    <Replicate>True</Replicate>\r\n" +
                "    <StoreID>{STORE}</StoreID>\r\n" +
                "    <TillID>{TILL}</TillID>\r\n" +
                "  </Options>\r\n" +
                "  <Application>\r\n" +
                "    <MainApplication>{PATH}\\POS\\Heavenskincare.PointOfSale.exe</MainApplication>\r\n" +
                "    <VersionInfo>http://www.heavenskincare.com/Download/POS/POSVersion.xml</VersionInfo>\r\n" +
                "  </Application>\r\n" +
                "</Heavenskincare>\r\n";

            xml = xml.Replace("{PATH}", path);
            xml = xml.Replace("{REMOTE_DATABASE}", remoteDB);
            xml = xml.Replace("{SERVER}", server);
            xml = xml.Replace("{STORE}", storeID);
            xml = xml.Replace("{TILL}", tillID);
            return (xml);
        }

    }
}