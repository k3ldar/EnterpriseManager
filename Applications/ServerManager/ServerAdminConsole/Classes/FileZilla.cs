using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ServerAdminConsole
{
    internal static class FileZilla
    {
        const string NEW_FTP_USER = "        <User Name=\"#URL#\">\n" +
            "        <Option Name=\"Pass\">756AE4879FCA9532AE6D538AC9A067EB01327B29E74970E7CD16BDA5F5108286D599DA73074B6517446CA2F199E6854674556753F48260F876F1294328DD5CDF</Option>\n" +
            "        <Option Name=\"Salt\">0g3^kWba\\+v&gt;Y&apos;d+/m@o?GN7\\iNuyAihZ`e%R2j$2x(Gf&lt;|&lt;kuKQX;VUQ]&quot;@e57&lt;</Option>\n" +
            "        <Option Name=\"Group\"></Option>\n" +
            "        <Option Name=\"Bypass server userlimit\">0</Option>\n" +
            "        <Option Name=\"User Limit\">0</Option>\n" +
            "        <Option Name=\"IP Limit\">0</Option>\n" +
            "        <Option Name=\"Enabled\">1</Option>\n" +
            "        <Option Name=\"Comments\"></Option>\n" +
            "        <Option Name=\"ForceSsl\">0</Option>\n" +
            "        <IpFilter>\n" +
            "            <Disallowed />\n" +
            "            <Allowed />\n" +
            "        </IpFilter>\n" +
            "        <Permissions>\n" +
            "            <Permission Dir=\"#FOLDER#\">\n" +
            "                <Option Name=\"FileRead\">1</Option>\n" +
            "                <Option Name=\"FileWrite\">1</Option>\n" +
            "                <Option Name=\"FileDelete\">1</Option>\n" +
            "                <Option Name=\"FileAppend\">1</Option>\n" +
            "                <Option Name=\"DirCreate\">1</Option>\n" +
            "                <Option Name=\"DirDelete\">1</Option>\n" +
            "                <Option Name=\"DirList\">1</Option>\n" +
            "                <Option Name=\"DirSubdirs\">1</Option>\n" +
            "                <Option Name=\"IsHome\">1</Option>\n" +
            "                <Option Name=\"AutoCreate\">0</Option>\n" +
            "            </Permission>\n" +
            "        </Permissions>\n" +
            "        <SpeedLimits DlType=\"0\" DlLimit=\"10\" ServerDlLimitBypass=\"0\" UlType=\"0\" UlLimit=\"10\" ServerUlLimitBypass=\"0\">\n" +
            "            <Download />\n" +
            "            <Upload />\n" +
            "        </SpeedLimits>\n" +
            "        </User>\n";

        internal static bool AddFTPSite(string url, string fileLocation)
        {
            string userData = NEW_FTP_USER.Replace("#URL#", url).Replace("#FOLDER#", fileLocation);
            string configFile = "C:\\Program Files (x86)\\FileZilla Server\\FileZilla Server.xml";

            if (File.Exists(configFile))
            {
                string contents = Shared.Utilities.FileRead(configFile, false);

                if (!contents.Contains(userData))
                {
                    int usersPos = contents.IndexOf("<Users>");

                    string newContents = contents.Substring(0, usersPos + 7) +
                        userData + contents.Substring(usersPos + 8);
                    Shared.Utilities.FileWrite(configFile, newContents);
                }
            }

            return (true);
        }
    }
}
