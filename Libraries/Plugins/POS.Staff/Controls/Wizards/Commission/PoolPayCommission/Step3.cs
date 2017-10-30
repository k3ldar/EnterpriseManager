using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Staff;
using Library.BOL.Therapists;
using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.Commission.PoolPayCommission
{
    public partial class Step3 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step3(PayCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);
            rbSplitPermanentDate.Text = LanguageStrings.AppCommissionSplitDatePermanent;
            rbSplitJoinDate.Text = LanguageStrings.AppCommissionSplitDateJoined;
            rbSplitJointly.Text = LanguageStrings.AppCommissionSplitEvenly;
        }

        public override void PageShown()
        {

        }

        public override bool NextClicked()
        {
            _settings.UseStartDate = rbSplitJoinDate.Checked;
            _settings.UsePermanentDate = rbSplitPermanentDate.Checked;
            _settings.SplitCommission();

            return (true);
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
