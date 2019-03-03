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
 *  File: MailChimpSettings.cs
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
using POS.Base.Classes;
using POS.Marketing.Classes;

namespace POS.Marketing.Controls
{
    public partial class MailChimpSettings : SharedControls.BaseSettings
    {
        #region Constructors

        public MailChimpSettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAPIKey.Text = String.Format(LanguageStrings.AppAPIKey, StringConstants.MAIL_CHIMP);
            btnTest.Text = LanguageStrings.AppMenuButtonTest;

            gbDefaultOptions.Text = LanguageStrings.AppOptions;
            cbAddFooter.Text = LanguageStrings.AppAddFooter;
            cbGoogleAnalytics.Text = LanguageStrings.AppGoogleAnalytics;
            cbPostToFaceBook.Text = LanguageStrings.AppPostToFacebook;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.MailChimpAPI = txtMailChimpAPIKey.Text;
            AppController.LocalSettings.MailChimpFooter = cbAddFooter.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            txtMailChimpAPIKey.Text = AppController.LocalSettings.MailChimpAPI;
            cbAddFooter.Checked = AppController.LocalSettings.MailChimpFooter;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnTest_Click(object sender, EventArgs e)
        {
            MailChimpWrapper wrapper = new MailChimpWrapper(txtMailChimpAPIKey.Text);
            try
            {
                IEnumerable<MailChimp.Net.Models.List> lists = wrapper.ListsGet();
                ShowInformation(LanguageStrings.AppMailChimp, LanguageStrings.AppMailChimpTestSuccessful);
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

        #endregion Private Methods
    }
}
