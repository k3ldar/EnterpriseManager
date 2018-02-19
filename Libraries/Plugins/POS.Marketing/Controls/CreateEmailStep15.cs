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
 *  File: CreateEmailStep15.cs
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

using Library;
using Library.Utils;
using Library.BOL.Campaigns;

using Languages;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep15 : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;
        private int _additionalCampaigns = 0;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep15()
        {
            InitializeComponent();
        }

        public CreateEmailStep15(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppCampaignRepeatTitle;
            lblHeaderDescription.Text = LanguageStrings.AppCampaignRepeatDescription;
            lblEvery.Text = LanguageStrings.AppEvery;
            lblDaysFrom.Text = LanguageStrings.AppCampaignRepeatDays;

            cbRepeat.Text = LanguageStrings.AppRepeat;
        }

        public override bool SkipPage()
        {
            return (base.SkipPage());
        }

        public override bool BeforeFinish()
        {
            if (cbRepeat.Enabled && cbRepeat.Checked && _settings.Campaign != null)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    pbProgress.Maximum = _additionalCampaigns;
                    pbProgress.Value = 0;
                    int repeat = txtDays.Text == String.Empty ? 7 : Convert.ToInt32(txtDays.Text);
                    DateTime finish = _settings.Campaign.FinishDateTime;
                    DateTime start = dtpStartDate.Value;

                    while (start.Date < finish.Date)
                    {
                        int newNumber = pbProgress.Value;
                        Campaign cmp = Campaigns.Create(_settings.CampaignName + newNumber.ToString());
                        cmp.StartDateTime = start.Date.AddMinutes(1);
                        cmp.FinishDateTime = start.Date.AddHours(6);

                        cmp.EmailSubject = _settings.Campaign.EmailSubject;
                        cmp.EmailSent = false;
                        cmp.SendEmail = true;
                        cmp.Message = _settings.Campaign.Message;
                        cmp.Save();

                        start = start.AddDays(repeat);
                        pbProgress.Value++;
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            return (true);
        }

        public override bool NextClicked()
        {

            return (true);
        }

        public override void PageShown()
        {
            cbRepeat.Checked = false;// _settings.Campaign != null;
            cbRepeat.Enabled = _settings.Campaign != null;

            lblProgress.Visible = false;
            pbProgress.Visible = false;

            LoadSettings();
        }

        public override bool PreviousClicked()
        {
            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSettings()
        {
            dtpStartDate.MinDate = DateTime.Now.AddDays(1);
            dtpStartDate.Value = DateTime.Now.AddDays(2);

            checkBox1_CheckedChanged(cbRepeat, EventArgs.Empty);
            LoadRepeatDates();
        }

        private void SaveSettings(ref string Setting, string value, string name)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lblEvery.Enabled = cbRepeat.Checked;
            txtDays.Enabled = cbRepeat.Checked;
            lblDaysFrom.Enabled = cbRepeat.Checked;
            lblRepeatSchedule.Enabled = cbRepeat.Checked;

            LoadRepeatDates();
        }

        private void LoadRepeatDates()
        {
            _additionalCampaigns = 0;
            lblRepeatSchedule.Text = String.Empty;

            if (cbRepeat.Checked && _settings.Campaign != null)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    int repeat = 7;

                    if (txtDays.Text != String.Empty)
                        repeat = Convert.ToInt32(txtDays.Text);

                    DateTime finish = _settings.Campaign.FinishDateTime;
                    DateTime start = dtpStartDate.Value;

                    while (start.Date < finish.Date)
                    {
                        if (String.IsNullOrEmpty(lblRepeatSchedule.Text))
                            lblRepeatSchedule.Text = LanguageStrings.AppCampaignEmailSendDates;

                        lblRepeatSchedule.Text += String.Format(StringConstants.PREFIX_AND_SUFFIX, 
                            start.ToShortDateString(), StringConstants.SYMBOL_CRLF);
                        start = start.AddDays(repeat);

                        _additionalCampaigns++;
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            LoadRepeatDates();
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !StringConstants.SPLIT_PAYMENT_VALID_CHARS.Contains(e.KeyChar.ToString());
        }

        #endregion Private Methods
    }
}
