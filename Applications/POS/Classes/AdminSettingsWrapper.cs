using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using PointOfSale.Controls.Settings.Admin;

using Languages;
using Library;
using SharedControls.Forms;
using POS.Base.Classes;

namespace PointOfSale.Classes
{
    internal class AdminSettingsWrapper
    {
        internal static bool LoadAdminSettings(Form parent)
        {
            bool Result = false;

            if (AppController.ActiveUser.MemberLevel < MemberLevel.AdminUpdateDelete)
                throw new Exception(LanguageStrings.AppNoPermissionsAdminSettings);

            if (parent != null)
            {
                parent.Cursor = Cursors.WaitCursor;
            }

            FormSettings adminSettings = new FormSettings(LanguageStrings.AppPointOfSaleAdministration, String.Empty);
            try
            {
                adminSettings.AddSettings += adminSettings_AddSettings;

                if (adminSettings.ShowDialog(parent) == DialogResult.OK)
                {
                    Result = true;
                    AppController.SaveSettings();
                }
            }
            finally
            {
                adminSettings.Dispose();
                adminSettings = null;

                if (parent != null)
                {
                    parent.Cursor = Cursors.Arrow;
                }
            }
            return (Result);
        }
      
        private static void adminSettings_AddSettings(object sender, Shared.SettingsLoadArgs e)
        {
            FormSettings settingsform = (FormSettings)sender;

            TreeNode parent = null;

            parent = settingsform.LoadControlOption(LanguageStrings.AppLoginLogout, 
                LanguageStrings.AppLoginLogoutSettings, 
                null, new LogInOut());

            settingsform.LoadControlOption(LanguageStrings.AppAutomaticLogin, 
                LanguageStrings.AppAutomaticLoginSettings, 
                parent, new AutoLogin());

            parent = settingsform.LoadControlOption(LanguageStrings.AppPluginSettings,
                LanguageStrings.AppPluginAdministrationSettings,
                null, new Controls.Settings.Admin.Plugins());

            settingsform.LoadControlOption(LanguageStrings.AppPluginStatusBar,
                LanguageStrings.AppPluginStatusBarSettings,
                parent, new Controls.Settings.Admin.PluginStatusBar());

            // are there any plugins which need to add items to the settings
            foreach (POS.Base.Plugins.BasePlugin pluginModule in PluginManager.PluginsGet())
            {
                pluginModule.LoadAdministrationSettings(settingsform);
            }

        }
    }
}
