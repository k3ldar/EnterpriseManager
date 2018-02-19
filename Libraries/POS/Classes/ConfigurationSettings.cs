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
 *  File: ConfigurationSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

using Shared;

namespace POS.Base.Classes
{
    public static class ConfigurationSettings
    {
        #region String Constants

        private const string ERROR_CONFIG_NOT_FOUND = "Configuration Value not Found";

        private const string SYSTEM_CONFIG_ERROR_CLIENT_IP_DEFAULT = "70.38.12.38";
        private const string SYSTEM_CONFIG_ERROR_CLIENT_PORT_DEFAULT = "37789";
        private const string SYSTEM_CONFIG_ERROR_CLIENT_USER_DEFAULT = "Shifoo";
        private const string SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD_DEFAULT = "Shifoo_!3B";
        private const string SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT_DEFAULT = "Simon Carter";
        private const string SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT_DEFAULT = "errors@sieradelta.com";
        private const string SYSTEM_CONFIG_EMAIL_NAME_SENDER_DEFAULT = "no-reply";
        private const string SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER_DEFAULT = "noreply@sieradelta.com";
        private const string SYSTEM_CONFIG_TITLE_DEFAULT = "Shifoo Small Business Manager";
        private const string SYSTEM_CONFIG_URL_MARKETING_DEFAULT = "http://www.sieradelta.com/Download/Marketing/Settings.xml";
        private const string SYSTEM_CONFIG_URL_MARKETING_TEMPLATE_DEFAULT = "http://www.sieradelta.com/images/emails/templates.xml";
        private const string SYSTEM_CONFIG_URL_MARKETING_TEMPLATE_COLOR = "http://www.sieradelta.com/images/emails/imagestyle.xml";
        private const string SYSTEM_CONFIG_URL_HELP_DEFAULT = "http://www.sieradelta.com/helpdesk/FAQ/FAQ.aspx?GroupID=5";
        private const string SYSTEM_CONFIG_PLUGIN_UPDATE_URL_DEFAULT = "http://www.sieradelta.com/Members/Products/PosModuleUpdater.aspx";
#if LOCALHOST && DEBUG
        private const string SYSTEM_CONFIG_UPDATE_URL_DEFAULT = "http://localhost:49999/Members/Products/POSInstallerUpdater.aspx";
        private const string SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK_DEFAULT = "http://localhost:49999/Members/Stock/ReOrder.aspx";
#else
        private const string SYSTEM_CONFIG_UPDATE_URL_DEFAULT = "http://www.sieradelta.com/Members/Products/POSInstallerUpdater.aspx";
        private const string SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK_DEFAULT = "https://www.sieradelta.com/Members/Stock/ReOrder.aspx";
#endif
        private const string SYSTEM_CONFIG_BASE_WEB_POS_VERSION_DEFAULT = "http://www.sieradelta.com/download/pos/PosVersion.xml";
        private const string SYSTEM_CONFIG_BASE_WEB_SERVICE_UPDATE_DEFAULT = "http://www.sieradelta.com/download/pos/PosService.xml";

        private const string SYSTEM_CONFIG_BASE_SAVE_FORMAT = "{0}{1}{2}{3}";

        public const string SYSTEM_CONFIG_ERROR_CLIENT_IP = "ERROR_CLIENT_IP";
        public const string SYSTEM_CONFIG_ERROR_CLIENT_PORT = "ERROR_CLIENT_PORT";
        public const string SYSTEM_CONFIG_ERROR_CLIENT_USER = "ERROR_CLIENT_USER";
        public const string SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD = "ERROR_CLIENT_PASSWORD";
        public const string SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT = "EMAIL_NAME_RECIPIENT";
        public const string SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT = "EMAIL_ADDRESS_RECIPIENT";
        public const string SYSTEM_CONFIG_EMAIL_NAME_SENDER = "EMAIL_NAME_SENDER";
        public const string SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER = "EMAIL_ADDRESS_SENDER";
        public const string SYSTEM_CONFIG_URL_MARKETING = "URL_MARKETING";
        public const string SYSTEM_CONFIG_URL_MARKETING_TEMPLATES = "URL_MARKETING_TEMPLATES";
        public const string SYSTEM_CONFIG_URL_MARKETING_TEXT_COLOR = "URL_MARKETING_COLORS";
        public const string SYSTEM_CONFIG_URL_HELP = "URL_HELP";
        public const string SYSTEM_CONFIG_TITLE = "APPLICATION_TITLE";
        public const string SYSTEM_CONFIG_PLUGIN_UPDATE_URL = "PLUGIN_UPDATE_URL";
        public const string SYSTEM_CONFIG_INSTALLER_UPDATE_URL = "POS_INSTALLER_UPDATE_URL";
        public const string SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK = "BASE_WEB_SITE_STOCK_REORDER_URL";
        public const string SYSTEM_CONFIG_BASE_WEB_POS_VERSION = "BASE_WEB_SITE_POS_VERSION";
        public const string SYSTEM_CONFIG_BASE_WEB_SERVICE_UPDATE = "BASE_WEB_SITE_SERVICE_UPDATE";

        #endregion String Constants

        #region Private Members

        private static Dictionary<string, string> _configValues = new Dictionary<string, string>();

        private static List<string> _configNames = new List<string>();

        #endregion Private Members

        #region Public Static Members

