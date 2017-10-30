using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.Utils;
using Library.BOL.CashDrawer;
using Library.BOL.ValidationChecks;
using POS.Base.Classes;

using POS.CashManager.Classes;

namespace POS.CashManager.Forms
{
    public partial class CashDrawerForm : POS.Base.Forms.BaseForm
    {
        #region Constants

        private const int WIDTH_NOTES = 540;
        private const int WIDTH_NO_NOTES = 352;

        #endregion Constants

        #region Private Members

        private bool _allowBypass = true;
        private bool _isSpotcheck = false;

        private CashDenominations _currencyDenominations;

        private decimal _total = 0.00m;

        private CashDrawerType _cashDrawerType = CashDrawerType.Till;

        #endregion Private Members

        #region Constructors

        public CashDrawerForm(CashDrawerType drawerType, string title)
        {
            InitializeComponent();
            LoadCurrencyDenominations();

            _cashDrawerType = drawerType;
            Text = title;
            string[] items;

            switch (_cashDrawerType)
            {
                case CashDrawerType.PettyCash:
                    this.Width = WIDTH_NOTES;
                    items = StringConstants.CASH_DRAWER_CASH_ITEMS.Split(StringConstants.SYMBOL_RETURN.ToCharArray()[0]);
                    break;
                case CashDrawerType.Safe:
                    this.Width = WIDTH_NOTES;
                    items = StringConstants.CASH_DRAWER_SAFE_ITEMS.Split(StringConstants.SYMBOL_RETURN.ToCharArray()[0]);
                    break;
                case CashDrawerType.Till:
                    this.Width = WIDTH_NO_NOTES;
                    items = StringConstants.CASH_DRAWER_TILL_ITEMS.Split(StringConstants.SYMBOL_RETURN.ToCharArray()[0]);
                    txtNotes.Visible = false;
                    break;
                default:
                    throw new Exception(StringConstants.ERROR_INVALID_TYPE);
            }

            for (int i = 0; i < items.Length; i++)
                cmbCheckType.Items.Add(items[i]);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            switch (_cashDrawerType)
            {
                case CashDrawerType.PettyCash:
                    HelpTopic = POS.Base.Classes.HelpTopics.CashManagerPettyCash;
                    break;
                case CashDrawerType.Safe:
                    HelpTopic = POS.Base.Classes.HelpTopics.CashManagerSafe;
                    break;
                case CashDrawerType.Till:
                    HelpTopic = POS.Base.Classes.HelpTopics.CashManagerTill;
                    break;
            }
        }


        #endregion Overridden Methods

        #region Static Methods

        public static void StartOfDayChecks()
        {
            CashDrawerForm form = new CashDrawerForm(CashDrawerType.Till, LanguageStrings.AppCashDrawerTillStartOfDay);

            try
            {
                form.cmbCheckType.SelectedIndex = 0;
                form.cmbCheckType.Enabled = false;
                form._allowBypass = false;
                form.btnCancel.Enabled = false;
                form.ShowDialog();
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }

        public static bool SpotCheck(Form parent, bool allowByPass)
        {
            CashDrawerForm form = new CashDrawerForm(CashDrawerType.Till, LanguageStrings.AppCashDrawerSpotCheckTill);
            try
            {
                form.cmbCheckType.SelectedIndex = 1;
                form.cmbCheckType.Enabled = false;
                form._allowBypass = allowByPass;
                form._isSpotcheck = true;
                form.ShowDialog(parent);

                return (form.DialogResult == DialogResult.OK);
            }
            finally
            {
                form.Dispose();
                form = null;
            }
        }

        #endregion Static Methods

        #region Private Methods

        private void LoadCurrencyDenominations()
        {
            _currencyDenominations = AppController.LocalCountry.CurrencyDenominations;

            foreach (CashDenomination denom in _currencyDenominations)
            {
                CashDrawerDenomination d = new CashDrawerDenomination(denom);
                d.OnValueChanged += denomination_OnValueChanged;
                panelDenominations.Controls.Add(d);
            }
        }

        private int GetDenominationCount(decimal linkValue)
        {
            int Result = 0;

            foreach (CashDrawerDenomination denom in panelDenominations.Controls)
            {
                if (denom.Denomination.LinkValue == linkValue)
                {
                    Result = denom.UserQuantity;
                    break;
                }
            }

            return (Result);
        }

        private decimal GetDenominationValue(decimal value)
        {
            decimal Result = 0.00m;

            foreach (CashDrawerDenomination denom in panelDenominations.Controls)
            {
                if (denom.Denomination.Value == value)
                {
                    Result = denom.UserQuantity * value;
                    break;
                }
            }

            return (Result);
        }

        private void denomination_OnValueChanged(object sender, EventArgs e)
        {
            _total = 0.00m;

            foreach (CashDenomination denom in _currencyDenominations)
            {
                _total += GetDenominationValue(denom.Value);
            }

            lblTotal.Text = Library.Utils.SharedUtils.FormatMoney(_total, AppController.LocalCurrency);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbCheckType.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppCashDrawerCheckType, LanguageStrings.AppCashDrawerCheckTypeSelect);
                cmbCheckType.DroppedDown = true;
                return;
            }

            if (_total <= 0.00m && !_allowBypass && AppController.LocalSettings.CashDrawerForceChecks && 
                !AppController.LocalSettings.CashDrawerBypassStartOfDay &&
                !CashDrawers.StartOfDayComplete(_cashDrawerType))
            {
                ShowError(LanguageStrings.AppCashDrawerStartOfDay, LanguageStrings.AppCashDrawerStartOfDayRequired);
                return;
            }

