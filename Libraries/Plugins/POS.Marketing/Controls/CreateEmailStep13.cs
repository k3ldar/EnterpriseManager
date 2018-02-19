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
 *  File: CreateEmailStep13.cs
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

using Languages;

using Library;
using Library.Utils;

using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep13 :  EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        private bool _previewClicked = false;
        private bool _sendTestEmailClicked = false;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep13()
        {
            InitializeComponent();
        }

        public CreateEmailStep13(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            OnUploadStart += CreateEmailStep8_OnUploadStart;
            OnUploadFinish += CreateEmailStep8_OnUploadFinish;
            OnUploadFile += CreateEmailStep8_OnUploadFile;


            LoadSettings();
        }

        void CreateEmailStep8_OnUploadFinish(object sender, EventArgs e)
        {
            lblUploading.Visible = false;
            progressUpload.Visible = false;
        }

        void CreateEmailStep8_OnUploadStart(object sender, EventArgs e)
        {
            lblUploading.Visible = true;
            progressUpload.Visible = true;
            progressUpload.Value = 0;
        }

        void CreateEmailStep8_OnUploadFile(object sender, UploadFileArgs e)
        {
            progressUpload.Maximum = e.TotalFiles;
            progressUpload.Value = e.CurrentFile;

        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPreview.Text = LanguageStrings.Preview;
            lblPreviewDescription.Text = LanguageStrings.AppCampaignPreviewDescription;
            lblUploading.Text = LanguageStrings.AppUploading;
            lblImageStyle.Text = LanguageStrings.AppCampaignImageTemplate;

            btnCopyEmail.Text = LanguageStrings.AppMenuButtonCopyEmail;
            btnPreviewWebPage.Text = LanguageStrings.AppMenuButtonPreview;
            btnSendTestEmail.Text = LanguageStrings.AppMenuButtonSendTestEmail;
            btnSaveCampaign.Text = LanguageStrings.AppMenuButtonSaveCampaign;
        }

        public override bool SkipPage()
        {
            return (base.SkipPage());
        }

        public override bool NextClicked()
        {
            if (!_previewClicked && !ShowQuestion(LanguageStrings.Preview, LanguageStrings.AppPreviewNotClicked))
                    return (false);

            if (!_sendTestEmailClicked && 
                    !ShowQuestion(LanguageStrings.AppCampaignTestEmail, LanguageStrings.AppCampaignTestEmailNotClicked))
                return (false);
            return (true);
        }

        public override void PageShown()
        {
            LoadSettings();
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep14;
        }

        public override bool PreviousClicked()
        {
            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSettings()
        {
            cmbImageTemplate.Items.Clear();

            string path = AppController.POSFolder(FolderType.Marketing, true);
            string fileName = path + StringConstants.FILE_MARKETING_IMAGE_TEMPLATE;

            if (System.IO.File.Exists(fileName))
            {
                string fileContents = Shared.Utilities.FileEncryptedRead(fileName, String.Empty).Replace(StringConstants.SYMBOL_CRLF, StringConstants.SYMBOL_LINE_FEED);

                string[] templates = fileContents.Split(StringConstants.SYMBOL_LINE_FEED.ToCharArray()[0]);

                foreach (string s in templates)
                {
                    if (!String.IsNullOrEmpty(s))
                    {
                        int index = cmbImageTemplate.Items.Add(s);

                        if (s == _settings.ImageTemplate)
                            cmbImageTemplate.SelectedIndex = index;
                    }
                }

                if (cmbImageTemplate.SelectedIndex == -1)
                    cmbImageTemplate.SelectedIndex = cmbImageTemplate.Items.Count -1;
            }
            else
            {
                cmbImageTemplate.Items.Add(StringConstants.SETTINGS_TEMPLATE + StringConstants.SYMBOL_ONE);
                cmbImageTemplate.SelectedIndex = 0;
            }
        }

        private void SaveSettings(ref string Setting, string value, string name)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                cmbImageTemplate_SelectedIndexChanged(sender, e);

                string file = UploadToServer(_settings);

                if (!String.IsNullOrEmpty(file))
                    System.Diagnostics.Process.Start(file);

                _previewClicked = true;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnSendTestEmail_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                cmbImageTemplate_SelectedIndexChanged(sender, e);

                if (SendTestEmail(_settings))
                    ShowInformation(LanguageStrings.AppCampaignTestEmail, LanguageStrings.AppCampaignTestEmailSent);

                _sendTestEmailClicked = true;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = _settings.CampaignName + StringConstants.FILE_EXTENSION_CAMPAIGN;

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    MainWizardForm.SaveAllSavedPageData(saveFileDialog1.FileName, StringConstants.XML_ROOT_NODE_NAME);
                }
                catch (Exception err)
                {
                    ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppCampaignGeneralError, err.Message));
                }
            }
        }

        private void btnCopyEmail_Click(object sender, EventArgs e)
        {
            string message = GenerateEmailForCampaign(_settings);
            Clipboard.SetText(message);

            ShowInformation(LanguageStrings.AppCampaignEmailRawData, LanguageStrings.AppCampaignEmailRawDataCopied);
        }

        private void cmbImageTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.ImageTemplate = (string)cmbImageTemplate.Items[cmbImageTemplate.SelectedIndex];
        }

        #endregion Private Methods
    }
}
