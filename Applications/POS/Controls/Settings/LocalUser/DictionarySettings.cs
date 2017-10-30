using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using Languages;

using PointOfSale.Classes;
using POS.Base.Classes;

namespace PointOfSale.Controls.Settings.LocalUser
{
    public partial class DictionarySettings : SharedControls.BaseSettings
    {
        public DictionarySettings()
        {
            InitializeComponent();

            LoadDictionaries();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDefaultLanguage.Text = LanguageStrings.AppSettingsDefaultLanguage;
        }

        public override bool SettingsSave()
        {
            bool Result = false;

            if (cmbDictionary.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppSettingsDictionary, LanguageStrings.AppSettingsDictionaryDefault);
                return (Result);
            }

            AppController.LocalSettings.CustomDictionary = System.IO.Path.GetFileName((string)cmbDictionary.Items[cmbDictionary.SelectedIndex]);

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
        }

        #endregion Overridden Methods

        #region Private Methods

        /// <summary>
        /// Loads dictionary settings
        /// </summary>
        private void LoadDictionaries()
        {
            cmbDictionary.Items.Clear();

            string dictionaryPath = String.Format(StringConstants.FOLDER_DICTIONARY_PATH, 
                Shared.Utilities.CurrentPath());

            string[] dictionaries = System.IO.Directory.GetFiles(dictionaryPath, 
                StringConstants.FILE_EXTENSION_DICTIONARY_SEARCH);
            int idx;

            foreach (string dictionary in dictionaries)
            {
                idx = cmbDictionary.Items.Add(dictionary);

                if (dictionary.EndsWith(AppController.LocalSettings.CustomDictionary))
                {
                    cmbDictionary.SelectedIndex = idx;
                }
            }
        }

        private void cmbDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCultureName.Text = CultureInfo.CreateSpecificCulture(
                System.IO.Path.GetFileNameWithoutExtension(
                (string)cmbDictionary.Items[cmbDictionary.SelectedIndex]).Replace(
                StringConstants.SYMBOL_UNDERSCORE, StringConstants.SYMBOL_HYPHEN)).DisplayName;
        }

        private void cmbDictionary_Format(object sender, ListControlConvertEventArgs e)
        {
            string dictionary = e.ListItem.ToString();
            string display = System.IO.Path.GetFileNameWithoutExtension(dictionary).Replace(StringConstants.SYMBOL_UNDERSCORE,StringConstants.SYMBOL_HYPHEN);
            e.Value = display;
        }

        #endregion Private Methods
    }
}
