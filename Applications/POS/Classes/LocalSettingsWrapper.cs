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
 *  File: LocalSettingsWrapper.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using PointOfSale.Controls.Settings.LocalUser;

using SharedControls.Forms;
using POS.Base.Classes;

namespace PointOfSale.Classes
{
    internal class LocalSettingsWrapper
    {
        internal static bool LoadLocalSettings(Form parent)
        {
            bool Result = false;

            FormSettings localSettings = new FormSettings(Languages.LanguageStrings.AppPointOfSaleLocalSettinigs, String.Empty);
            try
            {
                localSettings.AddSettings += adminSettings_AddSettings;

                if (localSettings.ShowDialog(parent) == DialogResult.OK)
                {
                    Result = true;
                    AppController.SaveSettings();
                }
            }
            finally
            {
                localSettings.Dispose();
                localSettings = null;
            }

            return (Result);
        }

        private static void adminSettings_AddSettings(object sender, Shared.SettingsLoadArgs e)
        {
            FormSettings settingsform = (FormSettings)sender;

            //TreeNode parent = null;

            settingsform.LoadControlOption(Languages.LanguageStrings.AppGeneral,
                Languages.LanguageStrings.AppGeneralSettings,
                null, new GeneralSettings());

            settingsform.LoadControlOption(Languages.LanguageStrings.AppSettingsDictionary,
                Languages.LanguageStrings.AppSettingsDictionaryDescription,
                null, new DictionarySettings());

            settingsform.LoadControlOption(Languages.LanguageStrings.AppSettingsLanguage,
                Languages.LanguageStrings.AppSettingsLanguageDescription,
                null, new LanguageSettings());

            settingsform.LoadControlOption(Languages.LanguageStrings.AppSettingsPriceData,
                Languages.LanguageStrings.AppSettingsPriceDataDescription,
                null, new PriceDataSettings());

            // are there any plugins which need to add items to the settings
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.LoadUserSettings(settingsform);
            }
        }
    }
}
