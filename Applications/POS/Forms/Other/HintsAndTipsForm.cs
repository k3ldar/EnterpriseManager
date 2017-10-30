using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using PointOfSale.Classes;
using POS.Base.Classes;
using SharedControls.Classes;

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
