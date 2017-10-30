using System;
using System.Collections.Generic;
using System.Text;

using SieraDelta.Languages;
using SieraDelta.Shared;
using SieraDelta.POS.Classes;

namespace Heavenskincare.PointOfSale.Classes
{
    internal static class ConfigurationSettings
    {
        private static Dictionary<string, string> _configValues = new Dictionary<string, string>();

        internal static string Value(string name)
        {
            string Result = String.Empty;

            if (_configValues.ContainsKey(name))
                Result = _configValues[name];

            return (Result);
        }

        internal static void LoadStaticConfig()
        {
            _configValues.Clear();

            string configFile = Utilities.CurrentPath(true) + StringConstants.FILE_SYSTEM_CONFIG;

            if (System.IO.File.Exists(configFile))
            {
                string contents = Utilities.FileEncrypedRead(configFile, String.Empty);
                string[] lines = contents.Split(StringConstants.SYMBOL_RETURN.ToCharArray()[0]);

                foreach (string line in lines)
                {
                    string[] data = line.Split(StringConstants.SYMBOL_EQUALS.ToCharArray()[0]);
                    _configValues.Add(data[0], data[1]);
                }
            }

            //has config got everything we need?
            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_IP))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_IP, StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_IP_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_PORT))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_PORT, StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_PORT_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_USER))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_USER, StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_USER_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD, StringConstants.SYSTEM_CONFIG_ERROR_CLIENT_PASSWORD_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT, StringConstants.SYSTEM_CONFIG_EMAIL_NAME_RECIPIENT_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT, StringConstants.SYSTEM_CONFIG_EMAIL_ADDRESS_RECIPIENT_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_EMAIL_NAME_SENDER))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_EMAIL_NAME_SENDER, StringConstants.SYSTEM_CONFIG_EMAIL_NAME_SENDER_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER, StringConstants.SYSTEM_CONFIG_EMAIL_ADDRESS_SENDER_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_URL_MARKETING))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_URL_MARKETING, StringConstants.SYSTEM_CONFIG_URL_MARKETING_DEFAULT);

            if (!_configValues.ContainsKey(StringConstants.SYSTEM_CONFIG_URL_HELP))
                _configValues.Add(StringConstants.SYSTEM_CONFIG_URL_HELP, StringConstants.SYSTEM_CONFIG_URL_HELP_DEFAULT);
        }
    }
}
