using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Staff;

using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SicknessWizardSettings _returnToWork;

        #endregion Private Members

        #region Constructors

        public Step2()
        {
            InitializeComponent();

            dtpDateFrom.CustomFormat = Shared.Utilities.DateFormat(true, true);
            dtpDateNotified.CustomFormat = Shared.Utilities.DateFormat(true, true);
        }

        public Step2(SicknessWizardSettings returnToWork)
            : this()
        {
            _returnToWork = returnToWork;
            dtpDateNotified.Value = DateTime.Now;

        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDateFrom.Text = LanguageStrings.AppSicknessDateStarted;
            lblDateNotified.Text = LanguageStrings.AppSicknessDateNotified;
            lblReason.Text = LanguageStrings.AppSicknessReasonProvided;
            cbPreBooked.Text = LanguageStrings.AppSicknessPreBooked;
            cbCertificateProvided.Text = LanguageStrings.AppSicknessCertificateProvided;
        }

        public override bool NextClicked()
        {
            if (String.IsNullOrEmpty(txtReason.Text))
            {
                ShowError(LanguageStrings.AppSicknessReasonProvided, LanguageStrings.AppSicknessEnterReason);
                return (false);
            }

            _returnToWork.PreBooked = cbPreBooked.Checked;
            _returnToWork.Certificate = cbCertificateProvided.Checked;
            _returnToWork.DateFrom = dtpDateFrom.Value;
            _returnToWork.DateNotified = dtpDateNotified.Value;
            _returnToWork.Reason = txtReason.Text;

            return (true);
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffSickStep2;
        }

        #endregion Overridden Methods
    }
}
