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

using SharedBase.BOL.Affiliate;
using SharedBase.BOL.Therapists;
using POS.Customers.Classes;

namespace POS.Customers.Controls.Wizards.Affiliate.PayCommission
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayAffiliateCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step2(PayAffiliateCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            btnPrint.Text = LanguageStrings.AppMenuButtonPrint;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        public override void PageShown()
        {
            LoadCommission();

            lblDescription.Text = LanguageStrings.AppAffiliatePayCommissionDescription;
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerAffPayCommissionStep2;
        }

        public override bool NextClicked()
        {
            if (_settings.CommissionItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppAffiliatePayNoPayments);
                return (false);
            }

            return (true);
        }

        public override bool CanGoFinish()
        {
            return base.CanGoFinish();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadCommission()
        {
            gridCommissionSplit.DataSource = null;
            gridCommissionSplit.DataSource = _settings.CommissionItems;
            gridCommissionSplit.Invalidate();

            gridCommissionSplit.Columns[0].Visible = false;
            gridCommissionSplit.Columns[1].Visible = false;
            gridCommissionSplit.Columns[2].HeaderText = LanguageStrings.AppEmployee;
            gridCommissionSplit.Columns[3].HeaderText = LanguageStrings.AppInvoiceNumber;
            gridCommissionSplit.Columns[4].Visible = false;
            gridCommissionSplit.Columns[5].Visible = false;
            gridCommissionSplit.Columns[6].HeaderText = LanguageStrings.AppPercentage;
            gridCommissionSplit.Columns[7].HeaderText = String.Format(LanguageStrings.AppInvoiceTotal, String.Empty).Trim();
            gridCommissionSplit.Columns[8].HeaderText = String.Format(LanguageStrings.AppCommissionableTotal, String.Empty).Trim();
            gridCommissionSplit.Columns[9].HeaderText = String.Format(LanguageStrings.AppCommissionDue, String.Empty).Trim();
            gridCommissionSplit.Columns[10].Visible = false;
            gridCommissionSplit.Columns[11].Visible = false;
            gridCommissionSplit.Columns[12].Visible = false;

            gridCommissionSplit.Columns[0].Width = 150;
            gridCommissionSplit.Columns[1].Width = 120;
            gridCommissionSplit.Columns[2].Width = 120;
        }

        private void gridCommissionSplit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void gridCommissionSplit_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void gridCommissionSplit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 7:
                case 8:
                case 9:
                    e.Value = SharedBase.Utils.SharedUtils.FormatMoney((decimal)e.Value, POS.Base.Classes.AppController.LocalCurrency);

                    break;
            }
        }

        #endregion Private Methods
    }
}
