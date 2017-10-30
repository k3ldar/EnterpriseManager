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
    public partial class Step4 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step4(PayCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            btnPrint.Text = LanguageStrings.AppMenuButtonPrint;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        public override void PageShown()
        {
            LoadCommission();

            string splitType = LanguageStrings.AppCommissionSplitTypeEvenly;

            if (_settings.UsePermanentDate)
                splitType = LanguageStrings.AppCommissionSplitTypePermanent;
            else if (_settings.UseStartDate)
                splitType = LanguageStrings.AppCommissionSplitTypeJoined;

            lblDescription.Text = String.Format(LanguageStrings.AppCommissionSplitDescription,
                Library.Utils.SharedUtils.FormatMoney(_settings.TotalPoolValue, POS.Base.Classes.AppController.LocalCurrency),
                splitType, _settings.StaffMembers.Count);
        }

        public override bool NextClicked()
        {

            return (true);
        }

        public override bool CanGoFinish()
        {
            return base.CanGoFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadCommission()
        {
            gridCommissionSplit.DataSource = null;
            gridCommissionSplit.DataSource = _settings.SplitAllStaff;
            gridCommissionSplit.Invalidate();

            gridCommissionSplit.Columns[3].Visible = false;
            gridCommissionSplit.Columns[0].HeaderText = LanguageStrings.AppEmployee;
            gridCommissionSplit.Columns[1].HeaderText = LanguageStrings.AppCurrentAllocation;
            gridCommissionSplit.Columns[2].HeaderText = LanguageStrings.AppPreviousAllocation;
            gridCommissionSplit.Columns[0].Width = 150;
            gridCommissionSplit.Columns[1].Width = 120;
            gridCommissionSplit.Columns[2].Width = 120;
        }

        private void gridCommissionSplit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void gridCommissionSplit_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion Private Methods
    }
}
