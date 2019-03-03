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
 *  File: Step2.cs
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
    public partial class Step2 : BaseWizardPage
    {
        #region Private Members

        private ExportSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step2(ExportSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbReceiveEmail.Text = LanguageStrings.AppCustomerExportOfferEmail;
            cbReceivePostal.Text = LanguageStrings.AppCustomerExportOfferPostal;
            cbReceiveTelephone.Text = LanguageStrings.AppCustomerExportOffertelephone;
            cbValidEmail.Text = LanguageStrings.AppCustomerExportValidEmail;
            cbExcludeInvalidPostal.Text = LanguageStrings.AppCustomerExportInvalidPostal;

            rbHasBusinessName.Text = LanguageStrings.AppCustomerExportHasBusinessName;
            rbIgnoreBusinessName.Text = LanguageStrings.AppCustomerExportIgnoreBusinessName;
            rbNoBusinessName.Text = LanguageStrings.AppCustomerExportNoBusinessName;

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerExportStep2;
        }

        public override bool CanCancel()
        {
            return base.CanCancel();
        }

        public override bool CanGoNext()
        {
            return (true);
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
            _settings.ExcludeInvalidAddress = cbExcludeInvalidPostal.Checked;
            _settings.OfferEmail = cbReceiveEmail.Checked;
            _settings.OfferPostal = cbReceivePostal.Checked;
            _settings.OfferTelephone = cbReceiveTelephone.Checked;
            _settings.ValidEmail = cbValidEmail.Checked;

            _settings.IgnoreBusiness = rbIgnoreBusinessName.Checked;
            _settings.HasBusinessName = rbHasBusinessName.Checked;

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

        #endregion Private Methods
    }
}
