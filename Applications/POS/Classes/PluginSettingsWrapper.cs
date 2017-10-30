using System;
using System.Windows.Forms;

using Languages;
using Library;
using SharedControls.Forms;
using POS.Base.Classes;

namespace PointOfSale.Classes
{
    internal class PluginSettingsWrapper
    {
        internal static bool LoadPluginSettings(Form parent, bool ishomeButtons)
        {
            bool Result = false;

            if (AppController.ActiveUser.MemberLevel < MemberLevel.AdminUpdateDelete)
                throw new Exception(LanguageStrings.AppNoPermissionsAdminSettings);

            FormSettings pluginSettings = new FormSettings(LanguageStrings.AppPluginCustomise, String.Empty);
            try
            {
                pluginSettings.AddSettings += pluginSettings_AddSettings;

                if (pluginSettings.ShowDialog(parent) == DialogResult.OK)
                {
                    Result = true;
                    AppController.SaveSettings();
                }
            }
            finally
            {
                pluginSettings.Dispose();
                pluginSettings = null;
            }

            return (Result);
        }

        private static void pluginSettings_AddSettings(object sender, Shared.SettingsLoadArgs e)
        {
            FormSettings settingsform = (FormSettings)sender;

            TreeNode nodeTray = settingsform.LoadControlOption(LanguageStrings.AppPluginStatusBar,
                LanguageStrings.AppPluginStatusBarSettings,
                null, new Controls.Settings.Admin.PluginStatusBar());

            nodeTray.TreeView.SelectedNode = nodeTray;
        }
    }
}
