using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

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
