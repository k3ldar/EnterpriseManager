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
 *  File: PluginSettingsWrapper.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
