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
 *  File: Step1.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Countries;
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