        public static string Value(string name)
        {
#if LOCALHOST && DEBUG
            if (name == SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK)
            {
                return (SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK_DEFAULT);
            }
            else
            {
                if (_configValues.ContainsKey(name))
                    return (_configValues[name]);
                else
                    throw new Exception(ERROR_CONFIG_NOT_FOUND);
            }
#else
            if (_configValues.ContainsKey(name))
                return (_configValues[name]);
            else
                throw new Exception(ERROR_CONFIG_NOT_FOUND);
#endif
        }

        public static string GetConfigValue(string name)
        {
            return (_configValues[name]);
        }

        public static bool SetConfigValue(string name, string value)
        {
            _configValues[name] = value;

            SaveConfiguration();

            return (value == GetConfigValue(name));
        }

        public static string GetConfigName(int index)
        {
            return (_configNames[index]);
        }

        public static int GetConfigCount()
        {
            return (_configNames.Count);
        }

        public static void LoadStaticConfig()
        {
            _configValues.Clear();

            string configFile = Utilities.CurrentPath(true) + StringConstants.FILE_SYSTEM_CONFIG;

            if (System.IO.File.Exists(configFile))
            {
                string contents = Utilities.FileEncryptedRead(configFile, String.Empty);
                string[] lines = contents.Split(StringConstants.SYMBOL_RETURN.ToCharArray()[0]);

                foreach (string line in lines)
                {
                    if (String.IsNullOrEmpty(line))
                        continue;

                    string[] data = line.Split(StringConstants.SYMBOL_EQUALS.ToCharArray()[0]);
                    _configValues.Add(data[0], data[1]);
                }
            }

            int currentCount = _configValues.Count;

            //has config got everything we need?
            if (!_configValues.ContainsKey(SYSTEM_CONFIG_TITLE))
                _configValues.Add(SYSTEM_CONFIG_TITLE, SYSTEM_CONFIG_TITLE_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_INSTALLER_UPDATE_URL))
                _configValues.Add(SYSTEM_CONFIG_INSTALLER_UPDATE_URL, SYSTEM_CONFIG_UPDATE_URL_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_PLUGIN_UPDATE_URL))
                _configValues.Add(SYSTEM_CONFIG_PLUGIN_UPDATE_URL, SYSTEM_CONFIG_PLUGIN_UPDATE_URL_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_ERROR_CLIENT_IP))
                _configValues.Add(SYSTEM_CONFIG_ERROR_CLIENT_IP, SYSTEM_CONFIG_ERROR_CLIENT_IP_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_ERROR_CLIENT_PORT))
                _configValues.Add(SYSTEM_CONFIG_ERROR_CLIENT_PORT, SYSTEM_CONFIG_ERROR_CLIENT_PORT_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_ERROR_CLIENT_USER))
                _configValues.Add(SYSTEM_CONFIG_ERROR_CLIENT_USER, SYSTEM_CONFIG_ERROR_CLIENT_USER_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD))
                _configValues.Add(SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD, SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT))
                _configValues.Add(SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT, SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT))
                _configValues.Add(SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT, SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_EMAIL_NAME_SENDER))
                _configValues.Add(SYSTEM_CONFIG_EMAIL_NAME_SENDER, SYSTEM_CONFIG_EMAIL_NAME_SENDER_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER))
                _configValues.Add(SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER, SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_URL_MARKETING))
                _configValues.Add(SYSTEM_CONFIG_URL_MARKETING, SYSTEM_CONFIG_URL_MARKETING_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_URL_MARKETING_TEMPLATES))
                _configValues.Add(SYSTEM_CONFIG_URL_MARKETING_TEMPLATES, SYSTEM_CONFIG_URL_MARKETING_TEMPLATE_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_URL_MARKETING_TEXT_COLOR))
                _configValues.Add(SYSTEM_CONFIG_URL_MARKETING_TEXT_COLOR, SYSTEM_CONFIG_URL_MARKETING_TEMPLATE_COLOR);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_URL_HELP))
                _configValues.Add(SYSTEM_CONFIG_URL_HELP, SYSTEM_CONFIG_URL_HELP_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK))
                _configValues.Add(SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK, SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK_DEFAULT);
            
            if (!_configValues.ContainsKey(SYSTEM_CONFIG_BASE_WEB_POS_VERSION))
                _configValues.Add(SYSTEM_CONFIG_BASE_WEB_POS_VERSION, SYSTEM_CONFIG_BASE_WEB_POS_VERSION_DEFAULT);

            if (!_configValues.ContainsKey(SYSTEM_CONFIG_BASE_WEB_SERVICE_UPDATE))
                _configValues.Add(SYSTEM_CONFIG_BASE_WEB_SERVICE_UPDATE, SYSTEM_CONFIG_BASE_WEB_SERVICE_UPDATE_DEFAULT);

            if (currentCount != _configValues.Count)
            {
                SaveConfiguration();
            }

            _configNames.Clear();

            foreach (KeyValuePair<string, string> name in _configValues)
            {
                _configNames.Add(name.Key);
            }
        }

        #endregion Public Static Members

        #region Private Static Methods

        private static void SaveConfiguration()
        {
            string configFile = Utilities.CurrentPath(true) + StringConstants.FILE_SYSTEM_CONFIG;

            // save the settings
            string currentSettings = String.Empty;

            foreach (KeyValuePair<string, string> kvp in _configValues)
            {
                currentSettings += String.Format(SYSTEM_CONFIG_BASE_SAVE_FORMAT,
                    kvp.Key, StringConstants.SYMBOL_EQUALS, kvp.Value, StringConstants.SYMBOL_RETURN);
            }

            Utilities.FileEncryptedWrite(configFile, currentSettings, String.Empty);
        }

        #endregion Private Static Methods
    }
}
