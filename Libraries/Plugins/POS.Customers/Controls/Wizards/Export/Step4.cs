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
 *  File: Step4.cs
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
using SharedBase;
using SharedBase.BOL.Countries;
using SharedBase.BOL.Export;
using POS.Base.Classes;
using POS.Customers.Classes;
using SharedControls.WizardBase;

namespace POS.Customers.Controls.Wizards.Export
{
    public partial class Step4 : BaseWizardPage
    {
        #region Private Members

        private ExportSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step4(ExportSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadExportColumns();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblColumnsDesc.Text = LanguageStrings.AppCustomerExportSelectColumns;
            lblAvailable.Text = LanguageStrings.AppAvailable;
            lblSelected.Text = LanguageStrings.AppAssigned;
            btnAssign.Text = String.Format(StringConstants.BUTTON_ASSIGN, LanguageStrings.AppAssign);
            btnRemove.Text = String.Format(StringConstants.BUTTON_UNASSIGN, LanguageStrings.AppRemove);

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerExportStep4;
        }

        public override bool CanCancel()
        {
            return base.CanCancel();
        }

        public override bool CanGoNext()
        {
            return (lstSelected.Items.Count > 0);
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

            return base.NextClicked();
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

        private void LoadExportColumns()
        {
            lstAvailable.Items.Clear();
            lstSelected.Items.Clear();

            foreach (ExportItem item in _settings.ExportItems)
            {
                item.Selected = false;
                lstAvailable.Items.Add(item);
            }
        }

        private void lstAvailable_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((ExportItem)e.ListItem).Description;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedIndex == -1)
                return;

            ExportItem item = (ExportItem)lstAvailable.SelectedItem;
            lstAvailable.Items.Remove(item);
            item.Position = lstSelected.Items.Add(item);
            item.Selected = true;

            MainWizardForm.UpdateUI();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedIndex == -1)
                return;

            ExportItem item = (ExportItem)lstSelected.SelectedItem;
            lstSelected.Items.Remove(item);
            lstAvailable.Items.Add(item);
            item.Selected = false;
            item.Position = -1;

            MainWizardForm.UpdateUI();
        }

        #endregion Private Methods
    }
}
