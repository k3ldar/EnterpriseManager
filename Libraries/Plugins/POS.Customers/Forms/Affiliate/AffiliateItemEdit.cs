using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Affiliate;

namespace POS.Customers.Forms
{
    public partial class AffiliateItemEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private AffiliatedItem _affiliate;

        #endregion Private Members

        #region Constructors

        public AffiliateItemEdit()
        {
            InitializeComponent();

           
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Current Affiliate item
        /// </summary>
        private AffiliatedItem Affiliate 
        {
            get
            {
                return (_affiliate);
            }

            set
            {
                _affiliate = value;

                txtAffiliateID.Text = Affiliate.AffiliateID;
                txtAffiliateURL.Text = Affiliate.Url;
                udPricePerClick.Value = Affiliate.PricePerClick;
                udPercentage.Value = Affiliate.Percentage;
                cbActive.Checked = Affiliate.Active;
            }
        }

        #endregion Properties

        #region Static Methods

        public static bool Show(AffiliatedItem affiliate)
        {
            bool Result = false;

            AffiliateItemEdit frm = new AffiliateItemEdit();
            try
            {
                frm.Affiliate = affiliate;
                Result = frm.ShowDialog() == DialogResult.OK;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.CustomerAffSettings;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AffiliateItemEdit;

            lblAffiliateID.Text = LanguageStrings.AffiliateID;
            lblAffiliateURL.Text = LanguageStrings.AffiliateURL;
            lblPercentCommission.Text = LanguageStrings.AffiliatePercentage;
            lblPricePerClick.Text = LanguageStrings.AffiliatePricePerClick;

            cbActive.Text = LanguageStrings.AppActive;

            btnOK.Text = LanguageStrings.AppMenuButtonSave;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!AffiliatedItems.IsIDUnique(Affiliate, txtAffiliateID.Text))
            {
                ShowError(LanguageStrings.AffiliateItemError, LanguageStrings.AffiliateItemUniqueIDError);
                return;
            }

            Affiliate.AffiliateID = txtAffiliateID.Text;
            Affiliate.Url = txtAffiliateURL.Text;
            Affiliate.PricePerClick = udPricePerClick.Value;
            Affiliate.Percentage = udPercentage.Value;
            Affiliate.Active = cbActive.Checked;
            Affiliate.Save();

            this.DialogResult = DialogResult.OK;
        }

        #endregion Private Methods
    }
}
