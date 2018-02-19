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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
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
