using System.Windows.Forms;

using Languages;

namespace POS.Staff.Controls.Wizards.Commission.PoolGenerate
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private bool _canCancel = true;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDateFrom.Text = LanguageStrings.AppDateFrom;
            lblDateTo.Text = LanguageStrings.AppDateTo;
            lblMayTakeTime.Text = LanguageStrings.AppMayTakeTime;

            cbReplaceData.Text = LanguageStrings.AppReplaceData;
        }

        public override bool CanCancel()
        {
            return (_canCancel);
        }

        public override bool BeforeFinish()
        {
            if (mcDateFrom.SelectionStart >= mcDateTo.SelectionStart)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorStartDateBeforeEndDate);
                return (false);
            }

            this.MainWizardForm.SetCursor(Cursors.WaitCursor);
            try
            {
                mcDateTo.Enabled = false;
                mcDateFrom.Enabled = false;
                cbReplaceData.Enabled = false;
                _canCancel = false;

                MainWizardForm.UpdateUI();

                // rebuild data 
                Library.BOL.Staff.StaffCommission.RebuildPoolData(mcDateFrom.SelectionStart, mcDateTo.SelectionEnd, cbReplaceData.Checked);

                return (true);
            }
            finally
            {
                mcDateTo.Enabled = true;
                mcDateFrom.Enabled = true;
                cbReplaceData.Enabled = true;
                this.MainWizardForm.SetCursor(Cursors.Arrow);
            }
        }

        #endregion Overridden Methods
    }
}
