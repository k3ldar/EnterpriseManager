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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
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

namespace POS.Staff.Controls.Wizards.Commission.ClientGenerate
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
                Library.BOL.Staff.StaffCommission.RebuildClientData(mcDateFrom.SelectionStart, mcDateTo.SelectionEnd, cbReplaceData.Checked);

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
