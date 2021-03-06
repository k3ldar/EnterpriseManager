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
 *  File: Step3.cs
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
using SharedBase.BOL.Staff;
using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    public partial class Step3 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step3(PayCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;

            rbSplitPermanentDate_CheckedChanged(this, EventArgs.Empty);
            dtpDateFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpDateTo.Value = DateTime.Now;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            rbSplitPermanentDate.Text = LanguageStrings.AppCommissionSplitDatePermanent;
            rbSplitJoinDate.Text = LanguageStrings.AppCommissionSplitDateJoined;
            rbSplitJointly.Text = LanguageStrings.AppCommissionSplitEvenly;

            lblDateDescription.Text = LanguageStrings.AppCommissionBonusDateMeaning;
            lblDateFrom.Text = LanguageStrings.AppDateFrom;
            lblDateTo.Text = LanguageStrings.AppDateTo;
        }

        public override bool NextClicked()
        {
            if (_settings.CommissionItems == null)
                _settings.CommissionItems = new StaffCommission();
            else
                _settings.CommissionItems.Clear();

            if (rbSplitJointly.Checked)
            {
                _settings.CommissionItems.Add(new StaffCommissionItem(_settings.TotalPoolValue, dtpDateTo.Value, dtpDateTo.Value.AddDays(14)));
            }
            else
            {
                if (dtpDateTo.Value < dtpDateFrom.Value)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCommissionBonusDateInvalid);
                    return (false);
                }

                DateTime currDate = dtpDateFrom.Value;

                do
	            {
	                _settings.CommissionItems.Add(new StaffCommissionItem(0, currDate, dtpDateTo.Value.AddDays(14)));
                    currDate = currDate.AddDays(DateTime.DaysInMonth(currDate.Year, currDate.Month));

	            } while (currDate < dtpDateTo.Value);

                decimal monthly = _settings.TotalPoolValue / _settings.CommissionItems.Count;

                foreach (StaffCommissionItem item in _settings.CommissionItems)
                {
                    item.CommissionDue = monthly;
                }
            }

            _settings.UseStartDate = rbSplitJoinDate.Checked;
            _settings.UsePermanentDate = rbSplitPermanentDate.Checked;

            _settings.SplitCommission();

            return base.NextClicked();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void rbSplitPermanentDate_CheckedChanged(object sender, EventArgs e)
        {
            lblDateDescription.Visible = !rbSplitJointly.Checked;
            lblDateFrom.Visible = !rbSplitJointly.Checked;
            lblDateTo.Visible = !rbSplitJointly.Checked;
            dtpDateFrom.Visible = !rbSplitJointly.Checked;
            dtpDateTo.Visible = !rbSplitJointly.Checked;
        }

        #endregion Private Methods
    }
}
