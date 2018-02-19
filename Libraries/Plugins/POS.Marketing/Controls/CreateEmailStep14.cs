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
 *  File: CreateEmailStep14.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Languages;

using Library.BOL.Campaigns;

using POS.Base.Classes;
using POS.Marketing.Classes;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0018 // Variable declaration can be inlined

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep14 : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        private bool _campaignCreated = false;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep14()
        {
            InitializeComponent();

            dtpStart.Value = DateTime.Now.Date.AddDays(1).AddHours(16);
        }

        public CreateEmailStep14(EmailWizardSettings settings)
            : this()
        {
            _settings = settings;

            LoadSettings();

            LoadMailChimpSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override bool SkipPage()
        {
            return base.SkipPage();
        }

        public override bool NextClicked()
        {
            if (!_campaignCreated)
            {
                if (ShowQuestion(LanguageStrings.AppCampaign, LanguageStrings.AppCampaignNotCreatedUpdated))
                {
                    btnCreateUpdateCampaign_Click(this, EventArgs.Empty);
                    return (false);
                }
            }

            return (true);
        }

        public override void PageShown()
        {
            LoadCampaigns();

            if (String.IsNullOrEmpty(txtEmailTitle.Text))
                txtEmailTitle.Text = _settings.Title;

            cmbMailType.Items.Add(LanguageStrings.AppNoEmail);

            if (!String.IsNullOrEmpty(AppController.LocalSettings.MailChimpAPI))
            {
                cmbMailType.Items.Add(LanguageStrings.AppMailChimp);
                cmbMailType.SelectedIndex = 1;
            }
            else
            {
                cmbMailType.SelectedIndex = 0;
            }

            cmbMailType.Items.Add(LanguageStrings.AppInternalEmail);

            AppController.ActiveHelpTopic = HelpTopics.MarketingStep15;
        }

        public override bool PreviousClicked()
        {
            return (true);
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCreateUpdateCampaign.Text = LanguageStrings.AppMenuButtonCreate;

            lblCampaign.Text = LanguageStrings.AppCampaign;
            lblEmailTitle.Text = LanguageStrings.AppEmailTitle;
            lblEndDateTime.Text = LanguageStrings.AppDateTimeEnd;
            lblMailList.Text = LanguageStrings.AppMailList;
            lblSenderEmail.Text = LanguageStrings.AppEmailSenderEmail;
            lblSenderName.Text = LanguageStrings.AppEmailSenderName;
            lblStartDateTime.Text = LanguageStrings.AppDateTimeStart;

            gbCampaignSender.Text = LanguageStrings.AppCampaignEmailType;
            gbMailChimpSettings.Text = LanguageStrings.AppMailChimpSettings;

            rbExistingCampaign.Text = LanguageStrings.AppExistingCampaign;
            rbNewCampaign.Text = LanguageStrings.AppCampaignNew;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadMailChimpSettings()
        {
            if (String.IsNullOrEmpty(AppController.LocalSettings.MailChimpAPI))
                return;

            cmbMailChimpLists.Items.Clear();
            MailChimpWrapper wrapper = new MailChimpWrapper(AppController.LocalSettings.MailChimpAPI);
            try
            {
                IEnumerable<MailChimp.Net.Models.List> lists = wrapper.ListsGet();

                foreach (MailChimp.Net.Models.List list in lists)
                {
                    cmbMailChimpLists.Items.Add(list);
                }
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
            finally
            {
                wrapper = null;
            }
        }

        private void LoadSettings()
        {
            _settings.Campaign = null;

            LoadCampaigns();
        }

        private void LoadCampaigns()
        {
            rbNewCampaign.Checked = true;
            cmbCampaigns.Items.Clear();

            // load existing campaigns
            Campaigns cmps = Campaigns.GetWizard();

            foreach (Campaign cmp in cmps)
            {
                int idx = cmbCampaigns.Items.Add(cmp);

                if (cmp.CampaignName == _settings.CampaignName)
                {
                    cmbCampaigns.SelectedIndex = idx;
                    cmbCampaigns.Enabled = false;
                    rbExistingCampaign.Checked = true;
                    rbNewCampaign.Enabled = false;
                    dtpStart.Value = cmp.StartDateTime;
                    dtpFinish.Value = cmp.FinishDateTime;
                }
            }

            cmbCampaigns.Enabled = cmbCampaigns.SelectedIndex == -1 && rbExistingCampaign.Checked;
        }

        private void cmbCampaigns_Format(object sender, ListControlConvertEventArgs e)
        {
            Campaign cmp = (Campaign)e.ListItem;
            e.Value = cmp.CampaignName;
        }

        private void rbNewCampaign_CheckedChanged(object sender, EventArgs e)
        {
            cmbCampaigns.Enabled = rbExistingCampaign.Checked;
            
            if (rbNewCampaign.Checked)
                btnCreateUpdateCampaign.Text = LanguageStrings.AppMenuButtonCreate;
            else
                btnCreateUpdateCampaign.Text = LanguageStrings.AppMenuButtonUpdate;
        }

        private void cmbCampaigns_SelectedIndexChanged(object sender, EventArgs e)
        {
            Campaign cmp = (Campaign)cmbCampaigns.SelectedItem;
            txtEmailTitle.Text = cmp.EmailSubject;
            dtpStart.Value = cmp.StartDateTime;
            dtpFinish.Value = cmp.FinishDateTime;
        }

        private void btnCreateUpdateCampaign_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmailTitle.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignEmailSubjectEmpty);
                return;
            }

            if (dtpStart.Value >= dtpFinish.Value)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignStartDateWrong);
                return;
            }

            TimeSpan span = dtpFinish.Value - dtpStart.Value;

            if (span.TotalHours < 5)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignMin5Hours);
                return;
            }

            Campaign campaign = null;

            if (rbExistingCampaign.Checked)
            {
                campaign = (Campaign)cmbCampaigns.SelectedItem;
            }
            else
            {
                campaign = Campaigns.Create(_settings.CampaignName);
            }

            if (gbMailChimpSettings.Visible)
            {
                // validate mail chimp stuff
                if (cmbMailChimpLists.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignSelectMailChimpList);
                    return;
                }
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                campaign.EmailSubject = txtEmailTitle.Text;
                campaign.StartDateTime = dtpStart.Value;
                campaign.FinishDateTime = dtpFinish.Value;
                campaign.EmailSent = false;

                if ((string)cmbMailType.SelectedItem == LanguageStrings.AppInternalEmail)
                {
                    campaign.SendEmail = true;
                    campaign.Message = GenerateEmailForCampaign(_settings);
                }
                else if ((string)cmbMailType.SelectedItem == LanguageStrings.AppMailChimp)
                {
                    //create a mailchimp campaign here
                    CreateMailChimpCampaign(GenerateEmailForCampaign(_settings));
                }

                if (!_settings.CustomImageLink)
                {
                    campaign.OfferProduct1 = _settings.ProductCost1;
                    campaign.OfferProduct2 = _settings.ProductCost2;
                    campaign.OfferProduct3 = _settings.ProductCost3;
                }

                campaign.Title = _settings.CampaignName;
                campaign.CampaignName = _settings.TrackingCode;

                campaign.Save();

                _settings.Campaign = campaign;
                _campaignCreated = true;
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_VIOLATION_CAMPAIGN))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignErrorDuplicateTrackCode);
                }
                else
                    ShowError(LanguageStrings.AppError, err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
           
        }

        #region Mail Chimp Integration

        private void CreateMailChimpCampaign(string emailText)
        {
            Classes.MailChimpWrapper mcWrapper = new Classes.MailChimpWrapper(AppController.LocalSettings.MailChimpAPI);
            try
            {
                int templateID = 0;

                // does the template exist?
                if (mcWrapper.TemplateExists(_settings.CampaignName, out templateID))
                {
                    mcWrapper.TemplateUpdate(templateID, _settings.CampaignName, emailText);
                }
                else
                {
                    mcWrapper.TemplateCreate(_settings.CampaignName, emailText, out templateID);
                }

                MailChimp.Net.Models.List selList = (MailChimp.Net.Models.List)cmbMailChimpLists.SelectedItem;

                //string listID = selList.Id;
                string campaignID = String.Empty;

                // does the campaign exist?
                if (mcWrapper.CampaignExists(_settings.CampaignName, out campaignID))
                {
#warning Update following line
                    //mcWrapper.CampaignUpdate(campaignID, _settings.CampaignName, txtEmailTitle.Text,
                    //    emailText, txtMailChimpSenderEmail.Text, txtMailChimpSenderName.Text,
                    //    dtpStart.Value, templateID, selList.Id);
                }

                if (mcWrapper.CampaignCreate(_settings.CampaignName, txtEmailTitle.Text, emailText,
                        txtMailChimpSenderEmail.Text, txtMailChimpSenderName.Text, dtpStart.Value,
                        templateID, selList.Id, ref campaignID))
                {
                    ShowInformation(LanguageStrings.AppCampaignMailChimp, LanguageStrings.AppCampaignMailChimpSuccess);
                }
                else
                    ShowInformation(LanguageStrings.AppCampaignMailChimp, LanguageStrings.AppCampaignMailChimpError);
            }
            finally
            {
                mcWrapper = null;
            }
        }

        #endregion Mail Chimp Integration

        private void cmbMailChimpLists_Format(object sender, ListControlConvertEventArgs e)
        {
            MailChimp.Net.Models.List item = (MailChimp.Net.Models.List)e.ListItem;
            e.Value = item.Name;
        }

        private void rbMailChimp_CheckedChanged(object sender, EventArgs e)
        {
            gbMailChimpSettings.Visible = (string)cmbMailType.SelectedItem == LanguageStrings.AppMailChimp;
        }

        private void cmbMailChimpLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            MailChimp.Net.Models.List item = (MailChimp.Net.Models.List)cmbMailChimpLists.SelectedItem;
            txtMailChimpSenderEmail.Text = item.CampaignDefaults.FromEmail;
            txtMailChimpSenderName.Text = item.CampaignDefaults.FromName;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFinish.Value < dtpStart.Value)
                dtpFinish.Value = dtpStart.Value.AddDays(21).AddHours(23 - dtpStart.Value.Hour).AddMinutes(59 - dtpStart.Value.Minute);
        }

        #endregion Private Methods
    }
}