            bool validateNotes = false;
            bool completeAddToSafeAmount = false;
            string checkType = String.Empty;

            switch (cmbCheckType.SelectedItem.ToString())
            {
                case StringConstants.CASH_DRAWER_TYPE_START_OF_DAY:
                    checkType = StringConstants.CASH_DRAWER_START_OF_DAY;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_ROUTINE_CHECK:
                    checkType = StringConstants.CASH_DRAWER_CHECK;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_MOVED_TO_SAFE:
                    checkType = StringConstants.CASH_DRAWER_SAFE_IN;
                    completeAddToSafeAmount = true;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_ADD_CASH:
                    checkType = StringConstants.CASH_DRAWER_CASH_ADD;
                    validateNotes = true;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_REMOVE_CASH:
                    checkType = StringConstants.CASH_DRAWER_CASH_REMOVE;
                    validateNotes = true;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_PURCHASE:
                    checkType = StringConstants.CASH_DRAWER_PURCHASE;
                    validateNotes = true;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_BANK:
                    checkType = StringConstants.CASH_DRAWER_BANK;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_END_OF_DAY:
                    checkType = StringConstants.CASH_DRAWER_END_OF_DAY;
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (validateNotes && txtNotes.Visible && String.IsNullOrEmpty(txtNotes.Text))
            {
                ShowError(LanguageStrings.AppNotes, LanguageStrings.AppCashDrawerEnterNotes);
                return;
            }


            CashDrawers.Submit(AppController.ActiveUser, 
                checkType, _cashDrawerType, txtNotes.Text,
                GetDenominationCount(500.00m), GetDenominationCount(100.00m),
                GetDenominationCount(50.00m), GetDenominationCount(20m),
                GetDenominationCount(10.00m), GetDenominationCount(5.00m),
                GetDenominationCount(2.00m), GetDenominationCount(1.00m),
                GetDenominationCount(0.50m), GetDenominationCount(0.20m),
                GetDenominationCount(0.10m), GetDenominationCount(0.05m),
                GetDenominationCount(0.02m), GetDenominationCount(0.01m));

            if (completeAddToSafeAmount)
            {
                CashDrawers.Submit(AppController.ActiveUser, StringConstants.CASH_DRAWER_CASH_ADD, CashDrawerType.Safe,
                    String.Format(LanguageStrings.AppCashDrawerAutoAddSafe, _cashDrawerType.ToString()),
                    GetDenominationCount(500.00m), GetDenominationCount(100.00m),
                    GetDenominationCount(50.00m), GetDenominationCount(20),
                    GetDenominationCount(10.00m), GetDenominationCount(5.00m),
                    GetDenominationCount(2.00m), GetDenominationCount(1.00m),
                    GetDenominationCount(0.50m), GetDenominationCount(0.20m),
                    GetDenominationCount(0.10m), GetDenominationCount(0.05m),
                    GetDenominationCount(0.02m), GetDenominationCount(0.01m));
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CashDrawerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_total <= 0.00m && !_allowBypass && AppController.LocalSettings.CashDrawerForceChecks &&
                !AppController.LocalSettings.CashDrawerBypassStartOfDay &&
                !CashDrawers.StartOfDayComplete(_cashDrawerType))
            {
                ShowError(LanguageStrings.AppCashDrawerStartOfDay, LanguageStrings.AppCashDrawerMandatory);
                e.Cancel = true;
            }
            else if (!_allowBypass && _total <= 0.00m)
            {
                ShowError(LanguageStrings.AppCashDrawerCheck, LanguageStrings.AppCashDrawerBypassFail);
                e.Cancel = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isSpotcheck && _total <= 0.00m)
            {
                POSValidation.Add(AppController.ActiveUser, ValidationReasons.CashDrawerSpotCheck, String.Empty);
            }

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CashDrawerForm_Shown(object sender, EventArgs e)
        {
            if (cmbCheckType.Enabled)
            {
                cmbCheckType.Focus();
                cmbCheckType.DroppedDown = true;
            }
        }

        private void cmbCheckType_Format(object sender, ListControlConvertEventArgs e)
        {
            if (cmbCheckType.SelectedItem == null)
                return;

            switch (cmbCheckType.SelectedItem.ToString())
            {
                case StringConstants.CASH_DRAWER_TYPE_START_OF_DAY:
                    e.Value = LanguageStrings.AppCashDrawerTypeStartOfDay;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_ROUTINE_CHECK:
                    e.Value = LanguageStrings.AppCashDrawerTypeRoutineCheck;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_MOVED_TO_SAFE:
                    e.Value = LanguageStrings.AppCashDrawerTypeMovedToSafe;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_ADD_CASH:
                    e.Value = LanguageStrings.AppCashDrawerTypeAddCash;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_REMOVE_CASH:
                    e.Value = LanguageStrings.AppCashDrawerTypeRemoveCash;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_PURCHASE:
                    e.Value = LanguageStrings.AppCashDrawerTypePurchase;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_BANK:
                    e.Value = LanguageStrings.AppCashDrawerTypeBank;
                    break;
                case StringConstants.CASH_DRAWER_TYPE_END_OF_DAY:
                    e.Value = LanguageStrings.AppCashDrawerTypeEndOfDay;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Private Methods
    }
}
