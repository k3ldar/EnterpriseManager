using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
