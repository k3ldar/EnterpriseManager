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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.Staff.Controls.Wizards.Commission.ClientPay
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

            dtpPayDate.MinDate = DateTime.Now;
            dtpPayDate.MaxDate = DateTime.Now.AddMonths(2);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Date commission should be paid
        /// </summary>
        public DateTime PayDate 
        { 
            get
            {
                return (dtpPayDate.Value);
            }

            set
            {

                if (value < dtpPayDate.MinDate || value > dtpPayDate.MaxDate)
                    dtpPayDate.Value = DateTime.Now.AddMonths(1);
                else
                    dtpPayDate.Value = value;
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPayClientCommissionDesc.Text = String.Format(Languages.LanguageStrings.AppCommissionClientPayDescription,
                POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays);
            lblSelectPayDate.Text = Languages.LanguageStrings.AppCommissionPayDate;
        }

        public override bool CanCancel()
        {
            return (_canCancel);
        }

        public override bool BeforeFinish()
        {

            return (true);
        }

        #endregion Overridden Methods
    }
}
