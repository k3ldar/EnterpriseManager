using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Library.Utils;
using Library.BOL.Countries;
using POS.Base.Classes;

namespace POS.Till.Controls
{
    public partial class CashTill : SharedControls.BaseControl
    {
        #region Private Members

        private decimal _totalDue;
        private bool hasDecimal = false;
        private bool inputStatus = true;

        #endregion Private Members

        #region Constructors

        public CashTill()
        {
            InitializeComponent();

            if (!DesignMode)
                lblChangeDue.Text = Library.Utils.SharedUtils.FormatMoney(0.0m, AppController.LocalCurrency);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAmountDue.Text = Languages.LanguageStrings.AppAmountDue;
            lblChange.Text = Languages.LanguageStrings.AppChangeDue;
            lblAmountTendered.Text = Languages.LanguageStrings.AppAmountTendered;

            if (!DesignMode)
            {
                try
                {
                    btn10.Text = LibUtils.RemovePence(Library.Utils.SharedUtils.FormatMoney(10.0m, AppController.LocalCurrency), culture);
                    btn20.Text = LibUtils.RemovePence(Library.Utils.SharedUtils.FormatMoney(20.0m, AppController.LocalCurrency), culture);
                    btn40.Text = LibUtils.RemovePence(Library.Utils.SharedUtils.FormatMoney(40.0m, AppController.LocalCurrency), culture);
                    btn50.Text = LibUtils.RemovePence(Library.Utils.SharedUtils.FormatMoney(50.0m, AppController.LocalCurrency), culture);
                    btn100.Text = LibUtils.RemovePence(Library.Utils.SharedUtils.FormatMoney(100.0m, AppController.LocalCurrency), culture);
                }
                catch {}
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void RefreshChangeDue(bool UpdateText)
        {
            if (!String.IsNullOrEmpty(txtTendered.Text))
            {
                decimal total = Convert.ToDecimal(txtTendered.Text) - _totalDue;
                lblChangeDue.Text = Library.Utils.SharedUtils.FormatMoney(total < 0.00m ? 0.00m : total, AppController.LocalCurrency);
            }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string btnName = btn.Name;
            double amount = 0;

            switch (btnName)
            {
                case StringConstants.PAYMENT_BUTTON_0:
                    amount = 0;
                    break;
                case StringConstants.PAYMENT_BUTTON_1:
                    amount = 1;
                    break;
                case StringConstants.PAYMENT_BUTTON_2:
                    amount = 2;
                    break;
                case StringConstants.PAYMENT_BUTTON_3:
                    amount = 3;
                    break;
                case StringConstants.PAYMENT_BUTTON_4:
                    amount = 4;
                    break;
                case StringConstants.PAYMENT_BUTTON_5:
                    amount = 5;
                    break;
                case StringConstants.PAYMENT_BUTTON_6:
                    amount = 6;
                    break;
                case StringConstants.PAYMENT_BUTTON_7:
                    amount = 7;
                    break;
                case StringConstants.PAYMENT_BUTTON_8:
                    amount = 8;
                    break;
                case StringConstants.PAYMENT_BUTTON_9:
                    amount = 9;
                    break;
                case StringConstants.PAYMENT_BUTTON_10:
                    amount = 10.00;
                    break;
                case StringConstants.PAYMENT_BUTTON_20:
                    amount = 20.00;
                    break;
                case StringConstants.PAYMENT_BUTTON_40:
                    amount = 40.00;
                    break;
                case StringConstants.PAYMENT_BUTTON_50:
                    amount = 50.0;
                    break;
                case StringConstants.PAYMENT_BUTTON_100:
                    amount = 100.00;
                    break;
                default:
                    amount = 0;
                    break;
            }

            //Check the inputStatus
            if (inputStatus)
            {
                if (!hasDecimal && sender == btnStop)
                {
                    //Check to make sure the length is > than 1
                    //Dont want user to add decimal as first character
                    if (txtTendered.Text.Length != 0)
                    {
                        //Make sure 0 isnt the first number
                        if (txtTendered.Text != StringConstants.SYMBOL_ZERO)
                        {
                            //It met all our requirements so add the zero
                            txtTendered.Text += StringConstants.SYMBOL_FULL_STOP;
                            //Toggle the flag to true (only 1 decimal per calculation)
                            hasDecimal = true;
                        }
                    }
                    else
                    {
                        //Since the length isnt > 1
                        //make the text 0.
                        txtTendered.Text = StringConstants.SYMBOL_ZERO_STOP;
                    }
                }
                else
                {
                    if (hasDecimal)
                    {
                        string[] parts = txtTendered.Text.Split(StringConstants.SYMBOL_FULL_STOP_CHAR);

                        if (parts[1].Length < 2)
                            txtTendered.Text += amount.ToString();

                        if (amount > 9)
                            txtTendered.Text = Convert.ToString(Convert.ToDouble(txtTendered.Text == String.Empty ? StringConstants.SYMBOL_ZERO : txtTendered.Text) + amount);
                    }
                    else
                    {
                        if (amount > 9)
                            txtTendered.Text = Convert.ToString(Convert.ToDouble(txtTendered.Text == String.Empty ? StringConstants.SYMBOL_ZERO : txtTendered.Text) + amount);
                        else
                            txtTendered.Text += amount.ToString();
                    }
                }
            }
            else
            {
                //Value is False
                //Set the value to the value of the button
                txtTendered.Text = amount.ToString();
                //Toggle inputStatus to True
                inputStatus = true;
            }

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) 
                RefreshChangeDue(true);
        }

        public decimal TotalDue
        {
            get
            {
                return (_totalDue);
            }

            set
            {
                _totalDue = value;

                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    lblAmountDueTotal.Text = Library.Utils.SharedUtils.FormatMoney(_totalDue, AppController.LocalCurrency);
                    RefreshChangeDue(true);
                }
            }
        }

        private void txtTendered_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtTendered.Text) || !txtTendered.Text.Contains(StringConstants.SYMBOL_FULL_STOP))
                    hasDecimal = false;

                //_tendered = Convert.ToDouble(txtTendered.Text);
                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) 
                    RefreshChangeDue(false);
            }
            catch (Exception err)
            {
                if (err.Message == StringConstants.ERROR_INPUT_STRING)
                    RefreshChangeDue(true);
                else
                    throw;
            }
        }

        private void txtTendered_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void rbReplaceTotal_CheckedChanged(object sender, EventArgs e)
        {
            //_stopPressed = false;
        }

        private void txtTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains(StringConstants.SYMBOL_FULL_STOP))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                e.Handled = !StringConstants.SPLIT_PAYMENT_VALID_CHARS.Contains(e.KeyChar.ToString());
        }

        #endregion Private Methods
    }
}
