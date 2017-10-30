using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Countries;
using POS.Customers.Classes;
using SharedControls.WizardBase;

namespace POS.Customers.Controls.Wizards.Export
{
    public partial class Step1 : BaseWizardPage
    {
        #region Private Members

        private ExportSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step1(ExportSettings settings)
        {
            InitializeComponent();
            clbCountries.Visible = false;
            _settings = settings;
            LoadCountries();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectCountryDesc.Text = LanguageStrings.AppCustomerExportCountrySelect;
            rbSelectCountries.Text = LanguageStrings.AppCustomerExportSelectCountries;
            rbAllCountries.Text = LanguageStrings.AppCustomerExportAllCountries;

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerExportStep1;
        }

        public override bool CanCancel()
        {
            return base.CanCancel();
        }

        public override bool CanGoNext()
        {
            if (rbAllCountries.Checked)
                return (true);

            return (clbCountries.CheckedItems.Count > 0);
        }

        public override bool CanGoPrevious()
        {
            return base.CanGoPrevious();
        }

        public override bool CanGoFinish()
        {
            return base.CanGoFinish();
        }

        public override bool NextClicked()
        {
            _settings.AllCountries = rbAllCountries.Checked;
            _settings.SelectedCountries.Clear();

            if (rbSelectCountries.Checked)
            {
                foreach (Country country in clbCountries.CheckedItems)
                {
                    _settings.SelectedCountries.Add(country);
                }
            }

            return (true);
        }

        public override bool PreviousClicked()
        {
            return base.PreviousClicked();
        }

        public override bool BeforeFinish()
        {
            return base.BeforeFinish();
        }

        public override bool CancelClicked()
        {
            return base.CancelClicked();
        }

        public override void PageShown()
        {
            
        }

        #endregion Overridden Methods

        #region Private Methods

        private void rbAllCountries_CheckedChanged(object sender, EventArgs e)
        {
            clbCountries.Visible = rbSelectCountries.Checked;

            UpdateWizardUI();
        }

        private void UpdateWizardUI()
        {
            MainWizardForm.UpdateUI();
        }

        private void LoadCountries()
        {
            clbCountries.Items.Clear();

            Countries countries = Countries.Get();

            foreach (Country country in countries)
            {
                clbCountries.Items.Add(country);
            }
        }

        private void clbCountries_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((Country)e.ListItem).Name;
        }

        private void clbCountries_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MainWizardForm.UpdateUI();

            UpdateWizardUI();
        }

        private void clbCountries_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateWizardUI();
        }

        #endregion Private Methods
    }
}
