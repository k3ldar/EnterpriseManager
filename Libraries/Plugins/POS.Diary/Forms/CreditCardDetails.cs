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
 *  File: CreditCardDetails.cs
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using SharedBase;
using SharedBase.BOL.Users;
using SharedBase.BOL.ValidationChecks;

using SharedControls;
using SharedControls.Classes;
using POS.Base.Classes;

namespace POS.Diary.Forms
{
    public partial class CreditCardDetails : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private User _userDetails;

        #endregion Private Members

        #region Constructors

        public CreditCardDetails()
        {
            InitializeComponent();
        }

        public CreditCardDetails(User userDetails)
            : this ()
        {
            _userDetails = userDetails;
            cmbCardType.SelectedIndex = 0;

            for (int i = DateTime.Now.AddYears(-6).Year; i <= DateTime.Now.Year; i++)
                cmbFromYear.Items.Insert(0, i.ToString());

            for (int i = DateTime.Now.Year; i <= DateTime.Now.AddYears(8).Year; i++)
                cmbToYear.Items.Add(i.ToString());

            bool userCanBypass = AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.BypassCreditCard);
            cbNoCardDetails.Enabled = userCanBypass;
            lblReason.Enabled = userCanBypass;
            txtReason.Enabled = userCanBypass;
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Validates that a user has valid credit card details, if not
        /// prompts staff member to enter credit card details
        /// </summary>
        /// <param name="user">User who needs credit card details</param>
        /// <returns>true if user has credit card details or a valid excuse was inserted, otherwise false</returns>
        public static bool UserHasCreditCardDetails(User user)
        {
            if (user.CardDetails != null && user.CardDetails.CardStillValied())
                return (true);

            CreditCardDetails cardDetails = new CreditCardDetails(user);
            try
            {
                return (cardDetails.ShowDialog() == DialogResult.OK);
            }
            finally
            {
                cardDetails.Dispose();
                cardDetails = null;
            }
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.DiaryCreditCardDetails;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppCardCreditCardDetails;

            lblDescription.Text = String.Format(LanguageStrings.AppCardReasonRequired, AppController.LocalSettings.CreditCardAppointmentMinutes,
                AppController.LocalSettings.CreditCardPercent, AppController.LocalSettings.CreditCardHoursCancel);
            lblCardNumber.Text = LanguageStrings.AppCardNumber;
            lblCardType.Text = LanguageStrings.AppCardType;
            lblLast3Digits.Text = LanguageStrings.AppCardLast3Digits;
            lblReason.Text = LanguageStrings.AppCardReason;
            lblValidFrom.Text = LanguageStrings.AppCardValidFrom;
            lblValidTo.Text = LanguageStrings.AppCardValidTo;

            cbNoCardDetails.Text = LanguageStrings.AppCardNotRequired;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cbNoCardDetails.Checked)
                {
                    // bit of validation
                    if (txtCardNumber.Text.Length < 5)
                        throw new Exception(StringConstants.ERROR_CARD_INVALID_NUMBER);

                    // validate against known credit card types
                    // will throw an exception if fails
                    Shared.Validation.Validate(txtCardNumber.Text, Shared.ValidationTypes.CreditCard);

                    if (txtLast3Digits.Text.Length != 3)
                        throw new Exception(StringConstants.ERROR_CARD_INVALID_LAST_3);

                    if (cmbFromMonth.SelectedIndex == -1 || cmbFromYear.SelectedIndex == -1 || cmbToMonth.SelectedIndex == -1 || cmbToYear.SelectedIndex == -1)
                        throw new Exception(StringConstants.ERROR_CARD_INVALID_FROM_TO);

                    DateTime datefrom = GetDateFrom();
                    DateTime dateTo = GetDateTo();

                    if (datefrom >= dateTo)
                        throw new Exception(StringConstants.ERROR_CARD_INVALID_FROM);

                    CreditCard.Add(BuildCreditCard(), _userDetails);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    if (txtReason.Text.Length < 15)
                        throw new Exception(StringConstants.ERROR_CARD_INVALID_REASON);

                    POSValidation.Add(AppController.ActiveUser, 0, String.Format(StringConstants.VALIDATION_CHECK_CARD, 
                        _userDetails.ID, Shared.Utilities.MaximumLength(_userDetails.UserName, 80), txtReason.Text));

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
        }

        private DateTime GetDateFrom()
        {
            int year = Shared.Utilities.StrToInt(cmbFromYear.Items[cmbFromYear.SelectedIndex].ToString(), 2220);
            int month = Shared.Utilities.StrToInt(cmbFromMonth.Items[cmbFromMonth.SelectedIndex].ToString(), 12);

            return (new DateTime(year, month, 28));
        }

        private DateTime GetDateTo()
        {
            int year = Shared.Utilities.StrToInt(cmbToYear.Items[cmbToYear.SelectedIndex].ToString(), 2220);
            int month = Shared.Utilities.StrToInt(cmbToMonth.Items[cmbToMonth.SelectedIndex].ToString(), 12);

            return (new DateTime(year, month, 28));
        }

        private CreditCard BuildCreditCard()
        {
            CreditCard Result;

            string cardType = cmbCardType.Items[cmbCardType.SelectedIndex].ToString().Replace(StringConstants.SYMBOL_SPACE, String.Empty);
            string last4 = txtCardNumber.Text.Substring(txtCardNumber.Text.Length -4);
            DateTime dateFrom = GetDateFrom();
            DateTime dateTo = GetDateTo();
            Shared.AcceptedCreditCardTypes cardTypeEnum = (Shared.AcceptedCreditCardTypes)Enum.Parse(typeof(Shared.AcceptedCreditCardTypes), cardType);
            Result = new CreditCard(-1, _userDetails, SharedBase.Utils.StringCipher.Encrypt(txtCardNumber.Text,
                StringConstants.CREDIT_CARD_PASSPHRASE), last4, dateFrom.ToString(StringConstants.CREDIT_CARD_DATE_FORMAT),
                dateTo.ToString(StringConstants.CREDIT_CARD_DATE_FORMAT), _userDetails.UserName, txtLast3Digits.Text, cardTypeEnum);

            return (Result);
        }

        #endregion Private Methods
    }
}
