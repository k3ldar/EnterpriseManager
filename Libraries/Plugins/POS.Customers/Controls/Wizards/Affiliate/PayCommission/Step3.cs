using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Affiliate;
using Library.BOL.Therapists;
using POS.Customers.Classes;

namespace POS.Customers.Controls.Wizards.Affiliate.PayCommission
{
    public partial class Step3 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayAffiliateCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step3(PayAffiliateCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblDescription.Text = LanguageStrings.AppAffiliateCommissionFinalise;
            lblMayTakeTime.Text = LanguageStrings.AppMayTakeTime;
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerAffPayCommissionStep3;
        }

        public override bool BeforeFinish()
        {
            MainWizardForm.Cursor = Cursors.WaitCursor;
            try
            {
                _settings.Save(POS.Base.Classes.AppController.ActiveUser, Library.CommissionPaymentType.Affiliate);
            }
            finally
            {
                MainWizardForm.Cursor = Cursors.Arrow;
            }
            return base.BeforeFinish();
        }

        public override bool CanGoFinish()
        {
            return base.CanGoFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
