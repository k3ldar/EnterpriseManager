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
 *  File: ProductEditText.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Windows.Forms;

using SharedBase.BOL.Products;
using SharedBase.BOL.Countries;
using SharedBase.BOL.CustomWebPages;

using SharedBase;
using POS.Base.Classes;

using SharedControls;

namespace POS.Administration.Controls
{
    public partial class ProductEditText : SharedControls.BaseControl
    {
        #region Private Members

        private Int64 _productID;

        private string _defaultText;

        CustomPage _page = null;

        #endregion Private Members

        #region Constructors

        public ProductEditText()
        {
            InitializeComponent();

            if (AppController.ApplicationRunning)
            {
                LoadLocalizableCountries();

                if (!PluginManager.WebsitesEnabled())
                {
                    btnSaveTranslation.Enabled = false;
                    cbLanguageActive.Enabled = false;
                    cmbLanguage.Enabled = false;
                    lblLanguage.Enabled = false;
                }
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Text From Text Box
        /// </summary>
        public override string Text
        {
            get
            {
                return (txtDescription.Text);
            }

            set
            {
                txtDescription.Text = value;
                _defaultText = value;
            }
        }

        public TextBox TextBox
        {
            get
            {
                return (txtDescription);
            }
        }

        /// <summary>
        /// Maximum text length
        /// </summary>
        public int MaximumLength
        {
            get
            {
                return (txtDescription.MaxLength);
            }

            set
            {
                txtDescription.MaxLength = value;
            }
        }

        /// <summary>
        /// Associated Product
        /// </summary>
        public Product Product
        {
            set
            {
                _productID = value.ID;
            }
        }

        /// <summary>
        /// PageType
        /// </summary>
        public CustomPagesType PageType { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnSaveTranslation.Text = Languages.LanguageStrings.AppSaveTranslation;
            cbLanguageActive.Text = Languages.LanguageStrings.AppLanguageActive;
            lblLanguage.Text = Languages.LanguageStrings.AppLanguage;

        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadLocalizableCountries()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            Countries localizableCountries = Countries.Get();

            foreach (Country country in localizableCountries)
            {
                if (country.CanLocalize)
                    cmbLanguage.Items.Add(country);
                else if (country.ID == 0)
                    cmbLanguage.Items.Insert(0, country);

            }

            cmbLanguage.SelectedIndex = 0;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblSize.Text = String.Format(StringConstants.TEXT_LENGTH_DESCRIPTION, txtDescription.Text.Length, 
                txtDescription.MaxLength, Languages.LanguageStrings.AppCharacters);
            lblParagraphs.Text = String.Format(Languages.LanguageStrings.AppParapgraphs, txtDescription.ParagraphCount());
            lblSentences.Text = String.Format(Languages.LanguageStrings.AppSentences, txtDescription.SentenceCount());
            lblWordCount.Text = String.Format(Languages.LanguageStrings.AppWords, txtDescription.WordCount());

            if (cmbLanguage.SelectedIndex == 0)
                _defaultText = txtDescription.Text;
            else
                _page.PageText = txtDescription.Text;
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblSize.Text = String.Format(StringConstants.TEXT_LENGTH_DESCRIPTION, txtDescription.Text.Length,
                txtDescription.MaxLength, Languages.LanguageStrings.AppCharacters);
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLanguageActive.Enabled = cmbLanguage.SelectedIndex > 0;
            btnSaveTranslation.Enabled = cmbLanguage.SelectedIndex > 0;
            Country selCountry = (Country)cmbLanguage.Items[cmbLanguage.SelectedIndex];

            if (cmbLanguage.SelectedIndex == 0)
            {
                txtDescription.Text = _defaultText;
            }
            else
            {
                _page = CustomPages.Get(selCountry, Products.Get(_productID), PageType);
                
                if (_page != null)
                {
                    if (String.IsNullOrEmpty(_page.PageText))
                        txtDescription.Text = _defaultText;
                    else
                        txtDescription.Text = _page.PageText;

                    cbLanguageActive.Checked = _page.IsActive;
                }
            }
        }

        private void btnSaveTranslation_Click(object sender, EventArgs e)
        {
            if (_page != null)
            {
                _page.PageText = txtDescription.Text;
                _page.IsActive = cbLanguageActive.Checked;
                _page.Save();
            }
        }

        private void cmbLanguage_Format(object sender, ListControlConvertEventArgs e)
        {
            Country country = (Country)e.ListItem;

            if (country.ID == 0)
                e.Value = Languages.LanguageStrings.AppDefault;
            else
                e.Value = String.IsNullOrEmpty(country.LocalizedLanguage) ? country.Name : country.LocalizedLanguage;
        }

        #endregion Private Methods
    }
}
