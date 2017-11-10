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
 *  File: EditPlugin.cs
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

namespace PointOfSale.Forms.Other
{
    public partial class EditPluginForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private PluginModule _pluginModule;

        #endregion Private Members

        #region Constructors

        internal EditPluginForm(PluginModule pluginModule)
        {
            InitializeComponent();

            _pluginModule = pluginModule;

            LoadModule();
        }

        public EditPluginForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Static Methods

        public static bool ShowEditPluginForm(Form parent, PluginModule pluginModule)
        {
            bool Result = false;

            EditPluginForm frm = new EditPluginForm(pluginModule);
            try
            {
                Result = frm.ShowDialog(parent) == DialogResult.OK;

                if (Result)
                {
                    pluginModule.Disabled = frm.cbDisabled.Checked;
                    pluginModule.CanLoad = frm.cbCanLoad.Checked;
                }
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.EditPlugin;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppPluginEdit;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;

            lblPath.Text = LanguageStrings.AppFolder;

            cbDisabled.Text = LanguageStrings.AppPluginDisabled;
            cbCanLoad.Text = LanguageStrings.AppPluginAllowLoad;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadModule()
        {
            lblName.Text = String.Format(StringConstants.PREFIX_SUFFIX_COLON,
                LanguageStrings.AppName, _pluginModule.Name());

            lblVersion.Text = String.Format(StringConstants.PREFIX_SUFFIX_COLON,
                LanguageStrings.AppVersion, _pluginModule.Version.ProductVersion);

            txtPath.Text = System.IO.Path.GetDirectoryName(_pluginModule.PluginFile);

            cbDisabled.Checked = _pluginModule.Disabled;
            cbCanLoad.Checked = _pluginModule.CanLoad;
        }

        #endregion Private Methods
    }
}
