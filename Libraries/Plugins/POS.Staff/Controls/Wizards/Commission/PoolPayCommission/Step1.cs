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

namespace POS.Staff.Controls.Wizards.Commission.PoolPayCommission
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step1(PayCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
            LoadPools();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblSelectPool.Text = LanguageStrings.AppCommissionPoolSelect;
        }

        public override bool NextClicked()
        {
            _settings.Pool = (CommissionPool)cmbPools.SelectedItem;

            _settings.CommissionItems = StaffCommission.Get(_settings.Pool, DateTime.MinValue, DateTime.Now, true, true);

            return base.NextClicked();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadPools()
        {
            cmbPools.Items.Clear();

            foreach (CommissionPool pool in CommissionPools.Get())
                cmbPools.Items.Add(pool);

            cmbPools.SelectedIndex = 0;
        }

        private void cmbPools_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((CommissionPool)e.ListItem).Name;
        }

        #endregion Private Methods
    }
}
