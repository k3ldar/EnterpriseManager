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
 *  File: MarkAsPaidForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Windows.Forms;

using Languages;

using Library.BOL.Accounts;
using Library.BOL.Orders;

using POS.Base.Classes;

#pragma warning disable IDE1006 // Naming rule violation: These words must begin with upper case characters

namespace POS.Till.Forms
{
    public partial class MarkAsPaidForm : Base.Forms.BaseForm
    {
        #region Private Members

        private PaymentStatus _payType;

        #endregion Private Members

        #region Constructors

        public MarkAsPaidForm()
        {
            InitializeComponent();
        }

        public MarkAsPaidForm(bool IsTill)
            : this()
        {
            cmbPaymentType.Items.Clear();

            foreach (PaymentStatus status in PaymentStatuses.Get())
            {
                if (IsTill && status.IsTill && status.IsPaid)
                {
                    int idx = cmbPaymentType.Items.Add(status);

                    if (status.Description.Contains(StringConstants.STATUS_SPLIT))
                        cmbPaymentType.SelectedIndex = idx;
                }
                else if (!IsTill && status.IsOffice)
                {
                    cmbPaymentType.Items.Add(status);
                    cmbPaymentType.SelectedIndex = 0;
                }
            }

            splitPayment1.Init();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            cmbPaymentType_SelectedIndexChanged(this, EventArgs.Empty);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppPaymentMake;

            lblPaymentType.Text = LanguageStrings.AppPaymentType;
            lblAdditionalInformation.Text = LanguageStrings.AppAdditionalInformation;
        }

        #endregion Overridden Methods


        #region Public Methods

        public void ProcessSplitPayment(Order order)
        {
            if (_payType.ID == PaymentStatuses.Get(StringConstants.PAYMENT_IN_STORE_SPLIT).ID)
            {
                splitPayment1.AddSplitPayment(order);
            }
        }

        #endregion Public Methods

        #region Properties

        public PaymentStatus PaymentStatus
        {
            get
            {
                return (_payType);
            }
        }

        public string AdditionalPaymentInformation
        {
            get
            {
                return (txtAdditionalInformation.Text);
            }
        }

        public decimal TotalToPay
        {
            set
            {
                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    cashTill1.TotalDue = value;
                    splitPayment1.TotalDue = value;
                }
            }
        }

        #endregion Properties

        #region Private Methods

        private void cmbPaymentType_Format(object sender, ListControlConvertEventArgs e)
        {
            PaymentStatus payType = (PaymentStatus)e.ListItem;
            e.Value = payType.Description;
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                _payType = (PaymentStatus)cmbPaymentType.Items[cmbPaymentType.SelectedIndex];

                cashTill1.Visible = _payType.ID == PaymentStatuses.Get(StringConstants.PAYMENT_IN_SALON_CASH).ID;
                splitPayment1.Visible = _payType.ID == PaymentStatuses.Get(StringConstants.PAYMENT_IN_STORE_SPLIT).ID;
                txtAdditionalInformation.Visible = !cashTill1.Visible && !splitPayment1.Visible;

                switch (_payType.Description)
                {
                    case "In Store Paid Cash":
                        AppController.ActiveHelpTopic = HelpTopics.TillPaymentCash;
                        break;
                    case "In Store Paid Card":
                        AppController.ActiveHelpTopic = HelpTopics.TillPaymentCard;
                        break;
                    case "In Store Paid Cheque":
                        AppController.ActiveHelpTopic = HelpTopics.TillPaymentCheque;
                        break;
                    case "In Store Split Payment":
                        AppController.ActiveHelpTopic = HelpTopics.TillPaymentSplit;
                        break;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (splitPayment1.Visible)
            {
                if (splitPayment1.CorrectPayment)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    if (splitPayment1.PaymentLessThan)
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppPaymentDoesNotMatchLessThan);
                    else
                        if (ShowErrorMessage(LanguageStrings.AppError, LanguageStrings.AppPaymentDoesNotMatch, true))
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ShowError(string Title, string Message)
        {
            string msg = String.Format(LanguageStrings.AppErrorContactSupport, Message);
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Private Methods
    }
}
