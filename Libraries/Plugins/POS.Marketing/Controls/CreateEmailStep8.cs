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
 *  File: CreateEmailStep8.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SharedBase;
using SharedBase.Utils;

using Languages;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep8 : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep8()
        {
            InitializeComponent();
        }

        public CreateEmailStep8(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            rbCampaignManagerPage.Text = LanguageStrings.AppCampaignDefaultURL;
            rbCustomWebPage.Text = LanguageStrings.AppCampaignCustomURL;

            lblWebLink.Text = LanguageStrings.AppURL;

            btnTestLink.Text = LanguageStrings.AppMenuButtonTestURL;
        }

        public override void LoadFromFile(string fileName)
        {
            _settings.ImageFileLink = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_IMAGE_LINK);
            _settings.CustomImageLink = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_IMAGE_LINK_CUSTOM, false);
            rbCustomWebPage.Checked = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_IMAGE_LINK_CUSTOM, false);
            rbCampaignManagerPage.Checked = !rbCustomWebPage.Checked;

            selectProductControl1.SetProductTypeIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_TYPE_1, 0));
            selectProductControl1.SetProductIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_1, -1));
            selectProductControl1.SetProductCostIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_COST_1, -1));

            selectProductControl2.SetProductTypeIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_TYPE_2, 0));
            selectProductControl2.SetProductIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_2, -1));
            selectProductControl2.SetProductCostIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_COST_2, -1));

            selectProductControl3.SetProductTypeIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_TYPE_3, 0));
            selectProductControl3.SetProductIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_3, -1));
            selectProductControl3.SetProductCostIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_COST_3, -1));

            selectProductControl4.SetProductTypeIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_TYPE_4, 0));
            selectProductControl4.SetProductIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_4, -1));
            selectProductControl4.SetProductCostIndex(XML.GetXMLValue(fileName, 
                StringConstants.SETTINGS_STEP_4, StringConstants.SETTINGS_PRODUCT_COST_4, -1));
        }

        public override void SaveToFile(string fileName)
        {
            if (rbCampaignManagerPage.Checked)
                XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                    StringConstants.SETTINGS_IMAGE_LINK, String.Empty);
            else
                XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                    StringConstants.SETTINGS_IMAGE_LINK, txtWebLink.Text);

            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_IMAGE_LINK_CUSTOM, 
                rbCustomWebPage.Checked.ToString());

            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_TYPE_1, 
                selectProductControl1.GetProductTypeIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_1, 
                selectProductControl1.GetProductIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_COST_1, 
                selectProductControl1.GetProductCostIndex().ToString());

            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_TYPE_2, 
                selectProductControl2.GetProductTypeIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_2, 
                selectProductControl2.GetProductIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_COST_2, 
                selectProductControl2.GetProductCostIndex().ToString());

            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_TYPE_3, 
                selectProductControl3.GetProductTypeIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_3, 
                selectProductControl3.GetProductIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_COST_3, 
                selectProductControl3.GetProductCostIndex().ToString());

            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_TYPE_4, 
                selectProductControl4.GetProductTypeIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_4, 
                selectProductControl4.GetProductIndex().ToString());
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_PRODUCT_COST_4, 
                selectProductControl4.GetProductCostIndex().ToString());
        }

        public override bool SkipPage()
        {
            return base.SkipPage();
        }

        public override bool NextClicked()
        {
            _settings.ImageFileLink = txtWebLink.Text;
            _settings.ProductCost1 = selectProductControl1.SelectedProductItemID();
            _settings.ProductCost2 = selectProductControl2.SelectedProductItemID();
            _settings.ProductCost3 = selectProductControl3.SelectedProductItemID();
            _settings.ProductCost4 = selectProductControl4.SelectedProductItemID();

            _settings.CustomImageLink = rbCustomWebPage.Checked;

            if (rbCustomWebPage.Checked && String.IsNullOrEmpty(_settings.ImageFileLink))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignLinkError);
                return (false);
            }

            return (true);
        }

        public override void PageShown()
        {
            txtWebLink.Text = _settings.ImageFileLink;

            rbCustomWebPage.Checked = _settings.CustomImageLink;

            rbCampaignManagerPage.Checked = !rbCustomWebPage.Checked;
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep6;
        }

        public override bool PreviousClicked()
        {

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSettings()
        {
            if (String.IsNullOrEmpty(_settings.URL))
            {
                rbCampaignManagerPage.Checked = true;
            }
            else
            {
                rbCustomWebPage.Checked = true;
            }

            SetDisplay();
        }

        private void SetDisplay()
        {
            txtWebLink.Enabled = rbCustomWebPage.Checked;
            lblWebLink.Enabled = rbCustomWebPage.Checked;
            btnTestLink.Enabled = rbCustomWebPage.Checked;
            selectProductControl1.Enabled = rbCampaignManagerPage.Checked;
            selectProductControl2.Enabled = rbCampaignManagerPage.Checked;
            selectProductControl3.Enabled = rbCampaignManagerPage.Checked;
            selectProductControl4.Enabled = rbCampaignManagerPage.Checked;
        }

        private void btnTestLink_Click(object sender, EventArgs e)
        {
            if (rbCustomWebPage.Checked)
            {
                if (txtWebLink.Text.ToLower().StartsWith(StringConstants.BASE_WEB_HTTP) ||
                    txtWebLink.Text.ToLower().StartsWith(StringConstants.BASE_WEB_HTTPS))
                {
                    System.Diagnostics.Process.Start(txtWebLink.Text);
                }
                else
                {
                    System.Diagnostics.Process.Start(String.Format(StringConstants.PREFIX_AND_SUFFIX,
                        _settings.URL, txtWebLink.Text));
                }
            }
        }

        private void rbCampaignManagerPage_CheckedChanged(object sender, EventArgs e)
        {
            SetDisplay();
        }

        #endregion Private Methods
    }
}
