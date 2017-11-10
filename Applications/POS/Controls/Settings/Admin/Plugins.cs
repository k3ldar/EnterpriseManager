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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Plugins.cs
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
using POS.Base.Classes;

namespace PointOfSale.Controls.Settings.Admin
{
    public partial class Plugins : SharedControls.BaseSettings
    {
        public Plugins()
        {
            InitializeComponent();
            LoadPlugins();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbPromptBeforeLoadNew.Text = LanguageStrings.AppPluginPromptBeforeLoadNew;
            cbAutoLoadNewModules.Text = LanguageStrings.AppPluginAutoLoadNewModules;

            lvPluginsColumnName.Text = LanguageStrings.AppName;
            lvPluginsColumnDisabled.Text = LanguageStrings.AppDisabled;
            lvPluginsColumnLoad.Text = LanguageStrings.AppLoad;
            lvPluginsColumnVersion.Text = LanguageStrings.AppVersion;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.PluginsPromptToLoad = false;// cbPromptBeforeLoadNew.Checked;
            AppController.LocalSettings.PluginsLoadNewModules = true;// cbAutoLoadNewModules.Checked;

            PluginManager.SavePluginConfiguration();

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbAutoLoadNewModules.Checked = AppController.LocalSettings.PluginsLoadNewModules;
            cbPromptBeforeLoadNew.Checked = AppController.LocalSettings.PluginsPromptToLoad;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadPlugins()
        {
            lvPluginModules.Items.Clear();

            foreach (PluginModule module in PluginManager.PluginModulesGet())
            {
                if (module.PluginModuleInstance == null || 
                    module.PluginModuleInstance.Version() != POS.Base.Plugins.PluginVersion.VersionInternal)
                {
                    ListViewItem lviNew = lvPluginModules.Items.Add(module.Name());
                    lviNew.SubItems.Add(module.CanLoad.ToString());
                    lviNew.SubItems.Add(module.Disabled.ToString());
                    lviNew.SubItems.Add(module.Version.ProductVersion);
                    lviNew.Tag = module;
                }
            }
        }

        private void lvPluginModules_DoubleClick(object sender, EventArgs e)
        {
            if (lvPluginModules.SelectedItems.Count > 0)
            {
                PluginModule selModule = (PluginModule)lvPluginModules.SelectedItems[0].Tag;

                if (Forms.Other.EditPluginForm.ShowEditPluginForm(ParentForm, selModule))
                {
                    lvPluginModules.SelectedItems[0].SubItems[1].Text = selModule.CanLoad.ToString();
                    lvPluginModules.SelectedItems[0].SubItems[2].Text = selModule.Disabled.ToString();
                }
            }
        }

        #endregion Private Methods
    }
}
