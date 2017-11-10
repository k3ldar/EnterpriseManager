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
 *  File: Step5.cs
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
using Library.BOL.Therapists;
using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    public partial class Step5 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step5(PayCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblDateDue.Text = LanguageStrings.AppCommissionDatePaymentDue;
            lblDescription.Text = LanguageStrings.AppCommissionBonusFinalise;
            lblMayTakeTime.Text = LanguageStrings.AppMayTakeTime;
        }

        public override void PageShown()
        {

        }

        public override bool BeforeFinish()
        {
            MainWizardForm.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (StaffCommissionItem item in _settings.CommissionItems)
                {
                    item.SetDateDue(dtpDateDue.Value);
                }

                _settings.Save(POS.Base.Classes.AppController.ActiveUser, Library.CommissionPaymentType.Bonus);
            }
            finally
            {
                MainWizardForm.Cursor = Cursors.Arrow;
            }
            return base.BeforeFinish();
        }

        public override bool CanGoFinish()
        {
            return base.CanGoFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
