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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: DictionarySettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;
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
