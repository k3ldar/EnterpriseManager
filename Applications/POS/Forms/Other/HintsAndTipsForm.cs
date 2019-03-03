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
 *  File: HintsAndTipsForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Data;

using Languages;
using POS.Base.Classes;
using SharedControls.Classes;

#pragma warning disable IDE1006

namespace PointOfSale.Forms.Other
{
    public partial class HintsAndTipsForm : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public HintsAndTipsForm()
        {
            InitializeComponent();

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.HintsAndTips;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppHintsAndTips;

            btnClose.Text = LanguageStrings.AppMenuButtonClose;
            btnNext.Text = LanguageStrings.AppMenuButtonNext;

            lblHeader.Text = LanguageStrings.AppDidYouKnow;

            cbShowAtStart.Text = LanguageStrings.AppShowAtStart;
        }

        protected override void LoadSettings()
        {
            hintsData.ReadXml(StringConstants.FILE_DID_YOU_KNOW, XmlReadMode.InferSchema);
            DataRow Hint = hintsData.Tables[0].First();
            lblHint.Text = Hint.ItemArray[0].ToString().Replace(
                StringConstants.SYMBOL_CRLF_SAVED, StringConstants.SYMBOL_CRLF);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void HintsAndTipsForm_Load(object sender, EventArgs e)
        {
            cbShowAtStart.Checked = AppController.LocalSettings.ShowDidYouKnowAtStartup;
        }

        private void cbShowAtStart_CheckedChanged(object sender, EventArgs e)
        {
            AppController.LocalSettings.ShowDidYouKnowAtStartup = cbShowAtStart.Checked;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string hintText = String.Empty;

            if (hintsData.Tables[0].LastRow())
                hintText = hintsData.Tables[0].First().ItemArray[0].ToString();
            else
                hintText = hintsData.Tables[0].Next().ItemArray[0].ToString();

            lblHint.Text = hintText.Replace(StringConstants.SYMBOL_CRLF_SAVED, 
                StringConstants.SYMBOL_CRLF);
        }

        #endregion Private Methods
    }

}
